---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.2.0
linktitle: Aspose.Slides pro .NET 15.2.0
type: docs
weight: 140
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a breaking změny v Aspose.Slides pro .NET, abyste hladce migrovali své řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) nebo [odstraněné](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 15.2.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Metody AddDataPointForDoughnutSeries byly přidány**
Byly přidány dvě přetížení metody IChartDataPointCollection.AddDataPointForDoughnutSeries() pro přidávání datových bodů do sérií typu koláčový graf.
#### **Třída Aspose.Slides.SmartArt.SmartArtShape byla zděděna z třídy Aspose.Slides.GeometryShape**
Třída Aspose.Slides.SmartArt.SmartArtShape byla zděděna z třídy Aspose.Slides.GeometryShape. Tato změna vylepšuje objektový model Aspose.Slides a přidává nové funkce do třídy SmartArtShape.
#### **Byly přidány metody pro odstraňování datových bodů a kategorií grafu dle indexu**
Metoda IChartDataPointCollection.RemoveAt(int index) byla přidána pro odstraňování datových bodů grafu podle jejich indexu.
Metoda IChartCategoryCollection.RemoveAt(int index) byla přidána pro odstraňování kategorií grafu podle jejich indexu.
#### **Byla přidána hodnota PptXPptY do výčtu Aspose.Slides.Animation.PropertyType**
Hodnota PptXPptY byla přidána do výčtu Aspose.Slides.Animation.PropertyType v souvislosti s opravou problému serializace.
#### **Metoda System.Drawing.Color GetAutomaticSeriesColor() byla přidána do Aspose.Slides.Charts.IChartSeries**
Metoda GetAutomaticSeriesColor vrací automatickou barvu série na základě indexu série a stylu grafu. Tato barva je použita jako výchozí, pokud je FillType nastaven na NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```