---
title: Stosowanie formuł arkusza wykresu w prezentacjach w .NET
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/net/chart-worksheet-formulas/
keywords:
- arkusz kalkulacyjny wykresu
- arkusz wykresu
- formuła wykresu
- formuła arkusza
- formuła arkusza kalkulacyjnego
- skoroszyt danych wykresu
- obliczanie formuły
- stała logiczna
- stała liczbowa
- stała łańcuchowa
- stała błędu
- operator arytmetyczny
- operator porównania
- styl A1
- styl R1C1
- funkcja wbudowana
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Stosuj formuły w stylu Excel w arkuszach wykresów Aspose.Slides dla .NET, przeliczaj wartości i używaj wyników w wykresach PowerPoint."
---
## **Przegląd**

Wykresy PowerPoint zazwyczaj przechowują dane źródłowe w osadzonym arkuszu kalkulacyjnym. W Aspose.Slides for .NET można uzyskać dostęp do tego arkusza przez skoroszyt danych wykresu, zapisywać wartości wejściowe, przypisywać formuły do komórek, obliczać obsługiwane formuły i wykorzystywać obliczone komórki jako dane wykresu.

Ten artykuł opisuje pełny przepływ pracy z formułami: tworzenie wykresu, wypełnianie jego arkusza, przypisywanie formuł w stylu A1 lub R1C1, ponowne ich obliczanie, odczyt obliczonych wartości, podłączanie tych komórek do serii wykresu i zapisywanie prezentacji. Opisuje także obsługiwaną składnię formuł, wbudowany podzbiór funkcji, wartości buforowane, nieobsługiwane formuły oraz błędy specyficzne dla arkuszy kalkulacyjnych.

## **Arkusze wykresów i formuły**

Arkusz wykresu zawiera kategorie, nazwy serii i wartości używane przez wykres. W PowerPoint można przeglądać arkusz, otwierając edytor danych wykresu:

![Wykres PowerPoint z otwartym osadzonym arkuszem, pokazujący dane kategorii i serii](chart-worksheet-formulas_1.png)

W Aspose.Slides arkusz jest udostępniany przez [chart data workbook](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/). Do formuł w stylu A1 służy właściwość [Formula](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/formula/), a do formuł w stylu R1C1 właściwość [R1C1Formula](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/r1c1formula/). Po zmianie komórek wejściowych lub formuł wywołaj [CalculateFormulas](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/), aby przeliczyć obsługiwane formuły i zaktualizować odpowiadające wartości komórek.

Obliczona komórka nadal udostępnia swój wynik przez właściwość [Value](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/value/). Jest to ważne, gdy trzeba sprawdzić wynik formuły w kodzie lub użyć komórki jako punktu danych wykresu.

## **Tworzenie wykresu i obliczanie formuł w arkuszu**

Poniższy przykład ilustruje kompletny przepływ pracy. Tworzy wykres słupkowy grupowany, czyści przykładowe dane, zapisuje kwartalne przychody i koszty, oblicza zysk przy użyciu formuł, odczytuje wyniki, używa obliczonych komórek jako wartości wykresu i zapisuje prezentację.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Punkty danych wykresu odwołują się do `D2:D4`, więc wykres korzysta z obliczonych wartości zysku. Nie ma osobnego wywołania odświeżenia wykresu w tym przepływie: najpierw przelicz skoroszyt, a potem użyj lub zapisz dane wykresu wskazujące na obliczone komórki.

## **Używanie formuł w stylu A1**

