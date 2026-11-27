---
title: Định dạng biểu đồ trong bản trình bày bằng JavaScript
linktitle: Định dạng biểu đồ
type: docs
weight: 60
url: /vi/nodejs-java/chart-formatting/
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
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho Node.js thông qua Java và nâng cao bản trình bày PowerPoint của bạn với các trục tùy chỉnh, phông chữ, định dạng số và viền biểu đồ bo tròn."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong bản thuyết trình PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các thành phần chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, khu vực vẽ và lớp nền tường để cải thiện ngoại hình và khả năng đọc dữ liệu biểu đồ.

Nó cũng trình bày cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng các định dạng số có sẵn cho dữ liệu biểu đồ và bật góc bo tròn cho khu vực biểu đồ. Các ví dụ này cho thấy cách kiểm soát cả kiểu hình ảnh và cách trình bày dữ liệu của biểu đồ trong bản trình chiếu.

Đối với nền và viền riêng biệt ở các khoảng thời gian tăng và giảm, xem [ví dụ biểu đồ chứng khoán](/slides/vi/nodejs-java/create-chart/#create-stock-charts).

## **Định dạng các thực thể biểu đồ**

Sử dụng [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) để định dạng tiêu đề biểu đồ, trục, đường lưới, chú giải và khu vực vẽ. Ví dụ này tạo một biểu đồ đường có dấu đánh dấu và dữ liệu mặc định, sau đó áp dụng các kiểu văn bản và đường riêng biệt cho trục giá trị và trục danh mục của nó. Kích thước phông chữ và độ rộng đường được chỉ định bằng điểm; nhãn danh mục được xoay 45 độ.

Trục giá trị sử dụng [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) một cách độc lập với các ô nguồn. Thang đo chạy từ -2 đến 15, với khoảng cách lớn là 2 và khoảng cách nhỏ là 0.5. Ví dụ cũng kết hợp định dạng phần trăm với [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) được đặt thành hàng nghìn, vì vậy hãy điều chỉnh các cài đặt này phù hợp với ý nghĩa và quy mô dữ liệu của bạn. Chú giải được đặt ở ngoài khu vực vẽ vì [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) được gọi với `false`. Các lớp nền tường và sàn được cấu hình thông qua [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) và [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor), nhưng những bề mặt này chỉ hiển thị trong biểu đồ 3D.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    let chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    chartTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15);
    chart.getAxes().getVerticalAxis().setMinValue(-2);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);

    let valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkGreen));
    valueAxisText.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    let valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    let categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    categoryAxisText.setLatinFont(new aspose.slides.FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    let categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    let legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    legendText.setFontHeight(16);
    legendText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    legendText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    legendText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkRed));

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.LightCyan));

    presentation.save("FormattedChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt thuộc tính phông chữ cho biểu đồ**

Đặt kích thước phông chữ mặc định cho văn bản biểu đồ thông qua [Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat). Ví dụ này tạo một biểu đồ cột nhóm với phông chữ 20 điểm và bật nhãn giá trị cho chuỗi đầu tiên thông qua [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue). Các phần tử văn bản có cài đặt phông chữ riêng có thể ghi đè lên mặc định của biểu đồ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tái sử dụng định dạng khung văn bản cho chú giải biểu đồ**

Để đồng bộ chú giải với tiêu đề slide, đặt phông chữ tiêu đề thông qua [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) trên đoạn văn đầu tiên. Gọi [copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyFrom) trên định dạng được trả về bởi [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#getTextFormat) của chú giải. Nó sao chép cài đặt khung văn bản, định dạng đoạn văn đầu tiên và các thuộc tính phông chữ mặc định của đoạn đó. Định dạng được áp dụng trực tiếp cho các phần riêng lẻ hoặc cho các đoạn sau sẽ chỉ tồn tại ở nguồn.

Ví dụ sử dụng tiêu đề Calibri đậm, 26 điểm, màu xanh hải quân làm mẫu. Sau khi định dạng chú giải, nó gọi [copyTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyTo) để áp dụng cùng một định dạng cho một chú thích riêng.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const heading = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 20, 640, 40, false);
    const sourceTextFrame = heading.addTextFrame("Quarterly sales");
    const font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new aspose.slides.FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    font.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    font.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 32, 64, 96));

    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(java.newByte(aspose.slides.StyleType.Style3));
    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (let quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(java.newByte(aspose.slides.LegendPositionType.Bottom));
    const legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    const caption = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 460, 640, 40, false);
    const captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trong bản trình chiếu đã lưu, chú giải và chú thích khớp với tiêu đề về kích thước, độ dày và màu sắc. Chú giải vẫn hiển thị tên các chuỗi, và chú thích giữ nguyên văn bản của nó. Nếu một phần trong chú thích đã có kích thước phông chữ cụ thể, kích thước đó sẽ có ưu tiên hơn so với đoạn mặc định đã sao chép.

| Trước khi sao chép | Sau khi sao chép |
| --- | --- |
| ![Biểu đồ bán hàng hàng quý với nhãn chú giải đen thông thường và chú thích đen](legend-formatting-before.png) | ![Biểu đồ tương tự với nhãn chú giải màu xanh hải quân đậm hơn, to hơn và chú thích khớp](legend-formatting.png) |

## **Đặt định dạng số**

