---
title: Aspose.Slides for Java 15.5.0 的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审查 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出所有[已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)类、方法、属性等，任何新限制以及其他[更改](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)均随 Aspose.Slides for Java 15.5.0 API 引入。

{{% /alert %}} 
## **公共 API 更改**
### **已添加 CommonSlideViewProperties 类和 ICommonSlideViewProperties 接口**
com.aspose.slides.CommonSlideViewProperties 类（以及其接口 com.aspose.slides.ICommonSlideViewProperties）表示通用幻灯片视图属性（当前为视图缩放选项）。

### **已添加 IAxis.getLabelOffset()、setLabelOffset(int) 方法**
IAxis.getLabelOffset()、setLabelOffset(int) 方法用于获取和指定标签距离轴的距离。适用于类别轴或日期轴。

### **已添加 IChartTextBlockFormat.getAutofitType()、setAutofitType(byte) 方法**
已向 com.aspose.slides.IChartTextBlockFormat 接口添加了 getAutofitType()、setAutofitType(/**TextAutofitType**/byte) 方法。更改此值仅会对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中对渲染没有效果）。

### **已添加 IChartTextBlockFormat.getWrapText()、setWrapText(byte) 方法**
已向接口 com.aspose.slides.IChartTextBlockFormat 添加了 getWrapText()、setWrapText(/**NullableBool**/byte) 方法。更改此值仅会对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2007/2013 中完全支持）。

### **已向 IChartTextBlockFormat 添加了管理边距的方法**
已向接口 com.aspose.slides.IChartTextBlockFormat 添加了 getMarginLeft()、setMarginLeft(double)、getMarginRight()、setMarginRight(double)、getMarginTop()、setMarginTop(double)、getMarginBottom() 和 setMarginBottom(double) 方法。更改这些值仅会对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中对渲染没有效果）。

### **已添加 ViewProperties.getNotesViewProperties() 方法**
已添加 com.aspose.slides.ViewProperties.getNotesViewProperties() 属性。它获取与备注视图模式关联的通用视图属性。

### **已添加 ViewProperties.getSlideViewProperties() 方法**
已添加 com.aspose.slides.ViewProperties.getSlideViewProperties() 方法。它获取与幻灯片视图模式关联的通用视图属性。