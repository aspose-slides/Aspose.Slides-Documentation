---
title: "Táblázatcellák kezelése prezentációkban C++-ban"
linktitle: "Cellák kezelése"
type: docs
weight: 30
url: /hu/cpp/manage-cells/
keywords:
- "táblázatcella"
- "cellák összevonása"
- "szegély eltávolítása"
- "cella felosztása"
- "kép a cellában"
- "háttérszín"
- "PowerPoint"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "PowerPoint táblázatcellák kezelése C++-ban: egyesített cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a táblázatcellák elérését és módosítását PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosíthatók az egyesített táblázatcellák, hogyan távolíthatók el a cellaszegélyek, hogyan kezelhető a cellaszámozás egyesítés vagy felosztás után, hogyan változtatható meg egy cella háttérszíne, valamint hogyan lehet képet hozzáadni egy táblázatcellához. A példák bemutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezhetünk egy táblázatot egy diáról, hogyan frissíthető a cella formázása a cella‑tulajdonságokon keresztül, és hogyan menthetjük a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nulla‑alapú indexeket használ a táblázatcellák eléréséhez a `(column, row)` sorrendben.

## **Egyesített táblázatcella azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblázatként érheti el. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat táblázat. Ezután végigiterál az összes soron és oszlopon, és a [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) segítségével azonosítja az egyesített régiók celláit. Minden egyezésnél kiírja a cella koordinátáit `row;column` sorrendben, a [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), a [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/) és a régió kezdő koordinátáit a [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) és a [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) segítségével.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Táblázatcella szegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) objektumot, és adjon hozzá egy táblázatot az első diájához a [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) segítségével. Az oszlopszélességek, sormagasságok és a táblázat pozíciója pontban van megadva. A példa mind a négy cellaszegélyt a [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) értékre állítja, így láthatatlanná téve őket.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Átlós cellaszegélyek hozzáadása**

Használja a [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) metódust egy vonal húzásához a bal felső sarokból a jobb alsó sarokba, és a [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) metódust egy vonal húzásához az alsó bal sarokból a jobb felső sarokba. Egy átló jelölheti a sarokfejlécet; mindkét átló X‑et képezhet, ezzel a cellát „nem alkalmazandóként” jelölve.

Az egyes átlók egy [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/) objektumok. A [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) segítségével érheti el a kitöltést, a [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) hívásával a [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) típust válassza, és a [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/) segítségével adjon meg egy színt. A vonalvastagságot a [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) pontban állíthatja be.

A példa egy sorban három cellát hoz létre: egy piros lefelé mutató átlót, egy kék felfelé mutató átlót és mindkét átlót. A felső, alsó, bal és jobb cellaszegélyek változatlanok maradnak.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

Egy átló formázási tulajdonság, nem cellafelosztás. Minden cella egyetlen szövegkeretet tartalmaz, amelyet a [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) segítségével érhet el; az átló mindkét oldalán lévő régiók nem szerkeszthetők függetlenül.

A mentett táblázat, amelyet a Microsoft PowerPoint jelenít meg:

![Három táblázatcella, amely egy piros átlót jelenít meg a bal felső sarokból a jobb alsó sarokig, egy kék átlót az alsó bal sarokból a jobb felső sarokig, valamint mindkét átlót, amelyek X-et alkotnak.](diagonal-cell-borders.png)

*Balról jobbra: lefelé mutató átló (piros, 3 pt), felfelé mutató átló (kék, 5 pt), és mindkét átló.*

## **Táblázatcellák egyesítése**

Használja a [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) metódust egy téglalap alakú cellatartomány egyetlen cellává fésüléséhez. Adja meg a tartomány bal‑felső és jobb‑alsó sarok celláit. Az utolsó paraméter szabályozza, hogy az egyesítés magában foglalhat‑e a megadott tartományon kívüli cellákat; a `false` érték az egyesítést csak a tartományon belül tartja.

A példa egy 4×4‑es táblázatot hoz létre 70‑pontos oszlopszélességgel és sormagassággal, majd egyesíti a négy középső cellát a `(1, 1)`‑től a `(2, 2)`‑ig terjedő tartományban. Az eredményül kapott cella két oszlopot és két sort fed le, míg a táblázat alaprácsa továbbra is négy oszlopból és négy sorból áll. Az egyesített cella tartalmát vagy formázását a bal‑felső pozícióval érheti el: `table->idx_get(1, 1)` ebben a példában. A többi pozíció a tartományban a táblázatrács része marad, így a tartományon kívüli cellák indexei változatlanok.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Táblázatcellák felosztása**

Az előző példában az egyesítés megőrzi a táblázat rácsát. Egy cella felosztása új rácsoloszlopot vezethet be, és megváltoztathatja a jobb oldali cellák oszlopszámait. Az Aspose.Slides a PowerPoint táblázatrács‑modellt követi.

Ez a példa egy 4×4‑es táblázatot hoz létre 70‑pontos oszlopszélességgel és sormagassággal, majd a `(1, 1)` cellán a [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) metódust hívja meg. A cella 70‑pontos szélességének felét adja át, így két egyenlő szélességű cella jön létre.

