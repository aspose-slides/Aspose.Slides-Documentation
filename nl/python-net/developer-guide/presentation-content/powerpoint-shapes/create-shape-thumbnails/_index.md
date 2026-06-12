---
title: Miniaturen van presentatievormen maken in Python
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/python-net/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint- en OpenDocument-dia's met Aspose.Slides for Python via .NET – maak en exporteer eenvoudig presentatieminiaturen."
---
## **Inleiding**

Aspose.Slides for Python via .NET wordt gebruikt om presentatie‑bestanden te maken waarbij elke pagina een dia is. U kunt deze dia’s bekijken in Microsoft PowerPoint door het presentatie‑bestand te openen. Soms moeten ontwikkelaars echter afbeeldingen van vormen afzonderlijk bekijken in een afbeeldingsviewer. In zulke gevallen kan Aspose.Slides miniatuur‑afbeeldingen voor dia‑vormen genereren. Dit artikel legt uit hoe u deze functie kunt gebruiken.

## **Miniaturen van vormen genereren vanuit dia’s**

Wanneer u een voorbeeld van een specifiek object wilt zien in plaats van de volledige dia, kunt u een miniatuur voor een individuele vorm renderen. Aspose.Slides laat u elke vorm exporteren naar een afbeelding, waardoor het eenvoudig is om lichte previews, iconen of assets voor nabewerking te maken.

Om een miniatuur van een willekeurige vorm te genereren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van diens ID of index.
1. Haal een referentie op naar een vorm op die dia.
1. Render de miniatuur‑afbeelding van de vorm.
1. Sla de miniatuur‑afbeelding op in het gewenste formaat.

Het voorbeeld hieronder genereert een miniatuur van een vorm.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het presentatiebestand te openen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Maak een afbeelding met de standaard schaal.
    with shape.get_image() as thumbnail:
        # Sla de afbeelding op schijf in PNG-formaat.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Miniaturen genereren met een aangepaste schaalfactor**

In dit gedeelte wordt getoond hoe u miniaturen van vormen kunt genereren met een zelf gedefinieerde schaalfactor in Aspose.Slides. Door de schaal te regelen, kunt u de miniatuurgrootte fijn afstemmen voor previews, exports of high‑DPI‑beeldschermen.

Om een miniatuur voor een willekeurige vorm op een dia te genereren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een dia op op basis van diens ID of index.
1. Haal de doelvorm op die dia.
1. Render de miniatuur‑afbeelding van de vorm met de opgegeven schaal.
1. Sla de miniatuur‑afbeelding op in het gewenste formaat.

Het voorbeeld hieronder genereert een miniatuur met een zelf gedefinieerde schaalfactor.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instantieer de Presentation-klasse om het presentatiebestand te openen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Maak een afbeelding met de gedefinieerde schaal.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Sla de afbeelding op schijf in PNG-formaat.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Miniaturen genereren met de weergave‑grenzen van een vorm**

Dit gedeelte laat zien hoe u een miniatuur binnen de weergave‑grenzen van een vorm kunt genereren. Er wordt rekening gehouden met alle vorm‑effecten. De gegenereerde miniatuur wordt beperkt door de dia‑grenzen.

Om een miniatuur van een willekeurige dia‑vorm binnen de grenzen van zijn weergave te genereren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een dia op op basis van diens ID of index.
1. Haal de doelvorm op die dia.
1. Render de miniatuur‑afbeelding van de vorm met de opgegeven grenzen.
1. Sla de miniatuur‑afbeelding op in het gewenste afbeeldingsformaat.

Het voorbeeld hieronder maakt een miniatuur met zelf gedefinieerde grenzen.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instantieer de Presentation-klasse om het presentatiebestand te openen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Maak een afbeelding van de vorm binnen de weergavegrenzen.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Sla de afbeelding op schijf in PNG-formaat.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van miniaturen van vormen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector‑SVG](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/write_as_svg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen SHAPE‑ en APPEARANCE‑grenzen bij het renderen van een miniatuur?**

`SHAPE` gebruikt de geometrie van de vorm; `APPEARANCE` houdt rekening met [visuele effecten](/slides/nl/python-net/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt er toch een miniatuur gegenereerd?**

Een verborgen vorm blijft onderdeel van het model en kan worden gerenderd; de verborgen‑vlag heeft alleen invloed op de weergave in de diavoorstelling, maar verhindert niet dat de afbeelding van de vorm wordt gegenereerd.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/), en [SmartArt](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/)) kan worden opgeslagen als miniatuur of als SVG.

**Hebben systeem‑geïnstalleerde lettertypen invloed op de kwaliteit van miniaturen voor tekstvormen?**

Ja. U moet de benodigde lettertypen [leveren](/slides/nl/python-net/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/python-net/font-substitution/)) om ongewenste fallback‑lettertypen en tekst‑herindelingen te vermijden.