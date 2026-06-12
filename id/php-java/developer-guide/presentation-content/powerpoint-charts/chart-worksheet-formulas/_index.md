---
title: Terapkan Rumus Worksheet Grafik dalam Presentasi Menggunakan PHP
linktitle: Rumus Worksheet
type: docs
weight: 70
url: /id/php-java/chart-worksheet-formulas/
keywords:
- spreadsheet grafik
- worksheet grafik
- rumus grafik
- rumus worksheet
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
- PHP
- Aspose.Slides
description: "Terapkan rumus bergaya Excel di Aspose.Slides untuk PHP melalui worksheet grafik Java dan otomatisasi laporan di file PPT serta PPTX."
---
## **Ikhtisar**

Worksheet grafik adalah sumber data di balik grafik dalam sebuah presentasi. Worksheet ini menyimpan nama kategori dan seri bersama dengan nilai numerik yang ditampilkan oleh grafik. Dalam Aspose.Slides, worksheet ini tersedia melalui workbook data grafik, yang memungkinkan Anda bekerja dengan data grafik secara programatis.

Artikel ini menjelaskan cara menggunakan rumus worksheet dalam data grafik sehingga nilai sel dapat dihitung dan diperbarui secara otomatis alih-alih dimasukkan secara manual. Artikel ini menunjukkan cara menetapkan rumus, menggunakan referensi bergaya A1 dan R1C1, menghitung ulang rumus workbook, serta bekerja dengan konstanta, operator, referensi sel, dan fungsi bawaan yang didukung untuk worksheet grafik dalam presentasi.

## **Tentang Rumus Spreadsheet Grafik dalam Presentasi**
**Spreadsheet grafik** (atau worksheet grafik) dalam presentasi adalah sumber data grafik. Spreadsheet grafik berisi data, yang ditampilkan pada grafik dalam bentuk visual. Ketika Anda membuat grafik di PowerPoint, worksheet yang terkait dengan grafik ini juga dibuat secara otomatis. Worksheet grafik dibuat untuk semua jenis grafik: diagram garis, diagram batang, diagram sunburst, diagram pai, dll. Untuk melihat spreadsheet grafik di PowerPoint Anda harus mengklik ganda pada grafik:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Spreadsheet grafik berisi nama elemen grafik (Nama Kategori: *Category1*, Nama Seri) dan tabel dengan data numerik yang sesuai dengan kategori dan seri tersebut. Secara default, ketika Anda membuat grafik baru – data spreadsheet grafik diatur dengan data bawaan. Kemudian Anda dapat mengubah data spreadsheet secara manual di worksheet.

Biasanya, grafik mewakili data yang kompleks (mis. analis keuangan, analis ilmiah), dengan sel yang dihitung dari nilai di sel lain atau dari data dinamis lainnya. Menghitung nilai sel secara manual dan menuliskannya secara keras ke dalam sel membuatnya sulit diubah di masa mendatang. Jika Anda mengubah nilai suatu sel, semua sel yang bergantung padanya juga harus diperbarui. Lebih lagi, data tabel dapat bergantung pada data dari tabel lain, menciptakan skema data presentasi yang kompleks dengan kebutuhan pembaruan yang mudah dan fleksibel.

**Rumus spreadsheet grafik** dalam presentasi adalah ekspresi untuk secara otomatis menghitung dan memperbarui data spreadsheet grafik. Rumus spreadsheet mendefinisikan logika perhitungan data untuk sel tertentu atau sekumpulan sel. Rumus spreadsheet adalah rumus matematika atau logika, yang menggunakan: referensi sel, fungsi matematika, operator logika, operator aritmatika, fungsi konversi, konstanta string, dll. Definisi rumus dituliskan ke dalam sel, dan sel tersebut tidak berisi nilai sederhana. Rumus spreadsheet menghitung nilai dan mengembalikannya, kemudian nilai tersebut ditetapkan ke sel. Rumus spreadsheet grafik dalam presentasi sebenarnya sama dengan rumus Excel, dan mendukung fungsi, operator, serta konstanta default yang sama untuk implementasinya.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/php-java/) spreadsheet grafik direpresentasikan dengan metode
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/#getChartDataWorkbook) dari tipe
[**ChartDataWorkbook**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/).
Rumus spreadsheet dapat ditetapkan dan diubah dengan 
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setFormula).
Fungsionalitas berikut didukung untuk rumus di Aspose.Slides:

