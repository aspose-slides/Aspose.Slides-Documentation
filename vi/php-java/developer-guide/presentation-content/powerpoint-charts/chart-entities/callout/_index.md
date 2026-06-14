---
title: Quản lý Callout trong Biểu đồ Trình chiếu bằng PHP
linktitle: Ghi chú
type: docs
url: /vi/php-java/callout/
keywords:
- callout biểu đồ
- sử dụng callout
- nhãn dữ liệu
- định dạng nhãn
- PowerPoint
- trình chiếu
- PHP
- Aspose.Slides
description: "Tạo và định dạng callout trong Aspose.Slides cho PHP thông qua Java với các ví dụ mã ngắn gọn, tương thích với PPT và PPTX để tự động hóa quy trình làm việc của bản trình chiếu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với callout cho nhãn dữ liệu biểu đồ trong Aspose.Slides. Nó trình bày cách sử dụng phương pháp `setShowLabelAsDataCallout` để hiển thị nhãn dưới dạng callout, cách cấu hình các thiết lập nhãn liên quan đến callout cho biểu đồ Doughnut, và lưu ý rằng callout và giao diện của chúng được bảo tồn khi bản trình bày được xuất ra các định dạng PDF, HTML5, SVG và ảnh raster.

## **Sử dụng Callouts**
Các phương pháp mới [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) và [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) đã được thêm vào lớp [DataLabelFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datalabelformat). Các phương pháp này xác định liệu nhãn dữ liệu của biểu đồ được chỉ định sẽ được hiển thị dưới dạng data callout hay dưới dạng nhãn dữ liệu.

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

## **Đặt Callout cho biểu đồ Doughnut**
Aspose.Slides cho PHP qua Java cung cấp hỗ trợ thiết lập hình dạng callout cho nhãn dữ liệu chuỗi trong biểu đồ Doughnut. Dưới đây là ví dụ mẫu được đưa ra.

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

**Callout có được bảo tồn khi chuyển đổi bản trình bày sang PDF, HTML5, SVG hoặc hình ảnh không?**

Có. Callout là một phần của quá trình render biểu đồ, vì vậy khi bạn xuất ra [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/vi/php-java/export-to-html5/), [SVG](/slides/vi/php-java/render-a-slide-as-an-svg-image/), hoặc [raster images](/slides/vi/php-java/convert-powerpoint-to-png/), chúng được bảo tồn cùng với định dạng của slide.

**Phông chữ tùy chỉnh có hoạt động trong callout không, và giao diện của chúng có thể được bảo tồn khi xuất không?**

Có. Aspose.Slides hỗ trợ [embedding fonts](/slides/vi/php-java/embedded-font/) vào bản trình bày và kiểm soát việc nhúng phông chữ trong quá trình xuất như [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), đảm bảo các callout hiển thị giống nhau trên các hệ thống khác nhau.