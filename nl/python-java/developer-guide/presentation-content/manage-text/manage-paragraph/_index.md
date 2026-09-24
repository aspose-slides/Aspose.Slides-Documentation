---
title: "PowerPoint-tekstparagrafen beheren in Python via Java"
linktitle: "Paragraaf beheren"
type: docs
weight: 40
url: /nl/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
  - "tekst toevoegen"
  - "paragraaf toevoegen"
  - "tekst beheren"
  - "paragraaf beheren"
  - "opsommingsteken beheren"
  - "paragraafinsprong"
  - "hangende insprong"
  - "paragraaf opsommingsteken"
  - "genummerde lijst"
  - "opsomminglijst"
  - "paragraafeigenschappen"
  - "HTML importeren"
  - "tekst naar HTML"
  - "paragraaf naar HTML"
  - "paragraaf naar afbeelding"
  - "tekst naar afbeelding"
  - "paragraaf exporteren"
  - "PowerPoint"
  - "presentatie"
  - "Python"
  - "Java"
  - "Aspose.Slides"
description: "Leer hoe u paragrafen, gedeelten, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en paragraafafbeeldingen kunt maken en opmaken met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides voor Python via Java stelt tekst voor als een hiërarchie van TextFrames, Paragraphs en Portions:

* [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) vertegenwoordigt de tekstopslag in een shape en biedt toegang tot de verzameling paragraphs.
* [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) vertegenwoordigt één paragraph in een TextFrame en biedt toegang tot de portions en de op paragraph‑niveau formattering.
* [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) vertegenwoordigt een tekstrun binnen een paragraph. Elke Portion kan zijn eigen tekst en op tekenniveau formattering hebben.

Een paragraph kan daarom tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere portions te gebruiken.

## **Paragraphen maken en opmaken**

### **Paragraphen maken met meerdere Portions**

De volgende stappen maken een TextFrame met drie paragraphen, elk met drie portions:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
2. Toegang krijgen tot de relevante slide via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de slide.
4. Toegang krijgen tot de [TextFrame] van de vorm.
5. Gebruik de standaard paragraph en voeg twee extra [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/)‑objecten toe aan het TextFrame.
6. Voeg genoeg [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/)‑objecten toe zodat elke paragraph drie portions bevat. De standaard paragraph bevat al één lege portion.
7. Stel de tekst van elke portion in.
8. Pas op tekenniveau formattering toe via [Portion.getPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getPortionFormat).
9. Sla de gewijzigde presentatie op.

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

Opsommingstekens en nummering maken verwante items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan.
2. Toegang krijgen tot de relevante slide via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de geselecteerde slide.
4. Toegang krijgen tot de [TextFrame] van de vorm.
5. Verwijder de standaard paragraph uit het TextFrame.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) voor een symboolbullet.
7. Stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bullettype/#Symbol) en specificeer het bulletteken.
8. Stel de tekst, inspringing, bulletkleur en bullethoogte van de paragraph in.
9. Voeg de paragraph toe aan het TextFrame.
10. Maak een tweede paragraph en stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bullettype/#Numbered).
11. Configureer de genummerde bulletstijl en voeg de paragraph toe aan het TextFrame.
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

### **Afbeeldingsbullets gebruiken**

Afbeeldingsbullets laten u een aangepaste afbeelding gebruiken in plaats van een symbool of cijfer.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan.
2. Toegang krijgen tot de relevante slide via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe en krijg toegang tot de [TextFrame].
4. Verwijder de standaard paragraph uit het TextFrame.
5. Laad de bulletafbeelding en voeg deze toe aan de afbeeldingenverzameling van de presentatie als een [PPImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bullettype/#Picture).
8. Wijs de afbeelding toe via [BulletFormat.getPicture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#getPicture) en stel de bullethoogte in.
9. Voeg de paragraph toe aan het TextFrame.
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

Stel [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setDepth) in om paragraphen op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) aan en krijg toegang tot een slide.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe en verwijder de standaard paragraph uit het TextFrame.
3. Maak vier paragraphen en configureer hun bullet‑symbolen.
4. Stel hun [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setDepth)-waarden in op `0`, `1`, `2` en `3`.
5. Voeg de paragraphen toe aan het TextFrame en sla de presentatie op.

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

### **Nummering van lijstitems starten met aangepaste waarden**

Gebruik [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) om het startnummer voor een genummerde paragraph in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan een slide.
2. Verwijder de standaard paragraph uit het TextFrame van de vorm.
3. Maak drie genummerde paragraphen.
4. Stel [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) in op `2`, `3` en `7` voor de respectieve paragraphen.
5. Voeg de paragraphen toe aan het TextFrame en sla de presentatie op.

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

## **Paragraphlay-out en eind‑eigenschappen beheren**

### **Een eerste‑lijninsprong instellen**

Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) om de eerste‑lijninsprong van een paragraph te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de paragraph. Een positieve waarde schuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met het paragraph‑lichaam.

