---
title: Terapkan Formula Lembar Kerja Grafik dalam Presentasi di Java
linktitle: Formula Lembar Kerja
type: docs
weight: 70
url: /id/java/chart-worksheet-formulas/
keywords:
- spreadsheet grafik
- lembar kerja grafik
- formula grafik
- formula lembar kerja
- formula spreadsheet
- buku kerja data grafik
- perhitungan formula
- konstanta logika
- konstanta numerik
- konstanta string
- konstanta error
- operator aritmetika
- operator perbandingan
- gaya A1
- gaya R1C1
- fungsi bawaan
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Terapkan formula gaya Excel di lembar kerja grafik Aspose.Slides untuk Java, hitung ulang nilai, dan gunakan hasilnya dalam grafik PowerPoint."
---
## **Gambaran Umum**

Grafik PowerPoint biasanya menyimpan data sumbernya dalam lembar kerja yang disematkan. Di Aspose.Slides untuk Java, Anda dapat mengakses lembar kerja tersebut melalui workbook data grafik, menulis nilai masukan, menetapkan formula ke sel, menghitung formula yang didukung, dan menggunakan sel yang telah dihitung sebagai data grafik.

Artikel ini menjelaskan alur kerja formula secara lengkap: membuat grafik, mengisi lembar kerjanya, menetapkan formula gaya A1 atau R1C1, menghitung ulang, membaca nilai yang dihitung, menghubungkan sel‑sel tersebut ke seri grafik, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks formula yang didukung, subset fungsi bawaan, nilai yang di‑cache, formula yang tidak didukung, serta kesalahan spesifik spreadsheet.

## **Lembar Kerja Grafik dan Formula**

Lembar kerja grafik berisi kategori, nama seri, dan nilai yang digunakan oleh grafik. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka editor data grafik:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspos melalui antarmuka [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/). Gunakan [IChartDataCell.setFormula](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) untuk formula gaya A1 dan [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) untuk formula gaya R1C1. Setelah mengubah sel masukan atau formula, panggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) untuk menghitung ulang formula yang didukung dan memperbarui nilai sel yang bersangkutan.

