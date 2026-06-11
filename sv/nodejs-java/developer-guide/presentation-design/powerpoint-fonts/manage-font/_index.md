---
title: Hantera typsnitt i presentationer med JavaScript
linktitle: Hantera typsnitt
type: docs
weight: 10
url: /sv/nodejs-java/manage-fonts/
keywords:
- hantera typsnitt
- typsnittsegenskaper
- stycke
- textformatering
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Styr typsnitt med Aspose.Slides för Node.js via Java: bädda in, ersätt och ladda anpassade typsnitt för att hålla PPT-, PPTX- och ODP-presentationer tydliga och konsekventa."
---
## **Introduktion**

Presentationer innehåller vanligtvis både text och bilder. Texten kan formateras på olika sätt, antingen för att markera specifika avsnitt och ord eller för att överensstämma med företagsstilar. Textformatering hjälper användare att variera utseendet på presentationsinnehållet. Den här artikeln visar hur du använder Aspose.Slides för Node.js via Java för att konfigurera teckensnittsegenskaper för textstycken på bilder.

## **Hantera teckensnittsegenskaper**

För att hantera teckensnittsegenskaper för ett stycke med Aspose.Slides för Node.js via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Hämta en bilds referens genom att använda dess index.
1. Få åtkomst till [Placeholder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholder/)-formerna i bilden och typkonvertera dem till [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/).
1. Hämta [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) från [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) som exponeras av [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/).
1. Justera stycket.
1. Få åtkomst till en [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/)'s text [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/).
1. Definiera teckensnittet med hjälp av [FontData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontdata/) och sätt **Font** för texten [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/) därefter.
   1. Ställ in teckensnittet till fet.
   1. Ställ in teckensnittet till kursiv.
1. Ställ in teckensnittsfärgen med hjälp av [FillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/) som exponeras av [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/)-objektet.
1. Spara den ändrade presentationen i en PPTX-fil.

Implementeringen av stegen ovan visas nedan. Den tar en obeklädd presentation och formaterar teckensnitten på en av bilderna. Skärmdumparna nedan visar ingångsfilerna och hur kodsnuttarna förändrar dem. Koden ändrar teckensnittet, färgen och teckensnittsstilen.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figur: Texten i indatafilen**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figur: Samma text med uppdaterad formatering**|

```javascript
// Skapa ett Presentation-objekt som representerar en PPTX-fil
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Åtkomst till en bild med hjälp av dess positionsnummer
    var slide = pres.getSlides().get_Item(0);
    // Åtkomst till den första och andra platshållaren i bilden och typkonvertera den till AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Åtkomst till det första stycket
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Justera stycket
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Åtkomst till den första delen
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Definiera nya teckensnitt
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Tilldela nya teckensnitt till delen
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Ställ in teckensnittet till fet
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Ställ in teckensnittet till kursiv
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ställ in teckensnittsfärg
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Spara PPTX-filen på disk
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ställ in textteckensnittsegenskaper**
{{% alert color="primary" %}} 

Som nämnt i **Hantera teckensnittsegenskaper**, används en [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/) för att hålla text med liknande formateringsstil i ett stycke. Denna artikel visar hur du använder Aspose.Slides för Node.js via Java för att skapa en textruta med lite text och sedan definiera ett specifikt teckensnitt samt olika andra egenskaper för teckensnittsfamiljekategorin.

{{% /alert %}} 

För att skapa en textruta och sätta teckensnittsegenskaper för texten i den:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) av typen **Rectangle** på bilden.
1. Ta bort fyllningsstilen som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/).
1. Få åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) för [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/).
1. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
1. Få åtkomst till [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/)‑objektet som är associerat med [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
1. Definiera teckensnittet som ska användas för [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/).
1. Ställ in andra teckensnittsegenskaper som fet, kursiv, understruken, färg och storlek med hjälp av de relevanta egenskaperna som exponeras av [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/)‑objektet.
1. Skriv den ändrade presentationen till en PPTX-fil.

Implementeringen av stegen ovan visas nedan.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figur: Text med vissa teckensnittsegenskaper inställda av Aspose.Slides för Node.js via Java**|

```javascript
// Skapa ett Presentation-objekt som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämta första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape av typen Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Ta bort eventuell fyllningsstil som är kopplad till AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Åtkomst till TextFrame som är kopplad till AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Åtkomst till Portion som är kopplad till TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Ställ in teckensnittet för Portionen
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Ställ in fet egenskap för teckensnittet
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Ställ in kursiv egenskap för teckensnittet
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ställ in understruken egenskap för teckensnittet
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Ställ in teckensnittets höjd
    port.getPortionFormat().setFontHeight(25);
    // Ställ in teckensnittets färg
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Spara presentationen på disk
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```