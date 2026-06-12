---
title: "Sesuaikan Diagram Gelembung dalam Presentasi Menggunakan JavaScript"
linktitle: "Diagram Gelembung"
type: docs
url: /id/nodejs-java/bubble-chart/
keywords:
- "diagram gelembung"
- "ukuran gelembung"
- "skala ukuran"
- "representasi ukuran"
- "PowerPoint"
- "presentasi"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Buat dan sesuaikan diagram gelembung yang kuat di PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js via Java guna meningkatkan visualisasi data Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan diagram gelembung di Aspose.Slides. Artikel ini mencakup dua opsi kustomisasi khusus: mengubah skala ukuran gelembung melalui metode `setBubbleSizeScale` dan mengontrol cara nilai ukuran gelembung direpresentasikan melalui metode `setBubbleSizeRepresentation`.

Contoh-contoh menunjukkan cara membuat diagram gelembung, menyesuaikan skala ukurannya, dan mengubah representasi ukuran gelembung menjadi lebar. Artikel ini juga mencakup bagian FAQ singkat yang menjelaskan dukungan untuk tipe diagram “Bubble with 3-D”, mencatat bahwa batas praktis diagram tergantung pada kinerja dan versi PowerPoint target, serta menjelaskan bahwa ekspor mempertahankan tampilan diagram melalui mesin rendering Aspose.Slides.

## **Skala Ukuran Diagram Gelembung**
Aspose.Slides for Node.js via Java menyediakan dukungan untuk skala ukuran diagram Gelembung. Di Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) dan [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) telah ditambahkan. Contoh kode berikut diberikan.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Representasikan Data sebagai Ukuran Diagram Gelembung**
Metode [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) dan [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) telah ditambahkan ke kelas [ChartSeries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartSeriesGroup) dan kelas terkait. **BubbleSizeRepresentation** menentukan bagaimana nilai ukuran gelembung direpresentasikan dalam diagram gelembung. Nilai yang mungkin adalah: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) dan [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Oleh karena itu, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BubbleSizeRepresentationType) telah ditambahkan untuk menentukan cara‑cara yang mungkin merepresentasikan data sebagai ukuran diagram gelembung. Contoh kode diberikan di bawah.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah “diagram gelembung dengan efek 3-D” didukung, dan bagaimana perbedaannya dengan diagram biasa?**

Ya. Ada tipe diagram terpisah, “Bubble with 3-D.” Tipe ini menerapkan gaya 3-D pada gelembung tetapi tidak menambah sumbu tambahan; data tetap X-Y-S (ukuran). Tipe ini tersedia dalam enumerasi [chart type](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/).

**Apakah ada batas jumlah seri dan titik dalam diagram gelembung?**

Tidak ada batas keras pada tingkat API; batasan ditentukan oleh kinerja dan versi PowerPoint target. Disarankan menjaga jumlah titik tetap wajar untuk keterbacaan dan kecepatan rendering.

**Bagaimana ekspor memengaruhi tampilan diagram gelembung (PDF, gambar)?**

Ekspor ke format yang didukung mempertahankan tampilan diagram; proses rendering dilakukan oleh mesin Aspose.Slides. Untuk format raster/vektor, aturan umum rendering grafik diagram berlaku (resolusi, anti‑aliasing), jadi pilih DPI yang cukup untuk pencetakan.