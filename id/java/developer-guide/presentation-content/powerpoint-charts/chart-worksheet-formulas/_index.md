---
title: Terapkan Rumus Lembar Kerja Diagram dalam Presentasi Menggunakan Java
linktitle: Rumus Lembar Kerja
type: docs
weight: 70
url: /id/java/chart-worksheet-formulas/
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
- konstanta aritmetika
- operator perbandingan
- gaya A1
- gaya R1C1
- fungsi bawaan
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Terapkan rumus bergaya Excel di Aspose.Slides untuk lembar kerja diagram Java dan otomatisasi laporan pada file PPT dan PPTX."
---
## **Ikhtisar**

Lembar kerja diagram adalah sumber data di balik diagram dalam sebuah presentasi. Ia menyimpan nama kategori dan seri bersama dengan nilai numerik yang ditampilkan oleh diagram. Di Aspose.Slides, lembar kerja ini tersedia melalui buku kerja data diagram, yang memungkinkan Anda bekerja dengan data diagram secara programatik.

Artikel ini menjelaskan cara menggunakan rumus lembar kerja dalam data diagram sehingga nilai sel dapat dihitung dan diperbarui secara otomatis alih‑alih dimasukkan secara manual. Ia menunjukkan cara menetapkan rumus, menggunakan referensi gaya A1 dan R1C1, menghitung ulang rumus buku kerja, serta bekerja dengan konstanta, operator, referensi sel, dan fungsi bawaan yang didukung untuk lembar kerja diagram dalam presentasi.

## **Tentang Rumus Spreadsheet Diagram dalam Presentasi**
**Spreadsheet diagram** (atau lembar kerja diagram) dalam presentasi adalah sumber data diagram. Spreadsheet diagram berisi data, yang direpresentasikan pada diagram secara grafik. Saat Anda membuat diagram di PowerPoint, lembar kerja yang terkait dengan diagram ini juga dibuat secara otomatis. Lembar kerja diagram dibuat untuk semua jenis diagram: diagram garis, diagram batang, diagram sunburst, diagram lingkaran, dll. Untuk melihat spreadsheet diagram di PowerPoint, Anda harus mengklik ganda pada diagram:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Spreadsheet diagram berisi nama elemen diagram (Nama Kategori: *Category1*, Nama Seri) dan tabel dengan data numerik yang sesuai dengan kategori dan seri tersebut. Secara default, ketika Anda membuat diagram baru – data spreadsheet diagram diatur dengan data bawaan. Kemudian Anda dapat mengubah data spreadsheet secara manual di lembar kerja.

Biasanya, diagram mewakili data yang rumit (mis. analis keuangan, analis ilmiah), yang memiliki sel yang dihitung dari nilai di sel lain atau dari data dinamis lainnya. Menghitung nilai sel secara manual dan menuliskannya secara tetap ke dalam sel membuatnya sulit untuk diubah di masa mendatang. Jika Anda mengubah nilai suatu sel, semua sel yang bergantung padanya juga harus diperbarui. Lebih lagi, data tabel dapat bergantung pada data dari tabel lain, menciptakan skema data presentasi yang kompleks dengan kebutuhan pembaruan yang mudah dan fleksibel.

**Rumus spreadsheet diagram** dalam presentasi adalah ekspresi untuk secara otomatis menghitung dan memperbarui data spreadsheet diagram. Rumus spreadsheet menentukan logika perhitungan data untuk sel tertentu atau sekumpulan sel. Rumus spreadsheet adalah rumus matematika atau logika, yang menggunakan: referensi sel, fungsi matematika, operator logika, operator aritmetika, fungsi konversi, konstanta string, dll. Definisi rumus dituliskan ke dalam sel, dan sel tersebut tidak berisi nilai sederhana. Rumus spreadsheet menghitung nilai dan mengembalikannya, kemudian nilai ini diberikan ke sel. Rumus spreadsheet diagram dalam presentasi pada dasarnya sama dengan rumus Excel, dan mendukung fungsi, operator, serta konstanta bawaan yang sama untuk implementasinya.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/java/) spreadsheet diagram direpresentasikan dengan 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData#getChartDataWorkbook--) method dari tipe
[**IChartDataWorkbook**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook). 
Rumus spreadsheet dapat ditetapkan dan diubah dengan 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) method. 
Fungsi berikut didukung untuk rumus di Aspose.Slides:

- Konstanta logika
- Konstanta numerik
- Konstanta string
- Konstanta error
- Operator aritmetika
- Operator perbandingan
- Referensi sel gaya A1
- Referensi sel gaya R1C1
- Fungsi bawaan


