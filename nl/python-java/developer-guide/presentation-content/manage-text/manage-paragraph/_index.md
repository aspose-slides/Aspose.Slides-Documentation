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
  - alinea opsommingsteken
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
description: "Leer hoe u alinea's, gedeeltes, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen kunt maken en opmaken met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides for Python via Java vertegenwoordigt tekst als een hiërarchie van tekstframes, alinea's en gedeeltes:

* [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) vertegenwoordigt de tekstopslag in een vorm en biedt toegang tot de alinea‑collectie.
* [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de gedeeltes en alinea‑niveau opmaak.
* [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) vertegenwoordigt een tekstrun binnen een alinea. Elk gedeelte kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan daardoor tekst met verschillende lettertypes, kleuren, groottes en andere opmaak bevatten door meerdere gedeeltes te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere gedeeltes**

De volgende stappen maken een tekstframe met drie alinea's, elk met drie gedeeltes:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/).
2. Toegang tot de gewenste dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaardalinea en voeg twee extra [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/)‑objecten toe aan het tekstframe.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/)‑objecten toe zodat elke alinea drie gedeeltes bevat. De standaardalinea bevat al één lege gedeelte.
7. Stel de tekst van elk gedeelte in.
8. Pas teken‑niveau opmaak toe via [Portion.getPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getPortionFormat).
9. Sla de gewijzigde presentatie op.

Dit Python‑voorbeeld implementeert de stappen:

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

## **Nummer- en bulletlijsten maken**

### **Een bullet‑ of genummerde lijst maken**

Bullet‑punten en nummering maken verwante items makkelijker te scannen. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Toegang tot de gewenste dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaardalinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) voor een symbool‑bullet.
7. Stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bullettype/#Symbol) en specificeer het bullet‑teken.
8. Stel de alinea‑tekst, inspringing, bullet‑kleur en bullet‑hoogte in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bullettype/#Numbered).
11. Configureer de genummerde bullet‑stijl en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

Dit Python‑voorbeeld maakt een symbool‑bullet en een genummerde bullet:

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

### **Afbeeldings‑bullets gebruiken**

Afbeeldings‑bullets laten je een eigen afbeelding gebruiken in plaats van een symbool of nummer.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Toegang tot de gewenste dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe en krijg toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/).
4. Verwijder de standaardalinea uit het tekstframe.
5. Laad de bullet‑afbeelding en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [PPImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bullettype/#Picture).
8. Koppel de afbeelding via [BulletFormat.getPicture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#getPicture) en stel de bullet‑hoogte in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

Dit Python‑voorbeeld maakt een afbeeldings‑bullet:

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

Stel [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setDepth) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) en krijg een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe en verwijder de standaardalinea uit het tekstframe.
3. Maak vier alinea's en configureer hun bullet‑symbolen.
4. Stel hun [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setDepth) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit Python‑voorbeeld maakt een vierlagige bullet‑lijst:

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

Gebruik [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) om het startnummer voor een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaardalinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) in op `2`, `3` en `7` voor de respectieve alinea's.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit Python‑voorbeeld kent een aangepast startnummer toe aan elke alinea:

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

## **Alinea‑lay‑out en eind‑eigenschappen regelen**

### **Eerste‑regel‑inspringing instellen**

Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) om de eerste‑regel‑inspringing van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met het alinea‑lichaam.

Gebruik [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginLeft) wanneer je de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) wanneer je alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt verschillende alinea's en past verschillende [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) waarden toe om te laten zien hoe de eerste‑regel‑inspringing de alinea‑lay‑out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Toegang tot de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
5. Maak verschillende alinea's en stel verschillende [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) waarden in voor hen.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

Deze code toont hoe je een alinea‑inspringing instelt:

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

### **Hangende inspringing instellen**

Een hangende inspringing is een alinea‑lay‑out waarbij de eerste regel links begint ten opzichte van de overige regels. In Aspose.Slides maak je dit effect met [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent). Geef een negatieve waarde op om de eerste regel naar links te verplaatsen ten opzichte van het alinea‑lichaam.

In de praktijk definieert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginLeft) de linkerpositie van het alinea‑lichaam, en [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) definieert de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te creëren, geef je een positieve waarde aan [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginLeft) en een negatieve waarde aan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent).

