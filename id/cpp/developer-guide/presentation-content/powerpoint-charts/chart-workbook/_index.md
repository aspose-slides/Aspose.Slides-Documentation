---
title: Kelola Buku Kerja Diagram dalam Presentasi Menggunakan C++
linktitle: Buku Kerja Diagram
type: docs
weight: 70
url: /id/cpp/chart-workbook/
keywords:
- buku kerja diagram
- data diagram
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache diagram
- pemulihan buku kerja
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Temukan Aspose.Slides untuk C++: kelola buku kerja diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga membahas penggunaan buku kerja eksternal sebagai sumber data diagram. Contoh‑contohnya memperlihatkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke diagram, serta mengedit data diagram ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Mengontrol Tampilan Sel Kosong](/slides/id/cpp/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) untuk mengontrol apakah diagram memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemetaan diagram; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

[presentasi contoh](hidden-source-data.pptx) berisi diagram kolom sebagai bentuk pertama pada slide pertama. Lembar kerja tersemat, `Sheet1`, memiliki rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, namun sel‑selnya tetap berisi nilai.

| Baris Lembar Kerja | A: Bulan | B: Ritel | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (baris tersembunyi) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Akses sel sumber melalui [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) dan baca [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) untuk memeriksa status tersembunyi mereka. Properti ini hanya dapat dibaca. Pada file ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `False`, `True`, dan `True` secara berurutan.

