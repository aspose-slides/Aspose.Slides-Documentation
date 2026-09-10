---
title: Tạo hoặc Cập nhật Biểu đồ Bản trình bày PowerPoint trong PHP
linktitle: Tạo hoặc Cập nhật Biểu đồ
type: docs
weight: 10
url: /vi/php-java/create-chart/
keywords:
- thêm biểu đồ
- tạo biểu đồ
- chỉnh sửa biểu đồ
- thay đổi biểu đồ
- cập nhật biểu đồ
- biểu đồ phân tán
- biểu đồ tròn
- biểu đồ đường
- biểu đồ cây
- biểu đồ chứng khoán
- biểu đồ hộp và râu
- biểu đồ phễu
- biểu đồ Sunburst
- biểu đồ histogram
- biểu đồ radar
- biểu đồ đa danh mục
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ trong bản trình bày PowerPoint bằng Aspose.Slides cho PHP thông qua Java. Thêm, định dạng và chỉnh sửa biểu đồ với các ví dụ mã thực tế."
---
## **Tổng quan**

Bài viết này cung cấp hướng dẫn toàn diện về cách tạo và tùy chỉnh biểu đồ bằng Aspose.Slides. Bạn sẽ học cách lập trình thêm biểu đồ vào một slide, điền dữ liệu vào và áp dụng các tùy chọn định dạng khác nhau để đáp ứng yêu cầu thiết kế cụ thể. Toàn bộ bài viết bao gồm các ví dụ mã chi tiết minh họa từng bước, từ việc khởi tạo bài thuyết trình và đối tượng biểu đồ đến cấu hình series, trục và legend. Khi làm theo hướng dẫn này, bạn sẽ nắm vững cách tích hợp việc tạo biểu đồ động vào ứng dụng, giúp đơn giản hoá quá trình tạo các bản trình bày dựa trên dữ liệu.

## **Tạo biểu đồ**

Biểu đồ giúp người dùng nhanh chóng hình dung dữ liệu và rút ra những insight mà có thể không rõ ràng khi xem bảng hoặc bảng tính.

**Tại sao tạo biểu đồ?**

Sử dụng biểu đồ, bạn có thể:

* tổng hợp, cô đọng hoặc tóm tắt một lượng lớn dữ liệu trên một slide trong bản thuyết trình
* phát hiện các mẫu và xu hướng trong dữ liệu
* suy đoán hướng và động lực của dữ liệu theo thời gian hoặc đối với một đơn vị đo lường cụ thể
* phát hiện các ngoại lệ, sai lệch, lỗi, dữ liệu vô lý, v.v.
* truyền đạt hoặc trình bày dữ liệu phức tạp

Trong PowerPoint, bạn có thể tạo biểu đồ thông qua chức năng *Insert*, cung cấp các mẫu để thiết kế nhiều loại biểu đồ. Sử dụng Aspose.Slides, bạn có thể tạo cả biểu đồ thông thường (dựa trên các loại biểu đồ phổ biến) và biểu đồ tùy chỉnh.

{{% alert color="info" title="Lưu ý" %}}
Để tạo biểu đồ, sử dụng lớp [ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/). Các trường trong lớp này tương ứng với các loại biểu đồ khác nhau.
{{% /alert %}}

### **Tạo biểu đồ cột nhóm**

Phần này giải thích cách tạo biểu đồ cột nhóm bằng Aspose.Slides. Bạn sẽ học cách khởi tạo một bài thuyết trình, thêm biểu đồ và tùy chỉnh các yếu tố như tiêu đề, dữ liệu, series, danh mục và kiểu dáng. Thực hiện các bước sau để xem cách một biểu đồ cột nhóm tiêu chuẩn được tạo ra:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Lấy tham chiếu đến một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với một số dữ liệu và chỉ định kiểu `ChartType::ClusteredColumn`.
1. Thêm tiêu đề cho biểu đồ.
1. Truy cập bảng dữ liệu của biểu đồ.
1. Xóa tất cả series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Áp dụng màu nền cho series.
1. Thêm nhãn cho series.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã C# sau minh họa cách tạo một biểu đồ cột nhóm:

