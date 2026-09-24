---
title: Quản lý Dữ liệu Chuỗi Biểu đồ trong Bản trình chiếu trên Android
linktitle: Chuỗi Dữ liệu
type: docs
url: /vi/androidjava/chart-series/
keywords:
- chuỗi biểu đồ
- chồng lấn chuỗi
- màu chuỗi
- tên chuỗi
- điểm dữ liệu
- ô workbook
- khoảng cách chuỗi
- giá trị âm
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, các điểm dữ liệu, ô workbook, định dạng, chồng lấn, độ rộng khoảng cách và giá trị âm trong bản trình chiếu trên Android."
---
## **Tổng quan**

Biểu đồ lưu trữ dữ liệu đã vẽ trong một workbook dữ liệu biểu đồ. Một [IChartSeries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatapoint/) trong chuỗi tham chiếu tới một hoặc nhiều ô workbook. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Do đó, tên chuỗi, các danh mục và giá trị điểm đều được kết nối tới các đối tượng [IChartDataCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục và các ô còn lại cho giá trị chuỗi. Các chỉ số worksheet, hàng và cột được truyền vào [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) là chỉ số bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên giả định mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản thuyết trình đã tải, hãy kiểm tra các ô được chuỗi, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp chuỗi, chẳng hạn như [IChartSeries.getFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#getFormat--), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt điểm dữ liệu, chẳng hạn như [IChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), ghi đè giao diện chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseriesgroup/). Truy cập nhóm thông qua [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) khi bạn cần thiết lập các tùy chọn như chồng lấn hoặc độ rộng khoảng cách.

Khi không có màu nền điểm hoặc chuỗi nào được đặt một cách rõ ràng, kiểu biểu đồ và chủ đề sẽ xác định giao diện tự động. Khi cả định dạng chuỗi và điểm đều tồn tại, định dạng điểm sẽ ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt chồng lấn chuỗi biểu đồ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#getOverlap--) báo cáo mức độ chồng lấn của các thanh hoặc cột trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Sử dụng [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm chuỗi không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt mức chồng lấn cho nhóm chứa chuỗi đầu tiên:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Biểu đồ mới chứa các chuỗi mẫu, danh mục và giá trị.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Chồng lấn chuỗi](series_overlap.png)

## **Thay đổi màu nền chuỗi**

Sử dụng [IChartSeries.getFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#getFormat--) để đặt màu nền mặc định cho toàn bộ một chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [IChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho chuỗi đầu tiên:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Màu của chuỗi](series_color.png)

## **Thay đổi tên chuỗi**

Tên chuỗi được lưu trong workbook dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong workbook mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm rõ cấu trúc đó:

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

Bạn cũng có thể cập nhật ô đã được tham chiếu bởi [IChartSeries.getName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#getName--). Cách tiếp cận này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ hiện có:

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

![Tên chuỗi](series_name.png)

## **Lấy màu nền chuỗi tự động**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) trả về màu được tính dựa trên chỉ số chuỗi và kiểu biểu đồ dưới dạng một số nguyên màu ARGB của Android. Đây là màu được sử dụng khi màu nền chuỗi chưa được xác định rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in ra số nguyên màu tự động của mỗi chuỗi mặc định:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Các giá trị số nguyên chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt màu nền đảo ngược cho một chuỗi biểu đồ**

Đối với các chuỗi thanh, cột và bong bóng, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) có thể hiển thị các giá trị âm bằng một màu nền khác. Đặt màu nền chuỗi thường thành màu đặc, bật chế độ đảo ngược, và gán màu cho giá trị âm qua [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Các số âm vẫn không thay đổi trong workbook; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng 0 của worksheet chứa tên chuỗi, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

![Màu nền đặc đảo ngược](inverted_solid_fill_color.png)

Bạn có thể bật chế độ đảo ngược cho một điểm thông qua [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Trong ví dụ sau, chế độ đảo ngược bị tắt cho chuỗi và chỉ bật cho điểm được chọn. Điểm này cũng được gán một giá trị âm để hiệu ứng hiển thị:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

## **Xóa giá trị của một điểm dữ liệu cụ thể**

Để làm một điểm trống mà không xóa các điểm khác, đặt ô workbook hỗ trợ của nó thành `null`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập thông qua [IChartDataPoint.getValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Điểm dữ liệu vẫn ở vị trí danh mục giống nhau, nhưng biểu đồ sẽ xem giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong chuỗi đầu tiên:

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

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng cũng sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [IChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) khi bạn muốn giữ lại các điểm khác, vì phương thức đó sẽ xóa mọi điểm dữ liệu khỏi bộ sưu tập.

## **Kiểm soát việc hiển thị các ô trống**

Một ô workbook trống đại diện cho dữ liệu bị thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Gọi [IChartDataCell.setValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) với `null` để làm ô trống. Số 0 vẫn là 0 bất kể cài đặt ô trống là gì.

Sử dụng [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các ô trống được vẽ, mà không lấp đầy ô workbook trống bằng số 0 hoặc một giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một chuỗi, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho các giá trị; hàng 0 chứa tên chuỗi. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

    // Để Ngày 3 thực sự trống, đồng thời giữ lại danh mục và điểm dữ liệu của nó.
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

Mỗi tệp đầu ra lưu chế độ được gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản thuyết trình một lần thay vì lặp lại qua các chế độ.

So sánh bên dưới hiển thị cùng một dữ liệu trong cả ba tệp. Ngày 3 là trống trong workbook trong mọi trường hợp:

![Biểu đồ đường với dữ liệu giống nhau: Gap làm đường bị ngắt tại Ngày 3, Zero làm đường hạ xuống 0, và Span nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường giúp so sánh ba chế độ dễ dàng. Biểu đồ thanh và cột không có đường để nối qua một danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột thiếu và một cột có chiều cao zero cũng có thể trông giống nhau. Tương tự, một biểu đồ scatter chỉ có các điểm đánh dấu không có đường nối. Đừng mong đợi ba kết quả khác nhau cho mọi loại biểu đồ; hãy kiểm tra kết quả cho loại bạn sử dụng.

## **Đặt độ rộng khoảng cách chuỗi**

Độ rộng khoảng cách là khoảng không gian giữa các cụm thanh hoặc cột liền kề, được biểu thị dưới dạng phần trăm của độ rộng thanh hoặc cột. Giống như chồng lấn, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi duy nhất. Gọi [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng cách và chỉ lưu bản thuyết trình cuối cùng:

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

![Độ rộng khoảng cách](gap_width.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chuỗi dữ liệu?**

Tất cả các loại biểu đồ được biểu diễn bởi enumeration [ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng các chuỗi của chúng không đồng nhất về cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ scatter sử dụng giá trị X và Y, và biểu đồ bong bóng thêm kích thước bong bóng. Sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại chuỗi. Các tùy chọn như chồng lấn và độ rộng khoảng cách chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm chuỗi biểu đồ là gì?**

Một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseriesgroup/) chứa các chuỗi tương thích chia sẻ các cài đặt vẽ ở mức độ nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một chuỗi không nhất thiết thay đổi mọi chuỗi trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Mặc định, [IShapeCollection.addChart](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) tạo các chuỗi mẫu, danh mục và giá trị. Bạn có thể chỉnh sửa các ô này hoặc xóa cả bộ sưu tập chuỗi và danh mục trước khi thêm một bộ dữ liệu hoàn toàn tùy chỉnh. Một overload cũng có thể tạo biểu đồ mà không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và hàng giá trị chuỗi đồng nhất để mỗi điểm được vẽ dưới danh mục mong muốn.

**Làm thế nào để xóa một điểm thay vì toàn bộ chuỗi?**

Đặt ô giá trị tương ứng thành `null` để giữ vị trí danh mục của điểm đó như một điểm trống. Chỉ sử dụng [IChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) khi bạn muốn xóa mọi điểm trong chuỗi đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi chuỗi để các giá trị của chúng vẫn đồng nhất với bộ sưu tập danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và giá trị được cấu hình qua [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Các biểu đồ hỗ trợ có thể hiển thị các ô trống dưới dạng khoảng trống, giá trị zero, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu bị thiếu trong bản thuyết trình của bạn. Xem [Control the Display of Empty Cells](#control-the-display-of-empty-cells) để có ví dụ đầy đủ và so sánh trực quan.

**Giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bong bóng được hỗ trợ, gọi [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) và đặt màu trả về bởi [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Các phương thức này ảnh hưởng đến định dạng, không phải các giá trị số được lưu.

**Định dạng nào được ưu tiên khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ ưu tiên cho điểm đó. Các điểm khác tiếp tục sử dụng định dạng chuỗi rõ ràng hoặc, khi định dạng chuỗi không được xác định, kiểu và chủ đề biểu đồ tự động. Các cài đặt nhóm như chồng lấn và độ rộng khoảng cách kiểm soát bố cục và không phải là các ghi đè định dạng cấp điểm.

**Có giới hạn số lượng chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không đặt giới hạn cố định cho số lượng chuỗi. Thực tế, các hạn chế của tệp bản thuyết trình, bộ nhớ khả dụng, thời gian render và khả năng đọc hiểu biểu đồ quyết định giới hạn hữu ích.

**Tôi nên thay đổi gì khi các cột quá gần nhau hoặc quá xa nhau?**

Gọi [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) trên nhóm chuỗi cha phù hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm giá trị để đưa các cụm lại gần nhau hơn.