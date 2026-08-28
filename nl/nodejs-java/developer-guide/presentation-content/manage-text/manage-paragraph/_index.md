---
title: Beheer PowerPoint-tekstparagrafen in JavaScript
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
  - insprong van alinea
  - hangende insprong
  - alinea opsommingsteken
  - genummerde lijst
  - opsomminglijst
  - eigenschappen van alinea
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
description: "Leer hoe u alinea's, delen, opsommingstekens, genummerde lijsten, inspringingen, HTML‑inhoud en alinea‑afbeeldingen kunt maken en opmaken met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides voor Node.js via Java stelt tekst voor als een hiërarchie van tekstkaders, alinea's en delen:

* [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) vertegenwoordigt de tekstopslag in een vorm en biedt toegang tot de alinea‑collectie.
* [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstkader en biedt toegang tot de delen en alinea‑niveau opmaak.
* [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) vertegenwoordigt een tekstrun binnen een alinea. Elk deel kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan daarom tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere delen te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere delen**

De volgende stappen maken een tekstkader met drie alinea's, elk met drie delen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
2. Open de betreffende dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaard alinea en voeg twee extra [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) objecten toe aan het tekstkader.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) objecten toe zodat elke alinea drie delen bevat. De standaard alinea bevat al één leeg deel.
7. Stel de tekst van elk deel in.
8. Pas teken‑niveau opmaak toe via [Portion.getPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/getportionformat/).
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

Opsommingstekens en nummering maken gerelateerde items makkelijker te scannen. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bulletformat/).

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
2. Open de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaard alinea uit het tekstkader.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [BulletFormat.setType] in op [BulletType.Symbol] en geef het opsommingsteken‑karakter op.
8. Stel de alinea‑tekst, insprong, kleur van het opsommingsteken en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstkader.
10. Maak een tweede alinea en stel [BulletFormat.setType] in op [BulletType.Numbered].
11. Configureer de nummer‑opsommingstij​l en voeg de alinea toe aan het tekstkader.
12. Sla de presentatie op.

Dit JavaScript‑voorbeeld maakt een symbool‑opsommingsteken en een genummerd opsommingsteken:

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

Afbeeldings‑opsommingstekens laten u een aangepast beeld gebruiken in plaats van een symbool of cijfer.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
2. Open de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe en open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) ervan.
4. Verwijder de standaard alinea uit het tekstkader.
5. Laad de opsommingsteken‑afbeelding en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat.setType] in op [BulletType.Picture].
8. Wijs de afbeelding toe via [BulletFormat.getPicture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bulletformat/getpicture/) en stel de hoogte van het opsommingsteken in.
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

Stel [ParagraphFormat.setDepth] in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe en verwijder de standaard alinea uit het tekstkader.
3. Maak vier alinea's en configureer hun opsommingsteken‑symbolen.
4. Stel hun [ParagraphFormat.setDepth] waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstkader en sla de presentatie op.

Dit JavaScript‑voorbeeld maakt een vier‑niveau opsomminglijst:

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

Gebruik [BulletFormat.setNumberedBulletStartWith] om het begincijfer in te stellen dat wordt weergegeven voor een genummerde alinea.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaard alinea uit het tekstkader van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [BulletFormat.setNumberedBulletStartWith] in op `2`, `3` en `7` voor de respectieve alinea's.
5. Voeg de alinea's toe aan het tekstkader en sla de presentatie op.

Dit JavaScript‑voorbeeld kent een aangepaste startwaarde toe aan elk van de alinea's:

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

## **Alinea‑indeling en einde‑eigenschappen beheren**

### **Eerste‑regelinsprong instellen**

Gebruik [ParagraphFormat.setIndent] om de eerste‑regelinsprong van een alinea te bepalen. Deze methode verschuift alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verplaatst de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑tekst.

Gebruik [ParagraphFormat.setMarginLeft] wanneer u de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.setIndent] wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt verschillende alinea's en past verschillende [ParagraphFormat.setIndent] waarden toe om te demonstreren hoe de eerste‑regelinsprong de alinea‑indeling beïnvloedt.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's en stel verschillende [ParagraphFormat.setIndent] waarden voor hen in.
6. Voeg de alinea's toe aan het tekstkader.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een alinea‑insprong instelt:

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