```php
  # Khởi tạo một lớp bản trình bày đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm một biểu đồ với dữ liệu mặc định
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Đặt tiêu đề cho biểu đồ
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Đặt series đầu tiên hiển thị giá trị
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Đặt chỉ mục cho bảng dữ liệu biểu đồ
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Xóa series và danh mục được tạo mặc định
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Thêm series mới
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Thêm danh mục mới
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Lấy series biểu đồ đầu tiên
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Bây giờ điền dữ liệu cho series
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Đặt màu nền cho series
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Lấy series biểu đồ thứ hai
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Điền dữ liệu cho series
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Đặt màu nền cho series
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Tạo nhãn tùy chỉnh cho mỗi danh mục cho series mới
    # Đặt nhãn đầu tiên hiển thị tên danh mục
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Hiển thị giá trị cho nhãn thứ ba
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Lưu bản trình bày kèm biểu đồ
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ phân tán**

Biểu đồ phân tán (còn gọi là scatter plot hoặc đồ thị x‑y) thường được dùng để kiểm tra các mẫu hoặc chứng minh mối tương quan giữa hai biến.

Sử dụng biểu đồ phân tán khi:

* bạn có dữ liệu số cặp đôi
* bạn có hai biến tương thích với nhau
* bạn muốn xác định liệu hai biến có liên quan hay không
* bạn có một biến độc lập có nhiều giá trị cho một biến phụ thuộc

1. Thực hiện các bước trong [Tạo biểu đồ cột nhóm](#tạo-biểu-đồ-cột-nhóm).
2. Ở bước thứ ba, thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ là một trong các lựa chọn sau:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Biểu thị một biểu đồ phân tán._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Biểu thị một biểu đồ phân tán được nối bằng đường cong, có dấu dữ liệu._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Biểu thị một biểu đồ phân tán được nối bằng đường cong, không có dấu dữ liệu._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Biểu thị một biểu đồ phân tán được nối bằng đường thẳng, có dấu dữ liệu._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Biểu thị một biểu đồ phân tán được nối bằng đường thẳng, không có dấu dữ liệu._

Mã PHP dưới đây cho thấy cách tạo một biểu đồ phân tán với các dấu khác nhau cho mỗi series:

```php
  # Khởi tạo một lớp bản trình bày đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Tạo biểu đồ mặc định
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Lấy chỉ mục worksheet dữ liệu biểu đồ mặc định
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Xóa series demo
    $chart->getChartData()->getSeries()->clear();
    # Thêm series mới
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Lấy series biểu đồ đầu tiên
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Thêm một điểm mới (1:3) vào series
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Thêm một điểm mới (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Thay đổi loại series
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Thay đổi dấu đánh dấu của series biểu đồ
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Lấy series biểu đồ thứ hai
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Thêm một điểm mới (5:2) vào đó
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Thêm một điểm mới (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Thêm một điểm mới (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Thêm một điểm mới (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Thay đổi dấu đánh dấu của series biểu đồ
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ tròn**

Biểu đồ tròn thích hợp để hiển thị mối quan hệ phần‑trên‑toàn trong dữ liệu, đặc biệt khi dữ liệu có nhãn phân loại kèm giá trị số. Tuy nhiên, nếu dữ liệu của bạn có quá nhiều phần hoặc nhãn, bạn có thể cân nhắc dùng biểu đồ cột thay thế.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType::Pie](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#Pie).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Thêm các điểm mới cho biểu đồ và áp dụng màu tùy chỉnh cho các đoạn của biểu đồ tròn.
9. Đặt nhãn cho các series.
10. Bật các đường dẫn (leader lines) cho nhãn series.
11. Đặt góc quay cho các đoạn của biểu đồ tròn.
12. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ tròn:

```php
  # Khởi tạo một lớp bản trình bày đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $slides = $pres->getSlides()->get_Item(0);
    # Thêm một biểu đồ với dữ liệu mặc định
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Đặt tiêu đề cho biểu đồ
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Đặt series đầu tiên hiển thị giá trị
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Đặt chỉ mục cho worksheet dữ liệu biểu đồ
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Xóa series và danh mục được tạo mặc định
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Thêm danh mục mới
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Thêm series mới
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Điền dữ liệu cho series
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Không hoạt động trong phiên bản mới
    # Thêm các điểm mới và đặt màu cho sector
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Đặt viền cho sector
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Đặt viền cho sector
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Đặt viền cho sector
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Tạo nhãn tùy chỉnh cho mỗi danh mục cho series mới
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Hiển thị đường dẫn (Leader Lines) cho biểu đồ
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Đặt góc quay cho các sector của biểu đồ tròn
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Lưu bản trình bày kèm biểu đồ
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ đường**

Biểu đồ đường (còn gọi là line graph) thích hợp khi bạn muốn minh họa sự thay đổi giá trị theo thời gian. Với biểu đồ đường, bạn có thể so sánh một lượng lớn dữ liệu cùng lúc, theo dõi các thay đổi và xu hướng theo thời gian, làm nổi bật các bất thường trong series dữ liệu, và nhiều hơn nữa.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType::Line](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#Line).
1. Truy cập sổ làm việc dữ liệu biểu đồ ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ đường:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Mặc định, các điểm trên biểu đồ đường được nối bằng các đường thẳng liên tục. Nếu bạn muốn các điểm được nối bằng dấu gạch, bạn có thể chỉ định kiểu gạch mong muốn như sau:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ cây**

Biểu đồ cây (Tree Map) thích hợp cho dữ liệu bán hàng khi bạn muốn hiển thị kích thước tương đối của các danh mục dữ liệu và nhanh chóng thu hút sự chú ý tới các mục đóng góp lớn trong mỗi danh mục.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType::Treemap](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#Treemap).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ cây:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # nhánh 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # nhánh 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ chứng khoán**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#OpenHighLowClose).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Xác định định dạng các đường high‑low.
9. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ chứng khoán:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ Box và Whisker**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#BoxAndWhisker).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ Box và Whisker:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ phễu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType::Funnel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#Funnel).
4. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ phễu:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ Sunburst**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType::Sunburst](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#Sunburst).
4. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ Sunburst:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # nhánh 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # nhánh 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ histogram**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType::Histogram](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#Histogram).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ histogram:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **Tạo biểu đồ radar**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ ưa thích của bạn ([ChartType::Radar](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#Radar) trong trường hợp này).
4. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ radar:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ đa danh mục**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType::ClusteredColumn](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ClusteredColumn).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ đa danh mục:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Thêm Series
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Lưu bản trình bày kèm biểu đồ
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ bản đồ**

Biểu đồ bản đồ hiển thị dữ liệu địa lý và giúp so sánh các giá trị qua các khu vực.

Mã PHP dưới đây cho thấy cách tạo một biểu đồ bản đồ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ kết hợp**

Biểu đồ kết hợp (hoặc combo chart) kết hợp hai hoặc nhiều loại biểu đồ trong một đồ thị duy nhất. Biểu đồ này cho phép bạn làm nổi bật, so sánh hoặc kiểm tra sự khác biệt giữa hai hoặc nhiều bộ dữ liệu, giúp xác định mối quan hệ giữa chúng.

![The combination chart](combination_chart.png)

Mã PHP sau đây cho thấy cách tạo biểu đồ kết hợp như trong hình trên trong một bản PowerPoint:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Đặt tiêu đề cho biểu đồ.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Đặt chú thích cho biểu đồ.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Xóa series và danh mục được tạo mặc định.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Thêm các danh mục mới.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Thêm series đầu tiên.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Đặt trục ngang.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Đặt trục dọc.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Đặt màu cho các đường lưới dọc chính.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Đặt trục ngang phụ.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Đặt trục dọc phụ.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Cập nhật biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) đại diện cho bản thuyết trình chứa biểu đồ bạn muốn cập nhật.
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập bảng dữ liệu của biểu đồ.
5. Sửa đổi series dữ liệu của biểu đồ bằng cách thay đổi giá trị series.
6. Thêm một series mới và điền dữ liệu cho nó.
7. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách cập nhật một biểu đồ:

```php
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Lấy biểu đồ với dữ liệu mặc định
    $chart = $sld->getShapes()->get_Item(0);
    # Đặt chỉ mục của sheet dữ liệu biểu đồ
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Thay đổi tên danh mục của biểu đồ
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Lấy series đầu tiên của biểu đồ
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Bây giờ cập nhật dữ liệu series
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1"); // Sửa tên series

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Lấy series thứ hai của biểu đồ
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Bây giờ cập nhật dữ liệu series
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2"); // Sửa tên series

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Bây giờ, thêm một series mới
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Lấy series thứ ba của biểu đồ
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Bây giờ điền dữ liệu cho series
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Lưu bản trình bày kèm biểu đồ
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt phạm vi dữ liệu cho biểu đồ**

Để đặt phạm vi dữ liệu cho một biểu đồ, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) đại diện cho bản thuyết trình chứa biểu đồ.
2. Lấy tham chiếu đến một slide bằng chỉ số của nó.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập dữ liệu biểu đồ và đặt phạm vi.
5. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP dưới đây cho thấy cách đặt phạm vi dữ liệu cho một biểu đồ:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sử dụng các dấu mặc định trong biểu đồ**

Khi bạn sử dụng các dấu mặc định trong biểu đồ, mỗi series sẽ tự động nhận một ký hiệu dấu khác nhau.

Mã PHP dưới đây cho thấy cách tự động đặt dấu cho một series biểu đồ:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # Lấy series biểu đồ thứ hai
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Bây giờ điền dữ liệu cho series
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào được Aspose.Slides hỗ trợ?**

Aspose.Slides hỗ trợ một loạt các [loại biểu đồ](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/), bao gồm bar, line, pie, area, scatter, histogram, radar và nhiều loại khác. Sự linh hoạt này cho phép bạn lựa chọn loại biểu đồ phù hợp nhất cho nhu cầu trực quan hoá dữ liệu của mình.

**Làm thế nào để thêm một biểu đồ mới vào slide?**

Để thêm một biểu đồ, trước tiên bạn tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), lấy slide mong muốn bằng chỉ số của nó, sau đó gọi phương thức để thêm biểu đồ, chỉ định loại biểu đồ và dữ liệu ban đầu. Quy trình này tích hợp trực tiếp biểu đồ vào bản thuyết trình của bạn.

**Làm sao để cập nhật dữ liệu hiển thị trong biểu đồ?**

Bạn có thể cập nhật dữ liệu của biểu đồ bằng cách truy cập sổ làm việc dữ liệu ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/)), xóa bất kỳ series và danh mục mặc định nào, rồi thêm dữ liệu tùy chỉnh của bạn. Điều này cho phép làm mới biểu đồ để phản ánh dữ liệu mới nhất.

**Có thể tùy chỉnh giao diện của biểu đồ không?**

Có, Aspose.Slides cung cấp nhiều tùy chọn tùy chỉnh. Bạn có thể thay đổi màu sắc, phông chữ, nhãn, legend và các [phần tử định dạng](/slides/vi/php-java/chart-entities/) khác để điều chỉnh giao diện biểu đồ cho phù hợp với yêu cầu thiết kế cụ thể.