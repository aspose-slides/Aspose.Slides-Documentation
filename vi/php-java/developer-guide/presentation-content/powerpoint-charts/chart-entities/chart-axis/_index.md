---
title: Tùy chỉnh các trục biểu đồ trong bài thuyết trình bằng PHP
linktitle: Trục biểu đồ
type: docs
url: /vi/php-java/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
- điều khiển trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho PHP qua Java để tùy chỉnh các trục biểu đồ trong các bài thuyết trình PowerPoint cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ trong Aspose.Slides. Nó cho thấy cách lấy giá trị thực của trục, hoán đổi dữ liệu giữa các trục, ẩn trục dọc hoặc trục ngang cho biểu đồ đường, thay đổi kiểu trục danh mục, đặt định dạng ngày cho các giá trị trục danh mục, xoay tiêu đề trục, đặt vị trí trục và hiển thị nhãn đơn vị trên trục giá trị.

## **Lấy giá trị tối đa trên trục dọc trong biểu đồ**
Aspose.Slides for PHP qua Java cho phép bạn lấy giá trị tối thiểu và tối đa trên trục dọc. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm một biểu đồ với dữ liệu mặc định.
1. Lấy giá trị tối đa thực tế trên trục.
1. Lấy giá trị tối thiểu thực tế trên trục.
1. Lấy đơn vị chính thực tế của trục.
1. Lấy đơn vị phụ thực tế của trục.
1. Lấy tỷ lệ đơn vị chính thực tế của trục.
1. Lấy tỷ lệ đơn vị phụ thực tế của trục.

Mã mẫu này — một triển khai các bước trên — cho bạn thấy cách lấy các giá trị cần thiết :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Lưu bài thuyết trình
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hoán đổi dữ liệu giữa các trục**
Aspose.Slides cho phép bạn nhanh chóng hoán đổi dữ liệu giữa các trục — dữ liệu hiển thị trên trục dọc (trục y) sẽ chuyển sang trục ngang (trục x) và ngược lại. 

Mã PHP này cho bạn thấy cách thực hiện việc hoán đổi dữ liệu giữa các trục trên một biểu đồ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Chuyển đổi hàng và cột
    $chart->getChartData()->switchRowColumn();
    # Lưu bài thuyết trình
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vô hiệu hoá trục dọc cho biểu đồ đường**

Mã PHP này cho bạn thấy cách ẩn trục dọc cho một biểu đồ đường:

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

## **Vô hiệu hoá trục ngang cho biểu đồ đường**

Mã này cho bạn thấy cách ẩn trục ngang cho một biểu đồ đường:

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

## **Thay đổi trục danh mục**

Bằng cách sử dụng thuộc tính **CategoryAxisType**, bạn có thể chỉ định kiểu trục danh mục ưa thích (**date** hoặc **text**). Mã này minh họa thao tác:

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

## **Đặt định dạng ngày cho các giá trị trục danh mục**
Aspose.Slides for PHP qua Java cho phép bạn đặt định dạng ngày cho giá trị trục danh mục. Thao tác được minh họa trong mã PHP này:

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

## **Đặt góc xoay cho tiêu đề trục biểu đồ**
Aspose.Slides for PHP qua Java cho phép bạn đặt góc xoay cho tiêu đề trục biểu đồ. Mã PHP này minh họa thao tác:

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

## **Đặt vị trí trục trên trục danh mục hoặc trục giá trị**
Aspose.Slides for PHP qua Java cho phép bạn đặt vị trí trục trên trục danh mục hoặc trục giá trị. Mã PHP này cho bạn biết cách thực hiện nhiệm vụ:

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

## **Bật hiển thị nhãn đơn vị trên trục giá trị của biểu đồ**
Aspose.Slides for PHP qua Java cho phép bạn cấu hình biểu đồ để hiển thị nhãn đơn vị trên trục giá trị của nó. Mã PHP này minh họa thao tác:

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

## **Câu hỏi thường gặp**

**Làm thế nào để đặt giá trị mà một trục cắt qua trục còn lại (giao điểm trục)?**

Các trục cung cấp một [cài đặt giao cắt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/axis/setcrosstype/): bạn có thể chọn giao tại zero, tại giá trị danh mục/giá trị tối đa, hoặc tại một giá trị số cụ thể. Điều này hữu ích để di chuyển trục X lên hoặc xuống hoặc để nhấn mạnh một đường cơ sở.

**Làm thế nào để định vị nhãn tick so với trục (bên cạnh, bên ngoài, bên trong)?**

Đặt [vị trí nhãn](https://reference.aspose.com/slides/vi/php-java/aspose.slides/axis/setmajortickmark/) thành "cross", "outside" hoặc "inside". Điều này ảnh hưởng đến khả năng đọc và giúp tiết kiệm không gian, đặc biệt trên các biểu đồ nhỏ.