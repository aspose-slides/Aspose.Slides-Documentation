---
title: Menerapkan Rumus Lembar Kerja Diagram dalam Presentasi Menggunakan C++
linktitle: Rumus Lembar Kerja
type: docs
weight: 70
url: /id/cpp/chart-worksheet-formulas/
keywords:
- spreadsheet bagan
- lembar kerja bagan
- rumus bagan
- rumus lembar kerja
- rumus spreadsheet
- buku kerja data bagan
- perhitungan rumus
- budaya yang diutamakan
- rumus khusus budaya
- DBCS
- konstanta logika
- konstanta numerik
- konstanta string
- konstanta kesalahan
- operator aritmetika
- operator perbandingan
- gaya A1
- gaya R1C1
- fungsi pradefinisi
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Menerapkan rumus gaya Excel dalam Aspose.Slides untuk lembar kerja bagan C++, menghitung ulang nilai, dan menggunakan hasilnya dalam diagram PowerPoint."
---
## **Gambaran Umum**

Diagram PowerPoint biasanya menyimpan data sumbernya dalam lembar kerja yang tersemat. Dalam Aspose.Slides untuk C++, Anda dapat mengakses lembar kerja tersebut melalui buku kerja data diagram, menulis nilai masukan, menetapkan rumus ke sel, menghitung rumus yang didukung, dan menggunakan sel yang dihitung sebagai data diagram.

Artikel ini menjelaskan alur kerja rumus secara lengkap: membuat diagram, mengisi lembar kerja, menetapkan rumus gaya A1 atau R1C1, menghitung ulang, membaca nilai yang dihitung, menghubungkan sel‑sel tersebut ke seri diagram, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks rumus yang didukung, subset fungsi bawaan, nilai yang di‑cache, rumus yang tidak didukung, serta kesalahan khusus spreadsheet.

## **Lembar Kerja Diagram dan Rumus**

Lembar kerja diagram berisi kategori, nama seri, dan nilai yang digunakan oleh sebuah diagram. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka editor data diagram:

