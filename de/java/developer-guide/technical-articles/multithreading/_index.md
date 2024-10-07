---
title: Multithreading in Aspose.Slides
type: docs
weight: 310
url: /java/multithreading/
keywords:
- PowerPoint
- Präsentation
- Multithreading
- paralleles Arbeiten
- Folien konvertieren
- Folien in Bilder
- Java
- Aspose.Slides für Java
---

## **Einführung**

Obwohl paralleles Arbeiten mit Präsentationen möglich ist (neben dem Parsen/Laden/Klonen) und meistens alles gut funktioniert, besteht eine geringe Wahrscheinlichkeit, dass Sie bei der Verwendung der Bibliothek in mehreren Threads inkorrekte Ergebnisse erhalten.

Wir empfehlen dringend, **keine** einzelne [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Instanz in einer Mehrthread-Umgebung zu verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen könnte, die nicht leicht zu erkennen sind.

Es ist **nicht** sicher, eine Instanz einer [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Solche Operationen werden **nicht** unterstützt. Wenn Sie solche Aufgaben ausführen müssen, sollten Sie die Operationen unter Verwendung mehrerer einzelner Prozesse mit einem Thread parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien aus einer PowerPoint-Präsentation parallel in PNG-Bilder konvertieren. Da es unsicher ist, eine einzige `Presentation` Instanz in mehreren Threads zu verwenden, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, indem wir jede Präsentation in einem separaten Thread verwenden. Das folgende Codebeispiel zeigt, wie man dies erreicht.

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
    // Folie i in eine separate Präsentation extrahieren.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Konvertiere die Folie in ein Bild in einer separaten Aufgabe.
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

// Auf den Abschluss aller Aufgaben warten.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```