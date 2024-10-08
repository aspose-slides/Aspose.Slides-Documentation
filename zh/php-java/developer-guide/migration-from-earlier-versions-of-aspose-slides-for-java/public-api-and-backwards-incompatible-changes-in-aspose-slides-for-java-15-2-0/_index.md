---
title: Aspose.Slides for PHP via Java 15.2.0 的公共 API 和向后不兼容的更改
type: docs
weight: 110
url: /zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

本页面列出了所有 [添加的](/slides/zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) 类、方法、属性等，以及与 Aspose.Slides for PHP via Java 15.2.0 API 相关的任何新限制和其他 [更改](/slides/zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)。

{{% /alert %}} {{% alert color="primary" %}} 

已知某些图像项目符号和 WordArt 对象存在问题，将在 Aspose.Slides for PHP via Java 15.2.0 中修复。

{{% /alert %}} 
## **公共 API 更改**
### **新增 addDataPointForDoughnutSeries 方法**
为将数据点添加到环形图系列中新增了 IChartDataPointCollection.addDataPointForDoughnutSeries() 方法的两个重载。
### **com.aspose.slides.SmartArtShape 类已从 com.aspose.slides.GeometryShape 类继承**
com.aspose.slides.SmartArtShape 类已从 com.aspose.slides.GeometryShape 类继承。此更改改善了 Aspose.Slides 对象模型，并为 SmartArtShape 类添加了新功能。
### **IGradientStopCollection.add(...) 和 IGradientStopCollection.insert(...) 方法已更改**
IGradientStop add(float position, int presetColor) 的签名已被 IGradientStop addPresetColor(float position, int presetColor) 签名替代。

IGradientStopCollection 方法 IGradientStop add(float position, SchemeColor schemeColor) 的签名已被 IGradientStop addSchemeColor(float position, int schemeColor) 签名替代。

IGradientStopCollection 方法 void insert(int index, float position, int presetColor) 的签名已被 void insertPresetColor(int index, float position, int presetColor) 签名替代。

IGradientStopCollection 方法 void insert(int index, float position, SchemeColor schemeColor) 的签名已被 void insertSchemeColor(int index, float position, int schemeColor) 签名替代。
### **java.awt.Color getAutomaticSeriesColor() 方法已添加到 com.aspose.slides.IChartSeries**
getAutomaticSeriesColor() 方法根据系列索引和图表样式返回系列的自动颜色。如果 FillType 等于 NotDefined，则默认使用此颜色。
﻿

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
  for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
    $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
  }
```
### **已添加通过索引移除图表数据点和图表类别的方法**
已添加 IChartDataPointCollection.removeAt(int index) 方法以通过索引移除图表数据点。
已添加 IChartCategoryCollection.removeAt(int index) 方法以通过索引移除图表类别。
### **PptXPptY 值已添加到 com.aspose.slides.PropertyType 枚举**
PptXPptY 值已添加到 com.aspose.slides.PropertyType 枚举，以解决序列化问题。