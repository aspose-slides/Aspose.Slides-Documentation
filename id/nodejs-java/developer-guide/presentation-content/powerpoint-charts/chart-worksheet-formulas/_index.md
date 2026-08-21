---
title: Terapkan Rumus Lembar Kerja Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Rumus Lembar Kerja
type: docs
weight: 70
url: /id/nodejs-java/chart-worksheet-formulas/
keywords:
- spreadsheet diagram
- lembar kerja diagram
- rumus diagram
- rumus lembar kerja
- rumus spreadsheet
- buku kerja data diagram
- perhitungan rumus
- budaya pilihan
- rumus khusus budaya
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Terapkan rumus bergaya Excel dalam Aspose.Slides untuk Node.js melalui lembar kerja diagram Java, hitung ulang nilai, dan gunakan hasilnya dalam diagram PowerPoint."
---
## **Gambaran Umum**

Diagram PowerPoint biasanya menyimpan data sumbernya dalam lembar kerja yang tersemat. Dalam Aspose.Slides untuk Node.js via Java, Anda dapat mengakses lembar kerja tersebut melalui chart data workbook, menulis nilai input, menetapkan rumus ke sel, menghitung rumus yang didukung, dan menggunakan sel yang telah dihitung sebagai data diagram.

Artikel ini menjelaskan alur kerja rumus secara lengkap: membuat diagram, mengisi lembar kerjanya, menetapkan rumus gaya A1 atau R1C1, menghitung kembali rumus, membaca nilai yang dihitung, menghubungkan sel‑sel tersebut ke seri diagram, dan menyimpan presentasi. Artikel ini juga menggambarkan sintaks rumus yang didukung, subset fungsi bawaan, nilai cache, rumus yang tidak didukung, dan kesalahan khusus spreadsheet.

## **Lembar Kerja Grafik dan Rumus**

Lembar kerja grafik berisi kategori, nama seri, dan nilai yang digunakan oleh sebuah diagram. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka editor data diagram:

![Diagram PowerPoint dengan lembar kerja tersemat terbuka, menampilkan data kategori dan seri](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspos melalui kelas [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/). Gunakan [ChartDataCell.setFormula](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) untuk rumus gaya A1 dan [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) untuk rumus gaya R1C1. Setelah mengubah sel input atau rumus, panggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) untuk menghitung ulang rumus yang didukung dan memperbarui nilai sel yang bersangkutan.

