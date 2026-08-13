---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.5.0
linktitle: Aspose.Slides voor Java 15.5.0
type: docs
weight: 130
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- migratie
- oude code
- moderne code
- ouderwetse aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de incompatibele wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) klassen, methoden, eigenschappen enzovoort, eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) die geïntroduceerd zijn met de Aspose.Slides for Java 15.5.0 API.

{{% /alert %}} 
## **Wijzigingen in de openbare API**
### **Klasse CommonSlideViewProperties en interface ICommonSlideViewProperties zijn toegevoegd**
com.aspose.slides.CommonSlideViewProperties class (and its interface com.aspose.slides.ICommonSlideViewProperties) represents common slide view properties (currently view scale options).
### **Methoden IAxis.getLabelOffset() en setLabelOffset(int) zijn toegevoegd**
IAxis.getLabelOffset(), setLabelOffset(int) methods allow to get and to specify the distance of labels from the axis. Applied to category or date axis.
### **Methoden IChartTextBlockFormat.getAutofitType() en setAutofitType(byte) zijn toegevoegd**
Methods getAutofitType(), setAutofitType(/**TextAutofitType**/byte) have been added to com.aspose.slides.IChartTextBlockFormat interface.
Changing of this value can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
### **Methoden IChartTextBlockFormat.getWrapText() en setWrapText(byte) zijn toegevoegd**
Methods getWrapText(), setWrapText(/**NullableBool**/byte) have been added to interface com.aspose.slides.IChartTextBlockFormat.
Changing of this value can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2007/2013).
### **De methoden om marges te beheren zijn toegevoegd aan IChartTextBlockFormat**
getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() and setMarginBottom(double) methods have been added to interface com.aspose.slides.IChartTextBlockFormat.
Changing of this values can produce a certain influence only for these chart parts: DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).
### **Methode ViewProperties.getNotesViewProperties() is toegevoegd**
com.aspose.slides.ViewProperties.getNotesViewProperties() property has been added. It gets common view properties associated with the notes view mode.
### **Methode ViewProperties.getSlideViewProperties() is toegevoegd**
com.aspose.slides.ViewProperties.getSlideViewProperties() method has been added. Its gets common view properties associated with the slide view mode.