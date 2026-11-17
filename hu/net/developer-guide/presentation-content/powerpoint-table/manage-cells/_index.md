---
title: Táblázatcellák kezelése prezentációkban .NET‑ben
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/net/manage-cells/
keywords:
- táblázatcella
- cella egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "PowerPoint táblázatcellák kezelése C#‑ban: egyesített cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy hozzáférjünk és módosítsuk a táblázat celláit a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosíthatóak az egyesített táblázatcellák, hogyan távolítható el a cella szegélye, hogyan kezelhető a cellaszámozás egyesítés vagy felosztás után, hogyan változtatható meg egy cella háttérszíne, illetve hogyan adhatunk képet egy táblázatcella belsejébe. A példák bemutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan kaphatunk egy táblázatot egy diáról, hogyan frissíthető a cella formázása a cella tulajdonságain keresztül, és hogyan menthető a módosított prezentáció PPTX‑fájlként.

Az Aspose.Slides nulla‑alapú indexeket használ a táblázatcellák eléréséhez a `(oszlop, sor)` sorrendben.

## **Egyesített táblázatcella azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián első alakzatát táblázatként éri el. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat táblázat. Ezután végigiterál az összes soron és oszlopon, és a [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) segítségével azonosítja az egyesített területek celláit. Minden egyezésnél kiírja a cella koordinátáit `sor;oszlop` sorrendben, a [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), valamint a terület kezdő koordinátáit, a [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) és a [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) értékeket.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Táblázatcella szegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) objektumot, és adjon egy táblázatot az első diájához a [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) segítségével. Az oszlopszélességeket, sormagasságokat és a táblázat pozícióját pontban adjuk meg. A példa az összes négy cellaszegélyt a [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) értékre állítja, ezáltal láthatatlanná téve őket.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Átlós cellaszegélyek hozzáadása**

Használja a [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) metódust a bal felső saroktól a jobb alsó sarokig tartó vonal rajzolásához, és a [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) metódust a bal alsó saroktól a jobb felső sarokig tartó vonalhoz. Egy átló jelölhet egy sarokfejlécet; mindkét átló X‑et alkothat, amely megjelöli, hogy a cella nem alkalmazandó.

Minden átló egy [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). A [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/)-ban állítsa a [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) értékét [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/)-ra, és válasszon egy [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) értéket. A vonal [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) értékét állítsa meg pontban.

A példa egy sorban három cellát hoz létre: egy piros lefelé mutató átlót, egy kék felfelé mutató átlót és mindkét átlót. A felső, alsó, bal és jobb cellaszegélyek változatlanok maradnak.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Az átló egy formázási tulajdonság, nem cellafelosztás. Minden cella egyetlen [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) objektumot tartalmaz; az átló mindkét oldalán lévő területek nem szerkeszthetők külön-külön.

A mentett táblázat, a Microsoft PowerPoint‑ben renderelve:
![Három táblázatcella, amely egy piros átlót mutat a bal felsőtől a jobb alsóig, egy kék átlót a bal alsótól a jobb felsőig, és mindkét átló X-et alkot.](diagonal-cell-borders.png)

*Balról jobbra: lefelé mutató átló (piros, 3 pt), felfelé mutató átló (kék, 5 pt), és mindkét átló.*

## **Táblázatcellák egyesítése**

Használja a [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) metódust, hogy egy téglalap alakú táblázatcella‑tartományt egyetlen cellává egyesítsen. Adja meg a tartomány bal felső és jobb alsó sarkának celláit. Az utolsó argumentum szabályozza, hogy az egyesítés tartalmazhat‑e a megadott tartományon kívüli cellákat; a `false` érték az egyesítést a tartományon belül hagyja.

A példa egy 4‑by‑4 táblázatot hoz létre 70‑pontos oszlopokkal és sorokkal, majd egyesíti a négy középső cellát a `(1, 1)`‑től a `(2, 2)`‑ig tartó tartományban. Az eredményül kapott cella két oszlopot és két sort fed le, míg a táblázat alaprácsa négy oszlopot és négy sort tartalmaz továbbra is. Az egyesített cella tartalmához vagy formázásához a bal felső pozíciót használja: `table[1, 1]` ebben a példában. A többi pozíció az egyesített tartományban a táblázat rácsának része marad, így a tartományn kívüli cellák indexei nem változnak.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Táblázatcellák felosztása**

Az előző példában a cellák egyesítése megőrzi a táblázat rácsát. Egy cella felosztása új rácsoszlopot hozhat létre, és módosíthatja a jobb oldali cellák oszlopszámait. Az Aspose.Slides a PowerPoint táblázatrács modelljét követi.

Ez a példa egy 4‑by‑4 táblázatot hoz létre 70‑pontos oszlopokkal és sorokkal, és a [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) metódust hívja a `(1, 1)` cellán. A cella 70‑pontos szélességének felét használja két egyenlő szélességű cella létrehozásához.

