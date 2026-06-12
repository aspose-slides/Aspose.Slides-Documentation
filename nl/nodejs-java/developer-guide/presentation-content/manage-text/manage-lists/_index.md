---
title: Beheer opsommingstekens en genummerde lijsten in presentaties met JavaScript
linktitle: Beheer lijsten
type: docs
weight: 60
url: /nl/nodejs-java/manage-lists/
keywords:
- opsommingsteken
- opsomminglijst
- genummerde lijst
- symbool opsommingsteken
- afbeelding opsommingsteken
- aangepast opsommingsteken
- meerniveaulijst
- opsommingsteken maken
- opsommingsteken toevoegen
- lijst toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u opsommingstekens, afbeelding, meerniveaulijsten en genummerde lijsten kunt maken en opmaken in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides voor Node.js via Java stelt u in staat om opsommingstekens en genummerde lijsten te maken en te formatteren in PowerPoint‑ en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingsteken‑instellingen worden beheerd via de alinea‑opmaak.

Gebruik de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/)‑klasse om lijstopmaak op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is `Paragraph.getParagraphFormat().getBullet()`, dat een [BulletFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bulletformat/)‑object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeropmaak en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming met een aangepast symbool maakt
- een afbeelding‑opsommingsteken maakt
- een meerlagige lijst maakt door de alinea‑diepte in te stellen
- een genummerde lijst maakt
- de lijstopmaak in een bestaande presentatie bekijkt en aanpast

## **Maak een opsomming met opsommingstekens**

Om een opsomming met opsommingstekens te maken, voegt u [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/)‑objecten toe aan een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) en stelt u `BulletFormat.setType` in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bullettype/). Vervolgens kunt u `BulletFormat.setChar`, `BulletFormat.getColor` en `BulletFormat.setHeight` instellen om het uiterlijk van het opsommingsteken te regelen.

De volgende JavaScript‑code demonstreert hoe u een opsomming met opsommingstekens in een dia maakt:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De symbool‑opsommingstekens](symbol_bullets.png)

## **Maak een genummerde lijst**

Gebruik genummerde lijsten wanneer de volgorde van items belangrijk is. Stel `BulletFormat.setType` in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bullettype/). U kunt ook een nummeropmaak kiezen met `BulletFormat.setNumberedBulletStyle` of `BulletFormat.setNumberedBulletStartWith` instellen wanneer de lijst moet beginnen met een waarde anders dan 1.

De volgende JavaScript‑code laat zien hoe u een genummerde lijst in een dia maakt:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De genummerde opsommingstekens](numbered_bullets.png)

## **Maak een afbeelding‑opsommingsteken**

Aspose.Slides stelt u in staat om een regulier opsommingsteken te vervangen door een afbeelding. Afbeelding‑opsommingstekens werken het beste met simpele afbeeldingen die ook op een kleine grootte leesbaar blijven, zoals iconen of kleine transparante PNG‑bestanden.

{{% alert color="primary" %}}
Idealiter, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, kiest u het beste een eenvoudige grafiek met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.

Houd er rekening mee dat de afbeelding wordt verkleind tot een zeer kleine grootte. Om die reden raden wij sterk aan een afbeelding te kiezen die duidelijk en visueel effectief blijft wanneer deze wordt gebruikt als opsommingsteken in een lijst.
{{% /alert %}}

Om een afbeelding‑opsommingsteken te maken, voegt u een afbeelding toe aan [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) met `Presentation.getImages().addImage` en kent u het geretourneerde [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/)‑object toe aan `BulletFormat.getPicture().setImage`. Stel `BulletFormat.setType` in op [BulletType.Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bullettype/) vóór het toewijzen van de afbeelding.

Stel dat we een “image.png” hebben:

![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende JavaScript‑code laat zien hoe u afbeelding‑opsommingstekens in een dia maakt:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Het resultaat:

![De afbeelding‑opsommingstekens](picture_bullets.png)

## **Maak een meerlagige lijst**

Gebruik `ParagraphFormat.setDepth` om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 is eronder genest, enzovoort.

De volgende JavaScript‑code laat zien hoe u een meerlagige opsomming maakt:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De meerlagige lijst](multilevel_list.png)

## **Wijzig een bestaande lijst**

Om de lijstopmaak in een bestaande presentatie te wijzigen, krijgt u toegang tot de doel‑alinea en werkt u de `ParagraphFormat.getBullet`‑instellingen bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen ook worden gebruikt om geladen lijsten uit een PPT, PPTX of ODP‑bestand te bekijken of aan te passen.

De volgende JavaScript‑code wijzigt de eerste alinea in een tekstframe zodat deze een genummerde lijststijl gebruikt:

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kunnen opsommingstekens en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doel­formaat de overeenkomstige tekstlay‑out en opsommingsteken‑functies ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, krijg toegang tot de doel‑alinea, bekijk of werk de `ParagraphFormat.getBullet`‑instellingen bij, en sla de presentatie vervolgens op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de in de presentatie gebruikte lettertypen de benodigde tekens ondersteunen.