---
title: Kelola Buku Kerja Diagram dalam Presentasi Menggunakan JavaScript
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
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Node.js via Java: kelola buku kerja diagram dengan mudah di format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga membahas kerja dengan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke sebuah diagram, serta mengedit data diagram ketika buku kerja tersedia.

## **Membaca dan Menulis Data Diagram dari Buku Kerja**

Aspose.Slides menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) dan [writeWorkbookStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumber.

Kode JavaScript berikut menunjukkan contoh operasi:

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

## **Menetapkan Sel WorkBook sebagai Label Data Diagram**

1. Buat instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram Bubble dengan beberapa data.
4. Akses seri diagram.
5. Tetapkan sel buku kerja sebagai label data.
6. Simpan presentasi.

Kode JavaScript berikut menunjukkan cara menetapkan sel buku kerja sebagai label data diagram:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Membuat instance kelas presentasi yang mewakili file presentasi
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

## **Mengelola Worksheet**

Kode JavaScript berikut menunjukkan operasi di mana metode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) digunakan untuk mengakses koleksi worksheet:

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

## **Menentukan Tipe Sumber Data**

Kode JavaScript berikut menunjukkan cara menentukan tipe untuk sumber data:

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

## **Mendeteksi Format Buku Kerja Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat tersemat di beberapa diagram. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [ChartData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewati diagram tersebut.

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
            // Buku kerja tersemat berada dalam format .xlsb, yang tidak didukung.
            continue;
        }

        // Baca atau ubah data buku kerja diagram di sini.
    }
} finally {
    presentation.dispose();
}
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung buku kerja eksternal sebagai sumber data untuk diagram.

### **Membuat Buku Kerja Eksternal**

Dengan menggunakan metode **`readWorkbookStream`** dan **`setExternalWorkbook`**, Anda dapat membuat buku kerja eksternal dari awal atau mengubah buku kerja internal menjadi eksternal.

Kode JavaScript berikut menunjukkan proses pembuatan buku kerja eksternal:

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

### **Menetapkan Buku Kerja Eksternal**

Dengan menggunakan metode **`setExternalWorkbook`**, Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya jarak jauh, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut secara otomatis dikonversi menjadi jalur lengkap.

Kode JavaScript berikut menunjukkan cara menetapkan buku kerja eksternal:

```javascript
// Membuat instance dari kelas Presentation
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

Parameter `ChartData` (di bawah metode `setExternalWorkbook`) digunakan untuk menentukan apakah buku kerja Excel akan dimuat atau tidak.

* Ketika nilai `ChartData` diatur ke `false`, hanya jalur buku kerja yang diperbarui — data diagram tidak akan dimuat atau diperbarui dari buku kerja target. Anda mungkin ingin menggunakan pengaturan ini ketika buku kerja target tidak ada atau tidak tersedia.  
* Ketika nilai `ChartData` diatur ke `true`, data diagram diperbarui dari buku kerja target.

```javascript
// Membuat instance dari kelas Presentation
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

### **Mendapatkan Jalur Buku Kerja Sumber Data Eksternal Diagram**

1. Buat instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Buat objek untuk bentuk diagram.
4. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data diagram.
5. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data buku kerja eksternal.

Kode JavaScript berikut menunjukkan operasi tersebut:

```javascript
// Membuat instance dari kelas Presentation
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

### **Mengedit Data Diagram**

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode JavaScript berikut merupakan implementasi proses yang dijelaskan:

```javascript
// Membuat instance dari kelas Presentation
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

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram tertentu terhubung ke buku kerja eksternal atau tersemat?**  
Ya. Sebuah diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana cara penyimpanannya?**  
Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perlu diingat bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Apakah saya dapat menggunakan buku kerja yang berada di sumber daya/jaringan bersama?**  
Ya, buku kerja semacam itu dapat digunakan sebagai sumber data eksternal. Namun, mengedit buku kerja jarak jauh secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**  
Tidak. Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi password?**  
Aspose.Slides tidak menerima password saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/nodejs-java/)) dan menautkan ke salinan tersebut.

**Apakah beberapa diagram dapat merujuk ke buku kerja eksternal yang sama?**  
Ya. Setiap diagram menyimpan tautannya masing-masing. Jika semuanya mengarah ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada saat data dimuat kembali.