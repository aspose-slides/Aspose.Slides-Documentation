---
title: Táblázatcellák kezelése prezentációkban .NET-ben
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/net/manage-cells/
keywords:
- táblázatcellák
- cellák egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "PowerPoint táblázatcellák kezelése C#-ban: egyesített cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a PowerPoint‑prezentációk táblázatcelláinak elérését és módosítását. Ez a cikk bemutatja, hogyan lehet azonosítani az egyesített táblázatcellákat, eltávolítani a cellaszegélyeket, a cellaszámozással dolgozni az egyesítés vagy felosztás után, megváltoztatni egy cella háttérszínét, és képet hozzáadni egy táblázatcellához. A példák azt mutatják be, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezhetünk táblát egy diáról, hogyan frissíthető a cella formázása a cella tulajdonságain keresztül, és hogyan menthetjük el a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nulla‑alapú indexeket használ a táblázatcellák eléréséhez a `(column, row)` sorrendben.

## **Egyesített táblázatcella azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblaként érli el. Feltételezi, hogy a dia és az alakzat létezik, valamint hogy az alakzat táblázat. Ezután végigiterál minden soron és oszlopon, és a [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) metódust használja az egyesített régiók celláinak azonosítására. Minden egyezésnél kiírja a cella koordinátáit `row;column` sorrendben, a [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), a [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), valamint a régió kiindulási koordinátáit, a [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) és a [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) értékeket.

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

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) objektumot, és adjon egy táblát az első diájához a [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) metódussal. Az oszlopszélességek, sormagasságok és a táblázat pozíciója pontokban van megadva. A példa az összes négy cellaszegélyt a [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) értékre állítja, így láthatatlanná téve őket.

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

## **Táblázatcellák egyesítése**

A [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) metódus segítségével egy téglalap alakú cellatartományt egy cellává egyesíthetünk. Meg kell adni a tartomány bal‑felső és jobb‑alsó sarkában lévő cellákat. Az utolsó argumentum szabályozza, hogy az egyesítés magában foglalhat‑e a megadott tartományon kívüli cellákat; a `false` érték az egyesítést a tartományon belül tartja.

A példa egy 4 × 4‑es táblát hoz létre 70‑pontos oszlopokkal és sorokkal, majd egyesíti a középső négy cellát a `(1, 1)`‑től `(2, 2)`‑ig terjedő tartományban. Az eredményül kapott cella két oszlopot és két sort foglal el, míg a táblázat alapszíma továbbra is négy oszlopból és négy sorból áll. Az egyesített cella tartalmának vagy formázásának eléréséhez használja a bal‑felső pozícióját: `table[1, 1]` ebben a példában. A többi pozíció a egyesített tartományban a táblázat rácsának része marad, ezért a tartományon kívüli cellák indexei nem változnak.

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

Az előző példában a cellák egyesítése megőrzi a táblázat rácsát. Egy cella felosztása új rácsoszlopot hozhat létre, és megváltoztathatja a jobbra lévő cellák oszlopszámait. Az Aspose.Slides a PowerPoint táblarács‑modelljét követi.

Ez a példa egy 4 × 4‑es táblát hoz létre 70‑pontos oszlopokkal és sorokkal, és a `[SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/)` metódust hívja a `(1, 1)` cellán. A cella 70‑pontos szélességének felét adja át, hogy két egyenlő szélességű cellát hozzon létre.

A felosztás után a két felét a `table[1, 1]` és a `table[2, 1]` indexekkel érhetjük el. A táblázat rácsa most már öt oszlopot tartalmaz: az eredetileg a 2. és 3. oszlopban lévő cellák a 3. és 4. oszlopba kerülnek. A sor‑indexek változatlanok maradnak. A felosztás után a cellák elérésekor az új oszlopszámokat kell használni.

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

### **Egyesített cellák felosztása sor- vagy oszlopkiterjedés szerint**

Az egyesített sabloncellák adatkitöltés előkészítéséhez használja a [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) metódust egy meglévő sortávolság mentén való felosztáshoz, vagy a [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) metódust oszlopkiterjedés mentén való felosztáshoz.

Az `index` argumentum a felosztás felső részének sorait vagy bal részének oszlopait számlálja; a megadott érték a egyesített régióhoz viszonyítva van:

- Sor‑felesztés: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Oszlop‑felesztés: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

A példa azt feltételezi, hogy a prezentáció első diájának első alakzata egy táblázat, amelyben a `(1, 2)` és a `(1, 3)` cellák függőlegesen egyesítve vannak. Az alsó pozíciótól kiindulva a [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) és a [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) segítségével határozza meg a kiindulópontot, és ellenőrzi mindkét kiterjedést. A `SplitByRowSpan(1)` ezután szétválasztja a 2. és 3. sorokat a terméknevekhez. Vízszintesen két oszlopos egyesítéshez helyette a `SplitByColSpan(1)` használható.

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

    // A felosztás után a táblában keletkezett cellákat lekérdezi.
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

A táblázat rácsa és a környező cellaindexek változatlanok maradnak. Az eredményül kapott cellákat a koordinátáik alapján kérhetjük le; ebben az esetben mindkettő 1‑es kiterjedéssel rendelkezik, és az [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) `False` értéket ad. Nagyobb területek egy felosztás után is maradhatnak részben egyesítve.

Az eredeti szöveg és formázása az felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. A felosztás után töltse fel a cellákat, és szükség esetén állítsa be a szövegformázást explicit módon.

A mentett prezentáció külön “Product A” és “Product B” cellákat tartalmaz, a sablon cellaformázása megtartva. További részletekért tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) dokumentációt.

## **A táblázatcella háttérszínének módosítása**

Ez a példa egy táblát hoz létre 150‑pontos oszlopokkal és 50‑pontos sorokkal. A `[FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)` értékét szilárdra, a `[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)` értékét pedig pirosra állítja a `(2, 3)` cellánál, amely a harmadik oszlop és a negyedik sor.

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

## **Kép hozzáadása táblázatcella belsejébe**

Helyezze az input képet a munkakönyvtárba, mielőtt futtatná ezt a példát. A kép betöltésére a [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) metódust használja, majd a [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) metódussal hozzáadja a prezentáció képgyűjteményéhez. Ezután a képet a `(0, 0)` cella képkitöltéséhez rendeli, amely a táblázat első cellája.

A [PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) a képet a cellához nyújtja, ami megváltoztathatja az arányát. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött kép automatikusan felszabadul a `using` deklaráció miatt.

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

**Beállíthatok‑e különböző vonalvastagságot és stílust a cella különböző oldalain?**

Igen. A [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) szegélyeknek külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha a képlet hátteres beállítása után módosítom az oszlop/sor méretét?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile) függvénye. Nyújtás esetén a kép a új cellához igazodik; csempe esetén a csempéket újraszámítják.

**Köthetek‑e hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/net/manage-hyperlinks/) a cella szövegkeretén (részlet) vagy a teljes táblán/alakzaton belül állítható be. Gyakorlatilag a linket egy részlethez vagy a cella teljes szövegéhez rendeli.

**Beállíthatok‑e különböző betűtípusokat egyetlen cellában?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (futtatás) önálló formázással – betűcsalád, stílus, méret és szín.