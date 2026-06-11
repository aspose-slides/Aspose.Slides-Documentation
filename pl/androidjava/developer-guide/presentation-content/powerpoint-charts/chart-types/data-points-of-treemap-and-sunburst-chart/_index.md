---
title: Dostosowanie punktów danych w wykresach Treemap i Sunburst na Androidzie
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- wykres treemap
- wykres sunburst
- punkt danych
- kolor etykiety
- kolor gałęzi
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać punktami danych w wykresach treemap i sunburst przy pomocy Aspose.Slides dla Androida poprzez Javę, kompatybilnego z formatami PowerPoint."
---
## **Wprowadzenie**

Wśród innych typów wykresów PowerPoint istnieją dwa typy „hierarchiczne” – **Treemap** i wykres **Sunburst** (znany również jako Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph lub Multi Level Pie Chart). Te wykresy wyświetlają dane hierarchiczne zorganizowane jako drzewo – od liści do szczytu gałęzi. Liście są definiowane przez punkty danych serii, a każdy kolejny zagnieżdżony poziom grupowania jest definiowany przez odpowiednią kategorię. Aspose.Slides for Android via Java umożliwia formatowanie punktów danych wykresu Sunburst i Treemap w Javie.

Poniżej znajduje się wykres Sunburst, w którym dane w kolumnie Series1 definiują węzły liści, a pozostałe kolumny definiują punkty danych hierarchicznych:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Rozpocznijmy od dodania nowego wykresu Sunburst do prezentacji:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Zobacz także" %}} 
- [**Utwórz lub zaktualizuj wykresy prezentacji PowerPoint na Androidzie**](/slides/pl/androidjava/create-chart/)
{{% /alert %}}

Jeśli istnieje potrzeba formatowania punktów danych wykresu, powinniśmy użyć następujących:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataPointLevel) klasy 
i [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) metoda 
zapewniają dostęp do formatowania punktów danych wykresów Treemap i Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
służy do uzyskiwania dostępu do kategorii wielopoziomowych – reprezentuje kontener obiektów 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataPointLevel). 
W zasadzie jest to wrapper dla 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartCategoryLevelsManager) z 
właściwościami dodanymi specjalnie dla punktów danych. 
Klasa [**IChartDataPointLevel**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataPointLevel) posiada dwie metody: [**getFormat**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) i 
[**getDataLabel**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) które zapewniają dostęp do odpowiednich ustawień.

## **Pokaż wartość punktu danych**

Pokaż wartość punktu danych „Leaf 4”:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ustaw etykietę i kolor punktu danych**

Ustaw etykietę danych „Branch 1”, aby wyświetlała nazwę serii („Series1”) zamiast nazwy kategorii. Następnie ustaw kolor tekstu na żółty:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ustaw kolor gałęzi punktu danych**

Zmień kolor gałęzi „Steam 4”:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Czy mogę zmienić kolejność (sortowanie) segmentów w wykresie Sunburst/Treemap?**

Nie. PowerPoint sortuje segmenty automatycznie (zazwyczaj malejąco według wartości, zgodnie z ruchem wskazówek zegara). Aspose.Slides odzwierciedla to zachowanie: nie można zmienić kolejności bezpośrednio; należy to zrobić poprzez wstępne przetworzenie danych.

**Jak motyw prezentacji wpływa na kolory segmentów i etykiet?**

Kolory wykresu dziedziczą [motyw/paleta](/slides/pl/androidjava/presentation-theme/) prezentacji, chyba że wyraźnie ustawisz wypełnienia/czcionki. Aby uzyskać spójne wyniki, zastosuj stałe wypełnienia i formatowanie tekstu na odpowiednich poziomach.

**Czy eksport do PDF/PNG zachowa niestandardowe kolory gałęzi i ustawienia etykiet?**

Tak. Podczas eksportu prezentacji ustawienia wykresu (wypełnienia, etykiety) są zachowywane w formatach wyjściowych, ponieważ Aspose.Slides renderuje wykres z zastosowanym formatowaniem.

**Czy mogę obliczyć rzeczywiste współrzędne etykiety/elementu w celu umieszczenia własnej nakładki na wykresie?**

Tak. Po zweryfikowaniu układu wykresu dostępne są rzeczywiste wartości *x* i *y* dla elementów (na przykład dla [DataLabel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/datalabel/)), co ułatwia precyzyjne pozycjonowanie nakładek.