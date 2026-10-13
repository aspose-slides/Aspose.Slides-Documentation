---
title: Diagrammachsen in Präsentationen mit .NET anpassen
linktitle: Diagrammachse
type: docs
url: /de/net/chart-axis/
keywords:
- Diagrammachse
- vertikale Achse
- horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achseneigenschaften
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
description: "Entdecken Sie, wie Sie Aspose.Slides für .NET verwenden, um Diagrammachsen in PowerPoint‑Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagrammachsen mit Aspose.Slides für .NET angepasst werden können. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagramm‑Zeilen und -Spalten, die Sichtbarkeit von Achsen, Intervall für Kategorienbeschriftungen und Teilstrichmarken, Datums­kategorien und -formatierung, Drehung von Achsentiteln, Positionierung von Achsen, Anzeige‑Einheiten und logarithmische Skalierung.

## **Maximale Werte auf der vertikalen Achse von Diagrammen abrufen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) auf, bevor Sie berechnete Achsenwerte auslesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) und [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) für die Achsenbegrenzungen sowie [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) und [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) für die Teilstrich‑Intervalle. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) und [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) liefern Zeiteinheiten‑Skalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

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

## **Daten zwischen Achsen vertauschen**

Verwenden Sie [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/), um die Rollen von Reihen und Kategorien in Diagrammdaten auszutauschen. Jede frühere Kategorie wird zu einer Serie und jede frühere Serie zu einer Kategorie. Dies ändert die Gruppierung der Daten; die horizontalen und vertikalen Achsen werden nicht vertauscht. Das Beispiel nutzt [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/), um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Kopfzeile und der Kategorien‑Spalte, bevor Zeilen und Spalten getauscht werden. Es speichert ein Diagramm mit vier Serien und drei Kategorien.

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

## **Vertikale Achse für Liniendiagramme deaktivieren**

Setzen Sie [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) auf `false` für die vertikale Achse, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter vertikaler Achse.

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

Setzen Sie [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) auf `false` für die horizontale Achse, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter horizontaler Achse.

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

