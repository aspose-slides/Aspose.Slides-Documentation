---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Node.js via Java 15.7.0
type: docs
weight: 150
url: /nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) or [removed](/slides/nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for Node.js via Java 15.7.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Enum aspose.slides.ImagePixelFormat has been added**
Enum aspose.slides.ImagePixelFormat has been added for specifying pixel format for the generated images.
#### **aspose.slides.IChartDataPoint.getAutomaticDataPointColor() method has been added**
This method returns an automatic color of data point based on series index, data point index, parentSeriesGroup, isColorVaried values and chart style. This color is used by default if fillType equals NotDefined.
#### **Methods getPixelFormat(), setPixelFormat(int) have been added to aspose.slides.ITiffOptions**
Methods getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) have been added to aspose.slides.ITiffOptions and aspose.slides.TiffOptions for specifying pixel format for the generated TIFF images.

```javascript
    var pres = new  aspose.slides.Presentation("demo.pptx");
    var options = new  aspose.slides.TiffOptions();
    options.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    pres.save("demo-out.tiff", aspose.slides.SaveFormat.Tiff, options);
```
