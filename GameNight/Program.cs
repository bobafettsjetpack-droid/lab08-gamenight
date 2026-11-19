/*
*Name: Aaron Robinson
*Course CSCI 1250, Section 001
*Assignment Lab 08, Game Night
*Date November 19, 2026
*Description: A program that remembers changes.  It keeps scores fora game night and the history of changes.
*/

using System.Security;

// PART 1 =======================================================================================================================================================
const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

// Look for the data files next to Program.cs, however the program is started.
string projectFolder = Path.GetFullPath(
Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

//reads the files into arrays
string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);

//writes out the player points heading
System.Console.WriteLine($"{"PLAYER".PadRight(11)}POINTS");
int i = 0;
//writes out each persons score and name
foreach(string line in players)
{
 System.Console.WriteLine($"{line.PadRight(11)}{points[i]}");  
    i++;
}

//writes the leader part
int leader = LeaderIndex(points);
System.Console.WriteLine($"Leader: {players[leader]} with {points[leader]}");
System.Console.WriteLine($"Season total: {TotalPoints(points)}");
int season = TotalPoints(points);

// Part 2 ===============================================================================================================================================
i = 0;
string[] pointsTonight = new string[players.Length];
foreach(string line in players)
{
    System.Console.Write($"Points tonight for {players[i]}: ");
    
    int newPoints = Convert.ToInt32(Console.ReadLine());
    while(newPoints < 0 || newPoints > 20)
    {
        System.Console.WriteLine("A score must be between 0 and 20.");
        System.Console.Write($"Points tonight for {players[i]}: ");
        newPoints = Convert.ToInt32(Console.ReadLine());
    }
    points[i] = Convert.ToString(Convert.ToInt32(points[i]) + newPoints);
    pointsTonight[i] = Convert.ToString(newPoints);
    //season = Convert.ToInt32(points[i]);
    //points[i] = season.ToString();
    i++;

}

File.WriteAllLines(POINTS_FILE, points);

int leaderTonight = LeaderIndex(pointsTonight);
int highScoreTonight = HighestPoints(pointsTonight);
System.Console.WriteLine($"Tonights winner is {players[leaderTonight]} with {highScoreTonight}");






//Methods ===================================================================================================================================================
static int HighestPoints(string[] points)
{
    int highPoint = 0;
    for(int i = 1; i < points.Length; i++)
    {
        int currentPoint = Convert.ToInt32(points[i]);
        if (currentPoint > highPoint)
        {
            highPoint = currentPoint;
            
        }
    }
    return highPoint;
}


static int LeaderIndex(string[] points)
{
    int highPoint = 0;
    int leaderIndex = 0;
    for(int i = 0; i < points.Length; i++)
    {
        int currentPoint = Convert.ToInt32(points[i]);
        if (currentPoint > highPoint)
        {
            highPoint = currentPoint;
            leaderIndex = i;
        }

    }
    return leaderIndex;
}


static int TotalPoints(string[] points)
{
    int i = 0;
    int total = 0;
    foreach(string line in points)
    {
        total = Convert.ToInt32(points[i]) + total;
        i++;
    }
    return total;
}

/*
static string HistoryEntry(int night, string winner, int points)
*/