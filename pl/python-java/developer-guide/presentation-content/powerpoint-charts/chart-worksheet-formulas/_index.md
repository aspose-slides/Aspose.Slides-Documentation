---
title: Zastosowanie formuł arkusza wykresu w prezentacjach w Pythonie via Java
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/python-java/chart-worksheet-formulas/
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
- stała numeryczna
- stała tekstowa
- stała błędu
- operator arytmetyczny
- operator porównania
- styl A1
- styl R1C1
- funkcja predefiniowana
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w arkuszach wykresów Aspose.Slides dla Pythona via Java, przelicz wartości i użyj wyników w wykresach PowerPoint."
---
## **Przegląd**

Wykresy PowerPoint zazwyczaj przechowują dane źródłowe w osadzonym arkuszu. W Aspose.Slides for Python via Java możesz uzyskać dostęp do tego arkusza przez skoroszyt danych wykresu, zapisywać wartości wejściowe, przypisywać formuły do komórek, obliczać obsługiwane formuły i używać obliczonych komórek jako danych wykresu.

Ten artykuł opisuje kompletny przepływ pracy z formułami: tworzenie wykresu, wypełnianie jego arkusza, przypisywanie formuł w stylu A1 lub R1C1, ponowne ich obliczanie, odczytywanie obliczonych wartości, podłączanie tych komórek do serii wykresu i zapisywanie prezentacji. Opisuje także obsługiwaną składnię formuł, podzbiór wbudowanych funkcji, wartości buforowane, nieobsługiwane formuły oraz błędy specyficzne dla arkuszy.

## **Arkusze wykresów i formuły**

Arkusz wykresu zawiera kategorie, nazwy serii i wartości używane przez wykres. W PowerPoint możesz przejrzeć arkusz, otwierając edytor danych wykresu:

![Wykres PowerPoint z otwartym osadzonym arkuszem, pokazujący dane kategorii i serii](chart-worksheet-formulas_1.png)

