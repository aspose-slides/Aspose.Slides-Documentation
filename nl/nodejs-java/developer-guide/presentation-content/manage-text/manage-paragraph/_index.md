---
title: Beheer PowerPoint-tekst alinea's in JavaScript
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
  - tekst toevoegen
  - alinea toevoegen
  - tekst beheren
  - alinea beheren
  - opsommingsteken beheren
  - alinea-inspringing
  - hangende inspringing
  - alinea-opsommingsteken
  - genummerde lijst
  - opsomminglijst
  - alinea-eigenschappen
  - HTML importeren
  - tekst naar HTML
  - alinea naar HTML
  - alinea naar afbeelding
  - tekst naar afbeelding
  - alinea exporteren
  - PowerPoint
  - presentatie
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Leer hoe je alinea's, porties, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen kunt maken en opmaken met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java represents text as a hierarchy of text frames, paragraphs, and portions:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) vertegenwoordigt de tekstcontainer in een vorm en biedt toegang tot de alinea‑collectie.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstkader en biedt toegang tot de porties en op alinea‑niveau vormgeving.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) vertegenwoordigt een tekstrun binnen een alinea. Elke portie kan zijn eigen tekst en karakter‑niveau vormgeving hebben.

Een alinea kan daarom tekst bevatten met verschillende lettertypes, kleuren, groottes en andere vormgeving door meerdere porties te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere porties**

De onderstaande stappen maken een tekstkader met drie alinea's, elk met drie porties:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Toegang tot de betreffende dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaardalinea en voeg twee extra [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) objecten toe aan het tekstkader.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) objecten toe zodat elke alinea drie porties bevat. De standaardalinea bevat al één lege portie.
7. Stel de tekst van elke portie in.
8. Pas karakter‑niveau opmaak toe via [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/).
9. Sla de gewijzigde presentatie op.

Dit JavaScript‑voorbeeld implementeert de stappen:

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

## **Opsommingstekens en genummerde lijsten maken**

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items gemakkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/).

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Toegang tot de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaardalinea uit het tekstkader.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) in op [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) en specificeer het opsommingsteken‑karakter.
8. Stel de alinea‑tekst, inspringing, kleur van het opsommingsteken en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstkader.
10. Maak een tweede alinea en stel [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) in op [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/).
11. Configureer de genummerde opsommingsteken‑stijl en voeg de alinea toe aan het tekstkader.
12. Sla de presentatie op.

Dit JavaScript‑voorbeeld maakt een symbool‑opsommingsteken en een genummerde opsommingsteken:

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

### **Afbeeldings‑opsommingstekens gebruiken**

Afbeeldings‑opsommingstekens laten je een aangepast beeld gebruiken in plaats van een symbool of nummer.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Toegang tot de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe en krijg toegang tot zijn [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
4. Verwijder de standaardalinea uit het tekstkader.
5. Laad de opsommingsteken‑afbeelding en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) in op [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/).
8. Wijs de afbeelding toe via [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstkader.
10. Sla de gewijzigde presentatie op.

Dit JavaScript‑voorbeeld maakt een afbeeldings‑opsommingsteken:

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

### **Een meerlagige lijst maken**

Stel [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) en krijg toegang tot een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe en verwijder de standaardalinea uit het tekstkader.
3. Maak vier alinea's en configureer hun opsommingsteken‑symbolen.
4. Stel hun [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstkader en sla de presentatie op.

Dit JavaScript‑voorbeeld maakt een vier-niveau opsomminglijst:

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

### **Genummerde lijstitems starten met aangepaste waarden**

Gebruik [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) om het initiële nummer voor een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaardalinea uit het tekstkader van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) in op `2`, `3` en `7` voor de respectievelijke alinea's.
5. Voeg de alinea's toe aan het tekstkader en sla de presentatie op.

Dit JavaScript‑voorbeeld kent een aangepast startnummer toe aan elke alinea:

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

## **Alinea‑indeling en eind‑eigenschappen beheren**

### **Een eerste‑regelin­ding instellen**

Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) om de eerste‑regelin­ding van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de resterende regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) wanneer je de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) wanneer je alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt verschillende alinea's en past verschillende [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) waarden toe om te demonstreren hoe de eerste‑regelin­ding de alinea‑lay-out beïnvloedt.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Toegang tot de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
5. Maak verschillende alinea's en stel verschillende [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) waarden voor hen in.
6. Voeg de alinea's toe aan het tekstkader.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe je een alinea‑inspringing instelt:

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

