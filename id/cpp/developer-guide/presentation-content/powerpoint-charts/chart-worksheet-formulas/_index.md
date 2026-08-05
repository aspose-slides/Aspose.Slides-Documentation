---
title: Terapkan Formula Worksheet Diagram dalam Presentasi Menggunakan C++
linktitle: Formula Worksheet
type: docs
weight: 70
url: /id/cpp/chart-worksheet-formulas/
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
- presentasi
- C++
- Aspose.Slides
description: "Terapkan formula gaya Excel di Aspose.Slides untuk worksheet diagram C++ dan otomatisasi laporan pada file PPT dan PPTX."
---
## **Ringkasan**

Worksheet diagram adalah sumber data di balik diagram dalam presentasi. Worksheet ini menyimpan nama kategori dan seri bersama dengan nilai numerik yang ditampilkan oleh diagram. Di Aspose.Slides, worksheet ini tersedia melalui chart data workbook, yang memungkinkan Anda bekerja dengan data diagram secara programatik.

Artikel ini menjelaskan cara menggunakan formula worksheet dalam data diagram sehingga nilai sel dapat dihitung dan diperbarui secara otomatis alih-alih dimasukkan secara manual. Artikel ini menunjukkan cara menetapkan formula, menggunakan referensi gaya A1 dan R1C1, menghitung ulang formula workbook, serta bekerja dengan konstanta, operator, referensi sel, dan fungsi bawaan yang didukung untuk worksheet diagram dalam presentasi.

## **Tentang Formula Spreadsheet Diagram dalam Presentasi**
**Spreadsheet diagram** (atau worksheet diagram) dalam presentasi adalah sumber data diagram. Spreadsheet diagram berisi data, yang ditampilkan pada diagram secara grafis. Saat Anda membuat diagram di PowerPoint, worksheet yang terkait dengan diagram ini juga dibuat secara otomatis. Worksheet diagram dibuat untuk semua jenis diagram: diagram garis, diagram batang, diagram sunburst, diagram pai, dll. Untuk melihat spreadsheet diagram di PowerPoint, Anda harus mengklik ganda pada diagram:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Spreadsheet diagram berisi nama elemen diagram (Category Name: *Category1*, Serie Name) dan tabel dengan data numerik yang sesuai dengan kategori dan seri tersebut. Secara default, saat Anda membuat diagram baru – data spreadsheet diagram diatur dengan data default. Kemudian Anda dapat mengubah data spreadsheet secara manual di worksheet.

Biasanya, diagram mewakili data yang kompleks (mis. analis keuangan, analis ilmiah), dengan sel yang dihitung dari nilai di sel lain atau dari data dinamis lainnya. Menghitung nilai sel secara manual dan menuliskannya secara keras ke dalam sel membuatnya sulit diubah di masa mendatang. Jika Anda mengubah nilai suatu sel, semua sel yang bergantung padanya juga harus diperbarui. Lebih lagi, data tabel dapat bergantung pada data dari tabel lain, menciptakan skema data presentasi yang kompleks dengan kebutuhan pembaruan yang mudah dan fleksibel.

**Formula spreadsheet diagram** dalam presentasi adalah ekspresi untuk secara otomatis menghitung dan memperbarui data spreadsheet diagram. Formula spreadsheet mendefinisikan logika perhitungan data untuk sel tertentu atau kumpulan sel. Formula spreadsheet adalah formula matematika atau logika, yang menggunakan: referensi sel, fungsi matematika, operator logika, operator aritmatika, fungsi konversi, konstanta string, dll. Definisi formula ditulis ke dalam sel, dan sel tersebut tidak berisi nilai sederhana. Formula spreadsheet menghitung nilai dan mengembalikannya, kemudian nilai ini diberikan ke sel. Formula spreadsheet dalam presentasi pada dasarnya sama dengan formula Excel, dan mendukung fungsi default, operator, serta konstanta yang sama untuk implementasinya.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/cpp/) spreadsheet diagram direpresentasikan dengan metode 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) dari tipe 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_workbook). 
Formula spreadsheet dapat ditetapkan dan diubah dengan 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). 
Fungsionalitas berikut didukung untuk formula di Aspose.Slides:

- Konstanta logika
- Konstanta numerik
- Konstanta string
- Konstanta error
- Operator aritmetika
- Operator perbandingan
- Referensi sel gaya A1
- Referensi sel gaya R1C1
- Fungsi bawaan



Biasanya, spreadsheet menyimpan nilai formula yang terakhir dihitung. Jika setelah pemuatan presentasi, data diagram tidak diubah – **IChartDataCell.get_Value()** mengembalikan nilai tersebut saat dibaca. Namun, jika data spreadsheet telah diubah, saat membaca **ChartDataCell.get_Value()** metode akan melempar **CellUnsupportedDataException** untuk formula yang tidak didukung. Ini karena ketika formula berhasil diparsing, dependensi sel ditentukan dan keabsahan nilai terakhir ditentukan. Tetapi, jika formula tidak dapat diparsing, keabsahan nilai sel tidak dapat dijamin.


## **Menambahkan Formula Spreadsheet Diagram ke Presentasi**
Pertama, tambahkan diagram ke slide pertama dari presentasi baru dengan 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
Worksheet diagram dibuat secara otomatis dan dapat diakses dengan 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) metode:



