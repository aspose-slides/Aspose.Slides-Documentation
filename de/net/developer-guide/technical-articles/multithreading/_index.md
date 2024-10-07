---
title: Multithreading in Aspose.Slides
type: docs
weight: 310
url: /net/multithreading/
keywords:
- PowerPoint
- Präsentation
- Multithreading
- parallele Arbeit
- Folien konvertieren
- Folien in Bilder
- C#
- .NET
- Aspose.Slides für .NET
---

## **Einführung**

Während parallele Arbeiten mit Präsentationen möglich sind (neben dem Parsen/Laden/Klonen) und alles in der Regel gut läuft, besteht eine geringe Wahrscheinlichkeit, dass Sie falsche Ergebnisse erhalten, wenn Sie die Bibliothek in mehreren Threads verwenden.

Wir empfehlen ausdrücklich, **keine** einzelne [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Instanz in einer Multi-Thread-Umgebung zu verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht erkannt werden.

Es ist **nicht** sicher, eine Instanz einer [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Solche Operationen werden **nicht** unterstützt. Wenn Sie solche Aufgaben durchführen müssen, müssen Sie die Operationen mit mehreren einzelnen Prozessen in einem Thread parallelisieren—und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien einer PowerPoint-Präsentation parallel in PNG-Bilder konvertieren. Da es unsicher ist, eine einzelne `Presentation` Instanz in mehreren Threads zu verwenden, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, indem wir jede Präsentation in einem separaten Thread verwenden. Das folgende Codebeispiel zeigt, wie dies zu tun ist.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Folie i in einer separaten Präsentation extrahieren.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Konvertiere die Folie in ein Bild in einer separaten Aufgabe.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```