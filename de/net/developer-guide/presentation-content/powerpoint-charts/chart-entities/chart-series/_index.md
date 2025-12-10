---
title: Verwalten von Diagramm‑Datenserien in Präsentationen in .NET
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
- Serienabstand
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien in C# für PowerPoint (PPT/PPTX) mit praktischen Codebeispielen und bewährten Methoden verwalten, um Ihre Datenpräsentationen zu verbessern."
---

## **Übersicht**

Dieser Artikel beschreibt die Rolle von [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) in Aspose.Slides für .NET und konzentriert sich darauf, wie Daten in Präsentationen strukturiert und visualisiert werden. Diese Objekte stellen die Grundelemente dar, die einzelne Datensätze, Kategorien und Anzeigeparameter in einem Diagramm definieren. Durch die Arbeit mit [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) können Entwickler Datenquellen nahtlos integrieren und die vollständige Kontrolle darüber behalten, wie Informationen angezeigt werden, was zu dynamischen, datengetriebenen Präsentationen führt, die Erkenntnisse und Analysen klar vermitteln.

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt werden.

![Diagramm‑Serie‑PowerPoint](chart-series-powerpoint.png)

## **Festlegen der Diagramm-Serienüberlappung**

Die Eigenschaft [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) steuert, wie Balken und Säulen in einem 2D‑Diagramm überlappen, indem ein Bereich von –100 bis 100 angegeben wird. Da diese Eigenschaft der Seriengruppe und nicht einzelnen Diagrammserien zugeordnet ist, ist sie auf Serienebene schreibgeschützt. Um Überlappungswerte zu konfigurieren, verwenden Sie die lese‑/schreibbare Eigenschaft `ParentSeriesGroup.Overlap`, die die angegebene Überlappung auf alle Serien in dieser Gruppe anwendet.

Im Folgenden ein C#‑Beispiel, das zeigt, wie man eine Präsentation erstellt, ein gruppiertes Säulendiagramm hinzufügt, die erste Diagrammserie zugreift, die Überlappungseinstellung konfiguriert und das Ergebnis als PPTX‑Datei speichert:
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügt ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Setzt die Serienüberlappung.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Speichert die Präsentationsdatei auf dem Datenträger.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die Serienüberlappung](series_overlap.png)

## **Ändern der Füllfarbe der Serie**

Aspose.Slides ermöglicht es, die Füllfarben von Diagrammserien einfach anzupassen, sodass Sie bestimmte Datenpunkte hervorheben und ansprechende Diagramme erstellen können. Dies geschieht über das [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/)-Objekt, das verschiedene Fülltypen, Farbkonfigurationen und weitere erweiterte Stiloptionen unterstützt. Nachdem ein Diagramm zu einer Folie hinzugefügt und die gewünschte Serie ausgewählt wurde, holen Sie die Serie und wenden die passende Füllfarbe an. Neben einfarbigen Füllungen können Sie auch Farbverläufe oder Musterfüllungen für mehr Gestaltungsflexibilität nutzen. Sobald Sie die Farben nach Ihren Vorgaben gesetzt haben, speichern Sie die Präsentation, um das aktualisierte Aussehen zu übernehmen.

Der folgende C#‑Code zeigt, wie die Farbe der ersten Serie geändert wird:
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügt ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Setzt die Farbe der ersten Serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Speichert die Präsentationsdatei auf dem Datenträger.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die Farbe der Serie](series_color.png)

## **Ändern des Seriennamens**

Aspose.Slides bietet eine einfache Möglichkeit, die Namen von Diagrammserien zu ändern, sodass Daten klar und aussagekräftig beschriftet werden können. Durch den Zugriff auf die entsprechende Arbeitsblattzelle in den Diagrammdaten können Entwickler das Erscheinungsbild der Daten anpassen. Diese Änderung ist besonders nützlich, wenn Seriennamen basierend auf dem Kontext der Daten aktualisiert oder präzisiert werden müssen. Nach dem Umbenennen der Serie kann die Präsentation gespeichert werden, um die Änderungen zu übernehmen.

Nachfolgend ein C#‑Code‑Snippet, das diesen Vorgang demonstriert:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügt ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Setzt den Namen der ersten Serie.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Speichert die Präsentationsdatei auf dem Datenträger.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Der folgende C#‑Code zeigt eine alternative Methode, den Seriennamen zu ändern:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügt ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Setzt den Namen der ersten Serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Speichert die Präsentationsdatei auf dem Datenträger.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der Serienname](series_name.png)

