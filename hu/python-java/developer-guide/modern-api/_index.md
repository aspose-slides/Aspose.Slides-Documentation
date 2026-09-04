---
title: Modern API-val a képfeldolgozás fejlesztése Pythonban
linktitle: Modern API
type: docs
weight: 237
url: /hu/python-java/modern-api/
keywords:
- modern API
- rajzolás
- dia bélyegkép
- dia képpé konvertálás
- alakzat bélyegkép
- alakzat képpé konvertálás
- bemutató bélyegkép
- bemutató képekhez
- kép hozzáadása
- kép beillesztése
- Python
- Java
- Aspose.Slides
description: "Modernizálja a képfeldolgozást Pythonon keresztül Java segítségével: rendereljen diákat és alakzatokat, adjon hozzá képeket, és migrálja a elavult képfeldolgozó hívásokat az Aspose.Slides Modern API-ra."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java a Java könyvtárat JPype-en keresztül érheti el. A régi képfeldolgozó API-ja a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) és a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) osztályokat a `java.awt`-ból használta.

A Java könyvtár a 24.4-es verziótól kezdve elavulttá tette ezeket a képfeldolgozó API-kat. A Modern API a [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) használatát írja elő képek betöltésére, renderelésére és mentésére. Új Python kód esetén, valamint a meglévő képfeldolgozó munkafolyamatok átigazításakor használja.

{{% alert color="info" title="Note" %}}
Az alábbi régi metódusnevek migrációs hivatkozások. Jelen verziókban már nem érhetők el. A futtatható példák a Modern API-t használják.
{{% /alert %}}

## **Modern API**

A fő képfeldolgozó típusok:

- [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) — egy raszteres vagy vektoros képet képvisel.
- [ImageFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imageformat/) — képfájl-formátum állandókat biztosít.
- [Images](https://reference.aspose.com/slides/hu/python-java/aspose.slides/images/) — képek létrehozása, például a [Images.fromFile](https://reference.aspose.com/slides/hu/python-java/aspose.slides/images/#fromFile) segítségével.

Használja a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) vagy a [Shape.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) metódust egy dia vagy alakzat rendereléséhez. A [Presentation.getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) renderelési beállításokkal több dia renderelésére szolgál. A paraméterek nélküli túlterhelés a bemutató képgyűjteményét adja vissza.

Képet betölthet a [Images.fromFile](https://reference.aspose.com/slides/hu/python-java/aspose.slides/images/#fromFile) segítségével, hozzáadhatja a [ImageCollection.addImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/#addImage) metódussal, vagy egy meglévő bemutató képet frissíthet a [PPImage.replaceImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#replaceImage) segítségével. Mindkét képgyűjtemény-művelet az [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) típusú objektumokat fogadja.

Minden betöltött vagy renderelt képet a `dispose` metódus meghívásával szabadítson fel egy `finally` blokkban. A bemutatót a [Presentation.dispose](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#dispose) metódussal adja le.

### **Készítsd elő a Python környezetet**

Telepítse a csomagokat a [Installation](/slides/hu/python-java/installation/) leírása szerint. Minden példa a `asposeslides` importálása előtt indítja el a JVM-et, majd a JVM futása közben importálja az API-t. A példák a JVM-et futtatva hagyják, hogy később újra felhasználható legyen. Lásd a [Limitations and API Differences](/slides/hu/python-java/limitations-and-api-differences/#import-the-library) részt a notebook és a JVM életciklus útmutatóért.

Azok a példák, amelyek a `pres.pptx`-t nyitják, egy bemutatót igényelnek a munkakönyvtárban. Azok a példák, amelyek a `image.png`-t töltik be, egy meglévő képfájlt igényelnek.

### **Kép betöltése és dia renderelése**

Ez a példa képet ad az első diára, majd a diát JPEG képként menti. Az [IImage.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/#save) a renderelt képet a megadott formátumban írja ki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Régi kód cseréje a Modern API-val**

Cserélje le a régi bélyegkép‑hívásokat olyan metódusokra, amelyek [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) objektumot adnak vissza, majd mentse az eredményt az [IImage.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/#save) segítségével. Így már nem szükséges a renderelt képet a [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-) metódusnak átadni.

### **Dia renderelése megadott méretben**

Cserélje le a régi `slide.getThumbnail(image_size)` hívást a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) használatára ugyanazzal a képmérettel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Dia bélyegkép lekérése**

Cserélje le a régi `slide.getThumbnail()` hívást a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) paraméterek nélküli változatára.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Alakzat bélyegkép lekérése**

Cserélje le a régi `shape.getThumbnail()` hívást a [Shape.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) hívásra. Ellenőrizze, hogy a dia tartalmaz-e alakzatot, mielőtt hozzáférne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Bemutató bélyegkép lekérése**

Cserélje le a régi `presentation.getThumbnails(options, image_size)` hívást a [Presentation.getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) használatára. A renderelés beállításához használja a [RenderingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/) osztályt.

Iteráljon közvetlenül a visszaadott tömbön a Python `enumerate` függvényével. Minden visszakapott képet egy `finally` blokkban szabadítson fel, hogy mentési hiba esetén sem maradjon felszabadítatlan kép.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Kép hozzáadása egy bemutatóhoz**

Cserélje le a [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) használatát a [Images.fromFile](https://reference.aspose.com/slides/hu/python-java/aspose.slides/images/#fromFile) függvényre, majd adja át a kapott képet a [ImageCollection.addImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/#addImage) metódusnak. Adja hozzá a képet a diához, majd mentse a bemutatót.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Elavult metódusok és helyettesítésük a Modern API-ban**

A táblázatok Python hívásnotációt használnak. Az elavult oszlopban szereplő nevek a már eltávolított API-kat azonosítják; használja a hivatkozott helyettesítő metódusokat. A modern kép‑renderelő metódusok [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) objektumot adnak vissza a Java buffered image helyett.

### **Prezentáció**

[Presentation.getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) akkor ad vissza renderelt képek tömbjét, ha renderelési beállításokkal hívják meg.

| Elavult hívás | Modern helyettesítés |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) with `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) with `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) with `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) with `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) with `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) with `options, image_size` |

Itt a `slides` egy Java `int[]` tömb, amely egy‑alapú diaszámokat tartalmaz; a `jpype.JArray(jpype.JInt)([1, 3])` kifejezéssel hozható létre a 1‑ és 3‑as diák kiválasztásához. Az `image_size` egy [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) objektum.

### **Alakzat**

| Elavult hívás | Modern helyettesítés |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) with no arguments |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) with `bounds, scale_x, scale_y` |

### **Dia**

| Elavult hívás | Modern helyettesítés |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) with no arguments |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) with `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) with `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) with `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) with `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) with `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) with `image_size` |
| `slide.renderToGraphics(options, graphics)` | No direct replacement; render to an image instead |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | No direct replacement; render to an image instead |
| `slide.renderToGraphics(options, graphics, image_size)` | No direct replacement; render to an image instead |

