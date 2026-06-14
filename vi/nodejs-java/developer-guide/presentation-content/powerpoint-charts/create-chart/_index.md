---
title: Tạo hoặc Cập nhật Biểu đồ PowerPoint Presentation trong JavaScript
linktitle: Tạo hoặc Cập nhật Biểu đồ
type: docs
weight: 10
url: /vi/nodejs-java/create-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ trong bản trình bày PowerPoint bằng Aspose.Slides cho Node.js. Thêm, định dạng và chỉnh sửa biểu đồ với các ví dụ mã thực tế trong JavaScript."
---
## **Tổng quan**

Bài viết này cung cấp hướng dẫn toàn diện về cách tạo và tùy chỉnh biểu đồ bằng Aspose.Slides. Bạn sẽ học cách thêm biểu đồ vào slide một cách lập trình, đưa dữ liệu vào và áp dụng các tùy chọn định dạng khác nhau để đáp ứng yêu cầu thiết kế cụ thể của bạn. Toàn bộ bài viết kèm các ví dụ mã chi tiết cho mỗi bước, từ khởi tạo Presentation và đối tượng biểu đồ đến cấu hình series, trục và legend. Khi theo dõi hướng dẫn này, bạn sẽ nắm vững cách tích hợp việc tạo biểu đồ động vào ứng dụng, giúp đơn giản hoá quy trình tạo bản trình bày dựa trên dữ liệu.

## **Tạo biểu đồ**
Biểu đồ giúp người dùng nhanh chóng hình dung dữ liệu và rút ra những hiểu biết mà có thể không hiển thị rõ ràng trong bảng hoặc bảng tính.

**Lý do tạo biểu đồ?**

Sử dụng biểu đồ, bạn có thể

* tổng hợp, rút gọn hoặc tóm tắt lượng dữ liệu lớn trên một slide trong bản trình bày
* phát hiện các mẫu và xu hướng trong dữ liệu
* suy ra hướng và động lượng của dữ liệu theo thời gian hoặc theo một đơn vị đo cụ thể
* xác định các ngoại lệ, sai lệch, lỗi, dữ liệu vô nghĩa, v.v.
* truyền đạt hoặc trình bày dữ liệu phức tạp

Trong PowerPoint, bạn có thể tạo biểu đồ thông qua chức năng chèn, cung cấp các mẫu dùng để thiết kế nhiều loại biểu đồ. Với Aspose.Slides, bạn có thể tạo biểu đồ thường (dựa trên các loại biểu đồ phổ biến) và biểu đồ tùy chỉnh.

{{% alert color="primary" %}} 

Để cho phép bạn tạo biểu đồ, Aspose.Slides cung cấp lớp [ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartType). Các trường trong lớp này tương ứng với các loại biểu đồ khác nhau.

{{% /alert %}} 

### **Tạo biểu đồ bình thường**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint bằng JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Các bước:</em> Tạo biểu đồ Presentation bằng JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation bằng JavaScript</strong></a>

_Code Steps:_

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide qua chỉ mục của nó.
3. Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ ưa thích.
4. Thêm tiêu đề cho biểu đồ.
5. Truy cập worksheet dữ liệu biểu đồ.
6. Xóa tất cả series và category mặc định.
7. Thêm series và category mới.
8. Thêm dữ liệu biểu đồ mới cho series.
9. Thêm màu nền cho series.
10. Thêm nhãn cho series.
11. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ bình thường:

