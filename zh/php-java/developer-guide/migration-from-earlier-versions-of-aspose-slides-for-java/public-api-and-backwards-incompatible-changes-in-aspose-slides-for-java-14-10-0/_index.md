---
title: Aspose.Slides for PHP via Java 14.10.0 的公共 API 和不兼容更改
type: docs
weight: 90
url: /zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for PHP via Java 14.10.0 API 中[新增](/slides/zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)的类、方法、属性等，任何新的限制以及其他[更改](/slides/zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)。

{{% /alert %}} 
## **公共 API 更改**
### **添加了 com.aspose.slides.FieldType::getFooter() 方法**
getFooter() 方法返回页脚字段类型。它是为了实现创建此类型字段的可能性以及有效的演示文稿序列化而添加的。
### **元素 com.aspose.slides.ShapeElementFillSource.Own 已被删除**
元素 ShapeElementFillSource.Own 已被删除，因其为重复项。请使用 ShapeElementFillSource.Shape 代替 ShapeElementFillSource.Own。
### **添加了用于删除图表数据点和类别的方法**
**已添加以下方法，用于从图表数据点集合中删除图表数据点：**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()

**已添加以下方法，用于从包含的集合中删除图表类别：**

IChartCategory.remove()

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 400, true);
  $chart->getChartData()->getCategories()->get_Item(0)->remove();// 使用 ChartCategory.remove() 删除

  $chart->getChartData()->getCategories()->remove($chart->getChartData()->getCategories()->get_Item(0));// 使用 ChartCategoryCollection.remove() 删除

  foreach($chart->getChartData()->getSeries() as $ser) {
    $ser->getDataPoints()->get_Item(0)->remove();// 使用 ChartDataPoint.remove() 删除

    $ser->getDataPoints()->remove($ser->getDataPoints()->get_Item(0));// ChartDataPointCollection.remove()

  }
  $pres->save("presentation.pptx", SaveFormat::Pptx);

```
### **已删除不再使用的 Aspose.Slides.ParagraphFormat 方法**
方法 getBulletChar()、getBulletColor()、getBulletColorFormat()、getBulletFont()、getBulletHeight()、getBulletType()、isBulletHardColor()、isBulletHardFont()、getNumberedBulletStartWith()、getNumberedBulletStyle() 及相应的设置方法已被删除。这些方法早已标记为过时。
### **已删除不必要和过时的构造函数**
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