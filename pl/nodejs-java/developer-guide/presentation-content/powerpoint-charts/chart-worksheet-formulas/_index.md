---
title: Zastosuj formuły arkusza wykresu w prezentacjach przy użyciu JavaScript
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/nodejs-java/chart-worksheet-formulas/
keywords:
- arkusz wykresu
- arkusz wykresu
- formuła wykresu
- formuła arkusza
- formuła arkusza kalkulacyjnego
- skoroszyt danych wykresu
- obliczanie formuły
- stała logiczna
- stała liczbowa
- stała tekstowa
- stała błędu
- operator arytmetyczny
- operator porównania
- styl A1
- styl R1C1
- funkcja wstępnie zdefiniowana
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w Aspose.Slides dla Node.js poprzez arkusze wykresów w Javie, przelicz wartości i użyj wyników w wykresach PowerPoint."
---
## **Przegląd**

Wykresy PowerPoint zazwyczaj przechowują swoje dane źródłowe w osadzonej arkuszu kalkulacyjnym. W Aspose.Slides dla Node.js poprzez Java możesz uzyskać dostęp do tego arkusza za pośrednictwem skoroszytu danych wykresu, zapisywać wartości wejściowe, przypisywać formuły do komórek, obliczać obsługiwane formuły i używać obliczonych komórek jako danych wykresu.

Ten artykuł opisuje kompletny przepływ pracy z formułami: tworzenie wykresu, wypełnianie jego arkusza, przypisywanie formuł w stylu A1 lub R1C1, przeliczanie ich, odczytywanie obliczonych wartości, łączenie tych komórek z serią wykresu oraz zapisywanie prezentacji. Zawiera również opis obsługiwanej składni formuł, wbudowanego podzbioru funkcji, wartości buforowanych, nieobsługiwanych formuł oraz błędów specyficznych dla arkuszy kalkulacyjnych.

## **Arkusze wykresów i formuły**

Arkusz wykresu zawiera kategorie, nazwy serii i wartości używane w wykresie. W PowerPoint możesz przeglądać arkusz, otwierając edytor danych wykresu:

![Wykres PowerPoint z otwartym osadzonym arkuszem, pokazujący dane kategorii i serii](chart-worksheet-formulas_1.png)

In Aspose.Slides arkusz jest udostępniany przez klasę [ChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdataworkbook/). Użyj [ChartDataCell.setFormula](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) dla formuł w stylu A1 oraz [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) dla formuł w stylu R1C1. Po zmianie komórek wejściowych lub formuł wywołaj [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) , aby przeliczyć obsługiwane formuły i zaktualizować odpowiednie wartości komórek.

