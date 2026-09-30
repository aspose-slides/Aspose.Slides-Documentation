---
title: Dostosuj legendy wykresów w prezentacjach przy użyciu PHP
linktitle: Legenda wykresu
type: docs
url: /pl/php-java/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dostosuj legendy wykresów przy użyciu Aspose.Slides for PHP via Java, aby zoptymalizować prezentacje PowerPoint dzięki dopasowanemu formatowaniu legend."
---
## **Przegląd**

Aspose.Slides for PHP via Java udostępnia opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić pozycję i rozmiar legendy, określić rozmiar czcionki dla całej legendy, sformatować pojedynczy wpis legendy oraz ukryć lub przywrócić wybrane wpisy.

FAQ opisuje powiązane zachowania, w tym rezerwowanie miejsca dla legendy, wyświetlanie wielowierszowych etykiet oraz dziedziczenie formatowania z motywu prezentacji.

## **Pozycjonowanie legendy**

Użyj metod legendy [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), i [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) aby określić jej pozycję i rozmiar jako ułamki wymiarów wykresu.

Ten przykład tworzy prezentację i dodaje skumulowany wykres kolumnowy z domyślnymi danymi do pierwszego slajdu. Dzieląc żądane przesunięcia i wymiary legendy przez szerokość i wysokość wykresu, przelicza się je na wartości względne: legenda jest przesunięta o 50 punktów od lewego górnego rogu wykresu i ma rozmiar 100 × 100 punktów. Przykład używa java_values do konwersji wymiarów wykresu zwróconych przez PHP/Java Bridge na liczby PHP przed podziałem.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Wyraź pozycję i rozmiar legendy względem wykresu.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw rozmiar czcionki legendy**

Użyj [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) legendy, aby uzyskać dostęp do formatowania tekstu, oraz [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight), aby ustawić rozmiar czcionki w punktach.

Ten przykład tworzy wykres z domyślnymi danymi i ustawia tekst legendy na 20 punktów. Wyłącza także automatyczne granice osi pionowej i ustawia jej zakres od -5 do 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw rozmiar czcionki pojedynczego wpisu legendy**

Użyj kolekcji zwróconej przez metodę [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) legendy, aby uzyskać dostęp do formatowania konkretnego wpisu. Indeksy wpisów są zerowe, więc indeks `1` odnosi się do drugiego wpisu.

Ten przykład tworzy skumulowany wykres kolumnowy, którego domyślne dane zawierają co najmniej dwie serie. Formatuje drugi wpis legendy na pogrubiony, kursywny i niebieski tekst o rozmiarze 20 punktów.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ukryj pojedyncze wpisy legendy**

Aby wykluczyć dodatkową serię z legendy, zachowując jej dane widoczne, wywołaj [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) z wartością `true` przez [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Ukrywa to tylko wybrany wpis legendy; nie usuwa serii ani jej punktów danych. Wywołanie [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) z `false`, w przeciwieństwie do tego, ukrywa całą legendę.

Poniższy przykład tworzy skumulowany wykres kolumnowy z wieloma seriami przy użyciu domyślnych danych. Ukrywa wpis legendy drugiej serii (indeks `1`) i zapisuje prezentację. Następnie przywraca wpis, wywołując [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) z `false`, i zapisuje drugą kopię. Kolumny pozostają widoczne w obu plikach.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Przywróć ten sam wpis bez zmiany danych wykresu.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Porównanie poniżej pokazuje ten sam wykres ze wszystkimi widocznymi wpisami i z ukrytym drugim wpisem. Kolumny drugiej serii pozostają niezmienione.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

W wykresach kolumnowych, słupkowych i liniowych wpisy legendy identyfikują serie. W wykresach kołowych identyfikują pojedyncze punkty danych (kawałki), więc użyj [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) na wybranym kawałku. API dokumentuje tę metodę punktu danych dla typów wykresów `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` i `BarOfPie`. Nie zakładaj, że działa ona dla wykresów pierścieniowych, które nie są wymienione.

## **FAQ**

**Czy mogę sprawić, aby wykres rezerwował miejsce dla legendy zamiast nakładać ją?**

Tak. Wywołaj [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) z `false`, aby zarezerwować miejsce dla legendy zamiast pozwalać jej nakładać się na obszar wykresu.

**Czy mogę tworzyć wielowierszowe etykiety legendy?**

Tak. Długie etykiety mogą się zawijać, gdy dostępna szerokość jest niewystarczająca. Można także używać znaków nowej linii w nazwach serii, aby wymusić podziały linii.

**Jak sprawić, aby legenda podążała za schematem kolorów motywu prezentacji?**

Pozostaw kolory, wypełnienia i czcionki legendy nieustawione, aby mogła dziedziczyć formatowanie motywu. Ręczne formatowanie nadpisuje odpowiadające ustawienia motywu.