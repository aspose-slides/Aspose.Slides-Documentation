---
title: Zastosuj formuły arkusza wykresu w prezentacjach przy użyciu Pythona
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/python-net/chart-worksheet-formulas/
keywords:
- arkusz kalkulacyjny wykresu
- arkusz roboczy wykresu
- formuła wykresu
- formuła arkusza
- formuła arkusza kalkulacyjnego
- skoroszyt danych wykresu
- obliczanie formuły
- stała logiczna
- stała numeryczna
- stała tekstowa
- stała błędu
- operator arytmetyczny
- operator porównania
- styl A1
- styl R1C1
- funkcja wbudowana
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w arkuszach wykresów Aspose.Slides dla Pythona via .NET, przelicz wartości i użyj wyników w wykresach PowerPoint."
---
## **Przegląd**

Wykresy PowerPoint zazwyczaj przechowują swoje dane źródłowe w osadzonym arkuszu kalkulacyjnym. W Aspose.Slides for Python via .NET możesz uzyskać dostęp do tego arkusza poprzez skoroszyt danych wykresu, zapisywać wartości wejściowe, przypisywać formuły do komórek, obliczać obsługiwane formuły i używać obliczonych komórek jako danych wykresu.

Ten artykuł opisuje kompletny proces z formułami: tworzenie wykresu, wypełnianie jego arkusza, przypisywanie formuł w stylu A1 lub R1C1, ich przeliczenie, odczyt obliczonych wartości, podłączenie tych komórek do serii wykresu i zapis prezentacji. Opisuje również obsługiwany składniowo zestaw formuł, wbudowany podzbiór funkcji, wartości buforowane, nieobsługiwane formuły oraz błędy specyficzne dla arkuszy kalkulacyjnych.

## **Arkusze wykresów i formuły**

Arkusz wykresu zawiera kategorie, nazwy serii i wartości używane przez wykres. W PowerPoint możesz przejrzeć arkusz, otwierając edytor danych wykresu:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

W Aspose.Slides arkusz jest udostępniany poprzez [chart data workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdataworkbook/). Użyj właściwości [formula](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/formula/) dla formuł w stylu A1 oraz [r1c1_formula](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) dla formuł w stylu R1C1. Po zmianie komórek wejściowych lub formuł wywołaj [calculate_formulas](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) aby przeliczyć obsługiwane formuły i zaktualizować odpowiadające wartości komórek.

Obliczona komórka nadal udostępnia swój wynik poprzez właściwość [value](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/value/). Jest to ważne, gdy trzeba sprawdzić wynik formuły w kodzie lub użyć komórki jako punktu danych wykresu.

## **Utworzenie wykresu i przeliczenie formuł w arkuszu**

Poniższy przykład demonstruje kompletny przebieg pracy. Tworzy wykres słupkowy grupowy, czyści przykładowe dane, zapisuje kwartalne przychody i wydatki, oblicza zysk przy pomocy formuł, odczytuje wyniki, używa obliczonych komórek jako wartości wykresu i zapisuje prezentację.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Punkty danych wykresu odwołują się do `D2:D4`, więc wykres używa obliczonych wartości zysku. W tym przebiegu nie ma osobnego wywołania odświeżania wykresu: najpierw przelicz skoroszyt, a potem użyj lub zapisz dane wykresu wskazujące na obliczone komórki.

## **Używanie formuł w stylu A1**

