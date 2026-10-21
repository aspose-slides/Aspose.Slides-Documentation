---
title: Mengelola Buku Kerja Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Buku Kerja Diagram
type: docs
weight: 70
url: /id/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Node.js via Java: kelola buku kerja diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai diagram.

Selain itu, artikel ini membahas penggunaan buku kerja eksternal sebagai sumber data diagram. Contoh‑contohnya mendemonstrasikan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke diagram, serta mengedit data diagram ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Kontrol Tampilan Sel Kosong](/slides/id/nodejs-java/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) untuk mengontrol apakah diagram memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat maupun tersembunyi. Pengaturan ini mengontrol pemetaan diagram; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

[Presentasi contoh](hidden-source-data.pptx) berisi diagram kolom sebagai bentuk pertama pada slide pertama. Lembar kerja tersemat, `Sheet1`, memiliki rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi sel‑selnya masih berisi nilai.

| Baris Lembar Kerja | A: Bulan | B: Eceran | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) dan baca [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) untuk memeriksa status tersembunyi mereka. Metode ini melaporkan status tersembunyi tanpa mengubahnya. Dalam contoh ini, B2 terlihat, B3 berada pada baris tersembunyi, dan C2 berada pada kolom tersembunyi; contoh mencetak `false`, `true`, dan `true` secara berurutan.

Untuk contoh ini, segarkan data diagram setelah mengubah pengaturan pemetaan: simpan buku kerja tersemat dengan [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) dan muat kembali dengan [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). Saat menyertakan semua sel, gunakan juga [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) untuk memulihkan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data diagram dan label kategori yang di‑cache dalam contoh ini. Contoh mengubah buffer Node.js menjadi array byte Java sebelum melewatkannya ke metode penulisan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Segarkan data diagram dari buku kerja yang tersemat.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Pulihkan rentang sumber lengkap, termasuk kategori tersembunyi.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Contoh menyimpan dua versi presentasi: satu dengan hanya nilai Eceran yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah mengilustrasikan dua mode pemetaan. Baris 3 dan kolom C tetap tersembunyi di kedua buku kerja tersemat.

| Hanya sel terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Hanya sel terlihat: nilai Eceran 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Eceran dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dari sel kosong. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber yang tersembunyi. Lihat [Kontrol Tampilan Sel Kosong](/slides/id/nodejs-java/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Mendapatkan Rentang Data Diagram**

Sebelum memperbarui data buku kerja dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel lembar kerja mana yang digunakan setiap diagram. Metode [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) mengembalikan rentang data saat ini sebagai formula yang memenuhi lembar kerja, misalnya `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama lembar kerja, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` mengidentifikasi sel A1 sampai D5, inklusif. Tanda dolar menunjukkan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah diagram atau buku kerjanya. Jika diagram tidak menggunakan buku kerja sebagai sumber data, ia melempar `InvalidOperationException`. Untuk informasi lebih lanjut, lihat [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Contoh ini membuka presentasi dan memeriksa bentuk‑bentuk langsung pada tiap slide untuk diagram. Ia mencetak nama tiap diagram dan rentang sumbernya. Jika sebuah diagram tidak menggunakan buku kerja, ia mencetak pesan dan melanjutkan ke diagram berikutnya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Membaca dan Menulis Data Diagram dari Buku Kerja**

Aspose.Slides for Node.js via Java menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) dan [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur serupa dengan sumbernya.

Contoh ini menggunakan presentasi dengan diagram sebagai bentuk pertama pada slide pertama. Ia membaca buku kerja tersemat ke dalam array byte, menghapus seri dan kategori yang ada, dan menulis kembali buku kerja yang sama. Perubahan tetap berada di memori; contoh tidak menyimpan presentasi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Validasi Tata Letak Diagram Setelah Modifikasi Buku Kerja**

Ketika Anda mengganti buku kerja tersemat dengan versi yang telah dimodifikasi, diagram mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis kembali buku kerja yang diperbarui ke diagram. Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat dimana penyuntingan buku kerja akan terjadi; contoh yang dapat dijalankan menulis kembali buku kerja asli dan memvalidasi tata letak di memori.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Modifikasi byte buku kerja di sini, misalnya, menggunakan Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Mengosongkan koleksi menghapus referensi data usang sebelum buku kerja ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan diagram.

## **Menetapkan Format Angka Kustom untuk Sel Buku Kerja**

Gunakan [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) untuk mengontrol bagaimana nilai numerik muncul dalam buku kerja tersemat diagram. Misalnya, sebuah laporan mungkin memerlukan tingkat konversi yang ditampilkan sebagai persentase dengan empat tempat desimal dan koefisien yang ditampilkan dengan lima tempat desimal. Pertahankan kedua nilai sebagai numerik agar tetap tersedia untuk perhitungan dan pemetaan diagram.

Format angka mengubah tampilan, bukan nilai yang disimpan. Format `0.0000%` menampilkan `0.125` sebagai `12.5000%`; tidak menggantikan angka yang disimpan dengan `12.5`. Demikian pula, `0.00000` menampilkan `0.1234567` sebagai `0.12346` tanpa membulatkan nilai yang disimpan. Jika format kustom adalah string kosong (`""`), format yang dikembalikan oleh [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) akan digunakan sebagai gantinya.

Contoh berikut membuat diagram kolom dan mengakses sel‑nya melalui [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). Pada lembar kerja 0, B2 berisi tingkat konversi dan C2 berisi koefisien. Kedua sel menyediakan nilai diagram. Contoh juga mengaktifkan label nilai yang ditautkan ke format sumber.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Format sel buku kerja terpisah dari format yang ditetapkan langsung pada sumbu diagram atau label data. Dalam contoh ini, setiap label menampilkan nilai sel sumbernya karena [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) diatur ke `true`, dan mengikuti format angka sumber karena [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) diatur ke `true`. Setelah menyimpan dan membuka kembali presentasi, label menampilkan `12.5000%` dan `0.12346`, seperti ditampilkan di bawah. Sumbu vertikal menggunakan format angka sendiri, yang ditetapkan dengan [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) sebagai `0.00`, dengan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) diatur ke `false`.

Untuk memformat label data secara independen, atur flag tautan‑sumbernya ke `false` dan tetapkan format dengan [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). Ini tidak mengubah format sel buku kerja. Misalnya, format label independen `0.00` menampilkan nilai pertama sebagai `0.13`, sementara B2 tetap menampilkan `12.5000%`. Lihat [Chart Data Labels](/slides/id/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) untuk pemformatan label langsung.

Gambar di bawah dihasilkan dari presentasi yang disimpan setelah dibuka kembali:

![Diagram kolom dengan label yang ditautkan ke sumber menampilkan 12.5000% dan 0.12346 serta sumbu numerik yang diformat secara independen.](custom-cell-formats.png)

## **Menetapkan Sel Buku Kerja sebagai Label Data Diagram**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data diagram.

Contoh ini menambahkan diagram gelembung dengan data default ke slide pertama dari presentasi yang ada. Ia menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama pada seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengelola Lembar Kerja**

Metode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) memberikan akses ke lembar kerja dalam buku kerja diagram. Contoh ini membuat diagram pai dengan data default dan mencetak setiap nama lembar kerja ke konsol.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Menentukan Jenis Sumber Data**

