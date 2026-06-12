---
title: Beheer PowerPoint-tekstalinea's in JavaScript
linktitle: Alinea beheren
type: docs
weight: 40
url: /nl/nodejs-java/manage-paragraph/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingsteken beheren
- alinea-insprong
- hangende insprong
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
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheers alinea-opmaak met Aspose.Slides voor Node.js via Java—optimaliseer uitlijning, afstand en stijl in PPT-, PPTX- en ODP-presentaties in JavaScript."
---
## **Inleiding**

Aspose.Slides levert alle klassen die u nodig heeft om met PowerPoint‑teksten, alinea's en fragmenten in Java te werken.

* Aspose.Slides biedt de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) class om objecten toe te voegen die een alinea vertegenwoordigen. Een `TextFame`‑object kan één of meerdere alinea's bevatten (elke alinea wordt aangemaakt met een regelterugloop).
* Aspose.Slides biedt de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) class om objecten toe te voegen die fragmenten vertegenwoordigen. Een `Paragraph`‑object kan één of meerdere fragmenten bevatten (een verzameling tekstfragment‑objecten).
* Aspose.Slides biedt de [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) class om objecten toe te voegen die teksten en hun opmaak‑eigenschappen vertegenwoordigen.

Een `Paragraph`‑object kan teksten met verschillende opmaak‑eigenschappen verwerken via de onderliggende `Portion`‑objecten.

## **Meerdere alinea's met meerdere fragmenten toevoegen**

Deze stappen laten zien hoe u een tekstframe met 3 alinea's toevoegt, waarbij elke alinea 3 fragmenten bevat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class.
2. Verkrijg de referentie van de betreffende dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Haal het ITextFrame op dat bij de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) hoort.
5. Maak twee [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) objecten aan en voeg ze toe aan de `IParagraphs`‑collectie van het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/).
6. Maak drie [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) objecten voor elke nieuwe `Paragraph` (twee Portion‑objecten voor de standaard Paragraph) en voeg elk `Portion`‑object toe aan de IPortion‑collectie van elke `Paragraph`.
7. Stel tekst in voor elk fragment.
8. Pas uw gewenste opmaakkenmerken toe op elk fragment via de opmaak‑eigenschappen van het `Portion`‑object.
9. Sla de gewijzigde presentatie op.

Deze Javascript‑code is een implementatie van de stappen om alinea's met fragmenten toe te voegen:

```javascript
// Instantieer een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type Rechthoek toe
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Toegang tot TextFrame van de AutoShape
    var tf = ashp.getTextFrame();
    // Maak alinea's en fragmenten met verschillende tekstformaten
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Sla PPTX op schijf
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alinea‑opsommingstekens beheren**

Opsommingstekens helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea's met opsommingstekens zijn altijd makkelijker te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class.
2. Verkrijg de referentie van de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de auto‑shape.
5. Verwijder de standaard‑alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie met de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) class.
7. Stel het bullet‑`Type` van de alinea in op `Symbol` en bepaal het bullet‑teken.
8. Stel de alinea‑`Text` in.
9. Stel de alinea‑`Indent` in voor de bullet.
10. Stel een kleur in voor de bullet.
11. Stel een hoogte in voor de bullet.
12. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
13. Voeg de tweede alinea toe en herhaal de stappen 7 tot 12.
14. Sla de presentatie op.

Deze Javascript‑code laat zien hoe u een alinea‑bullet toevoegt:

```javascript
// Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Verwijst naar de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Voegt een AutoShape toe en krijgt toegang tot deze
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Verkiest het tekstframe van de AutoShape
    var txtFrm = aShp.getTextFrame();
    // Verwijdert de standaard‑alinea
    txtFrm.getParagraphs().removeAt(0);
    // Maakt een alinea
    var para = new aspose.slides.Paragraph();
    // Stelt een alinea‑opsommingsteken‑stijl en -symbool in
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Stelt de alinea‑tekst in
    para.setText("Welcome to Aspose.Slides");
    // Stelt de insprong van het opsommingsteken in
    para.getParagraphFormat().setIndent(25);
    // Stelt de kleur van het opsommingsteken in
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // zet IsBulletHardColor op true om een eigen opsommingsteken‑kleur te gebruiken
    // Stelt de hoogte van het opsommingsteken in
    para.getParagraphFormat().getBullet().setHeight(100);
    // Voegt alinea toe aan het tekstframe
    txtFrm.getParagraphs().add(para);
    // Maakt tweede alinea
    var para2 = new aspose.slides.Paragraph();
    // Stelt alinea‑opsommingsteken‑type en -stijl in
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Voegt alinea‑tekst toe
    para2.setText("This is numbered bullet");
    // Stelt de insprong van het opsommingsteken in
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // zet IsBulletHardColor op true om een eigen opsommingsteken‑kleur te gebruiken
    // Stelt de hoogte van het opsommingsteken in
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Voegt alinea toe aan het tekstframe
    txtFrm.getParagraphs().add(para2);
    // Slaat de gewijzigde presentatie op
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Afbeeldings‑bullets beheren**