Notacja A1 identyfikuje kolumny literami, a wiersze numerami. Przypisz wyrażenia w stylu A1 poprzez [IChartDataCell.formula](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Typowe formy odwołań A1:

| Odwołanie | Względny | Bezwzględny | Mieszany |
|---|---|---|---|
| Komórka | `A2` | `$A$2` | `A$2`, `$A2` |
| Wiersz | `2:2` | `$2:$2` | — |
| Kolumna | `A:A` | `$A:$A` | — |
| Zakres | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Odwołania względne mogą się zmieniać, gdy formuła zostanie przeniesiona lub skopiowana w aplikacji arkusza. Odwołania bezwzględne utrzymują oba współrzędne stałe, natomiast odwołania mieszane ustalają tylko wiersz lub kolumnę.

## **Używanie formuł w stylu R1C1**

Notacja R1C1 identyfikuje zarówno wiersze, jak i kolumny numerycznie. Odwołania względne używają offsetów w nawiasach kwadratowych. Przypisz tę składnię poprzez [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
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

Wbudowany evaluator formuł obsługuje wartości logiczne, literały numeryczne, ciągi znaków, wartości błędów arkusza, operatory arytmetyczne i operatory porównania.

### **Stałe i literały**

| Typ | Przykłady | Uwaga |
|---|---|---|
| Logiczny | `TRUE`, `FALSE` | Można używać bezpośrednio w wyrażeniach logicznych, np. `A2=TRUE`. |
| Numeryczny | `1`, `0.5`, `.3`, `1E-2` | Obsługiwane są zapisy zwykłe i naukowe. |
| Tekstowy | `"abc"`, `"2/3/2020 12:00"` | Literały tekstowe są otoczone podwójnymi cudzysłowami wewnątrz formuły. |
| Wynik błędu | `#DIV/0!`, `#N/A`, `#REF!` | Prawidłowa formuła może zwrócić wartość błędu arkusza zamiast normalnego wyniku. |

Ten przykład używa kilku typów stałych:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Fałsz
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Operatory arytmetyczne**

| Operator | Znaczenie | Przykład |
|---|---|---|
| `+` | Dodawanie lub znak plus jednokrotny | `2+3` |
| `-` | Odejmowanie lub negacja | `2-3`, `-3` |
| `*` | Mnożenie | `2*3` |
| `/` | Dzielenie | `2/3` |
| `%` | Procent | `30%` |
| `^` | Potęgowanie | `2^3` |

Używaj nawiasów, aby wyraźnie określić kolejność obliczeń, np. `(A2+B2)*C2`.

### **Operatory porównania**

Wyrażenia porównawcze zwracają wartości logiczne.

| Operator | Znaczenie | Przykład |
|---|---|---|
| `=` | Równe | `A2=3` |
| `<>` | Nie równe | `A2<>3` |
| `>` | Większe niż | `A2>3` |
| `>=` | Większe lub równe | `A2>=3` |
| `<` | Mniejsze niż | `A2<3` |
| `<=` | Mniejsze lub równe | `A2<=3` |

## **Obsługiwane funkcje wbudowane**

Aspose.Slides zawiera wbudowany evaluator formuł dla arkuszy wykresów, ale nie jest to pełny silnik kalkulacji Excel. Dokumentowany zestaw funkcji jest ograniczony do poniższych funkcji. Nie zakładaj, że dowolna funkcja Excel zostanie przeliczona przez [calculate_formulas](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Funkcja | Cel lub obsługiwana forma | Przykład |
|---|---|---|
| `ABS` | Wartość bezwzględna | `ABS(A2)` |
| `AVERAGE` | Średnia arytmetyczna | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrąglenie liczby w górę do wielokrotności | `CEILING(A2,5)` |
| `CHOOSE` | Wybór wartości według indeksu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Łączenie wartości tekstowych | `CONCAT(A2,B2)` |
| `CONCATENATE` | Łączenie wartości tekstowych | `CONCATENATE(A2," ",B2)` |
| `DATE` | Utworzenie wartości daty przy użyciu systemu dat 1900 | `DATE(2026,8,19)` |
| `DAYS` | Zwrócenie liczby dni między datami | `DAYS(B2,A2)` |
| `FIND` | Znajdowanie jednej wartości tekstowej w drugiej | `FIND("-",A2)` |
| `FINDB` | Wyszukiwanie tekstu orientowane na bajty | `FINDB("a",A2)` |
| `IF` | Wynik warunkowy | `IF(A2>0,A2,0)` |
| `INDEX` | Forma odwołania | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma wektorowa | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma wektorowa | `MATCH(A2,B2:B5,0)` |
| `MAX` | Wartość maksymalna | `MAX(B2:B5)` |
| `SUM` | Sumowanie wartości | `SUM(B2:B5)` |
| `VLOOKUP` | Wyszukiwanie pionowe | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ograniczenia w tabeli są istotne: `INDEX` jest udokumentowany w formie odwołania, podczas gdy `LOOKUP` i `MATCH` w formie wektorowej. `DATE` używa systemu dat 1900. Funkcje i cechy nie wymienione tutaj powinny być traktowane jako nieobsługiwane przez evaluator formuł Aspose.Slides, chyba że są udokumentowane osobno.

## **Przeliczanie i wartości buforowane**

Pliki arkuszy zwykle przechowują zarówno formułę, jak i jej ostatnio obliczoną wartość. Aspose.Slides może więc odczytać wartość buforowaną z [IChartDataCell.value](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/value/) podczas ładowania prezentacji, o ile odpowiednie dane wykresu nie zostały zmienione.

Po zmianie komórek wejściowych lub formuł nie polegaj na starej buforowanej wartości. Wywołaj [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) przed odczytem obliczonych wartości lub zapisem danych wykresu, które od nich zależą.

Dla formuł spoza obsługiwanego podzbioru Aspose.Slides może nie być w stanie sparsować formuły ani ustalić jej zależności. Jeśli skoroszyt został zmodyfikowany, poprzednia buforowana wartość nie jest już wiarygodna. W takiej sytuacji odczyt wartości komórki z nieobsługiwanymi danymi może podnieść [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Jeśli twój wykres zależy od funkcji Excel, których Aspose.Slides nie ocenia, oblicz te formuły przy użyciu silnika arkusza, który je obsługuje, i zapisz otrzymane wyniki z powrotem do skoroszytu wykresu. Nie zastępuj nieobsługiwanych formuł zgadywanymi wartościami.

## **Obsługa błędów formuł**

Istnieją dwa różne rodzaje problemów do rozróżnienia.

Formuła może być prawidłowa, ale zwrócić wynik błędu arkusza, taki jak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` lub `#VALUE!`. W takim wypadku token błędu jest wynikiem komórki i może być zwrócony przez `value`.

Formuła może także nie powieść się na etapie parsowania, odwołania, zależności lub obsługi danych. Aspose.Slides udostępnia specyficzne dla arkusza wyjątki: [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), oraz [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Gdy formuły pochodzą z szablonów lub wejścia użytkownika, obsłuż te wyjątki wokół przeliczania i dostępu do wartości:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Praktyczne ograniczenia**

Obsługa formuł w arkuszach wykresów jest przeznaczona dla określonego podzbioru obliczeń arkusza, a nie dla pełnej kompatybilności z Excel. Pamiętaj o tych ograniczeniach przy projektowaniu przepływu raportowania:

- Używaj wyłącznie dokumentowanych stałych, operatorów, odwołań i funkcji, gdy potrzebujesz, aby Aspose.Slides przeliczało formuły.
- Przeliczaj po zmianie komórek, od których zależą wyniki formuł.
- Traktuj wartości buforowane z załadowanych prezentacji jako migawki, a nie jako zamiennik przeliczenia po edycjach.
- Testuj formuły z istniejących szablonów przed poleganiem na ich obliczonych wartościach, szczególnie gdy używają funkcji spoza udokumentowanej listy.
- Dla formuł wymagających pełnego silnika kalkulacji arkusza, przelicz je zewnętrznie, a następnie zaktualizuj skoroszyt wykresu otrzymanymi wartościami.

## **FAQ**

**Jaka jest różnica między `formula` a `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/formula/) przechowuje wyrażenie w stylu A1, np. `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) przechowuje wyrażenie w stylu R1C1, np. `RC[-2]-RC[-1]`. Użyj notacji, która najlepiej pasuje do sposobu generowania lub kopiowania formuł.

**Czy muszę odczytać samą komórkę czy jej wartość po przeliczeniu?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) zwraca `IChartDataCell`. Aby uzyskać obliczony wynik, odczytaj właściwość [value](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/value/) tej komórki po przeliczeniu.

**Kiedy powinienem wywołać `calculate_formulas`?**

Wywołaj [calculate_formulas](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) po zmianie wartości wejściowych lub formuł i przed użyciem obliczonych wyników. Aktualizuje to wartości formuł obsługiwanych przez wbudowany evaluator.

**Czy Aspose.Slides obsługuje każdą funkcję Excel?**

Nie. Wbudowany evaluator obsługuje udokumentowany podzbiór funkcji. Funkcje spoza tego podzbioru nie powinny być traktowane jako poprawnie przeliczane. Jeśli wymagana jest pełna kompatybilność z formułami Excel, wykonaj obliczenia w odpowiednim silniku arkusza i zapisz ostateczne wartości do skoroszytu wykresu.

**Co się stanie, jeśli załadowana prezentacja zawiera nieobsługiwaną formułę?**

Jeśli dane wykresu nie zostały zmienione, skoroszyt może nadal zawierać wcześniej obliczoną wartość buforowaną. Po modyfikacji powiązanych danych ta buforowana wartość może nie być już ważna. Dostęp do komórki, której formuła nie może być obsłużona, może podnieść [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Czy wartości błędów formuły są tym samym co wyjątki Pythona?**

Nie. Wynik taki jak `#DIV/0!` jest wartością arkusza uzyskaną w wyniku prawidłowego obliczenia. Wyjątki takie jak [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) czy [CellCircularReferenceException](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) wskazują, że formuła nie może być normalnie przetworzona.

**Czy wykres aktualizuje się automatycznie po zmianie komórki z formułą?**

Seria wykresu może odwoływać się do komórek skoroszytu. Najpierw przelicz skoroszyt, a potem zapisz lub wyrenderuj prezentację. Jeśli punkty danych wykresu odwołują się do obliczonych komórek, wykres użyje zaktualizowanych wartości; nie jest wymagane oddzielne wywołanie odświeżania wykresu w tym przebiegu.

**Czy wykresy mogą używać zewnętrznego skoroszytu Excel?**

Tak, dane wykresu można skonfigurować tak, aby używały zewnętrznego skoroszytu za pośrednictwem API danych wykresu. Jednak opisany w tym artykule przepływ przeliczania formuł dotyczy skoroszytu danych wykresu i podzbioru formuł ocenianych przez Aspose.Slides. Nie zakładaj, że [calculate_formulas](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) zapewnia pełne przeliczenie dowolnych formuł w zewnętrznym pliku XLSX.

**Czy mogę używać formuł odwołujących się do innego arkusza lub skoroszytu?**

Odwołania w stylu Excel mogą występować w skoroszytach wykresów, ale ocena formuł jest ograniczona przez obsługiwany parser i zestaw funkcji. Jeśli odwołanie międzyarkuszowe lub zewnętrzne jest niezbędne, zweryfikuj dokładną formułę w wersji Aspose.Slides, której używasz. Dla przepływów wymagających szerokiej kompatybilności odwołań Excel, przelicz skoroszyt zewnętrznie i zapisz rozwiązane wartości z powrotem do danych wykresu.

**Czy ciągi formuł powinny zaczynać się od `=`?**

Przykłady API Aspose.Slides przypisują wyrażenia takie jak `B2-C2` lub `SUM(B2:B5)` bez wiodącego `=`. Użycie tej formy utrzymuje generowane formuły zgodne z udokumentowanymi przykładami API.