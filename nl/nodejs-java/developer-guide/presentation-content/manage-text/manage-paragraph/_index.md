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
- opsommingstekens beheren
- alinea inspringing
- hangende inspringing
- alinea bullet
- genummerde lijst
- lijst met opsommingstekens
- alinea eigenschappen
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
description: "Beheers alinea-opmaak met Aspose.Slides voor Node.js via Java—optimaliseer uitlijning, spatiëring en stijl in PPT-, PPTX- en ODP-presentaties in JavaScript."
---
## **Introductie**

Aspose.Slides biedt alle klassen die u nodig hebt om te werken met PowerPoint-tekst, alinea's en porties in Java.

* Aspose.Slides biedt de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) klasse om objecten toe te voegen die een alinea vertegenwoordigen. Een `TextFame`‑object kan één of meerdere alinea's bevatten (elke alinea wordt aangemaakt via een regeleinde).
* Aspose.Slides biedt de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) klasse om objecten toe te voegen die porties vertegenwoordigen. Een `Paragraph`‑object kan één of meerdere porties bevatten (een verzameling van tekstportie‑objecten).
* Aspose.Slides biedt de [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) klasse om objecten toe te voegen die teksten en hun opmaak‑eigenschappen vertegenwoordigen.

Een `Paragraph`‑object kan teksten met verschillende opmaak‑eigenschappen verwerken via zijn onderliggende `Portion`‑objecten.

## **Meerdere alinea's toevoegen die meerdere porties bevatten**

Deze stappen laten zien hoe u een tekstkader kunt toevoegen met 3 alinea's, waarbij elke alinea 3 porties bevat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende slide via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de slide.
4. Haal het ITextFrame op dat geassocieerd is met de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/).
5. Maak twee [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) objecten aan en voeg ze toe aan de `IParagraphs`‑collectie van het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/).
6. Maak drie [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) objecten aan voor elke nieuwe `Paragraph` (twee Portion‑objecten voor de standaard Paragraph) en voeg elk `Portion`‑object toe aan de IPortion‑collectie van elke `Paragraph`.
7. Stel voor elke portie tekst in.
8. Pas de gewenste opmaak‑eigenschappen toe op elke portie met behulp van de opmaak‑eigenschappen van het `Portion`‑object.
9. Sla de gewijzigde presentatie op.

Deze Javascript‑code is een implementatie van de stappen om alinea's met porties toe te voegen:

```javascript
// Instantieer een Presentation-klasse die een PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Eerste dia openen
    var slide = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van type Rechthoek toe
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Toegang tot TextFrame van de AutoShape
    var tf = ashp.getTextFrame();
    // Maak alinea's en porties aan met verschillende tekstopmaak
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
    // Schrijf PPTX naar schijf
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alinea opsommingstekens beheren**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Met opsommingstekens gemarkeerde alinea's zijn altijd gemakkelijker te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende slide via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de geselecteerde slide.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de auto‑shape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie met behulp van de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) klasse.
7. Stel het bullet‑`Type` voor de alinea in op `Symbol` en stel het bullet‑teken in.
8. Stel de alinea‑`Text` in.
9. Stel de alinea‑`Indent` voor de bullet in.
10. Stel een kleur in voor de bullet.
11. Stel een hoogte in voor de bullet.
12. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
13. Voeg de tweede alinea toe en herhaal het proces dat in stap 7 tot 13 is beschreven.
14. Sla de presentatie op.

Deze Javascript‑code laat zien hoe u een alinea‑bullet toevoegt:

```javascript
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Voegt een AutoShape toe en krijgt toegang tot deze
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Toegang tot het tekstkader van de auto‑shape
    var txtFrm = aShp.getTextFrame();
    // Verwijdert de standaard alinea
    txtFrm.getParagraphs().removeAt(0);
    // Maakt een alinea aan
    var para = new aspose.slides.Paragraph();
    // Stelt de bullet‑stijl en het symbool van de alinea in
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Stelt de alinea‑tekst in
    para.setText("Welcome to Aspose.Slides");
    // Stelt de bullet‑inspringing in
    para.getParagraphFormat().setIndent(25);
    // Stelt de bullet‑kleur in
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// stel IsBulletHardColor in op true om een eigen bullet‑kleur te gebruiken
    // Stelt de bullet‑hoogte in
    para.getParagraphFormat().getBullet().setHeight(100);
    // Voeg alinea toe aan het tekstkader
    txtFrm.getParagraphs().add(para);
    // Maakt tweede alinea aan
    var para2 = new aspose.slides.Paragraph();
    // Stelt het bullet‑type en de stijl van de alinea in
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Voegt alinea‑tekst toe
    para2.setText("This is numbered bullet");
    // Stelt de bullet‑inspringing in
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// stel IsBulletHardColor in op true om een eigen bullet‑kleur te gebruiken
    // Stelt de bullet‑hoogte in
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Voeg alinea toe aan het tekstkader
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

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea's met afbeelding‑bullets zijn gemakkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende slide via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de slide.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de auto‑shape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie met behulp van de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) klasse.
7. Laad de afbeelding in [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/).
8. Stel het bullet‑type in op [Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) en stel de afbeelding in.
9. Stel de alinea‑`Text` in.
10. Stel de alinea‑`Indent` voor de bullet in.
11. Stel een kleur in voor de bullet.
12. Stel een hoogte in voor de bullet.
13. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
14. Voeg de tweede alinea toe en herhaal het proces op basis van de vorige stappen.
15. Sla de gewijzigde presentatie op.

