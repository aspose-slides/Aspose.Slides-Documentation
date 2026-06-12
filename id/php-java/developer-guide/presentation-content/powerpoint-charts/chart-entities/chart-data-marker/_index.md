---
title: Kelola Penanda Data Diagram dalam Presentasi Menggunakan PHP
linktitle: Penanda Data
type: docs
url: /id/php-java/chart-data-marker/
keywords:
- diagram
- titik data
- penanda
- opsi penanda
- ukuran penanda
- tipe isian
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menyesuaikan penanda data diagram di Aspose.Slides untuk PHP, meningkatkan dampak presentasi pada format PPT dan PPTX dengan contoh kode yang jelas."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan penanda data diagram di Aspose.Slides. Ini menunjukkan cara membuat diagram, mengakses seri dan titik datanya, menerapkan isian gambar pada penanda di tingkat titik data, menyesuaikan ukuran penanda, dan menyimpan presentasi yang diperbarui. Artikel ini juga mencatat bahwa bentuk penanda standar tersedia melalui enumerasi `MarkerStyleType` dan tampilan penanda dipertahankan saat mengekspor diagram ke format raster atau SVG.

## **Setel Opsi Penanda Diagram**
Penanda dapat diatur pada titik data diagram di dalam seri tertentu. Untuk mengatur opsi penanda diagram, ikuti langkah-langkah berikut:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
- Membuat diagram default.
- Atur gambar.
- Ambil seri diagram pertama.
- Tambahkan titik data baru.
- Tuliskan presentasi ke disk.

Dalam contoh di bawah ini, kami telah mengatur opsi penanda diagram pada tingkat titik data.

```php
  # Membuat presentasi kosong
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Membuat diagram default
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Mendapatkan indeks WorkSheet data diagram default
    $defaultWorksheetIndex = 0;
    # Mendapatkan WorkSheet data diagram
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Menghapus seri demo
    $chart->getChartData()->getSeries()->clear();
    # Menambahkan seri baru
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Memuat gambar 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Memuat gambar 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Mengambil seri diagram pertama
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Menambahkan titik baru (1:3) di sana.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Mengubah penanda seri diagram
    $series->getMarker()->setSize(15);
    # Menyimpan presentasi dengan diagram
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bentuk penanda apa yang tersedia secara bawaan?**

Bentuk standar tersedia (lingkaran, kotak, belah ketupat, segitiga, dll.); daftarnya didefinisikan oleh kelas [MarkerStyleType](https://reference.aspose.com/slides/id/php-java/aspose.slides/markerstyletype/). Jika Anda memerlukan bentuk yang tidak standar, gunakan penanda dengan isian gambar untuk meniru visual khusus.

**Apakah penanda dipertahankan saat mengekspor diagram ke gambar atau SVG?**

Ya. Saat merender diagram ke [format raster](/slides/id/php-java/convert-powerpoint-to-png/) atau menyimpan [bentuk sebagai SVG](/slides/id/php-java/render-a-slide-as-an-svg-image/), penanda mempertahankan tampilan dan pengaturannya, termasuk ukuran, isian, dan garis tepi.