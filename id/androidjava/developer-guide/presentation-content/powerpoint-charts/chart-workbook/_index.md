---
title: Kelola Buku Kerja Diagram dalam Presentasi di Android
linktitle: Buku Kerja Diagram
type: docs
weight: 70
url: /id/androidjava/chart-workbook/
keywords:
- buku kerja diagram
- data diagram
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache diagram
- pemulihan buku kerja
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Android via Java: kelola buku kerja diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga mencakup cara bekerja dengan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke diagram, dan menyunting data diagram ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Kontrol Tampilan Sel Kosong](/slides/id/androidjava/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) untuk mengontrol apakah diagram memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemplotan diagram; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

Unduh [hidden-source-data.pptx](hidden-source-data.pptx) dan letakkan di direktori kerja. Slide pertamanya berisi diagram kolom sebagai bentuk pertama. Lembar kerja tersemat, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi sel‑selnya tetap berisi nilai.

| Baris Lembar Kerja | A: Bulan | B: Ritel | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) dan baca [IChartDataCell.isHidden](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) untuk memeriksa status tersembunyi mereka. Metode ini melaporkan status tersembunyi tanpa mengubahnya. Pada file ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `false`, `true`, dan `true` secara berurutan.

Untuk contoh ini, segarkan data diagram setelah mengubah pengaturan plot: pertahankan buku kerja tersemat dengan [readWorkbookStream](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) dan muat ulang dengan [writeWorkbookStream](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Saat menyertakan semua sel, juga gunakan [setRange](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) untuk memulihkan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data diagram yang di‑cache dan label kategori pada contoh ini.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Segarkan data diagram dari buku kerja yang tersemat.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Pulihkan rentang sumber lengkap, termasuk kategori tersembunyi.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Contoh menyimpan `hidden_cells_true.pptx` hanya dengan nilai Ritel yang terlihat (10 dan 20), dan `hidden_cells_false.pptx` dengan semua enam nilai. Gambar di bawah mengilustrasikan dua mode plot. Baris 3 dan kolom C tetap tersembunyi di kedua buku kerja tersemat.

| Hanya sel yang terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Hanya sel yang terlihat: nilai Ritel 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Ritel dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sebuah sel tersembunyi yang berisi nilai berbeda dari sel kosong. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber yang tersembunyi. Lihat [Kontrol Tampilan Sel Kosong](/slides/id/androidjava/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Baca dan Tulis Data Diagram dari Buku Kerja**

Aspose.Slides for Android via Java menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) dan [writeWorkbookStream](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumbernya.

Contoh ini membuka `chart.pptx`, yang harus berisi diagram sebagai bentuk pertama pada slide pertama. Ia membaca buku kerja tersemat ke dalam array byte, mengosongkan seri dan kategori yang ada, dan menulis kembali buku kerja yang sama. Perubahan tetap berada di memori; contoh tidak menyimpan presentasi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Validasi Tata Letak Diagram Setelah Modifikasi Buku Kerja**

Saat Anda mengganti buku kerja tersemat dengan yang dimodifikasi, diagram mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [IChart.validateChartLayout](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/#validateChartLayout--) gagal dengan kesalahan indeks di luar jangkauan. Kosongkan seri dan kategori yang ada sebelum menulis buku kerja yang diperbarui kembali ke diagram. Contoh ini memerlukan `chart.pptx` dengan diagram sebagai bentuk pertama pada slide pertama. Komentar menandai tempat pengeditan buku kerja akan terjadi; contoh yang dapat dijalankan menulis kembali buku kerja asli dan memvalidasi tata letak di memori.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Ubah byte buku kerja di sini, misalnya, menggunakan Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Mengosongkan koleksi menghapus referensi data usang sebelum buku kerja ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan diagram.

## **Atur Sel Buku Kerja sebagai Label Data Diagram**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data diagram. Langkah‑langkah berikut menunjukkan cara menautkan label pada diagram gelembung ke sel dalam buku kerja datanya.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) .
2. Akses slide pertama berdasarkan indeks berbasis nol.
3. Tambahkan diagram gelembung dengan data default.
4. Akses seri diagram.
5. Atur sel buku kerja sebagai label data.
6. Simpan presentasi.

Contoh ini membuka `chart2.pptx`, yang harus berisi setidaknya satu slide, dan menambahkan diagram gelembung dengan data default. Ia menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama pada seri pertama, mengaktifkan label dari sel, dan menyimpan hasil ke `resultchart.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kelola Lembar Kerja**

Metode [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) memberikan akses ke lembar kerja dalam buku kerja diagram. Contoh ini membuat diagram pai dengan data default dan mencetak setiap nama lembar kerja ke konsol.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Tentukan Tipe Sumber Data**

Contoh ini membuat diagram kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; yang kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/datasourcetype/) memilih sumber untuk setiap nama. Hasil disimpan ke `pres.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Deteksi Format Buku Kerja Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja Excel biner (.xlsb) yang dapat tersemat dalam beberapa diagram. Anda dapat menggunakan metode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) pada [IChartData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram‑diagram tersebut. Contoh ini memeriksa bentuk‑bentuk pada slide pertama `sample.pptx`, melewatkan bentuk bukan diagram, dan mencetak pesan diagnostik untuk setiap diagram dengan buku kerja .xlsb tersemat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Baca atau ubah data buku kerja diagram yang didukung di sini.
    }
} finally {
    presentation.dispose();
}
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk diagram.

### **Buat Buku Kerja Eksternal**

Gunakan [readWorkbookStream](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) dan [setExternalWorkbook](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) untuk mengekspor buku kerja diagram tersemat ke file dan menautkan diagram ke buku kerja eksternal tersebut.

Contoh ini membuat diagram pai dengan data default, menulis buku kerja ke `externalWorkbook1.xlsx`, dan menyelesaikan penulisan file sebelum menetapkan file sebagai sumber data diagram. Ia menyimpan presentasi yang ditautkan ke `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Tetapkan Buku Kerja Eksternal**

Dengan menggunakan metode [setExternalWorkbook](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat menyunting data dalam buku kerja yang disimpan di lokasi atau sumber daya jarak jauh, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal disediakan, ia akan secara otomatis dikonversi menjadi jalur penuh.

Contoh ini memerlukan `externalWorkbook.xlsx` di direktori kerja. Lembar kerja bernama `Sheet1` harus berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh ini membuat diagram pai, menautkan buku kerja, dan menggunakan [setRange](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Ia menyimpan hasil ke `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Parameter `updateChartData` pada [setExternalWorkbook](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) mengontrol apakah buku kerja dimuat.

* Ketika `updateChartData` bernilai `false`, hanya jalur buku kerja yang diperbarui. Data diagram tidak dimuat atau diperbarui dari buku kerja target, sehingga buku kerja dapat tidak tersedia.
* Ketika `updateChartData` bernilai `true`, data diagram diperbarui dari buku kerja target.

Contoh berikut menetapkan URL placeholder dengan `updateChartData` diset ke `false`. Ia mempertahankan data default diagram pai dan menyimpan presentasi tanpa memuat buku kerja yang tidak tersedia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal dari Diagram**

Untuk mengidentifikasi buku kerja yang ditautkan ke sebuah diagram, pertama periksa apakah diagram menggunakan sumber data eksternal. Jika ya, Anda dapat mengambil jalur buku kerja dengan mengikuti langkah‑langkah berikut.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) .
2. Akses slide pertama berdasarkan indeks berbasis nol.
3. Pastikan bentuk pertama adalah diagram.
4. Baca tipe sumber data diagram.
5. Jika sumbernya adalah buku kerja eksternal, baca jalurnya.