Untuk contoh ini, segarkan data diagram setelah mengubah pengaturan plot: pertahankan buku kerja tersemat dengan [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) dan muat kembali dengan [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Saat menyertakan semua sel, gunakan juga [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) untuk memulihkan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data diagram yang di‑cache dalam contoh ini serta label kategori.

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

        // Segarkan data diagram dari buku kerja yang tersemat.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Pulihkan rentang sumber lengkap, termasuk kategori tersembunyi.
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

Contoh menyimpan dua versi presentasi: satu hanya dengan nilai Ritel yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah menggambarkan dua mode plot. Baris 3 dan kolom C tetap tersembunyi pada kedua buku kerja tersemat.

| Hanya sel yang terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Hanya sel yang terlihat: nilai Ritel 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Ritel dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dengan sel kosong. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber yang tersembunyi. Lihat [Mengontrol Tampilan Sel Kosong](/slides/id/cpp/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Ambil Rentang Data Diagram**

Sebelum memperbarui data buku kerja dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel lembar kerja mana yang digunakan diagram. Metode [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) mengembalikan rentang data saat ini sebagai formula yang memenuhi kualifikasi lembar kerja, misalnya `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama lembar kerja, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` menandai sel A1 hingga D5, inklusif. Tanda dolar menunjukkan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah diagram atau buku kerjanya. Jika diagram tidak menggunakan buku kerja sebagai sumber data, metode ini melempar [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Untuk informasi lebih lanjut, lihat [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Contoh ini membuka presentasi dan memeriksa bentuk‑bentuk langsung pada setiap slide untuk diagram. Contoh mencetak nama setiap diagram dan rentang sumbernya. Jika sebuah diagram tidak menggunakan buku kerja, contoh mencetak pesan dan melanjutkan ke diagram berikutnya.

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

## **Baca dan Tulis Data Diagram dari Buku Kerja**

Aspose.Slides untuk C++ menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) dan [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur serupa dengan sumbernya.

Contoh ini menggunakan presentasi dengan diagram sebagai bentuk pertama pada slide pertama. Contoh membaca buku kerja tersemat ke dalam aliran, menghapus seri dan kategori yang ada, dan menulis kembali buku kerja yang sama. Perubahan tetap berada di memori; contoh tidak menyimpan presentasi.

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

### **Validasi Tata Letak Diagram Setelah Modifikasi Buku Kerja**

Saat Anda mengganti buku kerja tersemat dengan yang telah dimodifikasi, diagram mempertahankan koleksi seri dan kategori asli. Ketidaksesuaian ini dapat menyebabkan [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis kembali buku kerja yang diperbarui ke diagram. Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat pengeditan buku kerja; contoh yang dapat dijalankan menulis kembali buku kerja asli dan memvalidasi tata letak di memori.

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

    // Ubah aliran buku kerja di sini, misalnya, menggunakan Aspose.Cells.

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

Mengosongkan koleksi menghilangkan referensi data usang sebelum buku kerja ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan diagram.

## **Tetapkan Format Angka Kustom untuk Sel Buku Kerja**

Gunakan [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) untuk mengontrol bagaimana nilai numerik ditampilkan dalam buku kerja tersemat diagram. Misalnya, sebuah laporan mungkin memerlukan tingkat konversi yang ditampilkan sebagai persentase dengan empat tempat desimal dan koefisien yang ditampilkan dengan lima tempat desimal. Pertahankan kedua nilai sebagai numerik agar tetap dapat digunakan untuk perhitungan dan pemetaan diagram.

Format angka mengubah tampilan, bukan nilai yang disimpan. Format `0.0000%` menampilkan `0.125` sebagai `12.5000%`; tidak menggantikan angka yang disimpan dengan `12.5`. Demikian pula, `0.00000` menampilkan `0.1234567` sebagai `0.12346` tanpa membulatkan nilai yang disimpan. Jika format kustom adalah string kosong (`""`), format yang ditetapkan melalui [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) akan digunakan sebagai gantinya.

Contoh berikut membuat diagram kolom dan mengakses sel‑nya melalui [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/). Pada lembar kerja 0, B2 berisi tingkat konversi dan C2 berisi koefisien. Kedua sel menyediakan nilai diagram. Contoh juga mengaktifkan label nilai yang ditautkan ke format sumber.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

Format sel buku kerja terpisah dari format yang ditetapkan langsung pada sumbu diagram atau label data. Dalam contoh ini, setiap label menampilkan nilai sel sumber karena [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) dipanggil dengan `true`, dan mengikuti format angka sumber karena [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) dipanggil dengan `true`. Setelah menyimpan dan membuka kembali presentasi, label menampilkan `12.5000%` dan `0.12346`, seperti yang ditunjukkan di bawah. Sumbu vertikal menggunakan formatnya sendiri `0.00`, yang ditetapkan melalui [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/), dengan [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) dipanggil dengan `false`.

Untuk memformat label data secara terpisah, setel flag tautan ke sumber menjadi `false` dan tetapkan formatnya melalui [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/). Ini tidak mengubah format sel buku kerja. Misalnya, format label independen `0.00` menampilkan nilai pertama sebagai `0.13`, sementara B2 tetap menampilkan `12.5000%`. Lihat [Chart Data Labels](/slides/id/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) untuk pemformatan label langsung.

Gambar di bawah dirender dari presentasi yang disimpan setelah dibuka kembali:

![Diagram kolom dengan label yang ditautkan ke sumber menampilkan 12.5000% dan 0.12346 serta sumbu numerik yang diformat secara independen.](custom-cell-formats.png)

## **Tetapkan Sel Buku Kerja sebagai Label Data Diagram**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data diagram.

Contoh ini menambahkan diagram gelembung dengan data default ke slide pertama dari presentasi yang ada. Contoh menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama pada seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

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

Metode [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) menyediakan akses ke lembar kerja dalam buku kerja diagram. Contoh ini membuat diagram pai dengan data default dan mencetak nama setiap lembar kerja ke konsol.

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

Nilai titik seri juga dapat disimpan langsung sebagai literal numerik. Lihat [Set Series Values Using Numeric Literals](/slides/id/cpp/chart-series/#set-series-values-using-numeric-literals) untuk contoh lengkap yang menyimpan dan membacanya. Tipe sumber nilai titik terpisah dari konfigurasi buku kerja internal atau eksternal diagram; penggunaan literal numerik tidak secara otomatis menghapus buku kerja tersemat.

Contoh ini membuat diagram kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) memilih sumber untuk setiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

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

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat tersemat pada beberapa diagram. Anda dapat menggunakan metode [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) pada [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewati diagram‑diagram tersebut. Contoh ini memeriksa bentuk‑bentuk pada slide pertama dari presentasi yang ada, melewati bentuk non‑diagram, dan mencetak pesan diagnostik untuk setiap diagram dengan buku kerja .xlsb tersemat.

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

    // Baca atau ubah data buku kerja diagram yang didukung di sini.
}
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk diagram.

### **Buat Buku Kerja Eksternal**

Gunakan [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) dan [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) untuk mengekspor buku kerja diagram tersemat ke berkas dan menautkan diagram ke buku kerja eksternal tersebut.

Contoh ini membuat diagram pai dengan data default dan mengekspor buku kerjanya. Contoh menutup aliran keluaran sebelum menetapkan buku kerja eksternal sebagai sumber data diagram, kemudian menyimpan presentasi yang ditautkan.

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

Dengan menggunakan metode [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/), Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut dipindahkan).

Meskipun Anda tidak dapat menyunting data pada buku kerja yang disimpan di lokasi remote atau sumber daya, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut otomatis dikonversi ke jalur penuh.

Contoh ini menggunakan buku kerja eksternal yang lembar kerjanya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat diagram pai, menautkan buku kerja, dan menggunakan [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Contoh menyimpan presentasi dengan diagram yang ditautkan.

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

* Ketika `updateChartData` bernilai `false`, hanya jalur buku kerja yang diperbarui. Data diagram tidak dimuat atau diperbarui dari buku kerja target, sehingga buku kerja dapat tidak tersedia.
* Ketika `updateChartData` bernilai `true`, data diagram diperbarui dari buku kerja target.

Contoh berikut menetapkan URL placeholder dengan `updateChartData` diset ke `false`. Contoh tetap mempertahankan data default diagram pai dan menyimpan presentasi tanpa memuat buku kerja yang tidak tersedia.

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

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal Sebuah Diagram**

Untuk mengidentifikasi buku kerja yang ditautkan ke diagram, periksa apakah diagram menggunakan sumber data eksternal dan ambil jalur bukunya.

Contoh ini memeriksa bentuk pertama pada slide pertama dari presentasi dengan buku kerja eksternal yang ditautkan. Jika bentuk tersebut merupakan diagram yang ditautkan ke buku kerja eksternal, contoh mencetak [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) ke konsol. Kemudian contoh menyimpan salinan presentasi.

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

### **Sunting Data Diagram**

Anda dapat menyunting data pada buku kerja eksternal dengan cara yang sama seperti mengubah konten buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama dan ditautkan ke buku kerja eksternal yang dapat diakses. Contoh menetapkan nilai berbasis sel dari titik data pertama pada seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Penyuntingan nilai sel dapat memperbarui berkas XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda harus mempertahankan buku kerja asli.

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

### **Pulihkan Buku Kerja dari Cache Diagram**

Jika sebuah diagram menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi buku kerja diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), konfigurasikan dengan [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), dan panggil [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) dengan `true` sebelum membuka presentasi.

Contoh C++ berikut memulihkan data buku kerja untuk diagram yang merupakan bentuk pertama pada slide pertama dan merujuk ke buku kerja eksternal yang tidak tersedia. Contoh mengakses data yang dipulihkan melalui [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) dan [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides melempar [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Aktifkan pemulihan hanya ketika penggunaan data diagram yang di‑cache dapat diterima sebagai cadangan, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah diagram tertentu ditautkan ke buku kerja eksternal atau tersemat?**

Ya. Sebuah diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana cara mereka disimpan?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut otomatis dikonversi ke jalur absolut. Presentasi menyimpan jalur absolut dalam berkas PPTX, sehingga memindahkan buku kerja mungkin memerlukan pembaruan tautan.

**Apakah saya dapat menggunakan buku kerja yang berada di sumber daya jaringan / share?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan buku kerja remote secara langsung dari Aspose.Slides tidak didukung — mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Penyuntingan data diagram berbasis sel juga dapat memperbarui berkas XLSX lokal yang ditautkan. Gunakan salinan buku kerja jika asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) dan menautkan ke salinan tersebut.

**Apakah beberapa diagram dapat merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑mas-masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada kali berikutnya data dimuat.