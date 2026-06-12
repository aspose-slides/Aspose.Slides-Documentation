---
title: Beheer PowerPoint‑tekst‑alinea’s in Python
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/python-net/manage-paragraph/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingstekens beheren
- alinea‑inspringing
- hangende inspringing
- alinea‑opsomming
- genummerde lijst
- opsommingslijst
- alinea‑eigenschappen
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
description: "Beheer de alinea‑opmaak met Aspose.Slides voor Python via .NET—optimaliseer uitlijning, afstand en stijl in PowerPoint‑ en OpenDocument‑presentaties in Python om de kijkers te boeien."
---
## **Inleiding**

Aspose.Slides biedt de klassen die u nodig hebt om met PowerPoint‑tekst in Python te werken.

* Aspose.Slides biedt de [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/)‑klasse voor het maken van tekstframe‑objecten. Een `TextFrame`‑object kan één of meer alinea’s bevatten (elke alinea wordt gescheiden door een regeleinde).
* Aspose.Slides biedt de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑klasse voor het maken van alinea‑objecten. Een `Paragraph`‑object kan één of meer tekstporties bevatten.
* Aspose.Slides biedt de [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/)‑klasse voor het maken van tekstportie‑objecten en het specificeren van hun opmaak‑eigenschappen.

Een `Paragraph`‑object kan tekst met verschillende opmaak‑eigenschappen verwerken via de onderliggende `Portion`‑objecten.

## **Meerdere alinea’s met meerdere porties toevoegen**

Deze stappen laten zien hoe u een tekstframe toevoegt dat drie alinea’s bevat, elk met drie porties:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een verwijzing naar de doel‑slide op basis van de index.
1. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de slide.
1. Haal het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) op dat bij de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) hoort.
1. Maak twee [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑objecten en voeg ze toe aan de alinea‑collectie van het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) (samen met de standaardalinea resulteert dit in drie alinea’s).
1. Maak voor elke alinea drie [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/)‑objecten en voeg ze toe aan de portie‑collectie van die alinea.
1. Stel de tekst voor elke portie in.
1. Pas de gewenste opmaak toe op elke tekstportie via de eigenschappen van [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/).
1. Sla de aangepaste presentatie op.

De volgende Python‑code implementeert deze stappen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantieer de Presentation‑klasse om een nieuw PPTX‑bestand aan te maken.
with slides.Presentation() as presentation:

    # Open de eerste slide.
    slide = presentation.slides[0]

    # Voeg een rechthoekige AutoShape toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Open het TextFrame van de AutoShape.
    text_frame = shape.text_frame

    # Maak alinea’s en porties aan; opmaak wordt hieronder toegepast.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Sla het PPTX‑bestand op schijf.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Beheren van alinea‑opsommingstekens**

Opsommingstekens helpen u informatie snel en efficiënt te ordenen en te presenteren. Alinea‑opsommingstekens zijn vaak makkelijker leesbaar en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Open de gewenste slide op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de slide.
1. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
1. Verwijder de standaardalinea uit het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Maak de eerste alinea met de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑klasse.
1. Stel het opsommingstype van de alinea in op `SYMBOL` en specificeer het opsommingsteken.
1. Stel de tekst van de alinea in.
1. Stel de inspringing van het opsommingsteken in voor de alinea.
1. Stel de kleur van het opsommingsteken in.
1. Stel de grootte (hoogte) van het opsommingsteken in.
1. Voeg de alinea toe aan de alinea‑collectie van het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Voeg een tweede alinea toe en herhaal stappen 7‑12.
1. Sla de presentatie op.

Deze Python‑code toont hoe u alinea‑opsommingstekens toevoegt:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een presentatie‑instantie.
with slides.Presentation() as presentation:

    # Open de eerste slide.
    slide = presentation.slides[0]

    # Voeg een AutoShape toe en open deze.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Open het tekstframe van de aangemaakte AutoShape.
    text_frame = shape.text_frame

    # Verwijder de standaardalinea.
    text_frame.paragraphs.remove_at(0)

    # Maak een alinea.
    paragraph = slides.Paragraph()

    # Stel de bullet‑stijl en het symbool van de alinea in.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Stel de alinea‑tekst in.
    paragraph.text = "Welcome to Aspose.Slides"

    # Stel de bullet‑inspringing in.
    paragraph.paragraph_format.indent = 25

    # Stel de bullet‑kleur in.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Stel de bullet‑hoogte in.
    paragraph.paragraph_format.bullet.height = 100

    # Voeg de alinea toe aan het tekstframe.
    text_frame.paragraphs.add(paragraph)

    # Maak de tweede alinea.
    paragraph2 = slides.Paragraph()

    # Stel het bullet‑type en de stijl van de alinea in.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Stel de alinea‑tekst in.
    paragraph2.text = "This is numbered bullet"

    # Stel de bullet‑inspringing in.
    paragraph2.paragraph_format.indent = 25

    # Stel de bullet‑kleur in.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Stel de bullet‑hoogte in.
    paragraph2.paragraph_format.bullet.height = 100

    # Voeg de alinea toe aan het tekstframe.
    text_frame.paragraphs.add(paragraph2)

    # Sla de presentatie op als een PPTX‑bestand.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Beheren van afbeelding‑opsommingstekens**

