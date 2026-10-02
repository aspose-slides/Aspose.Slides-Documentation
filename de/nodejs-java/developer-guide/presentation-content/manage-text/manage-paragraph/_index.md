---
title: Verwalten von PowerPoint-Textabsätzen in JavaScript
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
- Hängender Einzug
- Absatz-Aufzählungszeichen
- Nummerierte Liste
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
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Node.js über Java Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML-Inhalte und Absatz-Bilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides for Node.js via Java stellt Text als eine Hierarchie aus TextFrames, Paragraphen und Portionen dar:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) repräsentiert den Textcontainer in einer Form und bietet Zugriff auf die zugehörige Paragraphensammlung.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) repräsentiert einen Absatz in einem TextFrame und ermöglicht den Zugriff auf seine Portionen sowie die Absatzformatierung.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) repräsentiert einen Textlauf innerhalb eines Absatzes. Jede Portion kann eigenen Text und Zeichenformatierungen besitzen.

Ein Absatz kann daher Text mit unterschiedlichen Schriften, Farben, Größen und weiterer Formatierung enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

### **Absätze mit mehreren Portionen erstellen**

Die folgenden Schritte erzeugen ein TextFrame mit drei Absätzen, die jeweils drei Portionen enthalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die gewünschte Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) der Form zu.
5. Verwenden Sie den Standard‑Paragraph und fügen Sie dem TextFrame zwei weitere [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)‑Objekte hinzu.
6. Fügen Sie für jeden Absatz genügend [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)‑Objekte hinzu, damit er drei Portionen enthält. Der Standard‑Paragraph enthält bereits eine leere Portion.
7. Setzen Sie den Text jeder Portion.
8. Wenden Sie Zeichenformatierung über [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/) an.
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

### **Aufzählungs‑ oder nummerierte Liste erstellen**

Aufzählungszeichen und Nummerierungen erleichtern das Scannen zusammenhängender Punkte. In Aspose.Slides werden Listeneinstellungen über [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) definiert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die gewünschte Folie zu.
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) der Form zu.
5. Entfernen Sie den Standard‑Paragraph aus dem TextFrame.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) für ein Symbol‑Aufzählungszeichen.
7. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) auf [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) und geben Sie das Aufzählungszeichen‑Symbol an.
8. Setzen Sie den Paragraph‑Text, den Einzug, die Aufzählungszeichen‑Farbe und die Aufzählungszeichen‑Höhe.
9. Fügen Sie den Paragraph dem TextFrame hinzu.
10. Erstellen Sie einen zweiten Paragraph und setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) auf [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/).
11. Konfigurieren Sie den nummerierten Aufzählungsstil und fügen Sie den Paragraph dem TextFrame hinzu.
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die gewünschte Folie zu.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu und greifen Sie auf dessen [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) zu.
4. Entfernen Sie den Standard‑Paragraph aus dem TextFrame.
5. Laden Sie das Aufzählungszeichen‑Bild und fügen Sie es der Bildsammlung der Präsentation als [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) hinzu.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) und setzen Sie dessen Text.
7. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) auf [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/).
8. Ordnen Sie das Bild über [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) zu und setzen Sie die Aufzählungszeichen‑Höhe.
9. Fügen Sie den Paragraph dem TextFrame hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieses JavaScript‑Beispiel erzeugt ein Bild‑Aufzählungszeichen:

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

Setzen Sie [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/), um Paragraphen auf verschiedenen Ebenen einer Liste zu platzieren. Die oberste Ebene hat die Tiefe `0`.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und greifen Sie eine Folie ab.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu und entfernen Sie den Standard‑Paragraph aus dessen TextFrame.
3. Erstellen Sie vier Paragraphen und konfigurieren Sie deren Aufzählungssymbole.
4. Setzen Sie deren [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/)‑Werte auf `0`, `1`, `2` und `3`.
5. Fügen Sie die Paragraphen dem TextFrame hinzu und speichern Sie die Präsentation.

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

### **Nummerierte Listeneinträge bei benutzerdefinierten Werten beginnen lassen**

Verwenden Sie [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/), um die Anfangs‑Nummer eines nummerierten Paragraphen festzulegen.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und fügen Sie einer Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
2. Entfernen Sie den Standard‑Paragraph aus dem TextFrame der Form.
3. Erstellen Sie drei nummerierte Paragraphen.
4. Setzen Sie [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) auf `2`, `3` bzw. `7` für die jeweiligen Paragraphen.
5. Fügen Sie die Paragraphen dem TextFrame hinzu und speichern Sie die Präsentation.

Dieses JavaScript‑Beispiel weist jedem Paragraphen eine benutzerdefinierte Start‑Nummer zu:

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

### **Ersten Zeileneinzug festlegen**

