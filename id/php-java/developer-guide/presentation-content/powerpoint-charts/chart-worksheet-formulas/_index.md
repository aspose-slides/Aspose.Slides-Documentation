---
title: Terapkan Formula Lembar Kerja Diagram dalam Presentasi di PHP
linktitle: Formula Lembar Kerja
type: docs
weight: 70
url: /id/php-java/chart-worksheet-formulas/
keywords:
- spreadsheet diagram
- lembar kerja diagram
- formula diagram
- formula lembar kerja
- formula spreadsheet
- buku kerja data diagram
- perhitungan formula
- budaya pilihan
- formula khusus budaya
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
- PHP
- Aspose.Slides
description: "Terapkan formula gaya Excel dalam lembar kerja diagram Aspose.Slides untuk PHP via Java, hitung ulang nilai, dan gunakan hasilnya dalam diagram PowerPowerPoint."
---
## **Ikhtisar**

Diagram PowerPoint biasanya menyimpan data sumbernya dalam lembar kerja yang disematkan. Di Aspose.Slides untuk PHP via Java, Anda dapat mengakses lembar kerja tersebut melalui buku kerja data diagram, menulis nilai input, menetapkan formula ke sel, menghitung formula yang didukung, dan menggunakan sel yang dihitung sebagai data diagram.

Artikel ini menjelaskan alur kerja formula lengkap: membuat diagram, mengisi lembar kerja, menetapkan formula gaya A1 atau R1C1, menghitung ulang, membaca nilai yang dihitung, menghubungkan sel‑sel tersebut ke seri diagram, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks formula yang didukung, subset fungsi bawaan, nilai yang di‑cache, formula yang tidak didukung, dan kesalahan spesifik spreadsheet.

## **Lembar Kerja Diagram dan Formula**

Lembar kerja diagram berisi kategori, nama seri, dan nilai yang digunakan oleh diagram. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka editor data diagram:

