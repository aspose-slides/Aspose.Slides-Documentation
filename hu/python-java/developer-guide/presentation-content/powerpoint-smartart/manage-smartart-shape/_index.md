---
title: SmartArt grafika kezelése prezentációkban Python használatával
linktitle: SmartArt grafika
type: docs
weight: 20
url: /hu/python-java/manage-smartart-shape/
keywords:
- SmartArt objektum
- SmartArt grafika
- SmartArt stílus
- SmartArt szín
- SmartArt létrehozása
- SmartArt hozzáadása
- SmartArt szerkesztése
- SmartArt módosítása
- SmartArt elérése
- SmartArt elrendezéstípus
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Automatizálja a PowerPoint SmartArt létrehozását, szerkesztését és stilizálását Pythonban az Aspose.Slides használatával, tömör kódrészletekkel és a teljesítményre fókuszáló útmutatóval."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan hozzon létre és kezeljen SmartArt grafikákat PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan adjon hozzá SmartArt alakzatot egy diára, hogyan érje el a meglévő SmartArt alakzatokat, hogyan találjon SmartArt‑ot egy adott elrendezéstípus alapján, és hogyan frissítse a megjelenését a SmartArt stílus vagy színstílus módosításával.

## **SmartArt alakzat létrehozása**
Aspose.Slides for Python via Java API-t biztosít a SmartArt alakzatok létrehozásához. Egy SmartArt alakzat létrehozásához egy dián, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a diát az indexe alapján.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addSmartArt) egy [SmartArtLayoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartlayouttype/) megadásával.
1. Mentse a módosított prezentációt PPTX fájlként.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Az első diát kapja meg.
    slide = presentation.getSlides().get_Item(0)

    # SmartArt alakzat hozzáadása.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # A prezentáció mentése.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Ábra: SmartArt alakzat hozzáadva a diához**|

## **SmartArt alakzat elérése egy dián**
A következő példa eléri a SmartArt alakzatokat egy prezentációs dián. Végigiterál minden alakzaton a dián, és ellenőrzi, hogy az alakzat egy [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iteráljon minden alakzaton az első dián.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **SmartArt alakzat elérése egy adott elrendezéstípussal**
A következő példa egy adott elrendezéstípusú [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) alakzatot ér el, amelyet a [SmartArt.getLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/#getLayout) visszaad.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be azt a prezentációt, amely SmartArt alakzatot tartalmaz.
1. Szerezze meg az első diát az indexe alapján.
1. Végigiterál minden alakzaton az első dián.
1. Ellenőrizze, hogy az alakzat egy [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.
1. Ellenőrizze, hogy a SmartArt alakzat rendelkezik-e a megadott elrendezéstípussal, és hajtsa végre a szükséges műveletet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iteráljon minden alakzaton az első dián.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Ellenőrizze a SmartArt elrendezését.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **SmartArt alakzat stílusának módosítása**
Ez a példa bemutatja, hogyan változtassuk meg egy SmartArt alakzat gyors stílusát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a SmartArt alakzatot tartalmazó prezentációt.
1. Szerezze meg az első diát az indexe alapján.
1. Végigiterál minden alakzaton az első dián.
1. Ellenőrizze, hogy az alakzat egy [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.
1. Keresse meg a megadott stílussal rendelkező SmartArt alakzatot.
1. Állítsa be az új stílust a SmartArt alakzatra.
1. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iteráljon minden alakzaton az első dián.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Ellenőrizze és módosítsa a SmartArt stílusát.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Ábra: SmartArt alakzat módosított stílussal**|

## **SmartArt alakzat színstílusának módosítása**
Ez a példa egy adott színstílussal rendelkező SmartArt alakzatot ér el, és megváltoztatja azt a stílust.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a SmartArt alakzatot tartalmazó prezentációt.
1. Szerezze meg az első diát az indexe alapján.
1. Végigiterál minden alakzaton az első dián.
1. Ellenőrizze, hogy az alakzat egy [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.
1. Keresse meg a megadott színstílussal rendelkező SmartArt alakzatot.
1. Állítsa be az új színstílust a SmartArt alakzatra.
1. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iteráljon minden alakzaton az első dián.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Ellenőrizze és módosítsa a SmartArt stílusát.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Ábra: SmartArt alakzat módosított színstílussal**|

## **FAQ**

**Animálhatom a SmartArt-ot egyetlen objektumként?**

Igen. A SmartArt egy alakzat, ezért a [standard animations](/slides/hu/python-java/powerpoint-animation/) animációkat az animációs API-n keresztül (belépés, kilépés, hangsúlyozás, mozgási útvonalak) alkalmazhatja, akárcsak más alakzatoknál.

**Hogyan találhatok meg egy adott SmartArt-ot egy dián, ha nem ismerem a belső azonosítóját?**

Állítsa be és használja a [alternative text](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setAlternativeText) attribútumot, majd keresse meg az alakzatot ezen az értéken keresztül – ez a javasolt módja a cél alakzat megtalálásának.

**Csoportosíthatom a SmartArt-ot más alakzatokkal?**

Igen. A SmartArt-ot csoportosíthatja más alakzatokkal (képek, táblázatok stb.), majd [manipulálhatja a csoportot](/slides/hu/python-java/group/).

**Hogyan kapok képet egy adott SmartArt-ról (például előnézethez vagy jelentéshez)?**

Exportáljon egy előnézeti képet/miniaturát az alakzatról; a könyvtár képes [renderelni az egyes alakzatokat](/slides/hu/python-java/create-shape-thumbnails/) raszteres fájlokba (PNG/JPG/TIFF).

**Megmarad a SmartArt megjelenése, ha az egész prezentációt PDF‑be konvertáljuk?**

Igen. A renderelő motor a [PDF export](/slides/hu/python-java/convert-powerpoint-to-pdf/) során a magas hűséget célozza meg, számos minőség- és kompatibilitási lehetőséggel.