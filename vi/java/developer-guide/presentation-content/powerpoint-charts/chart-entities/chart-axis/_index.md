---
title: Tùy chỉnh trục biểu đồ trong bản trình bày bằng Java
linktitle: Trục biểu đồ
type: docs
url: /vi/java/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
- điều khiển trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides for Java để tùy chỉnh trục biểu đồ trong các bản trình bày PowerPoint cho báo cáo và trực quan hóa."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các trục biểu đồ bằng Aspose.Slides for Java. Nó bao gồm các giá trị trục được tính, chuyển đổi hàng và cột của biểu đồ, hiển thị trục, khoảng cách nhãn danh mục và dấu tick, danh mục ngày và định dạng, quay tiêu đề, vị trí trục, đơn vị hiển thị và tỷ lệ logarit.

## **Lấy Giá Trị Tối Đa Trên Trục Dọc Trong Biểu Đồ**

Tạo một [Bản trình bày](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) và thêm một biểu đồ khu vực với dữ liệu mặc định. Gọi [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) trước khi đọc các giá trị trục đã tính để bố cục biểu đồ được cập nhật.

Đọc [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) và [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) để lấy giới hạn trục, và [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) và [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) để lấy khoảng cách các dấu tick. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) và [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) cung cấp các tỉ lệ đơn vị thời gian, có liên quan đến các trục ngày. Ví dụ lưu các giá trị này vào các biến cục bộ và lưu biểu đồ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hoán Đổi Dữ Liệu Giữa Các Trục**

Use [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) để đổi vai trò của series và categories trong dữ liệu biểu đồ. Mỗi category cũ trở thành một series, và mỗi series cũ trở thành một category. Điều này thay đổi cách nhóm dữ liệu; nó không hoán đổi trục ngang và trục dọc. Ví dụ sử dụng [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) để liên kết dữ liệu mặc định tới `Sheet1!A1:D5`, bao gồm hàng tiêu đề và cột category, trước khi hoán đổi hàng và cột. Nó lưu một biểu đồ với bốn series và ba category.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đảo Ngược Thứ Tự Vẽ Của Một Trục**

Use [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) để đảo ngược một trục category hoặc value. Ví dụ, một biểu đồ thanh ngang có thể hiển thị các giai đoạn dự án từ trên xuống dưới theo cùng thứ tự như bảng tính: Planning, Development, Testing. Đảo ngược trục thay đổi hướng vẽ; nó không sắp xếp hoặc thay đổi dữ liệu trong workbook. Ngược lại, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) đổi vai trò của series và categories.

