---
title: Terapkan Formula Lembar Kerja Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Formula Lembar Kerja
type: docs
weight: 70
url: /id/nodejs-java/chart-worksheet-formulas/
keywords:
- spreadsheet diagram
- lembar kerja diagram
- formula diagram
- formula lembar kerja
- formula spreadsheet
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Terapkan formula bergaya Excel di Aspose.Slides untuk Node.js melalui lembar kerja diagram Java dan otomatisasi laporan di file PPT serta PPTX menggunakan JavaScript."
---
## **Ikhtisar**

Lembar kerja diagram adalah sumber data di balik diagram dalam presentasi. Ia menyimpan nama kategori dan seri bersama dengan nilai numerik yang ditampilkan oleh diagram. Di Aspose.Slides, lembar kerja ini tersedia melalui buku kerja data diagram, yang memungkinkan Anda bekerja dengan data diagram secara programatis.

Artikel ini menjelaskan cara menggunakan formula lembar kerja dalam data diagram sehingga nilai sel dapat dihitung dan diperbarui secara otomatis alih‑alih dimasukkan secara manual. Ini menunjukkan cara menetapkan formula, menggunakan referensi gaya A1 dan R1C1, menghitung ulang formula buku kerja, serta bekerja dengan konstanta, operator, referensi sel, dan fungsi bawaan yang didukung untuk lembar kerja diagram dalam presentasi.

## **Tentang Formula Spreadsheet Diagram dalam Presentasi**
**Spreadsheet diagram** (atau lembar kerja diagram) dalam presentasi adalah sumber data diagram. Spreadsheet diagram berisi data, yang ditampilkan pada diagram secara grafis. Ketika Anda membuat diagram di PowerPoint, lembar kerja yang terkait dengan diagram tersebut otomatis dibuat juga. Lembar kerja diagram dibuat untuk semua jenis diagram: diagram garis, diagram batang, diagram sunburst, diagram pai, dll. Untuk melihat spreadsheet diagram di PowerPoint Anda harus mengklik ganda pada diagram:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Spreadsheet diagram berisi nama elemen diagram (Nama Kategori: *Category1*, Nama Seri) dan tabel dengan data numerik yang sesuai dengan kategori dan seri tersebut. Secara default, ketika Anda membuat diagram baru – data spreadsheet diagram diatur dengan data bawaan. Kemudian Anda dapat mengubah data spreadsheet secara manual di lembar kerja.

Biasanya, diagram mewakili data yang kompleks (mis. analis keuangan, analis ilmiah), dengan sel yang dihitung dari nilai sel lain atau dari data dinamis lainnya. Menghitung nilai sel secara manual dan meng‑hard‑code‑nya ke dalam sel membuatnya sulit diubah di masa depan. Jika Anda mengubah nilai suatu sel, semua sel yang bergantung padanya juga harus diperbarui. Lebih jauh lagi, data tabel dapat bergantung pada data dari tabel lain, menciptakan skema data presentasi yang kompleks dengan kebutuhan pembaruan yang mudah dan fleksibel.

**Formula spreadsheet diagram** dalam presentasi adalah ekspresi untuk secara otomatis menghitung dan memperbarui data spreadsheet diagram. Formula spreadsheet mendefinisikan logika perhitungan data untuk suatu sel atau kumpulan sel. Formula spreadsheet adalah formula matematika atau logika, yang menggunakan: referensi sel, fungsi matematika, operator logika, operator aritmatika, fungsi konversi, konstanta string, dll. Definisi formula dituliskan ke dalam sel, dan sel tersebut tidak berisi nilai sederhana. Formula spreadsheet menghitung nilai dan mengembalikannya, kemudian nilai ini ditetapkan ke sel. Formula spreadsheet diagram dalam presentasi sebenarnya sama dengan formula Excel, dan mendukung fungsi, operator, serta konstanta default yang sama untuk implementasinya.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/nodejs-java/) spreadsheet diagram direpresentasikan dengan
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) metode dari tipe
[**ChartDataWorkbook**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook).
Formula spreadsheet dapat ditetapkan dan diubah dengan 
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) metode.
Fungsionalitas berikut didukung untuk formula di Aspose.Slides:

- Konstanta logika
- Konstanta numerik
- Konstanta string
- Konstanta error
- Operator aritmatika
- Operator perbandingan
- Referensi sel gaya A1
- Referensi sel gaya R1C1
- Fungsi bawaan


Biasanya, spreadsheet menyimpan nilai formula yang terakhir dihitung. Jika setelah pemuatan presentasi, data diagram tidak diubah – [**ChartDataCell.getValue**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataCell#getValue--) metode mengembalikan nilai‑nilai tersebut saat dibaca. Namun, jika data spreadsheet telah diubah, saat membaca properti **ChartDataCell.Value** ia melempar [**CellUnsupportedDataException**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/CellUnsupportedDataException) untuk formula yang tidak didukung. Hal ini karena ketika formula berhasil di‑parse, ketergantungan sel ditentukan dan kebenaran nilai terakhir dipastikan. Namun, bila formula tidak dapat diparse, kebenaran nilai sel tidak dapat dijamin.

## **Menambahkan Formula Spreadsheet Diagram ke Presentasi**
Pertama, tambahkan diagram ke slide pertama dari presentasi baru dengan 
[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-).
Lembar kerja diagram secara otomatis dibuat dan dapat diakses dengan 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) metode:



