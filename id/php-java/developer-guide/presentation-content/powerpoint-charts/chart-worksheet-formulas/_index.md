---
title: Terapkan Rumus Lembar Kerja Chart dalam Presentasi di PHP
linktitle: Rumus Lembar Kerja
type: docs
weight: 70
url: /id/php-java/chart-worksheet-formulas/
keywords:
- spreadsheet bagan
- lembar kerja bagan
- rumus bagan
- rumus lembar kerja
- rumus spreadsheet
- buku kerja data bagan
- perhitungan rumus
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
- PHP
- Aspose.Slides
description: "Terapkan rumus bergaya Excel dalam Aspose.Slides untuk PHP via Java pada lembar kerja chart, hitung ulang nilai, dan gunakan hasilnya dalam chart PowerPoint."
---
## **Ikhtisar**

PowerPoint charts biasanya menyimpan data sumbernya dalam lembar kerja yang disematkan. Di Aspose.Slides untuk PHP via Java, Anda dapat mengakses lembar kerja tersebut melalui chart data workbook, menulis nilai input, menetapkan rumus ke sel, menghitung rumus yang didukung, dan menggunakan sel yang dihitung sebagai data chart.

Artikel ini menjelaskan alur kerja rumus secara lengkap: membuat chart, mengisi lembar kerjanya, menetapkan rumus gaya A1 atau R1C1, menghitung ulang, membaca nilai yang dihitung, menghubungkan sel tersebut ke seri chart, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks rumus yang didukung, subset fungsi bawaan, nilai cache, rumus yang tidak didukung, dan kesalahan khusus spreadsheet.

## **Lembar Kerja Chart dan Rumus**

Lembar kerja chart berisi kategori, nama seri, dan nilai yang digunakan oleh chart. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka editor data chart:

