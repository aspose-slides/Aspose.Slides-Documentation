---
title: Beheer PowerPoint-tekstalinea's in Java
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingstekens beheren
- alinea‑inspringing
- hangende inspringing
- alinea‑opsomming
- genummerde lijst
- opsomming
- alinea‑eigenschappen
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
description: "Beheer alinea‑opmaak met Aspose.Slides voor Java—optimaliseer uitlijning, afstand en stijl in PPT-, PPTX- en ODP‑presentaties in Java."
---
## **Introductie**

Aspose.Slides biedt alle interfaces en klassen die u nodig heeft om met PowerPoint-teksten, alinea's en gedeelten in Java te werken.

* Aspose.Slides biedt de [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) interface om objecten toe te voegen die een alinea vertegenwoordigen. Een `ITextFame` object kan één of meerdere alinea's bevatten (elke alinea wordt aangemaakt via een regeleinde).
* Aspose.Slides biedt de [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) interface om objecten toe te voegen die gedeelten vertegenwoordigen. Een `IParagraph` object kan één of meerdere gedeelten bevatten (een collectie van iPortions‑objecten).
* Aspose.Slides biedt de [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) interface om objecten toe te voegen die teksten en hun opmaak‑eigenschappen vertegenwoordigen. 

Een `IParagraph` object kan teksten met verschillende opmaak‑eigenschappen verwerken via de onderliggende `IPortion` objecten.

## **Meerdere alinea's toevoegen met meerdere gedeelten**

Deze stappen laten zien hoe u een tekstkader toevoegt met 3 alinea's en elke alinea met 3 gedeelten:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de gewenste dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Haal het ITextFrame op dat aan de [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) gekoppeld is.
5. Maak twee [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) objecten en voeg ze toe aan de `IParagraphs`‑collectie van het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/).
6. Maak drie [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) objecten voor elke nieuw aangemaakte `IParagraph` (twee Portion‑objecten voor de standaard alinea) en voeg elk `IPortion` object toe aan de IPortion‑collectie van de betreffende `IParagraph`.
7. Stel voor elk gedeelte wat tekst in.
8. Pas de gewenste opmaak‑eigenschappen toe op elk gedeelte via de eigenschappen van het `IPortion` object.
9. Sla de gewijzigde presentatie op.

Deze Java‑code implementeert de stappen voor het toevoegen van alinea's met gedeelten:

```java
// Instantieer een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Eerste dia openen
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type Rechthoek toe
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Open het TextFrame van de AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Maak alinea's en gedeelten met verschillende tekstopmaak
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

    //Schrijf PPTX naar schijf
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Beheren van alinea‑opsommingstekens**

Opsommingstekens helpen om informatie snel en efficiënt te organiseren en te presenteren. Alinea‑opsommingstekens zijn altijd makkelijker te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de autoshape. 
5. Verwijder de standaard alinea in de `TextFrame`.
6. Maak een eerste alinea‑instantie met de [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) klasse.
7. Stel het bullet‑`Type` van de alinea in op `Symbol` en geef het bullet‑teken op.
8. Stel de alinea‑`Text` in.
9. Stel de alinea‑`Indent` in voor de bullet.
10. Geef een kleur op voor de bullet.
11. Geef een hoogte op voor de bullet.
12. Voeg de nieuwe alinea toe aan de alinea‑collectie van de `TextFrame`.
13. Voeg de tweede alinea toe en herhaal de stappen 7‑12.
14. Sla de presentatie op.

Deze Java‑code laat zien hoe u een alinea‑bullet toevoegt:

```java
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Opent de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voegt Autoshape toe en opent deze
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Opent het tekstkader van de autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Verwijdert de standaard alinea
    txtFrm.getParagraphs().removeAt(0);

    // Maakt een alinea
    Paragraph para = new Paragraph();

    // Stelt de bullet-stijl en het symbool van de alinea in
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Stelt de alinea-tekst in
    para.setText("Welcome to Aspose.Slides");

    // Stelt de inspringing van de bullet in
    para.getParagraphFormat().setIndent(25);

    // Stelt de bullet-kleur in
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // stel IsBulletHardColor in op true om eigen bulletkleur te gebruiken

    // Stelt de bullet-hoogte in
    para.getParagraphFormat().getBullet().setHeight(100);

    // Voegt alinea toe aan tekstkader
    txtFrm.getParagraphs().add(para);

    // Maakt tweede alinea
    Paragraph para2 = new Paragraph();

    // Stelt het bullet-type en de stijl van de alinea in
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Voegt alinea-tekst toe
    para2.setText("This is numbered bullet");

    // Stelt de inspringing van de bullet in
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // stel IsBulletHardColor in op true om eigen bulletkleur te gebruiken

    // Stelt de bullet-hoogte in
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Voegt alinea toe aan tekstkader
    txtFrm.getParagraphs().add(para2);
    
    // Slaat de gewijzigde presentatie op
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Beheren van afbeelding‑opsommingstekens**

