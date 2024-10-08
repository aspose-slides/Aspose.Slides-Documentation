---
title: Aspose.Slides for Java 15.2.0 中的公共 API 和不向后兼容的更改
type: docs
weight: 110
url: /zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

本页面列出了 Aspose.Slides for Java 15.2.0 API 中所有[添加的](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)类、方法、属性等，以及任何新限制和其他[更改](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)。

{{% /alert %}} {{% alert color="primary" %}} 

已知某些图像项目符号和 WordArt 对象存在问题，这些问题将在 Aspose.Slides for Java 15.2.0 中修复。

{{% /alert %}} 
## **公共 API 更改**
### **新增 addDataPointForDoughnutSeries 方法**
新增了两个 IChartDataPointCollection.addDataPointForDoughnutSeries() 方法的重载，用于向甜甜圈类型的系列中添加数据点。
### **com.aspose.slides.SmartArtShape 类已从 com.aspose.slides.GeometryShape 类继承**
com.aspose.slides.SmartArtShape 类已从 com.aspose.slides.GeometryShape 类继承。此更改改善了 Aspose.Slides 对象模型，并为 SmartArtShape 类添加了新功能。
### **IGradientStopCollection.add(...) 和 IGradientStopCollection.insert(...) 方法已更改**
IGradientStop 的签名 add(float position, int presetColor) 被替换为 IGradientStop addPresetColor(float position, int presetColor) 的签名。

IGradientStopCollection 方法 IGradientStop add(float position, SchemeColor schemeColor) 的签名被替换为 IGradientStop addSchemeColor(float position, int schemeColor) 的签名。

IGradientStopCollection 方法 void insert(int index, float position, int presetColor) 的签名被替换为 void insertPresetColor(int index, float position, int presetColor) 的签名。

IGradientStopCollection 方法 void insert(int index, float position, SchemeColor schemeColor) 的签名被替换为 void insertSchemeColor(int index, float position, int schemeColor) 的签名。
### **java.awt.Color getAutomaticSeriesColor() 方法已添加到 com.aspose.slides.IChartSeries**
getAutomaticSeriesColor() 方法根据系列索引和图表样式返回系列的自动颜色。如果 FillType 等于 NotDefined，则默认使用此颜色。
﻿

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **已添加通过索引删除图表数据点和图表类别的方法**
IChartDataPointCollection.removeAt(int index) 方法已添加，用于通过索引删除图表数据点。
IChartCategoryCollection.removeAt(int index) 方法已添加，用于通过索引删除图表类别。
### **在 com.aspose.slides.PropertyType 枚举中已添加 PptXPptY 值**
在序列化问题修复的范围内，已在 com.aspose.slides.PropertyType 枚举中添加 PptXPptY 值。