---
title: Terapkan Formula Lembar Kerja Diagram dalam Presentasi Menggunakan C++
linktitle: Formula Lembar Kerja
type: docs
weight: 70
url: /id/cpp/chart-worksheet-formulas/
keywords:
- spreadsheet diagram
- lembar kerja diagram
- formula diagram
- formula lembar kerja
- formula spreadsheet
- buku kerja data diagram
- perhitungan formula
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
description: "Terapkan formula bergaya Excel dalam lembar kerja diagram Aspose.Slides untuk C++, hitung ulang nilai, dan gunakan hasilnya dalam diagram PowerPoint."
---
## **Gambaran Umum**

Diagram PowerPoint biasanya menyimpan data sumbernya dalam lembar kerja yang disisipkan. Dalam Aspose.Slides untuk C++, Anda dapat mengakses lembar kerja tersebut melalui workbook data diagram, menulis nilai input, menetapkan formula ke sel, menghitung formula yang didukung, dan menggunakan sel yang dihitung sebagai data diagram.

Artikel ini menjelaskan alur kerja formula lengkap: membuat diagram, mengisi lembar kerjanya, menetapkan formula gaya A1 atau R1C1, menghitung ulang formula, membaca nilai yang dihitung, menghubungkan sel tersebut ke seri diagram, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks formula yang didukung, subset fungsi bawaan, nilai cache, formula yang tidak didukung, dan kesalahan khusus spreadsheet.

## **Lembar Kerja Diagram dan Formula**

Lembar kerja diagram berisi kategori, nama seri, dan nilai yang digunakan oleh sebuah diagram. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka penyunting data diagram:

