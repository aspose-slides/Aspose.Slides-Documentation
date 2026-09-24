---
title: Anpassa diagramdatatabeller i presentationer i .NET
linktitle: Datatabell
type: docs
url: /sv/net/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Anpassa diagramdatatabellens teckensnitt, ramar och förklaringsnycklar i PowerPoint-presentationer med Aspose.Slides för .NET och C#."
---
## **Översikt**

Aspose.Slides för .NET gör att du kan visa ett diagramdatas tabell och anpassa dess textformatering, ramar och förklaringsnycklar. Den här artikeln förklarar hur du aktiverar tabellen, formaterar dess text, styr varje typ av ram och visar eller döljer förklaringsnycklar. Exemplen sparar de konfigurerade diagrammen i PPTX‑filer.

## **Ange teckensnittsegenskaper**

För att visa ett diagramdatas tabell, sätt [HasDataTable](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/hasdatatable/) till `true`. Använd [ChartDataTable](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/chartdatatable/) för att komma åt tabellen och konfigurera dess textformatering.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Lägg till ett klustrat stapeldiagram på den första bilden.
1. Aktivera diagrammets datatabell.
1. Aktivera fet text med [FontBold](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/fontbold/) och sätt [FontHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/fontheight/) till `20` för 20‑punkts text.
1. Spara den modifierade presentationen.

Följande exempel kräver `test.pptx` i arbetskatalogen med minst en bild. Det lägger till ett diagram med standarddata på positionen (50, 50), med en bredd på 600 punkter och en höjd på 400 punkter. Den sparade `output.pptx` innehåller diagrammet med dess datatabell aktiverad och de angivna teckensnittsinställningarna tillämpade.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Anpassa ramar för datatabell**

Aktivera tabellen med [IChart.HasDataTable](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/hasdatatable/) och komma åt den via [IChart.ChartDataTable](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/chartdatatable/). Du kan styra tre typer av ramar oberoende:

- [HasBorderHorizontal](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/idatatable/hasborderhorizontal/) styr horisontella cellramar.
- [HasBorderVertical](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/idatatable/hasbordervertical/) styr vertikala cellramar.
- [HasBorderOutline](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/idatatable/hasborderoutline/) styr tabellens yttre ram.

Sätt varje egenskap till `true` för att visa dess ramar eller `false` för att dölja dem. Följande exempel skapar ett klustrat stapeldiagram med standarddata, visar horisontella ramar och den yttre ramen samt döljer vertikala ramar. Det kräver ingen inmatningsfil. Diagrammets position och storlek anges i punkter.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Jämförelsen nedan använder samma diagramdata och inställning för förklaringsnyckel i alla fyra fallen. Med alla ramar aktiverade från början, inaktiverar varje återstående variant bara en ram‑egenskap. Variant nedre vänster matchar raminställningarna i exemplet.

![Diagramdatatabeller med alla ramar aktiverade, utan horisontella ramar, utan vertikala ramar och utan yttre ram](data-table-borders.png)

## **Visa eller dölja förklaringsnycklar**

Förklaringsnycklar är små färgade markörer bredvid seriernas namn i datatabellen. De hjälper läsaren att matcha varje tabellrad med en diagramserie. Sätt [ShowLegendKey](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/idatatable/showlegendkey/) till `true` för att visa dessa markörer eller `false` för att dölja dem.

Diagrammets separata förklaring styrs av [IChart.HasLegend](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/haslegend/). Dessa inställningar är oberoende: att dölja den separata förklaringen döljer inte nycklarna i datatabellen, och att dölja tabellens nycklar döljer inte den separata förklaringen.

Följande exempel skapar ett diagram med standarddata, aktiverar dess datatabell och visar förklaringsnycklar i den medan den separata förklaringen döljs. Alla tabellramar är uttryckligen aktiverade. Ingen inmatningspresentation krävs. För att endast dölja tabellens nycklar, ändra `dataTable.ShowLegendKey` till `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Jämförelsen nedan visar samma tabell med förklaringsnycklar aktiverade respektive inaktiverade. Alla ramar förblir aktiverade, och diagrammets separata förklaring är dold i båda fallen.

![Diagramdatatabeller med förklaringsnycklar visade till vänster och dolda till höger](data-table-legend-keys.png)

## **FAQ**

**Kan jag visa förklaringsnycklar i ett diagramdatas tabell?**

Ja. Sätt [ShowLegendKey](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/datatable/showlegendkey/) till `true` för att visa förklaringsnycklar eller till `false` för att dölja dem.

**Behålls datatabellen när presentationen exporteras till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet och den visade datatabellen som en del av bilden när du exporterar till [PDF](/slides/sv/net/convert-powerpoint-to-pdf/), [HTML](/slides/sv/net/convert-powerpoint-to-html/) eller [bilder](/slides/sv/net/convert-powerpoint-to-png/).

**Kan jag arbeta med datatabeller i diagram som laddas från en mall?**

Ja. För ett diagram som laddas från en befintlig presentation eller mall, använd [HasDataTable](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/hasdatatable/) för att kontrollera eller ändra om dess datatabell visas.

**Hur kan jag hitta diagram som har en datatabell aktiverad?**

Iterera genom formerna på varje bild, identifiera diagrammen och kontrollera deras egenskap [HasDataTable](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/hasdatatable/). Ett värde på `true` indikerar att datatabellen är aktiverad.