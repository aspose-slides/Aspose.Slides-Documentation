---
title: Kelola Workbook Chart dalam Presentasi Menggunakan JavaScript
linktitle: Workbook Chart
type: docs
weight: 70
url: /id/nodejs-java/chart-workbook/
keywords:
- buku kerja grafik
- data grafik
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache grafik
- pemulihan buku kerja
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Node.js melalui Java: kelola workbook chart dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja chart di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data chart melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data chart, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai chart.

Artikel ini juga mencakup cara bekerja dengan buku kerja eksternal sebagai sumber data chart. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke chart, serta mengedit data chart ketika buku kerja tersedia.

## **Baca dan Tulis Data Chart dari Buku Kerja**

Aspose.Slides menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) dan [writeWorkbookStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) yang memungkinkan Anda membaca dan menulis buku kerja data chart (yang berisi data chart yang diedit dengan Aspose.Cells). **Catatan** bahwa data chart harus disusun dengan cara yang sama atau memiliki struktur yang mirip dengan sumbernya.

Kode JavaScript berikut mendemonstrasikan contoh operasi:
```javascript
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

## **Tetapkan Sel WorkBook sebagai DataLabel Chart**

1. Buat sebuah instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan chart Bubble dengan beberapa data.
4. Akses seri chart.
5. Tetapkan sel workbook sebagai label data.
6. Simpan presentasi.

Kode JavaScript berikut menunjukkan cara menetapkan sel workbook sebagai label data chart:
```javascript
// Membuat instance kelas presentasi yang mewakili file presentasi
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
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

Kode JavaScript berikut mendemonstrasikan operasi di mana metode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) digunakan untuk mengakses koleksi worksheet:
```javascript
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

## **Tentukan Jenis Sumber Data**

Kode JavaScript berikut menunjukkan cara menentukan jenis untuk sumber data:
```javascript
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

## **Deteksi Format Workbook Terembed yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook biner Excel (.xlsb) yang dapat tersemat dalam beberapa chart. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [ChartData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan chart tersebut.
```js
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

        // Baca atau ubah data workbook chart di sini.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook Eksternal**

Aspose.Slides mendukung workbook eksternal sebagai sumber data untuk chart.

### **Buat Workbook Eksternal**

Menggunakan metode **`readWorkbookStream`** dan **`setExternalWorkbook`**, Anda dapat membuat workbook eksternal dari awal atau menjadikan workbook internal menjadi eksternal.

Kode JavaScript berikut mendemonstrasikan proses pembuatan workbook eksternal:
```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tetapkan Workbook Eksternal**

Menggunakan metode **`setExternalWorkbook`**, Anda dapat menetapkan workbook eksternal ke sebuah chart sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam workbook yang disimpan di lokasi atau sumber daya jarak jauh, Anda masih dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal diberikan, jalur tersebut akan otomatis diubah menjadi jalur penuh.

Kode JavaScript berikut menunjukkan cara menetapkan workbook eksternal:
```javascript
// Membuat instance kelas Presentation
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

Parameter `ChartData` (di bawah metode `setExternalWorkbook`) digunakan untuk menentukan apakah workbook Excel akan dimuat atau tidak.

* When nilai `ChartData` diatur ke `false`, hanya jalur workbook yang diperbarui—data chart tidak akan dimuat atau diperbarui dari workbook target. Anda mungkin ingin menggunakan pengaturan ini ketika workbook target tidak ada atau tidak dapat diakses. 
* When nilai `ChartData` diatur ke `true`, data chart akan diperbarui dari workbook target.
```javascript
// Membuat instance kelas Presentation
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

### **Dapatkan Jalur Workbook Sumber Data Eksternal Chart**

1. Buat sebuah instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Buat objek untuk bentuk chart.
4. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data chart.
5. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data workbook eksternal.

Kode JavaScript berikut mendemonstrasikan operasi tersebut:
```javascript
// Membuat instance kelas Presentation
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

### **Edit Data Chart**

Anda dapat mengedit data dalam workbook eksternal dengan cara yang sama seperti mengubah isi workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode JavaScript berikut merupakan implementasi dari proses yang dijelaskan:
```javascript
// Membuat instance kelas Presentation
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

### **Pulihkan Workbook dari Cache Chart**

Jika sebuah chart menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali workbook chart dari data yang di-cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/), konfigurasikan dengan [SpreadsheetOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/spreadsheetoptions/), dan panggil [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) dengan `true` sebelum membuka presentasi.

Contoh JavaScript berikut membuka sebuah presentasi yang chart‑nya merujuk ke workbook eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):
```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Baca atau ubah data workbook yang dipulihkan di sini.
} finally {
    presentation.dispose();
}
```

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data chart yang di‑cache merupakan alternatif yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada workbook eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah chart tertentu terhubung ke workbook eksternal atau terembed?**

Ya. Sebuah chart memiliki [jenis sumber data](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) dan [jalur ke workbook eksternal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis diubah menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perlu diingat bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Apakah saya dapat menggunakan workbook yang terletak di sumber daya/berbagi jaringan?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit workbook jarak jauh secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan sebuah [tautan ke file eksternal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi password?**

Aspose.Slides tidak menerima password saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang sudah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/nodejs-java/)) dan menautkan ke salinan tersebut.

**Apakah beberapa chart dapat merujuk ke workbook eksternal yang sama?**

Ya. Setiap chart menyimpan tautannya masing‑masing. Jika semuanya mengarah ke file yang sama, memperbarui file tersebut akan tercermin di setiap chart pada kali berikutnya data dimuat.