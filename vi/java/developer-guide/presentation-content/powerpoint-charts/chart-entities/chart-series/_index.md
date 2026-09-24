---
title: Quản lý series dữ liệu biểu đồ trong bản trình chiếu bằng Java
linktitle: Series dữ liệu
type: docs
url: /vi/java/chart-series/
keywords:
- series biểu đồ
- chồng lấp series
- màu series
- tên series
- điểm dữ liệu
- ô sổ làm việc
- khoảng trống series
- giá trị âm
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ, điểm dữ liệu, ô sổ làm việc, định dạng, chồng lấp, độ rộng khoảng trống và giá trị âm trong bản trình chiếu bằng Java."
---
## **Tổng quan**

Biểu đồ lưu trữ dữ liệu đã vẽ trong một sổ dữ liệu biểu đồ. Một [IChartSeries](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/) trong series tham chiếu tới một hoặc nhiều ô trong sổ làm việc. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các series. Vì vậy, tên series, danh mục và giá trị điểm đều được kết nối tới các đối tượng [IChartDataCell](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/), thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục điển hình, sổ làm việc mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục, và các ô còn lại cho các giá trị series. Các chỉ số worksheet, hàng và cột được truyền tới [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) là dựa trên chỉ số 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình chiếu đã tải, hãy kiểm tra các ô được series, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị trong sổ làm việc.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt ở mức series, chẳng hạn [IChartSeries.getFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#getFormat--) cung cấp giao diện mặc định cho tất cả các điểm trong một series.
- Cài đặt điểm dữ liệu, chẳng hạn [IChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/#getFormat--) ghi đè giao diện series cho một điểm duy nhất.
- Cài đặt nhóm áp dụng cho các series tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseriesgroup/). Truy cập nhóm thông qua [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) khi bạn cần đặt các tùy chọn như overlap hoặc gap width.

Khi không có màu nền điểm hoặc series nào được xác định, kiểu biểu đồ và chủ đề sẽ quyết định giao diện tự động. Khi cả định dạng series và điểm đều tồn tại, định dạng điểm sẽ được ưu tiên cho điểm đó.

![đồ thị-series-powerpoint](chart-series-powerpoint.png)

## **Đặt phần chồng lấp cho Series Biểu đồ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#getOverlap--) báo cáo mức độ chồng lấp của các thanh hoặc cột trong biểu đồ 2D, từ -100 tới 100 phần trăm. Đây là một dự báo chỉ đọc của cài đặt trên nhóm series cha. Sử dụng [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt overlap cho nhóm chứa series đầu tiên:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Biểu đồ mới chứa các series mẫu, danh mục và giá trị.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![phần chồng lấp series](series_overlap.png)

## **Thay đổi màu nền Series**

Sử dụng [IChartSeries.getFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#getFormat--) để đặt màu nền mặc định cho toàn bộ một series. Nếu một điểm đã có màu nền xác định, cài đặt [IChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/#getFormat--) của nó sẽ ghi đè màu nền series cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho series đầu tiên:

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

![Màu của series](series_color.png)

## **Thay đổi Tên Series**

Tên series được lưu trong sổ dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong sổ làm việc mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các hằng số được đặt tên trong ví dụ dưới đây làm cho cấu trúc này rõ ràng:

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

Bạn cũng có thể cập nhật ô đã được [IChartSeries.getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#getName--) tham chiếu. Cách tiếp cận này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ hiện có:

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

![Tên series](series_name.png)

## **Lấy màu nền Series tự động**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) trả về màu được tính dựa trên chỉ số series và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền series chưa được xác định rõ. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu mới.

Ví dụ sau in ra màu tự động của mỗi series mặc định:

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

Màu chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt màu nền Đảo ngược cho Series Biểu đồ**

Đối với series thanh, cột và bong bóng, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) có thể hiển thị các giá trị âm bằng một màu nền khác. Đặt màu nền series thông thường thành đặc, bật tính năng đảo ngược, và gán màu giá trị âm qua [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Các số âm vẫn không thay đổi trong sổ làm việc; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một series. Hàng 0 của worksheet chứa tên series, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

![Màu nền rắn đảo ngược](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm thông qua [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Trong ví dụ sau, đảo ngược bị tắt cho series và chỉ bật cho điểm đã chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

## **Xóa Giá trị Điểm Dữ liệu Cụ thể**

Để làm cho một điểm rỗng mà không xóa các điểm khác, đặt ô chứa nó trong sổ làm việc thành `null`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [IChartDataPoint.getValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/#getValue--). Điểm dữ liệu vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ xem giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong series đầu tiên:

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

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng còn sử dụng ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [IChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapointcollection/#clear--) khi bạn muốn giữ các điểm còn lại, vì phương thức này sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Kiểm soát Hiển thị Ô Trống**

Một ô trống trong sổ làm việc đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Gọi [IChartDataCell.setValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) với `null` để làm ô thành trống. Số 0 vẫn là 0 bất kể cài đặt ô trống.

Sử dụng [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách vẽ các chỗ trống, mà không làm đầy ô trống bằng 0 hay một giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [IChartDataWorkbook](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 giữ tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

    // Để Ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu.
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

Mỗi tệp đầu ra lưu chế độ đã gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình chiếu một lần thay vì lặp qua các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong ba tệp. Ngày 3 là trống trong sổ làm việc trong mọi trường hợp:

![Biểu đồ đường với dữ liệu giống nhau: Gap ngắt đoạn tại Ngày 3, Zero hạ đường xuống 0, và Span nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường dễ so sánh ba chế độ. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không tạo đoạn nối như trên; một cột thiếu và một cột chiều cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ phân tán chỉ có dấu đánh dấu không có đường nối. Đừng kỳ vọng ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn đang dùng.

## **Đặt Khoảng cách Gap cho Series**

Khoảng cách gap là không gian giữa các cụm thanh hoặc cột kề nhau, biểu thị dưới dạng phần trăm của chiều rộng thanh hoặc cột. Giống như overlap, nó thuộc về nhóm series cha thay vì một series duy nhất. Gọi [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi khoảng cách gap và chỉ lưu bản trình chiếu cuối cùng:

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

![Khoảng cách gap](gap_width.png)

## **Câu hỏi thường gặp**

**Which chart types support data series?**  
Tất cả các loại biểu đồ được đại diện bởi enumeration [ChartType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng series của chúng không cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng thêm kích thước bong bóng. Sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại series. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**What is a chart series group?**  
[IChartSeriesGroup](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseriesgroup/) chứa các series tương thích chia sẻ cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Does a newly created chart contain default data?**  
Có. Mặc định, [IShapeCollection.addChart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) tạo các series, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả bộ sưu tập series và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**How are chart objects connected to workbook cells?**  
Tên series, nhãn danh mục và giá trị điểm dữ liệu tham chiếu tới các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/). Thay đổi ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị series căn chỉnh để mỗi điểm được vẽ dưới danh mục dự định.

**How do I clear one point instead of the whole series?**  
Đặt ô giá trị liên quan thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng [IChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapointcollection/#clear--) khi bạn muốn xóa mọi điểm trong series đó. Nếu bạn cũng xóa danh mục, hãy cập nhật mọi series sao cho các giá trị vẫn căn chỉnh với bộ danh mục.

**How are empty points displayed?**  
Kết quả phụ thuộc vào loại biểu đồ và giá trị được cấu hình qua [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Các biểu đồ hỗ trợ có thể hiển thị chỗ trống dưới dạng khoảng trống, giá trị zero, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình chiếu của bạn. Xem mục [Control the Display of Empty Cells](#control-the-display-of-empty-cells) để biết ví dụ đầy đủ và so sánh trực quan.

**How are negative values formatted?**  
Đối với series thanh, cột và bong bóng được hỗ trợ, gọi [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) và đặt màu trả về bởi [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Các phương thức này ảnh hưởng đến định dạng, không phải giá trị số lưu trữ.

**Which formatting wins when both a series and a point are formatted?**  
Định dạng điểm dữ liệu rõ ràng sẽ ưu tiên cho điểm đó. Các điểm khác vẫn sử dụng định dạng series rõ ràng hoặc, khi series không có định dạng, kiểu và chủ đề biểu đồ tự động. Cài đặt nhóm như overlap và gap width kiểm soát bố cục và không phải là các ghi đè định dạng mức điểm.

**Is there a limit to how many series a chart can contain?**  
Aspose.Slides không áp đặt một giới hạn cố định riêng cho số series. Trong thực tế, các hạn chế của tệp trình chiếu, bộ nhớ khả dụng, thời gian render và khả năng đọc của biểu đồ quyết định giới hạn thực tế.

**What should I change when columns are too close together or too far apart?**  
Gọi [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) trên nhóm series cha thích hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm giá trị để đưa các cụm lại gần hơn.