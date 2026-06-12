---
title: Presentatie afdrukken
type: docs
url: /nl/net/print-the-presentation/
---
Aspose.Slides for .NET biedt vier overladen methoden voor het afdrukken van presentaties. Deze methoden zijn flexibel genoeg om de presentatie naar de standaardprinter of naar een van de beschikbare printers met aangepaste instellingen af te drukken. U hoeft alleen de juiste afdrukmethode te selecteren op basis van de vereiste.
## **Afdrukken naar de standaardprinter**
Het afdrukken van de presentatie naar de standaardprinter is heel eenvoudig in Aspose.Slides for .NET. Voer de volgende stappen uit om de presentatie naar de standaardprinter af te drukken:

- Maak een instantie van de Presentation‑klasse om een presentatie te laden die moet worden afgedrukt
- Roep de Print‑methode zonder parameters aan die wordt aangeboden door het Presentation‑object

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Laad de presentatie

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Roep de afdrukmethode aan om de hele presentatie naar de standaardprinter af te drukken

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Laad de presentatie

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Roep de afdrukmethode aan om de hele presentatie naar de gewenste printer af te drukken

    asposePresentation.Print("LaserJet1100");


``` 
## **Afdrukken naar een specifieke printer**
Het afdrukken van de presentatie naar een specifieke printer vereist de naam van de printer als parameter voor de Print‑methode van de Presentation‑klasse. Voer de volgende stappen uit om de presentatie naar de gewenste printer af te drukken:

- Maak een instantie van de Presentation‑klasse om een presentatie te laden die moet worden afgedrukt
- Roep de Print‑methode van de Presentation‑klasse aan met de printernaam als string‑parameter

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Laad de presentatie

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Roep de afdrukmethode aan om de hele presentatie naar de gewenste printer af te drukken

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)