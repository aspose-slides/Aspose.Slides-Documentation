---
title: Vízjelek hozzáadása prezentációkhoz Pythonban
linktitle: Vízjel
type: docs
weight: 40
url: /hu/python-java/watermark/
keywords:
- vízjel
- szöveges vízjel
- képes vízjel
- vízjel hozzáadása
- vízjel módosítása
- vízjel eltávolítása
- vízjel törlése
- vízjel hozzáadása PPT-hez
- vízjel hozzáadása PPTX-hez
- vízjel hozzáadása ODP-hez
- vízjel eltávolítása PPT-ből
- vízjel eltávolítása PPTX-ből
- vízjel eltávolítása ODP-ből
- vízjel törlése PPT-ből
- vízjel törlése PPTX-ből
- vízjel törlése ODP-ből
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Kezelje a szöveges és képes vízjeleket PowerPoint és OpenDocument prezentációkban Pythonban, hogy jelezze a vázlatot, bizalmas információkat, szerzői jogot és egyebeket."
---
## **Bevezetés**

**A vízjel** egy prezentációban egy szöveges vagy képes pecsét, amelyet egy diára vagy az összes diára alkalmaznak. Általában a vízjelet arra használják, hogy jelezzék, hogy a prezentáció vázlat (például „Vázlat” vízjel), bizalmas információt tartalmaz („Bizalmas” vízjel), megmutassák, melyik céghez tartozik („Cég neve” vízjel), az előadó azonosítására, stb. A vízjel segít megakadályozni a szerzői jogok megsértését azzal, hogy jelzi, hogy a prezentációt nem szabad másolni. A vízjeleket a PowerPoint és az OpenOffice prezentációs formátumokban egyaránt használják. Az Aspose.Slides‑ben vízjelet adhat hozzá PowerPoint PPT, PPTX és OpenOffice ODP fájlformátumokhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/python-java/) különböző módokat kínál a vízjelek PowerPoint vagy OpenOffice dokumentumokba való létrehozására és a megjelenésük, viselkedésük módosítására. A közös pont, hogy szöveges vízjelek hozzáadásához a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) osztályt kell használni, képi vízjelekhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) osztályt vagy egy alakzat képfeltöltését. A [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) osztályból származik, így az alakzat objektum összes rugalmas beállítását használhatja. Mivel a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) nem alakzat, be van csomagolva egy [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) objektumba.

Két módja van a vízjel alkalmazásának: egyetlen diára vagy az összes diára. A Dia Mester (Slide Master) segítségével a vízjel minden diára alkalmazható – a vízjelet a Dia Mesterhez adjuk, ott teljesen megtervezzük, és minden diára átvitelre kerül anélkül, hogy befolyásolná az egyes diákon a vízjel módosítási jogosultságát.

A vízjelet általában nem szerkeszthetőnek tekintik más felhasználók számára. A vízjel (vagy inkább a vízjel szülő alakzata) szerkesztésének megakadályozásához az Aspose.Slides alakzat‑zárolási funkciót kínál. Egy adott alakzatot le lehet zárolni egy normál dián vagy a Dia Mesteren. Ha a vízjel alakzata a Dia Mesteren van zárolva, az minden dián zárolva lesz.

Megadhat nevet a vízjelnek, így a jövőben, ha törölni szeretné, név szerint megtalálhatja a dia alakzatai között.

A vízjelet bármilyen módon megtervezhetjük; a legtöbb esetben közös jellemzők a középre igazítás, elforgatás, előre helyezés stb. Az alábbi példákban ezeket a jellemzőket használjuk.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása egy diára**