Het resultaat:

![De eerste‑regelin­ding van de alinea's](first_line_indent.png)

### **Een hangende inspringing instellen**

Een hangende inspringing is een alinea‑lay-out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëer je dit effect met [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/). Geef een negatieve waarde op om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk definieert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) de linkse positie van de alinea‑inhoud, en [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) bepaalt de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te creëren, geef je een positieve waarde aan `setMarginLeft` en een negatieve waarde aan `setIndent`.

Deze opmaak is nuttig voor bibliografieën, referenties, glossarium‑items en andere alinea's waarbij regel­aftrekkingen onder de alinea‑inhoud moeten uitlijnen i.p.v. onder het eerste teken van de eerste regel.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Toegang tot de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
5. Maak alinea's en geef een positieve waarde aan [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) voor elke alinea.
6. Geef een negatieve waarde aan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) om het hangende‑inspringing‑effect te creëren.
7. Voeg de alinea's toe aan het tekstkader.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe je een hangende inspringing voor een alinea instelt:

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

Het resultaat:

![De hangende inspringing van de alinea's](hanging_indent.png)

### **Eind‑alinea‑run‑eigenschappen instellen**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) regelt de opmaak van het alinea‑eindteken. Het volgende voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het eindteken van de tweede alinea:

1. Maak of laad een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) en krijg toegang tot een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe en wis de standaardalinea.
3. Maak twee alinea's en voeg tekstporties toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) voor het eindteken van de tweede alinea.
5. Stel [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) en [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) in.
6. Wijs de opmaak toe met [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) en sla de presentatie op.

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

## **Aantal gerenderde regels tellen**

Voor alinea‑regels die automatische regel­afbreking en interpunctie aan het einde van regels beïnvloeden, zie [Regelafbreking beheersen](/slides/nl/nodejs-java/text-formatting/#control-line-breaking) en [Hangende interpunctie beheersen](/slides/nl/nodejs-java/text-formatting/#control-hanging-punctuation).

Gebruik [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) om het aantal regels dat een alinea na tekstlay-out inneemt te tellen, inclusief automatische afbreking. Dit is nuttig bij het controleren van tekstlengte en lay-out in presentatiesjablonen.

Een alinea is één item in [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParagraphs), en kan verschillende gerenderde regels innemen. Een expliciete regel­onderbreking binnen een alinea dwingt een nieuwe regel zonder een nieuwe alinea te creëren. Automatische afbreking maakt regels op basis van de beschikbare breedte zonder expliciete regel­onderbrekingen in de tekst in te voegen. Het tellen van alinea's of regel­onderbrekingstekens geeft dus niet het gerenderde regel‑aantal.

Het volgende voorbeeld maakt een tekstoppervlak, telt de regels, vernauwt het oppervlak en vervangt vervolgens de tekst door een kortere string. Afbreking is ingeschakeld en autofit uitgeschakeld zodat de breedte van het oppervlak de afbreking bepaalt zonder de tekst automatisch te verkleinen of het oppervlak te schalen. De afmetingen van het oppervlak zijn in points. Ten slotte voegt het voorbeeld nog een alinea toe en somt de regel‑aantallen van het tekstkader op.

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

Met deze tekst en deze afmetingen verhoogt het vernauwen van het oppervlak het aantal regels, terwijl het vervangen van de tekst door de korte string dit verlaagt. Exacte aantallen kunnen variëren afhankelijk van de beschikbaarheid en vervanging van lettertypes, lettergrootte, marges, inspringingen, afbreking en autofit‑instellingen. Gebruik de lettertypes en lay‑out‑instellingen die bedoeld zijn voor de doeleomgeving bij het controleren van een sjabloon.

Het aantal regels alleen bepaalt niet of tekst buiten de container overlijdt. De beschikbare hoogte, regelhoogtes, alinea‑ en regel­afstand, en autofit‑gedrag spelen eveneens een rol; zelfs een enkele regel kan de beschikbare breedte overschrijden wanneer afbreking is uitgeschakeld.

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) om HTML‑opmaak om te zetten naar alinea's en porties in een tekstkader.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Toegang tot een dia en voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe.
3. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
4. Definieer of lees de bron‑HTML‑string.
5. Geef de HTML‑string door aan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Sla de gewijzigde presentatie op.

