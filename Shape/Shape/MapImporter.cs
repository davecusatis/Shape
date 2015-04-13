using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Shape
{
    class MapImporter
    {
        private FileStream SourceFile;

        public MapImporter()
        {
            string filename = @"C:\Users\yung\Documents\GitHub\Shape\Shape\Shape\Content\test.txt";
            using(SourceFile = File.OpenRead(filename))
            {

            }
        }
    }
}
