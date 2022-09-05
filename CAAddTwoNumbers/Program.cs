class Program
{
    static public void Main(string[] args)
    {
        /*LinkedList<int> l1 = new LinkedList<int>();
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

        var l3 = SumTwoLinkedLists(l1, l2);*/



        Console.ReadLine();
    }
    public static LinkedList<int> SumTwoLinkedLists(LinkedList<int> l1, LinkedList<int> l2)
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

    public ListNode AddTwoNodes(ListNode l1, ListNode l2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode l3 = dummyHead;

        int carry = 0;

        while (l1 != null || l2 != null)
        {
            int l1Val = l1 != null ? l1.val : 0;
            int l2Val = l2 != null ? l2.val : 0;

            int currentSum = l1Val + l2Val + carry;
            carry = currentSum / 10;
            int lastDigit = currentSum % 10;

            ListNode newNode = new ListNode(lastDigit);
            l3.next = newNode;


            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
            l3 = l3.next;
        }

        if (carry != default(int))
        {
            ListNode newNode = new ListNode(carry);
            l3.next = newNode;
            l3 = l3.next;
        }

        return dummyHead.next;
    }
}
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}