---
title: Konvertera PowerPoint-bilder till PNG i Python
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/python-java/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- spara PPT som PNG
- spara PPTX som PNG
- exportera PPT till PNG
- exportera PPTX till PNG
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint-bilder till PNG-bilder i Python via Java. Exportera PPT, PPTX och ODP-presentationer med anpassade skalor eller exakta bilddimensioner."
---
## **Översikt**

Denna artikel förklarar hur du konverterar presentationsbilder till PNG‑bilder med Aspose.Slides för Python via Java. Du kan läsa in presentationer i format som PPT, PPTX och ODP, rendera varje bild och spara den som en separat PNG‑bild.

Exemplen nedan visar rendering med standardskala, ökad skala, ange utskriftsdimensioner i pixlar och välja en gradientrenderingsstil.

## **Konvertera PowerPoint till PNG**

Läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) och nå dess bilder via samlingen [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). Exemplet renderar varje bild med [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) utan parametrar för att skapa en miniatyr. Det anropar sedan [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) med [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) för att spara varje renderad bild som en PNG‑fil.

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
Den parameterlösa overloadeden [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) renderar med en skala på 0.2. Till exempel ger en bild som mäter 720 × 540 punkter en miniatyr på 144 × 108 pixlar. För att kontrollera utskriftsdimensionerna, använd overloaded‑metoderna med skalfaktorer eller en explicit bildstorlek som visas nedan.
{{% /alert %}}

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Ange horisontella och vertikala skalfaktorer till [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) för att kontrollera de renderade dimensionerna. I detta exempel är båda faktorerna 2, så en bild som mäter 720 × 540 punkter ger en bild på 1440 × 1080 pixlar. Likadana skalfaktorer behåller bildens bildförhållande. Varje renderad bild sparas i PNG‑format.

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

## **Konvertera PowerPoint till PNG med anpassad storlek**

För att ange utskriftsdimensioner i pixlar, skicka en storlek till [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) istället för skalfaktorer. Detta exempel renderar varje bild i 960 × 720 pixlar och sparar resultatet i PNG‑format. Välj dimensioner som matchar bildens bildförhållande för att undvika att bilden sträcks.

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

## **Välj en gradientrenderingsstil**

Anta att en bild innehåller gradientfyllningar, men övergångarna i den exporterade PNG‑filen ser ljusare eller på annat sätt annorlunda ut jämfört med vad du ser i PowerPoint. Du kan använda metoden [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) som ärvts av [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) för att välja hur gradienterna renderas.

Ladda ner [gradient-styles.pptx](gradient-styles.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller två linjära gradienter: cyan till orange högst upp och blå till gul längst ner. Varje gradient har två stopp, vid 0 % och 100 %.

Följande exempel läser in denna presentation och renderar den samma första bilden i båda lägena med [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

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

Bilderna nedan visar resultatet från samma bild, med båda gradienterna i varje bild:

| Standard | PowerPointUI |
| --- | --- |
| ![Cyan-till-orange och blå-till-gul gradienter renderade med Standard](gradient-Default.png) | ![Samma gradienter renderade med PowerPointUI](gradient-PowerPointUI.png) |

I detta exempel ger `Standard` ljusare mellanfärger, medan `PowerPointUI` ger mörkare mellanfärger. Skillnaden beror på färgerna och stoppen i gradienten.

Välj `Standard` när den standardmässiga Aspose.Slides‑outputen passar dina behov. Prova `PowerPointUI` när din prioritet är att matcha utseendet i PowerPoint. Jämför båda resultaten med ditt önskade resultat; inget läge är generellt att föredra.

## **Vanliga frågor**

**Hur kan jag exportera en specifik form, till exempel ett diagram eller en bild, istället för hela bilden?**

Aspose.Slides stöder [generering av miniatyrbilder för enskilda former](/slides/sv/python-java/create-shape-thumbnails/), vilket gör att du kan rendera en form som en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja. Använd ett separat presentations‑instans för varje tråd eller process; [dela inte en enda instans mellan trådar](/slides/sv/python-java/multithreading/).

**Vilka är begränsningarna i evalueringsläget när du exporterar till PNG?**

Evalueringsläget lägger till ett vattenmärke på utdatabilderna och tillämpar [andra begränsningar](/slides/sv/python-java/licensing/) tills en licens har tillämpats.