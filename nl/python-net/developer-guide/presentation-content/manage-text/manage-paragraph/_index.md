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
- opsomminglijst
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
description: "Beheers alinea-opmaak met Aspose.Slides voor Python via .NET—optimaliseer uitlijning, afstand en stijl in PowerPoint- en OpenDocument-presentaties in Python om kijkers te boeien."
---
## **Introductie**

Aspose.Slides biedt de klassen die u nodig heeft om met PowerPoint-tekst in Python te werken.

* Aspose.Slides biedt de [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/)‑klasse voor het maken van tekstkaderobjecten. Een `TextFrame`‑object kan een of meer alinea's bevatten (elke alinea wordt gescheiden door een carriagereturn).
* Aspose.Slides biedt de [Paragraph]‑klasse voor het maken van alinea‑objecten. Een `Paragraph`‑object kan een of meer tekstgedeelten bevatten.
* Aspose.Slides biedt de [Portion]‑klasse voor het maken van tekstgedeelten en het specificeren van hun opmaak‑eigenschappen.

Een `Paragraph`‑object kan tekst met verschillende opmaak‑eigenschappen verwerken via de onderliggende `Portion`‑objecten.

## **Installatie**

```bash
pip install aspose.slides
```

## **Meerdere alinea's met meerdere gedeelten toevoegen**

Deze stappen laten zien hoe u een tekstkader kunt toevoegen dat drie alinea's bevat, elk met drie gedeelten:

1. Maak een instantie van de [Presentation]‑klasse.
1. Verkrijg een referentie naar de doel‑dia op basis van de index.
1. Voeg een rechthoekige [AutoShape] toe aan de dia.
1. Haal het [TextFrame] op dat is gekoppeld aan de [AutoShape].
1. Maak twee [Paragraph]‑objecten en voeg ze toe aan de alinea‑collectie van het [TextFrame] (samen met de standaardalinea, dit geeft drie alinea's).
1. Voor elke alinea, maak drie [Portion]‑objecten en voeg ze toe aan de gedeelte‑collectie van die alinea.
1. Stel de tekst in voor elk gedeelte.
1. Pas de gewenste opmaak toe op elk tekstgedeelte met behulp van de eigenschappen die door [Portion] worden blootgesteld.
1. Sla de gewijzigde presentatie op.

De volgende Python‑code implementeert deze stappen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantieer de Presentation-klasse om een nieuw PPTX-bestand te maken.
with slides.Presentation() as presentation:

    # Open de eerste dia.
    slide = presentation.slides[0]

    # Voeg een rechthoekige AutoShape toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Open het TextFrame van de AutoShape.
    text_frame = shape.text_frame

    # Maak alinea's en gedeelten aan; opmaak wordt hieronder toegepast.
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
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Sla het PPTX-bestand op schijf.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Alinea‑opsommingstekens beheren**

Opsommingstekens helpen u informatie snel en efficiënt te organiseren en te presenteren. Met opsommingsteken‑alinea's is de tekst vaak makkelijker te lezen en te begrijpen.

1. Maak een instantie van de [Presentation]‑klasse.
1. Open de doel‑dia op basis van de index.
1. Voeg een [AutoShape] toe aan de dia.
1. Open het [TextFrame] van de vorm.
1. Verwijder de standaardalinea uit het [TextFrame].
1. Maak de eerste alinea met behulp van de [Paragraph]‑klasse.
1. Stel het opsommingsteken‑type van de alinea in op `SYMBOL` en geef het opsommingsteken‑karakter op.
1. Stel de tekst van de alinea in.
1. Stel de inspringing van het opsommingsteken voor de alinea in.
1. Stel de kleur van het opsommingsteken in.
1. Stel de grootte (hoogte) van het opsommingsteken in.
1. Voeg de alinea toe aan de alinea‑collectie van het [TextFrame].
1. Voeg een tweede alinea toe en herhaal stappen 7–12.
1. Sla de presentatie op.

Deze Python‑code laat zien hoe u alinea's met opsommingstekens kunt toevoegen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een presentatie‑instantie.
with slides.Presentation() as presentation:

    # Open de eerste dia.
    slide = presentation.slides[0]

    # Voeg een AutoShape toe en open deze.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Open het tekstkader van de gemaakte AutoShape.
    text_frame = shape.text_frame

    # Verwijder de standaardalinea.
    text_frame.paragraphs.remove_at(0)

    # Maak een alinea.
    paragraph = slides.Paragraph()

    # Stel de opsommingsteken‑stijl en het symbool van de alinea in.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Stel de alinea‑tekst in.
    paragraph.text = "Welcome to Aspose.Slides"

    # Stel de inspringing van het opsommingsteken in.
    paragraph.paragraph_format.indent = 25

    # Stel de kleur van het opsommingsteken in.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # Stel de hoogte van het opsommingsteken in.
    paragraph.paragraph_format.bullet.height = 100

    # Voeg de alinea toe aan het tekstkader.
    text_frame.paragraphs.add(paragraph)

    # Maak de tweede alinea.
    paragraph2 = slides.Paragraph()

    # Stel het opsommingsteken‑type en de stijl van de alinea in.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # Stel de alinea‑tekst in.
    paragraph2.text = "This is numbered bullet"

    # Stel de inspringing van het opsommingsteken in.
    paragraph2.paragraph_format.indent = 25

    # Stel de kleur van het opsommingsteken in.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # Stel de hoogte van het opsommingsteken in.
    paragraph2.paragraph_format.bullet.height = 100

    # Voeg de alinea toe aan het tekstkader.
    text_frame.paragraphs.add(paragraph2)

    # Sla de presentatie op als een PPTX‑bestand.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldings‑opsommingstekens beheren**

Opsommingsteeksen helpen u informatie snel en efficiënt te organiseren en te presenteren. Afbeeldings‑opsommingstekens zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation]‑klasse.
1. Open de doel‑dia op basis van de index.
1. Voeg een [AutoShape] toe aan de dia.
1. Open het [TextFrame] van de vorm.
1. Verwijder de standaardalinea uit het [TextFrame].
1. Maak een alinea met de [Paragraph]‑klasse en stel de tekst in.
1. Laad een afbeelding en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [PPImage].
1. Stel het opsommingsteken‑type in op `PICTURE` en wijs de [PPImage] toe aan het opsommingsteken.
1. Stel de hoogte van het opsommingsteken in.
1. Voeg de nieuwe alinea toe aan de alinea‑collectie van het [TextFrame].
1. Sla de presentatie op.

Deze Python‑code laat zien hoe u afbeeldings‑opsommingstekens kunt toevoegen en beheren:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Open de eerste dia.
    slide = presentation.slides[0]

    # Laad de opsommingsteken-afbeelding.
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # Voeg een AutoShape toe en open deze.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Open het TextFrame van de gemaakte AutoShape.
    text_frame = auto_shape.text_frame

    # Verwijder de standaardalinea.
    text_frame.paragraphs.remove_at(0)

    # Maak een nieuwe alinea.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Stel het opsommingsteken-type van de alinea in op Afbeelding en wijs de afbeelding toe.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Stel de hoogte van het opsommingsteken in.
    paragraph.paragraph_format.bullet.height = 100

    # Voeg de alinea toe aan het tekstkader.
    text_frame.paragraphs.add(paragraph)

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Sla de presentatie op als een PPT-bestand.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Meerlagige opsommingstekens beheren**