Opsommingstekens helpen om informatie snel en efficiënt te organiseren en te presenteren. Afbeeldings‑alinea’s zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de autoshape. 
5. Verwijder de standaard alinea in de `TextFrame`.
6. Maak een eerste alinea‑instantie met de [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) klasse.
7. Laad de afbeelding in [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/).
8. Stel het bullet‑type in op [Picture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) en wijs de afbeelding toe.
9. Stel de alinea‑`Text` in.
10. Stel de alinea‑`Indent` in voor de bullet.
11. Geef een kleur op voor de bullet.
12. Geef een hoogte op voor de bullet.
13. Voeg de nieuwe alinea toe aan de alinea‑collectie van de `TextFrame`.
14. Voeg de tweede alinea toe en herhaal de stappen.
15. Sla de gewijzigde presentatie op.

Deze Java‑code laat zien hoe u afbeelding‑bullets toevoegt en beheert:

```java
// Instancieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation presentation = new Presentation();
try {
    // Opent de eerste dia
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instancieert de afbeelding voor bullets
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Voegt een Autoshape toe en opent deze
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Opent het tekstkader van de autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Verwijdert de standaard alinea
    textFrame.getParagraphs().removeAt(0);

    // Maakt een nieuwe alinea
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Stelt de bullet-stijl en afbeelding van de alinea in
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Stelt de bullet-hoogte in
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Voegt alinea toe aan tekstkader
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

## **Beheren van meerlagige opsommingstekens**

Opsommingstekens helpen om informatie snel en efficiënt te organiseren en te presenteren. Meerlagige opsommingstekens zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe in de nieuwe dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de autoshape. 
5. Verwijder de standaard alinea in de `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) klasse en stel de diepte in op 0.
7. Maak de tweede alinea‑instantie via de `Paragraph` klasse en stel de diepte in op 1.
8. Maak de derde alinea‑instantie via de `Paragraph` klasse en stel de diepte in op 2.
9. Maak de vierde alinea‑instantie via de `Paragraph` klasse en stel de diepte in op 3.
10. Voeg de nieuwe alinea's toe aan de alinea‑collectie van de `TextFrame`.
11. Sla de gewijzigde presentatie op.

Deze Java‑code laat zien hoe u meerlagige opsommingstekens toevoegt en beheert:

```java
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Opent de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Voegt een Autoshape toe en opent deze
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Opent het tekstkader van de aangemaakte autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Leegt de standaard alinea
    text.getParagraphs().clear();

    // Voegt de eerste alinea toe
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het bulletniveau in
    para1.getParagraphFormat().setDepth((short)0);

    // Voegt de tweede alinea toe
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het bulletniveau in
    para2.getParagraphFormat().setDepth((short)1);

    // Voegt de derde alinea toe
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het bulletniveau in
    para3.getParagraphFormat().setDepth((short)2);

    // Voegt de vierde alinea toe
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Stelt het bulletniveau in
    para4.getParagraphFormat().setDepth((short)3);

    // Voegt alinea's toe aan de collectie
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

## **Een alinea beheren met een aangepaste genummerde lijst**

De [IBulletFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/) interface biedt de eigenschap [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) en andere die u toestaan alinea's met aangepaste nummering of opmaak te beheren. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de dia die de alinea bevat.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard alinea in de `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) klasse en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) in op 2.
7. Maak de tweede alinea‑instantie via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea‑instantie via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea's toe aan de alinea‑collectie van de `TextFrame`.
10. Sla de gewijzigde presentatie op.

