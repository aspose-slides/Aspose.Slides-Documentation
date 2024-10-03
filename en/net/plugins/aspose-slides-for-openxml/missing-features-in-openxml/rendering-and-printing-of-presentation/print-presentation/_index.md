---
title: Print Presentation
type: docs
url: /net/print-the-presentation/
---

Aspose.Slides for .NET provides four overloads methods for printing of the presentations. These methods are flexible enough to print the presentation to the default printer or to any of the available printer with customized settings. You only need to select the appropriate print method according to the requirement.
## **Printing to default printer**
Printing of the presentation to the default printer is quite simple in Aspose.Slides for .NET. Perform the following steps in order to print the presentation to default printer:

- Create an instance of Presentation class to load a presentation that is to be printed
- Call the Print method with no parameters as exposed by the Presentation object

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the default printer

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");


``` 
## **Printing to specific printer**
Printing of the presentation to the specific printer requires the name of the printer as parameter to the Print method of the Presentation. Perform the following steps in order to print the presentation to the desired printer:

- Create an instance of Presentation class to load a presentation that is to be printed
- Call the Print method of the Presentation class with printer name as string parameter to the Print method

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)