Opsommingsteeksen helpen u informatie snel en efficiënt te organiseren en te presenteren. Meerlagige opsommingstekens zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation]‑klasse.
1. Open de doel‑dia op basis van de index.
1. Voeg een [AutoShape] toe aan de dia.
1. Open het [AutoShape]‑[TextFrame].
1. Verwijder de standaardalinea uit het [TextFrame].
1. Maak de eerste alinea met de [Paragraph]‑klasse en stel de diepte in op 0.
1. Maak de tweede alinea met de [Paragraph]‑klasse en stel de diepte in op 1.
1. Maak de derde alinea met de [Paragraph]‑klasse en stel de diepte in op 2.
1. Maak de vierde alinea met de [Paragraph]‑klasse en stel de diepte in op 3.
1. Voeg de nieuwe alinea's toe aan de alinea‑collectie van het [TextFrame].
1. Sla de presentatie op.

De volgende Python‑code laat zien hoe u meerlagige opsommingstekens kunt toevoegen en beheren:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een presentatie‑instantie.
with slides.Presentation() as presentation:

    # Open de eerste dia.
    slide = presentation.slides[0]
    
    # Voeg een AutoShape toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Open het TextFrame van de gemaakte AutoShape.
    text_frame = shape.text_frame
    
    # Wis de standaardalinea.
    text_frame.paragraphs.clear()

    # Voeg de eerste alinea toe.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Stel het opsommingsteken‑niveau in.
    paragraph1.paragraph_format.depth = 0

    # Voeg de tweede alinea toe.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Stel het opsommingsteken‑niveau in.
    paragraph2.paragraph_format.depth = 1

    # Voeg de derde alinea toe.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Stel het opsommingsteken‑niveau in.
    paragraph3.paragraph_format.depth = 2

    # Voeg de vierde alinea toe.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Stel het opsommingsteken‑niveau in.
    paragraph4.paragraph_format.depth = 3

    # Voeg de alinea's toe aan de collectie.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Sla de presentatie op als een PPTX‑bestand.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Alinea's beheren met aangepaste genummerde lijsten**

De [BulletFormat]‑klasse biedt de eigenschap `numbered_bullet_start_with` (en andere) om aangepaste nummering en opmaak voor alinea's te regelen.

1. Maak een instantie van de [Presentation]‑klasse.
1. Open de dia die de alinea's zal bevatten.
1. Voeg een [AutoShape] toe aan de dia.
1. Open het [TextFrame] van de vorm.
1. Verwijder de standaardalinea uit het [TextFrame].
1. Maak de eerste [Paragraph] en stel `numbered_bullet_start_with` in op 2.
1. Maak de tweede [Paragraph] en stel `numbered_bullet_start_with` in op 3.
1. Maak de derde [Paragraph] en stel `numbered_bullet_start_with` in op 7.
1. Voeg de alinea's toe aan de collectie van het [TextFrame].
1. Sla de presentatie op.

De volgende Python‑code toont hoe u alinea's met aangepaste nummering en opmaak kunt toevoegen en beheren.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Voeg een AutoShape toe en open deze.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Open het TextFrame van de gemaakte AutoShape.
    text_frame = shape.text_frame

    # Verwijder de bestaande standaardalinea.
    text_frame.paragraphs.remove_at(0)

    # Maak het eerste genummerde item (start bij 2, diepte 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Maak het tweede genummerde item (start bij 3, diepte 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Maak het derde genummerde item (start bij 7, diepte 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eerste‑regelinspringing instellen voor een alinea**

Gebruik de eigenschap [ParagraphFormat.indent] om de eerste‑regelinspringing van een alinea te regelen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat.margin_left] wanneer u de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat.indent] wanneer u alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt meerdere alinea's en past verschillende `indent`‑waarden toe om te demonstreren hoe de eerste‑regelinspringing de lay-out van de alinea beïnvloedt.

1. Maak een instantie van de [Presentation]‑klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape] toe aan de dia.
4. Voeg een leeg [TextFrame] toe aan de vorm en verwijder de standaardalinea.
5. Maak meerdere alinea's en stel verschillende [indent]‑waarden voor hen in.
6. Voeg de alinea's toe aan het tekstkader.
7. Sla de gewijzigde presentatie op.

