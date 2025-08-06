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

The implementation of the above steps in C++ is as under:

```cpp
// Step - 1: Create an Excel chart using Aspose.Cells.
// ---------------------------------------------------
// Create a workbook.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Add an Excel chart.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Step - 2: Set the OLE size of the chart using Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Step - 3: Get the image of the chart with Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Save the workbook to a stream.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Step - 4 AND 5
// ==============
// Step - 4: Embed the chart as an OLE object inside a .ppt presentation using Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Step - 5: Replace the "EMBEDDED OLE OBJECT" image with the image obtained in step 3 to address Object Preview Issue.
// --------------------------------------------------------------------------------------------------------------------
// Create a presentation.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Add the workbook to the slide.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Step - 6: Save the output presentation to disk.
// -----------------------------------------------
presentation->Save(u"OutputChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

```cpp
void AddExcelChartInPresentation(System::SharedPtr<Presentation> presentation, System::SharedPtr<ISlide> slide, 
                                 System::SharedPtr<System::IO::Stream> workbookStream, 
                                 intrusive_ptr<Aspose::Cells::Systems::Drawing::Bitmap> chartImage)
{
    float oleWidth = presentation->get_SlideSize()->get_Size().get_Width();
    float oleHeight = presentation->get_SlideSize()->get_Size().get_Height();
    int32_t x = 0;
    System::ArrayPtr<uint8_t> oleData = System::MakeArray<uint8_t>(workbookStream->get_Length(), 0);
    workbookStream->set_Position(0);
    workbookStream->Read(oleData, 0, oleData->get_Length());

    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(oleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleFrame;
    oleFrame = slide->get_Shapes()->AddOleObjectFrame(static_cast<float>(x), 0.0f, oleWidth, oleHeight, dataInfo);

    intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
    chartImage->Save(cellsOutputStream, Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());

    auto slidesImage = Images::FromStream(ToSlidesMemoryStream(cellsOutputStream));
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(slidesImage));
}
```

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
int32_t AddExcelChartInWorkbook(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t chartRows, int32_t chartCols)
{
    // An array of cell names.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // An array of cell data.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Add a new worksheet to populate cells with data.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Populate the data sheet with data.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Add a chart sheet.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Add a chart to the chart sheet with data series from the data sheet.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Set the chart sheet as an active sheet.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

The presentation created by the above method will contain the Excel chart as an OLE object that can be activated by double-clicking the OLE object frame.

## **Conclusion**

By using Aspose.Cells for C++ together with Aspose.Slides for C++, we can create any Excel chart supported by Aspose.Cells and embed the chart as an OLE object in a PowerPoint slide. The OLE size of the Excel chart can also be defined. End users can then edit the Excel chart like any other OLE object.

## **Related Sections**

[Working Solution for Chart Resizing in PPTX](/slides/cpp/working-solution-for-chart-resizing-in-pptx/)
[Object Preview Issue when Adding OleObjectFrame](/slides/cpp/object-preview-issue-when-adding-oleobjectframe/)
