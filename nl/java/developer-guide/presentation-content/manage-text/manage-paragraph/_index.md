---
title: Beheer PowerPoint-tekstalinea's in Java
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/java/manage-paragraph/
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
- opsommingslijst
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
- Java
- Aspose.Slides
description: "Beheers alinea-opmaak met Aspose.Slides voor Java — optimaliseer uitlijning, regelafstand en stijl in PPT-, PPTX- en ODP-presentaties in Java."
---
## **Inleiding**

Aspose.Slides biedt alle interfaces en klassen die u nodig heeft om met PowerPoint‑teksten, alinea’s en delen in Java te werken.

* Aspose.Slides biedt de [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) interface waarmee u objecten kunt toevoegen die een alinea vertegenwoordigen. Een `ITextFame`‑object kan één of meerdere alinea’s bevatten (elke alinea wordt aangemaakt via een regeleinde).
* Aspose.Slides biedt de [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) interface waarmee u objecten kunt toevoegen die delen vertegenwoordigen. Een `IParagraph`‑object kan één of meerdere delen bevatten (een verzameling iPortions‑objecten).
* Aspose.Slides biedt de [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) interface waarmee u objecten kunt toevoegen die teksten en hun opmaak‑eigenschappen vertegenwoordigen.

Een `IParagraph`‑object kan teksten met verschillende opmaak‑eigenschappen verwerken via de onderliggende `IPortion`‑objecten.

## **Meerdere alinea’s toevoegen die meerdere delen bevatten**

Deze stappen laten zien hoe u een tekstframe met 3 alinea’s toevoegt, waarbij elke alinea 3 delen bevat:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Open de referentie van de betreffende slide via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de slide.
4. Haal het ITextFrame op dat gekoppeld is aan de [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/).
5. Maak twee [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) objecten en voeg ze toe aan de `IParagraphs`‑collectie van het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/).
6. Maak drie [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) objecten voor elke nieuwe `IParagraph` (twee Portion‑objecten voor de standaard alinea) en voeg elk `IPortion`‑object toe aan de IPortion‑collectie van elke `IParagraph`.
7. Stel tekst in voor elk deel.
8. Pas uw gewenste opmaakfuncties toe op elk deel met behulp van de opmaak‑eigenschappen van het `IPortion`‑object.
9. Sla de aangepaste presentatie op.

```java
// Instantieer een Presentation-klasse die een PPTX-bestand representeert
Presentation pres = new Presentation();
try {
    // Toegang tot eerste slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type Rectangle toe
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Toegang tot TextFrame van de AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Maak alinea's en delen met verschillende tekstformaten
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // Schrijf PPTX naar schijf
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinea‑opsommingstekens beheren**

Opsommingstekens helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea’s met opsommingstekens zijn steeds makkelijker te lezen en te begrijpen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Open de referentie van de betreffende slide via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de geselecteerde slide.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaardalinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie aan met de klasse [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/).
7. Stel het opsommingsteken‑`Type` van de alinea in op `Symbol` en bepaal het opsommingsteken‑karakter.
8. Stel de alinea‑`Text` in.
9. Stel de alinea‑`Indent` in voor het opsommingsteken.
10. Stel een kleur in voor het opsommingsteken.
11. Stel een hoogte in voor het opsommingsteken.
12. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
13. Voeg de tweede alinea toe en herhaal het proces dat wordt beschreven in stap 7 tot 13.
14. Sla de presentatie op.

```java
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot eerste slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voegt een Autoshape toe en benadert deze
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Benadert het tekstframe van de autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Verwijdert de standaardalinea
    txtFrm.getParagraphs().removeAt(0);

    // Creëert een alinea
    Paragraph para = new Paragraph();

    // Stelt een opsommingstekenstijl en symbool voor de alinea in
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Stelt de alinea‑tekst in
    para.setText("Welcome to Aspose.Slides");

    // Stelt de insprong van het opsommingsteken in
    para.getParagraphFormat().setIndent(25);

    // Stelt de kleur van het opsommingsteken in
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // stel IsBulletHardColor in op true om een eigen opsommingsteken‑kleur te gebruiken

    // Stelt de hoogte van het opsommingsteken in
    para.getParagraphFormat().getBullet().setHeight(100);

    // Voegt de alinea toe aan het tekstframe
    txtFrm.getParagraphs().add(para);

    // Creëert een tweede alinea
    Paragraph para2 = new Paragraph();

    // Stelt het opsommingsteken‑type en -stijl van de alinea in
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Voegt alinea‑tekst toe
    para2.setText("This is numbered bullet");

    // Stelt de insprong van het opsommingsteken in
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // stel IsBulletHardColor in op true om een eigen opsommingsteken‑kleur te gebruiken

    // Stelt de hoogte van het opsommingsteken in
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Voegt de alinea toe aan het tekstframe
    txtFrm.getParagraphs().add(para2);
    
    // Slaat de aangepaste presentatie op
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Afbeeldings‑opsommingstekens beheren**

