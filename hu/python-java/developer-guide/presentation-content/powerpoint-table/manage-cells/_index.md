---
title: Táblázatcellák kezelése prezentációkban Python nyelven
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/python-java/manage-cells/
keywords:
- táblázatcella
- cellák egyesítése
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

Az Aspose.Slides lehetővé teszi, hogy hozzáférj a PowerPoint‑prezentációk táblázatcelláihoz, és módosítsd őket. Ez a cikk bemutatja, hogyan azonosíts összevont táblázatcellákat, hogyan távolíthatod el a cella szegélyeit, hogyan dolgozhatsz a cellaszámozással egyesítés vagy felosztás után, hogyan változtathatod meg egy cella háttérszínét, és hogyan adhatunk képet egy táblázatcellához. A példák megmutatják, hogyan hozhatsz létre vagy nyithatsz meg egy prezentációt, hogyan szerezheted meg a táblázatot egy diáról, hogyan frissítheted a cella formázását a cella tulajdonságain keresztül, és hogyan mentheted a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nulla‑alapú indexeket használ a táblázatcellák eléréséhez a `(oszlop, sor)` sorrendben.

## **Összevont táblázatcellák azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián lévő első alakzatot táblázatként éri el. Feltételezi, hogy a dia és az alakzat létezik, valamint hogy az alakzat táblázat. Ezután végigiterál az összes soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) metódust használja az összevont régiók celláinak azonosítására. Minden egyezés esetén kiírja a cella koordinátáit `sor;oszlop` sorrendben, a [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), a [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) értékeket, valamint a régió kezdő koordinátáit, a [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) és a [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) segítségével.

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

## **Táblázatcellák szegélyeinek eltávolítása**

Hozz létre egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) objektumot, és adj hozzá egy táblázatot az első diájához a [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) metódussal. Az oszlopszélességek, sormagasságok és a táblázat pozíciója pontokban van megadva. A példa mind a négy cella szegélyét a [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) értékre állítja, így láthatatlanná téve őket.

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

## **Átlós cellaszegélyek hozzáadása**

A [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) metódussal a bal felső saroktól a jobb alsó sarokig, a [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) metódussal pedig a bal alsó saroktól a jobb felső sarokig rajzolhatsz vonalat. Egy átló jelölhet egy sarokfejlécet. Mindkét átló X‑et alkothat, ami azt jelzi, hogy a cella nem alkalmazható.

Minden átló egy [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/) objektum. Az ő [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) metódusában a [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) segítségével válaszd a [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) opciót, és válassz színt a [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) segítségével. A vonal vastagságát pontokban a [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) metódussal állíthatod be.

A példa egy sorban három cellát hoz létre: egy piros lefelé irányuló átlót, egy kék felfelé irányuló átlót és mindkét átlót. A felső, alsó, bal és jobb cellaszegélyeket változatlanul hagyja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az átló egy formázási tulajdonság, nem cellafelosztás. Minden cella egyetlen szövegkeretet tartalmaz, amelyet a [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) metódussal érhetsz el. Az átló mindkét oldalán lévő területeket nem lehet külön‑külön szerkeszteni.

A mentett táblázat, a Microsoft PowerPoint‑ban megjelenítve:

![Három táblázatcella, amelyek piros átlót mutatnak a bal felső saroktól a jobb alsó sarokig, kék átlót a bal alsó saroktól a jobb felső sarokig, és mindkét átló X-et alkot.](diagonal-cell-borders.png)

*Balról jobbra: lefelé irányú átló (piros, 3 pt), felfelé irányú átló (kék, 5 pt), és mindkét átló.*

## **Táblázatcellák egyesítése**

Használd a [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) metódust, hogy egy téglalap alakú táblázatcellákat egy cellává egyesítsd. Add meg a tartomány bal felső és jobb alsó sarkában lévő cellákat. Az utolsó argumentum határozza meg, hogy az egyesítés tartalmazhat‑e a megadott tartományon kívüli cellákat; a `False` érték az egyesítést a tartományon belül tartja.

A példa egy 4×4‑es táblázatot hoz létre 70‑pontos oszlopokkal és sorokkal, majd egyesíti a négy középső cellát a `(1, 1)`‑től `(2, 2)`‑ig terjedő tartományban. Az eredményül kapott cella két oszlopon és két soron átnyúlik, míg a táblázat alaprendszere négy oszlopot és négy sort tartalmaz továbbra is. Az egyesített cella tartalmának vagy formázásának eléréséhez használd a bal‑felső pozíciót: `table.get_Item(1, 1)` ebben a példában. A többi pozíció az egyesített tartományban továbbra is a táblázatrács része, ezért a tartományon kívüli cellák indexei nem változnak.

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

A korábbi példában a cellák összevonása megőrzi a táblázat rácsát. Egy cella felosztása új rácsoszlopot hozhat létre, és megváltoztathatja a jobb oldali cellák oszlopindexeit. Az Aspose.Slides a PowerPoint táblázatrács modelljét követi.

A példa egy 4×4‑es táblázatot hoz létre 70‑pontos oszlopokkal és sorokkal, majd meghívja a [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) metódust a `(1, 1)` cellán. A cella 70‑pontos szélességének felét átadja, hogy két egyenlő szélességű cellát hozzon létre.

