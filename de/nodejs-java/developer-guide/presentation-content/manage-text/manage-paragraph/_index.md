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
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Node.js über Java Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML-Inhalte und Absatz-Bilder erstellen und formatieren."
---
## **Überblick**

Aspose.Slides für Node.js über Java stellt Text als Hierarchie von TextFrames, Paragraphen und Portionen dar:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) repräsentiert den Textcontainer in einer Form und bietet Zugriff auf ihre Paragraphensammlung.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) stellt einen Paragraphen in einem TextFrame dar und bietet Zugriff auf seine Portionen und Paragraph‑Formatierung.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) repräsentiert einen Textlauf innerhalb eines Paragraphen. Jede Portion kann eigene Text‑ und Zeichenformatierung besitzen.

Ein Paragraph kann somit Text mit unterschiedlichen Schriftarten, Farben, Größen und sonstiger Formatierung enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

Erstellen Sie Paragraphen im TextFrame einer Form und verwenden Sie Portionen, um einzelne Textläufe zu formatieren. Dieser Abschnitt zeigt, wie mehrere Portionen innerhalb jedes Paragraphen kombiniert und verschiedene Farben, Schriftgrößen und Stile angewendet werden können.

### **Absätze mit mehreren Portionen erstellen**

Das folgende JavaScript‑Beispiel erstellt drei Paragraphen, die jeweils drei Textläufe in der Sammlung enthalten, die von [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/) zurückgegeben wird. Es verwendet den Standard‑Paragraphen und seine leere Portion erneut und fügt dann die übrigen Paragraphen und Portionen hinzu. Die Formatierung erfolgt über [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/): Die erste Portion jedes Paragraphen ist rot, fett und 15 pt; die zweite ist blau, kursiv und 18 pt. Die dritte Portion behält die Standardformatierung bei:

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

## **Aufzählungen und nummerierte Listen erstellen**

Organisieren Sie Paragraphentext in Listen mit Symbolen, Zahlen oder benutzerdefinierten Bildern. Die Beispiele in diesem Abschnitt behandeln Aufzählungsformatierung, mehrstufige Listen und benutzerdefinierte Startzahlen.

### **Eine Aufzählungs‑ oder nummerierte Liste erstellen**

Aufzählungen und Nummerierungen erleichtern das Scannen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) definiert.

Dieses JavaScript‑Beispiel fügt einem TextFrame sowohl ein Symbol‑Bullet als auch ein nummeriertes Element hinzu. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) wählt den Bullet‑Typ, [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) liefert das Symbol und [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) wählt den Nummerierungsstil. Beide Elemente verwenden schwarze Bullets mit einer Höhe von 100 % und einem Paragraph‑Einzug von 25 pt:

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

### **Bild‑Bullets verwenden**

Bild‑Bullets ermöglichen die Verwendung eines benutzerdefinierten Bildes anstelle eines Symbols oder einer Zahl.

Dieses JavaScript‑Beispiel lädt `image.png` aus dem Arbeitsverzeichnis der Anwendung, fügt das Bild der Präsentations‑Bildsammlung als ein [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) hinzu und verwendet es als Paragraph‑Bullet. Es ruft [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) auf, um ein Bild‑Bullet zu verwenden, und weist das Bild über [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) zu. [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) wird auf 100 % gesetzt, damit das Bullet relativ zur Paragraph‑Textgröße skaliert wird:

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

### **Eine mehrstufige Liste erstellen**

Setzen Sie [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/), um Paragraphen auf unterschiedlichen Ebenen einer Liste zu platzieren. Die oberste Ebene hat die Tiefe `0`.

Dieses JavaScript‑Beispiel weist [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) Werte von 0 bis 3 für vier Paragraphen zu und erzeugt so eine Hierarchie innerhalb eines TextFrames. Jeder Paragraph verwendet ein Symbol‑Bullet, wobei [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) abwechselnd zwischen einem runden Bullet und einem Bindestrich wechselt, um benachbarte Ebenen zu unterscheiden:

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

### **Nummerierte Listenelemente mit benutzerdefinierten Werten starten**

Verwenden Sie [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/), um die Anfangszahl eines nummerierten Paragraphen festzulegen.

