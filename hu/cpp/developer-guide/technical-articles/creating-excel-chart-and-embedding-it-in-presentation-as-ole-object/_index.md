---
title: Excel-diagramok létrehozása és OLE-objektumokként való beágyazása prezentációkba
type: docs
weight: 40
url: /hu/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- diagram beágyazása
- OLE-objektum
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Excel-diagramok létrehozása és OLE-objektumokként való beágyazása PowerPoint és OpenDocument prezentációkba C++‑bal. Lépésről‑lépésre útmutató kódrészletekkel."
---
## **Háttér**

A PowerPoint‑ban gyakori gyakorlat szerkeszthető diagramok használata az adatok grafikus megjelenítéséhez. Az Aspose támogatja az Excel‑diagramok létrehozását az Aspose.Cells for C++ segítségével, és ezeket a diagramokat OLE‑objektumokként be lehet ágyazni a PowerPoint‑diákba az Aspose.Slides for C++ használatával. Ez a cikk bemutatja a szükséges lépéseket, és C++ kódrészleteket biztosít az Excel‑diagram létrehozásához és OLE‑objektumként történő beágyazásához egy PowerPoint‑prezentációba az Aspose.Cells és az Aspose.Slides segítségével.

## **Szükséges lépések**

1. Hozzon létre egy Excel‑diagramot az Aspose.Cells segítségével.
1. Állítsa be az Excel‑diagram OLE‑méretét az Aspose.Cells segítségével.
1. Szerezzen képet az Excel‑diagramból az Aspose.Cells segítségével.
1. Ágyazza be az Excel‑diagramot OLE‑objektumként egy PPTX‑prezentációba az Aspose.Slides segítségével.
1. Cserélje ki a "EMBEDDED OLE OBJECT" képet a 3. lépésben kapott képre, hogy megoldja a [objektum előnézeti probléma](/slides/hu/cpp/object-preview-issue-when-adding-oleobjectframe/) felmerülő problémát.
1. Mentse a prezentációt lemezre PPTX formátumban.

## **A szükséges lépések megvalósítása**

A fenti lépések C++‑os megvalósítása a következő:

```cpp
// 1. lépés: Excel-diagram létrehozása az Aspose.Cells segítségével.
// ---------------------------------------------------
// Munkafüzet létrehozása.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Excel-diagram hozzáadása.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// 2. lépés: A diagram OLE-méretének beállítása az Aspose.Cells segítségével.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// 3. lépés: Diagram képének lekérése az Aspose.Cells segítségével.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Save the workbook to a stream.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// 4. és 5. lépés
// ==============
// 4. lépés: Diagram beágyazása OLE-objektumként egy .ppt prezentációba az Aspose.Slides segítségével.
// ------------------------------------------------------------------------------------------
// 5. lépés: A "EMBEDDED OLE OBJECT" képet cserélje ki a 3. lépésben kapott képre az Objektum előnézeti probléma megoldásához.
// --------------------------------------------------------------------------------------------------------------------
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Prezentáció létrehozása.
// Add the workbook to the slide.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// 6. lépés: A kimeneti prezentáció mentése lemezre.
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
    // Egy cellanév tömb.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Egy cellaadat tömb.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Új munkalap hozzáadása a cellák adatainak feltöltéséhez.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Az adatlap feltöltése adatokkal.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Diagram munkalap hozzáadása.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Diagram hozzáadása a diagram munkalaphoz, adat sorozatokkal az adatlapról.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // A diagram munkalap beállítása aktív munkalappá.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

A fenti módszerrel létrehozott prezentáció tartalmazni fogja az Excel‑diagramot OLE‑objektumként, amely a OLE‑objektumkeretet duplán kattintva aktiválható.

## **Összegzés**

Az Aspose.Cells for C++ és az Aspose.Slides for C++ együtt történő használatával bármely, az Aspose.Cells által támogatott Excel‑diagramot létrehozhatunk, és a diagramot OLE‑objektumként beágyazhatjuk egy PowerPoint‑diára. Az Excel‑diagram OLE‑mérete is definiálható. A végfelhasználók ezután a Excel‑diagramot bármely más OLE‑objektumhoz hasonlóan szerkeszthetik.

## **Kapcsolódó szakaszok**

- [Működő megoldás a diagram átméretezéséhez PPTX-ben](/slides/hu/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Objektum előnézeti probléma OleObjectFrame hozzáadása esetén](/slides/hu/cpp/object-preview-issue-when-adding-oleobjectframe/)