Setzen Sie [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/), um eine Datums‑ oder Text‑Kategorienachse auszuwählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm das erste Shape auf der ersten Folie ist und die Kategorienzellen numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Durch Setzen von [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) auf `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) auf `1` und [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) auf Monate werden Hauptteilstriche im Abstand von einem Monat platziert.

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

## **Intervall für Kategorienachsen‑Beschriftungen steuern**

Wenn ein Diagramm viele Kategorien enthält, kann die Anzahl der sichtbaren Achsenbeschriftungen reduziert werden, ohne Kategorien oder Datenpunkte zu entfernen. Setzen Sie [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) auf `false` und dann [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) auf das gewünschte Kategori­intervall. Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | In dem Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt zwischen den angezeigten Beschriftungen jeweils zwei verborgen. Es werden die zugehörigen Spalten nicht entfernt. Automatischer Abstand wählt ein Intervall basierend auf dem verfügbaren Platz; er zeigt nicht zwingend jede Beschriftung an.

Teilstrichmarken haben eigene Einstellungen. Setzen Sie [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) auf `false` und verwenden Sie [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) zur Festlegung ihres Abstands. Beispiel: `1` lässt eine Teilstrichmarke bei jedem Kategorienintervall erscheinen, während Beschriftungen nur bei jeder dritten Kategorie angezeigt werden. Setzen Sie [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) auf einen sichtbaren Stil, um das Ergebnis zu sehen. Wird eine der automatischen Abstandseigenschaften wieder auf `true` gesetzt, wählt das Diagramm das Intervall erneut automatisch.

Das folgende, eigenständige Beispiel erstellt 24 Kategorien und eine Serie, speichert dann drei Folien in `CategoryAxisIntervals.pptx`: automatischer Abstand, manuelle Beschriftungsabstände mit unabhängigen Teilstrichmarken und wiederhergestellter automatischer Abstand. Die beiden Kopien behalten die ursprünglichen Diagrammdaten. Keine Eingabepräsentation ist erforderlich. Der horizontale Beschriftungstext macht den Unterschied in der Dichte gut sichtbar.

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

// Folie 2: jede dritte Beschriftung anzeigen, aber für jede Kategorie eine Teilstrichmarke beibehalten.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Folie 3: das Diagramm wählt beide Intervalle erneut.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatischer Abstand (Folie 1):** In dieser Darstellung wird jede zweite Kategorienbeschriftung angezeigt und umbrechen auf zwei Zeilen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatischer Abstand der Kategorienbeschriftungen mit allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manueller Abstand (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Teilstrichmarken bei jedem Kategorienintervall verbleiben. Alle 24 Spalten, auch jene ohne Beschriftungen, bleiben sichtbar mit denselben Werten. Folie 3 stellt das oben gezeigte automatische Aussehen wieder her.

![Manueller Kategorienbeschriftungsintervall von drei mit allen 24 Spalten sichtbar](category-axis-manual.png)

### **Den richtigen Achsen‑ und Intervalltyp wählen**

Verwenden Sie dieses Kategori­zähl‑Intervall für eine Text‑Kategorienachse, z. B. die Kategorienachse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist sie die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorienachse vertikal, daher wenden Sie diese Einstellungen auf [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) an. Der Abstand für Teilstrichmarken gilt ebenfalls für eine Serienachse in Diagrammen, die eine besitzen.

Verwenden Sie die Kategorien‑Beschriftungs‑Abstände nicht, um die numerische Skala einer Werteachse festzulegen. Auf einer Werteachse gibt [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) einen Unterschied in den Werten an: z. B. erzeugt ein Hauptintervall von `10` Teilstriche bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungs‑Intervall von `3` zählt hingegen Kategorienpositionen, unabhängig von deren Datenwerten. Streu‑ und Blasendiagramme verwenden Werteachsen statt einer Text‑Kategorienachse. Für eine Datumsachse verwenden Sie zeitbasierte Haupteinheiten und Skalen wie in **[Kategorienachse ändern](#change-a-category-axis)** beschrieben.

## **Datumsformat für Kategorienachsen‑Werte festlegen**

Das Beispiel ersetzt die Standarddiagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert. Setzen Sie [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) auf eine Datumsachse, deaktivieren Sie [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) und weisen Sie `yyyy` [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) zu, sodass die Kategorienbeschriftungen vierstellige Jahreszahlen unabhängig von der Zellformatierung anzeigen.

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

## **Drehwinkel für einen Diagrammachsentitel festlegen**

Aktivieren Sie [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) auf der vertikalen Achse, geben Sie den Titeltext an und setzen Sie [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) zum Drehen des Titels. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm, dessen Werteachsen‑Titel um 90 Grad gedreht ist.

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

## **Achsenposition bei einer Kategorien‑ oder Werteachse festlegen**

Verwenden Sie [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/), um zu steuern, ob die Werteachse die Kategorienachse zwischen den Kategorien oder an den Kategorien‑Teilstrichmarken schneidet. Diese Eigenschaft gilt für Kategorienachsen. Das Beispiel setzt sie auf `true` für die horizontale Kategorienachse eines Säulendiagramms und speichert das Ergebnis.

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

## **Anzeige‑Einheit einer Diagramm‑Werteachse festlegen**

Setzen Sie [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) zu skalieren die Beschriftungen einer Werteachse, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) auf `Millions` zeigen Sie einen Wert von 60 000 000 als 60 an. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeige‑Einheit auf die vertikale Achse an.

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

Eine logarithmische Werteachse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Beispiel: Ein Dienst erhält 10, 100, 1 000, 10 000 und 100 000 Anfragen über fünf Zeiträume. Auf einer linearen Skala liegen die kleineren Werte nahe beieinander nahe Null. Eine logarithmische Skala macht ihr relatives Wachstum leichter vergleichbar: gleiche Abstände stehen für gleiche Verhältnisse statt gleiche Differenzen.

Setzen Sie [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) auf `true` für die Werteachse und verwenden Sie [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/), um die Basis zu wählen. Dies ändert, wie die vorhandenen Werte angezeigt werden; es ändert nicht die Daten und fügt keine logarithmische Trendlinie hinzu. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist ein separates Feature.

### **Werteachse und Basis wählen**

Für ein Linien‑ oder Säulendiagramm ist die Werteachse die [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Für ein horizontales Balkendiagramm ist sie die [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Streu‑ und Blasendiagramme besitzen zwei Werteachsen, sodass Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide wählen können. Wenden Sie keine logarithmische Skalierung auf eine Kategorienachse an.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme kann eine Basis zwischen `2` und `1000` (einschließlich) verwendet werden; Bruchbasen wie `2.5` werden ebenfalls unterstützt. Mit Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende, eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragenzahlen auf der ersten Folie, dupliziert diese Folie und aktiviert eine Basis‑10‑logarithmische Werteachse auf der zweiten. Beide Folien behalten dieselben Daten.

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

// Keep the first slide linear and change only the copy's value-axis scale.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineare Skala (Folie 1):** Gleiche vertikale Abstände stehen für gleiche Unterschiede in den Anfragenzahlen. Der größte Wert dominiert das Diagramm, sodass die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint, das fünf Anfragenzahlen auf einer linearen Werteachse zeigt](value-axis-linear.png)

**Logarithmische Skala (Folie 2):** Gleiche vertikale Abstände stehen für gleiche Verhältnisse. Jeder Zeitraum hat zehnmal so viele Anfragen wie der vorherige, sodass die Punkte auf einer Basis‑10‑Skala eine gerade steigende Linie bilden. Die Achsenbeschriftungen zeigen weiterhin die ursprünglichen Anfragenzahlen an.

![Die gleichen fünf Anfragenzahlen in PowerPoint auf einer Basis‑10‑logarithmischen Werteachse](value-axis-logarithmic.png)

### **Null‑ und Negative Werte behandeln**

Eine logarithmische Skala kann nur streng positive Werte darstellen. Prüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negative Werte eine Bedeutung haben, behalten Sie eine lineare Skala bei oder zeigen Sie diese Werte gesondert an. Wenn das Ausschließen dieser Werte für die Analyse sinnvoll ist, erklären Sie das Weglassen. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Bedeutung der Daten ändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert einer logarithmischen Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Verwenden Sie [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/), um das Kreuzungsverhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, setzen Sie [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Diese Einstellungen ermöglichen es Ihnen, die Achsenkreuzung zu einer geeigneten Basislinie zu verschieben.

**Wie kann ich Teilstrich‑Beschriftungen relativ zur Achse positionieren?**

Setzen Sie [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) mit [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` oder `None`. Um die Teilstrichmarken selbst zu steuern, verwenden Sie [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) oder [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); diese sind unabhängig von der Beschriftungsposition.