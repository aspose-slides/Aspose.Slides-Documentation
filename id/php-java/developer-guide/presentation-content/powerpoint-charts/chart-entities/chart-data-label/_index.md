---
title: Kelola Label Data Grafik dalam Presentasi Menggunakan PHP
linktitle: Label Data
type: docs
url: /id/php-java/chart-data-label/
keywords:
- grafik
- label data
- presisi data
- persentase
- jarak label
- lokasi label
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data grafik dalam presentasi PowerPoint menggunakan Aspose.Slides untuk PHP via Java untuk slide yang lebih menarik."
---
## **Pendahuluan**

Label data menampilkan informasi tentang seri grafik dan titik data individual, membantu pembaca mengidentifikasi nilai dan memahami grafik. Artikel ini menjelaskan cara memformat nilai, menampilkan persentase, membaca teks label, mengontrol label di luar maksimum sumbu, menyesuaikan jarak label sumbu kategori, dan memposisikan label diagram lingkaran.

## **Atur Presisi Data pada Label Data Grafik**

Gunakan [setNumberFormatOfValues](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) untuk memformat nilai seri. Contoh ini membuat diagram garis dengan data default, menampilkan tabel datanya, dan mengaktifkan label nilai untuk seri pertama. Format `#,##0.00` menampilkan pemisah ribuan dan dua tempat desimal tanpa mengubah nilai dasar.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tampilkan Persentase sebagai Label**

Untuk diagram kolom bertumpuk, hitung setiap nilai sebagai persentase dari total kategori dan tetapkan teksnya ke frame teks yang dikembalikan oleh [getTextFrameForOverriding](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabel/#getTextFrameForOverriding). Contoh ini menggunakan data grafik default dan menampilkan persentase dengan dua tempat desimal dalam font 8 poin. Kategori dengan total nol dilewati untuk menghindari pembagian dengan nol. Hitung ulang teks label khusus jika data grafik berubah.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Tanda Persen dengan Label Data Grafik**

Ketika nilai disimpan sebagai pecahan, gunakan [setNumberFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat/#setNumberFormat) untuk menampilkan persentase. Berikan `false` ke [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) agar format label diterapkan secara independen dari sel sumber.

Contoh ini membuat diagram kolom bertumpuk 100 % dengan seri merah dan biru pada empat kategori. Setiap pasangan nilai menjumlahkan menjadi 1. Format label `0.0%` menampilkan 0.30 sebagai 30.0 %, sementara sumbu vertikal menggunakan dua tempat desimal. Kedua seri menggunakan teks label putih berukuran 10 poin.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Baca Teks Aktual dari Label Data**

Gunakan [getActualLabelText](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabel/#getActualLabelText) untuk mengambil teks yang dihasilkan oleh pengaturan label data. Ini berguna saat mengekstrak label untuk laporan, mencari konten presentasi, atau memvalidasi grafik yang dihasilkan. Pada contoh di bawah, [format label data](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat/) default menggabungkan setiap nama kategori, nama seri, dan nilai. Satu titik memformat nilainya sebagai persentase, dan titik lain menggunakan teks khusus dari [getTextFrameForOverriding](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Angka yang disimpan dalam titik data tetap `0.75`, meskipun labelnya menampilkan `75%` bersama nama kategori dan seri. Teks khusus menggantikan teks label yang dihasilkan. [getActualLabelText](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabel/#getActualLabelText) mengembalikan string label hasil dalam kedua kasus. Periksa [isVisible](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabel/#isVisible) secara terpisah, seperti yang ditunjukkan di atas, ketika Anda hanya ingin mengekstrak label yang terlihat.

## **Kendalikan Label Data di Luar Maksimum Sumbu**

Ketika Anda membatasi rentang sumbu secara manual, beberapa titik data mungkin melampaui maksimum. Gunakan [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) untuk mengontrol apakah label data mereka ditampilkan. Pengaturan ini mengubah visibilitas label; tidak mengubah rentang sumbu atau nilai data yang mendasarinya.

Contoh di bawah membuat diagram kolom berkelompok 2D dengan nilai 60 dan 120. Ia memberikan `false` ke [setAutomaticMaxValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/#setAutomaticMaxValue) dan menetapkan maksimum menjadi 100 dengan [setMaxValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/#setMaxValue) pada sumbu vertikal. Slide pertama memungkinkan label di luar maksimum; salinan slide itu menonaktifkannya. Kedua slide disimpan dalam `DataLabelsOverMaximum.pptx`.

Aktifkan label nilai dengan [setShowValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat/#setShowValue). Pengaturan tingkat diagram tidak mengaktifkan tampilan nilai secara otomatis atau menimpa tampilan nilai yang dinonaktifkan pada label individu. Contoh ini mengaktifkan nilai untuk seluruh seri dan menggunakan [setPosition](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat/#setPosition) untuk menempatkan label di ujung luar setiap kolom.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gambar berikut menunjukkan slide yang disimpan dan dirender oleh Microsoft PowerPoint. Dengan `true`, label **120** terlihat pada batas atas; dengan `false`, label tersebut disembunyikan. Label **60** tetap terlihat, maksimum sumbu tetap **100**, dan titik data kedua tetap **120** dalam kedua kasus.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Diagram PowerPoint menampilkan label nilai 120 dengan maksimum sumbu 100](data-labels-over-maximum-true.png) | ![Diagram PowerPoint menyembunyikan label nilai 120 dengan maksimum sumbu 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Contoh ini menggunakan diagram kolom 2D dengan sumbu nilai. Diagram tanpa sumbu nilai, seperti diagram lingkaran dan donat, tidak memiliki maksimum sumbu untuk dibatasi dengan cara ini.
{{% /alert %}}

## **Atur Jarak Label dari Sumbu**

Gunakan [setLabelOffset](https://reference.aspose.com/slides/id/php-java/aspose.slides/axis/#setLabelOffset) untuk mengontrol jarak antara label sumbu kategori dan sumbu. Nilainya merupakan persentase dari ukuran font maksimum label sumbu. Contoh ini membuat diagram kolom berkelompok dan menetapkan offset label sumbu horizontal menjadi 500. Pengaturan ini memengaruhi label sumbu kategori, bukan label yang terlampir pada titik data individu.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sesuaikan Lokasi Label**

Pada diagram lingkaran, sesuaikan posisi label data untuk memperbaiki jarak dan memberi ruang bagi garis pemimpin.

Contoh ini menampilkan nilai titik data pertama, menempatkan labelnya di luar irisan, dan menyesuaikan offset horizontal serta vertikal menggunakan [setX](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabel/#setX) dan [setY](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabel/#setY). Offset ini relatif terhadap lebar dan tinggi diagram, masing‑-masing.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Diagram lingkaran dengan posisi label data yang disesuaikan](pie-chart-adjusted-label.png)

## **FAQ**

**Bagaimana saya dapat mencegah label data saling tumpang pada grafik yang padat?**

Gabungkan penempatan label otomatis, garis pemimpin, dan ukuran font yang diperkecil; jika diperlukan, sembunyikan beberapa bidang (misalnya kategori) atau tampilkan label hanya untuk nilai ekstrem atau titik kunci.

**Bagaimana saya dapat menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**

Saring titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai yang hilang sesuai aturan yang ditetapkan.

**Bagaimana saya dapat memastikan gaya label konsisten saat mengekspor ke PDF/gambar?**

Tetapkan secara eksplisit keluarga dan ukuran font serta verifikasi bahwa font tersedia di lingkungan rendering untuk menghindari fallback.