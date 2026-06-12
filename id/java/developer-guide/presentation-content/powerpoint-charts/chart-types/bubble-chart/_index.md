---
title: Sesuaikan Bagan Gelembung dalam Presentasi Menggunakan Java
linktitle: Bagan Gelembung
type: docs
url: /id/java/bubble-chart/
keywords:
  - bagan gelembung
  - ukuran gelembung
  - skala ukuran
  - representasi ukuran
  - PowerPoint
  - presentasi
  - Java
  - Aspose.Slides
description: "Buat dan sesuaikan bagan gelembung yang kuat di PowerPoint dengan Aspose.Slides untuk Java untuk meningkatkan visualisasi data Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan bagan gelembung di Aspose.Slides. Artikel ini mencakup dua opsi penyesuaian khusus: mengubah skala ukuran gelembung melalui metode `setBubbleSizeScale` dan mengontrol cara nilai ukuran gelembung direpresentasikan melalui metode `setBubbleSizeRepresentation`. Contoh-contoh tersebut menunjukkan cara membuat bagan gelembung, menyesuaikan skala ukurannya, dan mengubah representasi ukuran gelembung menjadi lebar. Artikel ini juga menyertakan bagian FAQ singkat yang menjelaskan dukungan untuk tipe bagan “Bubble with 3-D”, mencatat bahwa batas praktis bagan bergantung pada kinerja dan versi PowerPoint target, serta menjelaskan bahwa ekspor mempertahankan tampilan bagan melalui mesin rendering Aspose.Slides.

## **Skala Ukuran Bagan Gelembung**
Aspose.Slides for Java menyediakan dukungan untuk skala ukuran bagan Gelembung. Di Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) dan [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) metode telah ditambahkan. Contoh sampel di bawah diberikan.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Representasikan Data sebagai Ukuran Bagan Gelembung**
Metode [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) dan [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) telah ditambahkan ke antarmuka [IChartSeries](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartSeriesGroup) serta kelas terkait. **BubbleSizeRepresentation** menentukan bagaimana nilai ukuran gelembung direpresentasikan dalam bagan gelembung. Nilai yang mungkin adalah: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/id/java/com.aspose.slides/BubbleSizeRepresentationType#Area) dan [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/id/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Dengan demikian, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/id/java/com.aspose.slides/BubbleSizeRepresentationType) telah ditambahkan untuk menentukan cara-cara yang mungkin merepresentasikan data sebagai ukuran bagan gelembung. Kode contoh diberikan di bawah.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah "bubble chart with 3-D effect" didukung, dan bagaimana perbedaannya dengan yang biasa?**  
Ya. Ada tipe bagan terpisah, "Bubble with 3-D." Itu menerapkan gaya 3-D pada gelembung tetapi tidak menambahkan sumbu tambahan; data tetap X-Y-S (ukuran). Tipe ini tersedia di kelas [chart type](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/).

**Apakah ada batas pada jumlah seri dan titik dalam bagan gelembung?**  
Tidak ada batas keras pada tingkat API; batasan ditentukan oleh kinerja dan versi PowerPoint target. Disarankan untuk menjaga jumlah titik tetap wajar demi keterbacaan dan kecepatan rendering.

**Bagaimana ekspor memengaruhi tampilan bagan gelembung (PDF, gambar)?**  
Ekspor ke format yang didukung mempertahankan tampilan bagan; rendering dilakukan oleh mesin Aspose.Slides. Untuk format raster/vektor, aturan umum rendering grafik bagan berlaku (resolusi, anti-aliasing), jadi pilih DPI yang cukup untuk pencetakan.