Ví dụ bên dưới tạo một biểu đồ thanh ngang với ba giai đoạn và một series. Nó lưu một bản trình bày với ba slide: thứ tự bình thường, categories đảo ngược, và values đảo ngược. Mỗi bản sao sử dụng cùng một tập dữ liệu, và chỉ một trục được đảo ngược trên mỗi bản sao.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Slide 2: hiển thị danh mục đầu tiên ở trên cùng.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Giữ trục giá trị ngang ở phía dưới.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Slide 3: đảo ngược chỉ thang số ngang.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đảo ngược một trục cũng có thể di chuyển trục vuông góc sang phía đối diện của biểu đồ. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) kiểm soát nơi trục còn lại cắt qua trục đang cấu hình. Trong slide 2, gọi nó với `CrossesType.Maximum` trên trục category đã đảo ngược giữ trục value ngang ở phía dưới. Đối với một điểm cắt cụ thể, sử dụng [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Kiểm tra cài đặt cắt khi đổi hướng, đặc biệt nếu biểu đồ đã có một điểm cắt tùy chỉnh. Gọi `setPlotOrderReversed` với `false` để khôi phục hướng vẽ bình thường; cài đặt cắt là riêng biệt.

| Thứ tự bình thường (slide 1) | Categories đảo ngược (slide 2) | Values đảo ngược (slide 3) |
| --- | --- | --- |
| ![Biểu đồ thanh ngang với trục danh mục và giá trị theo thứ tự bình thường](axis-order-normal.png) | ![Biểu đồ thanh ngang với danh mục hiển thị từ trên xuống dưới](axis-order-categories-reversed.png) | ![Biểu đồ thanh ngang với trục giá trị đảo ngược và số 0 ở bên phải](axis-order-values-reversed.png) |
| Các danh mục chạy từ dưới lên trên; các giá trị tăng từ trái sang phải. | Planning, Development và Testing chạy từ trên xuống dưới. Các giá trị và thứ tự hàng trong workbook không thay đổi. | Các danh mục giữ nguyên thứ tự bình thường; các giá trị tăng từ phải sang trái. Trục danh mục cắt ở giá trị 0 bên phải. |

## **Vô Hiệu Hóa Trục Dọc Cho Biểu Đồ Đường**

Gọi [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) với `false` trên trục dọc để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu nó với trục dọc bị ẩn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vô Hiệu Hóa Trục Ngang Cho Biểu Đồ Đường**

Gọi [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) với `false` trên trục ngang để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu nó với trục ngang bị ẩn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thay Đổi Trục Danh Mục**

Sử dụng [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) để chọn trục danh mục dạng ngày hoặc văn bản. Ví dụ này yêu cầu `ExistingChart.pptx`, với một biểu đồ là shape đầu tiên trên slide đầu và các ô danh mục chứa giá trị ngày Excel dạng số. Nó thay đổi trục ngang thành trục ngày. Gọi [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) với `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) với `1`, và [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) với `TimeUnitType.Months` để đặt các dấu tick chính cách nhau một tháng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm Soát Khoảng Cách Nhãn Trục Danh Mục**

Khi một biểu đồ có nhiều category, giảm số lượng nhãn trục hiển thị mà không loại bỏ các category hoặc điểm dữ liệu. Gọi [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) với `false`, sau đó truyền khoảng cách category mong muốn vào [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Đối với các category văn bản theo thứ tự bình thường, đếm bắt đầu từ category đầu tiên:

| Khoảng cách | Nhãn hiển thị trong ví dụ |
| --- | --- |
| `1` | Danh mục 1, Danh mục 2, Danh mục 3, ... Danh mục 24 |
| `2` | Danh mục 1, Danh mục 3, Danh mục 5, ... Danh mục 23 |
| `3` | Danh mục 1, Danh mục 4, Danh mục 7, ... Danh mục 22 |

Khoảng cách `3` hiển thị mỗi nhãn thứ ba, để lại hai nhãn bị ẩn giữa các nhãn hiển thị. Nó không loại bỏ các cột tương ứng. Khoảng cách tự động chọn một khoảng dựa trên không gian khả dụng; nó không nhất thiết hiển thị mọi nhãn.

Dấu tick có các điều khiển riêng. Gọi [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) với `false` và sử dụng [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) để đặt khoảng cách của chúng. Ví dụ, `1` giữ một dấu tick ở mỗi khoảng category trong khi nhãn chỉ xuất hiện mỗi ba category. Sử dụng [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) với một kiểu hiển thị để bạn có thể thấy kết quả. Gọi bất kỳ setter tự động nào với `true` một lần nữa cho phép biểu đồ chọn lại khoảng đó.

Ví dụ tự chứa bên dưới tạo 24 category và một series, sau đó lưu ba slide trong `CategoryAxisIntervals.pptx`: khoảng cách tự động, khoảng cách nhãn thủ công với các dấu tick độc lập, và khôi phục khoảng cách tự động. Hai bản sao giữ dữ liệu biểu đồ gốc. Không cần bản trình bày đầu vào. Văn bản nhãn ngang làm cho sự khác biệt về mật độ dễ nhận thấy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slide 2: hiển thị mỗi nhãn thứ ba, nhưng giữ một dấu tick cho mỗi danh mục.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slide 3: để biểu đồ chọn lại cả hai khoảng cách.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Khoảng cách tự động (slide 1):** Trong hình này, mỗi nhãn category thứ hai được hiển thị và xuống dòng thành hai dòng. Kết quả tự động có thể thay đổi tùy kích thước biểu đồ, phông chữ và bộ render.

![Khoảng cách nhãn danh mục tự động với tất cả 24 cột hiển thị](category-axis-automatic.png)

**Khoảng cách thủ công (slide 2):** Mỗi nhãn thứ ba được hiển thị trên một dòng, trong khi các dấu tick vẫn ở mỗi khoảng category. Tất cả 24 cột, bao gồm các cột không có nhãn, vẫn hiển thị với cùng giá trị. Slide 3 khôi phục giao diện tự động như trên.

![Khoảng cách nhãn danh mục thủ công là ba với tất cả 24 cột hiển thị](category-axis-manual.png)

### **Chọn Trục và Khoảng Cách Phù Hợp**

Sử dụng khoảng cách này cho một trục category dạng văn bản, chẳng hạn trục category của biểu đồ cột, đường, khu vực hoặc thanh. Trong biểu đồ cột, nó là trục ngang. Trong biểu đồ thanh ngang, trục category là trục dọc, vì vậy áp dụng các cài đặt này cho trục được trả về bởi [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Khoảng cách dấu tick cũng áp dụng cho trục series trong các biểu đồ có trục series.

Không sử dụng khoảng cách nhãn category để thiết lập thang số của trục value. Trên trục value, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) chỉ định sự chênh lệch giá trị: ví dụ, một đơn vị lớn `10` tạo các dấu tick tại 0, 10, 20, … khi trục bắt đầu từ 0. Khoảng cách nhãn category `3` thay vào đó đếm vị trí category, bất kể giá trị dữ liệu. Các biểu đồ scatter và bubble sử dụng trục value thay vì trục category dạng văn bản. Đối với trục ngày, sử dụng đơn vị lớn và thang thời gian như mô tả trong [Thay Đổi Trục Danh Mục](#thay-đổi-trục-danh-mục).

## **Đặt Định Dạng Ngày Cho Giá Trị Trục Danh Mục**

Ví dụ thay thế dữ liệu biểu đồ mặc định bằng bốn giá trị hàng năm. Ngày được lưu dưới dạng số nguyên OLE Automation trong worksheet đầu tiên (chỉ mục `0`), tính bằng số ngày kể từ 30‑12‑1899. Sử dụng [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) với `CategoryAxisType.Date`, gọi [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) với `false`, và truyền `yyyy` vào [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) để nhãn category hiển thị năm bốn chữ số độc lập với định dạng ô.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Góc Xoay Cho Tiêu Đề Trục Biểu Đồ**

Gọi [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) với `true` trên trục dọc, cung cấp văn bản tiêu đề, và sử dụng [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) để quay tiêu đề. Góc đo bằng độ; ví dụ này lưu một biểu đồ cột với tiêu đề trục giá trị quay 90 độ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Vị Trí Trục Trên Trục Danh Mục Hoặc Giá Trị**

Sử dụng [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) để kiểm soát việc trục value cắt qua trục category giữa các category hoặc tại các dấu tick của category. Cài đặt này áp dụng cho các trục category. Ví dụ đặt nó thành `true` trên trục category ngang của một biểu đồ cột và lưu kết quả.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Đơn Vị Hiển Thị Trên Trục Giá Trị Của Biểu Đồ**

Sử dụng [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) để tỷ lệ các nhãn trên trục value mà không thay đổi dữ liệu nền. Với [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) đặt thành `Millions`, giá trị 60 000 000 sẽ hiển thị là 60. Ví dụ tạo một biểu đồ cột và áp dụng đơn vị hiển thị hàng triệu cho trục dọc của nó.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cấu Hình Trục Giá Trị Logarit**

Trục giá trị logarit hữu ích khi các giá trị dương trải qua nhiều bậc độ lớn. Ví dụ, một dịch vụ có thể nhận 10, 100, 1 000, 10 000 và 100 000 yêu cầu trong năm kỳ. Trên thang tuyến tính, các giá trị nhỏ hơn xuất hiện gần nhau ở gần zero. Thang logarit làm cho sự tăng trưởng tương đối của chúng dễ so sánh hơn: khoảng cách bằng nhau đại diện cho tỉ lệ bằng nhau thay vì chênh lệch bằng nhau.

Gọi [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) với `true` trên trục value và sử dụng [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) để chọn cơ số. Điều này thay đổi cách các giá trị hiện có được hiển thị; nó không thay đổi dữ liệu hay thêm đường xu hướng logarit. Đường xu hướng là một tính năng riêng, biểu thị mối quan hệ phù hợp trong dữ liệu.

### **Chọn Trục Giá Trị và Cơ Số**

Đối với biểu đồ đường hoặc cột, trục value được trả về bởi [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Đối với biểu đồ thanh ngang, trục này được trả về bởi [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Các biểu đồ scatter và bubble có hai trục value, vì vậy chọn trục ngang cho giá trị X, trục dọc cho giá trị Y, hoặc cả hai. Không áp dụng tỷ lệ logarit cho trục category.

Cơ số logarit mặc định là `10`. Đối với biểu đồ PPTX, sử dụng cơ số từ `2` đến `1000`, bao gồm cả các cơ số phân số như `2.5`. Với cơ số `10`, các lũy thừa liên tiếp như 10, 100, 1 000, và 10 000 có khoảng cách đều nhau.

### **So Sánh Thang Độ Tuyến Tính và Logarit**

Ví dụ tự chứa bên dưới tạo một biểu đồ đường với năm lượng yêu cầu trên slide đầu, sau đó sao chép slide đó và bật trục value logarit cơ số 10 trên slide thứ hai. Cả hai slide giữ cùng dữ liệu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Giữ slide đầu tiên ở dạng tuyến tính và chỉ thay đổi thang trục giá trị của bản sao.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Thang tuyến tính (slide 1):** Khoảng cách dọc bằng nhau đại diện cho sự chênh lệch bằng nhau trong số lượng yêu cầu. Giá trị lớn nhất chiếm ưu thế trong biểu đồ, làm cho các giá trị nhỏ hơn khó phân biệt.

![Biểu đồ đường trong PowerPoint hiển thị năm số lượng yêu cầu trên trục giá trị tuyến tính](value-axis-linear.png)

**Thang logarit (slide 2):** Khoảng cách dọc bằng nhau đại diện cho tỉ lệ bằng nhau. Mỗi kỳ có số yêu cầu gấp mười lần kỳ trước, vì vậy các điểm tạo thành một đường thẳng tăng lên trên thang cơ số 10. Các nhãn trục vẫn hiển thị số lượng yêu cầu gốc.

![Cùng năm số lượng yêu cầu trong PowerPoint trên trục giá trị logarit cơ số 10](value-axis-logarithmic.png)

### **Xử Lý Giá Trị Zero và Âm**

Thang logarit chỉ hiển thị các giá trị dương tuyệt đối. Kiểm tra dữ liệu trước khi bật nó. Nếu giá trị zero hoặc âm có ý nghĩa, giữ thang tuyến tính hoặc hiển thị chúng riêng biệt. Nếu việc loại bỏ các giá trị đó là phù hợp cho phân tích, hãy giải thích lý do. Đừng lặng lẽ thay thế chúng bằng các số dương nhỏ, vì điều này thay đổi ý nghĩa dữ liệu. Bất kỳ giá trị min hoặc max nào được cấu hình thủ công cho trục logarit cũng phải là dương.

## **Câu Hỏi Thường Gặp**

**Làm thế nào để đặt giá trị mà một trục cắt qua trục còn lại (cắt trục)?**

Sử dụng [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) để chọn hành vi cắt. Để chỉ định một giá trị cắt số, dùng [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Các cài đặt này cho phép bạn di chuyển điểm cắt trục tới một mức nền phù hợp.

**Làm thế nào tôi có thể định vị nhãn tick so với trục?**

Gọi [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) sử dụng [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, hoặc `None`. Để kiểm soát các dấu tick, sử dụng [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) hoặc [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); chúng tách biệt với vị trí nhãn.