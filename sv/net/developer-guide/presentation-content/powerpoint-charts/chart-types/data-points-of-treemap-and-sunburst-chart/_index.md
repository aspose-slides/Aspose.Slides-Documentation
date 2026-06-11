---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram i .NET
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-diagram
- sunburst-diagram
- datapunkt
- etikettfärg
- grenfärg
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hanterar datapunkter i treemap- och sunburst-diagram med Aspose.Slides för .NET, kompatibelt med PowerPoint-format."
---
## **Introduktion**

Förutom andra typer av PowerPoint-diagram finns det två ”hierarkiska” typer – **Treemap** och **Sunburst**‑diagram (även känt som Sunburst‑graf, Sunburst‑diagram, Radialt diagram, Radial graf eller Multi‑nivå‑tårt‑diagram). Dessa diagram visar hierarkiska data organiserade som ett träd – från löv till grenens topp. Löv definieras av serie‑datapunkterna, och varje efterföljande inbäddad grupperingsnivå definieras av motsvarande kategori. Aspose.Slides för .NET möjliggör formatering av datapunkter i Sunburst‑diagram och Treemap i C#.

Här är ett Sunburst‑diagram där data i Series1‑kolumnen definierar lövknutarna, medan övriga kolumner definierar hierarkiska datapunkter:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Vi börjar med att lägga till ett nytt Sunburst‑diagram i presentationen:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Se också" %}} 
- [**Skapa Sunburst‑diagram**](/slides/sv/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Om det behövs att formatera datapunkter i diagrammet bör vi använda följande:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapointlevel) klasser 
och [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) egenskap 
ger åtkomst till att formatera datapunkter i Treemap‑ och Sunburst‑diagram. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/IChartDataPointLevelsManager) 
används för att komma åt flernivåkategorier – den representerar behållaren för 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/IChartDataPointLevel) objekt. 
I grund och botten är den en wrapper för 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/IChartCategoryLevelsManager) med 
egenskaper som lagts till specifikt för datapunkter. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/IChartDataPointLevel) klassen har 
två egenskaper: [**Format**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapointlevel/properties/format) och 
[**DataLabel**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapointlevel/properties/label) som 
ger åtkomst till motsvarande inställningar.

## **Visa värdet på en datapunkt**

Visa värdet på datapunkten ”Leaf 4”:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ange en datapunktetikett och färg**

Sätt dataetiketten för ”Branch 1” att visa serienamnet (“Series1”) istället för kategorinamnet. Sätt sedan textfärgen till gul:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ange färg för datapunktgren**

Ändra färgen på grenen ”Stem 4”:

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

## **Vanliga frågor**

**Kan jag ändra ordningen (sorteringen) på segmenten i Sunburst/Treemap?**

Nej. PowerPoint sorterar segmenten automatiskt (vanligtvis efter fallande värden, medurs). Aspose.Slides speglar detta beteende: du kan inte ändra ordningen direkt; du får det genom att förbehandla data.

**Hur påverkar presentationens tema färgerna på segmenten och etiketter?**

Diagramfärger ärver presentationens [tema/palett](/slides/sv/net/presentation-theme/) om du inte uttryckligen anger fyllningar/typsnitt. För konsekventa resultat bör du låsa fast solida fyllningar och textformatering på de nödvändiga nivåerna.

**Kommer export till PDF/PNG att bevara anpassade grenfärger och etikettinställningar?**

Ja. Vid export av presentationen bevaras diagraminställningarna (fyllningar, etiketter) i de resulterande formaten eftersom Aspose.Slides renderar med diagrammets formatering tillämpad.

**Kan jag beräkna de faktiska koordinaterna för en etikett/element för anpassad överlagring ovanpå diagrammet?**

Ja. Efter att diagrammets layout har validerats är `ActualX`/`ActualY` tillgängliga för element (t.ex. en [DataLabel](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/datalabel/)), vilket underlättar exakt placering av överlägg.