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
description: "Skalieren Sie Formen auf PowerPoint- und OpenDocument-Folien ganz einfach mit Aspose.Slides für Java—automatisieren Sie Folienlayout-Anpassungen und steigern Sie die Produktivität."
---

## **Übersicht**

Eine der häufigsten Fragen von Aspose.Slides‑für‑Java‑Kunden ist, wie Formen skaliert werden können, damit beim Ändern der Foliengröße die Daten nicht abgeschnitten werden. Dieser kurze technische Artikel zeigt, wie das funktioniert.

## **Formen skalieren**

Um zu verhindern, dass Formen bei Änderungen der Foliengröße verschoben werden, aktualisieren Sie die Position und Größe jeder Form, sodass sie dem neuen Folienlayout entsprechen.
```java
// Präsentationsdatei laden.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Originale Foliengröße abrufen.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Neue Foliengröße abrufen.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Formen auf jeder Folie skalieren und neu positionieren.
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


{{% alert color="primary" %}} 
Enthält eine Folie eine Tabelle, funktioniert der obige Code nicht korrekt. In diesem Fall muss jede Zelle der Tabelle skaliert werden.
{{% /alert %}} 

Verwenden Sie den folgenden Code, um Folien, die Tabellen enthalten, zu skalieren. Für Tabellen ist das Festlegen von Breite oder Höhe ein Sonderfall: Sie müssen die einzelnen Zeilenhöhen und Spaltenbreiten anpassen, um die Gesamtabmessungen der Tabelle zu ändern.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Originale Foliengröße abrufen.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Neue Foliengröße abrufen.
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
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


## **FAQ**

**Warum werden Formen nach dem Skalieren einer Folie verzerrt oder abgeschnitten?**

Beim Skalieren einer Folie behalten Formen ihre ursprüngliche Position und Größe bei, sofern die Skalierung nicht explizit geändert wird. Das kann dazu führen, dass Inhalte beschnitten oder Formen verschoben werden.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das Grundbeispiel funktioniert für die meisten Formtypen (Textfelder, Bilder, Diagramme usw.). Für Tabellen muss jedoch jede Zeile und Spalte separat behandelt werden, da die Höhe und Breite einer Tabelle durch die Abmessungen der einzelnen Zellen bestimmt werden.

**Wie skalieren Sie Tabellen beim Skalieren einer Folie?**

Sie müssen alle Zeilen und Spalten der Tabelle durchlaufen und deren Höhe und Breite proportional anpassen, wie im zweiten Codebeispiel gezeigt.

**Funktioniert dieses Skalieren für Masterfolien und Layoutfolien?**

Ja, aber Sie sollten auch durch [Masterfolien](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) und [Layoutfolien](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) iterieren und dieselbe Skalierungslogik auf deren Formen anwenden, um Konsistenz über die gesamte Präsentation hinweg zu gewährleisten.

**Kann ich die Ausrichtung einer Folie (Portrait/Landschaft) zusammen mit dem Skalieren ändern?**

Ja. Sie können [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#setOrientation-int-) verwenden, um die Ausrichtung zu ändern. Stellen Sie sicher, dass Sie die Skalierungslogik entsprechend anpassen, um das Layout beizubehalten.

**Gibt es eine Grenze für die Foliengröße, die ich einstellen kann?**

Aspose.Slides unterstützt benutzerdefinierte Größen, aber sehr große Größen können die Leistung beeinträchtigen oder die Kompatibilität mit manchen PowerPoint‑Versionen einschränken.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Sie können vor dem Skalieren die Methode `getAspectRatioLocked` der Form prüfen. Ist sie gesperrt, passen Sie Breite oder Höhe proportional an, anstatt sie einzeln zu skalieren.