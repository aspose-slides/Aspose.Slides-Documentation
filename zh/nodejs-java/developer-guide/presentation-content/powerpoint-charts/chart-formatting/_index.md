---
title: 图表格式化
type: docs
weight: 60
url: /zh/nodejs-java/chart-formatting/
---

## **格式化图表实体**

Aspose.Slides for Node.js via Java 让开发人员能够从头开始向幻灯片添加自定义图表。本文介绍如何格式化不同的图表实体，包括图表类别轴和数值轴。

Aspose.Slides for Node.js via Java 提供了一个简单的 API，用于管理不同的图表实体并使用自定义值进行格式化：

1. 创建 [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，并指定所需的类型（在本例中我们将使用 ChartType.LineWithMarkers）。
1. 访问图表的数值轴并设置以下属性：
   1. 为数值轴主网格线设置 **Line format**
   1. 为数值轴次网格线设置 **Line format**
   1. 为数值轴设置 **Number Format**
   1. 为数值轴设置 **Min, Max, Major and Minor units**
   1. 为数值轴数据设置 **Text Properties**
   1. 为数值轴设置 **Title**
   1. 为数值轴设置 **Line Format**
1. 访问图表的类别轴并设置以下属性：
   1. 为类别轴主网格线设置 **Line format**
   1. 为类别轴次网格线设置 **Line format**
   1. 为类别轴数据设置 **Text Properties**
   1. 为类别轴设置 **Title**
   1. 为类别轴设置 **Label Positioning**
   1. 为类别轴标签设置 **Rotation Angle**
1. 访问图表的图例并为其设置 **Text Properties**
1. 设置显示图表图例而不与图表重叠
1. 访问图表的 **Secondary Value Axis** 并设置以下属性：
   1. 启用辅助 **Value Axis**
   1. 为辅助数值轴设置 **Line Format**
   1. 为辅助数值轴设置 **Number Format**
   1. 为辅助数值轴设置 **Min, Max, Major and Minor units**
1. 现在在辅助数值轴上绘制第一条图表系列
1. 设置图表背墙的填充颜色
1. 设置图表绘图区域的填充颜色
1. 将修改后的演示文稿写入 PPTX 文件
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加示例图表
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // 设置图表标题
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 为数值轴设置主网格线格式
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // 为数值轴设置次网格线格式
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // 设置数值轴数字格式
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // 设置图表的最大、最小值
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // 设置数值轴文本属性
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // 设置数值轴标题
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 为类别轴设置主网格线格式
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // 为类别轴设置次网格线格式
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // 设置类别轴文本属性
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // 设置类别标题
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 设置类别轴标签位置
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // 设置类别轴标签旋转角度
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // 设置图例文本属性
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // 设置显示图例而不与图表重叠
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // 设置次要数值轴
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // 设置次要数值轴数字格式
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // 设置图表的最大、最小值
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // 设置图表背墙颜色
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 设置绘图区域颜色
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // 保存演示文稿
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **为图表设置字体属性**

Aspose.Slides for Node.js via Java 提供了对图表字体相关属性的设置支持。请按照以下步骤为图表设置字体属性。

- 实例化 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类对象。
- 在幻灯片上添加图表。
- 设置字体高度。
- 保存修改后的演示文稿。

下面给出示例。
```javascript
// 创建 Presentation 类的实例
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


## **设置数值格式**

Aspose.Slides for Node.js via Java 提供了一个简单的 API，用于管理图表数据格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，并指定所需的类型（本例使用 **ChartType.ClusteredColumn**）。
1. 从可能的预设值中设置预设数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置图表数据数字格式。
1. 保存演示文稿。
1. 设置自定义数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置不同的图表数据数字格式。
1. 保存演示文稿。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加默认的簇状柱形图
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // 访问图表系列集合
    var series = chart.getChartData().getSeries();
    // 遍历每个图表系列
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // 遍历系列中的每个数据单元格
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // 设置数字格式
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // 保存演示文稿
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


下面给出可能的预设数字格式值及其对应的预设索引，可供使用：

|**0**|常规|
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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **设置图表区域圆角边框**

Aspose.Slides for Node.js via Java 提供了对设置图表区域的支持。已在 [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart) 类中添加了方法 [**hasRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) 和 [**setRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-)。

1. 实例化 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表的填充类型和填充颜色
1. 将圆角属性设为 True。
1. 保存修改后的演示文稿。

下面给出示例。  
```javascript
// 创建 Presentation 类的实例
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


## **常见问题**

**我能为柱形/区域设置半透明填充，同时保持边框不透明吗？**

是的。填充透明度和轮廓是分别配置的。这有助于在密集的可视化中提高网格和数据的可读性。

**当数据标签重叠时，我该如何处理？**

可以减小字体大小，禁用非必需的标签组件（例如类别），设置标签的偏移/位置，必要时仅对选定的数据点显示标签，或将格式切换为“数值 + 图例”。

**我能为系列应用渐变或图案填充吗？**

可以。通常同时支持纯色填充和渐变/图案填充。实际使用时应适度使用渐变，并避免与网格和文字的对比度降低的组合。