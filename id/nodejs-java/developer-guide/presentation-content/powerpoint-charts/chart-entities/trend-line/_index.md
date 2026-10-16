---
title: Tambahkan Garis Tren ke Diagram Presentasi dalam JavaScript
linktitle: Garis Tren
type: docs
url: /id/nodejs-java/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren pangkat
- garis tren kustom
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Tambahkan dan sesuaikan garis tren dengan cepat pada diagram PowerPoint menggunakan JavaScript dan Aspose.Slides untuk Node.js via Java — panduan praktis untuk melibatkan audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata‑rata bergerak, polinomial, dan pangkat.

Artikel ini juga menjelaskan cara menambahkan garis kustom ke diagram dengan menyisipkan bentuk garis, dan mencakup FAQ singkat tentang nilai proyeksi tren ke depan dan ke belakang serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Menambahkan Garis Tren**

Gunakan [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) untuk menambahkan garis tren ke seri diagram, memilih tipenya dengan [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). Contoh membuat diagram kolom berkelompok dengan data default dan menambahkan dua garis tren ke masing‑masing tiga serinya.

Garis tren eksponensial menyembunyikan persamaan dan nilai R‑squared melalui [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) dan [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), sementara garis tren linear berwarna merah. Garis tren logaritmik menggunakan [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) untuk label kustom. Rata‑rata bergerak menggunakan [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) tiga titik data dan [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) kustom.

Garis tren polinomial memiliki [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) tiga dan memperluas satu kategori ke depan melalui [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). Garis tren pangkat memperluas satu kategori ke belakang melalui [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menetapkan Intersep Garis Tren**

Gunakan [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) untuk memperbaiki nilai Y garis tren pada X = 0. Pengaturan ini didukung untuk garis tren linear, eksponensial, dan polinomial.

Sebagai contoh, model biaya produksi mungkin perlu dimulai dengan biaya tetap yang diketahui sebesar 100, meskipun pengukuran pada volume produksi non‑nol menunjukkan baseline yang berbeda. Untuk garis tren linear, memperbaiki intersep membatasi persamaan `y = ax + b` menjadi `b = 100`; kemiringan kemudian disesuaikan dengan data di bawah batasan tersebut. Ini tidak hanya memindahkan garis yang sudah dipasang. Pengaturan perpotongan sumbu mengontrol di mana sumbu diagram bertemu, bukan koefisien garis tren yang dipasang.

Contoh berikut membuat diagram pencar (XY) dengan volume produksi 1 hingga 4 dan biaya 170, 200, 230, serta 260. Diagram disimpan dengan intersep otomatis bawaan, intersep diatur menjadi 100, dan PPTX kedua disimpan. Kedua berkas hanya berbeda pada pengaturan intersep. Garis tren menampilkan persamaannya dan memperpanjang kembali ke X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dengan perhitungan otomatis, data ini menghasilkan `y = 30x + 140`. Mengatur intersep menjadi 100 menghasilkan kira‑kira `y = 43.33x + 100`: nilai yang dipasang pada nol cocok dengan baseline yang diketahui, sementara garis tidak lagi melalui setiap titik data.

| Intersep otomatis | Intersep tetap 100 |
| --- | --- |
| ![Garis tren linear dengan intersep yang dihitung otomatis sebesar 140](intercept-automatic.png) | ![Garis tren linear dengan intersep tetap sebesar 100](intercept-fixed.png) |

Kedua gambar menggunakan data dan skala sumbu yang sama. Garis tren diperpanjang kembali ke X = 0 untuk menampilkan intersepsnya.

Secara default, [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) mengembalikan `NaN`, yang mewakili intersep yang tidak ditentukan, bukan nol. Intersep kemudian dihitung otomatis dari data.

## **Menambahkan Garis Kustom**

Garis kustom adalah bentuk yang digambar di atas diagram, bukan garis tren yang dihitung dari data seri. Contoh ini menggunakan [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) untuk menambahkan garis horizontal ke slide di atas diagram. Posisi garis ditentukan dalam koordinat slide, diukur dalam poin, sehingga dimulai pada tepi kiri diagram dan berada setengah tinggi diagram. Lebarnya sama dengan lebar diagram. [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) memberikan warna merah padat pada garis.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa arti 'forward' dan 'backward' untuk sebuah garis tren?**

Kedua istilah tersebut merupakan panjang garis tren yang diproyeksikan ke depan atau ke belakang: untuk diagram pencar (XY) — dalam satuan sumbu; untuk diagram non‑pencar — dalam jumlah kategori. Hanya nilai non‑negatif yang diizinkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) atau [SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/) dan merender diagram ke gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/nodejs-java/create-shape-thumbnails/).