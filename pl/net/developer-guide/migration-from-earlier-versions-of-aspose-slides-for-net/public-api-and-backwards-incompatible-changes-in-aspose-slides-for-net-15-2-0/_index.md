---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 15.2.0
linktitle: Aspose.Slides dla .NET 15.2.0
type: docs
weight: 140
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migracja
- kod legacy
- kod nowoczesny
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące kompatybilność w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}}

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 15.2.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **AddDataPointForDoughnutSeries Methods Have Been Added**
Dodano dwa przeciążenia metody IChartDataPointCollection.AddDataPointForDoughnutSeries() służące do dodawania punktów danych do serii typu wykres pierścieniowy.
#### **Aspose.Slides.SmartArt.SmartArtShape Class Has Been Inherited from Aspose.Slides.GeometryShape Class**
Klasa Aspose.Slides.SmartArt.SmartArtShape została odziedziczona po klasie Aspose.Slides.GeometryShape. Zmiana ta ulepsza model obiektowy Aspose.Slides i dodaje nowe funkcje do klasy SmartArtShape.
#### **Methods for Removing Chart Data Point and Chart Category by Index Has Been Added**
Metoda IChartDataPointCollection.RemoveAt(int index) została dodana w celu usuwania punktu danych wykresu po jego indeksie. Metoda IChartCategoryCollection.RemoveAt(int index) została dodana w celu usuwania kategorii wykresu po jej indeksie.
#### **PptXPptY Value Has Been Added to Aspose.Slides.Animation.PropertyType Enumeration**
Wartość PptXPptY została dodana do wyliczenia Aspose.Slides.Animation.PropertyType w ramach naprawy problemu z serializacją.
#### **System.Drawing.Color GetAutomaticSeriesColor() Method Has Been Added to Aspose.Slides.Charts.IChartSeries**
Metoda GetAutomaticSeriesColor zwraca automatyczny kolor serii na podstawie indeksu serii i stylu wykresu. Ten kolor jest używany domyślnie, jeśli FillType ma wartość NotDefined.

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