Sel yang telah dihitung tetap menampilkan hasilnya melalui [ChartDataCell.getValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#getValue--). Ini penting ketika Anda perlu memeriksa hasil rumus dalam kode atau menggunakan sel tersebut sebagai titik data diagram.

## **Buat Grafik dan Hitung Rumus Lembar Kerja**

Contoh berikut memperlihatkan alur kerja ujung‑ke‑ujung. Ia membuat diagram kolom berkelompok, menghapus data contoh, menulis nilai pendapatan dan biaya kuartalan, menghitung laba dengan rumus, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai diagram, dan menyimpan presentasi.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Titik data diagram merujuk ke `D2:D4`, sehingga diagram menggunakan nilai laba yang telah dihitung. Tidak ada pemanggilan refresh diagram terpisah dalam alur kerja ini: hitung ulang workbook terlebih dahulu, lalu gunakan atau simpan data diagram yang menunjuk ke sel yang dihitung.

## **Gunakan Rumus Gaya A1**

Notasi A1 mengidentifikasi kolom dengan huruf dan baris dengan angka. Tetapkan ekspresi gaya A1 melalui [ChartDataCell.setFormula](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Bentuk referensi A1 umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `A2` | `$A$2` | `A$2`, `$A2` |
| Baris | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Rentang | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika rumus dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sementara referensi campuran memperbaiki hanya baris atau kolom saja.

## **Gunakan Rumus Gaya R1C1**

Notasi R1C1 mengidentifikasi baris dan kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
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

## **Konstanta Rumus dan Operator**

Evaluator rumus bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmetika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi biasa dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks ditulis dalam tanda kutip ganda di dalam rumus. |
| Hasil Kesalahan | `#DIV/0!`, `#N/A`, `#REF!` | Rumus yang valid dapat menghasilkan nilai kesalahan spreadsheet alih‑alih hasil normal. |

Contoh ini menggunakan beberapa tipe konstanta:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Operator Aritmetika**

| Operator | Arti | Contoh |
|---|---|---|
| `+` | Penjumlahan atau plus unary | `2+3` |
| `-` | Pengurangan atau negasi | `2-3`, `-3` |
| `*` | Perkalian | `2*3` |
| `/` | Pembagian | `2/3` |
| `%` | Persen | `30%` |
| `^` | Pangkat | `2^3` |

Gunakan tanda kurung untuk membuat urutan evaluasi jelas, misalnya `(A2+B2)*C2`.

### **Operator Perbandingan**

Ekspresi perbandingan mengembalikan nilai logika.

| Operator | Arti | Contoh |
|---|---|---|
| `=` | Sama dengan | `A2=3` |
| `<>` | Tidak sama dengan | `A2<>3` |
| `>` | Lebih besar dari | `A2>3` |
| `>=` | Lebih besar atau sama dengan | `A2>=3` |
| `<` | Lebih kecil dari | `A2<3` |
| `<=` | Lebih kecil atau sama dengan | `A2<=3` |

## **Fungsi Tertentu yang Didukung**

Aspose.Slides menyertakan evaluator rumus bawaan untuk lembar kerja diagram, namun bukan mesin perhitungan Excel lengkap. Set fungsi yang didokumentasikan terbatas pada fungsi berikut. Jangan mengasumsikan bahwa fungsi Excel arbitrer dapat dihitung ulang oleh [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Fungsi | Tujuan atau bentuk yang didukung | Contoh |
|---|---|---|
| `ABS` | Nilai absolut | `ABS(A2)` |
| `AVERAGE` | Rata‑rata aritmetika | `AVERAGE(B2:B5)` |
| `CEILING` | Membulatkan ke atas ke kelipatan | `CEILING(A2,5)` |
| `CHOOSE` | Memilih nilai berdasarkan indeks | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Menggabungkan nilai teks | `CONCAT(A2,B2)` |
| `CONCATENATE` | Menggabungkan nilai teks | `CONCATENATE(A2," ",B2)` |
| `DATE` | Membuat nilai tanggal menggunakan sistem tanggal 1900 | `DATE(2026,8,19)` |
| `DAYS` | Mengembalikan jumlah hari antara tanggal | `DAYS(B2,A2)` |
| `FIND` | Menemukan satu nilai teks di dalam teks lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil bersyarat | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlahkan nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan yang ditunjukkan dalam tabel signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sementara `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektor. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator rumus Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Hitung Rumus dengan Budaya Pilihan**

Beberapa fungsi workbook diagram menafsirkan teks berdasarkan aturan budaya‑spesifik. Ini terutama penting untuk fungsi yang ditujukan bagi bahasa yang menggunakan set karakter ganda (DBCS). Untuk menghitung rumus tersebut dengan benar, buat [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/), atur budaya pilihan dengan [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), tetapkan opsi spreadsheet melalui [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), lalu muat presentasi.

Contoh berikut memilih budaya Jepang, membuka presentasi dengan opsi muat yang dikonfigurasi, dan memanggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) untuk setiap workbook diagram:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Budaya pilihan merupakan bagian dari konfigurasi pemuatan presentasi, sehingga tetapkan sebelum membuat instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Gunakan budaya yang diharapkan oleh rumus workbook; misalnya, gunakan `ja-JP` untuk rumus yang harus mengikuti aturan perhitungan DBCS Jepang.

## **Rekalkulasi dan Nilai Cache**

File spreadsheet biasanya menyimpan baik rumus maupun nilai yang terakhir dihitung. Aspose.Slides dapat membaca nilai cache dari [ChartDataCell.getValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#getValue--) ketika presentasi dimuat dan data diagram terkait belum diubah.

Setelah mengubah sel input atau rumus, jangan mengandalkan hasil cache lama. Panggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) sebelum membaca nilai yang dihitung atau menyimpan data diagram yang bergantung padanya.

Untuk rumus di luar subset yang didukung, Aspose.Slides mungkin tidak dapat menguraikan rumus atau menentukan dependensinya. Jika workbook telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi tersebut, membaca nilai sel dengan data yang tidak didukung dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Jika diagram Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung rumus tersebut dengan mesin spreadsheet yang mendukungnya dan tulis nilai hasil kembali ke workbook diagram. Jangan mengganti rumus yang tidak didukung dengan nilai tebak‑tebakan.

## **Tangani Kesalahan Rumus**

Ada dua jenis masalah yang perlu dibedakan.

Sebuah rumus dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token kesalahan adalah hasil sel dan dapat dikembalikan melalui [ChartDataCell.getValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Sebuah rumus juga dapat gagal pada tingkat penguraian, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian khusus spreadsheet untuk kasus‑kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Ketika rumus berasal dari templat atau input pengguna, tangkap kesalahan di sekitar proses rekalkulasi dan akses nilai. Detail kesalahan mengidentifikasi masalah spreadsheet yang mendasari:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Batasan Praktis**

Dukungan rumus dalam lembar kerja diagram ditujukan untuk subset perhitungan spreadsheet tertentu, bukan untuk kompatibilitas Excel penuh. Ingatlah batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang terdokumentasi ketika Anda memerlukan Aspose.Slides untuk menghitung ulang rumus.
- Hitung ulang setelah mengubah sel yang menjadi dasar hasil rumus.
- Anggap nilai cache dari presentasi yang dimuat sebagai snapshot, bukan pengganti rekalkulasi setelah penyuntingan.
- Uji rumus dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka menggunakan fungsi di luar daftar yang didokumentasikan.
- Untuk rumus yang memerlukan mesin perhitungan spreadsheet penuh, hitunglah secara eksternal dan kemudian perbarui workbook diagram dengan nilai hasilnya.

## **Tanya Jawab**

**Apa perbedaan antara [ChartDataCell.setFormula](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) dan [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) menyimpan ekspresi gaya A1 seperti `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling cocok dengan cara Anda menghasilkan atau menyalin rumus.

**Apakah saya perlu membaca sel itu sendiri atau nilai sel setelah perhitungan?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) mengembalikan sebuah [ChartDataCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/). Untuk memperoleh hasil yang dihitung, panggil metode [ChartDataCell.getValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#getValue--) pada sel tersebut setelah rekalkulasi.

**Kapan saya harus memanggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

Panggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) setelah mengubah nilai input atau rumus dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai rumus yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung setiap fungsi Excel?**

Tidak. Evaluator bawaan mendukung subset fungsi yang terdokumentasi. Fungsi di luar subset itu tidak boleh diasumsikan dapat dihitung ulang dengan benar. Jika diperlukan kompatibilitas rumus Excel penuh, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tulis nilai akhir ke workbook diagram.

**Apa yang terjadi jika presentasi yang dimuat berisi rumus yang tidak didukung?**

Jika data diagram tidak berubah, workbook mungkin masih memiliki nilai cache yang telah dihitung sebelumnya. Setelah data terkait diubah, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang rumusnya tidak dapat ditangani dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**Apakah nilai kesalahan rumus sama dengan pengecualian?**

Tidak. Hasil seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Pengecualian seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellcircularreferenceexception/) menunjukkan bahwa rumus tidak dapat diproses secara normal.

**Apakah diagram memperbarui secara otomatis ketika sel rumus berubah?**

Seri diagram dapat merujuk ke sel workbook. Hitung ulang workbook terlebih dahulu, lalu simpan atau render presentasi. Jika titik data diagram merujuk ke sel yang dihitung, diagram akan menggunakan nilai sel yang diperbarui; tidak diperlukan metode refresh diagram terpisah untuk alur kerja ini.

**Dapatkah diagram menggunakan workbook Excel eksternal?**

Ya, data diagram dapat dikonfigurasi untuk menggunakan workbook eksternal melalui API data diagram. Namun, alur kerja perhitungan rumus yang dijelaskan dalam artikel ini berkaitan dengan workbook data diagram dan subset rumus yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) menyediakan perhitungan penuh untuk rumus apa pun dalam file XLSX eksternal.

**Dapatkah saya menggunakan rumus yang merujuk ke lembar kerja atau workbook lain?**

Referensi gaya Excel mungkin ada dalam workbook diagram, tetapi evaluasi rumus terbatas oleh parser dan set fungsi yang didukung. Jika referensi lintas‑sheet atau eksternal penting, validasikan rumus tersebut dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel luas, hitung workbook secara eksternal dan tulis nilai yang telah diselesaikan kembali ke data diagram.

**Apakah string rumus harus diawali dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa `=` di depan. Menggunakan bentuk itu menjaga konsistensi rumus yang dihasilkan dengan contoh API yang terdokumentasi.