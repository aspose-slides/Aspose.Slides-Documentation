---
title: "Kelola Buku Kerja Bagan dalam Presentasi Menggunakan C++"
linktitle: "Buku Kerja Bagan"
type: docs
weight: 70
url: /id/cpp/chart-workbook/
keywords:
- buku kerja bagan
- data bagan
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache bagan
- pemulihan buku kerja
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Temukan Aspose.Slides untuk C++: kelola buku kerja bagan dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja bagan di Aspose.Slides. Ia menunjukkan cara membaca dan menulis data bagan melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data bagan, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai bagan.

Selain itu, dibahas cara bekerja dengan buku kerja eksternal sebagai sumber data bagan. Contoh-contoh memperlihatkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang ditautkan ke bagan, serta mengedit data bagan ketika buku kerja tersedia.

Untuk sel buku kerja yang merepresentasikan data yang hilang, lihat [Kontrol Tampilan Sel Kosong](/slides/id/cpp/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) untuk mengontrol apakah bagan memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemplotan bagan; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

[presentasi contoh](hidden-source-data.pptx) berisi diagram kolom sebagai bentuk pertama pada slide pertama. Lembar kerja tersemat, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi sel‑nya masih berisi nilai.

| Baris lembar kerja | A: Bulan | B: Eceran | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) dan baca [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) untuk memeriksa status tersembunyi mereka. Properti ini hanya dapat dibaca. Dalam file ini, B2 terlihat, B3 termasuk ke dalam baris tersembunyi, dan C2 termasuk ke dalam kolom tersembunyi; contoh mencetak `False`, `True`, dan `True`, masing‑masing.

