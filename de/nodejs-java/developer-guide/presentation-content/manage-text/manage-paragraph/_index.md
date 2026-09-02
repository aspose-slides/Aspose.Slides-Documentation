---
title: PowerPoint-Textabsätze in JavaScript verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
  - Text hinzufügen
  - Absatz hinzufügen
  - Text verwalten
  - Absatz verwalten
  - Aufzählungszeichen verwalten
  - Absatzeinzug
  - hängender Einzug
  - Absatz-Aufzählungszeichen
  - nummerierte Liste
  - Aufzählungsliste
  - Absatzeigenschaften
  - HTML importieren
  - Text zu HTML
  - Absatz zu HTML
  - Absatz zu Bild
  - Text zu Bild
  - Absatz exportieren
  - PowerPoint
  - Präsentation
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Node.js via Java Absätze, Textteile, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML‑Inhalte und Absatz‑Bilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für Node.js via Java stellt Text als Hierarchie von Textrahmen, Absätzen und Portionen dar:

* [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) repräsentiert den Textbehälter in einer Form und bietet Zugriff auf die Absatzsammlung.
* [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) steht für einen Absatz in einem Textrahmen und ermöglicht Zugriff auf seine Portionen sowie die Absatzformatierung.
* [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/) stellt einen Textlauf innerhalb eines Absatzes dar. Jede Portion kann eigene Texteigenschaften und Zeichenformatierungen besitzen.

Ein Absatz kann somit Text mit unterschiedlichen Schriften, Farben, Größen und sonstigen Formatierungen enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

### **Absätze mit mehreren Portionen erstellen**

Die folgenden Schritte erzeugen einen Textrahmen mit drei Absätzen, wobei jeder Absatz drei Portionen enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Klasse.
2. Greifen Sie über den Index auf die gewünschte Folie zu.
3. Fügen Sie der Folie eine rechteckige [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) der Form zu.
5. Verwenden Sie den Standardabsatz und fügen Sie dem Textrahmen zwei weitere [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/)-Objekte hinzu.
6. Fügen Sie für jeden Absatz so viele [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/)-Objekte hinzu, dass er drei Portionen enthält. Der Standardabsatz enthält bereits eine leere Portion.
7. Setzen Sie den Text jeder Portion.
8. Wenden Sie Zeichenformatierungen über [Portion.getPortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/getportionformat/) an.
9. Speichern Sie die geänderte Präsentation.

Dieses JavaScript‑Beispiel implementiert die Schritte:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aufzählungs‑ und Nummerierungslisten erstellen**

### **Aufzählungs‑ oder Nummerierungsliste erstellen**

Aufzählungszeichen und Nummerierungen erleichtern das Scannen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [BulletFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/) definiert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Klasse.
2. Greifen Sie über den Index auf die gewünschte Folie zu.
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) der Form zu.
5. Entfernen Sie den Standardabsatz aus dem Textrahmen.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) für ein Symbol‑Aufzählungszeichen.
7. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/settype/) auf [BulletType.Symbol](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bullettype/) und geben Sie das Aufzählungszeichen‑Symbol an.
8. Setzen Sie den Absatztext, Einzug, Aufzählungsfarbe und Aufzählungs‑Höhe.
9. Fügen Sie den Absatz dem Textrahmen hinzu.
10. Erstellen Sie einen zweiten Absatz und setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/settype/) auf [BulletType.Numbered](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bullettype/).
11. Konfigurieren Sie den nummerierten Aufzählungsstil und fügen Sie den Absatz dem Textrahmen hinzu.
12. Speichern Sie die Präsentation.

Dieses JavaScript‑Beispiel erzeugt ein Symbol‑Aufzählungszeichen und ein nummeriertes Aufzählungszeichen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bild‑Aufzählungszeichen verwenden**

Bild‑Aufzählungszeichen ermöglichen die Verwendung eines benutzerdefinierten Bildes anstelle eines Symbols oder einer Zahl.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Klasse.
2. Greifen Sie über den Index auf die gewünschte Folie zu.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu und greifen Sie auf dessen [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) zu.
4. Entfernen Sie den Standardabsatz aus dem Textrahmen.
5. Laden Sie das Aufzählungs‑Bild und fügen Sie es der Bildsammlung der Präsentation als [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) hinzu.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) und setzen Sie dessen Text.
7. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/settype/) auf [BulletType.Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bullettype/).
8. Weisen Sie das Bild über [BulletFormat.getPicture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/getpicture/) zu und setzen Sie die Aufzählungs‑Höhe.
9. Fügen Sie den Absatz dem Textrahmen hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieses JavaScript‑Beispiel erstellt ein Bild‑Aufzählungszeichen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Mehrstufige Liste erstellen**

