---
title: Ekspor Diagram Presentasi dalam PHP
linktitle: Ekspor Diagram
type: docs
weight: 90
url: /id/php-java/export-chart/
keywords:
- diagram
- diagram ke gambar
- diagram sebagai gambar
- ekstrak gambar diagram
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengekspor diagram presentasi dengan Aspose.Slides untuk PHP via Java, mendukung format PPT dan PPTX, serta mempermudah pelaporan ke dalam alur kerja apa pun."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengekspor diagram dari presentasi sebagai gambar. Artikel ini menunjukkan cara mengambil gambar dari diagram dan menyimpannya, yang berguna ketika Anda perlu menggunakan kembali visual diagram di luar presentasi PowerPoint.

## **Dapatkan Gambar Diagram**

Aspose.Slides untuk PHP via Java menyediakan dukungan untuk mengekstrak gambar dari diagram tertentu. Contoh sampel di bawah ini diberikan.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat mengekspor diagram sebagai vektor (SVG) alih-alih gambar raster?**

Ya. Diagram adalah sebuah bentuk, dan isinya dapat disimpan ke SVG menggunakan [metode penyimpanan shape-to-SVG](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/writeassvg/).

**Bagaimana saya dapat mengatur ukuran pasti diagram yang diekspor dalam piksel?**

Gunakan overload rendering gambar yang memungkinkan Anda menentukan ukuran atau skala—perpustakaan mendukung rendering objek dengan dimensi/skala yang diberikan.

**Apa yang harus saya lakukan jika font pada label dan legenda terlihat salah setelah ekspor?**

[Muat font yang diperlukan](/slides/id/php-java/custom-font/) melalui [FontsLoader](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/) sehingga rendering diagram mempertahankan metrik dan tampilan teks.

**Apakah ekspor menghormati tema, gaya, dan efek PowerPoint?**

Ya. Renderer Aspose.Slides mengikuti pemformatan presentasi (tema, gaya, isi, efek), sehingga tampilan diagram dipertahankan.

**Di mana saya dapat menemukan kemampuan rendering/ekspor yang tersedia selain gambar diagram?**

Lihat [API](https://reference.aspose.com/slides/id/php-java/aspose.slides/)/[dokumentasi](/slides/id/php-java/convert-powerpoint/) untuk target output ([PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/id/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/id/php-java/convert-powerpoint-to-xps/), [HTML](/slides/id/php-java/convert-powerpoint-to-html/), dll.) dan opsi rendering terkait.