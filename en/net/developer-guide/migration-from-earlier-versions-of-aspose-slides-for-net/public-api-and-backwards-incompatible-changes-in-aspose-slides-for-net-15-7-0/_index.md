---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 15.7.0
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- migration
- legacy code
- modern code
- legacy approach
- modern approach
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Review public API updates and breaking changes in Aspose.Slides for .NET to smoothly migrate your PowerPoint PPT, PPTX and ODP presentation solutions."
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 15.7.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Enum ImagePixelFormat Has Been Added**
Enum Aspose.Slides.Export.ImagePixelFormat has been added for specifying pixel format for the generated images.
#### **IChartDataPoint.GetAutomaticDataPointColor() Method Has Been Added**
Returns an automatic color of data point based on series index, data point index, ParentSeriesGroup, IsColorVaried propery and chart style.
This color is used by default if FillType equals NotDefined.
#### **Method RenderToGraphics Has Been Added to Slide**
Method RenderToGraphics (and it's overloads) has been added to Aspose.Slides.Slide for rendering a slide to Graphics object.
#### **Property PixelFormat Has Been Added to ITiffOptions and TiffOptions**
Property PixelFormat has been added to Aspose.Slides.Export.ITiffOptions and Aspose.Slides.Export.TiffOptions for specifying pixel format for the generated TIFF images.
