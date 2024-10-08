---
title: Erstellen oder Aktualisieren von PowerPoint-Präsentationsdiagrammen in C# oder .NET
linktitle: Diagramm erstellen oder aktualisieren
type: docs
weight: 10
url: /net/create-chart/
keywords: "Diagramm erstellen, Streudiagramm, Kreisdiagramm, Baumkarten-Diagramm, Aktiendurchschnitt, Box-and-Whisker-Diagramm, Histogramm-Diagramm, Trichterdiagramm, Sonnenstrahl-Diagramm, Multikategoriendiagramm, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Diagramm in PowerPoint-Präsentation in C# oder .NET erstellen"
---

## **Diagramm erstellen**
Diagramme helfen Menschen, Daten schnell zu visualisieren und Einblicke zu gewinnen, die möglicherweise nicht sofort aus einer Tabelle oder einem Spreadsheet offensichtlich sind. 

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie

* große Datenmengen auf einer einzelnen Folie in einer Präsentation aggregieren, zusammenfassen oder zusammenfassen
* Muster und Trends in Daten aufdecken
* die Richtung und Dynamik von Daten im Laufe der Zeit oder in Bezug auf eine spezielle Maßeinheit ableiten 
* Ausreißer, Abweichungen, Fehler, unsinnige Daten usw. erkennen 
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die Einfügefunktion erstellen, die Vorlagen bereitstellt, die zur Gestaltung verschiedener Diagrammtypen verwendet werden. Mit Aspose.Slides können Sie reguläre Diagramme (basierend auf beliebten Diagrammtypen) und benutzerdefinierte Diagramme erstellen. 

{{% alert color="primary" %}} 

Um Ihnen die Erstellung von Diagrammen zu ermöglichen, stellt Aspose.Slides die [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) Enumeration im [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) Namespace zur Verfügung. Die Werte dieser Enumeration entsprechen verschiedenen Diagrammtypen. 

{{% /alert %}} 

### **Normale Diagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und wählen Sie Ihren bevorzugten Diagrammtyp aus. 
1. Fügen Sie einen Titel für das Diagramm hinzu. 
1. Greifen Sie auf das Datenarbeitsblatt des Diagramms zu.
1. Löschen Sie alle Standardserien und -kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie einige neue Diagrammdaten für die Diagrammserien hinzu.
1. Fügen Sie eine Füllfarbe für die Diagrammserien hinzu.
1. Fügen Sie Beschriftungen für die Diagrammserien hinzu. 
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt, wie man ein normales Diagramm erstellt:

```c#
// Erstellt die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();

// Greift auf die erste Folie zu
ISlide sld = pres.Slides[0];

// Fügt ein Diagramm mit den Standarddaten hinzu
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

// Setzt den Diagrammtitel
chart.ChartTitle.AddTextFrameForOverriding("Beispieltitel");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Setzt die erste Serie, um Werte anzuzeigen
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// Setzt den Index für das Diagrammdatenblatt
int defaultWorksheetIndex = 0;

// Holt sich das Diagrammdatenarbeitsblatt
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Löscht die standardmäßig generierten Serien und Kategorien
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

// Fügt neue Serien hinzu
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

// Fügt neue Kategorien hinzu
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Kategorie 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Kategorie 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Kategorie 3"));

// Nimmt die erste Diagrammserie
IChartSeries series = chart.ChartData.Series[0];

// Füllt die Seriendaten

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// Setzt die Füllfarbe für die Serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


// Nimmt die zweite Diagrammserie
series = chart.ChartData.Series[1];

// Füllt die Seriendaten
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Setzt die Füllfarbe für die Serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

// Setzt die erste Beschriftung, um den Kategorienamen anzuzeigen
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

// Setzt die Serie, um den Wert für die dritte Beschriftung anzuzeigen
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";
            
// Speichert die PPTX-Datei auf der Festplatte
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```


