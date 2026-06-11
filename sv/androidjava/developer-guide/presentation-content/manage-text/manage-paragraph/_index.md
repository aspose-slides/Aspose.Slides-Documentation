---
title: Hantera PowerPoint-textparagrafer på Android
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/androidjava/manage-paragraph/
keywords:
- lägga till text
- lägga till stycke
- hantera text
- hantera stycke
- hantera punkt
- styckeindrag
- hängande indrag
- styckepunkt
- numrerad lista
- punktlista
- styckeegenskaper
- importera HTML
- text till HTML
- stycke till HTML
- stycke till bild
- text till bild
- exportera stycke
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Behärska styckeformatering med Aspose.Slides för Android—optimera justering, avstånd och stil i PPT-, PPTX- och ODP-presentationer i Java."
---
## **Introduktion**

Aspose.Slides tillhandahåller alla gränssnitt och klasser du behöver för att arbeta med PowerPoint‑texter, stycken och portioner i Java.

* Aspose.Slides tillhandahåller gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) för att låta dig lägga till objekt som representerar ett stycke. Ett `ITextFame`‑objekt kan ha ett eller flera stycken (varje stycke skapas genom ett radbrytningstecken).
* Aspose.Slides tillhandahåller gränssnittet [IParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/) för att låta dig lägga till objekt som representerar portioner. Ett `IParagraph`‑objekt kan ha en eller flera portioner (samling av iPortions‑objekt).
* Aspose.Slides tillhandahåller gränssnittet [IPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/) för att låta dig lägga till objekt som representerar texter och deras formateringsegenskaper.

Ett `IParagraph`‑objekt kan hantera texter med olika formateringsegenskaper via sina underliggande `IPortion`‑objekt.

## **Lägg till flera stycken som innehåller flera textportioner**

Stegen visar hur du lägger till en textram som innehåller 3 stycken och varje stycke innehåller 3 portioner:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
4. Hämta ITextFrame som är associerad med [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/).
5. Skapa två [IParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/)‑objekt och lägg till dem i `IParagraphs`‑samlingen för [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
6. Skapa tre [IPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/)‑objekt för varje nytt `IParagraph` (två Portion‑objekt för standardstycket) och lägg till varje `IPortion`‑objekt i IPortion‑samlingen för respektive `IParagraph`.
7. Ange lite text för varje portion.
8. Tillämpa dina önskade formateringsfunktioner på varje portion med hjälp av formateringsegenskaperna som exponeras av `IPortion`‑objektet.
9. Spara den modifierade presentationen.

```java
// Instansiera en Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar första bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av rektangulär typ
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Hämta TextFrame för AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Skapa stycken och portioner med olika textformat
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

    // Spara PPTX till disk
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera paragrafpunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Listade stycken är alltid enklare att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på den valda bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första styckeinstansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/).
7. Ställ in punktens `Type` för stycket till `Symbol` och ange punkttecknet.
8. Ange styckets `Text`.
9. Ställ in styckets `Indent` för punkten.
10. Ange en färg för punkten.
11. Ange en höjd för punkten.
12. Lägg till det nya stycket i `TextFrame`‑styckessamlingen.
13. Lägg till det andra stycket och upprepa processen enligt steg 7 till 13.
14. Spara presentationen.

```java
// Instansierar en Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägger till och hämtar Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Hämtar autoshapens textram
    ITextFrame txtFrm = aShp.getTextFrame();

    // Tar bort standardstycket
    txtFrm.getParagraphs().removeAt(0);

    // Skapar ett stycke
    Paragraph para = new Paragraph();

    // Ställer in ett styckespunktsstil och -symbol
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Ställer in styckets text
    para.setText("Welcome to Aspose.Slides");

    // Ställer in punktindrag
    para.getParagraphFormat().setIndent(25);

    // Ställer in punktfärg
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // sätt IsBulletHardColor till true för att använda egen punktfärg

    // Ställer in punktens höjd
    para.getParagraphFormat().getBullet().setHeight(100);

    // Lägger till stycke i textramen
    txtFrm.getParagraphs().add(para);

    // Skapar andra stycket
    Paragraph para2 = new Paragraph();

    // Ställer in styckespunkttyp och -stil
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Lägger till stycke text
    para2.setText("This is numbered bullet");

    // Ställer in punktindrag
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // sätt IsBulletHardColor till true för att använda egen punktfärg

    // Ställer in punktens höjd
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Lägger till stycke i textramen
    txtFrm.getParagraphs().add(para2);
    
    // Sparar den modifierade presentationen
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera bildpunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Bildstycken är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första styckeinstansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/).
7. Läs in bilden i [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/).
8. Ställ in punkttypen till [Picture](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/) och ange bilden.
9. Ange styckets `Text`.
10. Ställ in styckets `Indent` för punkten.
11. Ange en färg för punkten.
12. Ange en höjd för punkten.
13. Lägg till det nya stycket i `TextFrame`‑styckessamlingen.
14. Lägg till det andra stycket och upprepa processen baserat på föregående steg.
15. Spara den modifierade presentationen.

