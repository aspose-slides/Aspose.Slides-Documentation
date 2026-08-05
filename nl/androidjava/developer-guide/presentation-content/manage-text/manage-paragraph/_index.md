---
title: Beheer PowerPoint-tekstparagrafen op Android
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
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
description: "Beheers de alinea-opmaak met Aspose.Slides voor Android—optimaliseer uitlijning, afstand en stijl in PPT-, PPTX- en ODP-presentaties in Java."
---
## **Introductie**

Aspose.Slides biedt alle interfaces en klassen die u nodig heeft om met PowerPoint‑teksten, alinea's en gedeelten in Java te werken.

* Aspose.Slides biedt de [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) interface waarmee u objecten kunt toevoegen die een alinea representeren. Een `ITextFame` object kan één of meerdere alinea's bevatten (elke alinea wordt aangemaakt via een carriage return).
* Aspose.Slides biedt de [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/) interface waarmee u objecten kunt toevoegen die gedeelten representeren. Een `IParagraph` object kan één of meerdere gedeelten bevatten (een collectie van iPortions‑objecten).
* Aspose.Slides biedt de [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/) interface waarmee u objecten kunt toevoegen die teksten en hun opmaak‑eigenschappen vertegenwoordigen.

Een `IParagraph` object kan teksten met verschillende opmaak‑eigenschappen verwerken via de onderliggende `IPortion` objecten.

## **Meerdere alinea's toevoegen met meerdere tekstgedeelten**

Deze stappen laten zien hoe u een tekstkader kunt toevoegen dat 3 alinea's bevat en waarbij elke alinea 3 gedeelten bevat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg de referentie naar de betreffende dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Haal het ITextFrame op dat bij de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) hoort.
5. Maak twee [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/) objecten aan en voeg ze toe aan de `IParagraphs` collectie van het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/).
6. Maak drie [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/) objecten aan voor elke nieuwe `IParagraph` (twee Portion‑objecten voor de standaard alinea) en voeg elk `IPortion` object toe aan de IPortion‑collectie van elke `IParagraph`.
7. Stel enige tekst in voor elk gedeelte.
8. Pas uw gewenste opmaakkenmerken toe op elk gedeelte met behulp van de opmaak‑eigenschappen die door het `IPortion` object worden blootgesteld.
9. Sla de aangepaste presentatie op.

```java
// Instantieer een Presentation-klasse die een PPTX-bestand voorstelt
Presentation pres = new Presentation();
try {
    // Toegang tot eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type Rectangle toe
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Toegang tot TextFrame van de AutoShape
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

    // PPTX naar schijf schrijven
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinea opsommingstekens beheren**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea's met opsommingstekens zijn altijd gemakkelijker te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg de referentie naar de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Verkrijg het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑aanmaak met behulp van de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/) klasse.
7. Stel het opsommingsteken `Type` van de alinea in op `Symbol` en bepaal het opsommingsteken.
8. Stel de alinea `Text` in.
9. Stel de alinea `Indent` in voor het opsommingsteken.
10. Stel een kleur in voor het opsommingsteken.
11. Stel een hoogte in voor het opsommingsteken.
12. Voeg de nieuwe alinea toe aan de `TextFrame` alinea‑collectie.
13. Voeg de tweede alinea toe en herhaal het proces beschreven in stap 7 tot 13.
14. Sla de presentatie op.

```java
// Instantieert een Presentation-klasse die een PPTX-bestand voorstelt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voeg een Autoshape toe en krijg deze toegang
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Toegang tot het tekstkader van de autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Verwijder de standaard alinea
    txtFrm.getParagraphs().removeAt(0);

    // Maak een alinea aan
    Paragraph para = new Paragraph();

    // Stel de opsommingsteken‑stijl en het symbool van de alinea in
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Stel de alinea‑tekst in
    para.setText("Welcome to Aspose.Slides");

    // Stel de inspringing van het opsommingsteken in
    para.getParagraphFormat().setIndent(25);

    // Stel de kleur van het opsommingsteken in
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // stel IsBulletHardColor in op true om eigen opsommingsteken kleur te gebruiken

    // Stel de hoogte van het opsommingsteken in
    para.getParagraphFormat().getBullet().setHeight(100);

    // Voeg de alinea toe aan het tekstkader
    txtFrm.getParagraphs().add(para);

    // Maak een tweede alinea aan
    Paragraph para2 = new Paragraph();

    // Stel het type en de stijl van het opsommingsteken van de alinea in
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Voeg de alinea‑tekst toe
    para2.setText("This is numbered bullet");

    // Stel de inspringing van het opsommingsteken in
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // stel IsBulletHardColor in op true om eigen opsommingsteken kleur te gebruiken

    // Stel de hoogte van het opsommingsteken in
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Voeg de alinea toe aan het tekstkader
    txtFrm.getParagraphs().add(para2);
    
    // Sla de aangepaste presentatie op
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Afbeeldingsopsommingstekens beheren**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea's met afbeeldingen zijn gemakkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg de referentie naar de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑aanmaak via de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/) klasse.
7. Laad de afbeelding in [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/).
8. Stel het opsommingstype in op [Picture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) en wijs de afbeelding toe.
9. Stel de `Text` van de alinea in.
10. Stel de `Indent` van de alinea in voor het opsommingsteken.
11. Stel een kleur in voor het opsommingsteken.
12. Stel een hoogte in voor het opsommingsteken.
13. Voeg de nieuwe alinea toe aan de `TextFrame` alinea‑collectie.
14. Voeg de tweede alinea toe en herhaal het proces volgens de voorgaande stappen.
15. Sla de aangepaste presentatie op.

