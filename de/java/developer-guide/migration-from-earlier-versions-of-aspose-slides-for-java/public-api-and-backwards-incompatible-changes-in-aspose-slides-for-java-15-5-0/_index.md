---
title: Öffentliches API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 15.5.0
type: docs
weight: 130
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) Klassen, Methoden, Eigenschaften usw. auf, sowie neue Einschränkungen und andere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), die mit der Aspose.Slides für Java 15.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen des öffentlichen APIs**
### **Die CommonSlideViewProperties-Klasse und das ICommonSlideViewProperties-Interface wurden hinzugefügt**
Die com.aspose.slides.CommonSlideViewProperties-Klasse (und ihr Interface com.aspose.slides.ICommonSlideViewProperties) repräsentiert gemeinsame Eigenschaften der Folienansicht (derzeit Ansichtsskalierungsoptionen).
### **IAxis.getLabelOffset(), setLabelOffset(int) Methoden wurden hinzugefügt**
Die IAxis.getLabelOffset(), setLabelOffset(int) Methoden ermöglichen es, den Abstand der Beschriftungen von der Achse abzurufen und anzugeben. Wird für Kategorien- oder Datumsachsen angewendet.
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) Methoden wurden hinzugefügt**
Die Methoden getAutofitType(), setAutofitType(/**TextAutofitType**/byte) wurden zum com.aspose.slides.IChartTextBlockFormat-Interface hinzugefügt.
Die Änderung dieses Wertes kann nur einen bestimmten Einfluss auf diese Diagrammteile haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat dies keinen Einfluss auf das Rendering).
### **Methoden IChartTextBlockFormat.getWrapText(), setWrapText(byte) wurden hinzugefügt**
Die Methoden getWrapText(), setWrapText(/**NullableBool**/byte) wurden zum Interface com.aspose.slides.IChartTextBlockFormat hinzugefügt.
Die Änderung dieses Wertes kann nur einen bestimmten Einfluss auf diese Diagrammteile haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2007/2013).
### **Die Methoden zur Verwaltung von Abständen wurden zum IChartTextBlockFormat hinzugefügt**
Die Methoden getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() und setMarginBottom(double) wurden zum Interface com.aspose.slides.IChartTextBlockFormat hinzugefügt.
Die Änderung dieser Werte kann nur einen bestimmten Einfluss auf diese Diagrammteile haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat dies keinen Einfluss auf das Rendering).
### **Die Methode ViewProperties.getNotesViewProperties() wurde hinzugefügt**
Die Eigenschaft com.aspose.slides.ViewProperties.getNotesViewProperties() wurde hinzugefügt. Sie ruft gemeinsame Ansichtseigenschaften ab, die mit dem Notizenansichtsmodus verbunden sind.
### **Die Methode ViewProperties.getSlideViewProperties() wurde hinzugefügt**
Die Methode com.aspose.slides.ViewProperties.getSlideViewProperties() wurde hinzugefügt. Sie ruft gemeinsame Ansichtseigenschaften ab, die mit dem Folienansichtsmodus verbunden sind.