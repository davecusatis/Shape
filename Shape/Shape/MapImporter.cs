using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace Shape
{
    class MapImporter
    {
        private IEnumerable<string> SourceFileLines;

        public MapImporter()
        {
            string filename = @"\Content\test.txt";
            SourceFileLines = File.ReadLines(filename);
        }

        public MapImporter(string filename)
        {
            SourceFileLines = File.ReadLines(filename);
        }

        /// <summary>
        /// Creates and returns a Grid object based on a previously loaded file.
        /// </summary>
        /// <returns>Grid object with all shapes loaded</returns>
        /// 
        /// TODO: remove string dependencies, enum possibly?
        public Grid LoadMap()
        {
            if(SourceFileLines == null)
            {
                Console.Write("Bogus fileloaded");
                return null;
            }

            Grid grid = new Grid();

            foreach (var line in SourceFileLines)
            {
                string[] words = line.Split(' ');
                string[] posCoords;
                string[] sizeCoords;
                Vector3 position;
                Vector3 size;
                if(words[0] == "start")
                {
                    // TODO: grid class needs to support initialize player start position
                }
                if(words[0] == "green")
                {
                    posCoords = words[1].Split(',');
                    posCoords[0] = posCoords[0].Substring(1);           // index 0 = "(xxx", want to extract the int
                    posCoords[2] = posCoords[2].Substring(0, posCoords[2].Length - 1);

                    sizeCoords = words[2].Split(',');
                    sizeCoords[0] = sizeCoords[0].Substring(1);
                    sizeCoords[2] = sizeCoords[2].Substring(0, sizeCoords[2].Length - 1);

                    position = new Vector3(float.Parse(posCoords[0]), float.Parse(posCoords[1]), float.Parse(posCoords[2]));
                    size = new Vector3(float.Parse(sizeCoords[0]), float.Parse(sizeCoords[1]), float.Parse(sizeCoords[2]));

                    grid.AddShape(new Grid.GreenBlock(position, size));
                }
                if(words[0] == "red")
                {
                    posCoords = words[1].Split(',');
                    posCoords[0] = posCoords[0].Substring(1);           // index 0 = "(xxx", want to extract the int
                    posCoords[2] = posCoords[2].Substring(0, posCoords[2].Length - 1);

                    sizeCoords = words[2].Split(',');
                    sizeCoords[0] = sizeCoords[0].Substring(1);
                    sizeCoords[2] = sizeCoords[2].Substring(0, sizeCoords[2].Length - 1);

                    position = new Vector3(float.Parse(posCoords[0]), float.Parse(posCoords[1]), float.Parse(posCoords[2]));
                    size = new Vector3(float.Parse(sizeCoords[0]), float.Parse(sizeCoords[1]), float.Parse(sizeCoords[2]));

                    grid.AddShape(new Grid.RedBlock(position, size));
                }
                if(words[0] == "end")
                {
                    // TODO: grid class support for ending position
                }

            }

            return grid;
        }
    }
}
