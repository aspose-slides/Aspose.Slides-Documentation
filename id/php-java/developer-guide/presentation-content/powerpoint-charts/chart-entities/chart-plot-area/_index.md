---
title: Sesuaikan Area Plot pada Diagram Presentasi di PHP
linktitle: Area Plot
type: docs
url: /id/php-java/chart-plot-area/
keywords:
- diagram
- area plot
- lebar area plot
- tinggi area plot
- ukuran area plot
- mode tata letak
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Temukan cara menyesuaikan area plot diagram dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java. Tingkatkan visual slide Anda dengan mudah."
---
## **Ikhtisar**

Artikel ini menunjukkan cara bekerja dengan area plot pada diagram di Aspose.Slides. Artikel ini menjelaskan cara mendapatkan posisi dan ukuran aktual area plot dengan memvalidasi tata letak diagram dan kemudian membaca nilai X, Y, lebar, dan tinggi‑nya.

Artikel ini juga mendemonstrasikan cara mengkonfigurasi mode tata letak area plot ketika tata letak diatur secara manual, menggunakan `LayoutTargetType` untuk menentukan apakah area plot dihitung berdasarkan wilayah dalamnya atau berdasarkan wilayah luar beserta sumbu dan label sumbu.

## **Dapatkan Lebar dan Tinggi Area Plot Diagram**
Aspose.Slides for PHP via Java menyediakan API sederhana untuk .  

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Panggil metode [Chart.validateChartLayout](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/validatechartlayout/) terlebih dahulu untuk memperoleh nilai aktual.
5. Dapatkan lokasi X aktual (kiri) elemen diagram relatif terhadap sudut kiri atas diagram.
6. Dapatkan posisi atas aktual elemen diagram relatif terhadap sudut kiri atas diagram.
7. Dapatkan lebar aktual elemen diagram.
8. Dapatkan tinggi aktual elemen diagram.

```php
  # Buat instance kelas Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Mode Tata Letak Area Plot Diagram**
Aspose.Slides for PHP via Java menyediakan API sederhana untuk mengatur mode tata letak area plot diagram. Metode [**setLayoutTargetType**](https://reference.aspose.com/slides/id/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) dan [**getLayoutTargetType**](https://reference.aspose.com/slides/id/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) telah ditambahkan ke kelas [**ChartPlotArea**](https://reference.aspose.com/slides/id/php-java/aspose.slides/ChartPlotArea). Jika tata letak area plot didefinisikan secara manual, properti ini menentukan apakah area plot ditata berdasarkan bagian dalamnya (tanpa menyertakan sumbu dan label sumbu) atau bagian luarnya (menyertakan sumbu dan label sumbu). Ada dua nilai yang mungkin yang didefinisikan dalam enum [**LayoutTargetType**](https://reference.aspose.com/slides/id/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/id/php-java/aspose.slides/LayoutTargetType#Inner) – menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tidak termasuk tanda centang dan label sumbu.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/id/php-java/aspose.slides/LayoutTargetType#Outer) – menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tanda centang, dan label sumbu.

Contoh kode diberikan di bawah ini.

```php
  # Buat instance kelas Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Dalam satuan apa x aktual, y aktual, lebar aktual, dan tinggi aktual dikembalikan?**

Dalam poin; 1 inci = 72 poin. Ini adalah satuan koordinat Aspose.Slides.

**Bagaimana perbedaan antara Plot Area dan Chart Area dalam hal konten?**

Plot Area adalah wilayah menggambar data (seri, garis kisi, garis tren, dll.); Chart Area mencakup elemen di sekitarnya (judul, legenda, dll.). Pada diagram 3D, Plot Area juga mencakup dinding/lantai dan sumbu.

**Bagaimana x, y, lebar, dan tinggi Plot Area ditafsirkan ketika tata letak diatur secara manual?**

Mereka adalah pecahan (0–1) dari ukuran keseluruhan diagram; dalam mode ini, penempatan otomatis dinonaktifkan dan pecahan yang Anda tentukan akan digunakan.

**Mengapa posisi Plot Area berubah setelah menambahkan/memindahkan legenda?**

Legenda berada di Chart Area di luar Plot Area tetapi memengaruhi tata letak dan ruang yang tersedia, sehingga Plot Area dapat bergeser ketika penempatan otomatis aktif. (Ini merupakan perilaku standar untuk diagram PowerPoint.)