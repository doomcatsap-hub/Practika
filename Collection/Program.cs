using System.Collections;
using System.Runtime.CompilerServices;

namespace Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<int> {55,66};
            var stack1 = new SmartStack<int>(list1);
            var stack2 = new SmartStack<int>();
            stack2.Push(1);
            stack2.Push(2);
            stack2.PushRange(new int[] { 11,22,33 });
            stack2.PushRange(stack2);
            stack1 +=  stack2;
            foreach (int i in stack1)
                Console.WriteLine(i);
            Random rand = new Random();
            Console.WriteLine("Случайный элемент стека " + stack1[rand.Next(stack1.Count)]);

        }
    }
    public class SmartStack<T> : IEnumerable<T>
    {
        private T[] array;
        private int _count;
        public SmartStack()
        {
            array = new T[4];
        }
        public SmartStack(int _count)
        {
            array = new T[_count];
        }
        public SmartStack(IEnumerable<T> Collection)
        {
            array = new T[Collection.Count()];
            foreach (var item in Collection)
            {
                Push(item);
            }
        }
        public void Push(T value)
        {
            if (array.Length == _count)
                Array.Resize(ref array, array.Length * 2);
            array[++_count-1] = value;;
        }
        public void PushRange(IEnumerable<T> Collection)
        {
            if (array.Length ==0 )
                Array.Resize(ref array, 4);
            int size = Collection.Count();
            while (array.Length - _count < size)
                Array.Resize(ref array, array.Length * 2);
            foreach (var item in Collection)
            {
                array[++_count-1] = item;
            }

        }
        public T Pop()
        {
            IsStackEmpty();
            {
                T value = array[--_count];
                Array.Clear(array, _count, 1);
                return value;
            }
        }
        public T Peek()
        {
            IsStackEmpty();
            return array[_count - 1];
        }
        public bool Contains(T element)
        {
            foreach (var item in array)
                if (EqualityComparer<T>.Default.Equals(item, element))
                    return true;
            return false;
        }
        public int Count { get => _count; }

        public int Capacity { get => array.Length; }

        //public IEnumerable<T> En()
        //{

        //}
        private void IsStackEmpty()
        {
            if (_count == 0)
                throw new InvalidOperationException();
        }
        public void Show()
        {
            foreach (var item in array)
                Console.WriteLine(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _count - 1; i >= 0; i--)
                yield return array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException("Индекс вне границ стека");
                return array[Count - 1 - index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException("Индекс вне границ стека");
                array[_count - 1 - index] = value;
            }
        }
        public static SmartStack<T> operator +(SmartStack<T> stack1, SmartStack<T> stack2) //Складывание стеков
        {
            stack1.PushRange(stack2);
            return stack1;
        }
    }
}
