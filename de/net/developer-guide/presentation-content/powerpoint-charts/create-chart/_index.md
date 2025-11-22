---
title: Erstellen oder Aktualisieren von PowerPoint-Präsentationsdiagrammen in C#
linktitle: Ein Diagramm erstellen oder aktualisieren
type: docs
weight: 10
url: /de/net/create-chart/
keywords:
- Diagramm hinzufügen
- Diagramm erstellen
- Diagramm bearbeiten
- Diagramm ändern
- Diagramm aktualisieren
- Streudiagramm
- Kuchendiagramm
- Liniendiagramm
- Baumkartendiagramm
- Börsendiagramm
- Box‑und‑Whisker‑Diagramm
- Trichterdiagramm
- Sonnenburst‑Diagramm
- Histogramm
- Radar‑Diagramm
- Mehrkategorie‑Diagramm
- PowerPoint‑Präsentation
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET erstellen und anpassen. Es behandelt das Hinzufügen, Formatieren und Bearbeiten von Diagrammen in Präsentationen mit praktischen Codebeispielen in C#."
---

## **Übersicht**

Dieser Artikel bietet eine umfassende Anleitung, wie man Diagramme mit Aspose.Slides für .NET erstellt und anpasst. Sie lernen, wie man programmgesteuert ein Diagramm zu einer Folie hinzufügt, es mit Daten füllt und verschiedene Formatierungsoptionen anwendet, um Ihren spezifischen Designanforderungen zu entsprechen. Im gesamten Artikel veranschaulichen detaillierte Codebeispiele jeden Schritt, von der Initialisierung der Präsentation und des Diagrammobjekts bis zur Konfiguration von Reihen, Achsen und Legenden. Durch Befolgen dieser Anleitung erhalten Sie ein solides Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre .NET‑Anwendungen integrieren und den Prozess der Erstellung datenbasierter Präsentationen optimieren.

## **Diagramm erstellen**

Diagramme helfen Menschen, Daten schnell zu visualisieren und Einsichten zu gewinnen, die aus einer Tabelle oder einem Arbeitsblatt nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie:

* große Datenmengen auf einer einzigen Folie einer Präsentation aggregieren, komprimieren oder zusammenfassen;
* Muster und Trends in Daten aufdecken;
* die Richtung und Dynamik von Daten über die Zeit oder in Bezug auf eine bestimmte Maßeinheit ableiten;
* Ausreißer, Anomalien, Abweichungen, Fehler und unsinnige Daten erkennen;
* komplexe Daten kommunizieren oder präsentieren.

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für viele Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="primary" %}} 
Verwenden Sie die [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)‑Aufzählung im [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/)-Namensraum. Die Werte dieser Aufzählung entsprechen verschiedenen Diagrammtypen.
{{% /alert %}} 

### **Gruppierte Säulendiagramme erstellen**

