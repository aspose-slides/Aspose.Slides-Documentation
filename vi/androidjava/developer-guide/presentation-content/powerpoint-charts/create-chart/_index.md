---
title: Tạo hoặc Cập nhật Biểu đồ Bài thuyết trình PowerPoint trên Android
linktitle: Tạo hoặc Cập nhật Biểu đồ
type: docs
weight: 10
url: /vi/androidjava/create-chart/
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
- biểu đồ dạng sunburst
- biểu đồ histogram
- biểu đồ radar
- biểu đồ đa danh mục
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ trong các bài thuyết trình PowerPoint bằng Aspose.Slides cho Android. Thêm, định dạng và chỉnh sửa biểu đồ với các ví dụ mã Java thực tế."
---
## **Tổng quan**

Bài viết này cung cấp hướng dẫn toàn diện về cách tạo và tùy chỉnh biểu đồ bằng Aspose.Slides. Bạn sẽ học cách lập trình để thêm biểu đồ vào slide, điền dữ liệu và áp dụng các tùy chọn định dạng khác nhau sao cho phù hợp với yêu cầu thiết kế của mình. Trong suốt bài viết, các ví dụ mã chi tiết minh họa từng bước, từ khởi tạo Presentation và đối tượng biểu đồ đến cấu hình series, trục và chú giải. Khi theo dõi hướng dẫn này, bạn sẽ nắm vững cách tích hợp việc tạo biểu đồ động vào ứng dụng, giúp đơn giản hoá quá trình tạo các bản thuyết trình dựa trên dữ liệu.

## **Tạo biểu đồ**
Biểu đồ giúp người dùng nhanh chóng hình dung dữ liệu và rút ra những hiểu biết có thể không hiện ra ngay trong bảng hoặc bảng tính.

**Tại sao tạo biểu đồ?**

Sử dụng biểu đồ, bạn có thể

* tổng hợp, cô đọng hoặc tóm tắt lượng dữ liệu lớn trên một slide trong bản thuyết trình
* hiển thị các mẫu và xu hướng trong dữ liệu
* suy ra hướng và động lực của dữ liệu theo thời gian hoặc theo một đơn vị đo cụ thể
* phát hiện các ngoại lệ, sai lệch, lỗi, dữ liệu vô nghĩa, v.v.
* truyền đạt hoặc trình bày dữ liệu phức tạp

Trong PowerPoint, bạn có thể tạo biểu đồ thông qua chức năng chèn, cung cấp các mẫu thiết kế cho nhiều loại biểu đồ. Khi dùng Aspose.Slides, bạn có thể tạo biểu đồ thông thường (dựa trên các loại biểu đồ phổ biến) và biểu đồ tùy chỉnh.

{{% alert color="info" %}} 

Để cho phép bạn tạo biểu đồ, Aspose.Slides cung cấp lớp [ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartType). Các trường trong lớp này tương ứng với các loại biểu đồ khác nhau.

{{% /alert %}} 

### **Tạo biểu đồ thường**

*_Các bước: Tạo biểu đồ_*
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint trong Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Các bước:</em> Tạo biểu đồ Presentation trong Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Các bước:</em> Tạo biểu đồ PowerPoint Presentation trong Java</strong></a>

_Các bước mã:_

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ bạn muốn.
4. Thêm tiêu đề cho biểu đồ.
5. Truy cập worksheet dữ liệu biểu đồ.
6. Xóa tất cả series và categories mặc định.
7. Thêm series và categories mới.
8. Thêm dữ liệu biểu đồ mới cho series.
9. Thêm màu nền cho series.
10. Thêm nhãn cho series.
11. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách tạo một biểu đồ thường:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Thêm một biểu đồ với dữ liệu mặc định
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Đặt tiêu đề cho biểu đồ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Đặt chỉ số cho trang dữ liệu biểu đồ
    int defaultWorksheetIndex = 0;
    
    // Lấy worksheet dữ liệu biểu đồ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Xóa các series và categories được tạo mặc định
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Thêm series mới
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Thêm categories mới
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Lấy series biểu đồ đầu tiên
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Bây giờ điền dữ liệu cho series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Đặt màu nền cho series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Lấy series biểu đồ thứ hai
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Điền dữ liệu cho series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Đặt màu nền cho series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Tạo nhãn tùy chỉnh cho mỗi category cho series mới
    // Đặt nhãn đầu tiên để hiển thị tên Category
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Hiển thị giá trị cho nhãn thứ ba
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Lưu bản thuyết trình kèm biểu đồ
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ phân tán**

