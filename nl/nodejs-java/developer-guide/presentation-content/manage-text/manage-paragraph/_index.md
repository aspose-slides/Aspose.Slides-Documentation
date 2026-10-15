---
title: Beheer PowerPoint-tekstalinea's in JavaScript
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
- alinea-inspring
- hangende inspring
- alinea-opsommingsteken
- genummerde lijst
- opsommingslijst
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
description: "Leer hoe u alinea's, fragmenten, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen maakt en opmaakt met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java vertegenwoordigt tekst als een hiërarchie van tekstframes, alinea’s en fragmenten:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) vertegenwoordigt de tekstopslag in een vorm en biedt toegang tot de alinea‑verzameling.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de fragmenten en alinea‑niveau opmaak.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) vertegenwoordigt een tekstrun binnen een alinea. Elk fragment kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan dus tekst met verschillende lettertypen, kleuren, groottes en andere opmaak bevatten door meerdere fragmenten te gebruiken.

## **Alinea’s maken en opmaken**

Maak alinea’s in het tekstframe van een vorm en gebruik fragmenten om individuele tekstruns op te maken. Deze sectie laat zien hoe meerdere fragmenten binnen elke alinea gecombineerd kunnen worden en hoe verschillende kleuren, lettergrootten en stijlen toegepast kunnen worden.

### **Alinea’s maken met meerdere fragmenten**

Het volgende JavaScript‑voorbeeld maakt drie alinea’s, elk met drie tekstruns in de collectie die wordt geretourneerd door [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/). Het hergebruikt de standaardalinea en het lege fragment, waarna de resterende alinea’s en fragmenten worden toegevoegd. Opmaak wordt toegepast via [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/): het eerste fragment in elke alinea is rood, vet en 15 punten; het tweede is blauw, cursief en 18 punten. Het derde fragment behoudt de standaardopmaak:

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

Organiseer alinea‑tekst in lijsten met symbolen, cijfers of aangepaste afbeeldingen. De voorbeelden in deze sectie behandelen opsommingsteken‑opmaak, meerlagige lijsten en aangepaste startnummers.

### **Een opsomming met opsommingsteken of nummer maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/).

Dit JavaScript‑voorbeeld voegt een symbool‑opsommingsteken en een genummerd item toe aan hetzelfde tekstframe. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) selecteert het type opsommingsteken, terwijl [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) het symbool levert en [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) de nummeringsstijl kiest. Beide items gebruiken zwarte opsommingstekens met een hoogte van 100 % en een alinea‑inspring van 25 punten:

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

### **Afbeeldingsopsommingstekens gebruiken**

Afbeeldingsopsommingstekens laten je een aangepaste afbeelding gebruiken in plaats van een symbool of cijfer.

Dit JavaScript‑voorbeeld laadt `image.png` uit de werkmap van de applicatie, voegt de afbeelding toe aan de presentatie‑afbeeldingscollectie als een [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) en gebruikt deze als alinea‑opsommingsteken. Het roept [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) aan om een afbeeldingsopsommingsteken te gebruiken en kent de afbeelding toe via [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/). [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) wordt ingesteld op 100 % om het opsommingsteken ten opzichte van de alinea‑tekst te dimensioneren:

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

Stel [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) in om alinea’s op verschillende niveaus van een lijst te plaatsen. Het hoogste niveau heeft een diepte van `0`.

Dit JavaScript‑voorbeeld kent [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) waarden van 0 tot 3 toe aan vier alinea’s, waardoor er een hiërarchie binnen één tekstframe ontstaat. Elke alinea gebruikt een symbool‑opsommingsteken, waarbij [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) afwisselt tussen een ronde bullet en een koppelteken om aangrenzende niveaus te onderscheiden:

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

Gebruik [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) om het initiële nummer in te stellen dat voor een genummerde alinea wordt getoond.

Dit JavaScript‑voorbeeld stelt [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) in op nummering voor drie alinea’s en kent [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) waarden 2, 3 en 7 toe. De startwaarde wordt afzonderlijk per alinea geconfigureerd, waardoor de weergegeven nummers waarden kunnen overslaan:

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

## **Alinea‑opmaak en -einde eigenschappen beheren**

Pas alinea‑marges en inspringingen aan om de positie van de eerste regel en ingesprongen regels te regelen. Je kunt ook het einde‑teken van de alinea apart opmaken van de zichtbare tekstfragmenten.

### **Een eerste‑regelinspring instellen**

Gebruik de methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) om de eerste‑regelinspring van een alinea te regelen. Deze instelling verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde schuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinia‑inhoud.

Gebruik [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) wanneer je de hele alinea moet verplaatsen. Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) wanneer je alleen de eerste regel moet verplaatsen.

Het volgende voorbeeld geeft drie alinea’s dezelfde [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) van 20 punten en [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) waarden van 0, 20 en 40 punten. De eerste regels beginnen steeds verder naar rechts, terwijl ingesprongen regels dezelfde linkermarge behouden:

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

