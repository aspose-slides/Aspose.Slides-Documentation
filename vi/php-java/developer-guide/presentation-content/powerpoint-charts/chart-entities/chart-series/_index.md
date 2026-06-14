---
title: Quản lý series dữ liệu biểu đồ trong bản trình bày bằng PHP
linktitle: Series dữ liệu
type: docs
url: /vi/php-java/chart-series/
keywords:
- series biểu đồ
- độ chồng series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng cách series
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tìm hiểu cách quản lý series dữ liệu biểu đồ trong PHP cho PowerPoint (PPT/PPTX) với các ví dụ mã thực tế và các thực tiễn tốt nhất để cải thiện các bản trình bày dữ liệu của bạn."
---
## **Overview**

Bài viết này mô tả vai trò của [ChartSeries](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/) trong Aspose.Slides, tập trung vào cách dữ liệu được cấu trúc và trực quan hoá trong các bản trình bày. Các đối tượng này cung cấp các yếu tố nền tảng để định nghĩa từng tập hợp các điểm dữ liệu, danh mục và các tham số hiển thị trong một biểu đồ. Khi làm việc với [ChartSeries](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/), các nhà phát triển có thể dễ dàng tích hợp nguồn dữ liệu nền và duy trì kiểm soát hoàn toàn cách thông tin được hiển thị, tạo ra các bản trình bày động, dựa trên dữ liệu, truyền đạt rõ ràng các insight và phân tích.

Một series là một hàng hoặc một cột các số được vẽ trên biểu đồ.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set the Chart Series Overlap**

