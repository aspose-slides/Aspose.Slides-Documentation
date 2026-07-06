---
title: Textabschnittsgrenzen aus Präsentationen in JavaScript ermitteln
linktitle: Abschnittsgrenzen
type: docs
weight: 47
url: /de/nodejs-java/portion-bounds/
keywords:
- Textabschnittsgrenzen
- Textabschnitt
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textabschnittsgrenzen in PowerPoint-Präsentationen mithilfe von Aspose.Slides für Node.js über Java abrufen."
---
## **Übersicht**

Ein Textabschnitt stellt ein bestimmtes Fragment von Text innerhalb eines Absatzes dar und ermöglicht es Ihnen, mit diesem Fragment unabhängig vom umgebenden Inhalt zu arbeiten. In Aspose.Slides können Abschnitte verwendet werden, wenn Sie die Begrenzungsrahmen eines Textfragments ermitteln, Formatierungen nur auf einen Teil eines Absatzes anwenden oder das Textverhalten auf einer detaillierteren Ebene steuern müssen.

Dieser Artikel zeigt, wie man das Begrenzungsrechteck eines Abschnitts mit [Portion.getRect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/getrect/) ermittelt. Er zeigt außerdem, wie man die Koordinaten des Beginns eines Abschnitts mit [Portion.getCoordinates](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/getcoordinates/) erhält. Darüber hinaus werden gängige szenarienbezogene Anwendungsfälle vorgestellt, z. B. das Anwenden eines Hyperlinks auf ein einzelnes Textfragment, das Verständnis der Stilvererbung über Abschnitt, Absatz, Textfeld und Thema hinweg sowie der Umgang mit fehlenden Schriftarten.

## **Grenzrechteck eines Textabschnitts ermitteln**

Verwenden Sie [Portion.getRect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/getrect/), um das Begrenzungsrechteck eines Textabschnitts abzurufen:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Koordinaten eines Textabschnitts ermitteln**

Verwenden Sie [Portion.getCoordinates](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/getcoordinates/), um die Koordinaten des Beginns eines Textabschnitts abzurufen:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/nodejs-java/manage-hyperlinks/) zu einer einzelnen Portion; nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt eine Portion und was wird aus einem Absatz oder Textfeld übernommen?**

Eigenschaften auf Portionsebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf der [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/) festgelegt ist, übernimmt Aspose.Slides sie von dem [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/). Ist sie dort ebenfalls nicht gesetzt, verwendet Aspose.Slides den Stil des [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) oder des [theme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/theme/).

**Was passiert, wenn die für eine Portion angegebene Schriftart auf dem Zielrechner oder Server fehlt?**

[Font substitution rules](/slides/de/nodejs-java/font-selection-sequence/) werden angewendet. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für eine präzise Positionierung wichtig ist.

**Kann ich für eine Portion die Transparenz oder einen Farbverlauf der Textfüllung unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf der [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/) Ebene können von benachbarten Fragmenten abweichen.