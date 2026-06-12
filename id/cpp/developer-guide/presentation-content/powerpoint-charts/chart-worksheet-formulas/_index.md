---
title: Terapkan Rumus Worksheet Bagan dalam Presentasi Menggunakan C++
linktitle: Rumus Worksheet
type: docs
weight: 70
url: /id/cpp/chart-worksheet-formulas/
keywords:
- spreadsheet bagan
- worksheet bagan
- rumus bagan
- rumus worksheet
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
- C++
- Aspose.Slides
description: "Terapkan rumus bergaya Excel di Aspose.Slides untuk worksheet bagan C++ dan otomatisasi laporan pada file PPT dan PPTX."
---
## **Gambaran Umum**

Worksheet bagan adalah sumber data di balik bagan dalam presentasi. Worksheet ini menyimpan nama kategori dan seri bersama nilai numerik yang ditampilkan oleh bagan. Dalam Aspose.Slides, worksheet ini tersedia melalui chart data workbook, yang memungkinkan Anda bekerja dengan data bagan secara programatik.

Artikel ini menjelaskan cara menggunakan rumus worksheet dalam data bagan sehingga nilai sel dapat dihitung dan diperbarui secara otomatis alih‑alih dimasukkan secara manual. Artikel ini menunjukkan cara menetapkan rumus, menggunakan referensi gaya A1 dan R1C1, menghitung ulang rumus workbook, serta bekerja dengan konstanta, operator, referensi sel, dan fungsi bawaan yang didukung untuk worksheet bagan dalam presentasi.

## **Tentang Rumus Spreadsheet Bagan dalam Presentasi**
**Spreadsheet bagan** (atau worksheet bagan) dalam presentasi adalah sumber data bagan. Spreadsheet bagan berisi data, yang ditampilkan pada bagan dalam bentuk grafis. Saat Anda membuat bagan di PowerPoint, worksheet yang terkait dengan bagan ini juga dibuat secara otomatis. Worksheet bagan dibuat untuk semua tipe bagan: bagan garis, bagan batang, bagan sunburst, bagan lingkaran, dll. Untuk melihat spreadsheet bagan di PowerPoint, cukup klik ganda pada bagan:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Spreadsheet bagan berisi nama elemen bagan (Category Name: *Category1*, Serie Name) dan tabel dengan data numerik yang sesuai dengan kategori dan seri tersebut. Secara default, saat Anda membuat bagan baru – data spreadsheet bagan diatur dengan data bawaan. Kemudian Anda dapat mengubah data spreadsheet secara manual di worksheet.

Umumnya, bagan menggambarkan data yang kompleks (mis. analis keuangan, analis ilmiah), dengan sel yang dihitung dari nilai sel lain atau dari data dinamis lainnya. Menghitung nilai sel secara manual dan menuliskannya secara tetap ke dalam sel menyulitkan perubahan di masa mendatang. Jika Anda mengubah nilai suatu sel, semua sel yang bergantung padanya juga harus diperbarui. Lebih lagi, data tabel dapat bergantung pada data dari tabel lain, sehingga menciptakan skema data presentasi yang kompleks dengan kebutuhan pembaruan yang mudah dan fleksibel.

**Rumus spreadsheet bagan** dalam presentasi adalah ekspresi untuk secara otomatis menghitung dan memperbarui data spreadsheet bagan. Rumus spreadsheet mendefinisikan logika perhitungan data untuk suatu sel atau sekumpulan sel. Rumus spreadsheet merupakan rumus matematis atau logis, yang menggunakan: referensi sel, fungsi matematika, operator logika, operator aritmetika, fungsi konversi, konstanta string, dll. Definisi rumus ditulis ke dalam sel, dan sel tersebut tidak berisi nilai sederhana. Rumus spreadsheet menghitung nilai dan mengembalikannya, kemudian nilai ini ditempatkan ke sel. Rumus spreadsheet bagan dalam presentasi sebenarnya sama dengan rumus Excel, dan mendukung fungsi, operator, serta konstanta bawaan yang sama untuk implementasinya.

Dalam [**Aspose.Slides**](https://products.aspose.com/slides/id/cpp/) spreadsheet bagan direpresentasikan dengan
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) metode dari tipe
[**IChartDataWorkbook**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_workbook).
Rumus spreadsheet dapat ditetapkan dan diubah dengan
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) metode.
Fungsionalitas berikut didukung untuk rumus dalam Aspose.Slides:

- Konstanta logika
- Konstanta numerik
- Konstanta string
- Konstanta error
- Operator aritmetika
- Operator perbandingan
- Referensi sel gaya A1
- Referensi sel gaya R1C1
- Fungsi bawaan

Umumnya, spreadsheet menyimpan nilai rumus yang terakhir dihitung. Jika setelah memuat presentasi, data bagan tidak diubah – metode **IChartDataCell.get_Value()** mengembalikan nilai‑nilai tersebut saat dibaca. Namun, jika data spreadsheet telah diubah, saat membaca **ChartDataCell.get_Value()** metode akan melempar **CellUnsupportedDataException** untuk rumus yang tidak didukung. Hal ini disebabkan karena ketika rumus berhasil di‑parsing, ketergantungan sel ditentukan dan keabsahan nilai terakhir diverifikasi. Jika rumus tidak dapat di‑parsing, keabsahan nilai sel tidak dapat dijamin.

## **Menambahkan Rumus Spreadsheet Bagan ke Presentasi**
Pertama, tambahkan bagan ke slide pertama dari presentasi baru dengan
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374).
Worksheet bagan dibuat secara otomatis dan dapat diakses dengan
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) metode:

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Mari tulis beberapa nilai dalam sel dengan
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) metode
dari tipe **Object**, yang berarti Anda dapat melewatkan nilai apa pun ke metode tersebut:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Sekarang untuk menulis rumus ke sel, Anda dapat menggunakan
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) metode:

