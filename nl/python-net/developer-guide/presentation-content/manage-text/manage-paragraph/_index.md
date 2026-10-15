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
- alinea-insprong
- hangende insprong
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
description: "Leer hoe je alinea's, gedeelten, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen kunt maken en opmaken met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET stelt tekst voor als een hiërarchie van tekstkaders, alinea's en gedeelten:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) vertegenwoordigt de tekstcontainer in een vorm en biedt toegang tot de alinea-collectie.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstkader en biedt toegang tot de gedeelten en alinea-opmaak.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) vertegenwoordigt een tekstdelen binnen een alinea. Elk gedeelte kan een eigen tekst en tekenopmaak hebben.

Een alinea kan daardoor tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere gedeelten te gebruiken.

## **Alinea's maken en opmaken**

Maak alinea's in het tekstkader van een vorm en gebruik gedeelten om afzonderlijke tekstdelen op te maken. Deze sectie laat zien hoe meerdere gedeelten binnen elke alinea te combineren en verschillende kleuren, lettergroottes en stijlen toe te passen.

### **Alinea's maken met meerdere gedeelten**

Het volgende Python‑voorbeeld maakt drie alinea's, elk met drie tekstdelen in de [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/)‑collectie. Het hergebruikt de standaardalinea en het lege gedeelte, voegt vervolgens de resterende alinea's en gedeelten toe. Opmaak wordt toegepast via [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): het eerste gedeelte in elke alinea is rood, vet en 15 pt; het tweede is blauw, cursief en 18 pt. Het derde gedeelte behoudt de standaardopmaak:

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

## **Opsommingen met opsommingstekens en genummerde lijsten maken**

Organiseer alinea‑tekst in lijsten met symbolen, cijfers of aangepaste afbeeldingen. De voorbeelden in deze sectie behandelen opsommingsteken‑opmaak, meerlagige lijsten en aangepaste startnummers.

### **Een opsomming met opsommingstekens of een genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Dit Python‑voorbeeld voegt een symbool‑opsommingsteken en een genummerd item toe aan hetzelfde tekstkader. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) selecteert het type opsommingsteken, terwijl [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) het symbool levert en [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) de nummeringsstijl kiest. Beide items gebruiken zwarte opsommingstekens met een hoogte van 100 % en een alinea‑insprong van 25 pt:

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

Afbeeldingsopsommingstekens laten je een aangepaste afbeelding gebruiken in plaats van een symbool of cijfer.

Het voorbeeld vereist `bullets.png` in de werkmap. Dit Python‑voorbeeld voegt een afbeelding toe aan de afbeeldingscollectie van de presentatie als een [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) en gebruikt deze als alinea‑opsommingsteken. Het stelt [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) in op afbeelding‑opsommingsteken en wijst de afbeelding toe via [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) wordt op 100 % gezet om de opsomming relatief tot de alinea‑tekst te schalen:

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

Stel [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het hoogste niveau heeft een diepte van `0`.

Dit Python‑voorbeeld kent [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) waarden van 0 tot 3 toe aan vier alinea's, waardoor een hiërarchie ontstaat binnen één tekstkader. Elke alinea gebruikt een symbool‑opsommingsteken, waarbij [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) afwisselt tussen een ronde punt en een streepje om aangrenzende niveaus te onderscheiden:

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

Gebruik [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) om het beginnummer voor een genummerde alinea in te stellen.

Dit Python‑voorbeeld zet [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) op nummering voor drie alinea's en kent [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) waarden 2, 3 en 7 toe. De startwaarde wordt afzonderlijk per alinea geconfigureerd, waardoor de weergegeven nummers waarden kunnen overslaan:

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

## **Paragraaflay-out en eind‑eigenschappen beheren**

Pas alinea‑marges en inspringingen aan om de positie van de eerste regel en ingesprongen regels te regelen. Je kunt ook het eind‑teken van de alinea apart opmaken van de zichtbare tekstdelen.

### **Eerste‑regelinspanning instellen**

Gebruik de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) om de eerste‑regelinspanning van een alinea te bepalen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de resterende regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) wanneer je de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) wanneer je alleen de eerste regel wilt verplaatsen.

Het volgende voorbeeld geeft drie alinea's dezelfde [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) van 20 pt en [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) waarden van 0, 20 en 40 pt. De eerste regels beginnen op steeds grotere offsetten, terwijl ingesprongen regels dezelfde linkermarge behouden:

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

