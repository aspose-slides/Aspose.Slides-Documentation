---
title: Diagramme für Präsentationen in .NET formatieren
linktitle: Diagramm-Formatierung
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
- Schrifteigenschaften
- Abgerundete Rahmen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für .NET formatieren und Ihre PowerPoint-Präsentation mit professionellem, auffälligem Design aufwerten."
---

## **Diagramm-Entitäten formatieren**
Aspose.Slides for .NET ermöglicht Entwicklern das Hinzufügen benutzerdefinierter Diagramme zu ihren Folien von Grund auf. Dieser Artikel erklärt, wie verschiedene Diagramm‑Entitäten einschließlich Diagrammkategorie‑ und Werteachse formatiert werden.

1. Eine Instanz der **Presentation**‑Klasse erstellen.
1. Eine Folienreferenz über deren Index abrufen.
1. Ein Diagramm mit Standarddaten hinzufügen, wobei der gewünschte Typ verwendet wird (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Auf die Werteachse des Diagramms zugreifen und die folgenden Eigenschaften festlegen:
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Werteachse
   1. Festlegen des **Line format** für die Hilfsgitternetzlinien der Werteachse
   1. Festlegen des **Number Format** für die Werteachse
   1. Festlegen von **Min, Max, Major und Minor units** für die Werteachse
   1. Festlegen der **Text Properties** für die Werteachsen‑Daten
   1. Festlegen des **Title** für die Werteachse
   1. Festlegen des **Line Format** für die Werteachse
1. Auf die Kategorieachse des Diagramms zugreifen und die folgenden Eigenschaften festlegen:
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Kategorieachse
   1. Festlegen des **Line format** für die Hilfsgitternetzlinien der Kategorieachse
   1. Festlegen der **Text Properties** für die Daten der Kategorieachse
   1. Festlegen des **Title** für die Kategorieachse
   1. Festlegen der **Label Positioning** für die Kategorieachse
   1. Festlegen des **Rotation Angle** für die Beschriftungen der Kategorieachse
1. Auf die Legende des Diagramms zugreifen und die **Text Properties** dafür festlegen
1. Diagrammlegenden anzeigen, ohne das Diagramm zu überlappen
1. Auf die **Secondary Value Axis** des Diagramms zugreifen und die folgenden Eigenschaften festlegen:
   1. Die sekundäre **Value Axis** aktivieren
   1. Festlegen des **Line Format** für die sekundäre Werteachse
   1. Festlegen des **Number Format** für die sekundäre Werteachse
   1. Festlegen von **Min, Max, Major und Minor units** für die sekundäre Werteachse
1. Jetzt die erste Diagramm‑Serie auf der sekundären Werteachse plotten
1. Die Füllfarbe der Rückwand des Diagramms festlegen
1. Die Füllfarbe des Diagramm‑Plot‑Bereichs festlegen
1. Die modifizierte Präsentation in eine PPTX‑Datei schreiben
```c#
// Instanziieren der Präsentation// Instanziieren der Präsentation
Presentation pres = new Presentation();

// Accessing the first slide
// Zugriff auf die erste Folie
ISlide slide = pres.Slides[0];

// Adding the sample chart
// Hinzufügen des Beispieldiagramms
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
// Festlegen des Diagrammtitels
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
// Festlegen des Formats der Hauptgitternetzlinien für die Werteachse
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
// Festlegen des Formats der Hilfsgitternetzlinien für die Werteachse
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
// Festlegen des Zahlenformats der Werteachse
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
// Festlegen der maximalen und minimalen Werte des Diagramms
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
// Festlegen der Text-Eigenschaften der Werteachse
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
// Festlegen des Titels der Werteachse
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting value axis line format : Now Obselete
// Festlegen des Linienformats der Werteachse: Jetzt veraltet
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
// Festlegen des Formats der Hauptgitternetzlinien für die Kategorieachse
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
// Festlegen des Formats der Hilfsgitternetzlinien für die Kategorieachse
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
// Festlegen der Text-Eigenschaften der Kategorieachse
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
// Festlegen des Kategorie-Titels
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
// Festlegen der Beschriftungsposition der Kategorieachse
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
// Festlegen des Rotationswinkels der Beschriftungen der Kategorieachse
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
// Festlegen der Text-Eigenschaften der Legenden
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart
// Legenden anzeigen, ohne das Diagramm zu überlappen
chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// Plotten der ersten Serie auf der sekundären Werteachse
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
// Festlegen der Hintergrundwandfarbe des Diagramms
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
// Festlegen der Farbe des Plotbereichs
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
// Präsentation speichern
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **Schrifteigenschaften für ein Diagramm festlegen**
Aspose.Slides for .NET unterstützt das Festlegen der schriftbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den untenstehenden Schritten, um die Schrifteigenschaften für das Diagramm festzulegen.

- Eine Instanz der **Presentation**‑Klasse erzeugen.
- Ein Diagramm auf der Folie hinzufügen.
- Schriftgröße festlegen.
- Die modifizierte Präsentation speichern.
```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **Das numerische Format festlegen**
Aspose.Slides for .NET bietet eine einfache API zur Verwaltung des Diagrammdatenformats:

1. Eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse erstellen.
1. Eine Folienreferenz über deren Index abrufen.
1. Ein Diagramm mit Standarddaten hinzufügen, wobei ein gewünschter Typ verwendet wird (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Das voreingestellte Zahlenformat aus den möglichen Voreinstellungen festlegen.
1. Durch die Datenzellen jedes Diagrammsereien iterieren und das Zahlenformat der Diagrammdaten festlegen.
1. Die Präsentation speichern.
1. Ein benutzerdefiniertes Zahlenformat festlegen.
1. Durch die Datenzellen jeder Diagrammsserie iterieren und ein unterschiedliches Zahlenformat festlegen.
1. Die Präsentation speichern.
```c#
// Instanzieren der Präsentation// Instanzieren der Präsentation
Presentation pres = new Presentation();

// Zugriff auf die erste Folie der Präsentation
ISlide slide = pres.Slides[0];

// Hinzufügen eines Standard-Clustered-Column-Diagramms
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Zugriff auf die Diagramm-Serien-Sammlung
IChartSeriesCollection series = chart.ChartData.Series;

// Festlegen des voreingestellten Zahlenformats
// Durchlaufen aller Diagrammserien
foreach (ChartSeries ser in series)
{
    // Durchlaufen aller Datenzellen in der Serie
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Festlegen des Zahlenformats
        cell.Value.AsCell.PresetNumberFormat = 10; //0,00%
    }
}

// Speichern der Präsentation
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Die möglichen voreingestellten Zahlenformatwerte zusammen mit ihrem Index, die verwendet werden können, sind unten aufgeführt:

|**0**|Allgemein|
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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Ränder für den Diagrammbereich festlegen**
Aspose.Slides for .NET unterstützt das Festlegen des Diagrammbereichs. Die Eigenschaften **IChart.HasRoundedCorners** und **Chart.HasRoundedCorners** wurden in Aspose.Slides hinzugefügt.

1. Eine Instanz der `Presentation`‑Klasse erzeugen.
2. Ein Diagramm auf der Folie hinzufügen.
3. Fülltyp und Füllfarbe des Diagramms festlegen
4. Die Eigenschaft für abgerundete Ecken auf True setzen.
5. Die modifizierte Präsentation speichern.
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

**Kann ich halbtransparente Füllungen für Spalten/Bereiche setzen, während die Rahmen undurchsichtig bleiben?**

Ja. Die Transparenz der Füllung und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitters und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit überlappenden Datenbeschriftungen umgehen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), setzen Sie den Beschriftungsversatz/-position, zeigen Sie Beschriftungen bei Bedarf nur für ausgewählte Punkte an oder wechseln Sie das Format zu "Wert + Legende".

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Farbverlauf‑/Musterfüllungen sind in der Regel verfügbar. In der Praxis sollten Sie Farbverläufe sparsam einsetzen und Kombinationen vermeiden, die den Kontrast zum Gitter und zum Text verringern.