---
title: Druckpräsentation
type: docs
url: /de/net/print-the-presentation/
---

Aspose.Slides für .NET bietet vier Überladungsmethoden zum Drucken von Präsentationen. Diese Methoden sind flexibel genug, um die Präsentation an den Standarddrucker oder an jeden verfügbaren Drucker mit benutzerdefinierten Einstellungen zu drucken. Sie müssen lediglich die entsprechende Druckmethode gemäß den Anforderungen auswählen.
## **Drucken an den Standarddrucker**
Das Drucken der Präsentation an den Standarddrucker ist in Aspose.Slides für .NET recht einfach. Führen Sie die folgenden Schritte aus, um die Präsentation an den Standarddrucker zu drucken:

- Erstellen Sie eine Instanz der Presentation-Klasse, um eine Präsentation zu laden, die gedruckt werden soll
- Rufen Sie die Print-Methode ohne Parameter auf, die vom Presentation-Objekt bereitgestellt wird

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Laden Sie die Präsentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Rufen Sie die Druckmethode auf, um die gesamte Präsentation an den Standarddrucker zu drucken

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Laden Sie die Präsentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Rufen Sie die Druckmethode auf, um die gesamte Präsentation an den gewünschten Drucker zu drucken

    asposePresentation.Print("LaserJet1100");

} 
```
## **Drucken an einen bestimmten Drucker**
Das Drucken der Präsentation an einen bestimmten Drucker erfordert den Namen des Druckers als Parameter für die Print-Methode der Presentation. Führen Sie die folgenden Schritte aus, um die Präsentation an den gewünschten Drucker zu drucken:

- Erstellen Sie eine Instanz der Presentation-Klasse, um eine Präsentation zu laden, die gedruckt werden soll
- Rufen Sie die Print-Methode der Presentation-Klasse mit dem Druckernamen als String-Parameter für die Print-Methode auf

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Laden Sie die Präsentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Rufen Sie die Druckmethode auf, um die gesamte Präsentation an den gewünschten Drucker zu drucken

    asposePresentation.Print("LaserJet1100");

} 
```
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)