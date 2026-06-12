---
title: Buat Grafik Excel dan Sematkan ke Presentasi sebagai Objek OLE
type: docs
weight: 40
url: /id/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafik Excel
- sematkan grafik
- objek OLE
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Buat grafik Excel dan sematkan sebagai objek OLE dalam presentasi PowerPoint dan OpenDocument dengan C++. Panduan langkah demi langkah dengan contoh kode."
---
## **Latar Belakang**

Di PowerPoint, menggunakan grafik yang dapat diedit untuk menampilkan data secara visual merupakan praktik umum. Aspose mendukung pembuatan grafik Excel dengan Aspose.Cells untuk C++, dan grafik ini kemudian dapat disematkan sebagai objek OLE dalam slide PowerPoint melalui Aspose.Slides untuk C++. Artikel ini menjelaskan langkah‑langkah yang diperlukan dan menyediakan contoh kode C++ untuk membuat grafik Excel dan menyematkannya sebagai objek OLE dalam presentasi PowerPoint menggunakan Aspose.Cells dan Aspose.Slides.

## **Langkah-Langkah yang Diperlukan**

Urutan langkah berikut diperlukan untuk membuat dan menyematkan grafik Excel sebagai objek OLE dalam slide PowerPoint:

1. Buat grafik Excel menggunakan Aspose.Cells.
1. Atur ukuran OLE grafik Excel menggunakan Aspose.Cells.
1. Dapatkan gambar grafik Excel dengan Aspose.Cells.
1. Sematkan grafik Excel sebagai objek OLE dalam presentasi PPTX menggunakan Aspose.Slides.
1. Ganti gambar "EMBEDDED OLE OBJECT" dengan gambar yang diperoleh pada langkah 3 untuk mengatasi [object preview issue](/slides/id/cpp/object-preview-issue-when-adding-oleobjectframe/).
1. Simpan presentasi ke disk dalam format PPTX.

## **Implementasi Langkah-Langkah yang Diperlukan**

Implementasi C++ untuk langkah‑langkah di atas adalah sebagai berikut:

```cpp
// Langkah - 1: Buat grafik Excel menggunakan Aspose.Cells.
// ---------------------------------------------------
// Buat workbook.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Tambahkan grafik Excel.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Langkah - 2: Atur ukuran OLE grafik menggunakan Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Langkah - 3: Dapatkan gambar grafik dengan Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Simpan workbook ke stream.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Langkah - 4 DAN 5
// ==============
 // Langkah - 4: Sematkan grafik sebagai objek OLE di dalam presentasi .ppt menggunakan Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Langkah - 5: Ganti gambar "EMBEDDED OLE OBJECT" dengan gambar yang diperoleh pada langkah 3 untuk mengatasi masalah Pratinjau Objek.
// --------------------------------------------------------------------------------------------------------------------
 // Buat presentasi.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Tambahkan workbook ke slide.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Langkah - 6: Simpan presentasi output ke disk.
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
    // Array nama sel.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Array data sel.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Tambahkan lembar kerja baru untuk mengisi sel dengan data.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Isi lembar data dengan data.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Tambahkan lembar grafik.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Tambahkan grafik ke lembar grafik dengan rangkaian data dari lembar data.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Atur lembar grafik sebagai lembar aktif.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

Presentasi yang dibuat dengan metode di atas akan berisi grafik Excel sebagai objek OLE yang dapat diaktifkan dengan mengklik ganda bingkai objek OLE.

## **Kesimpulan**

Dengan menggunakan Aspose.Cells untuk C++ bersama Aspose.Slides untuk C++, kita dapat membuat grafik Excel apa pun yang didukung oleh Aspose.Cells dan menyematkan grafik tersebut sebagai objek OLE dalam slide PowerPoint. Ukuran OLE grafik Excel juga dapat didefinisikan. Pengguna akhir kemudian dapat mengedit grafik Excel seperti objek OLE lainnya.

## **Bagian Terkait**

- [Working Solution for Chart Resizing in PPTX](/slides/id/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/id/cpp/object-preview-issue-when-adding-oleobjectframe/)