---
title: Create Excel Charts and Embed Them in Presentations as OLE Objects
type: docs
weight: 40
url: /cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel chart
- embed chart
- OLE object
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Create an Excel chart with Aspose.Cells for C++ and embed the workbook in a PowerPoint presentation with Aspose.Slides, including a chart preview."
---

## **Overview**

This article shows how to create an Excel column chart with Aspose.Cells for C++ and embed its workbook in a PowerPoint presentation with Aspose.Slides for C++. The embedded workbook contains both the source data and the chart. A separate PNG preview displays the chart on the slide before the OLE object is activated.

The result is an embedded Excel object, not a native PowerPoint chart. Editing the workbook through OLE requires a desktop application that supports OLE activation and a compatible Excel installation.

## **Prerequisites**

Configure your C++ project with the headers and libraries for Aspose.Cells for C++ and Aspose.Slides for C++. Place the example code in your application entry point, with the include declarations at file scope. Microsoft Office is not required to generate the presentation with these libraries.

No input files are required: the example creates the data and chart in memory, then writes `OutputChart.pptx` to the current working directory. Apply licenses for both products when running outside evaluation mode.

## **How the Embedding Works**

1. Create a workbook with a data worksheet and a chart sheet.
1. Make the chart sheet active so that the workbook opens on the chart.
1. Set the workbook's OLE display range and render the chart to PNG.
1. Save the workbook as XLSX in memory and embed those bytes in a slide.
1. Assign the PNG as the OLE object's preview and save the presentation as PPTX.

The workbook display range and the frame on the slide have different roles. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) takes zero-based start/end row and column indices. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) instead takes the top row, left column, bottom row, and right column. The example uses row index 55 and column index 25 as the lower-right boundaries; these values are layout choices, not the number of data rows or columns.

The slide frame uses points. The example fits it within the slide and centers it while preserving the PNG's aspect ratio, rather than stretching the preview to fill the slide.

## **Create and Embed the Chart**

The following complete example populates `DataSheet` with four rows and five columns of values. Each row becomes a chart series. `ChartSheet` is selected as the active sheet before the workbook is saved.

The workbook is explicitly saved as XLSX, matching the `xlsx` extension passed to [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). The PNG is loaded from an in-memory stream without an intermediate bitmap conversion. Aspose.Cells returns byte vectors, which the example copies into the array type accepted by Aspose.Slides. Initialize Aspose.Cells before using its objects, and release its resources after those objects have been destroyed. Assigning it through [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) replaces the default OLE placeholder.

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

// Initialize Cells before creating any of its objects.
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

    // Render the chart preview and serialize the editable workbook separately.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Copy Cells buffers into the array type used by Slides.
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

    // Fit the preview within the slide without changing its aspect ratio.
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
// Release Cells resources after all Cells objects have been destroyed.
Aspose::Cells::Cleanup();
```

## **Expected Result**

`OutputChart.pptx` contains one slide with an embedded Excel workbook and a chart preview. The workbook contains the original data and a column chart with four series. The preview is centered on the slide and retains its proportions.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

In a compatible desktop PowerPoint environment with Excel available, double-click the object to activate and edit the embedded workbook. Activation and editing depend on the host application's OLE support and security settings.

## **FAQ**

**Why is a preview image needed?**

The embedded workbook and its slide preview are separate content. Supply a chart image so the slide shows the chart instead of the default "EMBEDDED OLE OBJECT" placeholder. See [Object Preview Issue when Adding OleObjectFrame](/slides/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Does the preview update automatically when I change the workbook in code?**

Treat the preview as a snapshot. When updating workbook data programmatically, regenerate the chart image and replace the preview as well as the embedded workbook data.

**Can I use XLS instead of XLSX?**

Yes. Save the workbook in XLS format and use `xls` as the embedded data extension. The extension must match the actual workbook format; changing the extension alone does not convert the data.

**Why might the object change size after activation?**

The host application can update the OLE object's presentation when it activates the workbook. The workbook's OLE display range and the slide frame dimensions both matter. See [Working Solution for Chart Resizing in PPTX](/slides/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Related Sections**

- [Working Solution for Chart Resizing in PPTX](/slides/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/cpp/object-preview-issue-when-adding-oleobjectframe/)