Verwenden Sie [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/), um den Erstzeileneinzug eines Paragraphen zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Paragraphen. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Paragraphenkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/), wenn Sie den gesamten Paragraphen verschieben möchten. Verwenden Sie [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/), wenn Sie nur die erste Zeile verschieben wollen.

Das nachfolgende Beispiel erzeugt mehrere Paragraphen und wendet unterschiedliche [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)‑Werte an, um zu zeigen, wie sich der Erstzeileneinzug auf das Layout auswirkt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie die Ziel‑Folie ab.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standard‑Paragraph.
5. Erstellen Sie mehrere Paragraphen und setzen Sie verschiedene [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)‑Werte für sie.
6. Fügen Sie die Paragraphen dem TextFrame hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie ein Paragraph‑Einzug gesetzt wird:

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

![Der Erstzeileneinzug der Paragraphen](first_line_indent.png)

### **Hängenden Einzug festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/). Übergeben Sie einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) die linke Position des Paragraphenkörpers, und [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) bestimmt die Position der ersten Zeile relativ zu diesem Rand. Für einen hängenden Einzug übergeben Sie einen positiven Wert an `setMarginLeft` und einen negativen Wert an `setIndent`.

Diese Formatierung ist nützlich für Bibliographien, Verweise, Glossareinträge und andere Paragraphen, bei denen umgebrochene Zeilen unter dem Paragraphenkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie die Ziel‑Folie ab.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standard‑Paragraph.
5. Erstellen Sie Paragraphen und übergeben Sie für jeden einen positiven Wert an [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/).
6. Übergeben Sie einen negativen Wert an [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/), um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Paragraphen dem TextFrame hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie ein hängender Einzug für einen Paragraph gesetzt wird:

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

![Der hängende Einzug der Paragraphen](hanging_indent.png)

### **End‑Paragraph‑Lauf‑Eigenschaften festlegen**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) steuert die Formatierung des Absatzendzeichens. Das folgende Beispiel weist dem Endzeichen des zweiten Paragraphen eine Schriftgröße und eine Latin‑Schrift zu:

1. Erzeugen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und greifen Sie eine Folie ab.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu und löschen Sie dessen Standard‑Paragraph.
3. Erstellen Sie zwei Paragraphen und fügen Sie ihnen Textportionen hinzu.
4. Erzeugen Sie ein [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) für das Endzeichen des zweiten Paragraphen.
5. Setzen Sie [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) und [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Weisen Sie das Format mit [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) zu und speichern Sie die Präsentation.

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

## **Anzahl gerenderter Zeilen zählen**

Für Absatzregeln, die automatisches Umbrechen und Interpunktion am Zeilenende betreffen, siehe [Control Line Breaking](/slides/de/nodejs-java/text-formatting/#control-line-breaking) und [Control Hanging Punctuation](/slides/de/nodejs-java/text-formatting/#control-hanging-punctuation).

Verwenden Sie [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount), um die nach Textlayout belegten Zeilen eines Paragraphen zu zählen, einschließlich automatischem Umbrechen. Das ist nützlich, um Textlänge und Layout in Präsentationsvorlagen zu prüfen.

Ein Paragraph ist ein Element von [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParagraphs) und kann mehrere gerenderte Zeilen belegen. Ein expliziter Zeilenumbruch innerhalb eines Paragraphen erzwingt eine neue Zeile, ohne einen weiteren Paragraphen zu erzeugen. Automatisches Umbrechen erzeugt Zeilen basierend auf der verfügbaren Breite, ohne explizite Zeilenumbrüche in den Text einzufügen. Daher liefert das Zählen von Paragraphen oder Zeilenumbruch‑Zeichen nicht die gerenderte Zeilenzahl.

Das folgende Beispiel erstellt ein Text‑Shape, zählt dessen Zeilen, verkleinert das Shape und ersetzt anschließend den Text durch einen kürzeren String. Umbrechen ist aktiviert und Autofit deaktiviert, sodass die Shape‑Breite das Umbrechen steuert, ohne den Text automatisch zu verkleinern oder das Shape zu skalieren. Shape‑Abmessungen werden in Punkten angegeben. Abschließend fügt das Beispiel einen weiteren Paragraphen hinzu und addiert die Zeilenzahlen über das TextFrame hinweg.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Mit diesem Text und diesen Abmessungen erhöht das Verengen des Shapes die Zeilenzahl, während das Ersetzen des Textes durch den kurzen String sie reduziert. Exakte Zahlen können je nach verfügbaren Schriften, Schriftgröße, Rändern, Einzügen, Umbrechen und Autofit‑Einstellungen variieren. Verwenden Sie die für die Zielumgebung vorgesehenen Schriften und Layout‑Einstellungen beim Prüfen einer Vorlage.

Die Zeilenzahl allein bestimmt nicht, ob Text über das Container‑Volumen hinausläuft. Auch die verfügbare Höhe, Zeilenhöhen, Absatz‑ und Zeilenabstände sowie das Verhalten von Autofit sind relevant; bereits eine Zeile kann die verfügbare Breite überschreiten, wenn Umbrechen deaktiviert ist.

## **Absatzinhalt importieren und exportieren**

### **HTML‑Text in Paragraphen importieren**

Verwenden Sie [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/), um HTML‑Markup in Paragraphen und Portionen eines TextFrames zu konvertieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie eine Folie ab und fügen Sie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
3. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) der Form zu und löschen Sie den Standard‑Paragraph.
4. Definieren oder lesen Sie den Quell‑HTML‑String.
5. Übergaben Sie den HTML‑String an [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Speichern Sie die geänderte Präsentation.

Dieses JavaScript‑Beispiel importiert HTML in ein TextFrame:

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

### **Paragraphentext nach HTML exportieren**

Verwenden Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/), um einen ausgewählten Paragraphen‑Bereich als HTML zu exportieren.

1. Erzeugen oder laden Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie die Folie ab und finden Sie das [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), das den Text enthält.
3. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) der Form zu.
4. Rufen Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) mit dem Start‑Paragraph‑Index und der Anzahl zu exportierender Paragraphen auf.
5. Schreiben Sie den zurückgegebenen HTML‑String in eine Datei.

