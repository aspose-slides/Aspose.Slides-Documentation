---
title: Beheer PowerPoint-tekst alinea's in Python
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
description: "Leer hoe u alinea's, fragmenten, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen kunt maken en opmaken met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides voor Python via .NET stelt tekst voor als een hiërarchie van tekstframes, alinea's en fragmenten:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) vertegenwoordigt de tekstopslagplaats in een vorm en biedt toegang tot de alinea‑collectie.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de fragmenten en de op alinea‑niveau gebaseerde opmaak.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) vertegenwoordigt een tekstrun binnen een alinea. Elk fragment kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan dus tekst met verschillende lettertypen, kleuren, groottes en andere opmaak bevatten door meerdere fragmenten te gebruiken.

## **Aanmaken en opmaken van alinea's**

### **Aanmaken van alinea's met meerdere fragmenten**

De volgende stappen maken een tekstframe met drie alinea's, die elk drie fragmenten bevatten:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Toegang tot de relevante dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaard alinea en voeg twee extra [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)‑objecten toe aan het tekstframe.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)‑objecten toe zodat elke alinea drie fragmenten bevat. De standaard alinea bevat al één leeg fragment.
7. Stel de tekst van elk fragment in.
8. Pas teken‑niveau opmaak toe via [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/).
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

## **Aanmaken van opsommingstekens en genummerde lijsten**

### **Aanmaken van een opsomming of genummerde lijst**

Opsommingstekens en nummering maken gerelateerde items gemakkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Toegang tot de relevante dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaard alinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) aan voor een symbool‑opsommingsteken.
7. Stel [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) in op [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) en specificeer het opsommingsteken.
8. Stel de alinea‑tekst, inspringing, kleur van het opsommingsteken en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea aan en stel [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) in op [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/).
11. Stel de stijl van het genummerde opsommingsteken in en voeg de alinea toe aan het tekstframe.
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

### **Gebruik afbeeldings‑opsommingstekens**

Afbeeldings‑opsommingstekens laten u een aangepaste afbeelding gebruiken in plaats van een symbool of een cijfer.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Toegang tot de relevante dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe en krijg toegang tot zijn [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
4. Verwijder de standaard alinea uit het tekstframe.
5. Laad de afbeelding voor het opsommingsteken en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) aan en stel de tekst in.
7. Stel [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) in op [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/).
8. Wijs de afbeelding toe via [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

Dit Python‑voorbeeld maakt een afbeeldings‑opsommingsteken:

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

### **Aanmaken van een meerlagige lijst**

Stel [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het hoogste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) aan en krijg toegang tot een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe en verwijder de standaard alinea uit het tekstframe.
3. Maak vier alinea's aan en configureer hun opsommingstekens.
4. Stel hun [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/)‑waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit Python‑voorbeeld maakt een vierlagige opsommingslijst:

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

### **Start genummerde lijstitems met aangepaste waarden**

Gebruik [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) om het eerste getal in te stellen dat wordt weergegeven voor een genummerde alinea.

1. Maak een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) aan en voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaard alinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea's aan.
4. Stel [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) in op `2`, `3` en `7` voor de respectieve alinea's.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit Python‑voorbeeld kent een aangepaste startwaarde toe aan elke alinea:

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

## **Controle van alinea‑indeling en eind‑eigenschappen**

### **Instellen van een eerste‑lijninspringing**

Gebruik de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) om de eerste‑lijninspringing van een alinea te regelen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde schuift de eerste regel naar rechts, terwijl de resterende regels uitgelijnd blijven met het alinea‑lichaam.

Gebruik [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) wanneer u de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt verschillende alinea's en past verschillende [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)‑waarden toe om te laten zien hoe de eerste‑lijninspringing de alinea‑indeling beïnvloedt.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Toegang tot de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's aan en stel verschillende [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)‑waarden voor hen in.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een alinea‑inspringing instelt:

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

