---
title: Formen auf Präsentationsfolien skalieren
type: docs
weight: 110
url: /de/java/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Skalieren Sie Formen einfach auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Java - automatisieren Sie Folienlayout-Anpassungen und steigern Sie die Produktivität."
---
## **Übersicht**

Eine der häufigsten Fragen von Aspose.Slides for Java‑Kunden ist, wie man Formen so skalieren kann, dass bei einer Änderung der Foliengröße die Daten nicht abgeschnitten werden. Dieser kurze technische Artikel zeigt, wie das geht.

## **Formen skalieren**

Um zu verhindern, dass sich Formen bei einer Änderung der Foliengröße verschieben, aktualisieren Sie die Position und die Abmessungen jeder Form, sodass sie dem neuen Folienlayout entsprechen.

```java
import com.aspose.slides.*;

// Laden Sie die Präsentationsdatei.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Ermitteln Sie die ursprüngliche Foliengröße.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Ändern Sie die Foliengröße, ohne vorhandene Formen zu skalieren.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Ermitteln Sie die neue Foliengröße.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Formen auf jeder Folie skalieren und neu positionieren.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Skalieren Sie die Formgröße.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skalieren Sie die Formposition.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
Tabellen benötigen keine besondere Behandlung: Das Festlegen von Breite und Höhe einer Tabelle skaliert ihre Spalten und Zeilen proportional, sodass ein erneutes Skalieren von Zeilenhöhen und Spaltenbreiten das Verhältnis doppelt anwenden würde.
{{% /alert %}} 

Der obige Code ändert nur die Formen auf den Folien. Master‑Folien und Layout‑Folien behalten ihre eigenen Formen, daher sollten Sie diese ebenfalls skalieren, wenn die gesamte Präsentation der neuen Foliengröße folgen soll:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Originale Foliengröße ermitteln.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Neue Foliengröße ermitteln.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Formgröße skalieren.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Formposition skalieren.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Formgröße skalieren.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Formposition skalieren.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Formgröße skalieren.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Formposition skalieren.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

### Warum werden Formen nach dem Skalieren einer Folie verzerrt oder abgeschnitten?

Beim Skalieren einer Folie behalten Formen ihre ursprüngliche Position und Größe, wenn die Skalierung nicht ausdrücklich geändert wird. Das kann dazu führen, dass Inhalte abgeschnitten oder Formen verschoben werden.

### Funktioniert der bereitgestellte Code für alle Formtypen?

Ja. Das Festlegen von Höhe und Breite funktioniert gleichermaßen für Textfelder, Bilder, Diagramme und Tabellen.

### Wie skalieren Sie Tabellen beim Skalieren einer Folie?

Skalieren Sie die Tabellform selbst, genau wie jede andere Form. Ihre Zeilen und Spalten passen sich proportional an, daher dürfen Sie sie danach nicht erneut skalieren.

### Wird dieses Skalieren für Master‑Folien und Layout‑Folien funktionieren?

Ja, Sie sollten jedoch auch durch [Masterfolien](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getMasters--) und [Layout‑Folien](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getLayoutSlides--) iterieren und dieselbe Skalierungslogik auf deren Formen anwenden, um Konsistenz in der gesamten Präsentation zu gewährleisten.

### Kann ich die Ausrichtung einer Folie (Portrait/Landscape) zusammen mit dem Skalieren ändern?

Ja. Sie können [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidesize/#setOrientation-int-) verwenden, um die Ausrichtung zu ändern. Stellen Sie sicher, dass Sie die Skalierungslogik entsprechend anpassen, um das Layout beizubehalten.

### Gibt es ein Limit für die Foliengröße, die ich festlegen kann?

Aspose.Slides unterstützt benutzerdefinierte Größen, aber sehr große Größen können die Leistung beeinträchtigen oder die Kompatibilität mit einigen PowerPoint‑Versionen einschränken.

### Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?

Sie können die Methode `getAspectRatioLocked` der Form prüfen, bevor Sie skalieren. Ist sie gesperrt, passen Sie Breite oder Höhe proportional an, anstatt sie einzeln zu skalieren.