Setzen Sie [ParagraphFormat.setDepth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setdepth/), um Absätze auf verschiedenen Ebenen einer Liste zu platzieren. Die oberste Ebene hat die Tiefe `0`.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu und löschen Sie den Standardabsatz aus dessen Textrahmen.
3. Erstellen Sie vier Absätze und konfigurieren Sie deren Aufzählungssymbole.
4. Setzen Sie deren [ParagraphFormat.setDepth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setdepth/)‑Werte auf `0`, `1`, `2` bzw. `3`.
5. Fügen Sie die Absätze dem Textrahmen hinzu und speichern Sie die Präsentation.

Dieses JavaScript‑Beispiel erzeugt eine vierstufige Aufzählungsliste:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Nummerierte Listenelemente mit benutzerdefinierten Startwerten beginnen**

Verwenden Sie [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/), um die Anfangszahl eines nummerierten Absatzes festzulegen.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) und fügen Sie einer Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
2. Entfernen Sie den Standardabsatz aus dem Textrahmen der Form.
3. Erstellen Sie drei nummerierte Absätze.
4. Setzen Sie [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) für die jeweiligen Absätze auf `2`, `3` bzw. `7`.
5. Fügen Sie die Absätze dem Textrahmen hinzu und speichern Sie die Präsentation.

Dieses JavaScript‑Beispiel weist jedem Absatz einen benutzerdefinierten Startwert zu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Absatzlayout und End‑Eigenschaften steuern**

### **Erstzeileneinzug festlegen**

Verwenden Sie [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/), um den Erstzeileneinzug eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Absatzrand. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setmarginleft/), wenn Sie den gesamten Absatz verschieben möchten. Verwenden Sie [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/), wenn Sie nur die erste Zeile verschieben wollen.

Im folgenden Beispiel werden mehrere Absätze erstellt und verschiedene [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/)-Werte angewendet, um zu zeigen, wie sich der Erstzeileneinzug auf das Layout auswirkt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Klasse.
2. Greifen Sie die Ziel‑Folien‑Index an.
3. Fügen Sie der Folie eine rechteckige [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie mehrere Absätze und setzen Sie unterschiedliche [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/)-Werte.
6. Fügen Sie die Absätze dem Textrahmen hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie man einen Absatz‑Einzug festlegt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Erstzeileneinzug der Absätze](first_line_indent.png)

### **Hängenden Einzug festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/). Übergeben Sie einen negativen Wert, um die erste Zeile relativ zum Absatzkörper nach links zu verschieben.

In der Praxis definiert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) die linke Position des Absatzkörpers, während [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/) die Position der ersten Zeile relativ zu diesem Rand festlegt. Um einen hängenden Einzug zu erzeugen, setzen Sie einen positiven Wert für `setMarginLeft` und einen negativen Wert für `setIndent`.

Diese Formatierung ist nützlich für Bibliographien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Klasse.
2. Greifen Sie die Ziel‑Folien‑Index an.
3. Fügen Sie der Folie eine rechteckige [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie Absätze und setzen Sie für jeden einen positiven Wert bei [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setmarginleft/).
6. Übergeben Sie einen negativen Wert an [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/), um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze dem Textrahmen hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie man einen hängenden Einzug für einen Absatz festlegt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der hängende Einzug der Absätze](hanging_indent.png)

### **End‑Absatz‑Lauf‑Eigenschaften festlegen**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) steuert die Formatierung des Absatzendezeichens. Das folgende Beispiel weist dem Endzeichen des zweiten Absatzes eine Schriftgröße und eine lateinische Schrift zu:

