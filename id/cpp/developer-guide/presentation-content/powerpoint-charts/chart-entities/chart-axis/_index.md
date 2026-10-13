---
title: Sesuaikan Sumbu Diagram dalam Presentasi Menggunakan C++
linktitle: Sumbu Diagram
type: docs
url: /id/cpp/chart-axis/
keywords:
- sumbu diagram
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
description: "Temukan cara menggunakan Aspose.Slides untuk C++ dalam menyesuaikan sumbu diagram pada presentasi PowerPoint untuk laporan dan visualisasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram dengan Aspose.Slides untuk C++. Ini mencakup nilai sumbu yang dihitung, menukar baris dan kolom diagram, visibilitas sumbu, interval label kategori dan tanda‑tick, kategori tanggal dan pemformatannya, rotasi judul, penempatan sumbu, satuan tampilan, serta penskalaan logaritmik.

## **Dapatkan Nilai Maksimum pada Sumbu Vertikal pada Diagram**

Buat sebuah [Presentasi](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) dan tambahkan diagram area dengan data default. Panggil [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) sebelum membaca nilai sumbu yang dihitung sehingga tata letak diagram terbaru.

Baca [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) dan [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) untuk batas sumbu, serta [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) dan [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) untuk interval tanda. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) dan [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) memberikan skala satuan waktu, yang relevan untuk sumbu tanggal. Contoh menyimpan nilai‑nilai ini dalam variabel lokal dan menyimpan diagram.

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

Gunakan [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) untuk menukar peran seri dan kategori dalam data diagram. Setiap kategori lama menjadi seri, dan setiap seri lama menjadi kategori. Ini mengubah cara data dikelompokkan; tidak menukar sumbu horizontal dan vertikal. Contoh menggunakan [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) untuk mengaitkan data default ke `Sheet1!A1:D5`, termasuk baris header dan kolom kategori, sebelum menukar baris dan kolom. Ini menyimpan diagram dengan empat seri dan tiga kategori.

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

## **Nonaktifkan Sumbu Vertikal untuk Diagram Garis**

Gunakan [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) dengan `false` pada sumbu vertikal untuk menyembunyikannya. Contoh membuat diagram garis dengan data default dan menyimpannya dengan sumbu vertikal tersembunyi.

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

## **Nonaktifkan Sumbu Horizontal untuk Diagram Garis**

Gunakan [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) dengan `false` pada sumbu horizontal untuk menyembunyikannya. Contoh membuat diagram garis dengan data default dan menyimpannya dengan sumbu horizontal tersembunyi.

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

