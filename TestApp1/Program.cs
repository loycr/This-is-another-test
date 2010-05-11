using System;

namespace TestApp1
{
   partial class TestClass
   {
      private string m_firstName;
      private string m_lastName;
      static private int m_testInt;

      static TestClass()
      {
         m_testInt = 42;
      }

      public TestClass()
      {

      }

      public TestClass(string firstName, string lastName)
      {
         m_firstName = firstName;
         m_lastName = lastName;
      }

      public string FirstName
      {
         get
         {
            return m_firstName;
         }
         set
         {
            m_firstName = value;
         }
      }

      public string LastName
      {
         get
         {
            return m_lastName;
         }
         set
         {
            m_lastName = value;
         }
      }

      public string this[int index]
      {
         get
         {
            switch (index)
            {
               case 0: 
                  return m_firstName;
               case 1: 
                  return m_lastName;
               default: 
                  throw new ArgumentOutOfRangeException("index");
            }
         }
         private set
         {
            switch (index)
            {
               case 0:
                  m_firstName = value;
                  break;
               case 1:
                  m_lastName = value;
                  break;
               default:
                  throw new ArgumentOutOfRangeException("index");
            }
         }
      }


      public void TestParamterFunction(params int[] intValues)
      {
         if (intValues != null)
         {
            for (int index = 0; index < intValues.Length; index++ )
            {
               intValues[index] *= 10;
            }
         }
      }
   }

   partial class TestClass
   {
      public string AdditionalString;
      private static string m_licenseKey;

      public void SetAdditionalStringFromReference(ref string stringValue)
      {
         AdditionalString = stringValue;
      }

      public void GetAdditionalStringPlusFirstAndLast(out string value)
      {
         value = AdditionalString + m_firstName + m_lastName;
      }

      public string ReadOnlyString
      {
         get { return "Read_Only"; }
      }

      public int AutoInt
      {
         set;
         get;
      }

      public static string LicenseKey
      {
         get
         {
            return m_licenseKey;
         }
      }

   }

   class Program
   {
      static void Main()
      {
         var testInstance = new TestClass();
         var testInstance1 = new TestClass("Test First", "Test Last");

         testInstance.LastName = "Test Set";

         int testInt = 10;
         int[] testIntArray = { 10, 20, 12, -14 };

         testInstance.TestParamterFunction(testInt, 20, 12, -14);
         testInstance.TestParamterFunction(testIntArray);

         string testName = testInstance.FirstName;

         //testInstance.SetNameFromReference(ref testName);
      }
   }
}
