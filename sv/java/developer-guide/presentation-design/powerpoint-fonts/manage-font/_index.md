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
description: "Kontrollera teckensnitt i Java med Aspose.Slides: bädda in, ersätta och ladda anpassade teckensnitt för att hålla PPT-, PPTX- och ODP-presentationer tydliga, varumärkesäkra och konsekventa."
---
## **Översikt**

Aspose.Slides låter dig hantera teckensnittsegenskaper i presentations‑text direkt från din kod. Du kan komma åt text i bilder via former, textramar, stycken och delar och sedan tillämpa formatering på den markerade texten.

Den här artikeln förklarar hur du konfigurerar teckensnittsegenskaper för befintlig text i en presentation, inklusive teckensnittsfamilj, fetstil och kursiv stil, styckjustering och teckensnittsfärg. Den visar också hur du skapar en textruta, lägger till text i den och ställer in teckensnittsegenskaper som teckensnittsfamilj, fetstil, kursiv, understrykning, teckensnittsstorlek och färg innan du sparar resultatet som en PPTX‑fil.

## **Hantera teckensnittsegenskaper**
{{% alert color="info" %}} 

Presentationer innehåller vanligtvis både text och bilder. Texten kan formateras på olika sätt, antingen för att markera specifika sektioner och ord eller för att följa företagets stilriktlinjer. Textformatering hjälper användare att variera utseendet på presentationsinnehållet. Den här artikeln visar hur du använder Aspose.Slides for Java för att konfigurera teckensnittsegenskaper för stycken av text på bilder.

{{% /alert %}} 

För att hantera teckensnittsegenskaper för ett stycke med Aspose.Slides for Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Hämta en bilds referens genom att använda dess index.
1. Åtkomst till [Placeholder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/placeholder/)‑formerna i bilden och typkonvertera dem till [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/).
1. Hämta [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/) från [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/) som exponeras av [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/).
1. Justera stycket.
1. Åtkomst till ett [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/)-styckes text-[Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/).
1. Definiera teckensnittet med hjälp av [FontData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontdata/) och ange **Font** för text‑[Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/) därefter.
   1. Ställ in teckensnittet till fetstil.
   1. Ställ in teckensnittet till kursiv.
1. Ställ in teckensnittsfärgen med hjälp av [FillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/) som exponeras av [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/)-objektet.
1. Spara den ändrade presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan. Den tar en enkel presentation och formaterar tecknen på en av bilderna. Skärmbilderna som följer visar indatafilen och hur kodsnuttarna förändrar den. Koden ändrar teckensnitt, färg och teckensnittsstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figur: Texten i indatafilen**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figur: Samma text med uppdaterad formatering**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera ett Presentation‑objekt som representerar en PPTX‑fil
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Åtkomst till en bild med hjälp av dess bildposition
	ISlide slide = pres.getSlides().get_Item(0);

	// Åtkomst till den första och andra platshållaren i bilden och typkonvertera den till AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Åtkomst till det första stycket
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justera stycket
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Åtkomst till den första delen
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definiera nya teckensnitt
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Tilldela nya teckensnitt till delen
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Ställ in teckensnittet till fetstil
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Ställ in teckensnittet till kursiv
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Ställ in teckensnittsfärg
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
{{% alert color="info" %}} 

Som nämnts i **Hantera teckensnittsegenskaper** används en [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/) för att hålla text med liknande formateringsstil i ett stycke. Denna artikel visar hur du använder Aspose.Slides for Java för att skapa en textruta med någon text och sedan definiera ett specifikt teckensnitt samt diverse andra egenskaper i teckensnittsfamiljekategorin.

{{% /alert %}} 

För att skapa en textruta och ställa in teckensnittsegenskaper för texten i den:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/) av typen **Rectangle** på bilden.
1. Ta bort fyllningsstilen som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/).
1. Åtkomst till [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/).
1. Lägg till lite text till [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/).
1. Åtkomst till [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/)-objektet som är associerat med [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/).
1. Definiera teckensnittet som ska användas för [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/).
1. Ställ in andra teckensnittsegenskaper som fetstil, kursiv, understrykning, färg och storlek med hjälp av de relevanta egenskaperna som exponeras av [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/)-objektet.
1. Spara den ändrade presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figur: Text med vissa teckensnittsegenskaper inställda av Aspose.Slides for Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera ett Presentation-objekt som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
	// Hämta första bilden
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Lägg till en AutoShape av typen Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Ta bort eventuell fyllningsstil som är kopplad till AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Åtkomst till TextFrame som är associerad med AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Åtkomst till Portion som är associerad med TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Ställ in teckensnittet för Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Ställ in fetstil för teckensnittet
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Ställ in kursiv för teckensnittet
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Ställ in understrykning för teckensnittet
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Ställ in teckensnittshöjden
	port.getPortionFormat().setFontHeight(25);
	
	// Ställ in teckensnittsfärgen
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Spara presentationen till disk
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```