Obliczona komórka nadal udostępnia swój wynik przez [ChartDataCell.getValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/#getValue--). Jest to ważne, gdy trzeba sprawdzić wynik formuły w kodzie lub użyć komórki jako punktu danych wykresu.

## **Utworzenie wykresu i obliczenie formuł w arkuszu**

Przykład poniżej demonstruje kompletny przepływ pracy. Tworzy wykres kolumnowy grupowany, czyści przykładowe dane, zapisuje kwartalne przychody i wydatki, oblicza zysk przy użyciu formuł, odczytuje wyniki, wykorzystuje obliczone komórki jako wartości wykresu i zapisuje prezentację.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Punkty danych wykresu odwołują się do `D2:D4`, więc wykres używa obliczonych wartości zysku. W tym przepływie nie ma osobnego wywołania odświeżenia wykresu: najpierw przelicz skoroszyt, a potem użyj lub zapisz dane wykresu wskazujące na obliczone komórki.

## **Używanie formuł w stylu A1**

Notacja A1 identyfikuje kolumny literami, a wiersze liczbami. Przypisz wyrażenia w stylu A1 za pomocą [ChartDataCell.setFormula](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Typowe formy odwołań A1 to:

| Odwołanie | Względne | Bezwzględne | Mieszane |
|---|---|---|---|
| Komórka | `A2` | `$A$2` | `A$2`, `$A2` |
| Wiersz | `2:2` | `$2:$2` | — |
| Kolumna | `A:A` | `$A:$A` | — |
| Zakres | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Odwołania względne mogą się zmieniać, gdy formuła jest przenoszona lub kopiowana w aplikacji arkusza kalkulacyjnego. Odwołania bezwzględne utrzymują oba współrzędne niezmienione, natomiast odwołania mieszane blokują tylko wiersz lub kolumnę.

## **Używanie formuł w stylu R1C1**

Notacja R1C1 identyfikuje zarówno wiersze, jak i kolumny numerycznie. Odwołania względne używają przesunięć w nawiasach kwadratowych. Przypisz tę składnię za pomocą [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Typowe formy odwołań R1C1 to:

| Odwołanie | Względne | Bezwzględne | Mieszane |
|---|---|---|---|
| Komórka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Wiersz | `R[2]` | `R2` | — |
| Kolumna | `C[3]` | `C3` | — |
| Zakres | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Na przykład, w komórce `D2`, `RC[-2]` oznacza komórkę w tym samym wierszu, dwie kolumny w lewo (`B2`).

## **Stałe i operatory formuł**

Wbudowany evaluator formuł obsługuje wartości logiczne, liczby, łańcuchy znaków, wartości błędów arkusza, operatory arytmetyczne i operatory porównania.

### **Stałe i literały**

| Typ | Przykłady | Uwagi |
|---|---|---|
| Logiczny | `TRUE`, `FALSE` | Można używać bezpośrednio w wyrażeniach logicznych, np. `A2=TRUE`. |
| Liczbowy | `1`, `0.5`, `.3`, `1E-2` | Obsługiwana jest notacja zwykła i naukowa. |
| Tekstowy | `"abc"`, `"2/3/2020 12:00"` | Literały tekstowe są ujęte w podwójnych cudzysłowach wewnątrz formuły. |
| Wynik błędu | `#DIV/0!`, `#N/A`, `#REF!` | Poprawna formuła może zwrócić wartość błędu arkusza zamiast normalnego wyniku. |

Ten przykład używa kilku typów stałych:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
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

Użyj nawiasów, aby wyraźnie określić kolejność obliczeń, np. `(A2+B2)*C2`.

### **Operatory porównania**

Operatory porównania zwracają wartości logiczne.

| Operator | Znaczenie | Przykład |
|---|---|---|
| `=` | Równe | `A2=3` |
| `<>` | Nierówne | `A2<>3` |
| `>` | Większe niż | `A2>3` |
| `>=` | Większe lub równe | `A2>=3` |
| `<` | Mniejsze niż | `A2<3` |
| `<=` | Mniejsze lub równe | `A2<=3` |

## **Obsługiwane wbudowane funkcje**

Aspose.Slides zawiera wbudowany evaluator formuł dla arkuszy wykresów, ale nie jest pełnym silnikiem kalkulacyjnym Excel. Dokumentowany zestaw funkcji ogranicza się do poniższych funkcji. Nie zakładaj, że dowolna funkcja Excel może być przeliczona przez [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Funkcja | Cel lub obsługiwana forma | Przykład |
|---|---|---|
| `ABS` | Wartość bezwzględna | `ABS(A2)` |
| `AVERAGE` | Średnia arytmetyczna | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrąglenie liczby w górę do wielokrotności | `CEILING(A2,5)` |
| `CHOOSE` | Wybór wartości według indeksu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Łączenie wartości tekstowych | `CONCAT(A2,B2)` |
| `CONCATENATE` | Łączenie wartości tekstowych | `CONCATENATE(A2," ",B2)` |
| `DATE` | Utworzenie wartości daty w systemie dat 1900 | `DATE(2026,8,19)` |
| `DAYS` | Zwraca liczbę dni pomiędzy datami | `DAYS(B2,A2)` |
| `FIND` | Znajduje jeden tekst w innym | `FIND("-",A2)` |
| `FINDB` | Wyszukiwanie tekstu orientowane na bajty | `FINDB("a",A2)` |
| `IF` | Wynik warunkowy | `IF(A2>0,A2,0)` |
| `INDEX` | Forma odwołania | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma wektorowa | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma wektorowa | `MATCH(A2,B2:B5,0)` |
| `MAX` | Wartość maksymalna | `MAX(B2:B5)` |
| `SUM` | Suma wartości | `SUM(B2:B5)` |
| `VLOOKUP` | Wyszukiwanie wertykalne | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pokazane ograniczenia w tabeli są istotne: `INDEX` jest udokumentowany w formie odwołania, natomiast `LOOKUP` i `MATCH` w ich formach wektorowych. `DATE` używa systemu dat 1900. Funkcje i cechy nie wymienione tutaj powinny być traktowane jako nieobsługiwane przez evaluator formuł Aspose.Slides, chyba że są udokumentowane osobno.

## **Przeliczanie i wartości buforowane**

Pliki arkuszy kalkulacyjnych zwykle przechowują zarówno formułę, jak i jej ostatnio obliczoną wartość. Aspose.Slides może więc odczytać wartość buforowaną z [ChartDataCell.getValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/#getValue--) gdy prezentacja jest wczytana i odpowiednie dane wykresu nie zostały zmienione.

Po zmianie komórek wejściowych lub formuł nie polegaj na starej wartości buforowanej. Wywołaj [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) przed odczytaniem obliczonych wartości lub zapisem danych wykresu, które od nich zależą.

Dla formuł spoza obsługiwanego podzbioru Aspose.Slides może nie być w stanie parsować formuły ani ustalić jej zależności. Jeśli skoroszyt został zmodyfikowany, poprzednia wartość buforowana nie może być uznana za wiarygodną. W takiej sytuacji odczyt wartości komórki z nieobsługiwanymi danymi może wywołać [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Jeśli Twój wykres zależy od funkcji Excel, których Aspose.Slides nie ocenia, oblicz te formuły przy użyciu silnika arkusza kalkulacyjnego, który je obsługuje, i zapisz otrzymane wartości z powrotem do skoroszytu wykresu. Nie zastępuj nieobsługiwanych formuł przypuszczonymi wartościami.

## **Obsługa błędów formuł**

Są dwa różne rodzaje problemów, które należy rozróżnić.

Formuła może być prawidłowa, ale zwracać wynik błędu arkusza, np. `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` lub `#VALUE!`. W takim przypadku token błędu jest wynikiem komórki i może być zwrócony przez [ChartDataCell.getValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Formuła może również niepowodzenie na etapie parsowania, odwołania, zależności lub nieobsługiwanych danych. Aspose.Slides dostarcza specyficzne dla arkuszy kalkulacyjnych wyjątki dla tych przypadków: [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cellcircularreferenceexception/), i [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Gdy formuły pochodzą z szablonów lub danych wejściowych użytkownika, łap błędy wokół przeliczania i dostępu do wartości. Szczegóły błędu identyfikują podstawowy problem arkusza:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Praktyczne ograniczenia**

Obsługa formuł w arkuszach wykresów przeznaczona jest dla określonego podzbioru obliczeń arkusza, a nie dla pełnej kompatybilności z Excel. Pamiętaj o tych ograniczeniach przy projektowaniu przepływu raportowania:

- Używaj wyłącznie udokumentowanych stałych, operatorów, odwołań i funkcji, gdy potrzebujesz, aby Aspose.Slides przeliczało formuły.
- Przelicz po zmianie komórek, od których zależą wyniki formuł.
- Traktuj wartości buforowane z wczytanych prezentacji jako migawki, a nie jako zamiennik przeliczania po edycjach.
- Testuj formuły z istniejących szablonów przed poleganiem na ich obliczonych wartościach, szczególnie gdy używają funkcji spoza udokumentowanej listy.
- Dla formuł wymagających pełnego silnika kalkulacji arkusza, oblicz je zewnętrznie, a następnie zaktualizuj skoroszyt wykresu otrzymanymi wartościami.

## **FAQ**

**Jaka jest różnica między [ChartDataCell.setFormula](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula] przechowuje wyrażenie w stylu A1, np. `B2-C2`. [ChartDataCell.setR1C1Formula] przechowuje wyrażenie w stylu R1C1, np. `RC[-2]-RC[-1]`. Użyj notacji, która najlepiej pasuje do sposobu generowania lub kopiowania formuł.

**Czy muszę odczytać samą komórkę, czy jej wartość po obliczeniu?**

[ChartDataWorkbook.getCell] zwraca [ChartDataCell]. Aby uzyskać wynik obliczenia, wywołaj metodę [ChartDataCell.getValue] tej komórki po przeliczeniu.

**Kiedy powinienem wywołać [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

Wywołaj [ChartDataWorkbook.calculateFormulas] po zmianie wartości wejściowych lub formuł i przed użyciem wyników obliczeń. Aktualizuje to wartości formuł obsługiwanych przez wbudowany evaluator.

**Czy Aspose.Slides obsługuje każdą funkcję Excel?**

Nie. Wbudowany evaluator obsługuje udokumentowany podzbiór funkcji. Nie należy zakładać, że funkcje spoza tego podzbioru będą przeliczane poprawnie. Jeśli wymagana jest pełna kompatybilność z formułami Excel, wykonaj obliczenia przy użyciu odpowiedniego silnika arkusza kalkulacyjnego i zapisz ostateczne wartości w skoroszycie wykresu.

**Co się stanie, jeśli wczytana prezentacja zawiera nieobsługiwaną formułę?**

Jeśli dane wykresu nie uległy zmianie, skoroszyt może nadal zawierać wcześniej obliczoną wartość buforowaną. Po modyfikacji powiązanych danych ta buforowana wartość może stać się nieprawidłowa. Dostęp do komórki, której formuła nie może być obsłużona, może spowodować wyrzucenie [CellUnsupportedDataException].

**Czy wartości błędów formuły są takie same jak wyjątki?**

Nie. Wynik taki jak `#DIV/0!` jest wartością arkusza wygenerowaną przez prawidłowe obliczenie. Wyjątki takie jak [CellInvalidFormulaException] czy [CellCircularReferenceException] wskazują, że formuła nie może być przetworzona w normalny sposób.

**Czy wykres aktualizuje się automatycznie, gdy zmieni się komórka z formułą?**

Seria wykresu może odwoływać się do komórek skoroszytu. Najpierw przelicz skoroszyt, a potem zapisz lub wyrenderuj prezentację. Jeśli punkty danych wykresu odwołują się do obliczonych komórek, wykres użyje zaktualizowanych wartości; nie jest wymagane osobne wywołanie odświeżenia wykresu w tym przepływie.

**Czy wykresy mogą używać zewnętrznego skoroszytu Excel?**

Tak, dane wykresu można skonfigurować do używania zewnętrznego skoroszytu poprzez API danych wykresu. Jednak opisany w tym artykule proces obliczania formuł dotyczy skoroszytu danych wykresu i podzbioru formuł ocenianych przez Aspose.Slides. Nie zakładaj, że [ChartDataWorkbook.calculateFormulas] zapewnia pełne przeliczenie dowolnych formuł w zewnętrznym pliku XLSX.

**Czy mogę używać formuł odwołujących się do innego arkusza lub skoroszytu?**

Odwołania w stylu Excel mogą występować w skoroszytach wykresów, ale ocena formuł jest ograniczona przez obsługiwany parser i zestaw funkcji. Jeśli odwołanie między arkuszami lub do zewnętrznego skoroszytu jest niezbędne, zweryfikuj tę konkretną formułę w docelowej wersji Aspose.Slides. Dla przepływów wymagających szerokiej kompatybilności odwołań Excel, oblicz skoroszyt zewnętrznie i zapisz rozwiązane wartości z powrotem do danych wykresu.

**Czy łańcuchy formuł powinny zaczynać się od `=`?**

Przykłady API Aspose.Slides przypisują wyrażenia takie jak `B2-C2` lub `SUM(B2:B5)` bez wiodącego `=`. Użycie tej formy utrzymuje generowane formuły spójne z udokumentowanymi przykładami API.