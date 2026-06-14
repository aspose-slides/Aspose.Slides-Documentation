---
title: Tối ưu tính toán biểu đồ cho bản trình bày trong PHP
linktitle: Tính toán biểu đồ
type: docs
weight: 50
url: /vi/php-java/chart-calculations/
keywords:
- tính toán biểu đồ
- phần tử biểu đồ
- vị trí phần tử
- vị trí thực
- phần tử con
- phần tử cha
- giá trị biểu đồ
- giá trị thực
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Hiểu các tính toán biểu đồ, cập nhật dữ liệu và kiểm soát độ chính xác trong Aspose.Slides cho PHP qua Java cho PPT và PPTX, kèm các ví dụ mã thực tế."
---
## **Tổng quan**

Aspose.Slides cung cấp API để làm việc với các phép tính biểu đồ và dữ liệu bố cục trong bài thuyết trình. Bài viết này cho thấy cách lấy các giá trị thực tế của các phần tử biểu đồ, bao gồm vị trí và kích thước thực của các phần tử cũng như các giá trị thực của các trục biểu đồ. Nó cũng giải thích rằng các giá trị này được điền sau khi xác thực bố cục biểu đồ.

Ngoài ra, bài viết trình bày cách lấy vị trí thực của các phần tử biểu đồ cha và cách ẩn các thành phần biểu đồ như tiêu đề, các trục, chú giải và các đường lưới. Cùng nhau, các ví dụ này giúp bạn kiểm tra thông tin bố cục biểu đồ và điều khiển khả năng hiển thị của các phần tử biểu đồ trong bài thuyết trình PowerPoint một cách lập trình.

## **Tính Giá Trị Thực Tế của Các Phần Tử Biểu Đồ**
Aspose.Slides for PHP via Java cung cấp một API đơn giản để lấy các thuộc tính này. Các phương thức của lớp [Axis](https://reference.aspose.com/slides/vi/php-java/aspose.slides/axis/) cung cấp thông tin về vị trí thực của phần tử trục biểu đồ ([getActualMaxValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/axis/getactualmaxvalue/),[getActualMinValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/axis/getactualminvalue/),[getActualMajorUnit](https://reference.aspose.com/slides/vi/php-java/aspose.slides/axis/getactualmajorunit/),[getActualMinorUnit](https://reference.aspose.com/slides/vi/php-java/aspose.slides/axis/getactualminorunit/),[getActualMajorUnitScale](https://reference.aspose.com/slides/vi/php-java/aspose.slides/axis/getactualmajorunitscale/),[getActualMinorUnitScale](https://reference.aspose.com/slides/vi/php-java/aspose.slides/axis/getactualminorunitscale/)). Cần gọi phương thức [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/validatechartlayout/) trước để điền các thuộc tính bằng các giá trị thực.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tính Vị Trí Thực của Các Phần Tử Biểu Đồ Cha**
Aspose.Slides for PHP via Java cung cấp một API đơn giản để lấy các thuộc tính này. Các phương thức của lớp `ActualLayout` cung cấp thông tin về vị trí thực của phần tử biểu đồ cha (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Cần gọi phương thức [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/validatechartlayout/) trước để điền các thuộc tính bằng các giá trị thực.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ẩn Các Phần Tử Biểu Đồ**
Chủ đề này giúp bạn hiểu cách ẩn thông tin khỏi biểu đồ. Sử dụng Aspose.Slides cho PHP qua Java, bạn có thể ẩn **Tiêu đề, Trục Dọc, Trục Ngang** và **Các Đường Lưới** khỏi biểu đồ. Ví dụ mã dưới đây cho thấy cách sử dụng các thuộc tính này.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Ẩn tiêu đề biểu đồ
    $chart->setTitle(false);
    # /Ẩn trục Giá trị
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Hiển thị trục danh mục
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Ẩn chú giải
    $chart->setLegend(false);
    # Ẩn các đường lưới chính
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Đặt màu đường chuỗi
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu Hỏi Thường Gặp**

**Các sổ làm việc Excel bên ngoài có hoạt động như nguồn dữ liệu không, và điều đó ảnh hưởng như thế nào đến việc tính lại?**

Có. Một biểu đồ có thể tham chiếu tới một sổ làm việc bên ngoài: khi bạn kết nối hoặc làm mới nguồn bên ngoài, các công thức và giá trị được lấy từ sổ làm việc đó, và biểu đồ phản ánh các cập nhật trong quá trình mở/chỉnh sửa. API cho phép bạn [specify the external workbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/setexternalworkbook/) đường dẫn và quản lý dữ liệu liên kết.

**Tôi có thể tính toán và hiển thị các đường xu hướng mà không cần tự triển khai hồi quy không?**

Có. [Trendlines](/slides/vi/php-java/trend-line/) (tuyến tính, hàm mũ và các loại khác) được Aspose.Slides thêm và cập nhật; các tham số của chúng được tính lại từ dữ liệu chuỗi một cách tự động, vì vậy bạn không cần tự thực hiện các phép tính.

**Nếu một bài thuyết trình có nhiều biểu đồ với liên kết bên ngoài, tôi có thể kiểm soát sổ làm việc nào mỗi biểu đồ sử dụng cho các giá trị tính toán không?**

Có. Mỗi biểu đồ có thể chỉ tới [external workbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/setexternalworkbook/) riêng của nó, hoặc bạn có thể tạo/thay thế một sổ làm việc bên ngoài cho mỗi biểu đồ một cách độc lập với các biểu đồ khác.