```java
// Instantieert een Presentation-klasse die een PPTX-bestand voorstelt
Presentation presentation = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instantieert de afbeelding voor opsommingstekens
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Voeg een Autoshape toe en krijg deze toegang
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Toegang tot het tekstkader van de autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Verwijder de standaard alinea
    textFrame.getParagraphs().removeAt(0);

    // Maak een nieuwe alinea aan
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Stel de opsommingsteken‑stijl en afbeelding van de alinea in
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Stel de hoogte van het opsommingsteken in
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Voeg de alinea toe aan het tekstkader
    textFrame.getParagraphs().add(paragraph);

    // Sla de presentatie op als een PPTX‑bestand
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Sla de presentatie op als een PPT‑bestand
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Meerlagige opsommingstekens beheren**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Meerlagige opsommingstekens zijn gemakkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg de referentie naar de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe in de nieuwe dia.
4. Verkrijg het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑aanmaak via de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/) klasse en stel de diepte in op 0.
7. Maak de tweede alinea via de `Paragraph` klasse en stel de diepte in op 1.
8. Maak de derde alinea via de `Paragraph` klasse en stel de diepte in op 2.
9. Maak de vierde alinea via de `Paragraph` klasse en stel de diepte in op 3.
10. Voeg de nieuwe alinea's toe aan de `TextFrame` alinea‑collectie.
11. Sla de aangepaste presentatie op.

```java
// Instantieert een Presentation-klasse die een PPTX-bestand voorstelt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Voegt een Autoshape toe en krijgt toegang
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Toegang tot het tekstkader van de aangemaakte autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Verwijdert de standaard alinea
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

    // Voegt alinea's toe aan de collectie
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

De [IBulletFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/) interface biedt de [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) eigenschap en andere die u in staat stellen alinea's met aangepaste nummering of opmaak te beheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg de dia die de alinea bevat.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑aanmaak via de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/) klasse en stel [NumberedBulletStartWith] in op 2.
7. Maak de tweede alinea‑aanmaak via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea‑aanmaak via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea's toe aan de `TextFrame` alinea‑collectie.
10. Sla de aangepaste presentatie op.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Toegang tot het tekstkader van de aangemaakte autoshape
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

## **Eerste-regel inspringen voor een alinea instellen**

Gebruik de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) methode om de eerste‑regel inspringing van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de resterende regels uitgelijnd blijven met het alinea‑lichaam.

Gebruik [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) wanneer u de gehele alinea wilt verplaatsen. Gebruik [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) wanneer u alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt meerdere alinea's aan en past verschillende inspringwaarden toe om te demonstreren hoe de eerste‑regel inspringing de lay-out van de alinea beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/) toe aan de dia.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's aan en stel verschillende [Indent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) waarden voor hen in.
6. Voeg de alinea's toe aan het tekstkader.
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

Het resultaat:

![De eerste‑regel inspringing van de alinea's](first_line_indent.png)

## **Hangende inspringing voor een alinea instellen**

Een hangende inspringing is een alinea‑lay-out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëert u dit effect met de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) methode. Stel de inspringing in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van het alinea‑lichaam.