Deze Javascript‑code laat zien hoe u afbeelding‑bullets kunt toevoegen en beheren:

```javascript
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
var presentation = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var slide = presentation.getSlides().get_Item(0);
    // Instantieert de afbeelding voor bullets
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
    // Toegang tot het tekstkader van de auto‑shape
    var textFrame = autoShape.getTextFrame();
    // Verwijdert de standaard alinea
    textFrame.getParagraphs().removeAt(0);
    // Maakt een nieuwe alinea aan
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Stelt de bullet‑stijl en afbeelding van de alinea in
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Stelt de bullet‑hoogte in
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Voeg alinea toe aan het tekstkader
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

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Meerlagige bullets zijn gemakkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende slide via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe in de nieuwe slide.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de auto‑shape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) klasse en stel de diepte in op 0.
7. Maak de tweede alinea‑instantie via de `Paragraph`‑klasse en stel de diepte in op 1.
8. Maak de derde alinea‑instantie via de `Paragraph`‑klasse en stel de diepte in op 2.
9. Maak de vierde alinea‑instantie via de `Paragraph`‑klasse en stel de diepte in op 3.
10. Voeg de nieuwe alinea's toe aan de alinea‑collectie van het `TextFrame`.
11. Sla de gewijzigde presentatie op.

Deze Javascript‑code laat zien hoe u meerlagige bullets kunt toevoegen en beheren:

```javascript
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Voegt een AutoShape toe en krijgt toegang tot deze
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Toegang tot het tekstkader van de aangemaakte auto-shape
    var text = aShp.addTextFrame("");
    // Verwijdert de standaard alinea
    text.getParagraphs().clear();
    // Voegt de eerste alinea toe
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Stelt het bullet-niveau in
    para1.getParagraphFormat().setDepth(0);
    // Voegt de tweede alinea toe
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Stelt het bullet-niveau in
    para2.getParagraphFormat().setDepth(1);
    // Voegt de derde alinea toe
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Stelt het bullet-niveau in
    para3.getParagraphFormat().setDepth(2);
    // Voegt de vierde alinea toe
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Stelt het bullet-niveau in
    para4.getParagraphFormat().setDepth(3);
    // Voegt alinea's toe aan de collectie
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Schrijft de presentatie weg als een PPTX-bestand
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alinea met aangepaste genummerde lijst beheren**

De [BulletFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bulletformat/) klasse biedt de eigenschap [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) en andere die u in staat stellen alinea's met aangepaste nummering of opmaak te beheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de slide die de alinea bevat.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de slide.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) klasse en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) in op 2.
7. Maak de tweede alinea‑instantie via de `Paragraph`‑klasse en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea‑instantie via de `Paragraph`‑klasse en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea's toe aan de alinea‑collectie van het `TextFrame`.
10. Sla de gewijzigde presentatie op.

Deze Javascript‑code laat zien hoe u alinea's met aangepaste nummering of opmaak kunt toevoegen en beheren:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Toegang tot het tekstkader van de aangemaakte autoshape
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

## **Eerste‑regelinzet voor een alinea instellen**

Gebruik de methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) om de eerste‑regelinzet van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linker­marge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) wanneer u de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt verschillende alinea's aan en past verschillende insattingen toe om te demonstreren hoe de eerste‑regelinzet de lay‑out van een alinea beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de doel‑slide.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de slide.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's aan en stel verschillende [Indent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) waarden in.
6. Voeg de alinea's toe aan het tekstkader.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een alinea‑insluiting instelt:

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

![De eerste‑regelinzet van de alinea's](first_line_indent.png)

## **Hangende insluiting voor een alinea instellen**

Een hangende insluiting is een alinea‑lay‑out waarbij de eerste regel links begint ten opzichte van de overige regels. In Aspose.Slides creëert u dit effect met de methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/). Stel de insluiting in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk definieert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) de linkerpositie van de alinea‑inhoud, en [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) definieert de positie van de eerste regel ten opzichte van die marge. Om een hangende insluiting te creëren, stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, glossarium‑items en andere alinea's waarbij ingesprongen regels onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de doel‑slide.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de slide.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak alinea's aan en stel voor elke alinea een positieve [MarginLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) waarde in.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setindent/) waarde in om het hangende insluiting‑effect te creëren.
7. Voeg de alinea's toe aan het tekstkader.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een hangende insluiting voor een alinea instelt:

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