Deze code toont hoe u een alinea‑inspringing kunt instellen:

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

![De eerste‑regelinspringing van de alinea's](first_line_indent.png)

## **Hangende inspringing instellen voor een alinea**

Een hangende inspringing is een alinea‑lay-out waarbij de eerste regel links van de volgende regels begint. In Aspose.Slides creëert u dit effect met de eigenschap [ParagraphFormat.indent]. Stel `indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk definieert [ParagraphFormat.margin_left] de linkse positie van de alinea‑inhoud, en [ParagraphFormat.indent] definieert de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te maken, stelt u een positieve `margin_left`‑waarde en een negatieve `indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, glossarium‑vermeldingen en andere alinea's waarbij de regelafbrekingen onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation]‑klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape] toe aan de dia.
4. Voeg een leeg [TextFrame] toe aan de vorm en verwijder de standaardalinea.
5. Maak alinea's en stel voor elke alinea een positieve [margin_left]‑waarde in.
6. Stel een negatieve [indent]‑waarde in om het hangende inspringingseffect te creëren.
7. Voeg de alinea's toe aan het tekstkader.
8. Sla de gewijzigde presentatie op.

Deze code toont hoe u een hangende inspringing voor een alinea kunt instellen:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

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

![De hangende inspringing van de alinea's](hanging_indent.png)

## **Einde‑van‑alinea‑gedeelte‑opmaak beheren**

Wanneer u de opmaak van het "einde" van een alinea (de opmaak die wordt toegepast na het laatste tekstgedeelte) moet regelen, gebruikt u de eigenschap `end_paragraph_portion_format`. Het voorbeeld hieronder past een groter Times New Roman‑lettertype toe op het einde van de tweede alinea.

1. Maak een [Presentation]‑bestand aan of open er een.
2. Haal de doel‑dia op op basis van de index.
3. Voeg een rechthoekige [AutoShape] toe aan de dia.
4. Gebruik het [TextFrame] van de vorm en maak twee alinea's.
5. Maak een [PortionFormat] met 48‑pt Times New Roman en pas deze toe als de einde‑van‑alinea‑gedeelte‑opmaak van de alinea.
6. Ken het toe aan de `end_paragraph_portion_format` van de alinea (geldt voor het einde van de tweede alinea).
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u de einde‑van‑alinea‑opmaak voor de tweede alinea kunt instellen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# Verwijder de standaardalinea.
	shape.text_frame.paragraphs.clear()

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

## **HTML‑tekst importeren in alinea's**

Aspose.Slides biedt verbeterde ondersteuning voor het importeren van HTML‑tekst in alinea's.

1. Maak een instantie van de [Presentation]‑klasse.
1. Open de doel‑dia op basis van de index.
1. Voeg een [AutoShape] toe aan de dia.
1. Open het [TextFrame] van de [AutoShape].
1. Verwijder de standaardalinea uit het [TextFrame].
1. Lees het bron‑HTML‑bestand.
1. Voeg de HTML‑inhoud toe aan de alinea‑collectie van het [TextFrame].
1. Sla de gewijzigde presentatie op.

De volgende Python‑code implementeert deze stappen voor het importeren van HTML‑tekst in alinea's.

```python
import aspose.slides as slides

# Maak een lege Presentatie‑instantie.
with slides.Presentation() as presentation:

    # Open de eerste dia van de presentatie.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Voeg een AutoShape toe om de HTML‑inhoud te bevatten.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Wis alle alinea's in het toegevoegde tekstkader.
    shape.text_frame.paragraphs.clear()

    # Laad het HTML‑bestand.
    with open("file.html", "rt") as html_stream:
        # Voeg tekst uit het HTML‑bestand toe aan het tekstkader.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Sla de presentatie op.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt verbeterde ondersteuning voor het exporteren van tekst naar HTML.

1. Maak een instantie van de [Presentation]‑klasse en laad de doelpresentatie.
1. Open de gewenste dia op basis van de index.
1. Selecteer de vorm die de te exporteren tekst bevat.
1. Open het [TextFrame] van de vorm.
1. Open een bestandsstream om de HTML‑uitvoer te schrijven.
1. Geef de start‑index op en exporteer de benodigde alinea's.

Dit Python‑voorbeeld laat zien hoe u alinea‑tekst naar HTML kunt exporteren.

```python
import aspose.slides as slides

# Laad het presentiebestand.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Open de eerste dia van de presentatie.
    slide = presentation.slides[0]

    # Doelvorm-index.
    index = 0

    # Open de vorm op basis van de index.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Schrijf alinea-gegevens naar HTML door de start-alinea-index en het totale aantal te exporteren alinea's op te geven.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Een alinea opslaan als afbeelding**

In deze sectie verkennen we twee voorbeelden die laten zien hoe u een tekst‑alinea, vertegenwoordigd door de [Paragraph]‑klasse, als afbeelding kunt opslaan. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat met behulp van de `get_image`‑methoden van de [Shape]‑klasse, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren ervan als een bitmap‑afbeelding. Deze benaderingen stellen u in staat om specifieke delen van de tekst uit PowerPoint‑presentaties te extraheren en op te slaan als afzonderlijke afbeeldingen, wat nuttig kan zijn voor later gebruik in verschillende scenario's.

Laten we aannemen dat we een presentiebestand hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld verkrijgen we de tweede alinea als afbeelding. Hiervoor extraheren we de afbeelding van de vorm van de eerste dia van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstkader van de vorm. De alinea wordt daarna opnieuw getekend op een nieuwe bitmap‑afbeelding, die wordt opgeslagen in PNG‑formaat. Deze methode is vooral nuttig wanneer u een specifieke alinea als afzonderlijke afbeelding wilt opslaan terwijl de exacte afmetingen en opmaak van de tekst behouden blijven.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Sla de vorm in het geheugen op als een bitmap.
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

![De alinea-afbeelding](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren aan de alinea‑afbeelding toe te voegen. De vorm wordt uit de presentatie gehaald en opgeslagen als afbeelding met een schaalfactor van `2`. Hierdoor ontstaat een afbeelding met hogere resolutie bij het exporteren van de alinea. De alinea‑grenzen worden vervolgens berekend rekening houdend met de schaal. Schalen kan bijzonder nuttig zijn wanneer een gedetailleerdere afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardige gedrukte materialen.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Sla de vorm in het geheugen op als een bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Maak een bitmap van de vorm vanuit het geheugen.
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

    # Snijd de vorm-bitmap bij om alleen de alinea-bitmap te krijgen.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

### Kan ik de regelomslag volledig uitschakelen binnen een tekstkader?

Ja. Gebruik de omslaginstelling van het tekstkader ([wrap_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/wrap_text/)) om omslag uit te schakelen zodat regels niet breken aan de randen van het kader.

### Hoe kan ik de exacte positie op de dia van een specifieke alinea verkrijgen?

U kunt de begrenzende rechthoek van de alinea (en zelfs van een enkel gedeelte) ophalen om de exacte positie en grootte op de dia te kennen.

### Waar wordt de alinea‑uitlijning (links/rechts/centraal/uitvullen) geregeld?

[Alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/alignment/) is een instelling op alinea‑niveau in [ParagraphFormat]; deze wordt toegepast op de gehele alinea, ongeacht de opmaak van individuele gedeelten.

### Kan ik een spellingscontrole‑taal instellen voor slechts een deel van een alinea (bijv. één woord)?

Ja. De taal wordt ingesteld op gedeelte‑niveau ([PortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/)), zodat meerdere talen binnen één alinea kunnen bestaan.