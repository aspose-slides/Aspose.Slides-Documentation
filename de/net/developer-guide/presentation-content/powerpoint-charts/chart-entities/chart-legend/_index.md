---
title: Diagrammlegenden in Präsentationen in .NET anpassen
linktitle: Diagrammlegende
type: docs
url: /de/net/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für .NET an, um PowerPoint-Präsentationen mit individuell gestalteter Legendenformatierung zu optimieren."
---

## **Legendenpositionierung**
Um die Legenden‑Eigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
- Holen Sie sich die Referenz der Folie.
- Fügen Sie ein Diagramm auf der Folie hinzu.
- Legen Sie die Eigenschaften der Legende fest.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir die Position und Größe der Diagrammlegende festgelegt.
```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Holen Sie die Referenz der Folie
ISlide slide = presentation.Slides[0];

// Fügen Sie ein gruppiertes Säulendiagramm auf der Folie hinzu
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Legenden-Eigenschaften festlegen
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Präsentation auf die Festplatte speichern
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```




## **Schriftgröße der Legende festlegen**
Aspose.Slides für .NET ermöglicht Entwicklern, die Schriftgröße der Legende festzulegen. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die `Presentation`‑Klasse.
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



## **Schriftgröße einzelner Legendeinträge festlegen**
Aspose.Slides für .NET ermöglicht Entwicklern, die Schriftgröße einzelner Legendeinträge festzulegen. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die `Presentation`‑Klasse.
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


## **FAQ**

**Kann ich die Legende aktivieren, sodass das Diagramm automatisch Platz dafür reserviert, anstatt sie zu überlagern?**

Ja. Verwenden Sie den Nicht-Überlagerungsmodus ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/)=`false`); in diesem Fall wird der Plot‑Bereich verkleinert, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**

Ja. Lange Beschriftungen werden automatisch umgebrochen, wenn nicht genug Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Zeilenumbruch‑Zeichen im Seriennamen unterstützt.

**Wie bringe ich die Legende dazu, das Farbschema des Präsentationsthemas zu übernehmen?**

Setzen Sie keine expliziten Farben/Füllungen/Schriften für die Legende oder deren Text. Sie übernehmen dann das Theme und werden bei einer Designänderung korrekt aktualisiert.