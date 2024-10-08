---
title: Aspose.Slides for PHP via Java 15.5.0 的公共 API 和不兼容的变更
type: docs
weight: 130
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for PHP via Java 15.5.0 API 中 [添加的](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)类、方法、属性等、任何新的限制以及引入的其他 [变更](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)。

{{% /alert %}} 
## **公共 API 变更**
### **添加了 CommonSlideViewProperties 类和 ICommonSlideViewProperties 接口**
com.aspose.slides.CommonSlideViewProperties 类（及其接口 com.aspose.slides.ICommonSlideViewProperties）表示公共幻灯片视图属性（当前视图比例选项）。
### **添加了 IAxis.getLabelOffset() 和 setLabelOffset(int) 方法**
IAxis.getLabelOffset(), setLabelOffset(int) 方法允许获取和指定标签与轴之间的距离。适用于类别轴或日期轴。
### **添加了 IChartTextBlockFormat.getAutofitType() 和 setAutofitType(byte) 方法**
方法 getAutofitType(), setAutofitType(/**TextAutofitType**/byte) 已添加到 com.aspose.slides.IChartTextBlockFormat 接口。
更改此值仅对这些图表部分产生一定影响：数据标签和数据标签格式（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中没有渲染效果）。
### **添加了方法 IChartTextBlockFormat.getWrapText() 和 setWrapText(byte)**
方法 getWrapText(), setWrapText(/**NullableBool**/byte) 已添加到接口 com.aspose.slides.IChartTextBlockFormat。
更改此值仅对这些图表部分产生一定影响：数据标签和数据标签格式（在 PowerPoint 2007/2013 中完全支持）。
### **IChartTextBlockFormat 中添加了管理边距的方法**
方法 getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() 和 setMarginBottom(double) 已添加到接口 com.aspose.slides.IChartTextBlockFormat。
更改这些值仅对这些图表部分产生一定影响：数据标签和数据标签格式（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中没有渲染效果）。
### **添加了 ViewProperties.getNotesViewProperties() 方法**
com.aspose.slides.ViewProperties.getNotesViewProperties() 属性已添加。它获取与备注视图模式关联的公共视图属性。
### **添加了 ViewProperties.getSlideViewProperties() 方法**
com.aspose.slides.ViewProperties.getSlideViewProperties() 方法已添加。它获取与幻灯片视图模式关联的公共视图属性。