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
- abgerundeter Rand
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für .NET formatieren und heben Sie Ihre PowerPoint-Präsentation mit professionellem, auffälligem Styling hervor."
---

## **Diagramm-Entitäten formatieren**
Aspose.Slides for .NET ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm-Entitäten einschließlich Diagramm‑Kategorien‑ und Werte‑Achsen formatiert werden.

Aspose.Slides for .NET provides a simple API for managing different chart entities and formatting them using custom values:

1. Erstellen Sie eine Instanz der **Presentation**‑Klasse.  
1. Erhalten Sie den Verweis auf eine Folie über ihren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Diagrammtyp hinzu (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).  
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:  
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Werte‑Achse  
   1. Festlegen des **Line format** für die Neben‑Gitternetzlinien der Werte‑Achse  
   1. Festlegen des **Number Format** für die Werte‑Achse  
   1. Festlegen von **Min, Max, Major and Minor units** für die Werte‑Achse  
   1. Festlegen der **Text Properties** für die Werte‑Achsendaten  
   1. Festlegen des **Title** für die Werte‑Achse  
   1. Festlegen des **Line Format** für die Werte‑Achse  
1. Greifen Sie auf die Kategorien‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:  
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Kategorien‑Achse  
   1. Festlegen des **Line format** für die Neben‑Gitternetzlinien der Kategorien‑Achse  
   1. Festlegen der **Text Properties** für die Kategorien‑Achsendaten  
   1. Festlegen des **Title** für die Kategorien‑Achse  
   1. Festlegen der **Label Positioning** für die Kategorien‑Achse  
   1. Festlegen des **Rotation Angle** für die Kategorien‑Achsenbeschriftungen  
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text Properties** dafür  
1. Diagramm‑Legenden anzeigen, ohne das Diagramm zu überlappen  
1. Greifen Sie auf die sekundäre **Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:  
   1. Aktivieren Sie die sekundäre **Value Axis**  
   1. Festlegen des **Line Format** für die sekundäre Werte‑Achse  
   1. Festlegen des **Number Format** für die sekundäre Werte‑Achse  
   1. Festlegen von **Min, Max, Major and Minor units** für die sekundäre Werte‑Achse  
1. Plotte nun die erste Diagrammreihe auf der sekundären Werte‑Achse  
1. Legen Sie die Füllfarbe der Rückwand des Diagramms fest  
1. Legen Sie die Füllfarbe des Diagrammbereichs fest  
1. Speichern Sie die geänderte Präsentation in einer PPTX‑Datei  
```c#
// Instanziieren der Präsentation// Instanziieren der Präsentation
Presentation pres = new Presentation();

// Zugriff auf die erste Folie
ISlide slide = pres.Slides[0];

// Hinzufügen des Beispieldiagramms
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

// Festlegen des Formats für Hauptgitternetzlinien der Werteachse
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Festlegen des Formats für Nebengitternetzlinien der Werteachse
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

// Festlegen des Linienformats der Werteachse: jetzt veraltet
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Festlegen des Formats für Hauptgitternetzlinien der Kategorienachse
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Festlegen des Formats für Nebengitternetzlinien der Kategorienachse
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

// Festlegen des Kategorienachsentitels
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Festlegen der Beschriftungsposition der Kategorienachse
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Festlegen des Rotationswinkels der Kategorienachsenbeschriftungen
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Festlegen der Texteigenschaften der Legenden
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Legenden anzeigen, ohne das Diagramm zu überlappen

chart.Legend.Overlay = true;
            
// Plotten der ersten Serie auf der sekundären Werteachse
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Festlegen der Hintergrundwandfarbe des Diagramms
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


## **Schriftart‑Eigenschaften für ein Diagramm festlegen**
Aspose.Slides for .NET bietet Unterstützung zum Festlegen der schriftbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den nachstehenden Schritten, um die Schriftart‑Eigenschaften für das Diagramm zu setzen.

- Instanziieren Sie ein **Presentation**‑Klassenobjekt.  
- Fügen Sie dem Folie ein Diagramm hinzu.  
- Legen Sie die Schrifthöhe fest.  
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


## **Numerisches Format festlegen**
Aspose.Slides for .NET provides a simple API for managing chart data format:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.  
1. Obtain a slide's reference by its index.  
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).  
1. Legen Sie das vordefinierte Zahlenformat aus den möglichen Vorgabewerten fest.  
1. Durchlaufen Sie die Datenzelle jedes Diagramm‑Serien und setzen Sie das Zahlenformat der Diagrammdaten.  
1. Save the presentation.  
1. Legen Sie das benutzerdefinierte Zahlenformat fest.  
1. Durchlaufen Sie die Datenzelle in jeder Diagramm‑Serie und setzen Sie ein anderes Zahlenformat für die Diagrammdaten.  
1. Save the presentation.  
```c#
// Präsentation instanziieren// Präsentation instanziieren
Presentation pres = new Presentation();

// Auf die erste Präsentationsfolie zugreifen
ISlide slide = pres.Slides[0];

// Hinzufügen eines standardmäßigen gruppierten Säulendiagramms
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Zugriff auf die Diagramm‑Serien‑Sammlung
IChartSeriesCollection series = chart.ChartData.Series;

// Festlegen des vordefinierten Zahlenformats
// Durchlaufen aller Diagrammserien
foreach (ChartSeries ser in series)
{
    // Durchlaufen aller Datenzellen in der Serie
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Festlegen des Zahlenformats
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Speichern der Präsentation
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Die möglichen vordefinierten Zahlenformatwerte zusammen mit ihrem Index sind unten angegeben:

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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Randlinien für Diagrammbereich festlegen**
Aspose.Slides for .NET provides support for setting chart area. **IChart.HasRoundedCorners** and **Chart.HasRoundedCorners** properties have been added in Aspose.Slides. 

1. Instanziieren Sie ein `Presentation`‑Klassenobjekt.  
1. Fügen Sie dem Folie ein Diagramm hinzu.  
1. Legen Sie den Fülltyp und die Füllfarbe des Diagramms fest.  
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

**Kann ich halbtransparente Füllungen für Säulen/Flächen festlegen und gleichzeitig die Kontur undurchsichtig lassen?**

Ja. Die Fülltransparenz und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitternetzes und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit Datenbeschriftungen umgehen, wenn sie sich überschneiden?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), stellen Sie den Beschriftungsversatz/-position ein, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie zum Format „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Farbverlauf‑/Musterfüllungen stehen in der Regel zur Verfügung. Verwenden Sie Farbverläufe sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Gitternetz und zum Text verringern.