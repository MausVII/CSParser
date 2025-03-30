using CSParser.Tokens;

namespace CSParser;

public class Tokenizer(string input) {
   private int _cursor = 0;

   public Token? GetNextToken() {
      if (!this.HasMoreTokens()) return null;
      
      var str = input.Substring(this._cursor, input.Length);

      var number = "";
      while (_cursor < str.Length && char.IsDigit(str[_cursor])) {
         number += str[_cursor];
         _cursor++;
      }
      
      return new Token("NUMBER", int.Parse(number));
   }

   private bool HasMoreTokens() {
      return _cursor < input.Length;
   }
}