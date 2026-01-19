---
title: Öffnen einer Präsentation in VSTO und Aspose.Slides
type: docs
weight: 120
url: /de/net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
Unten finden Sie das Codebeispiel zum Öffnen einer Präsentation:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides für .NET stellt die Klasse **Presentation** bereit, die zum Öffnen einer vorhandenen Präsentation verwendet wird. Sie bietet einige überladene Konstruktoren und wir können einen der geeigneten Konstruktoren der Klasse **Presentation** verwenden, um deren Objekt basierend auf einer vorhandenen Präsentation zu erstellen. Im nachstehenden Beispiel haben wir den Namen der Präsentationsdatei (die geöffnet werden soll) an den Konstruktor der Klasse Presentation übergeben. Nachdem die Datei geöffnet wurde, ermitteln wir die Gesamtzahl der Folien in der Präsentation, um sie auf dem Bildschirm auszugeben.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Ausführbaren Code herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)