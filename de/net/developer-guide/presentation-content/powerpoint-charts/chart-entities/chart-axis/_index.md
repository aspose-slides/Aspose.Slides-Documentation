---
title: Diagrammachsen in Präsentationen in .NET anpassen
linktitle: Diagrammachse
type: docs
url: /de/net/chart-axis/
keywords:
- Diagrammachse
- Vertikale Achse
- Horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achsen-Eigenschaften
- Maximalwert
- Minimalwert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für .NET verwenden, um Diagrammachsen in PowerPoint‑Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Diagrammachsen mit Aspose.Slides für .NET anpasst. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagramm‑Zeilen und -Spalten, Achsensichtbarkeit, Intervall von Kategorienbeschriftungen und Tick‑Markierungen, Datums‑Kategorien und Formatierung, Titelrotation, Achsenpositionierung, Anzeigeeinheiten und logarithmische Skalierung.

## **Maximale Werte auf der vertikalen Achse von Diagrammen ermitteln**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) auf, bevor Sie berechnete Achsenwerte auslesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) und [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) für die Achsenbegrenzungen sowie [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) und [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) für die Tick‑Intervalle. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) und [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) geben Zeiteinheiten‑Skalen zurück, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Daten zwischen Achsen tauschen**

Verwenden Sie [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/), um die Rollen von Reihen und Spalten in Diagrammdaten auszutauschen. Jede ehemalige Kategorie wird zu einer Serie und jede ehemalige Serie wird zu einer Kategorie. Dies ändert, wie die Daten gruppiert werden; es vertauscht nicht die horizontale und vertikale Achse. Das Beispiel verwendet [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/), um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Header‑Zeile und der Kategorienspalte, bevor Zeilen und Spalten getauscht werden. Es speichert ein Diagramm mit vier Serien und drei Kategorien.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Reihenfolge der Achsenzeichnung umkehren**

Verwenden Sie [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/), um eine Kategorien‑ oder Werteachse umzukehren. Beispielsweise kann ein horizontales Balkendiagramm Projektphasen von oben nach unten in derselben Reihenfolge wie das Arbeitsblatt anzeigen: Planung, Entwicklung, Testen. Das Umkehren einer Achse ändert die Zeichenrichtung; es sortiert oder ordnet die Arbeitsmappendaten nicht neu. Im Vergleich dazu tauscht [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) die Rollen von Serien und Kategorien aus.

