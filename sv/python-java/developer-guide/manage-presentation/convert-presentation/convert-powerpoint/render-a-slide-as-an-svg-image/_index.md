---
title: Rendera presentationsbilder som SVG-bilder i Python via Java
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint till SVG
- presentation till SVG
- bild till SVG
- PPT till SVG
- PPTX till SVG
- SVG-exportalternativ
- interaktiv SVG
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Exportera PowerPoint-bilder som SVG-bilder i Python via Java och kontrollera typsnitt, text, bilder, ID:n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML-baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG-fil och låter dig kontrollera hur text, typsnitt, bilder och SVG-element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/) när den exporterade SVG-filen måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/), välj en bild och skriv den till en ström med [Slide.writeAsSvg](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/). Exemplen kräver en befintlig fil `presentation.pptx`. Varje exempel startar JVM om det behövs och stänger sina utdata-strömmar. Följande exempel exporterar varje bild i en presentation som en separat SVG-fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Filnamnet använder [Slide.getSlideNumber](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getSlideNumber), snarare än loop-indexet. Du kan också exportera en enskild form med [Shape.writeAsSvg](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG-utdata**

[SVGOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/) styr SVG-renderingen. För textramar inkluderar [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setUseFrameSize) textramen i renderingsområdet, och [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setUseFrameRotation) bestämmer om ramrotationen tillämpas. Sätt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) till `True` när text måste renderas utan ligaturer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Styr text och typsnitt**

### **Vektorisera all text**

Sätt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setVectorizeText) till `True` för att skriva all bildtext som vektorgrafik. Detta eliminerar beroenden av typsnitt och gör det visuella resultatet mer konsekvent i olika webbläsare, men texten blir inte längre selekterbar eller sökbar som SVG-text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Välj hur externa typsnitt hanteras**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgexternalfontshandling/)‑värde för typsnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera till separata typsnittsfiler, `Embed` för att inkludera typsnittsdata i SVG-filen, eller `Vectorize` för att rendera bara den text som använder externa typsnitt som grafik. Verifiera typsnittens licens innan du bäddar in dem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Minska storlek på inbäddade bilder**

Använd [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setPicturesCompression) för att minska upplösningen på inbäddade bilder, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) för att utelämna beskurna källområden, och [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setJpegQuality) för att kontrollera JPEG‑kodningskvaliteten. Dessa inställningar minskar filstorleken på bekostnad av bildens noggrannhet eller bevarad bilddata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Tilldela stabila ID:n till former och text**

Använd en Python‑formateringskontroller registrerad via `jpype.JProxy` för att tilldela [SvgShape.setId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgshape/#setId)-värden till former och [SvgTSpan.setId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgtspan/#setId)-värden till text‑`tspan`‑element. Tilldela proxyn med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Följande kontroller använder [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getOfficeInteropShapeId), vilket är stabilt under formens livstid, samt en upprepningsbar räknare för dess text‑spänn. Detta gör de genererade ID‑en lämpliga för efterbehandling av en oförändrad presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Lägg till SVG‑händelsehanterare**

I en Python‑formateringskontroller, anropa [SvgShape.setEventHandler](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgshape/#setEventHandler) med ett [SvgEvent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgevent/)‑värde för att lägga till en JavaScript‑händelsehanterare på en exporterad form. Registrera kontrollern via `jpype.JProxy` och tilldela den med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definiera JavaScript‑funktionen i sidan eller SVG‑dokumentet som innehåller resultatet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

Värdsidan kan definiera JavaScript‑funktionen som refereras av hanteraren. Att tilldela ID:n och händelsehanterare möjliggör bildvisare, förbättrad tillgänglighet och andra interaktiva SVG‑arbetsflöden.

## **FAQ**

**När bör jag använda [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setVectorizeText) istället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Använd [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgoptions/#setVectorizeText) när all text måste vara oberoende av typsnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) när endast den text som använder externa typsnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade typsnittsfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektoriserad text alla har olika kompromisser mellan kvalitet och storlek.

**Kan jag modifiera exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringskontroller och välj sedan motsvarande SVG‑element i ditt efterbehandlingsverktyg eller browserskript.