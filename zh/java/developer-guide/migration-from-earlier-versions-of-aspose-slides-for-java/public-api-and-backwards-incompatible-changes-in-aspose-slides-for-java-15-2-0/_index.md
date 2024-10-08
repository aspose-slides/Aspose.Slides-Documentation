---
title: Aspose.Slides for Java 15.2.0中的公共API和向后不兼容的更改
type: docs
weight: 110
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在Aspose.Slides for Java 15.2.0 API中新增的[class](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)类、方法、属性等、任何新的限制以及其他[变化](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)。

{{% /alert %}} {{% alert color="primary" %}} 

已知某些图像项目符号和WordArt对象存在问题，这将在Aspose.Slides for Java 15.2.0中修复。

{{% /alert %}} 
## **公共API更改**
### **添加了addDataPointForDoughnutSeries方法**
为将数据点添加到甜甜圈类型系列中，添加了IChartDataPointCollection.addDataPointForDoughnutSeries()方法的两个重载。
### **com.aspose.slides.SmartArtShape类已从com.aspose.slides.GeometryShape类继承**
com.aspose.slides.SmartArtShape类已从com.aspose.slides.GeometryShape类继承。此更改改善了Aspose.Slides对象模型，并为SmartArtShape类添加了新功能。
### **IGradientStopCollection.add(...)和IGradientStopCollection.insert(...)方法已更改**
IGradientStop add(float position, int presetColor)的签名已替换为IGradientStop addPresetColor(float position, int presetColor)签名。

IGradientStopCollection方法IGradientStop add(float position, SchemeColor schemeColor)的签名已替换为IGradientStop addSchemeColor(float position, int schemeColor)签名。

IGradientStopCollection方法void insert(int index, float position, int presetColor)的签名已替换为void insertPresetColor(int index, float position, int presetColor)签名。

IGradientStopCollection方法void insert(int index, float position, SchemeColor schemeColor)的签名已替换为void insertSchemeColor(int index, float position, int schemeColor)签名。
### **java.awt.Color getAutomaticSeriesColor()方法已添加到com.aspose.slides.IChartSeries**
getAutomaticSeriesColor()方法返回基于系列索引和图表样式的系列自动颜色。如果FillType等于NotDefined，则默认使用此颜色。
﻿

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **添加了通过索引移除图表数据点和图表类别的方法**
为通过索引移除图表数据点，添加了IChartDataPointCollection.removeAt(int index)方法。
为通过索引移除图表类别，添加了IChartCategoryCollection.removeAt(int index)方法。
### **PptXPptY值已添加到com.aspose.slides.PropertyType枚举中**
在序列化问题修复的范围内，PptXPptY值已添加到com.aspose.slides.PropertyType枚举中。