---
title: Định dạng biểu đồ trong bài thuyết trình bằng JavaScript
linktitle: Định dạng biểu đồ
type: docs
weight: 60
url: /vi/nodejs-java/chart-formatting/
keywords:
- định dạng biểu đồ
- định dạng cho biểu đồ
- thực thể biểu đồ
- thuộc tính biểu đồ
- cài đặt biểu đồ
- tùy chọn biểu đồ
- thuộc tính phông chữ
- viền tròn
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho Node.js bằng JavaScript và nâng cao bài thuyết trình PowerPoint của bạn với phong cách chuyên nghiệp, bắt mắt."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong bài thuyết trình PowerPoint bằng cách sử dụng Aspose.Slides. Nó chỉ ra cách tùy chỉnh các thành phần chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, vùng vẽ và màu nền tường để nâng cao diện mạo và khả năng đọc dữ liệu biểu đồ.

Nó cũng trình bày cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng định dạng số có sẵn và tùy chỉnh cho dữ liệu biểu đồ, và bật góc cạnh tròn cho khu vực biểu đồ. Những ví dụ này cho thấy cách kiểm soát cả kiểu dáng trực quan và cách trình bày dữ liệu của biểu đồ trong một bài thuyết trình.

## **Định dạng các thực thể biểu đồ**

Aspose.Slides for Node.js via Java cho phép nhà phát triển thêm biểu đồ tùy chỉnh vào slide từ đầu. Bài viết này giải thích cách định dạng các thực thể biểu đồ khác nhau bao gồm trục danh mục và trục giá trị.

Aspose.Slides for Node.js via Java cung cấp API đơn giản để quản lý các thực thể biểu đồ và định dạng chúng bằng các giá trị tùy chỉnh:

