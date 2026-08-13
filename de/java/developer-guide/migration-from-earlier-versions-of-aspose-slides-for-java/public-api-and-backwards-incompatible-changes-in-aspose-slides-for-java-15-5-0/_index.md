---
title: Öffentliches API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 15.5.0
linktitle: Aspose.Slides für Java 15.5.0
type: docs
weight: 130
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die inkompatiblen Änderungen in Aspose.Slides für Java, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) Klassen, Methoden, Eigenschaften usw. sowie neue Einschränkungen und andere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) auf, die mit der Aspose.Slides for Java 15.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **CommonSlideViewProperties class and ICommonSlideViewProperties interface have been added**
Die Klasse com.aspose.slides.CommonSlideViewProperties (und ihre Schnittstelle com.aspose.slides.ICommonSlideViewProperties) stellt allgemeine Folienansichtseigenschaften dar (derzeit Optionen für die Ansichtsskala).
### **IAxis.getLabelOffset(), setLabelOffset(int) methods have been added**
Methoden IAxis.getLabelOffset() und setLabelOffset(int) wurden hinzugefügt. Die Methoden IAxis.getLabelOffset() und setLabelOffset(int) ermöglichen das Abrufen und Festlegen des Abstands der Beschriftungen von der Achse. Gilt für Kategorien‑ oder Datumsachsen.
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) methods have been added**
Methoden IChartTextBlockFormat.getAutofitType() und setAutofitType(byte) wurden hinzugefügt. Methoden getAutofitType() und setAutofitType(/**TextAutofitType**/byte) wurden zur Schnittstelle com.aspose.slides.IChartTextBlockFormat hinzugefügt. Das Ändern dieses Werts kann nur bei diesen Diagrammteilen einen Einfluss haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat es keine Auswirkung auf die Darstellung).
### **Methods IChartTextBlockFormat.getWrapText(), setWrapText(byte) have been added**
Methoden IChartTextBlockFormat.getWrapText() und setWrapText(byte) wurden hinzugefügt. Methoden getWrapText() und setWrapText(/**NullableBool**/byte) wurden zur Schnittstelle com.aspose.slides.IChartTextBlockFormat hinzugefügt. Das Ändern dieses Werts kann nur bei diesen Diagrammteilen einen Einfluss haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2007/2013).
### **The methods to manage margins have been added to IChartTextBlockFormat**
Methoden zur Verwaltung von Rändern wurden zu IChartTextBlockFormat hinzugefügt. Die Methoden getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() und setMarginBottom(double) wurden zur Schnittstelle com.aspose.slides.IChartTextBlockFormat hinzugefügt. Das Ändern dieser Werte kann nur bei diesen Diagrammteilen einen Einfluss haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat es keine Auswirkung auf die Darstellung).
### **ViewProperties.getNotesViewProperties() method have been added**
Die Eigenschaft com.aspose.slides.ViewProperties.getNotesViewProperties() wurde hinzugefügt. Sie ruft die allgemeinen Ansichtseigenschaften für den Notizansichtsmodus ab.
### **ViewProperties.getSlideViewProperties() method has been added**
Die Methode com.aspose.slides.ViewProperties.getSlideViewProperties() wurde hinzugefügt. Sie ruft die allgemeinen Ansichtseigenschaften für den Folienansichtsmodus ab.