![PowerPoint chart dengan lembar kerja tersemat terbuka, menampilkan data kategori dan seri](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspos melalui kelas [ChartDataWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/). Gunakan [ChartDataCell::setFormula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setFormula) untuk rumus gaya A1 dan [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setR1C1Formula) untuk rumus gaya R1C1. Setelah mengubah sel input atau rumus, panggil [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) untuk menghitung ulang rumus yang didukung dan memperbarui nilai sel yang bersangkutan.

Sel yang dihitung tetap mengekspos hasilnya melalui [ChartDataCell::getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#getValue). Ini penting ketika Anda perlu memeriksa hasil rumus dalam kode atau menggunakan sel sebagai titik data chart.

## **Buat Chart dan Hitung Rumus Lembar Kerja**

Contoh berikut menunjukkan alur kerja end-to-end. Ia membuat chart kolom berkelompok, membersihkan data contoh, menulis nilai pendapatan dan pengeluaran kuartalan, menghitung laba dengan rumus, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai chart, dan menyimpan presentasi.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Poin data chart merujuk ke `D2:D4`, sehingga chart menggunakan nilai laba yang dihitung. Tidak ada pemanggilan refresh chart terpisah dalam alur kerja ini: hitung ulang workbook terlebih dahulu, kemudian gunakan atau simpan data chart yang menunjuk ke sel yang dihitung.

## **Gunakan Rumus Gaya A1**

Notasi A1 mengidentifikasi kolom dengan huruf dan baris dengan angka. Tetapkan ekspresi gaya A1 melalui [ChartDataCell::setFormula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Bentuk referensi A1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `A2` | `$A$2` | `A$2`, `$A2` |
| Baris | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Rentang | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika rumus dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sedangkan referensi campuran mengunci hanya baris atau kolom saja.

## **Gunakan Rumus Gaya R1C1**

Notasi R1C1 mengidentifikasi baris dan kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Bentuk referensi R1C1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Baris | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Rentang | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Sebagai contoh, pada sel `D2`, `RC[-2]` berarti sel di baris yang sama dua kolom ke kiri (`B2`).

## **Konstanta dan Operator Rumus**

Evaluator rumus bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmetika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks dikelilingi tanda kutip ganda di dalam rumus. |
| Hasil kesalahan | `#DIV/0!`, `#N/A`, `#REF!` | Rumus yang valid dapat mengevaluasi menjadi nilai kesalahan spreadsheet alih-alih hasil normal. |

Contoh ini menggunakan beberapa tipe konstanta:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
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

Gunakan kurung untuk membuat urutan evaluasi eksplisit, misalnya `(A2+B2)*C2`.

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

Aspose.Slides menyertakan evaluator rumus bawaan untuk lembar kerja chart, tetapi bukan mesin perhitungan Excel yang lengkap. Set fungsi yang didokumentasikan terbatas pada fungsi di bawah ini. Jangan menganggap bahwa fungsi Excel arbitrer dapat dihitung ulang oleh [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Fungsi | Tujuan atau bentuk yang didukung | Contoh |
|---|---|---|
| `ABS` | Nilai absolut | `ABS(A2)` |
| `AVERAGE` | Rata-rata aritmetika | `AVERAGE(B2:B5)` |
| `CEILING` | Membulatkan angka ke atas ke kelipatan | `CEILING(A2,5)` |
| `CHOOSE` | Memilih nilai berdasarkan indeks | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Menggabungkan nilai teks | `CONCAT(A2,B2)` |
| `CONCATENATE` | Menggabungkan nilai teks | `CONCATENATE(A2," ",B2)` |
| `DATE` | Membuat nilai tanggal menggunakan sistem tanggal 1900 | `DATE(2026,8,19)` |
| `DAYS` | Mengembalikan jumlah hari antara tanggal | `DAYS(B2,A2)` |
| `FIND` | Menemukan satu nilai teks di dalam nilai lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil bersyarat | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlah nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan yang ditunjukkan dalam tabel signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sementara `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektornya. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator rumus Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Rekalkulasi dan Nilai Cache**

File spreadsheet biasanya menyimpan baik rumus maupun nilai yang terakhir dihitung. Aspose.Slides dapat membaca nilai cache dari [ChartDataCell::getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#getValue) ketika presentasi dimuat dan data chart terkait belum diubah.

Setelah mengubah sel input atau rumus, jangan mengandalkan hasil cache lama. Panggil [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) sebelum membaca nilai yang dihitung atau menyimpan data chart yang bergantung padanya.

Untuk rumus di luar subset yang didukung, Aspose.Slides mungkin tidak dapat mengurai rumus atau menentukan ketergantungannya. Jika workbook telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi itu, membaca nilai sel dengan data yang tidak didukung dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellunsupporteddataexception/).

Jika chart Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung rumus tersebut dengan mesin spreadsheet yang mendukungnya dan tulis nilai hasilnya kembali ke workbook chart. Jangan mengganti rumus yang tidak didukung dengan nilai tebakan.

## **Menangani Kesalahan Rumus**

Ada dua jenis masalah yang perlu dibedakan.

Rumus dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam hal ini, token kesalahan merupakan hasil sel dan dapat dikembalikan melalui [ChartDataCell::getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#getValue).

Rumus juga dapat gagal pada tingkat parsing, referensi, ketergantungan, atau data yang didukung. Aspose.Slides menyediakan pengecualian khusus spreadsheet untuk kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellunsupporteddataexception/).

Di PHP via Java, pengecualian Java ditampilkan melalui `JavaException`. Ketika rumus berasal dari templat atau input pengguna, tangani di sekitar rekalkulasi dan akses nilai. Pengecualian Java yang dilaporkan dalam jejak stack mengidentifikasi kegagalan spreadsheet spesifik:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Batasan Praktis**

Dukungan rumus di lembar kerja chart dimaksudkan untuk subset perhitungan spreadsheet yang terdefinisi, bukan untuk kompatibilitas penuh Excel. Ingat batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang didokumentasikan ketika Anda memerlukan Aspose.Slides untuk menghitung ulang rumus.
- Hitung ulang setelah mengubah sel yang memengaruhi hasil rumus.
- Anggap nilai cache dari presentasi yang dimuat sebagai snapshot, bukan sebagai pengganti rekalkulasi setelah edit.
- Uji rumus dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka menggunakan fungsi di luar daftar yang didokumentasikan.
- Untuk rumus yang memerlukan mesin perhitungan spreadsheet lengkap, hitung secara eksternal lalu perbarui workbook chart dengan nilai hasilnya.

## **FAQ**

**Apa perbedaan antara [ChartDataCell::setFormula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setFormula) dan [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setFormula) menyimpan ekspresi gaya A1 seperti `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setR1C1Formula) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling cocok dengan cara Anda menghasilkan atau menyalin rumus.

**Apakah saya perlu membaca sel itu sendiri atau nilainya setelah perhitungan?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#getCell) mengembalikan sebuah [ChartDataCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/). Untuk memperoleh hasil yang dihitung, panggil metode [ChartDataCell::getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#getValue) pada sel tersebut setelah rekalkulasi.

**Kapan saya harus memanggil [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Panggil [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) setelah mengubah nilai input atau rumus dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai rumus yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung setiap fungsi Excel?**

Tidak. Evaluator bawaan mendukung subset fungsi yang didokumentasikan. Fungsi di luar subset tersebut tidak boleh dianggap dapat dihitung ulang dengan benar. Jika kompatibilitas rumus Excel penuh diperlukan, lakukan perhitungan dengan mesin spreadsheet yang tepat dan tulis nilai akhir ke workbook chart.

**Apa yang terjadi jika presentasi yang dimuat berisi rumus yang tidak didukung?**

Jika data chart tidak berubah, workbook mungkin masih berisi nilai cache yang telah dihitung sebelumnya. Setelah data terkait dimodifikasi, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang rumusnya tidak dapat ditangani dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellunsupporteddataexception/).

**Apakah nilai kesalahan rumus sama dengan pengecualian PHP?**

Tidak. Nilai seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Kegagalan pemrosesan spreadsheet seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellcircularreferenceexception/) adalah pengecualian Java yang ditampilkan ke PHP melalui `JavaException`.

**Apakah chart memperbarui secara otomatis ketika sel rumus berubah?**

Seri chart dapat merujuk sel workbook. Hitung ulang workbook terlebih dahulu, lalu simpan atau render presentasi. Jika poin data chart merujuk ke sel yang dihitung, chart akan menggunakan nilai sel yang diperbarui; tidak diperlukan metode refresh chart terpisah untuk alur kerja ini.

**Bisakah chart menggunakan workbook Excel eksternal?**

Ya, data chart dapat dikonfigurasi untuk menggunakan workbook eksternal melalui API data chart. Namun, alur kerja perhitungan rumus yang dijelaskan dalam artikel ini terkait dengan workbook data chart dan subset rumus yang dievaluasi oleh Aspose.Slides. Jangan menganggap bahwa [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) menyediakan perhitungan penuh untuk rumus arbitrer dalam file XLSX eksternal.

**Bisakah saya menggunakan rumus yang merujuk ke lembar kerja atau workbook lain?**

Referensi gaya Excel mungkin ada di workbook chart, tetapi evaluasi rumus terbatas oleh parser dan set fungsi yang didukung. Jika referensi lintas lembar atau eksternal penting, validasi rumus tersebut dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel yang luas, hitung workbook secara eksternal dan tulis nilai yang terselesaikan kembali ke data chart.

**Haruskah string rumus dimulai dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa `=` di depan. Menggunakan bentuk itu menjaga konsistensi rumus yang dihasilkan dengan contoh API yang didokumentasikan.