---
title: Tùy chỉnh biểu đồ tròn trong các bản trình bày trên Android
linktitle: Biểu đồ tròn
type: docs
url: /vi/androidjava/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn đồ thị
- màu sắc lát
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ tròn trên Android với Aspose.Slides for Android qua Java. Cấu hình đồ thị phụ, hiển thị nhãn dữ liệu và áp dụng màu sắc lát tự động trong PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó cho thấy cách cấu hình các tùy chọn đồ thị phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật việc tự động tô màu các lát cho biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các nhiệm vụ tùy chỉnh biểu đồ như thêm biểu đồ vào một slide, điều chỉnh cài đặt chuỗi và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn Đồ thị Phụ cho Biểu đồ Pie of Pie và Bar of Pie**

Aspose.Slides for Android qua Java hỗ trợ các tùy chọn đồ thị phụ cho biểu đồ Pie of Pie và Bar of Pie. Các tùy chọn này kiểm soát kích thước của đồ thị phụ và cách các điểm dữ liệu được chia giữa hai đồ thị.

Ví dụ sau tạo một biểu đồ Pie of Pie trong một bản trình bày mới và hiển thị giá trị các điểm dữ liệu dưới dạng nhãn. Phương thức [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) đặt kích thước đồ thị phụ là 149% của đồ thị chính. [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) chọn cách chia dựa trên phần trăm, và [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) đặt ngưỡng là 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Hiển thị giá trị và cấu hình đồ thị phụ.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Chọn Danh mục cho Đồ thị Phụ**

Sử dụng cách chia tùy chỉnh khi bạn muốn nhóm các danh mục cụ thể trong đồ thị phụ mà không quan tâm đến giá trị phần trăm của chúng. Ví dụ, báo cáo bán hàng có thể hiển thị Online và Events cùng nhau để độc giả có thể so sánh hai kênh này, mặc dù chúng chiếm 35% và 10% tổng doanh thu.

Gọi [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) với [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) và chọn các điểm qua [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Phương thức [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) của bộ sưu tập chấp nhận chỉ mục bắt đầu từ 0 trong chuỗi; sử dụng [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) để thêm đối tượng điểm dữ liệu. Trong ví dụ này, chỉ mục 1 chọn Online, và điểm tại chỉ mục 3 chọn Events. Partners cũng được thêm tạm thời, sau đó được loại bỏ bằng [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Thay thế dữ liệu mặc định bằng doanh số theo kênh.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Chọn Online bằng chỉ mục bắt đầu từ 0 và Events bằng đối tượng điểm dữ liệu.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Loại trừ Partners khỏi lựa chọn mà không xóa dữ liệu nguồn của nó.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) và Events (10) xuất hiện như các lát riêng biệt trong đồ thị phụ. Trong đồ thị chính, chúng được đại diện bằng một lát kết hợp với giá trị 45, cùng với Retail (40) và Partners (15). Loại bỏ Partners khỏi lựa chọn tùy chỉnh giữ nó trong đồ thị chính; nó không xóa danh mục hoặc giá trị của nó khỏi dữ liệu nguồn của biểu đồ.

Hình ảnh sau đây hiển thị bản trình bày đã lưu trong PowerPoint:

![Biểu đồ Pie of Pie với Online và Events trong đồ thị phụ và giá trị kết hợp của chúng là 45 trong đồ thị chính](pie_of_pie_custom.png)

## **Thiết lập Màu sắc Tự động cho Các Lát Biểu đồ Pie**

Aspose.Slides for Android qua Java có thể tự động gán màu sắc khác nhau cho các lát của biểu đồ tròn. Ví dụ sau tạo một biểu đồ tròn với tiêu đề ở trung tâm và thay thế dữ liệu mặc định bằng ba danh mục quý và giá trị của chúng. Phương thức [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) hiển thị các giá trị 20, 50 và 30 dưới dạng nhãn, trong khi [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) bật màu sắc riêng biệt cho mỗi lát.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Thêm tiêu đề biểu đồ ở trung tâm.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Thay thế dữ liệu mặc định bằng cách sử dụng bảng tính đầu tiên.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Hiển thị giá trị và gán màu sắc khác nhau cho các lát.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Các biến thể Pie of Pie và Bar of Pie có được hỗ trợ không?**

Có, thư viện [hỗ trợ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) một đồ thị phụ cho biểu đồ tròn, bao gồm các loại Pie of Pie và Bar of Pie.

**Tôi có thể xuất chỉ biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Có, bạn có thể [xuất biểu đồ dưới dạng hình ảnh](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (ví dụ PNG) mà không cần xuất toàn bộ bản trình bày.