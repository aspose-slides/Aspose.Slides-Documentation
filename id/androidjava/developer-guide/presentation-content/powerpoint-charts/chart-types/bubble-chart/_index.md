---
title: Sesuaikan Diagram Buih dalam Presentasi di Android
linktitle: Diagram Buih
type: docs
url: /id/androidjava/bubble-chart/
keywords:
- diagram buih
- ukuran buih
- skala ukuran
- representasi ukuran
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat dan sesuaikan diagram buih yang kuat di PowerPoint dengan Aspose.Slides untuk Android via Java untuk meningkatkan visualisasi data Anda dengan mudah."
---
## **Ikhtisar**

Artikel ini menunjukkan cara bekerja dengan diagram buih di Aspose.Slides. Ini mencakup dua opsi kustomisasi khusus: mengubah skala ukuran buih melalui metode `setBubbleSizeScale` dan mengontrol cara nilai ukuran buih direpresentasikan melalui metode `setBubbleSizeRepresentation`.

Contoh-contoh menunjukkan cara membuat diagram buih, menyesuaikan skala ukurannya, dan mengubah representasi ukuran buih untuk menggunakan lebar. Artikel ini juga menyertakan bagian FAQ singkat yang menjelaskan dukungan untuk tipe diagram “Bubble with 3‑D”, mencatat bahwa batas praktis diagram tergantung pada kinerja dan versi PowerPoint target, serta menjelaskan bahwa ekspor mempertahankan tampilan diagram melalui mesin rendering Aspose.Slides.

## **Skala Ukuran Diagram Buih**
Aspose.Slides for Android via Java menyediakan dukungan untuk skala ukuran diagram Buih. Di Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) dan [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) telah ditambahkan. Contoh sampel diberikan di bawah. 

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

## **Representasikan Data sebagai Ukuran Diagram Buih**
Metode [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) dan [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) telah ditambahkan ke antarmuka [IChartSeries](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartSeriesGroup), serta kelas terkait. **BubbleSizeRepresentation** menentukan bagaimana nilai ukuran buih direpresentasikan dalam diagram buih. Nilai yang mungkin adalah: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) dan [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Dengan demikian, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/BubbleSizeRepresentationType) telah ditambahkan untuk menentukan cara-cara yang mungkin merepresentasikan data sebagai ukuran diagram buih. Kode contoh diberikan di bawah.

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

**Apakah “diagram buih dengan efek 3‑D” didukung, dan bagaimana perbedaannya dengan yang biasa?**

Ya. Ada tipe diagram terpisah, “Bubble with 3‑D.” Ini menerapkan gaya 3‑D pada buih tetapi tidak menambahkan sumbu tambahan; data tetap X‑Y‑S (ukuran). Tipe ini tersedia di kelas [tipe diagram](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/charttype/).

**Apakah ada batas jumlah seri dan titik dalam diagram buih?**

Tidak ada batas keras pada tingkat API; batas ditentukan oleh kinerja dan versi PowerPoint target. Disarankan menjaga jumlah titik pada tingkat yang wajar untuk keterbacaan dan kecepatan rendering.

**Bagaimana ekspor memengaruhi tampilan diagram buih (PDF, gambar)?**

Ekspor ke format yang didukung mempertahankan tampilan diagram; proses rendering dilakukan oleh mesin Aspose.Slides. Untuk format raster/vektor, aturan umum rendering grafik diagram berlaku (resolusi, anti‑aliasing), jadi pilih DPI yang cukup untuk pencetakan.