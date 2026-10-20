---
title: Solusi Praktis untuk Perubahan Ukuran Diagram di PPTX
type: docs
weight: 60
url: /id/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- pengubahan ukuran diagram
- diagram Excel
- objek OLE
- menyematkan diagram
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Perbaiki perubahan ukuran diagram yang tidak terduga di PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk C++. Tetapkan dimensi diagram tetap untuk menjaga ukuran diagram dan bingkai OLE tetap konsisten."
---
## **Latar Belakang**

Diagram Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat berubah ukuran setelah aktivasi pertama kali. Hal ini dapat menyebabkan perbedaan yang jelas pada tampilan diagram sebelum dan sesudah aktivasi. Artikel ini menjelaskan mengapa perubahan ukuran terjadi dan menunjukkan cara mencegahnya dengan mencocokkan dimensi diagram tetap dengan bingkai OLE.

Dalam [Buat Diagram Excel dan Sematkan Sebagai Objek OLE dalam Presentasi](/slides/id/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat diagram Excel dengan Aspose.Cells untuk C++ dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides untuk C++. Untuk mengatasi [masalah pratinjau objek](/slides/id/cpp/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar diagram ke bingkai objek OLE diagram. Dalam presentasi hasil, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar diagram, diagram Excel diaktifkan. Pengguna dapat mengedit buku kerja Excel yang disematkan dan kemudian kembali ke slide dengan mengklik di luar buku kerja yang diaktifkan. Ukuran bingkai objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik bingkai objek OLE maupun buku kerja Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Buku kerja Excel yang disematkan memiliki dimensi jendela tersendiri, yang coba dipertahankan oleh Excel saat objek pertama kali diaktifkan. Bingkai OLE pada slide memiliki dimensi yang didefinisikan secara independen. Ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi tentang ukuran objek untuk mempertahankan proporsinya sebagai bagian dari proses penyematan. Perbedaan antara jendela buku kerja dan bingkai OLE dapat menyebabkan objek berubah ukuran.

## **Solusi yang Berfungsi**

Cocokkan ukuran diagram dengan bingkai OLE pada slide dan pertahankan dimensi diagram terpisah dari jendela buku kerja. Solusi ini berfungsi dengan presentasi baru atau templat yang ada.

Contoh ini memerlukan Aspose.Cells untuk C++ dan Aspose.Slides untuk C++. Ini membuat diagram batang sederhana pada lembar diagram aktif dan menyematkan buku kerja dalam format XLS. Tidak ada gambar pratinjau diagram yang ditetapkan; diagram menjadi terlihat ketika objek OLE diaktifkan di PowerPoint.

Letakkan kode contoh di titik masuk aplikasi Anda, dengan deklarasi include pada lingkup file. Inisialisasi Aspose.Cells sebelum membuat objeknya dan lepaskan sumber dayanya setelah objek-objek tersebut dihancurkan. Contoh ini menyalin vektor byte buku kerja yang dikembalikan oleh Aspose.Cells ke dalam tipe array yang diterima oleh Aspose.Slides.

Contoh ini membuat presentasi baru dengan bingkai OLE berukuran 9.5 × 4 inci yang ditempatkan 0.5 inci dari tepi kiri dan 1 inci dari atas. Koordinat dan dimensi slide dalam poin (72 poin per inci). Untuk presentasi yang ada, lihat [Gunakan Templat](#use-a-template).

## **Tetapkan Ukuran Diagram Tetap**

Setel [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) ke false sehingga dimensi diagram tidak bergantung pada jendela buku kerja. Setel dimensi [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) melalui [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) dan [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), mengonversi poin ke piksel dengan menggunakan 96 piksel per inci: sebuah bingkai berukuran 684 × 288 poin sesuai dengan diagram berukuran 912 × 384 piksel. Setel [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) ke nilai Custom dari [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). Contoh ini menyematkan buku kerja dengan [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) dan menyimpan presentasi dengan bingkai OLE berukuran 9.5 × 4 inci.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Koordinat slide dan dimensi dalam poin (72 poin per inci).
    auto width = 684.f; // 9,5 inci.
    auto height = 288.f; // 4 inci.

    chart.SetSizeWithWindow(false);
    // Konversi poin ke piksel diagram menggunakan 96 piksel per inci.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Salin vektor byte Cells ke dalam tipe array yang diterima oleh Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Gunakan Templat**

Logika pengukuran ukuran sama untuk presentasi yang sudah ada. Untuk menyesuaikan contoh:

1. Muat presentasi templat alih-alih membuat presentasi kosong.
1. Periksa bahwa slide pertama berisi setidaknya tiga shape, kemudian gunakan shape pada indeks 2 sebagai placeholder.
1. Ambil lebar dan tinggi bingkai dari shape tersebut alih-alih menggunakan nilai tetap 684 dan 288. Pertahankan perhitungan ukuran tidak berubah.
1. Tambahkan bingkai OLE pada posisi placeholder alih-alih koordinat tetap 36 dan 72.
1. Hapus placeholder sebelum menyimpan presentasi.

## **FAQ**

**Mengapa diagram Excel yang saya sematkan berubah ukuran setelah diaktifkan di PowerPoint?**

Ini terjadi karena Excel mencoba mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensinya sendiri. PowerPoint dan Excel bernegosiasi tentang ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Bagaimana saya dapat menjaga ukuran diagram dan bingkai OLE konsisten?**

Tetapkan dimensi diagram tetap yang cocok dengan bingkai OLE dan gunakan ukuran cetak diagram khusus sebelum menyematkan buku kerja. Contoh di atas menunjukkan pengaturan yang diperlukan serta konversi satuan.

**Apakah mencocokkan ukuran jendela buku kerja sudah cukup?**

Mencocokkan ukuran jendela buku kerja saja tidak secara andal mencegah bingkai OLE berubah ukuran setelah aktivasi. Gunakan dimensi diagram tetap seperti yang ditunjukkan pada contoh.

**Apakah solusi ini bekerja dengan presentasi berbasis templat dan presentasi baru?**

Ya. Untuk templat, gunakan dimensi dan posisi placeholder. Untuk presentasi baru, tentukan dimensi dan posisi bingkai secara langsung.

**Bisakah saya menggunakan contoh ini dengan diagram yang dibuat di program spreadsheet lain?**

Contoh ini menggunakan buku kerja Excel yang dibuat dengan Aspose.Cells. Ia tidak menunjukkan perilaku aktivasi untuk program spreadsheet lain.

## **Bagian Terkait**

- [Buat Diagram Excel dan Sematkan Sebagai Objek OLE dalam Presentasi](/slides/id/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)