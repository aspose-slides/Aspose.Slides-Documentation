---
title: Offentligt API och bakåt inkompatibla förändringar i Aspose.Slides för Java 15.5.0
linktitle: Aspose.Slides för Java 15.5.0
type: docs
weight: 130
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="info" %}} 

Denna sida listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) som införts med Aspose.Slides för Java 15.5.0 API.

{{% /alert %}} 
## **Ändringar i offentligt API**
### **CommonSlideViewProperties class and ICommonSlideViewProperties interface have been added**
Klassen CommonSlideViewProperties och gränssnittet ICommonSlideViewProperties har lagts till. com.aspose.slides.CommonSlideViewProperties class (and its interface com.aspose.slides.ICommonSlideViewProperties) represents common slide view properties (currently view scale options).
### **IAxis.getLabelOffset(), setLabelOffset(int) methods have been added**
Metoderna IAxis.getLabelOffset() och setLabelOffset(int) har lagts till. IAxis.getLabelOffset(), setLabelOffset(int) methods allow to get and to specify the distance of labels from the axis. Applied to category or date axis.
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) methods have been added**
Metoderna IChartTextBlockFormat.getAutofitType() och setAutofitType(byte) har lagts till. Methods getAutofitType(), setAutofitType(/**TextAutofitType**/byte) have been added to com.aspose.slides.IChartTextBlockFormat interface. Changing of this value can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
### **Methods IChartTextBlockFormat.getWrapText(), setWrapText(byte) have been added**
Metoderna IChartTextBlockFormat.getWrapText() och setWrapText(byte) har lagts till. Methods getWrapText(), setWrapText(/**NullableBool**/byte) have been added to interface com.aspose.slides.IChartTextBlockFormat. Changing of this value can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2007/2013).
### **The methods to manage margins have been added to IChartTextBlockFormat**
Metoderna för att hantera marginaler har lagts till i IChartTextBlockFormat. getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() and setMarginBottom(double) methods have been added to interface com.aspose.slides.IChartTextBlockFormat. Changing of this values can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
### **ViewProperties.getNotesViewProperties() method have been added**
Metoden ViewProperties.getNotesViewProperties() har lagts till. com.aspose.slides.ViewProperties.getNotesViewProperties() property has been added. It gets common view properties associated with the notes view mode.
### **ViewProperties.getSlideViewProperties() method has been added**
Metoden ViewProperties.getSlideViewProperties() har lagts till. com.aspose.slides.ViewProperties.getSlideViewProperties() method has been added. Its gets common view properties associated with the slide view mode.