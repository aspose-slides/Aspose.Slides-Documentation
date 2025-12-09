---
title: Öffentliche API- und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.2.0
linktitle: Aspose.Slides für .NET 15.2.0
type: docs
weight: 140
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- Migration
- Legacy-Code
- Moderne Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über Aktualisierungen der öffentlichen API und inkompatible Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT‑, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.2.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **AddDataPointForDoughnutSeries‑Methoden wurden hinzugefügt**
Die beiden Überladungen der Methode IChartDataPointCollection.AddDataPointForDoughnutSeries() wurden hinzugefügt, um Datenpunkte zu Serien des Doughnut‑Diagrammtyps hinzuzufügen.
#### **Aspose.Slides.SmartArt.SmartArtShape‑Klasse wurde von Aspose.Slides.GeometryShape geerbt**
Aspose.Slides.SmartArt.SmartArtShape‑Klasse wurde von Aspose.Slides.GeometryShape‑Klasse geerbt. Diese Änderung verbessert das Aspose.Slides‑Objektmodell und fügt neue Funktionen zur SmartArtShape‑Klasse hinzu.
#### **Methoden zum Entfernen von Diagrammdatenpunkten und Diagrammkategorien nach Index wurden hinzugefügt**
IChartDataPointCollection.RemoveAt(int index)‑Methode wurde hinzugefügt, um ein Diagrammdatenpunkt nach seinem Index zu entfernen.  
IChartCategoryCollection.RemoveAt(int index)‑Methode wurde hinzugefügt, um eine Diagrammkategorie nach ihrem Index zu entfernen.
#### **PptXPptY‑Wert wurde zur Aufzählung Aspose.Slides.Animation.PropertyType hinzugefügt**
PptXPptY‑Wert wurde zur Aufzählung Aspose.Slides.Animation.PropertyType im Rahmen einer Fehlerbehebung für Serialisierungsprobleme hinzugefügt.
#### **System.Drawing.Color GetAutomaticSeriesColor()‑Methode wurde zu Aspose.Slides.Charts.IChartSeries hinzugefügt**
GetAutomaticSeriesColor‑Methode gibt eine automatische Farbe der Serie zurück, basierend auf dem Serienindex und Diagrammstil. Diese Farbe wird standardmäßig verwendet, wenn FillType gleich NotDefined ist.

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