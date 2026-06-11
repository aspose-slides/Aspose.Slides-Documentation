---
title: Hantera teckensnitt i presentationer med Java
linktitle: Hantera teckensnitt
type: docs
weight: 10
url: /sv/java/manage-fonts/
keywords:
- hantera teckensnitt
- teckensnittsegenskaper
- stycke
- textformatering
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Styr teckensnitt i Java med Aspose.Slides: bädda in, ersätta och ladda anpassade teckensnitt för att hålla PPT-, PPTX- och ODP-presentationer tydliga, varumärkessäkra och konsekventa."
---
## **Översikt**

Aspose.Slides låter dig hantera teckensnittsegenskaper i presentationstext direkt från din kod. Du kan komma åt text i bilder genom former, textramar, stycken och delar och sedan tillämpa formatering på den valda texten.

Denna artikel förklarar hur du konfigurerar teckensnittrelaterade egenskaper för befintlig text i en presentation, inklusive teckensnittsfamilj, fet- och kursivstil, styckejustering och teckensnittsfärg. Den visar också hur du skapar en textruta, lägger till text i den och anger teckensnittsegenskaper som teckensnittsfamilj, fet, kursiv, understruken, teckensnittsstorlek och färg innan du sparar resultatet som en PPTX‑fil.

## **Hantera teckensnittrelaterade egenskaper**
{{% alert color="primary" %}} 

Presentationer innehåller vanligtvis både text och bilder. Texten kan formateras på olika sätt, antingen för att markera specifika avsnitt och ord eller för att följa företagets stilar. Textformatering hjälper användare att variera utseendet och känslan i presentationsinnehållet. Denna artikel visar hur du använder Aspose.Slides for Java för att konfigurera teckensnittsegenskaperna för textstycken på bilder.

{{% /alert %}} 

För att hantera teckensnittsegenskaper för ett stycke med Aspose.Slides for Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Hämta en bilds referens genom att använda dess index.
1. Kom åt [Placeholder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/placeholder/)‑formerna i bilden och typomvandla dem till [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/).
1. Hämta [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/) från [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/) som exponeras av [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/).
1. Justera stycket.
1. Kom åt en [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/)'s text [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/).
1. Definiera teckensnittet med [FontData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontdata/) och sätt **Font** för textens [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/) därefter.
   1. Sätt teckensnittet till fet.
   1. Sätt teckensnittet till kursiv.
1. Ställ in teckensnittsfärgen med hjälp av [FillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/) som exponeras av [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/)-objektet.
1. Spara den modifierade presentationen som en PPTX‑fil.

Implementeringen av ovanstående steg ges nedan. Den tar en enkel presentation och formaterar teckensnitten på en av bilderna. Skärmbilderna som följer visar inmatningsfilen och hur kodsnuttarna ändrar den. Koden ändrar teckensnittet, färgen och teckensnittsstilen.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figur: Texten i inmatningsfilen**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figur: Samma text med uppdaterad formatering**|

```java
// Skapa ett Presentation‑objekt som representerar en PPTX‑fil
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Kom åt en bild med dess bildposition
	ISlide slide = pres.getSlides().get_Item(0);

	// Kom åt den första och andra platshållaren i bilden och typomvandla den till AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Kom åt det första stycket
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justera stycket
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Kom åt den första delen
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definiera nya teckensnitt
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Tilldela nya teckensnitt till delen
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Sätt teckensnittet till fet
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Sätt teckensnittet till kursiv
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Sätt teckensnittsfärg
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Spara PPTX‑filen till disk
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ställ in textens teckensnittsegenskaper**
{{% alert color="primary" %}} 

Som nämnts i **Hantera teckensnittrelaterade egenskaper**, används en [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/) för att hålla text med liknande formateringsstil i ett stycke. Denna artikel visar hur du använder Aspose.Slides for Java för att skapa en textruta med någon text och sedan definiera ett specifikt teckensnitt samt olika andra egenskaper i teckensnittsfamiljekategorin.

{{% /alert %}} 

För att skapa en textruta och ange teckensnittsegenskaper för texten i den:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/) av typen **Rectangle** på bilden.
1. Ta bort fyllningsstilen som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/).
1. Kom åt [TextFrame] för [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/).
1. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/).
1. Kom åt [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/)-objektet som är associerat med [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/).
1. Definiera teckensnittet som ska användas för [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/).
1. Ställ in andra teckensnittsegenskaper som fet, kursiv, understruken, färg och storlek med hjälp av de relevanta egenskaperna som exponeras av [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/)-objektet.
1. Skriv den modifierade presentationen som en PPTX‑fil.

Implementeringen av ovanstående steg ges nedan.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figur: Text med några teckensnittsegenskaper inställda av Aspose.Slides for Java**|

```java
// Instansiera ett Presentation‑objekt som representerar en PPTX‑fil
Presentation pres = new Presentation();
try {
	// Hämta den första bilden
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Lägg till en AutoShape av typen Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Ta bort eventuell fyllningsstil som är associerad med AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Kom åt TextFrame som är kopplad till AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Kom åt Portion som är kopplad till TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Ange teckensnittet för Portionen
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Ställ in fet egenskap för teckensnittet
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Ställ in kursiv egenskap för teckensnittet
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Ställ in understrykning för teckensnittet
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Ställ in teckensnittets höjd
	port.getPortionFormat().setFontHeight(25);
	
	// Ställ in teckensnittets färg
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Spara presentationen till disk
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```