Sel yang telah dihitung tetap mengekspos hasilnya melalui [IChartDataCell.getValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#getValue--). Ini penting ketika Anda perlu memeriksa hasil formula dalam kode atau menggunakan sel tersebut sebagai titik data grafik.

## **Membuat Grafik dan Menghitung Formula Lembar Kerja**

Contoh berikut menunjukkan alur kerja ujung‑ke‑ujung. Ini membuat grafik kolom berkelompok, menghapus data contoh, menulis nilai pendapatan dan biaya triwulanan, menghitung laba dengan formula, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai grafik, dan menyimpan presentasi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Titik data grafik merujuk ke `D2:D4`, sehingga grafik menggunakan nilai laba yang dihitung. Tidak ada pemanggilan penyegaran grafik terpisah dalam alur kerja ini: hitung ulang workbook terlebih dahulu, kemudian gunakan atau simpan data grafik yang mengacu ke sel‑sel yang telah dihitung.

## **Menggunakan Formula Gaya A1**

Notasi A1 mengidentifikasi kolom dengan huruf dan baris dengan angka. Tetapkan ekspresi gaya A1 melalui [IChartDataCell.setFormula](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Bentuk referensi A1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `A2` | `$A$2` | `A$2`, `$A2` |
| Baris | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Rentang | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika formula dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sedangkan referensi campuran mengunci hanya baris atau kolom saja.

## **Menggunakan Formula Gaya R1C1**

Notasi R1C1 mengidentifikasi baik baris maupun kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
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

## **Konstanta dan Operator Formula**

Evaluator formula bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmetika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks dikelilingi tanda kutip ganda di dalam formula. |
| Hasil error | `#DIV/0!`, `#N/A`, `#REF!` | Formula yang valid dapat mengevaluasi menjadi nilai kesalahan spreadsheet alih‑alih hasil normal. |

Contoh ini menggunakan beberapa tipe konstanta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
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
| `^` | Eksponensial | `2^3` |

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

Aspose.Slides menyertakan evaluator formula bawaan untuk lembar kerja grafik, tetapi bukan mesin perhitungan Excel yang lengkap. Set fungsi yang didokumentasikan terbatas pada fungsi‑fungsi di bawah ini. Jangan menganggap bahwa fungsi Excel arbitrer dapat dihitung ulang oleh [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

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
| `FIND` | Menemukan satu nilai teks di dalam teks lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil kondisional | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlahkan nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan yang ditunjukkan dalam tabel penting: `INDEX` didokumentasikan dalam bentuk referensi, sementara `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektor. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator formula Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Perhitungan Ulang dan Nilai yang di‑Cache**

File spreadsheet biasanya menyimpan baik formula maupun nilai terakhir yang dihitung. Aspose.Slides dapat membaca nilai yang di‑cache dari [IChartDataCell.getValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#getValue--) ketika presentasi dimuat dan data grafik yang bersangkutan belum diubah.

Setelah mengubah sel masukan atau formula, jangan mengandalkan hasil cache lama. Panggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) sebelum membaca nilai yang dihitung atau menyimpan data grafik yang bergantung padanya.

Untuk formula di luar subset yang didukung, Aspose.Slides mungkin tidak dapat mengurai formula atau menentukan dependensinya. Jika workbook telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi itu, membaca nilai sel dengan data tidak didukung dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellunsupporteddataexception/).

Jika grafik Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung formula tersebut dengan mesin spreadsheet yang mendukungnya dan tuliskan nilai hasilnya kembali ke workbook grafik. Jangan mengganti formula yang tidak didukung dengan nilai perkiraan.

## **Menangani Kesalahan Formula**

Ada dua jenis masalah yang harus dibedakan.

Sebuah formula dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token kesalahan adalah hasil sel dan dapat dikembalikan melalui [IChartDataCell.getValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#getValue--).

Sebuah formula juga dapat gagal pada tingkat penguraian, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian spesifik spreadsheet untuk kasus‑kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellunsupporteddataexception/).

Ketika formula berasal dari templat atau input pengguna, tangani pengecualian‑pengecualian ini di sekitar perhitungan ulang dan akses nilai:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Batasan Praktis**

Dukungan formula pada lembar kerja grafik ditujukan untuk subset perhitungan spreadsheet yang terdefinisi, bukan untuk kompatibilitas Excel secara penuh. Ingatkan batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang didokumentasikan ketika Anda memerlukan Aspose.Slides untuk menghitung ulang formula.
- Hitung ulang setelah mengubah sel yang menjadi dependensi hasil formula.
- Anggap nilai yang di‑cache dari presentasi yang dimuat sebagai snapshot, bukan sebagai pengganti perhitungan ulang setelah suntingan.
- Uji formula dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka menggunakan fungsi di luar daftar yang didokumentasikan.
- Untuk formula yang memerlukan mesin perhitungan spreadsheet lengkap, hitunglah secara eksternal lalu perbarui workbook grafik dengan nilai hasilnya.

## **FAQ**

**Apa perbedaan antara [IChartDataCell.setFormula](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) dan [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) menyimpan ekspresi gaya A1 seperti `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling sesuai dengan cara Anda menghasilkan atau menyalin formula.

**Apakah saya harus membaca sel itu sendiri atau nilainya setelah perhitungan?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) mengembalikan sebuah [IChartDataCell](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/). Untuk memperoleh hasil yang dihitung, panggil metode [IChartDataCell.getValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#getValue--) pada sel tersebut setelah perhitungan ulang.

**Kapan saya harus memanggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Panggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) setelah mengubah nilai masukan atau formula dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai formula yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung setiap fungsi Excel?**

Tidak. Evaluator bawaan mendukung subset fungsi yang didokumentasikan. Fungsi di luar subset tersebut tidak boleh diasumsikan dapat dihitung ulang dengan benar. Jika diperlukan kompatibilitas formula Excel secara penuh, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tuliskan nilai akhir ke workbook grafik.

**Apa yang terjadi jika presentasi yang dimuat berisi formula yang tidak didukung?**

Jika data grafik tidak berubah, workbook mungkin masih berisi nilai cache yang telah dihitung sebelumnya. Setelah data terkait diubah, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang formula nya tidak dapat ditangani dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellunsupporteddataexception/).

**Apakah nilai kesalahan formula sama dengan pengecualian Java?**

Tidak. Hasil seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Pengecualian seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellcircularreferenceexception/) menunjukkan bahwa formula tidak dapat diproses secara normal.

**Apakah grafik memperbarui secara otomatis ketika sel formula berubah?**

Seri grafik dapat merujuk ke sel workbook. Hitung ulang workbook terlebih dahulu, kemudian simpan atau render presentasi. Jika titik data grafik merujuk ke sel yang dihitung, grafik akan menggunakan nilai sel yang diperbarui; tidak diperlukan metode penyegaran grafik terpisah untuk alur kerja ini.

**Apakah grafik dapat menggunakan workbook Excel eksternal?**

Ya, data grafik dapat dikonfigurasi untuk menggunakan workbook eksternal melalui API data grafik. Namun, alur kerja perhitungan formula yang dibahas dalam artikel ini berfokus pada workbook data grafik dan subset formula yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) memberikan perhitungan penuh untuk formula arbitrer dalam file XLSX eksternal.

**Apakah saya dapat menggunakan formula yang merujuk ke worksheet atau workbook lain?**

Referensi gaya Excel dapat ada dalam workbook grafik, tetapi evaluasi formula dibatasi oleh parser dan set fungsi yang didukung. Jika referensi lintas‑sheet atau eksternal penting, verifikasi formula tersebut dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel yang luas, hitung workbook secara eksternal dan tuliskan nilai yang telah diselesaikan kembali ke data grafik.

**Haruskah string formula dimulai dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa `=` di depan. Menggunakan bentuk itu membuat formula yang dihasilkan konsisten dengan contoh API yang didokumentasikan.