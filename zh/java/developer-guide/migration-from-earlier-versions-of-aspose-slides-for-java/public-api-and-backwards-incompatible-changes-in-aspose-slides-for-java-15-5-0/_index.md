---
title: Aspose.Slides for Java 15.5.0 中的公共 API 和向后不兼容的更改
type: docs
weight: 130
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 15.5.0 API 中[添加的](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)类、方法、属性等，以及任何新的限制和其他[更改](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)。

{{% /alert %}} 
## **公共 API 更改**
### **添加了 CommonSlideViewProperties 类和 ICommonSlideViewProperties 接口**
com.aspose.slides.CommonSlideViewProperties 类（及其接口 com.aspose.slides.ICommonSlideViewProperties）表示常见的幻灯片视图属性（当前视图缩放选项）。
### **添加了 IAxis.getLabelOffset()，setLabelOffset(int) 方法**
IAxis.getLabelOffset()，setLabelOffset(int) 方法允许获取和指定标签与轴的距离。适用于类别或日期轴。
### **添加了 IChartTextBlockFormat.getAutofitType()，setAutofitType(byte) 方法**
方法 getAutofitType()，setAutofitType(/**TextAutofitType**/byte) 已添加到 com.aspose.slides.IChartTextBlockFormat 接口。
更改此值可能仅对这些图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中全面支持；在 PowerPoint 2007 中没有渲染效果）。
### **添加了方法 IChartTextBlockFormat.getWrapText()，setWrapText(byte)**
方法 getWrapText()，setWrapText(/**NullableBool**/byte) 已添加到接口 com.aspose.slides.IChartTextBlockFormat。
更改此值可能仅对这些图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2007/2013 中全面支持）。
### **IChartTextBlockFormat 中添加了管理边距的方法**
getMarginLeft()，setMarginLeft(double)，getMarginRight()，setMarginRight(double)，getMarginTop()，setMarginTop(double)，getMarginBottom() 和 setMarginBottom(double) 方法已添加到接口 com.aspose.slides.IChartTextBlockFormat。
更改此值可能仅对这些图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中全面支持；在 PowerPoint 2007 中没有渲染效果）。
### **添加了 ViewProperties.getNotesViewProperties() 方法**
com.aspose.slides.ViewProperties.getNotesViewProperties() 属性已添加。它获取与备注视图模式相关的常见视图属性。
### **添加了 ViewProperties.getSlideViewProperties() 方法**
com.aspose.slides.ViewProperties.getSlideViewProperties() 方法已添加。它获取与幻灯片视图模式相关的常见视图属性。