![Diagram PowerPoint dengan lembar kerja tersemat terbuka, menampilkan data kategori dan seri](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspose melalui antarmuka [IChartDataWorkbook](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/). Gunakan [IChartDataCell::set_Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_formula/) untuk rumus gaya A1 dan [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) untuk rumus gaya R1C1. Setelah mengubah sel masukan atau rumus, panggil [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) untuk menghitung ulang rumus yang didukung dan memperbarui nilai sel yang bersangkutan.

Sel yang dihitung tetap dapat mengungkapkan hasilnya melalui [IChartDataCell::get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/get_value/). Ini penting ketika Anda perlu memeriksa hasil rumus dalam kode atau menggunakan sel sebagai titik data diagram.

## **Membuat Diagram dan Menghitung Rumus Lembar Kerja**

Contoh berikut menunjukkan alur kerja ujung‑ke‑ujung. Ia membuat diagram kolom berkelompok, menghapus data contoh, menulis nilai pendapatan dan pengeluaran triwulanan, menghitung laba dengan rumus, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai diagram, dan menyimpan presentasi.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Titik data diagram merujuk ke `D2:D4`, sehingga diagram menggunakan nilai laba yang telah dihitung. Tidak ada pemanggilan refresh diagram terpisah dalam alur kerja ini: hitung ulang buku kerja terlebih dahulu, lalu gunakan atau simpan data diagram yang menunjuk ke sel‑sel yang telah dihitung.

## **Menggunakan Rumus Gaya A1**

Notasi A1 mengidentifikasi kolom dengan huruf dan baris dengan angka. Tetapkan ekspresi gaya A1 melalui [IChartDataCell::set_Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Bentuk referensi A1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `A2` | `$A$2` | `A$2`, `$A2` |
| Baris | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Rentang | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika rumus dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sedangkan referensi campuran memperbaiki hanya baris atau kolom saja.

## **Menggunakan Rumus Gaya R1C1**

Notasi R1C1 mengidentifikasi baik baris maupun kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Bentuk referensi R1C1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Baris | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Rentang | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Sebagai contoh, dalam sel `D2`, `RC[-2]` berarti sel pada baris yang sama dua kolom ke kiri (`B2`).

## **Konstanta dan Operator Rumus**

Evaluator rumus bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmetika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks dikelilingi tanda kutip ganda di dalam rumus. |
| Hasil Kesalahan | `#DIV/0!`, `#N/A`, `#REF!` | Rumus yang valid dapat dievaluasi menjadi nilai kesalahan spreadsheet alih‑alih hasil normal. |

Contoh ini menggunakan beberapa tipe konstanta:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // False
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Operator Aritmetika**

| Operator | Arti | Contoh |
|---|---|---|
| `+` | Penjumlahan atau tanda plus unary | `2+3` |
| `-` | Pengurangan atau negasi | `2-3`, `-3` |
| `*` | Perkalian | `2*3` |
| `/` | Pembagian | `2/3` |
| `%` | Persen | `30%` |
| `^` | Pangkat | `2^3` |

Gunakan tanda kurung untuk membuat urutan evaluasi eksplisit, misalnya `(A2+B2)*C2`.

### **Operator Perbandingan**

Ekspresi perbandingan mengembalikan nilai logika.

| Operator | Arti | Contoh |
|---|---|---|
| `=` | Sama dengan | `A2=3` |
| `<>` | Tidak sama dengan | `A2<>3` |
| `>` | Lebih besar dari | `A2>3` |
| `>=` | Lebih besar atau sama dengan | `A2>=3` |
| `<` | Lebih kecil dari | `A2<3` |
| `<=` | Lebih kecil atau sama dengan | `A2<=3` |

## **Fungsi Pradefinisi yang Didukung**

Aspose.Slides menyertakan evaluator rumus bawaan untuk lembar kerja diagram, namun bukan mesin perhitungan Excel lengkap. Set fungsi yang terdokumentasi terbatas pada fungsi di bawah ini. Jangan menganggap bahwa fungsi Excel sembarangan dapat dihitung ulang oleh [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Fungsi | Tujuan atau bentuk yang didukung | Contoh |
|---|---|---|
| `ABS` | Nilai absolut | `ABS(A2)` |
| `AVERAGE` | Rata‑rata aritmetika | `AVERAGE(B2:B5)` |
| `CEILING` | Membulatkan ke atas ke kelipatan | `CEILING(A2,5)` |
| `CHOOSE` | Memilih nilai berdasarkan indeks | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Menggabungkan nilai teks | `CONCAT(A2,B2)` |
| `CONCATENATE` | Menggabungkan nilai teks | `CONCATENATE(A2," ",B2)` |
| `DATE` | Membuat nilai tanggal dengan sistem tanggal 1900 | `DATE(2026,8,19)` |
| `DAYS` | Mengembalikan jumlah hari antara dua tanggal | `DAYS(B2,A2)` |
| `FIND` | Menemukan satu nilai teks di dalam nilai lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil bersyarat | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlahkan nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan yang ditunjukkan dalam tabel bersifat signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sementara `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektor. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator rumus Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Menghitung Rumus dengan Budaya yang Diutamakan**

Beberapa fungsi buku kerja diagram menafsirkan teks menurut aturan budaya‑spesifik. Ini terutama penting untuk fungsi yang ditujukan bagi bahasa yang menggunakan set karakter ganda byte (DBCS). Untuk menghitung rumus tersebut secara tepat, buat [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/), konfigurasikan [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/id/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) melalui [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), lalu muat presentasi.

Contoh berikut memilih budaya Jepang, membuka presentasi dengan opsi muat yang telah dikonfigurasi, dan memanggil [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) untuk setiap buku kerja diagram:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

Budaya yang diutamakan merupakan bagian dari konfigurasi pemuatan presentasi, sehingga tentukan sebelum membuat instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Gunakan budaya yang diharapkan oleh rumus buku kerja; misalnya, gunakan `ja-JP` untuk rumus yang harus mengikuti aturan perhitungan DBCS Jepang.

## **Perhitungan Ulang dan Nilai yang Di‑Cache**

File spreadsheet biasanya menyimpan baik rumus maupun nilai yang terakhir dihitung. Aspose.Slides dapat membaca nilai ter‑cache dari [IChartDataCell::get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/get_value/) saat presentasi dimuat dan data diagram yang bersangkutan belum diubah.

Setelah mengubah sel masukan atau rumus, jangan mengandalkan hasil ter‑cache yang lama. Panggil [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) sebelum membaca nilai yang dihitung atau menyimpan data diagram yang bergantung padanya.

Untuk rumus di luar subset yang didukung, Aspose.Slides mungkin tidak dapat mengurai rumus atau menetapkan dependensinya. Jika buku kerja telah dimodifikasi, nilai ter‑cache sebelumnya tidak lagi dapat diandalkan. Dalam situasi tersebut, membaca nilai sel dengan data yang tidak didukung dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Jika diagram Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung rumus tersebut dengan mesin spreadsheet yang mendukungnya dan tulis kembali nilai yang dihasilkan ke buku kerja diagram. Jangan mengganti rumus yang tidak didukung dengan nilai tebakan.

## **Menangani Kesalahan Rumus**

Ada dua jenis masalah yang berbeda.

Sebuah rumus dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token kesalahan adalah hasil sel dan dapat dikembalikan melalui [IChartDataCell::get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Sebuah rumus juga dapat gagal pada tingkat parsing, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian khusus spreadsheet untuk kasus‑kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ketika rumus berasal dari templat atau input pengguna, tangani pengecualian‑pengecualian ini di sekitar perhitungan ulang dan akses nilai:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Tangani rumus yang tidak valid.
}
catch (CellInvalidReferenceException&)
{
    // Tangani referensi sel yang tidak valid.
}
catch (CellCircularReferenceException&)
{
    // Tangani referensi melingkar.
}
catch (CellUnsupportedDataException&)
{
    // Tangani data spreadsheet yang tidak didukung.
}
```

## **Batasan Praktis**

Dukungan rumus dalam lembar kerja diagram ditujukan untuk subset perhitungan spreadsheet yang terdefinisi, bukan untuk kompatibilitas Excel penuh. Ingatkan batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang didokumentasikan ketika Anda memerlukan Aspose.Slides untuk menghitung ulang rumus.
- Hitung ulang setelah mengubah sel yang memengaruhi hasil rumus.
- Anggap nilai yang di‑cache dari presentasi yang dimuat sebagai snapshot, bukan sebagai pengganti perhitungan ulang setelah penyuntingan.
- Uji rumus dari templat yang ada sebelum bergantung pada nilai yang dihitung, terutama bila mereka menggunakan fungsi di luar daftar yang terdokumentasi.
- Untuk rumus yang memerlukan mesin perhitungan spreadsheet penuh, hitung secara eksternal lalu perbarui buku kerja diagram dengan nilai yang dihasilkan.

## **FAQ**

**Apa perbedaan antara `set_Formula` dan `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_formula/) menyimpan ekspresi gaya A1 seperti `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling cocok dengan cara Anda menghasilkan atau menyalin rumus.

**Apakah saya perlu membaca sel itu sendiri atau nilai setelah perhitungan?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) mengembalikan sebuah `IChartDataCell`. Untuk mendapatkan hasil yang dihitung, baca nilai [IChartDataCell::get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/get_value/) sel tersebut setelah perhitungan ulang.

**Kapan saya harus memanggil `CalculateFormulas`?**

Panggil [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) setelah mengubah nilai masukan atau rumus dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai rumus yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung setiap fungsi Excel?**

Tidak. Evaluator bawaan mendukung subset fungsi yang terdokumentasi. Fungsi di luar subset tersebut tidak boleh diasumsikan dapat dihitung ulang dengan benar. Jika kompatibilitas rumus Excel penuh diperlukan, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tulis nilai akhir ke buku kerja diagram.

**Apa yang terjadi jika presentasi yang dimuat berisi rumus yang tidak didukung?**

Jika data diagram tidak berubah, buku kerja mungkin masih berisi nilai ter‑cache yang sebelumnya telah dihitung. Setelah data terkait dimodifikasi, nilai ter‑cache tersebut mungkin tidak lagi valid. Mengakses sel yang rumusnya tidak dapat ditangani dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Apakah nilai kesalahan rumus sama dengan pengecualian C++?**

Tidak. Nilai seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Pengecualian seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) menunjukkan bahwa rumus tidak dapat diproses secara normal.

**Apakah diagram memperbarui secara otomatis ketika sel rumus berubah?**

Seri diagram dapat merujuk ke sel buku kerja. Hitung ulang buku kerja terlebih dahulu, lalu simpan atau render presentasi. Jika titik data diagram merujuk ke sel yang dihitung, diagram akan menggunakan nilai sel yang diperbarui; tidak ada metode refresh diagram terpisah yang diperlukan untuk alur kerja ini.

**Dapatkah diagram menggunakan buku kerja Excel eksternal?**

Ya, data diagram dapat dikonfigurasi untuk menggunakan buku kerja eksternal melalui API data diagram. Namun, alur kerja perhitungan rumus yang dijelaskan dalam artikel ini berfokus pada buku kerja data diagram dan subset rumus yang dievaluasi oleh Aspose.Slides. Jangan menganggap bahwa [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) menyediakan perhitungan penuh untuk rumus sembarangan dalam file XLSX eksternal.

**Dapatkah saya menggunakan rumus yang merujuk ke lembar kerja atau buku kerja lain?**

Referensi gaya Excel dapat muncul dalam buku kerja diagram, tetapi evaluasi rumus dibatasi oleh parser dan set fungsi yang didukung. Jika referensi lintas‑lembar atau eksternal penting, validasi rumus tersebut dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel luas, hitung buku kerja secara eksternal dan tulis kembali nilai yang telah diselesaikan ke data diagram.

**Haruskah string rumus dimulai dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa awalan `=`. Menggunakan bentuk tersebut menjaga konsistensi rumus dengan contoh API yang terdokumentasi.