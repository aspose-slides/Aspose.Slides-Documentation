---
title: Kustomisasi Sumbu Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Sumbu Diagram
type: docs
url: /id/nodejs-java/chart-axis/
keywords:
- sumbu diagram
- sumbu vertikal
- sumbu horizontal
- sesuaikan sumbu
- manipulasi sumbu
- kelola sumbu
- properti sumbu
- nilai maksimum
- nilai minimum
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan cara menggunakan JavaScript dengan Aspose.Slides untuk Node.js via Java untuk menyesuaikan sumbu diagram dalam presentasi PowerPoint untuk laporan dan visualisasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram di Aspose.Slides. Artikel ini menunjukkan cara mendapatkan nilai sumbu yang sebenarnya, menukar data antar sumbu, menyembunyikan sumbu vertikal atau horizontal untuk diagram garis, mengubah tipe sumbu kategori, mengatur format tanggal untuk nilai sumbu kategori, memutar judul sumbu, mengatur posisi sumbu, dan menampilkan label satuan pada sumbu nilai.

## **Mendapatkan Nilai Maksimum pada Sumbu Vertikal pada Diagram**

Aspose.Slides for Node.js via Java memungkinkan Anda memperoleh nilai minimum dan maksimum pada sumbu vertikal. Ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Dapatkan nilai maksimum aktual pada sumbu.
5. Dapatkan nilai minimum aktual pada sumbu.
6. Dapatkan unit mayor aktual dari sumbu.
7. Dapatkan unit minor aktual dari sumbu.
8. Dapatkan skala unit mayor aktual dari sumbu.
9. Dapatkan skala unit minor aktual dari sumbu.

Kode contoh ini—implementasi dari langkah-langkah di atas—menunjukkan cara mendapatkan nilai yang diperlukan dalam JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Menyimpan presentasi
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menukar Data antar Sumbu**

Aspose.Slides memungkinkan Anda dengan cepat menukar data antar sumbu—data yang ditampilkan pada sumbu vertikal (y-axis) dipindahkan ke sumbu horizontal (x-axis) dan sebaliknya.

Kode JavaScript ini menunjukkan cara melakukan tugas penukaran data antar sumbu pada diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Menukar baris dan kolom
    chart.getChartData().switchRowColumn();
    // Menyimpan presentasi
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menonaktifkan Sumbu Vertikal untuk Diagram Garis**

Kode JavaScript ini menunjukkan cara menyembunyikan sumbu vertikal untuk diagram garis:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menonaktifkan Sumbu Horizontal untuk Diagram Garis**

Kode ini menunjukkan cara menyembunyikan sumbu horizontal untuk diagram garis:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengubah Sumbu Kategori**

Dengan menggunakan properti **CategoryAxisType**, Anda dapat menentukan tipe sumbu kategori yang diinginkan (**date** atau **text**). Kode ini dalam JavaScript mendemonstrasikan operasi tersebut:

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Mengatur Format Tanggal untuk Nilai Sumbu Kategori**

Aspose.Slides for Node.js via Java memungkinkan Anda mengatur format tanggal untuk nilai sumbu kategori. Operasi ini ditunjukkan dalam kode JavaScript berikut:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **Mengatur Sudut Rotasi untuk Judul Sumbu Diagram**

Aspose.Slides for Node.js via Java memungkinkan Anda mengatur sudut rotasi untuk judul sumbu diagram. Kode JavaScript ini mendemonstrasikan operasi tersebut:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengatur Posisi Sumbu pada Sumbu Kategori atau Nilai**

Aspose.Slides for Node.js via Java memungkinkan Anda mengatur posisi sumbu pada sumbu kategori atau nilai. Kode JavaScript ini menunjukkan cara melakukan tugas tersebut:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengaktifkan Label Unit Tampilan pada Sumbu Nilai Diagram**

Aspose.Slides for Node.js via Java memungkinkan Anda mengonfigurasi diagram agar menampilkan label unit pada sumbu nilai diagramnya. Kode JavaScript ini mendemonstrasikan operasi tersebut:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Bagaimana cara saya mengatur nilai di mana satu sumbu melewati yang lain (penyilangan sumbu)?**

Sumbu menyediakan [pengaturan penyilangan](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/axis/setcrosstype/): Anda dapat memilih untuk menyilangkan pada nol, pada kategori/nilai maksimum, atau pada nilai numerik tertentu. Ini berguna untuk menggeser sumbu X ke atas atau ke bawah atau untuk menekankan garis dasar.

**Bagaimana saya dapat memposisikan label tick relatif terhadap sumbu (di samping, di luar, di dalam)?**

Atur [posisi label](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/axis/setmajortickmark/) menjadi "cross", "outside", atau "inside". Ini memengaruhi keterbacaan dan membantu menghemat ruang, terutama pada diagram kecil.