Opsommingstekens helpen u informatie snel en efficiënt te ordenen en te presenteren. Afbeelding‑opsommingstekens zijn makkelijk leesbaar en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Open de gewenste slide op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de slide.
1. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
1. Verwijder de standaardalinea uit het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Maak de eerste alinea met de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑klasse.
1. Laad een afbeelding in een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/).
1. Stel het opsommingstype in op [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) en wijs de afbeelding toe.
1. Stel de tekst van de alinea in.
1. Stel de inspringing van de alinea in voor het opsommingsteken.
1. Stel de kleur van het opsommingsteken in.
1. Stel de hoogte van het opsommingsteken in.
1. Voeg de nieuwe alinea toe aan de alinea‑collectie van het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Voeg een tweede alinea toe en herhaal stappen 8‑12.
1. Sla de presentatie op.

Deze Python‑code toont hoe u afbeelding‑opsommingstekens toevoegt en beheert:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Open de eerste slide.
    slide = presentation.slides[0]

    # Laad de bullet-afbeelding.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Voeg een AutoShape toe en open deze.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Open het TextFrame van de aangemaakte AutoShape.
    text_frame = auto_shape.text_frame

    # Verwijder de standaardalinea.
    text_frame.paragraphs.remove_at(0)

    # Maak een nieuwe alinea.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Stel het bullet-type van de alinea in op Picture en wijs de afbeelding toe.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Stel de bullet-hoogte in.
    paragraph.paragraph_format.bullet.height = 100

    # Voeg de alinea toe aan het tekstframe.
    text_frame.paragraphs.add(paragraph)

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Sla de presentatie op als een PPT-bestand.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Beheren van meerlagige opsommingstekens**

Opsommingstekens helpen u informatie snel en efficiënt te ordenen en te presenteren. Meerlagige opsommingstekens zijn makkelijk leesbaar en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Open de gewenste slide op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de slide.
1. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/).
1. Verwijder de standaardalinea uit het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Maak de eerste alinea met de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑klasse en stel de diepte in op 0.
1. Maak de tweede alinea met de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑klasse en stel de diepte in op 1.
1. Maak de derde alinea met de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑klasse en stel de diepte in op 2.
1. Maak de vierde alinea met de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑klasse en stel de diepte in op 3.
1. Voeg de nieuwe alinea’s toe aan de alinea‑collectie van het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Sla de presentatie op.

De volgende Python‑code toont hoe u meerlagige opsommingstekens toevoegt en beheert:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een presentatie-instantie.
with slides.Presentation() as presentation:

    # Open de eerste slide.
    slide = presentation.slides[0]
    
    # Voeg een AutoShape toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Open het TextFrame van de aangemaakte AutoShape.
    text_frame = auto_shape.text_frame
    
    # Verwijder de standaardalinea.
    text_frame.paragraphs.clear()

    # Voeg de eerste alinea toe.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Stel het bullet-niveau in.
    paragraph1.paragraph_format.depth = 0

    # Voeg de tweede alinea toe.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Stel het bullet-niveau in.
    paragraph2.paragraph_format.depth = 1

    # Voeg de derde alinea toe.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Stel het bullet-niveau in.
    paragraph3.paragraph_format.depth = 2

    # Voeg de vierde alinea toe.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Stel het bullet-niveau in.
    paragraph4.paragraph_format.depth = 3

    # Voeg de alinea's toe aan de collectie.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Alinea’s met aangepaste genummerde lijsten beheren**

De [BulletFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/)‑klasse biedt de eigenschap `numbered_bullet_start_with` (en andere) om aangepaste nummering en opmaak voor alinea’s te regelen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Open de slide die de alinea’s zal bevatten.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de slide.
1. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
1. Verwijder de standaardalinea uit het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Maak de eerste [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) en stel `numbered_bullet_start_with` in op 2.
1. Maak de tweede [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) en stel `numbered_bullet_start_with` in op 3.
1. Maak de derde [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) en stel `numbered_bullet_start_with` in op 7.
1. Voeg de alinea’s toe aan de collectie van het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Sla de presentatie op.

