---
title: Quản lý nhãn dữ liệu biểu đồ trong các bản trình chiếu bằng PHP
linktitle: Nhãn dữ liệu
type: docs
url: /vi/php-java/chart-data-label/
keywords:
- biểu đồ
- nhãn dữ liệu
- độ chính xác dữ liệu
- phần trăm
- khoảng cách nhãn
- vị trí nhãn
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong các bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides cho PHP qua Java để tạo slide sinh động hơn."
---
## **Giới thiệu**

Nhãn dữ liệu trên biểu đồ hiển thị chi tiết về chuỗi dữ liệu hoặc các điểm dữ liệu riêng lẻ. Chúng cho phép người đọc nhanh chóng xác định chuỗi dữ liệu và cũng làm cho biểu đồ dễ hiểu hơn.

## **Đặt độ chính xác dữ liệu trong nhãn dữ liệu biểu đồ**

Đoạn mã PHP này cho bạn cách đặt độ chính xác dữ liệu trong một nhãn dữ liệu biểu đồ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hiển thị phần trăm dưới dạng nhãn**
Aspose.Slides for PHP via Java cho phép bạn đặt nhãn phần trăm trên các biểu đồ hiển thị. Đoạn mã PHP này minh họa thao tác:

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # Lưu bản trình chiếu chứa biểu đồ
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt ký hiệu phần trăm cho nhãn dữ liệu biểu đồ**
Đoạn mã PHP này cho bạn cách đặt ký hiệu phần trăm cho một nhãn dữ liệu biểu đồ:

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Lấy tham chiếu slide qua chỉ số của nó
    $slide = $pres->getSlides()->get_Item(0);
    # Tạo biểu đồ PercentsStackedColumn trên slide
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # Đặt NumberFormatLinkedToSource thành false
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # Thêm series mới
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # Đặt màu nền cho series
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Đặt các thuộc tính LabelFormat
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Thêm series mới
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # Đặt kiểu và màu Fill
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Ghi bản trình chiếu ra đĩa
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt khoảng cách nhãn so với trục**
Đoạn mã PHP này cho bạn cách đặt khoảng cách nhãn so với trục danh mục khi bạn làm việc với biểu đồ được vẽ từ các trục:

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Lấy tham chiếu slide
    $sld = $pres->getSlides()->get_Item(0);
    # Tạo biểu đồ trên slide
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # Đặt khoảng cách nhãn so với trục
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # Ghi bản trình chiếu ra đĩa
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Điều chỉnh vị trí nhãn**

Khi bạn tạo một biểu đồ không phụ thuộc vào bất kỳ trục nào như biểu đồ tròn, nhãn dữ liệu của biểu đồ có thể quá gần cạnh. Trong trường hợp đó, bạn cần điều chỉnh vị trí nhãn dữ liệu sao cho các đường dẫn (leader lines) được hiển thị rõ ràng.

Đoạn mã PHP này cho bạn cách điều chỉnh vị trí nhãn trên biểu đồ tròn:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Câu hỏi thường gặp**

**Làm sao tôi có thể ngăn nhãn dữ liệu chồng lên nhau trên các biểu đồ dày đặc?**

Kết hợp việc đặt nhãn tự động, các đường dẫn, và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ, danh mục) hoặc chỉ hiển thị nhãn cho các điểm cực đoan/quan trọng.

**Làm sao tôi có thể tắt nhãn chỉ cho các giá trị bằng 0, âm hoặc rỗng?**

Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị bằng 0, giá trị âm, hoặc giá trị thiếu theo quy tắc đã định nghĩa.

**Làm sao tôi có thể đảm bảo kiểu nhãn nhất quán khi xuất ra PDF/hình ảnh?**

Đặt rõ phông chữ (family, size) và xác minh rằng phông chữ có sẵn ở phía render để tránh việc fallback.