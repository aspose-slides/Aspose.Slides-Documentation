---
title: Sesuaikan Legenda Diagram dalam Presentasi Menggunakan C++
linktitle: Legenda Diagram
type: docs
url: /id/cpp/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides untuk C++ guna mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides for C++ menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, memformat entri legenda individu, serta menyembunyikan atau mengembalikan entri yang dipilih.

FAQ mencakup perilaku terkait, termasuk memesan ruang untuk legenda, menampilkan label multiline, dan mewarisi format dari tema presentasi.

## **Penempatan Legenda**

Gunakan metode [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/), dan [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) pada legenda untuk menentukan posisi dan ukurannya sebagai pecahan dari dimensi diagram.

Contoh ini membuat presentasi dan menambahkan diagram kolom berkelompok dengan data bawaan ke slide pertama. Membagi offset dan dimensi legenda yang diinginkan dengan lebar serta tinggi diagram mengubahnya menjadi nilai relatif: legenda dipindahkan 50 poin dari sudut kiri‑atas diagram dan berukuran 100 × 100 poin.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Nyatakan posisi dan ukuran legenda relatif terhadap diagram.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Mengatur Ukuran Font Legenda**

Gunakan [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) pada legenda untuk mengakses format teksnya dan [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) untuk mengatur ukuran font dalam poin.

Contoh ini membuat diagram dengan data bawaan dan mengatur teks legenda menjadi 20 poin. Ia juga menonaktifkan batas otomatis untuk sumbu vertikal dan menetapkan rentangnya dari -5 hingga 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Mengatur Ukuran Font Entri Legenda Individu**

Gunakan koleksi yang dikembalikan oleh [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) pada legenda untuk mengakses format entri tertentu. Indeks entri mulai dari nol, sehingga indeks `1` merujuk ke entri kedua.

Contoh ini membuat diagram kolom berkelompok yang data bawaannya mencakup setidaknya dua seri. Ia memformat entri legenda kedua dengan teks tebal, miring, berwarna biru, dan berukuran 20 poin.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Menyembunyikan Entri Legenda Individu**

Untuk mengecualikan seri tambahan dari legenda sementara data tetap terlihat, panggil [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) dengan `true` melalui [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Ini hanya menyembunyikan entri legenda yang dipilih; seri atau titik datanya tidak dihapus. Memanggil [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) dengan `false`, justru menyembunyikan seluruh legenda.

Contoh di bawah membuat diagram kolom berkelompok dengan beberapa seri menggunakan data bawaan. Ia menyembunyikan entri legenda seri kedua (indeks `1`) dan menyimpan presentasi. Kemudian entri dipulihkan dengan memanggil `set_Hide` dengan `false` dan menyimpan salinan kedua. Kolom tetap terlihat di kedua file.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Pulihkan entri yang sama tanpa mengubah data diagram.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Perbandingan di bawah menunjukkan diagram yang sama dengan semua entri terlihat dan dengan entri kedua tersembunyi. Kolom seri kedua tetap tidak berubah.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

Pada diagram kolom, batang, dan garis, entri legenda mengidentifikasi seri. Pada diagram pai, mereka mengidentifikasi titik data individu (irisan), jadi gunakan [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) pada irisan yang dipilih. API mendokumentasikan metode titik‑data ini untuk tipe diagram `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, dan `BarOfPie`. Jangan mengasumsikan bahwa ini berlaku untuk diagram donat, yang tidak termasuk dalam daftar tersebut.

## **FAQ**

**Apakah saya dapat membuat diagram memesan ruang untuk legenda alih‑alih menimpanya?**

Ya. Panggil [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) dengan `false` untuk memesan ruang bagi legenda sehingga tidak menimpa area plot.

**Apakah saya dapat membuat label legenda multiline?**

Ya. Label panjang dapat dibungkus ketika lebar yang tersedia tidak cukup. Anda juga dapat menggunakan karakter baris baru dalam nama seri untuk memaksa pemutusan baris.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Biarkan warna, isi, dan font legenda tidak diatur sehingga dapat mewarisi format tema. Pemformatan eksplisit akan menimpa pengaturan tema yang bersangkutan.