Dieser Abschnitt erklärt, wie man gruppierte Säulendiagramme mit Aspose.Slides für .NET erstellt. Sie lernen, wie Sie eine Präsentation initialisieren, ein Diagramm hinzufügen und dessen Elemente wie Titel, Daten, Reihen, Kategorien und Stil anpassen. Folgen Sie den untenstehenden Schritten, um zu sehen, wie ein Standard‑Gruppiertes‑Säulendiagramm erzeugt wird:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie den Typ `ChartType.ClusteredColumn` an.
1. Fügen Sie dem Diagramm einen Titel hinzu.
1. Greifen Sie auf das Daten‑Worksheet des Diagramms zu.
1. Löschen Sie alle Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Wenden Sie eine Füllfarbe auf die Diagramm‑Reihen an.
1. Fügen Sie Beschriftungen zu den Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert, wie man ein gruppiertes Säulendiagramm erstellt:
```c#
// Instanziieren der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    // Auf die erste Folie zugreifen.
    ISlide slide = presentation.Slides[0];

    // Gruppiertes Säulendiagramm mit Standarddaten hinzufügen.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Diagrammtitel festlegen.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Erste Serie so einstellen, dass Werte angezeigt werden.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Index des Diagrammdatensheets festlegen.
    int worksheetIndex = 0;

    // Diagrammdaten-Workbook abrufen.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Standardgenerierte Serien und Kategorien löschen.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Neue Serien hinzufügen.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Neue Kategorien hinzufügen.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Erste Diagrammserie abrufen.
    IChartSeries series = chart.ChartData.Series[0];

    // Daten der Serie füllen.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Füllfarbe für die Serie festlegen.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Zweite Diagrammserie abrufen.
    series = chart.ChartData.Series[1];

    // Daten der Serie füllen.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Füllfarbe für die Serie festlegen.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Erstes Label so einstellen, dass der Kategorienname angezeigt wird.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Serie so einstellen, dass für das dritte Label der Wert angezeigt wird.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Präsentation als PPTX-Datei auf Festplatte speichern.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das gruppierte Säulendiagramm](clustered_column_chart.png)

### **Streudiagramme erstellen**

Streudiagramme (auch Scatter‑Plots oder X‑Y‑Diagramme genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu zeigen.

Verwenden Sie ein Streudiagramm, wenn:

* Sie gepaarte numerische Daten haben.
* Sie zwei Variablen haben, die gut zusammenpassen.
* Sie feststellen möchten, ob die beiden Variablen miteinander verbunden sind.
* Sie eine unabhängige Variable besitzen, die für eine abhängige Variable mehrere Werte hat.

Dieser C#‑Code zeigt, wie Sie ein Streudiagramm mit unterschiedlichen Markerserien erstellen:
```c#
// Instanziieren der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    // Auf die erste Folie zugreifen.
    ISlide slide = presentation.Slides[0];

    // Standard-Streudiagramm erstellen.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Index des Diagrammdatensheets festlegen.
    int worksheetIndex = 0;

    // Diagrammdaten-Workbook abrufen.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Standardserie löschen.
    chart.ChartData.Series.Clear();

    // Neue Serien hinzufügen.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Erste Diagrammserie abrufen.
    IChartSeries series = chart.ChartData.Series[0];

    // Neuen Punkt (1:3) zur Serie hinzufügen.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Neuen Punkt (2:10) hinzufügen.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Serientyp ändern.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Diagrammserien-Marker ändern.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Zweite Diagrammserie abrufen.
    series = chart.ChartData.Series[1];

    // Neuen Punkt (5:2) zur Diagrammserie hinzufügen.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Neuen Punkt (3:1) hinzufügen.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Neuen Punkt (2:2) hinzufügen.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Neuen Punkt (5:1) hinzufügen.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Diagrammserien-Marker ändern.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Präsentation als PPTX-Datei auf Festplatte speichern.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Streudiagramm](scatter_chart.png)

### **Kuchendiagramme erstellen**

Kuchendiagramme eignen sich am besten, um das Verhältnis von Teil zu Ganzem zu zeigen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Enthält Ihre Datenmenge jedoch viele Teile oder Beschriftungen, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.Pie` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Fügen Sie neue Punkte für das Diagramm hinzu und wenden Sie benutzerdefinierte Farben auf die Segmente des Kuchendiagramms an.
1. Setzen Sie Beschriftungen für die Reihen.
1. Aktivieren Sie Führungs‑Linien für die Reihenbeschriftungen.
1. Legen Sie den Rotationswinkel für das Kuchendiagramm fest.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Kuchendiagramm erstellen:
```c#
// Instanziieren der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    // Auf die erste Folie zugreifen.
    ISlide slide = presentation.Slides[0];

    // Diagramm mit Standarddaten hinzufügen.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Diagrammtitel festlegen.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Erste Serie so einstellen, dass Werte angezeigt werden.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Index des Diagrammdatensheets festlegen.
    int worksheetIndex = 0;

    // Diagrammdaten-Workbook abrufen.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Standardgenerierte Serien und Kategorien löschen.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Neue Kategorien hinzufügen.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Neue Serien hinzufügen.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Daten der Serie füllen.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Segmentfarbe festlegen.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Segmentrand festlegen.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Segmentrand festlegen.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Segmentrand festlegen.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Benutzerdefinierte Beschriftungen für jede Kategorie in der neuen Serie erstellen.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Serie so einstellen, dass Führungslinien für das Diagramm angezeigt werden.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Rotationswinkel für die Kuchendiagrammsegmente festlegen.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Präsentation als PPTX-Datei auf Festplatte speichern.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Kuchendiagramm](pie_chart.png)

### **Liniendiagramme erstellen**

Liniendiagramme (auch Liniendiagramme genannt) eignen sich am besten, wenn Sie Änderungen des Wertes über die Zeit darstellen möchten. Mit einem Liniendiagramm können Sie viele Daten gleichzeitig vergleichen, Änderungen und Trends über die Zeit verfolgen, Anomalien in Datenreihen hervorheben und mehr.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.Line` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Liniendiagramm erstellen:
```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```


Standardmäßig werden Punkte in einem Liniendiagramm durch gerade kontinuierliche Linien verbunden. Wenn Sie die Punkte stattdessen durch Striche verbinden möchten, können Sie den gewünschten Strichtyp wie folgt angeben:
```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```


Das Ergebnis:

![Das Liniendiagramm](line_chart.png)

### **Baumkartendiagramme erstellen**

Baumkartendiagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und schnell auf große Beitragsleister innerhalb jeder Kategorie aufmerksam machen möchten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.Treemap` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Baumkarten‑Diagramm erstellen:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Zweig 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Zweig 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Baumkarten‑Diagramm](treemap_chart.png)

