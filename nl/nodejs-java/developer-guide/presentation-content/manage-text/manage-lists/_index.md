---
title: Beheer van opsommingstekens en genummerde lijsten in presentaties met JavaScript
linktitle: Beheer Lijsten
type: docs
weight: 60
url: /nl/nodejs-java/manage-lists/
keywords:
- opsommingsteken
- opsommingslijst
- genummerde lijst
- symbool opsommingsteken
- afbeeldingsopsommingsteken
- aangepast opsommingsteken
- meerlagige lijst
- creeer opsommingsteken
- voeg opsommingsteken toe
- voeg lijst toe
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u opsommingstekens, afbeelding‑opsommingstekens, meerlagige en genummerde lijsten maakt en opmaakt in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java stelt u in staat om bulleted en genummerde lijsten te maken en op te maken in PowerPoint- en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingstekeninstellingen worden beheerd via de alinea‑opmaak.

Gebruik de [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) klasse om lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is `Paragraph.getParagraphFormat().getBullet()`, dat een [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel toont hoe u:

- een opsomming met een aangepast symbool maakt
- een afbeelding‑opsommingsteken maakt
- een meerlagige lijst maakt door de alinea‑diepte in te stellen
- een genummerde lijst maakt
- de lijstopmaak in een bestaande presentatie inspecteert en wijzigt
- de werkelijke lijstmarkeringen en getallen leest naast de alinea‑tekst

## **Maak een opsomming met opsommingstekens**

Om een opsomming met opsommingstekens te maken, voegt u [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) objecten toe aan een [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) en stelt u `BulletFormat.setType` in op [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). Vervolgens kunt u `BulletFormat.setChar`, `BulletFormat.getColor` en `BulletFormat.setHeight` instellen om het uiterlijk van het opsommingsteken te regelen.

De volgende JavaScript‑code laat zien hoe u een opsomming met opsommingstekens maakt in een dia:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Gebruik genummerde lijsten wanneer de volgorde van items van belang is. Stel `BulletFormat.setType` in op [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). U kunt ook een nummerformaat kiezen met `BulletFormat.setNumberedBulletStyle` of `BulletFormat.setNumberedBulletStartWith` instellen wanneer de lijst moet starten met een waarde anders dan 1.

De volgende JavaScript‑code toont hoe u een genummerde lijst maakt in een dia:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Aspose.Slides stelt u in staat een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het beste met eenvoudige afbeeldingen die zelfs op een klein formaat leesbaar blijven, zoals iconen of kleine transparante PNG‑bestanden.

{{% alert color="info" title="Note" %}}
Ideaal gezien, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, kiest u het beste een eenvoudige afbeelding met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.

Houd er rekening mee dat de afbeelding wordt verkleind tot een zeer klein formaat. Om die reden raden wij sterk aan een afbeelding te kiezen die helder en visueel effectief blijft wanneer deze als opsommingsteken in een lijst wordt gebruikt.
{{% /alert %}}

Om een afbeelding‑opsommingsteken te maken, voegt u een afbeelding toe aan [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) met `Presentation.getImages().addImage` en kent u het geretourneerde [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) object toe aan `BulletFormat.getPicture().setImage`. Stel `BulletFormat.setType` in op [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) voordat u de afbeelding toewijst.

Stel dat we een "image.png" hebben:

![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende JavaScript‑code toont hoe u afbeelding‑opsommingstekens maakt in een dia:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Gebruik `ParagraphFormat.setDepth` om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 staat eronder genest, enzovoort.

De volgende JavaScript‑code toont hoe u een meerlagige opsomming maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Om de lijstopmaak in een bestaande presentatie te wijzigen, benadert u de doel‑alinea en werkt u de `ParagraphFormat.getBullet`‑instellingen bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen ook worden gebruikt om lijsten die uit een PPT-, PPTX- of ODP‑bestand zijn geladen, te inspecteren of te wijzigen.

De volgende JavaScript‑code wijzigt de eerste alinea in een tekstframe zodat deze een genummerde lijststijl gebruikt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Lees de werkelijke opsommingsteken‑waarden**

Wanneer u de presentatie‑inhoud extraheert, behoudt u lijstmarkeringen naast de alinea‑tekst. Roep [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective) aan en benader [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) om het effectieve opsommingsteken‑formaat te verkrijgen. Controleer de [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) voordat u [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) leest.

Voor genummerde lijsten, onderscheid deze drie waarden:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) bepaalt het formaat, bijvoorbeeld Arabische cijfers gevolgd door een punt of kleine letters gevolgd door een punt.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) specificeert het startnummer voor een groep genummerde alinea's.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) retourneert de opgemaakte marker voor een specifieke alinea. Bijvoorbeeld, het tweede item in een lijst die bij 5 begint, retourneert `6.`.

