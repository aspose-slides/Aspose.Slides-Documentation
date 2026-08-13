---
title: Hantera teckensnitt i presentationer på Android
linktitle: Hantera teckensnitt
type: docs
weight: 10
url: /sv/androidjava/manage-fonts/
keywords:
- hantera teckensnitt
- teckensegenskaper
- stycke
- textformatering
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Styr teckensnitt i Java med Aspose.Slides för Android: bädda in, ersätt och ladda anpassade teckensnitt för att hålla PPT-, PPTX- och ODP-presentationer tydliga, varumärkessäkra och konsekventa."
---
## **Översikt**

Aspose.Slides låter dig hantera teckensegenskaper i presentations‑text direkt från din kod. Du kan komma åt text i bilder via former, textrutor, stycken och delar och sedan tillämpa formatering på den markerade texten.

Denna artikel förklarar hur du konfigurerar teckenrelaterade egenskaper för befintlig text i en presentation, inklusive teckensnittsfamilj, fet och kursiv stil, styckejustering och teckenfärg. Den visar också hur du skapar en textruta, lägger till text i den och ställer in teckensegenskaper såsom teckensnittsfamilj, fet, kursiv, understruken, teckenstorlek och färg innan du sparar resultatet som en PPTX‑fil.

## **Hantera teckenrelaterade egenskaper**
{{% alert color="info" %}} 

Presentationer innehåller vanligtvis både text och bilder. Texten kan formateras på olika sätt, antingen för att framhäva specifika avsnitt och ord eller för att följa företagsstilar. Textformatering hjälper användare att variera utseendet på presentationsinnehållet. Denna artikel visar hur du använder Aspose.Slides för Android via Java för att konfigurera teckenegenskaperna för stycken med text på bilder.

{{% /alert %}} 

För att hantera teckenegenskaper för ett stycke med Aspose.Slides för Android via Java:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen.  
1. Hämta en bilds referens genom att använda dess index.  
1. Åtkom [Placeholder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholder/)‑formerna i bilden och gör en typkonvertering till [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/).  
1. Hämta [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/) från [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/) som exponeras av [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/).  
1. Justera stycket.  
1. Åtkom en [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/)s text‑[Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/).  
1. Definiera teckensnittet med [FontData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontdata/) och sätt **Font** för text‑[Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/) därefter.  
   1. Ställ in teckensnittet som fet.  
   1. Ställ in teckensnittet som kursiv.  
1. Ställ in teckenfärgen med [FillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/) som exponeras av [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/)-objektet.  
1. Spara den modifierade presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan. Den tar en opolerad presentation och formaterar tecknen i en av bilderna. Skärmbilderna som följer visar indatafilen och hur kodsnuttarna förändrar den. Koden ändrar teckensnitt, färg och teckenstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figur: Texten i indatafilen**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figur: Samma text med uppdaterad formatering**|

```java
import com.aspose.slides.*;
import java.awt.Color;

//	Instansiera ett Presentation-objekt som representerar en PPTX-fil
Presentation pres = new Presentation("FontProperties.pptx");
try {
	//	Åtkomst till en bild genom dess bildposition
	ISlide slide = pres.getSlides().get_Item(0);

	//	Åtkomst till den första och andra platshållaren i bilden och typkonvertera den till AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	//	Åtkomst till det första stycket
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	//	Justera stycket
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	//	Åtkomst till den första portionen
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	//	Definiera nya teckensnitt
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	//	Tilldela nya teckensnitt till portionen
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	//	Ställ in teckensnittet till fet
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	//	Ställ in teckensnittet till kursiv
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	//	Ställ in teckenfärg
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	//	Spara PPTX-filen på disk
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ställ in teckensnittsegenskaper för text**
{{% alert color="info" %}} 

Som nämnt i **Hantera teckenrelaterade egenskaper** används en [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/) för att hålla text med liknande formateringsstil i ett stycke. Denna artikel visar hur du använder Aspose.Slides för Android via Java för att skapa en textruta med någon text och sedan definiera ett specifikt teckensnitt samt olika andra egenskaper för teckensnittsfamiljekategorin.

{{% /alert %}} 

För att skapa en textruta och ställa in teckensnittsegenskaper för texten i den:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen.  
1. Hämta referensen till en bild genom att använda dess index.  
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/) av typen **Rectangle** på bilden.  
1. Ta bort fyllningsstilen som är kopplad till [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/).  
1. Åtkom [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/).  
1. Lägg till någon text i [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/).  
1. Åtkom [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/)‑objektet som är associerat med [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/).  
1. Definiera teckensnittet som ska användas för [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/).  
1. Ställ in andra teckensnittsegenskaper som fet, kursiv, understruken, färg och storlek med de relevanta egenskaperna som exponeras av [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/)-objektet.  
1. Skriv den modifierade presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figur: Text med några teckensnittsegenskaper inställda av Aspose.Slides för Android via Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera ett Presentation-objekt som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
	// Hämta den första bilden
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
	
	// Ställ in teckensnittet för Portionen
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Ställ in fet egenskap för teckensnittet
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Ställ in kursiv egenskap för teckensnittet
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Ställ in understruken egenskap för teckensnittet
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Ställ in teckenhöjden
	port.getPortionFormat().setFontHeight(25);
	
	// Ställ in teckenfärgen
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Spara presentationen till disk
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```