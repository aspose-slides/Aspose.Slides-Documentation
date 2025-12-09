---
title: Öffentliche API- und abwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.2.0
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
description: "Überblick über öffentliche API-Updates und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP-Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [added](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) oder [removed](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 15.2.0 API eingeführt wurden.

{{% /alert %}} 
## **Public API Changes**
#### **AddDataPointForDoughnutSeries methods have been added**
Die beiden Überladungen der Methode IChartDataPointCollection.AddDataPointForDoughnutSeries() wurden hinzugefügt, um Datenpunkte in Serien des Doughnut‑Diagrammtyps einzufügen.
#### **Aspose.Slides.SmartArt.SmartArtShape class has been inherited from Aspose.Slides.GeometryShape class**
Die Klasse Aspose.Slides.SmartArt.SmartArtShape erbt jetzt von der Klasse Aspose.Slides.GeometryShape. Diese Änderung verbessert das Aspose.Slides‑Objektmodell und erweitert die Funktionen der SmartArtShape‑Klasse.
#### **Methods for removing chart data point and chart category by index has been added**
Die Methode IChartDataPointCollection.RemoveAt(int index) wurde hinzugefügt, um einen Diagrammdatenpunkt anhand seines Index zu entfernen.
Die Methode IChartCategoryCollection.RemoveAt(int index) wurde hinzugefügt, um eine Diagrammkategorie anhand ihres Index zu entfernen.
#### **PptXPptY value has been added to Aspose.Slides.Animation.PropertyType enumeration**
Der Wert PptXPptY wurde der Aufzählung Aspose.Slides.Animation.PropertyType hinzugefügt, um ein Serialisierungsproblem zu beheben.
#### **System.Drawing.Color GetAutomaticSeriesColor() method has been added to Aspose.Slides.Charts.IChartSeries**
Die Methode GetAutomaticSeriesColor liefert eine automatische Farbe für eine Serie basierend auf dem Serien‑Index und dem Diagrammstil. Diese Farbe wird standardmäßig verwendet, wenn FillType gleich NotDefined ist.

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