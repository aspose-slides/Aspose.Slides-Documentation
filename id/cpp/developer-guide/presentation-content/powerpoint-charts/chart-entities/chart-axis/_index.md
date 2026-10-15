---
title: "Sesuaikan Sumbu Grafik dalam Presentasi Menggunakan C++"
linktitle: "Sumbu Grafik"
type: docs
url: /id/cpp/chart-axis/
keywords:
- sumbu grafik
- sumbu vertikal
- sumbu horizontal
- sesuaikan sumbu
- manipulasi sumbu
- kelola sumbu
- properti sumbu
- nilai maksimum
- nilai minimum
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Temukan cara menggunakan Aspose.Slides untuk C++ dalam menyesuaikan sumbu grafik pada presentasi PowerPoint untuk laporan dan visualisasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan sumbu grafik dengan Aspose.Slides untuk C++. Ini mencakup nilai sumbu yang dihitung, menukar baris dan kolom grafik, visibilitas sumbu, interval label kategori dan tanda centang, kategori tanggal dan pemformatannya, rotasi judul, penempatan sumbu, satuan tampilan, serta skala logaritmik.

## **Dapatkan Nilai Maksimum pada Sumbu Vertikal pada Grafik**

Buat sebuah [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) dan tambahkan grafik area dengan data default. Panggil [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) sebelum membaca nilai sumbu yang dihitung sehingga tata letak grafik terbaru.

Baca [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) dan [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) untuk batas sumbu, serta [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) dan [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) untuk interval tanda centang. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) dan [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) menyediakan skala satuan waktu, yang relevan untuk sumbu tanggal. Contoh menyimpan nilai-nilai ini dalam variabel lokal dan menyimpan grafik.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **Tukar Data antara Sumbu**

Gunakan [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) untuk menukar peran seri dan kategori dalam data grafik. Setiap kategori sebelumnya menjadi seri, dan setiap seri sebelumnya menjadi kategori. Ini mengubah cara data dikelompokkan; tidak menukar sumbu horizontal dan vertikal. Contoh menggunakan [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) untuk mengikat data default ke `Sheet1!A1:D5`, termasuk baris header dan kolom kategori, sebelum menukar baris dan kolom. Ini menyimpan grafik dengan empat seri dan tiga kategori.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Balikkan Urutan Plot pada Sumbu**

Gunakan [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) untuk membalikkan sumbu kategori atau nilai. Misalnya, grafik batang horizontal dapat menampilkan tahapan proyek dari atas ke bawah dengan urutan yang sama seperti lembar kerja: Perencanaan, Pengembangan, Pengujian. Membalikkan sumbu mengubah arah plot; tidak menyortir atau mengatur ulang data buku kerja. Sebagai perbandingan, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) menukar peran seri dan kategori.

Contoh berikut membuat grafik batang horizontal dengan tiga tahapan dan satu seri. Ini menyimpan presentasi dengan tiga slide: urutan normal, kategori terbalik, dan nilai terbalik. Setiap salinan menggunakan set data yang sama, dan hanya satu sumbu yang dibalik pada setiap salinan.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// Slide 2: tampilkan kategori pertama di bagian atas.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Pertahankan sumbu nilai horizontal di bagian bawah.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Slide 3: balikkan hanya skala numerik horizontal.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Membalikkan sumbu juga dapat memindahkan sumbu tegak lurus ke sisi berlawanan dari plot. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) mengontrol di mana sumbu lain menyeberangi sumbu yang dikonfigurasi. Pada slide 2, menyetelnya ke `Maximum` pada sumbu kategori terbalik menjaga sumbu nilai horizontal di bagian bawah. Untuk titik persilangan tertentu, gunakan [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Periksa pengaturan persilangan saat mengubah arah, terutama jika grafik sudah memiliki titik persilangan khusus. Panggil `set_IsPlotOrderReversed` dengan `false` untuk mengembalikan arah plot normal; pengaturan persilangan bersifat terpisah.

| Urutan normal (slide 1) | Kategori terbalik (slide 2) | Nilai terbalik (slide 3) |
| --- | --- | --- |
| ![Grafik batang horizontal dengan urutan sumbu kategori dan nilai normal](axis-order-normal.png) | ![Grafik batang horizontal dengan kategori ditampilkan dari atas ke bawah](axis-order-categories-reversed.png) | ![Grafik batang horizontal dengan sumbu nilai terbalik dan nol di kanan](axis-order-values-reversed.png) |
| Kategori berjalan dari bawah ke atas; nilai meningkat dari kiri ke kanan. | Perencanaan, Pengembangan, dan Pengujian berjalan dari atas ke bawah. Nilai dan urutan baris buku kerja tidak berubah. | Kategori mempertahankan urutan normal; nilai meningkat dari kanan ke kiri. Sumbu kategori melewati pada nol di kanan. |

## **Nonaktifkan Sumbu Vertikal untuk Grafik Garis**

Gunakan [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) dengan `false` pada sumbu vertikal untuk menyembunyikannya. Contoh membuat grafik garis dengan data default dan menyimpannya dengan sumbu vertikal tersembunyi.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **Nonaktifkan Sumbu Horizontal untuk Grafik Garis**