Dieses JavaScript‑Beispiel setzt [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) auf Nummerierung für drei Paragraphen und weist [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) die Werte 2, 3 und 7 zu. Der Startwert wird für jeden Paragraphen separat konfiguriert, sodass die angezeigten Nummern Werte überspringen können:

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

## **Paragraph‑Layout und End‑Eigenschaften steuern**

Passen Sie Paragraph‑Ränder und Einzüge an, um die Position der ersten Zeile und umbrochenen Zeilen zu steuern. Sie können das End‑Markierungszeichen eines Paragraphen getrennt vom sichtbaren Text formatieren.

### **Ersten‑Zeilen‑Einzug setzen**

Verwenden Sie die Methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/), um den Einzug der ersten Zeile eines Paragraphen zu steuern. Diese Einstellung verschiebt nur die erste Zeile relativ zum linken Rand des Paragraphen. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Paragraphenkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/), wenn Sie den gesamten Paragraphen verschieben möchten. Verwenden Sie [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/), wenn Sie nur die erste Zeile verschieben möchten.

Im folgenden Beispiel erhalten drei Paragraphen denselben [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) von 20 pt und [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) Werte von 0, 20 und 40 pt. Die ersten Zeilen beginnen bei fortlaufend größeren Offsets, während umbrochene Zeilen denselben linken Rand behalten:

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

![Der Einzug der ersten Zeile der Paragraphen](first_line_indent.png)

### **Hängenden Einzug setzen**

Ein hängender Einzug ist ein Paragraph‑Layout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/). Setzen Sie den Einzug auf einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) die linke Position des Paragraphenkörpers, und [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) definiert die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, setzen Sie einen positiven linken Rand und einen negativen Einzug.

Diese Formatierung ist nützlich für Bibliographien, Verweise, Glossareinträge und andere Paragraphen, bei denen umbrochene Zeilen unter dem Paragraphenkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

Im folgenden JavaScript‑Beispiel werden [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) Werte von 40 pt und 60 pt mit [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) Werten von -20 pt bzw. -30 pt kombiniert. In jedem Paragraphen beginnt die erste Zeile links von den umbrochenen Zeilen; der zweite Paragraph hat einen tieferen hängenden Einzug:

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

### **End‑Paragraph‑Run‑Eigenschaften setzen**

Die Methode [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) steuert die Formatierung des End‑Markierungszeichens eines Paragraphen. Das folgende Beispiel erstellt ein [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) mit [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) auf 48 pt und [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) auf Times New Roman. Es weist dieses Format dem End‑Markierungszeichen des zweiten Paragraphen zu, während die sichtbaren Textportionen unverändert bleiben:

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

## **Gerenderte Zeilen zählen**