Sử dụng [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) để áp dụng định dạng số có sẵn cho các ô trong sổ làm việc của biểu đồ. Ví dụ này tạo một biểu đồ cột nhóm với dữ liệu dựa trên ô mặc định và áp dụng chỉ mục định dạng 10 (`0.00%`) cho mỗi ô giá trị chuỗi. Điều này thay đổi cách hiển thị giá trị trong sổ làm việc mà không thay đổi các số thực tế; ví dụ, 0.25 sẽ hiển thị là 25.00%. Định dạng trục và nhãn dữ liệu có thể được cấu hình riêng biệt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    let series = chart.getChartData().getSeries();

    for (let i = 0; i < series.size(); i++) {
        let chartSeries = series.get_Item(i);
        for (let j = 0; j < chartSeries.getDataPoints().size(); j++) {
            let dataPoint = chartSeries.getDataPoints().get_Item(j);
            dataPoint.getValue().getAsCell().setPresetNumberFormat(java.newByte(10)); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bảng sau liệt kê các chỉ mục định dạng số có sẵn cùng với các định dạng Excel đại diện cho ngôn ngữ Anh (Hoa Kỳ). Các chuỗi định dạng và cách hiển thị có thể thay đổi tùy theo ứng dụng và ngôn ngữ, đặc biệt đối với tiền tệ và ngày tháng. Một số định dạng Excel cũng khác với mặc định trong tiêu chuẩn OOXML, như mô tả trong [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Chỉ mục | Định dạng |
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

## **Đặt viền bo tròn cho khu vực biểu đồ**

Gọi [Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) với `true` để làm tròn các góc của khu vực biểu đồ. Ví dụ này tạo một biểu đồ cột nhóm và sử dụng [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) để đặt viền của nó thành màu xám đặc và kiểu một đường trước khi lưu bản trình chiếu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chart.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Chỉnh sửa chú thích biểu đồ hiện có**

Biểu đồ có thể chứa các hình dạng tùy chỉnh, chẳng hạn như chú thích văn bản giải thích trạng thái của báo cáo. Truy cập các hình dạng này thông qua [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes). Bộ sưu tập trả về bởi [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) chứa các hình dạng thuộc sở hữu của biểu đồ.

Một hộp văn bản thông thường được đặt lên trên biểu đồ thuộc về slide, ngay cả khi nó trông giống như một phần của biểu đồ. Duyệt qua [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) sẽ tìm thấy biểu đồ và các hình dạng slide thông thường, nhưng sẽ không liệt kê các hình dạng riêng lẻ bên trong biểu đồ. Tiêu đề biểu đồ và nhãn dữ liệu là các thành phần biểu đồ riêng, không phải là chú thích tùy chỉnh trong bộ sưu tập này.

Tải xuống [chart-annotations.pptx](chart-annotations.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Slide đầu tiên chứa một biểu đồ có chú thích chưa được nhóm ghi “Preliminary results”, một đường thuộc sở hữu của biểu đồ, và một hộp văn bản slide bình thường ghi “Slide overlay”. Ví dụ tìm biểu đồ đầu tiên trên slide đó và thay đổi chú thích thành “Final results” khi báo cáo đã sẵn sàng để xuất bản. Nó kiểm tra bộ sưu tập rỗng và chỉ chỉnh sửa một [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) có khung văn bản không rỗng được trả về bởi [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) và văn bản mong đợi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("chart-annotations.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = null;
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
            chart = shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        console.log("No chart or chart-owned shapes found.");
    } else {
        let updated = false;
        for (let i = 0; i < chart.getUserShapes().getShapes().size(); i++) {
            let shape = chart.getUserShapes().getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let annotation = shape;
                if (annotation.getTextFrame() != null && annotation.getTextFrame().getText() === "Preliminary results") {
                    annotation.getTextFrame().setText("Final results");
                    updated = true;
                    break;
                }
            }
        }

        if (updated) {
            presentation.save("chart-annotations-updated.pptx", aspose.slides.SaveFormat.Pptx);
        } else {
            console.log("No matching text annotation found.");
        }
    }
} finally {
    presentation.dispose();
}
```

Đường và hộp văn bản slide vẫn giữ nguyên. Các hình ảnh sau đây hiển thị kết quả đầu vào và kết quả đã lưu, mở lại:

| Trước khi chỉnh sửa | Sau khi chỉnh sửa |
| --- | --- |
| ![Chú thích biểu đồ ghi Preliminary results](chart-annotations-before.png) | ![Chú thích biểu đồ ghi Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Ví dụ chỉ kiểm tra các hình dạng thuộc sở hữu của biểu đồ ở cấp cao nhất. Nếu một chú thích nằm trong một [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), hãy kiểm tra bộ sưu tập [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) của nhóm đó nữa. Lặp lại quá trình này một cách đệ quy cho các nhóm lồng nhau, áp dụng cùng các kiểm tra văn bản cho các hình dạng con của chúng. Một nhóm tự nó là một container; không được coi nó là một hộp văn bản.
{{% /alert %}}

## **FAQ**

**Tôi có thể đặt các lớp nền bán trong suốt cho cột/khu vực trong khi giữ viền không trong suốt không?**

Có. Độ trong suốt của lớp nền và đường viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm thế nào tôi có thể xử lý các nhãn dữ liệu khi chúng chồng lấn nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không thiết yếu (ví dụ: danh mục), điều chỉnh vị trí nhãn, chỉ hiển thị nhãn cho các điểm được chọn nếu cần, hoặc chuyển đổi định dạng thành “giá trị + chú giải”.

**Tôi có thể áp dụng lớp nền gradient hoặc họa tiết cho chuỗi không?**

Có. Các chuỗi hỗ trợ lớp nền đặc, gradient và họa tiết. Trong thực tế, hãy sử dụng gradient một cách hạn chế và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.