Dit JavaScript‑voorbeeld importeert HTML in een tekstkader:

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

### **Alinea‑tekst exporteren naar HTML**

Gebruik [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak of laad een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Toegang tot de dia en vind de [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) die de tekst bevat.
3. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) van de vorm.
4. Roep [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) aan met de beginalinea‑index en het aantal alinea's dat moet worden geëxporteerd.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit zelfstandige JavaScript‑voorbeeld maakt een tekstoppervlak en exporteert al haar alinea's:

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

### **Een alinea renderen als afbeelding**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) rendert een individuele alinea direct en retourneert een [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/). Sla het resultaat op in een bestand met [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Je hoeft de omvattende vorm niet te renderen of een bitmap handmatig bij te snijden.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) kan `null` retourneren als de alinea niet gevonden wordt in de bovenliggende collectie, geen geldige render‑grenzen heeft, of niet gerenderd kan worden. Controleer het resultaat vóór het opslaan en ruim de geretourneerde afbeelding correct op na gebruik.

#### **Een alinea renderen op de standaard schaal**

Het volgende tekstvak bevat drie alinea's:

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een regulier tekstkader op de standaard schaal en slaat de geretourneerde afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

Het resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

#### **Een alinea renderen in een tabelcel met schalen**

Gebruik de [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) overload die de parameters `scaleX` en `scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op tweemaal de standaard breedte en hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaard pixelgrootte. Bijvoorbeeld `2` voor beide factoren produceert een afbeelding waarvan breedte en hoogte ongeveer twee keer de standaard afmetingen zijn, wat resulteert in vier keer zoveel pixels. Grotere factoren leveren doorgaans scherper tekst voor vergroting of hoge‑resolutie uitvoer, maar verhogen ook het geheugengebruik en de bestandsgrootte. Factoren onder `1` produceren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de aspect‑ratio van de alinea te behouden; verschillende horizontale en verticale factoren rekken de uitvoer onafhankelijk uit.

Het renderen van een volledige vorm met [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) blijft nuttig wanneer de uitvoer de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een uitsluitend alinea‑afbeelding, gebruik [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Kan ik het regelomloop volledig uitschakelen binnen een tekstkader?**

Ja. Stel [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) in om omslag uit te schakelen zodat regels niet afbreken aan de randen van het tekstkader.

**Hoe kan ik de exacte grenzen op de dia van een specifieke alinea verkrijgen?**

Gebruik [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) om de omringende rechthoek van de alinea op te halen. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/#getRect) geeft de grenzen van een individuele portie.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of blok) ingesteld?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) is een alinea‑niveau instelling en wordt toegepast op de hele alinea, ongeacht de individuele portie‑opmaak.

Om porties met verschillende lettergroottes verticaal uit te lijnen binnen elke regel, zie [Lettertypen verticaal uitlijnen binnen een regel](/slides/nl/nodejs-java/text-formatting/#align-fonts-within-a-line).

**Kan ik de taal van de proeflezer voor een deel van een alinea instellen?**

Ja. Stel [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) in voor individuele porties, zodat één alinea tekst in meerdere talen kan bevatten.