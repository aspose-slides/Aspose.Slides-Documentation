---
title: Anpassa diagramförklaringar i presentationer i .NET
linktitle: Diagramförklaring
type: docs
url: /sv/net/chart-legend/
keywords:
- diagramförklaring
- förklaringens position
- teckenstorlek
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för .NET för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides för .NET erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Denna artikel visar hur man placerar och ändrar storlek på en förklaring, ställer in teckenstorlek för hela förklaringen, formaterar en enskild förklaringspost och döljer eller återställer valda poster.

FAQ:n täcker relaterade beteenden, inklusive att reservera utrymme för förklaringen, visa flerradiga etiketter och ärva formatering från presentationstemat.

## **Placering av förklaring**

Använd förklaringens [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), och [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) egenskaper för att ange dess position och storlek som bråkdelar av diagrammets dimensioner.

Detta exempel skapar en presentation och lägger till ett grupperat stapeldiagram med standarddata på den första bilden. Genom att dela de önskade förklaringsoffseten och dimensionerna med diagrammets bredd och höjd konverteras de till relativa värden: förklaringen är förskjuten 50 punkter från diagrammets övre vänstra hörn och har storleken 100 × 100 punkter.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Ställ in teckenstorlek för en förklaring**

Använd förklaringens [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) för att komma åt dess textformatering och sätt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) i punkter.

Detta exempel skapar ett diagram med standarddata och sätter förklaringstexten till 20 punkter. Det inaktiverar även automatiska gränser för den vertikala axeln och sätter dess område till -5 till 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Ställ in teckenstorlek för en enskild förklaringspost**

Använd förklaringens [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) samling för att komma åt formatering för en specifik post. Postindex är nollbaserade, så index `1` avser den andra posten.

Detta exempel skapar ett grupperat stapeldiagram vars standarddata innehåller minst två serier. Det formaterar den andra förklaringsposten med fet, kursiv och 20‑punkts blå text.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Dölj enskilda förklaringsposter**

För att utesluta en hjälpseries från förklaringen samtidigt som dess data förblir synlig, sätt [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) till `true` via [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Detta döljer endast den valda förklaringsposten; den tar inte bort serien eller dess datapunkter. Att sätta [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) till `false` döljer däremot hela förklaringen.

Exemplet nedan skapar ett grupperat stapeldiagram med flera serier med standarddata. Det döljer den andra seriens förklaringspost (index `1`) och sparar presentationen. Det återställer sedan posten genom att sätta `Hide` till `false` och sparar en andra kopia. Kolumnerna förblir synliga i båda filerna.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Återställ samma post utan att ändra diagramdata.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Jämförelsen nedan visar samma diagram med alla poster synliga och med den andra posten dold. Den andra seriens kolumner förblir oförändrade.

![Jämförelse av ett diagram med alla förklaringsposter synliga och med serie 2 dold från förklaringen; alla kolumner förblir synliga.](hide-legend-entry.png)

I stapel-, stång- och linjediagram identifierar förklaringsposter serier. I cirkeldiagram identifierar de enskilda datapunkter (skivor), så använd [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) på den valda skivan istället. API:n dokumenterar denna datapunkt-egenskap för diagramtyperna `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` och `BarOfPie`. Anta inte att den gäller för donutsdiagram, som inte ingår i listan.

## **FAQ**

**Kan jag låta diagrammet reservera utrymme för förklaringen istället för att överlappa den?**

Ja. Sätt [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) till `false` för att reservera utrymme för förklaringen istället för att låta den överlappa plotområdet.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter kan radbrytas när den tillgängliga bredden är otillräcklig. Du kan också använda nyradstecken i serienamn för att begära radbrytningar.

**Hur får jag förklaringen att följa presentationens färgschema?**

Lämna förklaringens färger, fyllningar och typsnitt odefinierade så att den kan ärva temats formatering. Explicit formatering åsidosätter motsvarande temainställningar.