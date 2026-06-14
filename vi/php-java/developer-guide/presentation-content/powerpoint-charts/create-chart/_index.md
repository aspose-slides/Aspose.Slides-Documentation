---
title: Tạo hoặc Cập nhật Biểu đồ PowerPoint trong PHP
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
- biểu đồ mặt trời
- biểu đồ histogram
- biểu đồ radar
- biểu đồ đa danh mục
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ trong bản trình bày PowerPoint bằng Aspose.Slides cho PHP qua Java. Thêm, định dạng và chỉnh sửa biểu đồ với các ví dụ mã thực tế."
---
## **Tổng quan**

Bài viết này cung cấp hướng dẫn toàn diện về cách tạo và tùy chỉnh biểu đồ bằng Aspose.Slides. Bạn sẽ học cách thêm biểu đồ vào slide bằng lập trình, điền dữ liệu và áp dụng các tùy chọn định dạng khác nhau để đáp ứng yêu cầu thiết kế cụ thể của mình. Trong suốt bài viết, các ví dụ mã chi tiết minh họa từng bước, từ khởi tạo đối tượng Presentation và chart cho đến cấu hình series, trục và legend. Khi làm theo hướng dẫn này, bạn sẽ nắm vững cách tích hợp việc tạo biểu đồ động vào ứng dụng, giúp đơn giản hoá quy trình tạo các bản trình bày dựa trên dữ liệu.

## **Tạo biểu đồ**

Biểu đồ giúp người dùng nhanh chóng hình dung dữ liệu và rút ra thông tin, điều mà có thể không rõ ràng ngay lập tức từ bảng hoặc bảng tính.

**Tại sao nên tạo biểu đồ?**

* tổng hợp, làm ngắn gọn hoặc tóm tắt lượng lớn dữ liệu trên một slide trong bản trình bày
* phát hiện các mẫu và xu hướng trong dữ liệu
* đưa ra hướng và tốc độ biến đổi của dữ liệu theo thời gian hoặc theo một đơn vị đo cụ thể
* phát hiện các giá trị ngoại lệ, sai lệch, lỗi, dữ liệu vô nghĩa, v.v.
* truyền đạt hoặc trình bày dữ liệu phức tạp

Trong PowerPoint, bạn có thể tạo biểu đồ thông qua chức năng chèn, cung cấp các mẫu dùng để thiết kế nhiều loại biểu đồ. Sử dụng Aspose.Slides, bạn có thể tạo các biểu đồ thông thường (dựa trên các loại biểu đồ phổ biến) và các biểu đồ tùy chỉnh.

{{% alert color="primary" %}} 
Để cho phép bạn tạo biểu đồ, Aspose.Slides cung cấp lớp [ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartType). Các trường trong lớp này tương ứng với các loại biểu đồ khác nhau.
{{% /alert %}} 

### **Tạo biểu đồ thông thường**

_Bước: Tạo biểu đồ_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Bước:</em> Tạo biểu đồ Presentation </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation </strong></a>

**Các bước mã:**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ bạn muốn.
4. Thêm tiêu đề cho biểu đồ.
5. Truy cập bảng tính dữ liệu của biểu đồ.
6. Xóa tất cả series và danh mục mặc định.
7. Thêm series và danh mục mới.
8. Thêm một số dữ liệu mới cho series của biểu đồ.
9. Thêm màu nền cho series của biểu đồ.
10. Thêm nhãn cho series của biểu đồ.
11. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách tạo biểu đồ thông thường:

