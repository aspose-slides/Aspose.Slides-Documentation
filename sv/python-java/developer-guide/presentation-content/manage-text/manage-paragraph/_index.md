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
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, portioner, punkter, numrerade listor, indrag, HTML‑innehåll och styckebilder med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides för Python via Java representerar text som en hierarki av textramar, stycken och portioner:

* [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) representerar textbehållaren i en form och ger åtkomst till dess styckesamling.
* [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) representerar ett stycke i en textram och ger åtkomst till dess portioner och formatering på styckesnivå.
* [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/) representerar ett textsegment inom ett stycke. Varje portion kan ha sin egen text och tecken‑nivå‑formatering.

Ett stycke kan därför innehålla text med olika typsnitt, färger, storlekar och annan formatering genom att använda flera portioner.

## **Skapa och formatera stycken**

### **Skapa stycken med flera portioner**

Följande steg skapar en textram med tre stycken, där varje stycke innehåller tre portioner:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Få åtkomst till den relevanta bilden via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
4. Få åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
5. Använd standardstycket och lägg till två ytterligare [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/)‑objekt i textramen.
6. Lägg till tillräckligt många [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/)‑objekt så att varje stycke får tre portioner. Standardstycket innehåller redan en tom portion.
7. Sätt texten för varje portion.
8. Tillämpa tecken‑nivå‑formatering via [Portion.getPortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getPortionFormat).
9. Spara den ändrade presentationen.

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
2. Få åtkomst till den relevanta bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på den valda bilden.
4. Få åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
5. Ta bort standardstycket från textramen.
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) för en symbolpunkt.
7. Sätt [BulletFormat.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Symbol](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bullettype/#Symbol) och ange punkttecknet.
8. Ange styckets text, indrag, punktfärg och punktens höjd.
9. Lägg till stycket i textramen.
10. Skapa ett andra stycke och sätt [BulletFormat.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Numbered](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bullettype/#Numbered).
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

Bildpunkter låter dig använda en anpassad bild i stället för en symbol eller ett nummer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Få åtkomst till den relevanta bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) och få åtkomst till dess [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
4. Ta bort standardstycket från textramen.
5. Läs in punktbilden och lägg till den i presentationens bildsamling som en [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/).
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) och sätt dess text.
7. Sätt [BulletFormat.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Picture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bullettype/#Picture).
8. Tilldela bilden via [BulletFormat.getPicture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#getPicture) och ange punktens höjd.
9. Lägg till stycket i textramen.
10. Spara den ändrade presentationen.

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

### **Skapa en flernivållista**

Sätt [ParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setDepth) för att placera stycken på olika nivåer i en lista. Top‑nivån har ett djup på `0`.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och få åtkomst till en bild.
2. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) och rensa standardstycket från dess textram.
3. Skapa fyra stycken och konfigurera deras punkt‑symboler.
4. Sätt deras [ParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setDepth)‑värden till `0`, `1`, `2` och `3`.
5. Lägg till styckena i textramen och spara presentationen.

Detta Python‑exempel skapar en fyranivå‑punktlista:

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

### **Starta numrerade listobjekt med egna startvärden**

Använd [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) för att ange det inledande numret som visas för ett numrerat stycke.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på en bild.
2. Rensa standardstycket från formens textram.
3. Skapa tre numrerade stycken.
4. Sätt [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) till `2`, `3` respektive `7` för de aktuella styckena.
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

## **Styr stycke‑layout och slutegenskaper**

### **Ange ett första‑rad‑indrag**

Använd [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent) för att kontrollera första‑rad‑indraget i ett stycke. Denna metod flyttar endast den första raden i förhållande till styckets vänstra marginal. Ett positivt värde flyttar den första raden åt höger, medan resterande rader förblir justerade mot styckeskroppen.

Använd [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginLeft) när du vill flytta hela stycket. Använd [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent) när du bara vill flytta den första raden.

Exemplet nedan skapar flera stycken och applicerar olika [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent)‑värden för att demonstrera hur första‑rad‑indraget påverkar layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Få åtkomst till mål‑bilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
4. Få åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) och ta bort standardstycket.
5. Skapa flera stycken och sätt olika [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent)‑värden för dem.
6. Lägg till styckena i textramen.
7. Spara den ändrade presentationen.

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

![Första‑rad‑indraget i styckena](first_line_indent.png)

### **Ange ett hängande indrag**

Ett hängande indrag är en stycke‑layout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent). Ange ett negativt värde för att flytta den första raden åt vänster i förhållande till styckets kropp.

I praktiken definierar [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginLeft) den vänstra positionen för styckeskroppen, och [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent) definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, ange ett positivt värde till [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginLeft) och ett negativt värde till [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent).

Denna formatering är användbar för bibliografier, referenser, ordlistposter och andra stycken där radbrytningar ska justeras under styckeskroppen snarare än under första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Få åtkomst till mål‑bilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
4. Få åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) och ta bort standardstycket.
5. Skapa stycken och ange ett positivt värde till [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginLeft) för varje stycke.
6. Ange ett negativt värde till [ParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setIndent) för att skapa det hängande indraget.
7. Lägg till styckena i textramen.
8. Spara den ändrade presentationen.

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

