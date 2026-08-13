---
title: Öffentliche API und abwärtsinkompatible Änderungen in Aspose.Slides für Java 15.2.0
linktitle: Aspose.Slides für Java 15.2.0
type: docs
weight: 110
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- Migration
- Legacy-Code
- Moderne Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überblick über Aktualisierungen der öffentlichen API und kritische Änderungen in Aspose.Slides für Java, um Ihre PowerPoint PPT, PPTX und ODP-Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 
Diese Seite listet alle [hinzugefügt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) Klassen, Methoden, Eigenschaften usw. sowie alle neuen Einschränkungen und anderen [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) ein, die mit der Aspose.Slides for Java 15.2.0 API eingeführt wurden.
{{% /alert %}} {{% alert color="info" %}} 
Bekannte Probleme mit einigen Bild‑Aufzählungszeichen und WordArt‑Objekten, die in Aspose.Slides for Java 15.2.0 behoben werden.
{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **addDataPointForDoughnutSeries-Methoden wurden hinzugefügt**
Die beiden Überladungen der Methode IChartDataPointCollection.addDataPointForDoughnutSeries() wurden hinzugefügt, um Datenpunkte zu Serien vom Typ Doughnut hinzuzufügen.
### **Die Klasse com.aspose.slides.SmartArtShape wurde von der Klasse com.aspose.slides.GeometryShape abgeleitet**
Die Klasse com.aspose.slides.SmartArtShape wurde von der Klasse com.aspose.slides.GeometryShape abgeleitet. Diese Änderung verbessert das Objektmodell von Aspose.Slides und fügt der Klasse SmartArtShape neue Funktionen hinzu.
### **IGradientStopCollection.add(...) und IGradientStopCollection.insert(...) Methoden wurden geändert**
Die Signatur von IGradientStop add(float position, int presetColor) wurde durch die Signatur IGradientStop addPresetColor(float position, int presetColor) ersetzt.
Die Signatur der IGradientStopCollection‑Methode IGradientStop add(float position, SchemeColor schemeColor) wurde durch die Signatur IGradientStop addSchemeColor(float position, int schemeColor) ersetzt.
Die Signatur der IGradientStopCollection‑Methode void insert(int index, float position, int presetColor) wurde durch die Signatur void insertPresetColor(int index, float position, int presetColor) ersetzt.
Die Signatur der IGradientStopCollection‑Methode void insert(int index, float position, SchemeColor schemeColor) wurde durch die Signatur void insertSchemeColor(int index, float position, int schemeColor) ersetzt.
### **Methode java.awt.Color getAutomaticSeriesColor() wurde zu com.aspose.slides.IChartSeries hinzugefügt**
Die Methode getAutomaticSeriesColor() gibt eine automatische Farbe einer Serie zurück, basierend auf dem Serienindex und dem Diagrammstil. Diese Farbe wird standardmäßig verwendet, wenn FillType gleich NotDefined ist.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Methode zum Entfernen von Diagrammdatenpunkten und Diagrammkategorien nach Index wurde hinzugefügt**
Die Methode IChartDataPointCollection.removeAt(int index) wurde hinzugefügt, um einen Diagrammdatenpunkt nach seinem Index zu entfernen.
Die Methode IChartCategoryCollection.removeAt(int index) wurde hinzugefügt, um eine Diagrammkategorie nach ihrem Index zu entfernen.
### **Der Wert PptXPptY wurde zur Aufzählung com.aspose.slides.PropertyType hinzugefügt**
Der Wert PptXPptY wurde zur Aufzählung com.aspose.slides.PropertyType im Rahmen einer Korrektur eines Serialisierungsproblems hinzugefügt.