### **Börsendiagramme erstellen**

Börsendiagramme werden verwendet, um Finanzdaten wie Eröffnungs-, Hoch‑, Tief‑ und Schlusskurse darzustellen und so Markttrends sowie Volatilität zu analysieren. Sie liefern wichtige Einblicke in die Kursentwicklung und unterstützen Investoren und Analysten bei fundierten Entscheidungen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.OpenHighLowClose` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Legen Sie das Format der HiLowLines fest.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Börsendiagramm erstellen:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Börsendiagramm](stock_chart.png)

### **Kasten‑ und Whisker‑Diagramme erstellen**

Kasten‑ und Whisker‑Diagramme werden verwendet, um die Verteilung von Daten darzustellen, indem zentrale statistische Kennzahlen wie Median, Quartile und mögliche Ausreißer zusammengefasst werden. Sie sind besonders nützlich in explorativen Datenanalysen und statistischen Studien, um schnell die Datenvariabilität zu verstehen und Anomalien zu identifizieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.BoxAndWhisker` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Kasten‑ und Whisker‑Diagramm erstellen:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```


### **Trichterdiagramme erstellen**

Trichterdiagramme visualisieren Prozesse mit aufeinanderfolgenden Stufen, bei denen das Datenvolumen von einer Stufe zur nächsten abnimmt. Sie sind besonders hilfreich, um Konversionsraten zu analysieren, Engpässe zu identifizieren und die Effizienz von Vertriebs‑ oder Marketingprozessen zu verfolgen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.Funnel` an.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Trichterdiagramm erstellen:
```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Trichterdiagramm](funnel_chart.png)

### **Sonnenbrunnen‑Diagramme erstellen**

Sonnenbrunnen‑Diagramme visualisieren hierarchische Daten, indem Ebenen als konzentrische Ringe dargestellt werden. Sie verdeutlichen Teil‑zu‑Ganz‑Beziehungen und eignen sich ideal, um verschachtelte Kategorien und Unterkategorien kompakt darzustellen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.Sunburst` an.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Sonnenbrunnen‑Diagramm erstellen:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Zweig 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Zweig 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Sonnenbrunnen‑Diagramm](sunburst_chart.png)

### **Histogramm‑Diagramme erstellen**

Histogramm‑Diagramme stellen die Verteilung numerischer Daten dar, indem Werte in Klassen (Bins) gruppiert werden. Sie sind besonders nützlich, um Muster wie Häufigkeit, Schiefe und Streuung zu erkennen und Ausreißer in einem Datensatz zu entdecken.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie den Typ `ChartType.Histogram` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Histogramm‑Diagramm erstellen:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Histogramm‑Diagramm](histogram_chart.png)

### **Radar‑Diagramme erstellen**

Radar‑Diagramme visualisieren multivariate Daten in einem zweidimensionalen Format und ermöglichen einen einfachen Vergleich mehrerer Variablen gleichzeitig. Sie sind besonders nützlich, um Muster, Stärken und Schwächen über verschiedene Leistungskennzahlen hinweg zu identifizieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie den Typ `ChartType.Radar` an.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Radar‑Diagramm erstellen:
```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Radar‑Diagramm](radar_chart.png)

### **Mehrkategorie‑Diagramme erstellen**

Mehrkategorie‑Diagramme visualisieren Daten, die mehr als eine kategoriale Gruppierung enthalten, sodass Werte über mehrere Dimensionen hinweg verglichen werden können. Sie sind besonders hilfreich, wenn komplexe, mehrschichtige Datensätze analysiert werden sollen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.ClusteredColumn` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Mehrkategorie‑Diagramm erstellen:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Eine Serie hinzufügen.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Präsentation mit dem Diagramm speichern.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Mehrkategorie‑Diagramm](multi_category_chart.png)

### **Karten‑Diagramme erstellen**

Karten‑Diagramme visualisieren geografische Daten, indem Informationen bestimmten Orten wie Ländern, Bundesländern oder Städten zugeordnet werden. Sie eignen sich besonders, um regionale Trends, demografische Daten und räumliche Verteilungen klar und ansprechend darzustellen.

Dieser C#‑Code zeigt, wie Sie ein Karten‑Diagramm erstellen:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Karten‑Diagramm](map_chart.png)

### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es, Unterschiede zwischen zwei oder mehreren Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen und so Beziehungen zwischen ihnen zu erkennen.

![Das Kombinations‑Diagramm](combination_chart.png)