### **Streudiagramme erstellen**
Streudiagramme (auch bekannt als Streudiagramme oder x-y-Diagramme) werden häufig verwendet, um nach Mustern zu suchen oder Korrelationen zwischen zwei Variablen zu demonstrieren.

Sie möchten möglicherweise ein Streudiagramm verwenden, wenn 

* Sie gepaarte numerische Daten haben
* Sie 2 Variablen haben, die gut zusammenpassen
* Sie bestimmen möchten, ob 2 Variablen zusammenhängen
* Sie eine unabhängige Variable haben, die mehrere Werte für eine abhängige Variable hat

Dieser C#-Code zeigt, wie man ein Streudiagramm mit einer anderen Reihe von Markierungen erstellt: 

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// Erstellt das Standarddiagramm
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// Holt sich den Index des Standarddiagrammdatenarbeitsblatts
int defaultWorksheetIndex = 0;

// Holt sich das Diagrammdatenarbeitsblatt
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Löscht die Demoserien
chart.ChartData.Series.Clear();

// Fügt neue Serien hinzu
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Serie 2"), chart.Type);

// Nimmt die erste Diagrammserie
IChartSeries series = chart.ChartData.Series[0];

// Fügt einen neuen Punkt (1:3) zur Serie hinzu
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// Fügt einen neuen Punkt (2:10) hinzu
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// Ändert den Serientyp
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// Ändert den Markierungstyp der Diagrammserie
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// Nimmt die zweite Diagrammserie
series = chart.ChartData.Series[1];

// Fügt einen neuen Punkt (5:2) zur Diagrammserie hinzu
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// Fügt einen neuen Punkt (3:1) hinzu
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// Fügt einen neuen Punkt (2:2) hinzu
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// Fügt einen neuen Punkt (5:1) hinzu
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// Ändert den Markierungstyp der Diagrammserie
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

// Speichert die PPTX-Datei auf der Festplatte
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **Kreisdiagramme erstellen**

Kreisdiagramme eignen sich am besten, um das Verhältnis Teil-und-Ganzes in Daten zu zeigen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Wenn Ihre Daten jedoch viele Teile oder Beschriftungen enthalten, sollten Sie stattdessen die Verwendung eines Balkendiagramms in Betracht ziehen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie den gewünschten Typ (in diesem Fall `ChartType.Pie`) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standardserien und -kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Fügen Sie neue Punkte für die Diagramme hinzu und fügen Sie benutzerdefinierte Farben für die Sektoren des Kreisdiagramms hinzu.
1. Setzen Sie die Beschriftungen für die Serien.
1. Setzen Sie die Führungsleitungen für die Serienbeschriftungen.
1. Setzen Sie den Rotationswinkel für die Folien des Kreisdiagramms.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Kreisdiagramm erstellt:

