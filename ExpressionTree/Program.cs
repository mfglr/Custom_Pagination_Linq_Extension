// See https://aka.ms/new-console-template for more information

using ExpressionTree;

List<Person> context = new()
{
    new() { Id = 1, Birthday = new DateTime(2016,7,16), Name = "ali" },
    new() { Id = 3, Birthday = new DateTime(2007,9,16), Name = "ayse" },
    new() { Id = 5, Birthday = new DateTime(1969,1,16), Name = "furkan" },
    new() { Id = 2, Birthday = new DateTime(1978,5,16), Name = "ahmet" },
    new() { Id = 4, Birthday = new DateTime(1987,4,16), Name = "elif" },
}; 

//***************************************************************************
var list0 = context
    .AsQueryable()
    .ToPage(x => x.Id, 0, false, 5)
    .ToList();

/*  output
 *  { Id = 1, Birthday = new DateTime(2016,7,16), Name = "ali" },
 *  { Id = 2, Birthday = new DateTime(1978,5,16), Name = "ahmet" },
 *  { Id = 3, Birthday = new DateTime(2007,9,16), Name = "ayse" },
 *  { Id = 4, Birthday = new DateTime(1987,4,16), Name = "elif" },
 *  { Id = 5, Birthday = new DateTime(1969,1,16), Name = "furkan" }
*/
//***************************************************************************


//***************************************************************************
var list1 =  context
    .AsQueryable()
    .ToPage(x => x.Name, "fatih", take : 3)
    .ToList();


/*  output
 *  { Id = 4, Birthday = new DateTime(1987,4,16), Name = "elif" },
 *  { Id = 3, Birthday = new DateTime(2007,9,16), Name = "ayse" },
 *  { Id = 1, Birthday = new DateTime(2016,7,16), Name = "ali" },
*/
//***************************************************************************


//***************************************************************************
var list2 = context
    .AsQueryable()
    .ToPage(x => x.Birthday, DateTime.Now, true,2)
    .ToList();

/*  output
 *  { Id = 1, Birthday = new DateTime(2016,7,16), Name = "ali" },
 *  { Id = 3, Birthday = new DateTime(2007,9,16), Name = "ayse" },
*/
//***************************************************************************

//***************************************************************************
var list3 = context
    .AsQueryable()
    .ToPage(x => x.Birthday, new DateTime(2007,02,19), true,2)
    .ToList();

/*  output
 *  { Id = 4, Birthday = new DateTime(1987,4,16), Name = "elif" },
 *  { Id = 2, Birthday = new DateTime(1978,5,16), Name = "ahmet" },
*/
//***************************************************************************

Console.WriteLine();


public class Person
{
    public int Id { get; set; }
    public DateTime Birthday { get; set; }
    public string Name { get; set; }
}


