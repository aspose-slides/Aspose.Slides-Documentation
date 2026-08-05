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
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Create Excel charts and embed them as OLE objects in PowerPoint and OpenDocument presentations with C++. Step-by-step guide with code samples."
---

## **Background**

In PowerPoint, using editable charts to display data graphically is a common practice. Aspose supports creating Excel charts with Aspose.Cells for C++, and these charts can then be embedded as OLE objects in PowerPoint slides through Aspose.Slides for C++. This article covers the necessary steps and provides C++ code samples for creating an Excel chart and embedding it as an OLE object in a PowerPoint presentation using Aspose.Cells and Aspose.Slides.

## **Required Steps**

The following sequence of steps is required to create and embed an Excel chart as an OLE object in a PowerPoint slide:

1. Create an Excel chart using Aspose.Cells.
1. Set the OLE size of the Excel chart using Aspose.Cells.
1. Get an image of the Excel chart with Aspose.Cells.
1. Embed the Excel chart as an OLE object in a PPTX presentation using Aspose.Slides.
1. Replace the "EMBEDDED OLE OBJECT" image with the image obtained in step 3 to address the [object preview issue](/slides/cpp/object-preview-issue-when-adding-oleobjectframe/).
1. Save the presentation to disk in PPTX format.

## **Implementation of the Required Steps**

The C++ implementation of the above steps is as follows:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;

// Aspose.Cells for C++ must be started before any of its types are used.
Aspose::Cells::Startup();

// Step - 1: Create an Excel chart using Aspose.Cells.
// ---------------------------------------------------
// Create a workbook.
Aspose::Cells::Workbook workbook;
// Add an Excel chart.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Step - 2: Set the OLE size of the chart using Aspose.Cells.
// -----------------------------------------------------------
workbook.GetWorksheets().SetOleSize(0, chartRows, 0, chartCols);

// Step - 3: Get the image of the chart with Aspose.Cells.
// -------------------------------------------------------
Aspose::Cells::Vector<uint8_t> chartImage = workbook.GetWorksheets().Get(chartSheetIndex)
    .GetCharts().Get(0).ToImage(Aspose::Cells::Drawing::ImageType::Png);
// Save the workbook to a buffer.
Aspose::Cells::Vector<uint8_t> workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);

// Step - 4 AND 5
// ==============
// Step - 4: Embed the chart as an OLE object inside a .ppt presentation using Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Step - 5: Replace the "EMBEDDED OLE OBJECT" image with the image obtained in step 3 to address Object Preview Issue.
// --------------------------------------------------------------------------------------------------------------------
// Create a presentation.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);
// Add the workbook to the slide.
AddExcelChartInPresentation(presentation, slide, workbookData, chartImage);

// Step - 6: Save the output presentation to disk.
// -----------------------------------------------
presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/io/memory_stream.h>
#include "Aspose.Cells/Vector.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

void AddExcelChartInPresentation(System::SharedPtr<Presentation> presentation, System::SharedPtr<ISlide> slide,
                                 const Aspose::Cells::Vector<uint8_t>& workbookData,
                                 const Aspose::Cells::Vector<uint8_t>& chartImage)
{
    float oleWidth = presentation->get_SlideSize()->get_Size().get_Width();
    float oleHeight = presentation->get_SlideSize()->get_Size().get_Height();
    int32_t x = 0;

    System::SharedPtr<OleEmbeddedDataInfo> dataInfo =
        System::MakeObject<OleEmbeddedDataInfo>(ToSlidesArray(workbookData), u"xls");
    System::SharedPtr<IOleObjectFrame> oleFrame;
    oleFrame = slide->get_Shapes()->AddOleObjectFrame(static_cast<float>(x), 0.0f, oleWidth, oleHeight, dataInfo);

    auto imageStream = System::MakeObject<System::IO::MemoryStream>(ToSlidesArray(chartImage));
    auto slidesImage = Images::FromStream(imageStream);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(slidesImage));
}
```

```cpp
#include <system/array.h>
#include "Aspose.Cells/Vector.h"

// Aspose.Cells for C++ hands back raw buffers as Aspose::Cells::Vector<uint8_t>, while
// Aspose.Slides for C++ consumes System::ArrayPtr<uint8_t>. This helper copies between them.
System::ArrayPtr<uint8_t> ToSlidesArray(const Aspose::Cells::Vector<uint8_t>& buffer)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
    std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), outputBuffer->data_ptr());

    return outputBuffer;
}
```

``` cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

int32_t AddExcelChartInWorkbook(Aspose::Cells::Workbook& workbook, int32_t chartRows, int32_t chartCols)
{
    // An array of cell names.
    const char16_t* cellNames[] =
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    };
    
    // An array of cell data.
    int32_t cellValues[] =
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    };

    // Add a new worksheet to populate cells with data.
    int32_t dataSheetIndex = workbook.GetWorksheets().Add();
    Aspose::Cells::Worksheet dataSheet = workbook.GetWorksheets().Get(dataSheetIndex);
    Aspose::Cells::U16String sheetName(u"DataSheet");
    dataSheet.SetName(sheetName);

    // Populate the data sheet with data.
    for (size_t i = 0; i < sizeof(cellValues) / sizeof(cellValues[0]); i++)
    {
        const char16_t* cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet.GetCells().Get(cellName).PutValue(cellValue);
    }

    // Add a chart sheet.
    int32_t chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    Aspose::Cells::Worksheet chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    // Add a chart to the chart sheet with data series from the data sheet.
    int32_t chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, chartRows, 0, chartCols);
    Aspose::Cells::Charts::Chart chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(sheetName + u"!A1:E1", false);
    chart.GetNSeries().Add(sheetName + u"!A2:E2", false);
    chart.GetNSeries().Add(sheetName + u"!A3:E3", false);
    chart.GetNSeries().Add(sheetName + u"!A4:E4", false);

    // Set the chart sheet as an active sheet.
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

The presentation created by the above method will contain the Excel chart as an OLE object that can be activated by double-clicking the OLE object frame.

## **Conclusion**

By using Aspose.Cells for C++ together with Aspose.Slides for C++, we can create any Excel chart supported by Aspose.Cells and embed the chart as an OLE object in a PowerPoint slide. The OLE size of the Excel chart can also be defined. End users can then edit the Excel chart like any other OLE object.

## **Related Sections**

- [Working Solution for Chart Resizing in PPTX](/slides/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/cpp/object-preview-issue-when-adding-oleobjectframe/)
