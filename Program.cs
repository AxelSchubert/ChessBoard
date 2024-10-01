internal class Program
{
    private static void Main(string[] args)
    {
        //Axel Schubert NET24
        //Hör tar jag in all input från användaren, hur rutorna och pjäsen ska se ut samt var den ska stå
        Console.Write("Skriv in hur stort bräde: ");
        int.TryParse(Console.ReadLine(), out int boardDimensions);
        Console.Write("Skriv hur svarta rutor ska se ut: ");
        char blackTile = Console.ReadKey().KeyChar;
        Console.WriteLine();
        Console.Write("Skriv hur vita rutor ska se ut: ");
        char whiteTile = Console.ReadKey().KeyChar;
        Console.WriteLine();
        Console.Write("Skriv hur din pjäs ska se ut: ");
        char userPiece = Console.ReadKey().KeyChar;
        Console.WriteLine();
        Console.Write("Skriv var du vill placera ut din pjäs i schacknotation (ex. F5): ");
        string pieceLocation = Console.ReadLine().ToUpper(); //Konverterar schacknotationen till stora bokstäver så jag kan hantera det konsekvent senare
        char tile = whiteTile; //deklarerar temporär variabel "tile" som ska alternera mellan svart och vit
        char[,] boardCharArray = new char[boardDimensions, boardDimensions]; //Skapar en 2d-array med användarens input som storlek
        //här användar jag mig av en nested for loop för att tilldela 2d-arrayen schackrutorna
        for (int i = 0; i < boardDimensions; i++)
        {
            for (int j = 0; j < boardDimensions; j++)
            {
                boardCharArray[i, j] = tile;
                tile = tile == blackTile ? whiteTile : blackTile; //Ser till att tile variabeln alternerar mellan varje ruta
            }
            if (boardDimensions % 2 == 0) // Om schackbrädet har jämna dimensioner så måste man skriva ut två av samma ruta på rad i radbytet
            {
                tile = tile == blackTile ? whiteTile : blackTile; 
            }
        }
        //Här konverterar jag användarens schacknotation till ints för att kunna placera ut dom i brädet
        int pieceColumn = pieceLocation[0] - 'A'; //Här läste jag på lite hur ascii och char-till-intkonvertering funkar om man subtraherar med 'A' så subtraheras ascii-värdet från charen man subtraherar. 
        //Till exempel så har 'A' ascii värdet 65, om användaren då skriver in 'B' vilket har värdet 66 och man subtraherar med 'A', värdet 65 så får man ascii-värdet 1 vilket man sen kan konvertera till int. Det funkar så för att om man konverterar en char till int så får man alltid ascii-värdet av sin char. 
        int pieceRow = pieceLocation[1] - '0'; //Subtraherar en char-siffra med charen '0' så man för ascii-värdet man vill ha
        boardCharArray[(boardDimensions - pieceRow), pieceColumn] = userPiece;//Placerar pjäsen efter notationen. Skriver: "(boardDimensions - pieceRow)" eftersom att notationen räknar nedifrån medan arrayan gör tvärtom
        //Här två for loopar som skriver ut det färdiga brädet.
        for (int i = 0; i < boardDimensions; i++)         
        {                                                 
            for (int j = 0; j < boardDimensions; j++)     
            {                                             
                Console.Write(boardCharArray[i, j]);              
                              
            } 
            Console.WriteLine();
        }                                                 
    }
}
