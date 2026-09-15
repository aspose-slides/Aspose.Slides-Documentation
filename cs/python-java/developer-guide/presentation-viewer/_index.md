---
title: Vytvořte vlastní prohlížeč prezentací v Pythonu přes Java
linktitle: Prohlížeč prezentací
type: docs
weight: 50
url: /cs/python-java/presentation-viewer/
keywords:
- zobrazit prezentaci
- prohlížeč prezentací
- vytvořit prohlížeč prezentací
- zobrazit PPT
- zobrazit PPTX
- zobrazit ODP
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte vlastní prohlížeč prezentací v Pythonu přes Java pomocí Aspose.Slides. Jednoduše zobrazujte soubory PowerPoint a OpenDocument bez Microsoft PowerPoint."
---
## **Úvod**

Aspose.Slides for Python via Java se používá k vytváření souborů prezentací se snímky. Tyto snímky lze zobrazit například otevřením prezentace v Microsoft PowerPoint. Někdy však vývojáři potřebují zobrazit snímky jako obrázky ve svém oblíbeném prohlížeči obrázků nebo vytvořit vlastní prohlížeč prezentací. V takových případech umožňuje Aspose.Slides exportovat jednotlivý snímek jako obrázek. Tento článek popisuje, jak na to.

## **Vytvoření obrázku SVG ze snímku**

Pro vytvoření obrázku SVG ze snímku prezentace pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Otevřete bajtový proud.
1. Uložte snímek jako SVG obrázek do proudu a zapište jej do souboru.

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

## **Vytvoření SVG s vlastním ID tvaru**

Aspose.Slides lze použít k vytvoření [SVG](https://docs.fileformat.com/page-description-language/svg/) ze snímku s vlastním ID tvaru. K tomu použijte metodu [SvgShape.setId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgshape/#setId) ze třídy [SvgShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` lze použít k nastavení ID tvaru.

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

## **Vytvoření miniatury snímku**

Aspose.Slides vám pomůže vygenerovat miniatury snímků. Pro vytvoření miniatury snímku pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte miniaturu referencovaného snímku v definovaném měřítku.
1. Uložte miniaturu v libovolném požadovaném formátu obrázku.

```python
import jpime
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

## **Vytvoření miniatury snímku s uživatelem definovanými rozměry**

Pro vytvoření miniatury snímku s rozměry definovanými uživatelem postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte miniaturu referencovaného snímku s definovanými rozměry.
1. Uložte miniaturu v libovolném požadovaném formátu obrázku.

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

## **Vytvoření miniatury snímku s poznámkami přednášejícího**

Pro vytvoření miniatury snímku s poznámkami přednášejícího pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [RenderingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/).
1. Pomocí metody [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) nastavte pozici poznámek přednášejícího.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte miniaturu referencovaného snímku s nastavenými možnostmi vykreslování.
1. Uložte miniaturu v libovolném požadovaném formátu obrázku.

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

## **Ukázkový příklad**

Vyzkoušejte si bezplatnou aplikaci [**Aspose.Slides Viewer**](https://products.aspose.app/slides/cs/viewer/) a zjistěte, co můžete implementovat pomocí API Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Mohu vložit prohlížeč prezentací do webové aplikace?**

Ano. Můžete použít Aspose.Slides na straně serveru k vykreslení snímků jako obrázků nebo HTML a zobrazit je v prohlížeči. Navigační a zoomovací funkce lze implementovat pomocí JavaScriptu pro interaktivní zážitek.

**Jaký je nejlepší způsob, jak zobrazit snímky v vlastním prohlížeči?**

Doporučený postup je vykreslit každý snímek jako obrázek (např. PNG nebo SVG) nebo jej převést na HTML pomocí Aspose.Slides a poté výstup zobrazit v komponentě PictureBox (pro desktop) nebo v HTML kontejneru (pro web).

**Jak mohu pracovat s velkými prezentacemi obsahujícími mnoho snímků?**

U velkých prezentací zvažte lazy-loading nebo vykreslování snímků na vyžádání. To znamená generovat obsah snímku pouze ve chvíli, kdy uživatel na něj přejde, čímž snížíte spotřebu paměti a dobu načítání.