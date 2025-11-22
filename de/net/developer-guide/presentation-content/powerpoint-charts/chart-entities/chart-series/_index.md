---
title: Diagrammserien in C# verwalten
linktitle: Diagrammserien
type: docs
url: /de/net/chart-series/
keywords:
- Diagrammserien
- Serienüberlappung
- Serienfarbe
- Kategoriefarbe
- Serienname
- Datenpunkt
- Serienlücke
- PowerPoint
- Präsentation
- C#
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien in C# für PowerPoint (PPT/PPTX) mit praxisnahen Codebeispielen und bewährten Methoden verwalten, um Ihre Datenpräsentationen zu verbessern."
---

## **Übersicht**

Dieser Artikel beschreibt die Rolle von [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) in Aspose.Slides for .NET und konzentriert sich darauf, wie Daten innerhalb von Präsentationen strukturiert und visualisiert werden. Diese Objekte stellen die grundlegenden Elemente dar, die einzelne Datenpunkt‑Sätze, Kategorien und Erscheinungsparameter in einem Diagramm definieren. Durch die Arbeit mit [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) können Entwickler zugrunde liegende Datenquellen nahtlos integrieren und die vollständige Kontrolle darüber behalten, wie Informationen angezeigt werden, was zu dynamischen, datengetriebenen Präsentationen führt, die Erkenntnisse und Analysen klar vermitteln.

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt wird.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagrammserien-Überlappung festlegen**

Die [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap)‑Eigenschaft steuert, wie Balken und Säulen in einem 2D‑Diagramm überlappen, indem ein Wertebereich von –100 bis 100 angegeben wird. Da diese Eigenschaft der Serengruppe und nicht einzelnen Diagrammserien zugeordnet ist, ist sie auf Serienebene schreibgeschützt. Um Überlappungswerte zu konfigurieren, verwenden Sie die lesbare/beschreibbare Eigenschaft `ParentSeriesGroup.Overlap`, die die angegebene Überlappung auf alle Serien in dieser Gruppe anwendet.

Unten finden Sie ein C#‑Beispiel, das zeigt, wie man eine Präsentation erstellt, ein gruppiertes Säulendiagramm hinzufügt, die erste Diagrammserie abruft, die Überlappung einstellt und das Ergebnis als PPTX‑Datei speichert:
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

    // Speichern Sie die Präsentationsdatei auf der Festplatte.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die Serienüberlappung](series_overlap.png)

## **Füllfarbe der Serie ändern**

Aspose.Slides macht es einfach, die Füllfarben von Diagrammserien anzupassen, sodass Sie bestimmte Datenpunkte hervorheben und optisch ansprechende Diagramme erstellen können. Dies wird über das [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/)‑Objekt erreicht, das verschiedene Fülltypen, Farbkonfigurationen und weitere erweiterte Stiloptionen unterstützt. Nachdem Sie ein Diagramm zu einer Folie hinzugefügt und die gewünschte Serie abgerufen haben, erhalten Sie die Serie und wenden die passende Füllfarbe an. Neben einfarbigen Füllungen können Sie auch Farbverläufe oder Musterfüllungen nutzen, um die Gestaltung zu erweitern. Sobald Sie die Farben nach Ihren Anforderungen festgelegt haben, speichern Sie die Präsentation, um das aktualisierte Aussehen abzuschließen.

Der folgende C#‑Code demonstriert, wie die Farbe der ersten Serie geändert wird:
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

    // Speichern Sie die Präsentationsdatei auf der Festplatte.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die Farbe der Serie](series_color.png)

## **Seriennamen ändern**

Aspose.Slides bietet eine einfache Möglichkeit, die Namen von Diagrammserien zu ändern, sodass Daten klar und sinnvoll beschriftet werden können. Durch den Zugriff auf die entsprechende Arbeitsblattzelle in den Diagrammdaten können Entwickler festlegen, wie die Daten präsentiert werden. Diese Anpassung ist besonders nützlich, wenn Seriennamen basierend auf dem Kontext der Daten aktualisiert oder präzisiert werden müssen. Nach der Umbenennung der Serie kann die Präsentation gespeichert werden, um die Änderungen zu übernehmen.

