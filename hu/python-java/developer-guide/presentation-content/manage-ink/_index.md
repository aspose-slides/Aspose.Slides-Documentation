---
title: PowerPoint tinta objektumok kezelése Pythonban Java-val
linktitle: Tinta kezelése
type: docs
weight: 95
url: /hu/python-java/manage-ink/
keywords:
- tinta
- tinta objektum
- tinta nyom
- tinta kezelése
- tinta rajzolása
- rajzolás
- tinta exportálás
- tinta renderelés
- tinta elrejtése
- InkOptions
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "PowerPoint tinta objektumok kezelése, nyomok és ecset tulajdonságok szerkesztése, valamint tinta megjelenésének vezérlése PDF, HTML, SVG, TIFF és kép exportálása során az Aspose.Slides for Python via Java segítségével."
---
## **Bevezetés**

A PowerPoint egy tinta funkciót biztosít, amely lehetővé teszi szabadkézi vonalak rajzolását. A tinta használható más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint a dián lévő konkrét elemek felhívására.

Az Aspose.Slides biztosítja a tinta objektumokkal való munkához szükséges típusokat. Például a [Ink](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ink/) osztály egy tinta objektumot képvisel egy dián.

## **A szabályos objektumok és a tinta objektumok közötti különbségek**

A PowerPoint diák objektumait általában alakzatobjektumok képviselik. Leg egyszerűbb formájában egy alakzat egy tároló, amely meghatározza az objektum (a keret) területét, valamint olyan tulajdonságokat, mint a tároló mérete, alakja és háttérje. További információért lásd a [Shape Layout Format](/slides/hu/python-java/shape-manipulations/#access-layout-formats-for-shape) oldalt.

Azonban amikor a PowerPoint egy tinta objektumot kezel, figyelmen kívül hagyja az objektum keret (tároló) összes tulajdonságát, kivéve a méretét. A tároló terület méretét a standard [Shape.getWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getWidth) és [Shape.getHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getHeight) metódusok határozzák meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tinta nyomok**

A tinta nyom egy alapvető elem, amely egy toll mozgását rögzíti, amikor a felhasználó digitális tintát ír. Egy nyom összefüggő pontok sorozatát tárolja.

A kódolás legegyszerűbb formája minden mintapont X és Y koordinátáit adja meg. Amikor az összes összekapcsolt pont megjelenik, egy ilyen képet hoz létre:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecset tulajdonságok a rajzoláshoz**

Az ecsetet a tinta nyom pontjait összekötő vonalak rajzolására használják. Az ecsetnek saját színe és mérete van, amelyet a [InkBrush.getColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkbrush/#getColor) és a [InkBrush.getSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkbrush/#getSize) metódusok képviselnek.

### **Tinta ecset szín beállítása**

Ez a Python kód bemutatja, hogyan állítható be egy tinta ecset színe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Tinta ecset méretének beállítása**

Ez a Python kód bemutatja, hogyan állítható be egy tinta ecset mérete:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Általában egy ecset szélessége és magassága nem egyezik, ezért a PowerPoint nem jeleníti meg az ecset méretét (a megfelelő adat szekció szürke). Ha az ecset szélessége és magassága megegyezik, a PowerPoint a méretet így jeleníti meg:

![ink_powerpoint3](ink_powerpoint3.png)

A világosabb bemutatás érdekében növeljük meg a tinta objektum magasságát, és tekintsük át a fontos méreteket:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig feltételezi, hogy a vonalvastagság nulla (lásd az előző képet).

Ezért a teljes tinta objektum látható területének meghatározásához figyelembe kell venni az egyes nyomok ecsetméretét. Itt a célobjektum (a kézírásos szöveg nyoma) a tároló (keret) méretéhez lett skálázva. Amikor a tároló mérete változik, az ecset mérete állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint hasonló viselkedést használ a szövegobjektumoknál:

![ink_powerpoint6](ink_powerpoint6.png)

## **A tinta megjelenésének vezérlése exportálás és renderelés közben**

Az Aspose.Slides a [InkOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/) osztályt biztosítja a tinta objektumok megjelenésének szabályozásához az exportált vagy renderelt kimenetben. A tulajdonságokkal teljesen elrejtheti a tintát, vagy módosíthatja, hogyan értelmeződnek a tinta ecset maszkműveletei.

A tinta beállítások több kimenettípus export vagy render opcióin keresztül érhetők el:

| Kimenet | Tinta beállítások tulajdonsága |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Dia kép | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/#getInkOptions) |

A következő [InkOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/) metódusok ugyanazokat a két beállítást teszik elérhetővé:

- [getHideInk](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/#getHideInk) meghatározza, hogy a tinta objektumok szerepelnek-e a kimenetben. Alapértelmezett értéke `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) meghatározza, hogy a maszk művelet opacitásként legyen-e értelmezve tinta ecset renderelésekor. Alapértelmezett értéke `True`; a ROP művelet helyett a [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) hívása `False` értékkel használható.

### **Tinta objektumok elrejtése PDF kimenetben**

Alapértelmezés szerint a tinta objektumok láthatóak maradnak exportáláskor. Egy tiszta kimenethez, amely nem tartalmaz kézírásos megjegyzéseket vagy egyéb tinta tartalmat, hívja meg a [InkOptions.setHideInk](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/#setHideInk) metódust `True` értékkel.

A következő Python példa egy prezentációt exportál PDF-be, miközben elrejti az összes tinta objektumot:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Tinta objektumok elrejtése diák képformátumú renderelésekor**

A tinta objektumok elrejtéséhez diák bitmap képként történő renderelésekor, konfigurálja a [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/#getInkOptions) beállítást, és adja át a renderelési opciókat a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) metódusnak.

A következő Python példa az első diát PNG képként rendereli tinta objektumok nélkül:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Tinta maszk renderelésének vezérlése**

A [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) beállítás szabályozza, hogyan értelmeződnek a maszk műveletek tinta ecsetek renderelésekor. Alapértelmezett értéke `True`, amely opacitást használ. A ROP művelet helyett hívja meg az [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) metódust `False` értékkel.

A következő Python példa egy diát exportál SVG-be, és ROP-alapú renderelést alkalmaz a tinta maszk műveleteknél:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

Ugyanez a beállítás alkalmazható a [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tiffoptions/#getInkOptions) segítségével, amikor egy prezentációt exportál vagy egy diát TIFF-re renderel.

### **Válassza ki, hogy elrejtse vagy megőrizze a tintát**

Amikor egy megjegyzésekkel ellátott prezentáció tiszta változatára van szükség a terjesztéshez, anélkül, hogy a felülvizsgálati jelölések láthatóak lennének, hívja meg a [InkOptions.setHideInk](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/#setHideInk) metódust `True` értékkel exportáláskor.

Hagyja a [InkOptions.getHideInk](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/#getHideInk) beállítást alapértelmezett `False` értéken, ha a tinta megjegyzések a kívánt tartalom részei, például felülvizsgálati megjegyzések, kézírásos jegyzetek, kiemelések vagy rajzok, amelyeknek láthatóaknak kell maradniuk az exportált eredményben. Ez lehetővé teszi, hogy az alkalmazások külön felülvizsgálati és végső kimeneteket generáljanak ugyanabból a prezentációból a forrás tinta objektumok módosítása nélkül.

## **GYIK**

**Megváltoztathatom egy meglévő tinta vonal színét vagy méretét?**

Igen. Szerezze be a nyomatot a [Ink.getTraces](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ink/#getTraces) metódussal, majd módosítsa annak [InkTrace.getBrush](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inktrace/#getBrush) tulajdonságát. Hívja a [InkBrush.setColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkbrush/#setColor) vagy a [InkBrush.setSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkbrush/#setSize) metódusokat a ecset módosításához.

**A tinta elrejtése módosítja a forrás prezentációt?**

Nem. A [InkOptions.setHideInk](https://reference.aspose.com/slides/hu/python-java/aspose.slides/inkoptions/#setHideInk) meghívása csak a renderelt vagy exportált eredményt befolyásolja; nem távolítja el vagy módosítja a tinta objektumokat a forrás prezentációban.

**Mely exportformátumok támogatják a tinta beállításokat?**

A tinta beállításokat konfigurálhatja PDF, HTML, SVG, TIFF és bitmap diakép formátumú exportokhoz a fent bemutatott megfelelő export vagy render opciók segítségével.

**További olvasmányok**

* A formákról általában olvasásért lásd a [PowerPoint Shapes](/slides/hu/python-java/powerpoint-shapes/) szekciót.
* A hatékony értékekről további információért lásd a [Shape Effective Properties](/slides/hu/python-java/shape-effective-properties/#get-effective-font-height-value) oldalt.
* A PDF export részleteiért lásd a [Convert PPT and PPTX to PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/) oldalt.
* A HTML export részleteiért lásd a [Convert PowerPoint Presentations to HTML](/slides/hu/python-java/convert-powerpoint-to-html/) oldalt.
* Az SVG export részleteiért lásd a [Render Presentation Slides as SVG Images](/slides/hu/python-java/render-a-slide-as-an-svg-image/) oldalt.
* A TIFF export részleteiért lásd a [Convert PowerPoint Presentations to TIFF](/slides/hu/python-java/convert-powerpoint-to-tiff/) oldalt.
* A dia kép formátumba történő renderelés részleteiért lásd a [Convert Presentation Slides to Images](/slides/hu/python-java/convert-slide/) oldalt.