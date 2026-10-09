---
title: Chart-Arbeitsmappen in Präsentationen in .NET verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/net/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsmappen-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externe Arbeitsmappe
- externe Daten
- Diagramm-Cache
- Wiederherstellung der Arbeitsmappe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für .NET: verwalten Sie mühelos Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie Diagrammdaten über Arbeitsmappen‑Streams gelesen und geschrieben werden, wie Arbeitsmappen‑Zellen als Diagramm‑Datenbeschriftungen verwendet werden, wie auf Arbeitsblatt‑Sammlungen zugegriffen wird und wie der Datentyp für Diagrammwerte angegeben wird.

Er behandelt zudem die Arbeit mit externen Arbeitsmappen als Diagrammdatenquelle. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer mit einem Diagramm verknüpften externen Arbeitsmappe abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

Für Arbeitsmappen‑Zellen, die fehlende Daten darstellen, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/net/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Daten aus ausgeblendeten Zeilen und Spalten einbeziehen**

Verwenden Sie [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) um zu steuern, ob ein Diagramm Daten aus ausgeblendeten Arbeitsblattzeilen und -spalten darstellt. Setzen Sie es auf `true`, um nur sichtbare Zellen zu plotten, oder auf `false`, um sowohl sichtbare als auch ausgeblendete Zellen einzubeziehen. Diese Einstellung steuert das Plotten des Diagramms; sie blendet Arbeitsblattzeilen oder -spalten nicht ein oder aus.

Die [Beispielpräsentation](hidden-source-data.pptx) enthält ein Säulendiagramm als erste Form auf ihrer ersten Folie. Das eingebettete Arbeitsblatt, `Sheet1`, enthält den folgenden Quellbereich, `A1:C4`. Zeile 3 und Spalte C sind ausgeblendet, aber ihre Zellen enthalten weiterhin Werte.

| Arbeitsblattzeile | A: Monat | B: Einzelhandel | C: Großhandel (ausgeblendete Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (ausgeblendete Zeile) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) auf die Quellzellen zu und lesen Sie [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) um deren ausgeblendeten Status zu prüfen. Diese Eigenschaft ist schreibgeschützt. In dieser Datei ist B2 sichtbar, B3 gehört zur ausgeblendeten Zeile und C2 zur ausgeblendeten Spalte; das Beispiel gibt `False`, `True` und `True` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten nach Änderung der Plot‑Einstellung: behalten Sie die eingebettete Arbeitsmappe mit [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) und laden Sie sie mit [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) erneut. Wenn alle Zellen einbezogen werden, verwenden Sie außerdem [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/), um den vollständigen Bereich wiederherzustellen, einschließlich der ausgeblendeten Februar‑Kategorie. Das bloße Ändern des Flags reicht nicht aus, um die zwischengespeicherten Diagrammdaten und Kategoriebeschriftungen dieses Beispiels zu aktualisieren.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Aktualisieren Sie die Diagrammdaten aus der eingebetteten Arbeitsmappe.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Stellen Sie den kompletten Quellbereich wieder her, einschließlich ausgeblendeter Kategorien.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Das Beispiel speichert zwei Versionen der Präsentation: eine nur mit den sichtbaren Einzelhandelswerten (10 und 20) und eine mit allen sechs Werten. Die untenstehenden Bilder wurden aus den gespeicherten Präsentationen nach erneutem Öffnen gerendert; beide Dateien behalten ihre zugewiesene Plot‑Einstellung bei. Zeile 3 und Spalte C bleiben in beiden eingebetteten Arbeitsmappen ausgeblendet.

