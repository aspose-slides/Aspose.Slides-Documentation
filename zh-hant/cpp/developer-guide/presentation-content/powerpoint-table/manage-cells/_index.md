---
title: 使用 C++ 管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/cpp/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除框線
- 拆分儲存格
- 儲存格內的影像
- 背景顏色
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 C++ 管理 PowerPoint 表格儲存格：辨識合併儲存格、移除框線、拆分儲存格，並使用 Aspose.Slides for C++ 設定背景顏色與影像。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中存取和修改表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格框線、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色，及在表格儲存格內加入影像。示例展示了如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔。

Aspose.Slides 使用零基索引以 `(column, row)` 的順序存取表格儲存格。

## **識別合併的表格儲存格**

範例開啟現有簡報，將第一張投影片的第一個圖形作為表格存取。它假設投影片與圖形皆存在且該圖形為表格。接著遍歷所有列與欄，使用 [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) 來識別合併區域中的儲存格。對於每個符合的儲存格，會依 `row;column` 順序列印儲存格座標、[get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)、[get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)，以及區域的起始座標 [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 和 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)。

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

## **移除表格儲存格框線**

建立一個 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)，並使用 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 在其第一張投影片加入表格。欄寬、列高與表格位置均以點 (point) 為單位指定。範例將四個儲存格框線全部設定為 [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)，使其不可見。

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

## **加入對角線框線**

使用 [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) 從左上角畫線至右下角，使用 [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) 從左下角畫線至右上角。對角線可用於標記角落標題；兩條對角線組成 X 可表示儲存格不適用。

每條對角線都是一個 [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/)。使用 [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) 取得其填充，呼叫 [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) 並傳入 [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 以選擇顏色，然後透過 [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/) 設定顏色。使用 [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) 以點為單位設定線寬。

範例在同一列建立三個儲存格：一個紅色向下對角線、一個藍色向上對角線，以及兩條對角線皆存在。其上下左右框線保持不變。

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

對角線屬於格式設定屬性，而非儲存格分割。每個儲存格仍保留單一文字框，可透過 [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) 存取；對角線兩側的區域無法獨立編輯。

儲存的表格於 Microsoft PowerPoint 中的呈現：

![三個表格儲存格分別顯示左上至右下的紅色對角線、左下至右上的藍色對角線，以及組成 X 的兩條對角線。](diagonal-cell-borders.png)

*由左至右：向下對角線（紅色，3 pt）、向上對角線（藍色，5 pt）以及兩條對角線。*

## **合併表格儲存格**

使用 [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) 將矩形範圍的表格儲存格合併為單一儲存格。指定範圍左上角與右下角的儲存格。最後一個參數控制合併是否可包含範圍外的儲存格；`false` 會將合併限制在該範圍內。

範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，然後合併位於 `(1, 1)` 至 `(2, 2)` 的四個中心儲存格。結果儲存格跨兩欄兩列，而表格底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，使用其左上角位置：本例中為 `table->idx_get(1, 1)`。合併範圍內的其他位置仍屬於表格格線，因此範圍外儲存格的索引不會變動。

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

前一個示例的合併會保留表格格線。拆分儲存格可能會引入新格線欄，並改變右側儲存格的欄索引。Aspose.Slides 依循 PowerPoint 的表格格線模型。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，然後對儲存格 `(1, 1)` 呼叫 [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/)。將儲存格 70 點寬度的一半傳入，以建立兩個等寬儲存格。

拆分後，兩個新儲存格分別以 `table->idx_get(1, 1)` 和 `table->idx_get(2, 1)` 取得。表格格線現在有五欄：原本屬於第 2、3 欄的儲存格移至第 3、4 欄。列索引保持不變。拆分後存取儲存格時請使用更新後的欄索引。

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
[![未合併的 70 點儲存格拆分為兩個 35 點儲存格，新增第 5 條格線欄並將右側索引往右移動。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*寬度拆分影響儲存格 (1, 1)，採用零基 (column, row) 索引。其他列的儲存格仍跨越新欄位的兩個位置。*
<!-- visual-explanation:manage-cells:end -->

### **依列或欄跨距拆分合併儲存格**

為了在資料填入前處理合併的範本儲存格，可使用 [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) 依現有列邊界拆分，或使用 [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) 依欄邊界拆分。

`index` 參數計算列在上部的數量或欄在左部的數量，且相對於合併區域：

- 列拆分：`0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)。
- 欄拆分：`0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)。

範例假設簡報的第一張投影片的第一個圖形為表格，且 `(1, 2)` 與 `(1, 3)` 垂直合併。從較低的位置開始，使用 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) 與 [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 定位來源，並檢查兩個跨距。`SplitByRowSpan(1)` 會將第 2、3 列分離，以放置產品名稱。若為水平兩欄合併，則改為使用 `SplitByColSpan(1)`。

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

    // 取得分割後表格中的結果儲存格。
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

表格格線與周圍儲存格索引保持不變。透過座標取得結果儲存格；此處兩個儲存格的跨距皆為 1，且 [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) 會傳回 `False`。較大的區域在一次拆分後仍可能部分保留合併狀態。

原始文字與格式保留在上方（或左側）儲存格；新儲存格為空，但會繼承填色、框線與邊距等儲存格格式。拆分後請自行填入文字並顯式設定任何所需的文字格式。

儲存的簡報會呈現分開的「Product A」與「Product B」儲存格，且保留範本的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/)。

### **以特定高度拆分儲存格**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) 以點為單位指定上部的高度。[SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) 以格線列數指定上部的行數。若要將 40 點的儲存格置於右欄的中間，先從儲存格實際高度減去 40 點，然後將剩餘空間上下各平分。

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

第一次拆分會加入一條格線列，使下方的 90 點保留在 `(1, 1)`。第二次拆分針對該儲存格，再在其下方加入一條列。右欄現在包含 `(1, 0)`（50 點，`margin`）、`(1, 1)`（40 點）以及 `(1, 2)`（50 點，`margin`）。左側儲存格跨越全部三列，保持原始高度 140 點。

![左側儲存格跨越整個表格高度，右側有三個儲存格，中間為 Middle。](split-by-height.png)

## **變更表格儲存格的背景顏色**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) 選取實心填充，並透過 [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) 取得填色，將儲存格 `(2, 3)`（第 3 欄第 4 列）的背景設為紅色。

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

## **在表格儲存格內加入影像**

在執行本範例前，請將輸入影像放置於工作目錄中。程式會使用 [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) 載入影像，並透過 [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) 加入簡報的影像集合。接著將影像指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填充。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) 會將影像拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高皆以點為單位。載入的影像在加入簡報後即被釋放。

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

**我可以為單一儲存格的不同邊設定不同的線寬與樣式嗎？**

可以。[top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)、[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)、[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)、[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) 框線各自有獨立屬性，可分別設定其厚度與樣式。

**若在將圖片設為儲存格背景後調整欄/列大小，圖片會發生什麼變化？**

行為取決於 [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)（stretch/tile）。使用 stretch 時，圖片會依新儲存格調整；使用 tile 時，圖磚會重新計算。

**我可以將超連結指派給儲存格的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/cpp/manage-hyperlinks/) 於儲存格的文字框（portion）層級或整個表格/圖形層級設定。實務上，您會將連結指派給文字框內的某個段落，或全部文字。

**我可以在單一儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)（文字片段），每個片段可擁有獨立的字型、樣式、大小與顏色。