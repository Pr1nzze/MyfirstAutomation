using System;

namespace MyfirstAutomation
{
    public class PracticeClassTest3 : Hooks
    {
        public static int Number1;
        public static int result;
        private string student;

        [Test]
        public void BrowserTest2()
        {
            Number1 = 30;
            Console.WriteLine(Number1);

            Number1 = 100;
            Console.WriteLine(Number1);

            Console.WriteLine(Add());

            Console.WriteLine(student);
        }

        public int Add()
        {
            result = 1 + 1;
            return result;    
        }
    }
}
