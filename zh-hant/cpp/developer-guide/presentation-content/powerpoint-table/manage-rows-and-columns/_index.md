---
title: 使用 C++ 管理 PowerPoint 表格中的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/cpp/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 首列
- 表格標題列
- 克隆列
- 克隆欄
- 複製列
- 複製欄
- 移除列
- 移除欄
- 列文字格式設定
- 欄文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 中管理表格列與欄，並加速簡報編輯與資料更新。"
---
## **簡介**

Aspose.Slides for C++ 讓您能透過 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 類別和 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 介面，管理 PowerPoint 簡報中的表格結構和格式設定。您可以指定標題列、複製或移除列與欄，並對整列或整欄套用文字格式。

本文章說明這些操作，並提供 C++ 範例。同時展示如何取得表格的樣式預設，以便重複使用。表格列與欄的索引從零開始。

## **控制列高度**

使用 [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) 以點數設定列的最小高度。它僅作為下限，並非固定高度。[IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) 會回傳實際高度；此值無法直接設定。可透過 [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/) 取得列。

範例載入 [row-height-input.pptx](row-height-input.pptx)，該檔案在第一張投影片的第一個圖形是一個表格。其第一列的起始高度為 70 點。儲存格使用 18 點 Arial 文字，啟用自動換行，且上下邊距為 6 點；第二欄較長的文字會換成多行。範例將最小高度提升至 100 點，然後降低至 20 點，在每次變更後輸出實際高度，並將兩個結果儲存。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

使用提供的簡報時，提高最小值會為列新增空間。降低最小值會移除該額外空間，但實際高度仍大於 20 點，因為文字與儲存格邊距需要更多空間。僅降低最小值無法將列強行縮小至低於內容所需的空間。

多種因素會影響實際高度：

- **文字與字型大小：** 較長的文字、明確的換行或較大的字型可能需要更多垂直空間。
- **換行與欄寬：** 啟用換行時，使用 [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) 減小欄寬會產生更多行。較寬的欄位則可減少垂直空間需求。
- **儲存格邊距：** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) 與 [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) 控制會增加垂直空間的邊距。[ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) 與 [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) 控制會縮減文字可用寬度的邊距，並可能導致額外換行。

對於此未合併儲存格的表格，最需要垂直空間的儲存格決定整列的內容驅動下限。若要使列變短，可能也需要縮短文字、減少字型大小或邊距，或增寬欄位。

下方圖片顯示相同尺寸的表格。在此示範的 .NET 參考執行中，實際高度分別為 70、100 與 55.2 點：最後一列仍高於其 20 點的最小值。文字的精確測量會因環境中可用的字型而異。下載已儲存的結果：[increased minimum](row-height-increased.pptx) 與 [decreased minimum](row-height-decreased.pptx)。

| 原始：最小 70 pt，實際 70 pt | 增加：最小 100 pt，實際 100 pt | 減少：最小 20 pt，實際 55.2 pt |
| --- | --- | --- |
| ![原始表格，第一列為 70 點。](row-height-before.png) | ![將第一列最小高度提升至 100 點後的表格。](row-height-increased.png) | ![將第一列最小高度降低至 20 點後的表格；換行文字使列高度仍高於最小值。](row-height-decreased.png) |

## **設定首列為標題列**

使用 [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) 方法將第一列標記為標題格式。其外觀取決於套用於表格的表格樣式。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 取得投影片上作為第一個圖形的表格。
4. 為其第一列啟用標題格式。
5. 儲存已修改的簡報。

範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格。它為第一列啟用標題格式，並儲存為 `First_row_header.pptx`。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **複製表格列或欄**

複製列或欄以重新使用其內容與格式。您可以將副本附加至表格末端，或插入於特定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法新增表格。
5. 複製所需的列。
6. 複製所需的欄。
7. 儲存已修改的簡報。

範例需要 `Test.pptx`，至少包含一張投影片。它建立一個三欄五列的表格，尺寸以點數指定。它將第一列與第一欄的副本附加至表格尾端，接着在索引 3（第四個位置）插入第二列與第二欄的副本。最終表格有七列五欄。`false` 參數會停用對相鄰合併列或欄的複製；此表格沒有合併儲存格。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **從表格中移除列或欄**

移除表格中不再需要的列或欄。移除項目會使其後的列或欄索引移位。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別建立簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法新增表格。
5. 移除第二列與第二欄。
6. 儲存已修改的簡報。

此範例建立一個 3x3 表格，並移除索引為 1 的列與欄，留下 2x2 表格於 `TestTable_out.pptx`。尺寸以點數表示。`false` 參數會停用對相鄰合併列或欄的移除；此表格沒有合併儲存格。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **在表格列層級設定文字格式**

對整列套用文字格式，以保持其儲存格的一致性。您可設定字型屬性、段落格式與文字方向，無需逐一格式化儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 使用 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 為第一列設定字型高度。
4. 使用 [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 與 [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) 為第一列設定對齊方式與右側段落邊距。
5. 使用 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) 為第二列設定文字方向。
6. 儲存已修改的簡報。

範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格且至少有兩列。它對第一列套用 25 點字型、右對齊以及 20 點右側段落邊距，然後對第二列設定垂直文字。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **在表格欄層級設定文字格式**

對整欄套用文字格式，以保持其儲存格的一致性。您可設定字型屬性、段落格式與文字方向，無需逐一格式化儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 使用 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 為第一欄設定字型高度。
4. 使用 [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 與 [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) 為第一欄設定對齊方式與右側段落邊距。
5. 使用 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) 為第二欄設定文字方向。
6. 儲存已修改的簡報。

範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格且至少有兩欄。它對第一欄套用 25 點字型、右對齊以及 20 點右側段落邊距，然後對第二欄設定垂直文字。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **取得表格樣式屬性**

使用 [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) 方法取得套用於表格的預設樣式，並可在另一個表格上重複使用。此方法識別的是預設樣式，而非單一儲存格的格式覆寫。

範例建立一個表格，套用 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/)，再讀回該預設。它會輸出 `DarkStyle1` 並將表格儲存為 `table.pptx`。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**我可以將 PowerPoint 佈景主題/樣式套用到已建立的表格嗎？**

可以。表格會繼承投影片/版面配置/母片的主題，且您仍可在此主題之上覆寫填滿、邊框與文字顏色。

**我可以像 Excel 那樣對表格列進行排序嗎？**

不能，Aspose.Slides 的表格沒有內建的排序或篩選功能。請先在記憶體中排序資料，然後依排序結果重新填入表格列。

**我可以在保留特定儲存格自訂顏色的同時，使用條紋欄位嗎？**

可以。先開啟條紋欄位，然後以局部格式覆寫特定儲存格；儲存格層級的格式會優先於表格樣式。