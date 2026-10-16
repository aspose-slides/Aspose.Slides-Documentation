---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trong Java
linktitle: Đường Xu Hướng
type: docs
url: /vi/java/trend-line/
keywords:
- biểu đồ
- đường xu hướng
- đường xu hướng hàm mũ
- đường xu hướng tuyến tính
- đường xu hướng logarit
- đường xu hướng trung bình động
- đường xu hướng đa thức
- đường xu hướng lũy thừa
- đường xu hướng tùy chỉnh
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint bằng Aspose.Slides cho Java — hướng dẫn thực tiễn để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm đường xu hướng vào biểu đồ trong bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó chỉ ra cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi dữ liệu của biểu đồ và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Hỏi Đáp ngắn về các giá trị chiếu hướng về phía trước và phía sau của đường xu hướng và việc các đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi hiển thị biểu đồ dưới dạng hình ảnh hay không.

## **Thêm đường xu hướng**

Use [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) để thêm một đường xu hướng vào chuỗi dữ liệu của biểu đồ, chọn loại bằng [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). Ví dụ tạo một biểu đồ cột nhóm với dữ liệu mặc định và thêm hai đường xu hướng cho mỗi trong ba chuỗi của nó.

The exponential trend line hides its equation and R-squared value through [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) và [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), while the linear trend line is red. The logarithmic trend line uses [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) for a custom label. The moving average uses a [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) of three data points and a custom [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

The polynomial trend line has an [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) of three and extends one category forward through [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). The power trend line extends one category backward through [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt giao điểm cho đường xu hướng**

Use [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) để cố định giá trị Y của đường xu hướng tại X = 0. Cài đặt này được hỗ trợ cho các đường xu hướng tuyến tính, hàm mũ và đa thức.

Ví dụ, một mô hình chi phí sản xuất có thể cần bắt đầu ở chi phí cố định đã biết là 100, ngay cả khi các đo lường ở mức sản lượng không bằng không gợi ý một nền tảng khác. Đối với một đường xu hướng tuyến tính, việc cố định giao điểm làm ràng buộc phương trình `y = ax + b` thành `b = 100`; hệ số góc được điều chỉnh để phù hợp với dữ liệu dưới ràng buộc đó. Nó không chỉ di chuyển một đường đã được điều chỉnh. Cài đặt giao điểm trục kiểm soát nơi các trục biểu đồ gặp nhau, không phải các hệ số của đường xu hướng đã điều chỉnh.

Ví dụ sau tạo một biểu đồ scatter (XY) với sản lượng từ 1 đến 4 và chi phí 170, 200, 230 và 260. Nó lưu biểu đồ với giao điểm tự động mặc định, đặt giao điểm thành 100 và lưu một PPTX thứ hai. Hai tệp chỉ khác nhau ở cài đặt giao điểm. Đường xu hướng hiển thị phương trình và kéo về X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Với tính toán tự động, những dữ liệu này tạo ra `y = 30x + 140`. Đặt giao điểm thành 100 thay vào đó tạo ra xấp xỉ `y = 43.33x + 100`: giá trị điều chỉnh tại zero phù hợp với nền tảng đã biết, trong khi đường không còn đi qua mọi điểm dữ liệu.

| Giao điểm tự động | Giao điểm cố định 100 |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

Both images use the same data and axis scales. The trend lines are extended back to X = 0 to show their intercepts.

By default, [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) returns `Double.NaN`, which represents an unspecified intercept rather than zero. The intercept is then calculated automatically from the data.

## **Thêm đường tùy chỉnh**

A custom line is a shape drawn over the chart rather than a trend line calculated from series data. This example uses [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) to add a horizontal line to the slide over the chart. The line's position is specified in slide coordinates, measured in points, so it starts at the chart's left edge and sits halfway down the chart. Its width matches the chart's width. The [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) gives the line a solid red color.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**'Forward' và 'backward' có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng chiếu về phía trước hoặc phía sau: đối với biểu đồ scatter (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải scatter — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Liệu đường xu hướng có được giữ lại khi xuất bản trình chiếu sang PDF hoặc SVG, hoặc khi hiển thị một slide dưới dạng hình ảnh không?**

Yes. Aspose.Slides converts presentations to [PDF](/slides/vi/java/convert-powerpoint-to-pdf/) or [SVG](/slides/vi/java/render-a-slide-as-an-svg-image/) and renders charts to images; trend lines, as part of the chart, are preserved during these operations. A method is also available to [xuất hình ảnh của biểu đồ](/slides/vi/java/create-shape-thumbnails/) itself.