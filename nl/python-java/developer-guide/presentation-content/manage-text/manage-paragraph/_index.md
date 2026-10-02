---
title: "Beheer PowerPoint-tekstalinea's in Python via Java"
linktitle: "Beheer alinea"
type: docs
weight: 40
url: /nl/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- "tekst toevoegen"
- "alinea toevoegen"
- "tekst beheren"
- "alinea beheren"
- "opsommingsteken beheren"
- "alinea‑inspringing"
- "hangende inspringing"
- "alinea‑opsommingsteken"
- "genummerde lijst"
- "opsomming met opsommingstekens"
- "alinea‑eigenschappen"
- "HTML importeren"
- "tekst naar HTML"
- "alinea naar HTML"
- "alinea naar afbeelding"
- "tekst naar afbeelding"
- "alinea exporteren"
- "PowerPoint"
- "presentatie"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Leer hoe u alinea's, fragmenten, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea‑afbeeldingen kunt maken en opmaken met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides voor Python via Java stelt tekst voor als een hiërarchie van tekstframes, alinea's en fragmenten:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) vertegenwoordigt de tekstcontainer in een vorm en biedt toegang tot de alinea-collectie.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de fragmenten en op alinea-niveau opmaak.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) vertegenwoordigt een tekstreeks binnen een alinea. Elk fragment kan zijn eigen tekst en teken-niveau opmaak hebben.

Een alinea kan daardoor tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere fragmenten te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere fragmenten**

De volgende stappen maken een tekstframe met drie alinea's, elk met drie fragmenten:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Open de betreffende dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaard alinea en voeg nog twee [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) objecten toe aan het tekstframe.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) objecten toe zodat elke alinea drie fragmenten bevat. De standaard alinea bevat al één leeg fragment.
7. Stel de tekst van elk fragment in.
8. Pas teken-niveau opmaak toe via [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat).
9. Sla de gewijzigde presentatie op.

This Python example implements the steps:

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

## **Opsommingstekens en genummerde lijsten maken**

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker te scannen. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/).

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Open de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaard alinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) voor een symbool opsommingsteken.
7. Stel [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) en specificeer het opsommingsteken.
8. Stel de alinea-tekst, inspringing, opsommingstekstkleur en -hoogte in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered).
11. Configureer de genummerde opsommingstekenstijl en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

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

### **Afbeeldings opsommingstekens gebruiken**

Afbeeldings opsommingstekens laten je een aangepaste afbeelding gebruiken in plaats van een symbool of nummer.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Open de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe en open het [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).
4. Verwijder de standaard alinea uit het tekstframe.
5. Laad de opsommingstekenafbeelding en voeg deze toe aan de beeldverzameling van de presentatie als een [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture).
8. Wijs de afbeelding toe via [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) en stel de opsommingstekenhoogte in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

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

Stel [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe en verwijder de standaard alinea uit het tekstframe.
3. Maak vier alinea's en configureer hun opsommingstekensymbolen.
4. Stel hun [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

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

### **Genummerde lijstitems starten bij aangepaste waarden**

Gebruik [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) om het startnummer in te stellen dat wordt weergegeven voor een genummerde alinea.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaard alinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) in op `2`, `3` en `7` voor de respectieve alinea's.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

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

## **Alinea-indeling en eind-eigenschappen beheren**

### **Eerste-regelinspringing instellen**

Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) om de eerste-regelinspringing van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met het alinea‑lichaam.

Gebruik [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) wanneer je de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) wanneer je alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt meerdere alinea's en past verschillende [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) waarden toe om te laten zien hoe de eerste-regelinspringing de alinea‑indeling beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) klasse.
2. Open de doel-dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak meerdere alinea's en stel verschillende [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) waarden in voor hen.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
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

The result:

![De eerste-regelinspringing van de alinea's](first_line_indent.png)

### **Hangende inspringing instellen**

Een hangende inspringing is een alinea‑indeling waarbij de eerste regel links begint ten opzichte van de overige regels. In Aspose.Slides creëer je dit effect met [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent). Geef een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van het alinea‑lichaam.

In de praktijk definieert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) de linkse positie van het alinea‑lichaam, en definieert [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te maken, geef je een positieve waarde aan [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) en een negatieve waarde aan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent).

Deze opmaak is nuttig voor bibliografieën, referenties, woordenlijstvermeldingen en andere alinea's waarbij ingesprongen regels onder het alinea‑lichaam moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) klasse.
2. Open de doel-dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak alinea's en geef een positieve waarde door aan [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) voor elke alinea.
6. Geef een negatieve waarde door aan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) om het hangende inspringingseffect te creëren.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

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

The result:

![De hangende inspringing van de alinea's](hanging_indent.png)

### **Einde‑alinea‑run‑eigenschappen instellen**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) regelt de opmaak van het alinea‑eindteken. Het onderstaande voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het eindteken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe en verwijder de standaard alinea.
3. Maak twee alinea's en voeg tekstdelen aan hen toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) voor het eindteken van de tweede alinea.
5. Stel [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) en [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) in.
6. Wijs de opmaak toe met [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) en sla de presentatie op.

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

## **Weergegeven regels tellen**

Voor alinea‑regels die automatische tekstomslag en interpunctie aan het einde van regels beïnvloeden, zie [Control Line Breaking](/slides/nl/python-java/text-formatting/#control-line-breaking) en [Control Hanging Punctuation](/slides/nl/python-java/text-formatting/#control-hanging-punctuation).

Gebruik [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) om het aantal regels te tellen dat een alinea inneemt na tekstopmaak, inclusief automatische omslag. Dit is nuttig bij het controleren van de tekstreekslengte en lay-out in presentatiesjablonen.

Een alinea is één item in [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs), en kan meerdere weergeven regels innemen. Een expliciete regeleinde binnen een alinea dwingt een nieuwe regel af zonder een extra alinea te creëren. Automatische omslag maakt regels op basis van de beschikbare breedte zonder expliciete regeleinden in de tekst in te voegen. Het tellen van alinea's of regeleinde‑tekens levert daarom niet het aantal weergeven regels op.

Het onderstaande voorbeeld maakt een tekstvorm, telt de regels, vernauwt de vorm en vervangt vervolgens de tekst door een kortere tekenreeks. Omslag is ingeschakeld en autofit uitgeschakeld zodat de breedte van de vorm de omslag bepaalt zonder automatisch de tekst te verkleinen of de vorm te schalen. Vormafmetingen zijn in punten. Ten slotte voegt het voorbeeld een extra alinea toe en somt de regelaantallen op over het tekstframe.

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

Met deze tekst en deze afmetingen verhoogt het vernauwen van de vorm het aantal regels, terwijl het vervangen van de tekst door de korte tekenreeks het aantal verlaagt. Exacte aantallen kunnen variëren afhankelijk van de beschikbaarheid en vervanging van lettertypen, lettergrootte, marges, inspringing, omslag en autofit‑instellingen. Gebruik de lettertypen en lay‑outinstellingen die bedoeld zijn voor de doelomgeving bij het controleren van een sjabloon.

Het aantal regels op zich bepaalt niet of de tekst buiten zijn container stroomt. De beschikbare hoogte, regelhoogtes, alinea‑ en regelafstand, en autofit‑gedrag zijn ook van belang; zelfs één regel kan de beschikbare breedte overschrijden wanneer omslag is uitgeschakeld.

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) om HTML‑opmaak om te zetten in alinea's en fragmenten in een tekstframe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) klasse.
2. Open een dia en voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe.
3. Open het [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Sla de gewijzigde presentatie op.

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

Gebruik [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Open de dia en zoek de [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) die de tekst bevat.
3. Open het [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) van de vorm.
4. Roep [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) aan met de start‑alinea‑index en het aantal alinea's dat moet worden geëxporteerd.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

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

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) rendert een individuele alinea direct en retourneert een afbeeldingobject. Sla het resultaat op naar een bestand of stream met de `save`‑methode. Het is niet nodig om de omvattende vorm te renderen of een bitmap handmatig bij te snijden.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) kan `None` teruggeven als de alinea niet gevonden kan worden in de bovenliggende collectie, geen geldige render‑grenzen heeft, of niet gerenderd kan worden. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding na gebruik vrij.

#### **Een alinea renderen op de standaard schaal**

Laten we aannemen dat we een presentatiedocument hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is dat drie alinea's bevat.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het onderstaande voorbeeld rendert de tweede alinea in een gewone tekstvorm op de standaard schaal en slaat de geretourneerde afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

![De alinea‑afbeelding](paragraph_to_image_output.png)

#### **Een alinea renderen in een tabelcel met schaalvergroting**

Gebruik de [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) overload die de parameters `scale_x` en `scale_y` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het onderstaande voorbeeld maakt een tabel, rendert de alinea in de eerste cel op het dubbele van de standaard breedte en hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` houdt die as op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan de breedte en hoogte ongeveer het dubbele zijn van de standaard afmetingen, resulterend in vier keer zoveel pixels. Grotere factoren leveren doorgaans scherpere tekst voor inzoomen of hoge‑resolutie‑output, maar ze verhogen ook het geheugenverbruik en de bestandsgrootte. Factoren onder `1` geven kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Het renderen van een volledige vorm met [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding van alleen een alinea, gebruik [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/).

## **FAQ**

**Kan ik tekstomslag volledig uitschakelen in een tekstframe?**

Ja. Stel [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) in om omslag uit te schakelen zodat regels niet afbreken aan de randen van het tekstframe.

**Hoe kan ik de exacte on‑slide grenzen van een specifieke alinea verkrijgen?**

Gebruik [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) om de begrenzende rechthoek van de alinea op te halen. [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) geeft de grenzen van een individueel fragment.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) bepaald?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) is een instelling op alinea‑niveau en wordt toegepast op de gehele alinea, ongeacht de opmaak van individuele fragmenten.

Om porties met verschillende lettergroottes binnen elke regel verticaal uit te lijnen, zie [Align Fonts Within a Line](/slides/nl/python-java/text-formatting/#align-fonts-within-a-line).

**Kan ik de proefleestaal instellen voor een deel van een alinea?**

Ja. Stel [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) in voor individuele fragmenten, zodat één alinea tekst in meerdere talen kan bevatten.