Opsommingstekens helpen u om informatie snel en efficiënt te organiseren en te presenteren. Afbeeldings‑alinea's zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class.
2. Verkrijg de referentie van de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de auto‑shape.
5. Verwijder de standaard‑alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie met de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) class.
7. Laad de afbeelding in [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/).
8. Stel het bullet‑type in op [Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) en wijs de afbeelding toe.
9. Stel de alinea‑`Text` in.
10. Stel de alinea‑`Indent` in voor de bullet.
11. Stel een kleur in voor de bullet.
12. Stel een hoogte in voor de bullet.
13. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
14. Voeg de tweede alinea toe en herhaal het proces volgens de vorige stappen.
15. Sla de gewijzigde presentatie op.

Deze Javascript‑code laat zien hoe u afbeeldings‑bullets toevoegt en beheert:

```javascript
// Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var presentation = new aspose.slides.Presentation();
try {
    // Verwijst naar de eerste dia
    var slide = presentation.getSlides().get_Item(0);
    // Instantieert de afbeelding voor opsommingstekens
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Voegt een AutoShape toe en krijgt toegang tot deze
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Verkiest het tekstframe van de AutoShape
    var textFrame = autoShape.getTextFrame();
    // Verwijdert de standaard‑alinea
    textFrame.getParagraphs().removeAt(0);
    // Maakt een nieuwe alinea
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Stelt de alinea‑opsommingsteken‑stijl en afbeelding in
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Stelt de hoogte van het opsommingsteken in
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Voegt alinea toe aan het tekstframe
    textFrame.getParagraphs().add(paragraph);
    // Schrijft de presentatie weg als een PPTX‑bestand
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Schrijft de presentatie weg als een PPT‑bestand
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Meerlagige bullets beheren**

Opsommingstekens helpen u om informatie snel en efficiënt te organiseren en te presenteren. Meerlagige bullets zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class.
2. Verkrijg de referentie van de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe in de nieuwe dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de auto‑shape.
5. Verwijder de standaard‑alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) class en stel diepte in op 0.
7. Maak de tweede alinea‑instantie via de `Paragraph` class en stel diepte in op 1.
8. Maak de derde alinea‑instantie via de `Paragraph` class en stel diepte in op 2.
9. Maak de vierde alinea‑instantie via de `Paragraph` class en stel diepte in op 3.
10. Voeg de nieuwe alinea's toe aan de alinea‑collectie van het `TextFrame`.
11. Sla de gewijzigde presentatie op.

Deze Javascript‑code laat zien hoe u meerlagige bullets toevoegt en beheert:

```javascript
// Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Verwijst naar de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Voegt een AutoShape toe en krijgt toegang tot deze
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Verkiest het tekstframe van de gemaakte AutoShape
    var text = aShp.addTextFrame("");
    // Leegt de standaard‑alinea
    text.getParagraphs().clear();
    // Voegt de eerste alinea toe
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Stelt het opsommingsteken‑niveau in
    para1.getParagraphFormat().setDepth(0);
    // Voegt de tweede alinea toe
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Stelt het opsommingsteken‑niveau in
    para2.getParagraphFormat().setDepth(1);
    // Voegt de derde alinea toe
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Stelt het opsommingsteken‑niveau in
    para3.getParagraphFormat().setDepth(2);
    // Voegt de vierde alinea toe
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Stelt het opsommingsteken‑niveau in
    para4.getParagraphFormat().setDepth(3);
    // Voegt alinea's toe aan de collectie
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Slaat de presentatie op als een PPTX‑bestand
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alinea met aangepaste genummerde lijst beheren**