```c#
// Erstellt eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation presentation = new Presentation();

// Greift auf die erste Folie zu
ISlide slides = presentation.Slides[0];

// Fügt ein Diagramm mit seinen Standarddaten hinzu
IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Setzt den Diagrammtitel
chart.ChartTitle.AddTextFrameForOverriding("Beispieltitel");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Setzt die erste Serie, um Werte anzuzeigen
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// Setzt den Index für das Diagrammdatenblatt
int defaultWorksheetIndex = 0;

// Holt sich das Diagrammdatenarbeitsblatt
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Löscht die standardmäßig generierten Serien und Kategorien
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

// Fügt neue Kategorien hinzu
chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "Erstes Quartal"));
chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "Zweites Quartal"));
chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "Drittes Quartal"));

// Fügt neue Serien hinzu
IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Serie 1"), chart.Type);

// Füllt die Seriendaten
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// Fügen Sie neue Punkte hinzu und setzen Sie die Sektorfarbe
// series.IsColorVaried = true;
chart.ChartData.SeriesGroups[0].IsColorVaried = true;

IChartDataPoint point = series.DataPoints[0];
point.Format.Fill.FillType = FillType.Solid;
point.Format.Fill.SolidFillColor.Color = Color.Cyan;
// Setzt den Sektor-Rand
point.Format.Line.FillFormat.FillType = FillType.Solid;
point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
point.Format.Line.Width = 3.0;
point.Format.Line.Style = LineStyle.ThinThick;
point.Format.Line.DashStyle = LineDashStyle.DashDot;

IChartDataPoint point1 = series.DataPoints[1];
point1.Format.Fill.FillType = FillType.Solid;
point1.Format.Fill.SolidFillColor.Color = Color.Brown;

// Setzt den Sektor-Rand
point1.Format.Line.FillFormat.FillType = FillType.Solid;
point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
point1.Format.Line.Width = 3.0;
point1.Format.Line.Style = LineStyle.Single;
point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

IChartDataPoint point2 = series.DataPoints[2];
point2.Format.Fill.FillType = FillType.Solid;
point2.Format.Fill.SolidFillColor.Color = Color.Coral;

// Setzt den Sektor-Rand
point2.Format.Line.FillFormat.FillType = FillType.Solid;
point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
point2.Format.Line.Width = 2.0;
point2.Format.Line.Style = LineStyle.ThinThin;
point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

// Erstellt benutzerdefinierte Beschriftungen für jede der Serienkategorien
IDataLabel lbl1 = series.DataPoints[0].Label;

// lbl.ShowCategoryName = true;
lbl1.DataLabelFormat.ShowValue = true;

IDataLabel lbl2 = series.DataPoints[1].Label;
lbl2.DataLabelFormat.ShowValue = true;
lbl2.DataLabelFormat.ShowLegendKey = true;
lbl2.DataLabelFormat.ShowPercentage = true;

IDataLabel lbl3 = series.DataPoints[2].Label;
lbl3.DataLabelFormat.ShowSeriesName = true;
lbl3.DataLabelFormat.ShowPercentage = true;

// Setzt die Serie, um Führungsleitungen für das Diagramm anzuzeigen
series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

// Setzt den Rotationswinkel der Sektoren des Kreisdiagramms
chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

// Speichert die PPTX-Datei auf der Festplatte
presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
```

### **Liniendiagramme erstellen**

Liniendiagramme (auch bekannt als Liniengrafiken) eignen sich am besten für Situationen, in denen Sie Änderungen des Wertes über die Zeit demonstrieren möchten. Mit einem Liniendiagramm können Sie viele Daten gleichzeitig vergleichen, Veränderungen und Trends im Laufe der Zeit verfolgen und Anomalien in Datensätzen hervorheben.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ (in diesem Fall `ChartType.Line`) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standardserien und -kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Liniendiagramm erstellt:

```c#
using (Presentation pres = new Presentation())
{
    IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);
    
    pres.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Standardmäßig werden Punkte auf einem Liniendiagramm durch gerade durchgehende Linien verbunden. Wenn Sie möchten, dass die Punkte stattdessen durch Striche verbunden werden, können Sie Ihren bevorzugten Strichstil so angeben: xxx

```c#
IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);

foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

### **Baumkarten-Diagramme erstellen**

Baumkarten-Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe der Datenkategorien anzeigen und gleichzeitig die Aufmerksamkeit auf große Beiträge zu jeder Kategorie lenken möchten. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ (in diesem Fall `ChartType.TreeMap`) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standardserien und -kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Baumkarten-Diagramm erstellt:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    wb.Clear(0);

    // Zweig 1
    IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Blatt 1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stamm 1");
    leaf.GroupingLevels.SetGroupingItem(2, "Zweig 1");

    chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Blatt 2"));

    leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Blatt 3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stamm 2");

    chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Blatt 4"));


    // Zweig 2
    leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Blatt 5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stamm 3");
    leaf.GroupingLevels.SetGroupingItem(2, "Zweig 2");

    chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Blatt 6"));

    leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Blatt 7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stamm 4");

    chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Blatt 8"));

    IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

