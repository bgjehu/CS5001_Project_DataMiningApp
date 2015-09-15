using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS5001_Data_Mining_Project.Classes
{
    class Item
    {
        public List<Condition> Conditions;
        public int Frequency;
        public Item(List<Condition> conditions, int frequency)
        {
            Conditions = conditions;
            Frequency = frequency;
        }
        public Condition Condition()
        {
            if (Conditions.Count == 1) { return Conditions[0]; }
            else { throw new Exception("Error retrieving condition: There is more than one condition"); }
        }
        public Condition ConditionDeepCopy()
        {
            if (Conditions.Count == 1) { return Conditions[0].DeepCopy(); }
            else { throw new Exception("Error retrieving condition: There is more than one condition"); }
        }
        public override string ToString()
        {
            string str = "";
            try
            {
                foreach (var condition in Conditions)
                {
                    if (condition != Conditions.Last()) { str += condition.ToString() + ","; }
                    else { str += condition.ToString() + " : " + Frequency; }
                }
                return str;
            }
            catch (Exception)
            {
                return base.ToString();
            }
        }
        public Item DeepCopy()
        {
            List<Condition> conditions = new List<Condition>();
            foreach (var condition in Conditions)
            {
                conditions.Add(condition.DeepCopy());
            }
            return new Item(conditions, Frequency);
        }
    }
    class Condition
    {
        public string Attribute;
        public string Value;
        public Condition(string attribute, string value)
        {
            Attribute = attribute;
            Value = value;
        }
        public override string ToString()
        {
            return Attribute + " = " + Value;
        }
        public List<Condition> ToList()
        {
            List<Condition> condition = new List<Condition>();
            condition.Add(new Condition(Attribute, Value));
            return condition;
        }
        public Condition DeepCopy()
        {
            return new Condition(Attribute, Value);
        }
    }
}