```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Mari menuliskan beberapa nilai ke sel dengan 
[**ChartDataCell.setValue**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) properti 
dari tipe **Object**, yang berarti Anda dapat menetapkan nilai apa pun ke properti tersebut:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

Sekarang untuk menuliskan formula ke sel, Anda dapat menggunakan 
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) metode:

*Catatan*: [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) metode digunakan untuk menetapkan referensi sel gaya A1. 

Untuk menetapkan referensi sel [R1C1Formula](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) , Anda dapat menggunakan metode [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-):

Kemudian jika Anda mencoba membaca nilai dari sel B2 dan C2, nilai tersebut akan dihitung:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **Konstanta Logika**
Anda dapat menggunakan konstanta logika seperti *FALSE* dan *TRUE* dalam formula sel:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// nilai berisi boolean "false"
```

## **Konstanta Numerik**
Angka dapat digunakan dalam notasi umum atau ilmiah untuk membuat formula spreadsheet diagram:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Konstanta String**
Konstanta string (atau literal) adalah nilai spesifik yang digunakan apa adanya dan tidak berubah. Konstanta string dapat berupa: tanggal, teks, angka, dll.:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Konstanta Error**
Kadang‑kadang tidak mungkin menghitung hasil dengan formula. Dalam kasus tersebut, kode error ditampilkan di sel alih‑alih nilainya. Setiap tipe error memiliki kode khusus:

- #DIV/0! - formula mencoba membagi dengan nol.
- #GETTING_DATA - dapat muncul pada sel, sementara nilainya masih dihitung.
- #N/A - informasi hilang atau tidak tersedia. Beberapa penyebabnya dapat berupa: sel yang digunakan dalam formula kosong, karakter spasi ekstra, salah eja, dll.
- #NAME? - sel tertentu atau objek formula lain tidak dapat ditemukan berdasarkan namanya. 
- #NULL! - dapat muncul ketika ada kesalahan dalam formula, seperti:  (,) atau karakter spasi yang digunakan alih‑alih titik dua (:).
- #NUM! - nilai numerik dalam formula tidak valid, terlalu panjang atau terlalu kecil, dll.
- #REF! - referensi sel tidak valid.
- #VALUE! - tipe nilai tidak terduga. Misalnya, nilai string ditempatkan pada sel numerik.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// nilai berisi string "#DIV/0!"
```

## **Operator Aritmatika**
Anda dapat menggunakan semua operator aritmatika dalam formula lembar kerja diagram:

|**Operator**|**Arti**|**Contoh**|
| :- | :- | :- |
|+ (tanda plus)|Penjumlahan atau unary plus|2 + 3|
|- (tanda minus)|Pengurangan atau negasi|2 - 3<br>-3|
|* (asterisk)|Perkalian|2 * 3|
|/ (garis miring)|Pembagian|2 / 3|
|% (tanda persen)|Persen|30%|
|^ (caret)|Eksponensial|2 ^ 3|

*Catatan*: Untuk mengubah urutan evaluasi, letakkan dalam tanda kurung bagian formula yang ingin dihitung terlebih dahulu.

## **Operator Perbandingan**
Anda dapat membandingkan nilai sel dengan operator perbandingan. Ketika dua nilai dibandingkan dengan operator ini, hasilnya adalah nilai logika *TRUE* atau FALSE:

|**Operator**|**Arti**|**Arti**|
| :- | :- | :- |
|= (tanda sama dengan)|Sama dengan|A2 = 3|
|<> (tanda tidak sama dengan)|Tidak sama dengan|A2 <> 3|
|> (tanda lebih besar)|Lebih besar dari|A2 > 3|
|>= (tanda lebih besar atau sama dengan)|Lebih besar atau sama dengan|A2 >= 3|
|< (tanda lebih kecil)|Lebih kecil dari|A2 < 3|
|<= (tanda lebih kecil atau sama dengan)|Lebih kecil atau sama dengan|A2 <= 3|

## **Referensi Sel Gaya A1**
**Referensi sel gaya A1** digunakan untuk lembar kerja, di mana kolom memiliki identifier huruf (mis. "*A*") dan baris memiliki identifier numerik (mis. "*1*"). Referensi sel gaya A1 dapat digunakan dengan cara berikut:

|**Referensi sel**|**Contoh**|||
| :- | :- | :- | :- |
||Absolut|Relatif|Campuran|
|Sel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Baris|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Rentang|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Berikut contoh cara menggunakan referensi sel gaya A1 dalam formula:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Referensi Sel Gaya R1C1**
**Referensi sel gaya R1C1** digunakan untuk lembar kerja, di mana baik baris maupun kolom memiliki identifier numerik. Referensi sel gaya R1C1 dapat digunakan dengan cara berikut:

|**Referensi sel**|**Contoh**|||
| :- | :- | :- | :- |
||Absolut|Relatif|Campuran|
|Sel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Baris|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Rentang|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Berikut contoh cara menggunakan referensi sel gaya A1 dalam formula:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Fungsi Bawaan**
Ada fungsi bawaan yang dapat digunakan dalam formula untuk menyederhanakan implementasinya. Fungsi‑fungsi ini mengenkapsulasi operasi yang paling sering digunakan, seperti: 

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

**Apakah file Excel eksternal didukung sebagai sumber data untuk diagram dengan formula?**

Ya. Aspose.Slides mendukung buku kerja eksternal sebagai [sumber data diagram](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatasourcetype/), yang memungkinkan Anda menggunakan formula dari file XLSX di luar presentasi.

**Apakah formula diagram dapat merujuk ke lembar dalam buku kerja yang sama dengan nama lembar?**

Ya. Formula mengikuti model referensi Excel standar, sehingga Anda dapat merujuk ke lembar lain dalam buku kerja yang sama atau buku kerja eksternal. Untuk referensi eksternal, sertakan jalur dan nama buku kerja menggunakan sintaks Excel.