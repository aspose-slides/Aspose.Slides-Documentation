---
title: Sesuaikan Diagram Donat dalam Presentasi Menggunakan PHP
linktitle: Diagram Donat
type: docs
weight: 30
url: /id/php-java/doughnut-chart/
keywords:
- diagram donat
- celah tengah
- ukuran lubang
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan diagram donat di Aspose.Slides untuk PHP melalui Java, mendukung format PowerPoint untuk presentasi dinamis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang tengahnya, dan menyimpan presentasi. Fokusnya adalah pada metode `setDoughnutHoleSize` dan menunjukkan langkah-langkah dasar yang diperlukan untuk menyesuaikan tipe diagram ini dalam kode.

Artikel ini juga menyertakan FAQ singkat yang mencakup skenario diagram donat terkait, seperti menggunakan beberapa seri untuk membuat beberapa cincin, bekerja dengan diagram donat yang meledak, dan mengekspor diagram sebagai gambar raster atau SVG.

## **Tentukan Celah Tengah pada Diagram Donat**

Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah-langkah di bawah ini:

1. Instansiasi objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
2. Tambahkan diagram donat pada slide.
3. Tentukan ukuran lubang pada diagram donat.
4. Tulis presentasi ke disk.

Pada contoh di bawah ini, kami telah menentukan ukuran lubang pada diagram donat.

```php
  # Buat sebuah instance dari kelas Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Tulis presentasi ke disk
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat membuat donat berjenjang dengan beberapa cincin?**

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

**Apakah donat "exploded" (irisan terpisah) didukung?**

Ya. Terdapat tipe diagram Exploded Doughnut [chart type](https://reference.aspose.com/slides/id/php-java/aspose.slides/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan individual.

**Bagaimana saya dapat memperoleh gambar diagram donat (PNG/SVG) untuk laporan?**

Diagram adalah bentuk; Anda dapat merendernya ke [raster image](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage) atau mengekspor diagram ke [SVG image](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#writeAsSvg).