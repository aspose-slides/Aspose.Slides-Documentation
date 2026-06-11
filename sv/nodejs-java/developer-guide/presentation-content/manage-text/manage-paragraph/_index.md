---
title: Hantera PowerPoint-textstycken i JavaScript
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/nodejs-java/manage-paragraph/
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
- punkterad lista
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska styckeformatering med Aspose.Slides för Node.js via Java—optimera justering, avstånd och stil i PPT-, PPTX- och ODP-presentationer i JavaScript."
---
## **Introduktion**

Aspose.Slides tillhandahåller alla klasser du behöver för att arbeta med PowerPoint‑texter, stycken och delar i Java.

* Aspose.Slides tillhandahåller klassen [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) för att låta dig lägga till objekt som representerar ett stycke. Ett `TextFame`‑objekt kan ha ett eller flera stycken (vart stycke skapas genom ett radbrytningstecken).
* Aspose.Slides tillhandahåller klassen [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) för att låta dig lägga till objekt som representerar delar. Ett `Paragraph`‑objekt kan ha en eller flera delar (samling av textdel‑objekt).
* Aspose.Slides tillhandahåller klassen [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/) för att låta dig lägga till objekt som representerar texter och deras formateringsegenskaper.

Ett `Paragraph`‑objekt kan hantera texter med olika formateringsegenskaper genom sina underliggande `Portion`‑objekt.

## **Lägg till flera stycken som innehåller flera delar**

