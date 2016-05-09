using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Triangle
    {
        public int[] sides;
    
        public Triangle(int side1, int side2, int side3)
        {
            sides = new int[] {side1, side2, side3};

            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                throw new System.ArgumentException("Triangle sides must have a positive length");
            }
        }
    
        public string Type()
        {
            if (IsEquilateral()) 
            {
                return "Equilateral";
            } 
            else if (IsIsosceles()) 
            {
                return "Isosceles";
            }
            else
            {
                return "Scalene";
            }
        }
    
        private bool IsEquilateral()
        {
            return (sides[0] == sides[1]) && (sides[0] == sides[2]);
        } 
    
        private bool IsIsosceles()
        {
            return (sides[0] == sides[1]) || (sides[0] == sides[2]) || (sides[1] == sides[2]);
        }
    }
}


