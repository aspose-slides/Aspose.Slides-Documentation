---
title: Táblázatcellák kezelése prezentációkban Python segítségével
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/python-java/manage-cells/
keywords:
- táblázatcella
- cellák összevonása
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "PowerPoint táblázatcellák kezelése Pythonban: összevont cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy elérje és módosítsa a táblázatcellákat PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosíthatók az összevont táblázatcellák, hogyan távolíthatók el a cellaszegélyek, hogyan kezelhető a cellaszámozás cellák összevonása vagy felosztása után, hogyan változtatható meg egy cella háttérszíne, és hogyan adhatunk képet a táblázatcellán belül. A példák azt mutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezhetünk táblázatot egy diából, hogyan frissíthetjük a cellaformázást cella‑tulajdonságokon keresztül, és hogyan menthetjük a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nulla‑alapú indexeket használ a táblázatcellák eléréséhez `(oszlop, sor)` sorrendben.

## **Az összevont táblázatcellák azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblázatként éri el. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat táblázat. Ezután végigiterál az összes soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) használatával azonosítja az összevont régiók celláit. Minden egyezésnél kiírja a cella koordinátáit `row;column` sorrendben, a [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), a [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), valamint a régió kezdő koordinátáit, a [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) és a [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Táblázatcella szegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) és adjon egy táblázatot az első diájához a [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) használatával. Az oszlopszélességeket, sormagasságokat és a táblázat pozícióját pontban adja meg. A példa minden négy cellaszegélyt a [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) értékre állítja, így azok láthatatlanok.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Táblázatcellák összevonása**

A [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) használatával egy téglalap alakú táblázatcellatartományt egy cellává egyesítheti. Adja meg a tartomány bal‑felső és jobb‑alsó sarkának celláit. Az utolsó argumentum határozza meg, hogy az összevonás tartalmazhat‑e a megadott tartományon kívüli cellákat; a `False` érték az összevonást a tartományon belül tartja.

A példa 4‑by‑4‑es táblázatot hoz létre 70‑pontos oszlopszélességekkel és sormagasságokkal, majd összevonja a négy középső cellát a `(1, 1)`‑től a `(2, 2)`‑ig terjedő tartományban. Az eredményül kapott cella két oszlopot és két sort fed le, míg a táblázat alaprendszere továbbra is négy oszlopból és négy sorból áll. Az összevont cella tartalmához vagy formázásához a bal‑felső pozíciót kell használni: `table.get_Item(1, 1)` ebben a példában. A többi pozíció az összevont tartományban továbbra is a táblázat rácsának része marad, így a tartományon kívüli cellák indexei nem változnak.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Táblázatcellák felosztása**

Az előző példában a cellák összevonása megőrzi a táblázat rácsát. Egy cella felosztása új rácsoszlopot vezethet be, és megváltoztathatja a jobbra lévő cellák oszlopindexeit. Az Aspose.Slides a PowerPoint táblázatrács-modelljét követi.

Ebben a példában egy 4‑by‑4‑es táblázatot hozunk létre 70‑pontos oszlopszélességekkel és sormagasságokkal, majd a `(1, 1)`‑es cellán meghívjuk a [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) metódust. A cella 70‑pontos szélességének felét adjuk meg, hogy két egyenlő szélességű cellát kapjunk.

A felosztás után a két felét a `table.get_Item(1, 1)` és a `table.get_Item(2, 1)` hívásokkal érhetjük el. A táblázat rácsa most már öt oszlopot tartalmaz: az eredetileg a 2‑es és 3‑as oszlopban lévő cellák a 3‑as és 4‑es oszlopokra kerülnek. A sorindexek változatlanok maradnak. A felosztás után a frissített oszlopindexeket kell használni a cellák eléréséhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Összevont cellák felosztása sor- vagy oszlopszakasz szerint**

Az összevont sabloncellák adatkitöltés előkészítéséhez használja a [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) metódust egy meglévő sorhatáron való felosztáshoz, vagy a [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) metódust oszlophatáron való felosztáshoz.

Az `index` argumentum a felosztás felső részének sorait vagy a bal részének oszlopait számolja; a megadott összevont területhez viszonyítva értendő:

- Sorfelosztás: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Oszlopfelosztás: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

A példa azt feltételezi, hogy a prezentáció első diáján az első alakzat egy táblázat, ahol a `(1, 2)` és `(1, 3)` cellák függőlegesen össze vannak vonva. Az alsó pozícióból kiindulva a [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) és a [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) segítségével meghatározza a kiindulópontot, és ellenőrzi mindkét kiterjedést. A `splitByRowSpan(1)` ezután szétválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Vízszintes két‑oszlopos összevonás esetén használja a `splitByColSpan(1)`-et.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # A felosztás után szerezze be a táblából a kapott cellákat.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

A táblázat rácsa és a környező cellaindexek változatlanok maradnak. Az eredményül kapott cellákat koordinátáik alapján kérdezhetjük le; itt mindkettőnek 1‑es kiterjedése van, és a [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) `False`‑t ad vissza. Nagyobb területek egy felosztás után is részben összevonva maradhatnak.

Az eredeti szöveg és formázása a felső (vagy bal) cellában marad; az új cella üres, de örökli a cellaformázást, például a kitöltést, a szegélyeket és a margókat. A felosztás után töltse fel a cellákat, és állítsa be a szükséges szövegformázást explicit módon.

A mentett prezentáció külön „Product A” és „Product B” cellákat tartalmaz, miközben a sablon cellaformázása megmarad. További részletekért tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/).

## **A táblázatcella háttérszínének módosítása**

Ez a példa 150‑pontos oszlopszélességgel és 50‑pontos sormagassággal hoz létre egy táblázatot. A [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) segítségével szilárd kitöltést választ, majd a [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) által visszaadott színt pirosra állítja a `(2, 3)`‑as cellához, azaz a harmadik oszlop négyedik sorához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kép hozzáadása egy táblázatcellához**

Helyezze a bemeneti képet a munkakönyvtárba a példa futtatása előtt. A képet a [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) betölti, majd a prezentáció képgyűjteményéhez a [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) segítségével adja hozzá. Ezután a képet a `(0, 0)`‑as cella képtöltésére rendeli, amely a táblázat első cellája.

A [PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) a képet a cellába nyújtja, ez megváltoztathatja az arányait. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött képet egy `finally` blokkban szabadítja fel, miután hozzá lett adva a prezentációhoz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Beállíthatok különböző vonalvastagságot és stílust egy cella különböző oldalain?**

Igen. A [felső](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[alsó](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[bal](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[jobb](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) szegélyeknek külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérő lehet.

**Mi történik a képpel, ha a oszlop/sor méretét megváltoztatom miután képet állítottam be a cella háttérként?**

A viselkedés a [kitöltési mód](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (nyújtás/ismétlés) függvénye. Nyújtás esetén a kép alkalmazkodik az új cellához, ismétlés esetén a csempéket újraszámolják.

**Hozzárendelhetek hiperhivatkozást a cella teljes tartalmához?**

A [Hiperhivatkozások](/slides/hu/python-java/manage-hyperlinks/) a cella szövegkeretének (rész) szintjén vagy a teljes táblázat/alakzat szintjén állíthatók be. Gyakorlatban a hivatkozást egy részre vagy a cella teljes szövegére kell alkalmazni.

**Beállíthatok különböző betűtípusokat egyetlen cellában?**

Igen. A cella szövegkerete támogatja a [rész](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (run) elemeket független formázással – betűtípus, stílus, méret és szín.