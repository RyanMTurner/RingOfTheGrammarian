using System;
using System.Collections.Generic;
using System.IO;

namespace RingOfTheGrammarian {
    class Program {
        static void Main(string[] args) {
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader("C:/Users/ryman/Documents/Unity Projects/RingOfTheGrammarian/words_alpha.txt")) {
                string readLine = reader.ReadLine();
                while (readLine != null) {
                    words.Add(readLine);
                    readLine = reader.ReadLine();
                }
            }
            while (true) {
                Console.Out.Flush();
                string input = Console.ReadLine().ToLower();
                if (input == "exit") {
                    break;
                }
                List<string> changedSpellWords = GetChangedSpellWords(words, input);
                for (int i = 0; i < changedSpellWords.Count; i++) {
                    Console.WriteLine($"{i+1:n0}. {changedSpellWords[i]}");
                }
            }
        }

        static List<string> GetChangedSpellWords(List<string> wordLibrary, string input) {
            string[] spellWords = input.Split(' ');
            List<string> spellChanges = new List<string>();
            for (int i = 0; i < spellWords.Length; i++) {
                foreach (string changedWord in GetWords1LetterChanged(wordLibrary, spellWords[i])) {
                    string newSpell = string.Empty;
                    for (int s = 0; s < spellWords.Length; s++) {
                        if (!string.IsNullOrEmpty(newSpell)) {
                            newSpell += " ";
                        }
                        if (s == i) {
                            newSpell += changedWord;
                        }
                        else {
                            newSpell += spellWords[s];
                        }
                    }
                    spellChanges.Add(newSpell);
                }
            }
            return spellChanges;
        }

        static List<string> GetWords1LetterChanged(List<string> wordLibrary, string word) {
            List<string> changedWords = new List<string>();
            foreach (string realWord in wordLibrary) {
                if (realWord.Length == word.Length) {
                    int characterDifference = 0;
                    for (int i = 0; i < realWord.Length; i++) {
                        if (realWord[i] != word[i]) {
                            characterDifference++;
                        }
                        if (characterDifference > 1) {
                            break;
                        }
                    }
                    if (characterDifference == 1) {
                        changedWords.Add(realWord);
                    }
                }
            }
            return changedWords;
        }
    }
}