Biểu đồ phân tán (còn được gọi là scatter plot hoặc đồ thị x‑y) thường được dùng để kiểm tra các mẫu hoặc chứng minh mối tương quan giữa hai biến.

Bạn có thể muốn sử dụng biểu đồ phân tán khi

* bạn có dữ liệu số ghép đôi
* bạn có 2 biến phù hợp với nhau
* bạn muốn xác định liệu 2 biến có liên quan hay không
* bạn có biến độc lập có nhiều giá trị cho một biến phụ thuộc

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Các bước:</em> Tạo biểu đồ phân tán trong Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Các bước:</em> Tạo biểu đồ phân tán PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Các bước:</em> Tạo biểu đồ phân tán PowerPoint Presentation trong Java</strong></a>

1. Vui lòng làm theo các bước đã nêu ở trên trong [Tạo biểu đồ thường](#creating-normal-charts)
2. Đối với bước thứ ba, Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ là một trong các tùy chọn sau
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Đại diện cho biểu đồ phân tán._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Đại diện cho biểu đồ phân tán nối bằng đường cong, có biểu tượng dữ liệu._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Đại diện cho biểu đồ phân tán nối bằng đường cong, không có biểu tượng dữ liệu._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Đại diện cho biểu đồ phân tán nối bằng đường thẳng, có biểu tượng dữ liệu._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Đại diện cho biểu đồ phân tán nối bằng đường thẳng, không có biểu tượng dữ liệu._

Mã Java này cho thấy cách tạo các biểu đồ phân tán với các series dấu hiệu khác nhau:

```java
import com.aspose.slides.*;

// Khởi tạo một lớp presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);

    // Tạo biểu đồ mặc định
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Lấy chỉ số worksheet dữ liệu biểu đồ mặc định
    int defaultWorksheetIndex = 0;
    
    // Lấy worksheet dữ liệu biểu đồ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Xóa series mẫu
    chart.getChartData().getSeries().clear();
    
    // Thêm series mới
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Lấy series biểu đồ đầu tiên
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Thêm một điểm mới (1:3) vào series
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Thêm một điểm mới (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Thay đổi loại series
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Thay đổi marker của series biểu đồ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Lấy series biểu đồ thứ hai
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Thêm một điểm mới (5:2) vào đó
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Thêm một điểm mới (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Thêm một điểm mới (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Thêm một điểm mới (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Thay đổi marker của series biểu đồ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ tròn**

Biểu đồ tròn thích hợp để hiển thị mối quan hệ phần‑trong‑toàn trong dữ liệu, đặc biệt khi dữ liệu có các nhãn phân loại kèm giá trị số. Tuy nhiên, nếu dữ liệu của bạn có quá nhiều phần hoặc nhãn, bạn nên cân nhắc sử dụng biểu đồ cột thay thế.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Các bước:</em> Tạo biểu đồ tròn trong Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Các bước:</em> Tạo biểu đồ tròn PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Các bước:</em> Tạo biểu đồ tròn PowerPoint Presentation trong Java</strong></a>

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn (trong trường hợp này là [ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartType).Pie).
4. Truy cập workbook dữ liệu biểu đồ [IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Xóa các series và categories mặc định.
6. Thêm series và categories mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Thêm các điểm mới cho biểu đồ và thêm màu tùy chỉnh cho các sector của biểu đồ tròn.
9. Đặt nhãn cho series.
10. Đặt đường dẫn cho nhãn series.
11. Đặt góc quay cho các slide biểu đồ tròn.
12. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách tạo một biểu đồ tròn:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo một lớp presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Thêm một biểu đồ với dữ liệu mặc định
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Đặt tiêu đề cho biểu đồ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Đặt chỉ số cho trang dữ liệu biểu đồ
    int defaultWorksheetIndex = 0;
    
    // Lấy worksheet dữ liệu biểu đồ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Xóa các series và categories được tạo mặc định
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Thêm các category mới
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Thêm series mới
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Populates the series data
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Not working in new version
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Đặt viền cho sector
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Đặt viền cho sector
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Đặt viền cho sector
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Tạo nhãn tùy chỉnh cho mỗi category cho series mới
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Hiển thị Leader Lines cho biểu đồ
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Đặt góc quay cho các sector của biểu đồ tròn
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Lưu bản thuyết trình kèm biểu đồ
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ đường**

Biểu đồ đường (còn gọi là line graph) thích hợp khi bạn muốn minh họa sự thay đổi giá trị theo thời gian. Với biểu đồ đường, bạn có thể so sánh nhiều dữ liệu cùng lúc, theo dõi các thay đổi và xu hướng theo thời gian, làm nổi bật các bất thường trong series dữ liệu, v.v.

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Lấy tham chiếu của một slide thông qua chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn (trong trường hợp này là `ChartType.Line`).
1. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách tạo một biểu đồ đường:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Mặc định, các điểm trên biểu đồ đường được nối bằng các đường thẳng liên tục. Nếu bạn muốn các điểm được nối bằng dấu gạch ngang, bạn có thể chỉ định kiểu gạch ngang ưa thích như sau:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ cây (Tree Map)**

Biểu đồ cây thích hợp cho dữ liệu bán hàng khi bạn muốn hiển thị kích thước tương đối của các danh mục dữ liệu và đồng thời nhanh chóng thu hút sự chú ý đến các mục đóng góp lớn cho mỗi danh mục.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ Tree Map trong Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ Tree Map PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ Tree Map PowerPoint Presentation trong Java</strong></a>

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn (trong trường hợp này là [ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartType).TreeMap).
4. Truy cập workbook dữ liệu biểu đồ [IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Xóa các series và categories mặc định.
6. Thêm series và categories mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách tạo một biểu đồ Tree Map:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //nhánh 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //nhánh 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ chứng khoán (Stock)**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Các bước:</em> Tạo biểu đồ chứng khoán trong Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Các bước:</em> Tạo biểu đồ chứng khoán PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Các bước:</em> Tạo biểu đồ chứng khoán PowerPoint Presentation trong Java</strong></a>

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartType).OpenHighLowClose).
4. Truy cập workbook dữ liệu biểu đồ [IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Xóa các series và categories mặc định.
6. Thêm series và categories mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Xác định định dạng HiLowLines.
9. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java mẫu dùng để tạo biểu đồ chứng khoán:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ hộp và râu (Box and Whisker)**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Các bước:</em> Tạo biểu đồ Box and Whisker trong Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Các bước:</em> Tạo biểu đồ Box and Whisker PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Các bước:</em> Tạo biểu đồ Box and Whisker PowerPoint Presentation trong Java</strong></a>

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartType).BoxAndWhisker).
4. Truy cập workbook dữ liệu biểu đồ [IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Xóa các series và categories mặc định.
6. Thêm series và categories mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách tạo một biểu đồ Box and Whisker:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ phễu (Funnel)**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Các bước:</em> Tạo biểu đồ Funnel trong Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Các bước:</em> Tạo biểu đồ Funnel PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Các bước:</em> Tạo biểu đồ Funnel PowerPoint Presentation trong Java</strong></a>

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartType).Funnel).
4. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java cho thấy cách tạo một biểu đồ Funnel:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ bùng nổ (Sunburst)**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Các bước:</em> Tạo biểu đồ Sunburst trong Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Các bước:</em> Tạo biểu đồ Sunburst PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Các bước:</em> Tạo biểu đồ Sunburst PowerPoint Presentation trong Java</strong></a>

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn (trong trường hợp này là [ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartType).sunburst).
4. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách tạo một biểu đồ Sunburst:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //nhánh 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //nhánh 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ histogram**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Các bước:</em> Tạo biểu đồ Histogram trong Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Các bước:</em> Tạo biểu đồ Histogram PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Các bước:</em> Tạo biểu đồ Histogram PowerPoint Presentation trong Java</strong></a>

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartType).Histogram).
4. Truy cập workbook dữ liệu biểu đồ [IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Xóa các series và categories mặc định.
6. Thêm series và categories mới.
7. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách tạo một biểu đồ histogram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Các bước:</em> Tạo biểu đồ Radar trong Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Các bước:</em> Tạo biểu đồ Radar PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Các bước:</em> Tạo biểu đồ Radar PowerPoint Presentation trong Java</strong></a>

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ ưa thích (`ChartType.Radar` trong trường hợp này).
4. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách tạo một biểu đồ Radar:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ đa danh mục (Multi‑Category)**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Các bước:</em> Tạo biểu đồ Multi Category trong Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Các bước:</em> Tạo biểu đồ Multi Category PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Các bước:</em> Tạo biểu đồ Multi Category PowerPoint Presentation trong Java</strong></a>

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng loại mong muốn ([ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartType).ClusteredColumn).
4. Truy cập workbook dữ liệu biểu đồ [IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Xóa các series và categories mặc định.
6. Thêm series và categories mới.
7. Thêm dữ liệu biểu đồ mới cho series.
8. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách tạo một biểu đồ đa danh mục:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Lưu bản thuyết trình kèm biểu đồ
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ bản đồ (Map)**

Biểu đồ bản đồ là một hình ảnh trực quan của một khu vực chứa dữ liệu. Biểu đồ bản đồ thích hợp để so sánh dữ liệu hoặc giá trị trên các vùng địa lý khác nhau.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ bản đồ trong Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ bản đồ PowerPoint trong Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Các bước:</em> Tạo biểu đồ bản đồ PowerPoint Presentation trong Java</strong></a>

Mã Java này cho thấy cách tạo một biểu đồ bản đồ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tạo biểu đồ kết hợp (Combination)**

Biểu đồ kết hợp (hoặc combo chart) kết hợp hai hay nhiều loại biểu đồ trong một đồ thị duy nhất. Biểu đồ này cho phép bạn làm nổi bật, so sánh hoặc kiểm tra sự khác biệt giữa hai hoặc nhiều bộ dữ liệu, giúp xác định mối quan hệ giữa chúng.

![Biểu đồ kết hợp](combination_chart.png)

Mã Java dưới đây cho thấy cách tạo biểu đồ kết hợp như hình trên trong một bản thuyết trình PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Đặt tiêu đề cho biểu đồ.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Đặt chú giải cho biểu đồ.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Xóa các series và categories được tạo mặc định.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Thêm các category mới.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Thêm series đầu tiên.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Đặt trục ngang.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Đặt trục dọc.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Đặt màu cho các đường lưới chính dọc.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Đặt trục ngang phụ.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Đặt trục dọc phụ.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Cập nhật biểu đồ**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Các bước:</em> Cập nhật biểu đồ PowerPoint trong Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Các bước:</em> Cập nhật biểu đồ Presentation trong Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Các bước:</em> Cập nhật biểu đồ PowerPoint Presentation trong Java</strong></a>

1. Khởi tạo một lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) đại diện cho bản thuyết trình chứa biểu đồ cần cập nhật.
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ số của nó.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập worksheet dữ liệu biểu đồ.
5. Sửa đổi dữ liệu series bằng cách thay đổi giá trị series.
6. Thêm một series mới và điền dữ liệu vào nó.
7. Ghi bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách cập nhật một biểu đồ:

```java
import com.aspose.slides.*;

// Mở bản thuyết trình chứa biểu đồ cần cập nhật
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Lấy biểu đồ từ slide
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Đặt chỉ số của trang dữ liệu biểu đồ
    int defaultWorksheetIndex = 0;

    // Lấy worksheet dữ liệu biểu đồ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Thay đổi tên Category của biểu đồ
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Lấy series biểu đồ đầu tiên
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Bây giờ cập nhật dữ liệu series
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Sửa tên series
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Lấy series biểu đồ thứ hai
    series = chart.getChartData().getSeries().get_Item(1);

    // Bây giờ cập nhật dữ liệu series
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Sửa tên series
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Bây giờ, Thêm một series mới
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Lấy series biểu đồ thứ ba
    series = chart.getChartData().getSeries().get_Item(2);

    // Bây giờ điền dữ liệu cho series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Lưu bản thuyết trình kèm biểu đồ
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt phạm vi dữ liệu cho biểu đồ**

Để đặt phạm vi dữ liệu cho biểu đồ, thực hiện các bước sau:

1. Khởi tạo một lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) đại diện cho bản thuyết trình chứa biểu đồ.
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập dữ liệu biểu đồ và đặt phạm vi.
5. Lưu bản thuyết trình đã chỉnh sửa thành tệp PPTX.

