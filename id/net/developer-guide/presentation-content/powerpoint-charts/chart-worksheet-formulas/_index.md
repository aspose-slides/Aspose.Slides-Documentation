---
title: Menerapkan Rumus Lembar Kerja Diagram dalam Presentasi di .NET
linktitle: Rumus Lembar Kerja
type: docs
weight: 70
url: /id/net/chart-worksheet-formulas/
keywords:
- spreadsheet diagram
- lembar kerja diagram
- rumus diagram
- rumus lembar kerja
- rumus spreadsheet
- sumber data
- konstanta logika
- konstanta numerik
- konstanta string
- konstanta error
- konstanta aritmatika
- operator perbandingan
- gaya A1
- gaya R1C1
- fungsi bawaan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Menerapkan rumus bergaya Excel di Aspose.Slides untuk .NET pada lembar kerja diagram dan mengotomatiskan laporan di file PPT dan PPTX."
---
## **Gambaran Umum**

Lembar kerja diagram adalah sumber data di balik diagram dalam presentasi. Ia menyimpan nama kategori dan seri bersama dengan nilai numerik yang ditampilkan oleh diagram. Dalam Aspose.Slides, lembar kerja ini tersedia melalui chart data workbook, yang memungkinkan Anda bekerja dengan data diagram secara programatik.

Artikel ini menjelaskan cara menggunakan rumus lembar kerja dalam data diagram sehingga nilai sel dapat dihitung dan diperbarui secara otomatis alih‑alih dimasukkan secara manual. Artikel ini menunjukkan cara menetapkan rumus, menggunakan referensi gaya A1 dan R1C1, menghitung ulang rumus workbook, serta bekerja dengan konstanta, operator, referensi sel, dan fungsi bawaan yang didukung untuk lembar kerja diagram dalam presentasi.

## **Tentang Rumus Spreadsheet Diagram dalam Presentasi**
**Spreadsheet diagram** (atau lembar kerja diagram) dalam presentasi adalah sumber data diagram. Spreadsheet diagram berisi data, yang ditampilkan pada diagram dalam bentuk grafis. Saat Anda membuat diagram di PowerPoint, lembar kerja yang terkait dengan diagram tersebut secara otomatis dibuat juga. Lembar kerja diagram dibuat untuk semua jenis diagram: diagram garis, diagram batang, diagram sunburst, diagram pai, dll. Untuk melihat spreadsheet diagram di PowerPoint Anda harus mengklik ganda pada diagram:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Spreadsheet diagram berisi nama elemen diagram (Category Name: *Category1*, Serie Name) dan tabel dengan data numerik yang sesuai dengan kategori dan seri tersebut. Secara default, ketika Anda membuat diagram baru – data spreadsheet diagram diatur dengan data default. Kemudian Anda dapat mengubah data spreadsheet secara manual di lembar kerja.

Biasanya, diagram mewakili data yang kompleks (mis. analis keuangan, analis ilmiah), dengan sel yang dihitung dari nilai sel lain atau dari data dinamis lainnya. Menghitung nilai sel secara manual dan mengkodekannya secara tetap ke dalam sel, membuatnya sulit untuk diubah di masa mendatang. Jika Anda mengubah nilai suatu sel, semua sel yang bergantung padanya juga harus diperbarui. Lebih jauh lagi, data tabel dapat bergantung pada data dari tabel lain, menciptakan skema data presentasi yang kompleks dengan kebutuhan untuk memperbarui secara mudah dan fleksibel.

**Rumus spreadsheet diagram** dalam presentasi adalah ekspresi untuk secara otomatis menghitung dan memperbarui data spreadsheet diagram. Rumus spreadsheet mendefinisikan logika perhitungan data untuk sel tertentu atau seperangkat sel. Rumus spreadsheet adalah rumus matematika atau rumus logika, yang menggunakan: referensi sel, fungsi matematika, operator logika, operator aritmatika, fungsi konversi, konstanta string, dll. Definisi rumus ditulis ke dalam sel, dan sel ini tidak berisi nilai sederhana. Rumus spreadsheet menghitung nilai dan mengembalikannya, kemudian nilai tersebut diberikan ke sel. Rumus spreadsheet dalam presentasi sebenarnya sama dengan rumus Excel, dan mendukung fungsi, operator, dan konstanta default yang sama untuk implementasinya.

