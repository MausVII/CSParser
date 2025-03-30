using CSParser;
using CSParser.Tokens;
using CSParser.Types;
using Newtonsoft.Json;

Parser parser = new Parser();
string program = "42";
Token ast = parser.Parse(program);

string json = Newtonsoft.Json.JsonConvert.SerializeObject(ast, Formatting.Indented);
Console.WriteLine(json);