![De eerste‑regelinspanning van de alinea's](first_line_indent.png)

### **Hangende insprong instellen**

Een hangende insprong is een alinea‑lay-out waarbij de eerste regel links van de resterende regels begint. In Aspose.Slides creëer je dit effect met de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Stel `indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk bepaalt [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) de linkse positie van de alinea‑inhoud, en bepaalt [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te maken, stel je een positieve `margin_left`-waarde en een negatieve `indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, woordenlijst‑items en andere alinea's waarbij ingesprongen regels onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

Het volgende Python‑voorbeeld combineert [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) waarden van 40 en 60 pt met [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) waarden van -20 en -30 pt. In elke alinea begint de eerste regel links van de ingesprongen regels; de tweede alinea heeft een diepere hangende insprong:

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

![De hangende insprong van de alinea's](hanging_indent.png)

### **Eind‑alinea‑run‑eigenschappen instellen**

De eigenschap [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) bepaalt de opmaak van het alinea‑eindteken. Het voorbeeld laadt `Test.pptx`, dat minstens één dia moet bevatten, en maakt een [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) met [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) ingesteld op 48 pt en [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) op Times New Roman. Het kent dit format toe aan het eindteken van de tweede alinea, terwijl de zichtbare tekstdelen ongewijzigd blijven:

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

Voor alinea‑regels die automatisch omslag en interpunctie aan het einde van regels beïnvloeden, zie [Control Line Breaking](/slides/nl/python-net/text-formatting/#control-line-breaking) en [Control Hanging Punctuation](/slides/nl/python-net/text-formatting/#control-hanging-punctuation).

Gebruik [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) om het aantal regels dat een alinea inneemt na tekstlayout te tellen, inclusief automatische omslag. Dit is nuttig bij het controleren van tekstlengte en layout in presentatiesjablonen.

Een alinea is één item in [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), en kan meerdere gerenderde regels innemen. Een expliciete regeleinde‑invoeging binnen een alinea forceert een nieuwe regel zonder een nieuwe alinea te maken. Automatische omslag maakt regels gebaseerd op de beschikbare breedte zonder expliciete regeleinde‑tekens in de tekst in te voegen. Het tellen van alinea's of regeleinde‑tekens geeft daarom niet het gerenderde regel‑aantal.

Het volgende voorbeeld maakt een tekstoppervlak, telt de regels, maakt het oppervlak smaller en vervangt vervolgens de tekst door een kortere string. Het voorbeeld schakelt [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) in en [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) uit zodat de breedte van het oppervlak de omslag bepaalt zonder de tekst automatisch te verkleinen of het oppervlak te herschalen. Elke meting gebruikt [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Afmetingen zijn in punten. Ten slotte voegt het voorbeeld een extra alinea toe en telt de regel‑aantallen op over het tekstkader.

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

Met deze tekst en afmetingen verhoogt het smaller maken van het oppervlak het aantal regels, terwijl het vervangen door de korte string het aantal verlaagt. Precieze aantallen kunnen variëren afhankelijk van beschikbare lettertypen en substitutie, lettergrootte, marges, inspringing, omslag en autofit‑instellingen. Gebruik de lettertypen en layout‑instellingen die bedoeld zijn voor de doelomgeving bij het testen van een sjabloon.

Het regel‑aantal alleen bepaalt niet of tekst buiten zijn container stroomt. De beschikbare hoogte, regel‑hoogtes, alinea‑ en regel‑spatiëring en autofit‑gedrag zijn eveneens van belang; zelfs één regel kan de beschikbare breedte overschrijden wanneer omslag is uitgeschakeld.

## **Paragraafinhoud importeren en exporteren**

Gebruik HTML om tekst in een presentatie te brengen of om bestaande alinea's buiten de presentatie te exporteren. Deze sectie laat ook zien hoe je individuele alinea's als afbeeldingen rendert, inclusief alinea's in tabelcellen.

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) om HTML‑markup te converteren naar alinea's en gedeelten in een tekstkader.

Dit Python‑voorbeeld leest HTML van `file.html` in de werkmap en geeft de markup door aan [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Het wist de standaardalinea van het tekstkader zodat het kader alleen de geïmporteerde inhoud bevat. De rechthoekige vorm laat een marge van 10 pt rondom de dia:

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

Gebruik [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) om een geselecteerd bereik alinea's als HTML te exporteren. Wanneer je presentatietekst opnieuw gebruikt op een website, wil je mogelijk lokale nadruk behouden zonder de lettertype‑, grootte‑ of tekstvakstijlen van de presentatie over te nemen. Stel [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) in om te bepalen hoe ver de exporteur de opmaak‑erfenis volgt.

Download [de voorbeeldpresentatie](text-inheritance.pptx) en plaats deze in de werkmap van de applicatie. De eerste dia bevat één tekstvorm met de tekst “Inherited text; explicit red 18pt”. De invoer gebruikt bewust verschillende opmaakniveaus:

- De standaardtekststijl van de presentatie levert Calibri en een grootte van 28 pt.
- De tekstkader‑eerste‑niveau stijl levert blauwe tekst en cursief.
- De alinea stelt expliciet vetgedrukte tekst in.
- Het tweede gedeelte, “explicit red 18pt”, stelt expliciet rode tekst en een grootte van 18 pt in.

Het volgende volledige voorbeeld exporteert dezelfde alinea's drie keer. Het geeft [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) door aan de export‑methode en schrijft elk resultaat naar een apart UTF‑8 HTML‑bestand:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

De gegenereerde HTML bevat de volgende CSS voor het eerste gedeelte, “Inherited text; ”. De tabel geeft de relevante declaraties weer; andere gegenereerde eigenschappen zijn weggelaten voor de duidelijkheid.

| Uitvoer | Relevante CSS voor het eerste gedeelte | Uiterlijk |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blauwe, vetgedrukte, cursieve tekst op 28 pt in Calibri, indien dat lettertype beschikbaar is. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blauwe, vetgedrukte, cursieve tekst; de omringende pagina of browser levert het lettertype en de grootte. |
| `ParagraphOnly.html` | `font-weight:bold` | Vetgedrukte tekst; de omringende pagina of browser levert het lettertype, de grootte, kleur en cursieve stijl. |

Het tweede gedeelte behoudt `color:#ff0000`, `font-size:18pt` en `font-weight:bold` in alle drie de uitvoerbestanden. Het behoudt ook cursief in `ALL` en `TEXT_BOX`, maar niet in `PARAGRAPH_ONLY`. Het beperken van de erfenis verwijdert dus niet de expliciet toegewezen opmaak van een alinea of gedeelte.

Open de bestanden in dezelfde browser om ze te vergelijken. In de twee beperkte modi worden weggelaten CSS‑eigenschappen opgevolgd door de stijlen van de bestemmingspagina of de standaard van de browser, waardoor het uiteindelijke uiterlijk afhangt van waar de HTML wordt gebruikt.

### **Een alinea als afbeelding renderen**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) rendert een individuele alinea direct en retourneert een [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Sla het resultaat op in een bestand of stream met [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Je hoeft niet de omvattende vorm te renderen of handmatig een bitmap bij te snijden.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) kan `None` teruggeven als de alinea niet gevonden wordt in de bovenliggende collectie, geen geldige render‑grenzen heeft, of niet gerenderd kan worden. Controleer het resultaat voordat je het opslaat en maak de geretourneerde afbeelding vrij na gebruik.

#### **Een alinea renderen met de standaardschaal**

Het voorbeeld gebruikt `sample.pptx`, een presentatie met één dia waarvan de eerste vorm een tekstvak met drie alinea's is.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld selecteert de tweede alinea (index 1) en roept [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) aan zonder schaal‑parameters. Het controleert dat de vorm de vereiste alinea bevat en dat het renderen een afbeelding oplevert voordat [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) wordt aangeroepen om deze in PNG‑formaat op te slaan. De context‑manager vrijgeeft de afbeeldingsbronnen na gebruik.

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

#### **Een alinea in een tabelcel renderen met schalen**

Gebruik de overload van [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) die `scale_x` en `scale_y` parameters accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel met twee keer de standaardbreedte en -hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaardpixelgrootte. Een factor van `2` voor beide assen produceert een afbeelding waarvan breedte en hoogte ongeveer twee keer de standaardafmetingen zijn, wat vier keer zoveel pixels oplevert. Grotere factoren geven doorgaans scherpere tekst bij zoomen of hoge‑resolutie‑output, maar verhogen ook het geheugen‑ en bestandsformaat. Factoren onder `1` geven kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk.

Het renderen van een volledige vorm met [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) blijft nuttig wanneer de output de opvulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding van alleen de alinea, gebruik je [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **FAQ**

**Kan ik het automatisch afbreken van regels in een tekstkader volledig uitschakelen?**

Ja. Stel [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) in om afbreken uit te schakelen zodat regels niet bij de randen van het tekstkader worden afgebroken.

**Hoe kan ik de exacte positie van een specifieke alinea op de dia verkrijgen?**

Gebruik [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) om het omhullende rechthoek van de alinea op te halen. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) geeft de grenzen van een afzonderlijk gedeelte.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitvullen) geregeld?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) is een alinea‑niveau instelling en wordt toegepast op de gehele alinea ongeacht de opmaak van afzonderlijke gedeelten.

Om delen van verschillende lettergroottes binnen elke regel verticaal op één lijn te krijgen, zie [Align Fonts Within a Line](/slides/nl/python-net/text-formatting/#align-fonts-within-a-line).

**Kan ik de proefleestaal voor een deel van een alinea instellen?**

Ja. Stel [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) in voor afzonderlijke gedeelten, zodat één alinea tekst in meerdere talen kan bevatten.