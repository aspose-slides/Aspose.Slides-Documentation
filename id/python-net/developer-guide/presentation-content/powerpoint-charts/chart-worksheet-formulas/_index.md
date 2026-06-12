---
title: Terapkan Formula Worksheet Diagram dalam Presentasi dengan Python
linktitle: Formula Worksheet
type: docs
weight: 70
url: /id/python-net/chart-worksheet-formulas/
keywords:
- spreadsheet diagram
- worksheet diagram
- formula diagram
- formula worksheet
- formula spreadsheet
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
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Terapkan formula bergaya Excel di Aspose.Slides untuk Python melalui worksheet diagram .NET dan otomatisasikan laporan di seluruh file PPT, PPTX, dan ODP."
---
## **Gambaran Umum**

Sebuah worksheet diagram adalah sumber data di balik sebuah diagram dalam presentasi. Worksheet ini menyimpan nama kategori dan seri bersama dengan nilai numerik yang ditampilkan oleh diagram. Di Aspose.Slides, worksheet ini tersedia melalui chart data workbook, yang memungkinkan Anda bekerja dengan data diagram secara programatis.

Artikel ini menjelaskan cara menggunakan formula worksheet dalam data diagram sehingga nilai sel dapat dihitung dan diperbarui secara otomatis alih-alih dimasukkan secara manual. Artikel ini menunjukkan cara menetapkan formula, menggunakan referensi gaya A1 dan R1C1, menghitung ulang formula workbook, dan bekerja dengan konstanta, operator, referensi sel, serta fungsi bawaan yang didukung untuk worksheet diagram dalam presentasi.

## **Tentang Formula Spreadsheet Diagram dalam Presentasi**
**Spreadsheet diagram** (atau chart worksheet) dalam presentasi adalah sumber data diagram. Spreadsheet diagram berisi data yang ditampilkan pada diagram secara grafis. Saat Anda membuat diagram di PowerPoint, worksheet yang terkait dengan diagram tersebut juga otomatis dibuat. Worksheet diagram dibuat untuk semua jenis diagram: diagram garis, diagram batang, diagram sunburst, diagram lingkaran, dll. Untuk melihat spreadsheet diagram di PowerPoint, cukup klik ganda pada diagram:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Spreadsheet diagram berisi nama elemen diagram (Category Name: *Category1*, Serie Name) dan tabel dengan data numerik yang sesuai dengan kategori dan seri tersebut. Secara default, ketika Anda membuat diagram baru – data spreadsheet diagram diatur dengan data default. Selanjutnya Anda dapat mengubah data spreadsheet di worksheet secara manual.

Biasanya, diagram merepresentasikan data yang rumit (misalnya analis keuangan, analis ilmiah), dengan sel-sel yang dihitung dari nilai di sel lain atau dari data dinamis lainnya. Menghitung nilai sel secara manual dan mengkodekannya secara tetap ke dalam sel, membuatnya sulit untuk diubah di masa depan. Jika Anda mengubah nilai suatu sel, semua sel yang bergantung padanya juga harus diperbarui. Lebih lagi, data tabel dapat bergantung pada data dari tabel lain, menciptakan skema data presentasi yang kompleks dengan kebutuhan untuk diperbarui secara mudah dan fleksibel.

**Formula spreadsheet diagram** dalam presentasi adalah sebuah ekspresi untuk secara otomatis menghitung dan memperbarui data spreadsheet diagram. Formula spreadsheet mendefinisikan logika perhitungan data untuk sel tertentu atau kumpulan sel. Formula spreadsheet merupakan formula matematika atau logika, yang menggunakan: referensi sel, fungsi matematika, operator logika, operator aritmetika, fungsi konversi, konstanta string, dll. Definisi formula dituliskan ke dalam sebuah sel, dan sel tersebut tidak berisi nilai sederhana. Formula spreadsheet menghitung nilai dan mengembalikannya, kemudian nilai tersebut diberikan ke sel. Formula spreadsheet diagram dalam presentasi sebenarnya sama dengan formula Excel, dan mendukung fungsi, operator, serta konstanta default yang sama untuk implementasinya.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/python-net/) spreadsheet diagram direpresentasikan dengan properti 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdata/) dari tipe
[**IChartDataWorkbook**](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdataworkbook/). 
Formula spreadsheet dapat ditetapkan dan diubah dengan properti 
[**formula**](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/). 
Fungsionalitas berikut didukung untuk formula dalam Aspose.Slides:

- Konstanta logika
- Konstanta numerik
- Konstanta string
- Konstanta error
- Operator aritmetika
- Operator perbandingan
- Referensi sel gaya A1
- Referensi sel gaya R1C1
- Fungsi bawaan

Biasanya, spreadsheet menyimpan nilai formula yang terakhir dihitung. Jika setelah pemuatan presentasi, data diagram tidak diubah – properti **IChartDataCell.Value** mengembalikan nilai tersebut saat dibaca. Namun, jika data spreadsheet telah diubah, saat membaca properti **ChartDataCell.Value** akan melempar **CellUnsupportedDataException** untuk formula yang tidak didukung. Hal ini karena ketika formula berhasil diparsing, ketergantungan sel ditentukan dan kebenaran nilai terakhir ditetapkan. Tetapi, jika formula tidak dapat diparsing, kebenaran nilai sel tidak dapat dijamin.

## **Menambahkan Formula Spreadsheet Diagram ke Presentasi**
Pertama, tambahkan sebuah diagram dengan beberapa data contoh ke slide pertama dari presentasi baru menggunakan [add_chart](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishapecollection/). 
Worksheet diagram secara otomatis dibuat dan dapat diakses dengan properti 
[**chart_data_workbook**](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdata/) :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Mari tuliskan beberapa nilai ke sel dengan properti 
[**value**](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/) 
dari tipe **Object**, yang berarti Anda dapat menetapkan nilai apa pun ke properti tersebut:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Sekarang untuk menulis formula ke sel, Anda dapat menggunakan properti 
[**formula**](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/) :

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Catatan*: Properti [**IChartDataCell.Formula**](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/) digunakan untuk menetapkan referensi sel gaya A1.

