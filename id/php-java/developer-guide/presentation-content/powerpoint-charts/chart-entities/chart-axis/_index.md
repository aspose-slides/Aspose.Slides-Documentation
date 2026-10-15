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
- nilai maksimum
- nilai minimum
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Temukan cara menggunakan Aspose.Slides untuk PHP via Java untuk menyesuaikan sumbu diagram dalam presentasi PowerPoint untuk laporan dan visualisasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram dengan Aspose.Slides untuk PHP via Java. Artikel ini mencakup nilai sumbu yang dihitung, menukar baris dan kolom diagram, visibilitas sumbu, interval label kategori dan tanda‑tick, kategori tanggal dan formatnya, rotasi judul, penempatan sumbu, unit tampilan, dan skala logaritmik.

## **Dapatkan Nilai Maksimum pada Sumbu Vertikal pada Diagram**

Buat sebuah [Presentasi](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dan tambahkan diagram area dengan data default. Panggil [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) sebelum membaca nilai sumbu yang dihitung agar tata letak diagram terbaru.

Baca [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) dan [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) untuk batas sumbu, serta [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) dan [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) untuk interval tanda. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) dan [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) menyediakan skala satuan waktu, yang relevan untuk sumbu tanggal. Contoh ini menyimpan nilai‑nilai tersebut dalam variabel lokal dan menyimpan diagram.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tukar Data antara Sumbu**

Gunakan [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) untuk menukar peran seri dan kategori dalam data diagram. Setiap kategori sebelumnya menjadi seri, dan setiap seri sebelumnya menjadi kategori. Ini mengubah cara data dikelompokkan; tidak menukar sumbu horizontal dan vertikal. Contoh ini menggunakan [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) untuk mengikat data default ke `Sheet1!A1:D5`, termasuk baris header dan kolom kategori, sebelum menukar baris dan kolom. Diagram yang disimpan memiliki empat seri dan tiga kategori.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Balikkan Urutan Plotting pada Sumbu**

Gunakan [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) untuk membalikkan sumbu kategori atau nilai. Misalnya, diagram batang horizontal dapat menampilkan tahapan proyek dari atas ke bawah dalam urutan yang sama dengan lembar kerja: Perencanaan, Pengembangan, Pengujian. Membalikkan sumbu mengubah arah plotting; tidak mengurutkan atau menyusun ulang data buku kerja. Sebagai perbandingan, [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) menukar peran seri dan kategori.

Contoh berikut membuat diagram batang horizontal dengan tiga tahapan dan satu seri. Diagram ini menyimpan presentasi dengan tiga slide: urutan normal, kategori terbalik, dan nilai terbalik. Setiap salinan menggunakan set data yang sama, dan hanya satu sumbu yang dibalik pada setiap salinan.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // Slide 2: tampilkan kategori pertama di bagian atas.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Pertahankan sumbu nilai horizontal di bagian bawah.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // Slide 3: balikkan hanya skala numerik horizontal.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Membalikkan sumbu juga dapat memindahkan sumbu tegak lurus ke sisi berlawanan dari plot. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) mengontrol di mana sumbu lain memotong sumbu yang sedang dikonfigurasi. Pada slide 2, memanggilnya dengan `CrossesType::Maximum` pada sumbu kategori yang dibalik menjaga sumbu nilai horizontal di bagian bawah. Untuk titik perpotongan tertentu, gunakan [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Periksa pengaturan perpotongan saat mengubah arah, terutama bila diagram sudah memiliki titik perpotongan khusus. Panggil `setPlotOrderReversed` dengan `false` untuk mengembalikan arah plotting normal; pengaturan perpotongan bersifat terpisah.

| Urutan normal (slide 1) | Kategori terbalik (slide 2) | Nilai terbalik (slide 3) |
| --- | --- | --- |
| ![Diagram batang horizontal dengan urutan sumbu kategori dan nilai normal](axis-order-normal.png) | ![Diagram batang horizontal dengan kategori ditampilkan dari atas ke bawah](axis-order-categories-reversed.png) | ![Diagram batang horizontal dengan sumbu nilai terbalik dan nol di kanan](axis-order-values-reversed.png) |
| Kategori berjalan dari bawah ke atas; nilai meningkat dari kiri ke kanan. | Perencanaan, Pengembangan, dan Pengujian berjalan dari atas ke bawah. Nilai dan urutan baris buku kerja tidak berubah. | Kategori mempertahankan urutan normal; nilai meningkat dari kanan ke kiri. Sumbu kategori memotong pada nol di kanan. |

## **Nonaktifkan Sumbu Vertikal untuk Diagram Garis**

Panggil [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) dengan `false` pada sumbu vertikal untuk menyembunyikannya. Contoh ini membuat diagram garis dengan data default dan menyimpannya dengan sumbu vertikal disembunyikan.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nonaktifkan Sumbu Horizontal untuk Diagram Garis**

Panggil [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) dengan `false` pada sumbu horizontal untuk menyembunyikannya. Contoh ini membuat diagram garis dengan data default dan menyimpannya dengan sumbu horizontal disembunyikan.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ubah Sumbu Kategori**

