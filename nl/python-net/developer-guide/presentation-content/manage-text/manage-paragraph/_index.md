---
title: "Beheer PowerPoint-tekstalinea's in Python"
linktitle: "Alinea beheren"
type: docs
weight: 40
url: /nl/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingsteken beheren
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
- Aspose.Slides
description: "Leer hoe u alinea's, delen, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen kunt maken en opmaken met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET vertegenwoordigt tekst als een hiërarchie van tekstframes, alinea's en delen:

* [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) vertegenwoordigt de tekstcontainer in een vorm en biedt toegang tot de verzameling alinea's.
* [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot zijn delen en de opmaak op alinea‑niveau.
* [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) vertegenwoordigt een tekstdeel binnen een alinea. Elke deel kan zijn eigen tekst en tekenopmaak hebben.

Een alinea kan dus tekst met verschillende lettertypes, kleuren, groottes en andere opmaak bevatten door meerdere delen te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere delen**

De volgende stappen maken een tekstframe met drie alinea's, elk met drie delen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de relevante dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaard alinea en voeg twee extra [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) objecten toe aan het tekstframe.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) objecten toe zodat elke alinea drie delen bevat. De standaard alinea bevat al één lege deel.
7. Stel de tekst van elk deel in.
8. Pas tekenopmaak toe via [Portion.portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/portion_format/).
9. Sla de gewijzigde presentatie op.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Lijsten met opsommingstekens en nummering maken**

### **Maak een lijst met opsommingstekens of genummerd**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de relevante dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaard alinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) voor een symboolopsomming.
7. Stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.SYMBOL](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/) en specificeer het opsommingsteken.
8. Stel de alinea‑tekst, inspringing, kleur van het opsommingsteken en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.NUMBERED](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/).
11. Configureer de stijl van de genummerde opsomming en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Afbeeldingsopsommingstekens gebruiken**

Afbeeldingsopsommingstekens laten u een aangepaste afbeelding gebruiken in plaats van een symbool of getal.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de relevante dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
4. Verwijder de standaard alinea uit het tekstframe.
5. Laad de opsommingafbeelding en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.PICTURE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/).
8. Wijs de afbeelding toe via [BulletFormat.picture](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/picture/) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Een meerlagige lijst maken**

Stel [ParagraphFormat.depth](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/depth/) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het hoogste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en verwijder de standaard alinea uit het tekstframe.
3. Maak vier alinea's en configureer hun opsommingstekens.
4. Stel hun [ParagraphFormat.depth](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/depth/) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Genummerde lijstitems starten met aangepaste waarden**

Gebruik [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) om het beginnummer in te stellen dat wordt weergegeven voor een genummerde alinea.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaard alinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) in op `2`, `3` en `7` voor de respectieve alinea's.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Lay-out en eind‑eigenschappen van alinea's beheren**

### **Een eerste‑regel inspringing instellen**

Gebruik de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) om de eerste‑regel inspringing van een alinea te regelen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) wanneer u de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt meerdere alinea's en past verschillende [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) waarden toe om te laten zien hoe de eerste‑regel inspringing de alinea‑lay-out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's en stel verschillende [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) waarden in.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De eerste‑regel inspringing van de alinea's](first_line_indent.png)

### **Een hangende inspringing instellen**