De volgende Python‑code demonstreert hoe u alinea’s met aangepaste nummering en opmaak toevoegt en beheert.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Voeg een AutoShape toe en open deze.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Open het TextFrame van de aangemaakte AutoShape.
    text_frame = shape.text_frame

    # Verwijder de standaard bestaande alinea.
    text_frame.paragraphs.remove_at(0)

    # Maak het eerste genummerde item (begin bij 2, diepte‑niveau 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Maak het tweede genummerde item (begin bij 3, diepte‑niveau 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Maak het derde genummerde item (begin bij 7, diepte‑niveau 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eerste‑regel‑inspringing voor een alinea instellen**

Gebruik de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) om de eerste‑regel‑inspringing van een alinea te regelen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) wanneer u de gehele alinea wilt verplaatsen. Gebruik [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt verschillende alinea’s en past verschillende `indent`‑waarden toe om te laten zien hoe de eerste‑regel‑inspringing de lay‑out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Open de doel‑slide.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de slide.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) toe aan de vorm en verwijder de standaardalinea.
5. Maak verschillende alinea’s en stel verschillende [indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/)‑waarden in.
6. Voeg de alinea’s toe aan het tekstframe.
7. Sla de aangepaste presentatie op.

Deze code laat zien hoe u een alinea‑inspringing instelt:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Hangende inspringing voor een alinea instellen**

Een hangende inspringing is een alinea‑lay‑out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëert u dit effect met de eigenschap [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/). Stel `indent` in op een negatieve waarde om de eerste regel naar links te verschuiven ten opzichte van de alinea‑inhoud.