De [BulletFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bulletformat/) class biedt de eigenschap [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) en andere die u in staat stellen alinea's met aangepaste nummering of opmaak te beheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class.
2. Open de dia die de alinea bevat.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de auto‑shape.
5. Verwijder de standaard‑alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) class en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) in op 2.
7. Maak de tweede alinea‑instantie via de `Paragraph` class en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea‑instantie via de `Paragraph` class en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea's toe aan de alinea‑collectie van het `TextFrame`.
10. Sla de gewijzigde presentatie op.

Deze Javascript‑code laat zien hoe u alinea's met aangepaste nummering of opmaak toevoegt en beheert:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Verkrijgt het tekstframe van de aangemaakte AutoShape
    var textFrame = shape.getTextFrame();
    // Verwijdert de standaard bestaande alinea
    textFrame.getParagraphs().removeAt(0);
    // Eerste lijst
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Eerste‑regellijninsprong voor een alinea instellen**

Gebruik de methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) om de eerste‑regellijninsprong van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑body.

Gebruik [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) wanneer u de gehele alinea wilt verplaatsen. Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt meerdere alinea's en past verschillende insprong‑waarden toe om te laten zien hoe de eerste‑regellijninsprong de lay‑out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard‑alinea.
5. Maak meerdere alinea's en stel verschillende [Indent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) waarden in voor hen.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een alinea‑insprong instelt:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Het resultaat:

![De eerste‑regellijninsprong van de alinea's](first_line_indent.png)

## **Hangende insprong voor een alinea instellen**

Een hangende insprong is een alinea‑lay‑out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëert u dit effect met de methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/). Stel de insprong in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑body.

In de praktijk bepaalt [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) de linkse positie van de alinea‑body, en [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te creëren, stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, glossarium‑items en andere alinea's waarbij doorgelopen regels onder de alinea‑body moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard‑alinea.
5. Maak alinea's en stel een positieve [MarginLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) waarde in voor elke alinea.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) waarde in om het hangende‑insprong‑effect te creëren.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een hangende insprong voor een alinea instelt:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Het resultaat:

![De hangende insprong van de alinea's](hanging_indent.png)

## **Eind‑alinea‑run‑eigenschappen voor alinea beheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class.
1. Haal de referentie op van de dia die de alinea bevat via de positie.
1. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) met twee alinea's toe aan de rechthoek.
1. Stel de `FontHeight` en het lettertype in voor de alinea's.
1. Stel de eind‑eigenschappen in voor de alinea's.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Javascript‑code laat zien hoe u de eind‑eigenschappen voor alinea's in PowerPoint instelt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **HTML‑tekst importeren in alinea's**

Aspose.Slides biedt uitgebreide ondersteuning voor het importeren van HTML‑tekst in alinea's.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
4. Voeg en open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de auto‑shape.
5. Verwijder de standaard‑alinea in het `TextFrame`.
6. Lees het bron‑HTML‑bestand in met een TextReader.
7. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) class.
8. Voeg de HTML‑bestandsinhoud uit de gelezen TextReader toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de gewijzigde presentatie op.

Deze Javascript‑code is een implementatie van de stappen voor het importeren van HTML‑teksten in alinea's:

