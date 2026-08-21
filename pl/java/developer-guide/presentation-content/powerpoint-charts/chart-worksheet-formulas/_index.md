---
title: Zastosowanie formuł arkusza wykresu w prezentacjach w Javie
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/java/chart-worksheet-formulas/
keywords:
- arkusz kalkulacyjny wykresu
- arkusz wykresu
- formuła wykresu
- formuła arkusza
- formuła arkusza kalkulacyjnego
- skoroszyt danych wykresu
- obliczanie formuły
- preferowana kultura
- formuła zależna od kultury
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
- Java
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w skoroszytach wykresów Aspose.Slides dla Javy, przelicz wartości i użyj wyników w wykresach PowerPoint."
---
## **Przegląd**

Wykresy PowerPoint zwykle przechowują swoje dane źródłowe w osadzonym arkuszu kalkulacyjnym. W Aspose.Slides for Java można uzyskać dostęp do tego arkusza poprzez skoroszyt danych wykresu, zapisywać wartości wejściowe, przypisywać formuły do komórek, obliczać obsługiwane formuły i używać obliczonych komórek jako danych wykresu.

Ten artykuł wyjaśnia kompletny przepływ pracy z formułami: tworzenie wykresu, wypełnianie jego arkusza, przypisywanie formuł w stylu A1 lub R1C1, ich ponowne obliczanie, odczyt obliczonych wartości, podłączanie tych komórek do serii wykresu i zapisywanie prezentacji. Opisuje również obsługiwaną składnię formuł, podzbiór wbudowanych funkcji, wartości buforowane, nieobsługiwane formuły oraz błędy specyficzne dla arkuszy kalkulacyjnych.

## **Arkusze wykresu i formuły**

Arkusz wykresu zawiera kategorie, nazwy serii i wartości używane przez wykres. W PowerPoint można przejrzeć arkusz, otwierając edytor danych wykresu:

![Wykres PowerPoint z otwartym osadzonym arkuszem, pokazujący dane kategorii i serii](chart-worksheet-formulas_1.png)

