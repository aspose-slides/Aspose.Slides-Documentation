---
title: Öffentliche API- und abwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.2.0
linktitle: Aspose.Slides für .NET 15.2.0
type: docs
weight: 140
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- Migration
- Legacy-Code
- Moderne Code
- Legacy-Ansatz
- Moderne Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über öffentliche API-Updates und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.2.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **AddDataPointForDoughnutSeries-Methoden wurden hinzugefügt**
Die beiden Überladungen der Methode IChartDataPointCollection.AddDataPointForDoughnutSeries() wurden hinzugefügt, um Datenpunkte in Serien des Doughnut-Diagrammtyps einzufügen.
#### **Die Klasse Aspose.Slides.SmartArt.SmartArtShape wurde von der Klasse Aspose.Slides.GeometryShape abgeleitet**
Die Klasse Aspose.Slides.SmartArt.SmartArtShape wurde von der Klasse Aspose.Slides.GeometryShape abgeleitet. Diese Änderung verbessert das Aspose.Slides‑Objektmodell und fügt der Klasse SmartArtShape neue Funktionen hinzu.
#### **Methoden zum Entfernen von Diagrammdatenpunkten und Diagrammkategorien nach Index wurden hinzugefügt**
Die Methode IChartDataPointCollection.RemoveAt(int index) wurde hinzugefügt, um einen Diagrammdatenpunkt nach seinem Index zu entfernen.
Die Methode IChartCategoryCollection.RemoveAt(int index) wurde hinzugefügt, um eine Diagrammkategorie nach ihrem Index zu entfernen.
#### **Der Wert PptXPptY wurde zur Aufzählung Aspose.Slides.Animation.PropertyType hinzugefügt**
Der Wert PptXPptY wurde zur Aufzählung Aspose.Slides.Animation.PropertyType im Rahmen einer Fehlerbehebung bei der Serialisierung hinzugefügt.
#### **Die Methode System.Drawing.Color GetAutomaticSeriesColor() wurde zu Aspose.Slides.Charts.IChartSeries hinzugefügt**
Die Methode GetAutomaticSeriesColor gibt eine automatische Farbe der Serie zurück, basierend auf dem Serienindex und dem Diagrammstil. Diese Farbe wird standardmäßig verwendet, wenn FillType den Wert NotDefined hat.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

```