1. Erstellen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu und löschen Sie dessen Standardabsatz.
3. Erstellen Sie zwei Absätze und fügen Sie ihnen Textportionen hinzu.
4. Erstellen Sie ein [PortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portionformat/) für das Endzeichen des zweiten Absatzes.
5. Setzen Sie [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) und [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Weisen Sie das Format mit [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) zu und speichern Sie die Präsentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Absatzinhalt importieren und exportieren**

### **HTML‑Text in Absätze importieren**

Verwenden Sie [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/), um HTML‑Markup in Absätze und Portionen eines Textrahmens zu konvertieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Klasse.
2. Greifen Sie eine Folie zu und fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
3. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) der Form zu und löschen Sie den Standardabsatz.
4. Definieren oder lesen Sie den Quell‑HTML‑String.
5. Übergeben Sie den HTML‑String an [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Speichern Sie die geänderte Präsentation.

Dieses JavaScript‑Beispiel importiert HTML in einen Textrahmen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Absatztext nach HTML exportieren**

Verwenden Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/), um einen ausgewählten Absatzbereich als HTML zu exportieren.

1. Erstellen oder laden Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Klasse.
2. Greifen Sie die Folie zu und finden Sie das [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/), das den Text enthält.
3. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) der Form zu.
4. Rufen Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) mit dem Start‑Absatz‑Index und der Anzahl der zu exportierenden Absätze auf.
5. Schreiben Sie den zurückgegebenen HTML‑String in eine Datei.

Dieses eigenständige JavaScript‑Beispiel erstellt eine Textform und exportiert alle ihre Absätze:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Einen Absatz als Bild rendern**

[Paragraph.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/#getImage) rendert einen einzelnen Absatz direkt und gibt ein [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) zurück. Speichern Sie das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/#save) in einer Datei. Sie müssen nicht die umgebende Form rendern oder ein Bitmap manuell zuschneiden.

[Paragraph.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/#getImage) kann `null` zurückgeben, wenn der Absatz nicht in seiner übergeordneten Sammlung gefunden wird, keine gültigen Render‑Grenzen hat oder nicht gerendert werden kann. Prüfen Sie das Ergebnis, bevor Sie es speichern, und entsorgen Sie das zurückgegebene Bild nach Gebrauch.

#### **Absatz mit Standard‑Skala rendern**

Der folgende Textkasten enthält drei Absätze:

![Der Textkasten mit drei Absätzen](paragraph_to_image_input.png)

Das nachfolgende Beispiel rendert den zweiten Absatz in einer regulären Textform bei Standard‑Skala und speichert das zurückgegebene Bild im PNG‑Format. Der `finally`‑Block stellt sicher, dass das Bild korrekt freigegeben wird.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Das Absatz‑Bild](paragraph_to_image_output.png)

#### **Absatz in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die [Paragraph.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/#getImage)-Überladung, die die Parameter `scaleX` und `scaleY` akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in der ersten Zelle mit dem Doppelten seiner Standard‑Breite und -Höhe und speichert das Ergebnis als PNG‑Bild.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Ein Skalierungsfaktor von `1` lässt die jeweilige Achse bei ihrer Standard‑Pixelgröße. Beispielsweise erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa doppelt so groß sind wie die Standard‑Abmessungen, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen im Allgemeinen schärferen Text für Zoom‑ oder Hochauflösungs‑Ausgaben, erhöhen jedoch Speicherverbrauch und Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Absatzes zu erhalten; unterschiedliche horizontale und vertikale Faktoren strecken die Ausgabe unabhängig voneinander.

Das Rendern einer gesamten Form mit [Shape.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getImage) bleibt sinnvoll, wenn das Ergebnis die Füllung, den Rand oder andere visuelle Kontextinformationen der Form enthalten soll. Für ein reines Absatz‑Bild verwenden Sie [Paragraph.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Kann ich das Zeilenumbruchverhalten in einem Textrahmen vollständig deaktivieren?**

Ja. Setzen Sie [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/setwraptext/) auf `false`, um das Umbrechen zu deaktivieren, damit Zeilen nicht an den Rändern des Textrahmens brechen.

**Wie erhalte ich die exakten on‑slide‑Grenzen eines bestimmten Absatzes?**

Verwenden Sie [Paragraph.getRect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/getrect/), um das begrenzende Rechteck des Absatzes zu erhalten. [Portion.getRect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#getRect) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatz‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setalignment/) ist eine Absatz‑Ebene‑Einstellung und gilt für den gesamten Absatz, unabhängig von individuellen Portion‑Formatierungen.

**Kann ich die Korrektursprache für einen Teil eines Absatzes festlegen?**

Ja. Setzen Sie [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) für einzelne Portionen, sodass ein Absatz Text in mehreren Sprachen enthalten kann.