---
title: 使用 C++ 管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/cpp/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格中的圖像
- 背景顏色
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 C++ 管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、拆分儲存格，並使用 Aspose.Slides for C++ 設定背景顏色與圖像。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中存取和修改表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色彩，以及在表格儲存格內新增圖像。範例展示了如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 使用零基索引以 `(column, row)` 的順序存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有簡報，並將第一張投影片上的第一個圖形作為表格存取。它假設投影片與圖形皆存在，且該圖形為表格。接著遍歷所有列與行，並使用 [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) 來識別合併區域中的儲存格。對於每個匹配，它會以 `row;column` 的順序列印儲存格座標、[get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)、[get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)，以及區域的起始座標，[get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 和 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)。

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

## **移除表格儲存格邊框**

建立一個 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)，並使用 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 在其第一張投影片上新增表格。欄寬、列高以及表格位置皆以點（points）為單位指定。此範例將四個儲存格邊框全部設定為 [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)，使其不可見。

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

## **合併表格儲存格**

使用 [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) 將矩形範圍的表格儲存格合併為一個儲存格。指定範圍左上角與右下角的儲存格。最後一個參數控制合併是否可以包含指定範圍之外的儲存格；`false` 會將合併限制在該範圍內。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，然後合併位於 `(1, 1)` 至 `(2, 2)` 的四個中心儲存格。合併後的儲存格跨越兩欄兩列，而表格的底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上角位置：在此範例中為 `table->idx_get(1, 1)`。合併範圍內的其他位置仍屬於表格格線的一部份，因此範圍外儲存格的索引不會改變。

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

## **拆分表格儲存格**

在前一個範例中合併儲存格會保留表格的格線。拆分儲存格可能會引入新的格線欄，並改變其右側儲存格的欄索引。Aspose.Slides 依循 PowerPoint 的表格格線模型。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，並在儲存格 `(1, 1)` 上呼叫 [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/)。將儲存格 70 點寬度的一半傳入，以建立兩個等寬的儲存格。

拆分後，兩個半部可分別以 `table->idx_get(1, 1)` 與 `table->idx_get(2, 1)` 取用。表格格線現在有五欄：原本在第 2 與第 3 欄的儲存格分別移至第 3 與第 4 欄。列索引保持不變。拆分後存取儲存格時，請使用這些更新後的欄索引。

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

### **依列或欄跨度拆分合併的儲存格**

若要為資料填充準備已合併的範本儲存格，可使用 [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) 沿現有列邊界拆分，或使用 [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) 沿欄邊界拆分。

`index` 參數計算分割上部的列數或左部的欄數；它相對於合併區域：

- 列拆分：`0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)。
- 欄拆分：`0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)。

此範例假設簡報的第一張投影片上第一個圖形為表格，且 `(1, 2)` 與 `(1, 3)` 之儲存格已垂直合併。從較低的位置開始，它使用 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) 與 [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 取得起始點，並檢查兩個跨度。`SplitByRowSpan(1)` 隨後分離第 2 與第 3 列，以放置產品名稱。若為水平兩欄合併，則改為使用 `SplitByColSpan(1)`。

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

    // 從表格中取得拆分後的結果儲存格。
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

表格格線與周圍儲存格的索引保持不變。可依座標取得結果儲存格；此處兩者的跨度皆為 1，且 [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) 會回傳 `False`。較大的區域在一次拆分後仍可能部分保留合併狀態。

原始文字與其格式保留在上方（或左側）儲存格；新儲存格為空白，但會繼承儲存格的格式，例如填色、邊框與邊距。拆分後請填入儲存格並明確設定任何必要的文字格式。

儲存的簡報包含分別的「Product A」與「Product B」儲存格，且保留了範本的儲存格格式。請參閱 [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) 了解詳細資訊。

## **變更表格儲存格背景色彩**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) 來選擇實心填色，並使用 [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) 取得填色顏色，將儲存格 `(2, 3)`（第 3 欄第 4 列）的背景設為紅色。

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

## **在表格儲存格內加入圖像**

在執行此範例前，請將輸入圖像放置於工作目錄中。程式使用 [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) 載入圖像，並以 [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) 新增至簡報的圖像集合。接著將該圖像指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填充。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) 會將圖像拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高以點為單位。載入的圖像在加入簡報後即被釋放。

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

## **常見問題**

**我可以為單一儲存格的不同側設定不同的線條粗細和樣式嗎？**

可以。[top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) 邊框各有獨立屬性，因此每一側的粗細與樣式可以不同。

**如果在將圖片設定為儲存格背景後，變更欄或列的尺寸，圖像會發生什麼變化？**

行為取決於 [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)（stretch/tile）。拉伸時，圖像會依新儲存格調整；平鋪時，圖塊會重新計算。

**我可以將超連結指派給儲存格內的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/cpp/manage-hyperlinks/) 會設定在儲存格文字框內的文字（片段）層級，或整個表格/圖形層級。實務上，您可以將連結指派給某個片段或儲存格內的全部文字。

**我可以在單一儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)（文字執行）具備獨立的格式設定—字型、樣式、大小與顏色。