---
title: Öffentliches API und rückwärts inkompatible Änderungen in Aspose.Slides für Java 15.2.0
type: docs
weight: 110
url: /de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) Klassen, Methoden, Eigenschaften und so weiter, alle neuen Einschränkungen und andere [Änderungen](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) auf, die mit der Aspose.Slides für Java 15.2.0 API eingeführt wurden.

{{% /alert %}} {{% alert color="primary" %}} 

Es gibt bekannte Probleme mit einigen Bildlisten und WordArt-Objekten, die in Aspose.Slides für Java 15.2.0 behoben werden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Methoden addDataPointForDoughnutSeries wurden hinzugefügt**
Die zwei Überladungen der Methode IChartDataPointCollection.addDataPointForDoughnutSeries() wurden hinzugefügt, um Datenpunkte in Serien vom Typ Doughnut hinzuzufügen.
### **Die Klasse com.aspose.slides.SmartArtShape wurde von der Klasse com.aspose.slides.GeometryShape abgeleitet**
Die Klasse com.aspose.slides.SmartArtShape wurde von der Klasse com.aspose.slides.GeometryShape abgeleitet. Diese Änderung verbessert das Aspose.Slides-Objektmodell und fügt der Klasse SmartArtShape neue Funktionen hinzu.
### **Die Methoden IGradientStopCollection.add(...) und IGradientStopCollection.insert(...) wurden geändert**
Die Signatur von IGradientStop add(float position, int presetColor) wurde durch die Signatur IGradientStop addPresetColor(float position, int presetColor) ersetzt.

Die Signatur der IGradientStopCollection-Methode IGradientStop add(float position, SchemeColor schemeColor) wurde durch die Signatur IGradientStop addSchemeColor(float position, int schemeColor) ersetzt.

Die Signatur der IGradientStopCollection-Methode void insert(int index, float position, int presetColor) wurde durch die Signatur void insertPresetColor(int index, float position, int presetColor) ersetzt.

Die Signatur der IGradientStopCollection-Methode void insert(int index, float position, SchemeColor schemeColor) wurde durch die Signatur void insertSchemeColor(int index, float position, int schemeColor) ersetzt.
### **Die Methode java.awt.Color getAutomaticSeriesColor() wurde zu com.aspose.slides.IChartSeries hinzugefügt**
Die Methode getAutomaticSeriesColor() gibt eine automatische Farbe der Serie basierend auf dem Serienindex und dem Diagrammstil zurück. Diese Farbe wird standardmäßig verwendet, wenn FillType gleich NotDefined ist.
﻿

``` java

 Präsentation pres = new Präsentation();

IChart diagramm = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < diagramm.getChartData().getSeries().size(); i++)

{

    diagramm.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Eine Methode zum Entfernen von Diagrammdatenpunkten und Diagrammkategorien nach ihrem Index wurde hinzugefügt**
Die Methode IChartDataPointCollection.removeAt(int index) wurde hinzugefügt, um einen Diagrammdatenpunkt nach seinem Index zu entfernen.
Die Methode IChartCategoryCollection.removeAt(int index) wurde hinzugefügt, um eine Diagrammkategorie nach ihrem Index zu entfernen.
### **Der Wert PptXPptY wurde zur Enumeration com.aspose.slides.PropertyType hinzugefügt**
Der Wert PptXPptY wurde zur Enumeration com.aspose.slides.PropertyType im Rahmen einer Behebung eines Serialisierungsproblems hinzugefügt.