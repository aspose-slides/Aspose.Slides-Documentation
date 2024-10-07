---
title: Öffnen einer Präsentation in VSTO und Aspose.Slides
type: docs
weight: 120
url: /net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
Unten finden Sie den Codeausschnitt zum Öffnen einer Präsentation:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides für .NET bietet die **Presentation**-Klasse, die verwendet wird, um eine vorhandene Präsentation zu öffnen. Es gibt einige überladene Konstruktoren, und wir können einen der geeigneten Konstruktoren der **Presentation**-Klasse verwenden, um ihr Objekt basierend auf einer vorhandenen Präsentation zu erstellen. Im folgenden Beispiel haben wir den Namen der Präsentationsdatei (die geöffnet werden soll) an den Konstruktor der Presentation-Klasse übergeben. Nachdem die Datei geöffnet wurde, erhalten wir die Gesamtzahl der Folien, die in der Präsentation vorhanden sind, um diese auf dem Bildschirm auszugeben.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download des ausführbaren Codes**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download des Beispielcodes**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Opening a Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)