Gebruik [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginLeft) wanneer u de gehele paragraph wilt verplaatsen. Gebruik [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt verschillende paragraphen en past verschillende [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent)-waarden toe om te laten zien hoe de eerste‑lijninsprong de lay-out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
2. Toegang krijgen tot de doel‑slide.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de slide.
4. Toegang krijgen tot de [TextFrame] van de vorm en verwijder de standaard paragraph.
5. Maak verschillende paragraphen en stel verschillende [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent)-waarden voor hen in.
6. Voeg de paragraphen toe aan het TextFrame.
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

![De eerste‑lijninsprong van de alinea's](first_line_indent.png)

### **Een hangende insprong instellen**

Een hangende insprong is een paragraph‑lay‑out waarbij de eerste regel links begint ten opzichte van de overige regels. In Aspose.Slides creëert u dit effect met [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent). Geef een negatieve waarde op om de eerste regel naar links te verplaatsen ten opzichte van het paragraph‑lichaam.

In de praktijk definieert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginLeft) de linkse positie van het paragraph‑lichaam, en [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te creëren, geef een positieve waarde op voor [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginLeft) en een negatieve waarde voor [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent).

Deze formattering is nuttig voor bibliografieën, referenties, woordenlijst‑items en andere paragraphen waarbij ingesprongen regels onder het paragraph‑lichaam moeten uitlijnen i.p.v. onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
2. Toegang krijgen tot de doel‑slide.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de slide.
4. Toegang krijgen tot de [TextFrame] van de vorm en verwijder de standaard paragraph.
5. Maak paragraphen en geef een positieve waarde op voor [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginLeft) voor elke paragraph.
6. Geef een negatieve waarde op voor [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setIndent) om het hangende‑insprongeffect te creëren.
7. Voeg de paragraphen toe aan het TextFrame.
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

Het resultaat:

![De hangende insprong van de alinea's](hanging_indent.png)

### **Eind‑paragraph‑run‑eigenschappen instellen**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) beheert de formattering van het eind‑teken van een paragraph. Het volgende voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het eind‑teken van de tweede paragraph:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) en krijg toegang tot een slide.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe en verwijder de standaard paragraph.
3. Maak twee paragraphen en voeg tekst‑portions toe aan hen.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/) voor het eind‑teken van de tweede paragraph.
5. Stel [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setFontHeight) en [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLatinFont) in.
6. Wijs het format toe met [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) en sla de presentatie op.

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

## **Gerenderde regels tellen**

Gebruik [Paragraph.getLinesCount](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#getLinesCount) om het aantal regels te tellen dat een paragraph inneemt na tekst‑lay‑out, inclusief automatisch afbreken. Dit is handig bij het controleren van tekstelengte en lay‑out in presentatiesjablonen.

Een paragraph is één item in [TextFrame.getParagraphs](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getParagraphs), en kan meerdere gerenderde regels bezetten. Een expliciete regeleinde‑invoeging binnen een paragraph dwingt een nieuwe regel af zonder een extra paragraph te maken. Automatisch afbreken genereert regels op basis van de beschikbare breedte zonder expliciete regeleindes in de tekst in te voegen. Het tellen van paragraphen of regeleinde‑tekens geeft daarom niet het gerenderde aantal regels.

Het volgende voorbeeld maakt een tekst‑shape, telt de regels, vernauwt de shape en vervangt daarna de tekst door een kortere string. Afbreken is ingeschakeld en autofit is uitgeschakeld zodat de breedte van de shape het afbreken bepaalt zonder de tekst automatisch te verkleinen of de shape te herschalen. Shape‑dimensies zijn in punten. Ten slotte voegt het voorbeeld een extra paragraph toe en somt de regel‑aantallen op over het TextFrame.

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

Met deze tekst en deze dimensies verhoogt het vernauwen van de shape het aantal regels, terwijl het vervangen van de tekst door de korte string dit vermindert. Precieze aantallen kunnen variëren afhankelijk van de beschikbare lettertypen en substitutie, lettergrootte, marges, inspringing, afbreken en autofit‑instellingen. Gebruik de lettertypen en lay‑out‑instellingen die bedoeld zijn voor de doelsituatie bij het controleren van een sjabloon.

Het aantal regels alleen bepaalt niet of tekst buiten zijn container stroomt. De beschikbare hoogte, regelhoogtes, alinea‑ en regel‑afstand, en autofit‑gedrag zijn ook van belang; zelfs één regel kan de beschikbare breedte overschrijden wanneer afbreken is uitgeschakeld.

## **Paragraphinhoud importeren en exporteren**

### **HTML‑tekst importeren in paragraphen**

Gebruik [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphcollection/#addFromHtml) om HTML‑markup om te zetten in paragraphen en portions in een TextFrame.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan.
2. Toegang krijgen tot een slide en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe.
3. Toegang krijgen tot de [TextFrame] van de vorm en verwijder de standaard paragraph.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphcollection/#addFromHtml).
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

### **Paragraphtekst exporteren naar HTML**

Gebruik [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphcollection/#exportToHtml) om een geselecteerd bereik van paragraphen als HTML te exporteren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan en laad de gewenste presentatie.
2. Toegang krijgen tot de slide en vind de [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) die de tekst bevat.
3. Toegang krijgen tot de [TextFrame] van de vorm.
4. Roep [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphcollection/#exportToHtml) aan met de start‑paragraph‑index en het aantal te exporteren paragraphen.
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

### **Een paragraph renderen als een afbeelding**

[Paragraph.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) rendert een individuele paragraph direct en retourneert een afbeelding‑object. Sla het resultaat op naar een bestand of stream met de `save`‑methode. Het is niet nodig om de omliggende shape te renderen of handmatig een bitmap bij te snijden.

[Paragraph.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) kan `None` retourneren als de paragraph niet in de bovenliggende collectie wordt gevonden, geen geldige render‑grenzen heeft, of niet kan worden gerenderd. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding na gebruik vrij.

#### **Een paragraph renderen op de standaard schaal**

Laten we aannemen dat we een presentatie‑bestand hebben genaamd sample.pptx met één slide, waarbij de eerste shape een tekstvak is dat drie paragraphen bevat.

![Het tekstvak met drie paragraphen](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede paragraph in een reguliere tekst‑shape op de standaard schaal en slaat de geretourneerde afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

![De paragraph‑afbeelding](paragraph_to_image_output.png)

#### **Een paragraph renderen in een tabelcel met schaalvergroting**

Gebruik de overload van [Paragraph.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) die de parameters `scale_x` en `scale_y` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de paragraph in de eerste cel op tweemaal de standaard breedte en hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan breedte en hoogte ongeveer het dubbele zijn van de standaard afmetingen, wat resulteert in vier keer zoveel pixels. Grotere factoren leveren doorgaans scherpere tekst voor zoom of hoge resolutie, maar verhogen ook het geheugen‑ en bestandsgroottegebruik. Factoren onder `1` produceren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de aspect‑ratio van de paragraph te behouden; verschillende horizontale en verticale factoren rekken de uitvoer onafhankelijk uit.

Het renderen van een volledige shape met [Shape.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de shape moet bevatten. Voor een alleen‑paragraph‑afbeelding, gebruik [Paragraph.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/).

## **FAQ**

**Kan ik het regelomloop volledig uitschakelen in een TextFrame?**

Ja. Stel [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setWrapText) in om omspringen uit te schakelen zodat regels niet af breken aan de randen van het TextFrame.

**Hoe kan ik de exacte on‑slide grenzen van een specifieke paragraph verkrijgen?**

Gebruik [Paragraph.getRect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#getRect) om de omhullende rechthoek van de paragraph op te halen. [Portion.getRect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getRect) geeft de grenzen van een individuele portion.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setAlignment) is een instelling op paragraph‑niveau en wordt toegepast op de volledige paragraph, ongeacht de formattering van individuele portions.

**Kan ik de taalcontrole voor een deel van een paragraph instellen?**

Ja. Stel [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) in voor individuele portions, zodat één paragraph tekst in meerdere talen kan bevatten.