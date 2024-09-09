---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) classes, methods, properties and so on, any new restrictions and other [changes](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introduced with the Aspose.Slides for Java 15.5.0 API.

{{% /alert %}} 
## **Public API Changes**
### **CommonSlideViewProperties class and ICommonSlideViewProperties interface have been added**
aspose.slides.CommonSlideViewProperties class (and its interface aspose.slides.ICommonSlideViewProperties) represents common slide view properties (currently view scale options).
### **IAxis.getLabelOffset(), setLabelOffset(int) methods have been added**
IAxis.getLabelOffset(), setLabelOffset(int) methods allow to get and to specify the distance of labels from the axis. Applied to category or date axis.
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) methods have been added**
Methods getAutofitType(), setAutofitType(/**TextAutofitType**/byte) have been added to aspose.slides.IChartTextBlockFormat interface.
Changing of this value can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
### **Methods IChartTextBlockFormat.getWrapText(), setWrapText(byte) have been added**
Methods getWrapText(), setWrapText(/**NullableBool**/byte) have been added to interface aspose.slides.IChartTextBlockFormat.
Changing of this value can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2007/2013).
### **The methods to manage margins have been added to IChartTextBlockFormat**
getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() and setMarginBottom(double) methods have been added to interface aspose.slides.IChartTextBlockFormat.
Changing of this values can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
### **ViewProperties.getNotesViewProperties() method have been added**
aspose.slides.ViewProperties.getNotesViewProperties() property has been added. It gets common view properties associated with the notes view mode.
### **ViewProperties.getSlideViewProperties() method has been added**
aspose.slides.ViewProperties.getSlideViewProperties() method has been added. Its gets common view properties associated with the slide view mode.