*Catatan*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) metode digunakan untuk menetapkan referensi sel gaya A1.

Untuk menetapkan referensi sel **R1C1Formula**, Anda dapat menggunakan
[**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) metode:

Kemudian jika Anda mencoba membaca nilai dari sel B2 dan C2, nilai tersebut akan dihitung:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Konstanta Logika**
Anda dapat menggunakan konstanta logika seperti *FALSE* dan *TRUE* dalam rumus sel:

## **Konstanta Numerik**
Angka dapat digunakan dalam notasi biasa atau ilmiah untuk membuat rumus spreadsheet bagan:

## **Konstanta String**
Konstanta string (atau literal) adalah nilai spesifik yang digunakan apa adanya dan tidak berubah. Konstanta string dapat berupa: tanggal, teks, angka, dll.:

## **Konstanta Error**
Terkadang tidak mungkin menghitung hasil dengan rumus. Dalam kasus tersebut, kode error ditampilkan di sel alih‑alih nilainya. Setiap tipe error memiliki kode khusus:

- #DIV/0! – rumus mencoba membagi dengan nol.
- #GETTING_DATA – dapat muncul pada sel sementara nilainya masih dihitung.
- #N/A – informasi hilang atau tidak tersedia. Beberapa penyebabnya: sel yang digunakan dalam rumus kosong, ada karakter spasi ekstra, salah ketik, dll.
- #NAME? – sel atau objek rumus lain tidak dapat ditemukan berdasarkan namanya.
- #NULL! – dapat muncul ketika ada kesalahan dalam rumus, seperti:  (,) atau karakter spasi yang digunakan alih‑alih titik dua (:).
- #NUM! – nilai numerik dalam rumus tidak valid, terlalu panjang atau terlalu pendek, dll.
- #REF! – referensi sel tidak valid.
- #VALUE! – tipe nilai tidak terduga. Misalnya, nilai string ditempatkan pada sel numerik.

## **Operator Aritmetika**
Anda dapat menggunakan semua operator aritmetika dalam rumus worksheet bagan:

|**Operator**|**Arti**|**Contoh**|
| :- | :- | :- |
|+ (tanda plus)|Penjumlahan atau plus unary|2 + 3|
|- (tanda minus)|Pengurangan atau negasi|2 - 3<br>-3|
|* (asterisk)|Perkalian|2 * 3|
|/ (garis miring)|Pembagian|2 / 3|
|% (tanda persen)|Persen|30%|
|^ (caret)|Eksponensiasi|2 ^ 3|

*Catatan*: Untuk mengubah urutan evaluasi, letakkan bagian rumus yang ingin dihitung terlebih dahulu dalam tanda kurung.

## **Operator Perbandingan**
Anda dapat membandingkan nilai sel dengan operator perbandingan. Ketika dua nilai dibandingkan dengan operator ini, hasilnya adalah nilai logika *TRUE* atau *FALSE*:

|**Operator**|**Arti**|**Arti**|
| :- | :- | :- |
|= (tanda sama dengan)|Sama dengan|A2 = 3|
|<> (tanda tidak sama dengan)|Tidak sama dengan|A2 <> 3|
|> (tanda lebih besar)|Lebih besar|A2 > 3|
|>= (tanda lebih besar atau sama dengan)|Lebih besar atau sama dengan|A2 >= 3|
|< (tanda lebih kecil)|Lebih kecil|A2 < 3|
|<= (tanda lebih kecil atau sama dengan)|Lebih kecil atau sama dengan|A2 <= 3|

## **Referensi Sel Gaya A1**
**Referensi sel gaya A1** digunakan untuk worksheet, di mana kolom memiliki identifier huruf (mis. "*A*") dan baris memiliki identifier numerik (mis. "*1*"). Referensi sel gaya A1 dapat digunakan sebagai berikut:

|**Referensi sel**|**Contoh**|||
| :- | :- | :- | :- |
||Mutlak|Relatif|Campuran|
|Sel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Baris|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Rentang|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Berikut contoh cara menggunakan referensi sel gaya A1 dalam rumus:

## **Referensi Sel Gaya R1C1**
**Referensi sel gaya R1C1** digunakan untuk worksheet, di mana baik baris maupun kolom memiliki identifier numerik. Referensi sel gaya R1C1 dapat digunakan sebagai berikut:

|**Referensi sel**|**Contoh**|||
| :- | :- | :- | :- |
||Mutlak|Relatif|Campuran|
|Sel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Baris|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Rentang|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Berikut contoh cara menggunakan referensi sel gaya A1 dalam rumus:

## **Fungsi Bawaan**
Ada fungsi bawaan yang dapat digunakan dalam rumus untuk menyederhanakan implementasinya. Fungsi‑fungsi ini mencakup operasi paling umum, seperti:

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

**Apakah file Excel eksternal didukung sebagai sumber data untuk bagan dengan rumus?**

Ya. Aspose.Slides mendukung workbook eksternal sebagai [sumber data bagan](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdatasourcetype/), yang memungkinkan Anda menggunakan rumus dari file XLSX di luar presentasi.

**Apakah rumus bagan dapat mereferensikan lembar kerja dalam workbook yang sama dengan nama lembar?**

Ya. Rumus mengikuti model referensi Excel standar, sehingga Anda dapat mereferensikan lembar lain dalam workbook yang sama atau workbook eksternal. Untuk referensi eksternal, sertakan jalur dan nama workbook menggunakan sintaks Excel.