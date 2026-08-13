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
description: "Prohlédněte si aktualizace veřejného API a rozbití změn v Aspose.Slides pro .NET a snadno migrujte své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) nebo [odstraněno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides for .NET 15.2.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Byly přidány metody AddDataPointForDoughnutSeries**
Byly přidány dvě přetížení metody IChartDataPointCollection.AddDataPointForDoughnutSeries() pro přidávání datových bodů do řad typu grafu Donut.
#### **Třída Aspose.Slides.SmartArt.SmartArtShape byla zděděna z třídy Aspose.Slides.GeometryShape**
Třída Aspose.Slides.SmartArt.SmartArtShape byla zděděna z třídy Aspose.Slides.GeometryShape. Tato změna zlepšuje model objektů Aspose.Slides a přidává nové funkce do třídy SmartArtShape.
#### **Byly přidány metody pro odstranění datového bodu grafu a kategorie grafu podle indexu**
Byla přidána metoda IChartDataPointCollection.RemoveAt(int index) pro odstranění datového bodu grafu podle jeho indexu.
Byla přidána metoda IChartCategoryCollection.RemoveAt(int index) pro odstranění kategorie grafu podle jejího indexu.
#### **Hodnota PptXPptY byla přidána do výčtu Aspose.Slides.Animation.PropertyType**
Hodnota PptXPptY byla přidána do výčtu Aspose.Slides.Animation.PropertyType v souvislosti s opravou problému serializace.
#### **Metoda System.Drawing.Color GetAutomaticSeriesColor() byla přidána do Aspose.Slides.Charts.IChartSeries**
Metoda GetAutomaticSeriesColor vrací automatickou barvu řady na základě indexu řady a stylu grafu. Tato barva je použita jako výchozí, pokud je FillType roven NotDefined.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```