![Diagram PowerPoint dengan lembar kerja tersemat terbuka, menampilkan data kategori dan seri](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspos melalui antarmuka [IChartDataWorkbook](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/). Gunakan [IChartDataCell::set_Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_formula/) untuk formula gaya A1 dan [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) untuk formula gaya R1C1. Setelah mengubah sel input atau formula, panggil [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) untuk menghitung ulang formula yang didukung dan memperbarui nilai sel yang bersangkutan.

Sel yang dihitung tetap mengekspos hasilnya melalui [IChartDataCell::get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/get_value/). Hal ini penting ketika Anda perlu memeriksa hasil formula dalam kode atau menggunakan sel sebagai titik data diagram.

## **Buat Diagram dan Hitung Formula Lembar Kerja**

Contoh berikut memperlihatkan alur kerja menyeluruh. Ia membuat diagram kolom berkelompok, membersihkan data contoh, menulis nilai pendapatan dan pengeluaran kuartalan, menghitung laba dengan formula, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai diagram, dan menyimpan presentasi.

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

Titik data diagram merujuk ke `D2:D4`, sehingga diagram menggunakan nilai laba yang dihitung. Tidak ada panggilan penyegaran diagram terpisah dalam alur kerja ini: hitung ulang workbook terlebih dahulu, kemudian gunakan atau simpan data diagram yang menunjuk ke sel yang dihitung.

## **Gunakan Formula Gaya A1**

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

Referensi relatif dapat berubah ketika formula dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sedangkan referensi campuran hanya mengunci baris atau kolom.

## **Gunakan Formula Gaya R1C1**

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

Sebagai contoh, pada sel `D2`, `RC[-2]` berarti sel di baris yang sama dua kolom ke kiri (`B2`).

## **Konstanta dan Operator Formula**

Penilai formula bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmetika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks dikelilingi tanda kutip ganda di dalam formula. |
| Hasil kesalahan | `#DIV/0!`, `#N/A`, `#REF!` | Formula yang valid dapat mengevaluasi menjadi nilai kesalahan spreadsheet alih-alih hasil normal. |

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

### **Operator Aritmatika**

| Operator | Makna | Contoh |
|---|---|---|
| `+` | Penjumlahan atau plus unary | `2+3` |
| `-` | Pengurangan atau negasi | `2-3`, `-3` |
| `*` | Perkalian | `2*3` |
| `/` | Pembagian | `2/3` |
| `%` | Persen | `30%` |
| `^` | Eksponensial | `2^3` |

Gunakan tanda kurung untuk membuat urutan evaluasi eksplisit, misalnya `(A2+B2)*C2`.

### **Operator Perbandingan**

Ekspresi perbandingan mengembalikan nilai logika.

| Operator | Makna | Contoh |
|---|---|---|
| `=` | Sama dengan | `A2=3` |
| `<>` | Tidak sama dengan | `A2<>3` |
| `>` | Lebih besar dari | `A2>3` |
| `>=` | Lebih besar atau sama dengan | `A2>=3` |
| `<` | Kurang dari | `A2<3` |
| `<=` | Kurang atau sama dengan | `A2<=3` |

## **Fungsi Pradefinisi yang Didukung**

Aspose.Slides mencakup penilai formula bawaan untuk lembar kerja diagram, tetapi bukan mesin perhitungan Excel lengkap. Set fungsi yang didokumentasikan terbatas pada fungsi di bawah ini. Jangan mengasumsikan bahwa fungsi Excel arbitrer dapat dihitung ulang oleh [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Fungsi | Tujuan atau bentuk yang didukung | Contoh |
|---|---|---|
| `ABS` | Nilai absolut | `ABS(A2)` |
| `AVERAGE` | Rata‑rata aritmetika | `AVERAGE(B2:B5)` |
| `CEILING` | Membulatkan angka ke atas ke kelipatan | `CEILING(A2,5)` |
| `CHOOSE` | Memilih nilai berdasarkan indeks | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Menggabungkan nilai teks | `CONCAT(A2,B2)` |
| `CONCATENATE` | Menggabungkan nilai teks | `CONCATENATE(A2," ",B2)` |
| `DATE` | Membuat nilai tanggal menggunakan sistem tanggal 1900 | `DATE(2026,8,19)` |
| `DAYS` | Mengembalikan jumlah hari antara tanggal | `DAYS(B2,A2)` |
| `FIND` | Menemukan satu nilai teks di dalam nilai lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil kondisional | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlahkan nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan yang ditunjukkan dalam tabel signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sementara `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektornya. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh penilai formula Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Perhitungan Ulang dan Nilai Cache**

File spreadsheet biasanya menyimpan baik formula maupun nilai terakhir yang dihitung. Aspose.Slides dapat membaca nilai cache dari [IChartDataCell::get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/get_value/) ketika presentasi dimuat dan data diagram terkait belum diubah.

Setelah mengubah sel input atau formula, jangan mengandalkan hasil cache lama. Panggil [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) sebelum membaca nilai yang dihitung atau menyimpan data diagram yang bergantung padanya.

Untuk formula di luar subset yang didukung, Aspose.Slides mungkin tidak dapat menguraikan formula atau menentukan dependensinya. Jika workbook telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi ini, membaca nilai sel dengan data yang tidak didukung dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Jika diagram Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung formula tersebut dengan mesin spreadsheet yang mendukungnya dan tuliskan nilai hasilnya kembali ke workbook diagram. Jangan mengganti formula yang tidak didukung dengan nilai dugaan.

## **Tangani Kesalahan Formula**

Ada dua jenis masalah yang perlu dibedakan.

Sebuah formula dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token kesalahan adalah hasil sel dan dapat dikembalikan melalui [IChartDataCell::get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Sebuah formula juga dapat gagal pada tingkat penguraian, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian khusus spreadsheet untuk kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ketika formula berasal dari templat atau masukan pengguna, tangani pengecualian ini di sekitar perhitungan ulang dan akses nilai:

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
    // Tangani formula yang tidak valid.
}
catch (CellInvalidReferenceException&)
{
    // Tangani referensi sel yang tidak valid.
}
catch (CellCircularReferenceException&)
{
    // Tangani referensi sirkular.
}
catch (CellUnsupportedDataException&)
{
    // Tangani data spreadsheet yang tidak didukung.
}
```

## **Batasan Praktis**

Dukungan formula pada lembar kerja diagram ditujukan untuk subset perhitungan spreadsheet yang terdefinisi, bukan untuk kompatibilitas Excel penuh. Ingat batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang didokumentasikan ketika Anda membutuhkan Aspose.Slides untuk menghitung ulang formula.
- Hitung ulang setelah mengubah sel yang menjadi dasar hasil formula.
- Anggap nilai cache dari presentasi yang dimuat sebagai snapshot, bukan sebagai pengganti perhitungan ulang setelah penyuntingan.
- Uji formula dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka memakai fungsi di luar daftar yang didokumentasikan.
- Untuk formula yang memerlukan mesin perhitungan spreadsheet lengkap, hitunglah secara eksternal lalu perbarui workbook diagram dengan nilai hasilnya.

## **FAQ**

**Apa perbedaan antara `set_Formula` dan `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_formula/) menyimpan ekspresi gaya A1 seperti `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling cocok dengan cara Anda menghasilkan atau menyalin formula.

**Apakah saya perlu membaca sel itu sendiri atau nilai sel setelah perhitungan?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) mengembalikan sebuah `IChartDataCell`. Untuk memperoleh hasil yang dihitung, baca nilai [IChartDataCell::get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatacell/get_value/) sel tersebut setelah perhitungan ulang.

**Kapan saya harus memanggil `CalculateFormulas`?**

Panggil [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) setelah mengubah nilai input atau formula dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai formula yang didukung oleh penilai bawaan.

**Apakah Aspose.Slides mendukung semua fungsi Excel?**

Tidak. Penilai bawaan mendukung subset fungsi yang didokumentasikan. Fungsi di luar subset tersebut tidak boleh dianggap dapat dihitung ulang dengan benar. Jika kompatibilitas formula Excel penuh diperlukan, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tuliskan nilai akhir ke workbook diagram.

**Apa yang terjadi jika presentasi yang dimuat berisi formula yang tidak didukung?**

Jika data diagram belum berubah, workbook mungkin masih berisi nilai cache yang dihitung sebelumnya. Setelah data terkait dimodifikasi, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang formulanya tidak dapat ditangani dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Apakah nilai kesalahan formula sama dengan pengecualian C++?**

Tidak. Hasil seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Pengecualian seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) menunjukkan bahwa formula tidak dapat diproses secara normal.

