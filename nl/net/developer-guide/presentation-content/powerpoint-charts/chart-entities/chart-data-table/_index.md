---
title: Grafiekgegevens tabellen aanpassen in presentaties in .NET
linktitle: Gegevenstabel
type: docs
url: /nl/net/chart-data-table/
keywords:
- grafiekgegevens
- gegevenstabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas de lettertype-eigenschappen, randen en legende-sleutels van grafiek-gegevenstabellen aan in PowerPoint-presentaties met Aspose.Slides voor .NET en C#."
---
## **Overzicht**

Aspose.Slides for .NET stelt u in staat om de gegevenstabel van een grafiek weer te geven en de tekstopmaak, randen en legende‑sleutels aan te passen. Dit artikel legt uit hoe u de tabel inschakelt, de tekst opmaakt, elk type rand beheert, en legende‑sleutels toont of verbergt. De voorbeelden slaan de geconfigureerde grafieken op in PPTX‑bestanden.

## **Lettertype-eigenschappen instellen**

Om de gegevenstabel van een grafiek weer te geven, stelt u [HasDataTable](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/hasdatatable/) in op `true`. Gebruik [ChartDataTable](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/chartdatatable/) om toegang te krijgen tot de tabel en de tekstopmaak te configureren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.  
2. Voeg een gegroepeerde kolomgrafiek toe aan de eerste dia.  
3. Schakel de gegevenstabel van de grafiek in.  
4. Schakel vetgedrukte tekst in met [FontBold](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/fontbold/) en stel [FontHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/fontheight/) in op `20` voor tekst van 20 punten.  
5. Sla de aangepaste presentatie op.  

Het volgende voorbeeld vereist `test.pptx` in de werkmap met ten minste één dia. Het voegt een grafiek met standaardgegevens toe op positie (50, 50), met een breedte van 600 punten en een hoogte van 400 punten. Het opgeslagen `output.pptx` bevat de grafiek met de ingeschakelde gegevenstabel en de opgegeven lettertype‑instellingen toegepast.

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

## **Randen van de gegevenstabel aanpassen**

Schakel de tabel in met [IChart.HasDataTable](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/hasdatatable/) en krijg er toegang via [IChart.ChartDataTable](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/chartdatatable/). U kunt drie soorten randen onafhankelijk beheren:

- [HasBorderHorizontal](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatatable/hasborderhorizontal/) regelt de horizontale celranden.  
- [HasBorderVertical](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatatable/hasbordervertical/) regelt de verticale celranden.  
- [HasBorderOutline](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatatable/hasborderoutline/) regelt de buitenrand van de tabel.  

Stel elke eigenschap in op `true` om de bijbehorende randen weer te geven of op `false` om ze te verbergen. Het volgende voorbeeld maakt een gegroepeerde kolomgrafiek met standaardgegevens, toont horizontale randen en de buitenrand, en verbergt verticale randen. Het vereist geen invoerbestand. De positie en grootte van de grafiek worden gespecificeerd in punten.

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

De vergelijking hieronder gebruikt in alle vier gevallen dezelfde grafiekgegevens en legende‑sleutelinstelling. Beginnend met alle randen ingeschakeld, schakelt elke volgende variant slechts één rand‑eigenschap uit. De variant links‑onder komt overeen met de randinstellingen in het voorbeeld.

![Grafiek‑gegevenstabellen met alle randen ingeschakeld, geen horizontale randen, geen verticale randen, en geen buitenrand](data-table-borders.png)

## **Legende‑sleutels weergeven of verbergen**

Legende‑sleutels zijn kleine gekleurde markeringen naast de reeksnamen in de gegevenstabel. Ze helpen lezers elke tabelrij te koppelen aan een grafiekreeks. Stel [ShowLegendKey](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatatable/showlegendkey/) in op `true` om deze markeringen weer te geven of op `false` om ze te verbergen.

De afzonderlijke legende van de grafiek wordt beheerd via [IChart.HasLegend](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/haslegend/). Deze instellingen zijn onafhankelijk: het verbergen van de afzonderlijke legende verbergt de sleutels in de gegevenstabel niet, en het verbergen van de sleutels in de tabel verbergt de afzonderlijke legende niet.

Het volgende voorbeeld maakt een grafiek met standaardgegevens, schakelt de gegevenstabel in en toont legende‑sleutels daarin terwijl de afzonderlijke legende verborgen wordt. Alle tabelranden worden expliciet ingeschakeld. Er is geen invoerpresentatie vereist. Om alleen de sleutels in de tabel te verbergen, wijzig `dataTable.ShowLegendKey` naar `false`.

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

De vergelijking hieronder toont dezelfde tabel met legende‑sleutels ingeschakeld en uitgeschakeld. Alle randen blijven ingeschakeld en de afzonderlijke grafieklegende is in beide gevallen verborgen.

![Grafiek‑gegevenstabellen met legende‑sleutels weergegeven links en verborgen rechts](data-table-legend-keys.png)

## **FAQ**

**Kan ik legende‑sleutels weergeven in de gegevenstabel van een grafiek?**

Ja. Stel [ShowLegendKey](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/datatable/showlegendkey/) in op `true` om legende‑sleutels weer te geven of op `false` om ze te verbergen.

**Wordt de gegevenstabel bewaard bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert de grafiek en de weergegeven gegevenstabel als onderdeel van de dia bij het exporteren naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/), [HTML](/slides/nl/net/convert-powerpoint-to-html/), of [images](/slides/nl/net/convert-powerpoint-to-png/).

**Kan ik werken met gegevenstabellen in grafieken die uit een sjabloon zijn geladen?**

Ja. Voor een grafiek die uit een bestaande presentatie of een sjabloon is geladen, gebruikt u [HasDataTable](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/hasdatatable/) om te controleren of de gegevenstabel wordt weergegeven, of om dit te wijzigen.

**Hoe kan ik grafieken vinden die een ingeschakelde gegevenstabel hebben?**

Itereer door de vormen op elke dia, identificeer de grafieken en controleer hun [HasDataTable](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/hasdatatable/) eigenschap. Een waarde van `true` geeft aan dat de gegevenstabel is ingeschakeld.