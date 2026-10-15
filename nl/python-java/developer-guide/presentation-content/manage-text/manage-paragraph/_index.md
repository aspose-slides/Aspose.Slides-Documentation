---
title: Beheer PowerPoint-tekstalinea's in Python via Java
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingstekens beheren
- alinea-inspringing
- hangende inspringing
- alinea-opsommingsteken
- genummerde lijst
- opsommingslijst
- alinea-eigenschappen
- HTML importeren
- tekst naar HTML
- alinea naar HTML
- alinea naar afbeelding
- tekst naar afbeelding
- alinea exporteren
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u alinea's, porties, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen maakt en opmaakt met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides voor Python via Java vertegenwoordigt tekst als een hiërarchie van tekstframes, alinea's en porties:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) vertegenwoordigt de tekstcontainer in een vorm en biedt toegang tot de alinea‑collectie.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de porties en alinea‑niveau opmaak.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) vertegenwoordigt een tekstdelen binnen een alinea. Elke portie kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan daardoor tekst met verschillende lettertypes, kleuren, groottes en andere opmaak bevatten door meerdere porties te gebruiken.

## **Alinea's maken en opmaken**

Maak alinea's in het tekstframe van een vorm en gebruik porties om individuele tekstdelen op te maken. Deze sectie laat zien hoe je meerdere porties binnen elke alinea combineert en verschillende kleuren, lettergroottes en stijlen toepast.

### **Alinea's maken met meerdere porties**

Het volgende Python‑voorbeeld maakt drie alinea's, elk met drie tekstdelen in de collectie die wordt geretourneerd door [Paragraph.getPortions](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getPortions). Het hergebruikt de standaard alinea en zijn lege portie, en voegt vervolgens de resterende alinea's en porties toe. Opmaak wordt toegepast via [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat): de eerste portie in elke alinea is rood, vet en 15 punten; de tweede is blauw, cursief en 18 punten. De derde portie behoudt de standaardopmaak:

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

## **Genummerde en opsommingstekst lijsten maken**

Organiseer alinea‑tekst in lijsten met symbolen, cijfers of aangepaste afbeeldingen. De voorbeelden in deze sectie behandelen opsommingsteken‑opmaak, meerlagige lijsten en aangepaste startnummers.

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/).

Dit Python‑voorbeeld voegt een symbool‑opsommingsteken en een genummerd item toe aan hetzelfde tekstframe. [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) selecteert het type opsommingsteken, terwijl [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) het symbool levert en [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) de nummeringsstijl kiest. Beide items gebruiken zwarte opsommingstekens met een hoogte van 100 % en een alinea‑inspringing van 25 punten:

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

### **Afbeeldings‑opsommingstekens gebruiken**

Afbeeldings‑opsommingstekens laten je een aangepaste afbeelding gebruiken i.p.v. een symbool of cijfer.

Dit Python‑voorbeeld voegt een afbeelding toe aan de presentatie‑afbeeldingscollectie als een [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) en gebruikt deze als alinea‑opsommingsteken. Het roept [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) aan om een afbeeldings‑opsommingsteken te gebruiken en kent de afbeelding toe via [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture). [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) wordt ingesteld op 100 % om het opsommingsteken te schalen ten opzichte van de alinea‑tekst:

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

### **Een meerlagige lijst maken**

Stel [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het hoogste niveau heeft een diepte van `0`.

Dit Python‑voorbeeld kent [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) waarden van 0 tot 3 toe aan vier alinea's, waardoor er een hiërarchie ontstaat binnen één tekstframe. Elke alinea gebruikt een symbool‑opsommingsteken, waarbij [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) afwisselt tussen een ronde opsommingsteken en een streepje om aangrenzende niveaus te onderscheiden:

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

### **Genummerde lijstitems beginnen met aangepaste waarden**

Gebruik [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) om het initiële nummer in te stellen dat wordt weergegeven voor een genummerde alinea.

Dit Python‑voorbeeld stelt [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) in om nummering te gebruiken voor drie alinea's en kent [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) waarden 2, 3 en 7 toe. De startwaarde wordt afzonderlijk voor elke alinea geconfigureerd, waardoor de weergegeven nummers kunnen overslaan:

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

## **Alinea‑indeling en eind‑eigenschappen regelen**

Pas alinea‑marges en inspringingen aan om de positie van de eerste regel en ingesprongen regels te regelen. Je kunt ook het einde‑teken van de alinea apart opmaken van de zichtbare tekstporties.

### **Een eerste‑regel‑inspringing instellen**

Gebruik de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent)‑methode om de eerste‑regel‑inspringing van een alinea te regelen. Deze instelling verplaatst alleen de eerste regel ten opzichte van de linker‑marge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑body.

Gebruik [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) wanneer je de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) wanneer je alleen de eerste regel wilt verplaatsen.

Het volgende voorbeeld geeft drie alinea's dezelfde [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) van 20 punten en [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) waarden van 0, 20 en 40 punten. De eerste regels beginnen steeds verder naar rechts, terwijl ingesprongen regels dezelfde linker‑marge behouden:

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

Het resultaat:

