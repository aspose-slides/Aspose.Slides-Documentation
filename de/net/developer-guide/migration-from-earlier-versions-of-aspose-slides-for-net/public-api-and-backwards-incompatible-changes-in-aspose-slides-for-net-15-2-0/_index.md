---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 15.2.0
type: docs
weight: 140
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) oder [entfernten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) Klassen, Methoden, Eigenschaften usw. sowie andere Änderungen auf, die mit der Aspose.Slides für .NET 15.2.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Die Methoden AddDataPointForDoughnutSeries wurden hinzugefügt**
Die zwei Überladungen der Methode IChartDataPointCollection.AddDataPointForDoughnutSeries() wurden hinzugefügt, um Datenpunkte in Serien des Typs Doughnut-Diagramm hinzuzufügen.
#### **Die Klasse Aspose.Slides.SmartArt.SmartArtShape wurde von der Klasse Aspose.Slides.GeometryShape abgeleitet**
Die Klasse Aspose.Slides.SmartArt.SmartArtShape wurde von der Klasse Aspose.Slides.GeometryShape abgeleitet. Diese Änderung verbessert das Aspose.Slides-Objektmodell und fügt der Klasse SmartArtShape neue Funktionen hinzu.
#### **Methoden zum Entfernen von Diagrammdatenpunkten und Diagrammkategorien nach Index wurden hinzugefügt**
Die Methode IChartDataPointCollection.RemoveAt(int index) wurde hinzugefügt, um Diagrammdatenpunkte nach ihrem Index zu entfernen.
Die Methode IChartCategoryCollection.RemoveAt(int index) wurde hinzugefügt, um Diagrammkategorien nach ihrem Index zu entfernen.
#### **PptXPptY-Wert wurde zur Aufzählung Aspose.Slides.Animation.PropertyType hinzugefügt**
Der PptXPptY-Wert wurde zur Aufzählung Aspose.Slides.Animation.PropertyType im Rahmen der Behebung eines Serialisierungsproblems hinzugefügt.
#### **Die Methode System.Drawing.Color GetAutomaticSeriesColor() wurde zu Aspose.Slides.Charts.IChartSeries hinzugefügt**
Die Methode GetAutomaticSeriesColor gibt eine automatische Farbe der Serie basierend auf dem Serienindex und dem Diagrammstil zurück. Diese Farbe wird standardmäßig verwendet, wenn FillType NotDefined entspricht.

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