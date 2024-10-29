---
title: Diagrammformatierung
type: docs
weight: 60
url: /de/net/chart-formatting/
keywords: "Diagrammobjekte, Diagrammeigenschaften, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Formatieren Sie Diagrammobjekte in PowerPoint-Präsentationen in C# oder .NET"
---

## **Diagrammobjekte formatieren**
Aspose.Slides für .NET ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie man verschiedene Diagrammobjekte, einschließlich der Kategorien- und Wertachsen, formatiert.

Aspose.Slides für .NET bietet eine einfache API zur Verwaltung verschiedener Diagrammobjekte und deren Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der **Presentation**-Klasse.
1. Erhalten Sie die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie jeden gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Wertachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Einstellung des **Linienformats** für die Hauptgitterlinien der Wertachse
   1. Einstellung des **Linienformats** für die Nebengitterlinien der Wertachse
   1. Einstellung des **Zahlenformats** für die Wertachse
   1. Einstellung der **Minimal-, Maximal-, Haupt- und Nebeneinheiten** für die Wertachse
   1. Einstellung der **Text Eigenschaften** für die Daten der Wertachse
   1. Einstellung des **Titels** für die Wertachse
   1. Einstellung des **Linienformats** für die Wertachse
1. Greifen Sie auf die Kategoriewerteachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Einstellung des **Linienformats** für die Hauptgitterlinien der Kategoriewerteachse
   1. Einstellung des **Linienformats** für die Nebengitterlinien der Kategoriewerteachse
   1. Einstellung der **Text Eigenschaften** für die Daten der Kategoriewerteachse
   1. Einstellung des **Titels** für die Kategoriewerteachse
   1. Einstellung der **Beschriftungspositionierung** für die Kategoriewerteachse
   1. Einstellung des **Rotationswinkels** für die Beschriftungen der Kategoriewerteachse
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text Eigenschaften** für diese
1. Legenden anzeigen, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **Sekundäre Wertachse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Wertachse**
   1. Einstellung des **Linienformats** für die sekundäre Wertachse
   1. Einstellung des **Zahlenformats** für die sekundäre Wertachse
   1. Einstellung der **Minimal-, Maximal-, Haupt- und Nebeneinheiten** für die sekundäre Wertachse
1. Plotten Sie jetzt die erste Diagrammreihe auf der sekundären Wertachse
1. Legen Sie die Hintergrundfüllfarbe der Diagrammwand fest
1. Legen Sie die Hintergrundfüllfarbe des Diagrammplotbereichs fest
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei

```c#
// Präsentation instanziieren
Presentation pres = new Presentation();

// Zugriff auf die erste Folie
ISlide slide = pres.Slides[0];

// Hinzufügen des Beispiel-Diagramms
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Titel des Diagramms festlegen
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Beispiel-Diagramm";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Einstellung des Formats für Hauptgitterlinien der Wertachse
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Einstellung des Formats für Nebengitterlinien der Wertachse
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Einstellung des Zahlenformats der Wertachse
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Einstellung der maximalen und minimalen Werte des Diagramms
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Einstellen der Text Eigenschaften der Wertachse
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Titel der Wertachse festlegen
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primäre Achse";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Einstellung des Formats für Hauptgitterlinien der Kategoriewerteachse
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Einstellung des Formats für Nebengitterlinien der Kategoriewerteachse
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Einstellen der Text Eigenschaften der Kategoriewerteachse
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Titel der Kategoriewerteachse festlegen
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Beispiel Kategorie";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Einstellung der Position der Beschriftungen der Kategoriewerteachse
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Einstellung des Rotationswinkels der Beschriftungen der Kategoriewerteachse
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Einstellung der Text Eigenschaften der Legenden
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Legenden anzeigen, ohne das Diagramm zu überlappen
chart.Legend.Overlay = true;
            
// Erste Serie auf der sekundären Wertachse plotten

// Einstellung der Hintergrundfarbe der Diagrammwand
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Einstellung der Farbe des Plotbereichs
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Präsentation speichern
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **Schriftart-Eigenschaften für Diagramm festlegen**
Aspose.Slides für .NET unterstützt das Festlegen der schriftartbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den folgenden Schritten, um die Schriftarteigenschaften für das Diagramm festzulegen.

- Instanziieren Sie das Presentation Klassenobjekt.
- Fügen Sie das Diagramm auf die Folie hinzu.
- Stellen Sie die Schriftartgröße ein.
- Speichern Sie die modifizierte Präsentation.

Das folgende Beispiel ist gegeben.

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
Aspose.Slides für .NET bietet eine einfache API zur Verwaltung des Datenformats von Diagrammen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie jeden gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Stellen Sie das vordefinierte Zahlenformat aus den möglichen vordefinierten Werten ein.
1. Durchlaufen Sie die Diagrammdatenzelle in jeder Diagrammreihe und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Legen Sie das benutzerdefinierte Zahlenformat fest.
1. Durchlaufen Sie die Diagrammdatenzelle in jeder Diagrammreihe und setzen Sie ein anderes Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.

```c#
// Präsentation instanziieren
Presentation pres = new Presentation();

// Zugriff auf die erste Präsentationsfolie
ISlide slide = pres.Slides[0];

// Hinzufügen eines standardisierten gruppierten Säulendiagramms
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Zugriff auf die Diagrammreihe Sammlung
IChartSeriesCollection series = chart.ChartData.Series;

// Festlegen des vordefinierten Zahlenformats
// Durchlaufen Sie jede Diagrammreihe
foreach (ChartSeries ser in series)
{
    // Durchlaufen Sie jede Datenzelle in der Serie
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Einstellungen des Zahlenformats
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Präsentation speichern
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Die möglichen vordefinierten Zahlenformatwerte zusammen mit ihrem vordefinierten Index, die verwendet werden können, sind unten angegeben:

|**0**|Allgemein|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rot$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rot$-#,##0.00|
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
|**38**|#,##0;Rot-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rot-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Gerundete Ränder für den Diagrammbereich festlegen**
Aspose.Slides für .NET bietet Unterstützung für die Einstellung des Diagrammbereichs. **IChart.HasRoundedCorners** und **Chart.HasRoundedCorners** Eigenschaften wurden in Aspose.Slides hinzugefügt.

1. Instanziieren Sie das `Presentation` Klassenobjekt.
1. Fügen Sie das Diagramm auf die Folie hinzu.
1. Stellen Sie den Fülltyp und die Füllfarbe des Diagramms ein
1. Setzen Sie die Eigenschaft für abgerundete Ecken auf Wahr.
1. Speichern Sie die modifizierte Präsentation.

Das folgende Beispiel ist gegeben.

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