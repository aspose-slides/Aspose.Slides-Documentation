---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 15.11.0
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 15.11.0 API.

{{% /alert %}} 
## **Public API Changes**

#### **Obsolete properties in DataLabelCollection class have been deleted**
Obsolete properties in DataLabelCollection class have been deleted:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **The new property FirstSlideNumber has been added to the Presentation class**
The new property FirstSlideNumber added to Presentation allows to get or to set the number of first slide in a presentation.

When a new FirstSlideNumber value is specified all slide numbers are recalculated.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

``` 
