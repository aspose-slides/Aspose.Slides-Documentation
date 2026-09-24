---
title: Dostosuj tabele danych wykresów w prezentacjach przy użyciu PHP
linktitle: Tabela danych
type: docs
url: /pl/php-java/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dostosuj czcionki, obramowania i klucze legendy w tabelach danych wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP via Java."
---
## **Przegląd**

Aspose.Slides dla PHP via Java umożliwia wyświetlanie tabeli danych wykresu oraz dostosowywanie formatowania tekstu, obramowań i kluczy legendy. Ten artykuł wyjaśnia, jak włączyć tabelę, sformatować jej tekst, sterować każdym typem obramowania oraz pokazać lub ukryć klucze legendy. Przykłady zapisują skonfigurowane wykresy w plikach PPTX.

## **Ustaw właściwości czcionki**

Aby wyświetlić tabelę danych wykresu, przekaż `true` do [setDataTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/setdatatable/). Użyj [getChartDataTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/getchartdatatable/), aby uzyskać dostęp do tabeli i skonfigurować formatowanie tekstu.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Dodaj wykres słupkowy grupowany do pierwszego slajdu.
1. Włącz tabelę danych wykresu.
1. Włącz pogrubiony tekst przy użyciu [setFontBold](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setFontBold) i przekaż `20` do [setFontHeight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setFontHeight) dla tekstu 20 punktów.
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład wymaga pliku `test.pptx` w katalogu roboczym z co najmniej jednym slajdem. Dodaje wykres z domyślnymi danymi w pozycji (50, 50), o szerokości 600 punktów i wysokości 400 punktów. Zapisany plik `output.pptx` zawiera wykres z włączoną tabelą danych oraz zastosowanymi ustawieniami czcionki.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dostosuj obramowania tabeli danych**

Włącz tabelę przy użyciu [Chart::setDataTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/setdatatable/) i uzyskaj do niej dostęp przez [Chart::getChartDataTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/getchartdatatable/). Możesz kontrolować trzy typy obramowań niezależnie:

- [setBorderHorizontal](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datatable/setborderhorizontal/) steruje poziomymi obramowaniami komórek.
- [setBorderVertical](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datatable/setbordervertical/) steruje pionowymi obramowaniami komórek.
- [setBorderOutline](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datatable/setborderoutline/) steruje zewnętrznym obramowaniem tabeli.

Przekaż `true` do każdej metody, aby wyświetlić jej obramowanie, lub `false`, aby je ukryć. Poniższy przykład tworzy wykres słupkowy grupowany z domyślnymi danymi, wyświetla poziome obramowania i zewnętrzne obramowanie, a ukrywa pionowe obramowania. Nie wymaga pliku wejściowego. Pozycja i rozmiar wykresu podane są w punktach.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Porównanie poniżej używa tych samych danych wykresu i ustawienia klucza legendy we wszystkich czterech przypadkach. Zaczynając od włączonych wszystkich obramowań, każdy kolejny wariant wyłącza tylko jedno ustawienie obramowania. Wariant w lewym dolnym rogu odpowiada ustawieniom obramowań w przykładzie.

![Tabele danych wykresu ze wszystkimi włączonymi obramowaniami, bez poziomych obramowań, bez pionowych obramowań oraz bez obramowania zewnętrznego](data-table-borders.png)

## **Pokaż lub ukryj klucze legendy**

Klucze legendy to małe kolorowe znaczniki obok nazw serii w tabeli danych. Pomagają czytelnikom dopasować każdy wiersz tabeli do serii wykresu. Przekaż `true` do [setShowLegendKey](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datatable/setshowlegendkey/), aby wyświetlić te znaczniki, lub `false`, aby je ukryć.

Oddzielna legenda wykresu jest sterowana przez [Chart::setLegend](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/setlegend/). Te ustawienia są niezależne: ukrycie oddzielnej legendy nie ukrywa kluczy w tabeli danych, a ukrycie kluczy w tabeli nie ukrywa oddzielnej legendy.

Poniższy przykład tworzy wykres z domyślnymi danymi, włącza jego tabelę danych i wyświetla klucze legendy w niej, jednocześnie ukrywając oddzielną legendę. Wszystkie obramowania tabeli są wyraźnie włączone. Nie wymaga prezentacji wejściowej. Aby ukryć tylko klucze tabeli, przekaż `false` do [setShowLegendKey](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Porównanie poniżej pokazuje tę samą tabelę z włączonymi i wyłączonymi kluczami legendy. Wszystkie obramowania pozostają włączone, a oddzielna legenda wykresu jest ukryta w obu przypadkach.

![Tabele danych wykresu z kluczami legendy po lewej stronie i ukrytymi po prawej stronie](data-table-legend-keys.png)

## **FAQ**

**Czy mogę wyświetlać klucze legendy w tabeli danych wykresu?**

Tak. Przekaż `true` do [setShowLegendKey](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datatable/setshowlegendkey/), aby wyświetlić klucze legendy, lub `false`, aby je ukryć.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres i wyświetlaną tabelę danych jako część slajdu podczas eksportu do [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/pl/php-java/convert-powerpoint-to-html/) lub [obrazów](/slides/pl/php-java/convert-powerpoint-to-png/).

**Czy mogę pracować z tabelami danych w wykresach załadowanych z szablonu?**

Tak. Dla wykresu załadowanego z istniejącej prezentacji lub szablonu użyj [hasDataTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/hasdatatable/) i [setDataTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/setdatatable/), aby sprawdzić lub zmienić, czy tabela danych jest wyświetlana.

**Jak mogę znaleźć wykresy, które mają włączoną tabelę danych?**

Iteruj po kształtach na każdym slajdzie, identyfikuj wykresy i wywołaj ich metodę [hasDataTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/hasdatatable/). Wartość `true` wskazuje, że tabela danych jest włączona.