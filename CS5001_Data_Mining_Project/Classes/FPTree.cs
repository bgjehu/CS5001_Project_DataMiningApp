using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS5001_Data_Mining_Project.Classes
{
    class FPTree
    {
        public Arff Source;
        public int MinimumCoverage;
        public int MaximumItemSetSize;
        public double MinimumAccuracy;
        public int ResultSize;
        public FPTreeNode Root;

        public FPTree(Arff source, int minimumCoverage, int maximumItemSetSize, double minimumAccuracy, int resultSize)
        {
            //load input
            Source = source;
            MinimumCoverage = minimumCoverage;
            MaximumItemSetSize = maximumItemSetSize;
            MinimumAccuracy = minimumAccuracy;
            ResultSize = resultSize;

            //initiate Root
            Root = new FPTreeNode();

            
            

            //local variables
            ItemSet ItemSet;
            ItemSet HighFrequencyOneItemSet;
            FPTreeTable FPTreeTable;
            

            //get the size 1 ItemSet
            ItemSet = new ItemSet(Source);

            //initiate High Frequency 1-item set
            HighFrequencyOneItemSet = ItemSet.DeepCopy();
            HighFrequencyOneItemSet.MeetMinimumCoverage(MinimumCoverage);
            HighFrequencyOneItemSet.OrderByFrequencyDescending();

            //initiate FPTreeTable
            FPTreeTable = new FPTreeTable(Source, HighFrequencyOneItemSet);

            //build FPTree
            BuildFPTreeFromRoot(FPTreeTable);
            




        }
        private void BuildFPTreeFromRoot(FPTreeTable table)
        {
            //pick first items from the table
            var FirstItemsQuery = from record in table.Records
                                  group record.Items[0].Condition by record.Items[0].Condition.ToString() into g
                                  select g.ToList();


            List<FPTreeTableRecordItem> FirstItems = new List<FPTreeTableRecordItem>();
            foreach (var firstItem in FirstItemsQuery)
            {
                FirstItems.Add(new FPTreeTableRecordItem(firstItem[0], firstItem.Count()));
            }
            FirstItems = FirstItems.OrderByDescending(i => i.Frequency).ToList();
            //put them into tree
            Root.AddChildren(FirstItems);

            




        }
        
    }

    class FPTreeNode
    {
        public FPTreeTableRecordItem Item;
        public FPTreeNode Parent;
        public List<FPTreeNode> Children;
        public FPTreeNode()
        {
            Item = null;
            Parent = null;
            Children = new List<FPTreeNode>();
        }
        public FPTreeNode(FPTreeTableRecordItem item, FPTreeNode parent)
        {
            Item = item;
            Parent = parent;
            Children = new List<FPTreeNode>();
        }
        public void AddChild(FPTreeTableRecordItem item)
        {
            this.Children.Add(new FPTreeNode(item, this));
        }
        public void AddChildren(List<FPTreeTableRecordItem> items)
        {
            foreach (var item in items)
            {
                this.Children.Add(new FPTreeNode(item, this));
            }
        }
        public override string ToString()
        {
            string str = "";
            if (Item == null) { str = "root"; }
            else { str = Item.Condition + " : " + Item.Frequency; }
            if (str == "") { return base.ToString(); }
            else { return str; }
        }
    }


    class FPTreeTable
    {
        public List<FPTreeTableRecord> Records;
        public FPTreeTable(Arff source, ItemSet itemSet)
        {
            if (itemSet.Size() == 1)
            {
                Records = new List<FPTreeTableRecord>();
                for (int i = 0; i < source.Count(); i++)
                {
                    //for every record
                    FPTreeTableRecord Record = new FPTreeTableRecord();
                    foreach (var item in itemSet.Items)
                    {
                        if (source.RecordContains(i, item))
                        {
                            Record.Add(new FPTreeTableRecordItem(item));
                        }
                    }
                    if (Record.Count() != 0) { Records.Add(Record); }
                }
            }
            else
            { throw new Exception("Error creating FPTreeTable: invalid itemset, only 1-item itemset allowed"); }
        }
        public override string ToString()
        {
            string str = "";
            foreach (var record in Records)
            {
                str += record.ToString() + "\r\n";
            }
            if (str != "") { return str; }
            else { return base.ToString(); }
        }
    }
    class FPTreeTableRecord 
    {
        public List<FPTreeTableRecordItem> Items;
        public FPTreeTableRecord()
        {
            Items = new List<FPTreeTableRecordItem>();
        }
        public void Add(FPTreeTableRecordItem item)
        {
            if (Items != null) { Items.Add(item); }
            else { throw new Exception("Error adding FPTreeTableRecordItem: Record is not itiated"); }
        }
        public int Count()
        {
            return Items.Count;
        }
        public override string ToString()
        {
            string str = "";
            foreach (var item in Items)
            {
                if (item != Items.Last()) { str += item.ToString() + ", "; }
                else { str += item.ToString(); }
            }
            if (str != "") { return str; }
            else { return base.ToString(); }
        }
    }
    class FPTreeTableRecordItem
    {
        public Condition Condition;
        public int Frequency;
        public FPTreeTableRecordItem(Item item)
        {
            Condition = item.ConditionDeepCopy();
            Frequency = item.Frequency;
        }
        public FPTreeTableRecordItem(Condition condition, int frequency)
        {
            Condition = condition;
            Frequency = frequency;
        }
        public override string ToString()
        {
            return Condition.ToString();
        }
    }
       
}
