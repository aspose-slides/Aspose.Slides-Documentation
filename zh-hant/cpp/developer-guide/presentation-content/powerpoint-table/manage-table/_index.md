---
title: 在 C++ 中管理簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/cpp/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比
- 對齊文字
- 文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 投影片中建立與編輯表格。探索簡單的程式碼範例，簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格將資訊以列和欄的方式組織，使閱讀和比較數值更為方便。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 類別、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 介面、[Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) 類別、[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 介面，以及其他類型，讓您能在簡報中建立、更新與管理表格。

## **從頭開始建立表格**

透過指定位置、欄寬與列高來建立表格。將表格加入投影片後，您可以設定儲存格邊框、合併儲存格、以及插入文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 定義以點為單位的欄寬陣列。  
4. 定義以點為單位的列高陣列。  
5. 透過 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法將 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 物件加入投影片。  
6. 遍歷每個 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 以套用上、下、左、右邊框的格式設定。  
7. 合併表格第一列的前兩個儲存格。  
8. 透過其 [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) 方法存取合併後的儲存格。  
9. 設定合併儲存格中的文字。  
10. 儲存已修改的簡報。

以下範例在 (100, 50) 點的位置建立一個 3 欄 5 列的表格。它套用寬度為 5 點的紅色邊框，合併第一列的前兩個儲存格，並將結果儲存為 `table.pptx`。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **標準表格的編號方式**

在標準表格中，儲存格索引採零基制，順序為 (欄, 列)。第一個儲存格的索引為 (0, 0)。

例如，具有 4 欄 4 列的表格之儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此範例建立上圖所示的 4 × 4 表格，欄寬與列高皆為 70 點，並套用寬度為 5 點的紅色儲存格邊框。座標說明儲存格索引；範例不填入任何內容，並將表格儲存為 `StandardTables_out.pptx`。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **存取現有的表格**

表格儲存在投影片的形狀集合中。遍歷形狀以尋找表格，然後使用 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 介面讀取或更新其儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別載入簡報。  
2. 依索引取得包含表格的投影片參考。  
3. 遍歷 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 物件，當找到表格時即停止。如果投影片包含多個表格，使用 [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) 辨識所需的表格。  
4. 更新目標儲存格中的文字。  
5. 儲存已修改的簡報。

以下範例開啟 `UpdateExistingTable.pptx`，並在第一張投影片中找到第一個表格。它將第 0 欄第 1 列的儲存格設定為 `New`，並將結果儲存為 `table1_out.pptx`。輸入檔必須至少包含一張投影片，且該投影片上的第一個表格必須至少有一欄兩列。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

若要調整現有表格的列高度，並了解實際高度為何可能超過要求的最小值，請參閱 [控制行高](/slides/zh-hant/cpp/manage-rows-and-columns/#control-row-height)。

## **找出擁有文字框的儲存格**

當通用文字處理程式碼從表格取得 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 時，使用 [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) 取得擁有該文字框的 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)。對於表格儲存格的文字框，[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) 會返回擁有者，而 [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) 會返回 `nullptr`，即使表格本身也是一個形狀。

儲存格座標可透過唯讀的 [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) 與 [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 方法取得。[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) 亦提供唯讀的導向功能：它返回擁有者但不改變所有權。使用前務必檢查返回的儲存格是否為 `nullptr`。

欲取得同時辨識表格儲存格與形狀擁有者（包括與 SmartArt 節點相關的形狀）的完整範例，請參閱 [搜尋與取代文字](/slides/zh-hant/cpp/search-and-replace-text/)。

## **對齊表格內的文字**

您可以控制個別儲存格的垂直定位與文字方向。本節範例將第一個儲存格的文字置中，並旋轉 270 度。

1. 建立 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片參考。  
3. 將 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 物件加入投影片。  
4. 從表格取得 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 物件。  
5. 取得第一個 [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)，設定其文字與顏色。  
6. 使用 [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) 與 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) 設定儲存格的垂直定位與文字方向。  
7. 儲存已修改的簡報。

此範例建立一個 4 × 4 表格，欄寬 120 點、列高 100 點。它格式化儲存格 (0, 0) 的文字，為第一列其餘儲存格加入值，並將結果儲存為 `Vertical_Align_Text_out.pptx`。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **在表格層級設定文字格式**

使用 [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) 可對表格中所有儲存格套用文字格式。其多載接受段落、文字區塊與文字框的格式設定，讓您無需逐一遍歷儲存格即可設定這些屬性。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別載入簡報。  
2. 依索引取得投影片參考。  
3. 從投影片取得 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 物件。  
4. 使用 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 為文字設定字型高度。  
5. 使用 [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 與 [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) 設定段落對齊方式與右邊距。  
6. 使用 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) 設定文字方向。  
7. 儲存已修改的簡報。

以下範例開啟 `table.pptx`（該檔必須至少包含一張投影片，且第一個形狀為表格），將字型高度設為 25 點，段落右對齊且右邊距為 20 點，並將文字設為垂直。格式化後的簡報儲存為 `result.pptx`。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **取得表格樣式屬性**

使用 [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) 讀取表格的預設樣式，使用 [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) 指定樣式。本範例將 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) 套用於第一個表格，列印預設名稱，然後將相同的預設套用至第二個表格。兩個表格皆儲存於 `table-style.pptx`。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **鎖定表格的長寬比**

表格的長寬比是寬度與高度的比例。使用 [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) 可為表格鎖定此比例。

以下範例開啟 `pres.pptx`（該檔必須至少包含一張投影片，且第一個形狀為表格），列印目前的鎖定狀態，啟用長寬比鎖定，列印更新後的狀態 (`True`)，並將結果儲存為 `pres-out.pptx`。

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **常見問題**

**我可以為整個表格及其儲存格中的文字啟用從右至左 (RTL) 閱讀方向嗎？**

可以。表格提供 [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) 方法，段落則有 [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/)。同時使用兩者可確保儲存格內的文字正確呈現 RTL 排序與渲染。

**如何防止使用者在最終檔案中移動或調整表格的大小？**

使用 [形狀鎖定](/slides/zh-hant/cpp/applying-protection-to-presentation/) 來停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援在儲存格內插入影像作為背景？**

支援。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/)，影像會依選擇的模式（拉伸或並排）覆蓋儲存格區域。