---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst w .NET
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- wykres treemap
- wykres sunburst
- punkt danych
- kolor etykiety
- kolor gałęzi
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zarządzać punktami danych w wykresach treemap i sunburst za pomocą Aspose.Slides dla .NET, zgodnie z formatami PowerPoint."
---
## **Wprowadzenie**

Wśród innych typów wykresów PowerPoint istnieją dwa typy „hierarchiczne” – **Treemap** i **Sunburst** (chart (also known as Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph or Multi Level Pie Chart)). Te wykresy wyświetlają dane hierarchiczne uporządkowane jako drzewo – od liści do wierzchołka gałęzi. Liście są definiowane przez punkty danych serii, a każdy kolejny poziom zagnieżdżonej grupy jest definiowany przez odpowiednią kategorię. Aspose.Slides for .NET umożliwia formatowanie punktów danych wykresu Sunburst i Treemap w C#.

To jest wykres Sunburst, w którym dane w kolumnie Series1 definiują węzły liści, a inne kolumny definiują punkty danych hierarchicznych:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Rozpocznijmy od dodania nowego wykresu Sunburst do prezentacji:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Zobacz także" %}} 
- [**Tworzenie wykresu Sunburst**](/slides/pl/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Jeśli istnieje potrzeba formatowania punktów danych wykresu, należy użyć następujących:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapointlevel) klasy oraz właściwość [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) zapewniają dostęp do formatowania punktów danych wykresów Treemap i Sunburst. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/IChartDataPointLevelsManager) jest używany do dostępu do kategorii wielopoziomowych – reprezentuje kontener obiektów [**IChartDataPointLevel**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/IChartDataPointLevel). W zasadzie jest to opakowanie dla [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/IChartCategoryLevelsManager) z dodatkowymi właściwościami specyficznymi dla punktów danych. Klasa [**IChartDataPointLevel**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/IChartDataPointLevel) posiada dwie właściwości: [**Format**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapointlevel/properties/format) oraz [**DataLabel**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapointlevel/properties/label), które zapewniają dostęp do odpowiednich ustawień.

## **Pokaż wartość punktu danych**

Pokaż wartość punktu danych „Leaf 4”:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ustaw etykietę i kolor punktu danych**

Ustaw etykietę danych „Branch 1”, aby wyświetlała nazwę serii („Series1”) zamiast nazwy kategorii. Następnie ustaw kolor tekstu na żółty:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ustaw kolor gałęzi punktu danych**

Zmień kolor gałęzi „Stem 4”:

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

**Czy mogę zmienić kolejność (sortowanie) segmentów w wykresie Sunburst/Treemap?**

Nie. PowerPoint sortuje segmenty automatycznie (zazwyczaj malejąco, zgodnie z ruchem wskazówek zegara). Aspose.Slides odzwierciedla to zachowanie: nie można zmienić kolejności bezpośrednio; należy to zrobić poprzez wstępne przetworzenie danych.

**Jak motyw prezentacji wpływa na kolory segmentów i etykiet?**

Kolory wykresu dziedziczą [motyw/palettę](/slides/pl/net/presentation-theme/) prezentacji, chyba że wyraźnie ustawisz wypełnienia/czcionki. Aby uzyskać spójne wyniki, zastosuj stałe wypełnienia i formatowanie tekstu na wymaganych poziomach.

**Czy eksport do PDF/PNG zachowa niestandardowe kolory gałęzi i ustawienia etykiet?**

Tak. Podczas eksportu prezentacji ustawienia wykresu (wypełnienia, etykiety) są zachowywane w formatach wyjściowych, ponieważ Aspose.Slides renderuje wykres z zastosowanym formatowaniem.

**Czy mogę obliczyć rzeczywiste współrzędne etykiety/elementu w celu umieszczenia własnej nakładki na wykresie?**

Tak. Po zweryfikowaniu układu wykresu dostępne są właściwości `ActualX`/`ActualY` dla elementów (na przykład dla [DataLabel](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/datalabel/)), co ułatwia precyzyjne pozycjonowanie nakładek.