Der folgende C#‑Code zeigt, wie das oben gezeigte Kombinations‑Diagramm in einer PowerPoint‑Präsentation erstellt wird:
```c#
private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Legt den Diagrammtitel fest
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Legt die Diagrammlegende fest
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Löscht die standardmäßig erzeugten Serien und Kategorien
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Fügt neue Kategorien hinzu
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Fügt die erste Serie hinzu
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Legt die horizontale Achse fest
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Legt die vertikale Achse fest
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Legt die Farbe der vertikalen Hauptgitternetzlinien fest
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Legt die sekundäre horizontale Achse fest
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Legt die sekundäre vertikale Achse fest
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```


## **Diagramme aktualisieren**

Aspose.Slides für .NET ermöglicht es Ihnen, PowerPoint‑Diagramme zu aktualisieren, indem Sie Diagrammdaten, Formatierungen und Stile ändern. Diese Funktion vereinfacht das Aktualisieren von Präsentationen mit dynamischen Inhalten und stellt sicher, dass Diagramme aktuelle Daten und visuelle Standards korrekt wiedergeben.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, die die Präsentation mit dem Diagramm repräsentiert.
1. Rufen Sie über den Index eine Folie ab.
1. Durchsuchen Sie alle Formen, um das Diagramm zu finden.
1. Greifen Sie auf das Daten‑Worksheet des Diagramms zu.
1. Ändern Sie die Diagrammdatenreihen, indem Sie die Reihenwerte anpassen.
1. Fügen Sie eine neue Reihe hinzu und füllen Sie deren Daten.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Diagramm aktualisieren:
```c#
const string chartName = "My chart";

// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Auf die erste Folie zugreifen.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Index des Diagrammdatensheets festlegen.
            int worksheetIndex = 0;

            // Diagrammdaten-Workbook abrufen.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Diagrammkategorienamen ändern.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Erste Diagrammserie abrufen.
            IChartSeries series = chart.ChartData.Series[0];

            // Seriendaten aktualisieren.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Seriennamen ändern.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Zweite Diagrammserie abrufen.
            series = chart.ChartData.Series[1];

            // Seriendaten aktualisieren.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Seriennamen ändern.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Neue Serie hinzufügen.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Serien-Daten befüllen.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Präsentation mit dem Diagramm speichern.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```


## **Datenbereich für Diagramme festlegen**

Aspose.Slides für .NET bietet die Möglichkeit, einen bestimmten Datenbereich aus einem Arbeitsblatt als Quelle für die Diagrammdaten festzulegen. Das bedeutet, dass Sie einen Teil Ihres Arbeitsblatts direkt dem Diagramm zuordnen können, wodurch Sie steuern, welche Zellen zu den Reihen und Kategorien des Diagramms beitragen. Dadurch können Sie Ihre Diagramme einfach aktualisieren und mit den neuesten Datenänderungen im Arbeitsblatt synchronisieren, sodass Ihre PowerPoint‑Präsentationen stets aktuelle und genaue Informationen widerspiegeln.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, die die Präsentation mit dem Diagramm repräsentiert.
1. Rufen Sie über den Index eine Folie ab.
1. Durchsuchen Sie alle Formen, um das Diagramm zu finden.
1. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie den Datenbereich für ein Diagramm festlegen:
```c#
const string chartName = "My chart";

// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Auf die erste Folie zugreifen.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```


## **Standard‑Marker in Diagrammen verwenden**

Wenn Sie Standard‑Marker in Diagrammen verwenden, erhält jede Diagrammreihe automatisch ein anderes Standardsymbol.

Dieser C#‑Code zeigt, wie Sie einen Diagrammreihen‑Marker automatisch festlegen:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Seriendaten befüllen.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```


## **FAQs**

**Welche Diagrammtypen werden von Aspose.Slides für .NET unterstützt?**

Aspose.Slides für .NET unterstützt eine breite Palette von Diagrammtypen, darunter Balken, Linien, Kuchen, Flächen, Streu, Histogramm, Radar und viele weitere. Diese Flexibilität ermöglicht es Ihnen, den am besten geeigneten Diagrammtyp für Ihre Datenvisualisierung auszuwählen.

**Wie füge ich ein neues Diagramm zu einer Folie hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, rufen die gewünschte Folie über deren Index ab und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf das Daten‑Workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) zugreifen, Standard‑Reihen und -Kategorien löschen und anschließend Ihre eigenen Daten hinzufügen. So können Sie das Diagramm programmgesteuert aktualisieren, sodass es die neuesten Daten widerspiegelt.

**Ist es möglich, das Aussehen des Diagramms anzupassen?**

Ja, Aspose.Slides für .NET bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere Formatierungselemente ändern, um das Aussehen des Diagramms an Ihre spezifischen Designanforderungen anzupassen.