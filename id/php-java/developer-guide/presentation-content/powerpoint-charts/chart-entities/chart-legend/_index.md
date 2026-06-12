---
title: "Sesuaikan Legenda Grafik dalam Presentasi Menggunakan PHP"
linktitle: "Legenda Grafik"
type: docs
url: /id/php-java/chart-legend/
keywords:
- legenda grafik
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Sesuaikan legenda grafik dengan Aspose.Slides untuk PHP via Java guna mengoptimalkan presentasi PowerPoint dengan format legenda yang disesuaikan."
---
## **Ikhtisar**

Aspose.Slides menyediakan pilihan untuk menyesuaikan legenda grafik dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, dan menerapkan pemformatan pada entri legenda individual.

Ini juga mencakup beberapa perilaku terkait dalam FAQ, termasuk menggunakan mode non-overlay sehingga area plot memberikan ruang untuk legenda, memungkinkan label legenda yang panjang membungkus atau menggunakan jeda baris, dan membiarkan format legenda mewarisi dari tema presentasi ketika pengaturan teks dan isi yang eksplisit tidak diterapkan.

## **Penempatan Legenda**
Untuk mengatur properti legenda, ikuti langkah-langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
- Dapatkan referensi slide.
- Menambahkan grafik pada slide.
- Mengatur properti legenda.
- Tulis presentasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah mengatur posisi dan ukuran untuk legenda Chart.

```php
  # Buat instance kelas Presentation
  $pres = new Presentation();
  try {
    # Dapatkan referensi slide
    $slide = $pres->getSlides()->get_Item(0);
    # Tambah diagram kolom terkelompok pada slide
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Atur properti Legenda
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Tulis presentasi ke disk
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Ukuran Font Legenda**
The Aspose.Slides for PHP via Java memungkinkan pengembang untuk mengatur ukuran font legenda. Ikuti langkah-langkah berikut:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
- Membuat grafik default.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Tulis presentasi ke disk.

```php
  # Buat instance kelas Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Ukuran Font Legenda Individual**
The Aspose.Slides for PHP via Java memungkinkan pengembang untuk mengatur ukuran font entri legenda individual. Ikuti langkah-langkah berikut:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
- Membuat grafik default.
- Akses entri legenda.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Tulis presentasi ke disk.

```php
  # Buat instance kelas Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat mengaktifkan legenda sehingga grafik secara otomatis menyediakan ruang untuknya alih-alih menimpanya?**

Ya. Gunakan mode non-overlay ([setOverlay(false)](https://reference.aspose.com/slides/id/php-java/aspose.slides/legend/setoverlay/)); dalam kasus ini, area plot akan menyusut untuk menampung legenda.

**Apakah saya dapat membuat label legenda multi-baris?**

Ya. Label yang panjang akan otomatis membungkus ketika ruang tidak cukup; jeda baris paksa didukung melalui karakter newline dalam nama seri.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Jangan mengatur warna/isi/font secara eksplisit untuk legenda atau teksnya. Mereka akan mewarisi dari tema dan memperbarui dengan benar ketika desain berubah.