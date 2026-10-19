---
title: Working Solution for Chart Resizing in PPTX
type: docs
weight: 60
url: /cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- chart resizing
- Excel chart
- OLE object
- embed chart
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Fix unexpected chart resizing in PPTX when using embedded Excel OLE objects with Aspose.Slides for C++. Set fixed chart dimensions to keep the chart and OLE frame sizes consistent."
---

## **Background**

Excel charts embedded as OLE objects in PowerPoint presentations using Aspose components can change size after their first activation. This can cause a noticeable difference in the chart's appearance before and after activation. This article explains why resizing occurs and shows how to prevent it by matching fixed chart dimensions to the OLE frame.

In [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for C++ and embed it in a PowerPoint presentation using Aspose.Slides for C++. To address the [object preview issue](/slides/cpp/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Cause of Resizing**

The embedded Excel workbook has its own window dimensions, which Excel tries to retain when the object is first activated. The OLE frame on the slide has independently defined dimensions. When the Excel workbook is activated, Excel and PowerPoint negotiate the object's size to maintain its proportions as part of the embedding process. Differences between the workbook window and the OLE frame can therefore cause the object to resize.

## **Working Solution**

Match the chart size to the OLE frame on the slide and keep the chart dimensions independent of the workbook window. This solution works with a new presentation or an existing template.

The example requires Aspose.Cells for C++ and Aspose.Slides for C++. It creates a simple column chart on an active chart sheet and embeds the workbook in XLS format. No chart preview image is assigned; the chart becomes visible when the OLE object is activated in PowerPoint.

Place the example code in your application entry point, with the include declarations at file scope. Initialize Aspose.Cells before creating its objects and release its resources after those objects have been destroyed. The example copies the workbook byte vector returned by Aspose.Cells into the array type accepted by Aspose.Slides.

The example creates a new presentation with a 9.5 × 4-inch OLE frame positioned 0.5 inches from the left edge and 1 inch from the top. Slide coordinates and dimensions are in points (72 points per inch). For an existing presentation, see [Use a Template](#use-a-template).

## **Set a Fixed Chart Size**

Set [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) to false so that the chart dimensions are independent of the workbook window. Set the [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) dimensions through [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) and [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) to the Custom value of [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). The example embeds the workbook with [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) and saves a presentation with a 9.5 × 4-inch OLE frame.

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

    // Slide coordinates and dimensions are in points (72 points per inch).
    auto width = 684.f; // 9.5 inches.
    auto height = 288.f; // 4 inches.

    chart.SetSizeWithWindow(false);
    // Convert points to chart pixels using 96 pixels per inch.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Copy the Cells byte vector into the array type accepted by Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Use a Template**

The sizing logic is the same for an existing presentation. To adapt the example:

1. Load the template presentation instead of creating an empty presentation.
1. Check that the first slide contains at least three shapes, then use the shape at index 2 as the placeholder.
1. Take the frame width and height from that shape instead of using the fixed values 684 and 288. Keep the sizing calculations unchanged.
1. Add the OLE frame at the placeholder's position instead of the fixed coordinates 36 and 72.
1. Remove the placeholder before saving the presentation.

## **FAQ**

**Why does my embedded Excel chart change size after activating it in PowerPoint?**

This happens because Excel tries to restore the original window size when first activated, whereas the OLE object frame in PowerPoint has its own dimensions. PowerPoint and Excel negotiate the size to maintain the aspect ratio, which can cause the resizing.

**How can I keep the chart and OLE frame sizes consistent?**

Set fixed chart dimensions that match the OLE frame and use a custom chart print size before embedding the workbook. The example above shows the required settings and unit conversions.

**Is matching the workbook window size sufficient?**

Matching the workbook window size alone does not reliably prevent the OLE frame from changing size after activation. Use fixed chart dimensions as shown in the example.

**Does this solution work with both template-based presentations and new presentations?**

Yes. For a template, use the placeholder's dimensions and position. For a new presentation, specify the frame dimensions and position directly.

**Can I use this example with charts created in other spreadsheet programs?**

The example uses an Excel workbook created with Aspose.Cells. It does not demonstrate activation behavior for other spreadsheet programs.

## **Related Sections**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