Für Paragraphen­regeln, die automatisches Umbrechen und Interpunktion am Zeilenende betreffen, siehe [Control Line Breaking](/slides/de/nodejs-java/text-formatting/#control-line-breaking) und [Control Hanging Punctuation](/slides/de/nodejs-java/text-formatting/#control-hanging-punctuation).

Verwenden Sie [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount), um die nach Layout‑Berechnung von einem Paragraphen belegten Zeilen zu zählen, einschließlich automatischem Umbrechen. Dies ist nützlich, wenn die Textlänge und das Layout in Präsentationsvorlagen geprüft werden.

Ein Paragraph ist ein Element von [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/), und er kann mehrere gerenderte Zeilen belegen. Ein expliziter Zeilenumbruch innerhalb eines Paragraphen erzwingt eine neue Zeile, ohne einen zusätzlichen Paragraphen zu erzeugen. Automatisches Umbrechen erzeugt Zeilen basierend auf der verfügbaren Breite, ohne explizite Zeilenumbrüche in den Text einzufügen. Daher liefert das Zählen von Paragraphen oder Zeilenumbruch‑Zeichen nicht die gerenderte Zeilenzahl.

Das folgende Beispiel erstellt eine Textform, zählt deren Zeilen, verengt die Form und ersetzt anschließend den Text durch eine kürzere Zeichenkette. Das Beispiel aktiviert das Umbrechen mit [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) und deaktiviert das Autofit mit [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/), sodass die Formbreite das Umbrechen steuert, ohne den Text automatisch zu verkleinern oder die Form zu skalieren. Jede Messung verwendet [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount). Formabmessungen werden in Punkten angegeben. Abschließend fügt das Beispiel einen weiteren Paragraphen hinzu und summiert die Zeilenzahlen über den gesamten TextFrame.

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

Bei diesem Text und diesen Abmessungen erhöht das Verengen der Form die Zeilenzahl, während das Ersetzen des Textes durch die kurze Zeichenkette sie reduziert. Exakte Zahlen können je nach Schriftverfügbarkeit und -ersetzung, Schriftgröße, Rändern, Einzügen, Umbrechen und Autofit‑Einstellungen variieren. Verwenden Sie die für die Zielumgebung vorgesehenen Schriften und Layout‑Einstellungen, wenn Sie eine Vorlage prüfen.

Die Zeilenzahl allein bestimmt nicht, ob Text über den Container hinausläuft. Auch die verfügbare Höhe, Zeilenhöhen, Absatz‑ und Zeilenabstände sowie das Autofit‑Verhalten spielen eine Rolle; bereits eine einzelne Zeile kann die verfügbare Breite überschreiten, wenn das Umbrechen deaktiviert ist.

## **Paragraph‑Inhalt importieren und exportieren**

Verwenden Sie HTML, um Text in eine Präsentation zu bringen oder vorhandene Paragraphen für die Verwendung außerhalb zu exportieren. Dieser Abschnitt zeigt außerdem, wie einzelne Paragraphen als Bilder gerendert werden können, einschließlich Paragraphen in Tabellenzellen.

### **HTML‑Text in Paragraphen importieren**

Verwenden Sie [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/), um HTML‑Markup in Paragraphen und Portionen eines TextFrames zu konvertieren.

Dieses JavaScript‑Beispiel liest HTML aus `file.html` im Arbeitsverzeichnis der Anwendung und übergibt das Markup an [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/). Es leert den Standard‑Paragraphen des TextFrames, sodass der Frame nur den importierten Inhalt enthält. Die rechteckige Form lässt an jeder Folienkante einen Rand von 10 pt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Paragraph‑Text nach HTML exportieren**

Verwenden Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/), um einen ausgewählten Paragraphen‑Bereich als HTML zu exportieren. Wenn Sie Präsentationstext auf einer Website wiederverwenden, möchten Sie ggf. lokale Hervorhebungen beibehalten, ohne die Schriftart, Größe oder Textfeld‑Stile der Präsentation zu übernehmen. Setzen Sie [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/), um zu steuern, wie weit der Exporter der Formatierungs‑Vererbung folgt.

Laden Sie die [Beispielpräsentation](text-inheritance.pptx) herunter und platzieren Sie sie im Arbeitsverzeichnis der Anwendung. Ihre erste Folie enthält eine Textform mit dem Text „Inherited text; explicit red 18pt“. Der Input verwendet bewusst mehrere Formatierungsebenen:

- Der Standard‑Textstil der Präsentation liefert Calibri und eine Größe von 28 pt.
- Der Text‑Stil des TextFrames auf erster Ebene liefert blauen Text und Kursivschrift.
- Der Paragraph setzt explizit fett formatierten Text.
- Die zweite Portion, „explicit red 18pt“, setzt explizit roten Text und eine Größe von 18 pt.

Das folgende vollständige Beispiel exportiert dieselben Paragraphen dreimal. Es übergibt [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) an die Export‑Methode und schreibt jedes Ergebnis in eine separate UTF‑8‑HTML‑Datei:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
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

Das erzeugte HTML enthält das folgende CSS für die erste Portion, „Inherited text; “. Die Tabelle listet die relevanten Deklarationen auf; andere erzeugte Eigenschaften wurden zur Übersicht weggelassen.

| Ausgabe | Relevantes CSS für die erste Portion | Darstellung |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blauer, fetter, kursiver Text mit 28 pt in Calibri, falls die Schrift verfügbar ist. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blauer, fetter, kursiver Text; die umgebende Seite oder der Browser liefert Schriftart und Größe. |
| `ParagraphOnly.html` | `font-weight:bold` | Fettschrift; die umgebende Seite oder der Browser liefert Schriftart, Größe, Farbe und Kursivstil. |

