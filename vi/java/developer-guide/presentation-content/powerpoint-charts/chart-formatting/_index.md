---
title: Định dạng biểu đồ trình chiếu trong Java
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
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho Java và nâng cao bản thuyết trình PowerPoint của bạn với phong cách chuyên nghiệp, bắt mắt."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong các bản thuyết trình PowerPoint bằng cách sử dụng Aspose.Slides. Nó chỉ ra cách tùy chỉnh các thành phần chính của biểu đồ như trục, dòng lưới, tiêu đề, chú giải, vùng vẽ và màu nền tường để cải thiện giao diện và khả năng đọc dữ liệu biểu đồ.

Nó cũng minh họa cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng các định dạng số có sẵn và tùy chỉnh cho dữ liệu biểu đồ, và bật các góc bo tròn cho khu vực biểu đồ. Cùng nhau, các ví dụ này cho thấy cách kiểm soát cả kiểu hình ảnh và cách trình bày dữ liệu của biểu đồ trong một bản thuyết trình.

## **Định dạng các thực thể biểu đồ**
Aspose.Slides for Java cho phép các nhà phát triển thêm biểu đồ tùy chỉnh vào slide từ đầu. Bài viết này giải thích cách định dạng các thực thể biểu đồ khác nhau bao gồm trục danh mục và trục giá trị của biểu đồ.

Aspose.Slides for Java cung cấp một API đơn giản để quản lý các thực thể biểu đồ khác nhau và định dạng chúng bằng các giá trị tùy chỉnh:

