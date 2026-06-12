---
title: "Excel-diagrammen maken en insluiten in presentaties als OLE-objecten"
type: docs
weight: 40
url: /nl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- diagram insluiten
- OLE-object
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Maak Excel-diagrammen en sluit ze in als OLE-objecten in PowerPoint- en OpenDocument-presentaties met C++. Stapsgewijze handleiding met code-voorbeelden."
---
## **Achtergrond**

In PowerPoint is het gebruik van bewerkbare diagrammen om gegevens grafisch weer te geven een gangbare praktijk. Aspose ondersteunt het maken van Excel‑diagrammen met Aspose.Cells for C++, en deze diagrammen kunnen vervolgens als OLE‑objecten in PowerPoint‑dia's worden ingebed via Aspose.Slides for C++. Dit artikel beschrijft de benodigde stappen en levert C++‑codevoorbeelden voor het maken van een Excel‑diagram en het embedden ervan als OLE‑object in een PowerPoint‑presentatie met Aspose.Cells en Aspose.Slides.

## **Vereiste stappen**

De volgende opeenvolging van stappen is vereist om een Excel‑diagram als OLE‑object in een PowerPoint‑dia te maken en in te sluiten:

1. Maak een Excel‑diagram met Aspose.Cells.
2. Stel de OLE‑grootte van het Excel‑diagram in met Aspose.Cells.
3. Haal een afbeelding van het Excel‑diagram op met Aspose.Cells.
4. Implementeer het Excel‑diagram als OLE‑object in een PPTX‑presentatie met Aspose.Slides.
5. Vervang de afbeelding “EMBEDDED OLE OBJECT” door de afbeelding die in stap 3 is verkregen om het [probleem met voorbeeldweergave van object](/slides/nl/cpp/object-preview-issue-when-adding-oleobjectframe/) op te lossen.
6. Sla de presentatie op schijf op in PPTX‑indeling.

## **Implementatie van de vereiste stappen**

De C++‑implementatie van de bovenstaande stappen is als volgt:

```cpp
// Stap - 1: Een Excel-diagram maken met Aspose.Cells.
// ---------------------------------------------------
// Maak een werkmap aan.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Voeg een Excel-diagram toe.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Stap - 2: De OLE-grootte van het diagram instellen met Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Stap - 3: De afbeelding van het diagram ophalen met Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Save the workbook to a stream.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Stap - 4 EN 5
// ==============
 // Stap - 4: Het diagram insluiten als OLE-object in een .ppt-presentatie met Aspose.Slides.
// ------------------------------------------------------------------------------------------
 // Stap - 5: Vervang de afbeelding “EMBEDDED OLE OBJECT” door de afbeelding die in stap 3 is verkregen om het probleem met voorbeeldweergave van objecten op te lossen.
// --------------------------------------------------------------------------------------------------------------------
 // Maak een presentatie aan.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Voeg de werkmap toe aan de dia.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Stap - 6: De resulterende presentatie opslaan op schijf.
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
    // Een array van celnamen.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Een array van celdata.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Voeg een nieuw werkblad toe om cellen te vullen met gegevens.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Vul het datablad met gegevens.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Voeg een diagramblad toe.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Voeg een diagram toe aan het diagramblad met dataseries uit het datablad.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Stel het diagramblad in als actief blad.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

De presentatie die met bovenstaande methode wordt aangemaakt bevat het Excel‑diagram als OLE‑object dat kan worden geactiveerd door dubbel te klikken op het OLE‑objectframe.

## **Conclusie**

Door Aspose.Cells for C++ te combineren met Aspose.Slides for C++ kunnen we elk door Aspose.Cells ondersteund Excel‑diagram maken en het diagram als OLE‑object in een PowerPoint‑dia embedden. De OLE‑grootte van het Excel‑diagram kan bovendien worden gedefinieerd. Eindgebruikers kunnen vervolgens het Excel‑diagram bewerken zoals elk ander OLE‑object.

## **Gerelateerde secties**

- [Werkende oplossing voor het schalen van diagrammen in PPTX](/slides/nl/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Probleem met voorbeeldweergave van object bij toevoegen van OleObjectFrame](/slides/nl/cpp/object-preview-issue-when-adding-oleobjectframe/)