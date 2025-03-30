using System.Data;
using CSParser.Tokens;
using CSParser.Types;

namespace CSParser;

public class Parser {
    private String _str;
    private Tokenizer _tokenizer;
    private Token? _lookahead;
    
    // Parses a string into an AST
    public Token Parse(String str) {
       this._str = str;
       this._tokenizer = new Tokenizer(str);
       this._lookahead = this._tokenizer.GetNextToken();
       
       return this.Program();
    }

    Token Program() {
        return new("Program", this.GetNumericLiteral());
    }
    
    Token GetNumericLiteral() { 
        Token token = this._eat("NUMBER"); 
        return new("Numeric Literal", Convert.ToInt32(token.value));
    }

    private Token _eat(string tokenType) {
        var token = this._lookahead;

        if (token is null) {
            throw new SyntaxErrorException("Unexpected end of input, expected: ${tokenType}");
        }

        if (token.type != tokenType) {
            throw new SyntaxErrorException("Unexpected token: ${token.type}, expected: ${tokenType}");
        }

        return token;
    }
}