W Aspose.Slides arkusz jest udostępniany przez klasę [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/). Użyj [ChartDataCell.setFormula](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#setFormula) dla formuł w stylu A1 oraz [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#setR1C1Formula) dla formuł w stylu R1C1. Po zmianie komórek wejściowych lub formuł wywołaj [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas), aby ponownie obliczyć obsługiwane formuły i zaktualizować odpowiadające wartości komórek.

Obliczona komórka nadal udostępnia swój wynik za pośrednictwem [ChartDataCell.getValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#getValue). Jest to ważne, gdy musisz sprawdzić wynik formuły w kodzie lub użyć komórki jako punktu danych wykresu.

## **Utworzenie wykresu i obliczenie formuł w arkuszu**

Poniższy przykład demonstruje kompletny przepływ pracy. Tworzy wykres kolumnowy grupowany, czyści przykładowe dane, zapisuje kwartalne przychody i koszty, oblicza zysk przy użyciu formuł, odczytuje wyniki, wykorzystuje obliczone komórki jako wartości wykresu i zapisuje prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Punkty danych wykresu odwołują się do `D2:D4`, więc wykres używa obliczonych wartości zysku. W tym przepływie nie ma osobnego wywołania odświeżania wykresu: najpierw przelicz skoroszyt, a potem użyj lub zapisz dane wykresu wskazujące na obliczone komórki.

## **Użycie formuł w stylu A1**

Notacja A1 identyfikuje kolumny literami, a wiersze liczbami. Przypisuj wyrażenia w stylu A1 za pomocą [ChartDataCell.setFormula](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#setFormula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Typowe formy odwołań A1:

| Odwołanie | Względne | Bezwzględne | Mieszane |
|---|---|---|---|
| Komórka | `A2` | `$A$2` | `A$2`, `$A2` |
| Wiersz | `2:2` | `$2:$2` | — |
| Kolumna | `A:A` | `$A:$A` | — |
| Zakres | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Odwołania względne mogą się zmieniać, gdy formuła jest przenoszona lub kopiowana w aplikacji arkusza. Odwołania bezwzględne utrzymują oba współrzędne stałe, natomiast odwołania mieszane zamrażają tylko wiersz lub kolumnę.

## **Użycie formuł w stylu R1C1**

Notacja R1C1 identyfikuje zarówno wiersze, jak i kolumny liczbami. Odwołania względne używają przesunięć w nawiasach kwadratowych. Przypisuj tę składnię za pomocą [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

Typowe formy odwołań R1C1:

| Odwołanie | Względne | Bezwzględne | Mieszane |
|---|---|---|---|
| Komórka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Wiersz | `R[2]` | `R2` | — |
| Kolumna | `C[3]` | `C3` | — |
| Zakres | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Na przykład w komórce `D2`, `RC[-2]` oznacza komórkę w tym samym wierszu, dwie kolumny w lewo (`B2`).

## **Stałe i operatory w formułach**

Wbudowany evaluator formuł obsługuje wartości logiczne, literały liczbowe, łańcuchy tekstowe, wartości błędów arkusza, operatory arytmetyczne i operatory porównania.

### **Stałe i literały**

| Typ | Przykłady | Uwagi |
|---|---|---|
| Logiczny | `TRUE`, `FALSE` | Można używać bezpośrednio w wyrażeniach logicznych, np. `A2=TRUE`. |
| Liczbowy | `1`, `0.5`, `.3`, `1E-2` | Obsługiwane są zapisy dziesiętne i naukowe. |
| Tekstowy | `"abc"`, `"2/3/2020 12:00"` | Literały tekstowe są ujęte w podwójnych cudzysłowach wewnątrz formuły. |
| Wynik błędu | `#DIV/0!`, `#N/A`, `#REF!` | Prawidłowa formuła może zwrócić wartość błędu arkusza zamiast wyniku. |

Ten przykład używa kilku rodzajów stałych:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # Fałsz
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Operatory arytmetyczne**

| Operator | Znaczenie | Przykład |
|---|---|---|
| `+` | Dodawanie lub znak plus jedynkowy | `2+3` |
| `-` | Odejmowanie lub negacja | `2-3`, `-3` |
| `*` | Mnożenie | `2*3` |
| `/` | Dzielenie | `2/3` |
| `%` | Procent | `30%` |
| `^` | Potęgowanie | `2^3` |

Używaj nawiasów, aby explicite określić kolejność obliczeń, np. `(A2+B2)*C2`.

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

## **Obsługiwane funkcje wbudowane**

Aspose.Slides zawiera wbudowany evaluator formuł dla arkuszy wykresów, ale nie jest pełnym silnikiem obliczeniowym Excel. Dokumentowany zestaw funkcji jest ograniczony do poniższych pozycji. Nie zakładaj, że dowolna funkcja Excel zostanie przeliczona przez [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Funkcja | Cel lub obsługiwana forma | Przykład |
|---|---|---|
| `ABS` | Wartość bezwzględna | `ABS(A2)` |
| `AVERAGE` | Średnia arytmetyczna | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrąglenie liczby w górę do wielokrotności | `CEILING(A2,5)` |
| `CHOOSE` | Wybór wartości po indeksie | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Łączenie wartości tekstowych | `CONCAT(A2,B2)` |
| `CONCATENATE` | Łączenie wartości tekstowych | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tworzy wartość daty w systemie dat 1900 | `DATE(2026,8,19)` |
| `DAYS` | Zwraca liczbę dni pomiędzy datami | `DAYS(B2,A2)` |
| `FIND` | Znajduje jeden tekst w drugim | `FIND("-",A2)` |
| `FINDB` | Wyszukiwanie tekstu bajtowo | `FINDB("a",A2)` |
| `IF` | Wynik warunkowy | `IF(A2>0,A2,0)` |
| `INDEX` | Forma odwołania | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma wektorowa | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma wektorowa | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maksymalna wartość | `MAX(B2:B5)` |
| `SUM` | Suma wartości | `SUM(B2:B5)` |
| `VLOOKUP` | Wyszukiwanie wertykalne | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ograniczenia przedstawione w tabeli są istotne: `INDEX` jest udokumentowany w formie odwołania, natomiast `LOOKUP` i `MATCH` w formach wektorowych. `DATE` używa systemu dat 1900. Funkcje i cechy nie wymienione tutaj powinny być traktowane jako nieobsługiwane przez evaluator formuł Aspose.Slides, chyba że są osobno udokumentowane.

## **Obliczanie formuł z preferowaną kulturą**

Niektóre funkcje skoroszytu interpretują tekst zgodnie z regułami kulturowymi. Jest to szczególnie ważne dla funkcji przeznaczonych dla języków używających zestawów znaków podwójnego bajtu (DBCS). Aby prawidłowo obliczyć takie formuły, utwórz [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/), ustaw preferowaną kulturę za pomocą [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), przypisz opcje arkusza przez [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), a następnie załaduj prezentację.

Poniższy przykład wybiera kulturę japońską, otwiera prezentację z skonfigurowanymi opcjami ładowania i wywołuje [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) dla każdego skoroszytu wykresu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

Preferowana kultura jest częścią konfiguracji ładowania prezentacji, więc ustaw ją przed utworzeniem instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Użyj kultury oczekiwanej przez formuły skoroszytu; na przykład `ja-JP` dla formuł, które mają stosować japońskie reguły DBCS.

## **Przeliczanie i wartości buforowane**

Pliki arkuszy zazwyczaj przechowują zarówno formułę, jak i jej ostatnio obliczoną wartość. Aspose.Slides może więc odczytać wartość buforowaną z [ChartDataCell.getValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#getValue), gdy prezentacja jest załadowana i odpowiednie dane wykresu nie zostały zmienione.

Po zmianie komórek wejściowych lub formuł nie polegaj na starej wartości buforowanej. Wywołaj [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) przed odczytem obliczonych wartości lub przed zapisem danych wykresu, od których zależą.

Dla formuł spoza obsługiwanego podzbioru Aspose.Slides może nie być w stanie parsować formuły ani ustalić jej zależności. Jeśli skoroszyt został zmodyfikowany, poprzednia wartość buforowana nie może być już uznana za wiarygodną. W takiej sytuacji odczyt wartości komórki z nieobsługiwanymi danymi może spowodować zgłoszenie [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellunsupporteddataexception/).

Jeśli twój wykres zależy od funkcji Excel, które Aspose.Slides nie ocenia, oblicz te formuły przy użyciu silnika arkusza obsługującego je i zapisz otrzymane wartości z powrotem do skoroszytu wykresu. Nie zastępuj nieobsługiwanych formuł domysłonymi wartościami.

## **Obsługa błędów formuł**

Należy rozróżnić dwa różne rodzaje problemów.

Formuła może być prawidłowa, ale zwracać wynik błędu arkusza, taki jak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` lub `#VALUE!`. W tym przypadku token błędu jest wynikiem komórki i może być zwrócony przez [ChartDataCell.getValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#getValue).

Formuła może także nie powieść się na etapie parsowania, odwołania, zależności lub obsługi danych. Aspose.Slides udostępnia specyficzne dla arkuszy wyjątki: [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellcircularreferenceexception/) oraz [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellunsupporteddataexception/).

Gdy formuły pochodzą z szablonów lub danych wprowadzonych przez użytkownika, obsłuż te wyjątki wokół przeliczania i dostępu do wartości:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Praktyczne ograniczenia**

Obsługa formuł w arkuszach wykresów jest przeznaczona dla określonego podzbioru obliczeń arkusza, a nie dla pełnej kompatybilności z Excelem. Pamiętaj o tych ograniczeniach przy projektowaniu przepływu raportowania:

- Używaj wyłącznie udokumentowanych stałych, operatorów, odwołań i funkcji, gdy potrzebujesz, aby Aspose.Slides przeliczało formuły.
- Przeliczaj po zmianie komórek, od których zależą wyniki formuł.
- Traktuj wartości buforowane z załadowanych prezentacji jako migawki, a nie jako zamiennik przeliczania po edycjach.
- Testuj formuły z istniejących szablonów przed poleganiem na ich obliczonych wartościach, zwłaszcza gdy używają funkcji spoza udokumentowanej listy.
- Dla formuł wymagających pełnego silnika obliczeniowego arkusza, oblicz je zewnętrznie, a następnie zaktualizuj skoroszyt wykresu uzyskanymi wartościami.

## **FAQ**

**Jaka jest różnica między [ChartDataCell.setFormula](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#setFormula) a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#setFormula) przechowuje wyrażenie w stylu A1, takie jak `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#setR1C1Formula) przechowuje wyrażenie w stylu R1C1, takie jak `RC[-2]-RC[-1]`. Użyj notacji, która najlepiej pasuje do sposobu generowania lub kopiowania formuł.

**Czy muszę odczytać samą komórkę czy jej wartość po przeliczeniu?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#getCell) zwraca [ChartDataCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/). Aby uzyskać obliczony wynik, wywołaj metodę [ChartDataCell.getValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#getValue) na tej komórce po przeliczeniu.

**Kiedy powinienem wywołać [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Wywołaj [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) po zmianie wartości wejściowych lub formuł i przed tym, jak zależysz od obliczonych wyników. To aktualizuje wartości formuł obsługiwanych przez wbudowany evaluator.

**Czy Aspose.Slides obsługuje każdą funkcję Excela?**

Nie. Wbudowany evaluator obsługuje udokumentowany podzbiór funkcji. Funkcje spoza tego podzbioru nie powinny być uznawane za prawidłowo przeliczane. Jeśli wymagana jest pełna kompatybilność z formułami Excela, wykonaj obliczenia przy użyciu odpowiedniego silnika arkusza i zapisz ostateczne wartości do skoroszytu wykresu.

**Co się stanie, jeśli załadowana prezentacja zawiera nieobsługiwaną formułę?**

Jeśli dane wykresu nie zostały zmienione, skoroszyt może nadal zawierać wcześniej obliczoną wartość buforowaną. Po modyfikacji powiązanych danych ta buforowana wartość może już nie być ważna. Dostęp do komórki, której formuła nie może być obsłużona, może spowodować zgłoszenie [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellunsupporteddataexception/).

**Czy wartości błędów formuły są tym samym co wyjątki?**

Nie. Wynik taki jak `#DIV/0!` jest wartością arkusza wygenerowaną przez prawidłowe obliczenie. Wyjątki takie jak [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellinvalidformulaexception/) czy [CellCircularReferenceException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellcircularreferenceexception/) wskazują, że formuła nie może być przetworzona w normalny sposób.

**Czy wykres aktualizuje się automatycznie po zmianie komórki z formułą?**

Seria wykresu może odwoływać się do komórek skoroszytu. Najpierw przelicz skoroszyt, a potem zapisz lub wyrenderuj prezentację. Jeśli punkty danych wykresu odwołują się do obliczonych komórek, wykres użyje zaktualizowanych wartości; nie jest wymagane osobne wywołanie odświeżania wykresu w tym przepływie.

**Czy wykresy mogą używać zewnętrznego skoroszytu Excel?**

Tak, dane wykresu można skonfigurować tak, aby korzystały z zewnętrznego skoroszytu poprzez API danych wykresu. Jednak opisany w tym artykule przepływ obliczania formuł dotyczy skoroszytu danych wykresu i podzbioru formuł ocenianych przez Aspose.Slides. Nie zakładaj, że [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) zapewnia pełne przeliczenie dowolnych formuł w zewnętrznym pliku XLSX.

**Czy mogę używać formuł odwołujących się do innego arkusza lub skoroszytu?**

Odwołania w stylu Excel mogą występować w skoroszytach wykresów, ale ocena formuł jest ograniczona obsługiwanym parserem i zestawem funkcji. Jeśli odwołanie między arkuszami lub do zewnętrznego skoroszytu jest niezbędne, zweryfikuj dokładną formułę z wersją Aspose.Slides, której używasz. Dla przepływów wymagających szerokiej kompatybilności odwołań Excel, oblicz skoroszyt zewnętrznie i zapisz rozwiązane wartości do danych wykresu.

**Czy ciągi formuł powinny zaczynać się od `=`?**

Przykłady w API Aspose.Slides przypisują wyrażenia takie jak `B2-C2` lub `SUM(B2:B5)` bez wiodącego znaku `=`. Użycie tej formy utrzymuje generowane formuły zgodne z udokumentowanymi przykładami API.