---
title: Zastosowanie formuł arkusza wykresu w prezentacjach w PHP
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/php-java/chart-worksheet-formulas/
keywords:
- arkusz kalkulacyjny wykresu
- arkusz wykresu
- formuła wykresu
- formuła arkusza
- formuła arkusza kalkulacyjnego
- skoroszyt danych wykresu
- obliczanie formuł
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
- PHP
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w Arkuszach wykresów Aspose.Slides dla PHP poprzez Java, przeliczaj wartości i wykorzystaj wyniki w wykresach PowerPoint."
---
## **Przegląd**

Wykresy PowerPoint zazwyczaj przechowują swoje dane źródłowe w osadzonej skoroszycie. W Aspose.Slides dla PHP via Java możesz uzyskać dostęp do tego skoroszytu za pośrednictwem skoroszytu danych wykresu, zapisywać wartości wejściowe, przypisywać formuły do komórek, obliczać obsługiwane formuły i używać obliczonych komórek jako danych wykresu.

Ten artykuł wyjaśnia kompletny przepływ pracy z formułami: tworzenie wykresu, wypełnianie jego arkusza, przypisywanie formuł w stylu A1 lub R1C1, przeliczanie ich, odczytywanie obliczonych wartości, łączenie tych komórek z serią wykresu i zapisywanie prezentacji. Opisuje także obsługiwaną składnię formuł, wbudowany podzbiór funkcji, wartości buforowane, nieobsługiwane formuły oraz błędy specyficzne dla arkuszy kalkulacyjnych.

## **Arkusze wykresów i formuły**

Arkusz wykresu zawiera kategorie, nazwy serii i wartości używane przez wykres. W PowerPoint możesz przeglądać arkusz, otwierając edytor danych wykresu:

![Wykres PowerPoint z otwartym osadzonym arkuszem, pokazujący dane kategorii i serii](chart-worksheet-formulas_1.png)

W Aspose.Slides arkusz jest udostępniany przez klasę [ChartDataWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/). Użyj [ChartDataCell::setFormula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula) dla formuł w stylu A1 oraz [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setR1C1Formula) dla formuł w stylu R1C1. Po zmianie komórek wejściowych lub formuł wywołaj [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas), aby przeliczyć obsługiwane formuły i zaktualizować odpowiednie wartości komórek.

