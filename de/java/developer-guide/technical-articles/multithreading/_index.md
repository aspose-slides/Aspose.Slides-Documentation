---
title: Multithreading in Aspose.Slides für Java
linktitle: Multithreading
type: docs
weight: 310
url: /de/java/multithreading/
keywords:
- Multithreading
- Mehrere Threads
- Parallele Verarbeitung
- Folien konvertieren
- Folien zu Bildern
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Aspose.Slides für Java Multithreading beschleunigt die Verarbeitung von PowerPoint und OpenDocument. Entdecken Sie bewährte Methoden für effiziente Präsentationsworkflows."
---

## **Einführung**

Während parallele Arbeit mit Präsentationen möglich ist (abgesehen vom Parsen/Laden/Klonen) und meistens alles gut funktioniert, besteht eine geringe Wahrscheinlichkeit, dass Sie bei der Verwendung der Bibliothek in mehreren Threads falsche Ergebnisse erhalten.

Wir empfehlen dringend, dass Sie in einer Multi‑Threading‑Umgebung **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Instanz verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind. 

Es ist **nicht** sicher, in mehreren Threads eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse zu laden, zu speichern und/oder zu klonen. Solche Vorgänge werden **nicht** unterstützt. Wenn Sie solche Aufgaben ausführen müssen, sollten Sie die Vorgänge mithilfe mehrerer ein‑threadiger Prozesse parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden. 

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien einer PowerPoint‑Präsentation parallel in PNG‑Bilder konvertieren. Da es unsicher ist, eine einzelne `Presentation`‑Instanz in mehreren Threads zu verwenden, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, wobei jede Präsentation in einem eigenen Thread verwendet wird. Das folgende Code‑Beispiel zeigt, wie das funktioniert.
```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extrahiere Folie i in eine separate Präsentation.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Konvertiere die Folie in ein Bild in einem separaten Task.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Warte, bis alle Tasks abgeschlossen sind.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```


## **FAQ**

**Muss ich die Lizenzinitialisierung in jedem Thread aufrufen?**

Nein. Es reicht, dies einmal pro Prozess/App‑Domain vor dem Start der Threads zu tun. Wenn [license setup](/slides/de/java/licensing/) möglicherweise parallel aufgerufen wird (zum Beispiel während einer Lazy‑Initialisierung), synchronisieren Sie diesen Aufruf, da die Lizenzinitialisierungsmethode selbst nicht thread‑sicher ist.

**Kann ich `Presentation`‑ oder `Slide`‑Objekte zwischen Threads übergeben?**

Das Übergeben von „lebenden“ Präsentationsobjekten zwischen Threads wird nicht empfohlen: Verwenden Sie unabhängige Instanzen pro Thread oder erstellen Sie separate Präsentationen/Slide‑Container für jeden Thread im Voraus. Dieser Ansatz folgt der allgemeinen Empfehlung, keine einzelne Präsentationsinstanz über Threads hinweg zu teilen.

**Ist es sicher, den Export in verschiedene Formate (PDF, HTML, Bilder) zu parallelisieren, sofern jeder Thread seine eigene `Presentation`‑Instanz hat?**

Ja. Mit unabhängigen Instanzen und separaten Ausgabepfaden lassen sich solche Aufgaben in der Regel korrekt parallelisieren; vermeiden Sie gemeinsam genutzte Präsentationsobjekte und gemeinsam genutzte I/O‑Ströme.

**Wie soll ich mit globalen Font‑Einstellungen (Ordner, Ersetzungen) beim Multithreading umgehen?**

Initialisieren Sie alle globalen [font settings](/slides/de/java/powerpoint-fonts/) vor dem Start der Threads und ändern Sie sie während der parallelen Arbeit nicht. Dadurch entfallen Rennbedingungen beim Zugriff auf gemeinsam genutzte Font‑Ressourcen.