Opsommingstekens helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea’s met afbeeldingen zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Open de referentie van de betreffende slide via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de slide.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaardalinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie aan met de klasse [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/).
7. Laad de afbeelding in [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/).
8. Stel het opsommingsteken‑type in op [Picture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) en wijs de afbeelding toe.
9. Stel de alinea‑`Text` in.
10. Stel de alinea‑`Indent` in voor het opsommingsteken.
11. Stel een kleur in voor het opsommingsteken.
12. Stel een hoogte in voor het opsommingsteken.
13. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
14. Voeg de tweede alinea toe en herhaal het proces op basis van de eerdere stappen.
15. Sla de aangepaste presentatie op.

```java
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation presentation = new Presentation();
try {
    // Toegang tot eerste slide
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instantieert de afbeelding voor opsommingstekens
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Voegt een Autoshape toe en benadert deze
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Benadert het tekstframe van de autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Verwijdert de standaardalinea
    textFrame.getParagraphs().removeAt(0);

    // Creëert een nieuwe alinea
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Stelt de opsommingstekenstijl en afbeelding van de alinea in
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Stelt de hoogte van het opsommingsteken in
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Voegt de alinea toe aan het tekstframe
    textFrame.getParagraphs().add(paragraph);

    // Schrijft de presentatie weg als een PPTX-bestand
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Schrijft de presentatie weg als een PPT-bestand
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Meerlagige opsommingstekens beheren**

Opsommingstekens helpen u om informatie snel en efficiënt te organiseren en te presenteren. Meerlagige opsommingstekens zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Open de referentie van de betreffende slide via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe in de nieuwe slide.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaardalinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de klasse [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) en stel de diepte in op 0.
7. Maak de tweede alinea‑instantie via de klasse `Paragraph` en stel de diepte in op 1.
8. Maak de derde alinea‑instantie via de klasse `Paragraph` en stel de diepte in op 2.
9. Maak de vierde alinea‑instantie via de klasse `Paragraph` en stel de diepte in op 3.
10. Voeg de nieuwe alinea’s toe aan de alinea‑collectie van het `TextFrame`.
11. Sla de aangepaste presentatie op.

```java
// Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Benadert de eerste slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Voegt een Autoshape toe en benadert deze
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Benadert het tekstframe van de gemaakte autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Leegt de standaardalinea
    text.getParagraphs().clear();

    // Voegt de eerste alinea toe
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het opsommingsteken‑niveau in
    para1.getParagraphFormat().setDepth((short)0);

    // Voegt de tweede alinea toe
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het opsommingsteken‑niveau in
    para2.getParagraphFormat().setDepth((short)1);

    // Voegt de derde alinea toe
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het opsommingsteken‑niveau in
    para3.getParagraphFormat().setDepth((short)2);

    // Voegt de vierde alinea toe
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het opsommingsteken‑niveau in
    para4.getParagraphFormat().setDepth((short)3);

    // Voegt alinea’s toe aan de collectie
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Schrijft de presentatie weg als een PPTX‑bestand
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een alinea met een aangepaste genummerde lijst beheren**