Contoh ini membuka `externalWorkbook.pptx`, yang dibuat pada contoh sebelumnya, dan memeriksa bentuk pertama pada slide pertama. Jika itu adalah diagram yang ditautkan ke buku kerja eksternal, contoh mencetak [getExternalWorkbookPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ke konsol. Kemudian ia menyimpan salinan presentasi ke `Result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sunting Data Diagram**

Anda dapat menyunting data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Contoh ini memerlukan `presentation.pptx` dengan diagram sebagai bentuk pertama pada slide pertama serta buku kerja eksternal yang dapat diakses. Ia menetapkan nilai berbasis sel dari titik data pertama pada seri pertama menjadi 100 dan menyimpan presentasi ke `presentation_out.pptx`. Menyunting nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu menjaga buku kerja asli tetap utuh.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Pulihkan Buku Kerja dari Cache Diagram**

Jika sebuah diagram menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi buku kerja diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/), panggil [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), dan setel [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) ke `true` sebelum membuka presentasi.

Contoh Java berikut membuka `presentation.pptx`, yang bentuk pertamanya pada slide pertama harus berupa diagram yang merujuk ke buku kerja eksternal yang tidak tersedia, dan mengakses data yang dipulihkan melalui [IChart.getChartData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/#getChartData--) dan [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Baca atau ubah data buku kerja yang dipulihkan di sini.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika menggunakan data diagram yang di‑cache merupakan alternatif yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir kali diperbarui.

## **Tanya Jawab**

**Apakah saya dapat menentukan apakah diagram tertentu terhubung ke buku kerja eksternal atau tersemat?**

Ya. Diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkapnya untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, secara otomatis akan dikonversi menjadi jalur absolut. Presentasi menyimpan jalur absolut dalam file PPTX, jadi memindahkan buku kerja mungkin memerlukan pembaruan tautan.

**Dapatkah saya menggunakan buku kerja yang berada pada sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan langsung buku kerja jarak jauh melalui Aspose.Slides tidak didukung—buku kerja tersebut hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Menyunting data diagram berbasis sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan buku kerja jika yang asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan sebelumnya atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/java/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa diagram merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semua diagram menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada kali berikutnya data dimuat.