Deze opmaak is nuttig voor bibliografieën, referenties, begrippenlijsten en andere alinea's waarbij de regelafbrekingen onder het alinea‑lichaam moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Toegang tot de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
5. Maak alinea's en geef een positieve waarde door aan [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginLeft) voor elke alinea.
6. Geef een negatieve waarde door aan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) om het hangende‑inspringing‑effect te creëren.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

Deze code toont hoe je een hangende inspringing voor een alinea instelt:

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

### **Eind‑alinea‑run‑eigenschappen instellen**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) beheert de opmaak van het einde‑teken van een alinea. Het volgende voorbeeld kent een lettertype‑grootte en een Latijns lettertype toe aan het einde‑teken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) en krijg een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe en verwijder de standaardalinea.
3. Maak twee alinea's en voeg tekstgedeeltes toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/) voor het einde‑teken van de tweede alinea.
5. Stel [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setFontHeight) en [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLatinFont) in.
6. Ken het formaat toe met [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) en sla de presentatie op.

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

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphcollection/#addFromHtml) om HTML‑markup om te zetten in alinea's en gedeeltes in een tekstframe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Toegang tot een dia en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe.
3. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Sla de gewijzigde presentatie op.

Dit Python‑voorbeeld importeert HTML in een tekstframe:

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

### **Alinea‑tekst exporteren naar HTML**

Gebruik [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphcollection/#exportToHtml) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Toegang tot de dia en vind de [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) die de tekst bevat.
3. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) van de vorm.
4. Roep [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphcollection/#exportToHtml) aan met de start‑alinea‑index en het aantal alinea's dat geëxporteerd moet worden.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit Python‑voorbeeld exporteert alle alinea's van de eerste tekstvorm:

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

### **Een alinea renderen als afbeelding**

[Paragraph.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) rendert een individuele alinea direct en retourneert een afbeelding‑object. Sla het resultaat op naar een bestand of stream met de `save`‑methode. Het is niet nodig om de omvattende vorm te renderen of handmatig een bitmap bij te snijden.

[Paragraph.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) kan `None` retourneren als de alinea niet in de bovenliggende collectie gevonden wordt, geen geldige render‑grenzen heeft, of niet gerenderd kan worden. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding vrij na gebruik.

#### **Een alinea renderen op de standaard schaal**

Laten we aannemen dat we een presentatiedocument hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is dat drie alinea's bevat.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een gewone tekstvorm op de standaard schaal en slaat de geretourneerde afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

#### **Een alinea renderen in een tabelcel met schaal**

Gebruik de [Paragraph.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) overload die `scale_x` en `scale_y` parameters accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op twee keer de standaard breedte en hoogte, en slaat het resultaat op als een PNG‑afbeelding.

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

Een schaalfactor van `1` houdt die as op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan breedte en hoogte ongeveer twee keer de standaardafmetingen zijn, wat resulteert in vier keer zoveel pixels. Grotere factoren geven doorgaans scherpere tekst voor zoomen of hoge resolutie uitvoer, maar ze verhogen ook het geheugengebruik en de bestandsgrootte. Factoren onder `1` produceren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de uitvoer onafhankelijk uit.

Het renderen van een gehele vorm met [Shape.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) blijft nuttig wanneer de uitvoer de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding die alleen een alinea bevat, gebruik [Paragraph.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/).

## **FAQ**

**Kan ik het regelomloop volledig uitschakelen binnen een tekstframe?**

Ja. Stel [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setWrapText) in om afbreken uit te schakelen zodat regels niet breken aan de randen van het tekstframe.

**Hoe kan ik de exacte afmetingen op de dia van een specifieke alinea verkrijgen?**

Gebruik [Paragraph.getRect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#getRect) om het begrenzingsrechthoek van de alinea op te halen. [Portion.getRect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getRect) geeft de grenzen van een individueel gedeelte.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setAlignment) is een instelling op alinea‑niveau en wordt toegepast op de hele alinea, ongeacht de opmaak van individuele gedeeltes.

**Kan ik de proefleestaal instellen voor een deel van een alinea?**

Ja. Stel [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) in voor individuele gedeeltes, zodat één alinea tekst in meerdere talen kan bevatten.