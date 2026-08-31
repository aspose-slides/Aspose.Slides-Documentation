---
title: Diagramm-Arbeitsmappen in Präsentationen verwalten in .NET
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
- Arbeitsmappen-Wiederherstellung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für .NET: verwalten Sie Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp für Diagrammwerte festlegt.

Er behandelt außerdem die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer externen Arbeitsmappe, die mit einem Diagramm verknüpft ist, abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**
Aspose.Slides bietet die [ReadWorkbookStream](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdata/readworkbookstream/) und [WriteWorkbookStream](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdata/writeworkbookstream/) Methoden, mit denen Sie Diagramm‑Arbeitsmappen (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis:** Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine Struktur besitzen, die der Quelle ähnlich ist.

Dieser C#‑Code demonstriert einen Beispielvorgang:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

### **Diagrammlayout nach Arbeitsmappen‑Änderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine modifizierte ersetzen, behält das Diagramm seine ursprünglichen Reihen‑ und Kategorien‑Sammlungen bei. Diese Diskrepanz kann dazu führen, dass [IChart.ValidateChartLayout](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/validatechartlayout/) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die bestehenden Reihen und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben.

```csharp
// Nach dem Ändern des Arbeitsmappen-Streams (z. B. mit Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Bestehende Datenreferenzen löschen.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Das Leeren der Sammlungen stellt sicher, dass die Diagrammdatenstruktur mit der neuen Arbeitsmappe übereinstimmt, sodass `ValidateChartLayout` ohne Fehler abgeschlossen werden kann.

## **Eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein Bubble‑Diagramm mit einigen Daten hinzu.  
4. Greifen Sie auf die Diagramm‑Reihe zu.  
5. Legen Sie die Arbeitsmappen‑Zelle als Datenbeschriftung fest.  
6. Speichern Sie die Präsentation.

Dieser C#‑Code zeigt, wie Sie eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt 

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Arbeitsblätter verwalten**

Dieser C#‑Code demonstriert einen Vorgang, bei dem die Eigenschaft [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Datentyp der Datenquelle angeben**

Dieser C#‑Code zeigt, wie Sie einen Typ für eine Datenquelle angeben:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Nicht unterstützte eingebettete Arbeitsmappen‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet werden kann. Sie können die Eigenschaft `EmbeddedWorkbookType` auf [IChartData](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/net/aspose.slides.charts/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Eingebettete Arbeitsmappe ist im .xlsb-Format, das nicht unterstützt wird.
            continue;
        }

        // Lesen oder Ändern der Diagramm-Arbeitsmappendaten hier.
    }
}
```

## **Externe Arbeitsmappe**

{{% alert color="info" %}} 
Ab [Aspose.Slides 19.4](https://docs.aspose.com/slides/de/net/aspose-slides-for-net-19-4-release-notes/) haben wir die Unterstützung für externe Arbeitsmappen als Datenquelle für Diagramme implementiert.
{{% /alert %}} 

### **Externe Arbeitsmappe erstellen**
Mit den Methoden **`ReadWorkbookStream`** und **`SetExternalWorkbook`** können Sie entweder eine externe Arbeitsmappe von Grund auf erstellen oder eine interne Arbeitsmappe extern machen.

Dieser C#‑Code demonstriert den Erstellungsprozess einer externen Arbeitsmappe:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Externe Arbeitsmappe zuweisen**
Mit der Methode **`SetExternalWorkbook`** können Sie einer Diagramm‑Formular ein externes Arbeitsmappen‑Objekt als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um einen Pfad zur externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Während Sie die Daten in Arbeitsmappen, die an entferntem Ort oder in Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle nutzen. Wird ein relativer Pfad für eine externe Arbeitsmappe angegeben, wird er automatisch in einen vollständigen Pfad umgewandelt.

Dieser C#‑Code zeigt, wie Sie eine externe Arbeitsmappe zuweisen:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Der Pfad zum Dokumentenverzeichnis.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

Der `ChartData`‑Parameter (unter der `SetExternalWorkbook`‑Methode) gibt an, ob eine Excel‑Arbeitsmappe geladen werden soll oder nicht.

* Wenn der Wert von `ChartData` auf `false` gesetzt ist, wird nur der Arbeitsmappen‑Pfad aktualisiert – die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Diese Einstellung ist sinnvoll, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.  
* Wenn der Wert von `ChartData` auf `true` gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Erstellen Sie ein Objekt für die Diagramm‑Form.  
4. Erstellen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), das die Datenquelle des Diagramms darstellt.  
5. Geben Sie die entsprechende Bedingung an, basierend darauf, dass der Quelltyp dem Typ der externen Arbeitsmappen‑Datenquelle entspricht.

Dieser C#‑Code demonstriert den Vorgang:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Speichert die Präsentation
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen genauso bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieser C#‑Code ist eine Implementierung des beschriebenen Prozesses:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm eine externe Arbeitsmappe verwendet, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/), konfigurieren Sie dessen [SpreadsheetOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/spreadsheetoptions/), und setzen Sie [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) auf `true`, bevor Sie die Präsentation öffnen.

Das folgende C#‑Beispiel öffnet eine Präsentation, deren Diagramm auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [IChart.ChartData](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/chartdata/) und [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdata/chartdataworkbook/) auf die wiederhergestellten Daten zu:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine `InvalidOperationException`. Aktivieren Sie die Wiederherstellung nur, wenn die Nutzung der zwischengespeicherten Diagrammdaten als akzeptabler Fallback gilt, da der Cache möglicherweise keine Änderungen enthält, die nach dem letzten Aktualisieren der Präsentation an der externen Arbeitsmappe vorgenommen wurden.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [data source type](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chartdata/datasourcetype/) und einen [path to an external workbook](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chartdata/externalworkbookpath/); ist die Quelle eine externe Arbeitsmappe, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wird ein relativer Pfad angegeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Projektportabilität; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen verwenden, die auf Netzwerkressourcen/Freigaben liegen?**

Ja, solche Arbeitsmappen können als externe Datenquelle genutzt werden. Das direkte Bearbeiten entfernter Arbeitsmappen über Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides die externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chartdata/externalworkbookpath/) und verwendet ihn zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verlinken kein Passwort. Ein gängiger Ansatz besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](/cells/net/)) und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Zeigen sie alle auf dieselbe Datei, wird ein Update dieser Datei in jedem Diagramm beim nächsten Laden der Daten reflektiert.