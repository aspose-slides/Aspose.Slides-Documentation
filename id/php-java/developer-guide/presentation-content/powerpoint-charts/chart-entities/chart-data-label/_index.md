---
title: Kelola Label Data Diagram dalam Presentasi Menggunakan PHP
linktitle: Label Data
type: docs
url: /id/php-java/chart-data-label/
keywords:
- diagram
- label data
- presisi data
- persentase
- jarak label
- lokasi label
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk PHP via Java untuk slide yang lebih menarik."
---
## **Pendahuluan**

Label data menampilkan informasi tentang seri diagram dan titik data individu, membantu pembaca mengidentifikasi nilai dan memahami diagram. Artikel ini menjelaskan cara memformat nilai, menampilkan persentase, membaca teks label, mengendalikan label di luar maksimum sumbu, menyesuaikan jarak label sumbu kategori, dan memposisikan label diagram lingkaran.

## **Atur Presisi Data pada Label Data Diagram**

Gunakan [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) untuk memformat nilai seri. Contoh ini membuat diagram garis dengan data default, menampilkan tabel datanya, dan mengaktifkan label nilai untuk seri pertama. Format `#,##0.00` menampilkan pemisah ribuan dan dua tempat desimal tanpa mengubah nilai dasar.

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

Untuk diagram kolom bertumpuk, hitung setiap nilai sebagai persentase dari total kategori masing‑masing dan tetapkan teks ke frame teks yang dikembalikan oleh [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/). Contoh ini menggunakan data diagram default dan menampilkan persentase dengan dua tempat desimal dalam font 8 poin. Kategori dengan total nol dilewati untuk menghindari pembagian dengan nol. Hitung ulang teks label khusus jika data diagram berubah.

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

## **Atur Tanda Persen dengan Label Data Diagram**

Ketika nilai disimpan sebagai pecahan, gunakan [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) untuk menampilkan persentase. Berikan `false` ke [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) agar format label diterapkan secara independen dari sel sumber. Contoh ini membuat diagram kolom bertumpuk 100% dengan seri merah dan biru pada empat kategori. Setiap pasangan nilai menjumlah menjadi 1. Format label `0.0%` menampilkan 0.30 sebagai 30.0%, sementara sumbu vertikal menggunakan dua tempat desimal. Kedua seri menggunakan teks label putih berukuran 10 poin.

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

## **Baca Teks Sebenarnya dari Label Data**

Gunakan [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) untuk mengambil teks yang dihasilkan oleh pengaturan label data. Ini berguna saat mengekstrak label untuk laporan, mencari konten presentasi, atau memvalidasi diagram yang dihasilkan. Dalam contoh di bawah, [format label data](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) default menggabungkan setiap nama kategori, nama seri, dan nilai. Satu titik memformat nilainya sebagai persentase, dan yang lain menggunakan teks khusus dari [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/).

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

Angka yang disimpan dalam sebuah titik data tetap `0.75`, meskipun labelnya menampilkan `75%` bersama nama kategori dan seri. Teks khusus menggantikan teks label yang dihasilkan. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) mengembalikan string label yang dihasilkan dalam kedua kasus. Periksa [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) secara terpisah, seperti yang ditunjukkan di atas, ketika Anda hanya ingin mengekstrak label yang terlihat.

## **Kendalikan Label Data di Luar Maksimum Sumbu**

Ketika Anda membatasi rentang sumbu secara manual, beberapa titik data mungkin melampaui maksimum sumbu. Gunakan [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) untuk mengendalikan apakah label data mereka ditampilkan. Pengaturan ini mengubah visibilitas label; tidak mengubah rentang sumbu atau nilai data yang mendasarinya.

Contoh di bawah membuat diagram kolom berkelompok 2D dengan nilai 60 dan 120. Ia memberikan `false` ke [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) dan menetapkan maksimum menjadi 100 dengan [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) pada sumbu vertikal. Slide pertama mengizinkan label di luar maksimum; salinan slide itu menonaktifkannya. Kedua slide disimpan dalam `DataLabelsOverMaximum.pptx`.

Aktifkan label nilai dengan [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/). Pengaturan pada tingkat diagram tidak mengaktifkan tampilan nilai secara otomatis atau menimpa tampilan nilai yang dinonaktifkan pada label individual. Contoh ini mengaktifkan nilai untuk seluruh seri dan menggunakan [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) untuk menempatkan label di ujung luar setiap kolom.

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

