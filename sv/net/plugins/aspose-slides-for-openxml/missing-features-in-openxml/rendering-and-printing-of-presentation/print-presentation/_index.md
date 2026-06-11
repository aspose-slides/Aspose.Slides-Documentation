---
title: Skriv ut presentation
type: docs
url: /sv/net/print-the-presentation/
---
Aspose.Slides for .NET tillhandahåller fyra överlagrade metoder för utskrift av presentationerna. Dessa metoder är tillräckligt flexibla för att skriva ut presentationen till standardskrivaren eller till någon av de tillgängliga skrivarna med anpassade inställningar. Du behöver bara välja lämplig utskriftsmetod enligt kravet.
## **Skriv ut till standardskrivaren**
Utskrift av presentationen till standardskrivaren är ganska enkelt i Aspose.Slides for .NET. Utför följande steg för att skriva ut presentationen till standardskrivaren:

- Skapa en instans av Presentation-klassen för att läsa in en presentation som ska skrivas ut
- Anropa Print-metoden utan parametrar som den exponeras av Presentation-objektet

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Läs in presentationen

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Anropa utskriftsmetoden för att skriva ut hela presentationen till standardskrivaren

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Läs in presentationen

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Anropa utskriftsmetoden för att skriva ut hela presentationen till önskad skrivare

    asposePresentation.Print("LaserJet1100");
``` 
## **Skriv ut till en specifik skrivare**
Utskrift av presentationen till en specifik skrivare kräver skrivarnamnet som parameter till Print-metoden i Presentation. Utför följande steg för att skriva ut presentationen till den önskade skrivaren:

- Skapa en instans av Presentation-klassen för att läsa in en presentation som ska skrivas ut
- Anropa Print-metoden i Presentation-klassen med skrivarnamnet som strängparameter till Print-metoden

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Läs in presentationen

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Anropa utskriftsmetoden för att skriva ut hela presentationen till önskad skrivare

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Ladda ner exempel på kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)