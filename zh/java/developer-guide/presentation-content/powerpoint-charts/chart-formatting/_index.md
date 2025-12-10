---
title: 在 Java 中格式化演示文稿图表
linktitle: 图表格式化
type: docs
weight: 60
url: /zh/java/chart-formatting/
keywords:
- 格式化图表
- 图表格式化
- 图表实体
- 图表属性
- 图表设置
- 图表选项
- 字体属性
- 圆角边框
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解在 Aspose.Slides for Java 中的图表格式化，并通过专业、引人注目的样式提升您的 PowerPoint 演示文稿。"
---

## **图表实体的格式化**
Aspose.Slides for Java 让开发人员可以从头在幻灯片中添加自定义图表。本文介绍如何格式化不同的图表实体，包括图表的类别轴和数值轴。

Aspose.Slides for Java 提供了一个简易 API，用于管理不同的图表实体并使用自定义值进行格式化：

1. 创建 [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，并选择任意所需类型（本例中使用 ChartType.LineWithMarkers）。
1. 访问图表的数值轴并设置以下属性：
   1. 为数值轴主要网格线设置 **线条格式**
   1. 为数值轴次要网格线设置 **线条格式**
   1. 为数值轴设置 **数字格式**
   1. 为数值轴设置 **最小值、最大值、主要单位和次要单位**
   1. 为数值轴数据设置 **文本属性**
   1. 为数值轴设置 **标题**
   1. 为数值轴设置 **线条格式**
1. 访问图表的类别轴并设置以下属性：
   1. 为类别轴主要网格线设置 **线条格式**
   1. 为类别轴次要网格线设置 **线条格式**
   1. 为类别轴数据设置 **文本属性**
   1. 为类别轴设置 **标题**
   1. 为类别轴设置 **标签定位**
   1. 为类别轴标签设置 **旋转角度**
1. 访问图表图例并为其设置 **文本属性**
1. 设置显示图表图例且不与图表重叠
1. 访问图表的 **次要数值轴** 并设置以下属性：
   1. 启用次要 **数值轴**
   1. 为次要数值轴设置 **线条格式**
   1. 为次要数值轴设置 **数字格式**
   1. 为次要数值轴设置 **最小值、最大值、主要单位和次要单位**
1. 现在在次要数值轴上绘制第一个图表系列
1. 设置图表背板填充颜色
1. 设置图表绘图区域填充颜色
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
        chartTitle.setText("Sample Chart");
        chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
        chartTitle.getPortionFormat().setFontHeight(20);
        chartTitle.getPortionFormat().setFontBold(NullableBool.True);
        chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

        // 设置数值轴主要网格线的格式
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

        // 设置数值轴次要网格线的格式
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

        // 设置数值轴的数字格式
        chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
        chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
        chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

        // 设置图表的最大值和最小值
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
        valtitle.setText("Primary Axis");
        valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
        valtitle.getPortionFormat().setFontHeight(20);
        valtitle.getPortionFormat().setFontBold(NullableBool.True);
        valtitle.getPortionFormat().setFontItalic(NullableBool.True);

        // 设置类别轴主要网格线的格式
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

        // 设置类别轴次要网格线的格式
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
        catTitle.setText("Sample Category");
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

        // 设置显示图例而不与图表重叠

        chart.getLegend().setOverlay(true);
        // chart.ChartData.Series[0].PlotOnSecondAxis=true;

        chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
        // 设置次要数值轴
        chart.getAxes().getSecondaryVerticalAxis().isVisible();
        chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
        chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

        // 设置次要数值轴数字格式
        chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
        chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
        chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

        // 设置图表的最大值和最小值
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

        chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
        chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
        chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
        chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

        // 设置图表背板颜色
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


## **为图表设置字体属性**
Aspose.Slides for Java 提供了为图表设置字体相关属性的支持。请按照以下步骤为图表设置字体属性。

- 实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类对象。
- 在幻灯片上添加图表。
- 设置字体高度。
- 保存修改后的演示文稿。

下面给出示例代码。  
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
Aspose.Slides for Java 提供了一个用于管理图表数据格式的简易 API：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，并选择任意所需类型（本例使用 **ChartType.ClusteredColumn**）。
1. 从可用的预设值中设置预设数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置其数字格式。
1. 保存演示文稿。
1. 设置自定义数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置不同的数字格式。
1. 保存演示文稿。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 访问第一张演示文稿幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加默认的聚类柱形图
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


可用的预设数字格式值及其对应的索引如下所示：

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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **设置图表区域圆角边框**
Aspose.Slides for Java 提供了设置图表区域的支持。已在 [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) 接口和 [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart) 类中添加了方法 [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) 和 [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-)。

1. 实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表的填充类型和填充颜色
1. 将圆角属性设置为 True。
1. 保存修改后的演示文稿。

下面给出示例代码。  
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


## **常见问题**

**我可以为柱形/区域设置半透明填充，同时保持边框不透明吗？**

可以。填充透明度和轮廓是分别配置的。这对于在密集的可视化中提升网格和数据的可读性非常有用。

**当数据标签重叠时，我该如何处理？**

可以减小字体大小、禁用非必要的标签组件（例如类别），设置标签的偏移/位置，必要时仅为选定点显示标签，或将格式切换为 “值 + 图例”。

**我可以为系列应用渐变或图案填充吗？**

可以。通常可以使用纯色填充以及渐变/图案填充。实际使用时应适量使用渐变，并避免与网格和文字的对比度下降的组合。