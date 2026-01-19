---
title: Präsentation drucken
type: docs
url: /de/net/print-the-presentation/
---

Aspose.Slides for .NET bietet vier überladene Methoden zum Drucken von Präsentationen. Diese Methoden sind so flexibel, dass sie die Präsentation entweder auf dem Standarddrucker oder auf einem beliebigen verfügbaren Drucker mit benutzerdefinierten Einstellungen drucken können. Sie müssen lediglich die passende Druckmethode entsprechend den Anforderungen auswählen.

## **Drucken zum Standarddrucker**
Das Drucken der Präsentation auf dem Standarddrucker ist in Aspose.Slides for .NET recht einfach. Führen Sie die folgenden Schritte aus, um die Präsentation auf dem Standarddrucker zu drucken:

- Erstellen Sie eine Instanz der **Presentation**‑Klasse, um die zu druckende Präsentation zu laden
- Rufen Sie die **Print**‑Methode ohne Parameter auf, die vom **Presentation**‑Objekt bereitgestellt wird

```csharp
PrintByDefaultPrinter();

PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()
{
    string MyDir = @"..\..\..\Sample Files\";
    //Lade die Präsentation
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");
    //Rufe die Druckmethode auf, um die gesamte Präsentation auf dem Standarddrucker zu drucken
    asposePresentation.Print();
}

public static void PrintBySpecificPrinter()
{
    string MyDir = @"..\..\..\Sample Files\";
    //Lade die Präsentation
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");
    //Rufe die Druckmethode auf, um die gesamte Präsentation auf dem gewünschten Drucker zu drucken
    asposePresentation.Print("LaserJet1100");
}
``` 

## **Drucken zu einem bestimmten Drucker**
Das Drucken der Präsentation auf einem bestimmten Drucker erfordert den Namen des Druckers als Parameter für die **Print**‑Methode der **Presentation**‑Klasse. Führen Sie die folgenden Schritte aus, um die Präsentation auf dem gewünschten Drucker zu drucken:

- Erstellen Sie eine Instanz der **Presentation**‑Klasse, um die zu druckende Präsentation zu laden
- Rufen Sie die **Print**‑Methode der **Presentation**‑Klasse mit dem Druckernamen als Zeichenkettenparameter auf

```csharp
public static void PrintBySpecificPrinter()
{
    string MyDir = @"..\..\..\Sample Files\";
    //Lade die Präsentation
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");
    //Rufe die Druckmethode auf, um die gesamte Präsentation auf dem gewünschten Drucker zu drucken
    asposePresentation.Print("LaserJet1100");
}
``` 

## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)