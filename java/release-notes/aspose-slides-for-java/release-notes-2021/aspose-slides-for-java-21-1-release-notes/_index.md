---
title: Aspose.Slides for Java 21.1 Release Notes
type: docs
weight: 120
url: /java/aspose-slides-for-java-21-1-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for Java 21.1](https://repository.aspose.com/repo/com/aspose/aspose-slides/21.1/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESNET-36994|Support for Edit shape points|Feature|
|SLIDESJAVA-38357|Aspose.Slides giving true for two unequal layout slides|Bug|
|SLIDESJAVA-38362|Issue while showing page number on slide|Bug|
|SLIDESJAVA-34173|Support for Edit points in Trapezoid shape|Feature|
|SLIDESJAVA-38171|Long loading & saving time for pptx|Investigation|
|SLIDESJAVA-37010|Text spacing differs from PPTX to PDF|Bug|
|SLIDESJAVA-38367|Repair message after cloning attached (unrepairable on larger files)|Bug|
|SLIDESJAVA-38365|PptUnsupportedFormatException on loading presentation|Bug|
|SLIDESJAVA-38212|Use Aspose.Slides for Net 21.1 features|Enhancement|
|SLIDESJAVA-38425|Getting wrong font names of Chinese fonts in SVG|Bug|
|SLIDESJAVA-38424|Exception on creating thumbnails|Bug|
|SLIDESJAVA-38373|Warning on rendering slide using Aspose.Slides|Investigation|
|SLIDESJAVA-38157|Arial MT Std throw error when slide number format with font Arial text fill = 'gradient'|Investigation|

## **Public API Changes**

### **Support of the shape points editing has been added** ###

Support of the shape points editing has been added. New classes, interfaces, enums, and **[GeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryShape)** methods have been added.

**New classes:**
- [PathSegment](https://apireference.aspose.com/slides/java/com.aspose.slides/PathSegment)
- [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath)
- [ShapeUtil](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeUtil)

**New interfaces:**
- [IPathSegment](https://apireference.aspose.com/slides/java/com.aspose.slides/IPathSegment)
- [IGeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath)

**New enums:**
- [PathFillModeType](https://apireference.aspose.com/slides/java/com.aspose.slides/PathFillModeType)
- [PathCommandType](https://apireference.aspose.com/slides/java/com.aspose.slides/PathCommandType)

**Public methods have been added to the GeometryShape class and its descendants:**  
- IGeometryPath[] [GeometryShape.getGeometryPaths()](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryShape#getGeometryPaths--)
- void [IGeometryShape.setGeometryPath()](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-)
- void [IGeometryShape.setGeometryPaths()](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-)

**Feature description:**

Customization of the shape geometry assumes editing points of an existing shape. 

![Edit shape points](1_editpoints_pp.png)

To provide the abovementioned functionality [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) class and [IGeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath) interface have been added. [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) instance represents a geometry path of the [IGeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape) object. 

To retrieve [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) from the [IGeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape) instance [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) method has been added. Please note that shapes may be built from a few smaller shapes (e.g. an "equal" sign) so this method returns an array of [IGeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath) objects. 

To set [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) to the shape two methods have been added: 
[IGeometryShape.setGeometryPath(IGeometryPath geometryPath)](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) for solid shapes and [setGeometryPaths(IGeometryPath[] geometryPaths)](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) for composite shapes.