![De eerste‑regel‑inspringing van de alinea's](first_line_indent.png)

### **Een hangende inspringing instellen**

Een hangende inspringing is een alinea‑indeling waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëer je dit effect met de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent)‑eigenschap. Stel `Indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑body.

In de praktijk definieert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) de linkse positie van de alinea‑body, en [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te maken, stel je een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, glossarium‑items en andere alinea's waarbij ingesprongen regels onder de alinea‑body uitgelijnd moeten worden in plaats van onder het eerste teken van de eerste regel.

Het volgende Python‑voorbeeld combineert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) waarden van 40 en 60 punten met [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) waarden van -20 en -30 punten. In elke alinea begint de eerste regel links van de ingesprongen regels; de tweede alinea heeft een diepere hangende inspringing:

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

Het resultaat:

![De hangende inspringing van de alinea's](hanging_indent.png)

### **Einde‑alinea‑run‑eigenschappen instellen**

De [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat)‑methode regelt de opmaak van het alinea‑eindteken. Het volgende voorbeeld maakt een [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) met [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) ingesteld op 48 punten en [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) ingesteld op Times New Roman. Het wijst dit formaat toe aan het einde‑teken van de tweede alinea, terwijl de zichtbare tekstporties ongewijzigd blijven:

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

## **Gerapporteerde regels tellen**

Voor alinea‑regels die automatische regelafbreking en interpunctie aan het einde van regels beïnvloeden, zie [Control Line Breaking](/slides/nl/python-java/text-formatting/#control-line-breaking) en [Control Hanging Punctuation](/slides/nl/python-java/text-formatting/#control-hanging-punctuation).

Gebruik [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) om het aantal regels te tellen dat een alinea inneemt na tekstindeling, inclusief automatische regelafbreking. Dit is nuttig bij het controleren van tekstarme en indeling in presentatie‑sjablonen.

Een alinea is één item in [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs), en kan meerdere gerapporteerde regels beslaan. Een expliciete regelafbreking binnen een alinea dwingt een nieuwe regel zonder een extra alinea te maken. Automatische afbreking creëert regels op basis van de beschikbare breedte zonder expliciete regelafbrekingen in de tekst in te voegen. Het tellen van alinea's of regel‑breek‑tekens geeft daarom niet het gerapporteerde regel‑aantal.

Het volgende voorbeeld maakt een tekstvorm, telt de regels, verkleint de vorm, en vervangt daarna de tekst door een kortere tekenreeks. Het voorbeeld schakelt afbreking in via [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) en schakelt autofit uit via [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) zodat de vormbreedte de afbreking bepaalt zonder de tekst automatisch te verkleinen of de vorm te schalen. Elke meting gebruikt [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount). Vormafmetingen zijn in punten. Ten slotte voegt het voorbeeld een extra alinea toe en telt de regel‑aantallen van alle alinea's bij elkaar op.

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

Met deze tekst en deze afmetingen leidt het verkleinen van de vorm tot meer regels, terwijl het vervangen van de tekst door de korte tekenreeks het aantal vermindert. Exacte aantallen kunnen variëren afhankelijk van de beschikbare lettertypes en substitutie, lettergrootte, marges, inspringing, afbreking en autofit‑instellingen. Gebruik de lettertypes en indelingsinstellingen die bedoeld zijn voor de doelomgeving bij het controleren van een sjabloon.

Het aantal regels alleen bepaalt niet of tekst buiten de container loopt. De beschikbare hoogte, regelhoogtes, alinea‑ en regel‑afstand en autofit‑gedrag zijn eveneens van belang; zelfs één regel kan de beschikbare breedte overschrijden wanneer afbreking is uitgeschakeld.

## **Alinea‑inhoud importeren en exporteren**

Gebruik HTML om tekst in een presentatie te brengen of om bestaande alinea's te exporteren voor gebruik elders. Deze sectie laat ook zien hoe je individuele alinea's als afbeeldingen rendert, inclusief alinea's in tabelcellen.

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) om HTML‑markering om te zetten in alinea's en porties in een tekstframe.

Dit Python‑voorbeeld leest HTML uit een bestand en geeft de markering door aan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml). Het wist de standaard alinea van het tekstframe zodat het frame alleen de geïmporteerde inhoud bevat. De rechthoekige vorm laat een marge van 10 punten aan elke kant van de dia zitten:

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

### **Alinea‑tekst naar HTML exporteren**

Gebruik [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) om een geselecteerd bereik alinea's als HTML te exporteren. Wanneer je presentatietekst opnieuw gebruikt op een website, wil je mogelijk de lokale nadruk behouden zonder de lettertype‑, grootte‑ of tekstvak‑stijlen van de presentatie over te nemen. Stel [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) in om te bepalen hoe ver de exporteur de opmaak‑erfenis volgt.

Download [de voorbeeldpresentatie](text-inheritance.pptx) en plaats deze in de werkmap van de applicatie. De eerste dia bevat één tekstvorm met de tekst “Inherited text; explicit red 18pt”. De invoer gebruikt opzettelijk verschillende opmaakniveaus:

- De standaardtekenstijl van de presentatie levert Calibri en een grootte van 28 pt.
- De eerste‑niveau tekenstijl van het tekstframe levert blauwe tekst en cursief.
- De alinea zet vetgedrukte tekst expliciet.
- De tweede portie, “explicit red 18pt”, zet rode tekst en een grootte van 18 pt expliciet.

Het volgende volledige voorbeeld exporteert dezelfde alinea's drie keer. Het geeft [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/) door aan de export‑methode en schrijft elk resultaat naar een apart UTF‑8 HTML‑bestand:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, TextInheritanceLimit, TextToHtmlConversionOptions

presentation = Presentation("text-inheritance.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_frame = shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            
            modes = [TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly]
            file_names = ["All.html", "TextBox.html", "ParagraphOnly.html"]

            for mode, file_name in zip(modes, file_names):
                options = TextToHtmlConversionOptions()
                options.setTextInheritanceLimit(mode)

                html = paragraphs.exportToHtml(0, paragraphs.getCount(), options)
                try:
                    Path(file_name).write_text(str(html), encoding="utf-8")
                except OSError as exception:
                    print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

De gegenereerde HTML bevat de volgende CSS voor de eerste portie, “Inherited text; ”. De tabel toont de relevante declaraties; andere gegenereerde eigenschappen zijn weggelaten voor de duidelijkheid.

| Output | Relevante CSS voor de eerste portie | Uiterlijk |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blauwe, vetgedrukte, cursieve tekst op 28 pt in Calibri, als dat lettertype beschikbaar is. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blauwe, vetgedrukte, cursieve tekst; de omringende pagina of browser levert lettertype en grootte. |
| `ParagraphOnly.html` | `font-weight:bold` | Vetgedrukte tekst; de omringende pagina of browser levert lettertype, grootte, kleur en cursieve stijl. |

De tweede portie behoudt `color:#ff0000`, `font-size:18pt` en `font-weight:bold` in alle drie de uitvoerbestanden. Het behoudt ook cursief in `All` en `TextBox`, maar niet in `ParagraphOnly`. Beperking van de erfenis verwijdert daarom niet de expliciet aan een alinea of portie toegekende opmaak.

