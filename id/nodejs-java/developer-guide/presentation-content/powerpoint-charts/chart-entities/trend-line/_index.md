---
title: Menambahkan Garis Tren ke Diagram Presentasi dalam JavaScript
linktitle: Garis Tren
type: docs
url: /id/nodejs-java/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata‑rata bergerak
- garis tren polinomial
- garis tren daya
- garis tren khusus
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Tambahkan dan sesuaikan garis tren dengan cepat dalam diagram PowerPoint menggunakan JavaScript dan Aspose.Slides untuk Node.js via Java — panduan praktis untuk menarik perhatian audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi menggunakan Aspose.Slides. Ini memperlihatkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata‑rata bergerak, polinomial, dan daya.

Artikel ini juga menjelaskan cara menambahkan garis khusus ke diagram dengan menyisipkan bentuk garis, dan mencakup FAQ singkat tentang nilai proyeksi garis tren maju dan mundur serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Tambahkan Garis Tren**

Aspose.Slides for Node.js via Java provides a simple API for managing different chart Trend Lines:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Dapatkan referensi slide dengan indeksnya.
1. Tambahkan diagram dengan data default serta tipe yang diinginkan (contoh ini menggunakan ChartType.ClusteredColumn).
1. Menambahkan garis tren eksponensial untuk seri diagram 1.
1. Menambahkan garis tren linear untuk seri diagram 1.
1. Menambahkan garis tren logaritmik untuk seri diagram 2.
1. Menambahkan garis tren rata‑rata bergerak untuk seri diagram 2.
1. Menambahkan garis tren polinomial untuk seri diagram 3.
1. Menambahkan garis tren daya untuk seri diagram 3.
1. Tuliskan presentasi yang telah diubah ke file PPTX.

Kode berikut digunakan untuk membuat diagram dengan Garis Tren.

```javascript
// Buat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Membuat diagram kolom terkelompok
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Menambahkan garis tren eksponensial untuk seri diagram 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Menambahkan garis tren Linear untuk seri diagram 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Menambahkan garis tren Logaritmik untuk seri diagram 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Menambahkan garis tren rata‑rata bergerak untuk seri diagram 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Menambahkan garis tren Polinomial untuk seri diagram 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Menambahkan garis tren Daya untuk seri diagram 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Menyimpan presentasi
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tambahkan Garis Kustom**

Aspose.Slides for Node.js via Java provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation)
- Dapatkan referensi slide dengan menggunakan Indeksnya
- Buat diagram baru menggunakan metode AddChart yang disediakan oleh objek Shapes
- Tambahkan AutoShape berjenis Line menggunakan metode AddAutoShape yang disediakan oleh objek Shapes
- Atur Color garis bentuk.
- Tuliskan presentasi yang telah diubah sebagai file PPTX

Kode berikut digunakan untuk membuat diagram dengan Garis Kustom.

```javascript
// Buat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apa arti 'forward' dan 'backward' pada garis tren?**

Mereka adalah panjang garis tren yang diproyeksikan ke depan/ke belakang: untuk diagram scatter (XY) — dalam satuan sumbu; untuk diagram non‑scatter — dalam jumlah kategori. Hanya nilai non‑negatif yang diperbolehkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/) dan merender diagram menjadi gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi ini. Sebuah metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/nodejs-java/create-shape-thumbnails/) itu sendiri.