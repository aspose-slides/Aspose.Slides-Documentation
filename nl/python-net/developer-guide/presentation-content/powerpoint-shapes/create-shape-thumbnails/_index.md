---
title: "Miniaturen van presentatievormen maken in Python"
linktitle: "Vormminiaturen"
type: docs
weight: 70
url: /nl/python-net/create-shape-thumbnails/
keywords:
- "vorm miniatuur"
- "vorm afbeelding"
- "vorm renderen"
- "vormrendering"
- "visuele grenzen"
- "vormgrenzen"
- "PowerPoint"
- "presentatie"
- "Python"
- "Aspose.Slides"
description: "Genereer hoogwaardige vormminiaturen van PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via .NET – maak en exporteer eenvoudig presentatieminiaturen."
---
## **Inleiding**

Aspose.Slides voor Python via .NET wordt gebruikt om presentatiebestanden te maken waarin elke pagina een dia is. Je kunt deze dia's bekijken in Microsoft PowerPoint door het presentatiebestand te openen. Soms moeten ontwikkelaars echter afbeeldingen van vormen afzonderlijk bekijken in een afbeeldingsviewer. In zulke gevallen kan Aspose.Slides miniatuurafbeeldingen voor dia‑vormen genereren. Dit artikel legt uit hoe je deze functionaliteit gebruikt.

## **Miniaturen van vormen uit dia's genereren**

Wanneer je een voorvertoning van een specifiek object nodig hebt in plaats van de volledige dia, kun je een miniatuur voor een individuele vorm renderen. Aspose.Slides stelt je in staat elke vorm naar een afbeelding te exporteren, waardoor het eenvoudig wordt om lichtgewicht voorvertoningen, pictogrammen of assets voor verdere verwerking te maken.

Om een miniatuur van een willekeurige vorm te genereren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn ID of index.
1. Verkrijg een referentie naar een vorm op die dia.
1. Render de miniatuurafbeelding van de vorm.
1. Sla de miniatuurafbeelding op in het gewenste formaat.

Het voorbeeld hieronder genereert een miniatuur van een vorm.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse om het presentatiebestand te openen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Maak een afbeelding met de standaard schaal.
    with shape.get_image() as thumbnail:
        # Sla de afbeelding op schijf op in PNG‑formaat.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Miniaturen genereren met een aangepaste schaalfactor**

Deze sectie toont hoe je vormminiaturen kunt genereren met een door de gebruiker gedefinieerde schaalfactor in Aspose.Slides. Door de schaal te regelen, kun je de miniatuurgrootte nauwkeurig afstemmen op voorvertoningen, exports of high‑DPI‑schermen.

Om een miniatuur voor een willekeurige vorm op een dia te genereren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een dia op basis van zijn ID of index.
1. Verkrijg de doelvorm op die dia.
1. Render de miniatuurafbeelding van de vorm met de opgegeven schaal.
1. Sla de miniatuurafbeelding op in het gewenste formaat.

Het voorbeeld hieronder genereert een miniatuur met een door de gebruiker gedefinieerde schaalfactor.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Maak een instantie van de Presentation-klasse om het presentatiebestand te openen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Maak een afbeelding met de gedefinieerde schaal.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Sla de afbeelding op schijf op in PNG-formaat.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Miniaturen genereren met behulp van de weergave‑grenzen van een vorm**

Deze sectie toont hoe je een miniatuur kunt genereren binnen de weergave‑grenzen van een vorm. Hierbij worden alle vormeffecten meegenomen. De gegenereerde miniatuur wordt beperkt door de dia‑grenzen.

Om een miniatuur van een willekeurige dia‑vorm binnen de grenzen van zijn weergave te genereren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een dia op basis van zijn ID of index.
1. Verkrijg de doelvorm op die dia.
1. Render de miniatuurafbeelding van de vorm met de opgegeven grenzen.
1. Sla de miniatuurafbeelding op in het gewenste afbeeldingsformaat.

