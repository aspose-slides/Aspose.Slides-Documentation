---
title: Öffentliche API und nicht abwärtskompatible Änderungen in Aspose.Slides für PHP über Java 15.5.0
type: docs
weight: 130
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) Klassen, Methoden, Eigenschaften usw. sowie neue Einschränkungen und andere [Änderungen](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) auf, die mit der Aspose.Slides für PHP über Java 15.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Die Klasse CommonSlideViewProperties und das Interface ICommonSlideViewProperties wurden hinzugefügt**
Die Klasse com.aspose.slides.CommonSlideViewProperties (und ihr Interface com.aspose.slides.ICommonSlideViewProperties) stellt allgemeine Eigenschaften der Folienansicht dar (derzeit Optionen für die Ansichtsskala).
### **Die Methoden IAxis.getLabelOffset(), setLabelOffset(int) wurden hinzugefügt**
Die Methoden IAxis.getLabelOffset(), setLabelOffset(int) ermöglichen es, den Abstand der Beschriftungen von der Achse zu erhalten und festzulegen. Anwendbar auf die Kategorien- oder Datumsachse.
### **Die Methoden IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) wurden hinzugefügt**
Die Methoden getAutofitType(), setAutofitType(/**TextAutofitType**/byte) wurden zum Interface com.aspose.slides.IChartTextBlockFormat hinzugefügt.
Die Änderung dieses Wertes kann einen bestimmten Einfluss nur auf diese Diagrammteile haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat es keinen Einfluss auf das Rendering).
### **Die Methoden IChartTextBlockFormat.getWrapText(), setWrapText(byte) wurden hinzugefügt**
Die Methoden getWrapText(), setWrapText(/**NullableBool**/byte) wurden zum Interface com.aspose.slides.IChartTextBlockFormat hinzugefügt.
Die Änderung dieses Wertes kann einen bestimmten Einfluss nur auf diese Diagrammteile haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2007/2013).
### **Die Methoden zur Verwaltung von Rändern wurden zu IChartTextBlockFormat hinzugefügt**
Die Methoden getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() und setMarginBottom(double) wurden zum Interface com.aspose.slides.IChartTextBlockFormat hinzugefügt.
Die Änderung dieser Werte kann einen bestimmten Einfluss nur auf diese Diagrammteile haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat es keinen Einfluss auf das Rendering).
### **Die Methode ViewProperties.getNotesViewProperties() wurde hinzugefügt**
Die Eigenschaft com.aspose.slides.ViewProperties.getNotesViewProperties() wurde hinzugefügt. Sie erhält allgemeine Anzeigeeigenschaften, die mit dem Notizenansichtsmodus verbunden sind.
### **Die Methode ViewProperties.getSlideViewProperties() wurde hinzugefügt**
Die Methode com.aspose.slides.ViewProperties.getSlideViewProperties() wurde hinzugefügt. Sie erhält allgemeine Anzeigeeigenschaften, die mit dem Folienansichtsmodus verbunden sind.