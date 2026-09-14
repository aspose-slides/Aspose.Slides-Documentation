---
title: Prezentáció háttér kezelése Pythonban Java-n keresztül
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/python-java/presentation-background/
keywords:
- prezentáció háttér
- dia háttér
- egyszínű szín
- színátmenetes szín
- kép háttér
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for Python via Java használatával, kódtippekkel, amelyek javítják prezentációit."
---
## **Bevezetés**

Az egyszínű színek, a színátmenetek és a képek gyakran használtak dia háttérként. Beállíthatja a háttért egy **normál diára** (egyetlen dia) vagy egy **mesterdiára** (több diára egyszerre alkalmazva).

![PowerPoint háttér](powerpoint-background.png)

## **Egyszínű háttér beállítása normál diára**

Aspose.Slides lehetővé teszi, hogy egy adott dia háttérét egy egyszínű színnel állítsa be egy prezentációban – még akkor is, ha a prezentáció mesterdiát használ. A módosítás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#getsolidfillcolor) metódust a [FillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/) osztályon a szilárd háttérszín megadásához.
5. Mentse el a módosított prezentációt.

A következő Python példa megmutatja, hogyan állíthat be egy kék egyszínű színt normál dia háttérként:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Állítsa be a dia háttérszínét kékre.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Mentse el a prezentációt a lemezen.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyszínű háttér beállítása mesterdiára**

Aspose.Slides lehetővé teszi, hogy egy egyszínű színt állítson be a mesterdia háttérként egy prezentációban. A mesterdia sablonként működik, amely az összes dia formázását szabályozza, így amikor egyszínű színt választ a mesterdia háttérhez, az minden diára alkalmazásra kerül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a mesterdia [BackgroundType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/backgroundtype/) értékét (a [getMasters](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getmasters) segítségével) `OwnBackground`-ra.
3. Állítsa be a mesterdia háttér [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#getsolidfillcolor) metódust a szilárd háttérszín megadásához.
5. Mentse el a módosított prezentációt.

A következő Python példa megmutatja, hogyan állíthat be egy zöld egyszínű színt mesterdia háttérként:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Állítsa be a mester dia háttérszínét zöldre.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Mentse el a prezentációt a lemezen.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Színátmenetes háttér beállítása diához**

A színátmenet egy grafikus hatás, amely fokozatos színváltozással jön létre. Diák háttérként használva a színátmenetek művészibbé és professzionálisabbá tehetik a prezentációkat. Az Aspose.Slides lehetővé teszi, hogy egy színátmenetes színt állítson be a diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét `Gradient`-ra.
4. Használja a [getGradientFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#getgradientformat) metódust a [FillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/) osztályon a kívánt színátmenet beállításához.
5. Mentse el a módosított prezentációt.

A következő Python példa megmutatja, hogyan állíthat be egy színátmenetes színt dia háttérként:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Alkalmazzon egy színátmenet hatást a háttérre.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Adja hozzá a színátmenet színeit. Színátmeneti állomások nélkül a háttér az alapértelmezett fekete-fehér skálára vált.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Mentse el a prezentációt a lemezen.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kép beállítása dia háttérként**

Az egyszínű és színátmenetes kitöltések mellett az Aspose.Slides lehetővé teszi, hogy képeket használjon dia háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét `Picture`-ra.
4. Töltse be a képet, amelyet a dia háttérként szeretne használni.
5. Adja hozzá a képet a prezentáció képgyűjteményéhez.
6. Használja a [getPictureFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#getpicturefillformat) metódust a [FillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/) osztályon a kép háttérként való hozzárendeléséhez.
7. Mentse el a módosított prezentációt.

A következő Python példa megmutatja, hogyan állíthat be egy képet dia háttérként:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Állítsa be a háttérkép tulajdonságait.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Töltse be a képet.
    image = Images.fromFile("Tulips.jpg")
    # Adja hozzá a képet a prezentáció képgyűjteményéhez.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Mentse el a prezentációt a lemezen.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A következő kódminta megmutatja, hogyan állítható be a háttérkitöltés típusára egy csempézett kép, és hogyan módosíthatók a csempézési tulajdonságok:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Állítsa be a háttér kitöltéséhez használt képet.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Állítsa be a kép kitöltési módot Csempére, és módosítsa a csempézési tulajdonságokat.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}}
Olvasson tovább: [Tile Picture as Texture](/slides/hu/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Előfordulhat, hogy módosítani szeretné egy dia háttérképének átlátszóságát, hogy a dia tartalma jobban kiemelkedjen. A következő Python kód megmutatja, hogyan változtathatja meg a dia háttérkép átlátszóságát:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Például.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Szerezze be a képtranszformáció műveletek gyűjteményét.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Keresse meg a meglévő fix százalékos átlátszósági hatást.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Állítsa be az új átlátszósági értéket.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dia háttérérték lekérése**

Az Aspose.Slides lehetővé teszi, hogy a [getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/background/#geteffective) metódussal a [Background](https://reference.aspose.com/slides/hu/python-java/aspose.slides/background/) objektumon lekérje egy dia hatékony háttérértékeit. A visszakapott adatok tartalmazzák a hatékony kitöltés- és effektformátumokat.

A [BaseSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/) osztály [getBackground](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getbackground) metódusával lekérheti egy dia hátterét.

A következő Python példa megmutatja, hogyan kaphatja meg egy dia hatékony háttérértékét:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Szerezze be a hatékony hátteret, figyelembe véve a mestert, elrendezést és a témát.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **GYIK**

**Visszaállíthatom-e az egyedi hátteret, és visszaállíthatom a téma/layout hátteret?**

Igen. Távolítsa el a dia egyedi kitöltését, és a háttér újra öröklődik a megfelelő [layout](/slides/hu/python-java/slide-layout/)/[master](/slides/hu/python-java/slide-master/) diáról (azaz a [theme background](/slides/hu/python-java/presentation-theme/))-tól.

**Mi történik a háttérrel, ha később megváltoztatom a prezentáció témáját?**

Ha egy diához saját kitöltés tartozik, az változatlan marad. Ha a háttér a [layout](/slides/hu/python-java/slide-layout/)/[master](/slides/hu/python-java/slide-master/) diáról öröklődik, akkor az frissül, hogy megfeleljen az [új theme](/slides/hu/python-java/presentation-theme/)-nek.