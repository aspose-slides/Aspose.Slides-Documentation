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

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram dalam Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga membahas penggunaan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh memperlihatkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke diagram, serta mengedit data diagram ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Kontrol Tampilan Sel Kosong](/slides/id/androidjava/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) untuk mengontrol apakah diagram memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemetaan diagram; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

[sample presentation](hidden-source-data.pptx) berisi diagram kolom sebagai bentuk pertama pada slide pertama. Lembar kerja yang disematkan, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi sel‑selnya masih berisi nilai.

| Baris lembar kerja | A: Bulan | B: Ritel | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) dan baca [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) untuk memeriksa status tersembunyi mereka. Metode ini melaporkan status tersembunyi tanpa mengubahnya. Dalam file ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `false`, `true`, dan `true`, masing‑masing.

Untuk contoh ini, segarkan data diagram setelah mengubah pengaturan plot: pertahankan buku kerja yang disematkan dengan [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) dan muat kembali dengan [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Saat menyertakan semua sel, juga gunakan [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) untuk memulihkan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk memperbarui data diagram yang di‑cache pada contoh ini serta label kategori.

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

            // Segarkan data diagram dari buku kerja yang disematkan.
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

Contoh menyimpan dua versi presentasi: satu hanya dengan nilai Ritel yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah mengilustrasikan dua mode plot. Baris 3 dan kolom C tetap tersembunyi pada kedua buku kerja yang disematkan.

| Hanya sel terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Hanya sel terlihat: nilai Ritel 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Ritel dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sebuah sel tersembunyi yang berisi nilai berbeda dari sel kosong. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber tersembunyi. Lihat [Kontrol Tampilan Sel Kosong](/slides/id/androidjava/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Ambil Rentang Data Diagram**

Sebelum memperbarui data buku kerja dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel lembar kerja mana yang digunakan setiap diagram. Metode [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) mengembalikan rentang data saat ini sebagai formula yang memenuhi kualifikasi lembar kerja, seperti `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama lembar kerja, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` mengidentifikasi sel A1 sampai D5, inklusif. Tanda dolar menunjukkan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah diagram atau buku kerjanya. Jika diagram tidak menggunakan buku kerja sebagai sumber datanya, metode ini akan melempar `InvalidOperationException`. Untuk info lebih lanjut, lihat [Referensi API ChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Contoh ini membuka presentasi dan memeriksa bentuk‑bentuk langsung pada setiap slide untuk diagram. Ia mencetak nama setiap diagram dan rentang sumbernya. Jika sebuah diagram tidak menggunakan buku kerja, ia mencetak pesan dan melanjutkan ke diagram berikutnya.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Baca dan Tulis Data Diagram dari Buku Kerja**

Aspose.Slides untuk Android via Java menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) dan [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur serupa dengan sumbernya.

Contoh ini menggunakan presentasi dengan diagram sebagai bentuk pertama pada slide pertama. Ia membaca buku kerja yang disematkan ke dalam array byte, menghapus seri dan kategori yang ada, dan menulis kembali buku kerja yang sama. Perubahan tetap ada dalam memori; contoh ini tidak menyimpan presentasi.

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

Saat Anda mengganti buku kerja yang disematkan dengan yang telah dimodifikasi, diagram mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis kembali buku kerja yang diperbarui ke diagram. Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat penyuntingan buku kerja akan terjadi; contoh yang dapat dijalankan menulis kembali buku kerja asli dan memvalidasi tata letak dalam memori.

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

        // Modifikasi byte workbook di sini, misalnya, menggunakan Aspose.Cells.

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

Menghapus koleksi menghilangkan referensi data usang sebelum buku kerja ditulis kembali. Bangun kembali seri dan pemetaan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan diagram.

## **Atur Sel Buku Kerja sebagai Label Data Diagram**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data diagram.

Contoh ini menambahkan diagram gelembung dengan data default ke slide pertama dari presentasi yang ada. Ia menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama dalam seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

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

Metode [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) menyediakan akses ke lembar kerja dalam buku kerja diagram. Contoh ini membuat diagram pai dengan data default dan mencetak setiap nama lembar kerja ke konsol.

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

Contoh ini membuat diagram kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) memilih sumber untuk setiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

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

## **Deteksi Format Buku Kerja yang Disematkan Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat disematkan dalam beberapa diagram. Anda dapat menggunakan metode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) pada [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram‑diagram tersebut. Contoh ini memeriksa bentuk‑bentuk pada slide pertama dari presentasi yang ada, melewatkan bentuk yang bukan diagram, dan mencetak pesan diagnostik untuk setiap diagram dengan buku kerja .xlsb yang disematkan.

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

        // Baca atau modifikasi data buku kerja diagram yang didukung di sini.
    }
} finally {
    presentation.dispose();
}
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk diagram.