Dessa steg visar hur du lägger till en textruta som innehåller 3 stycken och varje stycke innehåller 3 delar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
4. Hämta ITextFrame som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/).
5. Skapa två [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/)‑objekt och lägg till dem i `IParagraphs`‑samlingen för [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
6. Skapa tre [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/)‑objekt för varje nytt `Paragraph` (två Portion‑objekt för standard‑Paragraph) och lägg till varje `Portion`‑objekt i IPortion‑samlingen för varje `Paragraph`.
7. Ange lite text för varje del.
8. Applicera dina föredragna formateringsfunktioner på varje del med hjälp av de formateringsegenskaper som exponeras av `Portion`‑objektet.
9. Spara den modifierade presentationen.

Denna Javascript‑kod är en implementation av stegen för att lägga till stycken som innehåller delar:

```javascript
// Instansiera en Presentation-klass som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar första bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape av rektangeltyp
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Hämta TextFrame för AutoShape
    var tf = ashp.getTextFrame();
    // Create Paragraphs and Portions with different text formats
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
    // Spara PPTX till disk
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hantera styckebullets**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Punktlistade stycken är alltid lättare att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på den valda bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första styckeinstansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/).
7. Ställ in bullet‑`Type` för stycket till `Symbol` och ange bullet‑tecknet.
8. Ange styckets `Text`.
9. Ställ in styckets `Indent` för bullet.
10. Ange en färg för bullet.
11. Ange en höjd för bullet.
12. Lägg till det nya stycket i `TextFrame`‑styckesamlingen.
13. Lägg till det andra stycket och upprepa processen som beskrivs i steg 7 till 13.
14. Spara presentationen.

Denna Javascript‑kod visar hur du lägger till ett stycke‑bullet:

```javascript
    // Instansierar en Presentation-klass som representerar en PPTX-fil
    var pres = new aspose.slides.Presentation();
    try {
        // Hämtar den första bilden
        var slide = pres.getSlides().get_Item(0);
        // Lägger till och hämtar Autoshape
        var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // Hämtar autoshapens textruta
        var txtFrm = aShp.getTextFrame();
        // Tar bort standardstycket
        txtFrm.getParagraphs().removeAt(0);
        // Skapar ett stycke
        var para = new aspose.slides.Paragraph();
        // Ställer in ett styckebulletsstil och symbol
        para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para.getParagraphFormat().getBullet().setChar(8226);
        // Ställer in styckets text
        para.setText("Welcome to Aspose.Slides");
        // Ställer in bullet-indrag
        para.getParagraphFormat().setIndent(25);
        // Ställer in bullet-färg
        para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // set IsBulletHardColor till true för att använda egen bullet-färg
        // Ställer in bullet-höjd
        para.getParagraphFormat().getBullet().setHeight(100);
        // Lägger till stycke i textrutan
        txtFrm.getParagraphs().add(para);
        // Skapar andra stycket
        var para2 = new aspose.slides.Paragraph();
        // Ställer in styckebullettyp och stil
        para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
        para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
        // Lägger till styckestext
        para2.setText("This is numbered bullet");
        // Ställer in bullet-indrag
        para2.getParagraphFormat().setIndent(25);
        para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // set IsBulletHardColor till true för att använda egen bullet-färg
        // Ställer in bullet-höjd
        para2.getParagraphFormat().getBullet().setHeight(100);
        // Lägger till stycke i textrutan
        txtFrm.getParagraphs().add(para2);
        // Sparar den modifierade presentationen
        pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Hantera bildpunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Bildstycken är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första styckeinstansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/).
7. Läs in bilden i [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/).
8. Ställ in bullet‑typen till [Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) och ange bilden.
9. Ange stycke‑`Text`.
10. Ställ in stycke‑`Indent` för bullet.
11. Ange en färg för bullet.
12. Ange en höjd för bullet.
13. Lägg till det nya stycket i `TextFrame`‑styckesamlingen.
14. Lägg till det andra stycket och upprepa processen baserat på de föregående stegen.
15. Spara den modifierade presentationen.

Denna Javascript‑kod visar hur du lägger till och hanterar bildbullets:

```javascript
// Instansierar en Presentation-klass som representerar en PPTX-fil
var presentation = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var slide = presentation.getSlides().get_Item(0);
    // Instansierar bilden för punktlistor
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Lägger till och hämtar Autoshape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Hämtar autoshapens textruta
    var textFrame = autoShape.getTextFrame();
    // Tar bort standardstycket
    textFrame.getParagraphs().removeAt(0);
    // Skapar ett nytt stycke
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Ställer in styckebulletstil och bild
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Ställer in bulletens höjd
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Lägger till stycke i textrutan
    textFrame.getParagraphs().add(paragraph);
    // Skriver presentationen som en PPTX-fil
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Skriver presentationen som en PPT-fil
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Hantera flernivå‑bullets**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Flernivåbullets är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) i den nya bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första styckeinstansen via klassen [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) och sätt djupet till 0.
7. Skapa den andra styckeinstansen via `Paragraph`‑klassen och sätt djupet till 1.
8. Skapa den tredje styckeinstansen via `Paragraph`‑klassen och sätt djupet till 2.
9. Skapa det fjärde stycket via `Paragraph`‑klassen och sätt djupet till 3.
10. Lägg till de nya styckena i `TextFrame`‑styckesamlingen.
11. Spara den modifierade presentationen.

Denna Javascript‑kod visar hur du lägger till och hanterar flernivå‑bullets:

```javascript
// Instansierar en Presentation-klass som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägger till och hämtar Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Hämtar textrutan för den skapade autoshapen
    var text = aShp.addTextFrame("");
    // Rensar standardstycket
    text.getParagraphs().clear();
    // Lägger till det första stycket
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ställer in bullet-nivån
    para1.getParagraphFormat().setDepth(0);
    // Lägger till det andra stycket
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ställer in bullet-nivån
    para2.getParagraphFormat().setDepth(1);
    // Lägger till det tredje stycket
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ställer in bullet-nivån
    para3.getParagraphFormat().setDepth(2);
    // Lägger till det fjärde stycket
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ställer in bullet-nivån
    para4.getParagraphFormat().setDepth(3);
    // Lägger till stycken i samlingen
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Skriver presentationen som en PPTX-fil
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hantera stycke med anpassad numrerad lista**

Klassen [BulletFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bulletformat/) tillhandahåller egenskapen [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) och andra som låter dig hantera stycken med anpassad numrering eller formatering.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta bilden som innehåller stycket.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första styckeinstansen via klassen [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) och sätt [NumberedBulletStartWith] till 2.
7. Skapa den andra styckeinstansen via `Paragraph`‑klassen och sätt `NumberedBulletStartWith` till 3.
8. Skapa den tredje styckeinstansen via `Paragraph`‑klassen och sätt `NumberedBulletStartWith` till 7.
9. Lägg till de nya styckena i `TextFrame`‑styckesamlingen.
10. Spara den modifierade presentationen.

Denna Javascript‑kod visar hur du lägger till och hanterar stycken med anpassad numrering eller formatering:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Hämtar textramen för den skapade autoshapen
    var textFrame = shape.getTextFrame();
    // Tar bort standardstycket som finns
    textFrame.getParagraphs().removeAt(0);
    // Första listan
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

## **Ställ in första radens indrag för ett stycke**

Använd metoden [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setindent/) för att kontrollera indraget för första raden i ett stycke. Denna metod förflyttar endast den första raden relativt till styckets vänstra marginal. Ett positivt värde flyttar första raden åt höger, medan de återstående raderna förblir inriktade mot styckets kropp.

Använd [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) när du behöver flytta hela stycket. Använd [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setindent/) när du bara behöver flytta den första raden.

Exemplet nedan skapar flera stycken och applicerar olika indragsvärden för att demonstrera hur första radens indrag påverkar stycke layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta mål‑bilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) till formen och ta bort standardstycket.
5. Skapa flera stycken och ange olika [Indent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setindent/)‑värden för dem.
6. Lägg till styckena i textrutan.
7. Spara den modifierade presentationen.

