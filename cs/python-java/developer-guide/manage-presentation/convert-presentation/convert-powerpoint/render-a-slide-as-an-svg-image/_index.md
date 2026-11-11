---
title: Vykreslit snímky prezentace jako SVG obrázky v Pythonu přes Java
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
description: "Exportujte snímky PowerPointu jako SVG obrázky v Pythonu přes Java a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, pracovní postupy přístupnosti a automatické post‑processing. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, písma, obrázky a prvky SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) když exportované SVG musí být kompaktní, předvídatelné napříč prohlížeči nebo připravené pro interaktivní použití.

## **Exportovat snímek jako SVG**

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

Název souboru používá [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), když prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) zahrnuje textový rámec do oblasti vykreslování a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) určuje, zda se použije rotace rámce. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `True`, když musí být text vykreslen bez ligatur.

```python
import jpime
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

## **Ovládání ořezu konců čar u šipek**

SVG 1.1 nemá nastavení vnitřního odsazení značky, které by určovalo, kde má čára končit pod šipkou. Ve výchozím nastavení Aspose.Slides zkracuje exportovanou čáru, aby její tah nevyčníval skrz značku. Zavolejte [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) s hodnotou `True`, aby se tah kreslil až k původnímu koncovému bodu čáry. Toto nastavení ovlivňuje pouze výstup SVG. Čára si zachovává svou pozici a délku na snímku.

Příklad kreslí trojúhelníkové a diamantové šipky na čáry o šířce 2 a 10 bodů. Exportuje stejný snímek dvakrát, mění pouze nastavení ořezu.

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

Porovnání ukazuje trojúhelníkovou šipku na 10-bodové čáře. Při povoleném ořezu je hrot ostrý. Při zakázaném ořezu tah vyčnívá skrz šikmé strany značky a zanechává plochý konec.

![Zvětšený 10-bodový trojúhelník s ostrým hrotem, když je ořez povolen, a plochým koncem, když je ořez zakázán](line-end-cropping.png)

V ostatních čarách z příkladu je vyčnívající tah méně viditelný na 2-bodovém trojúhelníku. Vyplněný diamant zakrývá konec tahu u obou šířek.

## **Ovládání textu a písem**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo bude převeden na vektorovou grafiku, a jak jsou zahrnuta nebo odkazována externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, výběr textu a závislosti na fontech v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) na `True`, aby byl veškerý text snímku zapsán jako vektorová grafika. Tím se odstraní závislosti na fontech a vizuální výsledek bude konzistentnější napříč prohlížeči, ale text již nebude možné vybírat ani vyhledávat jako SVG text.

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

### **Zvolte, jak se zacházejí s externími fonty**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) , která určuje, jak se zachází s externě načtenými fonty. Vyberte `AddLinksToFontFiles` pro odkazování na samostatné soubory fontů, `Embed` pro zahrnutí dat fontu do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí fonty jako grafiky. Před vložením fontů ověřte licencování fontů.

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

## **Snížení velikosti vložených obrázků**

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression), abyste snížili rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), aby jste vynechali oříznuté oblasti zdrojů, a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality), abyste řídili kvalitu JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachovaných dat obrázku.

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

## **Řízení rozlišení rasterizace metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) nastavuje spodní limit rozlišení pro rasterizaci metafile během exportu SVG. Použijte jej k vyvážení detailu a velikosti souboru, když je rasterizován obrázek EMF nebo WMF. Nedefinuje globální DPI pro SVG ani nenužuje, aby se každý objekt na snímku změnil na rastrový obrázek.

Stáhněte [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s těsně umístěnými úhlopříčnými čarami. Následující příklad exportuje jeho první snímek ve třech rozlišeních rasterizace pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Všechna ostatní nastavení exportu zůstávají stejná, aby bylo možné výsledky porovnat.

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

Ve výstupu se EMF stal jedním vloženým PNG v každém SVG. Následující měření jsou pro dodanou prezentaci; nejsou obecnou formulí pro převedení DPI na rozměry v pixelech.

| Rasterizační DPI metafile | Rozměry vloženého PNG | Velikost souboru SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 x 596 | 170,221 |
| 150 | 2492 x 1242 | 423,149 |
| 300 | 4983 x 2483 | 1,027,169 |

Porovnání níže ukazuje stejnou oblast vloženého rastru při stejném zvětšeném zobrazení. Úhlopříčkové čáry vykazují viditelnou pixelaci při 72 DPI a hladší okraje při vyšších rozlišeních, zatímco soubor SVG roste. Zvýšení hodnoty nutně nezdokonalí každý detail ani nezmění každý exportovaný obrázek.

![Zvětšený detail úhlopříčkové čáry při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) řídí snížení rozlišení obrázku a může zamaskovat vliv změny rozlišení rasterizace metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) řídí kvalitu JPEG kódování, nikoli rozlišení rasterizace metafile.

## **Přiřazení stabilních ID tvarům a textu**

Použijte formátovací kontrolér v Pythonu registrovaný přes `jpype.JProxy` k přiřazení hodnot [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) tvarům a hodnot [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) textovým prvkům `tspan`. Přiřaďte proxy pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Následující kontrolér používá [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové úseky. To dělá generovaná ID vhodná pro následné zpracování nezměněné prezentace.

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

## **Přidání obslužníků událostí SVG**

V Python formátovacím kontroléru zavolejte [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) s hodnotou [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) , abyste přidali JavaScriptový obslužník události k exportovanému tvaru. Zaregistrujte kontrolér přes `jpype.JProxy` a přiřaďte jej pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definujte JavaScriptovou funkci na stránce nebo v dokumentu SVG, který výsledek hostí.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou obslužníkem. Přiřazení ID a obslužníků událostí umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní workflow s SVG.

## **Časté dotazy**

**Kdy bych měl použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText), když musí být celý text nezávislý na fontech. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), když by měl být převáděn na grafiku jen text využívající externí fonty.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých oblastí obrázků a volbou odkazovaných souborů fontů, pokud cílové prostředí může tyto soubory poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přiřaďte ID pomocí formátovacího kontroléru a poté vyberte odpovídající SVG elementy ve vašem nástroji pro post‑processing nebo v skriptu prohlížeče.