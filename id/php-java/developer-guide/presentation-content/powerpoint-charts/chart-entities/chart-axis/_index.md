---
title: Sesuaikan Sumbu Diagram dalam Presentasi Menggunakan PHP
linktitle: Sumbu Diagram
type: docs
url: /id/php-java/chart-axis/
keywords:
- sumbu diagram
- sumbu vertikal
- sumbu horizontal
- sesuaikan sumbu
- manipulasi sumbu
- kelola sumbu
- properti sumbu
- nilai maks
- nilai min
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Temukan cara menggunakan Aspose.Slides for PHP via Java untuk menyesuaikan sumbu diagram dalam presentasi PowerPoint untuk laporan dan visualisasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram di Aspose.Slides. Artikel ini menunjukkan cara mendapatkan nilai sumbu yang sebenarnya, menukar data antara sumbu, menyembunyikan sumbu vertikal atau horizontal untuk diagram garis, mengubah tipe sumbu kategori, mengatur format tanggal untuk nilai sumbu kategori, memutar judul sumbu, mengatur posisi sumbu, dan menampilkan label satuan pada sumbu nilai.

## **Dapatkan Nilai Maksimum pada Sumbu Vertikal pada Diagram**
Aspose.Slides for PHP via Java memungkinkan Anda memperoleh nilai minimum dan maksimum pada sumbu vertikal. Ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Dapatkan nilai maksimum aktual pada sumbu.
5. Dapatkan nilai minimum aktual pada sumbu.
6. Dapatkan satuan utama aktual dari sumbu.
7. Dapatkan satuan minor aktual dari sumbu.
8. Dapatkan skala satuan utama aktual dari sumbu.
9. Dapatkan skala satuan minor aktual dari sumbu.

Kode contoh ini—implementasi dari langkah-langkah di atas—menunjukkan cara mendapatkan nilai yang diperlukan :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Menyimpan presentasi
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menukar Data antara Sumbu**
Aspose.Slides memungkinkan Anda dengan cepat menukar data antara sumbu—data yang ditampilkan pada sumbu vertikal (y‑axis) dipindahkan ke sumbu horizontal (x‑axis) dan sebaliknya. 

Kode PHP ini menunjukkan cara melakukan tugas menukar data antara sumbu pada diagram:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Menukar baris dan kolom
    $chart->getChartData()->switchRowColumn();
    # Menyimpan presentasi
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nonaktifkan Sumbu Vertikal untuk Diagram Garis**

Kode PHP ini menunjukkan cara menyembunyikan sumbu vertikal untuk diagram garis:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nonaktifkan Sumbu Horizontal untuk Diagram Garis**

Kode ini menunjukkan cara menyembunyikan sumbu horizontal untuk diagram garis:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ubah Sumbu Kategori**

Menggunakan properti **CategoryAxisType**, Anda dapat menentukan tipe sumbu kategori yang diinginkan (**date** atau **text**). Kode ini menunjukkan operasinya:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Atur Format Tanggal untuk Nilai Sumbu Kategori**
Aspose.Slides for PHP via Java memungkinkan Anda mengatur format tanggal untuk nilai sumbu kategori. Operasi ini ditunjukkan dalam kode PHP berikut:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Atur Sudut Rotasi untuk Judul Sumbu Diagram**
Aspose.Slides for PHP via Java memungkinkan Anda mengatur sudut rotasi untuk judul sumbu diagram. Kode PHP ini menunjukkan operasinya:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Posisi Sumbu pada Sumbu Kategori atau Nilai**
Aspose.Slides for PHP via Java memungkinkan Anda mengatur posisi sumbu pada sumbu kategori atau nilai. Kode PHP ini menunjukkan cara melakukan tugas tersebut:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aktifkan Label Satuan Tampilan pada Sumbu Nilai Diagram**
Aspose.Slides for PHP via Java memungkinkan Anda mengonfigurasi diagram agar menampilkan label satuan pada sumbu nilai diagramnya. Kode PHP ini menunjukkan operasinya:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bagaimana cara mengatur nilai di mana satu sumbu memotong sumbu lainnya (persilangan sumbu)?**

Sumbu menyediakan [pengaturan persilangan](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/setcrosstype/): Anda dapat memilih untuk memotong pada nol, pada kategori/nilai maksimum, atau pada nilai numerik tertentu. Ini berguna untuk menggeser sumbu X ke atas atau ke bawah atau untuk menekankan garis dasar.

**Bagaimana cara memposisikan label tanda pada sumbu relatif terhadap sumbu (sebelah, di luar, di dalam)?**

Atur [posisi label](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/setmajortickmark/) ke “cross”, “outside”, atau “inside”. Ini memengaruhi keterbacaan dan membantu menghemat ruang, terutama pada diagram kecil.