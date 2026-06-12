---
title: Sesuaikan Diagram Lingkaran dalam Presentasi Menggunakan PHP
linktitle: Diagram Lingkaran
type: docs
url: /id/php-java/pie-chart/
keywords:
- diagram lingkaran
- kelola diagram
- sesuaikan diagram
- opsi diagram
- pengaturan diagram
- opsi plot
- warna irisan
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram lingkaran dengan Aspose.Slides untuk PHP via Java, dapat diekspor ke PowerPoint, meningkatkan cara Anda menyampaikan data dalam hitungan detik."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram lingkaran (pie chart) di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram lingkaran standar.

Contoh-contoh berfokus pada langkah-langkah kustomisasi diagram praktis seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram default dengan kategori dan nilai khusus, serta menyimpan presentasi yang telah diperbarui.

## **Opsi Plot Kedua untuk Diagram Pie of Pie dan Bar of Pie**
Aspose.Slides for PHP via Java kini mendukung opsi plot kedua untuk diagram Pie of Pie atau Bar of Pie. Pada topik ini, kami akan menunjukkan cara menentukan opsi tersebut menggunakan Aspose.Slides. Untuk menentukan properti, lakukan hal berikut:

1. Buat instance objek kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Tambahkan diagram pada slide.
1. Tentukan opsi plot kedua pada diagram.
1. Tulis presentasi ke disk.

Dalam contoh di bawah ini, kami telah mengatur properti yang berbeda dari diagram Pie of Pie.

```php
  # Buat instance kelas Presentation
  $pres = new Presentation();
  try {
    # Tambahkan diagram pada slide
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Atur properti yang berbeda
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Tulis presentasi ke disk
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Warna Irisan Diagram Pie Secara Otomatis**
Aspose.Slides for PHP via Java menyediakan API sederhana untuk mengatur warna irisan diagram pie secara otomatis. Kode contoh menerapkan pengaturan properti tersebut.

1. Buat instance objek kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Atur Judul diagram.
1. Atur seri pertama untuk Menampilkan Nilai.
1. Atur indeks lembar data diagram.
1. Dapatkan lembar kerja data diagram.
1. Hapus seri dan kategori yang dihasilkan secara default.
1. Tambahkan kategori baru.
1. Tambahkan seri baru.

Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```php
  # Buat instance kelas Presentation
  $pres = new Presentation();
  try {
    # Tambahkan diagram dengan data default
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Mengatur Judul diagram
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Atur seri pertama untuk Menampilkan Nilai
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Mengatur indeks lembar data diagram
    $defaultWorksheetIndex = 0;
    # Mendapatkan lembar kerja data diagram
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Hapus seri dan kategori yang dihasilkan secara default
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Menambahkan kategori baru
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Menambahkan seri baru
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Sekarang mengisi data seri
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah variasi 'Pie of Pie' dan 'Bar of Pie' didukung?**

Ya, perpustakaan [mendukung](https://reference.aspose.com/slides/id/php-java/aspose.slides/charttype/) plot sekunder untuk diagram pie, termasuk tipe 'Pie of Pie' dan 'Bar of Pie'.

**Bisakah saya mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage) (seperti PNG) tanpa harus mengekspor seluruh presentasi.