Gunakan [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) untuk memilih sumbu kategori tanggal atau teks. Contoh ini memerlukan `ExistingChart.pptx`, dengan diagram sebagai bentuk pertama pada slide pertama dan sel kategori berisi nilai tanggal Excel numerik. Ini mengubah sumbu horizontal menjadi sumbu tanggal. Memanggil [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) dengan `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) dengan `1`, dan [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) dengan `TimeUnitType::Months` menempatkan tanda utama pada interval satu bulan.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontrol Interval Label Sumbu Kategori**

Ketika diagram memiliki banyak kategori, kurangi jumlah label sumbu yang terlihat tanpa menghapus kategori atau titik data. Panggil [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) dengan `false`, kemudian berikan interval kategori yang diinginkan ke [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Untuk kategori teks dalam urutan normal, penghitungan dimulai dari kategori pertama:

| Interval | Label yang ditampilkan dalam contoh |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

Interval `3` menampilkan setiap label ketiga, meninggalkan dua label tersembunyi di antara label yang ditampilkan. Ini tidak menghapus kolom yang bersesuaian. Penataan otomatis memilih interval berdasarkan ruang yang tersedia; tidak selalu menampilkan setiap label.

Tanda‑tick memiliki kontrol terpisah. Panggil [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) dengan `false` dan gunakan [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) untuk mengatur intervalnya. Misalnya, `1` menjaga tanda tick pada setiap interval kategori sementara label hanya muncul setiap kategori ketiga. Gunakan [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) dengan gaya yang terlihat agar Anda dapat melihat hasilnya. Memanggil salah satu pengatur penataan otomatis dengan `true` lagi memungkinkan diagram memilih interval tersebut kembali.

Contoh mandiri berikut membuat 24 kategori dan satu seri, kemudian menyimpan tiga slide dalam `CategoryAxisIntervals.pptx`: penataan otomatis, penataan label manual dengan tanda tick terpisah, dan pemulihan penataan otomatis. Kedua salinan mempertahankan data diagram asli. Tidak diperlukan presentasi input. Teks label horizontal memudahkan melihat perbedaan kepadatan.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Slide 2: tampilkan setiap label ketiga, tetapi pertahankan tanda tick untuk setiap kategori.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Slide 3: biarkan diagram memilih kedua interval lagi.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Penataan otomatis (slide 1):** Pada rendering ini, setiap label kategori kedua ditampilkan dan membungkus menjadi dua baris. Hasil otomatis dapat bervariasi tergantung ukuran diagram, font, dan renderer.

![Penataan otomatis label kategori dengan semua 24 kolom terlihat](category-axis-automatic.png)

**Penataan manual (slide 2):** Setiap label ketiga ditampilkan dalam satu baris, sementara tanda tick tetap pada setiap interval kategori. Semua 24 kolom, termasuk yang tanpa label, tetap terlihat dengan nilai yang sama. Slide 3 mengembalikan tampilan otomatis seperti di atas.

![Interval label kategori manual tiga dengan semua 24 kolom terlihat](category-axis-manual.png)

### **Pilih Sumbu dan Interval yang Tepat**

Gunakan interval hitungan kategori ini untuk sumbu kategori teks, seperti sumbu kategori pada diagram kolom, garis, area, atau batang. Pada diagram kolom, ini adalah sumbu horizontal. Pada diagram batang horizontal, sumbu kategori berada secara vertikal, jadi terapkan pengaturan ini pada sumbu yang dikembalikan oleh [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Penataan jarak tanda‑tick juga berlaku untuk sumbu seri pada diagram yang memilikinya.

Jangan gunakan penataan label kategori untuk mengatur skala numerik pada sumbu nilai. Pada sumbu nilai, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) menentukan perbedaan nilai: misalnya, unit utama `10` menghasilkan tanda pada 0, 10, 20, dan seterusnya ketika sumbu dimulai dari nol. Interval label kategori `3` menghitung posisi kategori, terlepas dari nilai data mereka. Diagram sebar dan gelembung menggunakan sumbu nilai bukan sumbu kategori teks. Untuk sumbu tanggal, gunakan unit utama berbasis waktu dan skala sebagaimana dijelaskan pada [Ubah Sumbu Kategori](#change-a-category-axis).

## **Atur Format Tanggal untuk Nilai Sumbu Kategori**

Contoh ini mengganti data diagram default dengan empat nilai tahunan. Tanggal disimpan sebagai nomor seri OLE Automation di lembar kerja pertama (indeks `0`), dihitung sebagai jumlah hari sejak 30 Desember 1899, untuk tanggal‑tanggal ini. Gunakan [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) dengan `CategoryAxisType::Date`, panggil [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) dengan `false`, dan berikan `yyyy` ke [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) agar label kategori menampilkan tahun empat digit secara independen dari format sel.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Sudut Rotasi untuk Judul Sumbu Diagram**

Panggil [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) dengan `true` pada sumbu vertikal, berikan teks judul, dan gunakan [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) untuk memutar judul. Sudut diukur dalam derajat; contoh ini menyimpan diagram kolom dengan judul sumbu nilai diputar 90 derajat.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Posisi Sumbu pada Sumbu Kategori atau Nilai**

Gunakan [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) untuk mengontrol apakah sumbu nilai memotong sumbu kategori di antara kategori atau pada tanda kategori. Pengaturan ini berlaku untuk sumbu kategori. Contoh ini mengaturnya ke `true` pada sumbu kategori horizontal diagram kolom dan menyimpan hasilnya.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Unit Tampilan pada Sumbu Nilai Diagram**

Gunakan [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) untuk menskalakan label pada sumbu nilai tanpa mengubah data mendasarnya. Dengan [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) diset ke `Millions`, nilai 60.000.000 ditampilkan sebagai 60. Contoh ini membuat diagram kolom dan menerapkan unit tampilan jutaan pada sumbu vertikalnya.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Konfigurasikan Sumbu Nilai Logaritmik**

Sumbu nilai logaritmik berguna ketika nilai positif mencakup beberapa orde magnitude. Misalnya, sebuah layanan mungkin menerima 10, 100, 1.000, 10.000, dan 100.000 permintaan selama lima periode. Pada skala linier, nilai kecil muncul berdekatan di dekat nol. Skala logaritmik membuat pertumbuhan relatif mereka lebih mudah dibandingkan: jarak yang sama mewakili rasio yang sama, bukan selisih yang sama.

Panggil [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) dengan `true` pada sumbu nilai dan gunakan [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) untuk memilih basis. Ini mengubah cara nilai yang ada ditampilkan; tidak mengubah data atau menambahkan garis tren logaritmik. Garis tren mewakili hubungan terpasang pada data dan merupakan fitur terpisah.

### **Pilih Sumbu Nilai dan Basis**

Untuk diagram garis atau kolom, sumbu nilai dikembalikan oleh [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Untuk diagram batang horizontal, dikembalikan oleh [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Diagram sebar dan gelembung memiliki dua sumbu nilai, jadi pilih sumbu horizontal untuk nilai X, sumbu vertikal untuk nilai Y, atau keduanya. Jangan terapkan skala logaritmik pada sumbu kategori.

Basis logaritmik default adalah `10`. Untuk diagram PPTX, gunakan basis dari `2` hingga `1000`, inklusif; basis pecahan seperti `2.5` juga didukung. Dengan basis `10`, pangkat berurutan seperti 10, 100, 1.000, dan 10.000 berjarak sama.

### **Bandingkan Skala Linear dan Logaritmik**

Contoh mandiri berikut membuat diagram garis dengan lima hitungan permintaan pada slide pertama, kemudian menggandakan slide tersebut dan mengaktifkan sumbu nilai logaritmik basis‑10 pada slide kedua. Kedua slide mempertahankan data yang sama.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Pertahankan slide pertama linier dan ubah hanya skala sumbu nilai pada salinannya.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Skala linear (slide 1):** Jarak vertikal yang sama mewakili selisih yang sama dalam hitungan permintaan. Nilai terbesar mendominasi diagram, membuat nilai kecil sulit dibedakan.

![Diagram garis di PowerPoint menampilkan lima hitungan permintaan pada sumbu nilai linear](value-axis-linear.png)

**Skala logaritmik (slide 2):** Jarak vertikal yang sama mewakili rasio yang sama. Setiap periode memiliki sepuluh kali lebih banyak permintaan daripada periode sebelumnya, sehingga titik‑titik membentuk garis naik lurus pada skala basis‑10. Label sumbu tetap menampilkan hitungan permintaan asli.

![Lima hitungan permintaan yang sama di PowerPoint pada sumbu nilai logaritmik basis-10](value-axis-logarithmic.png)

### **Tangani Nilai Nol dan Negatif**

Skala logaritmik hanya dapat menampilkan nilai yang benar‑benar positif. Periksa data sebelum mengaktifkannya. Jika nilai nol atau negatif memiliki makna, pertahankan skala linear atau tampilkan secara terpisah. Jika mengeluarkan nilai tersebut sesuai analisis, jelaskan penghapusannya. Jangan diam‑diam menggantinya dengan angka positif kecil, karena ini mengubah makna data. Setiap minimum atau maksimum yang dikonfigurasi secara manual untuk sumbu logaritmik juga harus positif.

## **FAQ**

**Bagaimana cara mengatur nilai di mana satu sumbu memotong sumbu lainnya (perpotongan sumbu)?**

Gunakan [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) untuk memilih perilaku perpotongan. Untuk menentukan nilai numerik perpotongan, gunakan [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Pengaturan ini memungkinkan Anda memindahkan perpotongan sumbu ke baseline yang sesuai.

**Bagaimana saya dapat memposisikan label tanda relatif terhadap sumbu?**

Panggil [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) menggunakan [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, atau `None`. Untuk mengontrol tanda‑tick itu sendiri, gunakan [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) atau [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); ini terpisah dari penempatan label.