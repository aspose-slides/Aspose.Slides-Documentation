---
title: Định dạng biểu đồ trong PowerPoint bằng Java
linktitle: Định dạng biểu đồ
type: docs
weight: 60
url: /vi/java/chart-formatting/
keywords:
- định dạng biểu đồ
- định dạng biểu đồ
- thực thể biểu đồ
- thuộc tính biểu đồ
- cài đặt biểu đồ
- tùy chọn biểu đồ
- thuộc tính phông chữ
- viền bo tròn
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho Java và nâng cao bản trình chiếu PowerPoint của bạn với các trục tùy chỉnh, phông chữ, định dạng số và viền biểu đồ bo tròn."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các thành phần chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, vùng vẽ và màu nền tường để cải thiện ngoại hình và khả năng đọc dữ liệu biểu đồ.

Nó cũng minh họa cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng các định dạng số được đặt trước cho dữ liệu biểu đồ, và bật các góc bo tròn cho vùng biểu đồ. Cùng nhau, các ví dụ này cho thấy cách kiểm soát cả kiểu trực quan và cách trình bày dữ liệu của biểu đồ trong bản trình chiếu.

Đối với việc tô màu và đường viền riêng biệt cho các khoảng tăng và giảm, xem [ví dụ biểu đồ cổ phiếu](/slides/vi/java/create-chart/#create-stock-charts).

## **Định dạng các thực thể biểu đồ**

Sử dụng [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) để định dạng tiêu đề biểu đồ, trục, đường lưới, chú giải và vùng vẽ. Ví dụ này tạo một biểu đồ đường có các điểm đánh dấu và dữ liệu mặc định, sau đó áp dụng các kiểu văn bản và đường riêng biệt cho trục giá trị và trục danh mục. Kích thước phông chữ và độ rộng đường được chỉ định bằng điểm; nhãn danh mục được xoay 45 độ.

Trục giá trị sử dụng [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) một cách độc lập với các ô nguồn. Thang đo của nó chạy từ -2 đến 15, với khoảng cách lớn là 2 và khoảng cách nhỏ là 0.5. Ví dụ cũng kết hợp định dạng phần trăm với [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) được đặt thành hàng nghìn, vì vậy hãy điều chỉnh các cài đặt này cho ý nghĩa và quy mô dữ liệu của bạn. Chú giải nằm ngoài vùng vẽ vì [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) được gọi với `false`. Các màu nền tường sau và sàn được cấu hình qua [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) và [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--), nhưng những bề mặt này chỉ hiển thị trong biểu đồ 3D.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt thuộc tính phông chữ cho biểu đồ**

Đặt kích thước phông chữ mặc định cho văn bản biểu đồ bằng [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). Ví dụ tạo một biểu đồ cột nhóm với phông chữ 20 điểm và bật nhãn giá trị cho chuỗi đầu tiên thông qua [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Các phần tử văn bản có cài đặt phông chữ riêng có thể ghi đè lên mặc định của biểu đồ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tái sử dụng định dạng khung văn bản cho chú giải biểu đồ**

Để khớp chú giải với tiêu đề slide, đặt phông chữ của tiêu đề thông qua [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) trên đoạn đầu tiên. Gọi [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) trên định dạng được trả về bởi [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) của chú giải. Nó sao chép các cài đặt khung văn bản, định dạng của đoạn đầu tiên và các thuộc tính phông chữ mặc định của đoạn đó. Định dạng được áp dụng trực tiếp cho các phần riêng lẻ hoặc cho các đoạn sau sẽ giữ nguyên tại nguồn.

Ví dụ sử dụng tiêu đề Calibri đậm, 26 điểm màu xanh hải quân làm mẫu. Sau khi tạo kiểu cho chú giải, nó gọi [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) để áp dụng cùng một định dạng cho một chú thích riêng.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trong bản trình chiếu đã lưu, chú giải và chú thích khớp với tiêu đề về kích thước, độ đậm và màu sắc. Chú giải vẫn hiển thị tên các chuỗi, và chú thích giữ nguyên văn bản của nó. Nếu một phần trong chú thích đã có kích thước phông chữ cụ thể, kích thước đó sẽ có ưu tiên hơn mặc định của đoạn đã sao chép.

| Trước khi sao chép | Sau khi sao chép |
| --- | --- |
| ![Biểu đồ doanh thu hàng quý với nhãn chú giải đen thông thường và chú thích đen](legend-formatting-before.png) | ![Cùng biểu đồ với nhãn chú giải đen lớn hơn, đậm, màu xanh hải quân và chú thích phù hợp](legend-formatting.png) |

## **Đặt định dạng số**

Sử dụng [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) để áp dụng định dạng số tích hợp sẵn cho các ô trong sổ làm việc của biểu đồ. Ví dụ này tạo một biểu đồ cột nhóm với dữ liệu mặc định dựa trên ô và áp dụng chỉ mục định dạng 10 (`0.00%`) cho mỗi ô giá trị chuỗi. Điều này thay đổi cách các giá trị được hiển thị trong sổ làm việc mà không thay đổi các số gốc; ví dụ, 0.25 được hiển thị là 25.00%. Định dạng trục và nhãn dữ liệu có thể được cấu hình riêng biệt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bảng sau liệt kê các chỉ số định dạng số tích hợp sẵn cùng với các định dạng Excel đại diện cho bản địa Tiếng Anh (Hoa Kỳ). Các chuỗi định dạng và cách hiển thị chúng có thể khác nhau tùy ứng dụng và bản địa, đặc biệt đối với tiền tệ và ngày tháng. Một số định dạng Excel cũng khác với mặc định trong tiêu chuẩn OOXML, như được mô tả trong [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Chỉ số | Định dạng |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Đặt viền tròn cho vùng biểu đồ**

Gọi [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) với `true` để bo tròn các góc của vùng biểu đồ. Ví dụ tạo một biểu đồ cột nhóm và sử dụng [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) để đặt viền của nó thành màu xám đặc và kiểu một đường trước khi lưu bản trình chiếu.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Chỉnh sửa chú thích biểu đồ hiện có**

Một biểu đồ có thể chứa các hình dạng tùy chỉnh, chẳng hạn như một chú thích văn bản giải thích trạng thái của báo cáo. Truy cập các hình dạng này thông qua [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), cũng được liệt kê dưới [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) trong Tham chiếu API của Chart. Bộ sưu tập trả về bởi [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) chứa các hình dạng thuộc sở hữu của biểu đồ.

Một hộp văn bản thông thường được đặt lên trên biểu đồ thuộc về slide, ngay cả khi nó trông giống như một phần của biểu đồ. Duyệt qua [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) sẽ tìm thấy biểu đồ và các hình dạng slide thông thường, nhưng không liệt kê các hình dạng riêng lẻ bên trong biểu đồ. Tiêu đề biểu đồ và nhãn dữ liệu là các phần tử biểu đồ riêng biệt, không phải là chú thích tùy chỉnh trong bộ sưu tập này.

Tải xuống [chart-annotations.pptx](chart-annotations.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa một biểu đồ với chú thích chưa được nhóm ghi là "Preliminary results", một đường thuộc sở hữu của biểu đồ, và một hộp văn bản slide thông thường ghi "Slide overlay". Ví dụ tìm biểu đồ đầu tiên trên slide đó và thay đổi chú thích thành "Final results" khi báo cáo đã sẵn sàng để xuất bản. Nó kiểm tra xem bộ sưu tập có rỗng không và chỉ chỉnh sửa một [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) có khung văn bản không null được trả về bởi [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) và chứa văn bản mong đợi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

Đường và hộp văn bản slide vẫn không thay đổi. Các hình ảnh sau hiển thị đầu vào và kết quả đã lưu, mở lại:

| Trước khi chỉnh sửa | Sau khi chỉnh sửa |
| --- | --- |
| ![Chú thích biểu đồ ghi Preliminary results](chart-annotations-before.png) | ![Chú thích biểu đồ ghi Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Ví dụ chỉ kiểm tra các hình dạng thuộc sở hữu của biểu đồ ở mức độ cao nhất. Nếu một chú thích nằm bên trong một [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), hãy kiểm tra bộ sưu tập [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) của nhóm đó nữa. Lặp lại quy trình này một cách đệ quy cho các nhóm lồng nhau, áp dụng các kiểm tra văn bản tương tự cho các hình dạng con của chúng. Một nhóm tự nó là một container; không coi nó như một hộp văn bản.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Có thể đặt màu nền bán trong suốt cho các cột/khu vực trong khi giữ viền không trong suốt không?**

Có. Độ trong suốt của màu nền và viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc của lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm sao để xử lý các nhãn dữ liệu khi chúng chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ, danh mục), điều chỉnh vị trí nhãn, chỉ hiển thị nhãn cho các điểm đã chọn nếu cần, hoặc chuyển định dạng sang "giá trị + chú giải".

**Có thể áp dụng màu nền gradient hoặc mẫu cho các chuỗi không?**

Có. Các chuỗi hỗ trợ màu nền đặc, gradient và mẫu. Trong thực tế, nên sử dụng gradient một cách hạn chế và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.