Gunakan [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) dengan `false` pada sumbu horizontal untuk menyembunyikannya. Contoh membuat grafik garis dengan data default dan menyimpannya dengan sumbu horizontal tersembunyi.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **Ubah Sumbu Kategori**

Gunakan [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) untuk memilih sumbu kategori tanggal atau teks. Contoh ini memerlukan `ExistingChart.pptx`, dengan grafik sebagai bentuk pertama pada slide pertama dan sel kategori berisi nilai tanggal Excel numerik. Ini mengubah sumbu horizontal menjadi sumbu tanggal. Memanggil [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) dengan `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) dengan `1`, dan [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) dengan bulan menempatkan tanda utama pada interval satu bulan.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Kontrol Interval Label Sumbu Kategori**

Saat grafik memiliki banyak kategori, kurangi jumlah label sumbu yang terlihat tanpa menghapus kategori atau titik data. Gunakan [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) dengan `false`, lalu gunakan [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) dengan interval kategori yang diinginkan. Untuk kategori teks dalam urutan normal, penghitung dimulai dari kategori pertama:

| Interval | Label yang ditampilkan dalam contoh |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

Interval `3` menampilkan setiap label ketiga, meninggalkan dua label tersembunyi di antara label yang ditampilkan. Ini tidak menghapus kolom yang bersesuaian. Penataan otomatis memilih interval berdasarkan ruang yang tersedia; tidak selalu menampilkan setiap label.

Tanda centang memiliki kontrol terpisah. Gunakan [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) dengan `false` dan gunakan [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) untuk mengatur intervalnya. Misalnya, `1` mempertahankan tanda centang pada setiap interval kategori sementara label hanya muncul setiap kategori ketiga. Gunakan [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) dengan gaya yang terlihat agar Anda dapat melihat hasilnya. Mengatur kembali properti penataan otomatis mana pun ke `true` memungkinkan grafik memilih interval itu lagi.

Contoh mandiri berikut membuat 24 kategori dan satu seri, lalu menyimpan tiga slide dalam `CategoryAxisIntervals.pptx`: penataan otomatis, penataan label manual dengan tanda centang independen, dan pemulihan penataan otomatis. Dua salinan mempertahankan data grafik asli. Tidak diperlukan presentasi masukan. Teks label horizontal memudahkan melihat perbedaan kepadatan.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// Slide 2: show every third label, but keep a tick mark for every category.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: let the chart choose both intervals again.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Penataan otomatis (slide 1):** Pada render ini, setiap label kategori kedua ditampilkan dan membungkus menjadi dua baris. Hasil otomatis dapat bervariasi tergantung ukuran grafik, font, dan renderer.

![Penataan label kategori otomatis dengan semua 24 kolom terlihat](category-axis-automatic.png)

**Penataan manual (slide 2):** Setiap label ketiga ditampilkan pada satu baris, sementara tanda centang tetap pada setiap interval kategori. Semua 24 kolom, termasuk yang tanpa label, tetap terlihat dengan nilai yang sama. Slide 3 mengembalikan tampilan otomatis yang ditunjukkan di atas.

![Interval label kategori manual tiga dengan semua 24 kolom terlihat](category-axis-manual.png)

### **Pilih Sumbu dan Interval yang Tepat**

Gunakan interval hitung kategori ini untuk sumbu kategori teks, seperti sumbu kategori pada grafik kolom, garis, area, atau batang. Pada grafik kolom, itu adalah sumbu horizontal. Pada grafik batang horizontal, sumbu kategori berada vertikal, jadi terapkan pengaturan ini ke [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Penataan jarak tanda centang juga berlaku pada sumbu seri di grafik yang memilikinya.

Jangan gunakan penataan label kategori untuk mengatur skala numerik sumbu nilai. Pada sumbu nilai, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) menentukan perbedaan nilai: misalnya, satuan utama `10` menghasilkan tanda pada 0, 10, 20, dan seterusnya ketika sumbu dimulai dari nol. Interval label kategori `3` menghitung posisi kategori, terlepas dari nilai data mereka. Grafik pencar dan gelembung menggunakan sumbu nilai bukan sumbu kategori teks. Untuk sumbu tanggal, gunakan satuan utama dan skala berbasis waktu seperti dijelaskan di [Ubah Sumbu Kategori](#ubah-sumbu-kategori).

## **Atur Format Tanggal untuk Nilai Sumbu Kategori**

Contoh ini menggantikan data grafik default dengan empat nilai tahunan. Tanggal disimpan sebagai nomor seri OLE Automation di lembar kerja pertama (indeks `0`). Gunakan [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) untuk memilih sumbu tanggal, nonaktifkan pemformatan yang ditautkan ke sumber dengan [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), dan tetapkan `yyyy` dengan [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) sehingga label kategori menampilkan tahun empat digit secara independen dari pemformatan sel.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **Atur Sudut Rotasi untuk Judul Sumbu Grafik**

Aktifkan judul sumbu vertikal dengan [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), beri teks judul, dan gunakan [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) untuk memutar judul. Sudut diukur dalam derajat; contoh ini menyimpan grafik kolom dengan judul sumbu nilai diputar 90 derajat.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **Atur Posisi Sumbu pada Sumbu Kategori atau Nilai**

Gunakan [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) untuk mengontrol apakah sumbu nilai menyeberangi sumbu kategori di antara kategori atau pada tanda centang kategori. Properti ini berlaku untuk sumbu kategori. Contoh mengaturnya ke `true` pada sumbu kategori horizontal grafik kolom dan menyimpan hasilnya.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **Atur Satuan Tampilan pada Sumbu Nilai Grafik**

Gunakan [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) untuk menskala label pada sumbu nilai tanpa mengubah data dasar. Dengan [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) disetel ke `Millions`, nilai 60.000.000 ditampilkan sebagai 60. Contoh ini membuat grafik kolom dan menerapkan satuan tampilan jutaan pada sumbu vertikalnya.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Konfigurasikan Sumbu Nilai Logaritmik**

Sumbu nilai logaritmik berguna ketika nilai positif mencakup beberapa orde besaran. Misalnya, sebuah layanan mungkin menerima 10, 100, 1.000, 10.000, dan 100.000 permintaan selama lima periode. Pada skala linear, nilai kecil muncul berdekatan di dekat nol. Skala logaritmik memudahkan perbandingan pertumbuhan relatif: jarak yang sama mewakili rasio yang sama, bukan selisih yang sama.

Panggil [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) dengan `true` pada sumbu nilai dan gunakan [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) untuk memilih basisnya. Ini mengubah cara nilai yang ada ditampilkan; tidak mengubah data atau menambah garis tren logaritmik. Garis tren mewakili hubungan yang dipasang pada data dan merupakan fitur terpisah.

### **Pilih Sumbu Nilai dan Dasar**

Untuk grafik garis atau kolom, sumbu nilai adalah [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Untuk grafik batang horizontal, itu adalah [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Grafik pencar dan gelembung memiliki dua sumbu nilai, jadi pilih sumbu horizontal untuk nilai X, sumbu vertikal untuk nilai Y, atau keduanya. Jangan terapkan skala logaritmik pada sumbu kategori.

Basis logaritmik default adalah `10`. Untuk grafik PPTX, gunakan basis dari `2` hingga `1000`, inklusif; basis pecahan seperti `2.5` juga didukung. Dengan basis `10`, pangkat berurutan seperti 10, 100, 1.000, dan 10.000 berjarak sama.

### **Bandingkan Skala Linear dan Logaritmik**

Contoh mandiri berikut membuat grafik garis dengan lima jumlah permintaan pada slide pertama, lalu menggandakan slide tersebut dan mengaktifkan sumbu nilai logaritmik basis-10 pada slide kedua. Kedua slide mempertahankan data yang sama.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Pertahankan slide pertama linear dan ubah hanya skala sumbu nilai pada salinan.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Skala linear (slide 1):** Jarak vertikal yang sama mewakili perbedaan yang sama dalam jumlah permintaan. Nilai terbesar mendominasi grafik, membuat nilai yang lebih kecil sulit dibedakan.

![Grafik garis di PowerPoint menampilkan lima jumlah permintaan pada sumbu nilai linear](value-axis-linear.png)

**Skala logaritmik (slide 2):** Jarak vertikal yang sama mewakili rasio yang sama. Setiap periode memiliki sepuluh kali lebih banyak permintaan daripada periode sebelumnya, sehingga titik-titik membentuk garis naik lurus pada skala basis-10. Label sumbu tetap menampilkan jumlah permintaan asli.

![Lima jumlah permintaan yang sama di PowerPoint pada sumbu nilai logaritmik basis-10](value-axis-logarithmic.png)

### **Tangani Nilai Nol dan Negatif**

Skala logaritmik hanya dapat menampilkan nilai yang benar-benar positif. Periksa data sebelum mengaktifkannya. Jika nilai nol atau negatif bermakna, pertahankan skala linear atau tampilkan secara terpisah. Jika mengecualikan nilai tersebut tepat untuk analisis, jelaskan pengabaian tersebut. Jangan diam-diam menggantinya dengan angka positif kecil, karena hal itu mengubah makna data. Setiap minimum atau maksimum yang dikonfigurasi secara manual untuk sumbu logaritmik juga harus positif.

## **FAQ**

**Bagaimana cara mengatur nilai di mana satu sumbu memotong sumbu lain (persilangan sumbu)?**

Gunakan [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) untuk memilih perilaku persilangan. Untuk menentukan nilai persilangan numerik, gunakan [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Pengaturan ini memungkinkan Anda memindahkan persilangan sumbu ke baseline yang sesuai.

**Bagaimana saya dapat memposisikan label tanda centang relatif terhadap sumbu?**

Gunakan [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) dengan nilai dari [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, atau `None`. Untuk mengontrol tanda centang itu sendiri, gunakan [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) atau [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); ini terpisah dari penempatan label.