``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```



Tuliskan beberapa nilai ke dalam sel dengan 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) metode 
dari tipe **Object**, yang berarti Anda dapat memberikan nilai apa pun ke metode tersebut:



``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```



Sekarang untuk menulis formula ke sel, Anda dapat menggunakan 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) metode:





*Catatan*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) digunakan untuk menetapkan referensi sel gaya A1. 



Untuk menetapkan referensi sel R1C1Formula, Anda dapat menggunakan metode [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):





Kemudian jika Anda mencoba membaca nilai dari sel B2 dan C2, mereka akan dihitung:



``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Konstanta Logika**
Anda dapat menggunakan konstanta logika seperti *FALSE* dan *TRUE* dalam formula sel:




## **Konstanta Numerik**
Angka dapat digunakan dalam notasi umum atau ilmiah untuk membuat formula spreadsheet diagram:




## **Konstanta String**
Konstanta string (atau literal) adalah nilai spesifik yang digunakan apa adanya dan tidak berubah. Konstanta string dapat berupa: tanggal, teks, angka, dll.:




## **Konstanta Error**
Terkadang tidak memungkinkan menghitung hasil dengan formula. Dalam kasus tersebut, kode error ditampilkan di sel alih-alih nilainya. Setiap tipe error memiliki kode khusus:

- #DIV/0! - formula mencoba membagi dengan nol.
- #GETTING_DATA - mungkin muncul pada sel, sementara nilainya masih dihitung.
- #N/A - informasi hilang atau tidak tersedia. Beberapa penyebabnya dapat berupa: sel yang digunakan dalam formula kosong, karakter spasi ekstra, salah eja, dll.
- #NAME? - sel tertentu atau objek formula lain tidak dapat ditemukan berdasarkan namanya. 
- #NULL! - dapat muncul ketika ada kesalahan dalam formula, seperti:  (,) atau karakter spasi yang digunakan alih-alih titik dua (:).
- #NUM! - nilai numerik dalam formula tidak valid, terlalu panjang atau terlalu pendek, dll.
- #REF! - referensi sel tidak valid.
- #VALUE! - tipe nilai tidak terduga. Misalnya, nilai string ditempatkan pada sel numerik.




## **Operator Aritmetika**
Anda dapat menggunakan semua operator aritmetika dalam formula worksheet diagram:



|**Operator**|**Arti**|**Contoh**|
| :- | :- | :- |
|+ (tanda plus)|Penjumlahan atau plus unary|2 + 3|
|- (tanda minus)|Pengurangan atau negasi|2 - 3<br>-3|
|* (asterisk)|Perkalian|2 * 3|
|/ (garis miring)|Pembagian|2 / 3|
|% (tanda persen)|Persen|30%|
|^ (caret)|Eksponensiasi|2 ^ 3|


*Catatan*: Untuk mengubah urutan evaluasi, letakkan bagian formula yang akan dihitung terlebih dahulu dalam tanda kurung.


## **Operator Perbandingan**
Anda dapat membandingkan nilai sel dengan operator perbandingan. Saat dua nilai dibandingkan menggunakan operator ini, hasilnya berupa nilai logika *TRUE* atau FALSE:



|**Operator**|**Arti**|**Arti**|
| :- | :- | :- |
|= (tanda sama dengan)|Sama dengan|A2 = 3|
|<> (tanda tidak sama)|Tidak sama dengan|A2 <> 3|
|> (tanda lebih besar)|Lebih besar|A2 > 3|
|>= (tanda lebih besar atau sama dengan)|Lebih besar atau sama dengan|A2 >= 3|
|< (tanda kurang dari)|Kurang dari|A2 < 3|
|<= (tanda kurang dari atau sama dengan)|Kurang dari atau sama dengan|A2 <= 3|

## **Referensi Sel Gaya A1**
**Referensi sel gaya A1** digunakan untuk worksheet, di mana kolom memiliki identifier huruf (mis. "*A*") dan baris memiliki identifier numerik (mis. "*1*"). Referensi sel gaya A1 dapat digunakan dengan cara berikut:



|**Referensi sel**|**Contoh**|||
| :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Sel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Baris|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Rentang|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Berikut contoh cara menggunakan referensi sel gaya A1 dalam formula:




## **Referensi Sel Gaya R1C1**
**Referensi sel gaya R1C1** digunakan untuk worksheet, di mana baik baris maupun kolom memiliki identifier numerik. Referensi sel gaya R1C1 dapat digunakan dengan cara berikut:



|**Referensi sel**|**Contoh**|||
| :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Sel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Baris|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Rentang|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Berikut contoh cara menggunakan referensi sel gaya A1 dalam formula:




## **Fungsi Bawaan**
Ada fungsi bawaan yang dapat digunakan dalam formula untuk menyederhanakan implementasinya. Fungsi-fungsi ini mencakup operasi yang paling umum digunakan, seperti: 

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

Ya. Aspose.Slides mendukung workbook eksternal sebagai [sumber data bagan](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdatasourcetype/), yang memungkinkan Anda menggunakan formula dari file XLSX di luar presentasi.

**Apakah formula diagram dapat merujuk ke lembar dalam workbook yang sama dengan nama lembar?**

Ya. Formula mengikuti model referensi Excel standar, sehingga Anda dapat merujuk ke lembar lain dalam workbook yang sama atau workbook eksternal. Untuk referensi eksternal, sertakan jalur dan nama workbook menggunakan sintaks Excel.