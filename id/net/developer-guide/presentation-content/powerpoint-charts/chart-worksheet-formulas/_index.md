---
title: Terapkan Formula Worksheet Chart dalam Presentasi di .NET
linktitle: Formula Worksheet
type: docs
weight: 70
url: /id/net/chart-worksheet-formulas/
keywords:
- spreadsheet chart
- lembar kerja chart
- formula grafik
- formula lembar kerja
- formula spreadsheet
- buku kerja data chart
- perhitungan formula
- budaya yang diutamakan
- formula spesifik budaya
- DBCS
- konstanta logika
- konstanta numerik
- konstanta string
- konstanta kesalahan
- operator aritmetika
- operator perbandingan
- gaya A1
- gaya R1C1
- fungsi bawaan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Terapkan formula bergaya Excel dalam worksheet chart Aspose.Slides untuk .NET, hitung ulang nilai, dan gunakan hasilnya dalam chart PowerPoint."
---
## **Ikhtisar**

Chart PowerPoint biasanya menyimpan data sumbernya dalam worksheet yang tertanam. Di Aspose.Slides untuk .NET, Anda dapat mengakses worksheet tersebut melalui chart data workbook, menulis nilai input, menetapkan formula ke sel, menghitung formula yang didukung, dan menggunakan sel yang dihitung sebagai data chart.

Artikel ini menjelaskan alur kerja formula lengkap: membuat chart, mengisi worksheet-nya, menetapkan formula gaya A1 atau R1C1, menghitung ulang, membaca nilai yang dihitung, menghubungkan sel tersebut ke seri chart, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks formula yang didukung, subset fungsi bawaan, nilai cache, formula yang tidak didukung, dan error khusus spreadsheet.

## **Worksheet Chart dan Formula**

Worksheet chart berisi kategori, nama seri, dan nilai yang digunakan oleh chart. Di PowerPoint, Anda dapat memeriksa worksheet dengan membuka editor data chart:

![PowerPoint chart dengan worksheet tertanam terbuka, menampilkan data kategori dan seri](chart-worksheet-formulas_1.png)

Di Aspose.Slides, worksheet diekspos melalui [chart data workbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/). Gunakan properti [Formula](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/formula/) untuk formula gaya A1 dan properti [R1C1Formula](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/r1c1formula/) untuk formula gaya R1C1. Setelah mengubah sel input atau formula, panggil [CalculateFormulas](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) untuk menghitung ulang formula yang didukung dan memperbarui nilai sel yang bersesuaian.

Sel yang dihitung tetap mengekspos hasilnya melalui properti [Value](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/value/). Ini penting ketika Anda perlu memeriksa hasil formula dalam kode atau menggunakan sel sebagai titik data chart.

## **Membuat Chart dan Menghitung Formula Worksheet**

Contoh berikut menunjukkan alur kerja end‑to‑end. Ia membuat chart kolom berkelompok, menghapus data contoh, menulis nilai pendapatan dan pengeluaran kuartalan, menghitung laba dengan formula, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai chart, dan menyimpan presentasi.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Poin data chart merujuk ke `D2:D4`, sehingga chart menggunakan nilai laba yang dihitung. Tidak ada pemanggilan refresh chart terpisah dalam alur kerja ini: hitung ulang workbook terlebih dahulu, lalu gunakan atau simpan data chart yang menunjuk ke sel yang dihitung.

## **Gunakan Formula Gaya A1**

