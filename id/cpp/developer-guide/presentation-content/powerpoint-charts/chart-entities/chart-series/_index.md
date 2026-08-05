---
title: Kelola Seri Data Diagram dalam Presentasi Menggunakan C++
linktitle: Seri Data
type: docs
url: /id/cpp/chart-series/
keywords:
- seri diagram
- tumpang tindih seri
- warna seri
- warna kategori
- nama seri
- titik data
- celah seri
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram dalam C++ untuk PowerPoint (PPT/PPTX) dengan contoh kode praktis dan praktik terbaik untuk meningkatkan presentasi data Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan peran [ChartSeries](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartseries/) dalam Aspose.Slides, berfokus pada cara data disusun dan divisualisasikan dalam presentasi. Objek‑objek ini menyediakan elemen dasar yang mendefinisikan set titik data individual, kategori, dan parameter tampilan dalam sebuah diagram. Dengan bekerja dengan [ChartSeries](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartseries/), pengembang dapat dengan mulus mengintegrasikan sumber data mendasar dan mempertahankan kontrol penuh atas cara informasi ditampilkan, menghasilkan presentasi yang dinamis dan berbasis data yang secara jelas menyampaikan wawasan dan analisis.

Sebuah seri adalah baris atau kolom angka yang digambar dalam sebuah diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Overlap Seri Data**

Dengan metode [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) Anda dapat menentukan seberapa banyak batang dan kolom harus tumpang tindih pada diagram 2D (rentang: -100 hingga 100). Properti ini berlaku untuk semua seri dalam grup seri induk: ini merupakan proyeksi properti grup yang sesuai.

Gunakan metode `get_ParentSeriesGroup()::set_Overlap()` untuk mengatur nilai `Overlap` yang Anda inginkan.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Tambahkan diagram kolom berkelompok pada sebuah slide.
3. Akses seri diagram pertama.
4. Akses `ParentSeriesGroup` seri diagram dan atur nilai overlap yang Anda inginkan untuk seri tersebut.
5. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Kode C++ ini menunjukkan cara mengatur overlap untuk sebuah seri diagram:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Menambahkan diagram
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Mengatur tumpang tindih seri
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Menulis file presentasi ke disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Ubah Warna Seri Data**

Aspose.Slides untuk C++ memungkinkan Anda mengubah warna seri dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Tambahkan diagram pada slide.
3. Akses seri yang warnanya ingin Anda ubah. 
4. Atur jenis isian dan warna isian yang Anda inginkan.
5. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara mengubah warna seri:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Ubah Warna Kategori Seri Data**

Aspose.Slides untuk C++ memungkinkan Anda mengubah warna kategori seri dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Tambahkan diagram pada slide.
3. Akses kategori seri yang warnanya ingin Anda ubah.
4. Atur jenis isian dan warna isian yang Anda inginkan.
5. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara mengubah warna kategori seri:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Ubah Nama Seri Data** 

Secara default, nama legenda untuk sebuah diagram adalah isi sel di atas setiap kolom atau baris data. 

Dalam contoh kami (gambar contoh),

* kolomnya adalah *Series 1, Series 2,* dan *Series 3*;
* barisnya adalah *Category 1, Category 2, Category 3,* dan *Category 4.* 

Aspose.Slides untuk C++ memungkinkan Anda memperbarui atau mengubah nama seri dalam data diagramnya dan legenda.

Kode C++ ini menunjukkan cara mengubah nama seri dalam `ChartDataWorkbook` data diagramnya:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Kode C++ ini menunjukkan cara mengubah nama seri melalui `Series` dalam legendanya:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Atur Warna Isi Seri Data**

Aspose.Slides untuk C++ memungkinkan Anda mengatur warna isi otomatis untuk seri diagram di dalam area plot dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default berdasarkan tipe yang Anda pilih (dalam contoh di bawah, kami menggunakan `ChartType::ClusteredColumn`).
4. Akses seri diagram dan atur warna isi ke Automatic.
5. Simpan presentasi ke file PPTX.

Kode C++ ini menunjukkan cara mengatur warna isi otomatis untuk sebuah seri diagram:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Membuat diagram kolom berkelompok
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Mengatur format isi seri ke otomatis
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Menulis file presentasi ke disk
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Atur Warna Isi Terbalik Seri Data**

Aspose.Slides memungkinkan Anda mengatur warna isi terbalik untuk seri diagram di dalam area plot dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default berdasarkan tipe yang Anda pilih (dalam contoh di bawah, kami menggunakan `ChartType::ClusteredColumn`).
4. Akses seri diagram dan atur warna isi ke invert.
5. Simpan presentasi ke file PPTX.

Kode C++ ini mendemonstrasikan operasi tersebut:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Atur Warna Isi Terbalik untuk Seri Diagram**

Aspose.Slides memungkinkan Anda mengatur pembalikan melalui metode `IChartDataPoint::set_InvertIfNegative()` dan `ChartDataPoint.set_InvertIfNegative()`. Ketika pembalikan diatur menggunakan metode tersebut, titik data akan membalik warnanya ketika mendapatkan nilai negatif. 

Kode C++ ini mendemonstrasikan operasi tersebut:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Bersihkan Nilai Titik Data Spesifik**

Aspose.Slides untuk C++ memungkinkan Anda membersihkan data `DataPoints` untuk seri diagram tertentu dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Dapatkan referensi diagram melalui indeksnya.
4. Iterasi semua `DataPoints` diagram dan setel `XValue` serta `YValue` ke null.
5. Bersihkan semua `DataPoints` untuk seri diagram tertentu.
6. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Kode C++ ini mendemonstrasikan operasi tersebut:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Atur Lebar Celah Seri Data**

Aspose.Slides untuk C++ memungkinkan Anda mengatur Lebar Celah seri melalui metode **`set_GapWidth()`** dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Akses seri diagram mana saja.
5. Atur properti `GapWidth`.
6. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Kode C++ ini menunjukkan cara mengatur Lebar Celah seri:

```cpp
// Membuat presentasi kosong 
auto presentation = System::MakeObject<Presentation>();

// Mengakses slide pertama presentasi
auto slide = presentation->get_Slides()->idx_get(0);

// Menambahkan diagram dengan data default
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Mengatur indeks lembar data diagram
int32_t worksheetIndex = 0;

// Mendapatkan lembar kerja data diagram
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Menambahkan seri
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Menambahkan Kategori
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Mengambil seri diagram kedua
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Mengisi data seri
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Mengatur nilai GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Menyimpan presentasi ke disk
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah ada batasan berapa banyak seri yang dapat dimiliki satu diagram?**

Aspose.Slides tidak menetapkan batas tetap pada jumlah seri yang Anda tambahkan. Batas praktis ditentukan oleh keterbacaan diagram dan oleh memori yang tersedia untuk aplikasi Anda.

**Bagaimana jika kolom dalam sebuah klaster terlalu berdekatan atau terlalu jauh satu sama lain?**

Sesuaikan pengaturan Lebar Celah untuk seri tersebut (atau grup seri induknya). Meningkatkan nilai memperlebar ruang antar kolom, sementara menurunkannya membuat kolom lebih dekat satu sama lain.