using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS5001_Data_Mining_Project.Classes
{
    class ItemSet
    {
        public List<Item> Items;
        public Arff Source;
        public ItemSet(Arff source)
        {
            Source = source;
            Items = new List<Item>();


            foreach (var attribute in source.Attributes)
            {
                var valueList = attribute.Data.Select(i => i.Value).OrderBy(i=>i).GroupBy(i=>i);
                foreach (var value in valueList)
                {
                    Items.Add(new Item(new Condition(attribute.AttributeName, value.Key).ToList(), -1));
                }
            }
            UpdateItemsFrequency();
            
        }
        public ItemSet DeepCopy()
        {
            return new ItemSet(new Arff(Source.Source));
        }
        #region Report Methods
        public override string ToString()
        {
            string str = "";
            try
            {
                foreach (var item in Items)
                {
                    str += item.ToString() + "\r\n";
                }
                return str;
            }
            catch (Exception)
            {
                return base.ToString();
            }
        }
        public int Size() 
        {
            if (Items != null) { return Items[0].Conditions.Count; }
            else { return -1; }
        }
        public int Count()
        {
            if (Items != null) { return Items.Count; }
            else { return -1; }
        }
        #endregion

        #region Utility Methods
        public void UpdateItemsFrequency()
        {
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    item.Frequency = Source.CountFrequency(item);
                }
            }
        }
        public void MeetMinimumCoverage(int minimumCoverage)
        {
            Items.RemoveAll(i => i.Frequency < minimumCoverage);
        }
        public void OrderByFrequency()
        {
            Items = Items.OrderBy(i => i.Frequency).ToList();
        }
        public void OrderByFrequencyDescending()
        {
            Items = Items.OrderByDescending(i => i.Frequency).ToList();
        }


        #endregion


    }
    
}
