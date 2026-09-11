---
title: Táblázatcellák kezelése prezentációkban Python használatával
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/python-java/manage-cells/
keywords:
- táblázatcella
- cellák összefűzése
- határvonal eltávolítása
- cella felbontása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Könnyedén kezelheti a táblázatcellákat PowerPointban az Aspose.Slides for Python via Java segítségével. Gyorsan elsajátíthatja a cellák elérését, módosítását és stílusozását a zökkenőmentes diák automatizálásához."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy hozzáférjünk és módosítsuk a táblázatcellákat a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosítsunk összevont táblázatcellákat, távolítsuk el a cellahatárokat, hogyan dolgozzunk a cellaszámozással az összevonás vagy felbontás után, hogyan változtassuk meg egy cella háttérszínét, és hogyan adjunk képet egy táblázatcella belsejébe. A példák bemutatják, hogyan hozzunk létre vagy nyissunk meg egy prezentációt, hogyan szerezzünk egy táblázatot egy diáról, hogyan frissítsük a cellaformázást a cella tulajdonságain keresztül, és hogyan mentsük el a módosított prezentációt PPTX fájlként.

## **Egy összevont táblázatcella azonosítása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a táblázatot az első diáról.
3. Iteráljon a táblázat sorain és oszlopain, hogy megtalálja az összevont cellákat.
4. Nyomtasson üzenetet, ha összevont cellákat talál.

Ez a Python kód megmutatja, hogyan azonosíthatók az összevont táblázatcellák egy prezentációban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Tegyük fel, hogy az első dia első alakja egy táblázat.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Táblázatcella határok eltávolítása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Határozzon meg egy oszlopszélességek listáját.
4. Határozzon meg egy sormagasságok listáját.
5. Adjon hozzá egy táblázatot a diára a [addTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addTable) metódus segítségével.
6. Iteráljon minden cellán, hogy törölje a felső, alsó, jobb és bal határokat.
7. Mentse el a módosított prezentációt PPTX fájlként.

Ez a Python kód megmutatja, hogyan távolíthatók el a határok a táblázatcellákról:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Az első diát érjük el.
    slide = presentation.getSlides().get_Item(0)

    # Oszlop szélességeket és sor magasságokat definiáljuk.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Táblázatot adunk hozzá a diához.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Beállítjuk a szegély formátumát minden cellához.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Mentjük a prezentációt PPTX fájlként.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Számozás az összevont cellákban**

Ha két cellapárt vonunk össze, (1, 1) és (2, 1), valamint (1, 2) és (2, 2), az eredményül kapott táblázat megtartja a cellaszámozását. Ez a Python kód bemutatja a folyamatot:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    #    Az első diát érjük el.
    slide = presentation.getSlides().get_Item(0)

    #    Definiáljuk az oszlopszélességeket és a sormagasságokat.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    #    Táblázat hozzáadása a diához.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    #    A szegély formátumának beállítása minden cellához.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    #    Cellák (1, 1) és (2, 1) összevonása.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    #    Cellák (1, 2) és (2, 2) összevonása.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    #    A prezentáció mentése PPTX fájlként.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aztán tovább vonjuk össze a cellákat a (1, 1) és (1, 2) cellák összevonásával. Az eredmény egy középen nagy összevont cellát tartalmazó táblázat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    #    Az első diát érjük el.
    slide = presentation.getSlides().get_Item(0)

    #    Az oszlopszélességeket és sormagasságokat definiáljuk.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    #    Táblázat hozzáadása a diához.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    #    A szegély formátumának beállítása minden cellához.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    #    Cellák (1, 1) és (2, 1) összevonása.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    #    Cellák (1, 2) és (2, 2) összevonása.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    #    Cellák (1, 1) és (1, 2) összevonása.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    #    A prezentáció mentése PPTX fájlként.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Számozás egy felbontott cellában**

Az előző példákban a táblázatcellák összevonása nem változtatta meg a többi cella számozását.

Hagyományos táblázatot (azaz összevont cellákat nem tartalmazó táblázat) veszünk, majd megpróbáljuk felbontani a (1, 1) cellát, hogy egy speciális táblázatot kapjunk. Érdemes figyelni a táblázat számozására, amely furcsának tűnhet. Ez azonban a Microsoft PowerPoint által a táblázatcellák számozásának módja, és az Aspose.Slides is ugyanezt teszi.

Ez a Python kód bemutatja a leírt folyamatot:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Az első diát érjük el.
    slide = presentation.getSlides().get_Item(0)

    # Az oszlopszélességeket és sormagasságokat definiáljuk.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Táblázat hozzáadása a diához.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # A szegély formátumának beállítása minden cellához.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Cellát (1, 1) felosztja.
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # A prezentáció mentése PPTX fájlként.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A táblázatcella háttérszínének megváltoztatása**

Ez a Python kód megmutatja, hogyan változtatható meg egy táblázatcella háttérszíne:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    #    Az első diát érjük el.
    slide = presentation.getSlides().get_Item(0)

    #    Az oszlopszélességeket és sormagasságokat definiáljuk.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    #    Táblázat hozzáadása a diához.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    #    Cella háttérszínének beállítása.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    #    A prezentáció mentése PPTX fájlként.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kép hozzáadása egy táblázatcella belsejébe**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Határozzon meg egy oszlopszélességek listáját.
4. Határozzon meg egy sormagasságok listáját.
5. Adjon hozzá egy táblázatot a diára a [addTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addTable) metódus segítségével.
6. Töltse be a kép fájlt a [Images.fromFile](https://reference.aspose.com/slides/hu/python-java/aspose.slides/images/#fromFile) segítségével.
7. Adja hozzá a képet a prezentációhoz, hogy létrejöjjön egy [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) objektum.
8. Állítsa be a táblázatcella [FillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/) kitöltés típusát a [FillType.Picture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/#Picture) értékre.
9. Adja hozzá a képet a táblázat első cellájához.
10. Mentse el a módosított prezentációt PPTX fájlként.

Ez a Python kód megmutatja, hogyan helyezhető egy kép egy táblázatcella belsejébe táblázat létrehozásakor:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Az első diát érjük el.
    slide = presentation.getSlides().get_Item(0)

    # Az oszlopszélességeket és sormagasságokat definiáljuk.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Táblázat hozzáadása a diához.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Prezentáció kép létrehozása a képfájlból.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # A kép hozzáadása az első táblázatcella.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # A prezentáció mentése PPTX fájlként.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Beállíthatok különböző vonalvastagságokat és stílusokat egy cella egyes oldalaira?**

Igen. A [top](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellformat/#getBorderRight) határoknak külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérhet. Ez logikusan következik a cellára vonatkozó oldalankénti határvezérlésből, ahogyan a cikkben bemutatásra került.

**Mi történik a képpel, ha a képet beállítom a cella háttérként, majd megváltoztatom az oszlop/sor méretét?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillmode/) (stretch/tile) beállítástól függ. Nyújtás esetén a kép a új cellához igazodik; csempézés esetén a csempéket újraszámítják. A cikk említi a kép megjelenítési módjait egy cellában.

**Hozzá tudok-e adni hiperhivatkozást a cella teljes tartalmához?**

[Hyperlinks](/slides/hu/python-java/manage-hyperlinks/) a cella szövegtáblázatán belül a szöveg (részlet) szintjén vagy a teljes táblázat/forma szintjén állítható be. Gyakorlatban a linket egy részlethez vagy a cella teljes szövegéhez rendeli.

**Beállíthatok-e különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegtáblázata támogatja a [portions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) (futás) független formázásával – betűcsalád, stílus, méret és szín.