```javascript
// Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm biểu đồ với dữ liệu mặc định của nó
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Đặt tiêu đề cho biểu đồ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Đặt series đầu tiên để hiển thị giá trị
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Đặt chỉ mục cho bảng dữ liệu biểu đồ
    var defaultWorksheetIndex = 0;
    // Lấy WorkSheet dữ liệu của biểu đồ
    var fact = chart.getChartData().getChartDataWorkbook();
    // Xóa các series và category được tạo mặc định
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Thêm series mới
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Thêm category mới
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Lấy series biểu đồ đầu tiên
    var series = chart.getChartData().getSeries().get_Item(0);
    // Bây giờ điền dữ liệu cho series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Đặt màu nền cho series
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Lấy series biểu đồ thứ hai
    series = chart.getChartData().getSeries().get_Item(1);
    // Điền dữ liệu cho series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Đặt màu nền cho series
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Tạo nhãn tùy chỉnh cho mỗi category cho series mới
    // Đặt nhãn đầu tiên để hiển thị tên Category
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Hiển thị giá trị cho nhãn thứ ba
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Lưu bản trình bày kèm biểu đồ
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Scatter**

Biểu đồ scatter (còn gọi là scatter plot hoặc đồ thị x‑y) thường được dùng để kiểm tra mẫu hoặc thể hiện mối tương quan giữa hai biến.

Bạn có thể muốn sử dụng biểu đồ scatter khi

* bạn có dữ liệu số đôi
* bạn có 2 biến liên quan chặt chẽ với nhau
* bạn muốn xác định liệu 2 biến có liên quan hay không
* bạn có một biến độc lập có nhiều giá trị cho một biến phụ thuộc

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Các bước:</em> Tạo biểu đồ Scatter bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Scatter bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Scatter bằng JavaScript</strong></a>

1. Vui lòng làm theo các bước đã nêu ở mục [Creating Normal Charts](#creating-normal-charts)
2. Ở bước ba, thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ là một trong các lựa chọn sau
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Biểu diễn Scatter Chart có dấu đánh dấu._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Biểu diễn Scatter Chart nối bằng đường cong, có dấu đánh dấu dữ liệu._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Biểu diễn Scatter Chart nối bằng đường cong, không có dấu đánh dấu dữ liệu._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Biểu diễn Scatter Chart nối bằng đường thẳng, có dấu đánh dấu dữ liệu._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Biểu diễn Scatter Chart nối bằng đường thẳng, không có dấu đánh dấu dữ liệu._

Mã JavaScript dưới đây cho thấy cách tạo các biểu đồ scatter với các loại dấu đánh dấu khác nhau:

```javascript
// Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Tạo biểu đồ mặc định
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Lấy chỉ mục worksheet dữ liệu biểu đồ mặc định
    var defaultWorksheetIndex = 0;
    // Lấy worksheet dữ liệu của biểu đồ
    var fact = chart.getChartData().getChartDataWorkbook();
    // Xóa series demo
    chart.getChartData().getSeries().clear();
    // Thêm series mới
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Lấy series biểu đồ đầu tiên
    var series = chart.getChartData().getSeries().get_Item(0);
    // Thêm một điểm mới (1:3) vào series
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Thêm một điểm mới (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Thay đổi kiểu series
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Thay đổi marker của series biểu đồ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Lấy series biểu đồ thứ hai
    series = chart.getChartData().getSeries().get_Item(1);
    // Thêm một điểm mới (5:2) ở đó
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Thêm một điểm mới (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Thêm một điểm mới (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Thêm một điểm mới (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Thay đổi marker của series biểu đồ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Pie**

Biểu đồ Pie thích hợp nhất để hiển thị mối quan hệ phần‑trong‑toàn trong dữ liệu, đặc biệt khi dữ liệu có nhãn phân loại kèm giá trị số. Tuy nhiên, nếu dữ liệu của bạn có quá nhiều phần hoặc nhãn, bạn có thể cân nhắc dùng biểu đồ cột thay thế.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Các bước:</em> Tạo biểu đồ Pie bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Pie bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Pie bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide qua chỉ mục.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn (trong trường hợp này là [ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartType).Pie).
4. Truy cập dữ liệu biểu đồ qua [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Xóa series và category mặc định.
6. Thêm series và category mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Thêm các điểm mới cho biểu đồ và chỉ định màu tùy chỉnh cho các phần của biểu đồ Pie.
9. Đặt nhãn cho series.
10. Đặt đường dẫn dẫn cho nhãn series.
11. Đặt góc quay cho các slide biểu đồ Pie.
12. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Pie:

```javascript
// Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slides = pres.getSlides().get_Item(0);
    // Thêm một biểu đồ với dữ liệu mặc định
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Đặt tiêu đề cho biểu đồ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Đặt series đầu tiên để hiển thị giá trị
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Đặt chỉ mục cho worksheet dữ liệu của biểu đồ
    var defaultWorksheetIndex = 0;
    // Lấy worksheet dữ liệu của biểu đồ
    var fact = chart.getChartData().getChartDataWorkbook();
    // Xóa các series và category được tạo mặc định
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Thêm các category mới
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Thêm series mới
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Điền dữ liệu cho series
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Không hoạt động trong phiên bản mới
    // Thêm các điểm mới và thiết lập màu cho sector
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Đặt đường viền cho sector
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Đặt đường viền cho sector
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Đặt đường viền cho sector
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Tạo nhãn tùy chỉnh cho mỗi category cho series mới
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Hiển thị các Leader Line cho biểu đồ
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Đặt góc xoay cho các sector của biểu đồ Pie
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Lưu bản trình bày kèm biểu đồ
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Line**

Biểu đồ Line (còn gọi là đồ thị đường) thích hợp trong các trường hợp bạn muốn minh họa sự thay đổi giá trị theo thời gian. Với biểu đồ line, bạn có thể so sánh nhiều dữ liệu cùng lúc, theo dõi xu hướng và thay đổi theo thời gian, nổi bật các bất thường trong series dữ liệu, v.v.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Lấy tham chiếu của slide qua chỉ mục.
1. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn (trong trường hợp này là `ChartType.Line`).
1. Truy cập dữ liệu biểu đồ qua IChartDataWorkbook.
1. Xóa series và category mặc định.
1. Thêm series và category mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Line:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Mặc định, các điểm trên biểu đồ line được nối bằng các đường thẳng liên tục. Nếu bạn muốn các điểm được nối bằng dấu gạch, bạn có thể chỉ định kiểu gạch mong muốn như sau:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **Tạo biểu đồ Tree Map**

Biểu đồ Tree Map thích hợp cho dữ liệu bán hàng khi bạn muốn hiển thị kích thước tương đối của các danh mục dữ liệu và đồng thời nhanh chóng thu hút sự chú ý đến các mục đóng góp lớn cho mỗi danh mục.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ Tree Map bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Tree Map bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Tree Map bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ mục.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn (trong trường hợp này là [ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartType).TreeMap).
4. Truy cập dữ liệu biểu đồ qua [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Xóa series và category mặc định.
6. Thêm series và category mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Tree Map:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // nhánh 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // nhánh 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Stock**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Các bước:</em> Tạo biểu đồ Stock bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Stock bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Stock bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ mục.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartType).OpenHighLowClose).
4. Truy cập dữ liệu biểu đồ qua [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Xóa series và category mặc định.
6. Thêm series và category mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Chỉ định định dạng HiLowLines.
9. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript mẫu dùng để tạo một biểu đồ Stock:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Box and Whisker**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Các bước:</em> Tạo biểu đồ Box and Whisker bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Box and Whisker bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Box and Whisker bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ mục.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartType).BoxAndWhisker).
4. Truy cập dữ liệu biểu đồ qua [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Xóa series và category mặc định.
6. Thêm series và category mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Box and Whisker:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Funnel**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Các bước:</em> Tạo biểu đồ Funnel bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Funnel bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Funnel bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ mục.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartType).Funnel).
4. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Funnel:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Sunburst**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Các bước:</em> Tạo biểu đồ Sunburst bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Sunburst bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Sunburst bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ mục.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn (trong trường hợp này là [ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartType).sunburst).
4. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Sunburst:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // nhánh 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // nhánh 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Histogram**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Các bước:</em> Tạo biểu đồ Histogram bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Histogram bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Histogram bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ mục.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartType).Histogram).
4. Truy cập dữ liệu biểu đồ qua [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Xóa series và category mặc định.
6. Thêm series và category mới.
7. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Histogram:

```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Tạo biểu đồ Radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Các bước:</em> Tạo biểu đồ Radar bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Radar bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Radar bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ mục. 
3. Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ ưa thích (`ChartType.Radar` trong trường hợp này).
4. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Radar:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Multi Category**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Các bước:</em> Tạo biểu đồ Multi Category bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Multi Category bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Multi Category bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ mục. 
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartType).ClusteredColumn).
4. Truy cập dữ liệu biểu đồ qua [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Xóa series và category mặc định.
6. Thêm series và category mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Multi Category:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Thêm Series
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Lưu bản trình bày kèm biểu đồ
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Map**

Biểu đồ Map là một hình ảnh trực quan của một khu vực chứa dữ liệu. Biểu đồ Map thích hợp để so sánh dữ liệu hoặc giá trị giữa các khu vực địa lý.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ Map bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Map bằng JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation Map bằng JavaScript</strong></a>

Mã JavaScript dưới đây cho thấy cách tạo một biểu đồ Map:

```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo biểu đồ Combination**

Biểu đồ Combination (hoặc combo chart) kết hợp hai hoặc nhiều loại biểu đồ trong một đồ thị duy nhất. Biểu đồ này cho phép bạn làm nổi bật, so sánh hoặc kiểm tra sự khác biệt giữa hai hoặc nhiều bộ dữ liệu, giúp xác định mối quan hệ giữa chúng.

![The combination chart](combination_chart.png)

Mã JavaScript dưới đây cho thấy cách tạo biểu đồ Combination như hình trên trong một bản trình bày PowerPoint:

```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Đặt tiêu đề cho biểu đồ.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Đặt chú giải cho biểu đồ.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Xóa series và category được tạo mặc định.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Thêm các category mới.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Thêm series đầu tiên.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Đặt trục ngang.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Đặt trục dọc.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Đặt màu cho đường lưới chính dọc.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Đặt trục ngang phụ.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Đặt trục dọc phụ.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Cập nhật biểu đồ**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Các bước:</em> Cập nhật biểu đồ PowerPoint bằng JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Các bước:</em> Cập nhật biểu đồ Presentation bằng JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Các bước:</em> Cập nhật biểu đồ PowerPoint Presentation bằng JavaScript</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) đại diện cho bản trình bày chứa biểu đồ cần cập nhật.
2. Lấy tham chiếu của slide bằng chỉ mục.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập worksheet dữ liệu biểu đồ.
5. Sửa dữ liệu series của biểu đồ bằng cách thay đổi giá trị series.
6. Thêm một series mới và điền dữ liệu vào đó.
7. Ghi bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách cập nhật một biểu đồ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Lấy biểu đồ với dữ liệu mặc định
    var chart = sld.getShapes().get_Item(0);
    // Đặt chỉ mục của sheet dữ liệu biểu đồ
    var defaultWorksheetIndex = 0;
    // Lấy worksheet dữ liệu biểu đồ
    var fact = chart.getChartData().getChartDataWorkbook();
    // Thay đổi tên Category của biểu đồ
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Lấy series đầu tiên của biểu đồ
    var series = chart.getChartData().getSeries().get_Item(0);
    // Bây giờ cập nhật dữ liệu cho series
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Sửa tên series
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Lấy series thứ hai của biểu đồ
    series = chart.getChartData().getSeries().get_Item(1);
    // Bây giờ cập nhật dữ liệu cho series
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Sửa tên series
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Bây giờ, thêm một series mới
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Lấy series thứ ba của biểu đồ
    series = chart.getChartData().getSeries().get_Item(2);
    // Bây giờ điền dữ liệu cho series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Lưu bản trình bày kèm biểu đồ
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt phạm vi dữ liệu cho biểu đồ**

Để đặt phạm vi dữ liệu cho một biểu đồ, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) đại diện cho bản trình bày chứa biểu đồ.
2. Lấy tham chiếu của slide qua chỉ mục.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập dữ liệu biểu đồ và đặt phạm vi.
5. Lưu bản trình bày đã chỉnh sửa thành file PPTX.

Mã JavaScript dưới đây cho thấy cách đặt phạm vi dữ liệu cho một biểu đồ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sử dụng marker mặc định trong biểu đồ**
Khi bạn sử dụng marker mặc định trong biểu đồ, mỗi series sẽ tự động nhận được một ký hiệu marker mặc định khác nhau.

Mã JavaScript dưới đây cho thấy cách tự động đặt marker cho một series:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Lấy series thứ hai của biểu đồ
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Bây giờ đang điền dữ liệu cho series
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Các loại biểu đồ nào được Aspose.Slides hỗ trợ?**

Aspose.Slides hỗ trợ đa dạng các loại biểu đồ, bao gồm bar, line, pie, area, scatter, histogram, radar và nhiều loại khác. Sự linh hoạt này cho phép bạn chọn loại biểu đồ phù hợp nhất cho nhu cầu trực quan hoá dữ liệu của mình.

**Làm sao để thêm biểu đồ mới vào slide?**

Để thêm biểu đồ, trước tiên bạn tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) , lấy slide mong muốn bằng chỉ mục, sau đó gọi phương thức thêm biểu đồ, chỉ định loại biểu đồ và dữ liệu ban đầu. Quá trình này tích hợp biểu đồ trực tiếp vào bản trình bày.

**Làm sao tôi có thể cập nhật dữ liệu hiển thị trong biểu đồ?**

Bạn có thể cập nhật dữ liệu của biểu đồ bằng cách truy cập workbook dữ liệu của nó ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/)), xóa các series và category mặc định, sau đó thêm dữ liệu tùy chỉnh của bạn. Điều này cho phép bạn làm mới biểu đồ một cách lập trình để phản ánh dữ liệu mới nhất.

**Có thể tùy chỉnh giao diện của biểu đồ không?**

Có, Aspose.Slides cung cấp các tùy chọn tùy chỉnh phong phú. Bạn có thể thay đổi màu sắc, font, nhãn, legend và các yếu tố định dạng khác để điều chỉnh giao diện biểu đồ cho phù hợp với yêu cầu thiết kế của mình.