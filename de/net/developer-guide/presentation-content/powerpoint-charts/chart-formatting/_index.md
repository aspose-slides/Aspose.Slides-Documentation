---
title: Diagrammformatierung
type: docs
weight: 60
url: /de/net/chart-formatting/
keywords: "Diagramm-Entitäten, Diagrammeigenschaften, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Diagramm-Entitäten in PowerPoint-Präsentationen in C# oder .NET formatieren"
---

## **Diagramm-Entitäten formatieren**
Aspose.Slides für .NET ermöglicht Entwicklern das Hinzufügen benutzerdefinierter Diagramme zu ihren Folien von Grund auf. Dieser Artikel erklärt, wie verschiedene Diagramm‑Entitäten formatiert werden, einschließlich Diagrammkategorie‑ und Werteachse.

Aspose.Slides für .NET bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Entitäten und zur Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der **Presentation**‑Klasse.
1. Holen Sie sich den Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen gewünschten Diagrammtyp wählen (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Werteachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für die Hauptgitterlinien der Werteachse
   1. Festlegen des **Line format** für die Nebengitterlinien der Werteachse
   1. Festlegen des **Number Format** für die Werteachse
   1. Festlegen von **Min, Max, Major and Minor units** für die Werteachse
   1. Festlegen der **Text Properties** für die Werteachsendaten
   1. Festlegen des **Title** für die Werteachse
   1. Festlegen des **Line Format** für die Werteachse
1. Greifen Sie auf die Kategorienachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für die Hauptgitterlinien der Kategorienachse
   1. Festlegen des **Line format** für die Nebengitterlinien der Kategorienachse
   1. Festlegen der **Text Properties** für die Kategorienachsendaten
   1. Festlegen des **Title** für die Kategorienachse
   1. Festlegen der **Label Positioning** für die Kategorienachse
   1. Festlegen des **Rotation Angle** für die Kategorienachsennamen
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text Properties** dafür
1. Legen Sie fest, dass Diagrammlegenden angezeigt werden, ohne das Diagramm zu überdecken
1. Greifen Sie auf die **Secondary Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Value Axis**
   1. Festlegen des **Line Format** für die sekundäre Value Axis
   1. Festlegen des **Number Format** für die sekundäre Value Axis
   1. Festlegen von **Min, Max, Major and Minor units** für die sekundäre Value Axis
1. Plotten Sie nun die erste Diagrammreihe auf der sekundären Value Axis
1. Legen Sie die Füllfarbe der Diagrammhinterwand fest
1. Legen Sie die Füllfarbe des Diagramm‑Plot‑Bereichs fest
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei
```c#
// Instanziieren der Präsentation// Instanziieren der Präsentation
Presentation pres = new Presentation();

// Zugriff auf die erste Folie
ISlide slide = pres.Slides[0];

// Hinzufügen des Beispiel-Diagramms
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

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

// Festlegen des Formats der Hauptgitterlinien für die Werteachse
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Festlegen des Formats der Hilfsgitterlinien für die Werteachse
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Festlegen des Zahlenformats der Werteachse
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Festlegen der maximalen und minimalen Werte des Diagramms
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Festlegen der Texteigenschaften der Werteachse
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

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

// Festlegen des Linienformats der Werteachse: Jetzt veraltet
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Festlegen des Formats der Hauptgitterlinien für die Kategorienachse
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Festlegen des Formats der Hilfsgitterlinien für die Kategorienachse
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Festlegen der Texteigenschaften der Kategorienachse
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Festlegen des Kategorien-Titels
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Festlegen der Position der Beschriftung der Kategorienachse
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Festlegen des Rotationswinkels der Beschriftung der Kategorienachse
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Festlegen der Texteigenschaften der Legende
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Legenden anzeigen, ohne das Diagramm zu überdecken

chart.Legend.Overlay = true;
            
// Plotten der ersten Reihe auf der sekundären Werteachse
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Festlegen der Farbe der hinteren Wand des Diagramms
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Festlegen der Farbe des Plotbereichs
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **Schriftart-Eigenschaften für Diagramm festlegen**
Aspose.Slides für .NET bietet Unterstützung zum Festlegen der schriftenbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den nachstehenden Schritten, um die Schriftarteigenschaften für das Diagramm festzulegen.

- Instanziieren Sie das `Presentation`‑Klassenobjekt.
- Fügen Sie dem Folie ein Diagramm hinzu.
- Legen Sie die Schriftgröße fest.
- Speichern Sie die geänderte Präsentation.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **Format von Zahlen festlegen**
Aspose.Slides für .NET bietet eine einfache API zur Verwaltung des Diagrammdatenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.
1. Holen Sie sich den Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen gewünschten Typ wählen (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Legen Sie das voreingestellte Zahlenformat aus den möglichen Voreinstellungen fest.
1. Durchlaufen Sie die Diagrammdatenzelle in jeder Diagrammreihe und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Legen Sie das benutzerdefinierte Zahlenformat fest.
1. Durchlaufen Sie die Diagrammdatenzelle in jeder Diagrammreihe und setzen Sie ein anderes Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.

```c#
// Instanzierung der Präsentation// Instanzierung der Präsentation
Presentation pres = new Presentation();

// Zugriff auf die erste Präsentationsfolie
ISlide slide = pres.Slides[0];

// Hinzufügen eines standardmäßigen gruppierten Säulendiagramms
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Zugriff auf die Diagramm-Seriensammlung
IChartSeriesCollection series = chart.ChartData.Series;

// Festlegen des voreingestellten Zahlenformats
// Durchlaufen jeder Diagrammserie
foreach (ChartSeries ser in series)
{
    // Durchlaufen jeder Datenzelle in der Serie
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Festlegen des Zahlenformats
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Speichern der Präsentation
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Die möglichen voreingestellten Zahlenformatwerte zusammen mit ihrem Index, die verwendet werden können, sind unten angegeben:

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

## **Abgerundete Ränder des Diagrammbereichs festlegen**
Aspose.Slides für .NET bietet Unterstützung zum Festlegen des Diagrammbereichs. Die Eigenschaften **IChart.HasRoundedCorners** und **Chart.HasRoundedCorners** wurden in Aspose.Slides hinzugefügt.

1. Instanziieren Sie ein Objekt der `Presentation`‑Klasse.
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Legen Sie den Fülltyp und die Füllfarbe des Diagramms fest
1. Setzen Sie die Eigenschaft für abgerundete Ecken auf **True**.
1. Speichern Sie die geänderte Präsentation.

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

**Kann ich halbtransparente Füllungen für Spalten/Bereiche festlegen und dabei die Kontur undurchsichtig lassen?**

Ja. Die Fülltransparenz und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitters und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit Datenbeschriftungen umgehen, wenn sie überlappen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungselemente (z. B. Kategorien), passen Sie den Beschriftungsversatz/-position an, zeigen Sie Beschriftungen nur für ausgewählte Punkte an, falls nötig, oder ändern Sie das Format zu "Wert + Legende".

**Kann ich Farbverläufe oder Musterfüllungen auf Reihen anwenden?**

Ja. Sowohl einfarbige als auch Verlauf‑/Musterfüllungen sind in der Regel verfügbar. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zum Gitter und zum Text verringern.