Biasanya, spreadsheet menyimpan nilai rumus yang terakhir dihitung. Jika setelah pemuatan presentasi, data diagram tidak diubah – [**IChartDataCell.getValue**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataCell#getValue--) method mengembalikan nilai‑nilai tersebut saat dibaca. Namun, jika data spreadsheet telah diubah, saat membaca properti **ChartDataCell.Value** akan dilemparkan [**CellUnsupportedDataException**](https://reference.aspose.com/slides/id/java/com.aspose.slides/CellUnsupportedDataException) untuk rumus yang tidak didukung. Hal ini karena ketika rumus berhasil diparsing, ketergantungan sel ditentukan dan keakuratan nilai terakhir ditetapkan. Tetapi, jika rumus tidak dapat diparsing, keakuratan nilai sel tidak dapat dijamin.

## **Menambahkan Rumus Spreadsheet Diagram ke Presentasi**
Pertama, tambahkan diagram ke slide pertama dari presentasi baru dengan 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
Lembar kerja diagram dibuat secara otomatis dan dapat diakses dengan 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData#getChartDataWorkbook--) method:



```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Mari menulis beberapa nilai ke sel dengan 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) properti 
bertipe **Object**, yang berarti Anda dapat menetapkan nilai apa pun ke properti tersebut:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Sekarang untuk menulis rumus ke sel, Anda dapat menggunakan method 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-):

*Catatan*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) method digunakan untuk menetapkan referensi sel gaya A1. 

Untuk menetapkan referensi sel [R1C1Formula](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) , Anda dapat menggunakan method [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Kemudian jika Anda mencoba membaca nilai dari sel B2 dan C2, nilai tersebut akan dihitung:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Konstanta Logika**
Anda dapat menggunakan konstanta logika seperti *FALSE* dan *TRUE* dalam rumus sel:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // nilai berisi boolean "false"
```

## **Konstanta Numerik**
Angka dapat digunakan dalam notasi umum atau ilmiah untuk membuat rumus spreadsheet diagram:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Konstanta String**
Konstanta string (atau literal) adalah nilai spesifik yang digunakan apa adanya dan tidak berubah. Konstanta string dapat berupa: tanggal, teks, angka, dll.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Konstanta Error**
Kadang‑kadang tidak memungkinkan menghitung hasil menggunakan rumus. Dalam kasus tersebut, kode error ditampilkan di sel alih‑alih nilainya. Setiap tipe error memiliki kode tertentu:

- #DIV/0! - rumus mencoba membagi dengan nol.
- #GETTING_DATA - dapat muncul pada sel, sementara nilainya masih dihitung.
- #N/A - informasi hilang atau tidak tersedia. Beberapa penyebabnya dapat berupa: sel yang digunakan dalam rumus kosong, karakter spasi ekstra, salah eja, dll.
- #NAME? - sel tertentu atau objek rumus lain tidak dapat ditemukan dengan nama tersebut. 
- #NULL! - dapat muncul ketika ada kesalahan dalam rumus, seperti:  (,) atau karakter spasi digunakan alih‑alih titik dua (:).
- #NUM! - nilai numerik dalam rumus mungkin tidak valid, terlalu panjang atau terlalu kecil, dll.
- #REF! - referensi sel tidak valid.
- #VALUE! - tipe nilai tak terduga. Misalnya, nilai string ditempatkan pada sel numerik.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // nilai mengandung string "#DIV/0!"
```

## **Operator Aritmetika**
Anda dapat menggunakan semua operator aritmetika dalam rumus lembar kerja diagram:

|**Operator**|**Arti**|**Contoh**|
| :- | :- | :- |
|+ (tanda plus)|Penjumlahan atau plus unary|2 + 3|
|- (tanda minus)|Pengurangan atau negasi|2 - 3<br>-3|
|* (asterisk)|Perkalian|2 * 3|
|/ (garis miring)|Pembagian|2 / 3|
|% (tanda persen)|Persen|30%|
|^ (caret)|Eksponensial|2 ^ 3|

*Catatan*: Untuk mengubah urutan evaluasi, letakkan bagian rumus yang ingin dihitung terlebih dahulu dalam tanda kurung.

## **Operator Perbandingan**
Anda dapat membandingkan nilai sel dengan operator perbandingan. Ketika dua nilai dibandingkan menggunakan operator ini, hasilnya berupa nilai logika *TRUE* atau FALSE:

|**Operator**|**Arti**|**Contoh**|
| :- | :- | :- |
|= (tanda sama dengan)|Sama dengan|A2 = 3|
|<> (tanda tidak sama dengan)|Tidak sama dengan|A2 <> 3|
|> (tanda lebih besar)|Lebih besar dari|A2 > 3|
|>= (tanda lebih besar atau sama dengan)|Lebih besar atau sama dengan|A2 >= 3|
|< (tanda lebih kecil)|Lebih kecil dari|A2 < 3|
|<= (tanda lebih kecil atau sama dengan)|Lebih kecil atau sama dengan|A2 <= 3|

## **Referensi Sel Gaya A1**
**Referensi sel gaya A1** digunakan untuk lembar kerja, di mana kolom memiliki identifier huruf (mis. "*A*") dan baris memiliki identifier numerik (mis. "*1*"). Referensi sel gaya A1 dapat digunakan dengan cara berikut:

|**Referensi sel**|**Contoh**| | |
| :- | :- | :- | :- |
| |Absolute|Relative|Mixed|
|Sel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Baris|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Rentang|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Berikut contoh cara menggunakan referensi sel gaya A1 dalam rumus:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Referensi Sel Gaya R1C1**
**Referensi sel gaya R1C1** digunakan untuk lembar kerja, di mana baik baris maupun kolom memiliki identifier numerik. Referensi sel gaya R1C1 dapat digunakan dengan cara berikut:

|**Referensi sel**|**Contoh**| | |
| :- | :- | :- | :- |
| |Absolute|Relative|Mixed|
|Sel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Baris|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Rentang|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Berikut contoh cara menggunakan referensi sel gaya A1 dalam rumus:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

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

Ya. Aspose.Slides mendukung buku kerja eksternal sebagai [sumber data diagram](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdatasourcetype/), yang memungkinkan Anda menggunakan rumus dari XLSX di luar presentasi.

**Apakah rumus diagram dapat merujuk lembar dalam buku kerja yang sama berdasarkan nama lembar?**

Ya. Rumus mengikuti model referensi Excel standar, sehingga Anda dapat merujuk lembar lain dalam buku kerja yang sama atau buku kerja eksternal. Untuk referensi eksternal, sertakan jalur dan nama buku kerja menggunakan sintaks Excel.