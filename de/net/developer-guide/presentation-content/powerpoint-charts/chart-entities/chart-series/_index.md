---
title: Diagrammdatenserien in Präsentationen in .NET verwalten
linktitle: Datenserien
type: docs
url: /de/net/chart-series/
keywords:
- Diagrammserien
- Serienüberlappung
- Serienfarbe
- Kategorienfarbe
- Serienname
- Datenpunkt
- Serienlücke
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien in C# für PowerPoint (PPT/PPTX) verwalten, mit praktischen Codebeispielen und bewährten Methoden, um Ihre Datenpräsentationen zu verbessern."
---

## **Übersicht**

Dieser Artikel beschreibt die Rolle von [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) in Aspose.Slides für .NET und konzentriert sich darauf, wie Daten innerhalb von Präsentationen strukturiert und visualisiert werden. Diese Objekte stellen die grundlegenden Elemente bereit, die einzelne Sätze von Datenpunkten, Kategorien und Anzeigeparametern in einem Diagramm definieren. Durch die Arbeit mit [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) können Entwickler Datenquellen nahtlos integrieren und die volle Kontrolle darüber behalten, wie Informationen angezeigt werden, was zu dynamischen, datengetriebenen Präsentationen führt, die Erkenntnisse und Analysen klar vermitteln.

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt werden.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagramm Serienüberlappung festlegen**

Die [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) property steuert, wie Balken und Säulen in einem 2D‑Diagramm überlappen, indem ein Bereich von -100 bis 100 angegeben wird. Da diese Eigenschaft mit der Seriengruppe und nicht mit einzelnen Diagrammserien verknüpft ist, ist sie auf Seriene‑Ebene schreibgeschützt. Um Überlappungswerte zu konfigurieren, verwenden Sie die Lese‑/Schreib‑Eigenschaft `ParentSeriesGroup.Overlap`, die die angegebene Überlappung auf alle Serien dieser Gruppe anwendet.

Unten finden Sie ein C#‑Beispiel, das zeigt, wie eine Präsentation erstellt, ein gruppiertes Säulendiagramm hinzugefügt, die erste Diagrammserie abgerufen, die Überlappungseinstellung konfiguriert und das Ergebnis dann als PPTX‑Datei gespeichert wird:
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Setzen Sie die Serienüberlappung.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Speichern Sie die Präsentationsdatei auf dem Datenträger.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The series overlap](series_overlap.png)

## **Serienfüllfarbe ändern**

Aspose.Slides ermöglicht es, die Füllfarben von Diagrammserien einfach anzupassen, sodass Sie bestimmte Datenpunkte hervorheben und optisch ansprechende Diagramme erstellen können. Dies wird über das [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/)‑Objekt realisiert, das verschiedene Fülltypen, Farbkonfigurationen und weitere erweiterte Stiloptionen unterstützt. Nachdem Sie ein Diagramm zu einer Folie hinzugefügt und die gewünschte Serie abgerufen haben, erhalten Sie einfach die Serie und wenden die passende Füllfarbe an. Neben einfarbigen Füllungen können Sie auch Farbverläufe oder Musterfüllungen für größere Gestaltungsflexibilität nutzen. Sobald Sie die Farben nach Ihren Anforderungen festgelegt haben, speichern Sie die Präsentation, um das aktualisierte Aussehen zu übernehmen.

Das folgende C#‑Codebeispiel zeigt, wie die Farbe der ersten Serie geändert wird:
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Setzen Sie die Farbe der ersten Serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Speichern Sie die Präsentationsdatei auf dem Datenträger.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The color of the series](series_color.png)

## **Serienname ändern**

Aspose.Slides bietet eine einfache Möglichkeit, die Namen von Diagrammserien zu ändern, sodass Daten klar und sinnvoll beschriftet werden können. Durch den Zugriff auf die entsprechende Arbeitsblattzelle in den Diagrammdaten können Entwickler anpassen, wie die Daten dargestellt werden. Diese Änderung ist besonders nützlich, wenn Seriennamen basierend auf dem Kontext der Daten aktualisiert oder geklärt werden müssen. Nach dem Umbenennen der Serie kann die Präsentation gespeichert werden, um die Änderungen zu übernehmen.

Unten finden Sie ein C#‑Code‑Snippet, das diesen Vorgang in Aktion demonstriert.
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Setzen Sie den Namen der ersten Serie.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Speichern Sie die Präsentationsdatei auf dem Datenträger.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Der folgende C#‑Code zeigt eine alternative Methode, um den Seriennamen zu ändern:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Setzen Sie den Namen der ersten Serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Speichern Sie die Präsentationsdatei auf dem Datenträger.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The series name](series_name.png)

