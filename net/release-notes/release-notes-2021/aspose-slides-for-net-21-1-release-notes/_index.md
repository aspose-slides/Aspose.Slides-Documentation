---
title: Aspose.Slides for .NET 21.1 Release Notes
type: docs
weight: 60
url: /net/aspose-slides-for-net-21-1-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [ Aspose.Slides for .NET 21.1](https://www.nuget.org/packages/Aspose.Slides.NET/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESNET-42347|Missing libgdiplus library when using Aspose.Slides on Linux|Investigation|
|SLIDESNET-42306|Possible memory leak investigation in API|Investigation|
|SLIDESNET-42166|High memory/time consumption when saving a presentation|Investigation|
|SLIDESNET-36994|Support for Edit shape points|Feature|
|SLIDESNET-42333|Repair message after cloning attached (unrepairable on larger files)|Bug|
|SLIDESNET-42332|PptUnsupportedFormatException on loading presentation|Bug|
|SLIDESNET-42324|SVG shape added to Slide have the incorrect size|Bug|
|SLIDESNET-42321|IndexOutOfRangeException while invoking CreateShapeElements method|Bug|
|SLIDESNET-42318|Issue while showing page number on slide|Bug|
|SLIDESNET-42301|VectorizeText option does not work in Linux|Bug|
|SLIDESNET-42295|Aspose.Slides giving true for two unequal layout slides|Bug|
|SLIDESNET-42242|PPTX to PNG conversion: Some images lose rotation in the output|Bug|
|SLIDESNET-42221|Export to image has bad formatting|Bug|
|SLIDESNET-42219|Incorrect rendering of transparent PNG when converting PPTX to PDF/A-1b|Bug|
|SLIDESNET-42104|Font weight not set on Linux|Bug|
|SLIDESNET-41691|Not defined CSS class in the output HTML|Bug|
|SLIDESNET-40686|High memory consumption while loading and saving pptx|Bug|
|SLIDESNET-40073|Text spacing differs from PPTX to PDF|Bug|

## **Public API Changes**

### **Support of the shape points editing has been added** ###

Support of the shape points editing has been added. New classes, interfaces, enums, and **GeometryShape **methods have been added.

**New classes:**
- PathSegment
- GeometryPath
- ShapeUtil

**New interfaces:**
- IPathSegment
- IGeometryPath

**New enums:**
- PathFillModeType
- PathCommandType

**Public methods have been added to the GeometryShape class and its descendants:**  
- IGeometryPath[] GetGeometryPaths()
- void SetGeometryPath(IGeometryPath geometryPath)
- void SetGeometryPaths(IGeometryPath[] geometryPaths)

#### **Feature description:** ####

Customization of the shape geometry assumes editing points of an existing shape. 

To provide the mentioned functionality GeometryPath class and IGeometryPath interface have been added. GeometryPath instance represents a geometry path of the IGeometryShape object. 

To retrieve GeometryPath from the IGeometryShape instance IGeometryShape.GetGeometryPaths method has been added. Please note that shapes may be built from a few smaller shapes (e.g. an "equal" sign) so this method returns an array of IGeometryPath objects. 

To set GeometryPath to the shape has been added two methods: 
IGeometryShape.SetGeometryPath(IGeometryPath geometryPath) for solid shapes and SetGeometryPaths(IGeometryPath[] geometryPaths) for composite shapes.
