---
title: Sesuaikan Diagram Bubble dalam Presentasi Menggunakan PHP
linktitle: Diagram Bubble
type: docs
url: /id/php-java/bubble-chart/
keywords:
- diagram bubble
- ukuran bubble
- skala ukuran
- representasi ukuran
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat dan sesuaikan diagram bubble yang kuat di PowerPoint dengan Aspose.Slides untuk PHP via Java guna meningkatkan visualisasi data Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan diagram bubble di Aspose.Slides. Artikel ini mencakup dua opsi penyesuaian khusus: mengubah skala ukuran bubble melalui metode `setBubbleSizeScale` dan mengontrol cara nilai ukuran bubble direpresentasikan melalui metode `setBubbleSizeRepresentation`.

Contoh-contoh memperlihatkan cara membuat diagram bubble, menyesuaikan skala ukurannya, dan mengubah representasi ukuran bubble menjadi lebar. Artikel ini juga menyertakan bagian FAQ singkat yang menjelaskan dukungan untuk tipe diagram “Bubble with 3-D”, mencatat bahwa batas praktis diagram bergantung pada kinerja dan versi PowerPoint target, serta menjelaskan bahwa proses ekspor mempertahankan tampilan diagram melalui mesin rendering Aspose.Slides.

## **Skala Ukuran Diagram Bubble**
Aspose.Slides for PHP via Java menyediakan dukungan untuk skala ukuran diagram bubble. Pada Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) dan [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) telah ditambahkan. Contoh kode berikut diberikan.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Representasikan Data sebagai Ukuran Diagram Bubble**
Metode [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) dan [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) telah ditambahkan ke kelas [ChartSeries](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseriesgroup/) dan kelas terkait. **BubbleSizeRepresentation** menentukan bagaimana nilai ukuran bubble direpresentasikan dalam diagram bubble. Nilai yang mungkin adalah: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/id/php-java/aspose.slides/BubbleSizeRepresentationType#Area) dan [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/id/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Oleh karena itu, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/id/php-java/aspose.slides/BubbleSizeRepresentationType) telah ditambahkan untuk menentukan cara-cara yang mungkin dalam merepresentasikan data sebagai ukuran diagram bubble. Contoh kode diberikan di bawah.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah “diagram bubble dengan efek 3-D” didukung, dan bagaimana perbedaannya dengan diagram biasa?**

Ya. Ada tipe diagram terpisah, “Bubble with 3-D.” Tipe ini menerapkan gaya 3-D pada bubble tetapi tidak menambahkan sumbu tambahan; data tetap X‑Y‑S (ukuran). Tipe ini tersedia di kelas [tipe diagram](https://reference.aspose.com/slides/id/php-java/aspose.slides/charttype/).

**Apakah ada batasan jumlah seri dan titik dalam diagram bubble?**

Tidak ada batas keras pada tingkat API; kendala ditentukan oleh kinerja dan versi PowerPoint target. Disarankan agar jumlah titik tetap wajar untuk memastikan keterbacaan dan kecepatan rendering.

**Bagaimana proses ekspor memengaruhi tampilan diagram bubble (PDF, gambar)?**

Ekspor ke format yang didukung mempertahankan tampilan diagram; proses rendering dilakukan oleh mesin Aspose.Slides. Untuk format raster atau vektor, aturan umum rendering grafik diagram berlaku (resolusi, anti‑aliasing), jadi pilih DPI yang cukup untuk pencetakan.