Open de bestanden in dezelfde browser om ze te vergelijken. In de twee beperkte modi worden weggelaten CSS‑eigenschappen opgehaald uit de stijlen van de bestemmingspagina of uit de browser‑standaardinstellingen, waardoor de uiteindelijke weergave afhankelijk is van waar de HTML wordt gebruikt.

### **Een alinea als afbeelding renderen**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) rendert een individuele alinea direct en retourneert een afbeeldingobject. Sla het resultaat op naar een bestand of stream met de `save`‑methode. Je hoeft de omvattende vorm niet te renderen of een bitmap handmatig bij te snijden.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) kan `None` retourneren als de alinea niet wordt gevonden in de bovenliggende collectie, geen geldige render‑grenzen heeft, of niet kan worden gerenderd. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding vrij na gebruik.

#### **Een alinea renderen op de standaard schaal**

Het voorbeeld gebruikt een presentatie met één dia waarvan de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld selecteert de tweede alinea op index 1 en roept [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) aan zonder schaal‑parameters. Het controleert dat de vorm de vereiste alinea bevat en dat de render een afbeelding teruggeeft voordat de `save`‑methode wordt aangeroepen om deze in PNG‑formaat op te slaan. Het `finally`‑blok maakt de afbeelding vrij na gebruik.

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

Het resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

#### **Een alinea in een tabelcel renderen met schaling**

Gebruik de [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) overload die `scale_x` en `scale_y` parameters accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op twee keer de standaard breedte en hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren levert een afbeelding waarvan breedte en hoogte ongeveer twee keer de standaardafmetingen zijn, wat vier keer zoveel pixels oplevert. Grotere factoren geven doorgaans scherpere tekst bij inzoomen of hoge‑resolutie‑output, maar verhogen tevens het geheugenverbruik en de bestandsgrootte. Factoren onder `1` produceren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Het renderen van een volledige vorm met [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding van alleen de alinea, gebruik [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/).

## **FAQ**

**Kan ik het automatisch afbreken van tekst binnen een tekstframe volledig uitschakelen?**

Ja. Stel [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) in om afbreken uit te schakelen zodat regels niet bij de randen van het tekstframe worden afgebroken.

**Hoe krijg ik de exacte positie‑op‑dia van een specifieke alinea?**

Gebruik [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) om de begrenzende rechthoek van de alinea op te halen. [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) levert de grenzen van een individuele portie.

**Waar wordt de alineauitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) is een alineaniveau‑instelling en wordt toegepast op de gehele alinea, ongeacht de opmaak van individuele porties.

Om porties met verschillende lettergroottes verticaal uit te lijnen binnen elke regel, zie [Align Fonts Within a Line](/slides/nl/python-java/text-formatting/#align-fonts-within-a-line).

**Kan ik de spellings‑taal instellen voor een deel van een alinea?**

Ja. Stel [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) in voor individuele porties, zodat één alinea tekst in meerdere talen kan bevatten.