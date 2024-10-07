---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für Java 15.2.0
type: docs
weight: 110
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) Klassen, Methoden, Eigenschaften und so weiter, alle neuen Einschränkungen und andere [Änderungen](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) auf, die mit der Aspose.Slides für Java 15.2.0 API eingeführt wurden.

{{% /alert %}} {{% alert color="primary" %}} 

Es gibt bekannte Probleme mit einigen Bildaufzählungszeichen und WordArt-Objekten, die in Aspose.Slides für Java 15.2.0 behoben werden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **addDataPointForDoughnutSeries-Methoden wurden hinzugefügt**
Die beiden Überladungen der IChartDataPointCollection.addDataPointForDoughnutSeries() Methode wurden hinzugefügt, um Datenpunkte in Serien vom Donut-Typ hinzuzufügen.
### **Die Klasse com.aspose.slides.SmartArtShape wurde von der Klasse com.aspose.slides.GeometryShape abgeleitet**
Die Klasse com.aspose.slides.SmartArtShape wurde von der Klasse com.aspose.slides.GeometryShape abgeleitet. Diese Änderung verbessert das Objektmodell von Aspose.Slides und fügt der Klasse SmartArtShape neue Funktionen hinzu.
### **IGradientStopCollection.add(...) und IGradientStopCollection.insert(...) Methoden wurden geändert**
Die Signatur von IGradientStop add(float position, int presetColor) wurde durch die Signatur IGradientStop addPresetColor(float position, int presetColor) ersetzt.

Die Signatur der Methode IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) wurde durch die Signatur IGradientStop addSchemeColor(float position, int schemeColor) ersetzt.

Die Signatur der Methode IGradientStopCollection void insert(int index, float position, int presetColor) wurde durch die Signatur void insertPresetColor(int index, float position, int presetColor) ersetzt.

Die Signatur der Methode IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) wurde durch die Signatur void insertSchemeColor(int index, float position, int schemeColor) ersetzt.
### **java.awt.Color getAutomaticSeriesColor() Methode wurde zu com.aspose.slides.IChartSeries hinzugefügt**
Die Methode getAutomaticSeriesColor() gibt eine automatische Farbe der Serie basierend auf dem Serienindex und dem Diagrammstil zurück. Diese Farbe wird standardmäßig verwendet, wenn FillType NotDefined entspricht.
﻿

``` java

 Präsentation pres = new Präsentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Methode zum Entfernen eines Diagramm-Datenpunkts und einer Diagramm-Kategorie nach ihrem Index wurde hinzugefügt**
Die Methode IChartDataPointCollection.removeAt(int index) wurde hinzugefügt, um einen Diagramm-Datenpunkt nach seinem Index zu entfernen.
Die Methode IChartCategoryCollection.removeAt(int index) wurde hinzugefügt, um eine Diagramm-Kategorie nach ihrem Index zu entfernen.
### **PptXPptY-Wert wurde zur Aufzählung com.aspose.slides.PropertyType hinzugefügt**
Der PptXPptY-Wert wurde zur Aufzählung com.aspose.slides.PropertyType im Rahmen der Behebung eines Serialisierungsproblems hinzugefügt.