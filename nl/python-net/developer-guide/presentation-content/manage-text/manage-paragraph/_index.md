---
title: Beheer PowerPoint-tekstalinea's in Python
linktitle: Beheer alinea
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
- opsomming met opsommingstekens
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
description: "Leer hoe je alinea's, delen, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen maakt en opmaakt met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET stelt tekst voor als een hiërarchie van tekstkaders, alinea's en delen:

* [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) vertegenwoordigt de tekstopslag in een vorm en biedt toegang tot de alinea‑verzameling.
* [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstkader en biedt toegang tot de delen en alinea‑opmaak.
* [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) vertegenwoordigt een tekstrun binnen een alinea. Elk deel kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan dus tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere delen te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere delen**

De volgende stappen maken een tekstkader met drie alinea's, elk met drie delen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de betreffende dia via zijn index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaard alinea en voeg nog twee [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) objecten toe aan het tekstkader.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) objecten toe zodat elke alinea drie delen bevat. De standaard alinea bevat al één leeg deel.
7. Stel de tekst van elk deel in.
8. Pas teken‑niveau opmaak toe via [Portion.portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/portion_format/).
9. Sla de aangepaste presentatie op.

Dit Python‑voorbeeld implementeert de stappen:

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

## **Opsommingstekens en genummerde lijsten maken**

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de betreffende dia via zijn index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaard alinea uit het tekstkader.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.SYMBOL](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/) en specificeer het opsommingsteken.
8. Stel de alinea‑tekst, inspringing, kleur en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstkader.
10. Maak een tweede alinea en stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.NUMBERED](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/).
11. Configureer de genummerde opsommingsteken‑stijl en voeg de alinea toe aan het tekstkader.
12. Sla de presentatie op.

Dit Python‑voorbeeld maakt een symbool‑opsommingsteken en een genummerd opsommingsteken:

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

### **Afbeeldings‑opsommingstekens gebruiken**

Afbeeldings‑opsommingstekens laten je een aangepaste afbeelding gebruiken in plaats van een symbool of cijfer.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de betreffende dia via zijn index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en open zijn [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
4. Verwijder de standaard alinea uit het tekstkader.
5. Laad de opsommingsteken‑afbeelding en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.PICTURE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/).
8. Wijs de afbeelding toe via [BulletFormat.picture](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/picture/) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstkader.
10. Sla de aangepaste presentatie op.

Dit Python‑voorbeeld maakt een afbeelding‑opsommingsteken:

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
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en verwijder de standaard alinea uit het tekstkader.
3. Maak vier alinea's en configureer hun opsommingstekens.
4. Stel hun [ParagraphFormat.depth](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/depth/) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstkader en sla de presentatie op.

Dit Python‑voorbeeld maakt een vier‑niveau opsomming:

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

Gebruik [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) om het beginnummer voor een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaard alinea uit het tekstkader van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) in op `2`, `3` en `7` voor de respectieve alinea's.
5. Voeg de alinea's toe aan het tekstkader en sla de presentatie op.

Dit Python‑voorbeeld kent een aangepast startnummer toe aan elke alinea:

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

## **De lay-out en eind‑eigenschappen van alinea's beheren**

### **Eerste‑regel inspringing instellen**

Gebruik de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) om de eerste‑regel inspringing van een alinea te regelen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) wanneer je de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) wanneer je alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt verschillende alinea's en past verschillende [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) waarden toe om te laten zien hoe de eerste‑regel inspringing de lay-out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's en zet verschillende [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) waarden voor hen.
6. Voeg de alinea's toe aan het tekstkader.
7. Sla de aangepaste presentatie op.

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

Resultaat:

![De eerste‑regel inspringing van de alinea's](first_line_indent.png)

### **Hangende inspringing instellen**

Een hangende inspringing is een alinea‑lay-out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëer je dit effect met de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/). Stel `indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk bepaalt [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) de linkermarge van de alinea‑inhoud, en [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te maken, stel je een positieve `margin_left` en een negatieve `indent` in.

Deze opmaak is nuttig voor bibliografieën, referenties, begrippenlijsten en andere alinea's waarbij de omgebroken regels onder de alinea‑inhoud moeten worden uitgelijnd in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak alinea's en stel voor elke alinea een positieve [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) waarde in.
6. Stel een negatieve [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) waarde in om het hangende‑inspringing‑effect te verkrijgen.
7. Voeg de alinea's toe aan het tekstkader.
8. Sla de aangepaste presentatie op.

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

Resultaat:

![De hangende inspringing van de alinea's](hanging_indent.png)

### **Eind‑eigenschappen van alinea‑tekst instellen**

De eigenschap [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) regelt de opmaak van het alinea‑eindteken. Het volgende voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het eindteken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en verwijder de standaard alinea.
3. Maak twee alinea's en voeg tekstdelen toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/) voor het eindteken van de tweede alinea.
5. Stel [PortionFormat.font_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/font_height/) en [PortionFormat.latin_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/latin_font/) in.
6. Koppel de opmaak aan [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) en sla de presentatie op.

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

Gebruik [Paragraph.get_lines_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/get_lines_count/) om het aantal regels te tellen dat een alinea inneemt na de tekst‑lay‑out, inclusief automatische omslag. Dit is handig bij het controleren van tekstlengte en lay‑out in presentatiesjablonen.

Een alinea is één item in [TextFrame.paragraphs](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/paragraphs/), en kan meerdere gerenderde regels innemen. Een expliciete regeleinde‑invoering binnen een alinea dwingt een nieuwe regel zonder een extra alinea te maken. Automatische omslag maakt regels op basis van de beschikbare breedte zonder expliciete regeleinde‑tekens in de tekst te plaatsen. Het tellen van alinea's of regeleinde‑tekens levert daarom niet het aantal gerenderde regels op.

Het volgende voorbeeld maakt een tekstvorm, telt de regels, vernauwt de vorm en vervangt vervolgens de tekst door een kortere string. Ombrenging is ingeschakeld en autofit is uitgeschakeld zodat de vormbreedte de ombraak bepaalt zonder de tekst automatisch te verkleinen of de vorm te herschalen. Vormafmetingen zijn in punten. Ten slotte voegt het voorbeeld nog een alinea toe en somt de regel‑telling op over het tekstkader.

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

Met deze tekst en afmetingen verhoogt het vernauwen van de vorm het aantal regels, terwijl het vervangen van de tekst door de korte string het aantal verlaagt. Exacte aantallen kunnen variëren afhankelijk van beschikbare lettertypen en substitutie, lettergrootte, marges, inspringing, ombrenging en autofit‑instellingen. Gebruik de lettertypen en lay‑outinstellingen die voor de doelomgeving bedoeld zijn bij het testen van een sjabloon.

Het aantal regels alleen bepaalt niet of tekst buiten de container stroomt. De beschikbare hoogte, regelhoogtes, alinea‑ en regel‑afstand en het autofit‑gedrag zijn ook van belang; zelfs één regel kan de beschikbare breedte overschrijden wanneer ombrenging uitgeschakeld is.

## **Paragraafinhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/add_from_html/) om HTML‑opmaak om te zetten in alinea's en delen in een tekstkader.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open een dia en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe.
3. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Sla de aangepaste presentatie op.

Dit Python‑voorbeeld importeert HTML in een tekstkader:

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

### **Alineatekst exporteren naar HTML**

Gebruik [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/export_to_html/) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Open de dia en zoek de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) die de tekst bevat.
3. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
4. Roep [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/export_to_html/) aan met het start‑alinea‑index en het aantal te exporteren alinea's.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit Python‑voorbeeld exporteert alle alinea's van de eerste tekstvorm:

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

[Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) biedt de `get_image`‑methode voor het direct renderen van een individuele alinea. De methode retourneert een [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) die je kunt opslaan naar een bestand of stream met [IImage.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/save/). Je hoeft de omvattende vorm niet te renderen of handmatig een bitmap bij te snijden.

De `get_image`‑methode kan `None` teruggeven als de alinea niet wordt gevonden in de bovenliggende collectie, geen geldige render‑grenzen heeft, of niet gerenderd kan worden. Controleer het resultaat vóór het opslaan en gebruik de geretourneerde afbeelding als context‑manager om de resources vrij te geven.

#### **Een alinea renderen op de standaard schaal**

Stel je voor dat we een presentatiedocument hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is dat drie alinea's bevat.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een reguliere tekstvorm op de standaard schaal en slaat de verkregen afbeelding op in PNG‑formaat:

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

Resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

#### **Een alinea renderen in een tabelcel met schaling**

Geef horizontale en verticale schaalfactoren door aan `get_image` om de grootte van de gerenderde alinea te regelen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op tweemaal de standaard breedte en hoogte, en slaat het resultaat op als PNG‑afbeelding:

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

Een schaalfactor van `1` behoudt die as op de standaard pixeldimensie. Bijvoorbeeld `2` voor beide factoren levert een afbeelding op waarvan breedte en hoogte ongeveer twee keer de standaard afmetingen zijn, wat vier keer zoveel pixels oplevert. Grotere factoren geven doorgaans scherpere tekst voor inzoomen of hoge‑resolutie‑output, maar verhogen ook het geheugengebruik en de bestandsgrootte. Factoren onder `1` geven kleinere afbeeldingen met minder details. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Het renderen van een hele vorm met [Shape.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding die uitsluitend de alinea bevat, gebruik je `Paragraph.get_image`.

## **FAQ**

**Kan ik volledige regelomslag binnen een tekstkader uitschakelen?**

Ja. Stel [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/wrap_text/) in om omslag uit te schakelen zodat regels niet bij de randen van het tekstkader afbreken.

**Hoe kan ik de exacte on‑slide grenzen van een specifieke alinea krijgen?**

Gebruik [Paragraph.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/get_rect/) om het begrenzende rechthoek van de alinea op te halen. [Portion.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/get_rect/) geeft de grenzen van een afzonderlijk deel.

**Waar wordt de alinealijnuitlijning (links, rechts, gecentreerd of uitvullen) geregeld?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/alignment/) is een alinea‑niveau instelling en wordt toegepast op de volledige alinea, ongeacht de opmaak van individuele delen.

**Kan ik de proefleestaal voor een deel van een alinea instellen?**

Ja. Stel [PortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/) in voor afzonderlijke delen, zodat één alinea tekst in meerdere talen kan bevatten.