- Konstanta logika
- Konstanta numerik
- Konstanta string
- Konstanta error
- Operator aritmatika
- Operator perbandingan
- Referensi sel bergaya A1
- Referensi sel bergaya R1C1
- Fungsi bawaan


Biasanya, spreadsheet menyimpan nilai rumus yang terakhir dihitung. Jika setelah pemuatan presentasi, data grafik tidak diubah – [**ChartDataCell::getValue**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#getValue) mengembalikan nilai tersebut saat dibaca. Namun, jika data spreadsheet telah diubah, saat membaca nilai, ia melempar [**CellUnsupportedDataException**](https://reference.aspose.com/slides/id/php-java/aspose.slides/CellUnsupportedDataException) untuk rumus yang tidak didukung. Hal ini karena ketika rumus berhasil diparse, ketergantungan sel ditentukan dan keabsahan nilai terakhir dapat dipastikan. Tetapi, bila rumus tidak dapat diparse, keabsahan nilai sel tidak dapat dijamin.

## **Menambahkan Rumus Spreadsheet Grafik ke Presentasi**
Pertama, tambahkan grafik ke slide pertama dari presentasi baru dengan 
[ShapeCollection::addChart](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addChart).
Worksheet grafik secara otomatis dibuat dan dapat diakses dengan 
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/#getChartDataWorkbook) method:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Mari menuliskan beberapa nilai ke sel dengan [**ChartDataCell::setValue**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setValue) method dari tipe **Object**, yang berarti Anda dapat menetapkan nilai apa pun:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Sekarang untuk menuliskan rumus ke sel, Anda dapat menggunakan 
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setFormula) method.

*Catatan*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setFormula) method digunakan untuk menetapkan referensi sel bergaya A1. 

Untuk menetapkan rumus dalam gaya R1C1, Anda dapat menggunakan [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setR1C1Formula) method.

Kemudian jika Anda mencoba membaca nilai dari sel B2 dan C2, nilai tersebut akan dihitung:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Konstanta Logika**
Anda dapat menggunakan konstanta logika seperti *FALSE* dan *TRUE* dalam rumus sel:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// nilai berisi boolean "false"


```

## **Konstanta Numerik**
Angka dapat digunakan dalam notasi umum atau ilmiah untuk membuat rumus spreadsheet grafik:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Konstanta String**
Konstanta string (atau literal) adalah nilai spesifik yang digunakan apa adanya dan tidak berubah. Konstanta string dapat berupa: tanggal, teks, angka, dll.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Konstanta Error**
Kadang-kadang tidak mungkin menghitung hasil dengan rumus. Dalam kasus tersebut, kode error ditampilkan di sel alih-alih nilainya. Setiap jenis error memiliki kode spesifik:

- #DIV/0! – rumus mencoba membagi dengan nol.
- #GETTING_DATA – mungkin muncul pada sel saat nilainya masih dihitung.
- #N/A – informasi hilang atau tidak tersedia. Beberapa alasan dapat berupa: sel yang dipakai dalam rumus kosong, ada karakter spasi ekstra, salah eja, dll.
- #NAME? – sel tertentu atau objek rumus lain tidak dapat ditemukan berdasarkan namanya. 
- #NULL! – dapat muncul ketika ada kesalahan dalam rumus, seperti:  (,) atau karakter spasi yang digunakan alih-alih titik dua (:).
- #NUM! – nilai numerik dalam rumus tidak valid, terlalu panjang atau terlalu kecil, dll.
- #REF! – referensi sel tidak valid.
- #VALUE! – tipe nilai tidak terduga. Misalnya, nilai string ditempatkan pada sel numerik.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// nilai berisi string "#DIV/0!"


```

