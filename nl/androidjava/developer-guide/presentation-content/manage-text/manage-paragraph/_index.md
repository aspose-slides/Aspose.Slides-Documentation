---
title: Beheer PowerPoint-tekstalinea's op Android
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/androidjava/manage-paragraph/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingstekens beheren
- alinea-insprong
- hangende insprong
- alinea-opsomming
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
- Android
- Java
- Aspose.Slides
description: "Beheer alinea-opmaak met Aspose.Slides voor Android - optimaliseer uitlijning, afstand en stijl in PPT, PPTX en ODP-presentaties in Java."
---
## **Inleiding**

Aspose.Slides biedt alle interfaces en klassen die u nodig hebt om met PowerPoint‑teksten, alinea’s en delen in Java te werken.

* Aspose.Slides levert de [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/)‑interface waarmee u objecten kunt toevoegen die een alinea vertegenwoordigen. Een `ITextFame`‑object kan één of meerdere alinea’s bevatten (elke alinea wordt aangemaakt via een nieuwe regel).
* Aspose.Slides levert de [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/)‑interface waarmee u objecten kunt toevoegen die delen vertegenwoordigen. Een `IParagraph`‑object kan één of meerdere delen hebben (een collectie van iPortions‑objecten).
* Aspose.Slides levert de [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/)‑interface waarmee u objecten kunt toevoegen die teksten en hun opmaak‑eigenschappen vertegenwoordigen.

Een `IParagraph`‑object kan teksten met verschillende opmaak‑eigenschappen verwerken via de onderliggende `IPortion`‑objecten.

## **Meerdere alinea’s toevoegen met meerdere tekstdelen**

Deze stappen laten zien hoe u een tekstkader met 3 alinea’s en elke alinea met 3 delen kunt toevoegen:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de referentie naar de gewenste dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Haal het ITextFrame op dat bij de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) hoort.
5. Maak twee [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/)‑objecten en voeg ze toe aan de `IParagraphs`‑collectie van het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/).
6. Maak drie [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/)‑objecten voor elke nieuwe `IParagraph` (twee Portion‑objecten voor de standaard‑alinea) en voeg elk `IPortion`‑object toe aan de IPortion‑collectie van de betreffende `IParagraph`.
7. Stel tekst in voor elk deel.
8. Pas de gewenste opmaak‑functies toe op elk deel via de opmaak‑eigenschappen van het `IPortion`‑object.
9. Sla de gewijzigde presentatie op.

Deze Java‑code implementeert de stappen voor het toevoegen van alinea’s met delen:

```java
// Instantieer een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // De eerste dia openen
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type Rechthoek toe
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Open het TextFrame van de AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Maak alinea's en delen met verschillende tekstformaten aan
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

    //Schrijf de PPTX naar schijf
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinea‑opsommingstekens beheren**

Opsommingstekens helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea’s met opsommingstekens zijn altijd makkelijker leesbaar en begrijpelijk.

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de referentie naar de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard‑alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie met de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/)‑klasse.
7. Stel het bullet‑`Type` van de alinea in op `Symbol` en stel het bullet‑teken in.
8. Stel de alinea‑`Text` in.
9. Stel de alinea‑`Indent` in voor de bullet.
10. Stel een kleur in voor de bullet.
11. Stel een hoogte in voor de bullet.
12. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
13. Voeg de tweede alinea toe en herhaal de stappen 7 tot en met 13.
14. Sla de presentatie op.

Deze Java‑code laat zien hoe u een alinea‑bullet toevoegt:

```java
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Verkrijgt de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voegt een AutoShape toe en opent deze
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Opent het tekstkader van de autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Verwijdert de standaardalinea
    txtFrm.getParagraphs().removeAt(0);

    // Maakt een alinea aan
    Paragraph para = new Paragraph();

    // Stelt een alinea-bullet-stijl en symbool in
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Stelt de alinea-tekst in
    para.setText("Welcome to Aspose.Slides");

    // Stelt de bullet-insprong in
    para.getParagraphFormat().setIndent(25);

    // Stelt de bullet-kleur in
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // stel IsBulletHardColor in op true om een eigen bullet-kleur te gebruiken

    // Stelt de bullet-hoogte in
    para.getParagraphFormat().getBullet().setHeight(100);

    // Voegt de alinea toe aan het tekstkader
    txtFrm.getParagraphs().add(para);

    // Maakt een tweede alinea aan
    Paragraph para2 = new Paragraph();

    // Stelt het bullet-type en de stijl van de alinea in
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Voegt alinea-tekst toe
    para2.setText("This is numbered bullet");

    // Stelt de bullet-insprong in
    para2.getParagraphFormat().setIndent(25);

    // Stelt de bullet-kleur in
    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // stel IsBulletHardColor in op true om een eigen bullet-kleur te gebruiken

    // Stelt de bullet-hoogte in
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Voegt de alinea toe aan het tekstkader
    txtFrm.getParagraphs().add(para2);
    
    // Slaat de gewijzigde presentatie op
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Afbeeldings‑bullets beheren**

