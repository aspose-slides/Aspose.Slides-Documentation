---
title: 使用 C++ 在簡報中自訂圖表資料表格
linktitle: 資料表格
type: docs
url: /zh-hant/cpp/chart-data-table/
keywords:
- 圖表資料
- 資料表格
- 字型屬性
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中自訂圖表資料表格的字型、邊框與圖例鍵。"
---
## **概觀**

Aspose.Slides for C++ 允許您顯示圖表的資料表格，並自訂其文字格式、邊框和圖例鍵。本文說明如何啟用表格、格式化文字、控制各類邊框，以及顯示或隱藏圖例鍵。範例會將設定好的圖表儲存為 PPTX 檔案。

## **設定字型屬性**

若要顯示圖表的資料表格，請將 `true` 傳遞給 [IChart::set_HasDataTable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/set_hasdatatable/)。使用 [IChart::get_ChartDataTable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_chartdatatable/) 取得表格並設定其文字格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別載入簡報。
1. 在第一張投影片加入一個叢集柱狀圖。
1. 啟用圖表的資料表格。
1. 使用 [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/set_fontbold/) 啟用粗體文字，並傳遞 `20` 給 [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/set_fontheight/) 以設定 20 點大小的文字。
1. 儲存已修改的簡報。

以下範例需要工作目錄中有 `test.pptx`，且該檔案至少包含一張投影片。它會在位置 (50, 50) 加入一個預設資料的圖表，寬度為 600 點，高度為 400 點。儲存的 `output.pptx` 內含已啟用資料表格且套用指定字型設定的圖表。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **自訂資料表格邊框**

使用 [IChart::set_HasDataTable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/set_hasdatatable/) 啟用表格，並透過 [IChart::get_ChartDataTable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_chartdatatable/) 取得。您可以獨立控制三種邊框：

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) 控制水平儲存格邊框。
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) 控制垂直儲存格邊框。
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) 控制表格的外框邊框。

將 `true` 傳遞給各設定子以顯示相應邊框，或傳遞 `false` 隱藏。以下範例建立一個預設資料的叢集柱狀圖，顯示水平邊框與外框，並隱藏垂直邊框。此範例不需要輸入檔案。圖表的位置與尺寸以點為單位指定。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

以下比較使用相同的圖表資料與圖例鍵設定，分為四種情況。從全部啟用邊框開始，每個變體僅停用一種邊框設定。左下角的變體與範例中的邊框設定相同。

![所有邊框已啟用、未啟用水平邊框、未啟用垂直邊框、未啟用外框的圖表資料表格](data-table-borders.png)

## **顯示或隱藏圖例鍵**

圖例鍵是資料表格中系列名稱旁的彩色小標記。它們可協助讀者將每一列與圖表系列對應。將 `true` 傳遞給 [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) 以顯示這些標記，或傳遞 `false` 隱藏它們。

圖表的獨立圖例由 [IChart::set_HasLegend](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/set_haslegend/) 控制。這兩者設定互不影響：隱藏獨立圖例不會隱藏資料表格內的鍵，隱藏表格的鍵亦不會隱藏獨立圖例。

以下範例建立一個預設資料的圖表，啟用其資料表格，並在表格內顯示圖例鍵，同時隱藏獨立圖例。所有表格邊框皆明確啟用。此範例不需要輸入簡報。若僅想隱藏表格的鍵，請將 `false` 傳遞給 [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/idatatable/set_showlegendkey/)。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

以下比較顯示相同的表格，分別啟用與停用圖例鍵。所有邊框均保持啟用，且獨立圖例在兩種情況下皆隱藏。

![左側顯示圖例鍵、右側隱藏圖例鍵的圖表資料表格](data-table-legend-keys.png)

## **常見問題**

**我能在圖表的資料表格中顯示圖例鍵嗎？**

可以。將 `true` 傳遞給 [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) 以顯示圖例鍵，或傳遞 `false` 隱藏它們。

**在將簡報匯出為 PDF、HTML 或影像時，資料表格會保留嗎？**

會。Aspose.Slides 在匯出至 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/) 或 [images](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 時，會將圖表及其顯示的資料表格作為投影片的一部份呈現。

**我能在從範本載入的圖表中使用資料表格嗎？**

可以。對於從現有簡報或範本載入的圖表，使用 [IChart::get_HasDataTable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_hasdatatable/) 檢查其資料表格是否顯示，並使用 [IChart::set_HasDataTable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/set_hasdatatable/) 變更其可見性。

**我該如何找出已啟用資料表格的圖表？**

遍歷每張投影片上的形狀，辨識圖表，並檢查其 [IChart::get_HasDataTable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_hasdatatable/) 結果。值為 `true` 表示資料表格已啟用。