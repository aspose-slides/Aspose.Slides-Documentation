---
title: PowerPoint-dia's converteren naar PNG in Python
linktitle: Dia naar PNG
type: docs
weight: 30
url: /nl/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren naar PNG
- presentatie converteren naar PNG
- dia converteren naar PNG
- PPT converteren naar PNG
- PPTX converteren naar PNG
- ODP converteren naar PNG
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- ODP naar PNG
- Python
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-presentaties snel naar PNG-afbeeldingen van hoge kwaliteit met Aspose.Slides for Python via .NET, waarbij nauwkeurige, geautomatiseerde resultaten worden gegarandeerd."
---
## **Overzicht**

Aspose.Slides for Python via .NET maakt het eenvoudig om PowerPoint‑presentaties naar PNG te converteren. Je laadt een presentatie, doorloopt de dia's, rendert elke dia naar een rasterafbeelding en slaat het resultaat op als PNG‑bestanden. Dit is ideaal voor het genereren van dia‑vooraanzichten, het insluiten van dia's in webpagina's of het produceren van statische assets voor verdere verwerking.

## **Dia’s converteren naar PNG**

Deze sectie toont het eenvoudigste voorbeeld van het converteren van een PowerPoint‑presentatie naar PNG‑afbeeldingen met Aspose.Slides for Python via .NET.

Doorloop deze stappen:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een dia op uit de `Presentation.slides`‑collectie (zie de [Slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/)‑klasse).
1. Gebruik de `Slide.get_image`‑methode om een miniatuur van de dia te genereren.
1. Gebruik de `Presentation.save`‑methode om de dia‑miniatuur op te slaan in PNG‑formaat.

Dit Python‑codevoorbeeld toont hoe je een PowerPoint‑presentatie naar PNG kunt converteren:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Dia’s converteren naar PNG met aangepaste afmetingen**

Om dia's naar PNG te exporteren met een aangepaste schaal, roep je `Slide.get_image` aan met horizontale en verticale schaalfactoren. Deze vermenigvuldigers wijzigen de uitvoer ten opzichte van de oorspronkelijke afmetingen van de dia—bijvoorbeeld, `2.0` verdubbelt zowel de breedte als de hoogte. Gebruik gelijke waarden voor `scale_x` en `scale_y` om de beeldverhouding te behouden.

Deze Python‑code demonstreert de beschreven bewerking:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Dia’s converteren naar PNG met aangepaste grootte**

Als je PNG‑bestanden wilt genereren met een specifieke afmeting, geef je de gewenste `width`‑ en `height`‑waarden door. De code hieronder laat zien hoe je een PowerPoint naar PNG converteert terwijl je de afbeeldingsgrootte opgeeft: 

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Je kunt Aspose‑s gratis **PowerPoint‑naar‑PNG‑converters** proberen—[PPTX to PNG](https://products.aspose.app/slides/nl/conversion/pptx-to-png) en [PPT to PNG](https://products.aspose.app/slides/nl/conversion/ppt-to-png). Ze bieden een live‑implementatie van het proces dat op deze pagina wordt beschreven.
{{% /alert %}}

## **FAQ**

**Hoe kan ik alleen een specifieke vorm (bijv. grafiek of afbeelding) exporteren in plaats van de hele dia?**

Aspose.Slides ondersteunt [het genereren van miniaturen voor individuele vormen](/slides/nl/python-net/create-shape-thumbnails/); je kunt een vorm naar een PNG‑afbeelding renderen.

**Wordt parallelle conversie ondersteund op een server?**

Ja, maar [deel niet](/slides/nl/python-net/multithreading/) een enkele presentatie‑instantie niet over threads. Gebruik een aparte instantie per thread of proces.

**Wat zijn de beperkingen van de proefversie bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de output‑afbeeldingen en handhaaft [andere beperkingen](/slides/nl/python-net/licensing/) totdat een licentie wordt toegepast.