---
title: Aspose.Slides for Java 15.2.0 中的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出所有 [added](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) 类、方法、属性等，任何新的限制以及其他 [changes](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) 已随 Aspose.Slides for Java 15.2.0 API 引入。

{{% /alert %}} {{% alert color="info" %}} 

已知某些图像项目符号和 WordArt 对象存在问题，这些问题将在 Aspose.Slides for Java 15.2.0 中修复。

{{% /alert %}} 
## **公共 API 更改**
### **已添加 addDataPointForDoughnutSeries 方法**
已添加 IChartDataPointCollection.addDataPointForDoughnutSeries() 方法的两个重载，以向 Doughnut 类型的系列中添加数据点。
### **com.aspose.slides.SmartArtShape 类已从 com.aspose.slides.GeometryShape 类继承**
com.aspose.slides.SmartArtShape 类已从 com.aspose.slides.GeometryShape 类继承。此更改改进了 Aspose.Slides 对象模型，并为 SmartArtShape 类添加了新功能。
### **IGradientStopCollection.add(...) 与 IGradientStopCollection.insert(...) 方法已更改**
IGradientStop add(float position, int presetColor) 的签名已替换为 IGradientStop addPresetColor(float position, int presetColor) 签名。
IGradientStopCollection 方法 IGradientStop add(float position, SchemeColor schemeColor) 的签名已替换为 IGradientStop addSchemeColor(float position, int schemeColor) 签名。
IGradientStopCollection 方法 void insert(int index, float position, int presetColor) 的签名已替换为 void insertPresetColor(int index, float position, int presetColor) 签名。
IGradientStopCollection 方法 void insert(int index, float position, SchemeColor schemeColor) 的签名已替换为 void insertSchemeColor(int index, float position, int schemeColor) 签名。
### **已在 com.aspose.slides.IChartSeries 中添加 java.awt.Color getAutomaticSeriesColor() 方法**
getAutomaticSeriesColor() 方法根据系列索引和图表样式返回系列的自动颜色。如果 FillType 等于 NotDefined，则默认使用此颜色。
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **已添加按索引删除图表数据点和图表类别的方法**
已添加 IChartDataPointCollection.removeAt(int index) 方法，用于按索引删除图表数据点。
已添加 IChartCategoryCollection.removeAt(int index) 方法，用于按索引删除图表类别。
### **已在 com.aspose.slides.PropertyType 枚举中添加 PptXPptY 值**
已在 com.aspose.slides.PropertyType 枚举中添加 PptXPptY 值，以解决序列化问题。