### **Aktiencharts erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ (ChartType.OpenHighLowClose) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standardserien und -kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Geben Sie das HiLowLines-Format an.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Beispiel-C#-Code zum Erstellen eines Aktiencharts:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);
    
    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "Öffnen"), chart.Type);
    chart.ChartData.Series.Add(wb.GetCell(0, 0, 2, "Hoch"), chart.Type);
    chart.ChartData.Series.Add(wb.GetCell(0, 0, 3, "Tief"), chart.Type);
    chart.ChartData.Series.Add(wb.GetCell(0, 0, 4, "Schließen"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];

    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    pres.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```


### **Box- und Whisker-Diagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ (ChartType.BoxAndWhisker) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standardserien und -kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Box- und Whisker-Diagramm erstellt:

```c#
public static void Run()
{
    using (Presentation pres = new Presentation("test.pptx"))
    {
        IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

        wb.Clear(0);

        chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Kategorie 1"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Kategorie 1"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Kategorie 1"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Kategorie 1"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Kategorie 1"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Kategorie 1"));

        IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

        series.QuartileMethod = QuartileMethodType.Exclusive;
        series.ShowMeanLine = true;
        series.ShowMeanMarkers = true;
        series.ShowInnerPoints = true;
        series.ShowOutlierPoints = true;

        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B1", 15));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B2", 41));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B3", 16));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B4", 10));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B5", 23));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B6", 16));

        pres.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
    }
}
```


### **Trichterdiagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ (ChartType.Funnel) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Trichterdiagramm erstellt:

```c#
public static void Run()
{
    using (Presentation pres = new Presentation("test.pptx"))
    {
        IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

        wb.Clear(0);

        chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Kategorie 1"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Kategorie 2"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Kategorie 3"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Kategorie 4"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Kategorie 5"));
        chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Kategorie 6"));

        IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

        series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B1", 50));
        series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B2", 100));
        series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B3", 200));
        series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B4", 300));
        series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B5", 400));
        series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B6", 500));

        pres.Save("Funnel.pptx", SaveFormat.Pptx);
    }
}
```

### **Sonnenstrahl-Diagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ (in diesem Fall `ChartType.sunburst`) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Sonnenstrahl-Diagramm erstellt:

```c#
public static void Run()
{
    using (Presentation pres = new Presentation("test.pptx"))
    {
        IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50, 50, 500, 400);
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

        wb.Clear(0);

        // Zweig 1
        IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Blatt 1"));
        leaf.GroupingLevels.SetGroupingItem(1, "Stamm 1");
        leaf.GroupingLevels.SetGroupingItem(2, "Zweig 1");

        chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Blatt 2"));

        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Blatt 3"));
        leaf.GroupingLevels.SetGroupingItem(1, "Stamm 2");

        chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Blatt 4"));

        // Zweig 2
        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Blatt 5"));
        leaf.GroupingLevels.SetGroupingItem(1, "Stamm 3");
        leaf.GroupingLevels.SetGroupingItem(2, "Zweig 2");

        chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Blatt 6"));

        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Blatt 7"));
        leaf.GroupingLevels.SetGroupingItem(1, "Stamm 4");

        chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Blatt 8"));

        IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
        series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D1", 4));
        series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D2", 5));
        series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D3", 3));
        series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D4", 6));
        series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D5", 9));
        series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D6", 9));
        series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D7", 4));
        series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D8", 3));

        pres.Save("Sunburst.pptx", SaveFormat.Pptx);
    }
}
```


### **Histogramm-Diagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index. 
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und wählen Sie Ihren bevorzugten Diagrammtyp (in diesem Fall `ChartType.Histogram`).
1. Greifen Sie auf das Diagrammdaten `IChartDataWorkbook` zu.
1. Löschen Sie die Standardserien und -kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Histogramm-Diagramm erstellt:

```c#
public static void Run()
{
    using (Presentation pres = new Presentation("test.pptx"))
    {
        IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Histogram, 50, 50, 500, 400);
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

        wb.Clear(0);

        IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
        series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A1", 15));
        series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A2", -41));
        series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A3", 16));
        series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A4", 10));
        series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A5", -23));
        series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A6", 16));

        chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

        pres.Save("Histogram.pptx", SaveFormat.Pptx);
    }
}
```

### **Radar-Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index. 
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und wählen Sie Ihren bevorzugten Diagrammtyp (in diesem Fall `ChartType.Radar`).
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Radar-Diagramm erstellt:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 400, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

### **Multikategoriendiagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ (ChartType.ClusteredColumn) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standardserien und -kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Multikategoriendiagramm erstellt:

```c#
Presentation pres = new Presentation();
ISlide slide = pres.Slides[0];