Gambar berikut menampilkan slide yang disimpan dan dirender oleh Microsoft PowerPoint. Dengan `true`, label **120** terlihat pada batas atas; dengan `false`, label tersebut tersembunyi. Label **60** tetap terlihat, maksimum sumbu tetap **100**, dan titik data kedua tetap **120** pada kedua kasus.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Diagram PowerPoint yang menunjukkan label nilai 120 dengan maksimum sumbu 100](data-labels-over-maximum-true.png) | ![Diagram PowerPoint menyembunyikan label nilai 120 dengan maksimum sumbu 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Contoh ini menggunakan diagram kolom 2D dengan sumbu nilai. Diagram tanpa sumbu nilai, seperti diagram lingkaran dan donat, tidak memiliki maksimum sumbu untuk dibatasi dengan cara ini.
{{% /alert %}}

## **Atur Jarak Label dari Sumbu**

Gunakan [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) untuk mengendalikan jarak antara label sumbu kategori dan sumbu. Nilainya berupa persentase dari ukuran font maksimum label sumbu. Contoh ini membuat diagram kolom berkelompok dan menetapkan offset label sumbu horizontal menjadi 500. Pengaturan ini memengaruhi label sumbu kategori, bukan label yang melekat pada titik data individu.

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

Pada diagram lingkaran, sesuaikan posisi label data untuk memperbaiki jarak dan memberi ruang bagi garis penuntun.

Contoh ini menampilkan nilai titik data pertama, menempatkan labelnya di luar irisan, dan mengatur offset horizontal serta vertikal menggunakan [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) dan [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/). Offset ini relatif terhadap lebar dan tinggi diagram masing‑masing.

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

## **Format Garis Penuntun**

Ketika label diagram lingkaran berada di luar irisan mereka, garis penuntun membantu pembaca mencocokkan setiap nilai dengan irisan yang tepat. Warna yang kontras dan garis yang sedikit lebih tebal dapat membuat koneksi ini lebih mudah diikuti, sementara transparansi dan gaya putus‑putus menjaga garis tetap tidak mengganggu secara visual.

Gunakan [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) untuk memformat garis penuntun pada tingkat koleksi label data seri. Pengaturan dalam `$series->getLabels()->getLeaderLinesFormat()->getLine()` berlaku untuk seluruh koleksi, bukan untuk label individu.

Contoh ini membuat diagram lingkaran dengan data default, menampilkan nilai di luar irisan, dan mengaktifkan [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/). Ia memindahkan dua label lebih jauh dari irisan mereka menggunakan offset [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) dan [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/), yang dinyatakan sebagai pecahan lebar dan tinggi diagram. Tidak diperlukan presentasi masukan.

Format garisnya dengan [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) menetapkan warna biru solid dengan nilai alpha 191 dari 255, memberikan transparansi kira‑kira 25%. [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) mengatur ketebalan menjadi 2 poin, dan [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) membuat garis menjadi putus‑putus.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 80, 50, 560, 400);
    $chart->setLegend(false);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
    $labelFormat->setShowValue(true);
    $labelFormat->setPosition(LegendDataLabelPosition::OutsideEnd);
    $labelFormat->setShowLeaderLines(true);

    // Pindahkan dua label lebih jauh dari irisan mereka.
    $series->getLabels()->get_Item(0)->setX(0.10);
    $series->getLabels()->get_Item(0)->setY(-0.05);
    $series->getLabels()->get_Item(1)->setX(-0.10);
    $series->getLabels()->get_Item(1)->setY(0.05);

    $line = $series->getLabels()->getLeaderLinesFormat()->getLine();
    $line->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 30, 90, 160, 191);
    $line->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $line->setWidth(2);
    $line->setDashStyle(LineDashStyle::Dash);

    $presentation->save("FormattedLeaderLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mengaktifkan garis penuntun tidak menjamin bahwa sebuah garis akan muncul untuk setiap label. Visibilitas bergantung pada penempatan label dan perilaku tata letak diagram. Dalam contoh ini, dua label yang dipindahkan memiliki garis penuntun yang terlihat; label yang tetap dekat dengan irisan mereka tidak memerlukannya.

Gambar berikut menampilkan `FormattedLeaderLines.pptx` yang disimpan dan dirender dengan Aspose.Slides:

![Diagram lingkaran dengan garis penuntun biru, semi‑transparan, putus‑putus yang menghubungkan dua label luar ke irisan mereka](formatted-leader-lines.png)

## **Tambahkan Beberapa Baris Label Data di Atas Diagram Kolom**

Contoh ini membuat diagram kolom dengan dua baris label data di atas area plot. Seri A menampilkan kolom yang terlihat, sementara Seri B dan Seri C menyediakan label tambahan. Kolom mereka disembunyikan dengan menghapus isian dan garis tepi. Metode [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) menyelaraskan ketiga seri pada pusat kategori yang sama.

Pengaturan [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) menyisakan ruang untuk baris label. Setelah [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) menghitung posisi default, [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) dan [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) mempertahankan penyelarasan horizontal dan menerapkan offset vertikal untuk menyusun label dalam dua baris. Angka tetap menjadi label data yang terhubung ke nilai seri; hanya judul baris yang menjadi bentuk teks terpisah.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\LayoutTargetType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$colors = java("java.awt.Color");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
    $chart->setTitle(false);
    $chart->setLegend(false);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categories = [ "North", "South", "East", "West" ];
    $seriesNames = [ "Series A", "Series B", "Series C" ];
    $seriesValues = [
        [ 35, 42, 28, 47 ],
        [ 22, 31, 19, 26 ],
        [ 12, 16, 14, 18 ]
    ];
    
    for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
        $categoryCell = $workbook->getCell(0, $categoryIndex + 1, 0, $categories[$categoryIndex]);
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $seriesCell = $workbook->getCell(0, 0, $seriesIndex + 1, $seriesNames[$seriesIndex]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, ChartType::ClusteredColumn);

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $valueCell = $workbook->getCell(0, $categoryIndex + 1, $seriesIndex + 1, $seriesValues[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        if ($seriesIndex > 0) {
            // Sembunyikan kolom B dan C, tetapi pertahankan label data mereka.
            $series->getFormat()->getFill()->setFillType(FillType::NoFill);
            $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
            $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
            $labelFormat->setShowValue(true);
            $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(12);
            $labelFill = $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
            $labelFill->setFillType(FillType::Solid);
            $labelFill->getSolidFillColor()->setColor($colors->BLACK);
            $labelFormat->setPosition(LegendDataLabelPosition::InsideBase);
        }
    }

    // Sejajarkan ketiga seri dengan pusat kategori yang sama.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Gunakan lebih sedikit garis kisi untuk contoh kompak ini.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Sediakan ruang di atas plot untuk dua baris label data.
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $chart->getPlotArea()->setX(0.15);
    $chart->getPlotArea()->setY(0.32);
    $chart->getPlotArea()->setWidth(0.80);
    $chart->getPlotArea()->setHeight(0.48);
    $chart->validateChartLayout();

    $chartX = java_values($chart->getX());
    $chartY = java_values($chart->getY());
    $chartHeight = java_values($chart->getHeight());
    for ($seriesIndex = 1; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $rowTop = $seriesIndex == 1 ? 0.15 : 0.03;

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $dataLabel = $series->getDataPoints()->get_Item($categoryIndex)->getLabel();
            // Pertahankan posisi horizontal default. Y adalah offset dari
            // posisi label default, dinyatakan sebagai fraksi tinggi diagram.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // Hanya judul baris yang merupakan bentuk teks terpisah.
        $rowHeading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $chartX, $chartY + $rowTop * $chartHeight, 85, 18);
        $rowHeading->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->addTextFrame($seriesNames[$seriesIndex]);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginTop(0);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginBottom(0);
        $headingFormat = $rowHeading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $headingFormat->setFontHeight(12);
        $headingFormat->getFillFormat()->setFillType(FillType::Solid);
        $headingFormat->getFillFormat()->getSolidFillColor()->setColor($colors->BLACK);
    }

    $presentation->save("multiple-rows-of-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Diagram kolom dengan dua baris label data di atas area plot](multiple-rows-of-labels.png)


## **FAQ**

**Bagaimana saya dapat mencegah label data saling tumpang tindih pada diagram yang padat?**

Gabungkan penempatan label otomatis, garis penuntun, dan ukuran font yang lebih kecil; jika perlu, sembunyikan beberapa bidang (misalnya, kategori) atau tampilkan label hanya untuk nilai ekstrim atau titik penting.

**Bagaimana cara menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**

Filter titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai yang hilang sesuai dengan aturan yang ditentukan.

**Bagaimana saya dapat memastikan gaya label yang konsisten saat mengekspor ke PDF/gambar?**

Tetapkan secara eksplisit keluarga dan ukuran font serta pastikan font tersedia di lingkungan rendering untuk menghindari fallback.