Itt az `options` egy [RenderingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/) objektum, a `tiff_options` pedig egy [TiffOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tiffoptions/) objektum.

### **Kimenet**

| Elavult hívás | Modern helyettesítés |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/output/#add) with `path, image`, where `image` is [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Elavult hívás | Modern helyettesítés |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/#addImage) with an [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) |

### **PPImage**

| Elavult hívás | Modern helyettesítés |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getImage) |

Egy meglévő bemutató képet a [PPImage.replaceImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#replaceImage) metódussal, egy [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) objektummal helyettesíthet.

### **PatternFormat**

| Elavult hívás | Modern helyettesítés |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/hu/python-java/aspose.slides/patternformat/#getTile) with `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/hu/python-java/aspose.slides/patternformat/#getTile) with `background, foreground` |

A színargumentumok továbbra is Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) objektumok maradnak.

### **PatternFormatEffectiveData**

A Java API‑n keresztül JPype‑el visszaadott effektív mintázati adatok helyettesítő metódusa a `getTileIImage` nevet őrzi.

| Elavult hívás | Modern helyettesítés |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, returning [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) |

## **API támogatás a Graphics2D-hez**

Az elavult `renderToGraphics` túlterhelések a hívó által biztosított [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) kontextusba rajzoltak. A Modern API-nak nincs közvetlen helyettesítője, amely ebbe a kontextusba rajzolna.

Használja a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) metódust egy dia rendereléséhez vagy a [Presentation.getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) metódust több dia rendereléséhez, majd mentse a visszakapott képeket az [IImage.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/#save) segítségével. Azok az alkalmazások, amelyek a dia renderelést egyedi Java rajzolással kombinálták, át kell alakítaniuk a kompozíciós lépést.

## **GYIK**

**Miért lett a régi Java képalkotó API helyettesítve?**

A Modern API a képek betöltését, renderelését és mentését az [IImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/iimage/) használatára helyezi. Ez egy közös kép‑absztrakciót biztosít a munkafolyamatoknak, a Java buffered image vagy a Java graphics context helyett.

**Szükségem van még Java‑ra és JPype‑re?**

Igen. Az Aspose.Slides for Python via Java továbbra is a JVM-en fut. A Modern API csak a képfeldolgozó hívásokat módosítja, a futtatási követelményeket nem.

**Hogyan szabadítsam fel a képeket Pythonban?**

Hívja meg a `dispose` metódust minden betöltött vagy renderelt képen egy `finally` blokkban. Ha több diát renderel, szabadítsa fel minden képet a visszaadott tömbből. A bemutatót külön szabadítsa fel a [Presentation.dispose](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#dispose) metódussal.

**Garantálja a Modern API-ra való átállás a gyorsabb bélyegkép‑generálást?**

Nem garantált teljesítményjavulás. A helyettesítők támogatják a renderelési beállításokat, a skálázást és a képméreteket; a teljesítményt a saját bemutatóival és kimeneti beállításaival kell mérni.

**Miért ad vissza a kép‑lekérő néha gyűjteményt?**

A [Presentation.getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) paraméterek nélkül a beágyazott bemutatóképeket adja vissza. A renderelési beállításokkal rendelkező túlterhelések a renderelt diaképeket adják vissza.