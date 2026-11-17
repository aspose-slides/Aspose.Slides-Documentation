---
title: Táblázatcellák kezelése prezentációkban Python segítségével
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
description: "PowerPoint táblázatcellák kezelése Pythonban: összevont cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides for Python segítségével a .NET-en keresztül."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a táblázatcellák elérését és módosítását PowerPoint-prezentációkban. Ez a cikk bemutatja, hogyan azonosíthatók az összevont táblázatcellák, hogyan távolíthatók el a cellaszegélyek, hogyan kezelhető a cellaszámozás a cellák egyesítése vagy felosztása után, hogyan változtatható meg egy cella háttérszíne, és hogyan adható hozzá kép egy táblázatcellán belül. A példák azt mutatják be, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan kérhetünk le egy táblázatot egy diáról, hogyan frissíthetjük a cella formázását a cella tulajdonságain keresztül, és hogyan menthetjük el a módosított prezentációt PPTX-fájlként.

Az Aspose.Slides nulla alapú indexeket használ. A cikkben a koordináták `(oszlop, sor)` formátumban vannak megadva.

## **Az összevont táblázatcellák azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblázatként érheti el. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat táblázat. Ezután végigiterál az összes soron és oszlopon, és a [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) használatával azonosítja az összevont területek celláit. Minden egyezésnél kiírja a cella koordinátáit `row;column` sorrendben, valamint a [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), a [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), és a terület kezdő koordinátáit, a [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) és a [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) objektumot, és adjon egy táblázatot az első diájához a [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) segítségével. Az oszlopszélességek, sormagasságok és a táblázat pozíciója pontokban van megadva. A példa az összes négy cellaszegélyt a [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) értékre állítja, így láthatatlanná válik.

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
## **Átlós cellaszegélyek hozzáadása**

Használja a [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) függvényt, hogy vonalat rajzoljon a bal felső saroktól a jobb alsóig, és a [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) függvényt, hogy vonalat a bal alsó saroktól a jobb felsőig. Egy átló megjelölhet egy sarokfejlécet; mindkét átló X-et alakíthat, hogy a cellát nem alkalmazandóként jelölje.

Minden átló egy [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). A [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/)-ben állítsa a [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)-t a [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) értékre, és válasszon egy [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)-t. Állítsa be a vonal [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) értékét pontokban.

A példa három cellát hoz létre egy sorban: egy piros lefelé mutató átlót, egy kék felfelé mutató átlót, és mindkét átlót. A felső, alsó, bal és jobb cellaszegélyeket változatlanul hagyja.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Az átló formázási tulajdonság, nem cellamegosztás. Minden cella egyetlen [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) elemet tartalmaz; az átló mindkét oldalán lévő területek nem szerkeszthetők külön-külön.

A mentett táblázat, a Microsoft PowerPoint-ben megjelenítve:

![Három táblázatcella, melyek egy piros átlót mutatnak a bal felső saroktól a jobb alsóig, egy kék átlót a bal alsó saroktól a jobb felsőig, valamint mindkét átló egy X-et alkot.](diagonal-cell-borders.png)

*Balról jobbra: lefelé mutató átló (piros, 3 pt), felfelé mutató átló (kék, 5 pt), és mindkét átló.*

## **Táblázatcellák egyesítése**

Használja a [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) metódust, hogy egy téglalap alakú táblázatcella tartományt egy cellává egyesítsen. Adja meg a tartomány bal felső és jobb alsó sarok celláit. Az utolsó argumentum szabályozza, hogy az egyesítés magában foglalhat-e a megadott tartományon kívüli cellákat; a `False` az egyesítést a tartományon belül tartja.

A példa egy 4x4-es táblázatot hoz létre 70 pontos oszlopszélességekkel és sormagasságokkal, majd egyesíti a középső négy cellát a `(1, 1)`‑től `(2, 2)`‑ig tartó tartományban. Az eredményül kapott cella két oszlopot és két sort foglal el, míg a táblázat alaprácsa továbbra is négy oszlopból és négy sorból áll. Az egyesített cella tartalmához vagy formázásához használja a bal felső pozíciót: `table.rows[1][1]` ebben a példában. A többi pozíció a egyesített tartományban a táblázat rácsának részét képezi, ezért a tartományon kívüli cellák indexei nem változnak.

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

Az előző példában a cellák egyesítése megőrzi a táblázat rácsát. Egy cella felosztása új rácsoszlopot vezethet be, és megváltoztathatja a jobb oldali cellák oszlopindexeit. Az Aspose.Slides a PowerPoint táblázat‑rács modelljét követi.

Ez a példa egy 4x4-es táblázatot hoz létre 70 pontos oszlopszélességekkel és sormagasságokkal, és a [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) metódust hívja a `(1, 1)` cellán. A cella 70 pontos szélességének fele kerül átadásra két egyenlő szélességű cella létrehozásához.

A felosztás után a két rész a `table.rows[1][1]` és `table.rows[1][2]` segítségével érhető el. A táblázat rácsa most öt oszlopot tartalmaz: az eredetileg a 2‑es és 3‑as oszlopban lévő cellák a 3‑as és 4‑es oszlopba kerülnek. A sorindexek változatlanok maradnak. A felosztás utáni cella elérésénél használja ezeket a frissített oszlopindexeket.

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

