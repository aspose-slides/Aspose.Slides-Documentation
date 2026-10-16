---
title: Menambahkan Garis Tren ke Diagram Presentasi dalam C++
linktitle: Garis Tren
type: docs
url: /id/cpp/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linier
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren pangkat
- garis tren kustom
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Dengan cepat menambahkan dan menyesuaikan garis tren pada diagram PowerPoint menggunakan Aspose.Slides untuk C++ — panduan praktis untuk memikat audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linier, logaritmik, rata‑rata bergerak, polinomial, dan pangkat.

Artikel ini juga menjelaskan cara menambahkan garis khusus ke diagram dengan menyisipkan bentuk garis, serta menyertakan FAQ singkat tentang nilai proyeksi garis tren ke depan dan ke belakang serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Menambahkan Garis Tren**

Gunakan [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) untuk menambahkan garis tren ke sebuah seri diagram, memilih tipenya dengan [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). Contoh ini membuat diagram kolom terkelompok dengan data default dan menambahkan dua garis tren ke masing‑masing tiga serinya.

Garis tren eksponensial menyembunyikan persamaan dan nilai R‑kuadrat melalui [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) dan [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/), sementara garis tren linier berwarna merah. Garis tren logaritmik menggunakan [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) untuk label khusus. Rata‑rata bergerak menggunakan [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) untuk merata‑rata tiga titik data dan [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) untuk memberi nama khusus.

Garis tren polinomial menggunakan [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) untuk mengatur derajatnya menjadi tiga dan memperluas satu kategori ke depan melalui [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). Garis tren pangkat memperluas satu kategori ke belakang melalui [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **Mengatur Intersep Garis Tren**

Gunakan [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) untuk menetapkan nilai Y garis tren pada X = 0. Pengaturan ini didukung untuk garis tren linier, eksponensial, dan polinomial.

Sebagai contoh, model biaya produksi mungkin harus dimulai dengan biaya tetap yang diketahui sebesar 100, meskipun pengukuran pada volume produksi nonnol menunjukkan baseline yang berbeda. Untuk garis tren linier, menetapkan intersep membatasi persamaan `y = ax + b` menjadi `b = 100`; kemiringan dipasang ke data dengan batasan tersebut. Ini tidak sekadar memindahkan garis yang sudah dipasang. Pengaturan perpotongan sumbu mengontrol dimana sumbu diagram bertemu, bukan koefisien garis tren yang dipasang.

Contoh berikut membuat diagram sebar (XY) dengan volume produksi dari 1 hingga 4 dan biaya 170, 200, 230, dan 260. Diagram disimpan dengan intersep otomatis default, kemudian intersep diatur menjadi 100, dan menyimpan PPTX kedua. Kedua file hanya berbeda pada pengaturan intersep. Garis tren menampilkan persamaannya dan memperluas kembali ke X = 0.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

Dengan perhitungan otomatis, data ini menghasilkan `y = 30x + 140`. Mengatur intersep menjadi 100 menghasilkan kira‑kira `y = 43.33x + 100`: nilai yang dipasang pada nol cocok dengan baseline yang diketahui, sementara garis tersebut tidak lagi melewati setiap titik data.

| Intersep otomatis | Intersep tetap 100 |
| --- | --- |
| ![Garis tren linier dengan intersep yang dihitung secara otomatis sebesar 140](intercept-automatic.png) | ![Garis tren linier dengan intersep tetap sebesar 100](intercept-fixed.png) |

Kedua gambar menggunakan data dan skala sumbu yang sama. Garis tren diperluas kembali ke X = 0 untuk menampilkan intersepnya.

Secara default, properti berisi `std::numeric_limits<double>::quiet_NaN()`, yang mewakili intersep yang tidak ditentukan bukan nol. Intersep kemudian dihitung secara otomatis dari data.

## **Menambahkan Garis Kustom**

Garis kustom adalah bentuk yang digambar di atas diagram, bukan garis tren yang dihitung dari data seri. Contoh ini menggunakan [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) untuk menambahkan garis horizontal ke slide di atas diagram. Posisi garis ditentukan dalam koordinat slide, diukur dalam poin, sehingga mulai dari tepi kiri diagram dan berada setengah tinggi diagram. Lebarnya cocok dengan lebar diagram. Format garis yang dikembalikan oleh [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) memberi garis warna merah solid.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apa arti 'forward' dan 'backward' pada sebuah garis tren?**

Ini adalah panjang garis tren yang diproyeksikan ke depan/ke belakang: untuk diagram sebar (XY) — dalam satuan sumbu; untuk diagram non‑sebar — dalam jumlah kategori. Hanya nilai non‑negatif yang diizinkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/) atau [SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/) dan merender diagram menjadi gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Sebuah metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/cpp/shape-thumbnails/) itu sendiri.