```java
// Instansierar en Presentation-klass som representerar en PPTX-fil
Presentation presentation = new Presentation();
try {
    // Hämtar den första bilden
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instansierar bilden för punkter
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Lägger till och hämtar Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Hämtar autoshapens textram
    ITextFrame textFrame = autoShape.getTextFrame();

    // Tar bort standardstycket
    textFrame.getParagraphs().removeAt(0);

    // Skapar ett nytt stycke
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Ställer in styckespunktsstil och bild
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Ställer in punktens höjd
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Lägger till stycke i textramen
    textFrame.getParagraphs().add(paragraph);

    // Skriver presentationen som en PPTX-fil
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Skriver presentationen som en PPT-fil
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Hantera flernivåpunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Flernivåpunkter är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) i den nya bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första styckeinstansen via klassen [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/) och sätt djupet till 0.
7. Skapa den andra styckeinstansen via `Paragraph`‑klassen och sätt djupet till 1.
8. Skapa den tredje styckeinstansen via `Paragraph`‑klassen och sätt djupet till 2.
9. Skapa det fjärde stycket via `Paragraph`‑klassen och sätt djupet till 3.
10. Lägg till de nya styckena i `TextFrame`‑styckessamlingen.
11. Spara den modifierade presentationen.

```java
// Instansierar en Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till och hämtar Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Hämtar textramen för skapad autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Rensar standardstycket
    text.getParagraphs().clear();

    // Lägger till första stycket
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ställer in punktnivån
    para1.getParagraphFormat().setDepth((short)0);

    // Lägger till andra stycket
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ställer in punktnivån
    para2.getParagraphFormat().setDepth((short)1);

    // Lägger till tredje stycket
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ställer in punktnivån
    para3.getParagraphFormat().setDepth((short)2);

    // Lägger till fjärde stycket
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ställer in punktnivån
    para4.getParagraphFormat().setDepth((short)3);

    // Lägger till stycken i samlingen
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Skriver presentationen som en PPTX-fil
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera ett stycke med en anpassad numrerad lista**

Gränssnittet [IBulletFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/) tillhandahåller egenskapen [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) och andra som låter dig hantera stycken med anpassad numrering eller formatering.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta bilden som innehåller stycket.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första styckeinstansen via klassen [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/) och sätt [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) till 2.
7. Skapa det andra stycket via `Paragraph`‑klassen och sätt `NumberedBulletStartWith` till 3.
8. Skapa det tredje stycket via `Paragraph`‑klassen och sätt `NumberedBulletStartWith` till 7.
9. Lägg till de nya styckena i `TextFrame`‑styckessamlingen.
10. Spara den modifierade presentationen.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Hämtar textramen för den skapade autoshapen
    ITextFrame textFrame = shape.getTextFrame();

    // Tar bort standardstycket som finns
    textFrame.getParagraphs().removeAt(0);

    // Första listan
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

## **Ställ in första raden indrag för ett stycke**

Använd metoden [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) för att kontrollera första radens indrag i ett stycke. Metoden flyttar endast den första raden i förhållande till styckets vänstermarginal. Ett positivt värde flyttar den första raden åt höger, medan de återstående raderna förblir justerade med styckets huvudtext.

Använd [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) när du behöver flytta hela stycket. Använd [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) när du bara vill flytta den första raden.

Exemplet nedan skapar flera stycken och tillämpar olika indragsvärden för att demonstrera hur första radens indrag påverkar styckeformatet.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/) till formen och ta bort standardstycket.
5. Skapa flera stycken och ange olika [Indent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-)‑värden för dem.
6. Lägg till styckena i textramen.
7. Spara den modifierade presentationen.

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

Resultatet:

![Första radens indrag i styckena](first_line_indent.png)

## **Ställ in hängande indrag för ett stycke**

