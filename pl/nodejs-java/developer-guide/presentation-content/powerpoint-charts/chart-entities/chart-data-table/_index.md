---
title: Dostosowanie tabel danych wykresów w prezentacjach przy użyciu JavaScript
linktitle: Tabela danych
type: docs
url: /pl/nodejs-java/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dostosuj czcionki, obramowania i klucze legendy tabeli danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides for Node.js via Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java umożliwia wyświetlanie tabeli danych wykresu oraz dostosowywanie formatowania tekstu, obramowań i kluczy legendy. Ten artykuł wyjaśnia, jak włączyć tabelę, sformatować jej tekst, sterować każdym typem obramowania oraz pokazać lub ukryć klucze legendy. Przykłady zapisują skonfigurowane wykresy w plikach PPTX.

## **Ustaw właściwości czcionki**

Aby wyświetlić tabelę danych wykresu, przekaż `true` do [setDataTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/setdatatable/). Użyj [getChartDataTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/getchartdatatable/), aby uzyskać dostęp do tabeli i skonfigurować formatowanie tekstu.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Dodaj wykres kolumnowy skumulowany do pierwszego slajdu.
3. Włącz tabelę danych wykresu.
4. Włącz pogrubiony tekst za pomocą [setFontBold](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setfontbold) i przekaż `20` do [setFontHeight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setfontheight), aby uzyskać tekst o rozmiarze 20 punktów.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład wymaga pliku `input.pptx` w katalogu roboczym z co najmniej jednym slajdem. Dodaje wykres z domyślnymi danymi w położeniu (50, 50), o szerokości 600 punktów i wysokości 400 punktów. Zapisany plik `output.pptx` zawiera wykres z włączoną tabelą danych oraz zastosowanymi określonymi ustawieniami czcionki.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostosuj obramowania tabeli danych**

Uaktywnij tabelę za pomocą [Chart.setDataTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/setdatatable/) i uzyskaj do niej dostęp poprzez [Chart.getChartDataTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/getchartdatatable/). Możesz niezależnie sterować trzema typami obramowań:

- [setBorderHorizontal](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datatable/setborderhorizontal/) kontroluje poziome obramowania komórek.
- [setBorderVertical](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datatable/setbordervertical/) kontroluje pionowe obramowania komórek.
- [setBorderOutline](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datatable/setborderoutline/) kontroluje zewnętrzne obramowanie tabeli.

Przekaż `true` do każdej metody, aby wyświetlić jej obramowanie, lub `false`, aby je ukryć. Poniższy przykład tworzy wykres kolumnowy skumulowany z domyślnymi danymi, wyświetla poziome obramowania i obramowanie zewnętrzne, a ukrywa pionowe obramowania. Nie wymaga pliku wejściowego. Pozycja i rozmiar wykresu są określone w punktach.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższe porównanie używa tych samych danych wykresu i ustawienia klucza legendy we wszystkich czterech przypadkach. Rozpoczynając od włączonych wszystkich obramowań, każdy kolejny wariant wyłącza tylko jedno ustawienie obramowania. Wariant w lewym dolnym rogu odpowiada ustawieniom obramowań z przykładu.

![Tabele danych wykresu ze wszystkimi obramowaniami włączonymi, bez poziomych obramowań, bez pionowych obramowań i bez obramowania zewnętrznego](data-table-borders.png)

## **Pokaż lub ukryj klucze legendy**

Klucze legendy to małe kolorowe znaczniki obok nazw serii w tabeli danych. Pomagają czytelnikom dopasować każdy wiersz tabeli do serii wykresu. Przekaż `true` do [setShowLegendKey](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datatable/setshowlegendkey/), aby wyświetlić te znaczniki, lub `false`, aby je ukryć.

Oddzielna legenda wykresu jest sterowana przez [Chart.setLegend](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/setlegend/). Te ustawienia są niezależne: ukrycie oddzielnej legendy nie ukrywa kluczy w tabeli danych, a ukrycie kluczy w tabeli nie ukrywa oddzielnej legendy.

Poniższy przykład tworzy wykres z domyślnymi danymi, włącza jego tabelę danych i wyświetla klucze legendy wewnątrz niej, jednocześnie ukrywając oddzielną legendę. Wszystkie obramowania tabeli są wyraźnie włączone. Nie jest wymagana żadna prezentacja wejściowa. Aby ukryć tylko klucze tabeli, przekaż `false` do [setShowLegendKey](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższe porównanie pokazuje tę samą tabelę z włączonymi i wyłączonymi kluczami legendy. Wszystkie obramowania pozostają włączone, a oddzielna legenda wykresu jest ukryta w obu przypadkach.

![Tabele danych wykresu z kluczami legendy pokazanymi po lewej i ukrytymi po prawej](data-table-legend-keys.png)

## **FAQ**

**Czy mogę wyświetlić klucze legendy w tabeli danych wykresu?**

Tak. Przekaż `true` do [setShowLegendKey](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datatable/setshowlegendkey/), aby wyświetlić klucze legendy, lub `false`, aby je ukryć.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres i wyświetlaną tabelę danych jako część slajdu przy eksporcie do [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/), lub [obrazów](/slides/pl/nodejs-java/convert-powerpoint-to-png/).

**Czy mogę pracować z tabelami danych w wykresach wczytanych z szablonu?**

Tak. Dla wykresu wczytanego z istniejącej prezentacji lub szablonu użyj [hasDataTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/hasdatatable/) i [setDataTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/setdatatable/), aby sprawdzić lub zmienić, czy jego tabela danych jest wyświetlana.

**Jak mogę znaleźć wykresy, które mają włączoną tabelę danych?**

Iteruj po kształtach na każdym slajdzie, zidentyfikuj wykresy i wywołaj ich metodę [hasDataTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/hasdatatable/). Wartość `true` wskazuje, że tabela danych jest włączona.