Deze Java‑code laat zien hoe u alinea's met aangepaste nummering of opmaak beheert:

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

## **Eerste‑regelinspring voor een alinea instellen**

Gebruik de methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) om de eerste‑regelinspring van een alinea te bepalen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) wanneer u de volledige alinea wilt verplaatsen. Gebruik [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt verschillende alinea's en past verschillende inspring‑waarden toe om te laten zien hoe de eerste‑regelinspring de lay‑out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de doel­dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's en stel voor elk verschillende [Indent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) waarden in.
6. Voeg de alinea's toe aan het tekstkader.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een alinea‑inspring instelt:

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

![Eerste‑regelinspring van de alinea's](first_line_indent.png)

## **Hangende inspringing voor een alinea instellen**

Een hangende inspringing is een lay‑out waarbij de eerste regel links begint ten opzichte van de overige regels. In Aspose.Slides creëert u dit effect met de methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Stel de inspringing in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk definieert [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de linkermarge van de alinea‑inhoud, en [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te creëren, stelt u een positieve `MarginLeft` in en een negatieve `Indent`.

Deze opmaak is handig voor bibliografieën, referenties, begrippenlijsten en andere alinea's waarbij de omschreven regels onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de doel­dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak alinea's en stel voor elke alinea een positieve [MarginLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) waarde in.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) waarde in om het hangende‑inspring‑effect te creëren.
7. Voeg de alinea's toe aan het tekstkader.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een hangende inspringing voor een alinea instelt:

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

![Hangende inspringing van de alinea's](hanging_indent.png)

## **Eind‑alinea‑run‑eigenschappen beheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
1. Haal de referentie op van de dia die de alinea bevat via de positie.
1. Voeg een rechthoekige [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) met twee alinea's toe aan de rechthoek.
1. Stel de `FontHeight` en het lettertype in voor de alinea's.
1. Stel de End‑eigenschappen in voor de alinea's.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe u de End‑eigenschappen voor alinea's in PowerPoint instelt:

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

## **HTML‑tekst importeren in alinea's**

Aspose.Slides biedt uitgebreide ondersteuning voor het importeren van HTML‑tekst in alinea's.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Voeg een [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) toe aan de autoshape en open deze.
5. Verwijder de standaard alinea in de `ITextFrame`.
6. Lees het bron‑HTML‑bestand met een TextReader.
7. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) klasse.
8. Voeg de HTML‑inhoud uit de gelezen TextReader toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraphcollection/) van de TextFrame.
9. Sla de gewijzigde presentatie op.

Deze Java‑code implementeert de stappen voor het importeren van HTML‑teksten in alinea's:

```java
// Maak een lege presentatie‑instantie
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg de AutoShape toe om de HTML‑inhoud te huisvesten
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Voeg een tekstkader toe aan de vorm
    ashape.addTextFrame("");

    // Wis alle alinea's in het toegevoegde tekstkader
    ashape.getTextFrame().getParagraphs().clear();

    // Laad het HTML‑bestand met een stream‑reader
    TextReader tr = new StreamReader("file.html");

    // Voeg tekst van de HTML‑stream‑reader toe aan het tekstkader
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Sla de presentatie op
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt uitgebreide ondersteuning voor het exporteren van teksten (die zich in alinea's bevinden) naar HTML.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Open de gewenste dia via de index.
3. Open de vorm die de te exporteren tekst bevat.
4. Open de [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) van die vorm.
5. Maak een `StreamWriter` instantie aan en voeg het nieuwe HTML‑bestand toe.
6. Geef een start‑index op voor de StreamWriter en exporteer de gewenste alinea's.

Deze Java‑code laat zien hoe u PowerPoint‑alinea‑teksten exporteert naar HTML:

```java
// Laad het presentatie-bestand
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Toegang tot de standaard eerste dia van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Gewenste index
    int index = 0;

    // Open de toegevoegde vorm
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Maak het uitvoer-HTML-bestand
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Eerste alinea extraheren als HTML
    // Schrijf alinea-gegevens naar HTML door het start-index van de alinea op te geven, en het totale aantal alinea's dat gekopieerd moet worden
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een alinea opslaan als afbeelding**

In dit gedeelte bekijken we twee voorbeelden die laten zien hoe u een tekst‑alinea, vertegenwoordigd door de [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) interface, opslaat als een afbeelding. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `getImage`‑methoden van de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) interface, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren als een bitmap‑afbeelding. Deze benaderingen stellen u in staat om specifieke tekstgedeelten uit PowerPoint‑presentaties te extraheren en op te slaan als losse afbeeldingen, wat nuttig kan zijn voor verschillende scenario's.

Laten we aannemen dat we een presentatie‑bestand hebben genaamd **sample.pptx** met één dia, waarbij de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld halen we de tweede alinea op als afbeelding. Hiervoor extraheren we de afbeelding van de vorm van de eerste dia van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstkader van de vorm. De alinea wordt vervolgens opnieuw getekend op een nieuwe bitmap‑afbeelding, die wordt opgeslagen in PNG‑formaat. Deze methode is bijzonder handig wanneer u een specifieke alinea wilt opslaan als een aparte afbeelding met behoud van de exacte afmetingen en opmaak.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de vorm in het geheugen op als een bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Maak een bitmap van de vorm vanuit het geheugen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Bereken de grenzen van de tweede alinea.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Bereken de coördinaten en grootte voor de uitvoerafbeelding (minimumgrootte - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Snijd de vorm‑bitmap bij om alleen de alinea‑bitmap te krijgen.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Het resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren toe te passen op de alinea‑afbeelding. De vorm wordt geëxtraheerd uit de presentatie en opgeslagen als afbeelding met een schaalfactor van `2`. Hierdoor ontstaat een hogere resolutie bij het exporteren van de alinea. Vervolgens worden de alinea‑grenzen berekend rekening houdend met de schaal. Schalen is vooral nuttig wanneer een meer gedetailleerde afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardige drukwerken.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de vorm in het geheugen op als een bitmap met schaalvergroting.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Maak een bitmap van de vorm vanuit het geheugen.
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

    // Bereken de coördinaten en grootte voor de uitvoerafbeelding (minimumgrootte - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Snijd de vorm‑bitmap bij om alleen de alinea‑bitmap te verkrijgen.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Kan ik het regelterugloop in een tekstkader volledig uitschakelen?**

Ja. Gebruik de eigenschap voor tekstkader‑omloop ([setWrapText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) om de omloop uit te schakelen zodat regels niet afbreken aan de randen van het kader.

**Hoe krijg ik de exacte positie van een specifieke alinea op de dia?**

U kunt de omvattende rechthoek van de alinea (en zelfs van een enkel gedeelte) opvragen om de precieze positie en afmetingen op de dia te kennen.

**Waar wordt de alinea‑uitlijning (links/rechts/centraal/uitvullen) geregeld?**

[Alignment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraphformat/#setAlignment-int-) is een instelling op alinea‑niveau in [ParagraphFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraphformat/); deze wordt toegepast op de gehele alinea ongeacht de opmaak van individuele gedeelten.

**Kan ik een taal voor spellingcontrole instellen voor slechts een deel van een alinea (bijv. één woord)?**

Ja. De taal wordt ingesteld op gedeelte‑niveau ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), zodat meerdere talen binnen één alinea kunnen co‑existeren.