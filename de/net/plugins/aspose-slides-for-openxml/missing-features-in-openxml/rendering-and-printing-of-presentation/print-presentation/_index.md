---
title: Präsentation drucken
type: docs
url: /de/net/print-the-presentation/
---

Aspose.Slides für .NET bietet vier überladene Methoden zum Drucken von Präsentationen. Diese Methoden sind so flexibel, dass sie die Präsentation entweder zum Standarddrucker oder zu einem beliebigen verfügbaren Drucker mit benutzerdefinierten Einstellungen drucken können. Sie müssen lediglich die passende Druckmethode gemäß den Anforderungen auswählen.
## **Drucken zum Standarddrucker**
Das Drucken einer Präsentation zum Standarddrucker ist in Aspose.Slides für .NET ziemlich einfach. Führen Sie die folgenden Schritte aus, um die Präsentation zum Standarddrucker zu drucken:

- Erstellen Sie eine Instanz der Klasse Presentation, um die zu druckende Präsentation zu laden
- Rufen Sie die Print‑Methode ohne Parameter auf, die vom Presentation‑Objekt bereitgestellt wird

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
## **Drucken zu einem bestimmten Drucker**
Das Drucken einer Präsentation zu einem bestimmten Drucker erfordert den Namen des Druckers als Parameter für die Print‑Methode von Presentation. Führen Sie die folgenden Schritte aus, um die Präsentation zum gewünschten Drucker zu drucken:

- Erstellen Sie eine Instanz der Klasse Presentation, um die zu druckende Präsentation zu laden
- Rufen Sie die Print‑Methode der Klasse Presentation auf und übergeben Sie den Druckernamen als Zeichenkettenparameter

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
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)