A felosztás után a két felét a `table->idx_get(1, 1)` és a `table->idx_get(2, 1)` hivatkozásokkal érhetjük el. A táblázatrácsnak most öt oszlopa van: az eredetileg a 2. és 3. oszlopban lévő cellák a 3. és 4. oszlopba kerülnek. A sorindexek változatlanok maradnak. A felosztás után ezekkel a frissített oszlopszámokkal kell hivatkozni a cellákra.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

<!-- visual-explanation:manage-cells:start -->
[![Egy nem egyesített, 70 pontos cella két 35 pontos cellára esik szét, ezzel egy ötödik rácsoszlopot ad hozzá, és a jobb oldali indexeket eltolja.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*•	A szélesség felosztás a (1, 1) cellát érinti, nulla‑alapú (oszlop, sor) indexekkel. A többi sor megőrzi azt a cellát, amely mindkét új oszlophelyet lefedi.*
<!-- visual-explanation:manage-cells:end -->

### **Egyesített cellák felosztása sor- vagy oszlopszélesség alapján**

Az egyesített sabloncellák adatbetöltésre való előkészítéséhez használja a [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) metódust egy meglévő sorhatár mentén, vagy a [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) metódust egy oszlophatár mentén.

Az `index` argumentum a felosztás felső részének sorait vagy bal részének oszlopait számolja; a megadott érték a egyesített régióhoz képest relatív:

- Sor felosztás: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Oszlop felosztás: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

A példa egy prezentációt feltételez, amelynek első diáján az első alakzat egy táblázat, a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesítve vannak. Az alsó pozícióból kiindulva a [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) és a [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) segítségével keresik a kiindulót, és ellenőrzik mindkét kiterjedést. A `SplitByRowSpan(1)` elválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Vízszintes, két oszlopos egyesítéshez helyette a `SplitByColSpan(1)` használható.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // A felosztás után a táblázatból lekérdezzük az eredő cellákat.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

A táblázatrács és a környező cellaindexek változatlanok maradnak. A keletkezett cellákat a koordinátáik alapján érheti vissza; itt mindkettő 1‑es kiterjedésű, és a [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) `False` értéket ad ki. Nagyobb régiók egy felosztás után is részben egyesítve maradhatnak.

Az eredeti szöveg és formázása az felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. A felosztás után töltse fel a cellákat, és szükség esetén állítsa be a szövegformázást explicit módon.

A mentett prezentáció külön “Product A” és “Product B” cellákat tartalmaz, a sablon cellaformázása megmarad. Tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) részleteket.

### **Cellafelosztás meghatározott magasságban**

A [SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) a felső rész magasságát pontban veszi. A [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) a felső részben lévő meglévő rácssorok számát veszi. Egy 40‑pontos cella középre helyezéséhez a jobb oszlopban vonja le 40‑et a cella tényleges magasságából, majd ossza el a maradék helyet egyenlően felül és alul.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

Az első felosztás egy rácssort ad hozzá, így a `(1, 1)` alatti rész 90 pont marad. A második felosztás ezt a cellát célozza meg, és egy új sort ad hozzá alatta. A jobb oszlop most már `(1, 0)` 50 pont (margin), `(1, 1)` 40 pont és `(1, 2)` 50 pont (margin) magasságú cellákat tartalmaz. A bal cella mindhárom sort átfogja, eredeti 140 pontos magasságával.

![A bal cella kitölti a teljes táblázatmagasságot, három cella mellett, a középső cellában Middle áll.](split-by-height.png)

## **A táblázatcella háttérszínének módosítása**

Ez a példa egy 150‑pontos oszlopszélességű és 50‑pontos sormagasságú táblázatot hoz létre. A [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) segítségével szilárd kitöltést választ, a [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) pedig a kitöltőszínt adja vissza, amelyet pirosra állít a `(2, 3)` cellában, azaz a harmadik oszlopban és a negyedik sorban.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Kép hozzáadása egy táblázatcellához**

Helyezze el a bemeneti képet a munkakönyvtárban, mielőtt futtatná a példát. A kép betöltése a [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) segítségével történik, majd a [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) segítségével hozzáadja a prezentáció képgyűjteményéhez. Ezután a képet a `(0, 0)` cella (az első cella a táblázatban) képkitöltéséhez rendeli.

A [PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) a képet kinyújtja, hogy kitöltse a cellát, ami megváltoztathatja az arányait. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött képet a hozzáadás után a rendszer felszabadítja.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Beállíthatok különböző vonalvastagságot és stílust a cella különböző oldalain?**

Igen. A [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) szegélyeknek külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérő lehet.

**Mi történik a képpel, ha a képet tartalmazó cella háttérként beállítása után megváltoztatom az oszlop/sor méretét?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile) beállításától függ. Nyújtás esetén a kép a új cellához igazodik; csempe esetén a csempéket újraszámítják.

**Hozzáadhatok hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/cpp/manage-hyperlinks/) a cella szövegkeretének (rész) szintjén vagy a teljes táblázat/alakzat szintjén állítható be. Gyakorlatban egy részt vagy a cella összes szövegét linkeli meg.

**Beállíthatok különböző betűtípusokat egyetlen cellában?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (futtatások) önálló formázással — betűcsalád, stílus, méret és szín.