## **Automatische Serienfüllfarbe abrufen**

Aspose.Slides für .NET ermöglicht das Abrufen der automatischen Füllfarbe für Diagrammserien innerhalb eines Zeichenbereichs. Nachdem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse erstellt haben, können Sie über den Index eine Referenz zur gewünschten Folie erhalten und anschließend ein Diagramm mit Ihrem bevorzugten Typ hinzufügen (z. B. `ChartType.ClusteredColumn`). Durch den Zugriff auf die Serien im Diagramm können Sie die automatische Füllfarbe abrufen.

Der nachstehende C#‑Code demonstriert diesen Vorgang im Detail.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Holen Sie sich die Füllfarbe der Serie.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```


Ausgabe:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **Invertierte Füllfarbe für Diagrammserien festlegen**

Wenn Ihre Datenserie sowohl positive als auch negative Werte enthält, kann das einheitliche Färben jeder Spalte oder jedes Balkens das Diagramm schwer lesbar machen. Aspose.Slides für .NET ermöglicht das Zuweisen einer invertierten Füllfarbe – einer separaten Füllung, die automatisch auf Datenpunkte unter Null angewendet wird – sodass negative Werte sofort auffallen. In diesem Abschnitt lernen Sie, wie Sie diese Option aktivieren, eine passende Farbe auswählen und die aktualisierte Präsentation speichern.

Das folgende Codebeispiel demonstriert die Vorgehensweise:
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Neue Kategorien hinzufügen.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Neue Serie hinzufügen.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Die Seriendaten befüllen.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Farbeinstellungen für die Serie festlegen.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The inverted solid fill color](inverted_solid_fill_color.png)

Sie können die Füllfarbe für einen einzelnen Datenpunkt anstatt für die gesamte Serie invertieren. Greifen Sie einfach auf das gewünschte `IChartDataPoint` zu und setzen Sie dessen Eigenschaft `InvertIfNegative` auf true.

Das folgende Codebeispiel zeigt, wie das geht:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Farbe invertieren, wenn der Datenpunkt an Index 2 negativ ist.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **Bestimmte Datenpunktwerte löschen**

Manchmal enthält ein Diagramm Testwerte, Ausreißer oder veraltete Einträge, die Sie entfernen müssen, ohne die gesamte Serie neu zu erstellen. Aspose.Slides für .NET ermöglicht das Anvisieren eines beliebigen Datenpunkts über dessen Index, das Löschen seines Inhalts und das sofortige Aktualisieren des Diagramms, sodass die verbleibenden Punkte verschoben werden und die Achsen automatisch neu skaliert werden.

Das folgende Codebeispiel demonstriert die Vorgehensweise:
```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```


## **Serienlückenbreite festlegen**

Die Lückenbreite steuert den Abstand zwischen benachbarten Spalten oder Balken – breitere Lücken betonen einzelne Kategorien, während engere Lücken ein dichteres, kompakteres Erscheinungsbild erzeugen. Mit Aspose.Slides für .NET können Sie diesen Parameter für eine gesamte Serie feinjustieren und so das gewünschte visuelle Gleichgewicht Ihrer Präsentation erreichen, ohne die zugrunde liegenden Daten zu ändern.

Das folgende Codebeispiel zeigt, wie die Lückenbreite für eine Serie festgelegt wird:
```cs
ushort gapWidth = 30;

// Leere Präsentation erstellen.
using (Presentation presentation = new Presentation())
{
    // Auf die erste Folie zugreifen.
    ISlide slide = presentation.Slides[0];

    // Diagramm mit Standarddaten hinzufügen.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Präsentation auf dem Datenträger speichern.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // GapWidth-Wert festlegen.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Präsentation auf dem Datenträger speichern.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The gap width](gap_width.png)

## **FAQ**

**Gibt es ein Limit, wie viele Serien ein einzelnes Diagramm enthalten kann?**

Aspose.Slides legt keine feste Obergrenze für die Anzahl der Serien fest, die Sie hinzufügen können. Die praktische Grenze wird durch die Lesbarkeit des Diagramms und den verfügbaren Speicher Ihrer Anwendung bestimmt.

**Was ist, wenn die Spalten innerhalb eines Clusters zu eng beieinander oder zu weit auseinander liegen?**

Passen Sie die Einstellung `GapWidth` für diese Serie (oder ihre übergeordnete Seriengruppe) an. Ein Erhöhen des Wertes vergrößert den Abstand zwischen den Spalten, ein Verringern bringt sie näher zusammen.