![De eerste‑lijninspringing van de alinea's](first_line_indent.png)

### **Instellen van een hangende inspringing**

Een hangende inspringing is een alinea‑indeling waarbij de eerste regel links begint ten opzichte van de resterende regels. In Aspose.Slides creëert u dit effect met de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Stel `indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van het alinea‑lichaam.

In de praktijk definieert [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) de linkse positie van het alinea‑lichaam, en definieert [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te creëren, stelt u een positieve `margin_left`‑waarde en een negatieve `indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, woordenlijst‑items en andere alinea's waarbij de afgebroken regels onder het alinea‑lichaam moeten uitgelijnd worden in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Toegang tot de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak alinea's aan en stel voor elke alinea een positieve [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/)‑waarde in.
6. Stel een negatieve [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)‑waarde in om het hangende‑inspringing‑effect te creëren.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een hangende inspringing voor een alinea instelt:

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

### **Instellen van de eind‑alinea‑run‑eigenschappen**

De eigenschap [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) bepaalt de opmaak van het einde‑teken van een alinea. Het volgende voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het einde‑teken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en krijg toegang tot een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe en verwijder de standaard alinea.
3. Maak twee alinea's aan en voeg tekstfragmenten toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) aan voor het einde‑teken van de tweede alinea.
5. Stel [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) en [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) in.
6. Wijs de opmaak toe aan [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) en sla de presentatie op.

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

## **Aantal gerenderde regels tellen**

Voor alinea‑regels die automatische afbreking en interpunctie aan het einde van regels beïnvloeden, zie [Regelafbreking reguleren](/slides/nl/python-net/text-formatting/#control-line-breaking) en [Hangende interpunctie reguleren](/slides/nl/python-net/text-formatting/#control-hanging-punctuation).

Gebruik [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) om het aantal regels te tellen dat een alinea bezet na de tekstindeling, inclusief automatische afbreking. Dit is nuttig bij het controleren van tekstlengte en indeling in presentatiesjablonen.

Een alinea is één item in [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), en kan meerdere weergegeven regels bezetten. Een expliciete regeleinde‑invoeging binnen een alinea dwingt een nieuwe regel af zonder een extra alinea te maken. Automatische afbreking creëert regels op basis van de beschikbare breedte zonder expliciete regeleinde‑tekens in de tekst in te voegen. Het tellen van alinea's of regeleinde‑tekens geeft dus niet het aantal weergegeven regels.

Het volgende voorbeeld creëert een tekstvorm, telt de regels, verkleint de vorm en vervangt vervolgens de tekst door een kortere string. Afbreking is ingeschakeld en autofit is uitgeschakeld zodat de vormbreedte de afbreking bepaalt zonder de tekst automatisch te verkleinen of de vorm te schalen. Vormafmetingen zijn in points. Ten slotte voegt het voorbeeld een extra alinea toe en somt de regeltelling over het tekstframe op.

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

Met deze tekst en deze afmetingen verhoogt het verkleinen van de vorm het aantal regels, terwijl het vervangen van de tekst door de korte string het aantal verlaagt. Exacte aantallen kunnen variëren afhankelijk van lettertype‑beschikbaarheid en substitutie, lettergrootte, marges, inspringing, afbreking en autofit‑instellingen. Gebruik de lettertypen en indelingsinstellingen die bedoeld zijn voor de doelomgeving bij het controleren van een sjabloon.

Het aantal regels alleen bepaalt niet of tekst buiten de container valt. De beschikbare hoogte, regelhoogtes, alinea‑ en regelafstand, en autofit‑gedrag spelen ook een rol; zelfs één regel kan de beschikbare breedte overschrijden wanneer afbreking is uitgeschakeld.

## **Importeren en exporteren van alinea‑inhoud**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) om HTML‑opmaak om te zetten naar alinea's en fragmenten in een tekstframe.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Toegang tot een dia en voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe.
3. Toegang tot het [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Sla de gewijzigde presentatie op.

Dit Python‑voorbeeld importeert HTML in een tekstframe:

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

Gebruik [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en laad de gewenste presentatie.
2. Toegang tot de dia en vind de [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) die de tekst bevat.
3. Toegang tot het [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
4. Roep [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) aan met de start‑alinea‑index en het aantal alinea's dat moet worden geëxporteerd.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit Python‑voorbeeld exporteert alle alinea's uit de eerste tekstvorm:

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

[Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) biedt de methode `get_image` om een individuele alinea rechtstreeks te renderen. De methode retourneert een [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) die u kunt opslaan naar een bestand of stream met [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Het is niet nodig om de omvattende vorm te renderen of een bitmap handmatig bij te snijden.

De `get_image`‑methode kan `None` retourneren als de alinea niet gevonden wordt in de bovenliggende collectie, geen geldige renderingsgrenzen heeft, of niet gerenderd kan worden. Controleer het resultaat voordat u het opslaat en gebruik de geretourneerde afbeelding als context‑manager om de bronnen vrij te geven.

#### **Een alinea renderen op de standaard schaal**

Stel dat we een presentatiebestand hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is dat drie alinea's bevat.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een regulier tekstvak op de standaard schaal en slaat de verkregen afbeelding op in PNG‑formaat:

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

#### **Een alinea renderen in een tabelcel met schaling**

Geef horizontale en verticale schaalfactoren door aan `get_image` om de grootte van de gerenderde alinea te bepalen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op twee keer de standaard breedte en hoogte, en slaat het resultaat op als PNG‑afbeelding:

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

Een schaalfactor van `1` houdt die as op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan de breedte en hoogte ongeveer tweemaal de standaardafmetingen zijn, wat viermaal zoveel pixels oplevert. Grotere factoren leveren doorgaans scherpere tekst voor inzoomen of output met hoge resolutie op, maar verhogen ook het geheugen‑ en bestandsgrootteverbruik. Factoren onder `1` geven kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken het resultaat onafhankelijk uit.

Het renderen van een hele vorm met [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet omvatten. Voor een afbeelding die alleen de alinea bevat, gebruik `Paragraph.get_image`.

## **FAQ**

**Kan ik het automatisch afbreken van regels binnen een tekstframe volledig uitschakelen?**

Ja. Stel [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) in om afbreken uit te schakelen zodat regels niet breken bij de randen van het tekstframe.

**Hoe kan ik de exacte afmetingen op de dia van een specifieke alinea verkrijgen?**

Gebruik [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) om de begrenzende rechthoek van de alinea op te halen. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) geeft de grenzen van een individueel fragment.

**Waar wordt de uitlijning van alinea's (links, rechts, gecentreerd of uitgevuld) geregeld?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) is een instelling op alinea‑niveau en wordt toegepast op de hele alinea, ongeacht de opmaak van individuele fragmenten.  

Om porties van verschillende lettergroottes verticaal uit te lijnen binnen elke regel, zie [Lettertypen binnen een regel uitlijnen](/slides/nl/python-net/text-formatting/#align-fonts-within-a-line).

**Kan ik de taal van de proeflezing voor een deel van een alinea instellen?**

Ja. Stel [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) in voor individuele fragmenten, zodat één alinea tekst in meerdere talen kan bevatten.