Opsommingstekens helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea’s met afbeeldingen zijn makkelijk leesbaar en begrijpelijk.

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de referentie naar de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard‑alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie met de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/)‑klasse.
7. Laad de afbeelding in [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/).
8. Stel het bullet‑type in op [Picture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) en wijs de afbeelding toe.
9. Stel de alinea‑`Text` in.
10. Stel de alinea‑`Indent` in voor de bullet.
11. Stel een kleur in voor de bullet.
12. Stel een hoogte in voor de bullet.
13. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
14. Voeg de tweede alinea toe en herhaal het proces volgens de eerdere stappen.
15. Sla de gewijzigde presentatie op.

Deze Java‑code laat zien hoe u afbeelding‑bullets toevoegt en beheert:

```java
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation presentation = new Presentation();
try {
    // Verkrijgt de eerste dia
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instantieert de afbeelding voor bullets
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Voegt een AutoShape toe en opent deze
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Opent het tekstkader van de autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Verwijdert de standaardalinea
    textFrame.getParagraphs().removeAt(0);

    // Maakt een nieuwe alinea aan
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Stelt de bullet-stijl en afbeelding van de alinea in
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Stelt de bullet-hoogte in
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Voegt de alinea toe aan het tekstkader
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

## **Meerlagige bullets beheren**

Opsommingstekens helpen u om informatie snel en efficiënt te organiseren en te presenteren. Meerlagige bullets zijn makkelijk leesbaar en begrijpelijk.

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de referentie naar de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de nieuwe dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard‑alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/)‑klasse en stel de diepte in op 0.
7. Maak de tweede alinea‑instantie via de `Paragraph`‑klasse en stel de diepte in op 1.
8. Maak de derde alinea‑instantie via de `Paragraph`‑klasse en stel de diepte in op 2.
9. Maak de vierde alinea‑instantie via de `Paragraph`‑klasse en stel de diepte in op 3.
10. Voeg de nieuwe alinea’s toe aan de alinea‑collectie van het `TextFrame`.
11. Sla de gewijzigde presentatie op.

Deze Java‑code laat zien hoe u meerlagige bullets toevoegt en beheert:

```java
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Verkrijgt de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Voegt een AutoShape toe en opent deze
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Opent het tekstkader van de aangemaakte autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Verwijdert de standaardalinea
    text.getParagraphs().clear();

    // Voegt de eerste alinea toe
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het bullet-niveau in
    para1.getParagraphFormat().setDepth((short)0);

    // Voegt de tweede alinea toe
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het bullet-niveau in
    para2.getParagraphFormat().setDepth((short)1);

    // Voegt de derde alinea toe
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het bullet-niveau in
    para3.getParagraphFormat().setDepth((short)2);

    // Voegt de vierde alinea toe
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het bullet-niveau in
    para4.getParagraphFormat().setDepth((short)3);

    // Voegt de alinea's toe aan de collectie
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Schrijft de presentatie weg als een PPTX-bestand
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinea met een aangepaste genummerde lijst beheren**

