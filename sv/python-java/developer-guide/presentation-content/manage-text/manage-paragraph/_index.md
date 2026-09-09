---
title: Hantera PowerPoint-textstycken i Python via Java
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
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
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, delar, punkter, numrerade listor, indrag, HTML‑innehåll och styckebilder med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides för Python via Java representerar text som en hierarki av textramar, stycken och delar:

* [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) representerar textbehållaren i en form och ger åtkomst till dess styckeskollektion.
* [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) representerar ett stycke i en textram och ger åtkomst till dess delar och styckes‑nivå formatering.
* [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/) representerar ett textstycke inom ett stycke. Varje del kan ha egen text och tecken‑nivå formatering.

Ett stycke kan därför innehålla text med olika teckensnitt, färger, storlekar och annan formatering genom att använda flera delar.

## **Skapa och formatera stycken**

### **Skapa stycken med flera delar**

Följande steg skapar en textram med tre stycken, där varje innehåller tre delar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Åtkomst till den relevanta bilden via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
4. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
5. Använd standardstycket och lägg till två ytterligare [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/)-objekt i textramen.
6. Lägg till tillräckligt med [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/)-objekt så att varje stycke innehåller tre delar. Standardstycket innehåller redan en tom del.
7. Ange texten för varje del.
8. Applicera tecken‑nivå formatering via [Portion.getPortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getPortionFormat).
9. Spara den modifierade presentationen.

Detta Python‑exempel implementerar stegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Skapa punkt- och numrerade listor**

### **Skapa en punkt- eller numrerad lista**

Punkter och numrering gör relaterade objekt enklare att skanna. I Aspose.Slides definieras listinställningar via [BulletFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/).

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Åtkomst till den relevanta bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på den valda bilden.
4. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
5. Ta bort standardstycket från textramen.
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) för en symbolpunkt.
7. Ange [BulletFormat.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Symbol](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bullettype/#Symbol) och specificera punkttecknet.
8. Ställ in styckets text, indrag, punktfärg och punktens höjd.
9. Lägg till stycket i textramen.
10. Skapa ett andra stycke och ange [BulletFormat.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Numbered](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bullettype/#Numbered).
11. Konfigurera den numrerade punktstilen och lägg till stycket i textramen.
12. Spara presentationen.

Detta Python‑exempel skapar en symbolpunkt och en numrerad punkt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Använd bildpunkter**

Bildpunkter låter dig använda en anpassad bild istället för en symbol eller ett nummer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Åtkomst till den relevanta bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) och åtkomst till dess [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
4. Ta bort standardstycket från textramen.
5. Läs in punktbilden och lägg till den i presentationens bildsamling som en [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/).
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) och ange dess text.
7. Ange [BulletFormat.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Picture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bullettype/#Picture).
8. Tilldela bilden via [BulletFormat.getPicture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#getPicture) och ange punktens höjd.
9. Lägg till stycket i textramen.
10. Spara den modifierade presentationen.

Detta Python‑exempel skapar en bildpunkt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Skapa en flernivålista**

Ange [ParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setDepth) för att placera stycken på olika nivåer i en lista. Toppnivån har ett djup på `0`.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och åtkomst till en bild.
2. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) och rensa standardstycket från dess textram.
3. Skapa fyra stycken och konfigurera deras punkt‑symboler.
4. Ange deras [ParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setDepth)-värden till `0`, `1`, `2` och `3`.
5. Lägg till styckena i textramen och spara presentationen.

Detta Python‑exempel skapar en fyrnivåpunktlista:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Starta numrerade listobjekt på anpassade värden**

Använd [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) för att ange det initiala numret som visas för ett numrerat stycke.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på en bild.
2. Rensa standardstycket från formens textram.
3. Skapa tre numrerade stycken.
4. Ange [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) till `2`, `3` och `7` för respektive stycke.
5. Lägg till styckena i textramen och spara presentationen.

Detta Python‑exempel tilldelar ett anpassat startnummer till varje stycke:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Styr stycke layout och slutegenskaper**

### **Ange ett indrag för första raden**

Använd [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent) för att kontrollera förstalinjens indrag i ett stycke. Denna metod flyttar endast den första raden relativt styckets vänstra marginal. Ett positivt värde skjuter den första raden åt höger, medan de övriga raderna förblir inriktade mot styckets kropp.

Använd [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginLeft) när du behöver flytta hela stycket. Använd [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent) när du bara behöver flytta den första raden.

Exemplet nedan skapar flera stycken och applicerar olika [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent)-värden för att demonstrera hur förstalinjens indrag påverkar stycke layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Åtkomst till målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
4. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) och ta bort standardstycket.
5. Skapa flera stycken och ange olika [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent)-värden för dem.
6. Lägg till styckena i textramen.
7. Spara den modifierade presentationen.

Denna kod visar hur du anger ett styckeindrag:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Förstalinjens indrag i styckena](first_line_indent.png)