![Diagram PowerPoint dengan lembar kerja tersemat terbuka, menampilkan data kategori dan seri](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspos melalui kelas [ChartDataWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/). Gunakan [ChartDataCell::setFormula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setFormula) untuk formula gaya A1 dan [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setR1C1Formula) untuk formula gaya R1C1. Setelah mengubah sel input atau formula, panggil [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) untuk menghitung ulang formula yang didukung dan memperbarui nilai sel yang bersangkutan.

Sel yang dihitung tetap menyediakan hasilnya melalui [ChartDataCell::getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#getValue). Ini penting ketika Anda perlu memeriksa hasil formula dalam kode atau menggunakan sel sebagai titik data diagram.

## **Buat Diagram dan Hitung Formula Lembar Kerja**

Contoh berikut menunjukkan alur kerja end‑to‑end. Contoh ini membuat diagram kolom berkelompok, menghapus data contoh, menulis nilai pendapatan dan pengeluaran per kuartal, menghitung keuntungan dengan formula, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai diagram, dan menyimpan presentasi.

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

Poin data diagram merujuk ke `D2:D4`, sehingga diagram menggunakan nilai keuntungan yang dihitung. Tidak ada pemanggilan refresh diagram terpisah dalam alur kerja ini: hitung ulang buku kerja terlebih dahulu, kemudian gunakan atau simpan data diagram yang merujuk ke sel yang dihitung.

## **Gunakan Formula Gaya A1**

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

Bentuk referensi A1 umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `A2` | `$A$2` | `A$2`, `$A2` |
| Baris | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Rentang | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika formula dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sementara referensi campuran memperbaiki hanya baris atau kolom.

## **Gunakan Formula Gaya R1C1**

Notasi R1C1 mengidentifikasi baik baris maupun kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

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

Bentuk referensi R1C1 umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Baris | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Rentang | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Sebagai contoh, pada sel `D2`, `RC[-2]` berarti sel pada baris yang sama dua kolom ke kiri (`B2`).

## **Konstanta dan Operator Formula**

Evalutor formula bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmetika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks dikelilingi oleh tanda kutip ganda di dalam formula. |
| Hasil Kesalahan | `#DIV/0!`, `#N/A`, `#REF!` | Formula yang valid dapat menghasilkan nilai kesalahan spreadsheet alih‑alih hasil normal. |

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
| `+` | Penjumlahan atau tanda plus unary | `2+3` |
| `-` | Pengurangan atau negasi | `2-3`, `-3` |
| `*` | Perkalian | `2*3` |
| `/` | Pembagian | `2/3` |
| `%` | Persentase | `30%` |
| `^` | Pemangkatan | `2^3` |

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

Aspose.Slides menyertakan evaluator formula bawaan untuk lembar kerja diagram, tetapi bukan mesin perhitungan Excel lengkap. Set fungsi yang didokumentasikan terbatas pada fungsi di bawah ini. Jangan mengasumsikan bahwa fungsi Excel apa pun dapat dihitung ulang oleh [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

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
| `FIND` | Mencari satu nilai teks di dalam teks lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil bersyarat | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlahkan nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Batasan yang ditunjukkan dalam tabel signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sementara `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektor mereka. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator formula Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Hitung Formula dengan Budaya Pilihan**

Beberapa fungsi buku kerja diagram menafsirkan teks menurut aturan khusus budaya. Ini terutama penting untuk fungsi yang ditujukan bagi bahasa yang menggunakan set karakter dua byte (DBCS). Untuk menghitung formula tersebut dengan benar, buat [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/), set budaya pilihan dengan [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/id/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), tetapkan opsi spreadsheet melalui [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions), dan kemudian muat presentasi.

Contoh berikut memilih budaya Jepang, membuka presentasi dengan opsi muat yang dikonfigurasi, dan memanggil [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) untuk setiap buku kerja diagram:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Budaya pilihan merupakan bagian dari konfigurasi pemuatan presentasi, jadi tentukan sebelum membuat instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Gunakan budaya yang diharapkan oleh formula buku kerja; misalnya, gunakan `ja-JP` untuk formula yang harus mengikuti aturan perhitungan DBCS Jepang.

## **Penghitungan Ulang dan Nilai yang Di‑cache**

Berkas spreadsheet biasanya menyimpan baik formula maupun nilai terakhir yang dihitung. Oleh karena itu Aspose.Slides dapat membaca nilai yang di‑cache dari [ChartDataCell::getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#getValue) saat presentasi dimuat dan data diagram yang relevan belum berubah.

Setelah mengubah sel input atau formula, jangan bergantung pada hasil cache lama. Panggil [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) sebelum membaca nilai yang dihitung atau menyimpan data diagram yang bergantung pada mereka.

Untuk formula di luar subset yang didukung, Aspose.Slides mungkin tidak dapat mengurai formula atau menetapkan dependensinya. Jika buku kerja telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi tersebut, membaca nilai sel dengan data yang tidak didukung dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellunsupporteddataexception/).

Jika diagram Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung formula tersebut dengan mesin spreadsheet yang mendukungnya dan tulis kembali nilai hasilnya ke buku kerja diagram. Jangan mengganti formula yang tidak didukung dengan nilai tebakan.

## **Menangani Kesalahan Formula**

Ada dua jenis masalah yang berbeda untuk dibedakan.

Formula dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token kesalahan merupakan hasil sel dan dapat dikembalikan melalui [ChartDataCell::getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#getValue).

Formula juga dapat gagal pada tingkat parsing, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian khusus spreadsheet untuk kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellunsupporteddataexception/).

Di PHP via Java, pengecualian Java ditampilkan melalui `JavaException`. Ketika formula berasal dari templat atau input pengguna, tangani di sekitar penghitungan ulang dan akses nilai. Pengecualian Java yang dilaporkan dalam jejak tumpukan mengidentifikasi kegagalan spreadsheet spesifik:

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

Dukungan formula dalam lembar kerja diagram ditujukan untuk subset tertentu perhitungan spreadsheet, bukan untuk kompatibilitas penuh Excel. Ingat batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang didokumentasikan ketika Anda memerlukan Aspose.Slides menghitung ulang formula.
- Hitung ulang setelah mengubah sel yang menjadi dependensi hasil formula.
- Anggap nilai yang di‑cache dari presentasi yang dimuat sebagai snapshot, bukan sebagai pengganti penghitungan ulang setelah edit.
- Uji formula dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka menggunakan fungsi di luar daftar yang didokumentasikan.
- Untuk formula yang memerlukan mesin perhitungan spreadsheet lengkap, hitung secara eksternal kemudian perbarui buku kerja diagram dengan nilai hasilnya.

## **FAQ**

**Apa perbedaan antara [ChartDataCell::setFormula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setFormula) dan [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula] menyimpan ekspresi gaya A1 seperti `B2-C2`. [ChartDataCell::setR1C1Formula] menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling cocok dengan cara Anda menghasilkan atau menyalin formula.

**Apakah saya perlu membaca sel itu sendiri atau nilainya setelah perhitungan?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#getCell) mengembalikan sebuah [ChartDataCell]. Untuk memperoleh hasil yang dihitung, panggil metode [ChartDataCell::getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/#getValue) pada sel tersebut setelah penghitungan ulang.

**Kapan saya harus memanggil [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Hubungi [ChartDataWorkbook::calculateFormulas] setelah mengubah nilai input atau formula dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai formula yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung semua fungsi Excel?**

Tidak. Evaluator bawaan mendukung subset fungsi yang didokumentasikan. Fungsi di luar subset tersebut tidak boleh diasumsikan dapat dihitung ulang dengan benar. Jika diperlukan kompatibilitas formula Excel penuh, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tulis nilai akhir ke buku kerja diagram.

**Apa yang terjadi jika presentasi yang dimuat berisi formula yang tidak didukung?**

Jika data diagram tidak berubah, buku kerja mungkin masih berisi nilai cache yang telah dihitung sebelumnya. Setelah data terkait dimodifikasi, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel dengan formula yang tidak dapat ditangani dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellunsupporteddataexception/).

**Apakah nilai kesalahan formula sama dengan pengecualian PHP?**

Tidak. Hasil seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Kegagalan pemrosesan spreadsheet seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellcircularreferenceexception/) adalah pengecualian Java yang ditampilkan ke PHP melalui `JavaException`.

**Apakah diagram diperbarui secara otomatis ketika sel formula berubah?**

Sebuah seri diagram dapat merujuk ke sel buku kerja. Hitung ulang buku kerja terlebih dahulu, kemudian simpan atau render presentasi. Jika poin data diagram merujuk ke sel yang dihitung, diagram akan menggunakan nilai sel yang diperbarui; tidak diperlukan metode refresh diagram terpisah untuk alur kerja ini.

**Dapatkah diagram menggunakan buku kerja Excel eksternal?**

Ya, data diagram dapat dikonfigurasi untuk menggunakan buku kerja eksternal melalui API data diagram. Namun, alur kerja perhitungan formula yang dijelaskan dalam artikel ini berkaitan dengan buku kerja data diagram dan subset formula yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) memberikan penghitungan penuh untuk formula apa pun dalam file XLSX eksternal.

**Dapatkah saya menggunakan formula yang merujuk ke lembar kerja atau buku kerja lain?**

Referensi gaya Excel mungkin ada dalam buku kerja diagram, tetapi evaluasi formula dibatasi oleh parser dan set fungsi yang didukung. Jika referensi lintas lembar atau eksternal penting, validasi formula tersebut dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel yang luas, hitung buku kerja secara eksternal dan tulis nilai yang terurai kembali ke data diagram.

**Haruskah string formula dimulai dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa `=` di depan. Menggunakan bentuk itu menjaga formula yang dihasilkan konsisten dengan contoh API yang didokumentasikan.