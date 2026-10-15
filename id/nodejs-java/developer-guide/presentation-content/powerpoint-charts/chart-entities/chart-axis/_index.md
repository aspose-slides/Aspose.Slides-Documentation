---
title: Sesuaikan Sumbu Diagram dalam Presentasi Menggunakan JavaScript
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

Artikel ini menjelaskan cara menyesuaikan sumbu diagram dengan Aspose.Slides untuk Node.js via Java. Artikel ini mencakup nilai sumbu yang dihitung, menukar baris dan kolom diagram, visibilitas sumbu, interval label kategori dan tanda centang, kategori tanggal dan pemformatannya, rotasi judul, posisi sumbu, satuan tampilan, serta skala logaritmik.

## **Dapatkan Nilai Maksimum pada Sumbu Vertikal pada Diagram**

Buat sebuah [Presentasi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) dan tambahkan diagram area dengan data default. Panggil [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) sebelum membaca nilai sumbu yang dihitung sehingga tata letak diagram terbaru.

Baca [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) dan [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) untuk batas sumbu, serta [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) dan [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) untuk interval tanda centang. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) dan [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) menyediakan skala satuan waktu, yang relevan untuk sumbu tanggal. Contoh menyimpan nilai-nilai ini dalam variabel lokal dan menyimpan diagram.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tukar Data antar Sumbu**

Gunakan [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) untuk menukar peran seri dan kategori dalam data diagram. Setiap kategori sebelumnya menjadi seri, dan setiap seri sebelumnya menjadi kategori. Ini mengubah cara data dikelompokkan; tidak menukar sumbu horizontal dan vertikal. Contoh menggunakan [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) untuk mengikat data default ke `Sheet1!A1:D5`, termasuk baris header dan kolom kategori, sebelum menukar baris dan kolom. Ini menyimpan diagram dengan empat seri dan tiga kategori.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Balik Urutan Plot Sumbu**

Gunakan [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) untuk membalikkan sumbu kategori atau nilai. Misalnya, diagram batang horizontal dapat menampilkan tahap proyek dari atas ke bawah dalam urutan yang sama dengan lembar kerja: Perencanaan, Pengembangan, Pengujian. Membalikkan sumbu mengubah arah plotting; tidak mengurutkan atau menyusun ulang data workbook. Sebagai perbandingan, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) menukar peran seri dan kategori.

