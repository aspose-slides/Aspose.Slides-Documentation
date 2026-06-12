---
title: Sesuaikan Sumbu Diagram dalam Presentasi Menggunakan С++
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
- С++
- Aspose.Slides
description: "Temukan cara menggunakan Aspose.Slides untuk С++ untuk menyesuaikan sumbu diagram dalam presentasi PowerPoint untuk laporan dan visualisasi."
---
## **Ringkasan**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram dalam Aspose.Slides. Ini menunjukkan cara mendapatkan nilai sumbu sebenarnya, menukar data antara sumbu, menyembunyikan sumbu vertikal atau horizontal untuk diagram garis, mengubah tipe sumbu kategori, mengatur format tanggal untuk nilai sumbu kategori, memutar judul sumbu, mengatur posisi sumbu, dan menampilkan label satuan pada sumbu nilai.

## **Dapatkan Nilai Maksimum pada Sumbu Vertikal**
Aspose.Slides untuk C++ memungkinkan Anda memperoleh nilai minimum dan maksimum pada sumbu vertikal. Ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Dapatkan nilai maksimum aktual pada sumbu.
5. Dapatkan nilai minimum aktual pada sumbu.
6. Dapatkan satuan utama aktual pada sumbu.
7. Dapatkan satuan minor aktual pada sumbu.
8. Dapatkan skala satuan utama aktual pada sumbu.
9. Dapatkan skala satuan minor aktual pada sumbu.

Kode contoh—implementasi langkah‑langkah di atas—menunjukkan cara mendapatkan nilai yang diperlukan dalam C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Menyimpan presentasi
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Tukar Data antara Sumbu**
Aspose.Slides memungkinkan Anda dengan cepat menukar data antara sumbu—data yang ditampilkan pada sumbu vertikal (y‑axis) dipindahkan ke sumbu horizontal (x‑axis) dan sebaliknya.

Kode C++ berikut menunjukkan cara melakukan penukaran data antara sumbu pada diagram:

``` cpp
// Membuat presentasi kosong
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Menukar baris dan kolom
chart->get_ChartData()->SwitchRowColumn();

// Menyimpan presentasi
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Nonaktifkan Sumbu Vertikal untuk Diagram Garis**

Kode C++ berikut menunjukkan cara menyembunyikan sumbu vertikal untuk diagram garis:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Nonaktifkan Sumbu Horizontal untuk Diagram Garis**

Kode ini menunjukkan cara menyembunyikan sumbu horizontal untuk diagram garis:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Ubah Sumbu Kategori**

Dengan metode **set_CategoryAxisType()**, Anda dapat menentukan tipe sumbu kategori yang diinginkan (**date** atau **text**). Kode C++ berikut mendemonstrasikan operasinya:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Atur Format Tanggal untuk Nilai Sumbu Kategori**
Aspose.Slides untuk C++ memungkinkan Anda mengatur format tanggal untuk nilai sumbu kategori. Operasi ini ditunjukkan dalam kode C++ berikut:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Atur Sudut Rotasi untuk Judul Sumbu**
Aspose.Slides untuk C++ memungkinkan Anda mengatur sudut rotasi untuk judul sumbu diagram. Kode C++ berikut mendemonstrasikan operasinya:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Atur Posisi Sumbu pada Sumbu Kategori atau Nilai**
Aspose.Slides untuk C++ memungkinkan Anda mengatur posisi sumbu pada sumbu kategori atau nilai. Kode C++ berikut menunjukkan cara melakukan tugas tersebut:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Aktifkan Label Satuan pada Sumbu Nilai Diagram**
Aspose.Slides untuk C++ memungkinkan Anda mengonfigurasi diagram agar menampilkan label satuan pada sumbu nilai diagram. Kode C++ berikut mendemonstrasikan operasinya:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Bagaimana cara mengatur nilai di mana satu sumbu memotong sumbu lainnya (axis crossing)?**

Sumbu menyediakan [crossing setting](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/axis/set_crosstype/): Anda dapat memilih untuk memotong pada nol, pada kategori/nilai maksimum, atau pada nilai numerik tertentu. Ini berguna untuk menggeser sumbu X ke atas atau ke bawah atau untuk menekankan garis dasar.

**Bagaimana saya dapat memposisikan label tick relatif terhadap sumbu (di samping, di luar, di dalam)?**

Atur [label position](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/axis/set_majortickmark/) menjadi "cross", "outside", atau "inside". Ini memengaruhi keterbacaan dan membantu menghemat ruang, terutama pada diagram kecil.