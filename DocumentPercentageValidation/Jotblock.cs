using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentPercentageValidation
{
    public class Jotblock
    {
        public string name{get; set;}
        public string xPos;
        public string yPos;
        public string width;
        public string height;
        public string instruction;

        public Jotblock(string name, float xPos, float yPos, float width, float height,string instruction)
        {
            this.name = name;
            this.xPos = xPos.ToString();
            this.yPos = yPos.ToString();
            this.width = width.ToString();
            this.height = height.ToString();
            this.instruction = instruction;
        }
        public Jotblock()
        {
            this.name = "";
            this.xPos = null;
            this.yPos = null;
            this.width = null;
            this.height = null;
            this.instruction = "";
        }
    }
}