```php
  # Tạo một thể hiện của lớp trình bày đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm một biểu đồ với dữ liệu mặc định của nó
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Đặt tiêu đề cho biểu đồ
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Đặt series đầu tiên hiển thị giá trị
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Đặt chỉ mục cho bảng dữ liệu của biểu đồ
    $defaultWorksheetIndex = 0;
    # Lấy WorkSheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Xóa các series và danh mục được tạo mặc định
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
    # Đặt nhãn đầu tiên để hiển thị tên Danh mục
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

Biểu đồ phân tán (còn gọi là scatter plot hoặc đồ thị x-y) thường được sử dụng để kiểm tra các mẫu hoặc thể hiện mối tương quan giữa hai biến.

Bạn có thể muốn sử dụng biểu đồ phân tán khi

* bạn có dữ liệu số đôi
* bạn có 2 biến phù hợp với nhau
* bạn muốn xác định liệu 2 biến có liên quan hay không
* bạn có một biến độc lập có nhiều giá trị cho một biến phụ thuộc

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Bước:</em> Tạo biểu đồ phân tán </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint phân tán </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation phân tán </strong></a>

1. Vui lòng làm theo các bước đã đề cập ở trên trong [Tạo biểu đồ thông thường](#creating-normal-charts)
2. Đối với bước thứ ba, Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ là một trong các tùy chọn sau
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Biểu thị biểu đồ phân tán._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Biểu thị biểu đồ phân tán được nối bằng các đường cong, có dấu dữ liệu._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Biểu thị biểu đồ phân tán được nối bằng các đường cong, không có dấu dữ liệu._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Biểu thị biểu đồ phân tán được nối bằng các đường thẳng, có dấu dữ liệu._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Biểu thị biểu đồ phân tán được nối bằng các đường thẳng, không có dấu dữ liệu._

Mã PHP này cho bạn thấy cách tạo các biểu đồ phân tán với các loạt dấu khác nhau:

```php
  # Khởi tạo một lớp trình bày đại diện cho tệp PPTX
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
    # Thay đổi marker của series biểu đồ
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Lấy series biểu đồ thứ hai
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Thêm một điểm mới (5:2) ở đó
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Thêm một điểm mới (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Thêm một điểm mới (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Thêm một điểm mới (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Thay đổi marker của series biểu đồ
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

Biểu đồ tròn thích hợp để thể hiện mối quan hệ phần‑trong‑toàn trong dữ liệu, đặc biệt khi dữ liệu có nhãn danh mục kèm giá trị số. Tuy nhiên, nếu dữ liệu của bạn có quá nhiều phần hoặc nhãn, bạn có thể cân nhắc sử dụng biểu đồ cột thay thế.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Bước:</em> Tạo biểu đồ tròn </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint tròn </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation tròn </strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại muốn (trong trường hợp này là [ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartType).Pie).
4. Truy cập [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa các series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu mới cho series của biểu đồ.
8. Thêm các điểm mới cho biểu đồ và thêm màu tùy chỉnh cho các sector của biểu đồ tròn.
9. Đặt nhãn cho series.
10. Đặt đường dẫn cho nhãn series.
11. Đặt góc quay cho các slide biểu đồ tròn.
12. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách tạo biểu đồ tròn:

```php
  # Khởi tạo một lớp trình bày đại diện cho tệp PPTX
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
    # Đặt chỉ mục cho bảng dữ liệu của biểu đồ
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Xóa các series và danh mục được tạo mặc định
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Thêm các danh mục mới
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
    # Thêm các điểm mới và đặt màu khu vực
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Đặt đường viền cho khu vực
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Đặt đường viền cho khu vực
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Đặt đường viền cho khu vực
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
    # Hiển thị các đường dẫn cho biểu đồ
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Đặt góc quay cho các khu vực biểu đồ tròn
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

Biểu đồ đường (còn gọi là đồ thị đường) thích hợp khi bạn muốn mô tả sự thay đổi giá trị theo thời gian. Sử dụng biểu đồ đường, bạn có thể so sánh nhiều dữ liệu cùng lúc, theo dõi thay đổi và xu hướng theo thời gian, làm nổi bật các bất thường trong series dữ liệu, v.v.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại muốn (trong trường hợp này là `ChartType::Line`).
4. Truy cập IChartDataWorkbook của biểu đồ.
5. Xóa các series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu mới cho series của biểu đồ.
8. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách tạo biểu đồ đường:

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

Mặc định, các điểm trên biểu đồ đường được nối bằng các đường thẳng liên tục. Nếu bạn muốn các điểm được nối bằng dải gạch, bạn có thể chỉ định loại gạch mong muốn như sau:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **Tạo biểu đồ cây (Tree Map)**

Biểu đồ cây (Tree Map) thích hợp cho dữ liệu bán hàng khi bạn muốn hiển thị kích thước tương đối của các danh mục dữ liệu và đồng thời nhanh chóng thu hút sự chú ý tới các mục đóng góp lớn cho mỗi danh mục.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Bước:</em> Tạo biểu đồ Tree Map </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Tree Map </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation Tree Map </strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại muốn (trong trường hợp này là [ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartType).TreeMap).
4. Truy cập [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa các series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu mới cho series của biểu đồ.
8. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách tạo biểu đồ Tree Map:

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

### **Tạo biểu đồ chứng khoán (Stock)**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Bước:</em> Tạo biểu đồ chứng khoán </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint chứng khoán </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation chứng khoán </strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại muốn ([ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartType).OpenHighLowClose).
4. Truy cập [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa các series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu mới cho series của biểu đồ.
8. Đặt định dạng HiLowLines.
9. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mẫu mã PHP dùng để tạo biểu đồ chứng khoán:

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
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tạo biểu đồ hộp và râu (Box and Whisker)**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Bước:</em> Tạo biểu đồ Box and Whisker </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Box and Whisker </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation Box and Whisker </strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại muốn ([ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartType).BoxAndWhisker).
4. Truy cập [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa các series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu mới cho series của biểu đồ.
8. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách tạo biểu đồ Box and Whisker:

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

### **Tạo biểu đồ phễu (Funnel)**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Bước:</em> Tạo biểu đồ Funnel </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Funnel </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation Funnel </strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại muốn ([ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartType).Funnel).
4. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP cho thấy cách tạo biểu đồ Funnel:

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

### **Tạo biểu đồ mặt trời (Sunburst)**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Bước:</em> Tạo biểu đồ Sunburst </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Sunburst </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation Sunburst </strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại muốn (trong trường hợp này là [ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartType).sunburst).
4. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách tạo biểu đồ Sunburst:

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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Bước:</em> Tạo biểu đồ Histogram </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Histogram </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation Histogram </strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại muốn ([ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartType).Histogram).
4. Truy cập [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa các series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách tạo biểu đồ histogram:

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

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Bước:</em> Tạo biểu đồ Radar </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Radar </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation Radar </strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ mong muốn (`ChartType::Radar` trong trường hợp này).
4. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách tạo biểu đồ Radar:

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

### **Tạo biểu đồ đa danh mục (Multi-Category)**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Bước:</em> Tạo biểu đồ Multi Category </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Multi Category </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation Multi Category </strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại muốn ([ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartType).ClusteredColumn).
4. Truy cập [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
5. Xóa các series và danh mục mặc định.
6. Thêm series và danh mục mới.
7. Thêm dữ liệu mới cho series của biểu đồ.
8. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách tạo biểu đồ đa danh mục:

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
    # Thêm series
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

### **Tạo biểu đồ bản đồ (Map)**

Biểu đồ bản đồ là một hình ảnh trực quan của một khu vực chứa dữ liệu. Biểu đồ bản đồ thích hợp để so sánh dữ liệu hoặc giá trị giữa các vùng địa lý.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Bước:</em> Tạo biểu đồ Map </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Map </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Bước:</em> Tạo biểu đồ PowerPoint Presentation Map </strong></a>

Mã PHP này cho bạn thấy cách tạo biểu đồ bản đồ:

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

### **Tạo biểu đồ kết hợp (Combination)**

Biểu đồ kết hợp (hay combo chart) kết hợp hai hoặc nhiều loại biểu đồ trong một đồ thị. Biểu đồ này cho phép bạn làm nổi bật, so sánh hoặc kiểm tra sự khác biệt giữa hai hoặc nhiều bộ dữ liệu, giúp xác định mối quan hệ giữa chúng.

![The combination chart](combination_chart.png)

Mã PHP sau đây cho thấy cách tạo biểu đồ kết hợp như trên trong một bản trình bày PowerPoint:

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

    // Đặt tiêu đề biểu đồ.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Đặt chú giải biểu đồ.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Xóa các series và danh mục được tạo mặc định.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Bước:</em> Cập nhật biểu đồ PowerPoint </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Bước:</em> Cập nhật biểu đồ Presentation </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Bước:</em> Cập nhật biểu đồ PowerPoint Presentation </strong></a>

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) đại diện cho bản trình bày chứa biểu đồ cần cập nhật.
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ số của nó.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập bảng tính dữ liệu của biểu đồ.
5. Sửa đổi dữ liệu series của biểu đồ bằng cách thay đổi giá trị series.
6. Thêm một series mới và điền dữ liệu vào đó.
7. Ghi bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách cập nhật một biểu đồ:

```php
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Lấy biểu đồ với dữ liệu mặc định
    $chart = $sld->getShapes()->get_Item(0);
    # Đặt chỉ mục của bảng dữ liệu biểu đồ
    $defaultWorksheetIndex = 0;
    # Lấy worksheet dữ liệu biểu đồ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Thay đổi tên danh mục của biểu đồ
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Lấy series đầu tiên của biểu đồ
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Bây giờ cập nhật dữ liệu series
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Sửa tên series

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Lấy series thứ hai của biểu đồ
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Bây giờ cập nhật dữ liệu series
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Sửa tên series

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
    # Lưu bản trình bày với biểu đồ
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt phạm vi dữ liệu cho biểu đồ**

Để đặt phạm vi dữ liệu cho biểu đồ, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) đại diện cho bản trình bày chứa biểu đồ.
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập dữ liệu biểu đồ và đặt phạm vi.
5. Lưu bản trình bày đã chỉnh sửa thành tập tin PPTX.

Mã PHP này cho bạn thấy cách đặt phạm vi dữ liệu cho một biểu đồ:

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

Khi bạn sử dụng dấu mặc định trong biểu đồ, mỗi series sẽ tự động nhận các ký hiệu dấu khác nhau.

Mã PHP này cho bạn thấy cách tự động đặt dấu cho series của biểu đồ:

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

Aspose.Slides hỗ trợ một loạt [các loại biểu đồ](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/), bao gồm cột, đường, tròn, vùng, phân tán, histogram, radar và nhiều loại khác. Tính linh hoạt này cho phép bạn chọn loại biểu đồ phù hợp nhất cho nhu cầu trực quan hoá dữ liệu của mình.

**Làm thế nào để thêm một biểu đồ mới vào slide?**

Để thêm một biểu đồ, trước tiên bạn tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) , lấy slide mong muốn bằng chỉ số, sau đó gọi phương thức để thêm biểu đồ, chỉ định loại biểu đồ và dữ liệu ban đầu. Quá trình này tích hợp biểu đồ trực tiếp vào bản trình bày của bạn.

**Làm sao tôi có thể cập nhật dữ liệu hiển thị trong biểu đồ?**

Bạn có thể cập nhật dữ liệu của biểu đồ bằng cách truy cập workbook dữ liệu của nó ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/)), xóa mọi series và danh mục mặc định, rồi thêm dữ liệu tùy chỉnh của bạn. Điều này cho phép bạn làm mới biểu đồ để phản ánh dữ liệu mới nhất.

**Có thể tùy chỉnh giao diện của biểu đồ không?**

Có, Aspose.Slides cung cấp các tùy chọn tùy chỉnh rộng rãi. Bạn có thể thay đổi màu sắc, phông chữ, nhãn, legend và các [các yếu tố định dạng](/slides/vi/php-java/chart-entities/) khác để điều chỉnh giao diện biểu đồ sao cho phù hợp với yêu cầu thiết kế cụ thể của bạn.