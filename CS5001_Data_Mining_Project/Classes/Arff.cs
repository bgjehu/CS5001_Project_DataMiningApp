using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS5001_Data_Mining_Project.Classes
{
    enum AttributeType
    {
        real,
        integer,
        nominal
    }
    class Arff
    {
        public string RelationName;
        public List<Attribute> Attributes;
        public string Source;
        
        public Arff(string source)
        {
            //try
            //{
                //initiate member variables
                RelationName = "";
                Attributes = new List<Attribute>();
                Source = source;


                //temp variable
                string[] splitKeywords = { " ", "\t", "\r\n", "\n" };
                string attributeSource = "";
                string dataSource = "";
                string[] attributeArray;
                string[] dataArray;
                List<Attribute> attributes = new List<Attribute>();
                string relationName = "";


                #region Trimming Source
                //unify keyword: @relation @attribute @data
                source = source.Replace("@RELATION", "@relation").Replace("@Relation", "@relation");
                source = source.Replace("@ATTRIBUTE", "@attribute").Replace("@Attribute", "@attribute");
                source = source.Replace("@DATA", "@data").Replace("@Data", "@data");

                //unify <EOL>
                source = source.Replace("\n", "\r\n");
                source = source + "@end";
                #endregion
                #region Reading File
                //preparation
                relationName = GMs.ParseElement(source, "@relation ", "\r\n", false, false).Replace("\'", "").Replace("\"", "");
                attributeSource = GMs.ParseElement(source, "@attribute", "@data", true, false);
                dataSource = GMs.ParseElement(source, "@data", "@end", false, false);
                attributeArray = attributeSource.Split("\r\n".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                dataArray = dataSource.Split("\r\n".ToArray(), StringSplitOptions.RemoveEmptyEntries);

                //read attributes
                foreach (var attribute in attributeArray)
                {
                    //use this to handle comments in arff
                    if (attribute[0] != '%') 
                    {
                        string[] attributeElements = attribute.Split(splitKeywords, StringSplitOptions.RemoveEmptyEntries);
                        string attributeName = attributeElements[1];
                        AttributeType attributeType = AttributeType.nominal;
                        List<string> classes = null;
                        switch (attributeElements[2])
                        {
                            case "REAL":
                            case "Real":
                            case "read":
                            case "NUMERIC":
                            case "Numeric":
                            case "numeric":
                                attributeType = AttributeType.real;
                                break;
                            case "INTERGER":
                            case "Interger":
                            case "interger":
                                attributeType = AttributeType.integer;
                                break;
                            default:
                                attributeType = AttributeType.nominal;
                                //string[] tempSplitKeywords = { "{", "}", "\'", "\"", ",", "\r\n", "\n", "\t" };
                                //classes = attributeElements[2].Split(tempSplitKeywords, StringSplitOptions.RemoveEmptyEntries).ToList();
                                classes = new List<string>();
                                for (int i = 2; i < attributeElements.Count(); i++)
                                {
                                    classes.Add(attributeElements[i].Replace("{", "").Replace("}", "").Replace(",", "").Replace("\'", "").Replace("\"", ""));
                                }
                                break;
                        }
                        attributes.Add(new Attribute(attributeName, attributeType, classes));
                    }
                    
                }

                //read data
                foreach (var data in dataArray)
                {
                    //use this to handle comments in arff
                    if (data[0] != '%')
                    {
                        string[] tempSplitKeywords = { "\'", "\"", ",", "\r\n", "\n", "\t" };
                        string[] dataElements = data.Split(tempSplitKeywords, StringSplitOptions.RemoveEmptyEntries);
                        if (dataElements.Count() != attributes.Count) { throw new Exception("Error reading data source line by line: data element count no matching attribute count"); }
                        else
                        {
                            for (int i = 0; i < dataElements.Count(); i++)
                            {
                                attributes[i].Data.Add(new Data(dataElements[i]));
                            }
                        }
                    }
                }
                #endregion

                RelationName = relationName;
                Attributes = attributes;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error constructing instance of class Arff: {" + ex.Message + "}");
            //}
        }
        public string Cell(int indexOfAttribute, int indexOfData)
        {
            return Attributes[indexOfAttribute].Data[indexOfData].Value;
        }
        public string Cell(string attributeName, int indexOfData)
        {
            if (Attributes.Where(i => i.AttributeName == attributeName).Count() == 0) { throw new Exception("Error access cell: invalid attribute name"); }
            else 
            {
                return Attributes.Where(i => i.AttributeName == attributeName).Select(p => p.Data[indexOfData].Value).ToArray()[0];
            }
        }
        public int Count() 
        {
            return Attributes[0].Data.Count;
        }
        public Dictionary<string,string> Record(int indexOfRecord)
        {
            Dictionary<string, string> record = new Dictionary<string,string>();
            foreach (var attribute in Attributes)
            {
                record.Add(attribute.AttributeName,attribute.Data[indexOfRecord].Value);
            }
            return record;
        }
        public bool RecordContains(int indexOfRecord, Item item)
        {
            bool ContainsAll = true;
            foreach (var condition in item.Conditions)
            {
                if (!RecordContains(indexOfRecord, condition)) { ContainsAll = false; break; }
            }
            return ContainsAll;
        }
        public bool RecordContains(int indexOfRecord, Condition condition)
        {
            return Record(indexOfRecord)[condition.Attribute] == condition.Value;
        }
        public int CountFrequency(Item item)
        {
            int count = 0;
            for (int i = 0; i < Count(); i++)
            {
                bool conditionsAllTrue = true;
                foreach (var condition in item.Conditions)
                {
                    if (condition.Value != Cell(condition.Attribute, i)) { conditionsAllTrue = false; break; }
                }
                if (conditionsAllTrue) { count++; }
            }
            return count;   
        }
        public Arff DeepCopy()
        {
            return new Arff(Source);
        }
    }

    class Attribute
    {
        public string AttributeName;
        public AttributeType AttributeType;
        public List<string> Classes;
        public List<Data> Data;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="attributeType"></param>
        /// <param name="classes">if attribute type is not nominal, pass null value</param>
        public Attribute(string attributeName, AttributeType attributeType, List<string> classes)
        {
            AttributeName = attributeName;
            AttributeType = attributeType;
            if (AttributeType == AttributeType.nominal)
            {
                Classes = classes;
            }
            Data = new List<Data>();
        }

        public Attribute DeepCopy()
        {
            List<string> classes = new List<string>();
            List<Data> data = new List<Data>();
            foreach (var v in Classes)
            {
                classes.Add(v);
            }
            foreach (var v in Data)
            {
                data.Add(v.DeepCopy());
            }
            Attribute cpy = new Attribute(AttributeName, AttributeType, classes);
            cpy.Data.AddRange(data);
            return cpy;
        }


    }

    class Data
    {
        public string Value;         //always nominal form
        public double NumericForm_Double { get { return Convert.ToDouble(Value); } }
        public int NumericForm_Integer { get { return Convert.ToInt32(Value); } }
        public Data(string value)
        {
            Value = value;
        }

        public Data DeepCopy()
        {
            return new Data(Value);
        }
    }
}
