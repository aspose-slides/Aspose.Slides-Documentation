---
title: Dostosowywanie tabel danych wykresów w prezentacjach przy użyciu Javy
linktitle: Tabela danych
type: docs
url: /pl/java/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dostosuj czcionki, obramowania i klucze legendy tabeli danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Aspose.Slides for Java umożliwia wyświetlanie tabeli danych wykresu oraz dostosowywanie formatowania tekstu, obramowań i kluczy legendy. W tym artykule wyjaśniono, jak włączyć tabelę, sformatować jej tekst, sterować każdym typem obramowania oraz pokazać lub ukryć klucze legendy. Przykłady zapisują skonfigurowane wykresy w plikach PPTX.

## **Ustaw właściwości czcionki**

Aby wyświetlić tabelę danych wykresu, przekaż `true` do [setDataTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/#setDataTable-boolean-). Użyj [getChartDataTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/#getChartDataTable--) aby uzyskać dostęp do tabeli i skonfigurować formatowanie tekstu.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Dodaj wykres kolumnowy grupowany do pierwszego slajdu.
3. Włącz tabelę danych wykresu.
4. Włącz pogrubiony tekst za pomocą [setFontBold](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) i przekaż `20` do [setFontHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) aby uzyskać tekst 20‑punktowy.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład wymaga pliku `test.pptx` w katalogu roboczym z co najmniej jednym slajdem. Dodaje wykres z domyślnymi danymi w pozycji (50, 50), o szerokości 600 punktów i wysokości 400 punktów. Zapisany plik `output.pptx` zawiera wykres z włączoną tabelą danych oraz zastosowanymi ustawieniami czcionki.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostosuj obramowania tabeli danych**

Włącz tabelę za pomocą [IChart.setDataTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/#setDataTable-boolean-) i uzyskaj do niej dostęp przez [IChart.getChartDataTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/#getChartDataTable--). Możesz niezależnie sterować trzema typami obramowań:

- [setBorderHorizontal](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) kontroluje poziome obramowania komórek.
- [setBorderVertical](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) kontroluje pionowe obramowania komórek.
- [setBorderOutline](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) kontroluje zewnętrzne obramowanie tabeli.

Przekaż `true` do każdej metody, aby wyświetlić jej obramowanie, lub `false`, aby je ukryć. Poniższy przykład tworzy wykres kolumnowy grupowany z domyślnymi danymi, wyświetla poziome obramowania i obramowanie zewnętrzne, a ukrywa pionowe obramowania. Nie wymaga pliku wejściowego. Pozycja i rozmiar wykresu podane są w punktach.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższe porównanie wykorzystuje te same dane wykresu i ustawienie klucza legendy we wszystkich czterech przypadkach. Zaczynając od włączonych wszystkich obramowań, każdy kolejny wariant wyłącza tylko jedno ustawienie obramowania. Wariant w lewym dolnym rogu odpowiada ustawieniom obramowań w przykładzie.

![Tabele danych wykresu z włączonymi wszystkimi obramowaniami, bez poziomych obramowań, bez pionowych obramowań i bez obramowania zewnętrznego](data-table-borders.png)

## **Pokaż lub ukryj klucze legendy**

Klucze legendy to małe, kolorowe znaczniki obok nazw serii w tabeli danych. Pomagają czytelnikom dopasować każdy wiersz tabeli do serii wykresu. Przekaż `true` do [setShowLegendKey](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) aby wyświetlić te znaczniki lub `false`, aby je ukryć.

Oddzielna legenda wykresu jest sterowana przez [IChart.setLegend](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/#setLegend-boolean-). Ustawienia te są niezależne: ukrycie oddzielnej legendy nie ukrywa kluczy wewnątrz tabeli danych, a ukrycie kluczy tabeli nie ukrywa oddzielnej legendy.

Poniższy przykład tworzy wykres z domyślnymi danymi, włącza jego tabelę danych i pokazuje klucze legendy wewnątrz niej, jednocześnie ukrywając oddzielną legendę. Wszystkie obramowania tabeli są jawnie włączone. Nie wymaga żadnej wejściowej prezentacji. Aby ukryć tylko klucze tabeli, przekaż `false` do [setShowLegendKey](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższe porównanie pokazuje tę samą tabelę z włączonymi i wyłączonymi kluczami legendy. Wszystkie obramowania pozostają włączone, a oddzielna legenda wykresu jest ukryta w obu przypadkach.

![Tabele danych wykresu z kluczami legendy po lewej stronie i ukrytymi po prawej stronie](data-table-legend-keys.png)

## **FAQ**

**Czy mogę wyświetlać klucze legendy w tabeli danych wykresu?**

Tak. Przekaż `true` do [setShowLegendKey](https://reference.aspose.com/slides/pl/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) aby wyświetlić klucze legendy lub `false`, aby je ukryć.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres i jego wyświetlaną tabelę danych jako część slajdu przy eksporcie do [PDF](/slides/pl/java/convert-powerpoint-to-pdf/), [HTML](/slides/pl/java/convert-powerpoint-to-html/) lub [obrazów](/slides/pl/java/convert-powerpoint-to-png/).

**Czy mogę pracować z tabelami danych w wykresach załadowanych z szablonu?**

Tak. Dla wykresu załadowanego z istniejącej prezentacji lub szablonu użyj [hasDataTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/#hasDataTable--) oraz [setDataTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/#setDataTable-boolean-) aby sprawdzić lub zmienić, czy jego tabela danych jest wyświetlana.

**Jak mogę znaleźć wykresy, które mają włączoną tabelę danych?**

Iteruj po kształtach na każdym slajdzie, zidentyfikuj wykresy i wywołaj ich metodę [hasDataTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/#hasDataTable--). Wartość `true` wskazuje, że tabela danych jest włączona.