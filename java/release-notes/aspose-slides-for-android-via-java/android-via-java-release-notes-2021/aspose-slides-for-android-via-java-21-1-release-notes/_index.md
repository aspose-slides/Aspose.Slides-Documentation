---
title: Aspose.Slides for Android via Java 21.1 Release Notes
type: docs
weight: 120
url: /java/aspose-slides-for-android-via-java-21-1-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for Aspose.Slides for Android via Java 21.1

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESANDROID-322|[Use Aspose.Slides for Java 21.1 features](/slides/java/aspose-slides-for-java-21-1-release-notes/)|Enhancement|


## **Public API Changes**

### **Support of the shape points editing has been added** ###

Support of the shape points editing has been added. New classes, interfaces, enums, and **[GeometryShape](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape)** methods have been added.

**New classes:**
- [PathSegment](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/PathSegment)
- [GeometryPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath)
- [ShapeUtil](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil)

**New interfaces:**
- [IPathSegment](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IPathSegment)
- [IGeometryPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath)

**New enums:**
- [PathFillModeType](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/PathFillModeType)
- [PathCommandType](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/PathCommandType)

**Public methods have been added to the GeometryShape class and its descendants:**  
- IGeometryPath[] [GeometryShape.getGeometryPaths()](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape#getGeometryPaths--)
- void [IGeometryShape.setGeometryPath()](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-)
- void [IGeometryShape.setGeometryPaths()](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-)

Feature description:

Customization of the shape geometry assumes editing points of an existing shape. 

![Edit shape points](1_editPoints_PP.png)

To provide the mentioned functionality [GeometryPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) class and [IGeometryPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) interface have been added. [GeometryPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) instance represents a geometry path of the [IGeometryShape](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape) object. 

To retrieve [GeometryPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) from the [IGeometryShape](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape) instance [GeometryPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) method has been added. Please note that shapes may be built from a few smaller shapes (e.g. an "equal" sign) so this method returns an array of [IGeometryPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) objects. 

To set [GeometryPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) to the shape two methods have been added: 
[IGeometryShape.setGeometryPath(IGeometryPath geometryPath)](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) for solid shapes and [setGeometryPaths(IGeometryPath[] geometryPaths)](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) for composite shapes.

