---
title: Hantera teckensnitt i presentationer på Android
linktitle: Hantera teckensnitt
type: docs
weight: 10
url: /sv/androidjava/manage-fonts/
keywords:
- hantera teckensnitt
- teckensnittsegenskaper
- stycke
- textformatering
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Kontrollera teckensnitt i Java med Aspose.Slides för Android: bädda in, ersätta och ladda anpassade teckensnitt för att hålla PPT-, PPTX- och ODV‑presentationer tydliga, varumärkessäkra och konsekventa."
---
## **Översikt**

Aspose.Slides låter dig hantera teckensnittsegenskaper i presentations‑text direkt från din kod. Du kan komma åt text i bilder via former, textramar, stycken och portioner och sedan tillämpa formatering på den markerade texten.

Denna artikel förklarar hur du konfigurerar teckensnittsegenskaper för befintlig text i en presentation, inklusive teckensnittsfamilj, fetstil och kursiv stil, styckejustering samt teckensnittsfärg. Den visar också hur du skapar en textruta, lägger till text i den och anger teckensnittsegenskaper såsom teckensnittsfamilj, fet, kursiv, understruken, teckensnittsstorlek och färg innan du sparar resultatet som en PPTX‑fil.

## **Hantera teckensnittsegenskaper**
{{% alert color="primary" %}} 

Presentationer innehåller vanligtvis både text och bilder. Text kan formateras på olika sätt, antingen för att framhäva specifika avsnitt och ord eller för att följa företagets stilriktlinjer. Textformatering hjälper användare att variera utseendet på presentationsinnehållet. Denna artikel visar hur du med Aspose.Slides för Android via Java konfigurerar teckensnittsegenskaper för stycken text på bilder.

{{% /alert %}} 

För att hantera teckensnittsegenskaper för ett stycke med Aspose.Slides för Android via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Hämta en bilds referens genom att använda dess index.
1. Kom åt formerna [Placeholder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholder/) i bilden och typkonvertera dem till [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/).
1. Hämta [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/) från [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/) som exponeras av [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/).
1. Justera stycket.
1. Kom åt en [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/)s text‑[Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/).
1. Definiera teckensnittet med [FontData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontdata/) och sätt **Font** för text‑[Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/) därefter.
   1. Sätt teckensnittet till fet.
   1. Sätt teckensnittet till kursiv.
1. Ange teckensnittsfärgen med [FillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/) som exponeras av [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/)-objektet.
1. Spara den modifierade presentationen till en PPTX‑fil.

Implementeringen av stegen ovan ges nedan. Den tar en outfärgad presentation och formaterar teckensnitten på en av bilderna. Skärmbilderna som följer visar indatabilden och hur kodsnuttarna förändrar den. Koden ändrar teckensnitt, färg och teckensnittsstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figur: Texten i indatarfilen**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figur: Samma text med uppdaterad formatering**|

```java
// Skapa ett Presentation-objekt som representerar en PPTX-fil
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Åtkomst till en bild med dess positionsindex
	ISlide slide = pres.getSlides().get_Item(0);

	// Åtkomst till den första och andra platshållaren i bilden och typkonvertera till AutoShape
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

	// Spara PPTX-filen till disk
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ange textegenskaper för teckensnitt**
{{% alert color="primary" %}} 

Som nämnt i **Hantera teckensnittsegenskaper** används en [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/) för att hålla text med liknande formateringsstil i ett stycke. Denna artikel visar hur du med Aspose.Slides för Android via Java skapar en textruta med någon text och sedan definierar ett specifikt teckensnitt samt olika andra egenskaper för teckensnittsfamiljekategorin.

{{% /alert %}} 

För att skapa en textruta och ange teckensnittsegenskaper för texten i den:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/) av typen **Rectangle** på bilden.
1. Ta bort fyllningsstilen som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/).
1. Åtkomst till av [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/).
1. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/).
1. Kom åt [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/)-objektet som är kopplat till [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/).
1. Definiera teckensnittet som ska användas för [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/).
1. Ange andra teckensnittsegenskaper som fet, kursiv, understruken, färg och höjd med de relevanta egenskaperna som exponeras av [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/)-objektet.
1. Skriv den modifierade presentationen som en PPTX‑fil.

Implementeringen av stegen ovan ges nedan.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figur: Text med vissa teckensnittsegenskaper satta av Aspose.Slides för Android via Java**|

```java
// Skapa ett Presentation-objekt som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
	// Hämta första bilden
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Lägg till en AutoShape av typen Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Ta bort eventuell fyllningsstil som är associerad med AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Åtkomst till TextFrame som är associerad med AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Åtkomst till Portion som är associerad med TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Ange teckensnittet för Portionen
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Sätt fet egenskap för teckensnittet
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Sätt kursiv egenskap för teckensnittet
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Sätt understruken egenskap för teckensnittet
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Sätt höjden på teckensnittet
	port.getPortionFormat().setFontHeight(25);
	
	// Sätt färgen på teckensnittet
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Spara presentationen till disk
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```