1. Tạo một thể hiện của lớp [**Presentation**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới slide theo chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ kiểu nào mong muốn (trong ví dụ này chúng ta sẽ sử dụng ChartType.LineWithMarkers).
1. Truy cập trục Giá trị của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới Chính của trục Giá trị
   1. Đặt **Line format** cho các đường lưới Phụ của trục Giá trị
   1. Đặt **Number Format** cho trục Giá trị
   1. Đặt **Min, Max, Major and Minor units** cho trục Giá trị
   1. Đặt **Text Properties** cho dữ liệu trục Giá trị
   1. Đặt **Title** cho trục Giá trị
   1. Đặt **Line Format** cho trục Giá trị
1. Truy cập trục Danh mục của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới Chính của trục Danh mục
   1. Đặt **Line format** cho các đường lưới Phụ của trục Danh mục
   1. Đặt **Text Properties** cho dữ liệu trục Danh mục
   1. Đặt **Title** cho trục Danh mục
   1. Đặt **Label Positioning** cho trục Danh mục
   1. Đặt **Rotation Angle** cho nhãn trục Danh mục
1. Truy cập Chú giải của biểu đồ và đặt **Text Properties** cho chúng
1. Đặt hiển thị Chú giải biểu đồ mà không chồng lên biểu đồ
1. Truy cập **Secondary Value Axis** của biểu đồ và đặt các thuộc tính sau:
   1. Bật **Value Axis** phụ
   1. Đặt **Line Format** cho trục Giá trị phụ
   1. Đặt **Number Format** cho trục Giá trị phụ
   1. Đặt **Min, Max, Major and Minor units** cho trục Giá trị phụ
1. Bây giờ vẽ chuỗi biểu đồ đầu tiên trên trục Giá trị phụ
1. Đặt màu nền tường phía sau biểu đồ
1. Đặt màu nền vùng vẽ biểu đồ
1. Ghi bài thuyết trình đã chỉnh sửa vào tệp PPTX

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm biểu đồ mẫu
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Đặt tiêu đề biểu đồ
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Đặt định dạng đường lưới chính cho trục giá trị
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Đặt định dạng đường lưới phụ cho trục giá trị
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Đặt định dạng số cho trục giá trị
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Đặt giá trị tối đa, tối thiểu cho biểu đồ
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Đặt thuộc tính văn bản cho trục giá trị
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Đặt tiêu đề cho trục giá trị
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Đặt định dạng đường lưới chính cho trục danh mục
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Đặt định dạng đường lưới phụ cho trục danh mục
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setFillFormat(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Đặt thuộc tính văn bản cho trục danh mục
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Đặt tiêu đề danh mục
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Đặt vị trí nhãn trục danh mục
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Đặt góc quay nhãn trục danh mục
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Đặt thuộc tính văn bản cho chú giải
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Đặt hiển thị chú giải biểu đồ mà không chồng lên biểu đồ
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Đặt trục giá trị phụ
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Đặt định dạng số cho trục giá trị phụ
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Đặt giá trị tối đa, tối thiểu cho biểu đồ
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Đặt màu tường phía sau biểu đồ
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Đặt màu vùng vẽ
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Lưu bài thuyết trình
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt thuộc tính phông chữ cho biểu đồ**

Aspose.Slides for Node.js via Java hỗ trợ đặt các thuộc tính liên quan tới phông chữ cho biểu đồ. Vui lòng thực hiện các bước sau để thiết lập thuộc tính phông chữ cho biểu đồ.

- Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
- Thêm biểu đồ vào slide.
- Đặt chiều cao phông chữ.
- Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ mẫu dưới đây được cung cấp.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt định dạng số**

Aspose.Slides for Node.js via Java cung cấp API đơn giản để quản lý định dạng dữ liệu biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
1. Lấy tham chiếu tới slide theo chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ kiểu nào mong muốn (ví dụ này sử dụng **ChartType.ClusteredColumn**).
1. Đặt định dạng số có sẵn từ các giá trị preset có thể.
1. Duyệt qua các ô dữ liệu trong mỗi chuỗi biểu đồ và đặt định dạng số cho dữ liệu biểu đồ.
1. Lưu bài thuyết trình.
1. Đặt định dạng số tùy chỉnh.
1. Duyệt qua các ô dữ liệu trong mỗi chuỗi biểu đồ và đặt một định dạng số khác cho dữ liệu biểu đồ.
1. Lưu bài thuyết trình.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide thuyết trình đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm một biểu đồ cột nhóm mặc định
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Truy cập bộ sưu tập chuỗi biểu đồ
    var series = chart.getChartData().getSeries();
    // Duyệt qua mọi chuỗi biểu đồ
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Duyệt qua mọi ô dữ liệu trong chuỗi
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Đặt định dạng số
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Lưu bài thuyết trình
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Các giá trị định dạng số preset có thể sử dụng cùng với chỉ mục preset của chúng được đưa ra dưới đây:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Đặt viền góc tròn cho khu vực biểu đồ**

Aspose.Slides for Node.js via Java hỗ trợ thiết lập khu vực biểu đồ. Các phương thức [**hasRoundedCorners**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) và [**setRoundedCorners**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) đã được thêm vào lớp [Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Chart).

1. Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
1. Thêm biểu đồ vào slide.
1. Đặt loại và màu nền cho biểu đồ
1. Đặt thuộc tính góc tròn thành True.
1. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ mẫu dưới đây được cung cấp. 

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Tôi có thể đặt màu nền bán trong suốt cho cột/khu vực trong khi vẫn giữ viền không trong suốt không?**

Có. Độ trong suốt của nền và đường viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm sao để xử lý nhãn dữ liệu khi chúng bị chồng lấn?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ: danh mục), đặt độ offset/vị trí nhãn, chỉ hiển thị nhãn cho các điểm được chọn nếu cần, hoặc chuyển định dạng sang “value + legend”.

**Tôi có thể áp dụng màu nền gradient hoặc hoa văn cho chuỗi dữ liệu không?**

Có. Cả màu nền đặc và gradient/hoa văn thường đều khả dụng. Trong thực tế, nên sử dụng gradient một cách tiết kiệm và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.