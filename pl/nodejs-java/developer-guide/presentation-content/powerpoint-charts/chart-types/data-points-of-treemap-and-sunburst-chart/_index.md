---
title: Dostosuj punkty danych w wykresach Treemap i Sunburst przy użyciu JavaScript
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- wykres treemap
- wykres sunburst
- punkt danych
- kolor etykiety
- kolor gałęzi
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak zarządzać punktami danych w wykresach treemap i sunburst przy użyciu JavaScript i Aspose.Slides dla Node.js via Java, kompatybilne z formatami PowerPoint."
---
## **Wprowadzenie**

Wśród innych typów wykresów PowerPoint znajdują się dwa typy „hierarchiczne” - **Treemap** i **Sunburst** (znany także jako Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph lub Multi Level Pie Chart). Te wykresy wyświetlają hierarchiczne dane zorganizowane jako drzewo - od liści do wierzchołka gałęzi. Liście są definiowane przez punkty danych serii, a każdy kolejny zagnieżdżony poziom grupowania jest definiowany przez odpowiednią kategorię. Aspose.Slides for Node.js via Java umożliwia formatowanie punktów danych wykresu Sunburst i Treemap w JavaScript.

Poniżej znajduje się wykres Sunburst, w którym dane w kolumnie Series1 definiują węzły liści, natomiast pozostałe kolumny definiują hierarchiczne punkty danych:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Zacznijmy od dodania nowego wykresu Sunburst do prezentacji:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="Zobacz także" %}} 
- [**Utwórz lub zaktualizuj wykresy w prezentacji PowerPoint w JavaScript**](/slides/pl/nodejs-java/create-chart/)
{{% /alert %}}

Jeśli istnieje potrzeba formatowania punktów danych wykresu, powinniśmy użyć następujących:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataPointLevelsManager), [ChartDataPointLevel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataPointLevel) klasy i [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) metoda zapewniają dostęp do formatowania punktów danych wykresów Treemap i Sunburst.  
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataPointLevelsManager) jest używany do uzyskiwania dostępu do kategorii wielopoziomowych - reprezentuje kontener obiektów [**ChartDataPointLevel**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataPointLevel).  
Zasadniczo jest to wrapper dla [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartCategoryLevelsManager) z właściwościami dodanymi specjalnie dla punktów danych.  
Klasa [**ChartDataPointLevel**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataPointLevel) posiada dwie metody: [**getFormat**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) i [**getDataLabel**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) które zapewniają dostęp do odpowiednich ustawień.

## **Pokaż wartość punktu danych**

Pokaż wartość punktu danych "Leaf 4":

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ustaw etykietę i kolor punktu danych**

Ustaw etykietę danych "Branch 1", aby wyświetlała nazwę serii ("Series1") zamiast nazwy kategorii. Następnie ustaw kolor tekstu na żółty:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ustaw kolor gałęzi punktu danych**

Zmień kolor gałęzi "Steam 4":

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Czy mogę zmienić kolejność (sortowanie) segmentów w wykresie Sunburst/Treemap?**

Nie. PowerPoint sortuje segmenty automatycznie (zazwyczaj według wartości malejących, zgodnie z ruchem wskazówek zegara). Aspose.Slides odzwierciedla to zachowanie: nie możesz zmienić kolejności bezpośrednio; osiąga się to poprzez wstępne przetworzenie danych.

**Jak motyw prezentacji wpływa na kolory segmentów i etykiet?**

Kolory wykresu dziedziczą [motyw/paletę](/slides/pl/nodejs-java/presentation-theme/) prezentacji, chyba że wyraźnie ustawisz wypełnienia/czcionki. Aby uzyskać spójne wyniki, zastosuj stałe wypełnienia i formatowanie tekstu na wymaganych poziomach.

**Czy eksport do PDF/PNG zachowa niestandardowe kolory gałęzi i ustawienia etykiet?**

Tak. Podczas eksportu prezentacji ustawienia wykresu (wypełnienia, etykiety) są zachowywane w formatach wyjściowych, ponieważ Aspose.Slides renderuje wykres z zastosowanym formatowaniem.

**Czy mogę obliczyć rzeczywiste współrzędne etykiety/elementu w celu umieszczenia własnej nakładki nad wykresem?**

Tak. Po zwalidowaniu układu wykresu dostępne są rzeczywiste współrzędne X i Y dla elementów (na przykład dla [DataLabel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datalabel/)), co ułatwia precyzyjne pozycjonowanie nakładek.