A szöveges vízjel hozzáadásához PPT, PPTX vagy ODP formátumban először alakzatot kell a diára helyezni, majd szövegtáblát (text frame) adni ehhez az alakzathoz. A szövegtábla a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) osztállyal valósítható meg. Ez a típus nem örököl a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) osztályból, amely széles körű tulajdonságokat biztosít a vízjel rugalmas elhelyezéséhez. Ezért a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) objektum egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) objektumba van becsomagolva. A szöveges vízjel hozzáadásához az alakzathoz használja a [addTextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/#addTextFrame) metódust, ahogy az alább látható.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}} 
- [A TextFrame osztály használata](/slides/hu/python-java/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása egy prezentációhoz**

Ha a teljes prezentációhoz (azaz egyszerre az összes diához) szeretne szöveges vízjelet hozzáadni, tegye azt a [MasterSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/)-hez. A logika ugyanaz, mint egyetlen diához való hozzáadáskor – hozzon létre egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) objektumot, majd a [addTextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/#addTextFrame) metódussal adja hozzá a vízjelet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}} 
- [A Dia Mester használata](/slides/hu/python-java/slide-master/)
{{% /alert %}}

### **A vízjel alakzat átlátszóságának beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltési és vonalszínekkel van formázva. A következő kódsorok teszik az alakzatot átlátszóvá.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **A szöveges vízjel betűtípusának beállítása**

Az alábbiak szerint változtathatja meg a szöveges vízjel betűtípusát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **A vízjel szövegszínének beállítása**

A vízjel szövegszínének beállításához használja ezt a kódot:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Szöveges vízjel középre helyezése**

A vízjelet középre helyezheti a dián, ehhez tegye a következőket:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

Az alábbi kép mutatja a végső eredményt.

![A szöveges vízjel](text_watermark.png)

## **Képes vízjel**

### **Képes vízjel hozzáadása egy prezentációhoz**

Képes vízjel hozzáadásához egy prezentációs diához tegye a következőket:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Vízjel szerkesztésének letiltása**

Ha meg kell akadályozni a vízjel szerkesztését, használja a [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/#getAutoShapeLock) metódust az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, más elemekkel való csoportosítástól, a szöveg szerkesztésétől és még sok mástól:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Zárolja a vízjel alakzatot a módosítástól.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Vízjel előre hozatala**

Az Aspose.Slides‑ben az alakzatok Z‑rendjét a [ShapeCollection.reorder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#reorder) metódussal állíthatja be. Ehhez hívja meg ezt a metódust a dia alakzatait tartalmazó gyűjteményből, és adja át a alakzat referenciáját és a kívánt sorrendi számot. Így egy alakzatot előre hozhat vagy a dia hátterébe küldhet. Ez a funkció különösen akkor hasznos, ha a vízjelet a prezentáció előterébe kell helyezni:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **A vízjel forgatásának beállítása**

Az alábbi kódrészlet bemutatja, hogyan állítható be a vízjel forgatása, hogy átlósan helyezkedjen el a dián:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Név megadása egy vízjelnek**

Az Aspose.Slides lehetővé teszi az alakzat nevének beállítását. A név használatával a jövőben könnyen elérheti, módosíthatja vagy törölheti azt. A vízjel alakzat nevének beállításához adja át a nevet a [Shape.setName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setName) metódusnak:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja a [Shape.getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getName) metódust a dia alakzatai közötti kereséshez, majd adja át a megtalált alakzatot a [ShapeCollection.remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#remove) metódusnak:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **GYIK**

**Mi az a vízjel, és miért kell használni?**

A vízjel egy szöveges vagy képes átfedés, amelyet a diákra helyeznek, és amely segít a szellemi tulajdon védelmében, a márka felismerhetőségének növelésében vagy a jogosulatlan felhasználás megakadályozásában.

**Hozzáadhatok vízjelet az összes diához a prezentációban?**

Igen, az Aspose.Slides programozott módon hozzáadhat vízjelet minden diához a prezentációban. Végigiterálhat az összes dián, és egyenként alkalmazhatja a vízjel beállításait.

**Hogyan állíthatom be a vízjel átlátszóságát?**

Az átlátszóságot a forma kitöltési beállításainak ([getFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getFillFormat)) módosításával szabályozhatja. Ez biztosítja, hogy a vízjel diszkrét legyen, és ne vonja el a figyelmet a dia tartalmáról.

**Mely képformátumok támogatottak a vízjelekhez?**

Az Aspose.Slides különféle képformátumokat támogat, például PNG, JPEG, GIF, BMP, SVG és továbbiakat.

**Testreszabhatom a szöveges vízjel betűtípusát és stílusát?**

Igen, választhat bármely betűtípust, méretet és stílust, hogy megfeleljen a prezentáció tervezésének és a márka konzisztenciájának.

**Hogyan változtathatom meg a vízjel pozícióját vagy tájolását?**

Programozottan a forma koordinátáinak, méretének és forgatási tulajdonságainak módosításával állíthatja be a vízjel pozícióját és tájolását.