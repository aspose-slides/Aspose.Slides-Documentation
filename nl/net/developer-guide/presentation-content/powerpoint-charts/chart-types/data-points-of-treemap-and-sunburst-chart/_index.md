---
title: Pas gegevenspunten aan in Treemap- en Sunburst-diagrammen in .NET
linktitle: Gegevenspunten in Treemap- en Sunburst-diagrammen
type: docs
url: /nl/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-diagram
- sunburst-diagram
- gegevenspunt
- labelkleur
- takkleur
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u gegevenspunten in treemap- en sunburst-diagrammen beheert met Aspose.Slides voor .NET, compatibel met PowerPoint-formaten."
---
## **Inleiding**

Naast andere typen PowerPoint‑diagrammen bestaan er twee “hiërarchische” typen – **Treemap** en **Sunburst**‑diagram (ook bekend als Sunburst‑grafiek, Sunburst‑diagram, Radiale diagram, Radiale grafiek of Meerlagige taartdiagram). Deze diagrammen tonen hiërarchische gegevens georganiseerd als een boom – van blad­punten tot de top van de tak. Bladeren worden gedefinieerd door de gegevenspunten van de reeks, en elk volgend genest groepeerniveau wordt bepaald door de overeenkomstige categorie. Aspose.Slides voor .NET maakt het mogelijk om de gegevenspunten van Sunburst‑diagrammen en Treemap‑diagrammen te formatteren in C#.

Hier is een Sunburst‑diagram, waarbij de gegevens in de kolom Series1 de bladknooppunten definiëren, terwijl de andere kolommen hiërarchische gegevenspunten definiëren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Laten we beginnen met het toevoegen van een nieuw Sunburst‑diagram aan de presentatie:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Zie ook" %}} 
- [**Sunburst-diagram maken**](/slides/nl/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Wanneer er een behoefte is om de gegevenspunten van het diagram te formatteren, moeten we het volgende gebruiken:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/IChartDataPointLevelsManager),  
[IChartDataPointLevel](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointlevel) klassen  
en [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) eigenschap  
verlenen toegang tot het formatteren van gegevenspunten van Treemap‑ en Sunburst‑diagrammen.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/IChartDataPointLevelsManager) wordt gebruikt om toegang te krijgen tot meervoudige categorieniveaus – het vertegenwoordigt de container van [**IChartDataPointLevel**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/IChartDataPointLevel) objecten.  
In wezen is het een wrapper voor [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/IChartCategoryLevelsManager) met de eigenschappen die specifiek zijn toegevoegd voor gegevenspunten.  
De klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/IChartDataPointLevel) heeft twee eigenschappen: [**Format**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointlevel/properties/format) en [**DataLabel**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointlevel/properties/label) die toegang bieden tot de bijbehorende instellingen.

## **Waarde van een gegevenspunt weergeven**
Waarde van gegevenspunt “Leaf 4” tonen:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Gegevenspuntlabel en -kleur instellen**
Stel het label van gegevenspunt “Branch 1” in om de reeksnamen (“Series1”) weer te geven in plaats van de categorienaam. Stel vervolgens de tekstkleur in op geel:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Kleur van een tak van een gegevenspunt instellen**
Kleur van tak “Stem 4” wijzigen:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Veelgestelde vragen**

**Kan ik de volgorde (sortering) van segmenten in Sunburst/Treemap wijzigen?**

Nee. PowerPoint sorteert segmenten automatisch (meestal op aflopende waarden, met de klok mee). Aspose.Slides spiegelt dit gedrag: je kunt de volgorde niet rechtstreeks wijzigen; je bereikt dit door de gegevens vooraf te verwerken.

**Hoe beïnvloedt het presentatiethema de kleuren van segmenten en labels?**

De kleuren van diagrammen erven het [thema/palet](/slides/nl/net/presentation-theme/) van de presentatie, tenzij je expliciet vullingen of lettertypen instelt. Voor consistente resultaten, gebruik vaste vullingen en tekstopmaak op de nodige niveaus.

**Zal export naar PDF/PNG aangepaste takkleuren en labelinstellingen behouden?**

Ja. Bij het exporteren van de presentatie worden de diagraminstellingen (vullingen, labels) behouden in de uitvoerformaten, omdat Aspose.Slides rendert met de toegepaste diagramopmaak.

**Kan ik de werkelijke coördinaten van een label/element berekenen voor een aangepaste overlayplaatsing bovenop het diagram?**

Ja. Nadat de diagramlay-out is gevalideerd, zijn `ActualX`/`ActualY` beschikbaar voor elementen (bijvoorbeeld een [DataLabel](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/datalabel/)), wat helpt bij het nauwkeurig positioneren van overlays.