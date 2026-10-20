---
title: Formen auf Präsentationsfolien unter Android skalieren
type: docs
weight: 130
url: /de/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Aspose.Slides
description: "Einfach Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Android via Java skalieren – automatisieren Sie Folienlayout-Anpassungen und steigern Sie die Produktivität."
---
## **Übersicht**

Wenn Sie die Foliengröße einer Präsentation ändern, müssen Sie möglicherweise auch die Formen skalieren und neu positionieren, damit sie in die neuen Abmessungen passen. Dieser Artikel zeigt, wie Formen manuell skaliert werden können und wie Tabellen auf Folien, Masterfolien und Layouts behandelt werden.

## **Formen skalieren**

Um die relative Position und Größe jeder Form beizubehalten, multiplizieren Sie ihre horizontalen Koordinaten und die Breite mit dem Verhältnis der neuen Folienbreite zur ursprünglichen Breite. Wenden Sie das entsprechende Höhen‑Verhältnis auf ihre vertikalen Koordinaten und Höhe an.

Das erste Beispiel lädt eine Präsentation, deren Folien keine Tabellen enthalten, ändert die Foliengröße zu A4 und speichert das Ergebnis. Es verwendet [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) mit [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale), sodass die nachfolgende Schleife die Skalierung steuert. Die Verhältnisse sind ohne Einheit; Formpositionen und -abmessungen werden in Punkten gemessen. Unterschiedliche Breiten‑ und Höhen‑Verhältnisse können Formen verzerren, und das Ändern der Formabmessungen skaliert die Schriftgrößen nicht.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabellen erfordern eine separate Behandlung: Skalieren Sie ihre Spaltenbreiten und Zeilenhöhen, anstatt die Gesamtabmessungen der Tabelle zuzuweisen. Die Zeilenhöhen können größer bleiben als angefordert, wenn der Zellinhalt mehr Platz benötigt.
{{% /alert %}}

Das zweite Beispiel unterstützt Tabellen und verarbeitet Formen auf Master‑ und Layout‑Folien sowie einzelne Folien, bevor die skalierte Präsentation gespeichert wird. Der Helfer behandelt jedes [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) indem er die Spaltenbreiten mit [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) und die minimalen Zeilenhöhen mit [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) skaliert. Anschließend wird die Position der Tabelle skaliert, ohne ihre Gesamtabmessungen gesondert zu skalieren.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Tabellendimensionen werden durch Spaltenbreiten und Zeilenhöhen gesteuert.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Formen, die auf Master‑ und Layout‑Folien sowie einzelnen Folien definiert sind, skalieren.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Warum werden Formen nach dem Ändern einer Folie verzerrt oder abgeschnitten?**

Wenn Sie die Foliengröße ändern, ohne die Formen zu skalieren, behalten sie ihre ursprünglichen Positionen und Abmessungen bei und können über die Folie hinausgehen. Das Skalieren von Breite und Höhe mit unterschiedlichen Verhältnissen kann ebenfalls Formen verzerren.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das erste Beispiel ändert die Formgrenzen direkt und ist für Folien ohne Tabellen gedacht. Das zweite Beispiel behandelt Tabellen separat. Überprüfen Sie das resultierende Layout, insbesondere Text und Tabellen, da diese Beispiele die Schriftgrößen nicht skalieren und Tabelleninhalte die Zeilenhöhen einschränken können.

**Wie kann ich Tabellen beim Ändern der Foliengröße skalieren?**

Skalieren Sie die Spaltenbreiten nach dem Breiten‑Verhältnis und die minimalen Zeilenhöhen nach dem Höhen‑Verhältnis, und skalieren Sie anschließend die Position der Tabelle, wie im zweiten Beispiel gezeigt.

**Funktioniert diese Größenänderung für Masterfolien und Layoutfolien?**

Ja. Das zweite Beispiel iteriert über [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) und über jede Master‑Folien‑[IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) und wendet dieselbe Skalierungslogik auf deren Formen an.

**Kann ich die Ausrichtung einer Folie (Hochformat/Landformat) zusammen mit der Größenänderung ändern?**

Ja. Rufen Sie nach dem Ändern der Foliengröße und vor dem Auslesen der Zielabmessungen [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) auf, sodass die Skalierungsfaktoren die endgültige Ausrichtung berücksichtigen.

**Gibt es ein Limit für die Foliengröße, die ich festlegen kann?**

Sie können benutzerdefinierte Folienabmessungen mit [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) angeben. Die unterstützten Abmessungen hängen zudem vom Präsentationsformat und von der Anwendung ab, die die Datei öffnet.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Verwenden Sie denselben Skalierungsfaktor für Breite und Höhe. Um das ursprüngliche Layout innerhalb der neuen Folienabmessungen passend zu machen, verwenden Sie das kleinere der Breiten‑ oder Höhen‑Verhältnisse für beide Dimensionen und Positionen. Das bewahrt die Proportionen, kann jedoch an einer Kante ungenutzten Raum hinterlassen.