IChart ch = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
ch.ChartData.Series.Clear();
ch.ChartData.Categories.Clear();


IChartDataWorkbook fact = ch.ChartData.ChartDataWorkbook;
fact.Clear(0);
int defaultWorksheetIndex = 0;

IChartCategory category = ch.ChartData.Categories.Add(fact.GetCell(0, "c2", "A"));
category.GroupingLevels.SetGroupingItem(1, "Gruppe 1");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c3", "B"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c4", "C"));
category.GroupingLevels.SetGroupingItem(1, "Gruppe 2");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c5", "D"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c6", "E"));
category.GroupingLevels.SetGroupingItem(1, "Gruppe 3");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c7", "F"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c8", "G"));
category.GroupingLevels.SetGroupingItem(1, "Gruppe 4");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c9", "H"));

// Fügt die Serien hinzu
IChartSeries series = ch.ChartData.Series.Add(fact.GetCell(0, "D1", "Serie 1"),
    ChartType.ClusteredColumn);

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D2", 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D3", 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D4", 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D5", 40));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D6", 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D7", 60));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D8", 70));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D9", 80));
// Speichert die Präsentation mit dem Diagramm
pres.Save("AsposeChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **Kartendiagramme erstellen**

Ein Kartendiagramm ist eine Visualisierung eines Gebiets, das Daten enthält. Kartendiagramme eignen sich am besten zum Vergleichen von Daten oder Werten über geografische Regionen hinweg.

Dieser C#-Code zeigt, wie man ein Kartendiagramm erstellt:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Map, 50, 50, 500, 400);
    pres.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

### **Kombinationsdiagramme erstellen**

Ein Kombinationsdiagramm (oder Kombidiagramm) ist ein Diagramm, das zwei oder mehr Diagramme in einem einzigen Grafiken kombiniert. Ein solches Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei (oder mehr) Datensätzen hervorzuheben, zu vergleichen oder zu überprüfen. So sehen Sie die Beziehung (falls vorhanden) zwischen den Datensätzen. 

![combination-chart-ppt](combination-chart-ppt.png)

Dieser C#-Code zeigt, wie man ein Kombinationsdiagramm in PowerPoint erstellt:

```c#
private static void CreateComboChart()
{
    using (Presentation pres = new Presentation())
    {
        IChart chart = CreateChart(pres.Slides[0]);
        AddFirstSeriesToChart(chart);
        AddSecondSeriesToChart(chart);
        pres.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChart(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Serie 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Serie 2"), chart.Type);
    
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Kategorie 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Kategorie 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Kategorie 3"));

    IChartSeries series = chart.ChartData.Series[0];

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));
    
    series = chart.ChartData.Series[1];
    
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    return chart;
}

private static void AddFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Serie 3"), ChartType.ScatterWithSmoothLines);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 0, 1, 3),
        workbook.GetCell(worksheetIndex, 0, 2, 5));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 10),
        workbook.GetCell(worksheetIndex, 1, 4, 13));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 3, 20),
        workbook.GetCell(worksheetIndex, 2, 4, 15));

    series.PlotOnSecondAxis = true;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 5, "Serie 4"),
        ChartType.ScatterWithStraightLinesAndMarkers);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 5),
        workbook.GetCell(worksheetIndex, 1, 4, 2));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 5, 10),
        workbook.GetCell(worksheetIndex, 1, 6, 7));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 5, 15),
        workbook.GetCell(worksheetIndex, 2, 6, 12));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 3, 5, 12),
        workbook.GetCell(worksheetIndex, 3, 6, 9));
    
    series.PlotOnSecondAxis = true;
}
```

## **Diagramme aktualisieren**

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Präsentation mit dem Diagramm darstellt.
2. Holen Sie sich eine Folienreferenz über ihren Index.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Diagrammdatenarbeitsblatt zu.
5. Modifizieren Sie die Daten der Diagrammserie, indem Sie die Serienwerte ändern.
6. Fügen Sie eine neue Serie hinzu und fügen Sie Daten hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt, wie man ein Diagramm aktualisiert:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation("ExistingChart.pptx");

// Greift auf die erste Folie zu
ISlide sld = pres.Slides[0];

// Fügt ein Diagramm mit den Standarddaten hinzu
IChart chart = (IChart)sld.Shapes[0];

// Setzt den Index für das Diagrammdatenblatt
int defaultWorksheetIndex = 0;

// Holt sich das Diagrammdatenarbeitsblatt
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;


// Ändert den Namen der Diagrammkategorie
fact.GetCell(defaultWorksheetIndex, 1, 0, "Modifizierte Kategorie 1");
fact.GetCell(defaultWorksheetIndex, 2, 0, "Modifizierte Kategorie 2");


// Nimmt die erste Diagrammserie
IChartSeries series = chart.ChartData.Series[0];

// Aktualisiert die Seriendaten
fact.GetCell(defaultWorksheetIndex, 0, 1, "Neue_Serie1");// Serienname ändern
series.DataPoints[0].Value.Data = 90;
series.DataPoints[1].Value.Data = 123;
series.DataPoints[2].Value.Data = 44;

// Nimmt die zweite Diagrammserie
series = chart.ChartData.Series[1];

// Aktualisiert die Seriendaten
fact.GetCell(defaultWorksheetIndex, 0, 2, "Neue_Serie2");// Serienname ändern
series.DataPoints[0].Value.Data = 23;
series.DataPoints[1].Value.Data = 67;
series.DataPoints[2].Value.Data = 99;


// Fügt jetzt eine neue Serie hinzu
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 3, "Serie 3"), chart.Type);

