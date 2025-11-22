---
title: Multithreading in Aspose.Slides
type: docs
weight: 310
url: /de/net/multithreading/
keywords:
- PowerPoint
- Präsentation
- Multithreading
- Parallele Arbeit
- Folien konvertieren
- Folien zu Bildern
- C#
- .NET
- Aspose.Slides für .NET
---

## **Einleitung**

Während parallele Arbeit mit Präsentationen (außer Parsing/Laden/Klonen) möglich ist und meistens alles gut funktioniert, besteht eine geringe Wahrscheinlichkeit, dass Sie falsche Ergebnisse erhalten, wenn Sie die Bibliothek in mehreren Threads verwenden.

Wir empfehlen dringend, **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Instanz in einer Multi‑Thread‑Umgebung zu verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht erkannt werden.

Es ist **nicht** sicher, eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Derartige Vorgänge werden **nicht** unterstützt.  Wenn Sie solche Aufgaben ausführen müssen, müssen Sie die Vorgänge parallel mit mehreren ein‑Thread‑Prozessen ausführen – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien einer PowerPoint‑Präsentation parallel in PNG‑Bilder konvertieren. Da es unsicher ist, eine einzelne `Presentation` Instanz in mehreren Threads zu verwenden, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, wobei jede Präsentation in einem eigenen Thread verwendet wird. Das folgende Codebeispiel zeigt, wie das geht.
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
    // Folie i in eine separate Präsentation extrahieren.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Folie in ein Bild in einem separaten Task konvertieren.
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

**Muss ich die Lizenzkonfiguration in jedem Thread aufrufen?**

Nein. Es reicht, sie einmal pro Prozess/App‑Domain vor dem Start der Threads aufzurufen. Wenn [license setup](/slides/de/net/licensing/) gleichzeitig (z. B. bei Lazy‑Initialisierung) aufgerufen werden könnte, synchronisieren Sie diesen Aufruf, da die Lizenzkonfigurations‑Methode selbst nicht thread‑sicher ist.

**Kann ich `Presentation`‑ oder `Slide`‑Objekte zwischen Threads übergeben?**

Das Übergeben von „Live“-Präsentationsobjekten zwischen Threads wird nicht empfohlen: Verwenden Sie unabhängige Instanzen pro Thread oder erstellen Sie für jeden Thread separate Präsentationen/Slide‑Container im Voraus. Dieser Ansatz folgt der allgemeinen Empfehlung, keine einzelne Präsentationsinstanz über Threads hinweg zu teilen.

**Ist es sicher, den Export in verschiedene Formate (PDF, HTML, Bilder) zu parallelisieren, sofern jeder Thread seine eigene `Presentation`‑Instanz hat?**

Ja. Mit unabhängigen Instanzen und separaten Ausgabepfaden lassen sich solche Aufgaben in der Regel korrekt parallelisieren; vermeiden Sie gemeinsam genutzte Präsentationsobjekte und geteilte I/O‑Streams.

**Wie soll ich mit globalen Schriftarteinstellungen (Ordner, Substitutionen) beim Multithreading umgehen?**

Initialisieren Sie alle globalen Schriftarteinstellungen, bevor Sie die Threads starten, und ändern Sie sie während der parallelen Arbeit nicht. So werden Rennbedingungen beim Zugriff auf gemeinsam genutzte Schriftressourcen vermieden.