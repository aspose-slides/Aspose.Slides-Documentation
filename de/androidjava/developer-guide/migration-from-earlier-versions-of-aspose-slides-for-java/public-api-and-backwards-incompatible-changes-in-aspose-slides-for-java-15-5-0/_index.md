---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für Java 15.5.0
type: docs
weight: 130
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) Klassen, Methoden, Eigenschaften usw., alle neuen Einschränkungen und andere [Änderungen](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) auf, die mit der Aspose.Slides für Java 15.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen in der öffentlichen API**
### **Die Klasse CommonSlideViewProperties und das Interface ICommonSlideViewProperties wurden hinzugefügt**
Die Klasse com.aspose.slides.CommonSlideViewProperties (und ihr Interface com.aspose.slides.ICommonSlideViewProperties) repräsentiert gemeinsame Eigenschaften der Folienansicht (derzeit Optionen für den Ansichtsskalierung).
### **Die Methoden IAxis.getLabelOffset(), setLabelOffset(int) wurden hinzugefügt**
Die Methoden IAxis.getLabelOffset(), setLabelOffset(int) ermöglichen es, den Abstand der Beschriftungen von der Achse abzurufen und anzugeben. Anwendbar auf die Kategorie- oder Datumsachse.
### **Die Methoden IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) wurden hinzugefügt**
Die Methoden getAutofitType(), setAutofitType(/**TextAutofitType**/byte) wurden zum Interface com.aspose.slides.IChartTextBlockFormat hinzugefügt. Die Änderung dieses Wertes kann einen bestimmten Einfluss nur auf diese Diagrammteile haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat dies keinen Einfluss auf das Rendering).
### **Die Methoden IChartTextBlockFormat.getWrapText(), setWrapText(byte) wurden hinzugefügt**
Die Methoden getWrapText(), setWrapText(/**NullableBool**/byte) wurden zum Interface com.aspose.slides.IChartTextBlockFormat hinzugefügt. Die Änderung dieses Wertes kann einen bestimmten Einfluss nur auf diese Diagrammteile haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2007/2013).
### **Die Methoden zur Verwaltung der Ränder wurden zum IChartTextBlockFormat hinzugefügt**
Die Methoden getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() und setMarginBottom(double) wurden zum Interface com.aspose.slides.IChartTextBlockFormat hinzugefügt. Die Änderung dieser Werte kann einen bestimmten Einfluss nur auf diese Diagrammteile haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat dies keinen Einfluss auf das Rendering).
### **Die Methode ViewProperties.getNotesViewProperties() wurde hinzugefügt**
Die Methode com.aspose.slides.ViewProperties.getNotesViewProperties() wurde hinzugefügt. Sie ruft gemeinsame Ansichtseigenschaften ab, die mit dem Notenansichtsmodus verbunden sind.
### **Die Methode ViewProperties.getSlideViewProperties() wurde hinzugefügt**
Die Methode com.aspose.slides.ViewProperties.getSlideViewProperties() wurde hinzugefügt. Sie ruft gemeinsame Ansichtseigenschaften ab, die mit dem Folienansichtsmodus verbunden sind.