Untuk menetapkan referensi sel [r1c1_formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/), Anda dapat menggunakan properti [**r1c1_formula**](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/) :

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Selanjutnya gunakan metode [**calculate_formulas**](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/) untuk menghitung semua formula dalam workbook dan memperbarui nilai sel yang bersesuaian:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Konstanta Logika**
Anda dapat menggunakan konstanta logika seperti *FALSE* dan *TRUE* dalam formula sel:

## **Konstanta Numerik**
Angka dapat digunakan dalam notasi umum atau ilmiah untuk membuat formula spreadsheet diagram:

## **Konstanta String**
Konstanta string (atau literal) adalah nilai spesifik yang digunakan apa adanya dan tidak berubah. Konstanta string dapat berupa: tanggal, teks, angka, dll.:

## **Konstanta Error**
Terkadang tidak memungkinkan menghitung hasil dengan formula. Dalam kasus tersebut, kode error ditampilkan di sel alih-alih nilainya. Setiap tipe error memiliki kode spesifik:

- #DIV/0! - formula mencoba membagi dengan nol.
- #GETTING_DATA - dapat ditampilkan pada sel, sementara nilainya masih dalam proses perhitungan.
- #N/A - informasi tidak tersedia atau hilang. Beberapa penyebabnya dapat berupa: sel yang digunakan dalam formula kosong, ada karakter spasi ekstra, salah ketik, dll.
- #NAME? - sel tertentu atau objek formula lain tidak dapat ditemukan berdasarkan namanya.
- #NULL! - dapat muncul ketika ada kesalahan dalam formula, seperti:  (,) atau karakter spasi digunakan alih-alih titik dua (:).
- #NUM! - nilai numerik dalam formula mungkin tidak valid, terlalu panjang atau terlalu kecil, dll.
- #REF! - referensi sel tidak valid.
- #VALUE! - tipe nilai tidak diharapkan. Misalnya, nilai string ditempatkan pada sel numerik.

## **Operator Aritmetika**
Anda dapat menggunakan semua operator aritmetika dalam formula worksheet diagram:

|**Operator**|**Arti**|**Contoh**|
| :- | :- | :- |
|+ (tanda plus)|Penjumlahan atau plus unary|2 + 3|
|- (tanda minus)|Pengurangan atau negasi|2 - 3<br>-3|
|* (asterisk)|Perkalian|2 * 3|
|/ (garis miring)|Pembagian|2 / 3|
|% (tanda persen)|Persen|30%|
|^ (caret)|Eksponensial|2 ^ 3|

*Catatan*: Untuk mengubah urutan evaluasi, letakkan bagian formula yang ingin dihitung pertama dalam tanda kurung.

## **Operator Perbandingan**
Anda dapat membandingkan nilai-nilai sel dengan operator perbandingan. Ketika dua nilai dibandingkan menggunakan operator ini, hasilnya adalah nilai logika *TRUE* atau FALSE:

|**Operator**|**Arti**|**Contoh**|
| :- | :- | :- |
|= (tanda sama dengan)|Sama dengan|A2 = 3|
|<> (tanda tidak sama)|Tidak sama dengan|A2 <> 3|
|> (tanda lebih besar)|Lebih besar dari|A2 > 3|
|>= (tanda lebih besar atau sama dengan)|Lebih besar atau sama dengan|A2 >= 3|
|< (tanda lebih kecil)|Lebih kecil dari|A2 < 3|
|<= (tanda lebih kecil atau sama dengan)|Lebih kecil atau sama dengan|A2 <= 3|

## **Referensi Sel Gaya A1**
**Referensi sel gaya A1** digunakan untuk worksheet, di mana kolom memiliki identifier huruf (misalnya "*A*") dan baris memiliki identifier numerik (misalnya "*1*"). Referensi sel gaya A1 dapat digunakan dengan cara berikut:

|**Referensi Sel**|**Contoh**|||
| :- | :- | :- | :- |
||Absolut|Relatif|Campuran|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Berikut contoh cara menggunakan referensi sel gaya A1 dalam formula:

## **Referensi Sel Gaya R1C1**
**Referensi sel gaya R1C1** digunakan untuk worksheet, di mana baik baris maupun kolom memiliki identifier numerik. Referensi sel gaya R1C1 dapat digunakan dengan cara berikut:

|**Referensi Sel**|**Contoh**|||
| :- | :- | :- | :- |
||Absolut|Relatif|Campuran|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Berikut contoh cara menggunakan referensi sel gaya R1C1 dalam formula:

## **Fungsi Bawaan**
Ada fungsi bawaan yang dapat digunakan dalam formula untuk menyederhanakan implementasinya. Fungsi-fungsi ini mencakup operasi yang paling sering digunakan, seperti:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Apakah file Excel eksternal didukung sebagai sumber data untuk diagram dengan formula?**

Ya. Aspose.Slides mendukung workbook eksternal sebagai [sumber data diagram](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatasourcetype/), yang memungkinkan Anda menggunakan formula dari file XLSX di luar presentasi.

**Apakah formula diagram dapat merujuk ke sheet dalam workbook yang sama dengan nama sheet?**

Ya. Formula mengikuti model referensi Excel standar, sehingga Anda dapat merujuk ke sheet lain dalam workbook yang sama atau workbook eksternal. Untuk referensi eksternal, sertakan jalur dan nama workbook menggunakan sintaks Excel.