Mã Java này cho thấy cách đặt phạm vi dữ liệu cho một biểu đồ:

```java
import com.aspose.slides.*;

// Mở bản thuyết trình chứa biểu đồ
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sử dụng dấu hiệu mặc định trong biểu đồ**
Khi bạn sử dụng dấu hiệu mặc định trong biểu đồ, mỗi series sẽ tự động nhận các ký hiệu mặc định khác nhau.

Mã Java này cho thấy cách thiết lập dấu hiệu series tự động:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Lấy series biểu đồ thứ hai
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Bây giờ điền dữ liệu cho series
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

### Các loại biểu đồ nào được Aspose.Slides hỗ trợ?

Aspose.Slides hỗ trợ một loạt các [chart types](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/), bao gồm bar, line, pie, area, scatter, histogram, radar và nhiều loại khác. Sự linh hoạt này cho phép bạn chọn loại biểu đồ phù hợp nhất cho nhu cầu hiển thị dữ liệu của mình.

### Làm thế nào để thêm một biểu đồ mới vào slide?

Để thêm biểu đồ, trước tiên bạn tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) , lấy slide mong muốn bằng chỉ số, sau đó gọi phương thức để thêm biểu đồ, chỉ định loại biểu đồ và dữ liệu ban đầu. Quy trình này tích hợp biểu đồ trực tiếp vào bản thuyết trình của bạn.

### Làm sao để cập nhật dữ liệu hiển thị trong biểu đồ?

Bạn có thể cập nhật dữ liệu của biểu đồ bằng cách truy cập workbook dữ liệu của nó ([IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/)), xóa bất kỳ series và categories mặc định nào, rồi thêm dữ liệu tùy chỉnh của bạn. Điều này cho phép bạn làm mới biểu đồ để phản ánh dữ liệu mới nhất.

### Có thể tùy chỉnh giao diện của biểu đồ không?

Có, Aspose.Slides cung cấp nhiều tùy chọn tùy chỉnh. Bạn có thể thay đổi màu sắc, phông chữ, nhãn, chú giải và các [formatting elements](/slides/vi/androidjava/chart-entities/) khác để điều chỉnh giao diện biểu đồ sao cho phù hợp với yêu cầu thiết kế cụ thể của bạn.