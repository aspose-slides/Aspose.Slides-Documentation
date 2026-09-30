---
title: Grafieklegenda's aanpassen in presentaties in .NET
linktitle: Grafieklegenda
type: docs
url: /nl/net/chart-legend/
keywords:
- grafieklegenda
- legenda positie
- lettergrootte
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas grafieklegenda's aan met Aspose.Slides voor .NET om PowerPoint-presentaties te optimaliseren met op maat gemaakte legendarijopmaak."
---
## **Overzicht**

Aspose.Slides for .NET biedt opties om de legenda van een diagram in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe u een legenda kunt positioneren en meten, de lettergrootte voor de volledige legenda kunt instellen, een individuele legendarij‑invoer kunt opmaken, en geselecteerde items kunt verbergen of herstellen.

De FAQ behandelt gerelateerde gedragingen, waaronder het reserveren van ruimte voor de legenda, het weergeven van meerregelige labels en het erven van opmaak vanuit het themapakket van de presentatie.

## **Positionering van de legenda**

Gebruik de eigenschappen [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) en [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) van de legenda om de positie en grootte op te geven als fracties van de afmetingen van het diagram.

Dit voorbeeld maakt een presentatie aan en voegt een gegroepeerde kolomgrafiek met standaardgegevens toe aan de eerste dia. Door de gewenste legendarij‑verschuivingen en afmetingen te delen door de breedte en hoogte van het diagram, worden ze omgezet naar relatieve waarden: de legenda wordt 50 punten geshift vanaf de linkerbovenhoek van het diagram en krijgt een grootte van 100 bij 100 punten.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Geef de positie en grootte van de legenda weer relatief ten opzichte van het diagram.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Instellen van de lettergrootte van een legenda**

Gebruik de [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) om de tekstopmaak van de legenda te benaderen en stel [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in punten in.

Dit voorbeeld maakt een diagram met standaardgegevens en stelt de legendatekst in op 20 punten. Het schakelt ook de automatische grenzen voor de verticale as uit en stelt het bereik in op -5 tot 10.

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

## **Instellen van de lettergrootte van een individuele legendarij‑invoer**

Gebruik de [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/)‑collectie van de legenda om de opmaak voor een specifieke invoer te benaderen. Invoernummers starten bij nul, dus index `1` verwijst naar de tweede invoer.

Dit voorbeeld maakt een gegroepeerde kolomgrafiek waarvan de standaardgegevens tenminste twee series bevatten. Het formatteert de tweede legendarij‑invoer met vet, cursief en 20‑punt blauwe tekst.

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

## **Verberg individuele legendarij‑items**

Om een aanvullende serie uit de legenda te verwijderen terwijl de gegevens zichtbaar blijven, stelt u [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) in op `true` via [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Hiermee wordt alleen de geselecteerde legendarij‑invoer verborgen; de serie of diens gegevenspunten worden niet verwijderd. Het instellen van [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) op `false` verbergt daarentegen de volledige legenda.

Het volgende voorbeeld maakt een gegroepeerde kolomgrafiek met meerdere series op basis van standaardgegevens. Het verbergt de legendarij‑invoer van de tweede serie (index `1`) en slaat de presentatie op. Vervolgens wordt de invoer hersteld door `Hide` op `false` te zetten en wordt een tweede kopie opgeslagen. De kolommen blijven in beide bestanden zichtbaar.

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

// Herstel dezelfde invoer zonder de diagramgegevens te wijzigen.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

De vergelijking hieronder toont hetzelfde diagram met alle invoeren zichtbaar en met de tweede invoer verborgen. De kolommen van de tweede serie blijven ongewijzigd.

![Vergelijking van een diagram met alle legendarij‑items zichtbaar en met Serie 2 verborgen in de legenda; alle kolommen blijven zichtbaar.](hide-legend-entry.png)

In kolom‑, staaf‑ en lijndiagrammen identificeren legendarij‑items de series. Voor cirkeldiagrammen identificeren ze individuele gegevenspunten (partjes), dus gebruikt u [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) op het geselecteerde partje. De API documenteert deze eigenschap voor de `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` en `BarOfPie` diagramtypen. Neem niet aan dat dit geldt voor doughnut‑diagrammen, die niet in die lijst zijn opgenomen.

## **FAQ**

**Kan ik de diagram laten ruimte reserveren voor de legenda in plaats van deze te overlappen?**

Ja. Stel [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) in op `false` om ruimte te reserveren voor de legenda in plaats van toe te staan dat deze overlapt met het plotgebied.

**Kan ik meerregelige legendarij‑labels maken?**

Ja. Lange labels kunnen worden afgebroken wanneer de beschikbare breedte onvoldoende is. U kunt ook regeleinden in serienaam gebruiken om een regelpauze te forceren.

**Hoe laat ik de legenda het kleurschema van het presentatiethema volgen?**

Laat de kleuren, opvullingen en lettertypes van de legenda onbehandeld zodat ze de themavormgeving kunnen overerven. Expliciete opmaak overschrijft de overeenkomstige themainstellingen.