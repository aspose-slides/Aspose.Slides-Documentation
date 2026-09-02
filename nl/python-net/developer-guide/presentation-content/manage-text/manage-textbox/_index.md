---
title: Beheer van tekstvakken in presentaties met Python
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/python-net/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Aspose.Slides voor Python via .NET maakt het eenvoudig om tekstvakken te maken, te bewerken en te klonen in PowerPoint- en OpenDocument-bestanden, waardoor uw presentatiesautomatisering wordt verbeterd."
---
## **Introductie**

Teksten op dia's staan meestal in tekstvakken of vormen. Daarom moet je, om tekst aan een dia toe te voegen, een tekstvak toevoegen en vervolgens tekst in dat vak plaatsen. Aspose.Slides for Python biedt de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/)‑klasse waarmee je een vorm met tekst kunt toevoegen.

{{% alert title="Info" color="info" %}}
Aspose.Slides biedt ook de [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑klasse. Echter kunnen niet alle vormen tekst bevatten.
{{% /alert %}}

{{% alert title="Opmerking" color="warning" %}}
Wanneer je met een vorm werkt waaraan je tekst wilt toevoegen, wil je wellicht controleren of deze via de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/)‑klasse is omgezet. Pas daarna kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/), een eigenschap van [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/). Zie de sectie [Update Text](/slides/nl/python-net/manage-textbox/#update-text) op deze pagina.
{{% /alert %}}

## **Tekstvakken maken op dia's**

Om een tekstvak op een dia te maken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Haal een referentie op naar de eerste dia.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) met `ShapeType.RECTANGLE` toe op de gewenste positie op de dia.
4. Stel de tekst in het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm in.
5. Sla de presentatie op als een PPTX‑bestand.

Het volgende Python‑voorbeeld implementeert deze stappen:

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse.
with slides.Presentation() as presentation:

    # Haal de eerste dia op in de presentatie.
    slide = presentation.slides[0]

    # Voeg een AutoShape van het type RECTANGLE toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Sla de presentatie op schijf.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Controleren of een vorm een tekstvak is**

Aspose.Slides biedt de eigenschap [is_text_box](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/is_text_box/) op de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/)‑klasse, waarmee je kunt bepalen of een vorm een tekstvak is.

![Tekstvak en vorm](istextbox.png)

Dit Python‑voorbeeld toont hoe je controleert of een vorm als tekstvak is aangemaakt:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Merk op dat wanneer je een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toevoegt via de [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/)‑klasse, de eigenschap `is_text_box` van de vorm `False` teruggeeft. Nadat je echter tekst hebt toegevoegd – ofwel met de `add_text_frame`‑methode of door de `text`‑eigenschap in te stellen – geeft `is_text_box` `True` terug.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box is onwaar
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box is waar

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box is onwaar
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box is waar

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box is onwaar
    shape3.add_text_frame("")
    # shape3.is_text_box is onwaar

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box is onwaar
    shape4.text_frame.text = ""
    # shape4.is_text_box is onwaar
```

## **De vorm vinden die een TextFrame bezit**

In generieke tekstverwerkingscode kun je een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) ontvangen zonder te weten tot welke presentatie‑object het behoort. Gebruik de eigenschap [TextFrame.parent_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_shape/) om terug te navigeren naar de bijbehorende [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/).

Voor een tekstframe dat behoort tot een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) of een andere tekstdragende vorm, is [TextFrame.parent_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_shape/) ingesteld en is [TextFrame.parent_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_cell/) `None`. Beide eigenschappen zijn alleen‑lezen navigatie‑eigenschappen, dus het lezen ervan verandert de eigendom niet. Controleer altijd op `None` voordat je de vorm benadert.

Voor een compleet voorbeeld dat vorm‑ en tabelcel‑eigenaars identificeert, inclusief vormen die bij SmartArt‑knooppunten horen, zie [Search and Replace Text](/slides/nl/python-net/search-and-replace-text/).

## **Kolommen toevoegen aan tekstvakken**

Aspose.Slides biedt de eigenschappen [column_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/column_count/) en [column_spacing](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/column_spacing/) op de [TextFrameFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/)‑klasse om kolommen aan tekstvakken toe te voegen. Je kunt het aantal kolommen opgeven en de ruimte (in punten) tussen kolommen instellen.

De volgende Python‑code toont deze bewerking:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Haal de eerste dia op in de presentatie.
	slide = presentation.slides[0]

	# Voeg een AutoShape van het type RECTANGLE toe.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Voeg een TextFrame toe aan de rechthoek.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Haal het tekstopmaak van het TextFrame op.
	format = shape.text_frame.text_frame_format

	# Geef het aantal kolommen op in het TextFrame.
	format.column_count = 3

	# Geef de tussenruimte tussen kolommen op.
	format.column_spacing = 10

	# Sla de presentatie op.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekst bijwerken**

Aspose.Slides stelt je in staat om de tekst in één tekstvak of in de hele presentatie bij te werken.

Het volgende Python‑voorbeeld demonstreert hoe je alle tekst in een presentatie bijwerkt:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Sla de gewijzigde presentatie op.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekstvakken met hyperlinks toevoegen** 

Je kunt een koppeling in een tekstvak invoegen. Wanneer op het tekstvak wordt geklikt, wordt de koppeling geopend.

Om een tekstvak met een hyperlink toe te voegen, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Haal een referentie op naar de eerste dia.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) met `ShapeType.RECTANGLE` toe op de gewenste positie op de dia.
4. Stel de tekst in het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van de vorm in.
5. Haal een referentie op naar de [HyperlinkManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlinkmanager/).
6. Gebruik de eigenschap `hyperlink_manager` om een externe klik‑hyperlink in te stellen.
7. Sla de presentatie op als een PPTX‑bestand.

Dit Python‑voorbeeld toont hoe je een tekstvak met een hyperlink aan een dia toevoegt:

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse.
with slides.Presentation() as presentation:

    # Haal de eerste dia op in de presentatie.
    slide = presentation.slides[0]

    # Voeg een AutoShape van het type RECTANGLE toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Voeg tekst toe aan het frame.
    text_portion.text = "Aspose.Slides"

    # Stel een hyperlink in voor de portion-tekst.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑plaatsaanduiding bij het werken met masterslides?**

Een [placeholder](/slides/nl/python-net/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslide/) en kan op [layouts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/) worden overschreven, terwijl een regulier tekstvak een onafhankelijk object is op een specifieke dia en niet verandert wanneer je van layout wisselt.

**Hoe kan ik een bulk‑tekstvervanging uitvoeren in de hele presentatie zonder tekst in grafieken, tabellen en SmartArt aan te raken?**

Beperk je iteratie tot auto‑shapes die tekstframes hebben en sluit ingesloten objecten ([charts](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/)) uit door hun collecties apart te doorlopen of die objecttypen over te slaan.