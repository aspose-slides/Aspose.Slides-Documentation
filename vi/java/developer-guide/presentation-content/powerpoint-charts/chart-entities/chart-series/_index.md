---
title: Quản lý Series dữ liệu biểu đồ trong bản thuyết trình bằng Java
linktitle: Series dữ liệu
type: docs
url: /vi/java/chart-series/
keywords:
- series biểu đồ
- đè chồng series
- màu series
- tên series
- điểm dữ liệu
- ô workbook
- khoảng cách series
- giá trị âm
- PowerPoint
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ, điểm dữ liệu, ô workbook, định dạng, độ chồng, độ rộng khoảng cách và các giá trị âm trong bản thuyết trình bằng Java."
---
## **Tổng quan**

Biểu đồ có thể lưu các giá trị được vẽ vào các ô trong workbook hoặc trực tiếp dưới dạng các literal số. Một [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) đại diện cho một điểm trong tập hợp đó. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm mà các series chia sẻ. Trong các biểu đồ được tạo với dữ liệu mặc định, tên series, danh mục và giá trị điểm đều sử dụng các đối tượng [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) từ workbook của biểu đồ.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục và các ô còn lại cho giá trị series. Các chỉ số worksheet, hàng và cột được truyền vào [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) là dựa trên chỉ số 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản thuyết trình đã tải, hãy kiểm tra các ô mà series, categories và data points tham chiếu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt ở mức Series, chẳng hạn như [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), cung cấp giao diện mặc định cho tất cả các điểm trong một series.
- Cài đặt ở mức Data‑point, chẳng hạn như [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), ghi đè giao diện của series cho một điểm.
- Cài đặt ở mức Group áp dụng cho các series tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/). Truy cập nhóm qua [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) khi bạn cần đặt các tùy chọn như overlap hoặc gap width.

Khi không có fill point hoặc series nào được đặt một cách rõ ràng, kiểu biểu đồ và theme sẽ quyết định giao diện tự động. Khi cả định dạng series và point đều tồn tại, định dạng point sẽ có ưu tiên cho point đó.