Obliczona komórka nadal udostępnia swój wynik przez [ChartDataCell::getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#getValue). Jest to istotne, gdy musisz sprawdzić wynik formuły w kodzie lub użyć komórki jako punktu danych wykresu.

## **Tworzenie wykresu i obliczanie formuł w arkuszu**

Poniższy przykład demonstruje kompletny przepływ od początku do końca. Tworzy wykres kolumnowy grupowany, czyści przykładowe dane, zapisuje kwartalne przychody i koszty, oblicza zysk za pomocą formuł, odczytuje wyniki, używa obliczonych komórek jako wartości wykresu i zapisuje prezentację.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Punkty danych wykresu odwołują się do `D2:D4`, więc wykres używa obliczonych wartości zysku. W tym przepływie nie ma osobnego wywołania odświeżenia wykresu: najpierw przelicz arkusz, potem użyj lub zapisz dane wykresu wskazujące na obliczone komórki.

## **Używanie formuł w stylu A1**

Notacja A1 identyfikuje kolumny literami, a wiersze liczbami. Przypisuj wyrażenia w stylu A1 za pomocą [ChartDataCell::setFormula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Typowe formy odwołań A1:

| Odwołanie | Względne | Bezwzględne | Mieszane |
|---|---|---|---|
| Komórka | `A2` | `$A$2` | `A$2`, `$A2` |
| Wiersz | `2:2` | `$2:$2` | — |
| Kolumna | `A:A` | `$A:$A` | — |
| Zakres | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Odwołania względne mogą się zmieniać, gdy formuła zostanie przeniesiona lub skopiowana w arkuszu. Odwołania bezwzględne utrzymują oba współrzędne stałe, natomiast odwołania mieszane blokują tylko wiersz lub kolumnę.

## **Używanie formuł w stylu R1C1**

Notacja R1C1 identyfikuje zarówno wiersze, jak i kolumny liczbowo. Odwołania względne używają offsetów w nawiasach kwadratowych. Przypisz tę składnię za pomocą [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Typowe formy odwołań R1C1:

| Odwołanie | Względne | Bezwzględne | Mieszane |
|---|---|---|---|
| Komórka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Wiersz | `R[2]` | `R2` | — |
| Kolumna | `C[3]` | `C3` | — |
| Zakres | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Na przykład w komórce `D2`, `RC[-2]` oznacza komórkę w tym samym wierszu dwa kolumny w lewo (`B2`).

## **Stałe i operatory formuł**

Wbudowany evaluator formuł obsługuje wartości logiczne, literały liczbowe, ciągi znaków, wartości błędów arkusza, operatory arytmetyczne i operatory porównania.

### **Stałe i literały**

| Typ | Przykłady | Uwagi |
|---|---|---|
| Logiczna | `TRUE`, `FALSE` | Można używać bezpośrednio w wyrażeniach logicznych, np. `A2=TRUE`. |
| Numeryczna | `1`, `0.5`, `.3`, `1E-2` | Obsługiwane są notacje zwykła i naukowa. |
| Ciąg znaków | `"abc"`, `"2/3/2020 12:00"` | Literały tekstowe są otoczone podwójnymi cudzysłowami wewnątrz formuły. |
| Wynik błędu | `#DIV/0!`, `#N/A`, `#REF!` | Poprawna formuła może zwrócić wartość błędu arkusza zamiast wyniku. |

Ten przykład używa kilku typów stałych:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
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

Używaj nawiasów, aby wyraźnie określić kolejność działań, np. `(A2+B2)*C2`.

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

Aspose.Slides zawiera wbudowany evaluator formuł dla arkuszy wykresów, ale nie jest pełnym silnikiem obliczeniowym Excel. Zestaw udokumentowanych funkcji ogranicza się do poniższych. Nie zakładaj, że dowolna funkcja Excel zostanie przeliczona przez [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Funkcja | Zastosowanie lub obsługiwana forma | Przykład |
|---|---|---|
| `ABS` | Wartość bezwzględna | `ABS(A2)` |
| `AVERAGE` | Średnia arytmetyczna | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrąglenie liczby w górę do wielokrotności | `CEILING(A2,5)` |
| `CHOOSE` | Wybór wartości po indeksie | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Łączenie wartości tekstowych | `CONCAT(A2,B2)` |
| `CONCATENATE` | Łączenie wartości tekstowych | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tworzenie wartości daty w systemie 1900 | `DATE(2026,8,19)` |
| `DAYS` | Liczba dni pomiędzy datami | `DAYS(B2,A2)` |
| `FIND` | Znajdź tekst w innym tekście | `FIND("-",A2)` |
| `FINDB` | Wyszukiwanie tekstu bajtowo | `FINDB("a",A2)` |
| `IF` | Wynik warunkowy | `IF(A2>0,A2,0)` |
| `INDEX` | Forma odwołania | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma wektorowa | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma wektorowa | `MATCH(A2,B2:B5,0)` |
| `MAX` | Wartość maksymalna | `MAX(B2:B5)` |
| `SUM` | Suma wartości | `SUM(B2:B5)` |
| `VLOOKUP` | Wyszukiwanie wertykalne | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ograniczenia w tabeli są istotne: `INDEX` jest udokumentowany w formie odwołania, natomiast `LOOKUP` i `MATCH` w formach wektorowych. `DATE` używa systemu dat 1900. Funkcje nie wymienione tutaj należy traktować jako nieobsługiwane przez evaluator Aspose.Slides, chyba że są udokumentowane osobno.

## **Obliczanie formuł z preferowaną kulturą**

Niektóre funkcje skoroszytu interpretują tekst zgodnie z zasadami kulturowymi. Jest to szczególnie ważne dla funkcji przeznaczonych dla języków używających podwójnych bajtów znakowych (DBCS). Aby poprawnie obliczyć takie formuły, utwórz [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/), ustaw preferowaną kulturę za pomocą [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), przypisz opcje arkusza przez [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) i dopiero wczytaj prezentację.

Poniższy przykład wybiera kulturę japońską, otwiera prezentację z skonfigurowanymi opcjami ładowania i wywołuje [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) dla każdego skoroszytu wykresu:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Preferowana kultura jest częścią konfiguracji ładowania prezentacji, więc podaj ją przed utworzeniem instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Użyj kultury oczekiwanej przez formuły skoroszytu; na przykład `ja-JP` dla formuł, które mają stosować japońskie reguły DBCS.

## **Przeliczanie i wartości buforowane**

Pliki arkuszy często przechowują zarówno formułę, jak i jej ostatnio obliczoną wartość. Aspose.Slides może więc odczytać wartość buforowaną z [ChartDataCell::getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#getValue), kiedy prezentacja zostaje wczytana i odpowiednie dane wykresu nie zostały zmienione.

Po zmianie komórek wejściowych lub formuł nie polegaj na starej wartości buforowanej. Wywołaj [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) przed odczytem obliczonych wartości lub zapisem danych wykresu, od których zależą.

Dla formuł spoza obsługiwanego podzbioru Aspose.Slides może nie być w stanie sparsować formuły ani ustalić jej zależności. Jeśli skoroszyt został zmodyfikowany, poprzednia wartość buforowana nie jest już wiarygodna. W takiej sytuacji odczyt wartości komórki z nieobsługiwanymi danymi może wywołać [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellunsupporteddataexception/).

Jeśli Twój wykres zależy od funkcji Excel, których Aspose.Slides nie ocenia, oblicz te formuły przy użyciu silnika arkusza obsługującego je i zapisz uzyskane wartości z powrotem do skoroszytu wykresu. Nie zastępuj nieobsługiwanych formuł domyślnymi wartościami.

## **Obsługa błędów formuł**

Istnieją dwa różne rodzaje problemów do rozróżnienia.

Formuła może być prawidłowa, ale zwracać wynik błędu arkusza, taki jak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` lub `#VALUE!`. W takim przypadku token błędu jest wynikiem komórki i może być zwrócony przez [ChartDataCell::getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#getValue).

Formuła może także nie powieść się na etapie parsowania, odwołania, zależności lub nieobsługiwanych danych. Aspose.Slides udostępnia specyficzne dla arkuszy wyjątki dla tych przypadków: [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellcircularreferenceexception/) oraz [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellunsupporteddataexception/).

W PHP via Java wyjątki Java są prezentowane jako `JavaException`. Gdy formuły pochodzą z szablonów lub wejścia użytkownika, obsłuż je wokół przeliczenia i dostępu do wartości. Wyjątek Java zgłoszony w ścieżce stosu identyfikuje konkretną awarię arkusza:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Ograniczenia praktyczne**

Obsługa formuł w arkuszach wykresów jest przeznaczona dla określonego podzbioru obliczeń arkusza, a nie dla pełnej zgodności z Excelem. Pamiętaj o tych ograniczeniach przy projektowaniu przepływu raportowania:

- Używaj wyłącznie udokumentowanych stałych, operatorów, odwołań i funkcji, gdy potrzebujesz, aby Aspose.Slides przeliczał formuły.
- Przeliczaj po zmianie komórek, od których zależą wyniki formuł.
- Traktuj wartości buforowane z wczytanych prezentacji jako migawki, a nie jako zamiennik przeliczenia po edycji.
- Testuj formuły z istniejących szablonów przed poleganiem na ich obliczonych wartościach, szczególnie gdy używają funkcji spoza udokumentowanej listy.
- Dla formuł wymagających pełnego silnika obliczeniowego arkusza, oblicz je zewnętrznie, a następnie zaktualizuj skoroszyt wykresu uzyskanymi wartościami.

## **FAQ**

**Jaka jest różnica między [ChartDataCell::setFormula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula) a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula) przechowuje wyrażenie w stylu A1, takie jak `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setR1C1Formula) przechowuje wyrażenie w stylu R1C1, takie jak `RC[-2]-RC[-1]`. Użyj notacji, która najlepiej pasuje do sposobu generowania lub kopiowania formuł.

**Czy muszę odczytać samą komórkę czy jej wartość po przeliczeniu?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#getCell) zwraca [ChartDataCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/). Aby uzyskać obliczony wynik, po przeliczeniu wywołaj metodę [ChartDataCell::getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#getValue) tej komórki.

**Kiedy powinienem wywołać [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Wywołaj [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) po zmianie wartości wejściowych lub formuł i przed tym, jak zależysz od obliczonych wyników. Aktualizuje to wartości formuł obsługiwanych przez wbudowany evaluator.

**Czy Aspose.Slides obsługuje każdą funkcję Excel?**

Nie. Wbudowany evaluator obsługuje udokumentowany podzbiór funkcji. Funkcje spoza tego podzbioru nie powinny być uznawane za prawidłowo przeliczane. Jeśli wymagana jest pełna zgodność z formułami Excel, wykonaj obliczenia przy użyciu odpowiedniego silnika arkuszy i zapisz ostateczne wartości do skoroszytu wykresu.

**Co się stanie, jeśli wczytana prezentacja zawiera nieobsługiwaną formułę?**

Jeśli dane wykresu nie zostały zmienione, skoroszyt może nadal zawierać wcześniej obliczoną wartość buforowaną. Po modyfikacji powiązanych danych ta wartość może stracić ważność. Dostęp do komórki, której formuła nie może być obsłużona, może wywołać [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellunsupporteddataexception/).

**Czy wartości błędów formuły są tym samym co wyjątki PHP?**

Nie. Wynik taki jak `#DIV/0!` to wartość arkusza uzyskana w wyniku prawidłowego obliczenia. Niepowodzenia przetwarzania arkusza, takie jak [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellinvalidformulaexception/) czy [CellCircularReferenceException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellcircularreferenceexception/), są wyjątkami Java prezentowanymi w PHP jako `JavaException`.

**Czy wykres aktualizuje się automatycznie po zmianie komórki z formułą?**

Seria wykresu może odwoływać się do komórek skoroszytu. Najpierw przelicz skoroszyt, potem zapisz lub renderuj prezentację. Jeśli punkty danych wykresu odwołują się do obliczonych komórek, wykres użyje zaktualizowanych wartości; nie jest wymagane osobne wywołanie odświeżenia wykresu w tym przepływie.

**Czy wykresy mogą używać zewnętrznego skoroszytu Excel?**

Tak, dane wykresu można skonfigurować tak, aby używały zewnętrznego skoroszytu za pośrednictwem API danych wykresu. Jednak opisany w tym artykule przepływ obliczeń formuł dotyczy skoroszytu danych wykresu i podzbioru formuł ocenianych przez Aspose.Slides. Nie zakładaj, że [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) zapewnia pełne przeliczenie dowolnych formuł w zewnętrznym pliku XLSX.

**Czy mogę używać formuł odwołujących się do innego arkusza lub skoroszytu?**

Odwołania w stylu Excel mogą występować w skoroszytach wykresów, ale ocena formuł jest ograniczona obsługiwanym parserem i zestawem funkcji. Jeśli odwołanie między arkuszami lub zewnętrzne jest niezbędne, zweryfikuj dokładną formułę z wersją Aspose.Slides, której używasz. Dla przepływów wymagających szerokiej kompatybilności odwołań Excel, oblicz skoroszyt zewnętrznie i wpisz rozwiązane wartości z powrotem do danych wykresu.

**Czy łańcuchy formuł powinny rozpoczynać się od `=`?**

Przykłady API Aspose.Slides przypisują wyrażenia takie jak `B2-C2` lub `SUM(B2:B5)` bez wiodącego `=`. Używanie takiej formy utrzymuje generowane formuły zgodne z udokumentowanymi przykładami API.