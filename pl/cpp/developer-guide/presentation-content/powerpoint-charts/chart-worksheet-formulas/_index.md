---
title: Zastosuj formuły arkusza wykresu w prezentacjach przy użyciu C++
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/cpp/chart-worksheet-formulas/
keywords:
- arkusz kalkulacyjny wykresu
- arkusz wykresu
- formuła wykresu
- formuła arkusza
- formuła arkusza kalkulacyjnego
- skoroszyt danych wykresu
- obliczanie formuły
- preferowana kultura
- formuła specyficzna dla kultury
- DBCS
- stała logiczna
- stała liczbowa
- stała łańcuchowa
- stała błędu
- operator arytmetyczny
- operator porównania
- styl A1
- styl R1C1
- funkcja wstępnie zdefiniowana
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w skoroszytach wykresów Aspose.Slides dla C++, przelicz wartości i użyj wyników w wykresach PowerPoint."
---
## **Przegląd**

Wykresy PowerPoint zwykle przechowują dane źródłowe w osadzonym arkuszu. W Aspose.Slides for C++ można uzyskać dostęp do tego arkusza poprzez skoroszyt danych wykresu, zapisywać wartości wejściowe, przypisywać formuły do komórek, obliczać obsługiwane formuły i używać obliczonych komórek jako danych wykresu.

Ten artykuł wyjaśnia kompletny przepływ pracy z formułami: tworzenie wykresu, wypełnianie jego arkusza, przypisywanie formuł w stylu A1 lub R1C1, przeliczanie ich, odczytywanie obliczonych wartości, łączenie tych komórek z serią wykresu i zapisywanie prezentacji. Opisuje także składnię obsługiwanych formuł, wbudowany podzbiór funkcji, wartości buforowane, nieobsługiwane formuły oraz błędy specyficzne dla arkuszy kalkulacyjnych.

## **Arkusze wykresów i formuły**

Arkusz wykresu zawiera kategorie, nazwy serii i wartości używane przez wykres. W PowerPoint można przeglądać arkusz, otwierając edytor danych wykresu:

![Wykres PowerPoint z otwartym osadzonym arkuszem, pokazujący dane kategorii i serii](chart-worksheet-formulas_1.png)

W Aspose.Slides arkusz jest udostępniany poprzez interfejs [IChartDataWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/). Użyj [IChartDataCell::set_Formula](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/set_formula/) dla formuł w stylu A1 i [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) dla formuł w stylu R1C1. Po zmianie komórek wejściowych lub formuł wywołaj [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/), aby przeliczyć obsługiwane formuły i zaktualizować odpowiadające wartości komórek.

Obliczona komórka wciąż udostępnia swój wynik poprzez [IChartDataCell::get_Value](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/get_value/). Jest to istotne, gdy trzeba sprawdzić wynik formuły w kodzie lub użyć komórki jako punktu danych wykresu.

## **Utworzenie wykresu i obliczenie formuł w arkuszu**

Poniższy przykład demonstruje pełny przepływ pracy. Tworzy wykres kolumnowy grupowany, usuwa przykładowe dane, zapisuje kwartalne przychody i wydatki, oblicza zysk przy użyciu formuł, odczytuje wyniki, używa obliczonych komórek jako wartości wykresu i zapisuje prezentację.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Punkty danych wykresu odwołują się do `D2:D4`, więc wykres używa obliczonych wartości zysku. Nie ma osobnego wywołania odświeżania wykresu w tym przepływie: najpierw przelicz skoroszyt, a potem użyj lub zapisz dane wykresu wskazujące na obliczone komórki.

## **Używanie formuł w stylu A1**