Notacja A1 identyfikuje kolumny literami, a wiersze liczbami. Przypisuj wyrażenia w stylu A1 przez [IChartDataCell.Formula](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Typowe formy odwołań A1:

| Odwołanie | Względne | Bezpośrednie | Mieszane |
|---|---|---|---|
| Komórka | `A2` | `$A$2` | `A$2`, `$A2` |
| Wiersz | `2:2` | `$2:$2` | — |
| Kolumna | `A:A` | `$A:$A` | — |
| Zakres | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Odwołania względne mogą się zmieniać, gdy formuła zostanie przeniesiona lub skopiowana w arkuszu. Odwołania bezpośrednie utrzymują oba współrzędne stałe, a odwołania mieszane blokują tylko wiersz lub kolumnę.

## **Używanie formuł w stylu R1C1**

Notacja R1C1 identyfikuje zarówno wiersze, jak i kolumny liczbowo. Odwołania względne używają przesunięć w nawiasach kwadratowych. Przypisuj tę składnię przez [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Typowe formy odwołań R1C1:

| Odwołanie | Względne | Bezpośrednie | Mieszane |
|---|---|---|---|
| Komórka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Wiersz | `R[2]` | `R2` | — |
| Kolumna | `C[3]` | `C3` | — |
| Zakres | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Na przykład w komórce `D2` zapis `RC[-2]` oznacza komórkę w tym samym wierszu, dwie kolumny w lewo (`B2`).

## **Stałe i operatory formuł**

Wbudowany interpreter formuł obsługuje wartości logiczne, literały liczbowe, ciągi znaków, wartości błędów arkusza, operatory arytmetyczne i operatory porównania.

### **Stałe i literały**

| Typ | Przykłady | Uwagi |
|---|---|---|
| Logiczne | `TRUE`, `FALSE` | Można używać bezpośrednio w wyrażeniach logicznych, np. `A2=TRUE`. |
| Liczbowe | `1`, `0.5`, `.3`, `1E-2` | Obsługiwane są notacje dziesiętna i naukowa. |
| Ciąg znaków | `"abc"`, `"2/3/2020 12:00"` | Literały tekstowe są umieszczane w podwójnych cudzysłowach wewnątrz formuły. |
| Wynik błędu | `#DIV/0!`, `#N/A`, `#REF!` | Prawidłowa formuła może zwrócić wartość błędu arkusza zamiast wyniku. |

Ten przykład używa kilku typów stałych:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Fałsz
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
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

## **Obsługiwane funkcje wbudowane**

Aspose.Slides zawiera wbudowany interpreter formuł dla arkuszy wykresów, ale nie jest to pełny silnik obliczeniowy Excel. Dokumentowany zestaw funkcji jest ograniczony do poniższych funkcji. Nie zakładaj, że dowolna funkcja Excel zostanie przeliczona przez [CalculateFormulas](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Funkcja | Cel lub obsługiwana forma | Przykład |
|---|---|---|
| `ABS` | Wartość bezwzględna | `ABS(A2)` |
| `AVERAGE` | Średnia arytmetyczna | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrąglenie w górę do wielokrotności | `CEILING(A2,5)` |
| `CHOOSE` | Wybór wartości po indeksie | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Łączenie tekstów | `CONCAT(A2,B2)` |
| `CONCATENATE` | Łączenie tekstów | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tworzenie daty w systemie 1900 | `DATE(2026,8,19)` |
| `DAYS` | Liczba dni między datami | `DAYS(B2,A2)` |
| `FIND` | Znajdź tekst w innym tekście | `FIND("-",A2)` |
| `FINDB` | Wyszukiwanie bajtowe | `FINDB("a",A2)` |
| `IF` | Wynik warunkowy | `IF(A2>0,A2,0)` |
| `INDEX` | Forma odwołania | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma wektorowa | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma wektorowa | `MATCH(A2,B2:B5,0)` |
| `MAX` | Wartość maksymalna | `MAX(B2:B5)` |
| `SUM` | Suma | `SUM(B2:B5)` |
| `VLOOKUP` | Wyszukiwanie pionowe | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ograniczenia przedstawione w tabeli są istotne: `INDEX` jest udokumentowany w formie odwołania, natomiast `LOOKUP` i `MATCH` w formie wektorowej. `DATE` używa systemu daty 1900. Funkcje i cechy nie wymienione w tej liście należy traktować jako nieobsługiwane przez interpreter formuł Aspose.Slides, chyba że są udokumentowane oddzielnie.

## **Przeliczanie i wartości buforowane**

Pliki arkuszy zazwyczaj przechowują zarówno formułę, jak i jej ostatnio obliczoną wartość. Aspose.Slides może więc odczytać wartość buforowaną z [IChartDataCell.Value](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/value/) podczas ładowania prezentacji, o ile odpowiednie dane wykresu nie zostały zmienione.

Po zmianie komórek wejściowych lub formuł nie polegaj na starej buforowanej wartości. Wywołaj [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) przed odczytem obliczonych wartości lub przed zapisem danych wykresu zależnych od nich.

Dla formuł spoza obsługiwanego podzbioru Aspose.Slides może nie być w stanie ich sparsować lub ustalić zależności. Jeśli skoroszyt został zmodyfikowany, poprzednia buforowana wartość nie jest już wiarygodna. W takiej sytuacji odczyt wartości komórki z nieobsługiwanymi danymi może spowodować wyrzucenie [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Jeśli Twój wykres zależy od funkcji Excel, które Aspose.Slides nie ocenia, oblicz te formuły przy użyciu silnika arkuszy, który je obsługuje, i zapisz uzyskane wyniki z powrotem do skoroszytu wykresu. Nie zastępuj nieobsługiwanych formuł wartościami domyślnymi.

## **Obsługa błędów formuł**

Istnieją dwa różne rodzaje problemów.

Formuła może być prawidłowa, ale zwrócić wynik błędu arkusza, taki jak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` lub `#VALUE!`. W takim wypadku token błędu jest wynikiem komórki i może być zwrócony przez `Value`.

Formuła może także nie powieść się na etapie parsowania, odwołania, zależności lub obsługiwanych danych. Aspose.Slides udostępnia specyficzne dla arkuszy wyjątki: [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pl/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pl/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) i [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Gdy formuły pochodzą z szablonów lub wprowadzane są przez użytkownika, obsłuż te wyjątki wokół przeliczania i dostępu do wartości:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Praktyczne ograniczenia**

Obsługa formuł w arkuszach wykresów jest przeznaczona dla określonego podzbioru obliczeń arkuszowych, a nie dla pełnej kompatybilności z Excelem. Pamiętaj o tych ograniczeniach przy projektowaniu przepływu raportowania:

- Używaj wyłącznie dokumentowanych stałych, operatorów, odwołań i funkcji, gdy potrzebujesz, aby Aspose.Slides przeliczało formuły.
- Przeliczaj po zmianie komórek, od których zależą wyniki formuł.
- Traktuj wartości buforowane z załadowanych prezentacji jako migawki, a nie jako zamiennik przeliczenia po edycji.
- Testuj formuły z istniejących szablonów przed poleganiem na ich obliczonych wartościach, szczególnie gdy używają funkcji spoza udokumentowanej listy.
- Dla formuł wymagających pełnego silnika kalkulacyjnego, oblicz je zewnętrznie, a następnie zaktualizuj skoroszyt wykresu otrzymanymi wartościami.

## **FAQ**

**Jaka jest różnica między `Formula` a `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/formula/) przechowuje wyrażenie w stylu A1, np. `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/r1c1formula/) przechowuje wyrażenie w stylu R1C1, np. `RC[-2]-RC[-1]`. Użyj notacji, która najlepiej odpowiada sposobowi generowania lub kopiowania formuł.

**Czy po przeliczeniu powinienem odczytać samą komórkę czy jej wartość?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/getcell/) zwraca `IChartDataCell`. Aby uzyskać obliczony wynik, odczytaj właściwość [Value](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/value/) tej komórki po przeliczeniu.

**Kiedy wywołać `CalculateFormulas`?**

Wywołaj [CalculateFormulas](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) po zmianie wartości wejściowych lub formuł i przed użyciem obliczonych wyników. Aktualizuje to wartości formuł obsługiwanych przez wbudowany interpreter.

**Czy Aspose.Slides obsługuje każdą funkcję Excela?**

Nie. Wbudowany interpreter obsługuje udokumentowany podzbiór funkcji. Funkcje spoza tego podzbioru nie powinny być traktowane jako poprawnie przeliczalne. Jeśli wymagana jest pełna kompatybilność z formułami Excela, wykonaj obliczenia przy użyciu odpowiedniego silnika arkuszy i zapisz ostateczne wartości do skoroszytu wykresu.

**Co się stanie, jeśli załadowana prezentacja zawiera nieobsługiwaną formułę?**

Jeśli dane wykresu nie zmieniły się, skoroszyt może nadal zawierać wcześniej obliczoną wartość buforowaną. Po modyfikacji powiązanych danych ta buforowana wartość może stać się nieważna. Dostęp do komórki, której formuła nie może być obsłużona, może wywołać [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Czy wartości błędów formuły są takie same jak wyjątki .NET?**

Nie. Wynik taki jak `#DIV/0!` jest wartością arkusza uzyskaną w wyniku prawidłowego obliczenia. Wyjątki, takie jak [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) lub [CellCircularReferenceException](https://reference.aspose.com/slides/pl/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), wskazują, że formuła nie może być przetworzona w normalny sposób.

**Czy wykres aktualizuje się automatycznie po zmianie komórki z formułą?**

Seria wykresu może odwoływać się do komórek skoroszytu. Najpierw przelicz skoroszyt, a potem zapisz lub wyrenderuj prezentację. Jeśli punkty danych wykresu odwołują się do obliczonych komórek, wykres użyje zaktualizowanych wartości; nie jest wymagane osobne wywołanie odświeżania wykresu w tym przepływie.

**Czy wykresy mogą korzystać z zewnętrznego skoroszytu Excel?**

Tak, dane wykresu można skonfigurować tak, aby używały zewnętrznego skoroszytu poprzez API danych wykresu. Jednak opisany w tym artykule przepływ obliczania formuł dotyczy skoroszytu danych wykresu i podzbioru formuł ocenianych przez Aspose.Slides. Nie zakładaj, że [CalculateFormulas](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) zapewnia pełne przeliczenie dowolnych formuł w zewnętrznym pliku XLSX.

**Czy mogę używać formuł odwołujących się do innego arkusza lub skoroszytu?**

Odwołania w stylu Excel mogą występować w skoroszytach wykresów, ale ocena formuł jest ograniczona przez obsługiwany parser i zestaw funkcji. Jeśli odwołanie międzyarkuszowe lub zewnętrzne jest kluczowe, sprawdź dokładną formułę w wersji Aspose.Slides, której używasz. Dla przepływów wymagających szerokiej kompatybilności odwołań Excel, oblicz skoroszyt zewnętrznie i zapisz rozwiązane wartości z powrotem do danych wykresu.

**Czy łańcuchy formuł powinny zaczynać się od `=`?**

Przykłady API Aspose.Slides przypisują wyrażenia takie jak `B2-C2` lub `SUM(B2:B5)` bez początkowego `=`. Stosowanie tej formy utrzymuje generowane formuły zgodne z udokumentowanymi przykładami API.