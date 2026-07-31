---
title: Hantera PowerPoint‑textparagrafer i Java
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- lägg till text
- lägg till stycke
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
- Java
- Aspose.Slides
description: "Behärska formatering av stycken med Aspose.Slides för Java—optimera justering, avstånd och stil i PPT-, PPTX- och ODP-presentationer i Java."
---
## **Introduktion**

Aspose.Slides tillhandahåller alla de gränssnitt och klasser du behöver för att arbeta med PowerPoint‑texter, stycken och portioner i Java.

* Aspose.Slides tillhandahåller [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/)‑gränssnittet för att låta dig lägga till objekt som representerar ett stycke. Ett `ITextFame`‑objekt kan ha ett eller flera stycken (varje stycke skapas med ett radbrytningstecken).
* Aspose.Slides tillhandahåller [IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/)‑gränssnittet för att låta dig lägga till objekt som representerar portioner. Ett `IParagraph`‑objekt kan ha en eller flera portioner (en samling av iPortions‑objekt).
* Aspose.Slides tillhandahåller [IPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/)‑gränssnittet för att låta dig lägga till objekt som representerar texter och deras formateringsegenskaper. 

Ett `IParagraph`‑objekt kan hantera texter med olika formateringsegenskaper via sina underliggande `IPortion`‑objekt.

## **Lägg till flera paragrafer som innehåller flera portioner**

Dessa steg visar hur du lägger till en textram som innehåller 3 stycken och varje stycke innehåller 3 portioner:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
4. Hämta ITextFrame som är associerad med [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/).
5. Skapa två [IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/)‑objekt och lägg till dem i samlingen `IParagraphs` för [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/).
6. Skapa tre [IPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/)‑objekt för varje ny `IParagraph` (två Portion‑objekt för standardparagraf) och lägg till varje `IPortion`‑objekt i IPortion‑samlingen för varje `IParagraph`.
7. Ange lite text för varje portion.
8. Tillämpa dina föredragna formateringsfunktioner på varje portion med hjälp av de formateringsegenskaper som exponeras av `IPortion`‑objektet.
9. Spara den modifierade presentationen.

```java
// Instansiera en Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Åtkomst till den första bilden
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

    //Skriv PPTX till disk
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera styckepunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Stiliserade stycken är alltid lättare att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på den valda bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/). 
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första paragraf‑instansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/).
7. Ställ in bullet‑`Type` för paragrafen till `Symbol` och ange bullet‑tecknet.
8. Ange paragrafens `Text`.
9. Ställ in paragrafens `Indent` för bulleten.
10. Ange en färg för bulleten.
11. Ange bulletens höjd.
12. Lägg till den nya paragrafen i `TextFrame`‑paragrafssamlingen.
13. Lägg till den andra paragrafen och upprepa processen enligt steg 7 till 13.
14. Spara presentationen.

```java
// Skapar en Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Åtkomst till den första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägger till och får åtkomst till Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Åtkomst till autoshapens textram
    ITextFrame txtFrm = aShp.getTextFrame();

    // Tar bort standardstycket
    txtFrm.getParagraphs().removeAt(0);

    // Skapar ett stycke
    Paragraph para = new Paragraph();

    // Ställer in ett styckepunktformat och symbol
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

    // Lägger till stycke i textram
    txtFrm.getParagraphs().add(para);

    // Skapar andra stycket
    Paragraph para2 = new Paragraph();

    // Ställer in styckepunktens typ och stil
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Lägger till styckestext
    para2.setText("This is numbered bullet");

    // Ställer in punktindrag
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // sätt IsBulletHardColor till true för att använda egen punktfärg

    // Ställer in punktens höjd
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Lägger till stycke i textram
    txtFrm.getParagraphs().add(para2);
    
    // Sparar den modifierade presentationen
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera bildpunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Bildstycken är enkla att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/). 
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första paragraf‑instansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/).
7. Läs in bilden i [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/).
8. Ställ in bullet‑typen till [Picture](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/) och ange bilden.
9. Ange paragrafens `Text`.
10. Ställ in paragrafens `Indent` för bulleten.
11. Ange en färg för bulleten.
12. Ange bulletens höjd.
13. Lägg till den nya paragrafen i `TextFrame`‑paragrafssamlingen.
14. Lägg till den andra paragrafen och upprepa processen baserat på föregående steg.
15. Spara den modifierade presentationen.

