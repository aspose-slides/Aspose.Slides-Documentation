---
title: 图表格式化
type: docs
weight: 60
url: /java/chart-formatting/
---

## **格式化图表实体**
Aspose.Slides for Java 允许开发人员从头开始将自定义图表添加到他们的幻灯片。本文解释了如何格式化不同的图表实体，包括图表分类轴和数值轴。

Aspose.Slides for Java 提供了一个简单的 API 用于管理不同的图表实体并使用自定义值进行格式化：

1. 创建[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需类型中的任何一个（在此示例中我们将使用 ChartType.LineWithMarkers）。
1. 访问图表的数值轴并设置以下属性：
   1. 设置数值轴主网格线的**线条格式**
   1. 设置数值轴次网格线的**线条格式**
   1. 设置数值轴的**数字格式**
   1. 设置数值轴的**最小值、最大值、主单位和次单位**
   1. 设置数值轴数据的**文本属性**
   1. 设置数值轴的**标题**
   1. 设置数值轴的**线条格式**
1. 访问图表的分类轴并设置以下属性：
   1. 设置分类轴主网格线的**线条格式**
   1. 设置分类轴次网格线的**线条格式**
   1. 设置分类轴数据的**文本属性**
   1. 设置分类轴的**标题**
   1. 设置分类轴的**标签定位**
   1. 设置分类轴标签的**旋转角度**
1. 访问图表的图例并设置其**文本属性**
1. 设置图表图例不重叠图表
1. 访问图表的**次数值轴**并设置以下属性：
   1. 启用次**数值轴**
   1. 设置次数值轴的**线条格式**
   1. 设置次数值轴的**数字格式**
   1. 设置次数值轴的**最小值、最大值、主单位和次单位**
1. 现在在次数值轴上绘制第一个图表系列
1. 设置图表后墙填充颜色
1. 设置图表绘图区填充颜色
1. 将修改后的演示文稿写入 PPTX 文件

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Accessing the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adding the sample chart
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Setting Chart Title
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("样例图表");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Setting Major grid lines format for value axis
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Setting Minor grid lines format for value axis
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Setting value axis number format
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Setting chart maximum, minimum values
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Setting Value Axis Text Properties
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Setting value axis title
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("主轴");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Setting Major grid lines format for Category axis
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Setting Minor grid lines format for Category axis
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Setting Category Axis Text Properties
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Setting Category Title
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("样例分类");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Setting category axis label position
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Setting category axis label rotation angle
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Setting Legends Text Properties
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Set show chart legends without overlapping chart

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Setting secondary value axis
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Setting secondary value axis Number format
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Setting chart maximum, minimum values
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Setting chart back wall color
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Setting Plot area color
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Save Presentation
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **为图表设置字体属性**
Aspose.Slides for Java 提供了设置图表字体相关属性的支持。请按照以下步骤为图表设置字体属性。

- 实例化[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类对象。
- 在幻灯片上添加图表。
- 设置字体高度。
- 保存修改后的演示文稿。

下面给出了样例示例。

```java
// Create an instance of Presentation class
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
Aspose.Slides for Java 提供了一个简单的 API 用于管理图表数据格式：

1. 创建[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需类型中的任何一个（本示例使用 **ChartType.ClusteredColumn**）。
1. 从可能的预设值中设置预设数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置图表数据数字格式。
1. 保存演示文稿。
1. 设置自定义数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置不同的图表数据数字格式。
1. 保存演示文稿。

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Access the first presentation slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adding a default clustered column chart
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Accessing the chart series collection
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Traverse through every chart series
    for (IChartSeries ser : series) 
    {
        // Traverse through every data cell in series
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Setting the number format
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Saving presentation
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

可以使用的可能的预设数字格式值及其预设索引如下：

|**0**|常规|
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
|**46**|h:mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **设置图表区域圆角**
Aspose.Slides for Java 提供了对设置图表区域的支持。方法 [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) 和 [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) 已添加到 [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) 接口和 [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart) 类。

1. 实例化[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类对象。
1. 在幻灯片上添加图表。
1. 设置图表的填充类型和填充颜色
1. 设置圆角属性为真。
1. 保存修改后的演示文稿。

下面给出了样例示例。

```java
// Create an instance of Presentation class
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