De [IBulletFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/)‑interface biedt de eigenschap [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) en andere die u in staat stellen alinea’s met aangepaste nummering of opmaak te beheren.

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de dia die de alinea bevat.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard‑alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/)‑klasse en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) in op 2.
7. Maak de tweede alinea‑instantie via de `Paragraph`‑klasse en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea‑instantie via de `Paragraph`‑klasse en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea’s toe aan de alinea‑collectie van het `TextFrame`.
10. Sla de gewijzigde presentatie op.

Deze Java‑code laat zien hoe u alinea’s met aangepaste nummering of opmaak toevoegt en beheert:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Opent het tekstkader van de aangemaakte autoshape
    ITextFrame textFrame = shape.getTextFrame();

    // Verwijdert de standaard bestaande alinea
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

## **Eerste‑lijninsprong voor een alinea instellen**

Gebruik de methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) om de eerste‑lijninsprong van een alinea te regelen. Deze methode verschuift alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verplaatst de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) wanneer u de hele alinea wilt verschuiven. Gebruik [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt diverse alinea’s aan en past verschillende insprongwaarden toe om te laten zien hoe de eerste‑lijninsprong de lay‑out beïnvloedt.

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/) toe aan de vorm en verwijder de standaard‑alinea.
5. Maak meerdere alinea’s en stel verschillende [Indent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-)‑waarden in.
6. Voeg de alinea’s toe aan het tekstkader.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een alinea‑insprong instelt:

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

Het resultaat:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Hangende insprong voor een alinea instellen**

Een hangende insprong is een alinea‑lay‑out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëert u dit effect met de methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Stel de insprong in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk bepaalt [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de linkermarge van de alinea‑inhoud, en [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te creëren, stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is bruikbaar voor bibliografieën, referenties, glossarium‑items en andere alinea’s waarbij de ingesprongen regels onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/) toe aan de vorm en verwijder de standaard‑alinea.
5. Maak alinea’s en stel een positieve [MarginLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)‑waarde in voor elke alinea.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-)‑waarde in om het hangende‑insprong‑effect te verkrijgen.
7. Voeg de alinea’s toe aan het tekstkader.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een hangende insprong voor een alinea instelt:

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

Het resultaat:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Eind‑alinea‑run‑eigenschappen beheren**

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal de referentie op voor de dia die de alinea bevat via de positie.
1. Voeg een rechthoekige [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) met twee alinea’s toe aan de rechthoek.
1. Stel de `FontHeight` en het lettertype in voor de alinea’s.
1. Stel de End‑eigenschappen in voor de alinea’s.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe u de End‑eigenschappen voor alinea’s in PowerPoint instelt:

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

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de referentie naar de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Voeg een `autoshape`‑[ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) toe en open deze.
5. Verwijder de standaard‑alinea in het `ITextFrame`.
6. Lees het bron‑HTML‑bestand in met een TextReader.
7. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/)‑klasse.
8. Voeg de HTML‑inhoud uit de gelezen TextReader toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de gewijzigde presentatie op.

Deze Java‑code implementeert de stappen voor het importeren van HTML‑teksten in alinea’s:

```java
// Maak een lege presentatie‑instantie
Presentation pres = new Presentation();
try {
    // Open de standaard eerste dia van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg de AutoShape toe om de HTML-inhoud te huisvesten
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Voeg een tekstkader toe aan de vorm
    ashape.addTextFrame("");

    // Wis alle alinea's in het toegevoegde tekstkader
    ashape.getTextFrame().getParagraphs().clear();

    // Laad het HTML-bestand met een streamlezer
    TextReader tr = new StreamReader("file.html");

    // Voeg tekst uit de HTML-streamlezer toe aan het tekstkader
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Sla de presentatie op
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt uitgebreide ondersteuning voor het exporteren van teksten (geplaatst in alinea’s) naar HTML.

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse en laad de gewenste presentatie.
2. Open de referentie naar de gewenste dia via de index.
3. Open de vorm die de te exporteren tekst bevat.
4. Open de vorm‑[TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/).
5. Maak een instantie van `StreamWriter` en voeg het nieuwe HTML‑bestand toe.
6. Geef een start‑index door aan StreamWriter en exporteer de gewenste alinea’s.

Deze Java‑code laat zien hoe u PowerPoint‑alinea‑teksten exporteert naar HTML:

```java
// Laad het presentatiebestand
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Open de standaard eerste dia van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Gewenste index
    int index = 0;

    // Open de toegevoegde vorm
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Maak een uitvoer-HTML-bestand
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Exporteer de eerste alinea als HTML
    // Schrijf de alinea-data naar HTML door de startindex van de alinea en het totale aantal alinea's die gekopieerd moeten worden op te geven
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een alinea opslaan als afbeelding**