```java
// Instansierar en Presentation-klass som representerar en PPTX-fil
Presentation presentation = new Presentation();
try {
    // Åtkomst till den första bilden
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instansierar bilden för punkter
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Lägger till och får åtkomst till Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Hämtar autoshapens textram
    ITextFrame textFrame = autoShape.getTextFrame();

    // Tar bort standardstycket
    textFrame.getParagraphs().removeAt(0);

    // Skapar ett nytt stycke
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Ställer in styckepunktens stil och bild
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Ställer in punktens höjd
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Lägger till stycket i textram
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

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Flernivåpunkter är enkla att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på den nya bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/). 
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första paragrafen via klassen [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/) och sätt djupet till 0.
7. Skapa den andra paragrafen via klassen `Paragraph` och sätt djupet till 1.
8. Skapa den tredje paragrafen via klassen `Paragraph` och sätt djupet till 2.
9. Skapa den fjärde paragrafen via klassen `Paragraph` och sätt djupet till 3.
10. Lägg till de nya paragraferna i `TextFrame`‑paragrafssamlingen.
11. Spara den modifierade presentationen.

```java
// Instansierar en Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Åtkomst till den första bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till och får åtkomst till Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Åtkomst till den skapade autoshapens textram
    ITextFrame text = aShp.addTextFrame("");

    // Rensar standardstycket
    text.getParagraphs().clear();

    // Lägger till det första stycket
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ställer in punktnivån
    para1.getParagraphFormat().setDepth((short)0);

    // Lägger till det andra stycket
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ställer in punktnivån
    para2.getParagraphFormat().setDepth((short)1);

    // Lägger till det tredje stycket
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ställer in punktnivån
    para3.getParagraphFormat().setDepth((short)2);

    // Lägger till det fjärde stycket
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

IBulletFormat‑gränssnittet tillhandahåller egenskapen [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) och andra som låter dig hantera paragrafer med anpassad numrering eller formatering. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta bilden som innehåller paragrafen.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första paragrafen via klassen [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/) och sätt [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) till 2.
7. Skapa den andra paragrafen via klassen `Paragraph` och sätt `NumberedBulletStartWith` till 3.
8. Skapa den tredje paragrafen via klassen `Paragraph` och sätt `NumberedBulletStartWith` till 7.
9. Lägg till de nya paragraferna i `TextFrame`‑paragrafssamlingen.
10. Spara den modifierade presentationen.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Åtkomst till den skapade autoshapens textram
    ITextFrame textFrame = shape.getTextFrame();

    // Tar bort det befintliga standardstycket
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

## **Ställ in första‑radsindrag för ett stycke**

Använd metoden [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-) för att kontrollera första‑radsindraget för ett stycke. Metoden flyttar endast den första raden relativt paragrafens vänstra marginal. Ett positivt värde skjuter den första raden åt höger, medan de återstående raderna förblir i linje med styckets kropp.

Använd [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) när du vill flytta hela paragrafen. Använd [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-) när du bara vill flytta den första raden.

