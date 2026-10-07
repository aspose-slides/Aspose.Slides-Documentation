---
title: C++-ban táblacellák kezelése prezentációkban
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/cpp/manage-cells/
keywords:
- táblacella
- cellák összeolvasztása
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "PowerPoint táblacellák kezelése C++-ban: összeolvasztott cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a PowerPoint‑prezentációk táblacelláinak elérését és módosítását. Ez a cikk bemutatja, hogyan azonosíthatók az összeolvasztott táblacellák, hogyan távolíthatók el a cella szegélyei, hogyan kezelhető a cellaszámozás az összeolvasztás vagy felosztás után, hogyan változtatható meg egy cella háttérszíne, és hogyan adható hozzá kép egy táblacellához. A példák megmutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezzük meg a táblát egy diáról, hogyan frissíthető a cella formázása a cella tulajdonságain keresztül, és hogyan menthetjük el a módosított prezentációt PPTX‑fájlként.

Az Aspose.Slides a nullától indexelt (0‑bázisú) indexeket használja a táblacellák eléréséhez `(oszlop, sor)` sorrendben.

## **Összeolvasztott táblacell azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblaként használja. Feltételezi, hogy a dia és az alakzat létezik, valamint hogy az alakzat táblát tartalmaz. Ezután végigiterál az összes soron és oszlopon, és a [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) metódussal azonosítja az összeolvasztott területek celláit. Minden egyezésnél kiírja a cella koordinátáit `sor;oszlop` sorrendben, a [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), a [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), valamint a terület kezdő koordinátáit, a [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) és a [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) segítségével.

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

## **Táblacell szegélyek eltávolítása**

Hozzunk létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) objektumot, és adjunk hozzá egy táblát az első diájához a [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) metódussal. Az oszlopszélességek, sormagasságok és a tábla pozíciója pontban vannak megadva. A példa a négy cellaszegélyt is [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) típusra állítja, ezzel láthatatlanná téve őket.

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

## **Táblacellák összeolvasztása**

Használja a [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) metódust egy téglalap alakú cellatartomány egy cellává egyesítéséhez. Adja meg a tartomány bal‑felső és jobb‑alsó sarkában lévő cellákat. Az utolsó argumentum határozza meg, hogy az összeolvasztás magába foglalhat‑e a megadott tartományon kívüli cellákat; a `false` érték a tartományon belül tartja az összeolvasztást.

A példa egy 4‑by‑4 táblát hoz létre 70‑pontos oszlop- és sormérettel, majd a középső négy cellát összeolvasztja a `(1, 1)`‑től `(2, 2)`‑ig terjedő tartományban. Az eredményül kapott cella két oszlopot és két sort fed le, miközben a tábla alaprácsa továbbra is négy oszlopból és négy sorból áll. Az összeolvasztott cella tartalmának vagy formázásának eléréséhez használja a bal‑felső pozíciót: `table->idx_get(1, 1)` ebben a példában. A többi pozíció a tartományban továbbra is a tábla rácsának része marad, így a tartományon kívüli cellák indexei nem változnak.

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

## **Táblacellák felosztása**

Az előző példában az összeolvasztás megőrzi a tábla rácsát. Egy cella felosztása új rácsoszlopot hozhat létre, és megváltoztathatja a jobb oldalán lévő cellák oszlopszámait. Az Aspose.Slides a PowerPoint táblarács‑modelljét követi.

Ez a példa egy 4‑by‑4 táblát hoz létre 70‑pontos oszlop‑ és sormérettel, és a `(1, 1)` cellán meghívja a [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) metódust. A cella 70‑pontos szélességének felét adja át, így két egyenlő szélességű cella jön létre.

A felosztás után a két felét a `table->idx_get(1, 1)` és a `table->idx_get(2, 1)` hivatkozza. A tábla rácsa most már öt oszlopot tartalmaz: az eredetileg a 2. és 3. oszlopban lévő cellák most a 3. és 4. oszlopba kerülnek. A sor‑indexek változatlanok maradnak. A felosztás utáni cellák elérésekor használja ezeket a frissített oszlopszámokat.

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

### **Összeolvasztott cellák felosztása sor‑ vagy oszlopszélesség szerint**

Az összeolvasztott sabloncellák adatfeltöltés előtti felosztásához használja a [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) metódust egy meglévő sorhatáron vagy a [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) metódust egy oszlophatáron.

Az `index` argumentum a felosztás felső részének sorait vagy bal részének oszlopait számlálja; a megadott érték a összeolvasztott régióhoz képest relatív:

- Sor‑felosztás: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Oszlop‑felosztás: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

A példa azt feltételezi, hogy a prezentáció első diáján az első alakzat egy tábla, amelyben a `(1, 2)` és `(1, 3)` cellák függőlegesen vannak összeolvasztva. Az alsó pozícióból kiindulva a [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) és a [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) segítségével meghatározza a kiindulási pontot, majd ellenőrzi mindkét kiterjedést. A `SplitByRowSpan(1)` ezután szétválasztja a 2. és 3. sorokat a terméknevekhez. Vízszintes, két‑oszlopos összeolvasztáshoz használja helyette a `SplitByColSpan(1)`‑et.

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

    // Szerezze be a felosztás után keletkezett cellákat a táblából.
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

A tábla rácsa és a környező cella‑indexek változatlanok maradnak. A kapott cellákat a koordinátáik alapján érheti el; itt mindkettő 1‑es kiterjedéssel rendelkezik, és a [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) `False`‑t ad vissza. Nagyobb régiók egy felosztás után is részben összeolvasztva maradhatnak.

Az eredeti szöveg és formázása az felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, szegélyeket és margókat. A felosztás után töltse fel a cellákat, és állítsa be szükség szerint a szövegformázást.

A mentett prezentáció külön „Product A” és „Product B” cellákat tartalmaz, a sablon cellaformázása megmarad. További részletekért tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) oldalt.

## **A táblacell háttérszínének módosítása**

Ez a példa egy 150‑pontos oszloppal és 50‑pontos sorokkal rendelkező táblát hoz létre. A [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) segítségével szilárd kitöltést választ, majd a [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) segítségével eléri a kitöltés színét, amelyet pirosra állít a `(2, 3)` cellában, azaz a harmadik oszlopban és a negyedik sorban.

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

## **Kép hozzáadása egy táblacellán belül**

A futtatás előtt helyezze az bemeneti képet a munkakönyvtárba. A kép betöltése a [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) metódussal történik, majd a prezentáció képgyűjteményéhez adja hozzá a [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) segítségével. Ezután a képet a `(0, 0)` cella (a tábla első cellája) képkitöltéséhez rendeli.

A [PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) a képet a cella kitöltésére nyújtja, ami megváltoztathatja az arányait. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött képet a prezentációhoz való hozzáadás után felszabadítjuk.

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

**Beállíthatok különböző vonalvastagságokat és stílusokat egy cella egyes oldalaira?**

Igen. A [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) szegélyeknek külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha a cella háttérképeként beállítottam, majd módosítom az oszlop/sor méretét?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile) függvénye. Nyújtás esetén a kép alkalmazkodik az új cellához, csempézés esetén a csempéket újraszámítják.

**Hozzá tudok-e rendelni hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/cpp/manage-hyperlinks/) szövegszintű (részlet) vagy az egész táblához/alakzathoz állítható. Gyakorlatban a hivatkozást egy részlethez vagy a cella teljes szövegéhez rendeli.

**Beállíthatok-e különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegdoboza támogatja a [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (run‑ok) független formázását – betűcsalád, stílus, méret és szín.