![De hangende insluiting van de alinea's](hanging_indent.png)

## **Eind‑run‑eigenschappen voor alinea beheren**

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Haal de referentie op voor de slide die de alinea bevat via zijn positie.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de slide.
4. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) met twee alinea's toe aan de rechthoek.
5. Stel de `FontHeight` en het lettertype in voor de alinea's.
6. Stel de End‑eigenschappen in voor de alinea's.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Javascript‑code laat zien hoe u de End‑eigenschappen voor alinea's in PowerPoint kunt instellen:

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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende slide via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de slide.
4. Voeg de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de `AutoShape` toe en krijg er toegang toe.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Lees het bron‑HTML‑bestand met een TextReader.
7. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) klasse.
8. Voeg de inhoud van het HTML‑bestand, gelezen met de TextReader, toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de gewijzigde presentatie op.

Deze Javascript‑code is een implementatie van de stappen voor het importeren van HTML‑teksten in alinea's:

```javascript
// Maak lege presentaties‑instantie
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de standaard eerste dia van de presentatie
    var slide = pres.getSlides().get_Item(0);
    // Voeg de AutoShape toe om de HTML‑inhoud op te nemen
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Voeg een tekstkader toe aan de vorm
    ashape.addTextFrame("");
    // Wis alle alinea's in het toegevoegde tekstkader
    ashape.getTextFrame().getParagraphs().clear();
    // Laad het HTML‑bestand met een stream‑reader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Voeg tekst van de HTML‑stream‑reader toe aan het tekstkader
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Sla de presentatie op
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt uitgebreide ondersteuning voor het exporteren van teksten (geplaatst in alinea's) naar HTML.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Toegang tot de referentie van de betreffende slide via de index.
3. Toegang tot de vorm die de te exporteren tekst naar HTML bevat.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de vorm.
5. Maak een instantie van `StreamWriter` aan en voeg het nieuwe HTML‑bestand toe.
6. Geef een start‑index door aan StreamWriter en exporteer de door u gewenste alinea's.

Deze Javascript‑code laat zien hoe u PowerPoint‑alinea‑teksten naar HTML kunt exporteren:

```javascript
// Laad het presentatiebestand
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Toegang tot de standaard eerste dia van de presentatie
    var slide = pres.getSlides().get_Item(0);
    // Gewenste index
    var index = 0;
    // Toegang tot de toegevoegde vorm
    var ashape = slide.getShapes().get_Item(index);
    // Maak output‑HTML‑bestand
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extracteer de eerste alinea als HTML
    // Schrijf alinea‑gegevens naar HTML door de start‑index en het aantal te kopiëren alinea's op te geven
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

In dit gedeelte onderzoeken we twee voorbeelden die laten zien hoe u een tekstalinea, vertegenwoordigd door de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) klasse, als afbeelding kunt opslaan. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `getImage`‑methoden van de [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) klasse, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren als een bitmap‑afbeelding. Deze benaderingen stellen u in staat specifieke delen van de tekst uit PowerPoint‑presentaties te extraheren en als afzonderlijke afbeeldingen op te slaan, wat nuttig kan zijn voor verder gebruik in diverse scenario's.

Laten we aannemen dat we een presentatiedocument hebben genaamd sample.pptx met één slide, waarbij de eerste vorm een tekstvak is dat drie alinea's bevat.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld halen we de tweede alinea op als afbeelding. Hiervoor extraheren we de afbeelding van de vorm uit de eerste slide van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstkader van de vorm. De alinea wordt daarna opnieuw getekend op een nieuwe bitmap‑afbeelding, die in PNG‑formaat wordt opgeslagen. Deze methode is bijzonder nuttig wanneer u een specifieke alinea als afzonderlijke afbeelding wilt opslaan terwijl de exacte afmetingen en opmaak van de tekst behouden blijven.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de vorm op in het geheugen als een bitmap.
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

Het resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren toe te voegen aan de alinea‑afbeelding. De vorm wordt uit de presentatie gehaald en opgeslagen als een afbeelding met een schaalfactor van `2`. Dit maakt een uitvoer met hogere resolutie mogelijk bij het exporteren van de alinea. De grenzen van de alinea worden vervolgens berekend rekening houdend met de schaal. Schalen kan bijzonder nuttig zijn wanneer een meer gedetailleerde afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardige gedrukte materialen.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de vorm op in het geheugen als een bitmap met schaling.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Maak een vorm‑bitmap vanuit het geheugen.
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

**Kan ik de regelafbreking volledig uitschakelen binnen een tekstkader?**

Ja. Gebruik de omslaginstelling van het tekstkader ([setWrapText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/setwraptext/)) om afbreken uit te schakelen, zodat regels niet worden afgebroken aan de randen van het kader.

**Hoe kan ik de exacte positie en afmetingen van een specifieke alinea op de slide krijgen?**

U kunt de begrenzingsrechthoek van de alinea (en zelfs van een enkele portie) opvragen om de precieze positie en grootte op de slide te kennen.

**Waar wordt de uitlijning van alinea's (links/rechts/centreren/uitvullen) geregeld?**

[setAlignment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setalignment/) is een methode voor een alinea‑niveau instelling in [ParagraphFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/); het wordt toegepast op de hele alinea ongeacht de opmaak van individuele porties.

**Kan ik een spellingscontrole‑taal instellen voor slechts een deel van een alinea (bijv. één woord)?**

Ja. De taal wordt ingesteld op portieniveau ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), waardoor meerdere talen kunnen bestaan binnen één alinea.