## **Abrufen der automatischen Serienfüllfarbe**

Aspose.Slides für .NET ermöglicht das Abrufen der automatischen Füllfarbe für Diagrammserien innerhalb eines Plot‑Bereichs. Nachdem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse erstellt haben, können Sie per Index auf die gewünschte Folie zugreifen und ein Diagramm des gewünschten Typs (z. B. `ChartType.ClusteredColumn`) hinzufügen. Durch den Zugriff auf die Serien im Diagramm erhalten Sie die automatische Füllfarbe.

Der nachstehende C#‑Code demonstriert diesen Vorgang im Detail:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügt ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Ermittelt die Füllfarbe der Serie.
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


## **Festlegen einer invertierten Füllfarbe für eine Diagrammserie**

Wenn Ihre Datenserie sowohl positive als auch negative Werte enthält, kann die einheitliche Farbgebung von Säulen oder Balken das Diagramm schwer lesbar machen. Aspose.Slides für .NET ermöglicht das Zuweisen einer invertierten Füllfarbe – einer separaten Füllung, die automatisch auf Datenpunkte unter null angewendet wird –, sodass negative Werte sofort ins Auge springen. In diesem Abschnitt erfahren Sie, wie Sie diese Option aktivieren, eine geeignete Farbe auswählen und die aktualisierte Präsentation speichern.

Das folgende Beispiel demonstriert die Vorgehensweise:
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

    // Seriendaten befüllen.
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

![Die invertierte einfarbige Füllfarbe](inverted_solid_fill_color.png)

Sie können die invertierte Füllfarbe auch nur für einen einzelnen Datenpunkt statt für die gesamte Serie festlegen. Greifen Sie einfach auf das gewünschte `IChartDataPoint` zu und setzen Sie dessen `InvertIfNegative`‑Eigenschaft auf true.

Das folgende Beispiel zeigt, wie das geht:
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


## **Löschen bestimmter Datenpunktwerte**

Manchmal enthält ein Diagramm Testwerte, Ausreißer oder veraltete Einträge, die Sie entfernen möchten, ohne die gesamte Serie neu aufzubauen. Aspose.Slides für .NET ermöglicht das Zielgerichtete Ansteuern eines Datenpunkts per Index, das Löschen seines Inhalts und das sofortige Aktualisieren des Plots, sodass die verbleibenden Punkte verschoben werden und die Achsen automatisch neu skaliert werden.

Das folgende Beispiel demonstriert die Vorgehensweise:
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


## **Festlegen der Serienabstandsbreite**

Die Abstandsbreite steuert den Abstand zwischen benachbarten Säulen oder Balken – breitere Abstände betonen einzelne Kategorien, während engere Abstände ein kompakteres Bild erzeugen. Mit Aspose.Slides für .NET können Sie diesen Parameter für eine gesamte Serie feinjustieren und so das gewünschte visuelle Gleichgewicht Ihrer Präsentation erreichen, ohne die zugrunde liegenden Daten zu ändern.

Das folgende Beispiel zeigt, wie die Abstandsbreite einer Serie festgelegt wird:
```cs
ushort gapWidth = 30;

// Erstelle eine leere Präsentation.
using (Presentation presentation = new Presentation())
{
    // Greife auf die erste Folie zu.
    ISlide slide = presentation.Slides[0];

    // Füge ein Diagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Speichere die Präsentation auf dem Datenträger.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Setze den GapWidth-Wert.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Speichere die Präsentation auf dem Datenträger.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die Abstandsbreite](gap_width.png)

## **FAQ**

**Gibt es ein Limit, wie viele Serien ein einzelnes Diagramm enthalten kann?**

Aspose.Slides legt keine feste Obergrenze für die Anzahl der hinzugefügten Serien fest. Die praktische Grenze wird durch die Lesbarkeit des Diagramms und den verfügbaren Speicher Ihrer Anwendung bestimmt.

**Was tun, wenn die Säulen innerhalb eines Clusters zu eng beieinander oder zu weit auseinander liegen?**

Passen Sie die Einstellung `GapWidth` für diese Serie (oder deren übergeordnete Seriengruppe) an. Ein höherer Wert vergrößert den Abstand zwischen den Säulen, ein niedrigerer Wert bringt sie näher zusammen.