---
title: Hantera teckensnitt i presentationer med Python via Java
linktitle: Hantera teckensnitt
type: docs
weight: 10
url: /sv/python-java/manage-fonts/
keywords:
- hantera teckensnitt
- teckensnittsegenskaper
- stycke
- textformatering
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Kontrollera teckensnitt i Python via Java med Aspose.Slides: bädda in, ersätta och läs in anpassade teckensnitt för att hålla PPT-, PPTX- och ODP-presentationer tydliga, varumärkessäkra och konsekventa."
---
## **Översikt**

Aspose.Slides låter dig hantera teckensnittsegenskaper i presentationstext direkt från din kod. Du kan komma åt text i bilder via former, textramar, stycken och portioner och sedan applicera formatering på den markerade texten.

Denna artikel förklarar hur du konfigurerar teckensnittsegenskaper för befintlig text i en presentation, inklusive teckensnittsfamilj, fetstil och kursiv stil, styckejustering och teckensnittsfärg. Den visar också hur du skapar en textruta, lägger till text i den och anger teckensnittsegenskaper såsom teckensnittsfamilj, fetstil, kursiv, understruken, teckensnittsstorlek och färg innan du sparar resultatet som en PPTX‑fil.

## **Hantera teckensnittsrelaterade egenskaper**
{{% alert color="info" title="Note" %}} 

Presentationer innehåller vanligtvis både text och bilder. Texten kan formateras på olika sätt, antingen för att markera specifika avsnitt och ord eller för att följa företagsstilar. Textformatering hjälper användare att variera utseendet och känslan i presentationsinnehållet. Denna artikel visar hur man använder Aspose.Slides for Python via Java för att konfigurera teckensnittsegenskaper för textstycken på bilder.

{{% /alert %}} 

För att hantera teckensnittsegenskaper för ett stycke med Aspose.Slides for Python via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en bilds referens genom att använda dess index.
1. Få åtkomst till [Placeholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholder/)-formerna i bilden som [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).
1. Hämta [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) från [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) som exponeras av [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).
1. Justera stycket.
1. Få åtkomst till ett [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/)-text [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/).
1. Definiera teckensnittet med hjälp av [FontData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontdata/) och sätt **Font** för texten [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/) därefter.
   1. Ställ in teckensnittet som fet.
   1. Ställ in teckensnittet som kursiv.
1. Ange teckensnittsfärgen med hjälp av [FillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/) som exponeras av [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/)-objektet.
1. Spara den ändrade presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan. Den tar en enkel presentation och formaterar teckensnitten på en av bilderna. Skärmbilderna som följer visar indatafilen och hur kodsnuttarna ändrar den. Koden ändrar teckensnittet, färgen och teckensnittsstilen.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figur: Texten i indatafilen**|

|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figur: Samma text med uppdaterad formatering**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Ladda presentationen.
presentation = Presentation("FontProperties.pptx")
try:
    # Hämta den första bilden och textramarna för dess två första platshållare.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Hämta det första stycket i varje textram.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Hämta den första delen i varje stycke.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Definiera och tilldela nya teckensnitt.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Ställ in teckensnitten som fet och kursiv.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Ställ in teckensnittsfärgerna.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Spara presentationen.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange teckensnittsegenskaper för text**
{{% alert color="info" title="Note" %}} 

Som nämnt i **Hantera teckensnittsrelaterade egenskaper** används en [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/) för att hålla text med liknande formateringsstil i ett stycke. Denna artikel visar hur man använder Aspose.Slides for Python via Java för att skapa en textruta med lite text och sedan definiera ett specifikt teckensnitt samt olika andra teckensnittsegenskaper.

{{% /alert %}} 

För att skapa en textruta och ange teckensnittsegenskaper för texten i den:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) av typen **Rectangle** på bilden.
1. Ta bort fyllningsstilen som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).
1. Få åtkomst till [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
1. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
1. Få åtkomst till [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/)‑objektet som är associerat med [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
1. Definiera teckensnittet som ska användas för [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/).
1. Ange andra teckensnittsegenskaper såsom fet, kursiv, understruken, färg och storlek med hjälp av de relevanta egenskaperna som exponeras av [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/)-objektet.
1. Skriv den ändrade presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figur: Text med några teckensnittsegenskaper inställda av Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Hämta den första bilden och lägg till en rektangel.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Ta bort figurens fyllning.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Lägg till text i figurens textram.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Ställ in teckensnittsfamiljen.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Ställ in fet, kursiv, understruken och teckensnittsstorlek.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Ställ in teckensnittsfärgen.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Spara presentationen.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```