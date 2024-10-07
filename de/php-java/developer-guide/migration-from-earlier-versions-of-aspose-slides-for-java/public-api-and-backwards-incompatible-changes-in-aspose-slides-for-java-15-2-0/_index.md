---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für PHP über Java 15.2.0
type: docs
weight: 110
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) Klassen, Methoden, Eigenschaften usw., alle neuen Einschränkungen und andere [Änderungen](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) auf, die mit der API von Aspose.Slides für PHP über Java 15.2.0 eingeführt wurden.

{{% /alert %}} {{% alert color="primary" %}} 

Es gibt bekannte Probleme mit einigen Bildpunkt-Listen und WordArt-Objekten, die in Aspose.Slides für PHP über Java 15.2.0 behoben werden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Die Methoden addDataPointForDoughnutSeries wurden hinzugefügt**
Die zwei Überladungen der Methode IChartDataPointCollection.addDataPointForDoughnutSeries() wurden hinzugefügt, um Datenpunkte in Serien vom Typ Doughnut hinzuzufügen.
### **Die Klasse com.aspose.slides.SmartArtShape wurde von der Klasse com.aspose.slides.GeometryShape abgeleitet**
Die Klasse com.aspose.slides.SmartArtShape wurde von der Klasse com.aspose.slides.GeometryShape abgeleitet. Diese Änderung verbessert das Objektmodell von Aspose.Slides und fügt der Klasse SmartArtShape neue Funktionen hinzu.
### **Die Methoden IGradientStopCollection.add(...) und IGradientStopCollection.insert(...) wurden geändert**
Die Signatur von IGradientStop add(float position, int presetColor) wurde durch die Signatur IGradientStop addPresetColor(float position, int presetColor) ersetzt.

Die Signatur der IGradientStopCollection-Methode IGradientStop add(float position, SchemeColor schemeColor) wurde durch die Signatur IGradientStop addSchemeColor(float position, int schemeColor) ersetzt.

Die Signatur der IGradientStopCollection-Methode void insert(int index, float position, int presetColor) wurde durch die Signatur void insertPresetColor(int index, float position, int presetColor) ersetzt.

Die Signatur der IGradientStopCollection-Methode void insert(int index, float position, SchemeColor schemeColor) wurde durch die Signatur void insertSchemeColor(int index, float position, int schemeColor) ersetzt.
### **Die Methode java.awt.Color getAutomaticSeriesColor() wurde zu com.aspose.slides.IChartSeries hinzugefügt**
Die Methode getAutomaticSeriesColor() gibt eine automatische Farbe der Serie basierend auf dem Serienindex und dem Diagrammstil zurück. Diese Farbe wird standardmäßig verwendet, wenn FillType NotDefined entspricht.
﻿

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
  for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
    $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
  }
```
### **Die Methode zum Entfernen von Diagramm-Datenpunkten und Diagramm-Kategorien nach ihrem Index wurde hinzugefügt**
Die Methode IChartDataPointCollection.removeAt(int index) wurde hinzugefügt, um einen Diagramm-Datenpunkt nach seinem Index zu entfernen.
Die Methode IChartCategoryCollection.removeAt(int index) wurde hinzugefügt, um eine Diagramm-Kategorie nach ihrem Index zu entfernen.
### **PptXPptY-Wert wurde zur Aufzählung com.aspose.slides.PropertyType hinzugefügt**
Der PptXPptY-Wert wurde im Rahmen einer Lösung für ein Serialisierungsproblem zur Aufzählung com.aspose.slides.PropertyType hinzugefügt.