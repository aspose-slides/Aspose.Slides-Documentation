---
title: Prezentációs diák konvertálása képekké Pythonban
linktitle: Dia képnek
type: docs
weight: 35
url: /hu/python-java/convert-slide/
keywords:
  - dia konvertálása
  - dia exportálása
  - dia képpé
  - dia mentése képként
  - dia EMF-be
  - dia PNG-be
  - dia JPEG-be
  - dia bitmapbe
  - dia TIFF-be
  - PowerPoint
  - OpenDocument
  - prezentáció
  - Python
  - Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP prezentációk diáit PNG, JPEG, GIF, TIFF, EMF és egyéb képformátumokba Pythonban az Aspose.Slides segítségével."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java képes egyedi diák renderelésére PowerPoint és OpenDocument bemutatókból PNG, JPEG, GIF, TIFF és más képformátumokban.

A dia képpé konvertálásához kövesse az alábbi lépéseket:

1. Töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztállyal.  
2. Válassza ki a renderelni kívánt diát.  
3. Szükség esetén állítsa be a renderelést a [RenderingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tiffoptions/) osztállyal.  
4. Hívja meg a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) metódust. Ez egy képobjektust ad vissza.  
5. Mentse el a képet, és adja meg a kimeneti formátumot egy [ImageFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imageformat/) értékkel.

## **Dia konvertálása PNG képpé**

A legegyszerűbb konvertálás az alapértelmezett renderelési beállításokat használja. A kapott képobjektum feldolgozható memóriában vagy menthető fájlba.

Az alábbi Python példa rendereli az első diát, és PNG képként menti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Dia konvertálása képekké egyedi méretekkel**

Használja a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) túlterhelést, amely egy [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) értéket fogad el, hogy a diát pontos képpont-méretekkel renderelje.

Az alábbi példa egy 1820 × 1040 JPEG képet hoz létre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Dia konvertálása képekké jegyzetekkel és kommentárokkal**

Alapértelmezés szerint a dia képei nem tartalmaznak jegyzeteket vagy kommentárokat. Adjon át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) objektumot a [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) metódusnak, hogy szabályozza, hol jelenjenek meg a jegyzetek és kommentárok.

Az alábbi példa a csonkított jegyzeteket a dia alá, a kommentárokat pedig a jobb oldalára helyezi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Dia‑képpé konvertáláskor ne adja át a [BottomFull](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomFull) értéket a [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metódusnak. A jegyzetek több szöveget tartalmazhatnak, mint amit a rögzített képméret befogad. Ehelyett használja a [BottomTruncated](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomTruncated) értéket.
{{% /alert %}}

## **Dia konvertálása képekké TIFF opciókkal**

A [TiffOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tiffoptions/) osztály lehetővé teszi a renderelt TIFF kép méretének, felbontásának és egyéb tulajdonságainak szabályozását.

Az alábbi példa az első diát 2160 × 2880 TIFF képként, 300 DPI felbontással rendereli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
A TIFF támogatás nem garantált a JDK 9 előtti Java verziókban.
{{% /alert %}}

## **Az összes dia konvertálása képekké**

Iterálja végig a diakollekciót, hogy az egész bemutatót képsorozattá konvertálja. A rejtett diák bele vannak foglalva, hacsak nem hagyja ki őket kifejezetten.

Az alábbi példa minden diát JPEG képként renderel, vízszintes és függőleges 2-es méretezési tényezőkkel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Enhanced Metafile (EMF) kimenet létrehozása**

Az Enhanced Metafile (EMF) akkor hasznos, ha vektoralapú grafikákat kell cserélni a Microsoft Office-szal vagy egyéb Windows alkalmazásokkal, amelyek támogatják a Windows metafile-okat. A pixelalapú képhez képest egy EMF meg tudja őrizni a vektoros rajzolási műveleteket, amelyek méretezésekor nem veszítenek annyira a tisztaságukban. Az EMF azonban elsősorban kompatibilitási formátum Windows metafile-t támogató alkalmazások számára, nem pedig általános csereformátum. Emellett a bonyolult diá tartalmak, például bitmap képek és egyes hatások rasterizált elemekként tárolódhatnak a vektoros metafile konténerben.

### **Dia exportálása EMF-be**

A [Slide.writeAsEmf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) metódus egy [Slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) objektumot EMF formátumban egy cél stream-be ír. Az alábbi példa betölti egy bemutatót, kiválasztja az első diát, és egy EMF fájl streame írásával menti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

A hívó rendelkezik a [Slide.writeAsEmf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) metódusnak átadott stream-mel, és felelős annak lezárásáért, ahogyan a fenti példában látható.

### **SVG kép konvertálása EMF-be és hozzáadása egy bemutatóhoz**

Használja a [SvgImage.writeAsEmf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) metódust az SVG tartalom EMF-be konvertálásához. A kapott bájtok hozzáadhatók a bemutatóhoz a [ImageCollection.addImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/#addImage) segítségével, és a diára helyezhetők a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addPictureFrame) metódussal.

Az alábbi példa egy [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) objektumot hoz létre SVG markupból, memóriában EMF-be konvertálja, a metafilet az első diára helyezi, és elmenti a bemutatót:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A [SvgImage.writeAsEmf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) nem veszi át a cél stream tulajdonjogát. A [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) az összes generált adatot memóriában tárolja, így a [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) meghívása előtt nincs szükség pozíció visszaállításra. A visszakapott byte tömb a stream lezárása után is érvényes marad.

Az EMF generálás elérhető azon operációs rendszereken, amelyeket a kiválasztott Aspose.Slides for Python via Java és JDK konfiguráció támogat, azonban a renderelés platformonként eltérő lehet, ha a betűkészletek vagy grafikai függőségek nem állnak rendelkezésre. Telepítse a forrástartalom által használt betűkészleteket vagy konfiguráljon megfelelő helyettesítéseket, kövesse az Aspose.Slides for Python via Java [platformkövetelményeket](/slides/hu/python-java/system-requirements/), és ellenőrizze az eredményt a cél EMF-ot fogyasztó alkalmazásban. A Linux és macOS alkalmazások gyakran korlátozott vagy inkonzisztens támogatással rendelkeznek a Windows metafile-ok megjelenítésére és szerkesztésére.

## **Színes Emoji renderelés**

{{% alert title="Note" color="info" %}}
Ahhoz, hogy a színes emojikat helyesen renderelje a diák képekké konvertálásakor, a bemutatóban használt emoji betűkészleteket telepíteni kell, és elérhetőnek kell lenniük a konvertálást végző rendszeren. Például, ha a bemutató **Segoe UI Emoji** betűkészletet használ, és ez hiányzik, az emojik monokrómként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **GYIK**

**Támogatja az Aspose.Slides a diák animációval történő renderelését?**

Nem. A [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) metódus statikus képet renderel a diáról, és nem exportál animációkat.

**Exportálhatók rejtett diák képként?**

Igen. A rejtett diák is renderelhetők, mint a normál diák. Tartalmazza őket a feldolgozási ciklusban, ahogy a fenti példában is látható.

**Megmaradnak az árnyékok és egyéb hatások a diaképekben?**

Igen. Az Aspose.Slides árnyékokat, átlátszóságot és egyéb támogatott grafikai hatásokat renderel a diaképekben.