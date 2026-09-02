---
title: Kelola Seri Data Chart dalam Presentasi Menggunakan JavaScript
linktitle: Seri Data
type: docs
url: /id/nodejs-java/chart-series/
keywords:
- seri chart
- overlap seri
- warna seri
- nama seri
- titik data
- sel workbook
- celah seri
- nilai negatif
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengelola seri chart, titik data, sel workbook, pemformatan, overlap, lebar celah, dan nilai negatif dalam presentasi dengan JavaScript."
---
## **Ikhtisar**

Sebuah chart menyimpan data yang dipetakan dalam workbook data chart. Sebuah [ChartSeries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/) mewakili satu set nilai yang terkait, dan setiap [ChartDataPoint](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/) dalam seri mengacu pada satu atau lebih sel workbook. Objek [ChartCategory](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartcategory/) menyediakan label atau nilai pengelompokan yang dibagi oleh seri. Nama seri, kategori, dan nilai titik terhubung ke objek [ChartDataCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/) bukan hanya disimpan sebagai teks tampilan.

Untuk chart kategori standar, workbook default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel-sel sisanya untuk nilai seri. Indeks worksheet, baris, dan kolom yang diteruskan ke [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#getCell) berbasis nol. Tata letak ini berguna saat Anda membuat chart dengan data default, tetapi jangan menganggap setiap chart yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel-sel yang direferensikan oleh seri, kategori, dan titik data sebelum mengubah nilai workbook.

Pengaturan chart memiliki tiga lingkup berbeda:

- Pengaturan tingkat Seri, seperti [ChartSeries.getFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getFormat), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [ChartDataPoint.getFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#getFormat), menimpa tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang berada dalam satu [ChartSeriesGroup](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/). Akses grup melalui [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) ketika Anda perlu mengatur opsi seperti overlap atau lebar celah.

Ketika tidak ada isian titik atau seri yang eksplisit, gaya chart dan tema menentukan tampilan otomatis. Ketika format seri dan titik keduanya ada, format titik yang diutamakan untuk titik tersebut.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Overlap Seri Chart**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getOverlap) melaporkan seberapa banyak batang atau kolom saling tumpang tindih dalam chart 2D, dari -100 hingga 100 persen. Ini merupakan proyeksi baca-saja dari pengaturan pada grup seri induk. Gunakan [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe chart yang menampilkan batang atau kolom berkelompok; tidak memengaruhi grup seri yang tidak terkait dalam chart kombinasi.

Contoh berikut mengatur overlap untuk grup yang berisi seri pertama:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Chart baru berisi contoh seri, kategori, dan nilai.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![The series overlap](series_overlap.png)

## **Ubah Warna Isi Seri**

Gunakan [ChartSeries.getFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getFormat) untuk mengatur isi default bagi seluruh seri. Jika sebuah titik sudah memiliki isi eksplisit, pengaturan [ChartDataPoint.getFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#getFormat) menimpa isi seri untuk titik tersebut.

Contoh berikut menerapkan isian biru solid pada seri pertama:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![The color of the series](series_color.png)

## **Ubah Nama Seri**

Nama seri disimpan dalam workbook data chart dan biasanya ditampilkan di legenda. Pada workbook default yang dibuat untuk chart kolom berkelompok, sel B1 berada di baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut membuat struktur itu eksplisit:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat memperbarui sel yang sudah direferensikan oleh [ChartSeries.getName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getName). Pendekatan ini menghindari asumsi baris dan kolom tertentu pada chart yang sudah ada:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![The series name](series_name.png)

## **Dapatkan Warna Isi Seri Otomatis**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) mengembalikan warna yang dihitung dari indeks seri dan gaya chart. Ini adalah warna yang digunakan ketika isi seri tidak didefinisikan secara eksplisit. Memanggil metode ini hanya membaca warna yang dihitung; tidak menetapkan isian baru.

Contoh berikut mencetak warna otomatis setiap seri default:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Contoh output untuk gaya chart default:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Warna yang tepat bergantung pada gaya dan tema chart.

## **Atur Warna Isi Invert untuk Seri Chart**

Untuk seri batang, kolom, dan gelembung, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) dapat menampilkan nilai negatif dengan isian berbeda. Atur isi seri reguler menjadi solid, aktifkan inversi, dan tetapkan warna nilai negatif melalui [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Angka negatif tetap tidak berubah di workbook; hanya warna tampilan yang berubah.

Contoh berikut mengganti data chart default dengan satu seri. Baris worksheet 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![The inverted solid fill color](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Pada contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif agar efeknya terlihat:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kosongkan Nilai Titik Data Spesifik**

Untuk membuat satu titik kosong tanpa menghapus titik lainnya, atur sel workbook yang mendasarinya menjadi `null`. Untuk chart kolom, nilai yang dipetakan tersedia melalui [ChartDataPoint.getValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#getValue). Titik data tetap berada pada posisi kategori yang sama, tetapi chart memperlakukan nilainya sebagai kosong sesuai dengan pengaturan nilai kosong chart.

Contoh berikut mengosongkan hanya titik kedua dalam seri pertama:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Chart sebar menggunakan sel X dan Y terpisah, dan chart gelembung juga memakai sel ukuran. Kosongkan hanya sel yang mewakili nilai yang ingin Anda hapus. Jangan memanggil [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapointcollection/#clear) ketika Anda ingin mempertahankan titik lain, karena metode tersebut menghapus semua titik data dari koleksi.

## **Atur Lebar Celah Seri**

Lebar celah adalah ruang antara klaster batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti overlap, ini dimiliki oleh grup seri induk, bukan oleh satu seri. Panggil [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) sekali untuk grup tersebut. Nilai yang lebih besar menciptakan lebih banyak ruang antara klaster; nilai yang lebih kecil membuatnya lebih rapat.

Contoh berikut mengubah lebar celah dan menyimpan hanya presentasi akhir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![The gap width](gap_width.png)

## **FAQ**

**Tipe chart apa yang mendukung seri data?**

Semua tipe chart yang direpresentasikan oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/) menggunakan data chart, tetapi seri mereka tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, chart kategori menggunakan kategori dan nilai, chart sebar menggunakan nilai X dan Y, dan chart gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri chart?**

Sebuah [ChartSeriesGroup](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plotting tingkat grup. Sebuah chart kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang diakses melalui satu seri tidak selalu mengubah setiap seri dalam chart.

**Apakah chart yang baru dibuat berisi data default?**

Ya. Secara default, [ShapeCollection.addChart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addChart) membuat contoh seri, kategori, dan nilai. Anda dapat mengedit sel‑sel tersebut atau mengosongkan koleksi seri dan kategori sebelum menambahkan set data yang sepenuhnya khusus. Sebuah overload juga dapat membuat chart tanpa data default.

**Bagaimana objek chart terhubung ke sel workbook?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam sebuah [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/). Mengubah sel yang direferensikan memperbarui elemen chart yang bersangkutan. Saat Anda membangun data khusus, pertahankan baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara mengosongkan satu titik tanpa mengosongkan seluruh seri?**

Atur sel nilai yang relevan menjadi `null` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapointcollection/#clear) hanya ketika Anda berniat menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri agar nilai mereka tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe chart dan nilai yang dikonfigurasi melalui [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Chart yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, panggil [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) dan atur warna yang dikembalikan oleh [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Anda dapat menimpa perilaku untuk titik individu dengan [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Metode‑metode ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Pengaturan pemformatan mana yang menang ketika seri dan titik keduanya diformat?**

Pemformatan titik data eksplisit memiliki prioritas untuk titik tersebut. Titik lain terus menggunakan format seri eksplisit atau, bila format seri tidak didefinisikan, gaya dan tema chart otomatis. Pengaturan grup seperti overlap dan lebar celah mengontrol tata letak dan bukan penimpaan pemformatan tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki sebuah chart?**

Aspose.Slides tidak menetapkan batas tetap terpisah untuk jumlah seri. Pada praktiknya, batas dipengaruhi oleh keterbatasan berkas presentasi, memori yang tersedia, waktu rendering, dan keterbacaan chart.

**Apa yang harus saya ubah ketika kolom terlalu berdekatan atau terlalu berjauhan?**

Panggil [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) pada grup seri induk yang tepat. Tingkatkan nilai untuk memperlebar ruang antara klaster, atau turunkan nilai untuk mendekatkan klaster satu sama lain.