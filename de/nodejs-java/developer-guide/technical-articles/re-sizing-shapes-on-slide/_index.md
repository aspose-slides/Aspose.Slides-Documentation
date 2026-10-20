---
title: Formen auf Präsentationsfolien in Node.js skalieren
type: docs
weight: 130
url: /de/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/groessen-anpassen-formen-auf-folie/
  - /de/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Einfach Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Node.js via Java skalieren – automatisieren Sie Folienlayout-Anpassungen und steigern Sie die Produktivität."
---
## **Übersicht**

Wenn Sie die Foliengröße einer Präsentation ändern, müssen Sie möglicherweise auch die Formen skalieren und ihre Positionen anpassen, damit sie in die neuen Abmessungen passen. Dieser Artikel zeigt, wie man Formen manuell skaliert und wie man Tabellen auf Folien, Masterfolien und Layouts behandelt.

## **Formen skalieren**

Um die relative Position und Größe jeder Form beizubehalten, multiplizieren Sie ihre horizontalen Koordinaten und Breite mit dem Verhältnis der neuen Folienbreite zur ursprünglichen Breite. Wenden Sie das entsprechende Höhenverhältnis auf ihre vertikalen Koordinaten und Höhe an.

Das erste Beispiel lädt eine Präsentation, deren Folien keine Tabellen enthalten, ändert die Foliengröße zu A4 und speichert das Ergebnis. Es verwendet [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) mit [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale), sodass die nachfolgende Schleife die Skalierung steuert. Die Verhältnisse sind einheitenlos; Positionen und Abmessungen von Formen werden in Punkten gemessen. Unterschiedliche Breiten‑ und Höhenverhältnisse können Formen verzerren, und das Ändern der Formabmessungen skaliert die Schriftgrößen nicht.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Hinweis" %}}
Tabellen erfordern eine separate Behandlung: Skalieren Sie ihre Spaltenbreiten und Zeilenhöhen, anstatt die Gesamtabmessungen der Tabelle zuzuweisen. Zeilenhöhen können größer bleiben als angefordert, wenn der Zellinhalt mehr Platz benötigt.
{{% /alert %}}

Das zweite Beispiel unterstützt Tabellen und verarbeitet Formen auf Master‑ und Layout‑Folien sowie einzelne Folien, bevor die skalierte Präsentation gespeichert wird. Sein Helfer behandelt jede [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) indem er die Spaltenbreiten mit [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) und die minimalen Zeilenhöhen mit [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) skaliert. Anschließend wird die Position der Tabelle skaliert, ohne ihre Gesamtabmessungen separat zu skalieren.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Tabellendimensionen werden durch Spaltenbreiten und Zeilenhöhen gesteuert.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Formen auf Master- und Layout-Folien sowie einzelnen Folien skalieren.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Warum werden Formen nach dem Ändern der Foliengröße verzerrt oder abgeschnitten?**  
Wenn Sie die Foliengröße ändern, ohne die Formen zu skalieren, behalten sie ihre ursprünglichen Positionen und Abmessungen bei und können über die Folie hinausgehen. Das Skalieren von Breite und Höhe mit unterschiedlichen Verhältnissen kann Formen ebenfalls verzerren.

**Funktioniert der bereitgestellte Code für alle Formtypen?**  
Das erste Beispiel ändert die Formgrenzen direkt und ist für Folien ohne Tabellen vorgesehen. Das zweite Beispiel behandelt Tabellen separat. Überprüfen Sie das resultierende Layout, insbesondere Text und Tabellen, da diese Beispiele die Schriftgrößen nicht skalieren und Tabelleninhalte die Zeilenhöhen einschränken können.

**Wie kann ich Tabellen beim Ändern der Foliengröße skalieren?**  
Skalieren Sie die Spaltenbreiten mit dem Breitenverhältnis und die minimalen Zeilenhöhen mit dem Höhenverhältnis, anschließend skalieren Sie die Position der Tabelle, wie im zweiten Beispiel gezeigt.

**Funktioniert diese Skalierung für Master‑Folien und Layout‑Folien?**  
Ja. Das zweite Beispiel iteriert über [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) und über die [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) jedes Masters und wendet dieselbe Skalierungslogik auf deren Formen an.

**Kann ich die Ausrichtung einer Folie (Hochformat/Landschaft) zusammen mit der Skalierung ändern?**  
Ja. Rufen Sie [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) nach dem Ändern der Foliengröße und bevor Sie die Zielabmessungen auslesen auf, damit die Skalierungsfaktoren die endgültige Ausrichtung berücksichtigen.

**Gibt es ein Limit für die Foliengröße, die ich festlegen kann?**  
Sie können benutzerdefinierte Folienabmessungen mit [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) festlegen. Die unterstützten Abmessungen hängen zudem vom Präsentationsformat und von der Anwendung ab, mit der die Datei geöffnet wird.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**  
Verwenden Sie denselben Skalierungsfaktor für Breite und Höhe. Um das ursprüngliche Layout in die neuen Folienabmessungen einzupassen, nutzen Sie das kleinere der Breiten‑ oder Höhenverhältnisse für beide Dimensionen und Positionen. Dadurch bleiben die Proportionen erhalten, es kann jedoch an einer Kante ungenutzter Raum verbleiben.