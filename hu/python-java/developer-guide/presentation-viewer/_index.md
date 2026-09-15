---
title: Prezentációs megjelenítő létrehozása Pythonon keresztül Java-val
linktitle: Prezentációs megjelenítő
type: docs
weight: 50
url: /hu/python-java/presentation-viewer/
keywords:
- prezentáció megtekintése
- prezentációs megjelenítő
- prezentációs megjelenítő létrehozása
- PPT megtekintése
- PPTX megtekintése
- ODP megtekintése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Egy egyedi prezentációs megjelenítő létrehozása Pythonon keresztül Java-val az Aspose.Slides használatával. Könnyedén megjelenítheti a PowerPoint és OpenDocument fájlokat a Microsoft PowerPoint nélkül."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java a prezentációs fájlok diákkal való létrehozására szolgál. Ezek a diák például a Microsoft PowerPoint programban nyithatók meg. Néha azonban a fejlesztőknek szükségük lehet arra, hogy a diákat képként nézzék meg kedvenc képnézőjükben, vagy saját prezentációs nézőt hozzanak létre. Ilyen esetekben az Aspose.Slides lehetővé teszi egyetlen dia képformátumba történő exportálását. Ez a cikk leírja, hogyan kell ezt megtenni.

## **SVG kép generálása egy diából**

Az Aspose.Slides segítségével SVG képet generálni egy prezentációs diából, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Nyisson meg egy bájtos áramlást.
1. Mentse a diát SVG képként az áramlásba, majd írja egy fájlba.

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

## **SVG generálása egyéni alakzat-azonosítóval**

Az Aspose.Slides használható egy SVG generálására egy diából egyedi alakzat-azonosítóval. Ehhez használja a [SvgShape.setId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgshape/#setId) metódust a [SvgShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgshape/) osztályból. A `CustomSvgShapeFormattingController` használható az alakzat azonosítójának beállítására.

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

## **Dia bélyegkép létrehozása**

Az Aspose.Slides segít a diák bélyegképeinek előállításában. Egy dia bélyegképének generálásához az Aspose.Slides használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét a meghatározott méretarányban.
1. Mentse a bélyegképet bármely kívánt képformátumban.

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

## **Dia bélyegkép létrehozása felhasználó által meghatározott méretekkel**

Felhasználó által megadott méretekkel rendelkező dia bélyegkép létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét a meghatározott méretekkel.
1. Mentse a bélyegképet bármely kívánt képformátumban.

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

## **Dia bélyegkép létrehozása előadói jegyzetekkel**

Az Aspose.Slides segítségével előadói jegyzetekkel rendelkező dia bélyegképének generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [RenderingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/) osztályból.
1. Használja a [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) metódust az előadói jegyzetek pozíciójának beállításához.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét a renderelési beállításokkal.
1. Mentse a bélyegképet bármely kívánt képformátumban.

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

## **Élő példa**

Próbálja ki az **Aspose.Slides Viewer** ingyenes alkalmazást, hogy lássa, mit valósíthat meg az Aspose.Slides API-val:

![Online PowerPoint néző](online-PowerPoint-viewer.png)

## **GYIK**

**Beágyazhatok-e egy prezentációs nézőt egy webalkalmazásba?**

Igen. Az Aspose.Slides használható a szerveroldalon a diák képként vagy HTML-ként történő renderelésére, majd megjeleníthető a böngészőben. Navigációs és nagyítási funkciók JavaScript segítségével megvalósíthatók az interaktív élményhez.

**Mi a legjobb módja a diák megjelenítésének egy egyedi nézőben?**

Az ajánlott megközelítés, hogy minden diát képként (például PNG vagy SVG) renderel vagy HTML-re konvertál az Aspose.Slides segítségével, majd a kimenetet egy képtárba (asztali alkalmazás esetén) vagy HTML konténerbe (webes esetben) helyezi.

**Hogyan kezeljem a sok diát tartalmazó nagy prezentációkat?**

Nagy prezentációk esetén érdemes lazy-loading vagy igény szerinti renderelés alkalmazása, vagyis a dia tartalmát csak akkor generálni, amikor a felhasználó rá navigál, ez csökkenti a memória- és betöltési időt.