Với phương thức [getParentSeriesGroup](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#getParentSeriesGroup), bạn có thể xác định mức độ chồng của các thanh và cột trên biểu đồ 2D (phạm vi: -100 đến 100). Thuộc tính này áp dụng cho tất cả các series trong nhóm series cha: đây là một phép chiếu của thuộc tính nhóm tương ứng. Do đó, thuộc tính này chỉ đọc.

Sử dụng phương thức `ChartSeriesGroup::setOverlap` để đặt giá trị mong muốn cho `Overlap`.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Thêm một biểu đồ cột nhóm vào một slide.
1. Truy cập series đầu tiên của biểu đồ.
1. Truy cập `ParentSeriesGroup` của series và đặt giá trị chồng mong muốn cho series.
1. Ghi bản trình bày đã sửa đổi ra tệp PPTX.

Mã PHP sau cho thấy cách đặt độ chồng cho một series biểu đồ:

```php
  $pres = new Presentation();
  try {
    # Thêm biểu đồ
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Đặt độ chồng series
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Ghi tệp bản trình bày ra đĩa
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Change the Series Color**

Aspose.Slides for PHP via Java cho phép bạn thay đổi màu của một series theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Thêm biểu đồ vào slide.
1. Truy cập series mà bạn muốn thay đổi màu.
1. Đặt kiểu và màu tô bóng mong muốn.
1. Lưu bản trình bày đã sửa đổi.

Mã PHP sau cho thấy cách thay đổi màu của một series:

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

## **Change the Series Category Color**

Aspose.Slides for PHP via Java cho phép bạn thay đổi màu của danh mục trong một series theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Thêm biểu đồ vào slide.
1. Truy cập danh mục của series mà bạn muốn thay đổi màu.
1. Đặt kiểu và màu tô bóng mong muốn.
1. Lưu bản trình bày đã sửa đổi.

Mã này cho thấy cách thay đổi màu của một danh mục series:

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

## **Change the Series Name** 

Mặc định, tên chú giải cho một biểu đồ là nội dung của các ô phía trên mỗi cột hoặc hàng dữ liệu.

Trong ví dụ của chúng tôi (hình mẫu),

* các cột là *Series 1, Series 2,* và *Series 3*;
* các hàng là *Category 1, Category 2, Category 3,* và *Category 4*.

Aspose.Slides for PHP via Java cho phép bạn cập nhật hoặc thay đổi tên của một series trong dữ liệu biểu đồ và chú giải của nó.

Mã PHP sau cho thấy cách thay đổi tên của một series trong `ChartDataWorkbook` của dữ liệu biểu đồ:

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

Mã PHP sau cho thấy cách thay đổi tên của một series trong chú giải thông qua `Series`:

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

## **Set the Chart Series Fill Color**

Aspose.Slides for PHP via Java cho phép bạn đặt màu tô tự động cho series biểu đồ trong vùng vẽ theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định dựa trên loại bạn chọn (trong ví dụ dưới, chúng tôi sử dụng `ChartType::ClusteredColumn`).
1. Truy cập series biểu đồ và đặt màu tô thành Automatic.
1. Lưu bản trình bày ra tệp PPTX.

Mã PHP sau cho thấy cách đặt màu tô tự động cho một series biểu đồ:

```php
  $pres = new Presentation();
  try {
    # Tạo biểu đồ cột nhóm
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Đặt định dạng tô màu series thành tự động
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Ghi tệp bản trình bày ra đĩa
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Invert Fill Color for a Chart Series**

Aspose.Slides cho phép bạn đặt màu tô đảo ngược cho series biểu đồ trong vùng vẽ theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định dựa trên loại bạn chọn (trong ví dụ dưới, chúng tôi sử dụng `ChartType::ClusteredColumn`).
1. Truy cập series biểu đồ và đặt màu tô thành invert.
1. Lưu bản trình bày ra tệp PPTX.

Mã PHP này minh họa thao tác:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Thêm series và danh mục mới
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Lấy series đầu tiên của biểu đồ và điền dữ liệu cho series.
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

## **Set a Series to Invert When Value Is Negative**

Aspose.Slides cho phép bạn thiết lập đảo ngược thông qua các thuộc tính `IChartDataPoint.InvertIfNegative` và `ChartDataPoint.InvertIfNegative`. Khi một series được thiết lập đảo ngược bằng các thuộc tính này, điểm dữ liệu sẽ đổi màu khi nhận giá trị âm.

Mã PHP này minh họa thao tác:

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

## **Clear Specific Point Data**

Aspose.Slides for PHP via Java cho phép bạn xóa dữ liệu `DataPoints` cho một series biểu đồ cụ thể theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu tới slide theo chỉ mục của nó.
3. Lấy tham chiếu tới biểu đồ theo chỉ mục của nó.
4. Duyệt qua tất cả `DataPoints` của biểu đồ và đặt `XValue` và `YValue` thành null.
5. Xóa toàn bộ `DataPoints` cho series biểu đồ cụ thể.
6. Ghi bản trình bày đã sửa đổi ra tệp PPTX.

Mã PHP này minh họa thao tác:

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

## **Set the Series Gap Width**

Aspose.Slides for PHP via Java cho phép bạn đặt **`GapWidth`** cho một series theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Truy cập bất kỳ series nào của biểu đồ.
1. Đặt thuộc tính `GapWidth`.
1. Ghi bản trình bày đã sửa đổi ra tệp PPTX.

Mã này cho thấy cách đặt Gap Width cho một series:

```php
  # Tạo bản trình bày trống
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên của bản trình bày
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm biểu đồ với dữ liệu mặc định
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Đặt chỉ mục của bảng dữ liệu biểu đồ
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Thêm series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Thêm danh mục
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Lấy series thứ hai của biểu đồ
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Điền dữ liệu cho series
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Đặt giá trị GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Lưu bản trình bày ra đĩa
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Có giới hạn số lượng series mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt mức giới hạn cố định cho số series bạn thêm. Giới hạn thực tế phụ thuộc vào khả năng đọc biểu đồ và bộ nhớ có sẵn cho ứng dụng của bạn.

**Nếu các cột trong một nhóm quá gần nhau hoặc quá xa nhau thì phải làm sao?**

Điều chỉnh thiết lập `GapWidth` cho series đó (hoặc cho nhóm series cha). Tăng giá trị sẽ làm rộng khoảng cách giữa các cột, giảm giá trị sẽ làm chúng gần nhau hơn.