In de praktijk definieert [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de linkse positie van het alinea‑lichaam, en [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te maken, stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, glossee‑items en andere alinea's waarbij omschreven regels onder het alinea‑lichaam moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/) toe aan de dia.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak alinea's en stel een positieve [MarginLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) waarde voor elke alinea in.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) waarde in om het hangende‑inspringeffect te creëren.
7. Voeg de alinea's toe aan het tekstkader.
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

Het resultaat:

![De hangende inspringing van de alinea's](hanging_indent.png)

## **Eind‑alinea‑run‑eigenschappen beheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg de referentie naar de dia die de alinea bevat via de positie.
3. Voeg een rechthoekige [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) met twee alinea's toe aan de rechthoek.
5. Stel de `FontHeight` en het lettertype in voor de alinea's.
6. Stel de End‑eigenschappen in voor de alinea's.
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

## **HTML‑tekst importeren in alinea's**

Aspose.Slides biedt uitgebreide ondersteuning voor het importeren van HTML‑tekst in alinea's.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg de referentie naar de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Voeg een [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) toe aan de `autoshape` en krijg er toegang tot.
5. Verwijder de standaard alinea in het `ITextFrame`.
6. Lees het bron‑HTML‑bestand in met een TextReader.
7. Maak de eerste alinea‑aanmaak via de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/) klasse.
8. Voeg de HTML‑bestandinhoud uit de gelezen TextReader toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de aangepaste presentatie op.

```java
// Maak lege presentatiewinstantie
Presentation pres = new Presentation();
try {
    // Toegang tot de standaard eerste dia van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape toe om de HTML-inhoud te huisvesten
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Voeg een tekstkader toe aan de vorm
    ashape.addTextFrame("");

    // Verwijder alle alinea's in het toegevoegde tekstkader
    ashape.getTextFrame().getParagraphs().clear();

    // Laad het HTML-bestand met een StreamReader
    TextReader tr = new StreamReader("file.html");

    // Voeg tekst uit de HTML-streamreader toe aan het tekstkader
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Sla de presentatie op
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt uitgebreide ondersteuning voor het exporteren van teksten (gelegen in alinea's) naar HTML.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Verkrijg de referentie naar de betreffende dia via de index.
3. Verkrijg de vorm die de te exporteren tekst naar HTML bevat.
4. Verkrijg het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/) van de vorm.
5. Maak een instantie van `StreamWriter` aan en voeg het nieuwe HTML‑bestand toe.
6. Geef een start‑index aan de StreamWriter en exporteer de gewenste alinea's.

```java
    // Laad het presentatiebestand
    Presentation pres = new Presentation("ExportingHTMLText.pptx");
    try {
        // Toegang tot de standaard eerste dia van de presentatie
        ISlide slide = pres.getSlides().get_Item(0);

        // Gewenste index
        int index = 0;

        // Toegang tot de toegevoegde vorm
        IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

        // Maak uitvoer‑HTML‑bestand aan
        OutputStream os = new FileOutputStream("output.html");
        Writer writer = new OutputStreamWriter(os, "UTF-8");

        // Eerste alinea extraheren als HTML
        // Schrijft alinea‑data naar HTML door startindex en totaal aantal alinea's op te geven die gekopieerd moeten worden
        writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
        writer.close();
    } catch (IOException e) {
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **Een alinea opslaan als afbeelding**

In deze sectie verkennen we twee voorbeelden die laten zien hoe u een tekst‑alinea, vertegenwoordigd door de [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/) interface, als afbeelding kunt opslaan. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `getImage`‑methoden van de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) interface, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren ervan als bitmap‑afbeelding. Deze benaderingen stellen u in staat specifieke tekstdelen uit PowerPoint‑presentaties te extraheren en als afzonderlijke afbeeldingen op te slaan, wat nuttig kan zijn voor verder gebruik in diverse scenario's.

Laten we aannemen dat we een presentatie‑bestand hebben genaamd *sample.pptx* met één dia, waarbij de eerste vorm een tekstvak is dat drie alinea's bevat.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld verkrijgen we de tweede alinea als afbeelding. Hiervoor extraheren we de afbeelding van de vorm van de eerste dia van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstkader van de vorm. De alinea wordt vervolgens opnieuw getekend op een nieuw bitmap‑beeld, dat wordt opgeslagen in PNG‑formaat. Deze methode is bijzonder nuttig wanneer u een specifieke alinea als afzonderlijke afbeelding wilt opslaan terwijl de exacte afmetingen en opmaak van de tekst behouden blijven.

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
    RectF paragraphRectangle = secondParagraph.getRect();

    // Bereken de coördinaten en grootte voor de uitvoerafbeelding (minimum grootte - 1x1 pixel).
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

![De alinea afbeelding](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren toe te voegen aan de alinea‑afbeelding. De vorm wordt geëxtraheerd uit de presentatie en opgeslagen als afbeelding met een schaalfactor van `2`. Hierdoor ontstaat een hogere resolutie bij het exporteren van de alinea. De grenzen van de alinea worden vervolgens berekend rekening houdend met de schaal. Schalen kan bijzonder nuttig zijn wanneer een meer gedetailleerde afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardige gedrukte materialen.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sla de vorm in het geheugen op als een bitmap met schaal.
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

**Kan ik lijnomslag volledig uitschakelen binnen een tekstkader?**

Ja. Gebruik de instelling voor tekstomslag van het tekstkader ([setWrapText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) om omslag uit te schakelen zodat regels niet afbreken aan de randen van het kader.

**Hoe kan ik de exacte positie op de dia van een specifieke alinea verkrijgen?**

U kunt de begrenzende rechthoek van de alinea (en zelfs van een enkel gedeelte) ophalen om de precieze positie en grootte op de dia te kennen.

**Waar wordt de alinea‑uitlijning (links/rechts/midden/uitvullen) geregeld?**

[Alignment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) is een alinea‑niveau instelling in [ParagraphFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphformat/); deze wordt toegepast op de gehele alinea ongeacht individuele gedeelte‑opmaak.

**Kan ik een spellingscontrole‑taal instellen voor slechts een deel van een alinea (bijv. één woord)?**

Ja. De taal wordt op gedeelte‑niveau ingesteld ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), waardoor meerdere talen binnen één alinea kunnen bestaan.