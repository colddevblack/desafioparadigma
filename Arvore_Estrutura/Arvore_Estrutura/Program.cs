using System.Runtime.InteropServices;

var array1 = new Node('A', 
    new('B',
        new('G'),
        new('D')),
    new('C',
        new('E',
            new('F')
        ),
        new('H')
    )
);

var array2 = new Node('A',
  new('B',
        new('D',
           new('E',
                new('G')
        )
      )
    ),
   new('C',
            new('F')
      )
   );

var array3 = new Node('A',
    new('B',
        new('D')),
    new('C')
);

Console.WriteLine("\r\n TAREFA 1 - ARVORES:");


Console.WriteLine("\r\n Exemplo1:");


TreeTraversal.Exemplo1(array1, letter => Console.Write($"{letter}"));


Console.WriteLine("\r\n Exemplo2:");


TreeTraversal.Exemplo2(array2, letter => Console.Write($"{letter}"));

Console.WriteLine("\r\n Exemplo3:");


TreeTraversal.Exemplo3(array3, letter => Console.Write($"{letter}"));

class Node 
{
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public char Value { get; set; }

    public Node(char value, Node? left = null, Node? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}

static class TreeTraversal
{
    public static void Exemplo1(Node? root, Action<char> action)
    {
        var queue = new Queue<Node?>();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            if(node is null) continue;
            //Console.WriteLine("Pai " + node.Value);
            action(node.Value);

            queue.Enqueue(node.Left);
            //if (node.Left != null)
            //    Console.WriteLine("Filho esquerda " + node.Left.Value);
            //else
            //    Console.WriteLine("Filho esquerda vazio");
            queue.Enqueue(node.Right);
            //if (node.Right != null)
            //    Console.WriteLine("Filho direita " + node.Right.Value);
            //else
            //    Console.WriteLine("Filho direita vazio");

        }
    }


    public static void Exemplo2(Node? node, Action<char> action)
    {
        if (node is null) return;
        //Console.WriteLine("Pai " + node.Value);
        action(node.Value);
        //if (node.Left != null)
        //    Console.WriteLine("Filho esquerda " + node.Left.Value);
        //else
        //    Console.WriteLine("Filho esquerda vazio");
        Exemplo2(node.Left, action);
        //if (node.Right != null)
        //    Console.WriteLine("Filho direita " + node.Right.Value);
        //else
        //    Console.WriteLine("Filho direita vazio");
        Exemplo2(node.Right, action);
    }

    public static void Exemplo3(Node? node, Action<char> action)
    {
        try
        {
          
            action(node.Value);
            
            Exemplo3(node.Left, action);
           
            Exemplo3(node.Right, action);
        }
        catch (Exception)
        {

            Console.WriteLine("--Erro E3 - Raízes múltiplas");
            //Console.ReadKey();  
           
        }
       
    }
}