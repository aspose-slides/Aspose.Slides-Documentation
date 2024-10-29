---
title: Aspose.Slides for Java 14.10.0 的公共 API 和不兼容的更改
type: docs
weight: 90
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 14.10.0 API 中[添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)的类、方法、属性等，以及任何新限制和其他[更改](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)。

{{% /alert %}} 
## **公共 API 更改**
### **已添加 com.aspose.slides.FieldType.getFooter() 方法**
getFooter() 方法返回页脚字段类型。它的添加是为了实现创建此类型字段的功能以及有效的演示文稿序列化。
### **元素 com.aspose.slides.ShapeElementFillSource.Own 已被删除**
元素 ShapeElementFillSource.Own 已被删除，因为它是重复的。请使用 ShapeElementFillSource.Shape 代替 ShapeElementFillSource.Own。
### **已添加图表数据点、类别删除的方法**
**以下方法允许从图表数据点集合中删除图表数据点：**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()

**以下方法允许从包含集合中删除图表类别：**

IChartCategory.remove()

``` java

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
### **过时的 Aspose.Slides.ParagraphFormat 方法已被删除**
方法 getBulletChar()、getBulletColor()、getBulletColorFormat()、getBulletFont()、getBulletHeight()、getBulletType()、isBulletHardColor()、isBulletHardFont()、getNumberedBulletStartWith()、getNumberedBulletStyle() 和相应的设置方法已被删除。它们早已被标记为过时。
### **已删除无用和过时的构造函数**
以下构造函数已被删除：

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