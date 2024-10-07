---
title: Diagramm Legende
type: docs
url: /net/chart-legend/
keywords: "Diagramm legende, legende schriftgröße, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Positionierung und Schriftgröße für die Diagrammlegende in PowerPoint-Präsentationen in C# oder .NET festlegen"
---

## **Positionierung der Legende**
Um die Eigenschaften der Legende festzulegen. Bitte folgen Sie den folgenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Holen Sie sich eine Referenz zur Folie.
- Fügen Sie ein Diagramm zur Folie hinzu.
- Legen Sie die Eigenschaften der Legende fest.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir die Position und Größe für die Diagrammlegende festgelegt.

```c#
// Erstellen Sie eine Instanz der Klasse Presentation
Presentation presentation = new Presentation();

// Holen Sie sich eine Referenz zur Folie
ISlide slide = presentation.Slides[0];

// Fügen Sie ein gruppiertes Säulendiagramm zur Folie hinzu
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Legen Sie die Eigenschaften der Legende fest
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Schreiben Sie die Präsentation auf die Festplatte
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **Schriftgröße der Legende festlegen**
Aspose.Slides für .NET ermöglicht es Entwicklern, die Schriftgröße der Legende festzulegen. Bitte folgen Sie den folgenden Schritten:

- Instanziieren Sie die Klasse `Presentation`.
- Erstellen Sie das Standarddiagramm.
- Legen Sie die Schriftgröße fest.
- Legen Sie den minimalen Achsenwert fest.
- Legen Sie den maximalen Achsenwert fest.
- Schreiben Sie die Präsentation auf die Festplatte.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.MinValue = -5;
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.MaxValue = 10;

    pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Schriftgröße der einzelnen Legende festlegen**
Aspose.Slides für .NET ermöglicht es Entwicklern, die Schriftgröße der einzelnen Legendeneinträge festzulegen. Bitte folgen Sie den folgenden Schritten:

- Instanziieren Sie die Klasse `Presentation`.
- Erstellen Sie das Standarddiagramm.
- Greifen Sie auf den Legendeeintrag zu.
- Legen Sie die Schriftgröße fest.
- Legen Sie den minimalen Achsenwert fest.
- Legen Sie den maximalen Achsenwert fest.
- Schreiben Sie die Präsentation auf die Festplatte.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

    tf.PortionFormat.FontBold = NullableBool.True;
    tf.PortionFormat.FontHeight = 20;
    tf.PortionFormat.FontItalic = NullableBool.True;
    tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
    tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    pres.Save("output.pptx", SaveFormat.Pptx);
}
```