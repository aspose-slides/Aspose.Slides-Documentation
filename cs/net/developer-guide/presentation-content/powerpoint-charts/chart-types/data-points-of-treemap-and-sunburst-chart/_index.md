---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst v .NET
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- graf Treemap
- graf Sunburst
- datový bod
- barva popisku
- barva větve
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak spravovat datové body v grafech Treemap a Sunburst pomocí Aspose.Slides pro .NET, kompatibilní s formáty PowerPointu."
---
## **Úvod**

Mezi ostatními typy grafů v PowerPointu existují dva „hierarchické“ typy – **Treemap** a **Sunburst** graf (také známý jako Sunburst Graph, Sunburst Diagram, Radiální graf, Radiální diagram nebo vícestupňový koláčový graf). Tyto grafy zobrazují hierarchická data uspořádaná jako strom – od listů až po vrchol větve. Listy jsou definovány datovými body řady a každá následující úroveň vnořeného seskupení je určena odpovídající kategorií. Aspose.Slides pro .NET umožňuje formátovat datové body Sunburst grafu a Treemap v C#.

Zde je Sunburst graf, kde data ve sloupci Series1 definují listové uzly, zatímco ostatní sloupce definují hierarchické datové body:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Začněme přidáním nového Sunburst grafu do prezentace:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Viz také" %}} 
- [**Creating Sunburst Chart**](/slides/cs/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Pokud je potřeba formátovat datové body grafu, měli bychom použít následující:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapointlevel) třídy 
a [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) vlastnost 
poskytují přístup k formátování datových bodů grafů Treemap a Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/IChartDataPointLevelsManager) 
se používá pro přístup k vícestupňovým kategoriím – představuje kontejner 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/IChartDataPointLevel) objektů. 
V podstatě je to obal pro 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/IChartCategoryLevelsManager) s 
vlastnostmi přidanými specificky pro datové body. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/IChartDataPointLevel) třída má 
dvě vlastnosti: [**Format**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapointlevel/properties/format) a 
[**DataLabel**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapointlevel/properties/label) které 
poskytují přístup k odpovídajícím nastavením.
## **Zobrazit hodnotu datového bodu**
Zobrazit hodnotu datového bodu "Leaf 4":

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Nastavit popisek a barvu datového bodu**
Nastavte popisek datového bodu "Branch 1" tak, aby zobrazoval název řady ("Series1") místo názvu kategorie. Poté nastavte barvu textu na žlutou:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Nastavit barvu větve datového bodu**

Změňte barvu větve "Stem 4":

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

## **FAQ**

**Mohu změnit pořadí (třídění) segmentů v Sunburst/Treemap?**

Ne. PowerPoint segmenty řadí automaticky (obvykle podle sestupných hodnot ve směru hodinových ručiček). Aspose.Slides toto chování napodobuje: nemůžete změnit pořadí přímo; dosáhnete toho předzpracováním dat.

**Jak ovlivňuje téma prezentace barvy segmentů a popisků?**

Barvy grafu dědí [téma/paletu](/slides/cs/net/presentation-theme/) prezentace, pokud explicitně nenastavíte výplně/písma. Pro konzistentní výsledek zamkněte pevné výplně a formátování textu na požadovaných úrovních.

**Zachová export do PDF/PNG vlastní barvy větví a nastavení popisků?**

Ano. Při exportu prezentace jsou nastavení grafu (výplně, popisky) zachována v výstupních formátech, protože Aspose.Slides renderuje s aplikovaným formátováním grafu.

**Mohu vypočítat skutečné souřadnice popisku/prvku pro vlastní překrytí nad grafem?**

Ano. Po ověření rozložení grafu jsou pro prvky k dispozici `ActualX`/`ActualY` (například pro [DataLabel](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/datalabel/)), což pomáhá s přesným umístěním překryvů.