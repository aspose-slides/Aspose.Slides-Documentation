---
title: PowerPoint-dia's naar PNG converteren in Python
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint naar PNG converteren
- presentatie naar PNG converteren
- dia naar PNG converteren
- PPT naar PNG converteren
- PPTX naar PNG converteren
- ODP naar PNG converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- ODP naar PNG
- Python
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-presentaties snel naar PNG-afbeeldingen van hoge kwaliteit met Aspose.Slides voor Python via .NET, en zorg voor nauwkeurige, geautomatiseerde resultaten."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatieslides kunt converteren naar PNG-afbeeldingen met Aspose.Slides voor Python via .NET. Je kunt presentaties laden in formaten zoals PPT, PPTX en ODP, elke slide renderen en deze opslaan als een afzonderlijke PNG-afbeelding.

De onderstaande voorbeelden laten zien hoe je rendert op de standaard schaal, de schaal vergroot, de uitvoerafmetingen in pixels opgeeft en een gradiëntrenderingsstijl kiest.

## **PowerPoint naar PNG converteren**

Laad een presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse en krijg toegang tot de slides via de [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collectie. Het voorbeeld rendert elke slide met [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) zonder parameters om een thumbnail te maken. Vervolgens wordt [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) aangeroepen met [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) om elke gerenderde slide op te slaan als een PNG-afbeelding.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
De parameterloze overload van [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) rendert op een schaal van 0,2. Bijvoorbeeld, een slide van 720 × 540 points levert een thumbnail van 144 × 108 pixels op. Om de uitvoerafmetingen te beheren, gebruik je de overloads met schaalfactoren of een expliciete afbeeldingsgrootte zoals hieronder weergegeven.
{{% /alert %}}

## **PowerPoint naar PNG converteren met aangepaste afmetingen**

Geef horizontale en verticale schaalfactoren door aan [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) om de gerenderde afmetingen te controleren. In dit voorbeeld zijn beide factoren 2, waardoor een slide van 720 × 540 points een afbeelding van 1440 × 1080 pixels oplevert. Gelijke schaalfactoren behouden de beeldverhouding van de slide. Elke afbeelding wordt opgeslagen in PNG-formaat met [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **PowerPoint naar PNG converteren met aangepaste grootte**

Om uitvoerafmetingen in pixels op te geven, geef je een grootte door aan [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) in plaats van schaalfactoren. Dit voorbeeld rendert elke slide op 960 × 720 pixels en slaat het resultaat op met [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Kies afmetingen die overeenkomen met de beeldverhouding van de slide om uitrekken van de afbeelding te voorkomen.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Kies een gradiëntrenderingsstijl**

Stel dat een slide gradientvullingen bevat, maar de overgangen in de geëxporteerde PNG lichter of anders uitzien dan in PowerPoint. Je kunt de eigenschap [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) van [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) gebruiken om te bepalen hoe de gradients worden gerenderd.

Download [gradient-styles.pptx](gradient-styles.pptx) en plaats het in de werkmap van de applicatie. De eerste slide bevat twee lineaire gradients: cyaan naar oranje bovenaan en blauw naar geel onderaan. Elke gradient heeft twee stops, op 0% en 100%.

Het volgende voorbeeld laadt deze presentatie en rendert dezelfde eerste slide in beide modi met [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

De onderstaande afbeeldingen tonen de output van dezelfde slide, met beide gradients in elke afbeelding:

| Standaard | PowerPointUI |
| --- | --- |
| ![Cyaan-naar-oranje en blauw-naar-geel gradients gerenderd met Standaard](gradient-Default.png) | ![Dezelfde gradients gerenderd met PowerPointUI](gradient-PowerPointUI.png) |

In dit voorbeeld levert `DEFAULT` lichtere tussenkleuren op, terwijl `POWER_POINT_UI` donkerdere tussenkleuren oplevert. Het verschil hangt af van de kleuren en stops in de gradient.

Kies `DEFAULT` wanneer de standaard Aspose.Slides-output aan je wensen voldoet. Probeer `POWER_POINT_UI` wanneer je prioriteit is om de weergave in PowerPoint te evenaren. Vergelijk beide outputs met het gewenste resultaat; geen van beide modi is in alle gevallen beter.

## **Veelgestelde vragen**

**Hoe kan ik een specifiek vorm, zoals een diagram of afbeelding, exporteren in plaats van de hele slide?**

Aspose.Slides ondersteunt [het genereren van thumbnails voor individuele vormen](/slides/nl/python-net/create-shape-thumbnails/), waardoor je een vorm kunt renderen als een PNG-afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja. Gebruik een aparte presentatie‑instantie voor elke thread of elk proces; [deel geen enkele instantie tussen threads](/slides/nl/python-net/multithreading/).

**Wat zijn de beperkingen in evaluatiemodus bij exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoerafbeeldingen en past [andere beperkingen](/slides/nl/python-net/licensing/) toe tot er een licentie is geïnstalleerd.