Het voorbeeld hieronder maakt een miniatuur met door de gebruiker gedefinieerde grenzen.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Maak een instantie van de Presentation-klasse om het presentatiebestand te openen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Maak een afbeelding van de vorm binnen de weergavegrenzen.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Sla de afbeelding op schijf op in PNG-formaat.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **De werkelijke visuele grenzen van een vorm ophalen**

De frame‑eigenschappen van een [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)—`Shape.x`, `Shape.y`, `Shape.width` en `Shape.height`—beschrijven het rechthoekige gebied dat in het presentatiemodel wordt opgeslagen. De inhoud die daadwerkelijk wordt gerenderd kan buiten dat frame uitsteken of een ander rechthoekig, as‑gealignerd gebied innemen. Rotatie, contouren, pijlpunten, tekstopmaak en overflow, gegenereerde SmartArt‑geometrie en andere render‑effecten kunnen allemaal het bezette gebied wijzigen.

Gebruik [Shape.get_visual_bounds](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_visual_bounds/) om dat bezette gebied te berekenen zonder een afbeelding te maken. De methode retourneert een zwevend‑kommagetallen‑rechthoek in dia‑coördinaten. Het geretourneerde rechthoek wordt niet bijgesneden tot de dia, waardoor de coördinaten negatief kunnen zijn wanneer de inhoud buiten de oorsprong van de dia reikt.

Het volgende voorbeeld haalt en vergelijkt de frame‑ en visuele grenzen op:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Hetzelfde rechthoek kan worden gebruikt om naburige vormen uit te lijnen op de `left`, `right`, `top` of `bottom` rand; voldoende ruimte te reserveren in een gegenereerde lay‑out; of inhoud buiten een toegestane regio te detecteren. Visuele grenzen zijn bijzonder nuttig voor SmartArt, tekstvakken, pijlen, afbeeldingen, gedraaide vormen en groep‑vormen, waarbij het opgeslagen frame mogelijk niet het volledige gerenderde resultaat weergeeft.

Gebruik [Shape.get_visual_bounds](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_visual_bounds/) wanneer je coördinaten nodig hebt voor lay‑out of validatie en geen bitmap nodig hebt. Gebruik [Shape.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/) wanneer je de vorm moet renderen. Met [ShapeThumbnailBounds](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapethumbnailbounds/) bepaalt `ShapeThumbnailBounds.SHAPE` de afbeelding op basis van de vorm‑grenzen, inclusief de contourinstellingen, terwijl `ShapeThumbnailBounds.APPEARANCE` de afbeelding baseert op de weergave van de vorm en het resultaat beperkt tot de dia‑grenzen. Daarentegen retourneert `Shape.get_visual_bounds` alleen het berekende rechthoek en snijdt het niet af tot de dia.

## **Veelgestelde vragen**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van vormminiaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector‑SVG](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/write_as_svg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen SHAPE‑ en APPEARANCE‑grenzen bij het renderen van een miniatuur?**

`SHAPE` gebruikt de geometrie van de vorm; `APPEARANCE` houdt rekening met [visuele effecten](/slides/nl/python-net/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt er nog steeds een miniatuur van gerenderd?**

Een verborgen vorm blijft onderdeel van het model en kan gerenderd worden; de verborgen‑vlag beïnvloedt de weergave tijdens de diavoorstelling maar voorkomt niet dat de afbeelding van de vorm wordt gegenereerd.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/) en [SmartArt](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/)) kan worden opgeslagen als een miniatuur of als SVG.

**Beïnvloeden systeem‑geïnstalleerde lettertypen de kwaliteit van miniaturen voor tekstvormen?**

Ja. Je moet de benodigde lettertypen [voorzien](/slides/nl/python-net/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/python-net/font-substitution/)) om ongewenste fallback‑opties en tekst‑herindelingen te vermijden.