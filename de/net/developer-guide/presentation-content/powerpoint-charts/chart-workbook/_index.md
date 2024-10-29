---
title: Diagrammarbeitsbuch
type: docs
weight: 70
url: /de/net/chart-workbook/
keywords: "Diagrammarbeitsbuch, Diagrammdaten, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Diagrammarbeitsbuch in PowerPoint-Präsentation in C# oder .NET"
---

## **Diagrammdaten aus Arbeitsbuch festlegen**
Aspose.Slides bietet die [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) und [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) Methoden, die es Ihnen ermöglichen, Diagrammdatenarbeitsbücher (die mit Aspose.Cells bearbeitet wurden) zu lesen und zu schreiben. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelle aufweisen.

Dieser C#-Code demonstriert eine Beispieloperation:

```c#
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

## **Arbeitsbuchzelle als Diagramm-Datenbeschriftung festlegen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie ein Blasendiagramm mit einigen Daten hinzu.
1. Greifen Sie auf die Diagrammserien zu.
1. Legen Sie die Arbeitsbuchzelle als Datenbeschriftung fest.
1. Speichern Sie die Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie eine Arbeitsbuchzelle als Diagramm-Datenbeschriftung festlegen:

```c#
string lbl0 = "Wert der Beschriftung 0 Zelle";
string lbl1 = "Wert der Beschriftung 1 Zelle";
string lbl2 = "Wert der Beschriftung 2 Zelle";

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

Dieser C#-Code demonstriert eine Operation, bei der die [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) Eigenschaft verwendet wird, um auf eine Sammlung von Arbeitsblättern zuzugreifen:

```csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Datentyp für die Datenquelle angeben**

Dieser C#-Code zeigt Ihnen, wie Sie einen Typ für eine Datenquelle angeben:

```c#
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

## **Externes Arbeitsbuch**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/), haben wir die Unterstützung für externe Arbeitsbücher als Datenquelle für Diagramme implementiert.
{{% /alert %}} 

### **Externes Arbeitsbuch erstellen**
Mit den Methoden **`ReadWorkbookStream`** und **`SetExternalWorkbook`** können Sie entweder ein externes Arbeitsbuch von Grund auf neu erstellen oder ein internes Arbeitsbuch extern machen.

Dieser C#-Code demonstriert den Prozess zur Erstellung eines externen Arbeitsbuchs:

```c#
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

### **Externes Arbeitsbuch festlegen**
Mit der Methode **`SetExternalWorkbook`** können Sie einem Diagramm ein externes Arbeitsbuch als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zum externen Arbeitsbuch (falls dieses verschoben wurde) zu aktualisieren.

Obwohl Sie die Daten in Arbeitsbüchern, die an entfernten Standorten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Arbeitsbücher weiterhin als externe Datenquelle verwenden. Wenn der relative Pfad für ein externes Arbeitsbuch angegeben wird, wird er automatisch in einen vollständigen Pfad umgewandelt.

Dieser C#-Code zeigt Ihnen, wie Sie ein externes Arbeitsbuch festlegen:

```c#
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

Der `ChartData` Parameter (unter der Methode `SetExternalWorkbook`) wird verwendet, um anzugeben, ob ein Excel-Arbeitsbuch geladen werden soll oder nicht.

* Wenn der Wert `ChartData` auf `false` gesetzt ist, wird nur der Arbeitsbuchpfad aktualisiert – die Diagrammdaten werden nicht aus dem Zielarbeitsbuch geladen oder aktualisiert. Diese Einstellung sollten Sie möglicherweise verwenden, wenn sich das Zielarbeitsbuch nicht existiert oder nicht verfügbar ist. 
* Wenn der Wert `ChartData` auf `true` gesetzt ist, werden die Diagrammdaten aus dem Zielarbeitsbuch aktualisiert.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Pfad zur externen Datenquelle des Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie über ihren Index.
1. Erstellen Sie ein Objekt für die Diagrammform.
1. Erstellen Sie ein Objekt für den Typ der Quelle (`ChartDataSourceType`), das die Datenquelle des Diagramms darstellt.
1. Geben Sie die relevante Bedingung an, basierend darauf, dass der Quelltyp derselbe wie der Typ der externen Arbeitsbuchdatenquelle ist.

Dieser C#-Code demonstriert die Operation:

```c#
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

Sie können die Daten in externen Arbeitsbüchern genauso bearbeiten, wie Sie Änderungen an den Inhalten interner Arbeitsbücher vornehmen. Wenn ein externes Arbeitsbuch nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieser C#-Code ist eine Implementierung des beschriebenen Prozesses:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```