De [IBulletFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/) interface biedt de eigenschap [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) en andere die u in staat stellen alinea’s met aangepaste nummering of opmaak te beheren.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Open de slide die de alinea bevat.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de slide.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaardalinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de klasse [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) in op 2.
7. Maak de tweede alinea‑instantie via de klasse `Paragraph` en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea‑instantie via de klasse `Paragraph` en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea’s toe aan de alinea‑collectie van het `TextFrame`.
10. Sla de aangepaste presentatie op.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Benadert het tekstframe van de gemaakte autoshape
    ITextFrame textFrame = shape.getTextFrame();

    // Verwijdert de standaard aanwezige alinea
    textFrame.getParagraphs().removeAt(0);

    // Eerste lijst
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Eerste‑regelinsprong voor een alinea instellen**

Gebruik de methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) om de eerste‑regelinsprong van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) wanneer u de gehele alinea wilt verplaatsen. Gebruik [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) wanneer u alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt meerdere alinea’s aan en past verschillende insprongwaarden toe om te laten zien hoe de eerste‑regelinsprong de lay-out van een alinea beïnvloedt.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Open de doel‑slide.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) toe aan de slide.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) toe aan de shape en verwijder de standaardalinea.
5. Maak meerdere alinea’s en stel verschillende [Indent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) waarden voor hen in.
6. Voeg de alinea’s toe aan het tekstframe.
7. Sla de aangepaste presentatie op.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![De eerste‑regelinsprong van de alinea’s](first_line_indent.png)

## **Hangende insprong voor een alinea instellen**

Een hangende insprong is een alinea‑lay-out waarbij de eerste regel links begint ten opzichte van de overige regels. In Aspose.Slides creëert u dit effect met de methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Stel de insprong in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk definieert [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de linkermarge van de alinea‑inhoud, en [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) bepaalt de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te creëren, stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, begrippenlijsten en andere alinea’s waarbij ingepakte regels onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Open de doel‑slide.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) toe aan de slide.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) toe aan de shape en verwijder de standaardalinea.
5. Maak alinea’s en stel een positieve [MarginLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) waarde in voor elke alinea.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) waarde in om het hangende‑insprongeffect te creëren.
7. Voeg de alinea’s toe aan het tekstframe.
8. Sla de aangepaste presentatie op.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![De hangende insprong van de alinea’s](hanging_indent.png)

## **Einde‑Alinea‑Run‑eigenschappen beheren**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Haal de referentie van de slide die de alinea bevat op via de positie.
3. Voeg een rechthoekige [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de slide.
4. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) met twee alinea’s toe aan de rechthoek.
5. Stel de `FontHeight` en het lettertype in voor de alinea’s.
6. Stel de End‑eigenschappen in voor de alinea’s.
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **HTML‑tekst importeren in alinea’s**

Aspose.Slides biedt uitgebreide ondersteuning voor het importeren van HTML‑tekst in alinea’s.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Open de referentie van de betreffende slide via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de slide.
4. Voeg de `autoshape` toe en open het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/).
5. Verwijder de standaardalinea in het `ITextFrame`.
6. Lees het bron‑HTML‑bestand in met een TextReader.
7. Maak de eerste alinea‑instantie via de klasse [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/).
8. Voeg de inhoud van het HTML‑bestand, gelezen met de TextReader, toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de aangepaste presentatie op.

```java
// Maak een lege presentatie‑instantie
Presentation pres = new Presentation();
try {
    // Toegang tot de standaard eerste slide van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Voegt de AutoShape toe om de HTML‑inhoud te huisvesten
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Voegt een tekstframe toe aan de shape
    ashape.addTextFrame("");

    // Leegt alle alinea’s in het toegevoegde tekstframe
    ashape.getTextFrame().getParagraphs().clear();

    // Laadt het HTML‑bestand met een stream‑reader
    TextReader tr = new StreamReader("file.html");

    // Voegt tekst uit de HTML‑stream‑reader toe aan het tekstframe
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Slaat de presentatie op
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt uitgebreide ondersteuning voor het exporteren van teksten (gehouden in alinea’s) naar HTML.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) en laad de gewenste presentatie.
2. Open de referentie van de betreffende slide via de index.
3. Open de shape die de te exporteren tekst bevat.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) van de shape.
5. Maak een instantie van `StreamWriter` en voeg het nieuwe HTML‑bestand toe.
6. Geef een start‑index door aan StreamWriter en exporteer de gewenste alinea’s.

```java
// Laad het presentatie‑bestand
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Toegang tot de standaard eerste slide van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Gewenste index
    int index = 0;

    // Benadert de toegevoegde shape
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Maak het uitvoer‑HTML‑bestand
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Eerste alinea extraheren als HTML
    // Schrijft alinea‑gegevens naar HTML door de start‑index van de alinea en het totaal aantal te kopiëren alinea’s op te geven
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een alinea opslaan als afbeelding**

