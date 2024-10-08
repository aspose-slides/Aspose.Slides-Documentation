---
title: Aspose.Slides for Java 15.5.0 的公共 API 和不兼容的更改
type: docs
weight: 130
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

此页面列出了所有 [添加的](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) 类、方法、属性等，以及任何新限制和与 Aspose.Slides for Java 15.5.0 API 相关的其他 [更改](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)。

{{% /alert %}} 
## **公共 API 更改**
### **添加了 CommonSlideViewProperties 类和 ICommonSlideViewProperties 接口**
com.aspose.slides.CommonSlideViewProperties 类 (及其接口 com.aspose.slides.ICommonSlideViewProperties) 表示通用幻灯片视图属性（当前视图比例选项）。
### **添加了 IAxis.getLabelOffset()、setLabelOffset(int) 方法**
IAxis.getLabelOffset()、setLabelOffset(int) 方法允许获取和指定标签与轴之间的距离。适用于分类轴或日期轴。
### **添加了 IChartTextBlockFormat.getAutofitType()、setAutofitType(byte) 方法**
已向 com.aspose.slides.IChartTextBlockFormat 接口添加了 getAutofitType() 和 setAutofitType(/**TextAutofitType**/byte) 方法。
更改此值仅对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中没有渲染效果）。
### **添加了 IChartTextBlockFormat.getWrapText()、setWrapText(byte) 方法**
已向 com.aspose.slides.IChartTextBlockFormat 接口添加了 getWrapText() 和 setWrapText(/**NullableBool**/byte) 方法。
更改此值仅对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2007/2013 中完全支持）。
### **向 IChartTextBlockFormat 添加了管理边距的方法**
已向 com.aspose.slides.IChartTextBlockFormat 接口添加了 getMarginLeft()、setMarginLeft(double)、getMarginRight()、setMarginRight(double)、getMarginTop()、setMarginTop(double)、getMarginBottom() 和 setMarginBottom(double) 方法。
更改这些值仅对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中没有渲染效果）。
### **添加了 ViewProperties.getNotesViewProperties() 方法**
已添加 com.aspose.slides.ViewProperties.getNotesViewProperties() 属性。它获取与备注视图模式相关的通用视图属性。
### **添加了 ViewProperties.getSlideViewProperties() 方法**
已添加 com.aspose.slides.ViewProperties.getSlideViewProperties() 方法。它获取与幻灯片视图模式相关的通用视图属性。