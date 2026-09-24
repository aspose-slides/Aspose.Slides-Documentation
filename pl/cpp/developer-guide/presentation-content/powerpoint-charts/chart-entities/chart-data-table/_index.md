---
title: Dostosowywanie tabel danych wykresów w prezentacjach przy użyciu C++
linktitle: Tabela danych
type: docs
url: /pl/cpp/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dostosuj czcionki, obramowania i klucze legendy tabeli danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides for C++."
---
## **Przegląd**

Aspose.Slides for C++ umożliwia wyświetlanie tabeli danych wykresu oraz dostosowywanie formatowania tekstu, obramowań i kluczy legendy. Ten artykuł wyjaśnia, jak włączyć tabelę, sformatować jej tekst, sterować każdym typem obramowania oraz pokazać lub ukryć klucze legendy. Przykłady zapisują skonfigurowane wykresy w plikach PPTX.

## **Ustaw właściwości czcionki**

Aby wyświetlić tabelę danych wykresu, przekaż `true` do [IChart::set_HasDataTable](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Użyj [IChart::get_ChartDataTable](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/get_chartdatatable/), aby uzyskać dostęp do tabeli i skonfigurować formatowanie tekstu.

1. Wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Dodaj wykres kolumnowy grupowany do pierwszego slajdu.
1. Włącz tabelę danych wykresu.
1. Włącz pogrubiony tekst przy użyciu [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/set_fontbold/), a także przekaż `20` do [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/set_fontheight/), aby uzyskać tekst o wysokości 20 punktów.
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład wymaga pliku `test.pptx` w katalogu roboczym, który zawiera co najmniej jeden slajd. Dodaje wykres z domyślnymi danymi w pozycji (50, 50) o szerokości 600 punktów i wysokości 400 punktów. Zapisany plik `output.pptx` zawiera wykres z włączoną tabelą danych oraz zastosowanymi określonymi ustawieniami czcionki.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Dostosuj obramowania tabeli danych**

Włącz tabelę przy użyciu [IChart::set_HasDataTable](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/set_hasdatatable/), a uzyskaj do niej dostęp poprzez [IChart::get_ChartDataTable](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/get_chartdatatable/). Możesz niezależnie sterować trzema typami obramowań:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) steruje poziomymi obramowaniami komórek.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) steruje pionowymi obramowaniami komórek.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) steruje zewnętrznym obramowaniem tabeli.

Przekaż `true` do każdego ustawiającego, aby wyświetlić odpowiednie obramowanie, lub `false`, aby je ukryć. Poniższy przykład tworzy wykres kolumnowy grupowany z domyślnymi danymi, wyświetla poziome obramowania oraz zewnętrzne obramowanie, a ukrywa pionowe obramowania. Nie wymaga pliku wejściowego. Pozycja i rozmiar wykresu są określone w punktach.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

Poniższe porównanie używa tych samych danych wykresu i ustawienia kluczy legendy w czterech przypadkach. Zaczynając od włączonych wszystkich obramowań, każdy kolejny wariant wyłącza tylko jedno ustawienie obramowania. Wariant w lewym dolnym rogu odpowiada ustawieniom obramowań z przykładu.

![Tablice danych wykresu z włączonymi wszystkimi obramowaniami, bez poziomych obramowań, bez pionowych obramowań i bez obramowania zewnętrznego](data-table-borders.png)

## **Pokaż lub ukryj klucze legendy**

Klucze legendy to małe kolorowe znaczniki obok nazw serii w tabeli danych. Pomagają czytelnikom dopasować każdy wiersz tabeli do serii wykresu. Przekaż `true` do [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/idatatable/set_showlegendkey/), aby wyświetlić te znaczniki, lub `false`, aby je ukryć.

Oddzielna legenda wykresu jest kontrolowana przez [IChart::set_HasLegend](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/set_haslegend/). Te ustawienia są niezależne: ukrycie oddzielnej legendy nie ukrywa kluczy w tabeli danych, a ukrycie kluczy w tabeli nie ukrywa oddzielnej legendy.

Poniższy przykład tworzy wykres z domyślnymi danymi, włącza jego tabelę danych i pokazuje klucze legendy wewnątrz niej, jednocześnie ukrywając oddzielną legendę. Wszystkie obramowania tabeli są wyraźnie włączone. Nie jest wymagany żaden plik wejściowy. Aby ukryć jedynie klucze tabeli, przekaż `false` do [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

Poniższe porównanie pokazuje tę samą tabelę z włączonymi i wyłączonymi kluczami legendy. Wszystkie obramowania pozostają włączone, a oddzielna legenda wykresu jest ukryta w obu przypadkach.

![Tablice danych wykresu z kluczami legendy wyświetlonymi po lewej i ukrytymi po prawej](data-table-legend-keys.png)

## **FAQ**

**Czy mogę wyświetlić klucze legendy w tabeli danych wykresu?**

Tak. Przekaż `true` do [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/idatatable/set_showlegendkey/), aby wyświetlić klucze legendy lub `false`, aby je ukryć.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres i wyświetlaną tabelę danych jako część slajdu przy eksporcie do [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/pl/cpp/convert-powerpoint-to-html/) lub [images](/slides/pl/cpp/convert-powerpoint-to-png/).

**Czy mogę pracować z tabelami danych w wykresach załadowanych z szablonu?**

Tak. Dla wykresu załadowanego z istniejącej prezentacji lub szablonu, użyj [IChart::get_HasDataTable](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/get_hasdatatable/), aby sprawdzić, czy jego tabela danych jest wyświetlana, oraz [IChart::set_HasDataTable](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/set_hasdatatable/), aby zmienić jej widoczność.

**Jak mogę znaleźć wykresy, które mają włączoną tabelę danych?**

Iteruj przez kształty na każdym slajdzie, identyfikuj wykresy i sprawdzaj wynik [IChart::get_HasDataTable](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Wartość `true` wskazuje, że tabela danych jest włączona.