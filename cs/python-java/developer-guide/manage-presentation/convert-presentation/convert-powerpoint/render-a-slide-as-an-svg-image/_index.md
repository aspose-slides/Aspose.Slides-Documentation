---
title: Vykreslení snímků prezentace do SVG obrázků v Pythonu pomocí Javy
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentace do SVG
- snímek do SVG
- PPT do SVG
- PPTX do SVG
- Možnosti exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako SVG obrázky v Pythonu přes Java a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, pracovní postupy zpřístupnění a automatické postprocesování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, písma, obrázky a prvky SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) když exportovaný SVG musí být kompaktní, předvídatelný napříč prohlížeči nebo připravený k interaktivnímu použití.

## **Export snímku jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Příklady vyžadují existující soubor `presentation.pptx`. Každý příklad spustí JVM, pokud je to potřeba, a uzavře své výstupní proudy. Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

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

Název souboru používá [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) namísto indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), když prohlížeč snímků nebo webová stránka potřebuje jen ten tvar.

## **Nastavení výstupu SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámy [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) zahrnuje textový rám do oblasti vykreslování a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) určuje, zda se použije otočení rámu. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `True`, když text musí být vykreslen bez ligatur.

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

## **Ovládání textu a písem**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo bude převeden na vektorovou grafiku, a jak jsou zahrnuta nebo odkazována externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, výběr textu a závislosti na písmu v exportovaném SVG.

### **Vektorizovat veškerý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) na `True`, aby byl veškerý text snímku zapsán jako vektorová grafika. Tím se odstraní závislosti na písmu a výsledek bude vizuálně konzistentnější napříč prohlížeči, ale text již nebude možné v SVG vybrat ani vyhledávat.

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

### **Zvolte, jak jsou zpracovávána externí písma**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) pro písma načítaná externě. Vyberte `AddLinksToFontFiles` pro odkazování na samostatné soubory písem, `Embed` pro zahrnutí dat písma do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí písma jako grafiky. Před zahrnutím písem ověřte licencování písem.

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

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression), abyste snížili rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), abyste vynechali ořezané oblasti zdroje, a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality), abyste řídili kvalitu JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachovaných obrazových dat.

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

## **Řízení rozlišení rastrování metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) nastavuje dolní hranici rozlišení pro rastrování metafile během exportu SVG. Použijte jej pro vyvážení detailu a velikosti souboru, když je rastrován obrázek EMF nebo WMF. Nedefinuje globální DPI pro SVG ani nenutí každý objekt na snímku stát se rastrovým obrázkem.

Stáhněte [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s těsně urostlými diagonálními čarami. Následující příklad exportuje jeho první snímek ve třech rozlišeních rastrování pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Všechna ostatní nastavení exportu zůstávají stejná, aby bylo možné výsledky porovnat.

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

Ve výstupu se EMF změnilo na jeden vložený PNG v každém SVG. Následující měření jsou pro dodanou prezentaci; nejedná se o obecný vzorec pro převod DPI na rozměry v pixelech.

| Rastrování metafile DPI | Rozměry vloženého PNG | Velikost SVG souboru (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Níže uvedené srovnání ukazuje stejnou oblast vloženého rastru při stejné zvětšené velikosti zobrazení. Diagonální čáry vykazují viditelnou pixelaci při 72 DPI a hladší hrany při vyšších rozlišeních, zatímco velikost SVG souboru roste. Zvýšení hodnoty nutně neznamená zlepšení každého detailu ani změnu každého exportovaného obrázku.

![Zvětšené detaily diagonální čáry při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) řídí snížení rozlišení obrázku a může skrýt efekt změny rozlišení rastrování metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) řídí kvalitu JPEG kódování, nikoli rozlišení rastrování metafile.

## **Přiřazení stabilních ID tvarům a textu**

Použijte formátovací kontroler v Pythonu registrovaný přes `jpype.JProxy` k přiřazení hodnot [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) tvarům a [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) textovým prvkům `tspan`. Přidělte proxy pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Následující kontroler používá [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové spany. To činí generovaná ID vhodnými pro postprocesování nezměněné prezentace.

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

## **Přidání SVG událostních obslužníků**

V Python formátovacím kontroleru zavolejte [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) s hodnotou [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) , abyste přidali JavaScriptový obslužník události k exportovanému tvaru. Zaregistrujte kontroler přes `jpype.JProxy` a přiřaďte jej pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který hostí výsledek.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou obslužníkem. Přiřazení ID a obslužníků událostí umožňuje prohlížeče snímků, vylepšení zpřístupnění a další interaktivní SVG pracovní postupy.

## **FAQ**

**Kdy bych měl použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText), když musí být veškerý text nezávislý na písmu. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), když by měl být převáděn na grafiku jen text používající externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním ořezaných oblastí obrázků a volbou odkazovaných souborů písem, pokud je cílové prostředí schopno je poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají každý odlišné kompromisy mezi kvalitou a velikostí.

**Mohu upravit exportované SVG prvky po exportu?**

Ano. Přiřaďte ID pomocí formátovacího kontroleru a poté vyberte odpovídající SVG prvky ve vašem nástroji pro postprocesování nebo skriptu v prohlížeči.