[![Egy 70 pontos, nem egyesített cella felosztódik két 35 pontos cellára, ezzel ötödik rácsoszlopot adva és jobbra tolva az indexeket.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*A szélesség felosztása a (1, 1) cellát érinti, nulla alapú (oszlop, sor) indexekkel. A többi sor megőrzi azt a cellát, amely mindkét új oszloppozíciót lefedi.*

### **Összevont cellák felosztása sor- vagy oszlopszélesség szerint**

Az összevont sabloncellák adatkitöltésre való előkészítéséhez használja a [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) módszert a meglévő sorhatáron való felosztáshoz, vagy a [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) módszert egy oszlophatáron való felosztáshoz.

A `index` argument a felosztás felső részének sorait vagy a bal részének oszlopait számolja; a merged régióhoz viszonyítottan:

- Sor felosztás: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Oszlop felosztás: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

A példa azt feltételezi, hogy a prezentációban a első dián az első alakzat egy táblázat, ahol a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesítve vannak. Az alsó pozíciótól kezdve a [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) és a [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) használatával határozza meg az eredetet, és ellenőrzi mindkét átfedést. A `split_by_row_span` 1‑es indexszel elválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Vízszintes, két oszlopos egyesítéshez használja a `split_by_col_span` 1‑es indexét.

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

        # Szerezze meg a felosztás után keletkezett cellákat a táblázatból.
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

A táblázat rácsa és a környező cella indexek változatlanok maradnak. A keletkezett cellákat koordinátáik alapján kérdezze le; itt mindkettő 1‑es átfedéssel rendelkezik, és a [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) `False` értéket ad. Nagyobb területek egy felosztás után is részben egyesítve maradhatnak.

Az eredeti szöveg és annak formázása az felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. Töltse fel a cellákat a felosztás után, és állítson be minden szükséges szövegformázást explicit módon.

A mentett prezentáció különálló „Product A” és „Product B” cellákat tartalmaz, a sablon cellaformázásával. Részletekért lásd a [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) oldalt.

### **Cellának felosztása meghatározott magasságban**

A [split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) a felső rész magasságát pontokban veszi. A [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) a felső részben lévő meglévő rácssorok számát veszi. Egy 40 pontos cella függőleges középre helyezéséhez a jobb oszlopban, vonja le 40-et a cella tényleges magasságából, és ossza el a maradék helyet egyenlően felül és alul.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

Az első felosztás egy rácssort ad hozzá, a `table.rows[1][1]` alján 90 pontot hagyva. A második felosztás ezt a cellát egy 40 pontos középső cellára és egy 50 pontos alsó cellára bontja. A jobb oszlop három cellája most 50, 40 és 50 pont magas egymás alatt. A bal cella mind a három sort lefedi, eredeti 140 pontos magasságával.

![A bal cella a teljes táblázatmagasságot lefedi, a jobb oszlopban három cella van, középen egy középső cella.](split-by-height.png)

## **A táblázatcella háttérszínének megváltoztatása**

Ez a példa egy 150 pontos oszlopszélességű és 50 pontos sormagasságú táblázatot hoz létre. A `[fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)`‑t szilárdra, a `[solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)`‑t pedig pirosra állítja a `(2, 3)` cellában, amely a harmadik oszlopban és negyedik sorban található.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```
## **Kép hozzáadása egy táblázatcellához**

Helyezze az bemeneti képet a munkakönyvtárba a példa futtatása előtt. A képet a [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) segítségével tölti be, és a prezentáció képgyűjteményéhez adja a [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) metódussal. Ezután a képet a `(0, 0)` cella (a táblázat első cellája) képkitöltéséhez rendeli.

A [PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) a képet a cellába nyújtja, ami megváltoztathatja az arányait. Az oszlopszélességek és sormagasságok pontokban vannak megadva. A betöltött kép automatikusan felszabadul, amikor a `with` blokk befejeződik.

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

**Beállíthatok különböző vonalvastagságokat és stílusokat egy cella különböző oldalaihoz?**

Igen. A [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) szegélyeknek külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha a cella háttérképének beállítása után megváltoztatom az oszlop/sor méretét?**

A viselkedés a [kitöltési mód](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) beállítástól függ. Nyújtás esetén a kép a új cellához igazodik; csempézés esetén a csempéket újraszámítják.

**Hozzárendelhetek hiperhivatkozást a cella teljes tartalmához?**

[Hyperlinks](/slides/hu/python-net/manage-hyperlinks/) a cell szövegkeretén belüli szöveg (rész) szintjén vagy a teljes táblázat/forma szintjén kerül beállításra. Gyakorlatban a hivatkozást egy szövegrészhez vagy a cella teljes szövegéhez rendeli.

**Beállíthatok különböző betűtípusokat egy cellán belül?**

Igen. A cell szövegkerete támogatja a [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (futamok) független formázással — betűcsalád, stílus, méret és szín.