In de praktijk bepaalt [ParagraphFormat.margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/) de linkermarge van de alinea‑inhoud, en bepaalt [ParagraphFormat.indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te creëren, stelt u een positieve `margin_left`‑waarde en een negatieve `indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, verwijzingen, begrippenlijsten en andere alinea’s waarbij ingesprongen regels onder de alinea‑inhoud moeten uitlijnen i.p.v. onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Open de doel‑slide.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de slide.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) toe aan de vorm en verwijder de standaardalinea.
5. Maak alinea’s en stel voor elke alinea een positieve [margin_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/margin_left/)‑waarde in.
6. Stel een negatieve [indent](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/indent/)‑waarde in om het hangende‑inspringing‑effect te bereiken.
7. Voeg de alinea’s toe aan het tekstframe.
8. Sla de aangepaste presentatie op.

Deze code laat zien hoe u een hangende inspringing voor een alinea instelt:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Eind‑van‑alinea‑portie‑opmaak beheren**

Wanneer u de opmaak van het “einde” van een alinea wilt regelen (de opmaak die wordt toegepast na de laatste tekstportie), gebruikt u de eigenschap `end_paragraph_portion_format`. In het onderstaande voorbeeld wordt een groter Times New Roman‑lettertype toegepast op het einde van de tweede alinea.

1. Maak of open een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑bestand.
1. Haal de doel‑slide op via de index.
1. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de slide.
1. Gebruik het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm en maak twee alinea’s.
1. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/) ingesteld op 48 pt Times New Roman en pas deze toe als de eind‑alinea‑portie‑opmaak van de alinea.
1. Ken deze toe aan de alinea’s `end_paragraph_portion_format` (geldt voor het einde van de tweede alinea).
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze Python‑code toont hoe u de eind‑van‑alinea‑opmaak voor de tweede alinea instelt:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **HTML‑tekst importeren in alinea’s**

Aspose.Slides biedt verbeterde ondersteuning voor het importeren van HTML‑tekst in alinea’s.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Open de doel‑slide via de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de slide.
1. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/).
1. Verwijder de standaardalinea uit het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Lees het bron‑HTML‑bestand.
1. Maak de eerste alinea met de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑klasse.
1. Voeg de HTML‑inhoud toe aan de alinea‑collectie van het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Sla de aangepaste presentatie op.

De volgende Python‑code implementeert deze stappen voor het importeren van HTML‑tekst in alinea’s.

```python
import aspose.slides as slides

# Maak een lege Presentation-instantie.
with slides.Presentation() as presentation:

    # Open de eerste slide van de presentatie.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Voeg een AutoShape toe om de HTML-inhoud te huisvesten.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Verwijder alle alinea’s in het toegevoegde tekstframe.
    shape.text_frame.paragraphs.clear()

    # Laad het HTML-bestand.
    with open("file.html", "rt") as html_stream:
        # Voeg de tekst uit het HTML-bestand toe aan het tekstframe.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Sla de presentatie op.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt verbeterde ondersteuning voor het exporteren van tekst naar HTML.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en laad de doelpresentatie.
1. Open de gewenste slide via de index.
1. Selecteer de vorm die de te exporteren tekst bevat.
1. Open het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm.
1. Open een bestands‑stream om de HTML‑uitvoer te schrijven.
1. Specificeer de start‑index en exporteer de gewenste alinea’s.

Dit Python‑voorbeeld toont hoe u alinea‑tekst exporteert naar HTML.

```python
import aspose.slides as slides

# Laad het presentatiebestand.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Open de eerste slide van de presentatie.
    slide = presentation.slides[0]

    # Doelvorm-index.
    index = 0

    # Open de vorm op basis van de index.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Schrijf alinea-data naar HTML door de start-alinea-index en het totale aantal alinea's dat moet worden geexporteerd op te geven.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Een alinea opslaan als afbeelding**

In dit gedeelte bekijken we twee voorbeelden die laten zien hoe u een tekst‑alinea, vertegenwoordigd door de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑klasse, als afbeelding opslaat. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `get_image`‑methoden van de [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑klasse, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren ervan als bitmap‑afbeelding. Deze benaderingen stellen u in staat specifieke delen van de tekst uit PowerPoint‑presentaties te extraheren en op te slaan als afzonderlijke afbeeldingen, wat nuttig kan zijn voor verder gebruik in verschillende scenario’s.

Laten we aannemen dat we een presentatiebestand hebben genaamd **sample.pptx** met één slide, waarbij de eerste vorm een tekstvak is dat drie alinea’s bevat.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld verkrijgen we de tweede alinea als afbeelding. Hiervoor extraheren we de afbeelding van de vorm op de eerste slide van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstframe van de vorm. De alinea wordt daarna opnieuw getekend op een nieuwe bitmap‑afbeelding, die wordt opgeslagen in PNG‑formaat. Deze methode is vooral nuttig wanneer u een specifieke alinea als afzonderlijke afbeelding wilt bewaren, met behoud van de exacte afmetingen en opmaak van de tekst.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Sla de vorm op in het geheugen als bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Maak een bitmap van de vorm vanuit het geheugen.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Bereken de grenzen van de tweede alinea.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Bereken de coördinaten en grootte voor de uitvoerafbeelding (minimumgrootte - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Snijd de vorm-bitmap bij om alleen de alinea-bitmap te krijgen.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Het resultaat:

![The paragraph image](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren toe te passen op de alinea‑afbeelding. De vorm wordt uit de presentatie gehaald en opgeslagen als afbeelding met een schaalfactor van `2`. Dit biedt een hogere resolutie bij het exporteren van de alinea. De alinea‑grenzen worden vervolgens berekend rekening houdend met de schaal. Schalen kan vooral nuttig zijn wanneer een meer gedetailleerde afbeelding vereist is, bijvoorbeeld voor gebruik in hoogwaardig gedrukt materiaal.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Sla de vorm op in het geheugen als bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Maak een bitmap van de vorm uit het geheugen.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Bereken de grenzen van de tweede alinea.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Bereken de coördinaten en grootte voor de uitvoerafbeelding (minimumgrootte - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Snijd de vorm‑bitmap bij om alleen de alinea‑bitmap te krijgen.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

**Kan ik het automatisch afbreken van regels binnen een tekstframe helemaal uitschakelen?**

Ja. Gebruik de instelling voor regelomslag van het tekstframe ([wrap_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/wrap_text/)) om de omslag uit te schakelen zodat regels niet breken aan de randen van het frame.

**Hoe krijg ik de exacte on‑slide‑grenzen van een specifieke alinea?**

U kunt de begrenzende rechthoek van de alinea (en zelfs van een enkele portie) opvragen om de precieze positie en grootte op de slide te kennen.

**Waar wordt de alinea‑uitlijning (links/rechts/centreren/uitvullen) geregeld?**

[Alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/alignment/) is een alinea‑niveau instelling in [ParagraphFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/); deze wordt toegepast op de hele alinea ongeacht de opmaak van individuele porties.

**Kan ik een spellings‑taal instellen voor slechts een deel van een alinea (bijvoorbeeld één woord)?**

Ja. De taal wordt ingesteld op portie‑niveau ([PortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/)), zodat meerdere talen binnen één alinea kunnen co‑existentiëren.