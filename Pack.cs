using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_Packer
{
    public class Pack
    {
        private string _packName;

        public string PackName
        {
            get { return _packName; }
            set { _packName = value; }
        }

        private string _packDesc;

        public string PackDesc
        {
            get { return _packDesc; }
            set { _packDesc = value; }
        }


        //UUID for Resources
        private string _uu1;
        public string UUID1
        {
            get { return _uu1; }
            set { _uu1 = value; }
        }

        //UUID for Behaviors
        private string _uu2;
        public string UUID2
        {
            get { return _uu2; }
            set { _uu2 = value; }
        }

        //UUID for linking
        private string _uu3;
        public string UUID3
        {
            get { return _uu3; }
            set { _uu3 = value; }
        }

        private int _rMan;

        public int RMan
        {
            get { return _rMan; }
            set { _rMan = value; }
        }


        public void NewPack(string name, string desc)
        {
            //sets pack variables
            PackName = name;
            PackDesc = desc;
            UUID1 = Guid.NewGuid().ToString();
            UUID2 = Guid.NewGuid().ToString();
            UUID3 = Guid.NewGuid().ToString();

            //create resource pack manifest

            //create behavior pack manifest
        }
    }
}
