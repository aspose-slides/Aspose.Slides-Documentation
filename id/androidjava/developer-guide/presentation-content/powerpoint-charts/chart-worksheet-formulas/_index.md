---
title: Terapkan Rumus Lembar Kerja Diagram dalam Presentasi di Android
linktitle: Rumus Lembar Kerja
type: docs
weight: 70
url: /id/androidjava/chart-worksheet-formulas/
keywords:
  - spreadsheet diagram
  - lembar kerja diagram
  - rumus diagram
  - rumus lembar kerja
  - rumus spreadsheet
  - buku kerja data diagram
  - perhitungan rumus
  - konstanta logika
  - konstanta numerik
  - konstanta string
  - konstanta error
  - operator aritmetika
  - operator perbandingan
  - gaya A1
  - gaya R1C1
  - fungsi yang telah ditentukan
  - PowerPoint
  - presentasi
  - Android
  - Java
  - Aspose.Slides
description: "Terapkan rumus gaya Excel dalam Aspose.Slides untuk Android via Java pada lembar kerja diagram, hitung ulang nilai, dan gunakan hasilnya dalam diagram PowerPoint."
---
## **Overview**

Diagram PowerPoint biasanya menyimpan data sumbernya dalam lembar kerja yang disematkan. Dalam Aspose.Slides untuk Android via Java, Anda dapat mengakses lembar kerja tersebut melalui workbook data diagram, menulis nilai input, menetapkan rumus ke sel, menghitung rumus yang didukung, dan menggunakan sel yang telah dihitung sebagai data diagram.

Artikel ini menjelaskan alur kerja rumus lengkap: membuat diagram, mengisi lembar kerjanya, menetapkan rumus gaya A1 atau gaya R1C1, menghitung kembali rumus tersebut, membaca nilai yang dihitung, menghubungkan sel‑sel itu ke seri diagram, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks rumus yang didukung, subset fungsi bawaan, nilai yang di‑cache, rumus yang tidak didukung, dan kesalahan khusus spreadsheet.

## **Chart Worksheets and Formulas**

Lembar kerja diagram berisi kategori, nama seri, dan nilai yang digunakan oleh diagram. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka editor data diagram:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspos melalui antarmuka [IChartDataWorkbook](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/). Gunakan [IChartDataCell.setFormula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) untuk rumus gaya A1 dan [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) untuk rumus gaya R1C1. Setelah mengubah sel input atau rumus, panggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) untuk menghitung ulang rumus yang didukung dan memperbarui nilai sel yang bersangkutan.

