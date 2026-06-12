---
title: Maak een presentatiewiewer in Python
linktitle: Presentatiewiewer
type: docs
weight: 50
url: /nl/python-net/presentation-viewer/
keywords:
- presentatie bekijken
- presentatiewiewer
- presentatiewiewer maken
- PPT bekijken
- PPTX bekijken
- ODP bekijken
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Leer hoe u met Aspose.Slides een aangepaste presentatiewiewer in Python kunt maken. Toon eenvoudig PowerPoint (PPTX, PPT) en OpenDocument (ODP) bestanden zonder Microsoft PowerPoint of andere kantoortoepassingen."
---
## **Inleiding**

Aspose.Slides voor Python wordt gebruikt om presentatiedocumenten met dia's te maken. Deze dia's kunnen bijvoorbeeld worden bekeken door de presentaties te openen in Microsoft PowerPoint. Ontwikkelaars moeten echter soms dia's als afbeeldingen bekijken in hun favoriete beeldviewer of ze gebruiken in een aangepaste presentatieviewer. In dergelijke gevallen stelt Aspose.Slides u in staat om individuele dia's als afbeeldingen te exporteren. Dit artikel legt uit hoe u dat doet.

## **Genereer een SVG‑afbeelding van een dia**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
2. Verkrijg een referentie naar de dia op basis van de index.  
3. Open een bestandsstroom.  
4. Sla de dia op als een SVG‑afbeelding in de bestandsstroom.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Maak een miniatuurafbeelding van een dia**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
2. Verkrijg een referentie naar de dia op basis van de index.  
3. Maak een miniatuurafbeelding van de gerefereerde dia op de gewenste schaal.  
4. Sla de miniatuurafbeelding op in uw gewenste afbeeldingsformaat.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Maak een miniatuurafbeelding van een dia met door de gebruiker gedefinieerde afmetingen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
2. Verkrijg een referentie naar de dia op basis van de index.  
3. Genereer een miniatuurafbeelding van de gerefereerde dia met de opgegeven afmetingen.  
4. Sla de miniatuurafbeelding op in uw gewenste afbeeldingsformaat.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Maak een miniatuurafbeelding van een dia met spreker notities**

1. Maak een instantie van de [RenderingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/renderingoptions/) klasse.  
2. Gebruik de eigenschap `RenderingOptions.slides_layout_options` om de positie van de spreker notities in te stellen.  
3. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
4. Verkrijg een referentie naar de dia op basis van de index.  
5. Genereer een miniatuurafbeelding van de gerefereerde dia met behulp van de rendering‑opties.  
6. Sla de miniatuurafbeelding op in uw gewenste afbeeldingsformaat.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Live‑voorbeeld**

Probeer de gratis app [**Aspose.Slides Viewer**](https://products.aspose.app/slides/nl/viewer/) om te zien wat u kunt implementeren met de Aspose.Slides‑API:

[![Online PowerPoint‑viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/nl/viewer/)

## **FAQ**

**Kan ik een presentatiewiewer inbedden in een ASP.NET‑webapplicatie?**

Ja. U kunt Aspose.Slides aan de serverzijde gebruiken om dia's te renderen als [afbeeldingen](/slides/nl/python-net/convert-powerpoint-to-png/) of [HTML](/slides/nl/python-net/convert-powerpoint-to-html/) en ze weergeven in de browser. Navigatie‑ en zoomfuncties kunnen met JavaScript worden geïmplementeerd voor een interactieve ervaring.

**Wat is de beste manier om dia's weer te geven in een aangepaste .NET‑viewer?**

De aanbevolen aanpak is om elke dia te renderen als een [afbeelding](/slides/nl/python-net/convert-powerpoint-to-png/) (bijv. PNG of SVG) of deze te converteren naar [HTML](/slides/nl/python-net/convert-powerpoint-to-html/) met Aspose.Slides, en vervolgens de uitvoer weer te geven in een picture box (voor desktop) of een HTML‑container (voor web).

**Hoe ga ik om met grote presentaties met veel dia's?**

Voor grote presentaties kunt u overwegen om dia's lazily te laden of on‑demand te renderen. Dit betekent dat de inhoud van een dia alleen wordt gegenereerd wanneer de gebruiker er naartoe navigeert, waardoor geheugen‑ en laadtijd worden verminderd.