![biểu đồ-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Giá Trị Series Bằng Literal Số**

Sử dụng literal số khi giá trị series đến từ dữ liệu hoặc tính toán trong ứng dụng và không cần tham chiếu tới ô trong worksheet. Gọi [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) với [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) trước khi gán kết quả của [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) cho mỗi point qua [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

Cài đặt collection kiểm soát loại nguồn của tất cả các giá trị point trong series đó. Phương thức [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) của mỗi point báo cáo loại đã chọn; thay đổi nó bằng cài đặt collection. Với `Worksheet`, sử dụng [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) để truy cập ô được tham chiếu. Với `DoubleLiterals`, sử dụng [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) hoặc `setAsLiteralDouble` để đọc hoặc ghi trực tiếp số.

Ví dụ dưới đây tạo một biểu đồ cột với series và categories mặc định, sau đó gán các giá trị tính toán 10, 20, … cho các point hiện có của series đầu tiên. Nó lưu bản thuyết trình, mở lại và in các giá trị đã lưu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Loại nguồn giá trị point tách biệt khỏi [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--), phương thức này xác định cấu hình workbook nội bộ hoặc ngoại vi của biểu đồ. Việc sử dụng literal số không tự động loại bỏ workbook nhúng. Trong ví dụ này, workbook vẫn tồn tại cho nhãn danh mục, tên series và các series khác. Xem [Chart Workbook](/slides/vi/java/chart-workbook/) để quản lý workbook.

Đối với biểu đồ scatter và bubble, sử dụng [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) và [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) để chọn nguồn cho [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) và [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--). Biểu đồ bubble cũng sử dụng [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) cho [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Đặt mỗi nguồn thích hợp thành `DoubleLiterals` trước khi gán số qua phương thức `setAsLiteralDouble` của giá trị đó.

## **Đặt Overlap Cho Series Biểu Đồ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) báo cáo mức độ mà các thanh hoặc cột chồng lên nhau trong biểu đồ 2D, từ -100 tới 100 phần trăm. Đây là một dự đoán chỉ đọc của cài đặt trên nhóm series cha. Sử dụng [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột nhóm; nó không ảnh hưởng tới các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ dưới đây đặt overlap cho nhóm chứa series đầu tiên:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Biểu đồ mới chứa các series mẫu, các danh mục và các giá trị.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![overlap-series](series_overlap.png)

## **Thay Đổi Màu Fill Của Series**

Sử dụng [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) để đặt fill mặc định cho toàn bộ series. Nếu một point đã có fill rõ ràng, cài đặt [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) của nó sẽ ghi đè fill của series cho point đó.

Ví dụ dưới đây áp dụng fill xanh đậm dạng solid cho series đầu tiên:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![màu-series](series_color.png)

## **Thay Đổi Tên Series**

Tên series được lưu trong workbook dữ liệu biểu đồ và thường hiển thị trong legend. Trong workbook mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các hằng số được đặt tên trong ví dụ dưới đây làm rõ cấu trúc này:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể cập nhật ô đã được [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) tham chiếu. Cách này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ đã tồn tại:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![tên-series](series_name.png)

### **Tạo Series Với Tên Từ Nhiều Ô**

Tên series hợp thành hữu ích khi tên sản phẩm và kỳ báo cáo được lưu trong các ô workbook riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` ở B1 và `2026` ở C1 thành một tên series duy nhất trong khi vẫn giữ cả hai phần liên kết tới ô nguồn.

Sử dụng [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) để lấy dải tên, sau đó truyền collection này vào [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Tham số `skipHiddenCells` quyết định có bao gồm các ô ẩn hay không: `true` loại bỏ chúng, `false` bao gồm chúng. Ví dụ này dùng `false` để bao gồm mọi ô trong dải tên.

Ví dụ dưới đây tạo một bản thuyết trình với một series và hai data point. Các ô B1:C1 chỉ cung cấp tên series; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Hai ô này cung cấp tên series.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Các ô riêng biệt cung cấp danh mục và các điểm dữ liệu số.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tên series tạo ra là `Product A 2026`, có một dấu cách giữa hai giá trị ô. Legend hiển thị điều này như một mục duy nhất cho cả hai cột. Hình ảnh dưới minh họa kết quả:

![biểu đồ cột với giá trị North và South và tên series hợp thành Product A 2026 trong legend](composite_series_name.png)

## **Lấy Màu Fill Tự Động Của Series**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) trả về màu được tính dựa trên chỉ số series và kiểu biểu đồ. Đây là màu được sử dụng khi fill của series chưa được định nghĩa rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán fill mới.

Ví dụ dưới đây in màu tự động của mỗi series mặc định:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Kết quả mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Màu sắc chính xác phụ thuộc vào kiểu biểu đồ và theme.

## **Đặt Invert Fill Color Cho Series Biểu Đồ**

Đối với series thanh, cột và bubble, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) có thể hiển thị các giá trị âm với một fill khác. Đặt fill series thông thường thành solid, bật inversion, và gán màu âm qua [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Các số âm vẫn giữ nguyên trong workbook; chỉ màu hiển thị thay đổi.

Ví dụ dưới đây thay thế dữ liệu biểu đồ mặc định bằng một series. Hàng 0 của worksheet chứa tên series, cột 0 chứa nhãn danh mục, và cột 1 chứa các giá trị:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![màu fill solid bị invert](inverted_solid_fill_color.png)

Bạn có thể bật inversion cho một point thông qua [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Trong ví dụ sau, inversion bị tắt cho series và chỉ bật cho point đã chọn. Point cũng được gán giá trị âm để hiệu ứng hiển thị:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa Giá Trị Của Một Data Point Cụ Thể**

Để làm cho một point trống mà không xóa các point khác, đặt ô workbook tương ứng của nó thành `null`. Đối với biểu đồ cột, giá trị được vẽ có thể truy cập qua [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--). Point vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt blank‑value của biểu đồ.

Ví dụ dưới đây chỉ xóa point thứ hai trong series đầu tiên:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble còn dùng ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Đừng gọi [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) khi muốn giữ các point còn lại, vì phương thức này sẽ xóa mọi data point trong collection.

## **Kiểm Soát Hiển Thị Các Ô Trống**

Các ô ẩn chứa giá trị là một trường hợp riêng so với các ô trống. Để bao gồm hoặc loại bỏ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu bị thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Gọi [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) với `null` để làm ô trống. Số 0 vẫn vẫn là 0 bất kể cài đặt ô trống.

Sử dụng [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách vẽ các ô trống, mà không điền giá trị 0 hay giá trị nội suy vào ô workbook trống.

Ví dụ tự chứa dưới đây tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu biểu đồ cùng lúc với mỗi chế độ. Không cần tệp đầu vào. [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục và cột 1 cho giá trị; hàng 0 chứa tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Giữ ngày 3 thực sự trống, đồng thời giữ lại danh mục và điểm dữ liệu của nó.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Mỗi tệp đầu ra lưu chế độ đã gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản thuyết trình một lần thay vì lặp qua các chế độ.

Bảng so sánh dưới đây cho thấy cùng một dữ liệu trong ba tệp. Ngày 3 là ô trống trong workbook ở mọi trường hợp:

![biểu đồ đường với dữ liệu giống nhau: Gap ngắt đường ở Ngày 3, Zero hạ đường xuống 0, và Span nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng nhìn thấy phụ thuộc vào loại biểu đồ. Biểu đồ đường dễ dàng so sánh cả ba chế độ. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không tạo đoạn nối như trên; một cột thiếu và một cột chiều cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ scatter chỉ có marker thì không có đường nối. Đừng mong đợi ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn dùng.

## **Đặt Gap Width Cho Series**

Gap width là khoảng cách giữa các cụm thanh hoặc cột liền kề, biểu thị dưới dạng phần trăm của chiều rộng thanh hoặc cột. Giống như overlap, nó thuộc về nhóm series cha chứ không phải một series đơn. Gọi [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ dưới đây thay đổi gap width và chỉ lưu bản thuyết trình cuối cùng:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![gap-width-series](gap_width.png)

## **Câu Hỏi Thường Gặp**

**Các loại biểu đồ nào hỗ trợ series dữ liệu?**

Tất cả các loại biểu đồ được liệt kê trong enum [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) đều dùng dữ liệu biểu đồ, nhưng series của chúng không giống nhau về cấu trúc giá trị hay cài đặt. Ví dụ, biểu đồ danh mục dùng categories và values, biểu đồ scatter dùng X và Y, và biểu đồ bubble còn thêm bubble sizes. Hãy dùng phương thức tạo data‑point phù hợp với loại series. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Series group là gì?**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) chứa các series tương thích chia sẻ các cài đặt plotting ở mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Mặc định, [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) tạo các series, categories và values mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả collections series và category trước khi thêm một bộ dữ liệu hoàn toàn tùy chỉnh. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị data‑point tham chiếu tới các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật yếu tố biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị series đồng bộ để mỗi point được vẽ dưới đúng danh mục.

**Làm sao để xóa một point mà không xóa toàn bộ series?**

Đặt ô giá trị liên quan thành `null` để giữ vị trí danh mục của point dưới dạng điểm trống. Chỉ dùng [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) khi bạn muốn xóa mọi point trong series đó. Nếu bạn cũng xóa các category, hãy cập nhật mọi series để giá trị của chúng vẫn khớp với collection category.

**Các point trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và giá trị được cấu hình qua [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Các biểu đồ hỗ trợ có thể hiển thị ô trống dưới dạng gap, zero hoặc bằng cách nối các point lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản thuyết trình của bạn. Xem [Control the Display of Empty Cells](#control-the-display-of-empty-cells) để có ví dụ đầy đủ và so sánh trực quan.

**Các giá trị âm được định dạng ra sao?**

Đối với các series thanh, cột và bubble được hỗ trợ, gọi [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) và đặt màu trả về bởi [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Bạn có thể ghi đè hành vi cho một point riêng lẻ bằng [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Các phương thức này ảnh hưởng đến định dạng, không thay đổi giá trị số lưu trữ.

**Định dạng nào thắng khi cả series và point đều được định dạng?**

Định dạng explicit của data‑point có ưu tiên cho point đó. Các point khác vẫn sử dụng định dạng series explicit hoặc, nếu series không có định dạng, thì style và theme của biểu đồ tự động. Các cài đặt nhóm như overlap và gap width kiểm soát bố cục và không phải là các ghi đè định dạng ở mức point.

**Có giới hạn số series một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định cho số series. Trong thực tế, các ràng buộc của tệp bản thuyết trình, bộ nhớ khả dụng, thời gian render và khả năng đọc hiểu của biểu đồ sẽ xác định một giới hạn thực tế.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Gọi [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) trên nhóm series cha thích hợp. Tăng giá trị để mở rộng khoảng cách giữa các cụm, hoặc giảm giá trị để đưa các cụm lại gần nhau hơn.