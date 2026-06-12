---
title: Kelola Callout pada Grafik Presentasi Menggunakan PHP
linktitle: Callout
type: docs
url: /id/php-java/callout/
keywords:
- callout grafik
- gunakan callout
- label data
- format label
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat dan gayakan callout di Aspose.Slides untuk PHP via Java dengan contoh kode singkat, kompatibel dengan PPT dan PPTX untuk mengotomatiskan alur kerja presentasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan callout untuk label data grafik di Aspose.Slides. Ini memperlihatkan cara menggunakan metode `setShowLabelAsDataCallout` untuk menampilkan label sebagai callout, cara mengonfigurasi pengaturan label terkait callout untuk grafik donat, serta mencatat bahwa callout dan tampilannya tetap dipertahankan ketika presentasi diekspor ke PDF, HTML5, SVG, dan format gambar raster.

## **Menggunakan Callout**
Metode baru [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) dan [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) telah ditambahkan ke kelas [DataLabelFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat). Metode ini menentukan apakah label data pada grafik yang ditentukan akan ditampilkan sebagai callout data atau sebagai label data.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 500, 400);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowLabelAsDataCallout(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->get_Item(2)->getDataLabelFormat()->setShowLabelAsDataCallout(false);
    $pres->save("DisplayCharts.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menetapkan Callout untuk Grafik Donat**
Aspose.Slides for PHP via Java menyediakan dukungan untuk mengatur bentuk callout label data seri pada grafik Donat. Contoh sampel diberikan di bawah ini.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Doughnut, 10, 10, 500, 500, false);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(false);
    $seriesIndex = 0;
    while ($seriesIndex < 15) {
      $series = $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, $seriesIndex + 1, "SERIES " . $seriesIndex), $chart->getType());
      $series->setExplosion(0);
      $series->getParentSeriesGroup()->setDoughnutHoleSize(20);
      $series->getParentSeriesGroup()->setFirstSliceAngle(351);
      $seriesIndex++;
    } 
    $categoryIndex = 0;
    while ($categoryIndex < 15) {
      $chart->getChartData()->getCategories()->add($workBook->getCell(0, $categoryIndex + 1, 0, "CATEGORY " . $categoryIndex));
      $i = 0;
      while ($i < java_values($chart->getChartData()->getSeries()->size())) {
        $iCS = $chart->getChartData()->getSeries()->get_Item($i);
        $dataPoint = $iCS->getDataPoints()->addDataPointForDoughnutSeries($workBook->getCell(0, $categoryIndex + 1, $i + 1, 1));
        $dataPoint->getFormat()->getFill()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
        $dataPoint->getFormat()->getLine()->setWidth(1);
        $dataPoint->getFormat()->getLine()->setStyle(LineStyle->Single);
        $dataPoint->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
        if ($i == java_values($chart->getChartData()->getSeries()->size()) - 1) {
          $lbl = $dataPoint->getLabel();
          $lbl->getTextFormat()->getTextBlockFormat()->setAutofitType(TextAutofitType::Shape);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setLatinFont(new FontData("DINPro-Bold"));
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(12);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
          $lbl->getDataLabelFormat()->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
          $lbl->getDataLabelFormat()->setShowValue(false);
          $lbl->getDataLabelFormat()->setShowCategoryName(true);
          $lbl->getDataLabelFormat()->setShowSeriesName(false);
          $lbl->getDataLabelFormat()->setShowLeaderLines(true);
          $lbl->getDataLabelFormat()->setShowLabelAsDataCallout(false);
          $chart->validateChartLayout();
          $lbl->setX($lbl->getX() + 0.5);
          $lbl->setY($lbl->getY() + 0.5);
        }
        $i++;
      } 
      $categoryIndex++;
    } 
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah callout dipertahankan saat mengonversi presentasi ke PDF, HTML5, SVG, atau gambar?**

Ya. Callout merupakan bagian dari proses rendering grafik, sehingga ketika Anda mengekspor ke [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/id/php-java/export-to-html5/), [SVG](/slides/id/php-java/render-a-slide-as-an-svg-image/), atau [raster images](/slides/id/php-java/convert-powerpoint-to-png/), mereka tetap dipertahankan bersama format slide.

**Apakah font khusus berfungsi di callout, dan apakah tampilannya dapat dipertahankan saat ekspor?**

Ya. Aspose.Slides mendukung [embedding fonts](/slides/id/php-java/embedded-font/) ke dalam presentasi dan mengontrol penyematan font selama proses ekspor seperti [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), memastikan callout terlihat sama di berbagai sistem.