Behoud [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDepth) bij elke alinea om het nestingsniveau te behouden. De werkelijke marker codeert niet de volledige hiërarchie: een geneste item kan `c.` retourneren in plaats van een gecombineerd label zoals `6.c.`.

Het volgende zelfstandige voorbeeld maakt lijsten, slaat ze op in een presentatie en laadt de presentatie opnieuw om voor elke alinea de tekst, diepte, opsommingsteken‑type en werkelijke waarde te rapporteren. De kleine blauwe afbeelding‑marker wordt gecreëerd uit inline SVG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Maak een afbeeldingmarker zonder extern afbeeldingsbestand.
    const svg = new aspose.slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    const bulletImage = presentation.getImages().addImage(svg);

    function addParagraph(text, depth, type, start, style) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.setText(text);

        const format = paragraph.getParagraphFormat();
        format.setDepth(java.newShort(depth));
        format.setMarginLeft(30 + depth * 40);
        format.setIndent(-28);
        format.setSpaceAfter(8);
        format.getDefaultPortionFormat().setFontHeight(22);
        format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(black);
        format.getBullet().setType(java.newByte(type));
        format.getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
        format.getBullet().getColor().setColor(black);
        if (type === aspose.slides.BulletType.Numbered) {
            format.getBullet().setNumberedBulletStyle(java.newByte(style));
            format.getBullet().setNumberedBulletStartWith(java.newShort(start));
        } else if (type === aspose.slides.BulletType.Symbol) {
            format.getBullet().setChar(java.newChar(0x2022));
        } else if (type === aspose.slides.BulletType.Picture) {
            format.getBullet().getPicture().setImage(bulletImage);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    addParagraph("First item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Second item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Next nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Deep item", 2, aspose.slides.BulletType.Numbered, 4, aspose.slides.NumberedBulletStyle.BulletRomanLCPeriod);
    addParagraph("Back to top level", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Symbol marker", 0, aspose.slides.BulletType.Symbol, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("No bullet", 0, aspose.slides.BulletType.None, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Picture marker", 0, aspose.slides.BulletType.Picture, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const loadedPresentation = new aspose.slides.Presentation("actual_bullet_values.pptx");
try {
    const loadedShape = loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Text | Depth | Type | Actual value");
    const paragraphs = loadedShape.getTextFrame().getParagraphs();
    for (let i = 0; i < paragraphs.getCount(); i++) {
        const paragraph = paragraphs.get_Item(i);
        const bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        let marker;
        switch (bullet.getType()) {
            case aspose.slides.BulletType.Numbered:
            case aspose.slides.BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case aspose.slides.BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case aspose.slides.BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        const typeName = Object.keys(aspose.slides.BulletType).find(name => aspose.slides.BulletType[name] === bullet.getType());
        console.log(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

De oorspronkelijke lijsten worden hieronder weergegeven.

![Lijsten die beginnen bij 5, geneste letter‑ en Romeins‑nummer items, een symbool‑marker, een alinea zonder opsommingsteken, en een blauwe afbeelding‑marker](actual_bullet_values.png)

Het rapport komt overeen met de markers die in PowerPoint worden weergegeven:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Voor [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) retourneert [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null`, niet een lege tekenreeks. Behandel deze types afzonderlijk: het eerste heeft geen marker, terwijl het tweede vereist dat de opsommingsteken‑afbeelding apart wordt extraheerd. Een afbeelding‑opsommingsteken kan niet alleen worden gereproduceerd door een tekst‑marker te extraheren.

## **Veelgestelde vragen**

**Kunnen opsommingstekens en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de overeenkomstige tekstopmaak en opsommingsteken‑functies ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, benader de doel‑alinea, inspecteer of werk de `ParagraphFormat.getBullet`‑instellingen bij, en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de gebruikte lettertypen in de presentatie de benodigde tekens ondersteunen.