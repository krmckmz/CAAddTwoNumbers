class Program
{
    static public void Main(string[] args)
    {
        LinkedList<int> l1 = new LinkedList<int>();
        l1.AddLast(9);
        l1.AddLast(9);
        l1.AddLast(9);
        l1.AddLast(9);
        l1.AddLast(9);
        l1.AddLast(9);
        l1.AddLast(9);

        LinkedList<int> l2 = new LinkedList<int>();
        l2.AddLast(9);
        l2.AddLast(9);
        l2.AddLast(9);
        l2.AddLast(9);

        var l3 = AddTwoNumbers(l1, l2);
        Console.WriteLine();
        Console.ReadLine();
    }
    public static LinkedList<int> AddTwoNumbers(LinkedList<int> l1, LinkedList<int> l2)
    {

        LinkedList<int> l3 = new LinkedList<int>();

        int carry = default(int);
        const int ten = 10;

        var smallerLinkedList = l1.Count < l2.Count ? l1 : l2;
        var biggerLinkedList = l1.Count > l2.Count ? l1 : l2;

        for (int i = default(int); i < smallerLinkedList.Count; i++)
        {
            var sum = l1.ElementAt(i) + l2.ElementAt(i);

            if (carry != default(int))
                sum += carry;

            if (sum < ten)
                l3.AddLast(sum);
            else
            {
                carry = sum / ten;
                int value = sum % ten;
                l3.AddLast(value);
            }
        }

        if (l1.Count != l2.Count)
        {
            for (int i = smallerLinkedList.Count; i < biggerLinkedList.Count; i++)
            {
                var sum = biggerLinkedList.ElementAt(i);

                if (carry != default(int))
                    sum += carry;

                if (sum < ten)
                    l3.AddLast(sum);
                else
                {
                    carry = sum / ten;
                    int value = sum % ten;
                    l3.AddLast(value);
                }
            }
        }

        if (carry != default(int))
            l3.AddLast(carry);

        return l3;

    }
}