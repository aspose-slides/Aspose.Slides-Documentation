---
title: Vykreslení snímků prezentace jako SVG obrázky v Pythonu pomocí Javy
linktitle: Snímek na SVG
type: docs
weight: 50
url: /cs/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint na SVG
- prezentace na SVG
- snímek na SVG
- PPT na SVG
- PPTX na SVG
- Možnosti exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Exportujte PowerPoint snímky jako SVG obrázky v Pythonu pomocí Javy a ovládejte fonty, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrazu založený na XML, který dobře funguje pro webové publikování, prohlížeče snímků, pracovní postupy přístupnosti a automatické následné zpracování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje řídit, jak jsou zapisovány text, písma, obrázky a elementy SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/) když exportované SVG musí být kompaktní, předvídatelné napříč prohlížeči nebo připravené pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/). Příklady vyžadují existující soubor `presentation.pptx`. Každý příklad spustí JVM podle potřeby a uzavře své výstupní proudy. Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

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

Název souboru používá [Slide.getSlideNumber](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getSlideNumber), místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.writeAsSvg](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/) když prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setUseFrameSize) zahrnuje textový rámec do vykreslovací oblasti a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setUseFrameRotation) určuje, zda se aplikuje otáčení rámce. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `True`, když text musí být vykreslen bez ligatur.

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

## **Ovládání textu a fontů**

### **Vektorizovat veškerý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setVectorizeText) na `True`, aby byl veškerý text snímku zapisován jako vektorová grafika. Tím se odstraní závislosti na fontech a vizuální výsledek bude konzistentnější napříč prohlížeči, ale text již nebude možné vybrat ani vyhledávat jako SVG text.

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

### **Zvolte, jak jsou zpracovávány externí fonty**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgexternalfontshandling/) pro fonty načítané externě. Zvolte `AddLinksToFontFiles` pro odkazování na samostatné soubory s fonty, `Embed` pro zahrnutí dat fontu do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí fonty jako grafiku. Před vložením fontů ověřte licencování fontů.

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

## **Zmenšit velikost vložených obrázků**

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setPicturesCompression), aby se snížilo rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), aby se vynechaly oříznuté zdrojové oblasti, a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setJpegQuality), aby se řídila kvalita JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachovaných dat obrázku.

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

## **Přiřadit stabilní ID tvarům a textu**

Použijte formátovací kontrolér v Pythonu registrovaný přes `jpype.JProxy` k přiřazení hodnot [SvgShape.setId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgshape/#setId) tvarům a hodnot [SvgTSpan.setId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgtspan/#setId) textovým elementům `tspan`. Proxy přiřaďte pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Následující kontrolér používá [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getOfficeInteropShapeId), který je stabilní po celou dobu existence tvaru, a opakovatelný čítač pro jeho textové spany. To činí generovaná ID vhodnými pro post-processing nezměněné prezentace.

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

## **Přidat SVG obslužné rutiny událostí**

V Python formátovacím kontroléru zavolejte [SvgShape.setEventHandler](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgshape/#setEventHandler) s hodnotou [SvgEvent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgevent/) , abyste přidali JavaScriptový obslužný handler události k exportovanému tvaru. Registrujte kontrolér přes `jpype.JProxy` a přiřaďte jej pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou obslužným handlerem. Přiřazení ID a obslužných rutin událostí umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní SVG pracovní postupy.

## **FAQ**

**Kdy mám použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setVectorizeText) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#setVectorizeText), když celý text musí být nezávislý na fontech. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), když má být pouze text používající externí fonty převeden na grafiku.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých oblastí obrazu a výběrem odkazovaných souborů fontů, pokud cílové prostředí může tyto soubory poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přiřaďte ID pomocí formátovacího kontroléru a poté vyberte odpovídající SVG elementy ve svém nástroji pro post-processing nebo ve skriptu prohlížeče.