| Nur sichtbare Zellen (`true`) | Alle Zellen (`false`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine ausgeblendete Zelle, die einen Wert enthält, unterscheidet sich von einer leeren Zelle. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) steuert, wie fehlende Werte angezeigt werden; sie schließt ausgeblendete Quelldaten weder ein noch aus. Siehe [Steuerung der Anzeige leerer Zellen](/slides/de/net/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Den Datenbereich eines Diagramms abrufen**

Bevor Sie Arbeitsmappendaten in einer bestehenden Präsentation aktualisieren, prüfen Sie die Quellbereiche, um zu ermitteln, welche Arbeitsblattzellen jedes Diagramm verwendet. Die Methode [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) gibt den aktuellen Datenbereich als arbeitsblattqualifizierte Formel zurück, z. B. `Sheet1!$A$1:$D$5`. Hier ist `Sheet1` der Arbeitsblattname, `!` trennt ihn vom Zellbereich, und `$A$1:$D$5` bezeichnet die Zellen A1 bis D5 einschließlich. Die Dollarzeichen kennzeichnen absolute Zeilen‑ und Spaltenbezüge.

Die Methode liest den aktuellen Bereich, ohne das Diagramm oder dessen Arbeitsmappe zu ändern. Wenn das Diagramm keine Arbeitsmappe als Datenquelle verwendet, wirft es [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Weitere Informationen finden Sie in der [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Dieses Beispiel öffnet eine Präsentation und prüft die Formen jeder Folie direkt auf Diagramme. Es gibt den Namen jedes Diagramms und dessen Quellbereich aus. Wenn ein Diagramm keine Arbeitsmappe verwendet, gibt es eine Meldung aus und fährt mit dem nächsten Diagramm fort.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**

Aspose.Slides für .NET stellt die Methoden [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) und [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) bereit, mit denen Sie Diagramm‑Datenarbeitsmappen (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine dem Quellformat ähnliche Struktur aufweisen.

Dieses Beispiel verwendet eine Präsentation mit einem Diagramm als erste Form auf der ersten Folie. Es liest die eingebettete Arbeitsmappe in einen Stream, löscht die vorhandenen Serien und Kategorien und schreibt dieselbe Arbeitsmappe zurück. Die Änderungen bleiben im Speicher; das Beispiel speichert die Präsentation nicht.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Diagrammlayout nach Arbeitsmappen‑Modifikation validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine modifizierte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategoriesammlungen bei. Diese Inkonsistenz kann dazu führen, dass [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Leeren Sie die vorhandenen Serien und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben. Dieses Beispiel verwendet ein Diagramm, das die erste Form auf der ersten Folie ist. Der Kommentar markiert die Stelle, an der die Arbeitsmappe bearbeitet würde; das ausführbare Beispiel schreibt die ursprüngliche Arbeitsmappe zurück und validiert das Layout im Speicher.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Modifiziere hier den Arbeitsmappen-Stream, zum Beispiel mit Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Das Leeren der Sammlungen entfernt veraltete Datenreferenzen, bevor die Arbeitsmappe zurückgeschrieben wird. Stellen Sie vor der Verwendung des Diagramms alle erforderlichen Serien‑ und Kategoriemappings für die aktualisierte Arbeitsmappe wieder her.

## **Eine Arbeitsmappen‑Zelle als Diagramm‑Datenbeschriftung festlegen**

Sie können Text aus Arbeitsmappen‑Zellen als Diagramm‑Datenbeschriftungen verwenden.

Dieses Beispiel fügt einer bestehenden Präsentation auf der ersten Folie ein Blasendiagramm mit Standarddaten hinzu. Es verwendet die Zellen A10:A12 im Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Serie, aktiviert Beschriftungen aus Zellen und speichert die aktualisierte Präsentation.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Arbeitsblätter verwalten**

Die Eigenschaft [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) bietet Zugriff auf die Arbeitsblätter einer Diagramm‑Arbeitsmappe. Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und gibt jeden Arbeitsblattnamen in der Konsole aus.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Datentyp der Datenquelle angeben**

Dieses Beispiel erstellt ein 3D‑Säulendiagramm mit Standarddaten und legt zwei Seriennamen mithilfe verschiedener Datenquellen fest. Der erste Name verwendet ein Zeichenketten‑Literal; der zweite verwendet die Zelle C1 im Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) wählt die Quelle für jeden Namen aus. Das Beispiel speichert die Präsentation mit den aktualisierten Seriennamen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Nicht unterstützte eingebettete Arbeitsmappen‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die Eigenschaft [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) auf [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel untersucht die Formen auf der ersten Folie einer bestehenden Präsentation, überspringt Nicht‑Diagramm‑Formen und gibt für jedes Diagramm mit einer eingebetteten .xlsb‑Arbeitsmappe eine Diagnosemeldung aus.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Lesen oder ändern Sie hier unterstützte Diagramm‑Arbeitsmappendaten.
}
```

## **Externe Arbeitsmappe**

Aspose.Slides unterstützt die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme.

### **Eine externe Arbeitsmappe erstellen**

Verwenden Sie [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) und [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), um eine eingebettete Diagramm‑Arbeitsmappe in eine Datei zu exportieren und das Diagramm mit dieser externen Arbeitsmappe zu verknüpfen.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und exportiert dessen Arbeitsmappe. Es schließt den Ausgabestream, bevor es die externe Arbeitsmappe als Datenquelle für das Diagramm zuweist, und speichert dann die verknüpfte Präsentation.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Eine externe Arbeitsmappe festlegen**

Mit der Methode [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) können Sie einer Diagramm‑Arbeitsmappe eine externe Arbeitsmappe als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einer externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Obwohl Sie die Daten in Arbeitsmappen, die an entfernten Speicherorten oder Ressourcen abgelegt sind, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle nutzen. Wenn ein relativer Pfad für eine externe Arbeitsmappe angegeben wird, wird er automatisch in einen vollständigen Pfad umgewandelt.

Dieses Beispiel verwendet eine externe Arbeitsmappe, deren Arbeitsblatt `Sheet1` einen Seriennamen in B1, Kategorinamen in A2:A4 und numerische Werte in B2:B4 enthält. Das Beispiel erstellt ein Kreisdiagramm, verknüpft die Arbeitsmappe und verwendet [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/), um A1:B4 einer Serie und drei Kategorien zuzuordnen. Es speichert die Präsentation mit dem verknüpften Diagramm.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

Der Parameter `updateChartData` von [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) steuert, ob die Arbeitsmappe geladen wird.
- Wenn `updateChartData` `false` ist, wird nur der Pfad zur Arbeitsmappe aktualisiert. Die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert, sodass die Arbeitsmappe nicht vorhanden sein kann.
- Wenn `updateChartData` `true` ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

Das folgende Beispiel weist eine Platzhalter‑URL zu, wobei `updateChartData` auf `false` gesetzt ist. Es behält die Standarddaten des Kreisdiagramms bei und speichert die Präsentation, ohne die nicht verfügbare Arbeitsmappe zu laden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms ermitteln**

Um die mit einem Diagramm verknüpfte Arbeitsmappe zu ermitteln, prüfen Sie, ob das Diagramm eine externe Datenquelle verwendet, und rufen Sie dessen Arbeitsmappen‑Pfad ab.

Dieses Beispiel untersucht die erste Form auf der ersten Folie einer Präsentation mit einer verknüpften externen Arbeitsmappe. Ist es ein Diagramm, das mit einer externen Arbeitsmappe verknüpft ist, gibt das Beispiel [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) in der Konsole aus. Anschließend speichert es eine Kopie der Präsentation.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen auf dieselbe Weise bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses Beispiel verwendet ein Diagramm, das die erste Form auf der ersten Folie ist und mit einer zugänglichen externen Arbeitsmappe verknüpft ist. Es setzt den zellbasierten Wert des ersten Datenpunkts der ersten Serie auf 100 und speichert die aktualisierte Präsentation. Das Bearbeiten von Zellwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn das Original erhalten bleiben soll.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Eine Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Verwendet ein Diagramm eine fehlende oder nicht verfügbare externe Arbeitsmappe, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), konfigurieren Sie dessen [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), und setzen Sie [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) auf `true`, bevor Sie die Präsentation öffnen.

Das folgende C#‑Beispiel stellt Arbeitsmappendaten für ein Diagramm wieder her, das die erste Form auf der ersten Folie ist und auf eine nicht verfügbare externe Arbeitsmappe verweist. Es greift über [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) und [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) auf die wiederhergestellten Daten zu:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Lese oder ändere hier die wiederhergestellten Arbeitsmappendaten.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten eine akzeptable Alternative ist, da der Cache möglicherweise nicht die Änderungen enthält, die an der externen Arbeitsmappe nach der letzten Aktualisierung der Präsentation vorgenommen wurden.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**  
Ja. Ein Diagramm verfügt über einen [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) und einen [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); ist die Quelle eine externe Arbeitsmappe, können Sie den vollständigen Pfad lesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**  
Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass ein Verschieben der Arbeitsmappe ein Aktualisieren des Links erfordern kann.

**Kann ich Arbeitsmappen auf Netzwerkressourcen/Freigaben verwenden?**  
Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von entfernten Arbeitsmappen über Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle verwendet werden.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**  
Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Das Bearbeiten von zellbasierten Diagrammdaten kann zudem die verknüpfte lokale XLSX‑Datei aktualisieren. Verwenden Sie eine Kopie der Arbeitsmappe, wenn das Original unverändert bleiben muss.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**  
Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz ist, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/net/)) und auf diese zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**  
Ja. Jedes Diagramm speichert seine eigene Verknüpfung. Zeigen sie alle auf dieselbe Datei, wird eine Aktualisierung dieser Datei beim nächsten Laden der Daten in jedem Diagramm berücksichtigt.