In dit hoofdstuk bekijken we twee voorbeelden die laten zien hoe u een tekstalinea, weergegeven door de [IParagraph]-interface, als afbeelding kunt opslaan. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een shape die de alinea bevat met behulp van de `getImage`‑methoden van de [IShape]-interface, het berekenen van de grenzen van de alinea binnen de shape, en het exporteren ervan als bitmap‑afbeelding. Deze benaderingen stellen u in staat om specifieke delen van de tekst uit PowerPoint‑presentaties te extraheren en op te slaan als afzonderlijke afbeeldingen, wat nuttig kan zijn voor verder gebruik in diverse scenario’s.

Laten we aannemen dat we een presentatiedocument hebben genaamd sample.pptx met één slide, waarbij de eerste shape een tekstvak is dat drie alinea’s bevat.

![Het tekstvak met drie alinea’s](paragraph_to_image_input.png)

**Example 1**

In dit voorbeeld halen we de tweede alinea op als afbeelding. Daarna berekenen we de grenzen van de tweede alinea in het tekstframe van de shape, tekenen de alinea opnieuw op een nieuwe bitmap en slaan deze op in PNG‑formaat. Deze methode is vooral handig wanneer u een specifieke alinea apart wilt opslaan terwijl de exacte afmetingen en opmaak behouden blijven.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de shape op in het geheugen als een bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Maak een shape bitmap aan vanuit het geheugen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Bereken de grenzen van de tweede alinea.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Bereken de coördinaten en afmetingen voor de uitvoer‑afbeelding (minimumgrootte - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Snijd de shape bitmap bij om alleen de alinea bitmap te krijgen.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

![De alinea‑afbeelding](paragraph_to_image_output.png)

**Example 2**

In dit voorbeeld breiden we de vorige aanpak uit door een schaalsfactor van `2` toe te passen op de alinea‑afbeelding. De shape wordt geëxtraheerd uit de presentatie en opgeslagen als afbeelding met een schaalfactor van `2`, wat een hogere resolutie oplevert bij het exporteren van de alinea. De afmetingen van de alinea worden vervolgens berekend rekening houdend met de schaal. Schalen kan bijzonder nuttig zijn wanneer een meer gedetailleerde afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardig drukwerk.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de shape op in het geheugen als een bitmap met schaling.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Maak een shape‑bitmap aan vanuit het geheugen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Bereken de grenzen van de tweede alinea.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Bereken de coördinaten en grootte voor de uitvoer‑afbeelding (minimumgrootte - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Snijd de shape‑bitmap bij om alleen de alinea‑bitmap te krijgen.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Kan ik helemaal geen regelomslag binnen een tekstframe gebruiken?**

Ja. Gebruik de omslaginstelling van het tekstframe ([setWrapText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) om omslag uit te schakelen zodat regels niet afbreken aan de randen van het frame.

**Hoe kan ik de exacte grenzen van een specifieke alinea op de slide krijgen?**

U kunt de begrenzende rechthoek van de alinea (en zelfs van een enkel deel) opvragen om de exacte positie en grootte op de slide te kennen.

**Waar wordt de alinea‑uitlijning (links/rechts/centreren/uitvullen) geregeld?**

Alignment is een alinea‑niveau instelling in ParagraphFormat; deze wordt toegepast op de gehele alinea, ongeacht de opmaak van individuele delen.

**Kan ik een spellingscontrole‑taal instellen voor slechts een deel van een alinea (bijvoorbeeld één woord)?**

Ja. De taal wordt op het niveau van een deel ingesteld (PortionFormat.setLanguageId), waardoor meerdere talen kunnen coëxisteren binnen één alinea.