Een hangende inspringing is een alinea‑lay-out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëert u dit effect met de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/). Stel `indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk definieert [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) de linkse positie van de alinea‑inhoud, en [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) definieert de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te creëren, stelt u een positieve `margin_left` waarde in en een negatieve `indent` waarde.

Deze opmaak is nuttig voor bibliografieën, referenties, begrippenlijsten en andere alinea's waarbij omgebroken regels onder de alinea‑inhoud moeten uitgelijnd worden in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak alinea's en stel een positieve [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) waarde in voor elke alinea.
6. Stel een negatieve [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) waarde in om het hangende inspringingseffect te creëren.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De hangende inspringing van de alinea's](hanging_indent.png)

### **Eind‑run‑eigenschappen van alinea instellen**

De eigenschap [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) regelt de opmaak van het eindteken van een alinea. Het volgende voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het eindteken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en verwijder de standaard alinea.
3. Maak twee alinea's en voeg tekstdelen toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/) voor het eindteken van de tweede alinea.
5. Stel [PortionFormat.font_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/font_height/) en [PortionFormat.latin_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/latin_font/) in.
6. Wijs de opmaak toe aan [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) en sla de presentatie op.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenderde regels tellen**

Voor alinea‑regels die automatisch afbreken en interpunctie aan het einde van regels beïnvloeden, zie [Control Line Breaking](/slides/nl/python-net/text-formatting/#control-line-breaking) en [Control Hanging Punctuation](/slides/nl/python-net/text-formatting/#control-hanging-punctuation).

Gebruik [Paragraph.get_lines_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/get_lines_count/) om het aantal regels te tellen dat een alinea inneemt na tekstlay-out, inclusief automatisch afbreken. Dit is nuttig bij het controleren van de tekstlengte en lay-out in presentatiesjablonen.

Een alinea is één item in [TextFrame.paragraphs](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/paragraphs/), en kan meerdere gerenderde regels innemen. Een expliciete regelafbreking binnen een alinea dwingt een nieuwe regel af zonder een extra alinea te creëren. Automatisch afbreken creëert regels op basis van de beschikbare breedte zonder expliciete regelafbrekingen in de tekst in te voegen. Het tellen van alinea's of regelafbrekings‑tekens geeft daarom niet het aantal gerenderde regels.

Het volgende voorbeeld maakt een tekstopmaak, telt de regels, vernauwt de vorm, en vervangt vervolgens de tekst door een kortere tekenreeks. Afbreken is ingeschakeld en automatisch aanpassen is uitgeschakeld zodat de breedte van de vorm het afbreken regelt zonder de tekst automatisch te verkleinen of de vorm te schalen. De afmetingen van de vorm zijn in punten. Ten slotte voegt het voorbeeld een extra alinea toe en telt de regelaantallen van het gehele tekstframe op.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Met deze tekst en afmetingen verhoogt het vernauwen van de vorm het aantal regels, terwijl het vervangen van de tekst door de korte tekenreeks het aantal verlaagt. Exacte aantallen kunnen variëren afhankelijk van de beschikbaarheid en vervanging van lettertypen, lettergrootte, marges, inspringing, afbreken en automatisch‑aanpassingsinstellingen. Gebruik de lettertypen en lay‑outinstellingen die voor de doelomgeving bedoeld zijn bij het controleren van een sjabloon.

Het aantal regels alleen bepaalt niet of de tekst buiten zijn container stroomt. De beschikbare hoogte, regelhoogtes, alinea‑ en regel‑afstand, en het gedrag van automatisch aanpassen spelen ook een rol; zelfs een enkele regel kan de beschikbare breedte overschrijden wanneer afbreken is uitgeschakeld.

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/add_from_html/) om HTML‑opmaak om te zetten in alinea's en delen in een tekstframe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open een dia en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe.
3. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Sla de gewijzigde presentatie op.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Alinea‑tekst exporteren naar HTML**

Gebruik [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/export_to_html/) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Open de dia en zoek de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) die de tekst bevat.
3. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
4. Roep [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/export_to_html/) aan met de start‑alinea‑index en het aantal alinea's dat moet worden geëxporteerd.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Een alinea renderen als afbeelding**

[Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) biedt de `get_image`‑methode om een individuele alinea direct te renderen. De methode retourneert een [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) dat u kunt opslaan naar een bestand of stream met [IImage.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/save/). Het is niet nodig om de omvattende vorm te renderen of een bitmap handmatig bij te snijden.

De `get_image`‑methode kan `None` teruggeven als de alinea niet in de bovenliggende collectie wordt gevonden, geen geldige renderingsgrenzen heeft, of niet kan worden gerenderd. Controleer het resultaat vóór het opslaan en gebruik de geretourneerde afbeelding als context‑manager om de bronnen vrij te geven.

#### **Een alinea renderen op de standaardschaal**

Laten we aannemen dat we een presentatiedocument hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is dat drie alinea's bevat.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een normaal tekstvak op de standaardschaal en slaat de teruggegeven afbeelding op in PNG‑formaat:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Het resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

#### **Een alinea renderen in een tabelcel met schalen**

Geef horizontale en verticale schaalfactoren door aan `get_image` om de grootte van de gerenderde alinea te regelen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op het dubbele van de standaardbreedte en -hoogte, en slaat het resultaat op als een PNG‑afbeelding:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Een schaalfactor van `1` houdt die as op de standaardpixedimensie. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan de breedte en hoogte ongeveer het dubbele zijn van de standaardafmetingen, wat resulteert in vier keer zoveel pixels. Grotere factoren leveren doorgaans scherpere tekst voor inzoomen of high‑resolution output, maar verhogen ook het geheugen‑ en bestandsgroottegebruik. Factoren onder `1` produceren kleinere afbeeldingen met minder details. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Het renderen van een volledige vorm met [Shape.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding met alleen een alinea, gebruik `Paragraph.get_image`.

## **Veelgestelde vragen**

**Kan ik volledig het regelafbreken binnen een tekstframe uitschakelen?**

Ja. Stel [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/wrap_text/) in om afbreken uit te schakelen zodat regels niet afbreken aan de randen van het tekstframe.

**Hoe kan ik de exacte grenzen van een specifieke alinea op de dia verkrijgen?**

Gebruik [Paragraph.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/get_rect/) om de omhullende rechthoek van de alinea op te halen. [Portion.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/get_rect/) geeft de grenzen van een individueel deel.

**Waar wordt de uitlijning van alinea's (links, rechts, gecentreerd of uitgevuld) geregeld?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/alignment/) is een instelling op alinea‑niveau en geldt voor de hele alinea ongeacht de opmaak van individuele delen.

**Kan ik de proefleestaal voor een deel van een alinea instellen?**

Ja. Stel [PortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/) in voor individuele delen, zodat één alinea tekst in meerdere talen kan bevatten.