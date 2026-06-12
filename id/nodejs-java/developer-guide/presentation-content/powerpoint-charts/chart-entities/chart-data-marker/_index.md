---
title: Kelola Penanda Data Grafik dalam Presentasi Menggunakan JavaScript
linktitle: Penanda Data
type: docs
url: /id/nodejs-java/chart-data-marker/
keywords:
- grafik
- poin data
- penanda
- opsi penanda
- ukuran penanda
- tipe isian
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menyesuaikan penanda data grafik di Aspose.Slides untuk Node.js, meningkatkan dampak presentasi pada format PPT dan PPTX dengan contoh kode yang jelas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan penanda data grafik di Aspose.Slides. Artikel ini menunjukkan cara membuat grafik, mengakses seri dan poin data‑nya, menerapkan isian gambar pada penanda di tingkat poin data, menyesuaikan ukuran penanda, dan menyimpan presentasi yang telah diperbarui. Artikel ini juga mencatat bahwa bentuk penanda standar tersedia melalui enumerasi `MarkerStyleType` dan bahwa penampilan penanda dipertahankan saat mengekspor grafik ke format raster atau SVG.

## **Atur Opsi Penanda Grafik**

Penanda dapat diatur pada poin data grafik di dalam seri tertentu. Untuk mengatur opsi penanda grafik, ikuti langkah‑langkah berikut:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
- Membuat grafik default.
- Menetapkan gambar.
- Mengambil seri grafik pertama.
- Menambahkan poin data baru.
- Menulis presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur opsi penanda grafik pada tingkat poin data.

```javascript
// Membuat presentasi kosong
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Membuat grafik default
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Mendapatkan indeks WorkSheet data grafik default
    var defaultWorksheetIndex = 0;
    // Mendapatkan WorkSheet data grafik
    var fact = chart.getChartData().getChartDataWorkbook();
    // Menghapus seri demo
    chart.getChartData().getSeries().clear();
    // Menambahkan seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Memuat gambar 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Memuat gambar 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Mengambil seri grafik pertama
    var series = chart.getChartData().getSeries().get_Item(0);
    // Menambahkan titik baru (1:3) di sana.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Mengubah penanda seri grafik
    series.getMarker().setSize(15);
    // Menyimpan presentasi dengan grafik
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Bentuk penanda apa yang tersedia secara default?**

Bentuk standar tersedia (lingkaran, persegi, belah ketupat, segitiga, dll.); daftarnya didefinisikan oleh enumerasi [MarkerStyleType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markerstyletype/). Jika Anda memerlukan bentuk yang tidak standar, gunakan penanda dengan isian gambar untuk meniru visual khusus.

**Apakah penanda dipertahankan saat mengekspor grafik ke gambar atau SVG?**

Ya. Saat merender grafik ke [raster formats](/slides/id/nodejs-java/convert-powerpoint-to-png/) atau menyimpan [shapes as SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/), penanda mempertahankan penampilan dan pengaturannya, termasuk ukuran, isian, dan garis tepi.