/***********************************************************
 **
 ** Tranix-design 
 **
 ** Author: 		Darius Korzeniewski
 ** Date:   		06.09.2016
 ** Filename:		program.cs
 ** Descirption:	Ist ein Programm das es gestatt 
 **			Woerter zu zaehlen
 ** 
 ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Dict
{
	class Program
	{
		// Mit Dictarnary dublicate zu lassen
		Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();

		public static void Main(string[] args)
		{
			string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LargeCanterburyCorpus.txt");
			Program p = new Program();
			p.CreateDictionary(filePath);
			p.OutputStatistics();

			Console.ReadKey(true);
		}
		
		private void CreateDictionary(string filePath)
		{
			wordsDictionary.Clear();
			string fileText = File.ReadAllText(filePath);
			string[] words = fileText.Split(new char[] { ' ', '\t', '\r', '\n', '.', ',', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string word in words)
			{
				if (wordsDictionary.ContainsKey(word))
					wordsDictionary[word] = wordsDictionary[word] + 1;
				else
				{
					wordsDictionary.Add(word, 1);
				}
			}
		}

		public void OutputStatistics()
		{
			var orderedPairs = wordsDictionary.OrderBy(k => k.Value);
			foreach (KeyValuePair<string, int> kvp in orderedPairs)
			{
				Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
			}
		}
	}
}
