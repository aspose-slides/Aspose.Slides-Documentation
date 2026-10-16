---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trên Android
linktitle: Đường Xu Hướng
type: docs
url: /vi/androidjava/trend-line/
keywords:
- biểu đồ
- đường xu hướng
- đường xu hướng hàm số mũ
- đường xu hướng tuyến tính
- đường xu hướng logarit
- đường xu hướng trung bình động
- đường xu hướng đa thức
- đường xu hướng lũy thừa
- đường xu hướng tùy chỉnh
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint bằng Aspose.Slides cho Android qua Java — hướng dẫn thực tế để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bài thuyết trình bằng cách sử dụng Aspose.Slides. Nó trình bày cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi biểu đồ, và làm việc với một số loại đường xu hướng, bao gồm đường xu hướng hàm số mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Hỏi đáp ngắn về các giá trị chiếu hướng tiến và lùi của đường xu hướng và việc các đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi render biểu đồ dưới dạng hình ảnh hay không.

## **Thêm đường xu hướng**

Sử dụng [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) để thêm một đường xu hướng vào một chuỗi biểu đồ, chọn loại của nó bằng [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/). Ví dụ tạo một biểu đồ cột nhóm với dữ liệu mặc định và thêm hai đường xu hướng cho mỗi trong ba chuỗi của nó.

Đường xu hướng hàm số mũ ẩn phương trình và giá trị R‑bình phương thông qua [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) và [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), trong khi đường xu hướng tuyến tính có màu đỏ. Đường xu hướng logarit sử dụng [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) cho một nhãn tùy chỉnh. Trung bình động sử dụng [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) với ba điểm dữ liệu và một [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) tùy chỉnh.

Đường xu hướng đa thức có [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) bằng ba và mở rộng một danh mục phía trước thông qua [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-). Đường xu hướng lũy thừa mở rộng một danh mục phía sau thông qua [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Đặt điểm giao cắt của đường xu hướng**

Sử dụng [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) để cố định giá trị Y của đường xu hướng tại X = 0. Cài đặt này được hỗ trợ cho các đường xu hướng tuyến tính, hàm số mũ và đa thức.

Ví dụ, một mô hình chi phí sản xuất có thể cần bắt đầu với chi phí cố định đã biết là 100, ngay cả khi các đo lường tại khối lượng sản xuất khác 0 gợi ý một cơ sở khác. Đối với một đường xu hướng tuyến tính, việc cố định giao cắt buộc phương trình `y = ax + b` thành `b = 100`; độ dốc được điều chỉnh dựa trên dữ liệu dưới ràng buộc đó. Nó không chỉ di chuyển một đường đã được điều chỉnh. Cài đặt giao cắt trục kiểm soát nơi các trục biểu đồ gặp nhau, không phải các hệ số của đường xu hướng đã điều chỉnh.

Ví dụ sau tạo một biểu đồ phân tán (XY) với khối lượng sản xuất từ 1 đến 4 và chi phí 170, 200, 230 và 260. Nó lưu biểu đồ với giao cắt tự động mặc định, đặt giao cắt thành 100, và lưu một PPTX thứ hai. Hai tệp chỉ khác nhau ở cài đặt giao cắt. Đường xu hướng hiển thị phương trình và mở rộng trở lại X = 0.

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

Với tính toán tự động, các dữ liệu này cho ra `y = 30x + 140`. Đặt giao cắt thành 100 thay vào đó cho ra khoảng `y = 43.33x + 100`: giá trị điều chỉnh tại zero khớp với cơ sở đã biết, trong khi đường không còn đi qua mọi điểm dữ liệu.

| Giao cắt tự động | Giao cắt cố định 100 |
| --- | --- |
| ![Đường xu hướng tuyến tính với giao cắt được tính tự động là 140](intercept-automatic.png) | ![Đường xu hướng tuyến tính với giao cắt cố định là 100](intercept-fixed.png) |

Cả hai hình đều sử dụng cùng một dữ liệu và tỉ lệ trục. Các đường xu hướng được mở rộng trở lại X = 0 để hiển thị giao cắt của chúng.

Mặc định, [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) trả về `Double.NaN`, biểu thị một giao cắt chưa xác định thay vì zero. Giao cắt sau đó được tính tự động từ dữ liệu.

## **Thêm đường tùy chỉnh**

Một đường tùy chỉnh là một hình dạng được vẽ lên trên biểu đồ thay vì một đường xu hướng được tính toán từ dữ liệu chuỗi. Ví dụ này sử dụng [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) để thêm một đường ngang vào slide trên biểu đồ. Vị trí của đường được xác định bằng tọa độ slide, đo bằng point, vì vậy nó bắt đầu ở cạnh trái của biểu đồ và nằm ở giữa chiều cao của biểu đồ. Độ rộng của nó khớp với độ rộng của biểu đồ. [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) cung cấp cho đường một màu đỏ đặc.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

**'forward' và 'backward' có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu tiến hoặc lùi: đối với biểu đồ phân tán (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải phân tán — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Liệu đường xu hướng có được giữ lại khi xuất bản trình chiếu sang PDF hoặc SVG, hoặc khi render một slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi trình chiếu sang [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) hoặc [SVG](/slides/vi/androidjava/render-a-slide-as-an-svg-image/) và render các biểu đồ thành hình ảnh; các đường xu hướng, như một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương thức cũng có sẵn để [xuất hình ảnh của biểu đồ](/slides/vi/androidjava/create-shape-thumbnails/) trực tiếp.