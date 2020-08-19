using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_Packer
{
    public class Items
    {
        //lists for all item data
        public List<string> names = new List<string>();
        public List<string> textures = new List<string>();
        public List<string> alldata = new List<string>();
        public List<List<string>> allTags = new List<List<string>>();

        //string for current item
        public string name { get; set; }
        public string texture { get; set; }
        public string data { get; set; }
        public string tags { get; set; }

        //Populates all lists for vanilla items if show == true
        // use Items(false) to use for single item
        public Items(bool show = true)
        {
            if(show == true)
            {
                PopulateVanilla();
            }
        }


        public void PopulateVanilla()
        {
            string texturedir = "../../Resources/Vanilla/Vanilla_Resource_Pack_1.14.30/textures/items/";
            string itemtexturedb = "../../Resources/Vanilla/Vanilla_Resource_Pack_1.14.30/textures/item_texture.json";

            //json from item textures
            string texjson = System.IO.File.ReadAllText(itemtexturedb);
            dynamic texturelist = JObject.Parse(texjson);


            //json from alias list
            string aliasjson = System.IO.File.ReadAllText("../../Resources/aliases.json");
            dynamic aliaslist = JObject.Parse(aliasjson);


            dynamic texturedata = texturelist.texture_data;
            foreach (dynamic type in texturedata)
            {
                foreach (dynamic alltextures in type)
                {
                    foreach (dynamic texture in alltextures)
                    {
                        string itemname = texture.Value.ToString().Replace("textures/items/", "");
                        itemname = itemname.Replace("\r", "").Replace("[", "").Replace("\n", "").Replace("]", "").Replace("\"","").Replace(" ", "");
                        if (itemname.Split(',').Length > 1)
                        {
                            foreach (string item in itemname.Split(','))
                            {
                                this.names.Add(aliaslist["Items"][item]["alias"][0].ToString());
                                this.textures.Add(texturedir + item + ".png");
                                List<string> tags = new List<string>();
                                for (int i = 0; i < aliaslist["Items"][item]["tags"].Count; i++)
                                {
                                    tags.Add(aliaslist["Items"][item]["tags"][i].ToString());
                                }
                                this.allTags.Add(tags);
                            }
                        }
                        else
                        {
                            this.names.Add(aliaslist["Items"][itemname]["alias"][0].ToString());
                            this.textures.Add(texturedir + itemname + ".png");
                            List<string> tags = new List<string>();
                            for (int i = 0; i < aliaslist["Items"][itemname]["tags"].Count; i++)
                            {
                                tags.Add(aliaslist["Items"][itemname]["tags"][i].ToString());
                            }
                            this.allTags.Add(tags);
                        }
                    }
                }
            }
        }
    }
}