### **Ange slut‑stycke‑egenskaper**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) styr formateringen av styckets slutmarkering. Följande exempel tilldelar en teckenstorlek och ett latinskt typsnitt till slutmarkeringen i det andra stycket:

1. Läs in en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och få åtkomst till en bild.
2. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) och rensa dess standardstycke.
3. Skapa två stycken och lägg till textrader i dem.
4. Skapa ett [PortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/) för det andra styckets slutmarkering.
5. Sätt [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setFontHeight) och [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLatinFont).
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

## **Räkna renderade rader**

Använd [Paragraph.getLinesCount](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#getLinesCount) för att räkna antalet rader som ett stycke upptar efter textlayout, inklusive automatisk radbrytning. Detta är användbart när man kontrollerar textlängd och layout i presentationsmallar.

Ett stycke är ett objekt i [TextFrame.getParagraphs](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParagraphs) och kan uppta flera renderade rader. Ett explicit radbrytningstecken inom ett stycke tvingar en ny rad utan att skapa ett nytt stycke. Automatisk radbrytning skapar rader baserat på tillgänglig bredd utan att infoga explicita radbrytningstecken i texten. Att räkna stycken eller radbrytningstecken ger därför inte det renderade radantalet.

Följande exempel skapar en textform, räknar dess rader, smalnar av formen och ersätter sedan texten med en kortare sträng. Radbrytning är aktiverad och autofit är inaktiverat så att formens bredd styr radbrytningen utan att automatiskt krympa texten eller ändra formens storlek. Formens dimensioner anges i punkter. Slutligen lägger exemplet till ett ytterligare stycke och summerar radantalet för hela textramen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

Med denna text och dessa dimensioner ökar radantalet när formen smalnas, medan ersättning med den korta strängen minskar det. Exakta siffror kan variera beroende på tillgängliga typsnitt, typsnitts­substitution, teckenstorlek, marginaler, indrag, radbrytning och autofit‑inställningar. Använd de typsnitt och layoutinställningar som är avsedda för målmiljön när du kontrollerar en mall.

Endast radantalet avgör inte om texten överskrider sin behållare. Tillgänglig höjd, radhöjder, stycke‑ och radavstånd samt autofit‑beteende spelar också in; även en enda rad kan överskrida tillgänglig bredd när radbrytning är inaktiverad.

## **Importera och exportera styckeinnehåll**

### **Importera HTML‑text till stycken**

Använd [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphcollection/#addFromHtml) för att konvertera HTML‑markup till stycken och portioner i en textram.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Få åtkomst till en bild och lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).
3. Få åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) och rensa dess standardstycke.
4. Läs in käll‑HTML‑filen.
5. Skicka HTML‑strängen till [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Spara den ändrade presentationen.

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
2. Få åtkomst till bilden och hitta den [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) som innehåller texten.
3. Få åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
4. Anropa [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphcollection/#exportToHtml) med start‑stycke‑index och antal stycken som ska exporteras.
5. Skriv den returnerade HTML‑strängen till en fil.

Detta Python‑exempel exporterar alla stycken från den första textformen:

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

[Paragraph.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) renderar ett enskilt stycke direkt och returnerar ett bildobjekt. Spara resultatet till en fil eller ström med dess `save`‑metod. Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[Paragraph.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) kan returnera `None` om stycket inte kan hittas i sin föräldrakollektion, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar och frigör den returnerade bilden efter användning.

#### **Rendera ett stycke i standardskala**

Låt oss anta att vi har en presentationsfil som heter `sample.pptx` med en bild, där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

Följande exempel renderar det andra stycket i en vanlig textruta i standardskala och sparar den returnerade bilden i PNG‑format. `finally`‑blocket säkerställer att bilden frigörs korrekt.

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

![Stycke‑bilden](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd [Paragraph.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/)‑överkursen som accepterar parametrarna `scale_x` och `scale_y` för att ange horisontella och vertikala skalningsfaktorer. Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbelt så stor bredd och höjd som standard, och sparar resultatet som en PNG‑bild.

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

En skalningsfaktor på `1` behåller den axeln på dess standardpixelstorlek. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standardmåtten, vilket resulterar i fyra gånger så många pixlar. Större faktorer ger i allmänhet skarpare text för zoomning eller högupplöst utskrift, men ökar också minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detalj. Använd lika faktorer för att bevara styckets bildförhållande; olika horisontella och vertikala faktorer sträcker ut resultatet oberoende.

Att rendera en hel form med [Shape.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) är fortfarande användbart när utdata måste inkludera formens fyllning, kantlinje eller annan visuell kontext. För enbart stycke‑bild, använd [Paragraph.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/).

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Sätt [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setWrapText) för att inaktivera radbrytning så att raderna inte bryts vid textrammans kanter.

**Hur kan jag få exakt bild‑position för ett specifikt stycke?**

Använd [Paragraph.getRect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#getRect) för att hämta styckets omgivande rektangel. [Portion.getRect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getRect) ger gränserna för en enskild portion.

**Var styrs styckejustering (vänster, höger, centrerad eller marginal) ?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setAlignment) är en inställning på styckesnivå och gäller hela stycket oavsett individuell portionsformatering.

**Kan jag ange språk för korrekturläsning för en del av ett stycke?**

Ja. Sätt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId) för enskilda portioner, så att ett stycke kan innehålla text på flera språk.