A felosztás után a két felét a `table[1, 1]` és a `table[2, 1]` hivatkozza. A táblázat rácsa most öt oszlopot tartalmaz: az eredetileg a 2. és 3. oszlopban lévő cellák a 3. és 4. oszlopba kerülnek, rendre. A sorindexek változatlanok maradnak. A felosztás után a cellák elérésekor ezeket a frissített oszlopszámokat használja.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Egyesített cellák felosztása sor‑ vagy oszlopszakasz szerint**

Az egyesített sabloncella‑k adatokkal való feltöltésére való előkészítéshez használja a [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) metódust egy meglévő sorhatár mentén történő felosztáshoz, vagy a [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) metódust egy oszlophatár mentén történő felosztáshoz.

Az `index` argumentum a felosztás felső részében lévő sorokat vagy a bal részben lévő oszlopokat számolja; a megadott érték a egyesített tartományhoz viszonyítva:
- Row split: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)
- Column split: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)

A példa feltételezi, hogy a prezentáció első diáján első alakzata egy táblázat, amelyben a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesítve vannak. Az alsó pozíciótól kiindulva a [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) és [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) segítségével meghatározza a kiindulási pontot, és ellenőrzi mindkét kiterjedést. A `SplitByRowSpan(1)` ezután szétválasztja a 2. és 3. sort a terméknevekhez. Vízszintes, kétoszlopos egyesítés esetén a `SplitByColSpan(1)` használható.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // A felosztás után a táblázatból származó cellák lekérése.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

A táblázat rácsa és a környező cella indexek változatlanok maradnak. A kapott cellákat a koordinátáik alapján kérdezheti le; itt mindkettő 1‑es kiterjedéssel rendelkezik, és a [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) `False` értéket ad vissza. Nagyobb területek egy felosztás után is részben egyesítve maradhatnak.

Az eredeti szöveg és formázása az felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. A felosztás után töltse fel a cellákat, és állítsa be a szükséges szövegformázást kifejezetten.

A mentett prezentáció külön „Product A” és „Product B” cellákat tartalmaz, a sablon cellaformázása megmarad. A részletekért tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) dokumentációt.

<!-- visual-explanation:manage-cells:start -->
[![Az 1. oszlopban, 2. és 3. sorokban lévő egyesített cella felosztódik Product A és Product B‑re ugyanazokkal a rácsindexekkel.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*​A sor‑kiterjedés felosztása a meglévő határt használja. A Product A és a Product B a (1, 2) és (1, 3) pozíciókat foglalja el.*
<!-- visual-explanation:manage-cells:end -->

### **Cella felosztása megadott magasságban**

A [SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) a felső rész magasságát pontban veszi. A [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) a felső részben lévő meglévő rácssorok számát veszi. Egy 40‑pontos cella középre helyezéséhez a jobb oszlopban, vonja ki 40‑et a cella tényleges magasságából, és ossza el a maradék helyet egyenlően felül és alul.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

Az első felosztás egy rácssort ad hozzá, a `[1, 1]` alatti 90 pont marad. A második felosztás ezt a cellát célozza, és egy új sorral bővíti alatta. A jobb oszlop most `[1, 0]` 50 pont (`margin`), `[1, 1]` 40 pont, és `[1, 2]` 50 pont (`margin`) értékekkel rendelkezik. A bal cella a három sorra kiterjed eredeti 140 pont magasságával.

![A bal cella a teljes táblázatmagasságot lefedi, három középen elhelyezkedő cella mellett.](split-by-height.png)

## **A táblázatcella háttérszínének megváltoztatása**

Ez a példa egy 150‑pontos oszloppal és 50‑pontos sorral rendelkező táblázatot hoz létre. A `[FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)`‑t szilárdra, a `[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)`‑t pedig pirosra állítja a `(2, 3)` cellában, amely a harmadik oszlopban és a negyedik sorban található.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Kép hozzáadása a táblázatcella belsejébe**

Helyezze az bemeneti képet a munkakönyvtárba a példa futtatása előtt. A képet a [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) segítségével tölti be, és a prezentáció képgyűjteményéhez adja a [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) metódussal. Ezután a képet a `(0, 0)` cella (a táblázat első cellája) képpel kitöltéshez rendeli.

A [PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) nyújtja a képet, hogy kitöltse a cellát, ami megváltoztathatja az arányát. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött kép automatikusan felszabadul a using deklaráció által.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Beállíthatok különböző vonalvastagságokat és stílusokat a cella egyes oldalaira?**

Igen. A [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) szegélyeknek külön tulajdonságaik vannak, így az egyes oldalak vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha az oszlop-/sorméretet megváltoztatom, miután képet állítottam be a cella háttérként?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) beállítástól függ (stretch/tile). Nyújtás esetén a kép alkalmazkodik az új cellához; csempézés esetén a csempéket újraszámítják.

**Hozzá tudok-e rendelnél hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/net/manage-hyperlinks/) a cell szövegkeretének (portion) szintjén vagy a teljes táblázat/alakzat szintjén állítható be. Gyakorlatban a hivatkozást egy részre vagy a cella összes szövegére rendeli.

**Beállíthatok-e különböző betűtípusokat egyetlen cellában?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (futás) önálló formázással—betűcsalád, stílus, méret és szín.