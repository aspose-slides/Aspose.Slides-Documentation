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
- opsomming beheren
- alinea-inspringing
- hangende inspringing
- alinea-opsomming
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
description: "Leer hoe u alinea's, delen, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen maakt en opmaakt met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides voor Python via .NET stelt tekst voor als een hiërarchie van tekstkaders, alinea's en delen:

* [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) vertegenwoordigt de tekstdeler in een vorm en biedt toegang tot de alinea‑verzameling.
* [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstkader en biedt toegang tot de delen en de alinea‑niveau opmaak.
* [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) vertegenwoordigt een tekstreeks binnen een alinea. Elk deel kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan daardoor tekst met verschillende lettertypen, kleuren, groottes en andere opmaak bevatten door meerdere delen te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere delen**

De volgende stappen maken een tekstkader met drie alinea's, elk met drie delen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
2. Benader de gewenste dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Benader het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaardalinea en voeg twee extra [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) objecten toe aan het tekstkader.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) objecten toe zodat elke alinea drie delen bevat. De standaardalinea bevat al één leeg deel.
7. Stel de tekst van elk deel in.
8. Pas teken‑niveau opmaak toe via [Portion.portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/portion_format/).
9. Sla de gewijzigde presentatie op.

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

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
2. Benader de gewenste dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Benader het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaardalinea uit het tekstkader.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.SYMBOL](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/) en geef het opsommingsteken op.
8. Stel de alinea‑tekst, inspringing, kleur en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstkader.
10. Maak een tweede alinea en stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.NUMBERED](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/).
11. Configureer de stijl van de genummerde opsomming en voeg de alinea toe aan het tekstkader.
12. Sla de presentatie op.

Dit Python‑voorbeeld maakt een symbool‑ en een genummerde opsomming:

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

Afbeeldings‑opsommingstekens laten je een aangepast beeld gebruiken in plaats van een symbool of cijfer.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
2. Benader de gewenste dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en benader het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
4. Verwijder de standaardalinea uit het tekstkader.
5. Laad het opsommingsteken‑beeld en voeg het toe aan de afbeeldingscollectie van de presentatie als een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.PICTURE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/).
8. Wijs de afbeelding toe via [BulletFormat.picture](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/picture/) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstkader.
10. Sla de gewijzigde presentatie op.

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

Stel [ParagraphFormat.depth](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/depth/) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en benader een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en verwijder de standaardalinea uit het tekstkader.
3. Maak vier alinea's en configureer hun opsommingsteken‑symbolen.
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

Gebruik [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) om het beginnummer van een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaardalinea uit het tekstkader van de vorm.
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

## **Alinea‑lay-out en eind‑eigenschappen beheren**

### **Een eerste‑rij‑inspringing instellen**

Gebruik de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) om de eerste‑rij‑inspringing van een alinea te regelen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) als je de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) als je alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt verschillende alinea's en past verschillende [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) waarden toe om te laten zien hoe de eerste‑rij‑inspringing de lay‑out beïnvloedt.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
2. Benader de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Benader het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
5. Maak meerdere alinea's en stel verschillende [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) waarden in.
6. Voeg de alinea's toe aan het tekstkader.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe je een alinea‑inspringing instelt:

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

