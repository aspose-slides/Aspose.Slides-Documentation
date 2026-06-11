---
title: Anpassa diagramlegender i presentationer i .NET
linktitle: Diagramlegend
type: docs
url: /sv/net/chart-legend/
keywords:
- diagramlegend
- legendposition
- teckenstorlek
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Anpassa diagramlegender med Aspose.Slides för .NET för att optimera PowerPoint-presentationer med skräddarsydd legendformatering."
---
## **Översikt**

Aspose.Slides erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Den här artikeln visar hur man placerar och storlekar en förklaring, anger teckenstorlek för hela förklaringen och tillämpar formatering på ett enskilt förklaringspost.

Den täcker också flera relaterade beteenden i FAQ, inklusive att använda icke‑överlappningsläge så att diagramområdet ger plats för förklaringen, tillåter långa förklaringsetiketter att radbrytas eller använda radbrytningar, och låter förklaringsformatering ärva från presentationens tema när explicita text‑ och fyllningsinställningar inte har angetts.

## **Placering av legenden**
För att ställa in egenskaperna för legenden. Följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
- Hämta referens till bilden.
- Lägg till ett diagram på bilden.
- Ställ in egenskaperna för legenden.
- Skriv presentationen som en PPTX‑fil.

I exemplet nedan har vi angivit position och storlek för diagramlegenden.

```c#
// Skapa en instans av Presentation-klassen
Presentation presentation = new Presentation();

// Hämta referens till bilden
ISlide slide = presentation.Slides[0];

// Lägg till ett grupperat stapeldiagram på bilden
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Ställ in legendegenskaper
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Skriv presentationen till disk
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **Ange teckenstorlek för en legend**
Aspose.Slides för .NET låter utvecklare ange teckenstorlek för legenden. Följ stegen nedan:

- Instansiera klassen `Presentation`.
- Skapa standarddiagrammet.
- Ange teckenstorleken.
- Ange minimumvärde för axeln.
- Ange maximumvärde för axeln.
- Skriv presentationen till disk.

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

## **Ange teckenstorlek för en enskild legend**
Aspose.Slides för .NET låter utvecklare ange teckenstorlek för enskilda legendposteringar. Följ stegen nedan:

- Instansiera klassen `Presentation`.
- Skapa standarddiagrammet.
- Åtkomst till legendpost.
- Ange teckenstorleken.
- Ange minimumvärde för axeln.
- Ange maximumvärde för axeln.
- Skriv presentationen till disk.

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

**Kan jag aktivera legenden så att diagrammet automatiskt avsätter utrymme för den istället för att överlappa den?**

Ja. Använd icke‑överlappningsläget ([Overlay](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/legend/overlay/) = `false`); i så fall kommer diagramområdet att krympa för att rymma legenden.

**Kan jag skapa flerradiga legendetiketter?**

Ja. Långa etiketter radbryts automatiskt när utrymmet är otillräckligt; tvingade radbrytningar stödjs via nyrads­tecken i seriens namn.

**Hur får jag legenden att följa presentationens temas färgschema?**

Ange inte explicita färger/fyllningar/teckensnitt för legenden eller dess text. De kommer då att ärva från temat och uppdateras korrekt när designen ändras.