W Aspose.Slides arkusz jest udostępniony poprzez interfejs [IChartDataWorkbook](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/). Użyj [IChartDataCell.setFormula](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) dla formuł w stylu A1 oraz [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) dla formuł w stylu R1C1. Po zmianie komórek wejściowych lub formuł wywołaj [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aby ponownie obliczyć obsługiwane formuły i zaktualizować odpowiadające wartości komórek.

Obliczona komórka nadal udostępnia swój wynik poprzez [IChartDataCell.getValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#getValue--). Jest to istotne, gdy trzeba sprawdzić wynik formuły w kodzie lub użyć komórki jako punktu danych wykresu.

## **Tworzenie wykresu i obliczanie formuł w arkuszu**

Poniższy przykład demonstruje pełny przepływ pracy. Tworzy wykres kolumnowy grupowany, czyści dane przykładowe, zapisuje kwartalne przychody i koszty, oblicza zysk przy użyciu formuł, odczytuje wyniki, używa obliczonych komórek jako wartości wykresu i zapisuje prezentację.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Punkty danych wykresu odwołują się do `D2:D4`, więc wykres używa obliczonych wartości zysku. W tym przepływie nie ma osobnego wywołania odświeżania wykresu: najpierw przelicz skoroszyt, a potem użyj lub zapisz dane wykresu wskazujące na obliczone komórki.

## **Używanie formuł w stylu A1**

Notacja A1 identyfikuje kolumny literami, a wiersze liczbami. Przypisuj wyrażenia w stylu A1 poprzez [IChartDataCell.setFormula](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Typowe formy odwołań A1:

| Odwołanie | Względne | Bezwzględne | Mieszane |
|---|---|---|---|
| Komórka | `A2` | `$A$2` | `A$2`, `$A2` |
| Wiersz | `2:2` | `$2:$2` | — |
| Kolumna | `A:A` | `$A:$A` | — |
| Zakres | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Odwołania względne mogą się zmieniać, gdy formuła zostanie przeniesiona lub skopiowana w aplikacji arkusza. Odwołania bezwzględne utrzymują oba współrzędne stałe, natomiast odwołania mieszane ustalają tylko wiersz lub kolumnę.

## **Używanie formuł w stylu R1C1**

Notacja R1C1 identyfikuje zarówno wiersze, jak i kolumny liczbami. Odwołania względne używają przesunięć w nawiasach kwadratowych. Przypisuj tę składnię poprzez [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Typowe formy odwołań R1C1:

| Odwołanie | Względne | Bezwzględne | Mieszane |
|---|---|---|---|
| Komórka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Wiersz | `R[2]` | `R2` | — |
| Kolumna | `C[3]` | `C3` | — |
| Zakres | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Na przykład w komórce `D2` wyrażenie `RC[-2]` oznacza komórkę w tym samym wierszu, dwie kolumny w lewo (`B2`).

## **Stałe i operatory w formułach**

Wbudowany evaluator formuł obsługuje wartości logiczne, literały liczbowe, ciągi znaków, wartości błędów arkusza, operatory arytmetyczne i operatory porównania.

### **Stałe i literały**

| Typ | Przykłady | Uwagi |
|---|---|---|
| Logiczny | `TRUE`, `FALSE` | Można używać bezpośrednio w wyrażeniach logicznych, np. `A2=TRUE`. |
| Liczbowy | `1`, `0.5`, `.3`, `1E-2` | Obsługiwane są notacja zwykła i naukowa. |
| Tekstowy | `"abc"`, `"2/3/2020 12:00"` | Literały tekstowe umieszczane są w podwójnych cudzysłowach wewnątrz formuły. |
| Wynik błędu | `#DIV/0!`, `#N/A`, `#REF!` | Prawidłowa formuła może zwrócić wartość błędu arkusza zamiast normalnego wyniku. |

Ten przykład używa kilku typów stałych:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // fałsz
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Operatory arytmetyczne**

| Operator | Znaczenie | Przykład |
|---|---|---|
| `+` | Dodawanie lub znak plus jednoargumentowy | `2+3` |
| `-` | Odejmowanie lub negacja | `2-3`, `-3` |
| `*` | Mnożenie | `2*3` |
| `/` | Dzielenie | `2/3` |
| `%` | Procent | `30%` |
| `^` | Potęgowanie | `2^3` |

Używaj nawiasów, aby jawnie określić kolejność obliczeń, np. `(A2+B2)*C2`.

### **Operatory porównania**

Wyrażenia porównawcze zwracają wartości logiczne.

| Operator | Znaczenie | Przykład |
|---|---|---|
| `=` | Równe | `A2=3` |
| `<>` | Różne | `A2<>3` |
| `>` | Większe niż | `A2>3` |
| `>=` | Większe lub równe | `A2>=3` |
| `<` | Mniejsze niż | `A2<3` |
| `<=` | Mniejsze lub równe | `A2<=3` |

## **Obsługiwane funkcje wbudowane**

Aspose.Slides zawiera wbudowany evaluator formuł dla arkuszy wykresów, ale nie jest pełnym silnikiem obliczeniowym Excel. Zestaw dokumentowanych funkcji jest ograniczony do poniższych. Nie zakładaj, że dowolna funkcja Excel zostanie przeliczona przez [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Funkcja | Przeznaczenie lub obsługiwana forma | Przykład |
|---|---|---|
| `ABS` | Wartość bezwzględna | `ABS(A2)` |
| `AVERAGE` | Średnia arytmetyczna | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrąglenie w górę do wielokrotności | `CEILING(A2,5)` |
| `CHOOSE` | Wybór wartości po indeksie | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Łączenie wartości tekstowych | `CONCAT(A2,B2)` |
| `CONCATENATE` | Łączenie wartości tekstowych | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tworzenie wartości daty w systemie 1900 | `DATE(2026,8,19)` |
| `DAYS` | Liczba dni pomiędzy datami | `DAYS(B2,A2)` |
| `FIND` | Znajdź tekst w innym tekście | `FIND("-",A2)` |
| `FINDB` | Wyszukiwanie tekstu bajtowo | `FINDB("a",A2)` |
| `IF` | Wynik warunkowy | `IF(A2>0,A2,0)` |
| `INDEX` | Forma referencyjna | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma wektorowa | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma wektorowa | `MATCH(A2,B2:B5,0)` |
| `MAX` | Wartość maksymalna | `MAX(B2:B5)` |
| `SUM` | Suma wartości | `SUM(B2:B5)` |
| `VLOOKUP` | Wyszukiwanie pionowe | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ograniczenia w tabeli są istotne: `INDEX` jest udokumentowany w formie referencyjnej, natomiast `LOOKUP` i `MATCH` w formie wektorowej. `DATE` używa systemu dat 1900. Funkcje i cechy nie wymienione tutaj należy uznać za nieobsługiwane przez evaluator Aspose.Slides, chyba że są udokumentowane osobno.

## **Obliczanie formuł z preferowaną kulturą**

Niektóre funkcje skoroszytu interpretują tekst zgodnie z regułami kulturowymi. Jest to szczególnie ważne dla funkcji przeznaczonych dla języków używających podwójnych bajtów (DBCS). Aby poprawnie obliczyć takie formuły, utwórz [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/), ustaw preferowaną kulturę za pomocą [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/pl/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), przypisz opcje arkusza przez [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), a następnie załaduj prezentację.

Poniższy przykład wybiera kulturę japońską, otwiera prezentację z skonfigurowanymi opcjami ładowania i wywołuje [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) dla każdego skoroszytu wykresu:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Preferowana kultura jest częścią konfiguracji ładowania prezentacji, więc określ ją przed utworzeniem obiektu [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Użyj kultury oczekiwanej przez formuły skoroszytu; na przykład `ja-JP` dla formuł, które powinny stosować japońskie reguły DBCS.

## **Przeliczanie i wartości buforowane**

Pliki arkuszy kalkulacyjnych zwykle przechowują zarówno formułę, jak i jej ostatnio obliczoną wartość. Aspose.Slides może więc odczytać wartość buforowaną z [IChartDataCell.getValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#getValue--) podczas ładowania prezentacji, jeśli odpowiednie dane wykresu nie zostały zmienione.

Po zmianie komórek wejściowych lub formuł nie polegaj na starej wartości buforowanej. Wywołaj [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) przed odczytem obliczonych wartości lub zapisem danych wykresu, od których zależą.

Dla formuł spoza obsługiwanego podzbioru Aspose.Slides może nie być w stanie sparsować formuły ani ustalić jej zależności. Jeśli skoroszyt został zmodyfikowany, poprzednia wartość buforowana nie może już być uznana za wiarygodną. W takiej sytuacji odczyt wartości komórki z nieobsługiwanymi danymi może spowodować wyrzucenie [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellunsupporteddataexception/).

Jeśli Twój wykres zależy od funkcji Excel, których Aspose.Slides nie ocenia, oblicz te formuły przy użyciu silnika arkusza obsługującego je i zapisz otrzymane wartości z powrotem do skoroszytu wykresu. Nie zamieniaj nieobsługiwanych formuł na zgadywane wartości.

## **Obsługa błędów formuł**

Rozróżnia się dwa rodzaje problemów.

Formuła może być prawidłowa, ale zwracać wynik błędu arkusza, taki jak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` lub `#VALUE!`. W takim przypadku token błędu jest wynikiem komórki i może zostać zwrócony przez [IChartDataCell.getValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#getValue--).

Formuła może także nie powieść się na etapie parsowania, odwołania, zależności lub obsługi danych. Aspose.Slides udostępnia specyficzne dla arkusza wyjątki: [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellcircularreferenceexception/), oraz [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellunsupporteddataexception/).

Gdy formuły pochodzą z szablonów lub danych wejściowych użytkownika, obsłuż te wyjątki wokół przeliczania i dostępu do wartości:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Praktyczne ograniczenia**

Obsługa formuł w arkuszach wykresów jest przeznaczona dla określonego podzbioru obliczeń arkuszy, a nie pełnej kompatybilności z Excelem. Pamiętaj o tych ograniczeniach przy projektowaniu przepływu raportowania:

- Używaj wyłącznie udokumentowanych stałych, operatorów, odwołań i funkcji, gdy potrzebujesz, aby Aspose.Slides przeliczało formuły.
- Przeliczaj po zmianie komórek, od których zależą wyniki formuł.
- Traktuj wartości buforowane z załadowanych prezentacji jako migawki, a nie jako zamiennik przeliczania po edycjach.
- Testuj formuły z istniejących szablonów przed poleganiem na ich obliczonych wartościach, szczególnie gdy używają funkcji spoza udokumentowanej listy.
- Dla formuł wymagających pełnego silnika obliczeniowego arkusza, oblicz je zewnętrznie, a następnie zaktualizuj skoroszyt wykresu otrzymanymi wartościami.

## **FAQ**

**Jaka jest różnica między [IChartDataCell.setFormula](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) zapisuje wyrażenie w stylu A1, np. `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) zapisuje wyrażenie w stylu R1C1, np. `RC[-2]-RC[-1]`. Użyj notacji, która najlepiej pasuje do sposobu generowania lub kopiowania formuł.

**Czy muszę odczytać samą komórkę czy jej wartość po przeliczeniu?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) zwraca obiekt [IChartDataCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/). Aby uzyskać obliczony wynik, wywołaj metodę [IChartDataCell.getValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#getValue--) tej komórki po przeliczeniu.

**Kiedy powinienem wywołać [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Wywołaj [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) po zmianie wartości wejściowych lub formuł i przed tym, jak zależysz od obliczonych wyników. Aktualizuje to wartości formuł obsługiwanych przez wbudowany evaluator.

**Czy Aspose.Slides obsługuje każdą funkcję Excela?**

Nie. Wbudowany evaluator obsługuje udokumentowany podzbiór funkcji. Funkcje spoza tego podzbioru nie powinny być traktowane jako prawidłowo przeliczane. Jeśli wymagana jest pełna zgodność z formułami Excel, wykonaj obliczenia przy użyciu odpowiedniego silnika arkusza i zapisz finalne wartości do skoroszytu wykresu.

**Co się stanie, jeśli załadowana prezentacja zawiera nieobsługiwaną formułę?**

Jeśli dane wykresu nie zostały zmienione, skoroszyt może nadal zawierać wcześniej obliczoną wartość buforowaną. Po zmodyfikowaniu powiązanych danych ta buforowana wartość może stracić ważność. Dostęp do komórki, której formuła nie może być obsłużona, może spowodować wyrzucenie [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellunsupporteddataexception/).

**Czy wartości błędów formuły są tym samym co wyjątki Javy?**

Nie. Wynik taki jak `#DIV/0!` jest wartością arkusza uzyskaną w wyniku prawidłowego obliczenia. Wyjątki takie jak [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellinvalidformulaexception/) czy [CellCircularReferenceException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellcircularreferenceexception/) wskazują, że formuła nie może być przetworzona w normalny sposób.

**Czy wykres aktualizuje się automatycznie po zmianie komórki z formułą?**

Seria wykresu może odwoływać się do komórek skoroszytu. Najpierw przelicz skoroszyt, a potem zapisz lub renderuj prezentację. Jeśli punkty danych wykresu odwołują się do obliczonych komórek, wykres użyje zaktualizowanych wartości; nie wymaga to osobnej metody odświeżania wykresu w tym przepływie.

**Czy wykresy mogą używać zewnętrznego skoroszytu Excel?**

Tak, dane wykresu można skonfigurować do użycia zewnętrznego skoroszytu poprzez API danych wykresu. Jednak opisany w tym artykule przepływ obliczania formuł dotyczy skoroszytu danych wykresu i podzbioru funkcji ocenianych przez Aspose.Slides. Nie zakłada się, że [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) zapewnia pełne przeliczenie dowolnych formuł w zewnętrznym pliku XLSX.

**Czy mogę używać formuł odwołujących się do innego arkusza lub skoroszytu?**

Odwołania w stylu Excel mogą występować w skoroszytach wykresów, ale ocena formuł jest ograniczona przez obsługiwany parser i zestaw funkcji. Jeśli odwołanie międzyarkuszowe lub zewnętrzne jest niezbędne, zweryfikuj dokładną formułę w wersji Aspose.Slides, której używasz. Dla przepływów wymagających szerokiej kompatybilności odwołań Excel, oblicz skoroszyt zewnętrznie i zapisz rozwiązane wartości z powrotem do danych wykresu.

**Czy ciągi formuł powinny zaczynać się od `=`?**

Przykłady API Aspose.Slides przypisują wyrażenia takie jak `B2-C2` lub `SUM(B2:B5)` bez wiodącego znaku `=`. Używanie takiej formy utrzymuje generowane formuły spójne z udokumentowanymi przykładami API.