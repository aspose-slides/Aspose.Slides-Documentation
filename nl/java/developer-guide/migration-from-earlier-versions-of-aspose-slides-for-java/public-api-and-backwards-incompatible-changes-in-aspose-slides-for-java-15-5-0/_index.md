---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.5.0
linktitle: Aspose.Slides voor Java 15.5.0
type: docs
weight: 130
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de publieke API en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [added](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) klassen, methoden, eigenschappen enzovoort, eventuele nieuwe beperkingen en andere [changes](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) die geïntroduceerd zijn met de Aspose.Slides for Java 15.5.0 API.

{{% /alert %}} 
## **Public API Changes**
### **CommonSlideViewProperties class and ICommonSlideViewProperties interface have been added**
com.aspose.slides.CommonSlideViewProperties class (and its interface com.aspose.slides.ICommonSlideViewProperties) represents common slide view properties (currently view scale options).
### **IAxis.getLabelOffset(), setLabelOffset(int) methods have been added**
IAxis.getLabelOffset(), setLabelOffset(int) methods allow to get and to specify the distance of labels from the axis. Applied to category or date axis.
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) methods have been added**
Methods getAutofitType(), setAutofitType(/**TextAutofitType**/byte) have been added to com.aspose.slides.IChartTextBlockFormat interface.
Changing of this value can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
### **Methods IChartTextBlockFormat.getWrapText(), setWrapText(byte) have been added**
Methods getWrapText(), setWrapText(/**NullableBool**/byte) have been added to interface com.aspose.slides.IChartTextBlockFormat.
Changing of this value can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2007/2013).
### **The methods to manage margins have been added to IChartTextBlockFormat**
getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() and setMarginBottom(double) methods have been added to interface com.aspose.slides.IChartTextBlockFormat.
Changing of this values can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
### **ViewProperties.getNotesViewProperties() method have been added**
com.aspose.slides.ViewProperties.getNotesViewProperties() property has been added. It gets common view properties associated with the notes view mode.
### **ViewProperties.getSlideViewProperties() method has been added**
com.aspose.slides.ViewProperties.getSlideViewProperties() method has been added. Its gets common view properties associated with the slide view mode.