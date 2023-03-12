
    class Tester<T1, T2>
    {
        public List<T1> Tests = new List<T1>();
        public Test TestFunc;
        public ValidateTest Validator;

        public delegate T2 Test(T1 arg);
        public delegate string ValidateTest(T1 testInput, T2 testResult, double millis);

        public Tester()
        {

        }

        public void RunTests()
        {
            Console.WriteLine("Starting Tests ... ");
            Console.WriteLine("" + Tests.Count + " Tests");
            if(Validator == null)
            {
                Console.WriteLine("INFO: Validator=NULL   generating Default output for tests");
            }
            if (TestFunc == null)
            {
                Console.WriteLine("ERROR: TestFunc=NULL");
                return;
            }
            double totalMillisInTests = 0;
            int totalTestsPerformed = 0;

            for(int i=0; i<Tests.Count; i++)
            {
                DateTime start = DateTime.Now;
                T2 res = default(T2);
                bool exception = false;
                try
                {
                    res = TestFunc.Invoke(Tests[i]);
                }
                catch(Exception ex)
                {
                    exception = true;
                    Console.WriteLine("CATCH: " + ex.ToString() + " on Test " + i + "     Skipping Validator");
                }
                DateTime end = DateTime.Now;
                double millis = (end - start).TotalMilliseconds;
                totalMillisInTests += millis;
                totalTestsPerformed++;
                if (Validator == null)
                {
                    if (!exception)
                    {
                        Console.WriteLine("[TEST " + i + "] took " + Math.Round(millis, 1) + " ms   result=" + res.ToString());
                    }
                }
                else
                {
                    if (!exception)
                    {
                        Console.WriteLine("[TEST " + i + "] took " + Math.Round(millis, 1) + " ms\n  => " + 
                            Validator.Invoke(Tests[i], res, millis));
                    }
                }
            }
            Console.WriteLine("Finished!");
            Console.WriteLine("Completed " + totalTestsPerformed + " / " + Tests.Count + " Tests");
            Console.WriteLine("Avg. " + Math.Round(totalMillisInTests / totalTestsPerformed, 2) + " ms");
        }
    }