Notasi A1 mengidentifikasi kolom dengan huruf dan baris dengan angka. Tetapkan ekspresi gaya A1 melalui [IChartDataCell.Formula](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Bentuk referensi A1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `A2` | `$A$2` | `A$2`, `$A2` |
| Baris | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Rentang | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika formula dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sedangkan referensi campuran memperbaiki hanya baris atau kolom saja.

## **Gunakan Formula Gaya R1C1**

Notasi R1C1 mengidentifikasi baris dan kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Bentuk referensi R1C1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Baris | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Rentang | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Sebagai contoh, pada sel `D2`, `RC[-2]` berarti sel pada baris yang sama dua kolom ke kiri (`B2`).

## **Konstanta dan Operator Formula**

Evaluator formula bawaan mendukung nilai logika, literal numerik, string, nilai error spreadsheet, operator aritmetika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks dikelilingi tanda kutip ganda di dalam formula. |
| Hasil error | `#DIV/0!`, `#N/A`, `#REF!` | Formula yang valid dapat mengevaluasi menjadi nilai error spreadsheet alih‑alih hasil normal. |

Contoh ini menggunakan beberapa jenis konstanta:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // False
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Operator Aritmetika**

| Operator | Makna | Contoh |
|---|---|---|
| `+` | Penjumlahan atau unary plus | `2+3` |
| `-` | Pengurangan atau negasi | `2-3`, `-3` |
| `*` | Perkalian | `2*3` |
| `/` | Pembagian | `2/3` |
| `%` | Persen | `30%` |
| `^` | Pangkat | `2^3` |

Gunakan tanda kurung untuk membuat urutan evaluasi eksplisit, misalnya `(A2+B2)*C2`.

### **Operator Perbandingan**

Ekspresi perbandingan mengembalikan nilai logika.

| Operator | Makna | Contoh |
|---|---|---|
| `=` | Sama dengan | `A2=3` |
| `<>` | Tidak sama dengan | `A2<>3` |
| `>` | Lebih besar dari | `A2>3` |
| `>=` | Lebih besar atau sama dengan | `A2>=3` |
| `<` | Lebih kecil dari | `A2<3` |
| `<=` | Lebih kecil atau sama dengan | `A2<=3` |

## **Fungsi Bawaan yang Didukung**

Aspose.Slides menyertakan evaluator formula bawaan untuk worksheet chart, tetapi bukan mesin perhitungan Excel lengkap. Set fungsi yang terdokumentasi terbatas pada fungsi di bawah ini. Jangan mengasumsikan bahwa fungsi Excel sembarang dapat dihitung ulang oleh [CalculateFormulas](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

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
| `FIND` | Menemukan satu nilai teks di dalam yang lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil bersyarat | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlahkan nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan dalam tabel signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sementara `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektornya. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator formula Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Menghitung Formula dengan Budaya yang Diutamakan**

Beberapa fungsi workbook chart menginterpretasikan teks sesuai aturan budaya‑spesifik. Ini terutama penting untuk fungsi yang ditujukan bagi bahasa yang menggunakan set karakter ganda (DBCS). Untuk menghitung formula tersebut dengan benar, buat [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/), setel [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/id/net/aspose.slides/ispreadsheetoptions/preferredculture/) melalui [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/spreadsheetoptions/), kemudian muat presentasi.

Contoh berikut memilih budaya Jepang, membuka presentasi dengan opsi load yang dikonfigurasi, dan memanggil [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) untuk setiap workbook chart:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

Budaya yang diutamakan adalah bagian dari konfigurasi pemuatan presentasi, jadi tentukan sebelum membuat instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Gunakan budaya yang diharapkan oleh formula workbook; misalnya, gunakan `ja-JP` untuk formula yang harus mengikuti aturan perhitungan DBCS Jepang.

## **Penghitungan Ulang dan Nilai Cache**

File spreadsheet biasanya menyimpan baik formula maupun nilai terakhir yang dihitung. Aspose.Slides dapat membaca nilai cache dari [IChartDataCell.Value](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/value/) ketika presentasi dimuat dan data chart yang relevan belum diubah.

Setelah mengubah sel input atau formula, jangan mengandalkan hasil cache lama. Panggil [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) sebelum membaca nilai yang dihitung atau menyimpan data chart yang bergantung padanya.

Untuk formula di luar subset yang didukung, Aspose.Slides mungkin tidak dapat mengurai formula atau menetapkan dependensinya. Jika workbook telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi tersebut, membaca nilai sel dengan data yang tidak didukung dapat memunculkan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Jika chart Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung formula tersebut dengan mesin spreadsheet yang mendukungnya dan tulis kembali nilai hasil ke workbook chart. Jangan mengganti formula yang tidak didukung dengan nilai tebakan.

## **Menangani Error Formula**

Ada dua jenis masalah yang berbeda untuk dibedakan.

Sebuah formula bisa valid tetapi menghasilkan nilai error spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token error adalah hasil sel dan dapat dikembalikan melalui `Value`.

Sebuah formula juga dapat gagal pada tingkat parsing, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan exception khusus spreadsheet untuk kasus tersebut: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ketika formula berasal dari templat atau input pengguna, tangani exception ini di sekitar penghitungan ulang dan akses nilai:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Batasan Praktis**

Dukungan formula di worksheet chart ditujukan untuk subset perhitungan spreadsheet yang terdefinisi, bukan untuk kompatibilitas Excel penuh. Ingat batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang terdokumentasi ketika Anda memerlukan Aspose.Slides untuk menghitung ulang formula.
- Hitung ulang setelah mengubah sel yang memengaruhi hasil formula.
- Anggap nilai cache dari presentasi yang dimuat sebagai snapshot, bukan sebagai pengganti penghitungan ulang setelah edit.
- Uji formula dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka menggunakan fungsi di luar daftar yang terdokumentasi.
- Untuk formula yang memerlukan mesin perhitungan spreadsheet lengkap, hitung secara eksternal lalu perbarui workbook chart dengan nilai hasil.

## **FAQ**

**Apa perbedaan antara `Formula` dan `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/formula/) menyimpan ekspresi gaya A1 seperti `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/r1c1formula/) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling cocok dengan cara Anda menghasilkan atau menyalin formula.

**Apakah saya harus membaca sel itu sendiri atau nilai setelah perhitungan?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/getcell/) mengembalikan sebuah `IChartDataCell`. Untuk memperoleh hasil yang dihitung, baca properti [Value](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/value/) sel tersebut setelah penghitungan ulang.

**Kapan saya harus memanggil `CalculateFormulas`?**

Panggil [CalculateFormulas](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) setelah mengubah nilai input atau formula dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai formula yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung semua fungsi Excel?**

Tidak. Evaluator bawaan hanya mendukung subset fungsi yang terdokumentasi. Fungsi di luar subset tersebut tidak boleh diasumsikan dapat dihitung ulang dengan benar. Jika kompatibilitas formula Excel penuh diperlukan, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tulis nilai akhir ke workbook chart.

**Apa yang terjadi jika presentasi yang dimuat berisi formula yang tidak didukung?**

Jika data chart tidak berubah, workbook mungkin masih berisi nilai cache yang sebelumnya dihitung. Setelah data terkait dimodifikasi, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang formulanya tidak dapat ditangani dapat memunculkan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Apakah nilai error formula sama dengan exception .NET?**

Tidak. Hasil seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Exception seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) menandakan bahwa formula tidak dapat diproses secara normal.

**Apakah chart memperbarui secara otomatis ketika sel formula berubah?**

Seri chart dapat merujuk ke sel workbook. Hitung ulang workbook terlebih dahulu, lalu simpan atau render presentasi. Jika poin data chart merujuk ke sel yang dihitung, chart akan menggunakan nilai sel yang diperbarui; tidak diperlukan metode refresh chart terpisah untuk alur kerja ini.

**Bisakah chart menggunakan workbook Excel eksternal?**

Ya, data chart dapat dikonfigurasi untuk menggunakan workbook eksternal melalui API data chart. Namun, alur kerja perhitungan formula yang dibahas dalam artikel ini berkaitan dengan workbook data chart dan subset formula yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [CalculateFormulas](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) memberikan penghitungan penuh untuk formula sembarang dalam file XLSX eksternal.

**Bisakah saya menggunakan formula yang merujuk ke worksheet atau workbook lain?**

Referensi gaya Excel mungkin ada di workbook chart, tetapi evaluasi formula dibatasi oleh parser dan set fungsi yang didukung. Jika referensi lintas sheet atau eksternal penting, validasikan formula tersebut dengan versi Aspose.Slides target Anda. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel yang luas, hitung workbook secara eksternal dan tulis kembali nilai yang diselesaikan ke data chart.

**Haruskah string formula dimulai dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa `=` di depan. Menggunakan bentuk itu membuat formula yang dihasilkan konsisten dengan contoh API yang terdokumentasi.