![De eerste‑regelinsprong van de alinea's](first_line_indent.png)

### **Hangende insprong instellen**

Een hangende insprong is een alinea‑indeling waarbij de eerste regel links begint ten opzichte van de overige regels. In Aspose.Slides creëert u dit effect met [ParagraphFormat.setIndent]. Geef een negatieve waarde op om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑tekst.

In de praktijk definieert [ParagraphFormat.setMarginLeft] de linkersepositie van de alinea‑tekst, en defineert [ParagraphFormat.setIndent] de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te maken, geeft u een positieve waarde aan `setMarginLeft` en een negatieve waarde aan `setIndent`.

Deze opmaak is nuttig voor bibliografieën, referenties, woordenboekvermeldingen en andere alinea's waarbij omsluitende regels onder de alinea‑tekst moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak alinea's en geef een positieve waarde aan [ParagraphFormat.setMarginLeft] voor elke alinea.
6. Geef een negatieve waarde aan [ParagraphFormat.setIndent] om het hangende insprongeffect te creëren.
7. Voeg de alinea's toe aan het tekstkader.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een hangende insprong voor een alinea instelt:

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

![De hangende insprong van de alinea's](hanging_indent.png)

### **Eind‑alinea‑run‑eigenschappen instellen**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) bepaalt de opmaak van het einde‑teken van een alinea. Het volgende voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het einde‑teken van de tweede alinea:

1. Maak of laad een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe en verwijder de standaard alinea.
3. Maak twee alinea's en voeg tekstdelen toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/) voor het einde‑teken van de tweede alinea.
5. Stel [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) en [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) in.
6. Wijs de opmaak toe met [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) en sla de presentatie op.

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

## **Paragraaf‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) om HTML‑opmaak om te zetten in alinea's en delen in een tekstkader.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
2. Open een dia en voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe.
3. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
4. Definieer of lees de bron‑HTML‑string.
5. Geef de HTML‑string door aan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
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

Gebruik [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak of laad een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
2. Open de dia en vind de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) die de tekst bevat.
3. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de vorm.
4. Roep [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) aan met de start‑alinea‑index en het aantal alinea's dat moet worden geëxporteerd.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit zelfstandige JavaScript‑voorbeeld maakt een tekstvorm en exporteert al haar alinea's:

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

[Paragraph.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/#getImage) rendert een afzonderlijke alinea direct en geeft een [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) terug. Sla het resultaat op in een bestand met [IImage.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/#save). Het is niet nodig om de omvattende vorm te renderen of handmatig een bitmap bij te snijden.

[Paragraph.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/#getImage) kan `null` retourneren als de alinea niet kan worden gevonden in de bovenliggende collectie, geen geldige render‑bounds heeft, of niet kan worden gerenderd. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding vrij na gebruik.

#### **Een alinea renderen op de standaard schaal**

Het volgende tekstvak bevat drie alinea's:

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een gewone tekstvorm op de standaard schaal en slaat de geretourneerde afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

#### **Een alinea renderen in een tabelcel met schaalvergroting**

Gebruik de overload van [Paragraph.getImage] die de parameters `scaleX` en `scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op tweemaal de standaard breedte en hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan breedte en hoogte ongeveer twee keer de standaardafmetingen zijn, wat resulteert in vier keer zoveel pixels. Grotere factoren leveren doorgaans scherpere tekst voor inzoomen of high‑resolution uitvoer, maar verhogen ook het geheugenverbruik en de bestandsgrootte. Factoren onder `1` produceren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de uitvoer onafhankelijk uit.

Het renderen van een volledige vorm met [Shape.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage) blijft handig wanneer de uitvoer de opvulling, rand of andere visuele context van de vorm moet bevatten. Voor uitsluitend een alinea‑afbeelding, gebruik [Paragraph.getImage].

## **Veelgestelde vragen**

**Kan ik het regelomloop volledig uitschakelen binnen een tekstkader?**

Ja. Stel [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/setwraptext/) in om het omslaan uit te schakelen zodat regels niet worden afgebroken aan de randen van het tekstkader.

**Hoe kan ik de exacte op‑dia grenzen van een specifieke alinea krijgen?**

Gebruik [Paragraph.getRect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/getrect/) om de begrenzende rechthoek van de alinea op te halen. [Portion.getRect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#getRect) geeft de grenzen van een afzonderlijk deel.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setalignment/) is een alinea‑niveau instelling en wordt toegepast op de hele alinea, ongeacht de opmaak van individuele delen.

**Kan ik de proefleestaal voor een deel van een alinea instellen?**

Ja. Stel [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) in voor individuele delen, zodat één alinea tekst in meerdere talen kan bevatten.