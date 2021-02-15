---
title: Aspose.Slides for .NET 21.2 Release Notes
type: docs
weight: 50
url: /net/aspose-slides-for-net-21-2-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for .NET 21.2](https://www.nuget.org/packages/Aspose.Slides.NET/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESNET-42222|Characters seems thicker in png images converted in the environment Docker + Linux|Investigation|
|SLIDESNET-41073|(C#/.Net Core) Creating Presentations in AWS Lambda environment does not work (libdl missing)|Investigation|
|SLIDESNET-42348|Saving PPTX as PDF does not retain accessibility features|Feature|
|SLIDESNET-42329|Improper image rendering using Aspose.Slides|Enhancement|
|SLIDESNET-41752|How get/update end points of shape|Enhancement|
|SLIDESNET-42410|ArgumentException: An element with the same key already exists|Bug|
|SLIDESNET-42405|Aspose.Slides color shift when saving to PDF|Bug|
|SLIDESNET-42388|ArgumentException on generating slide thumbnail|Bug|
|SLIDESNET-42378|Stack overflow when saving presentation with charts|Bug|
|SLIDESNET-42376|SVG added to slide is not displayed correctly|Bug|
|SLIDESNET-42364|The surrogate pair (0xD83D, 0xD83D) is invalid. A high surrogate character (0xD800 - 0xDBFF) must always be paired with a low surrogate character (0xDC00 - 0xDFFF).|Bug|
|SLIDESNET-42362|"Object reference not set to an instance of an object." exception when open document PPTX file|Bug|
|SLIDESNET-42361|"Error reading adjustment value: connsiteX0 = "*/ 0 w 8286"" exception when open document PPTX file|Bug|
|SLIDESNET-42353|Specified Font is not embedded in an output HTML document.|Bug|
|SLIDESNET-42337|Unknown Wingding char in list bullet format|Bug|
|SLIDESNET-42296|GetThumbnail with BottomTruncated option fails on Linux|Bug|
|SLIDESNET-42206|3D-rotated object background-color is lost in the output HTML|Bug|
|SLIDESNET-42115|Aspose blocks fonts resources|Bug|
|SLIDESNET-42035|Created time is not correctly set in document properties|Bug|
|SLIDESNET-41561|PptxReadException on using NetStandard with 4.7|Bug|
|SLIDESNET-40863|Exception on loading ppt|Bug|

## **Public API Changes**

### **Obsolete methods have been removed** ###

**IShapeCollection.AddOleObjectFrame(float x, float y, float width, float height, string className, byte[] objectData)** has been removed. Use **AddOleObjectFrame(float x, float y, float width, float height, IOleEmbeddedDataInfo dataInfo)** method instead.
**IShapeCollection.InsertOleObjectFrame(int index, float x, float y, float width, float height, string className, byte[] objectData)** has been removed. Use **InsertOleObjectFrame(int index, float x, float y, float width, float height, IOleEmbeddedDataInfo dataInfo)** method instead.

**ShapeCollection.AddOleObjectFrame(float x, float y, float width, float height, string className, byte[] objectData)** has been removed. Use **AddOleObjectFrame(float x, float y, float width, float height, IOleEmbeddedDataInfo dataInfo)** method instead.
**ShapeCollection.InsertOleObjectFrame(int index, float x, float y, float width, float height, string className, byte[] objectData)** has been removed. Use **InsertOleObjectFrame(int index, float x, float y, float width, float height, IOleEmbeddedDataInfo dataInfo)** method instead.
