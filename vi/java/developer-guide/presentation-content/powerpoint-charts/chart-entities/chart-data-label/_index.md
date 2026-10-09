---
title: Quản lý nhãn dữ liệu biểu đồ trong bài thuyết trình sử dụng Java
linktitle: Nhãn Dữ liệu
type: docs
url: /vi/java/chart-data-label/
keywords:
- biểu đồ
- nhãn dữ liệu
- độ chính xác dữ liệu
- phần trăm
- khoảng cách nhãn
- vị trí nhãn
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho Java để tạo slide hấp dẫn hơn."
---
## **Giới thiệu**

Nhãn dữ liệu hiển thị thông tin về các chuỗi biểu đồ và các điểm dữ liệu riêng lẻ, giúp người đọc xác định giá trị và hiểu biểu đồ. Bài viết này giải thích cách định dạng giá trị, hiển thị phần trăm, đọc văn bản nhãn, kiểm soát nhãn vượt qua mức tối đa của trục, điều chỉnh khoảng cách nhãn trục danh mục, và định vị nhãn biểu đồ tròn.

## **Thiết lập độ chính xác dữ liệu trong nhãn dữ liệu biểu đồ**

Sử dụng [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) để định dạng các giá trị của chuỗi. Ví dụ này tạo một biểu đồ đường với dữ liệu mặc định, hiển thị bảng dữ liệu của nó và bật nhãn giá trị cho chuỗi đầu tiên. Định dạng `#,##0.00` hiển thị dấu phân cách hàng nghìn và hai chữ số thập phân mà không thay đổi giá trị gốc.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hiển thị phần trăm dưới dạng nhãn**