Ett hängande indrag är en styckeformat där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med metoden [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Sätt indraget till ett negativt värde för att flytta den första raden åt vänster i förhållande till styckets huvudtext.

I praktiken definierar [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) den vänstra positionen för styckets huvudtext, och [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) definierar positionen för den första raden i förhållande till den marginalen. För att skapa ett hängande indrag, ange ett positivt `MarginLeft`‑värde och ett negativt `Indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, uppslagsord, och andra stycken där radbrytna rader ska justeras under styckets huvudtext snarare än under det första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/) till formen och ta bort standardstycket.
5. Skapa stycken och ange ett positivt [MarginLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)‑värde för varje stycke.
6. Ange ett negativt [Indent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-)‑värde för att skapa hängande indrag.
7. Lägg till styckena i textramen.
8. Spara den modifierade presentationen.

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

Resultatet:

![Hängande indrag i styckena](hanging_indent.png)

## **Hantera slutrunegenskaper för stycke**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta referensen till bilden som innehåller stycket via dess position.
3. Lägg till en rektangulär [autoshape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
4. Lägg till ett [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) med två stycken till rektangeln.
5. Ställ in `FontHeight` och teckensnittstyp för styckena.
6. Ställ in slut‑egenskaperna för styckena.
7. Skriv den modifierade presentationen som en PPTX‑fil.

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

## **Importera HTML‑text till stycken**

Aspose.Slides erbjuder förbättrat stöd för att importera HTML‑text till stycken.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
4. Lägg till och hämta `autoshape`‑[ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
5. Ta bort standardstycket i `ITextFrame`.
6. Läs in käll‑HTML‑filen med en TextReader.
7. Skapa den första styckeinstansen via klassen [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/).
8. Lägg till HTML‑filens innehåll från den lästa TextReader‑objektet till TextFrames [ParagraphCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraphcollection/).
9. Spara den modifierade presentationen.

```java
// Skapa tom presentationsinstans
Presentation pres = new Presentation();
try {
    // Hämta standardförsta bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till AutoShape för att rymma HTML-innehållet
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Lägger till textram till formen
    ashape.addTextFrame("");

    // Rensar alla stycken i den tillagda textramen
    ashape.getTextFrame().getParagraphs().clear();

    // Laddar HTML-filen med stream reader
    TextReader tr = new StreamReader("file.html");

    // Lägger till text från HTML-stream reader i textramen
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Sparar presentationen
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exportera stycketext till HTML**

Aspose.Slides erbjuder förbättrat stöd för att exportera texter (innehållande i stycken) till HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och läs in den önskade presentationen.
2. Hämta referensen till den relevanta bilden via dess index.
3. Hämta formen som innehåller texten som ska exporteras till HTML.
4. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/).
5. Skapa en instans av `StreamWriter` och lägg till den nya HTML‑filen.
6. Ange ett startindex till StreamWriter och exportera dina önskade stycken.

```java
// Ladda presentationsfilen
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Hämtar standardförsta bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // Önskat index
    int index = 0;

    // Hämtar den tillagda formen
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Skapar utdata-HTML-fil
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extraherar första stycket som HTML
    // Skriver styckedata till HTML genom att ange startindex för stycke och totalt antal stycken som ska kopieras
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spara ett stycke som en bild**

I det här avsnittet ska vi gå igenom två exempel som visar hur man sparar ett textstycke, representerat av gränssnittet [IParagraph], som en bild. Båda exemplen inkluderar att erhålla bilden av en form som innehåller stycket med metoderna `getImage` från gränssnittet [IShape], beräkna styckets gränser inom formen och exportera det som en bitmap‑bild. Dessa metoder låter dig extrahera specifika delar av texten från PowerPoint‑presentationer och spara dem som separata bilder, vilket kan vara användbart i olika scenarier.

Låt oss anta att vi har en presentationsfil som heter sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

**Example 1**

I det här exemplet hämtar vi det andra stycket som en bild. För att göra detta extraherar vi bilden av formen från den första bilden i presentationen och beräknar sedan gränserna för det andra stycket i formens textram. Stycket ritas sedan om på en ny bitmap‑bild som sparas i PNG‑format. Denna metod är särskilt användbar när du behöver spara ett specifikt stycke som en separat bild samtidigt som du bevarar textens exakta dimensioner och formatering.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Spara formen i minnet som en bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Skapa en form-bitmap från minnet.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Beräkna gränserna för det andra stycket.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Beräkna koordinaterna och storleken för utdatareformen (minsta storlek - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Beskär form-bitmapen för att bara få stycke-bitmapen.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

![Styckets bild](paragraph_to_image_output.png)

**Example 2**

I det här exemplet utvidgar vi den föregående metoden genom att lägga till skalningsfaktorer till styckets bild. Formen extraheras från presentationen och sparas som en bild med en skalningsfaktor på `2`. Detta ger en högre upplösning vid export av stycket. Styckets gränser beräknas sedan med hänsyn till skalan. Skalning kan vara särskilt användbart när en mer detaljerad bild behövs, till exempel för användning i högkvalitativa trycksaker.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Spara formen i minnet som en bitmap med skalning.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Skapa en form-bitmap från minnet.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Beräkna gränserna för det andra stycket.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Beräkna koordinaterna och storleken för utdata-bilden (minsta storlek - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Beskär form-bitmapen för att bara få stycke-bitmapen.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Använd textramens inställning för radbrytning ([setWrapText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) för att stänga av radbrytning så att rader inte bryts vid ramens kanter.

**Hur kan jag få exakt på‑bildens gräns för ett specifikt stycke?**

Du kan hämta styckets (och även en enskild portions) avgränsningsrektangel för att veta dess exakta position och storlek på bilden.

**Var styrs styckejusteringen (vänster/höger/centrerad/justerad)?**

[Alignment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) är en inställning på styckennivå i [ParagraphFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraphformat/); den gäller hela stycket oavsett enskild portions formatering.

**Kan jag ange ett stavningsspråk för bara en del av ett stycke (t.ex. ett ord)?**

Ja. Språket sätts på portionsnivå ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), så flera språk kan samexistera inom ett och samma stycke.