In dit gedeelte bespreken we twee voorbeelden die laten zien hoe u een tekst‑alinea, vertegenwoordigd door de [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/)‑interface, als afbeelding kunt opslaan. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `getImage`‑methoden van de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/)‑interface, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren als een bitmap‑afbeelding. Deze benaderingen stellen u in staat specifieke tekstonderdelen uit PowerPoint‑presentaties te extraheren en als losse afbeeldingen op te slaan, wat nuttig kan zijn voor verdere toepassingen in diverse scenario’s.

Stel, we hebben een presentatiebestand genaamd *sample.pptx* met één dia, waarbij de eerste vorm een tekstvak bevat met drie alinea’s.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld halen we de tweede alinea op als afbeelding. Hiervoor extraheren we de afbeelding van de vorm uit de eerste dia van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstkader van de vorm. De alinea wordt daarna opnieuw getekend op een nieuw bitmap‑beeld, dat in PNG‑formaat wordt opgeslagen. Deze methode is vooral bruikbaar wanneer u een specifieke alinea apart wilt opslaan terwijl de exacte afmetingen en opmaak behouden blijven.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de vorm in geheugen op als bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Maak een bitmap van de vorm vanuit het geheugen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Bereken de grenzen van de tweede alinea.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Bereken de coördinaten en afmetingen voor de uitvoerafbeelding (minimumgrootte - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Snijd de bitmap van de vorm bij om alleen de bitmap van de alinea te krijgen.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Het resultaat:

![The paragraph image](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren toe te passen op de alinea‑afbeelding. De vorm wordt uit de presentatie gehaald en opgeslagen als afbeelding met een schaalfactor van `2`. Hierdoor ontstaat een afbeelding met hogere resolutie bij het exporteren van de alinea. De alinea‑grenzen worden vervolgens opnieuw berekend met inachtneming van de schaal. Schalen is bijzonder nuttig wanneer een meer gedetailleerde afbeelding benodigd is, bijvoorbeeld voor gebruik in hoogwaardige drukmaterialen.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de vorm in geheugen op als bitmap met schaal.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Maak een bitmap van de vorm vanuit het geheugen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Bereken de grenzen van de tweede alinea.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Bereken de coördinaten en afmetingen voor de uitvoerafbeelding (minimumgrootte - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Snijd de bitmap van de vorm bij om alleen de bitmap van de alinea te krijgen.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Kan ik het automatisch afbreken van regels binnen een tekstkader volledig uitschakelen?**

Ja. Gebruik de instelling voor regelafbreking van het tekstkader ([setWrapText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) om afbreken uit te schakelen zodat regels niet bij de randen van het kader worden afgebroken.

**Hoe krijg ik de exacte positie van een specifieke alinea op de dia?**

U kunt de begrenzingsrechthoek van de alinea (en zelfs van een enkel deel) ophalen om de precieze positie en grootte op de dia te kennen.

**Waar wordt de uitlijning van alinea’s (links/rechts/centraal/uitvullen) geregeld?**

[Alignment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) is een instelling op alinea‑niveau in [ParagraphFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphformat/); deze wordt toegepast op de hele alinea, ongeacht de opmaak van individuele delen.

**Kan ik een spellingscontrole‑taal instellen voor slechts een deel van een alinea (bijvoorbeeld één woord)?**

Ja. De taal wordt ingesteld op deelniveau ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), waardoor meerdere talen binnen één alinea kunnen co‑existentie.