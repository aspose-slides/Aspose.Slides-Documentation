---
title: Bélyegképek létrehozása a bemutató formáiról Pythonon keresztül Java-val
linktitle: Forma bélyegképek
type: docs
weight: 70
url: /hu/python-java/create-shape-thumbnails/
keywords:
- forma bélyegkép
- forma kép
- forma renderelése
- forma renderelés
- vizuális határok
- forma határok
- PowerPoint
- bemutató
- Python
- Java
- Aspose.Slides
description: "Készítsen magas minőségű forma bélyegképeket PowerPoint diákból az Aspose.Slides for Python via Java segítségével – egyszerűen hozhat létre és exportálhat bemutató bélyegképeket."
---
## **Bevezetés**

Aspose.Slides for Python via Java használható bemutató fájlok létrehozására, ahol minden oldal egy diára vonatkozik. A diákat a Microsoft PowerPoint segítségével lehet megnyitni. Néha a fejlesztőknek a formák képeit külön képnézőben szeretnék megtekinteni. Ilyenkor az Aspose.Slides for Python via Java segít a diák formáinak bélyegképeinek generálásában.

Ez a cikk bemutatja, hogyan lehet különböző módokon létrehozni a forma bélyegképeket:

- Bélyegkép generálása egy forma számára egy dián belül.
- Bélyegkép generálása egy diára helyezett forma számára felhasználó által meghatározott méretekkel.
- Bélyegkép generálása a forma megjelenésének határain belül.

## **Bélyegkép generálása egy formáról egy diából**

A forma bélyegképének generálásához bármely diáról az Aspose.Slides for Python via Java használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára azonosítója vagy indexe alapján.
1. [Szerezze meg a forma bélyegképét](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) a hivatkozott dián lévő formáról az alapértelmezett méretezésben.
1. Mentse a bélyegképet a kívánt képpformátumban.

Ez a mintakód bemutatja, hogyan generálhat bélyegképet egy formáról egy diából:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# A Presentation osztály példányosítása, amely a bemutató fájlt képviseli.
presentation = Presentation("Thumbnail.pptx")
try:
    # Teljes méretű képet hoz létre.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Kép mentése lemezre PNG formátumban.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Bélyegkép generálása felhasználó által meghatározott méretezési tényezővel**

A forma bélyegképének generálásához bármely diáról az Aspose.Slides for Python via Java használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára azonosítója vagy indexe alapján.
1. [Szerezze meg a forma bélyegképét](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) a hivatkozott dián lévő formáról felhasználó által meghatározott méretekkel.
1. Mentse a bélyegképet a kívánt képpformátumban.

Ez a mintakód bemutatja, hogyan generálhat bélyegképet egy meghatározott méretezési tényező alapján:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# A Presentation osztály példányosítása, amely a bemutató fájlt képviseli.
presentation = Presentation("Thumbnail.pptx")
try:
    # Kép létrehozása, amely mindkét irányban a 2-es szorzóval van méretezve.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Kép mentése lemezre PNG formátumban.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Határolt megjelenésű forma bélyegkép létrehozása**

Ez a módszer a formák bélyegképének létrehozására lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül generáljanak bélyegképet. Figyelembe veszi az összes formahatást. A létrehozott forma bélyegképét a dia határai korlátozzák. A forma bélyegképének a megjelenés határai között történő generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára azonosítója vagy indexe alapján.
1. Szerezze meg a bélyegképet egy formáról a hivatkozott dián a megjelenési határok alapján.
1. Mentse a bélyegképet a kívánt képpformátumban.

Ez a mintakód a fenti lépések alapján készült:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# A Presentation osztály példányosítása, amely a bemutató fájlt képviseli.
presentation = Presentation("Thumbnail.pptx")
try:
    # Teljes méretű képet hoz létre.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Kép mentése lemezre PNG formátumban.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **A forma tényleges vizuális határainak lekérdezése**

A [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) keret tulajdonságai—az [getX](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getWidth) és [getHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getHeight) metódusok—leírják a prezentáció modellben tárolt téglalapot. A ténylegesen renderelt tartalom túlnyúlhat ezen a kereten vagy egy másik tengely-alignment téglalapot foglalhat el. A forgatás, kontúr, nyílfejek, szöveg elrendezése és túlcsordulása, a generált SmartArt geometria és egyéb renderelési hatások mind módosíthatják a lefoglalt területet.

Használja a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getVisualBounds) metódust a foglalt terület kiszámításához képkészítés nélkül. A metódus egy [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) objektumot ad vissza dia koordinátákban. A visszaadott téglalap nincs levágva a diára, ezért koordinátái negatívak lehetnek, ha a tartalom túlnyúlik a dia kiindulópontján.

Az alábbi példa lekéri és összehasonlítja a keret- és a vizuális határokat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Ugyanaz a [Rectangle2D.Float] használható a közeli formák bal, jobb, felső vagy alsó szélhez történő igazításához; elegendő hely lefoglalásához egy generált elrendezésben; vagy a megengedett területen kívüli tartalom észleléséhez. A vizuális határok különösen hasznosak a SmartArt, szövegdobozok, nyilak, képek, elforgatott formák és csoportformák esetén, ahol a tárolt keret nem feltétlenül tükrözi a teljes megjelenített eredményt.

Használja a [Shape.getVisualBounds] metódust, ha elrendezési vagy validációs koordinátákra van szükség és nem szükséges a bitmap. Használja a [Shape.getImage] metódust, ha a formát renderelni kell. A [ShapeThumbnailBounds](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapethumbnailbounds/) esetén a [ShapeThumbnailBounds.Shape] a képet a forma határai alapján méretezi, beleértve a körvonal beállításokat, míg a [ShapeThumbnailBounds.Appearance] a forma megjelenése alapján méretezi és a diára korlátozza az eredményt. Ezzel szemben a [Shape.getVisualBounds] csak a kiszámított téglalapot adja vissza, és nem vágja le a diára.

## **FAQ**

**Milyen képformátumok használhatók a forma bélyegképeinek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imageformat/), és egyebek. A formák [exportálhatók vektor SVG‑ként](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#writeAsSvgToBytes) is a forma tartalmának SVG‑ként mentésével.

**Mi a különbség a Shape és az Appearance határok között bélyegkép renderelésekor?**

`Shape` a forma geometriai adatait használja; `Appearance` a [visual effects](/slides/hu/python-java/shape-effect/) (árnyékok, ragyogások stb.) figyelembevételével.

**Mi történik, ha egy forma rejtettnek van jelölve? Továbbra is renderelődik bélyegképként?**

A rejtett forma továbbra is része a modellnek, és renderelhető; a rejtett jelző a diavetítés megjelenítését befolyásolja, de nem akadályozza meg a forma képének generálását.

**Támogatottak-e a csoportformák, diagramok, SmartArt és egyéb összetett objektumok?**

Igen. Bármely objektum, amely [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/)‑ként (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/) és a [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/)) van reprezentálva, elmenthető bélyegképként vagy SVG‑ként.

**A rendszerben telepített betűkészletek befolyásolják a szövegformák bélyegképeinek minőségét?**

Igen. Ajánlatos [a szükséges betűkészleteket biztosítani](/slides/hu/python-java/custom-font/) (vagy [betűcsere beállítását](/slides/hu/python-java/font-substitution/) konfigurálni), hogy elkerülje a nem kívánt helyettesítéseket és a szöveg újrafuttatását.