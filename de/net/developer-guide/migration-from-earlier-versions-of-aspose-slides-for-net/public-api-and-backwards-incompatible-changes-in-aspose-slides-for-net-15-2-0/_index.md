---
title: Öffentliche API und abwärts inkompatible Änderungen in Aspose.Slides für .NET 15.2.0
linktitle: Aspose.Slides für .NET 15.2.0
type: docs
weight: 140
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über öffentliche API‑Aktualisierungen und abwärts inkompatible Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 
Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.2.0 API eingeführt wurden.
{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **AddDataPointForDoughnutSeries-Methoden wurden hinzugefügt**
Die beiden Überladungen der Methode IChartDataPointCollection.AddDataPointForDoughnutSeries() wurden hinzugefügt, um Datenpunkte zu Serien des Doughnut-Diagrammtyps hinzuzufügen.
#### **Die Klasse Aspose.Slides.SmartArt.SmartArtShape wurde von der Klasse Aspose.Slides.GeometryShape abgeleitet**
Die Klasse Aspose.Slides.SmartArt.SmartArtShape wurde von der Klasse Aspose.Slides.GeometryShape abgeleitet. Diese Änderung verbessert das Objektmodell von Aspose.Slides und fügt der Klasse SmartArtShape neue Funktionen hinzu.
#### **Methoden zum Entfernen von Diagrammdatenpunkten und Diagrammkategorien nach Index wurden hinzugefügt**
Die Methode IChartDataPointCollection.RemoveAt(int index) wurde hinzugefügt, um einen Diagrammdatenpunkt anhand seines Index zu entfernen.
Die Methode IChartCategoryCollection.RemoveAt(int index) wurde hinzugefügt, um eine Diagrammkategorie anhand ihres Index zu entfernen.
#### **Der Wert PptXPptY wurde zur Aufzählung Aspose.Slides.Animation.PropertyType hinzugefügt**
Der Wert PptXPptY wurde zur Aufzählung Aspose.Slides.Animation.PropertyType im Rahmen einer Fehlerbehebung bei der Serialisierung hinzugefügt.
#### **Die Methode System.Drawing.Color GetAutomaticSeriesColor() wurde zu Aspose.Slides.Charts.IChartSeries hinzugefügt**
Die Methode GetAutomaticSeriesColor gibt eine automatische Farbe einer Serie zurück, basierend auf dem Serienindex und dem Diagrammstil. Diese Farbe wird standardmäßig verwendet, wenn FillType gleich NotDefined ist.
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```