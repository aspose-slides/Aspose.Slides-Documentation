---
title: Publiczne API i zmiany niezgodne wstecz w Aspose.Slides dla .NET 15.2.0
linktitle: Aspose.Slides dla .NET 15.2.0
type: docs
weight: 140
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migracja
- kod dziedziczony
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides dla .NET 15.2.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Zostały dodane metody AddDataPointForDoughnutSeries**
Dodano dwie wersje przeciążone metody IChartDataPointCollection.AddDataPointForDoughnutSeries() służące do dodawania punktów danych do serii wykresu typu Doughnut.
#### **Klasa Aspose.Slides.SmartArt.SmartArtShape została odziedziczona po klasie Aspose.Slides.GeometryShape**
Klasa Aspose.Slides.SmartArt.SmartArtShape została odziedziczona po klasie Aspose.Slides.GeometryShape. Ta zmiana ulepsza model obiektowy Aspose.Slides i dodaje nowe funkcje do klasy SmartArtShape.
#### **Dodano metody usuwania punktu danych wykresu i kategorii wykresu według indeksu**
Metoda IChartDataPointCollection.RemoveAt(int index) została dodana w celu usunięcia punktu danych wykresu według jego indeksu.
Metoda IChartCategoryCollection.RemoveAt(int index) została dodana w celu usunięcia kategorii wykresu według jej indeksu.
#### **Dodano wartość PptXPptY do wyliczenia Aspose.Slides.Animation.PropertyType**
Wartość PptXPptY została dodana do wyliczenia Aspose.Slides.Animation.PropertyType w ramach rozwiązania problemu serializacji.
#### **Dodano metodę System.Drawing.Color GetAutomaticSeriesColor() do Aspose.Slides.Charts.IChartSeries**
Metoda GetAutomaticSeriesColor zwraca automatyczny kolor serii na podstawie indeksu serii i stylu wykresu. Ten kolor jest używany domyślnie, jeśli FillType ma wartość NotDefined.

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