Đối với biểu đồ cột chồng, tính mỗi giá trị dưới dạng phần trăm của tổng danh mục và gán văn bản vào khung văn bản được trả về bởi [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Ví dụ này sử dụng dữ liệu biểu đồ mặc định và hiển thị phần trăm với hai chữ số thập phân trong phông chữ 8 điểm. Các danh mục có tổng bằng không sẽ bị bỏ qua để tránh chia cho zero. Tính lại văn bản nhãn tùy chỉnh nếu dữ liệu biểu đồ thay đổi.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt ký hiệu phần trăm cho Nhãn Dữ liệu Biểu đồ**

Khi các giá trị được lưu dưới dạng phân số, sử dụng [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) để hiển thị phần trăm. Gửi `false` tới [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) để áp dụng định dạng nhãn một cách độc lập với các ô nguồn.

Ví dụ này tạo một biểu đồ cột chồng 100% với các chuỗi màu đỏ và xanh dương trên bốn danh mục. Mỗi cặp giá trị cộng lại thành 1. Định dạng nhãn `0.0%` hiển thị 0.30 thành 30.0%, trong khi trục dọc sử dụng hai chữ số thập phân. Cả hai chuỗi đều sử dụng nhãn màu trắng, cỡ 10 điểm.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đọc Văn bản Thực tế của Nhãn Dữ liệu**

Sử dụng [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) để lấy văn bản được tạo bởi cài đặt của một nhãn dữ liệu. Điều này hữu ích khi trích xuất nhãn cho báo cáo, tìm kiếm nội dung bài thuyết trình, hoặc xác thực các biểu đồ đã tạo. Trong ví dụ dưới đây, [định dạng nhãn dữ liệu](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) mặc định kết hợp mỗi tên danh mục, tên chuỗi và giá trị. Một điểm định dạng giá trị của nó dưới dạng phần trăm, và một điểm khác sử dụng văn bản tùy chỉnh từ [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Số được lưu trong một điểm dữ liệu vẫn là `0.75`, ngay cả khi nhãn của nó hiển thị `75%` cùng với tên danh mục và tên chuỗi. Văn bản tùy chỉnh thay thế văn bản nhãn được tạo. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) trả về chuỗi nhãn kết quả trong cả hai trường hợp. Kiểm tra [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) riêng biệt, như đã minh họa ở trên, khi bạn muốn trích xuất chỉ các nhãn hiển thị.

## **Kiểm soát Nhãn Dữ liệu vượt quá Giá trị Tối đa của Trục**

Khi bạn giới hạn phạm vi trục một cách thủ công, một số điểm dữ liệu có thể vượt quá mức tối đa của nó. Sử dụng [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) để kiểm soát việc hiển thị nhãn dữ liệu của chúng. Cài đặt này thay đổi khả năng hiển thị nhãn; nó không thay đổi phạm vi trục hoặc giá trị dữ liệu gốc.

Ví dụ dưới đây tạo một biểu đồ cột cụm 2D với các giá trị 60 và 120. Nó gửi `false` tới [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) và đặt giá trị tối đa là 100 bằng [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) trên trục dọc. Bản trình chiếu đầu tiên cho phép nhãn vượt quá mức tối đa; một bản sao của bản trình chiếu đó tắt chúng. Cả hai bản trình chiếu đều được lưu trong `DataLabelsOverMaximum.pptx`.

Bật nhãn giá trị bằng [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Cài đặt ở mức biểu đồ không tự động bật hiển thị giá trị hoặc ghi đè lên việc tắt hiển thị giá trị của nhãn riêng lẻ. Ví dụ này bật giá trị cho toàn bộ chuỗi và sử dụng [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) để đặt nhãn ở đầu ngoài của mỗi cột.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hình ảnh dưới đây minh họa các slide đã lưu được hiển thị bởi Microsoft PowerPoint. Khi dùng `true`, nhãn **120** hiển thị ở rìa trên; khi dùng `false`, nó bị ẩn. Nhãn **60** vẫn hiển thị, giá trị tối đa của trục vẫn ở **100**, và điểm dữ liệu thứ hai vẫn là **120** trong cả hai trường hợp.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Biểu đồ PowerPoint hiển thị nhãn giá trị 120 với trục tối đa là 100](data-labels-over-maximum-true.png) | ![Biểu đồ PowerPoint ẩn nhãn giá trị 120 với trục tối đa là 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ví dụ này sử dụng biểu đồ cột 2D có trục giá trị. Các biểu đồ không có trục giá trị, chẳng hạn biểu đồ tròn và bánh donut, không có giá trị tối đa của trục để giới hạn theo cách này.
{{% /alert %}}

## **Thiết lập Khoảng cách Nhãn từ Trục**

Sử dụng [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) để kiểm soát khoảng cách giữa các nhãn trục danh mục và trục. Giá trị là phần trăm của kích thước phông chữ tối đa của các nhãn trục. Ví dụ này tạo một biểu đồ cột cụm và đặt độ dịch nhãn trục ngang là 500. Cài đặt này ảnh hưởng tới các nhãn trục danh mục thay vì các nhãn gắn vào từng điểm dữ liệu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Điều chỉnh Vị trí Nhãn**

Trong biểu đồ tròn, điều chỉnh vị trí nhãn dữ liệu để cải thiện khoảng cách và tạo không gian cho các đường dẫn.

Ví dụ này hiển thị giá trị của điểm dữ liệu đầu tiên, đặt nhãn của nó bên ngoài phần bánh, và điều chỉnh độ dịch ngang và dọc bằng cách sử dụng [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) và [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). Các độ dịch này được tính tương đối so với chiều rộng và chiều cao của biểu đồ, tương ứng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Biểu đồ tròn với vị trí nhãn dữ liệu đã điều chỉnh](pie-chart-adjusted-label.png)

## **Thêm Nhiều Hàng Nhãn Dữ liệu ở Trên Biểu đồ Cột**

Ví dụ này tạo một biểu đồ cột với hai hàng nhãn dữ liệu ở trên vùng vẽ. Chuỗi A hiển thị các cột có thể nhìn thấy, trong khi Chuỗi B và Chuỗi C cung cấp các nhãn bổ sung. Các cột của chúng được ẩn bằng cách loại bỏ màu nền và viền. Phương pháp [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) căn chỉnh cả ba chuỗi sao cho trung tâm danh mục giống nhau.

Cài đặt [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) dành không gian cho các hàng nhãn. Sau khi [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) tính toán vị trí mặc định, [DataLabel.setX và DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) giữ căn chỉnh ngang và áp dụng độ dịch dọc để sắp xếp các nhãn thành hai hàng. Các số vẫn là nhãn dữ liệu liên kết với giá trị của chuỗi; chỉ các tiêu đề hàng là các hình dạng văn bản riêng.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // Ẩn các cột của B và C, nhưng vẫn giữ nhãn dữ liệu của chúng.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // Căn chỉnh cả ba chuỗi sao cho có cùng trung tâm danh mục.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // Sử dụng ít đường lưới hơn cho ví dụ gọn này.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Dành không gian ở trên khu vực vẽ cho hai hàng nhãn dữ liệu.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Giữ vị trí ngang mặc định. Y là độ lệch tính từ
            // vị trí nhãn mặc định, được biểu diễn dưới dạng phân số chiều cao biểu đồ.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Chỉ tiêu đề hàng là một hình dạng văn bản riêng biệt.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để ngăn nhãn dữ liệu chồng lên nhau trên các biểu đồ dày đặc?**  
Kết hợp việc đặt nhãn tự động, các đường dẫn, và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ, danh mục) hoặc chỉ hiển thị nhãn cho các giá trị cực đoan hoặc các điểm chính.

**Làm sao tôi có thể tắt nhãn chỉ cho các giá trị bằng 0, âm hoặc trống?**  
Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị bằng 0, giá trị âm, hoặc giá trị thiếu theo một quy tắc đã định.

**Làm sao tôi có thể đảm bảo phong cách nhãn đồng nhất khi xuất ra PDF/hình ảnh?**  
Cài đặt rõ ràng họ phông chữ và kích thước, đồng thời xác minh rằng phông chữ đó có sẵn trong môi trường render để tránh việc dùng phông chữ thay thế.