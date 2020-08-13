---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0-html/) or [removed](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0-html/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for Java 15.7.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Enum com.aspose.slides.ImagePixelFormat has been added**
Enum com.aspose.slides.ImagePixelFormat has been added for specifying pixel format for the generated images.
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() method has been added**
This method returns an automatic color of data point based on series index, data point index, parentSeriesGroup, isColorVaried values and chart style. This color is used by default if fillType equals NotDefined.
#### **Methods getPixelFormat(), setPixelFormat(int) have been added to com.aspose.slides.ITiffOptions**
Methods getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) have been added to com.aspose.slides.ITiffOptions and com.aspose.slides.TiffOptions for specifying pixel format for the generated TIFF images.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```
