---
title: Kelola Seri Data Chart dalam Presentasi dengan C++
linktitle: Seri Data
type: docs
url: /id/cpp/chart-series/
keywords:
- seri chart
- overlap seri
- warna seri
- warna kategori
- nama seri
- titik data
- celah seri
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengelola seri chart, titik data, sel buku kerja, pemformatan, overlap, lebar celah, dan nilai negatif dalam presentasi dengan C++."
---
## **Ikhtisar**

Sebuah chart menyimpan data yang diplot di dalam buku kerja data chart. Sebuah [IChartSeries](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/) mewakili satu set nilai yang saling terkait, dan setiap [IChartDataPoint](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/) dalam seri mengacu pada satu atau lebih sel buku kerja. Objek [IChartCategory](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Nama seri, kategori, dan nilai titik oleh karena itu terhubung ke objek [IChartDataCell](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/) alih‑alih hanya disimpan sebagai teks tampilan.

Untuk chart kategori tipikal, buku kerja default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel sisanya untuk nilai seri. Indeks lembar kerja, baris, dan kolom yang diteruskan ke [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) bersifat berbasis nol. Tata letak ini berguna ketika Anda membuat chart dengan data default, tetapi jangan berasumsi bahwa setiap chart yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel‑sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai buku kerja.

Pengaturan chart memiliki tiga cakupan berbeda:

- Pengaturan tingkat Seri, seperti [IChartSeries::get_Format](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/get_format/), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [IChartDataPoint::get_Format](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/get_format/), menimpa tampilan seri untuk satu titik.
- Pengaturan grup diterapkan pada seri yang kompatibel yang berada dalam satu [IChartSeriesGroup](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseriesgroup/). Akses grup melalui [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) ketika Anda perlu mengatur opsi seperti overlap atau lebar celah.

Ketika tidak ada pengisian titik atau seri yang eksplisit, gaya dan tema chart menentukan tampilan otomatis. Ketika format seri dan titik keduanya ada, format titik memiliki prioritas untuk titik tersebut.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Mengatur Overlap Seri Chart**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/get_overlap/) melaporkan seberapa banyak batang atau kolom saling tumpang tindih dalam chart 2D, dari -100 sampai 100 persen. Ini merupakan proyeksi baca‑saja dari pengaturan pada grup seri induk. Panggil [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe chart yang menampilkan batang atau kolom yang dikelompokkan; tidak memengaruhi grup seri yang tidak terkait dalam chart kombinasi.

Contoh berikut mengatur overlap untuk grup yang berisi seri pertama:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// Chart baru berisi contoh seri, kategori, dan nilai.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![The series overlap](series_overlap.png)

## **Mengubah Warna Isi Seri**

Gunakan [IChartSeries::get_Format](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/get_format/) untuk mengatur isi default bagi seluruh seri. Jika sebuah titik sudah memiliki isi eksplisit, pengaturan [IChartDataPoint::get_Format](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/get_format/)‑nya menimpa isi seri untuk titik tersebut.

Contoh berikut menerapkan isi biru padat pada seri pertama:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![The color of the series](series_color.png)

## **Mengubah Nama Seri**

Nama seri disimpan dalam buku kerja data chart dan biasanya ditampilkan di legenda. Dalam buku kerja default yang dibuat untuk chart kolom berkelompok, sel B1 berada pada baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut membuat struktur itu eksplisit:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [IChartSeries::get_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/get_name/). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam chart yang ada:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![The series name](series_name.png)

## **Mendapatkan Warna Isi Seri Otomatis**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) mengembalikan warna yang dihitung dari indeks seri dan gaya chart. Inilah warna yang digunakan ketika isi seri tidak didefinisikan secara eksplisit. Memanggil metode ini hanya membaca warna yang dihitung; tidak menetapkan isi baru.

Contoh berikut mencetak warna otomatis untuk setiap seri default:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

Contoh keluaran untuk gaya chart default:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Warna yang tepat bergantung pada gaya dan tema chart.

## **Menetapkan Warna Isi Invers untuk Seri Chart**

Untuk seri batang, kolom, dan gelembung, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) dapat menampilkan nilai negatif dengan isi yang berbeda. Atur isi seri reguler menjadi padat, aktifkan inversi, dan tetapkan warna nilai negatif melalui [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Angka negatif tetap tidak berubah di buku kerja; hanya warna tampilan yang berubah.

Contoh berikut mengganti data chart default dengan satu seri. Baris lembar kerja 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![The inverted solid fill color](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Pada contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif sehingga efeknya terlihat:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mengosongkan Nilai Titik Data Tertentu**

Untuk membuat satu titik kosong tanpa menghapus titik‑titik lain, atur sel buku kerja yang mendasarinya menjadi `nullptr`. Untuk chart kolom, nilai yang diplot tersedia melalui [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Titik data tetap berada pada posisi kategori yang sama, tetapi chart memperlakukan nilainya sebagai kosong sesuai pengaturan nilai kosong chart.

Contoh berikut mengosongkan hanya titik kedua dalam seri pertama:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Chart sebar menggunakan sel X dan Y terpisah, dan chart gelembung juga menggunakan sel ukuran. Hanya kosongkan sel yang mewakili nilai yang ingin Anda hilangkan. Jangan panggil [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) ketika Anda ingin mempertahankan titik‑titik lain, karena metode tersebut menghapus semua titik data dari koleksi.

## **Mengontrol Tampilan Sel Kosong**

Sel tersembunyi yang berisi nilai merupakan kasus terpisah dari sel kosong. Untuk menyertakan atau mengecualikan data dari baris dan kolom lembar kerja yang tersembunyi, lihat [Include Data from Hidden Rows and Columns](/slides/id/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns).

Sel buku kerja kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Panggil [IChartDataCell::set_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_value/) dengan `nullptr` untuk membuat sel kosong. Nol numerik tetap nol terlepas dari pengaturan sel kosong.

Gunakan [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichart/set_displayblanksas/) untuk memilih bagaimana chart menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh chart. Ia mengubah cara kosong dipetakan, tanpa mengisi sel buku kerja kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat chart garis dengan satu seri, mengosongkan nilai untuk Hari 3, dan menyimpan chart yang sama dengan tiap mode. Tidak diperlukan file input. [IChartDataWorkbook](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/) menggunakan lembar kerja 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 memuat nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Biarkan Hari 3 benar-benar kosong, sambil mempertahankan kategori dan titik datanya.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

Setiap file output menyimpan mode yang ditetapkan sebelum penyimpanan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja alih‑alih mengiterasi semua mode.

Perbandingan di bawah ini menampilkan data yang sama di ketiga file. Hari 3 kosong di buku kerja dalam setiap kasus:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Efek yang terlihat tergantung pada tipe chart. Chart garis membuat ketiga mode mudah dibandingkan. Chart batang dan kolom tidak memiliki garis yang menghubungkan antar kategori yang hilang, sehingga `Span` tidak dapat menghasilkan segmen penghubung yang ditunjukkan di atas; kolom yang hilang dan kolom dengan tinggi nol dapat terlihat serupa. Demikian pula, chart sebar dengan hanya penanda tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil berbeda untuk setiap tipe chart; periksa output untuk tipe yang Anda gunakan.

## **Mengatur Lebar Celah Seri**

Lebar celah adalah ruang antara klaster batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti overlap, ini merupakan properti grup seri induk, bukan milik satu seri. Panggil [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) sekali untuk grup. Nilai yang lebih besar menciptakan lebih banyak ruang antara klaster; nilai yang lebih kecil membuatnya lebih padat.

Contoh berikut mengubah lebar celah dan menyimpan hanya presentasi akhir:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![The gap width](gap_width.png)

## **FAQ**

**Tipe chart apa yang mendukung data seri?**

Semua tipe chart yang direpresentasikan oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/) menggunakan data chart, tetapi serinya tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, chart kategori menggunakan kategori dan nilai, chart sebar menggunakan nilai X dan Y, dan chart gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe serinya. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri chart?**

Sebuah [IChartSeriesGroup](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseriesgroup/) berisi seri yang kompatibel dan berbagi pengaturan plotting tingkat grup. Chart kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang dicapai melalui satu seri tidak selalu mengubah setiap seri dalam chart.

**Apakah chart yang baru dibuat berisi data default?**

Ya. Secara default, [IShapeCollection::AddChart](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addchart/) membuat contoh seri, kategori, dan nilai. Anda dapat mengedit sel‑sel tersebut atau mengosongkan koleksi seri dan kategori sebelum menambahkan set data yang sepenuhnya khusus. Sebuah overload juga dapat membuat chart tanpa data default.

**Bagaimana objek chart terhubung ke sel buku kerja?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam sebuah [IChartDataWorkbook](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen chart yang bersangkutan. Saat Anda membangun data khusus, pertahankan baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara mengosongkan satu titik tanpa menghapus seluruh seri?**

Atur sel nilai terkait menjadi `nullptr` untuk mempertahankan posisi kategori titik sebagai titik kosong. Panggil [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) hanya ketika Anda berniat menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri agar nilai mereka tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe chart dan [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Chart yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik‑titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda. Lihat [Control the Display of Empty Cells](#control-the-display-of-empty-cells) untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, panggil [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) dan tetapkan warna melalui [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Anda dapat menimpa perilaku untuk titik individu dengan [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Metode‑metode ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Pemformatan mana yang menang ketika baik seri maupun titik diformat?**

Pemformatan titik data yang eksplisit memiliki prioritas untuk titik tersebut. Titik‑titik lain terus menggunakan format seri eksplisit atau, ketika format seri tidak didefinisikan, gaya dan tema chart otomatis. Pengaturan grup seperti overlap dan lebar celah mengontrol tata letak dan bukan penimpaan pemformatan tingkat titik.

**Apakah ada batas jumlah seri yang dapat dimiliki sebuah chart?**

Aspose.Slides tidak memberlakukan batas tetap terpisah untuk jumlah seri. Pada praktiknya, batas bergantung pada batasan file presentasi, memori yang tersedia, waktu rendering, dan keterbacaan chart.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu berjauhan?**

Panggil [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) pada grup seri induk yang sesuai. Tingkatkan nilai untuk memperlebar ruang antara klaster, atau turunkan nilai untuk mendekatkan klaster.