---
title: 建立 Excel 圖表並將其作為 OLE 物件嵌入簡報
type: docs
weight: 40
url: /zh-hant/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Cells for C++ 建立 Excel 圖表，並將工作簿嵌入 PowerPoint 簡報中，搭配 Aspose.Slides，並包含圖表預覽。"
---
## **概觀**

本文說明如何使用 Aspose.Cells for C++ 建立 Excel 柱狀圖，並將其工作簿嵌入到使用 Aspose.Slides for C++ 的 PowerPoint 簡報中。嵌入的工作簿同時包含來源資料與圖表。獨立的 PNG 預覽會在 OLE 物件被啟動之前於投影片上顯示圖表。

最終得到的是嵌入的 Excel 物件，而非原生的 PowerPoint 圖表。透過 OLE 編輯工作簿需要支援 OLE 啟動的桌面應用程式以及相容的 Excel 安裝。

## **先決條件**

在 C++ 專案中配置 Aspose.Cells for C++ 與 Aspose.Slides for C++ 的標頭檔與函式庫。將範例程式碼放在應用程式的入口點，並將 include 宣告置於檔案層級。使用這些函式庫產生簡報時不需要安裝 Microsoft Office。

不需要任何輸入檔案：範例會在記憶體中建立資料與圖表，然後將 `OutputChart.pptx` 寫入當前工作目錄。於非評估模式執行時請為兩個產品套用授權。

## **內嵌工作方式**

1. 建立包含資料工作表與圖表工作表的工作簿。
1. 將圖表工作表設為作用中，使工作簿開啟時顯示圖表。
1. 設定工作簿的 OLE 顯示範圍，並將圖表渲染為 PNG。
1. 將工作簿以 XLSX 格式儲存於記憶體，並將其位元組嵌入投影片中。
1. 將 PNG 設為 OLE 物件的預覽，並將簡報儲存為 PPTX。

工作簿的顯示範圍與投影片框架的角色不同。[WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) 使用以 0 為起點的起始/結束列與欄索引。相對地，[ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) 需要指定上方列、左側欄、下方列與右側欄。範例以第 55 列與第 25 欄作為右下角界限；這些數值屬於版面配置的選擇，而非資料列或欄的數量。

投影片框架的單位為點 (points)。範例將其縮放至投影片內，置中且保留 PNG 的長寬比，而非將預覽圖拉伸至填滿整個投影片。

## **建立並內嵌圖表**

以下完整範例會在 `DataSheet` 中填入四列五欄的數值。每一列都會成為圖表的一個系列。`ChartSheet` 會在儲存工作簿前被選為作用中工作表。

工作簿會明確以 XLSX 格式儲存，與傳遞給 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) 的 `xlsx` 副檔名相符。PNG 直接從記憶體串流載入，未經中間的 bitmap 轉換。Aspose.Cells 會回傳 byte 向量，範例將其複製到 Aspose.Slides 所接受的陣列型別。請在使用 Aspose.Cells 物件前先初始化，並在這些物件銷毀後釋放其資源。透過 [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) 指定，可取代預設的 OLE 佔位圖。

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// 初始化 Cells 於建立任何物件之前。
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // 渲染圖表預覽並分別序列化可編輯的工作簿。
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // 將 Cells 緩衝區複製到 Slides 使用的陣列型別。
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // 在投影片內適配預覽圖，且不改變長寬比。
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// 釋放 Cells 資源於所有 Cells 物件銷毀之後。
Aspose::Cells::Cleanup();
```

## **預期結果**

`OutputChart.pptx` 包含一張投影片，內有嵌入的 Excel 工作簿與圖表預覽。工作簿包含原始資料以及四個系列的柱狀圖。預覽圖置於投影片中央，並保留其比例。

![Excel欄位圖表作為嵌入工作簿的預覽](excel-chart-ole-preview.png)

在具備 Excel 的相容桌面 PowerPoint 環境中，雙擊該物件即可啟動並編輯嵌入的工作簿。啟動與編輯取決於主機應用程式的 OLE 支援與安全性設定。

## **常見問題**

**為何需要預覽圖像？**

嵌入的工作簿與投影片預覽是獨立的內容。提供圖表圖像可讓投影片顯示圖表，而非預設的「EMBEDDED OLE OBJECT」佔位符。請參閱 [添加 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/)。

**變更程式碼中的工作簿時，預覽會自動更新嗎？**

將預覽視為快照。當以程式方式更新工作簿資料時，需重新產生圖表影像，並同時取代預覽以及嵌入的工作簿資料。

**我可以使用 XLS 而非 XLSX 嗎？**

可以。將工作簿以 XLS 格式儲存，並使用 `xls` 作為嵌入資料的副檔名。副檔名必須與實際的工作簿格式相符；僅更改副檔名並不會轉換資料。

**為何物件在啟動後會改變尺寸？**

主機應用程式在啟動工作簿時，可能會更新 OLE 物件的呈現。工作簿的 OLE 顯示範圍與投影片框架尺寸皆會影響結果。請參閱 [PPTX 圖表大小調整的可行解決方案](/slides/zh-hant/cpp/working-solution-for-chart-resizing-in-pptx/)。

## **相關章節**

- [PPTX 圖表大小調整的可行解決方案](/slides/zh-hant/cpp/working-solution-for-chart-resizing-in-pptx/)
- [添加 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/)