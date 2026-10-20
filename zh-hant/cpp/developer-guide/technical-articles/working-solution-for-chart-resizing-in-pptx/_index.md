---
title: 在 PPTX 中圖表調整大小的可行解決方案
type: docs
weight: 60
url: /zh-hant/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 嵌入的 Excel OLE 物件時，修復 PPTX 中意外的圖表調整大小。設定固定的圖表尺寸，以保持圖表與 OLE 框的大小一致。"
---
## **背景**

使用 Aspose 元件將 Excel 圖表作為 OLE 物件嵌入 PowerPoint 簡報時，圖表在首次啟用後可能會改變大小。這會導致圖表在啟用前後的外觀出現明顯差異。本文說明產生調整大小的原因，並展示如何透過將固定的圖表尺寸與 OLE 框相匹配來防止此問題。

在[在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)，我們說明了如何使用 Aspose.Cells for C++ 建立 Excel 圖表，並使用 Aspose.Slides for C++ 將其嵌入 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表圖像指派給圖表的 OLE 物件框。在輸出簡報中，當您雙擊顯示圖表圖像的 OLE 物件框時，Excel 圖表會被啟用。使用者可以編輯嵌入的 Excel 活頁簿，然後透過點擊已啟用活頁簿外部返回投影片。使用者返回投影片時，OLE 物件框的大小會發生變化，且調整比例會根據 OLE 物件框與嵌入的 Excel 活頁簿的原始尺寸而異。

## **調整大小的原因**

嵌入的 Excel 活頁簿有其自己的視窗尺寸，Excel 會在物件首次啟用時嘗試保留該尺寸。投影片上的 OLE 框則有獨立定義的尺寸。當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商物件的大小，以在嵌入過程中維持其比例。因此，活頁簿視窗與 OLE 框之間的差異可能導致物件調整大小。

## **可行的解決方案**

將圖表尺寸與投影片上的 OLE 框相匹配，並使圖表尺寸獨立於活頁簿視窗。此解決方案適用於新簡報或現有範本。

此範例需要 Aspose.Cells for C++ 與 Aspose.Slides for C++。它會在活動的圖表工作表上建立簡單的直條圖，並以 XLS 格式嵌入活頁簿。未指派圖表預覽圖像；圖表會在 PowerPoint 中啟用 OLE 物件時顯示。

將範例程式碼放置於應用程式的入口點，並在檔案層級加入宣告。於建立 Aspose.Cells 物件之前先初始化 Aspose.Cells，並於這些物件銷毀後釋放其資源。此範例會將 Aspose.Cells 回傳的活頁簿位元組向量複製到 Aspose.Slides 接受的陣列類型中。

此範例建立一個新的簡報，內含一個 9.5 × 4 吋的 OLE 框，該框距離左邊緣 0.5 吋、距離上方 1 吋。投影片的座標與尺寸以點為單位（每英吋 72 點）。若使用現有簡報，請參閱[使用範本](#use-a-template)。

## **設定固定圖表大小**

將[Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/)設為 false，使圖表尺寸獨立於活頁簿視窗。透過[Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/)和[Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/)設定[Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/)的尺寸，並以每英吋 96 像素將點轉換為像素：684 × 288 點的框相當於 912 × 384 像素的圖表。將[Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/)設定為[PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/)的自訂值。此範例使用[IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/)嵌入活頁簿，並以 9.5 × 4 吋的 OLE 框儲存簡報。

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 投影片座標與尺寸以點為單位（每英吋 72 點）。
    auto width = 684.f; // 9.5 吋。
    auto height = 288.f; // 4 吋。

    chart.SetSizeWithWindow(false);
    // 使用每英吋 96 像素將點轉換為圖表像素。
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // 將 Cells 位元組向量複製到 Slides 接受的陣列類型中。
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **使用範本**

現有簡報的尺寸邏輯相同。若要套用此範例，請依照以下步驟：

1. 載入範本簡報，而非建立空的簡報。  
2. 確認第一張投影片至少包含三個圖形，然後使用索引為 2 的圖形作為佔位符。  
3. 從該圖形取得框的寬度與高度，而非使用固定值 684 與 288。保持尺寸計算不變。  
4. 在佔位符的位置加入 OLE 框，而非使用固定座標 36 與 72。  
5. 在儲存簡報之前移除佔位符。

## **常見問題**

**為何我的嵌入式 Excel 圖表在 PowerPoint 中啟用後會改變大小？**  
這是因為 Excel 會在首次啟用時嘗試恢復原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致調整大小。

**如何保持圖表與 OLE 框的尺寸一致？**  
設定與 OLE 框相匹配的固定圖表尺寸，並在嵌入活頁簿之前使用自訂的圖表列印大小。上述範例展示了所需的設定與單位換算。

**只匹配活頁簿視窗大小是否足夠？**  
僅匹配活頁簿視窗大小無法可靠防止 OLE 框在啟用後改變大小。請使用如範例所示的固定圖表尺寸。

**此解決方案是否同時適用於基於範本的簡報和新簡報？**  
是。對於範本，使用佔位符的尺寸與位置。對於新簡報，直接指定框的尺寸與位置。

**我可以將此範例用於其他試算表程式產生的圖表嗎？**  
此範例使用 Aspose.Cells 建立的 Excel 活頁簿。它未示範其他試算表程式的啟用行為。

## **相關章節**

- [在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)