Contoh ini membuat diagram kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) memilih sumber untuk tiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mendeteksi Format Buku Kerja Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja Excel biner (.xlsb) yang dapat tersemat dalam beberapa diagram. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram‑diagram tersebut. Contoh ini memeriksa bentuk pada slide pertama dari presentasi yang ada, melewatkan bentuk non‑diagram, dan mencetak pesan diagnostik untuk tiap diagram dengan buku kerja .xlsb yang tersemat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
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

Gunakan [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) dan [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) untuk mengekspor buku kerja diagram tersemat ke file dan menautkan diagram ke buku kerja eksternal tersebut.

Contoh ini membuat diagram pai dengan data default dan mengekspor bukunya. Ia menyelesaikan penulisan file sebelum menetapkan buku kerja eksternal sebagai sumber data diagram, kemudian menyimpan presentasi yang ditautkan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Tetapkan Buku Kerja Eksternal**

Dengan menggunakan metode [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat menyunting data dalam buku kerja yang disimpan di lokasi remote atau sumber daya, Anda masih dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, ia secara otomatis dikonversi menjadi jalur lengkap.

Contoh ini menggunakan buku kerja eksternal yang lembar kerjanya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat diagram pai, menautkan buku kerja, dan menggunakan [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Ia menyimpan presentasi dengan diagram yang ditautkan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Parameter `updateChartData` pada metode [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) mengontrol apakah buku kerja dimuat.

* Ketika `updateChartData` bernilai `false`, hanya jalur buku kerja yang diperbarui. Data diagram tidak dimuat atau diperbarui dari buku kerja target, sehingga buku kerja dapat tidak tersedia.
* Ketika `updateChartData` bernilai `true`, data diagram diperbarui dari buku kerja target.

Contoh berikut menetapkan URL placeholder dengan `updateChartData` diatur ke `false`. Ia mempertahankan data default diagram pai dan menyimpan presentasi tanpa memuat buku kerja yang tidak tersedia.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal dari Diagram**

Untuk mengidentifikasi buku kerja yang ditautkan ke diagram, periksa apakah diagram menggunakan sumber data eksternal dan ambil jalur bukunya.

Contoh ini memeriksa bentuk pertama pada slide pertama dari presentasi dengan buku kerja eksternal yang ditautkan. Jika bentuk tersebut adalah diagram yang ditautkan ke buku kerja eksternal, contoh mencetak [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ke konsol. Kemudian ia menyimpan salinan presentasi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sunting Data Diagram**

Anda dapat menyunting data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama dan ditautkan ke buku kerja eksternal yang dapat diakses. Ia menetapkan nilai berbasis sel dari titik data pertama pada seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Menyunting nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu mempertahankan buku kerja asli.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Pulihkan Buku Kerja dari Cache Diagram**

Jika sebuah diagram menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi buku kerja diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), panggil [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/), dan atur [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) ke `true` sebelum membuka presentasi.

Contoh JavaScript berikut memulihkan data buku kerja untuk diagram yang merupakan bentuk pertama pada slide pertama dan merujuk ke buku kerja eksternal yang tidak tersedia. Ia mengakses data yang dipulihkan melalui [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) dan [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Baca atau ubah data workbook yang dipulihkan di sini.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data diagram yang di‑cache merupakan solusi yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **Tanya Jawab**

**Apakah saya dapat menentukan apakah diagram tertentu terhubung ke buku kerja eksternal atau tersemat?**

Ya. Diagram memiliki [jenis sumber data](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana mereka disimpan?**

Ya. Jika Anda menentukan jalur relatif, ia secara otomatis dikonversi menjadi jalur absolut. Presentasi menyimpan jalur absolut dalam file PPTX, sehingga memindahkan buku kerja mungkin memerlukan pembaruan tautan.

**Bisakah saya menggunakan buku kerja yang berada di sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan buku kerja remote langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Menyunting data diagram yang berbasis sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan buku kerja jika yang asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/java/)) dan menautkan ke salinan tersebut.

**Bisakah beberapa diagram merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semua diagram menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada saat data dimuat berikutnya.