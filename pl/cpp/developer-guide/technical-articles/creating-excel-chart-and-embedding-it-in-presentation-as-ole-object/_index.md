---
title: Tworzenie wykresów Excel i osadzanie ich w prezentacjach jako obiekty OLE
type: docs
weight: 40
url: /pl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Wykres Excel
- osadzanie wykresu
- obiekt OLE
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Twórz wykresy Excel i osadzaj je jako obiekty OLE w prezentacjach PowerPoint i OpenDocument przy użyciu C++. Przewodnik krok po kroku z przykładami kodu."
---
## **Tło**

W programie PowerPoint powszechną praktyką jest używanie edytowalnych wykresów do graficznego przedstawiania danych. Aspose umożliwia tworzenie wykresów Excel przy użyciu Aspose.Cells dla C++, a następnie ich osadzanie jako obiektów OLE w slajdach PowerPoint przy pomocy Aspose.Slides dla C++. Ten artykuł opisuje niezbędne kroki i zawiera przykłady kodu w C++ dotyczące tworzenia wykresu Excel oraz osadzania go jako obiektu OLE w prezentacji PowerPoint przy użyciu Aspose.Cells i Aspose.Slides.

## **Wymagane kroki**

Kolejność działań potrzebna do utworzenia i osadzenia wykresu Excel jako obiektu OLE w slajdzie PowerPoint:

1. Utwórz wykres Excel przy użyciu Aspose.Cells.
1. Ustaw rozmiar OLE wykresu Excel przy użyciu Aspose.Cells.
1. Pobierz obraz wykresu Excel za pomocą Aspose.Cells.
1. Osadź wykres Excel jako obiekt OLE w prezentacji PPTX przy użyciu Aspose.Slides.
1. Zastąp obraz „EMBEDDED OLE OBJECT” obrazem uzyskanym w kroku 3, aby rozwiązać [object preview issue](/slides/pl/cpp/object-preview-issue-when-adding-oleobjectframe/).
1. Zapisz prezentację na dysku w formacie PPTX.

## **Implementacja wymaganych kroków**

Implementacja w C++ powyższych kroków przedstawia się następująco:

```cpp
// Krok - 1: Utwórz wykres Excel przy użyciu Aspose.Cells.
// ---------------------------------------------------
// Utwórz skoroszyt.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Dodaj wykres Excel.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Krok - 2: Ustaw rozmiar OLE wykresu przy użyciu Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Krok - 3: Pobierz obraz wykresu przy użyciu Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Zapisz skoroszyt do strumienia.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Krok - 4 I 5
// ==============
// Krok - 4: Osadź wykres jako obiekt OLE w prezentacji .ppt przy użyciu Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Krok - 5: Zastąp obraz "EMBEDDED OLE OBJECT" obrazem uzyskanym w kroku 3, aby rozwiązać problem podglądu obiektu.
// --------------------------------------------------------------------------------------------------------------------
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
// Utwórz prezentację.
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Dodaj skoroszyt do slajdu.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Krok - 6: Zapisz wynikową prezentację na dysku.
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
    // Tablica nazw komórek.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Tablica danych komórek.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Dodaj nowy arkusz, aby wypełnić komórki danymi.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Wypełnij arkusz danymi.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Dodaj arkusz wykresu.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Dodaj wykres do arkusza wykresu z serią danych z arkusza danych.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Ustaw arkusz wykresu jako aktywny.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

Prezentacja utworzona w powyższy sposób będzie zawierać wykres Excel jako obiekt OLE, który można aktywować podwójnym kliknięciem ramki obiektu OLE.

## **Podsumowanie**

Korzystając z Aspose.Cells dla C++ oraz Aspose.Slides dla C++, możemy utworzyć dowolny wykres Excel obsługiwany przez Aspose.Cells i osadzić go jako obiekt OLE w slajdzie PowerPoint. Można również określić rozmiar OLE wykresu Excel. Użytkownicy końcowi mogą następnie edytować wykres Excel tak jak każdy inny obiekt OLE.

## **Powiązane sekcje**

- [Working Solution for Chart Resizing in PPTX](/slides/pl/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/pl/cpp/object-preview-issue-when-adding-oleobjectframe/)