## **Operator Aritmatika**
Anda dapat menggunakan semua operator aritmatika dalam rumus worksheet grafik:

|**Operator**|**Makna**|**Contoh**|
| :- | :- | :- |
|+ (tanda plus)|Penjumlahan atau tanda plus unary|2 + 3|
|- (tanda minus)|Pengurangan atau negasi|2 - 3<br>-3|
|* (asterisk)|Perkalian|2 * 3|
|/ (garis miring)|Pembagian|2 / 3|
|% (tanda persen)|Persen|30%|
|^ (caret)|Eksponensial|2 ^ 3|

*Catatan*: Untuk mengubah urutan evaluasi, letakkan dalam tanda kurung bagian rumus yang ingin dihitung terlebih dahulu.

## **Operator Perbandingan**
Anda dapat membandingkan nilai sel dengan operator perbandingan. Ketika dua nilai dibandingkan menggunakan operator ini, hasilnya adalah nilai logika *TRUE* atau FALSE:

|**Operator**|**Arti**|**Contoh**|
| :- | :- | :- |
|= (tanda sama dengan)|Sama dengan|A2 = 3|
|<> (tanda tidak sama dengan)|Tidak sama dengan|A2 <> 3|
|> (tanda lebih besar)|Lebih besar|A2 > 3|
|>= (tanda lebih besar atau sama dengan)|Lebih besar atau sama dengan|A2 >= 3|
|< (tanda lebih kecil)|Lebih kecil|A2 < 3|
|<= (tanda lebih kecil atau sama dengan)|Lebih kecil atau sama dengan|A2 <= 3|

## **Referensi Sel Bergaya A1**
**Referensi sel bergaya A1** digunakan untuk worksheet, di mana kolom memiliki identifikator huruf (mis. "*A*") dan baris memiliki identifikator numerik (mis. "*1*"). Referensi sel bergaya A1 dapat digunakan sebagai berikut:

|**Referensi sel**|**Contoh**|||
| :- | :- | :- | :- |
||Absolut|Relatif|Campuran|
|Sel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Baris|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Rentang|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Berikut contoh penggunaan referensi sel bergaya A1 dalam rumus:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **Referensi Sel Bergaya R1C1**
**Referensi sel bergaya R1C1** digunakan untuk worksheet, di mana baik baris maupun kolom memiliki identifikator numerik. Referensi sel bergaya R1C1 dapat digunakan sebagai berikut:

|**Referensi sel**|**Contoh**|||
| :- | :- | :- | :- |
||Absolut|Relatif|Campuran|
|Sel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Baris|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Rentang|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Berikut contoh penggunaan referensi sel bergaya A1 dalam rumus:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Fungsi Bawaan**
Ada fungsi bawaan yang dapat digunakan dalam rumus untuk menyederhanakan implementasinya. Fungsi-fungsi ini mencakup operasi yang paling umum digunakan, seperti:

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

**Apakah file Excel eksternal didukung sebagai sumber data untuk grafik dengan rumus?**

Ya. Aspose.Slides mendukung workbook eksternal sebagai [sumber data grafik](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatasourcetype/), yang memungkinkan Anda menggunakan rumus dari file XLSX di luar presentasi.

**Dapatkah rumus grafik merujuk ke lembar dalam workbook yang sama dengan nama lembar?**

Ya. Rumus mengikuti model referensi standar Excel, sehingga Anda dapat merujuk lembar lain dalam workbook yang sama atau workbook eksternal. Untuk referensi eksternal, sertakan jalur dan nama workbook menggunakan sintaks Excel.