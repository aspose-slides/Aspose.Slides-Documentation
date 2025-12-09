---
title: Multithreading in Aspose.Slides für .NET
linktitle: Multithreading
type: docs
weight: 310
url: /de/net/multithreading/
keywords:
- Multithreading
- mehrere Threads
- parallele Arbeit
- Folien konvertieren
- Folien zu Bildern
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides für .NET Multithreading beschleunigt die Verarbeitung von PowerPoint- und OpenDocument-Dateien. Entdecken Sie bewährte Methoden für effiziente Präsentationsabläufe."
---

## **Introduction**

Während parallele Arbeit mit Präsentationen möglich ist (abgesehen vom Parsen/Laden/Klonen) und meistens alles gut läuft, besteht eine geringe Chance, dass Sie bei mehrfädiger Nutzung der Bibliothek falsche Ergebnisse erhalten.

Wir empfehlen dringend, dass Sie **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Instanz in einer Multi-Threading-Umgebung verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind.

Es ist **nicht** sicher, eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Solche Vorgänge werden **nicht** unterstützt. Wenn Sie solche Aufgaben ausführen müssen, sollten Sie die Vorgänge mit mehreren ein-Thread-Prozessen parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien einer PowerPoint‑Präsentation parallel in PNG‑Bilder konvertieren. Da es unsicher ist, eine einzelne `Presentation` Instanz in mehreren Threads zu verwenden, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, wobei jede Präsentation in einem eigenen Thread verwendet wird. Das folgende Code‑Beispiel zeigt, wie das geht.
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
    // Extrahiere Folie i in eine separate Präsentation.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Konvertiere die Folie in ein Bild in einem separaten Task.
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


## **FAQ**

**Muss ich die Lizenzinitialisierung in jedem Thread aufrufen?**

Nein. Es reicht, dies einmal pro Prozess/App‑Domain vor dem Start der Threads durchzuführen. Falls die [license setup](/slides/de/net/licensing/) gleichzeitig aufgerufen werden könnte (z. B. bei lazy‑Initialisierung), sollten Sie diesen Aufruf synchronisieren, da die Lizenz‑Methode selbst nicht thread‑sicher ist.

**Kann ich `Presentation`‑ oder `Slide`‑Objekte zwischen Threads übergeben?**

Das Übergeben von „Live“‑Präsentationsobjekten zwischen Threads wird nicht empfohlen: Verwenden Sie unabhängige Instanzen pro Thread oder erzeugen Sie im Voraus separate Präsentationen/Slide‑Container für jeden Thread. Dieser Ansatz entspricht der allgemeinen Empfehlung, keine einzelne Präsentationsinstanz über Threads hinweg zu teilen.

**Ist es sicher, den Export in verschiedene Formate (PDF, HTML, Bilder) zu parallelisieren, vorausgesetzt, jeder Thread verfügt über seine eigene `Presentation` Instanz?**

Ja. Bei unabhängigen Instanzen und getrennten Ausgabepfaden lassen sich solche Aufgaben in der Regel korrekt parallelisieren; vermeiden Sie gemeinsam genutzte Präsentationsobjekte und geteilte I/O‑Streams.

**Wie soll ich mit globalen Schriftarteinstellungen (Ordner, Substitutionen) in einer Multi‑Threading‑Umgebung umgehen?**

Initialisieren Sie alle globalen Schriftarteinstellungen, bevor Sie die Threads starten, und ändern Sie sie während der parallelen Arbeit nicht. Dies verhindert Rennbedingungen beim Zugriff auf gemeinsam genutzte Schriftressourcen.