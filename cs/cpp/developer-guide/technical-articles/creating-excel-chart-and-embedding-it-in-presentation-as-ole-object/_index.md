---
title: Vytvoření grafů Excel a vložení do prezentací jako objekty OLE
type: docs
weight: 40
url: /cs/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel graf
- vložit graf
- objekt OLE
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte grafy Excel a vložte je jako objekty OLE do prezentací PowerPoint a OpenDocument v C++. Průvodce krok za krokem s ukázkami kódu."
---
## **Pozadí**

V PowerPointu je běžnou praxí používat editovatelné grafy k vizuálnímu zobrazování dat. Aspose podporuje vytváření grafů Excel pomocí Aspose.Cells pro C++, a tyto grafy mohou být následně vloženy jako objekty OLE do snímků PowerPointu prostřednictvím Aspose.Slides pro C++. Tento článek popisuje potřebné kroky a poskytuje ukázky kódu C++ pro vytváření grafu Excel a jeho vložení jako objekt OLE do prezentace PowerPoint pomocí Aspose.Cells a Aspose.Slides.

## **Požadované kroky**

Následující posloupnost kroků je vyžadována k vytvoření a vložení grafu Excel jako objektu OLE do snímku PowerPoint:

1. Vytvořte graf Excel pomocí Aspose.Cells.
1. Nastavte velikost OLE grafu Excel pomocí Aspose.Cells.
1. Získejte obrázek grafu Excel pomocí Aspose.Cells.
1. Vložte graf Excel jako objekt OLE do prezentace PPTX pomocí Aspose.Slides.
1. Nahraďte obrázek „EMBEDDED OLE OBJECT“ obrázkem získaným ve třetím kroku, aby se vyřešil [object preview issue](/slides/cs/cpp/object-preview-issue-when-adding-oleobjectframe/).
1. Uložte prezentaci na disk ve formátu PPTX.

## **Implementace požadovaných kroků**

Implementace v C++ výše uvedených kroků je následující:

```cpp
// Krok - 1: Vytvořit graf Excel pomocí Aspose.Cells.
// ---------------------------------------------------
// Vytvořte sešit.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Přidejte graf Excel.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Krok - 2: Nastavte velikost OLE grafu pomocí Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Krok - 3: Získejte obrázek grafu pomocí Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Uložte sešit do proudu.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Krok - 4 A 5
// ==============
// Krok - 4: Vložte graf jako objekt OLE do prezentace .ppt pomocí Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Krok - 5: Nahraďte obrázek "EMBEDDED OLE OBJECT" obrázkem získaným ve kroku 3, aby se vyřešil problém s náhledem objektu.
// --------------------------------------------------------------------------------------------------------------------
// Vytvořte prezentaci.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Přidejte sešit do snímku.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Krok - 6: Uložte výstupní prezentaci na disk.
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
    // Pole názvů buněk.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Pole dat buněk.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Přidat nový list pro naplnění buněk daty.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Naplnit datový list daty.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Přidat list s grafem.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Přidat graf do listu s grafem s datovými řadami z datového listu.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Nastavit list s grafem jako aktivní list.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

Prezentace vytvořená výše uvedeným způsobem bude obsahovat graf Excel jako objekt OLE, který lze aktivovat dvojitým kliknutím na rámec objektu OLE.

## **Závěr**

Pomocí Aspose.Cells pro C++ společně s Aspose.Slides pro C++ můžeme vytvořit jakýkoli graf Excel podporovaný Aspose.Cells a vložit jej jako objekt OLE do snímku PowerPointu. Velikost OLE grafu Excel lze také definovat. Koneční uživatelé pak mohou upravovat graf Excel jako jakýkoli jiný objekt OLE.

## **Související sekce**

- [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/cpp/object-preview-issue-when-adding-oleobjectframe/)