Gunakan [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) untuk memilih sumbu kategori tanggal atau teks. Contoh ini memerlukan `ExistingChart.pptx`, dengan diagram sebagai bentuk pertama pada slide pertama dan sel kategori berisi nilai tanggal Excel numerik. Ini mengubah sumbu horizontal menjadi sumbu tanggal. Memanggil [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) dengan `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) dengan `1`, dan [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) dengan bulan menempatkan tanda utama pada interval satu bulan.

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

Ketika diagram memiliki banyak kategori, kurangi jumlah label sumbu yang terlihat tanpa menghapus kategori atau titik data. Gunakan [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) dengan `false`, lalu gunakan [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) dengan interval kategori yang diinginkan. Untuk kategori teks dalam urutan normal, penghitung dimulai dari kategori pertama:

| Interval | Label yang ditampilkan dalam contoh |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Interval `3` menampilkan setiap label ketiga, meninggalkan dua label tersembunyi di antara label yang ditampilkan. Ini tidak menghapus kolom yang bersesuaian. Spasi otomatis memilih interval berdasarkan ruang yang tersedia; tidak selalu menampilkan setiap label.

Tanda‑tick memiliki kontrol terpisah. Gunakan [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) dengan `false` dan gunakan [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) untuk mengatur intervalnya. Misalnya, `1` menjaga tanda‑tick pada setiap interval kategori sementara label muncul hanya setiap kategori ketiga. Gunakan [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) dengan gaya terlihat agar Anda dapat melihat hasilnya. Mengatur kembali properti spasi otomatis ke `true` membuat diagram memilih interval itu lagi.

Contoh mandiri berikut membuat 24 kategori dan satu seri, kemudian menyimpan tiga slide dalam `CategoryAxisIntervals.pptx`: spasi otomatis, spasi label manual dengan tanda‑tick independen, dan spasi otomatis yang dipulihkan. Dua salinan mempertahankan data diagram asli. Tidak diperlukan presentasi masukan. Teks label horizontal memudahkan melihat perbedaan kepadatan.

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

// Slide 2: tampilkan setiap label ketiga, tetapi tetap pertahankan tanda‑tick untuk setiap kategori.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: biarkan diagram memilih kedua interval lagi.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Spasi otomatis (slide 1):** Pada render ini, setiap label kategori kedua ditampilkan dan terbungkus menjadi dua baris. Hasil otomatis dapat bervariasi tergantung ukuran diagram, font, dan renderer.
![Spasi label kategori otomatis dengan semua 24 kolom terlihat](category-axis-automatic.png)

**Spasi manual (slide 2):** Setiap label ketiga ditampilkan dalam satu baris, sementara tanda‑tick tetap pada setiap interval kategori. Semua 24 kolom, termasuk yang tanpa label, tetap terlihat dengan nilai yang sama. Slide 3 memulihkan tampilan otomatis yang ditunjukkan di atas.
![Interval label kategori manual tiga dengan semua 24 kolom terlihat](category-axis-manual.png)

### **Pilih Sumbu dan Interval yang Tepat**

Gunakan interval hitungan kategori ini untuk sumbu kategori teks, seperti sumbu kategori pada diagram kolom, garis, area, atau batang. Pada diagram kolom, ini adalah sumbu horizontal. Pada diagram batang horizontal, sumbu kategori bersifat vertikal, jadi terapkan pengaturan ini ke [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Jarak tanda‑tick juga berlaku pada sumbu seri dalam diagram yang memilikinya.

Jangan gunakan spasi label kategori untuk mengatur skala numerik sumbu nilai. Pada sumbu nilai, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) menentukan selisih nilai: misalnya, satuan utama `10` menghasilkan tanda pada 0, 10, 20, dan seterusnya ketika sumbu mulai dari nol. Interval label kategori `3` menghitung posisi kategori, terlepas dari nilai data mereka. Diagram sebar dan gelembung menggunakan sumbu nilai bukan sumbu kategori teks. Untuk sumbu tanggal, gunakan satuan utama dan skala berbasis waktu seperti dijelaskan dalam [Change a Category Axis](#change-a-category-axis).

## **Atur Format Tanggal untuk Nilai Sumbu Kategori**

Contoh mengganti data diagram default dengan empat nilai tahunan. Tanggal disimpan sebagai nomor seri OLE Automation di lembar kerja pertama (indeks `0`). Gunakan [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) untuk memilih sumbu tanggal, nonaktifkan pemformatan terkait sumber dengan [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), dan tetapkan `yyyy` dengan [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) sehingga label kategori menampilkan tahun empat digit secara independen dari pemformatan sel.

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

## **Atur Sudut Rotasi untuk Judul Sumbu Diagram**

Aktifkan judul sumbu vertikal dengan [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), berikan teks judul, dan gunakan [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) untuk memutar judul. Sudut diukur dalam derajat; contoh ini menyimpan diagram kolom dengan judul sumbu nilai diputar 90 derajat.

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

Gunakan [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) untuk mengontrol apakah sumbu nilai melewati sumbu kategori di antara kategori atau pada tanda‑tick kategori. Properti ini berlaku untuk sumbu kategori. Contoh mengaturnya ke `true` pada sumbu kategori horizontal diagram kolom dan menyimpan hasilnya.

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

## **Atur Satuan Tampilan pada Sumbu Nilai Diagram**

Gunakan [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) untuk mengubah skala label pada sumbu nilai tanpa mengubah data yang mendasarinya. Dengan [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) diatur ke `Millions`, nilai 60.000.000 ditampilkan sebagai 60. Contoh ini membuat diagram kolom dan menerapkan satuan tampilan jutaan pada sumbu vertikalnya.

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

Sumbu nilai logaritmik berguna saat nilai positif mencakup beberapa orde besaran. Misalnya, sebuah layanan mungkin menerima 10, 100, 1.000, 10.000, dan 100.000 permintaan selama lima periode. Pada skala linear, nilai kecil muncul berdekatan di dekat nol. Skala logaritmik memudahkan perbandingan pertumbuhan relatif mereka: jarak yang sama mewakili rasio yang sama bukan selisih yang sama.

Panggil [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) dengan `true` pada sumbu nilai dan gunakan [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) untuk memilih basis. Ini mengubah cara nilai yang ada ditampilkan; tidak mengubah data atau menambahkan garis tren logaritmik. Garis tren mewakili hubungan yang dipasangkan pada data dan merupakan fitur terpisah.

### **Pilih Sumbu Nilai dan Basis**

Untuk diagram garis atau kolom, sumbu nilai adalah [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Untuk diagram batang horizontal, itu adalah [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Diagram sebar dan gelembung memiliki dua sumbu nilai, jadi pilih sumbu horizontal untuk nilai X, sumbu vertikal untuk nilai Y, atau keduanya. Jangan terapkan penskalaan logaritmik pada sumbu kategori.

Basis logaritmik default adalah `10`. Untuk diagram PPTX, gunakan basis dari `2` hingga `1000`, inklusif; basis pecahan seperti `2.5` juga didukung. Dengan basis `10`, pangkat berurutan seperti 10, 100, 1.000, dan 10.000 memiliki jarak yang sama.

### **Bandingkan Skala Linear dan Logaritmik**

Contoh mandiri berikut membuat diagram garis dengan lima hitungan permintaan pada slide pertama, kemudian menggandakan slide tersebut dan mengaktifkan sumbu nilai logaritmik basis-10 pada slide kedua. Kedua slide mempertahankan data yang sama.

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

// Pertahankan slide pertama secara linear dan ubah hanya skala sumbu nilai pada salinan.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Skala linear (slide 1):** Jarak vertikal yang sama mewakili perbedaan yang sama dalam hitungan permintaan. Nilai terbesar mendominasi diagram, membuat nilai yang lebih kecil sulit dibedakan.
![Diagram garis di PowerPoint menampilkan lima hitungan permintaan pada sumbu nilai linear](value-axis-linear.png)

**Skala logaritmik (slide 2):** Jarak vertikal yang sama mewakili rasio yang sama. Setiap periode memiliki sepuluh kali lebih banyak permintaan daripada periode sebelumnya, sehingga titik‑titik membentuk garis naik lurus pada skala basis-10. Label sumbu masih menampilkan hitungan permintaan asli.
![Lima hitungan permintaan yang sama di PowerPoint pada sumbu nilai logaritmik basis-10](value-axis-logarithmic.png)

### **Tangani Nilai Nol dan Negatif**

Skala logaritmik hanya dapat menampilkan nilai yang benar-benar positif. Periksa data sebelum mengaktifkannya. Jika nilai nol atau negatif memiliki makna, pertahankan skala linear atau tampilkan secara terpisah. Jika mengecualikan nilai tersebut sesuai untuk analisis, jelaskan pengabaian itu. Jangan diam‑diam menggantinya dengan angka positif kecil, karena hal ini mengubah makna data. Setiap minimum atau maksimum yang dikonfigurasi secara manual untuk sumbu logaritmik juga harus positif.

## **FAQ**

**Bagaimana cara saya mengatur nilai di mana satu sumbu memotong sumbu lainnya (persilangan sumbu)?**

Gunakan [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) untuk memilih perilaku persilangan. Untuk menentukan nilai persilangan numerik, gunakan [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Pengaturan ini memungkinkan Anda memindahkan persilangan sumbu ke baseline yang sesuai.

**Bagaimana saya dapat menempatkan label tick relatif terhadap sumbu?**

Gunakan [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) dengan nilai dari [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, atau `None`. Untuk mengontrol tanda‑tick itu sendiri, gunakan [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) atau [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); ini terpisah dari posisi label.