Dalam [**Aspose.Slides**](https://products.aspose.com/slides/id/net/) spreadsheet diagram direpresentasikan dengan properti [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) dari tipe [**IChartDataWorkbook**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook). 
Rumus spreadsheet dapat ditetapkan dan diubah dengan properti [**IChartDataCell.Formula**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/properties/formula). 
Fungsionalitas berikut didukung untuk rumus dalam Aspose.Slides:

- Konstanta logika
- Konstanta numerik
- Konstanta string
- Konstanta error
- Operator aritmatika
- Operator perbandingan
- Referensi sel gaya A1
- Referensi sel gaya R1C1
- Fungsi bawaan



Biasanya, spreadsheet menyimpan nilai rumus yang terakhir dihitung. Jika setelah memuat presentasi, data diagram tidak berubah – properti **IChartDataCell.Value** mengembalikan nilai tersebut saat dibaca. Tetapi, jika data spreadsheet telah diubah, saat membaca properti **ChartDataCell.Value** akan melempar **CellUnsupportedDataException** untuk rumus yang tidak didukung. Hal ini karena ketika rumus berhasil diparsing, ketergantungan sel ditentukan dan kebenaran nilai terakhir ditetapkan. Namun, jika rumus tidak dapat diparsing, kebenaran nilai sel tidak dapat dijamin.

## **Menambahkan Rumus Spreadsheet Diagram ke Presentasi**
Pertama, tambahkan diagram dengan beberapa data contoh ke slide pertama dari presentasi baru dengan [IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/addchart/methods/1). Lembar kerja diagram secara otomatis dibuat dan dapat diakses dengan properti [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook):

``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```

Tuliskan beberapa nilai ke sel dengan properti [**IChartDataCell.Value**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/properties/value) bertipe **Object**, yang berarti Anda dapat menetapkan nilai apa saja ke properti tersebut:

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

Sekarang untuk menulis rumus ke sel, Anda dapat menggunakan properti [**IChartDataCell.Formula**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/properties/formula):

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Catatan*: properti [**IChartDataCell.Formula**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/properties/formula) digunakan untuk menetapkan referensi sel gaya A1.  

Untuk menetapkan referensi sel [R1C1Formula](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula), Anda dapat menggunakan properti [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula):

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Kemudian gunakan metode [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) untuk menghitung semua rumus dalam workbook dan memperbarui nilai sel yang bersesuaian:

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **Konstanta Logika**
Anda dapat menggunakan konstanta logika seperti *FALSE* dan *TRUE* dalam rumus sel:




## **Konstanta Numerik**
Angka dapat digunakan dalam notasi umum atau ilmiah untuk membuat rumus spreadsheet diagram:




## **Konstanta String**
Konstanta string (atau literal) adalah nilai spesifik yang digunakan apa adanya dan tidak berubah. Konstanta string dapat berupa: tanggal, teks, angka, dll:




## **Konstanta Error**
Kadang‑kadang tidak mungkin menghitung hasil dengan rumus. Dalam kasus tersebut, kode error ditampilkan di sel alih‑alih nilainya. Setiap jenis error memiliki kode khusus:

- #DIV/0! - rumus mencoba membagi dengan nol.
- #GETTING_DATA - dapat muncul pada sel, sementara nilainya masih dihitung.
- #N/A - informasi hilang atau tidak tersedia. Beberapa penyebabnya dapat berupa: sel yang digunakan dalam rumus kosong, karakter spasi ekstra, salah eja, dll.
- #NAME? - sel tertentu atau objek rumus lain tidak dapat ditemukan berdasarkan namanya. 
- #NULL! - dapat muncul ketika ada kesalahan dalam rumus, seperti:  (,) atau karakter spasi yang digunakan alih‑alih titik dua (:).
- #NUM! - angka dalam rumus mungkin tidak valid, terlalu panjang atau terlalu pendek, dll.
- #REF! - referensi sel tidak valid.
- #VALUE! - tipe nilai tidak terduga. Misalnya, nilai string ditempatkan pada sel numerik.




## **Operator Aritmatika**
Anda dapat menggunakan semua operator aritmatika dalam rumus lembar kerja diagram:

|**Operator**|**Makna**|**Contoh**|
| :- | :- | :- |
|+ (tanda plus)|Penjumlahan atau plus unary|2 + 3|
|- (tanda minus)|Pengurangan atau negatif|2 - 3<br>-3|
|* (asterisk)|Perkalian|2 * 3|
|/ (garis miring)|Pembagian|2 / 3|
|% (tanda persen)|Persen|30%|
|^ (caret)|Pemangkatan|2 ^ 3|

*Catatan*: Untuk mengubah urutan evaluasi, letakkan bagian rumus yang ingin dihitung terlebih dahulu dalam tanda kurung.

## **Operator Perbandingan**
Anda dapat membandingkan nilai sel dengan operator perbandingan. Ketika dua nilai dibandingkan menggunakan operator ini, hasilnya adalah nilai logika *TRUE* atau *FALSE*:

|**Operator**|**Makna**|**Contoh**|
| :- | :- | :- |
|= (sama dengan)|Sama dengan|A2 = 3|
|<> (tidak sama dengan)|Tidak sama dengan|A2 <> 3|
|> (lebih besar)|Lebih besar|A2 > 3|
|>= (lebih besar atau sama dengan)|Lebih besar atau sama dengan|A2 >= 3|
|< (lebih kecil)|Lebih kecil|A2 < 3|
|<= (lebih kecil atau sama dengan)|Lebih kecil atau sama dengan|A2 <= 3|

## **Referensi Sel Gaya A1**
**Referensi sel gaya A1** digunakan untuk lembar kerja, di mana kolom memiliki pengenal huruf (mis. "*A*") dan baris memiliki pengenal numerik (mis. "*1*"). Referensi sel gaya A1 dapat digunakan dengan cara berikut:

|**Referensi sel**|**Contoh**| | |
| :- | :- | :- | :- |
| |Absolute|Relative|Mixed|
|Sel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Baris|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Rentang|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Berikut contoh cara menggunakan referensi sel gaya A1 dalam rumus:




## **Referensi Sel Gaya R1C1**
**Referensi sel gaya R1C1** digunakan untuk lembar kerja, di mana baris dan kolom keduanya memiliki pengenal numerik. Referensi sel gaya R1C1 dapat digunakan dengan cara berikut:

|**Referensi sel**|**Contoh**| | |
| :- | :- | :- | :- |
| |Absolute|Relative|Mixed|
|Sel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Baris|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Rentang|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C7<br>R[2]C3:R5C[7]|

Berikut contoh cara menggunakan referensi sel gaya A1 dalam rumus:




## **Fungsi Bawaan**
Ada fungsi bawaan yang dapat digunakan dalam rumus untuk menyederhanakan implementasinya. Fungsi‑fungsi ini mencakup operasi yang paling sering dipakai, seperti:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (sistem tanggal 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (bentuk referensi)
- LOOKUP (bentuk vektor)
- MATCH (bentuk vektor)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Apakah file Excel eksternal didukung sebagai sumber data untuk diagram dengan rumus?**

Ya. Aspose.Slides mendukung workbook eksternal sebagai [sumber data diagram](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdatasourcetype/), yang memungkinkan Anda menggunakan rumus dari file XLSX di luar presentasi.

**Apakah rumus diagram dapat merujuk ke lembar dalam workbook yang sama dengan nama lembar?**

Ya. Rumus mengikuti model referensi Excel standar, sehingga Anda dapat merujuk ke lembar lain dalam workbook yang sama atau workbook eksternal. Untuk referensi eksternal, sertakan jalur dan nama workbook menggunakan sintaks Excel.