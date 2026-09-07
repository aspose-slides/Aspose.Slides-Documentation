---
title: Konvertera PowerPoint‑bilder till PNG i Python
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
description: "Konvertera PowerPoint‑bilder till PNG‑bilder i Python via Java. Exportera PPT‑, PPTX‑ och ODP‑presentationer med anpassade skalor eller exakta bilddimensioner."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint‑presentationer till PNG‑bilder med Aspose.Slides för Python via Java. Du kan läsa in PPT‑, PPTX‑ och ODP‑filer, rendera varje bild och spara den som en separat PNG‑bild.

Exemplen visar också hur du styr utskriftsdimensionerna med skalningsfaktorer eller en exakt bredd och höjd. Varje exempel startar Java‑virtuell maskin om det behövs och frigör presentation‑ och bildresurser efter användning.

## **Konvertera PowerPoint till PNG**

1. Läs in inmatningsfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta bilderna med [Presentation.getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides).
3. Rendera varje bild med [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage).
4. Spara varje renderad bild med [ImageFormat.Png](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imageformat/#Png) och frigör sedan dess resurser.

Följande Python‑exempel exporterar alla bilder i deras standardstorlek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Konvertera PowerPoint till PNG med anpassad skala**

Skicka horisontella och vertikala skalningsfaktorer till [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) för att öka eller minska utskriftsdimensionerna. Till exempel ger en 720 × 540‑punkts bild renderad med en skalningsfaktor på 2 på båda axlarna en 1440 × 1080‑pixel bild.

Använd lika skalningsfaktorer för att bevara bildens bildförhållande. Olika faktorer sträcker bilden horisontellt eller vertikalt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Konvertera PowerPoint till PNG med anpassad storlek**

För att ange exakta pixeldimensioner, skicka ett Java‑`Dimension`‑objekt med önskad bredd och höjd till [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage). Välj dimensioner med samma bildförhållande som källbilden för att undvika distorsion.

Följande exempel sparar varje bild som en 960 × 720‑pixel PNG‑bild:

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
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag exportera en enskild form, till exempel ett diagram eller en bild, istället för hela bilden?**

Ja. Aspose.Slides stöder [generating thumbnails for individual shapes](/slides/sv/python-java/create-shape-thumbnails/), som du kan spara som PNG‑bilder.

**Kan jag konvertera presentationer parallellt på en server?**

Använd en separat presentation‑instans för varje tråd eller process, och använd unika utdata‑sökvägar för att förhindra att filer skrivs över. Dela inte en presentation‑instans mellan trådar. Se [Multithreading](/slides/sv/python-java/multithreading/).

**Vilka begränsningar har provversionen när man exporterar till PNG?**

Utvärderingsläget lägger till ett vattenmärke på utdata‑bilder och tillämpar [other restrictions](/slides/sv/python-java/licensing/). Använd en licens för att ta bort dessa begränsningar.