---
title: Sesuaikan Diagram Donat dalam Presentasi Menggunakan JavaScript
linktitle: Diagram Donat
type: docs
weight: 30
url: /id/nodejs-java/doughnut-chart/
keywords:
- diagram donat
- celah tengah
- ukuran lubang
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan diagram donat dengan JavaScript dan Aspose.Slides untuk Node.js, mendukung format PowerPoint untuk presentasi dinamis."
---
## **Ringkasan**

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang tengahnya, dan menyimpan presentasi. Fokusnya pada metode `setDoughnutHoleSize` dan memperlihatkan langkah dasar yang diperlukan untuk menyesuaikan jenis diagram ini dalam kode.

Juga termasuk FAQ singkat yang mencakup skenario terkait diagram donat, seperti menggunakan beberapa seri untuk membuat beberapa cincin, bekerja dengan diagram donat yang meledak, dan mengekspor diagram sebagai gambar raster atau SVG.

## **Ubah Celah Tengah pada Diagram Donat**

Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah-langkah berikut:

1. Instansiasi objek [Presentasi](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Tambahkan diagram donat pada slide.
1. Tentukan ukuran lubang pada diagram donat.
1. Tulis presentasi ke disk.

Dalam contoh di bawah ini, kami telah mengatur ukuran lubang pada diagram donat.

```javascript
// Buat instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Tulis presentasi ke disk
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat membuat donat multi‑tingkat dengan beberapa cincin?**

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

**Apakah donat "meledak" (irisan terpisah) didukung?**

Ya. Ada tipe diagram Donat Meledak [chart type](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan individual.

**Bagaimana cara mendapatkan gambar diagram donat (PNG/SVG) untuk laporan?**

Diagram adalah bentuk; Anda dapat merendernya ke [gambar raster](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getImage) atau mengekspor diagram ke [gambar SVG](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/writeassvg/).