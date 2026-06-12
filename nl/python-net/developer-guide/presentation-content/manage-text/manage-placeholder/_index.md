---
title: Beheer plaatsaanduidingen in presentaties met Python
linktitle: Beheer plaatsaanduidingen
type: docs
weight: 10
url: /nl/python-net/manage-placeholder/
keywords:
- plaatsaanduiding
- tekstplaatsaanduiding
- afbeeldingsplaatsaanduiding
- grafiekplaatsaanduiding
- prompt-tekst
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer moeiteloos plaatsaanduidingen in Aspose.Slides voor Python via .NET: vervang tekst, pas prompts aan en stel afbeeldings-transparantie in PowerPoint en OpenDocument in."
---
## **Overzicht**

Met Aspose.Slides kunt u presentatie‑plaatsaanduidingen programmatisch beheren. Dit artikel legt uit hoe u plaatsaanduidingen op dia’s kunt vinden en hun tekst kunt wijzigen, aangepaste prompt‑tekst voor plaatsaanduidingslay-outs kunt instellen, en de transparantie van een afbeelding die als achtergrond van een plaatsaanduiding wordt gebruikt, kunt aanpassen. Het bevat ook een korte FAQ die het verschil tussen basis‑plaatsaanduidingen en lokale vormen verduidelijkt, uitlegt hoe plaatsaanduidingswijzigingen kunnen worden toegepast via lay-outs of masters, en wijst op het beheer van kop‑ en voettekst‑plaatsaanduidingen.

## **Tekst wijzigen in plaatsaanduidingen**

Met Aspose.Slides voor Python kunt u plaatsaanduidingen op dia’s in een presentatie vinden en aanpassen. Aspose.Slides stelt u in staat de tekst in een plaatsaanduiding te wijzigen.

**Voorvereiste:** U hebt een presentatie nodig die een plaatsaanduiding bevat. Zo’n presentatie kunt u maken in Microsoft PowerPoint.

Zo gebruikt u Aspose.Slides om de tekst in een plaatsaanduiding te vervangen:

1. Instantiëer de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en geef de presentatie als argument door.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Itereer door de vormen om de plaatsaanduiding te vinden.
4. Wijzig de tekst met behulp van het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) dat gekoppeld is aan de [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/).
5. Sla de aangepaste presentatie op.

Deze Python‑code laat zien hoe u de tekst in een plaatsaanduiding wijzigt:

```python
import aspose.slides as slides

# Instantieer de Presentation-klasse.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Itereer door de vormen om plaatsaanduidingen te vinden.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Wijzig de tekst in elke plaatsaanduiding.
            shape.text_frame.text = "This is Placeholder"

    # Sla de presentatie op naar schijf.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Prompt‑tekst instellen voor een plaatsaanduiding**

Standaard‑ en vooraf gebouwde lay-outs bevatten prompt‑tekst voor plaatsaanduidingen, zoals **Click to add a title** of **Click to add a subtitle**. Met Aspose.Slides kunt u deze prompts vervangen door uw eigen tekst in de plaatsaanduidings‑lay-outs.

Het volgende Python‑voorbeeld laat zien hoe u de prompt‑tekst voor een plaatsaanduiding instelt:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Itereer door vormen om plaatsaanduidingen te vinden.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingstransparantie instellen in een plaatsaanduiding**

Met Aspose.Slides kunt u de transparantie van een achtergrondafbeelding in een tekst‑plaatsaanduiding instellen. Door de transparantie van de afbeelding in dat frame aan te passen, kunt u of de tekst of de afbeelding laten opvallen, afhankelijk van hun kleuren.

Het volgende Python‑voorbeeld laat zien hoe u de transparantie van een afbeelding‑achtergrond in een vorm instelt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**Wat is een basis‑plaatsaanduiding en hoe verschilt deze van een lokale vorm op een dia?**

Een basis‑plaatsaanduiding is de oorspronkelijke vorm op een lay-out of master waarvan de vorm op de dia erft — type, positie en sommige opmaak komen van die vorm. Een lokale vorm staat op zichzelf; als er geen basis‑plaatsaanduiding is, geldt er geen overerving.

**Hoe kan ik alle titels of bijschriften in een presentatie bijwerken zonder iedere dia te doorlopen?**

Bewerk de bijbehorende plaatsaanduiding op de lay-out of de master. Dia’s die gebaseerd zijn op die lay-outs/master erven de wijziging automatisch.

**Hoe beheer ik de standaard kop‑/voettekst‑plaatsaanduidingen — datum & tijd, dia‑nummer en voettekst?**

Gebruik de HeaderFooter‑beheerders op de juiste scope (normale dia’s, lay-outs, master, notities/hand-outs) om die plaatsaanduidingen in of uit te schakelen en hun inhoud in te stellen.