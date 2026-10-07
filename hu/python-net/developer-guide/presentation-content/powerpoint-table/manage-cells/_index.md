---
title: Táblázatcellák kezelése prezentációkban Python-nal
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/python-net/manage-cells/
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
description: "PowerPoint táblázatcellák kezelése Pythonban: egyesített cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides for Python segítségével .NET-en keresztül."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy táblázatcellákat érjen el és módosítson PowerPoint prezentációkban. Ez a cikk bemutatja, hogyan lehet azonosítani az egyesített táblázatcellákat, eltávolítani a cellaszegélyeket, a cellaszámozással dolgozni az egyesítés vagy felosztás után, módosítani egy cella háttérszínét, és képet hozzáadni egy táblázatcellához. A példák megmutatják, hogyan hozhat létre vagy nyithat meg egy prezentációt, hogyan szerezhet be egy táblázatot egy diáról, hogyan frissítheti a cella formázását a cella tulajdonságain keresztül, és hogyan mentheti a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nulla alapú indexeket használ. A koordinátákat ebben a cikkben `(oszlop, sor)` formában írják.

## **Egyesített táblázatcella azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblázatként érheti el. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat táblázat. Ezután végigiterál az összes soron és oszlopon, és a [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) segítségével azonosítja az egyesített területek celláit. Minden egyezésnél kiírja a cella koordinátáit `row;column` sorrendben, a [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), a [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), valamint a terület kezdő koordinátáit, a [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) és a [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) értékeket.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Táblázatcella szegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) objektumot, és adjon egy táblázatot az első diájához a [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) segítségével. Az oszlopszélességeket, sormagasságokat és a táblázat pozícióját pontban adják meg. A példa az összes négy cellaszegélyt a [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) értékre állítja, így láthatatlanok.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázatcellák egyesítése**

A [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) segítségével egy téglalap alakú táblázatcella tartományt egyetlen cellába egyesíthetünk. Adja meg a tartomány bal felső és jobb alsó sarkának celláit. Az utolsó argumentum szabályozza, hogy az egyesítés tartalmazhat-e a megadott tartományon kívüli cellákat; a `False` érték az egyesítést a tartományon belül tartja.

A példa egy 4×4-es táblázatot hoz létre 70 pontos oszlopokkal és sorokkal, majd egyesíti a négy középső cellát a `(1, 1)` és `(2, 2)` közötti tartományban. Az eredményül kapott cella két oszlopot és két sort fed le, míg a táblázat alaprészének rácsa továbbra is négy oszlopból és négy sorból áll. Az egyesített cella tartalmához vagy formázásához a bal felső pozíciót kell használni: ebben a példában `table.rows[1][1]`. A többi pozíció a egyesített tartományban továbbra is a táblázat rácsának része, ezért a tartományon kívüli cellák indexei nem változnak.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázatcellák felosztása**

A korábbi példában a cellák egyesítése megőrzi a táblázat rácsát. Egy cella felosztása új rácsolkapot hozhat létre, és megváltoztathatja a jobb oldali cellák oszlopindexeit. Az Aspose.Slides a PowerPoint táblázatrács modelljét követi.

Ez a példa egy 4×4-es táblázatot hoz létre 70 pontos oszlopokkal és sorokkal, és a `(1, 1)` cellára meghívja a [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) metódust. A cella 70 pontos szélességének fele kerül átadásra, hogy két egyenlő szélességű cella jöjjön létre.

A felosztás után a két felét a `table.rows[1][1]` és a `table.rows[1][2]` hivatkozza. A táblázat rácsa most már öt oszlopot tartalmaz: az eredetileg a 2. és 3. oszlopban lévő cellák a 3. és 4. oszlopba kerülnek. A sorindexek változatlanok maradnak. Ezeket a frissített oszlopindexeket használja a cellák eléréséhez a felosztás után.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Egyesített cellák felosztása sor vagy oszlop kiterjedés szerint**

Az egyesített sabloncellák adatkitöltésre való előkészítéséhez használja a [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) metódust egy meglévő sorhatáron történő felosztáshoz, vagy a [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) metódust egy oszlophatáron történő felosztáshoz.

Az `index` argumentum a felosztás felső részének sorait vagy bal részének oszlopait számolja; a megadott érték az egyesített területhez viszonyítva értendő:

- Sor felosztás: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Oszlop felosztás: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

A példa olyan prezentációt feltételez, amelyen az első dián az első alakzat egy táblázat, és a `(1, 2)` valamint a `(1, 3)` cellák függőlegesen egyesítve vannak. Az alsó pozícióból kiindulva a [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) és a [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) segítségével határozza meg a kiinduló pontot, és ellenőrzi mindkét kiterjedést. A `split_by_row_span` 1-es indexszel szétválasztja a 2. és 3. sort a terméknevekhez. Vízszintesen két oszlop egyesítése esetén helyette a `split_by_col_span` 1-es indexszel használható.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Szerezze meg a felosztás után a táblázatból az eredményül kapott cellákat.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

A táblázat rácsa és a környező cellaindexek változatlanok maradnak. A kapott cellákat a koordinátáik alapján kérdezheti le; itt mindkettő 1-es kiterjedéssel rendelkezik, és a [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) `False` értéket ad vissza. Nagyobb területek egy felosztás után is részben egyesítve maradhatnak.

Az eredeti szöveg és formázás az felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. Töltse fel a cellákat a felosztás után, és állítsa be a szükséges szövegformázást kifeexplicit módon.

A mentett prezentáció külön "Product A" és "Product B" cellákat tartalmaz, a sablon cellaformázása megmarad. A részletekért tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) oldalt.

## **A táblázatcella háttérszín módosítása**

Ez a példa 150 pont széles oszlopokkal és 50 pont magas sorokkal rendelkező táblázatot hoz létre. A `[fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)` értékét szilárdra, a `[solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)` értékét pedig pirosra állítja a `(2, 3)` cellához, amely a harmadik oszlopban és a negyedik sorban található.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Kép hozzáadása egy táblázatcella belsejébe**

Először helyezze a bemeneti képet a munkakönyvtárba, mielőtt futtatná ezt a példát. A képet a [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) tölti be, majd a [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) segítségével a prezentáció képgyűjteményéhez adja hozzá. Ezután a képet a `(0, 0)` cella (a táblázat első cellája) képpel kitöltéséhez rendeli.

A [PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) a képet a cella kitöltésére nyújtja, ami megváltoztathatja az oldalarányát. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött kép automatikusan felszabadul, amikor a `with` blokk véget ér.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Beállíthatok különböző vonalvastagságokat és stílusokat a cella egyes oldalain?**

Igen. A [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) szegélyek különálló tulajdonságokkal rendelkeznek, így az egyes oldalak vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha a oszlop/sor méretét módosítom a kép cella háttérként való beállítása után?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) beállításától függ. Nyújtás esetén a kép az új cellához igazodik; csempézés esetén a csempéket újraszámítják.

**Hozzá tudok-e rendelni hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/python-net/manage-hyperlinks/) a cella szövegkeretének (rész) szintjén vagy a teljes táblázat/alakzat szintjén állítható be. Gyakorlatban a hivatkozást egy részhez vagy a cella egész szövegéhez rendeli.

**Beállíthatok-e különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (futamok) önálló formázását – betűcsalád, stílus, méret és szín.