Untenstehend ein C#‑Code‑Snippet, das diesen Vorgang in Aktion zeigt.
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

    // Speichern Sie die Präsentationsdatei auf der Festplatte.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Der folgende C#‑Code zeigt eine alternative Methode, den Seriennamen zu ändern:
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

    // Speichern Sie die Präsentationsdatei auf der Festplatte.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der Serienname](series_name.png)

## **Automatische Füllfarbe der Serie abrufen**

Aspose.Slides for .NET ermöglicht das Abrufen der automatischen Füllfarbe für Diagrammserien innerhalb eines Plot‑Bereichs. Nachdem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse erstellt haben, können Sie die gewünschte Folie per Index abrufen und ein Diagramm des gewünschten Typs hinzufügen (z. B. `ChartType.ClusteredColumn`). Durch den Zugriff auf die Serien im Diagramm können Sie die automatische Füllfarbe ermitteln.

Der nachfolgende C#‑Code demonstriert diesen Vorgang im Detail.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Ermitteln Sie die Füllfarbe der Serie.
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


## **Invertierte Füllfarbe für Diagrammserie festlegen**

Wenn Ihre Datenserie sowohl positive als auch negative Werte enthält, kann das einheitliche Färben jeder Säule oder jedes Balkens das Diagramm schwer lesbar machen. Aspose.Slides für .NET ermöglicht das Zuweisen einer invertierten Füllfarbe – einer separaten Füllung, die automatisch auf Datenpunkte unter Null angewendet wird – sodass negative Werte auf einen Blick hervorgehoben werden. In diesem Abschnitt erfahren Sie, wie Sie diese Option aktivieren, eine passende Farbe auswählen und die aktualisierte Präsentation speichern.

Der folgende Code demonstriert die Vorgehensweise:
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

    // Serien-Daten befüllen.
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

Sie können die Füllfarbe für einen einzelnen Datenpunkt invertieren, anstatt die gesamte Serie zu ändern. Greifen Sie einfach auf das gewünschte `IChartDataPoint` zu und setzen Sie dessen `InvertIfNegative`‑Eigenschaft auf `true`.

Der folgende Code zeigt, wie das geht:
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

Manchmal enthält ein Diagramm Testwerte, Ausreißer oder veraltete Einträge, die Sie entfernen möchten, ohne die gesamte Serie neu zu erstellen. Aspose.Slides für .NET erlaubt es Ihnen, jeden Datenpunkt per Index anzusprechen, dessen Inhalt zu löschen und das Diagramm sofort zu aktualisieren, sodass die verbleibenden Punkte verschoben und die Achsen automatisch neu skaliert werden.

Der folgende Code demonstriert den Vorgang:
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


## **Lückenbreite der Serie festlegen**

Die Lückenbreite steuert den Abstand zwischen benachbarten Säulen oder Balken – breitere Lücken betonen einzelne Kategorien, während schmalere Lücken ein dichteres, kompakteres Erscheinungsbild erzeugen. Mit Aspose.Slides für .NET können Sie diesen Parameter für eine gesamte Serie feinjustieren und so genau das visuelle Gleichgewicht erreichen, das Ihre Präsentation benötigt, ohne die zugrunde liegenden Daten zu verändern.

Der folgende Code zeigt, wie Sie die Lückenbreite für eine Serie festlegen:
```cs
ushort gapWidth = 30;

// Erstelle eine leere Präsentation.
using (Presentation presentation = new Presentation())
{
    // Greife auf die erste Folie zu.
    ISlide slide = presentation.Slides[0];

    // Füge ein Diagramm mit Standarddaten hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Speichere die Präsentation auf der Festplatte.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Setze den GapWidth-Wert.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Speichere die Präsentation auf der Festplatte.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die Lückenbreite](gap_width.png)

## **FAQ**

**Gibt es ein Limit, wie viele Serien ein einzelnes Diagramm enthalten kann?**

Aspose.Slides setzt keine feste Obergrenze für die Anzahl der hinzugefügten Serien. Die praktische Grenze wird durch die Lesbarkeit des Diagramms und den verfügbaren Speicher Ihrer Anwendung bestimmt.

**Was ist, wenn die Spalten innerhalb eines Clusters zu eng beieinander liegen oder zu weit auseinander sind?**

Passen Sie die `GapWidth`‑Einstellung für diese Serie (oder deren übergeordnete Serengruppe) an. Ein höherer Wert vergrößert den Abstand zwischen den Spalten, ein niedrigerer Wert bringt sie näher zusammen.