Contoh berikut membuat diagram batang horizontal dengan tiga tahap dan satu seri. Ini menyimpan presentasi dengan tiga slide: urutan normal, kategori terbalik, dan nilai terbalik. Setiap salinan menggunakan set data yang sama, dan hanya satu sumbu yang dibalik pada setiap salinan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Slide 2: tampilkan kategori pertama di atas.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Pertahankan sumbu nilai horizontal di bagian bawah.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Slide 3: balikkan hanya skala numerik horizontal.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Membalikkan sumbu juga dapat memindahkan sumbu tegak lurus ke sisi berlawanan dari plot. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) mengontrol di mana sumbu lain memotong sumbu yang dikonfigurasi. Pada slide 2, memanggilnya dengan `aspose.slides.CrossesType.Maximum` pada sumbu kategori yang dibalik menjaga sumbu nilai horizontal di bagian bawah. Untuk titik perpotongan tertentu, gunakan [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Periksa pengaturan perpotongan saat mengubah arah, terutama jika diagram sudah memiliki titik perpotongan khusus. Panggil `setPlotOrderReversed` dengan `false` untuk mengembalikan arah plotting normal; pengaturan perpotongan terpisah.

| Urutan normal (slide 1) | Kategori terbalik (slide 2) | Nilai terbalik (slide 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Kategori berjalan dari bawah ke atas; nilai meningkat dari kiri ke kanan. | Perencanaan, Pengembangan, dan Pengujian berjalan dari atas ke bawah. Nilai dan urutan baris workbook tidak berubah. | Kategori mempertahankan urutan normal; nilai meningkat dari kanan ke kiri. Sumbu kategori memotong pada nol di sebelah kanan. |

## **Nonaktifkan Sumbu Vertikal untuk Diagram Garis**

Panggil [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) dengan `false` pada sumbu vertikal untuk menyembunyikannya. Contoh membuat diagram garis dengan data default dan menyimpannya dengan sumbu vertikal disembunyikan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nonaktifkan Sumbu Horizontal untuk Diagram Garis**

Panggil [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) dengan `false` pada sumbu horizontal untuk menyembunyikannya. Contoh membuat diagram garis dengan data default dan menyimpannya dengan sumbu horizontal disembunyikan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ubah Sumbu Kategori**

Gunakan [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) untuk memilih sumbu kategori tanggal atau teks. Contoh ini membutuhkan `ExistingChart.pptx`, dengan diagram sebagai shape pertama pada slide pertama dan sel kategori berisi nilai tanggal Excel numerik. Ini mengubah sumbu horizontal menjadi sumbu tanggal. Memanggil [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) dengan `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) dengan `1`, dan [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) dengan `TimeUnitType.Months` menempatkan tanda utama pada interval satu bulan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrol Interval Label Sumbu Kategori**

Ketika sebuah diagram memiliki banyak kategori, kurangi jumlah label sumbu yang terlihat tanpa menghapus kategori atau titik data. Panggil [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) dengan `false`, kemudian berikan interval kategori yang diinginkan ke [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Untuk kategori teks dalam urutan normal, penghitungan dimulai dari kategori pertama:

| Interval | Label yang ditampilkan dalam contoh |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

Interval `3` menampilkan setiap label ketiga, menyisakan dua label tersembunyi di antara label yang ditampilkan. Ini tidak menghapus kolom yang bersesuaian. Jarak otomatis memilih interval berdasarkan ruang yang tersedia; tidak selalu menampilkan setiap label.

Tanda centang memiliki kontrol terpisah. Panggil [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) dengan `false` dan gunakan [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) untuk mengatur intervalnya. Misalnya, `1` mempertahankan tanda centang pada setiap interval kategori sementara label muncul hanya setiap kategori ketiga. Gunakan [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) dengan gaya yang terlihat agar Anda dapat melihat hasilnya. Memanggil salah satu setter jarak otomatis dengan `true` lagi memungkinkan diagram memilih interval tersebut kembali.

Contoh mandiri berikut membuat 24 kategori dan satu seri, kemudian menyimpan tiga slide dalam `CategoryAxisIntervals.pptx`: jarak otomatis, jarak label manual dengan tanda centang independen, dan pemulihan jarak otomatis. Kedua salinan mempertahankan data diagram asli. Tidak diperlukan presentasi input. Teks label horizontal memudahkan melihat perbedaan kepadatan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slide 2: tampilkan setiap label ketiga, tetapi tetap pertahankan tanda centang untuk setiap kategori.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slide 3: biarkan diagram memilih kedua interval lagi.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Jarak otomatis (slide 1):** Dalam render ini, setiap label kategori kedua ditampilkan dan dibungkus menjadi dua baris. Hasil otomatis dapat bervariasi tergantung ukuran diagram, font, dan renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Jarak manual (slide 2):** Setiap label ketiga ditampilkan pada satu baris, sementara tanda centang tetap pada setiap interval kategori. Semua 24 kolom, termasuk yang tanpa label, tetap terlihat dengan nilai yang sama. Slide 3 mengembalikan tampilan otomatis yang ditunjukkan di atas.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Pilih Sumbu dan Interval yang Tepat**

Gunakan interval hitungan kategori ini untuk sumbu kategori teks, seperti sumbu kategori pada diagram kolom, garis, area, atau batang. Pada diagram kolom, ini adalah sumbu horizontal. Pada diagram batang horizontal, sumbu kategori adalah vertikal, jadi terapkan pengaturan ini pada sumbu yang dikembalikan oleh [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Jarak tanda centang juga berlaku untuk sumbu seri pada diagram yang memilikinya.

Jangan gunakan jarak label kategori untuk mengatur skala numerik sumbu nilai. Pada sumbu nilai, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) menentukan perbedaan nilai: misalnya, satuan utama `10` menghasilkan tanda pada 0, 10, 20, dan seterusnya ketika sumbu dimulai dari nol. Interval label kategori `3` menghitung posisi kategori, terlepas dari nilai datanya. Diagram sebar dan gelembung menggunakan sumbu nilai bukan sumbu kategori teks. Untuk sumbu tanggal, gunakan satuan utama berbasis waktu dan skala seperti yang dijelaskan pada [Change a Category Axis](#change-a-category-axis).

## **Atur Format Tanggal untuk Nilai Sumbu Kategori**

Contoh mengganti data diagram default dengan empat nilai tahunan. Tanggal disimpan sebagai nomor seri OLE Automation di lembar kerja pertama (indeks `0`), dihitung sebagai jumlah hari sejak 30 Desember 1899, untuk tanggal-tanggal ini. Perhitungan JavaScript menggunakan timestamp UTC dan membagi selisihnya dengan 86.400.000 milidetik per hari. Gunakan [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) dengan `CategoryAxisType.Date`, panggil [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) dengan `false`, dan berikan `yyyy` ke [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) agar label kategori menampilkan tahun empat digit secara terpisah dari pemformatan sel.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Sudut Rotasi untuk Judul Sumbu Diagram**

Panggil [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) dengan `true` pada sumbu vertikal, berikan teks judul, dan gunakan [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) untuk memutar judul. Sudut diukur dalam derajat; contoh ini menyimpan diagram kolom dengan judul sumbu nilai diputar 90 derajat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Posisi Sumbu pada Sumbu Kategori atau Nilai**

Gunakan [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) untuk mengontrol apakah sumbu nilai memotong sumbu kategori di antara kategori atau pada tanda centang kategori. Pengaturan ini berlaku untuk sumbu kategori. Contoh mengaturnya ke `true` pada sumbu kategori horizontal pada diagram kolom dan menyimpan hasilnya.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Satuan Tampilan pada Sumbu Nilai Diagram**

Gunakan [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) untuk mengubah skala label pada sumbu nilai tanpa mengubah data yang mendasarinya. Dengan [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) diatur ke `Millions`, nilai 60.000.000 ditampilkan sebagai 60. Contoh membuat diagram kolom dan menerapkan satuan tampilan jutaan pada sumbu vertikalnya.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Konfigurasikan Sumbu Nilai Logaritmik**

Sumbu nilai logaritmik berguna ketika nilai positif mencakup beberapa orde besaran. Misalnya, sebuah layanan mungkin menerima 10, 100, 1.000, 10.000, dan 100.000 permintaan selama lima periode. Pada skala linier, nilai lebih kecil tampak berdekatan dekat nol. Skala logaritmik memudahkan perbandingan pertumbuhan relatif mereka: jarak yang sama mewakili rasio yang sama bukan perbedaan yang sama.

Panggil [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) dengan `true` pada sumbu nilai dan gunakan [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) untuk memilih basisnya. Ini mengubah cara nilai yang ada ditampilkan; tidak mengubah data atau menambahkan garis tren logaritmik. Garis tren mewakili hubungan yang dipasang pada data dan merupakan fitur terpisah.

### **Pilih Sumbu Nilai dan Basis**

Untuk diagram garis atau kolom, sumbu nilai dikembalikan oleh [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Untuk diagram batang horizontal, sumbu nilai dikembalikan oleh [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Diagram sebar dan gelembung memiliki dua sumbu nilai, jadi pilih sumbu horizontal untuk nilai X, sumbu vertikal untuk nilai Y, atau keduanya. Jangan terapkan skala logaritmik pada sumbu kategori.

Basis logaritmik default adalah `10`. Untuk diagram PPTX, gunakan basis dari `2` hingga `1000`, inklusif; basis pecahan seperti `2.5` juga didukung. Dengan basis `10`, pangkat berurutan seperti 10, 100, 1.000, dan 10.000 memiliki jarak yang sama.

### **Bandingkan Skala Linear dan Logaritmik**

Contoh mandiri berikut membuat diagram garis dengan lima jumlah permintaan pada slide pertama, kemudian menggandakan slide itu dan mengaktifkan sumbu nilai logaritmik basis-10 pada slide kedua. Kedua slide mempertahankan data yang sama.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Pertahankan slide pertama linear dan ubah hanya skala sumbu nilai salinan.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Skala linear (slide 1):** Jarak vertikal yang sama mewakili perbedaan yang sama dalam jumlah permintaan. Nilai terbesar mendominasi diagram, membuat nilai yang lebih kecil sulit dibedakan.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Skala logaritmik (slide 2):** Jarak vertikal yang sama mewakili rasio yang sama. Setiap periode memiliki sepuluh kali lebih banyak permintaan daripada periode sebelumnya, sehingga titik-titik membentuk garis naik lurus pada skala basis-10. Label sumbu masih menampilkan jumlah permintaan asli.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Tangani Nilai Nol dan Negatif**

Skala logaritmik hanya dapat menampilkan nilai yang benar-benar positif. Periksa data sebelum mengaktifkannya. Jika nilai nol atau negatif memiliki makna, pertahankan skala linear atau tampilkan secara terpisah. Jika mengecualikan nilai tersebut cocok untuk analisis, jelaskan pengabaian tersebut. Jangan diam-diam menggantinya dengan angka positif kecil, karena hal itu mengubah makna data. Setiap minimum atau maksimum yang dikonfigurasi secara manual untuk sumbu logaritmik juga harus positif.

## **FAQ**

**Bagaimana cara mengatur nilai di mana satu sumbu memotong sumbu lainnya (perpotongan sumbu)?**

Gunakan [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) untuk memilih perilaku perpotongan. Untuk menentukan nilai perpotongan numerik, gunakan [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Pengaturan ini memungkinkan Anda memindahkan perpotongan sumbu ke baseline yang sesuai.

**Bagaimana saya dapat memposisikan label tanda centang relatif terhadap sumbu?**

Panggil [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) menggunakan [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, atau `None`. Untuk mengontrol tanda centang itu sendiri, gunakan [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) atau [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); ini terpisah dari posisi label.