Die zweite Portion behält `color:#ff0000`, `font-size:18pt` und `font-weight:bold` in allen drei Ausgaben bei. Sie behält ebenfalls Kursivschrift in `All` und `TextBox`, jedoch nicht in `ParagraphOnly`. Das Einschränken der Vererbung entfernt also nicht die explizit einem Paragraphen oder einer Portion zugewiesene Formatierung.

Öffnen Sie die Dateien im selben Browser, um sie zu vergleichen. In den beiden eingeschränkten Modi werden fehlende CSS‑Eigenschaften durch die Stile der Zielseite oder die Browser‑Standarde übernommen, sodass das Ergebnis vom Verwendungsort des HTML abhängt.

### **Einen Paragraphen als Bild rendern**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) rendert einen einzelnen Paragraphen direkt und liefert ein [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/). Speichern Sie das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) in einer Datei oder einem Stream. Sie müssen nicht die umgebende Form rendern oder ein Bitmap manuell zuschneiden.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) kann `null` zurückgeben, wenn der Paragraph nicht in seiner übergeordneten Sammlung gefunden wird, keine gültigen Render‑Grenzen hat oder nicht gerendert werden kann. Prüfen Sie das Ergebnis vor dem Speichern und geben Sie das zurückgegebene Bild nach Gebrauch wieder frei.

#### **Einen Paragraphen in Standardskala rendern**

Das Beispiel erstellt eine Präsentation mit einer Folie, deren erste Form ein Textfeld mit drei Paragraphen ist.

![Das Textfeld mit drei Paragraphen](paragraph_to_image_input.png)

Das folgende Beispiel wählt den zweiten Paragraphen (Index 1) aus und ruft [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) ohne Skalierungsparameter auf. Es prüft, ob die Form den erforderlichen Paragraphen enthält und ob das Rendering ein Bild liefert, bevor es [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) zum Speichern im PNG‑Format aufruft. Der `finally`‑Block gibt das Bild nach Gebrauch frei.

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

#### **Einen Paragraphen in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage), die die Parameter `scaleX` und `scaleY` akzeptiert, um horizontale und vertikale Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Paragraphen in ihrer ersten Zelle bei doppelter Standardbreite und -höhe und speichert das Ergebnis als PNG‑Bild.

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

Ein Skalierungsfaktor von `1` behält die Standard‑Pixelgröße der jeweiligen Achse bei. Beispielsweise erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa doppelt so groß sind wie die Standardmaße, also viermal so viele Pixel. Größere Faktoren erzeugen in der Regel schärferen Text für Zoom‑ oder hochauflösende Ausgaben, erhöhen jedoch Speicher‑ und Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Paragraphen zu erhalten; unterschiedliche horizontale und vertikale Faktoren dehnen die Ausgabe jeweils unabhängig.

Das Rendern einer gesamten Form mit [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) bleibt sinnvoll, wenn das Ergebnis die Füllung, den Rand oder andere visuelle Kontexte der Form enthalten muss. Für ein reines Paragraph‑Bild verwenden Sie [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Kann ich das Zeilen‑Umbrechen in einem TextFrame vollständig deaktivieren?**

Ja. Setzen Sie [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) auf deaktiviert, damit Zeilen nicht an den Rändern des TextFrames umgebrochen werden.

**Wie erhalte ich die genauen On‑Slide‑Grenzen eines bestimmten Paragraphen?**

Verwenden Sie [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/), um das Begrenzungsrechteck des Paragraphen abzurufen. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Paragraph‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) ist eine Paragraph‑Ebene‑Einstellung und gilt für den gesamten Paragraphen, unabhängig von der Formatierung einzelner Portionen.

Um Portionen unterschiedlicher Schriftgrößen innerhalb einer Zeile vertikal auszurichten, siehe [Align Fonts Within a Line](/slides/de/nodejs-java/text-formatting/#align-fonts-within-a-line).

**Kann ich die Rechtschreib‑Sprache für einen Teil eines Paragraphen festlegen?**

Ja. Setzen Sie [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) für einzelne Portionen, sodass ein Paragraph Text in mehreren Sprachen enthalten kann.