1. Tạo một thể hiện của lớp [**Presentation**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Lấy tham chiếu slide theo chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (trong ví dụ này chúng ta sẽ sử dụng ChartType.LineWithMarkers).
4. Truy cập trục Giá trị của biểu đồ và đặt các thuộc tính sau:
    1. Đặt **Line format** cho các đường lưới chính của trục Giá trị
    2. Đặt **Line format** cho các đường lưới phụ của trục Giá trị
    3. Đặt **Number Format** cho trục Giá trị
    4. Đặt **Min, Max, Major and Minor units** cho trục Giá trị
    5. Đặt **Text Properties** cho dữ liệu trục Giá trị
    6. Đặt **Title** cho trục Giá trị
    7. Đặt **Line Format** cho trục Giá trị
5. Truy cập trục Danh mục của biểu đồ và đặt các thuộc tính sau:
    1. Đặt **Line format** cho các đường lưới chính của trục Danh mục
    2. Đặt **Line format** cho các đường lưới phụ của trục Danh mục
    3. Đặt **Text Properties** cho dữ liệu trục Danh mục
    4. Đặt **Title** cho trục Danh mục
    5. Đặt **Label Positioning** cho trục Danh mục
    6. Đặt **Rotation Angle** cho nhãn trục Danh mục
6. Truy cập chú giải của biểu đồ và đặt **Text Properties** cho chúng
7. Đặt hiển thị chú giải biểu đồ mà không chồng lên biểu đồ
8. Truy cập **Secondary Value Axis** của biểu đồ và đặt các thuộc tính sau:
    1. Bật **Value Axis** phụ
    2. Đặt **Line Format** cho Secondary Value Axis
    3. Đặt **Number Format** cho Secondary Value Axis
    4. Đặt **Min, Max, Major and Minor units** cho Secondary Value Axis
9. Bây giờ vẽ chuỗi biểu đồ đầu tiên trên Secondary Value Axis
10. Đặt màu nền tường phía sau của biểu đồ
11. Đặt màu nền cho vùng vẽ của biểu đồ
12. Ghi bản thuyết trình đã chỉnh sửa ra tệp PPTX

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm biểu đồ mẫu
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Đặt tiêu đề biểu đồ
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Đặt định dạng đường lưới chính cho trục giá trị
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Đặt định dạng đường lưới phụ cho trục giá trị
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Đặt định dạng số cho trục giá trị
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Đặt giá trị tối đa, tối thiểu cho biểu đồ
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Đặt thuộc tính văn bản cho trục giá trị
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Đặt tiêu đề trục giá trị
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Đặt định dạng đường lưới chính cho trục Danh mục
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Đặt định dạng đường lưới phụ cho trục Danh mục
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Đặt thuộc tính văn bản cho trục Danh mục
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Đặt tiêu đề Danh mục
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Đặt vị trí nhãn trục Danh mục
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Đặt góc quay nhãn trục Danh mục
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Đặt thuộc tính văn bản cho chú giải
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Đặt hiển thị chú giải biểu đồ mà không chồng lên biểu đồ

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Đặt trục giá trị phụ
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Đặt định dạng số cho trục giá trị phụ
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Đặt giá trị tối đa, tối thiểu cho biểu đồ
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Đặt màu tường sau của biểu đồ
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Đặt màu khu vực vẽ biểu đồ
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Save Presentation
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Đặt thuộc tính phông chữ cho biểu đồ**
Aspose.Slides for Java hỗ trợ việc đặt các thuộc tính liên quan đến phông chữ cho biểu đồ. Vui lòng thực hiện các bước dưới đây để đặt thuộc tính phông chữ cho biểu đồ.

- Tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
- Thêm biểu đồ vào slide.
- Đặt độ cao phông chữ.
- Lưu bản thuyết trình đã chỉnh sửa.

Ví dụ mẫu dưới đây được đưa ra.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt định dạng số**
Aspose.Slides for Java cung cấp một API đơn giản để quản lý định dạng dữ liệu biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy tham chiếu slide theo chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng **ChartType.ClusteredColumn**).
4. Đặt định dạng số có sẵn từ các giá trị sẵn có.
5. Duyệt qua các ô dữ liệu biểu đồ trong mỗi chuỗi và đặt định dạng số cho dữ liệu biểu đồ.
6. Lưu bản thuyết trình.
7. Đặt định dạng số tùy chỉnh.
8. Duyệt qua các ô dữ liệu biểu đồ trong mỗi chuỗi và đặt một định dạng số khác cho dữ liệu biểu đồ.
9. Lưu bản thuyết trình.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên của bản thuyết trình
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm biểu đồ cột nhóm mặc định
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Truy cập bộ sưu tập chuỗi biểu đồ
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Duyệt qua từng chuỗi biểu đồ
    for (IChartSeries ser : series) 
    {
        // Duyệt qua từng ô dữ liệu trong chuỗi
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Đặt định dạng số
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Lưu bản thuyết trình
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Các giá trị định dạng số sẵn có cùng với chỉ số preset của chúng và có thể sử dụng được nêu dưới đây:

|**0**|Chung|
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
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Đặt viền bo tròn cho khu vực biểu đồ**
Aspose.Slides for Java hỗ trợ việc đặt khu vực biểu đồ. Các phương thức [**hasRoundedCorners**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChart#hasRoundedCorners--) và [**setRoundedCorners**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) đã được thêm vào giao diện [IChart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChart) và lớp [Chart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Chart).

1. Tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Thêm biểu đồ vào slide.
3. Đặt loại và màu nền cho biểu đồ
4. Đặt thuộc tính góc bo tròn thành True.
5. Lưu bản thuyết trình đã chỉnh sửa.

Ví dụ mẫu dưới đây được đưa ra.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt màu nền bán trong suốt cho cột/vùng trong khi giữ viền không trong suốt không?**

Có. Độ trong suốt của màu nền và đường viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc của lưới và dữ liệu trong các biểu đồ cô đọng.

**Làm thế nào tôi có thể xử lý các nhãn dữ liệu khi chúng chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ: danh mục), đặt vị trí/độ dịch của nhãn, chỉ hiển thị nhãn cho các điểm đã chọn nếu cần, hoặc chuyển định dạng sang "giá trị + chú giải".

**Tôi có thể áp dụng màu nền gradient hoặc mẫu cho các chuỗi không?**

Có. Cả màu nền đặc và gradient/mẫu thường đều có sẵn. Trong thực tế, nên sử dụng gradient một cách tiết chế và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.