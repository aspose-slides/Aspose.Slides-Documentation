---
title: Diagramme in .NET formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/net/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm-Entität
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schriftarteigenschaften
- Abgerundete Rahmen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für .NET formatieren und verleihen Sie Ihrer PowerPoint-Präsentation mit professionellem, auffälligem Design mehr Wirkung."
---

## **Diagramm-Entitäten formatieren**
Aspose.Slides for .NET ermöglicht Entwicklern das Hinzufügen benutzerdefinierter Diagramme zu ihren Folien von Grund auf. Dieser Artikel erklärt, wie verschiedene Diagramm‑Entitäten formatiert werden, einschließlich der Kategorien‑ und Werte‑Achse.

Aspose.Slides for .NET bietet eine einfache API zum Verwalten verschiedener Diagramm‑Entitäten und zum Formatieren mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der **Presentation**‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. **Linienformat** für Hauptgitternetzlinien der Werte‑Achse festlegen
   1. **Linienformat** für Neben­gitternetzlinien der Werte‑Achse festlegen
   1. **Zahlenformat** für die Werte‑Achse festlegen
   1. **Min‑, Max‑, Haupt‑ und Neben‑Einheiten** für die Werte‑Achse festlegen
   1. **Text‑Eigenschaften** für Werte‑Achsen‑Daten festlegen
   1. **Titel** für die Werte‑Achse festlegen
   1. **Linienformat** für die Werte‑Achse festlegen
1. Greifen Sie auf die Kategorien‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. **Linienformat** für Hauptgitternetzlinien der Kategorien‑Achse festlegen
   1. **Linienformat** für Neben­gitternetzlinien der Kategorien‑Achse festlegen
   1. **Text‑Eigenschaften** für Kategorien‑Achsen‑Daten festlegen
   1. **Titel** für die Kategorien‑Achse festlegen
   1. **Beschriftungs‑Positionierung** für die Kategorien‑Achse festlegen
   1. **Drehwinkel** für Kategorien‑Achsen‑Beschriftungen festlegen
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text‑Eigenschaften** dafür
1. Diagramm‑Legenden anzeigen, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **sekundäre Werte‑Achse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Sekundäre **Werte‑Achse** aktivieren
   1. **Linienformat** für die sekundäre Werte‑Achse festlegen
   1. **Zahlenformat** für die sekundäre Werte‑Achse festlegen
   1. **Min‑, Max‑, Haupt‑ und Neben‑Einheiten** für die sekundäre Werte‑Achse festlegen
1. Nun die erste Diagramm‑Serie auf der sekundären Werte‑Achse plotten
1. Hintergrundfarbe der Rückwand des Diagramms festlegen
1. Hintergrundfarbe des Diagrammbereichs festlegen
1. Die geänderte Präsentation in eine PPTX‑Datei schreiben
```c#
// Instanziieren der Präsentation// Instanziieren der Präsentation
Presentation pres = new Presentation();

// Zugriff auf die erste Folie
ISlide slide = pres.Slides[0];

// Hinzufügen des Beispieldiagramms
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Diagrammtitel festlegen
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Hauptgitterlinienformat für Wertachse festlegen
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Nebengitterlinienformat für Wertachse festlegen
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Zahlenformat für Wertachse festlegen
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Maximal- und Minimalwerte des Diagramms festlegen
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Texteigenschaften der Wertachse festlegen
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Titel der Wertachse festlegen
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Linienformat der Wertachse festlegen: Jetzt veraltet
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Hauptgitterlinienformat für Kategorienachse festlegen
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Nebengitterlinienformat für Kategorienachse festlegen
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Texteigenschaften der Kategorienachse festlegen
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Kategorienamen festlegen
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Position der Achsenbeschriftung festlegen
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Rotationswinkel der Achsenbeschriftung festlegen
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Texteigenschaften der Legende festlegen
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Legenden anzeigen, ohne das Diagramm zu überlappen

chart.Legend.Overlay = true;
            
// Erste Serie auf sekundärer Wertachse plotten
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Hintergrundfarbe der Rückwand des Diagramms festlegen
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Plotbereichsfarbe festlegen
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Präsentation speichern
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```




## **Schriftart‑Eigenschaften für Diagramme festlegen**
Aspose.Slides for .NET unterstützt das Festlegen von schriftbezogenen Eigenschaften für Diagramme. Bitte folgen Sie den nachstehenden Schritten, um die Schriftart‑Eigenschaften für ein Diagramm festzulegen.

- Instanziieren Sie ein **Presentation**‑Klassenobjekt.
- Fügen Sie ein Diagramm auf der Folie hinzu.
- Schriftgröße festlegen.
- Geänderte Präsentation speichern.

Im Folgenden ein Beispiel.
```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```





## **Numerische Formate festlegen**
Aspose.Slides for .NET bietet eine einfache API zur Verwaltung des Datenformats von Diagrammen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Legen Sie das voreingestellte Zahlenformat aus den verfügbaren Voreinstellungen fest.
1. Durchlaufen Sie jede Datenzelle jeder Diagramm‑Serie und setzen Sie das Zahlenformat der Diagrammdaten.
1. Präsentation speichern.
1. Benutzerdefiniertes Zahlenformat festlegen.
1. Durchlaufen Sie die Datenzellen jeder Diagramm‑Serie und setzen Sie ein anderes Zahlenformat.
1. Präsentation speichern.
```c#
// Instanziieren der Präsentation// Instanziieren der Präsentation
Presentation pres = new Presentation();

// Zugriff auf die erste Präsentationsfolie
ISlide slide = pres.Slides[0];

// Hinzufügen eines Standard-Clustered-Column-Diagramms
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Zugriff auf die Diagramm‑Serien‑Sammlung
IChartSeriesCollection series = chart.ChartData.Series;

// Festlegen des voreingestellten Zahlenformats
// Durchlaufen jeder Diagramm‑Serie
foreach (ChartSeries ser in series)
{
    // Durchlaufen jeder Datenzelle in der Serie
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Festlegen des Zahlenformats
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Präsentation speichern
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Die möglichen voreingestellten Zahlenformat‑Werte zusammen mit ihrem Index sind unten aufgeführt:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Rahmen für Diagrammbereich festlegen**
Aspose.Slides for .NET unterstützt das Festlegen des Diagrammbereichs. Die Eigenschaften **IChart.HasRoundedCorners** und **Chart.HasRoundedCorners** wurden in Aspose.Slides hinzugefügt.

1. Instanziieren Sie ein `Presentation`‑Klassenobjekt.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Fülltyp und Füllfarbe des Diagramms festlegen
1. Eigenschaft für abgerundete Ecken auf **True** setzen.
1. Geänderte Präsentation speichern.

Im Folgenden ein Beispiel.
```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Flächen verwenden und dabei die Kontur undurchsichtig lassen?**

Ja. Transparenz der Füllung und Kontur werden separat konfiguriert. Das ist nützlich, um die Lesbarkeit von Gittern und Daten in dichten Visualisierungen zu verbessern.

**Wie gehe ich mit Datenbeschriftungen um, wenn sie sich überlappen?**

Schriftgröße reduzieren, nicht wesentliche Beschriftungselemente deaktivieren (z. B. Kategorien), Beschriftungs‑Offset/‑Position anpassen, bei Bedarf Beschriftungen nur für ausgewählte Punkte anzeigen oder das Format zu „Wert + Legende“ wechseln.

**Kann ich Farbverlauf‑ oder Muster‑Füllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Farbverlauf‑/Muster‑Füllungen stehen in der Regel zur Verfügung. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zum Gitter und zum Text verringern.