// Nimmt die dritte Diagrammserie
series = chart.ChartData.Series[2];

// Füllt die Seriendaten
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 3, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 30));

chart.Type = ChartType.ClusteredCylinder;

// Speichert die Präsentation mit dem Diagramm
pres.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
```

## **Datenbereich für Diagramme festlegen**

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Präsentation mit dem Diagramm darstellt.
2. Holen Sie sich eine Folienreferenz über ihren Index.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt, wie man den Datenbereich für ein Diagramm festlegt:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation presentation = new Presentation("ExistingChart.pptx");

// Greift auf die erste Folie zu und fügt ein Diagramm mit Standarddaten hinzu
ISlide slide = presentation.Slides[0];
IChart chart = (IChart)slide.Shapes[0];
chart.ChartData.SetRange("Sheet1!A1:B4");
presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
```


## **Standardmarkierer in Diagrammen verwenden**
Wenn Sie einen Standardmarkierer in Diagrammen verwenden, erhält jede Diagrammserie automatisch unterschiedliche Standardmarkierungssymbole.

Dieser C#-Code zeigt, wie man automatisch einen Diagrammserienmarker festlegt:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
    chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Serie 1"), chart.Type);
    IChartSeries series = chart.ChartData.Series[0];

    chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 1, 24));
    chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 1, 23));
    chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 1, -10));
    chart.ChartData.Categories.Add(fact.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 1, null));

    chart.ChartData.Series.Add(fact.GetCell(0, 0, 2, "Serie 2"), chart.Type);
    // Nimmt die zweite Diagrammserie
    IChartSeries series2 = chart.ChartData.Series[1];

    // Füllt die serielle Daten
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    pres.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
``` 