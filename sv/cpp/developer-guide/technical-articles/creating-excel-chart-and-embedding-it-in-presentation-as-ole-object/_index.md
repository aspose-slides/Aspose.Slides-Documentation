---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 40
url: /sv/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Skapa Excel-diagram och bädda in dem som OLE-objekt i PowerPoint- och OpenDocument-presentationer med C++. Steg-för-steg-guide med kodexempel."
---
## **Bakgrund**

I PowerPoint är det vanligt att använda redigerbara diagram för att visuellt visa data. Aspose stöder skapande av Excel-diagram med Aspose.Cells för C++, och dessa diagram kan sedan bäddas in som OLE-objekt i PowerPoint-bilder via Aspose.Slides för C++. Den här artikeln beskriver de nödvändiga stegen och ger C++-kodexempel för att skapa ett Excel-diagram och bädda in det som ett OLE-objekt i en PowerPoint-presentation med Aspose.Cells och Aspose.Slides.

## **Nödvändiga steg**

Följande sekvens av steg krävs för att skapa och bädda in ett Excel-diagram som ett OLE-objekt i en PowerPoint-bild:

1. Skapa ett Excel-diagram med Aspose.Cells.
1. Ställ in OLE-storleken för Excel-diagrammet med Aspose.Cells.
1. Hämta en bild av Excel-diagrammet med Aspose.Cells.
1. Bädda in Excel-diagrammet som ett OLE-objekt i en PPTX-presentation med Aspose.Slides.
1. Byt ut bilden "EMBEDDED OLE OBJECT" mot bilden som erhölls i steg 3 för att åtgärda [object preview issue](/slides/sv/cpp/object-preview-issue-when-adding-oleobjectframe/).
1. Spara presentationen till disk i PPTX-format.

## **Implementering av de nödvändiga stegen**

C++-implementeringen av stegen ovan är följande:

```cpp
// Steg - 1: Skapa ett Excel-diagram med Aspose.Cells.
// ---------------------------------------------------
// Skapa en arbetsbok.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Lägg till ett Excel-diagram.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Steg - 2: Ställ in OLE-storleken för diagrammet med Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Steg - 3: Hämta bilden av diagrammet med Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Spara arbetsboken till en ström.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Steg - 4 OCH 5
// ==============
 // Steg - 4: Bädda in diagrammet som ett OLE-objekt i en .ppt-presentation med Aspose.Slides.
// ------------------------------------------------------------------------------------------
 // Steg - 5: Ersätt bilden "EMBEDDED OLE OBJECT" med bilden som hämtades i steg 3 för att åtgärda problem med förhandsgranskning av objekt.
// --------------------------------------------------------------------------------------------------------------------
 // Skapa en presentation.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Lägg till arbetsboken på bilden.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Steg - 6: Spara den färdiga presentationen till disk.
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

```cpp
int32_t AddExcelChartInWorkbook(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t chartRows, int32_t chartCols)
{
    // En array med cellnamn.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // En array med celldata.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Lägg till ett nytt kalkylblad för att fylla celler med data.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Fyll datasheetet med data.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Lägg till ett diagramblad.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Lägg till ett diagram på diagrambladet med dataserier från datasheetet.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Ange diagrambladet som aktivt blad.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

Presentationen som skapas med metoden ovan kommer att innehålla Excel-diagrammet som ett OLE-objekt som kan aktiveras genom att dubbelklicka på OLE-objekt-ramen.

## **Slutsats**

Genom att använda Aspose.Cells för C++ tillsammans med Aspose.Slides för C++ kan vi skapa vilket Excel-diagram som helst som stöds av Aspose.Cells och bädda in diagrammet som ett OLE-objekt i en PowerPoint-bild. OLE-storleken för Excel-diagrammet kan också definieras. Slutanvändare kan sedan redigera Excel-diagrammet som vilket annat OLE-objekt som helst.

## **Relaterade avsnitt**

- [Fungerande lösning för diagramändring i PPTX](/slides/sv/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problem med förhandsgranskning av objekt när OleObjectFrame läggs till](/slides/sv/cpp/object-preview-issue-when-adding-oleobjectframe/)