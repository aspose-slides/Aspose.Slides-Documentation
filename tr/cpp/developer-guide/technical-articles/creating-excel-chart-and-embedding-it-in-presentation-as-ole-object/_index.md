---
title: Excel Grafikleri Oluşturma ve Sunumlarda OLE Nesneleri Olarak Yerleştirme
type: docs
weight: 40
url: /tr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiği
- grafiği yerleştir
- OLE nesnesi
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ ile Excel grafikleri oluşturun ve bunları PowerPoint ve OpenDocument sunumlarına OLE nesneleri olarak yerleştirin. Adım adım kod örnekli rehber."
---
## **Arka Plan**

PowerPoint'te, düzenlenebilir grafikler kullanarak verileri görsel olarak göstermek yaygın bir uygulamadır. Aspose, Aspose.Cells for C++ ile Excel grafikleri oluşturmayı destekler ve bu grafikler daha sonra Aspose.Slides for C++ aracılığıyla PowerPoint slaytlarına OLE nesnesi olarak yerleştirilebilir. Bu makale, gerekli adımları kapsar ve Aspose.Cells ve Aspose.Slides kullanarak bir Excel grafiği oluşturup bunu bir PowerPoint sunumuna OLE nesnesi olarak yerleştirmek için C++ kod örnekleri sunar.

## **Gerekli Adımlar**

PowerPoint slaytında bir Excel grafiğini OLE nesnesi olarak oluşturup yerleştirmek için aşağıdaki adımların sırasıyla uygulanması gerekir:

1. Aspose.Cells kullanarak bir Excel grafiği oluşturun.
1. Aspose.Cells kullanarak Excel grafiğinin OLE boyutunu ayarlayın.
1. Aspose.Cells ile Excel grafiğinin bir görüntüsünü alın.
1. Aspose.Slides kullanarak Excel grafiğini bir PPTX sunumunda OLE nesnesi olarak yerleştirin.
1. Adım 3'te elde edilen görüntü ile "EMBEDDED OLE OBJECT" görüntüsünü değiştirerek [nesne önizleme sorunu](/slides/tr/cpp/object-preview-issue-when-adding-oleobjectframe/) sorununu giderin.
1. Sunumu PPTX formatında diske kaydedin.

## **Gerekli Adımların Uygulanması**

Yukarıdaki adımların C++ uygulaması aşağıdaki gibidir:

```cpp
// Adım - 1: Aspose.Cells kullanarak bir Excel grafiği oluşturun.
// ---------------------------------------------------
// Bir çalışma kitabı oluşturun.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Bir Excel grafiği ekleyin.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Adım - 2: Aspose.Cells kullanarak grafiğin OLE boyutunu ayarlayın.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Adım - 3: Aspose.Cells ile grafiğin görüntüsünü alın.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Çalışma kitabını bir akışa kaydedin.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Adım - 4 VE 5
// =============
// Adım - 4: Aspose.Slides kullanarak grafiği .ppt sunumunda OLE nesnesi olarak gömün.
// ------------------------------------------------------------------------------------------
// Adım - 5: "EMBEDDED OLE OBJECT" görüntüsünü adım 3'te elde edilen görüntü ile değiştirerek Nesne Önizleme Sorununu giderin.
// --------------------------------------------------------------------------------------------------------------------
// Bir sunum oluşturun.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Çalışma kitabını slayta ekleyin.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Adım - 6: Çıktı sunumunu diske kaydedin.
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
    // Hücre adlarının bir dizisi.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Hücre verilerinin bir dizisi.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Veri ile hücreleri doldurmak için yeni bir çalışma sayfası ekleyin.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Veri sayfasını veriyle doldurun.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Bir grafik sayfası ekleyin.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Veri sayfasından veri serileriyle grafik sayfasına bir grafik ekleyin.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Grafik sayfasını aktif sayfa olarak ayarlayın.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

Yukarıdaki yöntemle oluşturulan sunum, OLE nesnesi çerçevesine çift tıklanarak etkinleştirilebilen bir OLE nesnesi olarak Excel grafiğini içerir.

## **Sonuç**

Aspose.Cells for C++ ile Aspose.Slides for C++'ı birleştirerek, Aspose.Cells tarafından desteklenen herhangi bir Excel grafiğini oluşturabilir ve bu grafiği bir PowerPoint slaytına OLE nesnesi olarak yerleştirebiliriz. Excel grafiğinin OLE boyutu da tanımlanabilir. Son kullanıcılar, Excel grafiğini diğer OLE nesneleri gibi düzenleyebilir.

## **İlgili Bölümler**

- [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/cpp/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Eklerken Nesne Önizleme Sorunu](/slides/tr/cpp/object-preview-issue-when-adding-oleobjectframe/)