Dieses eigenständige JavaScript‑Beispiel erstellt ein Text‑Shape und exportiert alle seine Paragraphen:

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

### **Einen Paragraphen als Bild rendern**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) rendert einen einzelnen Paragraphen direkt und gibt ein [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) zurück. Speichern Sie das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) in einer Datei. Sie müssen nicht das umgebende Shape rendern oder ein Bitmap manuell zuschneiden.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) kann `null` zurückgeben, wenn der Paragraph nicht in seiner übergeordneten Sammlung gefunden wird, keine gültigen Render‑Grenzen hat oder nicht gerendert werden kann. Prüfen Sie das Ergebnis vor dem Speichern und geben Sie das zurückgegebene Bild nach der Verwendung frei.

#### **Paragraphen mit Standardskala rendern**

Die folgende Textbox enthält drei Paragraphen:

![Die Textbox mit drei Paragraphen](paragraph_to_image_input.png)

Das nachstehende Beispiel rendert den zweiten Paragraphen in einem regulären Text‑Shape mit Standardskala und speichert das zurückgegebene Bild im PNG‑Format. Der `finally`‑Block stellt sicher, dass das Bild korrekt freigegeben wird.

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

![Das Paragraph‑Bild](paragraph_to_image_output.png)

#### **Paragraphen in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage), die `scaleX`‑ und `scaleY`‑Parameter akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Paragraphen in der ersten Zelle mit dem doppelten Standard‑Breiten‑ und Höhenwert und speichert das Ergebnis als PNG‑Bild.

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

Ein Skalierungsfaktor von `1` behält die Standard‑Pixelgröße der jeweiligen Achse bei. Beispielsweise erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa das Doppelte der Standardmaße betragen, also viermal so viele Pixel. Größere Faktoren liefern im Allgemeinen schärferen Text für Vergrößerungen oder hochauflösende Ausgaben, erhöhen jedoch Speicherverbrauch und Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Paragraphen zu bewahren; unterschiedliche horizontale und vertikale Faktoren strecken das Ergebnis unabhängig voneinander.

Das Rendern eines gesamten Shapes mit [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) bleibt sinnvoll, wenn das Ergebnis das Füll‑, Rand‑ oder andere visuelle Kontext‑Informationen des Shapes enthalten muss. Für ein reines Paragraph‑Bild verwenden Sie [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Kann ich das Zeilen‑Umbrechen innerhalb eines TextFrames vollständig deaktivieren?**

Ja. Setzen Sie [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) auf deaktiviert, damit Zeilen nicht an den Rändern des TextFrames umbrechen.

**Wie erhalte ich die genauen On‑Slide‑Grenzen eines bestimmten Paragraphen?**

Verwenden Sie [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/), um das Begrenzungsrechteck des Paragraphen abzurufen. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/#getRect) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatz‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) ist eine Absatz‑Ebene‑Einstellung und gilt für den gesamten Paragraphen, unabhängig von der Formatierung einzelner Portionen.

Um Portionen unterschiedlicher Schriftgrößen innerhalb einer Zeile vertikal auszurichten, siehe [Align Fonts Within a Line](/slides/de/nodejs-java/text-formatting/#align-fonts-within-a-line).

**Kann ich die Korrektursprache für einen Teil eines Paragraphen festlegen?**

Ja. Setzen Sie [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) für einzelne Portionen, sodass ein Paragraph Text in mehreren Sprachen enthalten kann.