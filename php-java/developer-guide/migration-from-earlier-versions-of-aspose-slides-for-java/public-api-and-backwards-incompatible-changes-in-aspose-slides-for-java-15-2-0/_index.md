---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for PHP via Java 15.2.0
type: docs
weight: 110
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) classes, methods, properties and so on, any new restrictions and other [changes](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) introduced with the Aspose.Slides for PHP via Java 15.2.0 API.

{{% /alert %}} {{% alert color="primary" %}} 

There are known issues with some image bullets and WordArt objects which will be fixed in Aspose.Slides for PHP via Java 15.2.0.

{{% /alert %}} 
## **Public API Changes**
### **addDataPointForDoughnutSeries methods have been added**
The two overloads of IChartDataPointCollection.addDataPointForDoughnutSeries() method have been added for adding data points into series of Doughnut type.
### **com.aspose.slides.SmartArtShape class has been inherited from com.aspose.slides.GeometryShape class**
com.aspose.slides.SmartArtShape class has been inherited from com.aspose.slides.GeometryShape class. This change improves Aspose.Slides object model and adds new features to SmartArtShape class.
### **IGradientStopCollection.add(...) and IGradientStopCollection.insert(...) methods have been changed**
The signature of IGradientStop add(float position, int presetColor) is replaced with IGradientStop addPresetColor(float position, int presetColor) signature.

The signature of IGradientStopCollection method IGradientStop add(float position, SchemeColor schemeColor) is replaced with IGradientStop addSchemeColor(float position, int schemeColor) signature.

The signature of the IGradientStopCollection method void insert(int index, float position, int presetColor) is replaced with void insertPresetColor(int index, float position, int presetColor) signature.

The signature of the IGradientStopCollection method void insert(int index, float position, SchemeColor schemeColor) is replaced with void insertSchemeColor(int index, float position, int schemeColor) signature.
### **java.awt.Color getAutomaticSeriesColor() method has been added to com.aspose.slides.IChartSeries**
getAutomaticSeriesColor() method returns an automatic color of series based on series index and chart style. This color is used by default if FillType equals NotDefined.
﻿

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
  for ($i = 0; $i < $chart->getChartData()->getSeries()->size(); $i++) {
    $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
  }

```
### **Method for removing chart data point and chart category by its index has been added**
IChartDataPointCollection.removeAt(int index) method has been added for removing chart data point by its index.
IChartCategoryCollection.removeAt(int index) method has been added for removing chart category by its index.
### **PptXPptY value has been added to com.aspose.slides.PropertyType enumeration**
PptXPptY value has been added to com.aspose.slides.PropertyType enumeration in the scope of a serialization issue fix.