Notacja A1 identyfikuje kolumny literami, a wiersze liczbami. Przypisuj wyrażenia w stylu A1 za pomocą [IChartDataCell::set_Formula](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Typowe formy odwołań A1:

| Odwołanie | Względny | Bezwzględny | Mieszany |
|---|---|---|---|
| Komórka | `A2` | `$A$2` | `A$2`, `$A2` |
| Wiersz | `2:2` | `$2:$2` | — |
| Kolumna | `A:A` | `$A:$A` | — |
| Zakres | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Odwołania względne mogą się zmieniać, gdy formuła jest przenoszona lub kopiowana w aplikacji arkusza. Odwołania bezwzględne utrzymują oba współrzędne stałe, natomiast odwołania mieszane blokują tylko wiersz lub kolumnę.

## **Używanie formuł w stylu R1C1**

Notacja R1C1 identyfikuje zarówno wiersze, jak i kolumny liczbami. Odwołania względne używają przesunięć w nawiasach kwadratowych. Przypisz tę składnię za pomocą [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Typowe formy odwołań R1C1:

| Odwołanie | Względny | Bezwzględny | Mieszany |
|---|---|---|---|
| Komórka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Wiersz | `R[2]` | `R2` | — |
| Kolumna | `C[3]` | `C3` | — |
| Zakres | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Na przykład w komórce `D2`, `RC[-2]` oznacza komórkę w tym samym wierszu dwie kolumny w lewo (`B2`).

## **Stałe i operatory formuł**

Wbudowany evaluator formuł obsługuje wartości logiczne, literały liczbowe, łańcuchy, wartości błędów arkusza, operatory arytmetyczne i operatory porównania.

### **Stałe i literały**

| Typ | Przykłady | Uwagi |
|---|---|---|
| Logiczny | `TRUE`, `FALSE` | Można używać bezpośrednio w wyrażeniach logicznych, np. `A2=TRUE`. |
| Numeryczny | `1`, `0.5`, `.3`, `1E-2` | Obsługiwane są notacje dziesiętna i naukowa. |
| Łańcuch | `"abc"`, `"2/3/2020 12:00"` | Literały tekstowe są umieszczane w podwójnych cudzysłowach wewnątrz formuły. |
| Wynik błędu | `#DIV/0!`, `#N/A`, `#REF!` | Prawidłowa formuła może zwrócić wartość błędu arkusza zamiast wyniku. |

Ten przykład używa kilku typów stałych:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Fałsz
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Operatory arytmetyczne**

| Operator | Znaczenie | Przykład |
|---|---|---|
| `+` | Dodawanie lub znak plus unarny | `2+3` |
| `-` | Odejmowanie lub negacja | `2-3`, `-3` |
| `*` | Mnożenie | `2*3` |
| `/` | Dzielenie | `2/3` |
| `%` | Procent | `30%` |
| `^` | Potęgowanie | `2^3` |

Używaj nawiasów, aby jasno określić kolejność obliczeń, np. `(A2+B2)*C2`.

### **Operatory porównania**

Wyrażenia porównawcze zwracają wartości logiczne.

| Operator | Znaczenie | Przykład |
|---|---|---|
| `=` | Równe | `A2=3` |
| `<>` | Nierówne | `A2<>3` |
| `>` | Większe niż | `A2>3` |
| `>=` | Większe lub równe | `A2>=3` |
| `<` | Mniejsze niż | `A2<3` |
| `<=` | Mniejsze lub równe | `A2<=3` |

## **Obsługiwane wbudowane funkcje**

Aspose.Slides zawiera wbudowany evaluator formuł dla arkuszy wykresów, ale nie jest pełnym silnikiem obliczeniowym Excel. Dokumentowany zestaw funkcji jest ograniczony do poniższych. Nie zakładaj, że dowolna funkcja Excel zostanie przeliczona przez [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Funkcja | Cel lub obsługiwana forma | Przykład |
|---|---|---|
| `ABS` | Wartość bezwzględna | `ABS(A2)` |
| `AVERAGE` | Średnia arytmetyczna | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrąglenie w górę do wielokrotności | `CEILING(A2,5)` |
| `CHOOSE` | Wybór wartości po indeksie | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Łączenie wartości tekstowych | `CONCAT(A2,B2)` |
| `CONCATENATE` | Łączenie wartości tekstowych | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tworzenie wartości daty w systemie 1900 | `DATE(2026,8,19)` |
| `DAYS` | Liczba dni pomiędzy datami | `DAYS(B2,A2)` |
| `FIND` | Znalezienie jednej wartości tekstowej w drugiej | `FIND("-",A2)` |
| `FINDB` | Wyszukiwanie tekstu bajtowo | `FINDB("a",A2)` |
| `IF` | Wynik warunkowy | `IF(A2>0,A2,0)` |
| `INDEX` | Forma odwołania | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma wektorowa | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma wektorowa | `MATCH(A2,B2:B5,0)` |
| `MAX` | Wartość maksymalna | `MAX(B2:B5)` |
| `SUM` | Suma wartości | `SUM(B2:B5)` |
| `VLOOKUP` | Wyszukiwanie pionowe | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ograniczenia w tabeli są istotne: `INDEX` jest dokumentowany w formie odwołania, podczas gdy `LOOKUP` i `MATCH` w formach wektorowych. `DATE` używa systemu dat 1900. Funkcje nie wymienione tutaj należy uznać za nieobsługiwane przez evaluator Aspose.Slides, chyba że są osobno udokumentowane.

## **Obliczanie formuł przy użyciu preferowanej kultury**

Niektóre funkcje skoroszytu interpretują tekst zgodnie z regułami kulturowymi. Ma to szczególne znaczenie dla funkcji przeznaczonych dla języków używających zestawów znaków podwójnego bajtu (DBCS). Aby poprawnie obliczyć takie formuły, utwórz [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/), skonfiguruj [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) przez [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), a następnie załaduj prezentację.

Poniższy przykład wybiera kulturę japońską, otwiera prezentację z skonfigurowanymi opcjami ładowania i wywołuje [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) dla każdego skoroszytu wykresu:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

Preferowana kultura jest częścią konfiguracji ładowania prezentacji, więc określ ją przed utworzeniem obiektu [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Użyj kultury oczekiwanej przez formuły skoroszytu; na przykład `ja-JP` dla formuł, które powinny stosować japońskie reguły DBCS.

## **Przeliczanie i wartości buforowane**

Pliki arkuszy kalkulacyjnych często przechowują zarówno formułę, jak i ostatnio obliczoną wartość. Aspose.Slides może więc odczytać wartość buforowaną z [IChartDataCell::get_Value](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/get_value/) podczas ładowania prezentacji, jeśli odpowiednie dane wykresu nie uległy zmianie.

Po zmianie komórek wejściowych lub formuł nie polegaj na starej buforowanej wartości. Wywołaj [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) przed odczytaniem obliczonych wartości lub zapisaniem danych wykresu zależnych od nich.

Dla formuł spoza obsługiwanego podzbioru Aspose.Slides może nie być w stanie sparsować formuły ani ustalić jej zależności. Jeśli skoroszyt został zmodyfikowany, poprzednia wartość buforowana nie jest już wiarygodna. W takiej sytuacji odczyt wartości komórki z nieobsługiwanymi danymi może spowodować wyrzucenie [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Jeśli twój wykres zależy od funkcji Excel, których Aspose.Slides nie ocenia, oblicz te formuły przy użyciu silnika arkusza kalkulacyjnego, który je obsługuje, i zapisz uzyskane wartości z powrotem do skoroszytu wykresu. Nie zastępuj nieobsługiwanych formuł wartościami domyślnymi.

## **Obsługa błędów formuł**

Rozróżnia się dwa rodzaje problemów.

Formuła może być prawidłowa, ale zwrócić wynik błędu arkusza, taki jak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` lub `#VALUE!`. W takim wypadku token błędu jest wynikiem komórki i może być zwrócony przez [IChartDataCell::get_Value](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Formuła może także nie powieść się na etapie parsowania, odwołania, zależności lub obsługi danych. Aspose.Slides dostarcza specyficzne dla arkuszy wyjątki: [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pl/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pl/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), oraz [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Gdy formuły pochodzą z szablonów lub wejścia użytkownika, obsłuż te wyjątki wokół przeliczania i dostępu do wartości:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Obsłuż nieprawidłową formułę.
}
catch (CellInvalidReferenceException&)
{
    // Obsłuż nieprawidłowe odwołanie do komórki.
}
catch (CellCircularReferenceException&)
{
    // Obsłuż odwołanie cykliczne.
}
catch (CellUnsupportedDataException&)
{
    // Obsłuż nieobsługiwane dane arkusza kalkulacyjnego.
}
```

## **Praktyczne ograniczenia**

Obsługa formuł w arkuszach wykresów jest przeznaczona dla określonego podzbioru obliczeń arkuszy, a nie dla pełnej kompatybilności z Excel. Pamiętaj o tych ograniczeniach przy projektowaniu przepływu raportowania:

- Używaj wyłącznie udokumentowanych stałych, operatorów, odwołań i funkcji, gdy potrzebujesz, aby Aspose.Slides przeliczało formuły.
- Przeliczaj po zmianie komórek, od których zależą wyniki formuł.
- Traktuj wartości buforowane z załadowanych prezentacji jako migawki, a nie jako zamiennik przeliczania po edycji.
- Przetestuj formuły z istniejących szablonów przed poleganiem na ich obliczonych wartościach, szczególnie gdy używają funkcji spoza udokumentowanej listy.
- Dla formuł wymagających pełnego silnika obliczeniowego arkusza, oblicz je zewnętrznie, a następnie zaktualizuj skoroszyt wykresu uzyskanymi wartościami.

## **FAQ**

**Jaka jest różnica między `set_Formula` a `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/set_formula/) przechowuje wyrażenie w stylu A1, np. `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) przechowuje wyrażenie w stylu R1C1, np. `RC[-2]-RC[-1]`. Użyj notacji, która najlepiej pasuje do sposobu generowania lub kopiowania formuł.

**Czy muszę odczytać samą komórkę czy jej wartość po przeliczeniu?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) zwraca `IChartDataCell`. Aby uzyskać obliczony wynik, odczytaj wartość tej komórki przez [IChartDataCell::get_Value](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/get_value/) po przeliczeniu.

**Kiedy powinienem wywołać `CalculateFormulas`?**

Wywołaj [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) po zmianie wartości wejściowych lub formuł i przed tym, jak będziesz zależny od obliczonych wyników. Aktualizuje to wartości formuł obsługiwanych przez wbudowany evaluator.

**Czy Aspose.Slides obsługuje każdą funkcję Excela?**

Nie. Wbudowany evaluator obsługuje udokumentowany podzbiór funkcji. Funkcje spoza tego podzbioru nie powinny być traktowane jako przeliczalne poprawnie. Jeśli wymagana jest pełna kompatybilność z formułami Excel, wykonaj obliczenia przy użyciu odpowiedniego silnika arkusza i zapisz ostateczne wartości do skoroszytu wykresu.

**Co się stanie, jeśli załadowana prezentacja zawiera nieobsługiwaną formułę?**

Jeśli dane wykresu nie uległy zmianie, skoroszyt może nadal zawierać poprzednio obliczoną wartość buforowaną. Po modyfikacji powiązanych danych ta buforowana wartość może być już nieprawidłowa. Dostęp do komórki, której formuła nie może być obsłużona, może spowodować wyrzucenie [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Czy wartości błędów formuły są tym samym, co wyjątki C++?**

Nie. Wynik taki jak `#DIV/0!` jest wartością arkusza uzyskaną z prawidłowego obliczenia. Wyjątki takie jak [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) lub [CellCircularReferenceException](https://reference.aspose.com/slides/pl/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) wskazują, że formuła nie może być przetworzona w normalny sposób.

**Czy wykres aktualizuje się automatycznie po zmianie komórki formuły?**

Seria wykresu może odwoływać się do komórek skoroszytu. Przelicz najpierw skoroszyt, a potem zapisz lub renderuj prezentację. Jeśli punkty danych wykresu odwołują się do obliczonych komórek, wykres użyje zaktualizowanych wartości; nie jest wymagane osobne wywołanie odświeżania wykresu w tym przepływie.

**Czy wykresy mogą używać zewnętrznego skoroszytu Excel?**

Tak, dane wykresu można skonfigurować do użycia zewnętrznego skoroszytu poprzez API danych wykresu. Jednak opisany w tym artykule przepływ obliczania formuł dotyczy skoroszytu danych wykresu i podzbioru formuł ocenianych przez Aspose.Slides. Nie zakładaj, że [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) zapewnia pełne przeliczenie dowolnych formuł w zewnętrznym pliku XLSX.

**Czy mogę używać formuł odwołujących się do innego arkusza lub skoroszytu?**

Odwołania w stylu Excel mogą występować w skoroszytach wykresów, ale ocena formuł jest ograniczona przez obsługiwany parser i zestaw funkcji. Jeśli odwołanie między arkuszami lub do zewnętrznego skoroszytu jest niezbędne, zweryfikuj dokładną formułę z wersją Aspose.Slides, której używasz. Dla przepływów wymagających szerokiej kompatybilności odwołań Excel, oblicz skoroszyt zewnętrznie i zapisz rozwiązane wartości z powrotem do danych wykresu.

**Czy ciągi formuł powinny zaczynać się od `=`?**

Przykłady API Aspose.Slides przypisują wyrażenia takie jak `B2-C2` lub `SUM(B2:B5)` bez początkowego znaku `=`. Używanie takiej formy utrzymuje generowane formuły zgodne z udokumentowanymi przykładami API.