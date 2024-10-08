---
title: 图表格式化
type: docs
weight: 60
url: /zh/androidjava/chart-formatting/
---

## **格式化图表元素**
Aspose.Slides for Android via Java 允许开发者从头开始向幻灯片添加自定义图表。本文解释了如何格式化不同的图表元素，包括图表类别和数值轴。

Aspose.Slides for Android via Java 提供了一个简单的 API 来管理不同的图表元素并使用自定义值格式化它们：

1. 创建一个 [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表以及任何所需的类型（在本示例中，我们将使用 ChartType.LineWithMarkers）。
1. 访问图表的数值轴并设置以下属性：
   1. 设置数值轴主网格线的 **线格式**
   1. 设置数值轴次网格线的 **线格式**
   1. 设置数值轴的 **数字格式**
   1. 设置数值轴的 **最小、最大、主要和次要单位**
   1. 设置数值轴数据的 **文本属性**
   1. 设置数值轴的 **标题**
   1. 设置数值轴的 **线格式**
1. 访问图表的类别轴并设置以下属性：
   1. 设置类别轴主网格线的 **线格式**
   1. 设置类别轴次网格线的 **线格式**
   1. 设置类别轴数据的 **文本属性**
   1. 设置类别轴的 **标题**
   1. 设置类别轴的 **标签定位**
   1. 设置类别轴标签的 **旋转角度**
1. 访问图表的图例并设置它们的 **文本属性**
1. 设置图表图例在不重叠图表的情况下显示
1. 访问图表的 **辅助数值轴**并设置以下属性：
   1. 启用辅助 **数值轴**
   1. 设置辅助数值轴的 **线格式**
   1. 设置辅助数值轴的 **数字格式**
   1. 设置辅助数值轴的 **最小、最大、主要和次要单位**
1. 现在在辅助数值轴上绘制第一个图表系列
1. 设置图表后墙的填充颜色
1. 设置图表绘图区域的填充颜色
1. 将修改后的演示文稿写入 PPTX 文件

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加示例图表
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // 设置图表标题
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("示例图表");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 设置数值轴主网格线格式
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // 设置数值轴次网格线格式
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 设置数值轴数字格式
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // 设置图表最大、最小值
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // 设置数值轴文本属性
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // 设置数值轴标题
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("主轴");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 设置类别轴主网格线格式
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // 设置类别轴次网格线格式
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 设置类别轴文本属性
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // 设置类别标题
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("示例类别");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 设置类别轴标签位置
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // 设置类别轴标签旋转角度
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // 设置图例文本属性
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // 设置图表图例在不重叠图表的情况下显示

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // 设置辅助数值轴
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // 设置辅助数值轴数字格式
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // 设置图表最大、最小值
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // 设置图表后墙颜色
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // 设置绘图区域颜色
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // 保存演示文稿
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置图表字体属性**
Aspose.Slides for Android via Java 支持设置图表的字体相关属性。请按照以下步骤设置图表的字体属性。

- 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类对象。
- 在幻灯片上添加图表。
- 设置字体高度。
- 保存修改后的演示文稿。

以下是示例代码。

```java
// 创建 Presentation 类的实例
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

## **设置数字格式**
Aspose.Slides for Android via Java 提供了一个简单的 API 来管理图表数据格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表以及任何所需的类型（本示例使用 ChartType.ClusteredColumn）。
1. 从可能的预设值中设置预设数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置图表数据数字格式。
1. 保存演示文稿。
1. 设置自定义数字格式。
1. 在每个图表系列中遍历图表数据单元格并设置不同的图表数据数字格式。
1. 保存演示文稿。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 访问第一张演示文稿幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加默认的簇状柱形图
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // 访问图表系列集合
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // 遍历每个图表系列
    for (IChartSeries ser : series) 
    {
        // 遍历系列中的每个数据单元格
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // 设置数字格式
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // 保存演示文稿
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

可能的预设数字格式值及其预设索引如下：

|**0**|一般|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;红色$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;红色$-#,##0.00|
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
|**38**|#,##0;红色-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;红色-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **设置图表区域圆角**
Aspose.Slides for Android via Java 支持设置图表区域。方法 [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) 和 [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) 已添加到 [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) 接口和 [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart) 类。

1. 实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表的填充类型和填充颜色。
1. 设置圆角属性为 True。
1. 保存修改后的演示文稿。

以下是示例代码。

```java
// 创建 Presentation 类的实例
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