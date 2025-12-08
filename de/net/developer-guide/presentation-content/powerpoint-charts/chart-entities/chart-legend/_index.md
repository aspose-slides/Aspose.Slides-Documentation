---
title: Diagrammlegende
type: docs
url: /de/net/chart-legend/
keywords: "Diagrammlegende, Legenden-Schriftgröße, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Positionierung und Schriftgröße für Diagrammlegende in PowerPoint-Präsentationen in C# oder .NET festlegen"
---

## **Legendenpositionierung**
Um die Legenden‑Eigenschaften festzulegen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
- Holen Sie sich eine Referenz der Folie.
- Fügen Sie der Folie ein Diagramm hinzu.
- Legen Sie die Eigenschaften der Legende fest.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir die Position und Größe der Diagramm‑Legende festgelegt.
```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Holen Sie die Referenz der Folie
ISlide slide = presentation.Slides[0];

// Fügen Sie der Folie ein gruppiertes Säulendiagramm hinzu
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Legenden-Eigenschaften festlegen
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Präsentation auf die Festplatte schreiben
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **Schriftgröße der Legende festlegen**
Aspose.Slides für .NET ermöglicht es Entwicklern, die Schriftgröße der Legende festzulegen. Bitte führen Sie die folgenden Schritte aus:

- Instanziieren Sie die `Presentation`‑Klasse.
- Erstellen Sie das Standards‑Diagramm.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
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


## **Schriftgröße einzelner Legenden‑Einträge festlegen**
Aspose.Slides für .NET ermöglicht es Entwicklern, die Schriftgröße einzelner Legenden‑Einträge festzulegen. Bitte führen Sie die folgenden Schritte aus:

- Instanziieren Sie die `Presentation`‑Klasse.
- Erstellen Sie das Standards‑Diagramm.
- Greifen Sie auf den Legenden‑Eintrag zu.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
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


## **FAQ**

**Kann ich die Legende aktivieren, sodass das Diagramm automatisch Platz dafür reserviert, anstatt es zu überlagern?**

Ja. Verwenden Sie den Nicht‑Overlay‑Modus ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`); in diesem Fall wird der Plot‑Bereich verkleinert, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legenden‑Beschriftungen erstellen?**

Ja. Lange Beschriftungen umbrechen automatisch, wenn nicht genug Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Zeilenumbruch‑Zeichen im Seriennamen unterstützt.

**Wie bringe ich die Legende dazu, das Farbschema des Präsentationsthemas zu übernehmen?**

Setzen Sie keine expliziten Farben/Füllungen/Schriften für die Legende oder deren Text. Sie erben dann vom Theme und werden bei einer Design‑Änderung korrekt aktualisiert.