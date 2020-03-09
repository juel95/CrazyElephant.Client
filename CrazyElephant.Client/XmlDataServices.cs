using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyElephant.Client.Models;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Reflection;

namespace CrazyElephant.Client.Services
{
    class XmlDataServices : IDataService
    {
        public List<Dish> GetAllDishes()
        {
            List<Dish> dishList = new List<Dish>();
            string xmlFileName = @"D:\Revit开发工作\MVVM\CrazyElephant.Client\CrazyElephant.Client\Data\DataXml.xml";
            XDocument xmlDoc = XDocument.Load(xmlFileName);
            var dishes = xmlDoc.Descendants("Dish");
            foreach(var s in dishes)
            {
                Dish d = new Dish()
                {
                    Name = s.Element("Name").Value,
                    Category= s.Element("Category").Value,
                    Comment= s.Element("Comment").Value,
                    Score=Convert.ToDouble(s.Element("Score").Value)
                };
                dishList.Add(d);
            }

            return dishList;
        }
    }
}
