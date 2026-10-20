---
title: Formen auf Präsentationsfolien in Java skalieren
type: docs
weight: 130
url: /de/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /de/java/re-sizing-shapes-on-slide/
keywords:
  - Form skalieren
  - Formgröße ändern
  - PowerPoint
  - OpenDocument
  - Präsentation
  - Java
  - Aspose.Slides
description: "Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Java ganz einfach skalieren – Folienlayout‑Anpassungen automatisieren und die Produktivität steigern."
---
## **Übersicht**

Wenn Sie die Foliengröße einer Präsentation ändern, müssen Sie möglicherweise auch die Formen neu skalieren und neu positionieren, damit sie in die neuen Abmessungen passen. Dieser Artikel zeigt, wie man Formen manuell skaliert und wie man Tabellen auf Folien, Masterfolien und Layouts behandelt.

## **Formen skalieren**

Um die relative Position und Größe jeder Form beizubehalten, multiplizieren Sie ihre horizontalen Koordinaten und Breite mit dem Verhältnis der neuen Folienbreite zur Originalbreite. Wenden Sie das entsprechende Höhenverhältnis auf ihre vertikalen Koordinaten und Höhe an.

Das erste Beispiel lädt eine Präsentation, deren Folien keine Tabellen enthalten, ändert die Foliengröße auf A4 und speichert das Ergebnis. Es verwendet [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) mit [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale), sodass die nachfolgende Schleife die Skalierung steuert. Die Verhältnisse sind einheitenlos; Formpositionen und -abmessungen werden in Punkten gemessen. Unterschiedliche Breiten- und Höhenverhältnisse können Formen verzerren, und das Ändern der Formabmessungen skaliert die Schriftgrößen nicht.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

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
Tabellen erfordern eine separate Behandlung: Skalieren Sie deren Spaltenbreiten und Zeilenhöhen, anstatt die Gesamtabmessungen der Tabelle festzulegen. Zeilenhöhen können größer bleiben als angefordert, wenn der Zellinhalt mehr Platz benötigt.
{{% /alert %}}

Das zweite Beispiel unterstützt Tabellen und verarbeitet Formen auf Masterfolien und Layouts sowie einzelne Folien, bevor die skalierte Präsentation gespeichert wird. Sein Helfer verarbeitet jede [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) indem er die Spaltenbreiten mit [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) und die minimalen Zeilenhöhen mit [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) skaliert. Anschließend wird die Position der Tabelle skaliert, ohne ihre Gesamtabmessungen separat zu skalieren.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Tabellendimensionen werden über Spaltenbreiten und Zeilenhöhen gesteuert.
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
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

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

**Warum werden Formen nach dem Ändern der Foliengröße verzerrt oder abgeschnitten?**

Wenn Sie die Foliengröße ändern, ohne die Formen zu skalieren, behalten diese ihre ursprünglichen Positionen und Abmessungen bei und können über die Folie hinausreichen. Das Skalieren von Breite und Höhe mit unterschiedlichen Verhältnissen kann ebenfalls Formen verzerren.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das erste Beispiel ändert die Formgrenzen direkt und ist für Folien ohne Tabellen vorgesehen. Das zweite Beispiel behandelt Tabellen separat. Überprüfen Sie das resultierende Layout, insbesondere Text und Tabellen, da diese Beispiele die Schriftgrößen nicht skalieren und Tabelleninhalte die Zeilenhöhen einschränken können.

**Wie kann ich Tabellen beim Ändern der Foliengröße skalieren?**

Skalieren Sie die Spaltenbreiten mit dem Breitenverhältnis und die minimalen Zeilenhöhen mit dem Höhenverhältnis, dann skalieren Sie die Position der Tabelle, wie im zweiten Beispiel gezeigt.

**Funktioniert diese Skalierung für Masterfolien und Layoutfolien?**

Ja. Das zweite Beispiel durchläuft [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) und für jede Masterfolie die [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) und wendet dieselbe Skalierungslogik auf deren Formen an.

**Kann ich die Ausrichtung einer Folie (Hochformat/Querformat) zusammen mit der Skalierung ändern?**

Ja. Rufen Sie [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) nach dem Ändern der Foliengröße und vor dem Auslesen der Zielabmessungen auf, damit die Skalierungsfaktoren die endgültige Ausrichtung berücksichtigen.

**Gibt es eine Obergrenze für die Foliengröße, die ich festlegen kann?**

Sie können benutzerdefinierte Folienabmessungen mit [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) festlegen. Die unterstützten Abmessungen hängen zudem vom Präsentationsformat und der Anwendung ab, mit der die Datei geöffnet wird.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Verwenden Sie denselben Skalierungsfaktor für Breite und Höhe. Um das ursprüngliche Layout in die neuen Folienabmessungen einzupassen, nutzen Sie das kleinere der Breiten‑ und Höhenverhältnisse für beide Dimensionen und Positionen. Dadurch bleiben die Proportionen erhalten, es kann jedoch an einer Kante ungenutzter Raum bleiben.