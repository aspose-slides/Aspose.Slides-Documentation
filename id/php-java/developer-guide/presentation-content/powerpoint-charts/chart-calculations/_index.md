---
title: Optimalkan Perhitungan Bagan untuk Presentasi di PHP
linktitle: Perhitungan Bagan
type: docs
weight: 50
url: /id/php-java/chart-calculations/
keywords:
- perhitungan bagan
- elemen bagan
- posisi elemen
- posisi sebenarnya
- elemen anak
- elemen induk
- nilai bagan
- nilai sebenarnya
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pahami perhitungan bagan, pembaruan data, dan kontrol presisi dalam Aspose.Slides untuk PHP via Java untuk PPT dan PPTX, dengan contoh kode praktis."
---
## **Gambaran Umum**

Aspose.Slides menyediakan API untuk bekerja dengan perhitungan bagan dan data tata letak dalam presentasi. Artikel ini menunjukkan cara mengambil nilai sebenarnya dari elemen bagan, termasuk posisi dan ukuran nyata elemen serta nilai sebenarnya dari sumbu bagan. Artikel ini juga menjelaskan bahwa nilai-nilai tersebut diisi setelah validasi tata letak bagan.

Selain itu, artikel ini menunjukkan cara mendapatkan posisi sebenarnya dari elemen bagan induk dan cara menyembunyikan komponen bagan seperti judul, sumbu, legenda, dan garis kisi. Bersama-sama, contoh-contoh ini membantu Anda memeriksa informasi tata letak bagan dan mengendalikan visibilitas elemen bagan dalam presentasi PowerPoint secara programatik.

## **Hitung Nilai Sebenarnya dari Elemen Bagan**
Aspose.Slides for PHP via Java menyediakan API sederhana untuk mendapatkan properti ini. Metode-metode dari kelas [Axis](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/) memberikan informasi tentang posisi sebenarnya dari elemen sumbu bagan ([getActualMaxValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/getactualminorunitscale/)). Perlu memanggil metode [Chart.validateChartLayout](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/validatechartlayout/) terlebih dahulu untuk mengisi properti dengan nilai sebenarnya.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hitung Posisi Sebenarnya dari Elemen Bagan Induk**
Aspose.Slides for PHP via Java menyediakan API sederhana untuk mendapatkan properti ini. Metode-metode dari kelas `ActualLayout` memberikan informasi tentang posisi sebenarnya dari elemen bagan induk (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Perlu memanggil metode [Chart.validateChartLayout](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/validatechartlayout/) terlebih dahulu untuk mengisi properti dengan nilai sebenarnya.

```php
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

## **Sembunyikan Elemen Bagan**
Topik ini membantu Anda memahami cara menyembunyikan informasi dari bagan. Menggunakan Aspose.Slides for PHP via Java Anda dapat menyembunyikan **Title, Vertical Axis, Horizontal Axis** dan **Grid Lines** dari bagan. Contoh kode di bawah ini menunjukkan cara menggunakan properti tersebut.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Menyembunyikan judul bagan
    $chart->setTitle(false);
    # /Menyembunyikan sumbu Nilai
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Visibilitas sumbu Kategori
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Menyembunyikan legenda
    $chart->setLegend(false);
    # Menyembunyikan Garis Kisi Utama
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Menetapkan warna garis seri
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah buku kerja Excel eksternal dapat digunakan sebagai sumber data, dan bagaimana hal itu memengaruhi perhitungan ulang?**

Ya. Sebuah bagan dapat merujuk ke buku kerja eksternal: ketika Anda menghubungkan atau menyegarkan sumber eksternal, rumus dan nilai diambil dari buku kerja tersebut, dan bagan mencerminkan pembaruan selama operasi buka/edit. API memungkinkan Anda [menentukan buku kerja eksternal](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/setexternalworkbook/) path dan mengelola data yang ditautkan.

**Apakah saya dapat menghitung dan menampilkan garis tren tanpa mengimplementasikan regresi sendiri?**

Ya. [Trendlines](/slides/id/php-java/trend-line/) (linear, eksponensial, dan lainnya) ditambahkan dan diperbarui oleh Aspose.Slides; parameternya dihitung kembali dari data seri secara otomatis, sehingga Anda tidak perlu mengimplementasikan perhitungan Anda sendiri.

**Jika sebuah presentasi memiliki beberapa bagan dengan tautan eksternal, apakah saya dapat mengontrol buku kerja mana yang digunakan setiap bagan untuk nilai yang dihitung?**

Ya. Setiap bagan dapat menunjuk ke [buku kerja eksternal](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/setexternalworkbook/) miliknya sendiri, atau Anda dapat membuat/mengganti buku kerja eksternal per bagan secara terpisah dari yang lain.