---
title: Aspose.Slides for Java 14.10.0 的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审查 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 
此页面列出所有[已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) 类、方法、属性等，以及在 Aspose.Slides for Java 14.10.0 API 中引入的任何新限制和其他[更改](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)。
{{% /alert %}} 
## **Public API Changes**
### **com.aspose.slides.FieldType.getFooter() method has been added**
getFooter() 方法返回页脚字段类型。添加此方法是为了实现创建此类型字段的可能性并支持有效的演示文稿序列化。
### **Element com.aspose.slides.ShapeElementFillSource.Own has been deleted**
元素 ShapeElementFillSource.Own 被删除，因为它是重复的。请改用 ShapeElementFillSource.Shape 而不是 ShapeElementFillSource.Own。
### **Methods for chart data points, categories removing have been added**
**已添加以下方法，可从图表数据点集合中移除图表数据点：**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**已添加以下方法，可从所属集合中移除图表类别：**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // 使用 ChartCategory.remove() 删除

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // 使用 ChartCategoryCollection.remove() 删除

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // 使用 ChartDataPoint.remove() 删除

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Obsolete Aspose.Slides.ParagraphFormat methods have been removed**
已删除 getBulletChar()、getBulletColor()、getBulletColorFormat()、getBulletFont()、getBulletHeight()、getBulletType()、isBulletHardColor()、isBulletHardFont()、getNumberedBulletStartWith()、getNumberedBulletStyle() 以及相应的 set 方法。这些方法早已标记为过时。
### **Un-useful and obsolete constructors have been removed**
已删除以下构造函数：

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)