![De eerste‑rij‑inspringing van de alinea's](first_line_indent.png)

### **Een hangende inspringing instellen**

Een hangende inspringing is een alinea‑lay‑out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides maak je dit effect met de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/). Stel `indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk bepaalt [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) de linkermarge van de alinea‑inhoud, en bepaalt [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) de positie van de eerste regel relatief aan die marge. Voor een hangende inspringing stel je een positieve `margin_left` en een negatieve `indent` in.

Deze opmaak is nuttig voor bibliografieën, referenties, glossarium‑items en andere alinea's waarbij de regels onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
2. Benader de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Benader het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
5. Maak alinea's en stel voor elke alinea een positieve [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) waarde in.
6. Stel een negatieve [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) waarde in om het hangende‑inspringingseffect te creëren.
7. Voeg de alinea's toe aan het tekstkader.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe je een hangende inspringing voor een alinea instelt:

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

### **Einde‑alinea‑run‑eigenschappen instellen**

De eigenschap [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) bepaalt de opmaak van het eind‑teken van een alinea. Het volgende voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het eind‑teken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en benader een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en verwijder de standaardalinea.
3. Maak twee alinea's en voeg tekstreeksen toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/) voor het eind‑teken van de tweede alinea.
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

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/add_from_html/) om HTML‑opmaak om te zetten in alinea's en delen in een tekstkader.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
2. Benader een dia en voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe.
3. Benader het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Sla de gewijzigde presentatie op.

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

### **Alinea‑tekst exporteren naar HTML**

Gebruik [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/export_to_html/) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en laad de gewenste presentatie.
2. Benader de dia en zoek de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) die de tekst bevat.
3. Benader het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
4. Roep [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphcollection/export_to_html/) aan met de start‑alinea‑index en het aantal alinea's dat moet worden geëxporteerd.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit Python‑voorbeeld exporteert alle alinea's uit de eerste tekst‑vorm:

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

[Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) biedt de methode `get_image` om een afzonderlijke alinea direct te renderen. De methode retourneert een [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) die je kunt opslaan naar een bestand of stream met [IImage.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/save/). Je hoeft niet de omvattende vorm te renderen of handmatig een bitmap bij te snijden.

De `get_image`‑methode kan `None` teruggeven als de alinea niet gevonden wordt in de bovenliggende collectie, geen geldige render‑bounds heeft, of niet kan worden gerenderd. Controleer het resultaat voordat je het opslaat en gebruik de geretourneerde afbeelding als context‑manager om de resources vrij te geven.

#### **Een alinea renderen op de standaardschaal**

Stel je voor dat we een presentatiedocument hebben genaamd `sample.pptx` met één dia, waarbij de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het onderstaande voorbeeld rendert de tweede alinea in een gewone tekstvorm op de standaardschaal en slaat de geretourneerde afbeelding op in PNG‑formaat:

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

#### **Een alinea renderen in een tabelcel met schaalvergroting**

Geef horizontale en verticale schaalfactoren door aan `get_image` om de grootte van de gerenderde alinea te bepalen. Het onderstaande voorbeeld maakt een tabel, rendert de alinea in de eerste cel op het dubbele van de standaardbreedte en -hoogte, en slaat het resultaat op als PNG‑afbeelding:

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

Een schaalfactor van `1` behoudt die as op de standaardpixelgrootte. Bijvoorbeeld, `2` voor beide factoren levert een afbeelding waarvan breedte en hoogte ongeveer het dubbele zijn, wat vier keer zoveel pixels betekent. Grotere factoren geven over het algemeen scherpere tekst voor inzoomen of high‑resolution uitvoer, maar vergroten ook het geheugenverbruik en de bestandsgrootte. Factoren onder `1` geven kleinere afbeeldingen met minder detail. Gebruik dezelfde factor voor beide assen om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken het resultaat onafhankelijk uit.

Het renderen van een volledige vorm met [Shape.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/) blijft nuttig wanneer de uitvoer de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een alleen‑alinea‑afbeelding gebruik je `Paragraph.get_image`.

## **FAQ**

**Kan ik volledig voorkomen dat regels binnen een tekstkader afbreken?**

Ja. Stel [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/wrap_text/) in om afbreken uit te schakelen zodat regels niet bij de randen van het tekstkader worden gesplitst.

**Hoe krijg ik de exacte op‑dia‑afmetingen van een specifieke alinea?**

Gebruik [Paragraph.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/get_rect/) om het omvattende rechthoek van de alinea op te halen. [Portion.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/get_rect/) geeft de afmetingen van een afzonderlijk deel.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/alignment/) is een alinea‑niveau instelling en wordt toegepast op de volledige alinea, ongeacht de opmaak van individuele delen.

**Kan ik de taalcontrole voor een deel van een alinea instellen?**

Ja. Stel [PortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/) in voor afzonderlijke delen, zodat één alinea tekst in meerdere talen kan bevatten.