Sel yang telah dihitung tetap mengekspos hasilnya melalui [IChartDataCell.getValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#getValue--). Ini penting ketika Anda perlu memeriksa hasil rumus dalam kode atau menggunakan sel sebagai titik data diagram.

## **Create a Chart and Calculate Worksheet Formulas**

Contoh berikut menunjukkan alur kerja end‑to‑end. Ia membuat diagram kolom terkelompok, menghapus data contoh, menulis nilai pendapatan dan biaya kuartalan, menghitung laba dengan rumus, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai diagram, dan menyimpan presentasi.

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

Poin data diagram merujuk ke `D2:D4`, sehingga diagram menggunakan nilai laba yang dihitung. Tidak ada pemanggilan penyegaran diagram terpisah dalam alur kerja ini: hitung ulang workbook terlebih dahulu, lalu gunakan atau simpan data diagram yang mengarah ke sel yang dihitung.

## **Use A1-Style Formulas**

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

Bentuk referensi A1 yang umum adalah:

| Reference | Relative | Absolute | Mixed |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika rumus dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sedangkan referensi campuran hanya mengunci baris atau kolom saja.

## **Use R1C1-Style Formulas**

Notasi R1C1 mengidentifikasi baik baris maupun kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

| Reference | Relative | Absolute | Mixed |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Sebagai contoh, dalam sel `D2`, `RC[-2]` berarti sel pada baris yang sama dua kolom ke kiri (`B2`).

## **Formula Constants and Operators**

Evaluator rumus bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmetika, dan operator perbandingan.

### **Constants and Literals**

| Type | Examples | Notes |
|---|---|---|
| Logical | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks dikelilingi oleh tanda kutip ganda di dalam rumus. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | Rumus yang valid dapat mengevaluasi menjadi nilai kesalahan spreadsheet alih‑alih hasil normal. |

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

### **Arithmetic Operators**

| Operator | Meaning | Example |
|---|---|---|
| `+` | Penjumlahan atau unary plus | `2+3` |
| `-` | Pengurangan atau negasi | `2-3`, `-3` |
| `*` | Perkalian | `2*3` |
| `/` | Pembagian | `2/3` |
| `%` | Persen | `30%` |
| `^` | Pangkat | `2^3` |

Gunakan tanda kurung untuk membuat urutan evaluasi eksplisit, misalnya `(A2+B2)*C2`.

### **Comparison Operators**

Ekspresi perbandingan mengembalikan nilai logika.

| Operator | Meaning | Example |
|---|---|---|
| `=` | Sama dengan | `A2=3` |
| `<>` | Tidak sama dengan | `A2<>3` |
| `>` | Lebih besar dari | `A2>3` |
| `>=` | Lebih besar atau sama dengan | `A2>=3` |
| `<` | Lebih kecil dari | `A2<3` |
| `<=` | Lebih kecil atau sama dengan | `A2<=3` |

## **Supported Predefined Functions**

Aspose.Slides menyertakan evaluator rumus bawaan untuk lembar kerja diagram, tetapi bukan mesin perhitungan Excel lengkap. Set fungsi yang didokumentasikan terbatas pada fungsi-fungsi di bawah ini. Jangan mengasumsikan bahwa fungsi Excel apa pun dapat dihitung ulang oleh [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Function | Purpose or supported form | Example |
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

Pembatasan yang ditunjukkan dalam tabel signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sedangkan `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektor. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator rumus Aspose.Slides, kecuali didokumentasikan secara terpisah.

## **Recalculation and Cached Values**

File spreadsheet biasanya menyimpan baik rumus maupun nilai yang terakhir dihitung. Aspose.Slides dapat membaca nilai yang di‑cache dari [IChartDataCell.getValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#getValue--) ketika presentasi dimuat dan data diagram yang relevan belum diubah.

Setelah mengubah sel input atau rumus, jangan mengandalkan hasil cache lama. Panggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) sebelum membaca nilai yang dihitung atau menyimpan data diagram yang bergantung padanya.

Untuk rumus di luar subset yang didukung, Aspose.Slides mungkin tidak dapat mengurai rumus atau menentukan dependensinya. Jika workbook telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi itu, membaca nilai sel dengan data yang tidak didukung dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Jika diagram Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung rumus tersebut dengan mesin spreadsheet yang mendukungnya dan tulis nilai hasil kembali ke workbook diagram. Jangan mengganti rumus yang tidak didukung dengan nilai tebakan.

## **Handle Formula Errors**

Ada dua jenis masalah yang harus dibedakan.

Sebuah rumus dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token kesalahan merupakan hasil sel dan dapat dikembalikan melalui [IChartDataCell.getValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Sebuah rumus juga dapat gagal pada tingkat parsing, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian khusus spreadsheet untuk kasus‑kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Ketika rumus berasal dari templat atau input pengguna, tangani pengecualian‑pengecualian ini di sekitar perhitungan ulang dan akses nilai:

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

## **Practical Limitations**

Dukungan rumus dalam lembar kerja diagram ditujukan untuk subset perhitungan spreadsheet yang terdefinisi, bukan untuk kompatibilitas Excel penuh. Ingat batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang terdokumentasi ketika Anda memerlukan Aspose.Slides untuk menghitung ulang rumus.
- Hitung ulang setelah mengubah sel yang memengaruhi hasil rumus.
- Anggap nilai cache dari presentasi yang dimuat sebagai snapshot, bukan sebagai pengganti perhitungan ulang setelah penyuntingan.
- Uji rumus dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka menggunakan fungsi di luar daftar yang terdokumentasi.
- Untuk rumus yang memerlukan mesin perhitungan spreadsheet lengkap, hitunglah secara eksternal lalu perbarui workbook diagram dengan nilai hasilnya.

## **FAQ**

**What is the difference between [IChartDataCell.setFormula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) and [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) menyimpan ekspresi gaya A1 seperti `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling cocok dengan cara Anda membuat atau menyalin rumus.

**Do I need to read the cell itself or its value after calculation?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) mengembalikan sebuah [IChartDataCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/). Untuk memperoleh hasil yang dihitung, panggil metode [IChartDataCell.getValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#getValue--) pada sel tersebut setelah perhitungan ulang.

**When should I call [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Panggil [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) setelah mengubah nilai input atau rumus dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai rumus yang didukung oleh evaluator bawaan.

**Does Aspose.Slides support every Excel function?**

Tidak. Evaluator bawaan mendukung subset fungsi yang terdokumentasi. Fungsi di luar subset tersebut tidak boleh diasumsikan dapat dihitung ulang dengan benar. Jika kompatibilitas rumus Excel penuh diperlukan, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tulis nilai akhir ke workbook diagram.

**What happens if a loaded presentation contains an unsupported formula?**

Jika data diagram belum diubah, workbook mungkin masih berisi nilai cache yang telah dihitung sebelumnya. Setelah data terkait dimodifikasi, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang rumusnya tidak dapat ditangani dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Are formula error values the same as Java exceptions?**

Tidak. Nilai seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Pengecualian seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellcircularreferenceexception/) menunjukkan bahwa rumus tidak dapat diproses secara normal.

**Does a chart update automatically when a formula cell changes?**

Seri diagram dapat merujuk ke sel workbook. Hitung ulang workbook terlebih dahulu, lalu simpan atau render presentasi. Jika poin data diagram merujuk ke sel yang dihitung, diagram akan menggunakan nilai sel yang diperbarui; tidak diperlukan metode penyegaran diagram terpisah untuk alur kerja ini.

**Can charts use an external Excel workbook?**

Ya, data diagram dapat dikonfigurasi untuk menggunakan workbook eksternal melalui API data diagram. Namun, alur kerja perhitungan rumus yang dijelaskan dalam artikel ini berkaitan dengan workbook data diagram dan subset rumus yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) menyediakan perhitungan penuh untuk rumus apa pun dalam file XLSX eksternal.

**Can I use formulas that reference another worksheet or workbook?**

Referensi gaya Excel dapat muncul dalam workbook diagram, tetapi evaluasi rumus dibatasi oleh parser dan set fungsi yang didukung. Jika referensi lintas‑sheet atau eksternal penting, validasi rumus spesifik tersebut dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel luas, hitung workbook secara eksternal dan tulis nilai yang sudah diselesaikan kembali ke data diagram.

**Should formula strings start with `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa `=` di depan. Menggunakan bentuk ini menjaga konsistensi rumus yang dihasilkan dengan contoh API yang terdokumentasi.