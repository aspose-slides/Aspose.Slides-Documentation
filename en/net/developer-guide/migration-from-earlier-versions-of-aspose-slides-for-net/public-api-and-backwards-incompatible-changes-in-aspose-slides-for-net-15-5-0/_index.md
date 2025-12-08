---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 15.5.0
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
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

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 15.5.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **CommonSlideViewProperties Class and ICommonSlideViewProperties Interface Have Been Added**
The Aspose.Slides.CommonSlideViewProperties class and Aspose.Slides.ICommonSlideViewProperties interface respresent common slide view properties (currently view scale options).
#### **IAxis.LabelOffset Property Has Been Added**
IAxis.LabelOffset property specifies the distance of labels from the axis. Applied to category or date axis.
#### **IChartTextBlockFormat.AutofitType Property Has Been Added**
Changing of this property can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
#### **IChartTextBlockFormat.WrapText Property Has Been Added**
Changing of this property can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2007/2013).
#### **Margin Properties Have Been Added to IChartTextBlockFormat**
Changing of this properties can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
#### **ViewProperties.NotesViewProperties Property Has Been Added**
Aspose.Slides.ViewProperties.NotesViewProperties property has been added. Its specifies common view properties associated with the notes view mode.
#### **ViewProperties.SlideViewProperties Property Has Been Added**
Aspose.Slides.ViewProperties.SlideViewProperties property has been added. Its specifies common view properties associated with the slide view mode.
