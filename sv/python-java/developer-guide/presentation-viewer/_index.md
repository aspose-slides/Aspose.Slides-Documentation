---
title: Skapa en presentationsvisare i Python via Java
linktitle: Presentationsvisare
type: docs
weight: 50
url: /sv/python-java/presentation-viewer/
keywords:
- visa presentation
- presentationsvisare
- skapa presentationsvisare
- visa PPT
- visa PPTX
- visa ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa en anpassad presentationsvisare i Python via Java med Aspose.Slides. Visa enkelt PowerPoint- och OpenDocument-filer utan Microsoft PowerPoint."
---
## **Introduktion**

Aspose.Slides för Python via Java används för att skapa presentationsfiler med bildspel. Dessa bildspel kan visas genom att öppna presentationerna i Microsoft PowerPoint, till exempel. Ibland kan utvecklare dock behöva se bilderna som bilder i deras föredragna bildvisare eller skapa sin egen presentationsvisare. I sådana fall låter Aspose.Slides dig exportera en enskild bild som en bild. Denna artikel beskriver hur du gör det.

## **Generera en SVG-bild från en bild**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Öppna ett byteflöde.
1. Spara bilden som en SVG-bild till flödet och skriv den till en fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Generera en SVG med ett anpassat form‑ID**

Aspose.Slides kan användas för att generera en [SVG](https://docs.fileformat.com/page-description-language/svg/) från en bild med ett anpassat form‑ID. För att göra detta, använd metoden [SvgShape.setId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgshape/#setId) från [SvgShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` kan användas för att ange form‑ID‑et.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Skapa en miniatyrbild av en bild**

Aspose.Slides hjälper dig att skapa miniatyrbilder av bildspel. För att generera en miniatyrbild av en bild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Hämta miniatyrbilden av den refererade bilden med en definierad skala.
1. Spara miniatyrbilden i önskat bildformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Skapa en miniatyrbild av en bild med användardefinierade dimensioner**

För att skapa en miniatyrbild av en bild med användardefinierade dimensioner, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Hämta miniatyrbilden av den refererade bilden med de definierade dimensionerna.
1. Spara miniatyrbilden i önskat bildformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Skapa en miniatyrbild av en bild med talarnoter**

För att generera en miniatyrbild av en bild med talarnoter med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [RenderingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/).
1. Använd metoden [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) för att ange positionen för talarnoter.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Hämta miniatyrbilden av den refererade bilden med renderingsalternativen.
1. Spara miniatyrbilden i önskat bildformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Live‑exempel**

Du kan prova den kostnadsfria appen [**Aspose.Slides Viewer**](https://products.aspose.app/slides/sv/viewer/) för att se vad du kan implementera med Aspose.Slides‑API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kan jag bädda in en presentationsvisare i en webbapplikation?**

Ja. Du kan använda Aspose.Slides på serversidan för att rendera bildspel som bilder eller HTML och visa dem i webbläsaren. Navigations‑ och zoom‑funktioner kan implementeras med JavaScript för en interaktiv upplevelse.

**Vad är det bästa sättet att visa bildspel i en anpassad visare?**

Den rekommenderade metoden är att rendera varje bild som en bild (t.ex. PNG eller SVG) eller konvertera den till HTML med Aspose.Slides, och sedan visa resultatet i en bildruta (för skrivbord) eller HTML‑behållare (för webben).

**Hur hanterar jag stora presentationer med många bilder?**

För stora presentationer, överväg lazy‑loading eller rendering på begäran av bilder. Detta innebär att generera en bilds innehåll först när användaren navigerar till den, vilket minskar minnes- och laddningstid.