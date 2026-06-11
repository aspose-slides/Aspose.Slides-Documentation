---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst przy użyciu Javy
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- wykres treemap
- wykres sunburst
- punkt danych
- kolor etykiety
- kolor gałęzi
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać punktami danych w wykresach treemap i sunburst przy użyciu Aspose.Slides dla Javy, zgodnie z formatami PowerPoint."
---
## **Wprowadzenie**

Wśród innych typów wykresów PowerPoint istnieją dwa typy „hierarchiczne” – **Treemap** i **Sunburst** (znany również jako Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph lub Multi Level Pie Chart). Te wykresy wyświetlają dane hierarchiczne zorganizowane jako drzewo – od liści do szczytu gałęzi. Liście są definiowane przez punkty danych serii, a każdy kolejny poziom zagnieżdżonej grupy jest definiowany przez odpowiadającą kategorię. Aspose.Slides for Java umożliwia formatowanie punktów danych wykresów Sunburst i Treemap w Javie.

Oto wykres Sunburst, w którym dane w kolumnie Series1 definiują węzły liści, natomiast inne kolumny definiują punkty danych hierarchicznych:

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
- [**Tworzenie lub aktualizacja wykresów prezentacji PowerPoint w Javie**](/slides/pl/java/create-chart/)
{{% /alert %}}

Jeśli istnieje potrzeba formatowania punktów danych wykresu, powinniśmy użyć następujących:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataPointLevel) klasy 
i [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) metoda 
udostępniają dostęp do formatowania punktów danych wykresów Treemap i Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataPointLevelsManager) 
służy do uzyskiwania dostępu do wielopoziomowych kategorii – reprezentuje kontener 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartCategoryLevelsManager) z 
właściwościami dodanymi specyficznie dla punktów danych. 
Klasa [**IChartDataPointLevel**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataPointLevel) ma 
dwie metody: [**getFormat**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataPointLevel#getFormat--) oraz 
[**getDataLabel**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataPointLevel#getLabel--) które 
udostępniają dostęp do odpowiednich ustawień.

## **Pokaż wartość punktu danych**

Pokaż wartość punktu danych "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ustaw etykietę i kolor punktu danych**

Ustaw etykietę danych "Branch 1", aby wyświetlała nazwę serii ("Series1") zamiast nazwy kategorii. Następnie ustaw kolor tekstu na żółty:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ustaw kolor gałęzi punktu danych**

Zmień kolor gałęzi "Steam 4":

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

Nie. PowerPoint sortuje segmenty automatycznie (zazwyczaj malejąco, zgodnie z ruchem wskazówek zegara). Aspose.Slides odzwierciedla to zachowanie: nie można zmienić kolejności bezpośrednio; można to uzyskać poprzez wstępne przetworzenie danych.

**Jak motyw prezentacji wpływa na kolory segmentów i etykiet?**

Kolory wykresu dziedziczą [theme/palette](/slides/pl/java/presentation-theme/) prezentacji, chyba że jawnie ustawisz wypełnienia/czcionki. Aby uzyskać spójne wyniki, ustal stałe wypełnienia i formatowanie tekstu na odpowiednich poziomach.

**Czy eksport do PDF/PNG zachowa niestandardowe kolory gałęzi i ustawienia etykiet?**

Tak. Podczas eksportu prezentacji ustawienia wykresu (wypełnienia, etykiety) są zachowywane w formatach wyjściowych, ponieważ Aspose.Slides renderuje wykres z zastosowanym formatowaniem.

**Czy mogę obliczyć rzeczywiste współrzędne etykiety/elementu w celu umieszczenia niestandardowej warstwy nakładki nad wykresem?**

Tak. Po zweryfikowaniu układu wykresu dostępne są rzeczywiste współrzędne *x* i *y* elementów (na przykład [DataLabel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/datalabel/)), co ułatwia precyzyjne pozycjonowanie nakładek.