![De eerste‑regelinspring van de alinea's](first_line_indent.png)

### **Een hangende inspring instellen**

Een hangende inspring is een alinea‑opmaak waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëer je dit effect met de methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/). Stel de inspringing in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinia‑inhoud.

In de praktijk bepaalt [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) de linkse positie van de alinia‑inhoud, en bepaalt [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspring te creëren, stel je een positieve linkermarge en een negatieve inspringing in.

Deze opmaak is nuttig voor bibliografieën, referenties, woordenlijstvermeldingen en andere alinea’s waarbij ingesprongen regels moeten uitlijnen onder de alinia‑inhoud in plaats van onder het eerste teken van de eerste regel.

Het volgende JavaScript‑voorbeeld combineert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) waarden van 40 en 60 punten met [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) waarden van -20 en -30 punten. In elke alinea begint de eerste regel links van de ingesprongen regels; de tweede alinea heeft een diepere hangende inspring:

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

![De hangende inspring van de alinea's](hanging_indent.png)

### **Einde‑alinea‑run‑eigenschappen instellen**

De methode [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) regelt de opmaak van het einde‑teken van een alinea. Het volgende voorbeeld maakt een [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) met [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) ingesteld op 48 punten en [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) ingesteld op Times New Roman. Het kent dit formaat toe aan het einde‑teken van de tweede alinea, zonder de zichtbare tekstfragmenten te wijzigen:

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

## **Aantal weergegeven regels tellen**

Voor alinea‑regels die automatisch afbreken en interpunctie aan het einde van een regel beïnvloeden, zie [Regelafbreking beheren](/slides/nl/nodejs-java/text-formatting/#control-line-breaking) en [Hangende interpunctie beheren](/slides/nl/nodejs-java/text-formatting/#control-hanging-punctuation).

Gebruik [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) om het aantal regels te tellen dat een alinea na tekstlay-out occupyert, inclusief automatische afbreking. Handig bij het controleren van tekstopmaak en lay-out in presentatiesjablonen.

Een alinea is één item in [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/), en kan meerdere weergegeven regels in beslag nemen. Een expliciete regeleinde binnen een alinea dwingt een nieuwe regel af zonder een extra alinea te maken. Automatische afbreking genereert regels op basis van de beschikbare breedte zonder expliciete regeleindes in de tekst in te voegen. Het tellen van alinea’s of regeleinde‑tekens levert dus niet het aantal weergegeven regels op.

Het volgende voorbeeld maakt een tekstoppervlak, telt de regels, vernauwt de vorm en vervangt daarna de tekst door een kortere string. Het voorbeeld schakelt afbreken in via [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) en schakelt autofit uit via [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/) zodat de vormbreedte de afbreking regelt zonder de tekst automatisch te verkleinen of de vorm te schalen. Elke meting gebruikt [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount). Vormafmetingen zijn in punten. Ten slotte voegt het voorbeeld nog een alinea toe en telt de regelaantallen op over het tekstframe.

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

Met deze tekst en afmetingen verhoogt het vernauwen van de vorm het aantal regels, terwijl het vervangen van de tekst door de korte string het aantal verlaagt. Precieze aantallen kunnen variëren afhankelijk van de beschikbare lettertypen en substitutie, lettergrootte, marges, inspringen, afbreking en autofit‑instellingen. Gebruik de lettertypen en lay‑outinstellingen die bedoeld zijn voor de doelomgeving bij het controleren van een sjabloon.

Het aantal regels alleen bepaalt niet of tekst buiten het vlak uitsteekt. De beschikbare hoogte, regelhoogtes, alinea‑ en regelafstanden en autofit‑gedrag spelen ook een rol; zelfs één regel kan de beschikbare breedte overschrijden wanneer afbreken uitgeschakeld is.

## **Alinea‑inhoud importeren en exporteren**

Gebruik HTML om tekst in een presentatie te brengen of bestaande alinea’s te exporteren voor gebruik daarbuiten. Deze sectie laat ook zien hoe individuele alinea’s als afbeeldingen gerenderd kunnen worden, inclusief alinea’s in tabelcellen.

### **HTML‑tekst importeren in alinea’s**

Gebruik [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) om HTML‑markup om te zetten in alinea’s en fragmenten in een tekstframe.

Dit JavaScript‑voorbeeld leest HTML uit `file.html` in de werkmap van de applicatie en geeft de markup door aan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/). Het leegt het standaard‑alinea‑fragment van het tekstframe zodat het frame alleen de geïmporteerde inhoud bevat. De rechthoekige vorm laat een marge van 10 punten aan elke kant van de dia over:

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

### **Alinea‑tekst exporteren naar HTML**

Gebruik [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) om een geselecteerd bereik van alinea’s als HTML te exporteren. Wanneer je presentatietekst opnieuw wilt gebruiken op een website, wil je misschien lokale nadruk behouden zonder de lettertype‑, grootte‑ of tekstvak‑stijlen van de presentatie mee te nemen. Stel [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) in om te bepalen hoe ver de exporteur de opmaak‑erfenis volgt.

Download [de voorbeeldpresentatie](text-inheritance.pptx) en plaats deze in de werkmap van de applicatie. De eerste dia bevat één tekstvorm met de tekst “Inherited text; explicit red 18pt”. De invoer gebruikt opzettelijk verschillende opmaak‑niveaus:

- De standaard‑tekststijl van de presentatie levert Calibri en een grootte van 28 pt.
- De eerste‑niveau tekststijl van het tekstframe levert blauwe tekst en cursief.
- De alinea stelt expliciet vetgedrukte tekst in.
- Het tweede fragment, “explicit red 18pt”, stelt expliciet rode tekst en een grootte van 18 pt in.

Het volgende volledige voorbeeld exporteert dezelfde alinea’s drie keer. Het geeft [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) door aan de export‑methode en schrijft elk resultaat naar een apart UTF‑8 HTML‑bestand:

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

De gegenereerde HTML bevat de volgende CSS voor het eerste fragment, “Inherited text; ”. De tabel toont de relevante declaraties; andere gegenereerde eigenschappen zijn weggelaten voor de duidelijkheid.

| Uitvoer | Relevante CSS voor het eerste fragment | Uiterlijk |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blauwe, vetgedrukte, cursieve tekst op 28 pt in Calibri, indien dat lettertype beschikbaar is. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blauwe, vetgedrukte, cursieve tekst; de omringende pagina of browser levert het lettertype en de grootte. |
| `ParagraphOnly.html` | `font-weight:bold` | Vetgedrukte tekst; de omringende pagina of browser levert het lettertype, de grootte, de kleur en de cursieve stijl. |

Het tweede fragment behoudt `color:#ff0000`, `font-size:18pt` en `font-weight:bold` in alle drie de uitvoerbestanden. Het behoudt ook cursief in `All` en `TextBox`, maar niet in `ParagraphOnly`. Het beperken van erfelijkheid verwijdert dus niet de opmaak die expliciet aan een alinea of fragment is toegewezen.

Open de bestanden in dezelfde browser om ze te vergelijken. In de twee beperkte modi worden weggelaten CSS‑eigenschappen opgelost door de stijlen van de bestemmingspagina of de browser‑standaarden, waardoor het uiteindelijke uiterlijk afhankelijk is van waar de HTML wordt gebruikt.

### **Een alinea renderen als afbeelding**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) rendert een individuele alinea direct en retourneert een [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/). Sla het resultaat op in een bestand of stream met [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Je hoeft de omliggende vorm niet te renderen of handmatig een bitmap bij te snijden.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) kan `null` retourneren als de alinea niet in de bovenliggende collectie wordt gevonden, geen geldige render‑bounds heeft, of niet gerenderd kan worden. Controleer het resultaat voordat je het opslaat en maak de geretourneerde afbeelding na gebruik weer vrij.

#### **Een alinea renderen op de standaard schaal**

Het voorbeeld maakt een presentatie met één dia waarvan de eerste vorm een tekstvak is met drie alinea’s.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld selecteert de tweede alinea op index 1 en roept [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) aan zonder schaal‑parameters. Het controleert dat de vorm de vereiste alinea bevat en dat de weergave een afbeelding retourneert voordat [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) wordt aangeroepen om deze in PNG‑formaat op te slaan. Het `finally`‑blok maakt de afbeelding na gebruik vrij.

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

![De alinea afbeelding](paragraph_to_image_output.png)

#### **Een alinea renderen in een tabelcel met schaling**

Gebruik de overload van [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) die `scaleX` en `scaleY` parameters accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op twee keer de standaardbreedte en -hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan de breedte en hoogte ongeveer twee keer de standaardafmetingen zijn, wat resulteert in vier keer zoveel pixels. Grotere factoren leveren over het algemeen scherper tekst voor inzoomen of hoge‑resolutie‑output, maar verhogen ook het geheugen‑ en bestandsgrootte‑gebruik. Factoren onder `1` geven kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Het renderen van een volledige vorm met [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding van alleen de alinea, gebruik [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Kan ik het automatisch afbreken van tekst in een tekstframe volledig uitschakelen?**

Ja. Stel [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) in op uitschakelen van afbreken zodat regels niet bij de randen van het tekstframe afbreken.

**Hoe kan ik de exacte on-slide‑afmetingen van een specifieke alinea verkrijgen?**

Gebruik [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) om de begrenzende rechthoek van de alinea op te halen. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) geeft de afmetingen van een afzonderlijk fragment.

**Waar wordt de uitlijning van alinea's (links, rechts, gecentreerd of uitgevuld) geregeld?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) is een alinea‑niveau instelling en wordt toegepast op de hele alinea, ongeacht de opmaak van individuele fragmenten.

Om delen van verschillende lettergroottes verticaal uit te lijnen binnen elke regel, zie [Align Fonts Within a Line](/slides/nl/nodejs-java/text-formatting/#align-fonts-within-a-line).

**Kan ik de proeflees‑taal voor een deel van een alinea instellen?**

Ja. Stel [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) in voor individuele fragmenten, zodat één alinea tekst in meerdere talen kan bevatten.