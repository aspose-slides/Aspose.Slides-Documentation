---
title: Terapkan Formula Lembar Kerja Diagram dalam Presentasi di Android
linktitle: Formula Lembar Kerja
type: docs
weight: 70
url: /id/androidjava/chart-worksheet-formulas/
keywords:
- spreadsheet diagram
- lembar kerja diagram
- formula diagram
- formula lembar kerja
- formula spreadsheet
- buku kerja data diagram
- perhitungan formula
- budaya pilihan
- formula spesifik budaya
- DBCS
- konstanta logika
- konstanta numerik
- konstanta string
- konstanta error
- operator aritmatika
- operator perbandingan
- gaya A1
- gaya R1C1
- fungsi bawaan
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Terapkan formula bergaya Excel dalam Aspose.Slides untuk Android via Java pada lembar kerja diagram, hitung ulang nilai, dan gunakan hasilnya dalam diagram PowerPoint."
---
## **Gambaran Umum**

Diagram PowerPoint biasanya menyimpan data sumbernya dalam lembar kerja yang disematkan. Dalam Aspose.Slides for Android via Java, Anda dapat mengakses lembar kerja tersebut melalui buku kerja data diagram, menulis nilai masukan, menetapkan formula ke sel, menghitung formula yang didukung, dan menggunakan sel yang dihitung sebagai data diagram.

Artikel ini menjelaskan alur kerja formula secara lengkap: membuat diagram, mengisi lembar kerjanya, menetapkan formula gaya A1 atau R1C1, menghitung ulang, membaca nilai yang dihitung, menghubungkan sel tersebut ke serangkaian diagram, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks formula yang didukung, subkumpulan fungsi bawaan, nilai yang di‑cache, formula yang tidak didukung, dan kesalahan khusus spreadsheet.

## **Lembar Kerja Diagram dan Formula**

Lembar kerja diagram berisi kategori, nama seri, dan nilai yang digunakan oleh diagram. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka penyunting data diagram:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspos melalui antarmuka [IChartDataWorkbook](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/). Gunakan [IChartDataCell.setFormula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) untuk formula gaya A1 dan [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) untuk formula gaya R1C1. Setelah mengubah sel masukan atau formula, panggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) untuk menghitung ulang formula yang didukung dan memperbarui nilai sel yang bersesuaian.