Untuk contoh ini, segarkan data bagan setelah mengubah pengaturan pemplotan: pertahankan buku kerja tersemat dengan [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) dan muat kembali dengan [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Saat menyertakan semua sel, juga gunakan [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) untuk memulihkan rentang lengkap, termasuk kategori Februari yang tersembunyi. Sekadar mengubah flag tidak cukup untuk memperbarui data bagan yang di‑cache dan label kategori dalam contoh ini.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // Segarkan data bagan dari buku kerja yang tersemat.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Pulihkan rentang sumber lengkap, termasuk kategori yang tersembunyi.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Contoh menyimpan dua versi presentasi: satu dengan hanya nilai Eceran yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah mengilustrasikan dua mode pemplotan. Baris 3 dan kolom C tetap tersembunyi dalam kedua buku kerja tersemat.

| Hanya sel terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Hanya sel terlihat: nilai Eceran 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Eceran dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dari sel kosong. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber yang tersembunyi. Lihat [Kontrol Tampilan Sel Kosong](/slides/id/cpp/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Ambil Rentang Data Bagan**

Sebelum memperbarui data buku kerja dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel lembar kerja mana yang digunakan setiap bagan. Metode [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) mengembalikan rentang data saat ini sebagai formula yang memenuhi kualifikasi lembar kerja, seperti `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama lembar kerja, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` mengidentifikasi sel A1 hingga D5, inklusif. Tanda dolar menunjukkan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah bagan atau buku kerjanya. Jika bagan tidak menggunakan buku kerja sebagai sumber datanya, ia akan melempar [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Untuk informasi lebih lanjut, lihat [Referensi API ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Contoh ini membuka sebuah presentasi dan memeriksa bentuk‑bentuk langsung pada setiap slide untuk bagan. Ia mencetak nama setiap bagan dan rentang sumbernya. Jika sebuah bagan tidak menggunakan buku kerja, ia mencetak pesan dan melanjutkan ke bagan berikutnya.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **Baca dan Tulis Data Bagan dari Buku Kerja**

Aspose.Slides for C++ menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) dan [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis buku kerja data bagan (berisi data bagan yang diedit dengan Aspose.Cells). **Catatan** bahwa data bagan harus diatur dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumbernya.

Contoh ini menggunakan sebuah presentasi dengan bagan sebagai bentuk pertama pada slide pertama. Ia membaca buku kerja tersemat ke dalam aliran, menghapus seri dan kategori yang ada, dan menulis kembali buku kerja yang sama. Perubahan tetap berada dalam memori; contoh tidak menyimpan presentasi.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Validasi Tata Letak Bagan Setelah Modifikasi Buku Kerja**

Saat Anda mengganti buku kerja tersemat dengan yang telah dimodifikasi, bagan mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis kembali buku kerja yang diperbarui ke bagan. Contoh ini menggunakan bagan yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat di mana penyuntingan buku kerja akan terjadi; contoh yang dapat dijalankan menulis kembali buku kerja asli dan memvalidasi tata letak dalam memori.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // Ubah aliran workbook di sini, misalnya menggunakan Aspose.Cells.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Mengosongkan koleksi menghapus referensi data usang sebelum buku kerja ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan bagan.

## **Tetapkan Sel Buku Kerja sebagai Label Data Bagan**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data bagan.

Contoh ini menambahkan bagan gelembung dengan data default ke slide pertama dari presentasi yang ada. Ia menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama dalam seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **Kelola Lembar Kerja**

Metode [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) menyediakan akses ke lembar kerja dalam buku kerja bagan. Contoh ini membuat bagan pai dengan data default dan mencetak setiap nama lembar kerja ke konsol.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **Tentukan Tipe Sumber Data**

Contoh ini membuat bagan kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) memilih sumber untuk setiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **Deteksi Format Buku Kerja Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja Excel biner (.xlsb) yang dapat tersemat dalam beberapa bagan. Anda dapat menggunakan metode [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) pada [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan bagan‑bagan tersebut. Contoh ini memeriksa bentuk pada slide pertama dari presentasi yang ada, melewatkan bentuk non‑bagan, dan mencetak pesan diagnostik untuk setiap bagan dengan buku kerja .xlsb yang tersemat.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Baca atau ubah data buku kerja bagan yang didukung di sini.
}
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk bagan.

### **Buat Buku Kerja Eksternal**

Gunakan [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) dan [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) untuk mengekspor buku kerja bagan tersemat ke berkas dan menautkan bagan ke buku kerja eksternal tersebut.

Contoh ini membuat bagan pai dengan data default dan mengekspor buku kerjanya. Ia menutup aliran output sebelum menetapkan buku kerja eksternal sebagai sumber data bagan, kemudian menyimpan presentasi yang ditautkan.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);

presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **Tetapkan Buku Kerja Eksternal**

Dengan menggunakan metode [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/), Anda dapat menetapkan buku kerja eksternal ke bagan sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya jarak jauh, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut secara otomatis diubah menjadi jalur penuh.

Contoh ini menggunakan buku kerja eksternal yang lembar kerjanya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat bagan pai, menautkan buku kerja, dan menggunakan [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Ia menyimpan presentasi dengan bagan yang ditautkan.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

Parameter `updateChartData` pada metode [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) mengontrol apakah buku kerja dimuat.

* Ketika `updateChartData` bernilai `false`, hanya jalur buku kerja yang diperbarui. Data bagan tidak dimuat atau diperbarui dari buku kerja target, sehingga buku kerja dapat tidak tersedia.
* Ketika `updateChartData` bernilai `true`, data bagan diperbarui dari buku kerja target.

Contoh berikut menetapkan URL placeholder dengan `updateChartData` diset ke `false`. Ia mempertahankan data default bagan pai dan menyimpan presentasi tanpa memuat buku kerja yang tidak tersedia.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal Sebuah Bagan**

Untuk mengidentifikasi buku kerja yang ditautkan ke sebuah bagan, periksa apakah bagan menggunakan sumber data eksternal dan ambil jalur bukunya.

Contoh ini memeriksa bentuk pertama pada slide pertama dari presentasi dengan buku kerja eksternal yang ditautkan. Jika bentuk tersebut adalah bagan yang ditautkan ke buku kerja eksternal, contoh mencetak [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) ke konsol. Kemudian ia menyimpan salinan presentasi.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **Edit Data Bagan**

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Contoh ini menggunakan bagan yang merupakan bentuk pertama pada slide pertama dan ditautkan ke buku kerja eksternal yang dapat diakses. Ia menetapkan nilai berbasis sel untuk titik data pertama dalam seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Mengedit nilai sel dapat memperbarui berkas XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu mempertahankan buku kerja asli.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Pulihkan Buku Kerja dari Cache Bagan**

Jika sebuah bagan menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi buku kerja bagan dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), konfigurasikan dengan [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), dan panggil [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) dengan `true` sebelum membuka presentasi.

Contoh C++ berikut memulihkan data buku kerja untuk sebuah bagan yang merupakan bentuk pertama pada slide pertama dan merujuk ke buku kerja eksternal yang tidak tersedia. Ia mengakses data yang dipulihkan melalui [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) dan [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Baca atau ubah data buku kerja yang dipulihkan di sini.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Aktifkan pemulihan hanya ketika penggunaan data bagan yang di‑cache merupakan alternatif yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah bagan tertentu ditautkan ke buku kerja eksternal atau tersemat?**

Ya. Sebuah bagan memiliki [tipe sumber data](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana cara mereka disimpan?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis diubah menjadi jalur absolut. Presentasi menyimpan jalur absolut dalam berkas PPTX, sehingga memindahkan buku kerja mungkin memerlukan pembaruan tautan.

**Bisakah saya menggunakan buku kerja yang berada di sumber daya atau berbagi jaringan?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit buku kerja jauh secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Mengedit data bagan berbasis sel juga dapat memperbarui berkas XLSX lokal yang ditautkan. Gunakan salinan buku kerja jika yang asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi sandi?**

Aspose.Slides tidak menerima sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan sebelumnya atau menyiapkan salinan yang sudah didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa bagan merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap bagan menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin di setiap bagan pada saat data dimuat berikutnya.