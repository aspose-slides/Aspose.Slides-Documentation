---
title: Diagrammdaten‑Tabellen in Präsentationen in .NET anpassen
linktitle: Daten‑Tabelle
type: docs
url: /de/net/chart-data-table/
keywords:
- Diagrammdaten
- Daten‑Tabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Passen Sie Schriftarten, Rahmen und Legenden‑Schlüssel von Diagrammdaten‑Tabellen in PowerPoint‑Präsentationen mit Aspose.Slides für .NET und C# an."
---
## **Übersicht**

Aspose.Slides für .NET ermöglicht das Anzeigen einer Daten‑Tabelle eines Diagramms und das Anpassen der Textformatierung, der Rahmen und der Legenden‑Schlüssel. Dieser Artikel erklärt, wie die Tabelle aktiviert, ihr Text formatiert, jeder Randtyp gesteuert und Legenden‑Schlüssel ein‑ oder ausgeblendet werden können. Die Beispiele speichern die konfigurierten Diagramme in PPTX‑Dateien.

## **Schrifteigenschaften festlegen**

Um die Daten‑Tabelle eines Diagramms anzuzeigen, setzen Sie [HasDataTable](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chart/hasdatatable/) auf `true`. Verwenden Sie [ChartDataTable](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chart/chartdatatable/), um auf die Tabelle zuzugreifen und deren Textformatierung zu konfigurieren.

1. Laden Sie die Präsentation mithilfe der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Fügen Sie der ersten Folie ein gruppiertes Säulendiagramm hinzu.
1. Aktivieren Sie die Daten‑Tabelle des Diagramms.
1. Aktivieren Sie Fettschrift mit [FontBold](https://reference.aspose.com/slides/de/net/aspose.slides/baseportionformat/fontbold/) und setzen Sie [FontHeight](https://reference.aspose.com/slides/de/net/aspose.slides/baseportionformat/fontheight/) auf `20` für Text mit 20 Punkt.
1. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erfordert `test.pptx` im Arbeitsverzeichnis mit mindestens einer Folie. Es fügt ein Diagramm mit Standarddaten an der Position (50, 50) hinzu, mit einer Breite von 600 Punkten und einer Höhe von 400 Punkten. Die gespeicherte `output.pptx` enthält das Diagramm mit aktivierter Daten‑Tabelle und den angegebenen Schriftarteinstellungen.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Daten‑Tabellenränder anpassen**

Aktivieren Sie die Tabelle mit [IChart.HasDataTable](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/hasdatatable/) und greifen Sie über [IChart.ChartDataTable](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/chartdatatable/) darauf zu. Sie können drei Arten von Rahmen unabhängig voneinander steuern:

- [HasBorderHorizontal](https://reference.aspose.com/slides/de/net/aspose.slides.charts/idatatable/hasborderhorizontal/) steuert die horizontalen Zellenrahmen.
- [HasBorderVertical](https://reference.aspose.com/slides/de/net/aspose.slides.charts/idatatable/hasbordervertical/) steuert die vertikalen Zellenrahmen.
- [HasBorderOutline](https://reference.aspose.com/slides/de/net/aspose.slides.charts/idatatable/hasborderoutline/) steuert den äußeren Rahmen der Tabelle.

Setzen Sie jede Eigenschaft auf `true`, um die Rahmen anzuzeigen, oder auf `false`, um sie zu verbergen. Das folgende Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten, zeigt horizontale Rahmen und den äußeren Rahmen an und verbirgt vertikale Rahmen. Es erfordert keine Eingabedatei. Position und Größe des Diagramms sind in Punkten angegeben.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Der Vergleich unten verwendet in allen vier Fällen dieselben Diagrammdaten und dieselbe Einstellung für Legenden‑Schlüssel. Ausgangspunkt ist ein Diagramm mit allen aktivierten Rahmen; jede weitere Variante deaktiviert genau eine Rahmen‑Eigenschaft. Die linke‑untere Variante entspricht den Rahmeneinstellungen des Beispiels.

![Diagrammdaten‑Tabellen mit allen Rahmen aktiviert, ohne horizontale Rahmen, ohne vertikale Rahmen und ohne äußeren Rahmen](data-table-borders.png)

## **Legenden‑Schlüssel anzeigen oder ausblenden**

Legenden‑Schlüssel sind kleine farbige Markierungen neben den Seriennamen in der Daten‑Tabelle. Sie helfen den Lesern, jede Tabellenzeile einer Diagrammserie zuzuordnen. Setzen Sie [ShowLegendKey](https://reference.aspose.com/slides/de/net/aspose.slides.charts/idatatable/showlegendkey/) auf `true`, um diese Markierungen anzuzeigen, oder auf `false`, um sie zu verbergen.

Die separate Legende des Diagramms wird über [IChart.HasLegend](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/haslegend/) gesteuert. Diese Einstellungen sind unabhängig: Das Ausblenden der separaten Legende versteckt die Schlüssel in der Daten‑Tabelle nicht, und das Ausblenden der Tabellenschlüssel versteckt die separate Legende nicht.

Das folgende Beispiel erstellt ein Diagramm mit Standarddaten, aktiviert dessen Daten‑Tabelle und zeigt Legenden‑Schlüssel darin an, während die separate Legende ausgeblendet wird. Alle Tabellengrenzen sind explizit aktiviert. Keine Eingabedatei ist erforderlich. Um nur die Tabellenschlüssel zu verbergen, ändern Sie `dataTable.ShowLegendKey` auf `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Der Vergleich unten zeigt dieselbe Tabelle mit aktivierten und deaktivierten Legenden‑Schlüsseln. Alle Rahmen bleiben aktiviert, und die separate Diagrammlegende ist in beiden Fällen ausgeblendet.

![Diagrammdaten‑Tabellen mit Legenden‑Schlüsseln links angezeigt und rechts ausgeblendet](data-table-legend-keys.png)

## **FAQ**

**Kann ich Legenden‑Schlüssel in der Daten‑Tabelle eines Diagramms anzeigen?**

Ja. Setzen Sie [ShowLegendKey](https://reference.aspose.com/slides/de/net/aspose.slides.charts/datatable/showlegendkey/) auf `true`, um Legenden‑Schlüssel anzuzeigen, oder auf `false`, um sie zu verbergen.

**Bleibt die Daten‑Tabelle beim Export der Präsentation nach PDF, HTML oder Bildern erhalten?**

Ja. Aspose.Slides rendert das Diagramm und seine angezeigte Daten‑Tabelle als Teil der Folie, wenn Sie zu [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [HTML](/slides/de/net/convert-powerpoint-to-html/) oder [Bildern](/slides/de/net/convert-powerpoint-to-png/) exportieren.

**Kann ich mit Daten‑Tabellen in Diagrammen arbeiten, die aus einer Vorlage geladen wurden?**

Ja. Für ein Diagramm, das aus einer vorhandenen Präsentation oder Vorlage geladen wurde, verwenden Sie [HasDataTable](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chart/hasdatatable/), um zu prüfen oder zu ändern, ob die Daten‑Tabelle angezeigt wird.

**Wie finde ich Diagramme, bei denen die Daten‑Tabelle aktiviert ist?**

Iterieren Sie über die Shapes auf jeder Folie, identifizieren Sie die Diagramme und prüfen Sie deren [HasDataTable](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chart/hasdatatable/)-Eigenschaft. Ein Wert von `true` zeigt an, dass die Daten‑Tabelle aktiviert ist.