Exemplet nedan skapar flera paragrafer och använder olika indragsvärden för att demonstrera hur första‑radsindraget påverkar layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta mål‑bilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/) till formen och ta bort standardstycket.
5. Skapa flera paragrafer och ange olika [Indent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑värden för dem.
6. Lägg till paragraferna i textramen.
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

![Första‑radsindraget för paragraferna](first_line_indent.png)

## **Ställ in hängande indrag för ett stycke**

Ett hängande indrag är en layout där den första raden startar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med metoden [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Sätt indraget till ett negativt värde för att flytta den första raden åt vänster relativt paragrafens kropp.

I praktiken definierar [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) den vänstra positionen för paragrafens kropp, och [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-) definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, sätt ett positivt `MarginLeft`‑värde och ett negativt `Indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, uppslagsord och andra stycken där radbrytningar ska justeras under paragrafens kropp snarare än under det första tecknet i första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta mål‑bilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/) till formen och ta bort standardstycket.
5. Skapa paragrafer och ange ett positivt [MarginLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)‑värde för varje paragraf.
6. Ange ett negativt [Indent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑värde för att skapa det hängande indraget.
7. Lägg till paragraferna i textramen.
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

![Det hängande indraget för paragraferna](hanging_indent.png)

## **Hantera slutliga körproperty för stycke**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassen.
2. Hämta referensen till bilden som innehåller stycket via dess position.
3. Lägg till en rektangulär [autoshape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
4. Lägg till en [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) med två stycken till rektangeln.
5. Ange `FontHeight` och typsnitt för styckena.
6. Ange End‑egenskaperna för styckena.
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

## **Importera HTML‑text i stycken**

Aspose.Slides ger förbättrat stöd för att importera HTML‑text i stycken.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
4. Lägg till och hämta `autoshape`‑[ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/).
5. Ta bort standardstycket i `ITextFrame`.
6. Läs in käll‑HTML‑filen med en TextReader.
7. Skapa den första paragraf‑instansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/).
8. Lägg till HTML‑filens innehåll från den lästa TextReader‑n till TextFrames [ParagraphCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraphcollection/).
9. Spara den modifierade presentationen.

```java
// Skapa en tom presentationsinstans
Presentation pres = new Presentation();
try {
    // Atkomst till presentationens standardforsta bild
    ISlide slide = pres.getSlides().get_Item(0);

    // Lagger till AutoShape for att rymma HTML-innehalllet
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Lagger till textram till formen
    ashape.addTextFrame("");

    // Rensar alla stycken i den tillagda textramen
    ashape.getTextFrame().getParagraphs().clear();

    // Laddar HTML-filen med stream-lasare
    TextReader tr = new StreamReader("file.html");

    // Lagger till text fran HTML-stream-lasaren i textramen
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Sparar presentationen
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exportera stycke‑text till HTML**

Aspose.Slides ger förbättrat stöd för att exportera texter (innehållna i stycken) till HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och läs in önskad presentation.
2. Hämta referensen till den relevanta bilden via dess index.
3. Hämta formen som innehåller texten som ska exporteras till HTML.
4. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/).
5. Skapa en instans av `StreamWriter` och lägg till den nya HTML‑filen.
6. Ange ett startindex till StreamWriter och exportera dina valda stycken.

```java
// Ladda presentationsfilen
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Åtkomst till presentationens standardförsta bild
    ISlide slide = pres.getSlides().get_Item(0);

    // Önskat index
    int index = 0;

    // Åtkomst till den tillagda formen
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Skapar utdata HTML-fil
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extraherar första stycket som HTML
    // Skriver stycke‑data till HTML genom att ange startindex för stycke, totala antal stycken som ska kopieras
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spara ett stycke som en bild**

I detta avsnitt utforskar vi två exempel som demonstrerar hur ett textstycke, representerat av [IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/)‑gränssnittet, kan sparas som en bild. Båda exemplen omfattar att hämta bilden av en form som innehåller stycket via `getImage`‑metoderna från [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/)‑gränssnittet, beräkna styckets gränser inom formen och exportera det som en bitmap‑bild. Dessa metoder möjliggör extrahering av specifika delar av texten från PowerPoint‑presentationer och sparande som separata bilder, vilket kan vara användbart i olika scenarier.

Låt oss anta att vi har en presentationsfil kallad sample.pptx med en bild, där den första formen är en textruta med tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

**Exempel 1**

I detta exempel hämtar vi det andra stycket som bild. För att göra detta extraherar vi bildens form från den första bilden i presentationen och beräknar sedan styckets gränser i formens textram. Stycket ritas därefter om på en ny bitmap‑bild som sparas i PNG‑format. Metoden är särskilt användbar när du behöver spara ett specifikt stycke som en separat bild samtidigt som du behåller exakt dimension och formatering.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Spara formen i minnet som en bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Skapa en bitmap av formen från minnet.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Beräkna gränserna för det andra stycket.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Beräkna koordinaterna och storleken för utdata bilden (minimistorlek - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Beskär formens bitmap för att endast få styckets bitmap.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Resultatet:

![Styckebilden](paragraph_to_image_output.png)

**Exempel 2**

I detta exempel utökar vi föregående tillvägagångssätt genom att lägga till skalningsfaktorer för styckebilden. Formen extraheras från presentationen och sparas som bild med en skalningsfaktor på `2`. Detta möjliggör högre upplösning vid export av stycket. Styckets gränser beräknas sedan med hänsyn till skalan. Skalning kan vara särskilt användbart när en mer detaljerad bild behövs, exempelvis för högkvalitativa trycksaker.

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

    // Skapa en bitmap av formen från minnet.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Beräkna gränserna för det andra stycket.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Beräkna koordinaterna och storleken för utdata bilden (minimistorlek - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Beskär formens bitmap för att endast få styckets bitmap.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Använd textramens omslagsinställning ([setWrapText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) för att stänga av omslag så att rader inte bryts vid ramens kanter.

**Hur kan jag få de exakta gränserna på bilden för ett specifikt stycke?**

Du kan hämta styckets (och även en enskild portions) omgivande rektangel för att känna till dess exakta position och storlek på bilden.

**Var styrs styckejustering (vänster/höger/centrerad/justerad)?**

Alignment är en inställning på paragrafnivå i ParagraphFormat; den gäller för hela paragrafen oavsett individuell portionsformatering.

**Kan jag ange språkkontroll för endast en del av ett stycke (t.ex. ett ord)?**

Ja. Språket anges på portionsnivå (PortionFormat.setLanguageId), så flera språk kan samexistera inom ett enda stycke.