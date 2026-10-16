---
title: Menambahkan Garis Tren ke Diagram Presentasi dalam PHP
linktitle: Garis Tren
type: docs
url: /id/php-java/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linier
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren pangkat
- garis tren khusus
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Tambahkan dan sesuaikan garis tren dengan cepat pada diagram PowerPoint menggunakan Aspose.Slides untuk PHP via Java — panduan praktis untuk menarik perhatian audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linier, logaritmik, rata‑rata bergerak, polinomial, dan pangkat.

Artikel ini juga menjelaskan cara menambahkan garis khusus ke diagram dengan menyisipkan bentuk garis, dan menyertakan FAQ singkat tentang nilai proyeksi garis tren ke depan dan ke belakang serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan ketika merender diagram sebagai gambar.

## **Menambahkan Garis Tren**

Gunakan [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) untuk menambahkan garis tren ke seri diagram, memilih tipenya dengan [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). Contoh ini membuat diagram kolom terkelompok dengan data default dan menambahkan dua garis tren ke masing‑masing tiga serinya.

Garis tren eksponensial menyembunyikan persamaan dan nilai R‑squared melalui [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) dan [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), sementara garis tren linier berwarna merah. Garis tren logaritmik menggunakan [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) untuk label khusus. Rata‑rata bergerak menggunakan [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) dengan tiga titik data dan [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/) khusus.

Garis tren polinomial memiliki orde tiga, diatur melalui [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), dan memperluas satu kategori ke depan melalui [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). Garis tren pangkat memperluas satu kategori ke belakang melalui [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mengatur Intersep Garis Tren**

Gunakan [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) untuk menetapkan nilai Y garis tren pada X = 0. Pengaturan ini didukung untuk garis tren linier, eksponensial, dan polinomial.

Sebagai contoh, model biaya produksi mungkin perlu dimulai dengan biaya tetap yang diketahui sebesar 100, bahkan ketika pengukuran pada volume produksi non‑nol menunjukkan baseline yang berbeda. Untuk garis tren linier, menetapkan intersep membatasi persamaan `y = ax + b` menjadi `b = 100`; kemiringan dioptimalkan terhadap data dengan batasan tersebut. Ini tidak sekadar memindahkan garis yang sudah dioptimalkan. Pengaturan perpotongan sumbu mengontrol di mana sumbu diagram bertemu, bukan koefisien garis tren yang dioptimalkan.

Contoh berikut membuat diagram sebar (XY) dengan volume produksi dari 1 hingga 4 dan biaya 170, 200, 230, dan 260. Diagram disimpan dengan intersep otomatis default, kemudian intersep diatur menjadi 100, dan disimpan sebagai PPTX kedua. Kedua file hanya berbeda pada pengaturan intersep. Garis tren menampilkan persamaannya dan memperpanjang kembali ke X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dengan perhitungan otomatis, data ini menghasilkan `y = 30x + 140`. Mengatur intersep menjadi 100 menghasilkan kira‑kira `y = 43.33x + 100`: nilai yang dipasang pada nol cocok dengan baseline yang diketahui, sementara garis tidak lagi melewati setiap titik data.

| Intercept Otomatis | Intercept Tetap 100 |
| --- | --- |
| ![Garis tren linier dengan intersep yang dihitung otomatis sebesar 140](intercept-automatic.png) | ![Garis tren linier dengan intersep tetap sebesar 100](intercept-fixed.png) |

Kedua gambar menggunakan data dan skala sumbu yang sama. Garis tren diperpanjang kembali ke X = 0 untuk menunjukkan intersepsnya.

Secara default, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) mengembalikan `NaN`, yang mewakili intersep yang tidak ditentukan bukan nol. Intersep kemudian dihitung secara otomatis dari data.

## **Menambahkan Garis Khusus**

Garis khusus adalah bentuk yang digambar di atas diagram, bukan garis tren yang dihitung dari data seri. Contoh ini menggunakan [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) untuk menambahkan garis horizontal ke slide di atas diagram. Posisi garis ditentukan dalam koordinat slide, diukur dalam poin, sehingga mulai dari tepi kiri diagram dan berada di tengah tinggi diagram. Lebar garis sama dengan lebar diagram. [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) memberikan warna merah solid pada garis.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apa arti 'forward' dan 'backward' pada sebuah garis tren?**

Mereka adalah panjang garis tren yang diproyeksikan ke depan/ke belakang: untuk diagram sebar (XY) — dalam satuan sumbu; untuk diagram non‑sebar — dalam jumlah kategori. Hanya nilai non‑negatif yang diizinkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/) atau [SVG](/slides/id/php-java/render-a-slide-as-an-svg-image/) dan merender diagram menjadi gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Sebuah metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/php-java/create-shape-thumbnails/) itu sendiri.