Sel yang dihitung tetap mengekspos hasilnya melalui [IChartDataCell.getValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#getValue--). Ini penting bila Anda perlu memeriksa hasil formula dalam kode atau menggunakan sel sebagai titik data diagram.

## **Buat Diagram dan Hitung Formula Lembar Kerja**

Contoh berikut memperlihatkan alur kerja ujung‑ke‑ujung. Ia membuat diagram kolom berkelompok, menghapus data contoh, menulis nilai pendapatan dan pengeluaran kuartalan, menghitung laba dengan formula, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai diagram, dan menyimpan presentasi.

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

Poin data diagram merujuk ke `D2:D4`, sehingga diagram menggunakan nilai laba yang dihitung. Tidak ada pemanggilan penyegaran diagram terpisah dalam alur kerja ini: hitung ulang buku kerja terlebih dahulu, kemudian gunakan atau simpan data diagram yang menunjuk ke sel yang dihitung.

## **Gunakan Formula Gaya A1**

Notasi A1 mengidentifikasi kolom dengan huruf dan baris dengan angka. Tetapkan ekspresi gaya A1 melalui [IChartDataCell.setFormula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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

Bentuk referensi A1 yang umum:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `A2` | `$A$2` | `A$2`, `$A2` |
| Baris | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Rentang | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika formula dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sedangkan referensi campuran memperbaiki hanya baris atau hanya kolom.

## **Gunakan Formula Gaya R1C1**

Notasi R1C1 mengidentifikasi baris dan kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

Bentuk referensi R1C1 yang umum:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Baris | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Rentang | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Misalnya, dalam sel `D2`, `RC[-2]` berarti sel pada baris yang sama dua kolom ke kiri (`B2`).

## **Konstanta dan Operator Formula**

Evaluator formula bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmatika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks dikelilingi tanda kutip ganda di dalam formula. |
| Hasil kesalahan | `#DIV/0!`, `#N/A`, `#REF!` | Formula yang valid dapat menghasilkan nilai kesalahan spreadsheet alih‑alih hasil normal. |

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

### **Operator Aritmatika**

| Operator | Makna | Contoh |
|---|---|---|
| `+` | Penjumlahan atau plus unary | `2+3` |
| `-` | Pengurangan atau negasi | `2-3`, `-3` |
| `*` | Perkalian | `2*3` |
| `/` | Pembagian | `2/3` |
| `%` | Persen | `30%` |
| `^` | Pangkat | `2^3` |

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

Aspose.Slides menyertakan evaluator formula bawaan untuk lembar kerja diagram, tetapi bukan mesin perhitungan Excel yang lengkap. Set fungsi yang didokumentasikan terbatas pada fungsi di bawah ini. Jangan mengasumsikan bahwa fungsi Excel apa pun dapat dihitung ulang oleh [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Fungsi | Tujuan atau bentuk yang didukung | Contoh |
|---|---|---|
| `ABS` | Nilai absolut | `ABS(A2)` |
| `AVERAGE` | Rata‑rata aritmatika | `AVERAGE(B2:B5)` |
| `CEILING` | Membulatkan angka ke atas ke kelipatan | `CEILING(A2,5)` |
| `CHOOSE` | Memilih nilai berdasarkan indeks | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Menggabungkan nilai teks | `CONCAT(A2,B2)` |
| `CONCATENATE` | Menggabungkan nilai teks | `CONCATENATE(A2," ",B2)` |
| `DATE` | Membuat nilai tanggal menggunakan sistem tanggal 1900 | `DATE(2026,8,19)` |
| `DAYS` | Mengembalikan jumlah hari antara dua tanggal | `DAYS(B2,A2)` |
| `FIND` | Menemukan satu nilai teks di dalam teks lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berorientasi byte | `FINDB("a",A2)` |
| `IF` | Hasil bersyarat | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlahkan nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan yang ditunjukkan dalam tabel bersifat signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sedangkan `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektor. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator formula Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Hitung Formula dengan Budaya Pilihan**

Beberapa fungsi buku kerja diagram menafsirkan teks menurut aturan budaya tertentu. Ini terutama penting untuk fungsi yang ditujukan bagi bahasa yang menggunakan set karakter ganda byte (DBCS). Untuk menghitung formula tersebut dengan tepat, buat [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/), atur budaya pilihan dengan [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), tetapkan opsi spreadsheet melalui [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), lalu muat presentasi.

Contoh berikut memilih budaya Jepang, membuka presentasi dengan opsi muat yang dikonfigurasi, dan memanggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) untuk setiap buku kerja diagram:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Budaya pilihan adalah bagian dari konfigurasi pemuatan presentasi, jadi tentukan sebelum membuat instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Gunakan budaya yang diharapkan oleh formula buku kerja; misalnya, gunakan `ja-JP` untuk formula yang harus mengikuti aturan perhitungan DBCS Jepang.

## **Perhitungan Ulang dan Nilai yang di‑Cache**

File spreadsheet biasanya menyimpan baik formula maupun nilai terhitung terakhirnya. Aspose.Slides dapat membaca nilai yang di‑cache dari [IChartDataCell.getValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#getValue--) ketika presentasi dimuat dan data diagram yang relevan belum diubah.

Setelah mengubah sel masukan atau formula, jangan mengandalkan hasil cache lama. Panggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) sebelum membaca nilai yang dihitung atau menyimpan data diagram yang bergantung padanya.

Untuk formula di luar sub‑set yang didukung, Aspose.Slides mungkin tidak dapat mengurai formula atau menentukan dependensinya. Jika buku kerja telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi tersebut, membaca nilai sel dengan data yang tidak didukung dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Jika diagram Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung formula tersebut dengan mesin spreadsheet yang mendukungnya dan tulis nilai hasilnya kembali ke buku kerja diagram. Jangan mengganti formula yang tidak didukung dengan nilai perkiraan.

## **Menangani Kesalahan Formula**

Ada dua jenis masalah yang berbeda untuk dibedakan.

Sebuah formula dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token kesalahan adalah hasil sel dan dapat dikembalikan melalui [IChartDataCell.getValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Sebuah formula juga dapat gagal pada tingkat penguraian, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian khusus spreadsheet untuk kasus‑kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Ketika formula berasal dari templat atau masukan pengguna, tangani pengecualian ini di sekitar perhitungan ulang dan akses nilai:

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

Dukungan formula dalam lembar kerja diagram ditujukan untuk sub‑set perhitungan spreadsheet yang terdefinisi, bukan untuk kompatibilitas Excel penuh. Ingat batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang didokumentasikan ketika Anda memerlukan Aspose.Slides untuk menghitung ulang formula.
- Hitung ulang setelah mengubah sel yang memengaruhi hasil formula.
- Anggap nilai yang di‑cache dari presentasi yang dimuat sebagai snapshot, bukan sebagai pengganti perhitungan ulang setelah penyuntingan.
- Uji formula dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka memakai fungsi di luar daftar yang didokumentasikan.
- Untuk formula yang memerlukan mesin perhitungan spreadsheet lengkap, hitung secara eksternal lalu perbarui buku kerja diagram dengan nilai hasilnya.

## **FAQ**

**Apa perbedaan antara [IChartDataCell.setFormula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) dan [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) menyimpan ekspresi gaya A1 seperti `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling cocok dengan cara Anda menghasilkan atau menyalin formula.

**Apakah saya harus membaca sel itu sendiri atau nilainya setelah perhitungan?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) mengembalikan sebuah [IChartDataCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/). Untuk memperoleh hasil yang dihitung, panggil metode [IChartDataCell.getValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#getValue--) pada sel tersebut setelah perhitungan ulang.

**Kapan saya harus memanggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Panggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) setelah mengubah nilai masukan atau formula dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai formula yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung setiap fungsi Excel?**

Tidak. Evaluator bawaan mendukung sub‑set fungsi yang didokumentasikan. Fungsi di luar sub‑set tersebut tidak boleh diasumsikan dapat dihitung ulang dengan benar. Jika kompatibilitas formula Excel penuh diperlukan, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tulis nilai akhir ke buku kerja diagram.

**Apa yang terjadi jika presentasi yang dimuat berisi formula yang tidak didukung?**

Jika data diagram tidak berubah, buku kerja mungkin masih berisi nilai cache yang telah dihitung sebelumnya. Setelah data terkait dimodifikasi, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang formula-nya tidak dapat ditangani dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Apakah nilai kesalahan formula sama dengan pengecualian Java?**

Tidak. Hasil seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Pengecualian seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellcircularreferenceexception/) menunjukkan bahwa formula tidak dapat diproses secara normal.

**Apakah diagram memperbarui secara otomatis ketika sel formula berubah?**

Seri diagram dapat merujuk ke sel buku kerja. Hitung ulang buku kerja terlebih dahulu, kemudian simpan atau render presentasi. Jika poin data diagram merujuk ke sel yang dihitung, diagram akan menggunakan nilai sel yang diperbarui; tidak ada metode penyegaran diagram terpisah yang diperlukan untuk alur kerja ini.

**Dapatkah diagram menggunakan buku kerja Excel eksternal?**

Ya, data diagram dapat dikonfigurasi untuk menggunakan buku kerja eksternal melalui API data diagram. Namun, alur kerja perhitungan formula yang dibahas dalam artikel ini berlaku untuk buku kerja data diagram dan sub‑set formula yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) memberikan perhitungan penuh untuk formula apa pun dalam file XLSX eksternal.

**Dapatkah saya menggunakan formula yang merujuk ke lembar kerja atau buku kerja lain?**

Referensi gaya Excel mungkin ada dalam buku kerja diagram, tetapi evaluasi formula dibatasi oleh parser dan set fungsi yang didukung. Jika referensi lintas lembar atau eksternal penting, validasikan formula tersebut dengan versi Aspose.Slides target Anda. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel luas, hitung buku kerja secara eksternal dan tulis kembali nilai yang telah diselesaikan ke data diagram.

**Haruskah string formula dimulai dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa `=` di depan. Menggunakan bentuk itu menjaga konsistensi formula yang dihasilkan dengan contoh API yang didokumentasikan.