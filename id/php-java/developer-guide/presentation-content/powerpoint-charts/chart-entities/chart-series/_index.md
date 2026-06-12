---
title: Kelola Seri Data Diagram dalam Presentasi Menggunakan PHP
linktitle: Seri Data
type: docs
url: /id/php-java/chart-series/
keywords:
- seri diagram
- tumpang tindih seri
- warna seri
- warna kategori
- nama seri
- titik data
- celah seri
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengelola seri data diagram dalam PHP untuk PowerPoint (PPT/PPTX) dengan contoh kode praktis dan praktik terbaik untuk meningkatkan presentasi data Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan peran [ChartSeries](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseries/) di Aspose.Slides, dengan fokus pada bagaimana data disusun dan divisualisasikan dalam presentasi. Objek-objek ini menyediakan elemen dasar yang menentukan kumpulan titik data, kategori, dan parameter tampilan individu dalam sebuah diagram. Dengan menggunakan [ChartSeries](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseries/), pengembang dapat mengintegrasikan sumber data yang mendasarinya secara mulus dan mempertahankan kontrol penuh atas cara informasi ditampilkan, menghasilkan presentasi yang dinamis dan berbasis data yang dengan jelas menyampaikan wawasan dan analisis.

Sebuah seri adalah baris atau kolom angka yang digambarkan dalam diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Overlap Seri Diagram**

Dengan metode [getParentSeriesGroup](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseries/#getParentSeriesGroup), Anda dapat menentukan seberapa banyak batang dan kolom harus saling tumpang tindih pada diagram 2D (rentang: -100 hingga 100). Properti ini berlaku untuk semua seri dalam grup seri induk: ini adalah proyeksi dari properti grup yang sesuai. Oleh karena itu, properti ini hanya dapat dibaca.

Gunakan metode `ChartSeriesGroup::setOverlap` untuk mengatur nilai `Overlap` yang Anda inginkan.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Tambahkan diagram kolom berkelompok pada slide.
1. Akses seri diagram pertama.
1. Akses `ParentSeriesGroup` dari seri diagram dan atur nilai overlap yang Anda inginkan untuk seri tersebut.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

This PHP code shows you how to set the overlap for a chart series:

```php
  $pres = new Presentation();
  try {
    # Menambahkan diagram
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Menetapkan tumpang tindih seri
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Menulis file presentasi ke disk
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ubah Warna Seri**

Aspose.Slides untuk PHP via Java memungkinkan Anda mengubah warna seri dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Tambahkan diagram pada slide.
1. Akses seri yang warnanya ingin Anda ubah.
1. Atur tipe isian dan warna isian yang Anda inginkan.
1. Simpan presentasi yang telah dimodifikasi.

This PHP code shows you how to change a series' color:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ubah Warna Kategori Seri**

Aspose.Slides untuk PHP via Java memungkinkan Anda mengubah warna kategori seri dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Tambahkan diagram pada slide.
1. Akses kategori seri yang warnanya ingin Anda ubah.
1. Atur tipe isian dan warna isian yang Anda inginkan.
1. Simpan presentasi yang telah dimodifikasi.

This code  shows you how to change a series category's color:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ubah Nama Seri** 

Secara default, nama legenda untuk diagram berasal dari isi sel di atas setiap kolom atau baris data.

Dalam contoh kami (gambar contoh),

* kolom adalah *Series 1, Series 2,* dan *Series 3*;
* baris adalah *Category 1, Category 2, Category 3,* dan *Category 4.*

Aspose.Slides untuk PHP via Java memungkinkan Anda memperbarui atau mengubah nama seri dalam data diagram dan legendanya.

This PHP code shows you how to change a series' name in its chart data `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

This PHP code shows you how to change a series name in its legend through `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Warna Isian Seri Diagram**

Aspose.Slides untuk PHP via Java memungkinkan Anda mengatur warna isian otomatis untuk seri diagram di dalam area plot dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Dapatkan referensi slide dengan indeksnya.
1. Tambahkan diagram dengan data default berdasarkan tipe yang Anda pilih (pada contoh di bawah, kami menggunakan `ChartType::ClusteredColumn`).
1. Akses seri diagram dan atur warna isian menjadi Automatic.
1. Simpan presentasi ke file PPTX.

This PHP code shows you how to set the automatic fill color for a chart series:

```php
  $pres = new Presentation();
  try {
    # Membuat diagram kolom berkelompok
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Menetapkan format isian seri ke otomatis
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Menulis file presentasi ke disk
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Warna Isian Terbalik untuk Seri Diagram**

Aspose.Slides memungkinkan Anda mengatur warna isian terbalik untuk seri diagram di dalam area plot dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Dapatkan referensi slide dengan indeksnya.
1. Tambahkan diagram dengan data default berdasarkan tipe yang Anda pilih (pada contoh di bawah, kami menggunakan `ChartType::ClusteredColumn`).
1. Akses seri diagram dan atur warna isian menjadi invert.
1. Simpan presentasi ke file PPTX.

This PHP code demonstrates the operation:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Menambahkan seri dan kategori baru
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Mengambil seri diagram pertama dan mengisi data serinya.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Seri untuk Terbalik Saat Nilai Negatif**

Aspose.Slides memungkinkan Anda mengatur pembalikan melalui properti `IChartDataPoint.InvertIfNegative` dan `ChartDataPoint.InvertIfNegative`. Ketika pembalikan diatur menggunakan properti tersebut, titik data akan membalik warna ketika menerima nilai negatif.

This PHP code demonstrates the operation:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bersihkan Data Titik Spesifik**

Aspose.Slides untuk PHP via Java memungkinkan Anda membersihkan data `DataPoints` untuk seri diagram tertentu dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Dapatkan referensi diagram melalui indeksnya.
4. Iterasi semua `DataPoints` diagram dan atur `XValue` serta `YValue` menjadi null.
5. Bersihkan semua `DataPoints` untuk seri diagram tertentu.
6. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

This PHP code demonstrates the operation:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Lebar Celah Seri**

Aspose.Slides untuk PHP via Java memungkinkan Anda mengatur Lebar Celah (`GapWidth`) untuk sebuah seri melalui properti **`GapWidth`** dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Akses seri diagram mana saja.
1. Atur properti `GapWidth`.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

This code  shows you how to set a series' Gap Width:

```php
  # Membuat presentasi kosong
  $pres = new Presentation();
  try {
    # Mengakses slide pertama presentasi
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan diagram dengan data default
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Menetapkan indeks lembar data diagram
    $defaultWorksheetIndex = 0;
    # Mendapatkan lembar kerja data diagram
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Menambahkan seri
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Menambahkan Kategori
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Mengambil seri diagram kedua
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Mengisi data seri
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Menetapkan nilai GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Menyimpan presentasi ke disk
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah ada batasan jumlah seri yang dapat dimiliki satu diagram?**

Aspose.Slides tidak memberlakukan batas tetap pada jumlah seri yang Anda tambahkan. Batas praktis ditentukan oleh keterbacaan diagram dan memori yang tersedia untuk aplikasi Anda.

**Bagaimana jika kolom dalam sebuah klaster terlalu dekat atau terlalu jauh satu sama lain?**

Sesuaikan pengaturan `GapWidth` untuk seri tersebut (atau grup seri induknya). Meningkatkan nilai akan memperlebar ruang antar kolom, sementara menurunkannya akan mendekatkan kolom tersebut.