A felosztás után a két felét a `table.get_Item(1, 1)` és a `table.get_Item(2, 1)` segítségével érheted el. A táblázatrács most öt oszlopot tartalmaz: az eredetileg a 2‑ és 3‑as oszlopban lévő cellák a 3‑as és 4‑es oszlopba kerülnek. A sorindexek változatlanok maradnak. A felosztás utáni cellák elérésénél ezeket a frissített oszlopindexeket használd.

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

<!-- visual-explanation:manage-cells:start -->
[![Egy nem összevont 70‑pontos cella két 35‑pontos cellára oszlik, egy ötödik rácsoszlopot hozzáadva, és a jobb oldali indexeket eltolva.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*~A szélesség felosztása a (1, 1) cellát érinti, nulla‑alapú (oszlop, sor) indexekkel. A többi sor egy cellát tart meg, amely mindkét új oszloppozíciót átnyúlik.~*
<!-- visual-explanation:manage-cells:end -->

### **Összevont cellák felosztása sor- vagy oszlopszélesség szerint**

A összevont sabloncellák adatkitöltésre való előkészítéséhez használd a [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) metódust egy meglévő sorhatár mentén történő felosztáshoz, vagy a [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) metódust oszlophatár mentén.

Az `index` argumentum a felosztás felső részében lévő sorok vagy a bal részében lévő oszlopok számát adja meg; a összevont régióhoz viszonylagos.

- Sor felosztás: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Oszlop felosztás: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

A példa azt feltételezi, hogy a prezentáció első diáján az első alakzat egy táblázat, amelyben a `(1, 2)` és `(1, 3)` cellák függőlegesen össze vannak vonva. Az alsó pozícióból kiindulva a [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) és [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) metódusokkal határozza meg az eredetet, és ellenőrzi mindkét átfedést. A `splitByRowSpan(1)` ezután szétválasztja a 2‑ és 3‑as sorokat a terméknevekhez. Vízszintes, két oszlopos összevonáshoz használd a `splitByColSpan(1)`‑et helyette.

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

        # A felosztás után a táblázatban keletkezett cellákat lekérdezi.
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

A táblázatrács és a környező cella indexek változatlanok maradnak. A kapott cellákat a koordinátáik alapján érheted el; itt mindkettő 1‑es átfedéssel rendelkezik, és a [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) `False`‑t ad vissza. Nagyobb régiók egy felosztás után is részben összevonva maradhatnak.

Az eredeti szöveg és formázása az felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, mint például a kitöltést, szegélyeket és margókat. A felosztás után töltsd fel a cellákat, és állítsd be a szükséges szövegformázást explicit módon.

A mentett prezentáció külön "Product A" és "Product B" cellákat tartalmaz, a sablon cellaformázását megtartva. A részletekért lásd a [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) oldalt.

### **Cellának felosztása meghatározott magasságban**

A [splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) metódus a felső rész magasságát veszi pontban. A [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) a felső részben lévő meglévő rácssorok számát veszi. Egy 40‑pontos cella középre helyezéséhez a jobb oszlopban vonj le 40‑et a cella tényleges magasságából, és oszd el egyenlően a maradék helyet felül és alul.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az első felosztás egy rácssort ad hozzá, és a `(1, 1)` cellában 90 pontot hagy alul. A második felosztás a cellát egy 40‑pontos középső cellára és egy 50‑pontos alsó cellára osztja. A jobb oszlop most három cellát tartalmaz, magasságuk felülről lefelé 50, 40 és 50 pont. A bal cella mindhárom sort átnyúlik, és megtartja az eredeti 140‑pontos magasságát.

![A bal cella a teljes táblázatmagasságot lefedi, mellette három cella van, középen a 'Middle' felirattal.](split-by-height.png)

## **A táblázatcella háttérszínének módosítása**

A példa egy 150‑pontos oszlopszélességű és 50‑pontos sormagasságú táblázatot hoz létre. A [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) segítségével szilárd kitöltést választ, majd a [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) által visszaadott színt pirosra állítja a `(2, 3)` cellában, a harmadik oszlopban és negyedik sorban.

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

## **Kép hozzáadása táblázatcella belsejébe**

Tedd a bemeneti képet a munkakönyvtárba a példa futtatása előtt. A [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) segítségével betölti a képet, és a prezentáció képkollekciójába adja a [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) metódussal. Ezután a képet a `(0, 0)` cella (a táblázat első cellája) képpel kitöltésére rendeli.

[A PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) a képet a cellához nyújtja, ami megváltoztathatja az arányát. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött képet a `finally` blokkban felszabadítják, miután hozzá lett adva a prezentációhoz.

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

**Beállíthatok különböző vonalvastagságot és stílust a cella egyes oldalaira?**

Igen. A [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) szegélyek külön tulajdonságokkal rendelkeznek, így minden oldal vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha a cella háttérképeként beállítás után megváltoztatom az oszlop/sor méretét?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile) függvénye. Nyújtás esetén a kép a új cellához igazodik, csempézés esetén a csempéket újraszámolják.

**Rendelhetek hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/python-java/manage-hyperlinks/) a cell szövegkeretének szövegréssze (portion) szintjén vagy a teljes tábla/alakzat szintjén állítható be. Gyakorlatban a hivatkozást egy részlethez vagy a cella teljes szövegéhez rendelik.

**Beállíthatok különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (futás) független formázással – betűcsalád, stílus, méret és szín.