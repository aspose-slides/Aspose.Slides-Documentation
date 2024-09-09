---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Node.js via Java 14.10.0
type: docs
weight: 90
url: /nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) classes, methods, properties and so on, any new restrictions and other [changes](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introduced with the Aspose.Slides for Node.js via Java 14.10.0 API.

{{% /alert %}} 
## **Public API Changes**
### **aspose.slides.FieldType.getFooter() method has been added**
getFooter() method returns footer field type. It has been added for the implementation of the possibility to create fields of this type and for valid presentation serialization.
### **Element aspose.slides.ShapeElementFillSource.Own has been deleted**
Element ShapeElementFillSource.Own has been deleted as duplicated. Use ShapeElementFillSource.Shape instead of ShapeElementFillSource.Own.
### **Methods for chart data points, categories removing have been added**
**The following methods, which allow to remove chart data point from a chart data point collection have been added:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**The following method, which allows to remove a chart category from the containing collection has been added:**

IChartCategory.remove()

```javascript
    var pres = new  aspose.slides.Presentation();
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 400, true);
    chart.getChartData().getCategories().get_Item(0).remove();// remove with ChartCategory.remove()
    chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0));// remove with ChartCategoryCollection.remove()
    chart.getChartData().getSeries().forEach(function(ser) {
        ser.getDataPoints().get_Item(0).remove();// remove with ChartDataPoint.remove()
        ser.getDataPoints().remove(ser.getDataPoints().get_Item(0));// ChartDataPointCollection.remove()
    });
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
```
### **Obsolete Aspose.Slides.ParagraphFormat methods have been removed**
The methods getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() and corresponding set methods have been removed. They were marked as obsolete long time ago.
### **Un-useful and obsolete constructors have been removed**
The following constructors have been removed:

aspose.slides.AlphaBiLevel(float)
aspose.slides.AlphaModulateFixed(float)
aspose.slides.AlphaReplace(float)
aspose.slides.BiLevel(float)
aspose.slides.Blur(double, boolean)
aspose.slides.HSL(float, float, float)
aspose.slides.ImageTransformOperation(aspose.slides.ImageTransformOperationCollection)
aspose.slides.Luminance(float, float)
aspose.slides.Tint(float, float)
aspose.slides.PortionFormat(aspose.slides.ParagraphFormat)
aspose.slides.PortionFormat(aspose.slides.Portion)
aspose.slides.PortionFormat(aspose.slides.PortionFormat)
