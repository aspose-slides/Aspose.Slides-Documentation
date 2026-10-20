---
title: Buat Grafik Excel dan Sematkan dalam Presentasi sebagai Objek OLE
type: docs
weight: 40
url: /id/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafik Excel
- sematkan grafik
- objek OLE
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Buat grafik Excel dengan Aspose.Cells untuk C++ dan sematkan workbook di presentasi PowerPoint dengan Aspose.Slides, termasuk pratinjau grafik."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat grafik kolom Excel dengan Aspose.Cells untuk C++ dan menyematkan workbook‑nya dalam presentasi PowerPoint dengan Aspose.Slides untuk C++. Workbook yang disematkan berisi data sumber dan grafik. Pratinjau PNG terpisah menampilkan grafik pada slide sebelum objek OLE diaktifkan.

Hasilnya adalah objek Excel yang disematkan, bukan grafik PowerPoint asli. Mengedit workbook melalui OLE memerlukan aplikasi desktop yang mendukung aktivasi OLE dan instalasi Excel yang kompatibel.

## **Prasyarat**

Konfigurasikan proyek C++ Anda dengan header dan pustaka untuk Aspose.Cells untuk C++ dan Aspose.Slides untuk C++. Letakkan kode contoh di titik masuk aplikasi Anda, dengan deklarasi include pada lingkup file. Microsoft Office tidak diperlukan untuk menghasilkan presentasi dengan pustaka ini.

Tidak diperlukan file input: contoh membuat data dan grafik di memori, kemudian menulis `OutputChart.pptx` ke direktori kerja saat ini. Terapkan lisensi untuk kedua produk saat dijalankan di luar mode evaluasi.

## **Cara Kerja Penyematan**

1. Buat workbook dengan lembar kerja data dan lembar grafik.  
1. Aktifkan lembar grafik sehingga workbook terbuka pada grafik.  
1. Atur rentang tampilan OLE workbook dan render grafik ke PNG.  
1. Simpan workbook sebagai XLSX dalam memori dan sematkan byte‑byte tersebut ke slide.  
1. Tetapkan PNG sebagai pratinjau objek OLE dan simpan presentasi sebagai PPTX.

Rentang tampilan workbook dan bingkai pada slide memiliki peran yang berbeda. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) mengambil indeks baris dan kolom mulai/akhir berbasis nol. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) sebaliknya mengambil baris atas, kolom kiri, baris bawah, dan kolom kanan. Contoh menggunakan indeks baris 55 dan indeks kolom 25 sebagai batas kanan‑bawah; nilai‑nilai ini merupakan pilihan tata letak, bukan jumlah baris atau kolom data.

Bingkai slide menggunakan satuan poin. Contoh menyesuaikannya di dalam slide dan memusatkannya sambil mempertahankan rasio aspek PNG, alih‑alih meregangkan pratinjau untuk mengisi slide.

## **Buat dan Sematkan Grafik**

Contoh lengkap berikut mengisi `DataSheet` dengan empat baris dan lima kolom nilai. Setiap baris menjadi satu seri grafik. `ChartSheet` dipilih sebagai lembar aktif sebelum workbook disimpan.

Workbook secara eksplisit disimpan sebagai XLSX, sesuai dengan ekstensi `xlsx` yang diberikan ke [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG dimuat dari aliran memori tanpa konversi bitmap menengah. Aspose.Cells mengembalikan vektor byte, yang kemudian contoh salin ke tipe array yang diterima oleh Aspose.Slides. Inisialisasi Aspose.Cells sebelum menggunakan objeknya, dan lepaskan sumber dayanya setelah objek‑objek tersebut dihancurkan. Menetapkannya melalui [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) menggantikan placeholder OLE default.

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

// Inisialisasi Cells sebelum membuat objek apa pun.
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

    // Render pratinjau grafik dan serialisasi workbook yang dapat diedit secara terpisah.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Salin buffer Cells ke tipe array yang digunakan oleh Slides.
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

    // Sesuaikan pratinjau dalam slide tanpa mengubah rasio aspeknya.
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
// Lepaskan sumber daya Cells setelah semua objek Cells dihancurkan.
Aspose::Cells::Cleanup();
```

## **Hasil yang Diharapkan**

`OutputChart.pptx` berisi satu slide dengan workbook Excel yang disematkan dan pratinjau grafik. Workbook berisi data asli dan grafik kolom dengan empat seri. Pratinjau dipusatkan pada slide dan mempertahankan proporsinya.

![Grafik kolom Excel yang ditampilkan sebagai pratinjau workbook yang disematkan](excel-chart-ole-preview.png)

Di lingkungan desktop PowerPoint yang kompatibel dengan Excel tersedia, klik ganda objek untuk mengaktifkan dan mengedit workbook yang disematkan. Aktivasi dan penyuntingan bergantung pada dukungan OLE aplikasi host serta pengaturan keamanannya.

## **FAQ**

**Mengapa diperlukan gambar pratinjau?**

Workbook yang disematkan dan pratinjau slide‑nya adalah konten terpisah. Sediakan gambar grafik sehingga slide menampilkan grafik alih‑alih placeholder default "EMBEDDED OLE OBJECT". Lihat [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Apakah pratinjau diperbarui secara otomatis saat saya mengubah workbook dalam kode?**

Anggap pratinjau sebagai snapshot. Saat memperbarui data workbook secara programatis, hasilkan kembali gambar grafik dan ganti pratinjau serta data workbook yang disematkan.

**Bisakah saya menggunakan XLS alih‑alih XLSX?**

Ya. Simpan workbook dalam format XLS dan gunakan `xls` sebagai ekstensi data yang disematkan. Ekstensi harus sesuai dengan format workbook yang sebenarnya; mengubah ekstensi saja tidak mengonversi data.

**Mengapa objek dapat berubah ukuran setelah aktivasi?**

Aplikasi host dapat memperbarui tampilan objek OLE ketika mengaktifkan workbook. Rentang tampilan OLE workbook dan dimensi bingkai slide keduanya berpengaruh. Lihat [Solusi Bekerja untuk Mengubah Ukuran Grafik di PPTX](/slides/id/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Bagian Terkait**

- [Solusi Bekerja untuk Mengubah Ukuran Grafik di PPTX](/slides/id/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/cpp/object-preview-issue-when-adding-oleobjectframe/)