### **Ange ett hängande indrag**

Ett hängande indrag är en stycke layout där den första raden börjar till vänster om de övriga raderna. I Aspose.Slides skapar du denna effekt med [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent). Skicka ett negativt värde för att flytta den första raden åt vänster relativt styckets kropp.

I praktiken definierar [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginLeft) det vänstra läget för styckets kropp, och [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent) definierar den första radens position relativt den marginalen. För att skapa ett hängande indrag, skicka ett positivt värde till [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginLeft) och ett negativt värde till [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent).

Denna formatering är användbar för bibliografier, referenser, glossposter och andra stycken där radbrytningar måste justeras under styckets kropp snarare än under den första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Åtkomst till målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
4. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) och ta bort standardstycket.
5. Skapa stycken och skicka ett positivt värde till [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginLeft) för varje stycke.
6. Skicka ett negativt värde till [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent) för att skapa det hängande indraget.
7. Lägg till styckena i textramen.
8. Spara den modifierade presentationen.

Denna kod visar hur du anger ett hängande indrag för ett stycke:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Det hängande indraget i styckena](hanging_indent.png)

### **Ange slutstycke‑körningsegenskaper**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) styr formateringen av paragrafens sluttecken. Följande exempel tilldelar en teckenstorlek och ett latinskt teckensnitt till sluttecknet för det andra stycket:

1. Läs in en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och åtkomst till en bild.
2. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) och rensa dess standardstycke.
3. Skapa två stycken och lägg till textdelar i dem.
4. Skapa ett [PortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/) för det andra styckets sluttecken.
5. Ange [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setFontHeight) och [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. Tilldela formatet med [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) och spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Importera och exportera styckeinnehåll**

### **Importera HTML‑text till stycken**

Använd [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphcollection/#addFromHtml) för att konvertera HTML‑taggning till stycken och delar i en textram.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Åtkomst till en bild och lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).
3. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) och rensa dess standardstycke.
4. Läs in käll‑HTML‑filen.
5. Skicka HTML‑strängen till [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Spara den modifierade presentationen.

Detta Python‑exempel importerar HTML till en textram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Exportera stycketext till HTML**

Använd [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphcollection/#exportToHtml) för att exportera ett valt intervall av stycken som HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och läs in den önskade presentationen.
2. Åtkomst till bilden och hitta den [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) som innehåller texten.
3. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
4. Anropa [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphcollection/#exportToHtml) med start‑stycke‑indexet och antalet stycken att exportera.
5. Skriv den returnerade HTML‑strängen till en fil.

Detta Python‑exempel exporterar alla stycken från den första textramen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Rendera ett stycke som en bild**

[Paragraph.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) renderar ett enskilt stycke direkt och returnerar ett bildobjekt. Spara resultatet till en fil eller stream med dess `save`‑metod. Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[Paragraph.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) kan returnera `None` om stycket inte kan hittas i sin föräldrakollektion, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar det och disponera den returnerade bilden efter användning.

#### **Rendera ett stycke i standardskala**

Låt oss anta att vi har en presentationsfil som heter sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

Följande exempel renderar det andra stycket i en vanlig textruta i standardskala och sparar den returnerade bilden i PNG‑format. `finally`‑blocket säkerställer att bilden disponeras korrekt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

Resultatet:

![Styckebilden](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd [Paragraph.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/)‑överladdningen som accepterar `scale_x` och `scale_y`‑parametrar för att ange de horisontella och vertikala skalningsfaktorerna. Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbelt så stor standardbredd och -höjd, och sparar resultatet som en PNG‑bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

En skalningsfaktor på `1` behåller den axeln på dess standardpixelstorlek. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standardmåtten, vilket resulterar i fyra gånger så många pixlar. Större faktorer ger vanligtvis skarpare text vid inzoomning eller högupplöst utskrift, men de ökar också minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detaljrikedom. Använd lika faktorer för att bevara styckets bildförhållande; olika horisontella och vertikala faktorer sträcker ut resultatet oberoende.

Rendering av en hel form med [Shape.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) är fortfarande användbart när utskriften måste inkludera formens fyllning, kant eller annan visuell kontext. För en bild som endast innehåller ett stycke, använd [Paragraph.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/).

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Ange [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setWrapText) för att inaktivera radbrytning så att rader inte bryts vid textramens kanter.

**Hur kan jag få de exakta gränserna på bilden för ett specifikt stycke?**

Använd [Paragraph.getRect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#getRect) för att hämta styckets avgränsningsrektangel. [Portion.getRect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getRect) ger gränserna för en enskild del.

**Var styrs styckejustering (vänster, höger, centrerad eller marginaljustering)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setAlignment) är en inställning på stycketnivå och tillämpas på hela stycket oavsett individuell delformatering.

**Kan jag ange korrekturläsningsspråk för en del av ett stycke?**

Ja. Ange [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId) för enskilda delar, så att ett stycke kan innehålla text på flera språk.