**Apakah diagram memperbarui secara otomatis ketika sel formula berubah?**

Seri diagram dapat merujuk ke sel workbook. Hitung ulang workbook terlebih dahulu, lalu simpan atau render presentasi. Jika titik data diagram merujuk ke sel yang dihitung, diagram akan menggunakan nilai sel yang telah diperbarui; tidak diperlukan metode penyegaran diagram terpisah untuk alur kerja ini.

**Dapatkah diagram menggunakan workbook Excel eksternal?**

Ya, data diagram dapat dikonfigurasi untuk menggunakan workbook eksternal melalui API data diagram. Namun, alur kerja perhitungan formula yang dijelaskan dalam artikel ini berkaitan dengan workbook data diagram dan subset formula yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) menyediakan perhitungan penuh untuk formula arbitrer dalam file XLSX eksternal.

**Bisakah saya menggunakan formula yang merujuk ke lembar kerja atau workbook lain?**

Referensi gaya Excel mungkin ada dalam workbook diagram, tetapi evaluasi formula dibatasi oleh parser dan set fungsi yang didukung. Jika referensi lintas lembar atau eksternal penting, validasi formula tersebut dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel yang luas, hitung workbook secara eksternal dan tuliskan nilai yang telah diselesaikan kembali ke data diagram.

**Apakah string formula harus diawali dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa awalan `=`. Menggunakan bentuk ini menjaga konsistensi formula dengan contoh API yang didokumentasikan.