---
title: PowerPoint-dia's converteren naar PNG in Python
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- Python
- Java
- Aspose.Slides
description: "Converteer PowerPoint-dia's naar PNG-afbeeldingen in Python via Java. Exporteer PPT-, PPTX- en ODP-presentaties met aangepaste schalen of exacte afbeeldingsafmetingen."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieslides kunt converteren naar PNG-afbeeldingen met Aspose.Slides voor Python via Java. U kunt presentaties laden in formaten zoals PPT, PPTX en ODP, elke slide renderen en deze opslaan als een afzonderlijke PNG-afbeelding.

## **PowerPoint naar PNG converteren**

Laad een presentatie met de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse en krijg toegang tot de slides via de [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides)‑collectie. Het voorbeeld rendert elke slide met [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) zonder parameters om een miniatuur te maken. Vervolgens wordt [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) aangeroepen met [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) om elke gerenderde slide op te slaan als een PNG‑afbeelding.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
De parameterloze overload van [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) rendert op een schaal van 0,2. Een slide van 720 × 540 points levert bijvoorbeeld een miniatuur van 144 × 108 pixels op. Om de uitvoerafmetingen te bepalen, gebruikt u de overloads met schaalfactoren of een expliciete afbeeldingsgrootte zoals hieronder getoond.
{{% /alert %}}

## **PowerPoint naar PNG met aangepaste afmetingen**

Geef horizontale en verticale schaalfactoren door aan [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) om de gerenderde afmetingen te regelen. In dit voorbeeld zijn beide factoren 2, waardoor een slide van 720 × 540 points een afbeelding van 1440 × 1080 pixels oplevert. Gelijke schaalfactoren behouden de beeldverhouding van de slide. Elke gerenderde afbeelding wordt opgeslagen in PNG‑formaat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint naar PNG met aangepaste grootte**

Om de uitvoerafmetingen in pixels op te geven, geeft u een grootte door aan [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) in plaats van schaalfactoren. Dit voorbeeld rendert elke slide op 960 × 720 pixels en slaat het resultaat op in PNG‑formaat. Kies afmetingen die overeenkomen met de beeldverhouding van de slide om uitrekking van de afbeelding te voorkomen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Kies een gradient‑renderingsstijl**

Stel dat een slide gradient‑vullingen bevat, maar de overgangen in de geëxporteerde PNG er lichter of anders uitzien dan in PowerPoint. U kunt de methode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) gebruiken, die erfelijk is via [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/), om te bepalen hoe de gradienten worden gerenderd.

Download [gradient-styles.pptx](gradient-styles.pptx) en plaats het in de werkmap van de applicatie. De eerste slide bevat twee lineaire gradienten: cyaan naar oranje bovenaan en blauw naar geel onderaan. Elke gradient heeft twee stops, op 0 % en 100 %.

Het volgende voorbeeld laadt deze presentatie en rendert dezelfde eerste slide in beide modi met [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

De afbeeldingen hieronder tonen de uitvoer van dezelfde slide, met beide gradienten in elke afbeelding:

| Default | PowerPointUI |
| --- | --- |
| ![Cyaan-naar-oranje en blauw-naar-geel gradienten gerenderd met Default](gradient-Default.png) | ![Dezelfde gradienten gerenderd met PowerPointUI](gradient-PowerPointUI.png) |

In dit voorbeeld levert `Default` lichtere tussenliggende kleuren op, terwijl `PowerPointUI` donkerdere tussenliggende kleuren oplevert. Het verschil hangt af van de kleuren en stops in de gradient.

Kies `Default` wanneer de standaard Aspose.Slides‑uitvoer aan uw behoeften voldoet. Probeer `PowerPointUI` wanneer uw prioriteit is om de weergave in PowerPoint te evenaren. Vergelijk beide uitvoer met het gewenste resultaat; geen van beide modi is universeel beter.

## **FAQ**

**Hoe kan ik een specifiek vormelement, zoals een grafiek of afbeelding, exporteren in plaats van de volledige slide?**

Aspose.Slides ondersteunt [miniaturen genereren voor individuele vormen](/slides/nl/python-java/create-shape-thumbnails/), waardoor u een vorm als PNG‑afbeelding kunt renderen.

**Wordt parallelle conversie ondersteund op een server?**

Ja. Gebruik een aparte presentatie‑instantie per thread of proces; [deel geen enkele instantie tussen threads](/slides/nl/python-java/multithreading/).

**Wat zijn de beperkingen in de evaluatiemodus bij exporteren naar PNG?**

In de evaluatiemodus wordt een watermerk aan de uitvoerafbeeldingen toegevoegd en gelden [andere beperkingen](/slides/nl/python-java/licensing/) tot een licentie is geïnstalleerd.