### **Buat Buku Kerja Eksternal**

Gunakan [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) dan [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) untuk mengekspor buku kerja diagram yang disematkan ke file dan menautkan diagram ke buku kerja eksternal tersebut.

Contoh ini membuat diagram pai dengan data default dan mengekspor buku kerjanya. Ia menyelesaikan penulisan file sebelum menetapkan buku kerja eksternal sebagai sumber data diagram, lalu menyimpan presentasi yang ditautkan.

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

Dengan metode [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja dipindahkan).

Meskipun Anda tidak dapat menyunting data dalam buku kerja yang disimpan di lokasi atau sumber daya remote, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut secara otomatis dikonversi ke jalur lengkap.

Contoh ini menggunakan buku kerja eksternal yang lembar kerjanya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat diagram pai, menautkan buku kerja, dan menggunakan [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Ia menyimpan presentasi dengan diagram yang ditautkan.

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

Parameter `updateChartData` pada metode [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) mengontrol apakah buku kerja dimuat.

* Saat `updateChartData` `false`, hanya jalur buku kerja yang diperbarui. Data diagram tidak dimuat atau diperbarui dari buku kerja target, sehingga buku kerja dapat tidak tersedia.
* Saat `updateChartData` `true`, data diagram diperbarui dari buku kerja target.

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

Untuk mengidentifikasi buku kerja yang ditautkan ke diagram, periksa apakah diagram menggunakan sumber data eksternal dan ambil jalur buku kerja tersebut.

Contoh ini memeriksa bentuk pertama pada slide pertama dari presentasi dengan buku kerja eksternal yang ditautkan. Jika itu diagram yang ditautkan ke buku kerja eksternal, contoh mencetak [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ke konsol. Kemudian ia menyimpan salinan presentasi.

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

Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama dan ditautkan ke buku kerja eksternal yang dapat diakses. Ia menetapkan nilai berbasis sel untuk titik data pertama dalam seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Menyunting nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan bila Anda perlu mempertahankan buku kerja asli.

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

Jika sebuah diagram menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi buku kerja diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), panggil [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), dan setel [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) ke `true` sebelum membuka presentasi.

Contoh Java berikut memulihkan data buku kerja untuk diagram yang merupakan bentuk pertama pada slide pertama dan merujuk ke buku kerja eksternal yang tidak tersedia. Ia mengakses data yang dipulihkan melalui [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) dan [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Baca atau modifikasi data buku kerja yang dipulihkan di sini.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data diagram yang di‑cache merupakan fallback yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram tertentu terhubung ke buku kerja eksternal atau yang disematkan?**

Ya. Diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana mereka disimpan?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Presentasi menyimpan jalur absolut dalam file PPTX, sehingga memindahkan buku kerja mungkin memerlukan pembaruan tautan.

**Bisakah saya menggunakan buku kerja yang terletak pada sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan buku kerja remote langsung dari Aspose.Slides tidak didukung—hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Menyunting data diagram berbasis sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan buku kerja bila yang asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi sandi?**

Aspose.Slides tidak menerima sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan sebelumnya atau menyiapkan salinan yang didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/java/)) dan menautkan ke salinan tersebut.

**Bisakah beberapa diagram merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram saat data dimuat kembali.