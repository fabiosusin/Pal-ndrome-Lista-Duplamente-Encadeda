using System;
using System.Linq;

namespace Palindrome
{
    class Program
    {
        static void Main()
        {
            string text;
            do
            {
                Console.WriteLine("Digite o texto");
                text = Console.ReadLine();

                if (string.IsNullOrEmpty(text))
                    Console.WriteLine("Texto não informado corretamente!");
            }
            while (string.IsNullOrEmpty(text));

            var header = new Node
            {
                Next = null,
                Prev = null
            };

            var palidrome = new LinkedListInput(header);
            var ant = header;
            var counter = 0;
            foreach (var character in text.ToList())
            {
                var node = new Node
                {
                    Data = character.ToString(),
                    Prev = ant
                };

                ant.Next = node;
                ant = node;
                counter++;
            }
            header.Data = counter.ToString();

            palidrome.VerifyListIsPalindrome();
        }
    }
    
    public class Node
    {
        public string Data;
        public Node Next;
        public Node Prev;
    };

    public class LinkedListInput
    {
        public Node Head;

        public LinkedListInput(Node head) => Head = head;

        public void VerifyListIsPalindrome()
        {
            var temp = Head;
            if (temp == null || int.Parse(temp.Data) == 0 || temp.Next == null)
                Console.WriteLine("A lista está vazia");
            else
            {
                Console.WriteLine("Quantidade de caracteres: " + int.Parse(temp.Data));
                var header = temp;
                temp = temp.Next;

                string init = null;
                string end = null;

                while (temp != null)
                {
                    init += temp.Data;
                    if (temp.Next == null)
                    {
                        while (temp != null)
                        {
                            if (header == temp)
                                break;

                            end += temp.Data;
                            temp = temp.Prev;
                        }

                        break;
                    }

                    temp = temp.Next;
                }

                if (init == end)
                    Console.WriteLine("É Palíndrome");
                else
                {
                    Console.WriteLine("Não é Palíndrome");
                    Console.WriteLine("Texto digitado: " + init);
                    Console.WriteLine("Texto lido de trás pra frente: " + end);
                }
            }
        }
    };
}
