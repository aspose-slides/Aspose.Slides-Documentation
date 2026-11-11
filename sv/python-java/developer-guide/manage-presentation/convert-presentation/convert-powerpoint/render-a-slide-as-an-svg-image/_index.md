---
title: Rendera presentationsbilder som SVG‑bilder i Python via Java
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
- SVG‑exportalternativ
- interaktiv SVG
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Exportera PowerPoint‑bilder som SVG‑bilder i Python via Java och kontrollera teckensnitt, text, bilder, ID:n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML‑baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG‑fil och låter dig styra hur text, teckensnitt, bilder och SVG‑element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) när den exporterade SVG‑filen måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), välj en bild och skriv den till en ström med [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Exemplen kräver en befintlig fil `presentation.pptx`. Varje exempel startar JVM om det behövs och stänger sina utdata‑strömmar. Följande exempel exporterar varje bild i en presentation som en separat SVG‑fil.

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

Filnamnet använder [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) snarare än loop‑indexet. Du kan även exportera en enskild form med [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG‑utmatning**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) styr SVG‑rendering. För textramar inkluderar [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) textramen i renderingsområdet, och [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) bestämmer om ramens rotation tillämpas. Ställ in [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) till `True` när text måste renderas utan ligaturer.

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

## **Styr beskärning av linjeändar vid pilspetsar**

SVG 1.1 har ingen marker‑inset‑inställning för att ange var en linje ska sluta under en pilspets. Som standard förkortar Aspose.Slides den exporterade linjen så att dess streck inte sticker igenom markören. Anropa [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) med `True` för att rita strecket hela vägen till linjens ursprungliga slutpunkt. Denna inställning påverkar endast SVG‑utmatningen. Linjen behåller sin position och längd på bilden.

Exemplet ritar triangel‑ och diamant‑pilspetsar på linjer med bredden 2 och 10 punkter. Det exporterar samma bild två gånger och ändrar bara beskärningsalternativet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Jämförelsen visar den triangulära pilspetsen på 10‑punktslinjen. Med beskärning aktiverad är spetsen skarp. Med beskärning inaktiverad sticker strecket igenom de sluttande sidorna på markören och lämnar en platt ände.

![Förstorad 10‑punkts triangel med en skarp spets när beskärning är aktiverad och en platt ände när beskärning är inaktiverad](line-end-cropping.png)

I de andra linjerna i exemplet är det utskjutande strecket mindre synligt på 2‑punkts triangeln. Den fyllda diamanten täcker streckets ände vid båda bredderna.

## **Styr text och teckensnitt**

När du exporterar bilder till SVG kan du styra om text kvarstår som text eller konverteras till vektorgrafik, samt hur externa teckensnitt inkluderas eller refereras. Följande alternativ hjälper dig att balansera visuell konsistens, texturval och teckensnittsberoenden i den exporterade SVG‑filen.

### **Vektorisera all text**

Ställ in [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) till `True` för att skriva all bildtext som vektorgrafik. Detta eliminerar teckensnittsberoenden och gör det visuella resultatet mer konsekvent i olika webbläsare, men texten kan inte längre väljas eller sökas som SVG‑text.

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

### **Välj hur externa teckensnitt hanteras**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/)‑värde för teckensnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera till separata teckensnittsfiler, `Embed` för att inkludera teckensnittsdata i SVG‑filen, eller `Vectorize` för att rendera endast text som använder externa teckensnitt som grafik. Verifiera teckensnittslicenser innan du bäddar in teckensnitt.

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

Använd [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) för att minska upplösningen på inbäddade bilder, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) för att utelämna beskurna källområden, och [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) för att styra JPEG‑kodningskvalitet. Dessa inställningar minskar filstorleken på bekostnad av bildkvalitet eller bevarade bilddata.

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

## **Styr rasteriseringsupplösning för metafiler**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) anger den lägre upplösningsgränsen för rasterisering av metafiler vid SVG‑export. Använd den för att balansera detaljrikedom och filstorlek när en EMF‑ eller WMF‑bild rasteriseras. Den definierar inte ett globalt DPI för SVG‑filen eller tvingar varje objekt i bilden att bli en rasterbild.

Hämta [metafile-rasterization.pptx](metafile-rasterization.pptx), som innehåller en EMF‑bild med tätt placerade diagonala linjer. Följande exempel exporterar dess första bild i tre rasteriseringsupplösningar via [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Alla andra exportinställningar förblir lika så att resultaten kan jämföras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()

```

I utdata blev EMF‑filen en inbäddad PNG i varje SVG. Följande mått gäller för den medföljande presentationen; de är inte en generell formel för att konvertera DPI till pixelmått.

| Metafil rasterisering DPI | Inbäddade PNG‑dimensioner | SVG‑filstorlek (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Jämförelsen nedan visar samma område av den inbäddade rasterbilden i samma förstorade visningsstorlek. De diagonala linjerna visar synlig pixellering vid 72 DPI och mjukare kanter vid högre upplösningar, medan SVG‑filen växer. Att öka värdet förbättrar inte nödvändigtvis varje detalj eller förändrar varje exporterad bild.

![Förstorad detalj av diagonal linje vid 72, 150 och 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) styr minskning av bildupplösning och kan dölja effekten av att ändra metafilens rasteriseringsupplösning. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) styr JPEG‑kodningskvalitet, inte rasteriseringsupplösningen för metafilen.

## **Tilldela stabila ID till former och text**

Använd en Python‑formateringskontroller registrerad via `jpype.JProxy` för att tilldela [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId)-värden till former och [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId)-värden till text‑`tspan`‑element. Tilldela proxyn med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Följande kontroller använder [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), som är stabil för formens livstid, samt en repeterbar räknare för dess textsnuttar. Detta gör de genererade ID‑en lämpliga för efterbehandling av en oförändrad presentation.

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

I en Python‑formateringskontroller, anropa [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) med ett [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/)-värde för att lägga till en JavaScript‑händelsehanterare till en exporterad form. Registrera kontrollern via `jpype.JProxy` och tilldela den med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definiera JavaScript‑funktionen i sidan eller SVG‑dokumentet som innehåller resultatet.

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

Värd‑sidan kan definiera JavaScript‑funktionen som refereras av hanteraren. Tilldelning av ID‑n och händelsehanterare möjliggör bildvisare, tillgänglighetsförbättringar och andra interaktiva SVG‑arbetsflöden.

## **FAQ**

**När bör jag använda [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) istället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Använd [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) när all text måste vara oberoende av teckensnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) när endast text som använder externa teckensnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade teckensnittsfiler när målmiljön kan servera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektorisering av text alla har olika kvalitet‑ och storleksavvägningar.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID‑n via en formateringskontroller och välj sedan de matchande SVG‑elementen i ditt efterbehandlingsverktyg eller browserskript.