Denna kod visar hur du ställer in ett styckeindrag:

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

Resultatet:

![Första radens indrag av styckena](first_line_indent.png)

## **Ställ in hängande indrag för ett stycke**

Ett hängande indrag är en stycke layout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med metoden [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setindent/). Sätt indraget till ett negativt värde för att flytta den första raden åt vänster relativt till styckets kropp.

I praktiken definierar [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) den vänstra positionen för styckets kropp, och [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setindent/) definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, sätt ett positivt `MarginLeft`‑värde och ett negativt `Indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, glossarposter och andra stycken där radbrytningar måste anpassas under styckets kropp snarare än under första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta mål‑bilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) till formen och ta bort standardstycket.
5. Skapa stycken och ange ett positivt [MarginLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)‑värde för varje stycke.
6. Ange ett negativt [Indent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setindent/)‑värde för att skapa hängande indrag.
7. Lägg till styckena i textrutan.
8. Spara den modifierade presentationen.

Denna kod visar hur du ställer in hängande indrag för ett stycke:

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

Resultatet:

![Det hängande indraget av styckena](hanging_indent.png)

## **Hantera slut‑egenskaper för stycke**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta referensen till bilden som innehåller stycket via dess position.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
4. Lägg till en [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) med två stycken till rektangeln.
5. Ange `FontHeight` och teckensnittstyp för styckena.
6. Ange Slut‑egenskaperna för styckena.
7. Skriv den modifierade presentationen som en PPTX‑fil.

Denna Javascript‑kod visar hur du ställer in Slut‑egenskaper för stycken i PowerPoint:

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

## **Importera HTML‑text i stycken**

Aspose.Slides tillhandahåller förbättrat stöd för att importera HTML‑text i stycken.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
4. Lägg till och hämta `AutoShape`s [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Läs in käll‑HTML‑filen i en TextReader.
7. Skapa den första styckeinstansen via klassen [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/).
8. Lägg till HTML‑filens innehåll från den lästa TextReader till TextFrames [ParagraphCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphcollection/).
9. Spara den modifierade presentationen.

Denna Javascript‑kod är en implementation av stegen för att importera HTML‑texter i stycken:

```javascript
// Skapa tom presentation-instans
var pres = new aspose.slides.Presentation();
try {
    // Hämtar standardförsta bilden i presentationen
    var slide = pres.getSlides().get_Item(0);
    // Lägger till AutoShape för att rymma HTML-innehållet
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Lägger till textruta i formen
    ashape.addTextFrame("");
    // Rensar alla stycken i den tillagda textrutan
    ashape.getTextFrame().getParagraphs().clear();
    // Laddar HTML-filen med stream reader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Lägger till text från HTML stream reader i textrutan
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Sparar presentationen
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Exportera styckestexter till HTML**

Aspose.Slides tillhandahåller förbättrat stöd för att exportera texter (innehållna i stycken) till HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och ladda den önskade presentationen.
2. Hämta referensen till den aktuella bilden via dess index.
3. Hämta formen som innehåller texten som ska exporteras till HTML.
4. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
5. Skapa en instans av `StreamWriter` och lägg till den nya HTML‑filen.
6. Ange ett startindex till StreamWriter och exportera dina önskade stycken.

Denna Javascript‑kod visar hur du exporterar PowerPoint‑styckestexter till HTML:

```javascript
// Ladda presentationsfilen
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Hämtar standardförsta bilden i presentationen
    var slide = pres.getSlides().get_Item(0);
    // Önskat index
    var index = 0;
    // Hämtar den tillagda formen
    var ashape = slide.getShapes().get_Item(index);
    // Skapar utdata-HTML-fil
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extraherar första stycket som HTML
    // Skriver styckedata till HTML genom att ange styckets startindex och totalt antal stycken som ska kopieras
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Spara ett stycke som en bild**

I detta avsnitt kommer vi att utforska två exempel som demonstrerar hur man sparar ett textstycke, representerat av klassen [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/), som en bild. Båda exemplen inkluderar att hämta bilden av en form som innehåller stycket med hjälp av `getImage`‑metoderna från klassen [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/), beräkna styckets gränser inom formen och exportera det som en bitmap‑bild. Dessa tillvägagångssätt låter dig extrahera specifika delar av texten från PowerPoint‑presentationer och spara dem som separata bilder, vilket kan vara användbart i olika scenarier.

Låt oss anta att vi har en presentationsfil som heter sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

**Exempel 1**

I detta exempel hämtar vi det andra stycket som en bild. För att göra detta extraherar vi bilden av formen från den första bilden i presentationen och beräknar sedan gränserna för det andra stycket i formens textruta. Stycket ritas sedan om på en ny bitmap‑bild som sparas i PNG‑format. Denna metod är särskilt användbar när du behöver spara ett specifikt stycke som en separat bild samtidigt som du bevarar exakt dimension och formatering av texten.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Spara formen i minnet som en bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Skapa en bitmap av formen från minnet.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Beräkna gränserna för det andra stycket.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Beräkna koordinaterna och storleken för output-bilden (minsta storlek - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Beskär formens bitmap för att bara få stycke-bitmapen.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Resultatet:

![Stycke‑bilden](paragraph_to_image_output.png)

**Exempel 2**

I detta exempel bygger vi vidare på föregående metod genom att lägga till skalningsfaktorer till stycke‑bilden. Formen extraheras från presentationen och sparas som en bild med en skalningsfaktor på `2`. Detta möjliggör en högre upplösning vid export av stycket. Styckets gränser beräknas sedan med hänsyn till skalningen. Skalning kan vara särskilt användbart när en mer detaljerad bild behövs, till exempel för högkvalitativt tryckt material.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Spara formen i minnet som en bitmap med skalning.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Skapa en bitmap av formen från minnet.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Beräkna gränserna för det andra stycket.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Beräkna koordinaterna och storleken för utdata-bilden (minsta storlek - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Beskär formens bitmap för att endast få stycke-bitmapen.
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

**Kan jag helt inaktivera radbrytning i en textruta?**

Ja. Använd textrutans omslaginställning ([setWrapText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/setwraptext/)) för att stänga av omslag så att rader inte bryts vid rutan kanter.

**Hur kan jag få exakta gränser på bilden för ett specifikt stycke?**

Du kan hämta styckets (och även en enskild portions) omgivande rektangel för att veta dess exakta position och storlek på bilden.

**Var styrs styckejustering (vänster/höger/center/justify)?**

[setAlignment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setalignment/) är en metod för en styckenivåinställning i [ParagraphFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/); den tillämpas på hela stycket oavsett individuell portionsformatering.

**Kan jag ange ett stavningskontrollspråk för bara en del av ett stycke (t.ex. ett ord)?**

Ja. Språket sätts på portionsnivå ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), så flera språk kan samexistera inom ett och samma stycke.