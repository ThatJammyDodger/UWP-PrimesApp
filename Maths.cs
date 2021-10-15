using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesApp
{
    static class Maths
    {
        //PROPERTIES

        static public int Maximum
        {
            get; set;
        }
        static public int Mode
        {
            get; set;
        }

        static public List<int> Final = new List<int>();

        static public bool DefaultValuesUsed
        {
            get; set;
        }


        //METHODS

        static private List<int> Mode1()
        {

            Final.Add(2);
            int counter = 0;
            int i = 3;


            while (counter < (Maximum - 1))
            {
                bool Prime = true;
                foreach (int a in Final)
                {
                    if (i % a == 0)
                    {
                        Prime = false;
                        break;
                    }
                }
                if (Prime)
                {
                    Final.Add(i);
                    counter++;
                }
                i += 2;
            }

            return Final;

        }

        static private List<int> Mode2()
        {

            Final.Add(2);

            for (int i = 3; i <= Maximum; i += 2)
            {
                bool prime = true;
                foreach (int a in Final)
                {
                    if (i % a == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime)
                {
                    Final.Add(i);
                }
            }



            return Final;
        }


        static public string ReturnModeX()
        {
            Final.Clear();

            if (DefaultValuesUsed)
            {
                Mode = 2;
                Maximum = 1000;
            }

            List<int> tempList = new List<int>();

            if (Mode == 1)
            {
                tempList = Mode1();
            }
            else if (Mode == 2)
            {
                tempList = Mode2();
            }

            string FinalReturn = "";

            foreach (int x in tempList)
            {
                FinalReturn += $"{x}\t";
            }
            return FinalReturn;
        }
    }
}