```javascript
// Maak lege presentatie‑instantie
var pres = new aspose.slides.Presentation();
try {
    // Benader de standaard eerste dia van de presentatie
    var slide = pres.getSlides().get_Item(0);
    // Voeg de AutoShape toe om de HTML‑inhoud te huisvesten
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Voeg een tekstframe toe aan de vorm
    ashape.addTextFrame("");
    // Wis alle alinea's in het toegevoegde tekstframe
    ashape.getTextFrame().getParagraphs().clear();
    // Laad het HTML‑bestand met een stream‑reader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Voeg tekst uit de HTML‑stream‑reader toe aan het tekstframe
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Sla de presentatie op
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alinea‑teksten exporteren naar HTML**

Aspose.Slides biedt uitgebreide ondersteuning voor het exporteren van teksten (gehouden in alinea's) naar HTML.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) class en laad de gewenste presentatie.
2. Open de referentie van de betreffende dia via de index.
3. Open de vorm die de te exporteren tekst bevat.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de vorm.
5. Maak een instantie van `StreamWriter` en voeg het nieuwe HTML‑bestand toe.
6. Geef een start‑index aan StreamWriter en exporteer de gewenste alinea's.

Deze Javascript‑code laat zien hoe u PowerPoint‑alinea‑teksten exporteert naar HTML:

```javascript
// Laad het presentatie‑bestand
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Benader de standaard eerste dia van de presentatie
    var slide = pres.getSlides().get_Item(0);
    // Gewenste index
    var index = 0;
    // Toegang tot de toegevoegde vorm
    var ashape = slide.getShapes().get_Item(index);
    // Maak uitvoer‑HTML‑bestand
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Exporteer de eerste alinea als HTML
    // Schrijf alinea‑gegevens naar HTML door de start‑index van de alinea en het totaal aantal alinea's op te geven die gekopieerd moeten worden
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Een alinea opslaan als afbeelding**

In dit onderdeel bekijken we twee voorbeelden die laten zien hoe u een tekst‑alinea, gerepresenteerd door de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) class, opslaat als afbeelding. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `getImage`‑methoden van de [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) class, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren als bitmap‑afbeelding. Deze benaderingen stellen u in staat om specifieke tekstgedeelten uit PowerPoint‑presentaties te extraheren en als afzonderlijke afbeeldingen op te slaan, wat nuttig kan zijn voor verdere toepassingen in diverse scenario's.

Laten we aannemen dat we een presentatie‑bestand hebben genaamd **sample.pptx** met één dia, waarbij de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld verkrijgen we de tweede alinea als afbeelding. Hiervoor extraheren we de afbeelding van de vorm van de eerste dia van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstframe van de vorm. De alinea wordt daarna opnieuw getekend op een nieuw bitmap‑beeld, dat in PNG‑formaat wordt opgeslagen. Deze methode is vooral handig wanneer u een specifieke alinea als aparte afbeelding wilt bewaren terwijl u de exacte afmetingen en opmaak behoudt.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de vorm in het geheugen op als een bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Maak een vorm‑bitmap vanuit het geheugen.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Bereken de grenzen van de tweede alinea.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Bereken de coördinaten en grootte voor de uitvoer‑afbeelding (minimumgrootte - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Snijd de vorm‑bitmap bij om alleen de alinea‑bitmap te verkrijgen.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Het resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaal‑factoren toe te passen op de alinea‑afbeelding. De vorm wordt uit de presentatie gehaald en opgeslagen als afbeelding met een schaal‑factor van `2`. Dit levert een hogere resolutie bij het exporteren van de alinea. De alinea‑grenzen worden vervolgens berekend rekening houdend met de schaal. Schalen kan bijzonder nuttig zijn wanneer een gedetailleerdere afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardige drukwerk‑materialen.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de vorm in het geheugen op als een bitmap met schaling.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Maak een bitmap van de vorm vanuit het geheugen.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Bereken de grenzen van de tweede alinea.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Bereken de coördinaten en grootte voor de uitvoerafbeelding (minimumgrootte - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Snijd de vorm‑bitmap bij om alleen de alinea‑bitmap te krijgen.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Kan ik regelomslag volledig uitschakelen binnen een tekstvak?**

Ja. Gebruik de omslaginstelling van het tekstvak ([setWrapText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/setwraptext/)) om omslag uit te schakelen zodat regels niet afbreken aan de randen van het vak.

**Hoe kan ik de exacte positie‑en‑afmeting van een specifieke alinea op de dia verkrijgen?**

U kunt de begrenzende rechthoek van de alinea (en zelfs van een enkel fragment) ophalen om de precieze positie en grootte op de dia te kennen.

**Waar wordt de alinea‑uitlijning (links/rechts/centreren/uitvullen) geregeld?**

[setAlignment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setalignment/) is een methode voor een alinea‑niveau instelling in [ParagraphFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/); deze wordt toegepast op de gehele alinea, ongeacht de afzonderlijke fragment‑opmaak.

**Kan ik een spellingscontrole‑taal instellen voor slechts een deel van een alinea (bijv. één woord)?**

Ja. De taal wordt ingesteld op fragmentniveau ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), zodat meerdere talen kunnen bestaan binnen één alinea.