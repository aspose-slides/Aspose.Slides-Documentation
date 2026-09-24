---
title: Kelola Workbook Grafik dalam Presentasi Menggunakan JavaScript
linktitle: Workbook Grafik
type: docs
weight: 70
url: /id/nodejs-java/chart-workbook/
keywords:
- workbook grafik
- data grafik
- sel workbook
- label data
- lembar kerja
- sumber data
- workbook eksternal
- data eksternal
- cache grafik
- pemulihan workbook
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Node.js melalui Java: kelola workbook grafik dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan workbook grafik di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data grafik melalui stream workbook, menggunakan sel workbook sebagai label data grafik, mengakses koleksi worksheet, dan menentukan tipe sumber data untuk nilai grafik.

Artikel ini juga mencakup cara bekerja dengan workbook eksternal sebagai sumber data grafik. Contoh-contoh menunjukkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke grafik, serta mengedit data grafik ketika workbook tersedia.

Untuk sel workbook yang mewakili data yang hilang, lihat [Control the Display of Empty Cells](/slides/id/nodejs-java/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Baca dan Tulis Data Grafik dari Workbook**

Aspose.Slides menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) dan [writeWorkbookStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) yang memungkinkan Anda membaca dan menulis workbook data grafik (yang berisi data grafik yang diedit dengan Aspose.Cells). **Catatan** bahwa data grafik harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumber.

Kode JavaScript ini menunjukkan operasi contoh:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Validasi Tata Letak Grafik Setelah Modifikasi Workbook**

Ketika Anda mengganti workbook tersemat dengan yang telah dimodifikasi, grafik tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart.validateChartLayout](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Chart#validateChartLayout--) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis workbook yang diperbarui kembali ke grafik.

```javascript
// Setelah memodifikasi stream workbook (misalnya, menggunakan Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Hapus referensi data yang ada.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Menghapus koleksi memastikan bahwa struktur data grafik konsisten dengan workbook baru, sehingga `validateChartLayout` dapat selesai tanpa kesalahan.

## **Set Sel Workbook sebagai DataLabel Grafik**

1. Buat instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan diagram Bubble dengan beberapa data.
1. Akses seri grafik.
1. Tetapkan sel workbook sebagai label data.
1. Simpan presentasi.

Kode JavaScript ini menunjukkan cara menetapkan sel workbook sebagai label data grafik:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Menginstansiasi kelas presentasi yang mewakili file presentasi
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kelola Worksheet**

Kode JavaScript ini menunjukkan operasi dimana metode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) digunakan untuk mengakses koleksi worksheet:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tentukan Tipe Sumber Data**

Kode JavaScript ini menunjukkan cara menentukan tipe untuk sumber data:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Deteksi Format Workbook Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook biner Excel (.xlsb) yang dapat tersemat dalam beberapa grafik. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [ChartData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewati grafik tersebut.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // Workbook tersemat berada dalam format .xlsb, yang tidak didukung.
            continue;
        }

        // Baca atau modifikasi data workbook grafik di sini.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook Eksternal**

Aspose.Slides mendukung workbook eksternal sebagai sumber data untuk grafik.

### **Buat Workbook Eksternal**

Dengan menggunakan metode **`readWorkbookStream`** dan **`setExternalWorkbook`**, Anda dapat membuat workbook eksternal dari awal atau menjadikan workbook internal menjadi eksternal.

Kode JavaScript ini menunjukkan proses pembuatan workbook eksternal:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream mengembalikan byte workbook sebagai Node Buffer.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Set Workbook Eksternal**

Dengan menggunakan metode **`setExternalWorkbook`**, Anda dapat menetapkan workbook eksternal ke grafik sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam workbook yang disimpan di lokasi remote atau sumber daya, Anda tetap dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal diberikan, jalur tersebut akan otomatis dikonversi menjadi jalur lengkap.

Kode JavaScript ini menunjukkan cara menetapkan workbook eksternal:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Parameter kedua dari metode `setExternalWorkbook`, `updateChartData`, menentukan apakah workbook Excel akan dimuat atau tidak.

* Ketika `updateChartData` diatur ke `false`, hanya jalur workbook yang diperbarui—data grafik tidak akan dimuat atau diperbarui dari workbook target. Anda mungkin ingin menggunakan pengaturan ini ketika workbook target tidak ada atau tidak tersedia.
* Ketika `updateChartData` diatur ke `true`, data grafik diperbarui dari workbook target.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Dapatkan Jalur Workbook Sumber Data Eksternal Grafik**

1. Buat instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Buat objek untuk shape grafik.
1. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data grafik.
1. Tentukan kondisi relevan berdasarkan tipe sumber yang sama dengan tipe sumber data workbook eksternal.

Kode JavaScript ini menunjukkan operasi tersebut:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Menyimpan presentasi
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Edit Data Grafik**

Anda dapat mengedit data dalam workbook eksternal dengan cara yang sama seperti mengubah isi workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode JavaScript ini merupakan implementasi proses yang dijelaskan:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Pulihkan Workbook dari Cache Grafik**

Jika sebuah grafik menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi workbook grafik dari data yang di-cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/), konfigurasikan dengan [SpreadsheetOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/spreadsheetoptions/), dan panggil [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) dengan `true` sebelum membuka presentasi.

Contoh JavaScript berikut membuka presentasi yang grafiknya merujuk ke workbook eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Baca atau modifikasi data workbook yang dipulihkan di sini.
} finally {
    presentation.dispose();
}
```

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data grafik yang di-cache merupakan fallback yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada workbook eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah grafik tertentu terhubung ke workbook eksternal atau tersemat?**

Ya. Grafik memiliki [tipe sumber data](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) dan [jalur ke workbook eksternal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perlu diketahui bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Bisakah saya menggunakan workbook yang berada di sumber daya atau share jaringan?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit workbook remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Bagaimana jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat membuat tautan. Pendekatan umum adalah menghapus proteksi terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya dengan menggunakan [Aspose.Cells](/cells/nodejs-java/)) dan menautkan ke salinan tersebut.

**Apakah beberapa grafik dapat merujuk ke workbook eksternal yang sama?**

Ya. Setiap grafik menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap grafik saat data dimuat kembali.