Das folgende Beispiel erstellt ein horizontales Balkendiagramm mit drei Phasen und einer Serie. Es speichert eine Präsentation mit drei Folien: normale Reihenfolge, umgekehrte Kategorien und umgekehrte Werte. Jede Kopie verwendet den gleichen Datensatz, und nur eine Achse ist in jeder Kopie umgekehrt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Folie 2: Die erste Kategorie oben anzeigen.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Die horizontale Werteachse unten beibehalten.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Folie 3: Nur die horizontale numerische Skala umkehren.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Das Umkehren einer Achse kann auch die senkrechte Achse auf die gegenüber­liegende Seite des Plots verschieben. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) bestimmt, wo die andere Achse die zu konfigurierende Achse schneidet. In Folie 2 hält die Einstellung `Maximum` auf der umgekehrten Kategorienachse die horizontale Werteachse unten. Für einen konkreten Schnittpunkt verwenden Sie [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Prüfen Sie die Kreuzungseinstellungen beim Richtungswechsel, insbesondere wenn das Diagramm bereits einen benutzerdefinierten Schnittpunkt hat. Setzen Sie `IsPlotOrderReversed` zurück auf `false`, um die normale Zeichenrichtung wiederherzustellen; die Kreuzungseinstellungen sind separat.

| Normalreihenfolge (Folie 1) | Umgekehrte Kategorien (Folie 2) | Umgekehrte Werte (Folie 3) |
| --- | --- | --- |
| ![Horizontales Balkendiagramm mit normaler Kategorie‑ und Werteachsen‑Reihenfolge](axis-order-normal.png) | ![Horizontales Balkendiagramm mit von oben nach unten angezeigten Kategorien](axis-order-categories-reversed.png) | ![Horizontales Balkendiagramm mit umgekehrter Werteachse und Null rechts](axis-order-values-reversed.png) |
| Kategorien verlaufen von unten nach oben; Werte steigen von links nach rechts. | Planung, Entwicklung und Testen verlaufen von oben nach unten. Werte und Zeilenreihenfolge der Arbeitsmappe bleiben unverändert. | Kategorien behalten ihre normale Reihenfolge bei; Werte steigen von rechts nach links. Die Kategorienachse schneidet bei Null rechts. |

## **Vertikale Achse für Liniendiagramme deaktivieren**

Setzen Sie [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) auf `false` bei der vertikalen Achse, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter vertikaler Achse.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Horizontale Achse für Liniendiagramme deaktivieren**

Setzen Sie [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) auf `false` bei der horizontalen Achse, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter horizontaler Achse.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Eine Kategorienachse ändern**

Setzen Sie [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) um eine Datums‑ oder Text‑Kategorienachse auszuwählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm das erste Shape auf der ersten Folie ist und die Kategorie­zellen numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Durch Setzen von [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) auf `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) auf `1` und [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) auf Monate werden Hauptticks im Abstand von einem Monat platziert.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **Kategorienachsen‑Beschriftungs‑Intervalle steuern**

Wenn ein Diagramm viele Kategorien hat, reduzieren Sie die Anzahl sichtbarer Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Setzen Sie [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) auf `false` und dann [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) auf das gewünschte Kategorien‑Intervall. Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt zwischen den angezeigten Beschriftungen jeweils zwei ausgeblendet. Es entfernt nicht die zugehörigen Spalten. Die automatische Abstandsbestimmung wählt ein Intervall basierend auf dem verfügbaren Platz; sie zeigt nicht notwendigerweise jede Beschriftung an.

Tick‑Marks haben separate Einstellungen. Setzen Sie [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) auf `false` und verwenden Sie [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) zur Festlegung ihres Intervalls. Zum Beispiel lässt `1` einen Tick‑Mark bei jedem Kategorien‑Intervall, während Beschriftungen nur bei jeder dritten Kategorie erscheinen. Setzen Sie [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) auf einen sichtbaren Stil, um das Ergebnis zu sehen. Das Zurücksetzen der automatischen Abstandseigenschaft auf `true` lässt das Diagramm das Intervall wieder automatisch wählen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Folie 2: jede dritte Beschriftung anzeigen, aber für jede Kategorie einen Tick‑Mark beibehalten.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Folie 3: das Diagramm die beiden Intervalle wieder auswählen lassen.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatischer Abstand (Folie 1):** In dieser Darstellung wird jede zweite Kategorien­beschriftung angezeigt und umbrechen in zwei Zeilen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatischer Kategorienbeschriftungsabstand mit allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manueller Abstand (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Tick‑Marks bei jedem Kategorien‑Intervall verbleiben. Alle 24 Spalten, einschließlich der nicht beschrifteten, bleiben mit denselben Werten sichtbar. Folie 3 stellt das oben gezeigte automatische Aussehen wieder her.

![Manuelles Kategorienbeschriftungsintervall von drei mit allen 24 Spalten sichtbar](category-axis-manual.png)

### **Richtige Achse und Intervall wählen**

Verwenden Sie dieses Kategorien‑Zähl‑Intervall für eine Text‑Kategorienachse, z. B. die Kategorienachse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist es die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorienachse vertikal, sodass diese Einstellungen auf [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) angewendet werden. Der Tick‑Mark‑Abstand gilt ebenfalls für eine Serienachse in Diagrammen, die eine besitzen.

Verwenden Sie die Kategorien‑Beschriftungs‑Abstandseinstellung nicht, um die numerische Skala einer Werteachse zu setzen. Auf einer Werteachse gibt [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) eine Werte‑Differenz an: Zum Beispiel erzeugt ein Hauptintervall von `10` Ticks bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungs‑Intervall von `3` zählt stattdessen Kategorienpositionen, unabhängig von deren Werte. Streu‑ und Blasendiagramme verwenden Werteachsen statt einer Text‑Kategorienachse. Für eine Datumsachse verwenden Sie zeitrelevante Haupteinheiten und Skalen, wie in [Eine Kategorienachse ändern](#eine-kategorienachse-ändern) beschrieben.

## **Datumsformat für Kategorienachsenwerte festlegen**

Das Beispiel ersetzt die Standard‑Diagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert. Setzen Sie [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) auf eine Datumsachse, deaktivieren Sie [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) und weisen Sie `yyyy` [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) zu, damit die Kategorienbeschriftungen vierstellige Jahreszahlen unabhängig von der Zellenformatierung anzeigen.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Rotationswinkel für einen Diagrammachsentitel festlegen**

Aktivieren Sie [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) auf der vertikalen Achse, geben Sie einen Titeltext an und setzen Sie [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) zum Drehen des Titels. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm, bei dem der Titel der Werteachse um 90 Grad gedreht ist.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Achsenposition auf einer Kategorien‑ oder Werteachse festlegen**

Verwenden Sie [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/), um zu steuern, ob die Werteachse die Kategorienachse zwischen Kategorien oder an den Kategorie‑Tick‑Marks kreuzt. Diese Eigenschaft gilt für Kategorienachsen. Das Beispiel setzt sie auf `true` bei der horizontalen Kategorienachse eines Säulendiagramms und speichert das Ergebnis.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Anzeigeeinheit auf einer Werteachse festlegen**

Setzen Sie [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) um die Beschriftungen einer Werteachse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) auf `Millions` wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeige­einheit auf seine vertikale Achse an.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Logarithmische Werteachse konfigurieren**

Eine logarithmische Werteachse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Beispielsweise kann ein Dienst 10, 100, 1 000, 10 000 und 100 000 Anfragen über fünf Zeiträume erhalten. Auf einer linearen Skala erscheinen die kleineren Werte dicht beieinander nahe Null. Eine logarithmische Skala erleichtert den Vergleich ihres relativen Wachstums: Gleiche Abstände repräsentieren gleiche Verhältnisse statt gleicher Differenzen.

Setzen Sie [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) auf `true` bei der Werteachse und verwenden Sie [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/), um die Basis zu wählen. Dies ändert die Darstellung der vorhandenen Werte; es ändert nicht die Daten und fügt keine logarithmische Trendlinie hinzu. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist eine separate Funktion.

### **Werteachse und Basis wählen**

Für ein Linien‑ oder Säulendiagramm ist die Werteachse [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Für ein horizontales Balkendiagramm ist es [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Streu‑ und Blasendiagramme besitzen zwei Werteachsen, sodass Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide auswählen können. Wenden Sie keine logarithmische Skalierung auf eine Kategorienachse an.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme kann eine Basis von `2` bis `1000` verwendet werden; Bruch‑Basen wie `2.5` werden ebenfalls unterstützt. Bei Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende selbstständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragenzahlen auf der ersten Folie, klont dann diese Folie und aktiviert eine Basis‑10‑logarithmische Werteachse auf der zweiten. Beide Folien behalten dieselben Daten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Die erste Folie linear lassen und nur die Werteachsenskalierung der Kopie ändern.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineare Skala (Folie 1):** Gleiche vertikale Abstände repräsentieren gleiche Unterschiede bei den Anfragenzahlen. Der größte Wert dominiert das Diagramm und macht die kleineren Werte schwer zu unterscheiden.

![Liniendiagramm in PowerPoint, das fünf Anfragenzahlen auf einer linearen Werteachse zeigt](value-axis-linear.png)

**Logarithmische Skala (Folie 2):** Gleiche vertikale Abstände repräsentieren gleiche Verhältnisse. Jede Periode hat zehnmal so viele Anfragen wie die vorherige, sodass die Punkte auf einer Basis‑10‑Skala eine gerade steigende Linie bilden. Die Achsen‑Beschriftungen zeigen weiterhin die ursprünglichen Anfragenzahlen.

![Die gleichen fünf Anfragenzahlen in PowerPoint auf einer Basis‑10‑logarithmischen Werteachse](value-axis-logarithmic.png)

### **Umgang mit Null‑ und negativen Werten**

Eine logarithmische Skala kann nur streng positive Werte anzeigen. Prüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negative Werte eine Bedeutung haben, behalten Sie eine lineare Skala bei oder zeigen Sie sie getrennt an. Wenn das Ausschließen dieser Werte für die Analyse sinnvoll ist, erklären Sie die Auslassung. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Bedeutung der Daten ändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert für eine logarithmische Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie setze ich den Wert, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Verwenden Sie [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/), um das Kreuzungsverhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, setzen Sie [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Diese Einstellungen ermöglichen es, den Achsenkreuzpunkt zu einer geeigneten Basis zu verschieben.

**Wie kann ich Tick‑Beschriftungen relativ zur Achse positionieren?**

Setzen Sie [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) mit [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` oder `None`. Um die Tick‑Marks selbst zu steuern, verwenden Sie [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) oder [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); diese sind getrennt von der Beschriftungsposition.