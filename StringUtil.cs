using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Frosty.Essentials.StringUtil
{
  public static class StringUtil
  {
    private static int passwordRequiredNumber = 8;

    // Strings

    private static readonly string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec feugiat bibendum rutrum. Vivamus facilisis ligula tellus, at gravida justo maximus in. Pellentesque eu pulvinar arcu. Sed nisl erat, vestibulum eu facilisis et, ullamcorper sollicitudin ligula. Pellentesque risus metus, condimentum at semper quis, aliquam vel lorem. Integer id diam sed tellus dictum sollicitudin ut et elit. Vivamus mattis porttitor velit, a laoreet lacus convallis eu. Donec sagittis ac lectus in bibendum.";
    private static readonly string validInput = "Please provide a valid input";
    private static readonly string enterText = "Enter your text here";
    private static readonly string enterEmail = "Enter your email address";
    private static readonly string loadingMessage = "Loading, please wait...";

    private static string passwordRequired = $"Password must be at least {passwordRequiredNumber} characters";

        // Modify passwordRequired
        public static void ModifyPasswordRequiredText(int number)
        {
          passwordRequiredNumber = number;
        }

    public static string Lorem => lorem;
    public static string ValidInput => validInput;
    public static string EnterText => enterText;
    public static string EnterEmail => enterEmail;
    public static string LoadingMessage => loadingMessage;
    public static string PasswordRequired
    {
      get { return passwordRequired; }
    }

    // Methods

    public static string Reverse(string input)
    {
      string output = "";

      for (int i = input.Length - 1; i >= 0; i--)
      {
        output += input[i];
      }

      return output;
    }

    public static bool IsPalindromeSensitive(string input)
    {
      string reverse = Reverse(input);
      return reverse == input;
    }

    public static bool IsPalindromeInsensitive(string input)
    {
      string reverse = Reverse(input.ToLower());
      return reverse == input.ToLower();
    }

    public static int CountAmountOfLetter(string words, char input)
    {
      int amount = 0;

      foreach (char c in words)
      {
        if (c == input) amount++;
      }

      return amount;
    }

    public static int CountWords(string input)
    {
      if (string.IsNullOrWhiteSpace(input))
      {
        return 0;
      }

      return input
        .Trim()
        .Split([' '], StringSplitOptions.RemoveEmptyEntries)
        .Length;
    }

    public static bool TryExtractDigits(string input, out List<int> numbers)
    {
      numbers = new List<int>();
      bool hasNumber = false;

      for (int i = 0; i < 10; i++)
      {
        if (input.Contains(i.ToString()))
        {
          hasNumber = true;
          numbers.Add(i);
        }
      }

      return hasNumber;
    }

    public static bool TryExtractDigit(string input, out List<int> numbers)
    {
      numbers = new List<int>();
      bool hasNumber = false;

      for (int i = 0; i < 10; i++)
      {
        if (input.Contains(i.ToString()))
        {
          hasNumber = true;
          numbers.Add(i);
          break;
        }
      }

      return hasNumber;
    }

    public static List<string>? ExtractSentences(string text)
    {
      if (string.IsNullOrWhiteSpace(text))
      {
        return null;
      }

      List<string> sentences = new List<string>();

      int start = 0;

      for (int i = 0; i < text.Length; i++)
      {
        if (text[i] == '.' || text[i] == '!' || text[i] == '?')
        {
          sentences.Add(text.Substring(start, i - start + 1).Trim());

          start = i + 1;

          while (start < text.Length && char.IsWhiteSpace(text[start]))
          {
            start++;
          }
        }
      }

      if (start < text.Length)
      {
          sentences.Add(text.Substring(start).Trim());
      }

      return sentences;
    }
  }
}
