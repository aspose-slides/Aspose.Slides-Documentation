---
title: Zastosowanie formuł arkusza wykresu w prezentacjach w PHP
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/php-java/chart-worksheet-formulas/
keywords:
- arkusz wykresu
- arkusz wykresu
- formuła wykresu
- formuła arkusza
- formuła arkusza kalkulacyjnego
- skoroszyt danych wykresu
- obliczanie formuły
- stała logiczna
- stała numeryczna
- stała łańcuchowa
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
description: "Zastosuj formuły w stylu Excel w arkuszach wykresów Aspose.Slides dla PHP via Java, przelicz wartości i użyj wyników w wykresach PowerPoint."
---
## **Przegląd**

Wykresy PowerPoint zazwyczaj przechowują dane źródłowe w osadzonym arkuszu kalkulacyjnym. W Aspose.Slides for PHP via Java możesz uzyskać dostęp do tego arkusza przez skoroszyt danych wykresu, zapisywać wartości wejściowe, przypisywać formuły do komórek, obliczać obsługiwane formuły i używać obliczonych komórek jako danych wykresu.

Ten artykuł opisuje kompletny proces pracy z formułami: tworzenie wykresu, wypełnianie jego arkusza, przypisywanie formuł w stylu A1 lub R1C1, ich ponowne obliczanie, odczyt obliczonych wartości, podłączenie tych komórek do serii wykresu oraz zapis prezentacji. Opisuje także obsługiwaną składnię formuł, podzbiór wbudowanych funkcji, wartości buforowane, nieobsługiwane formuły oraz błędy specyficzne dla arkuszy kalkulacyjnych.

## **Arkusze wykresów i formuły**

Arkusz wykresu zawiera kategorie, nazwy serii i wartości używane przez wykres. W PowerPoint możesz przejrzeć arkusz, otwierając edytor danych wykresu:

![Wykres PowerPoint z otwartym osadzonym arkuszem, pokazujący dane kategorii i serii](chart-worksheet-formulas_1.png)

W Aspose.Slides arkusz jest udostępniany przez klasę [ChartDataWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/). Użyj [ChartDataCell::setFormula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula) dla formuł w stylu A1 oraz [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setR1C1Formula) dla formuł w stylu R1C1. Po zmianie komórek wejściowych lub formuł wywołaj [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas), aby ponownie obliczyć obsługiwane formuły i zaktualizować odpowiadające wartości komórek.

Obliczona komórka nadal udostępnia wynik przez [ChartDataCell::getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#getValue). Jest to istotne, gdy musisz sprawdzić wynik formuły w kodzie lub użyć komórki jako punktu danych wykresu.

## **Utworzenie wykresu i obliczenie formuł w arkuszu**

Poniższy przykład demonstruje kompletny przepływ pracy. Tworzy skumulowany wykres kolumnowy, wymazuje przykładowe dane, zapisuje kwartalne przychody i koszty, oblicza zysk za pomocą formuł, odczytuje wyniki, używa obliczonych komórek jako wartości wykresu i zapisuje prezentację.

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

Punkty danych wykresu odwołują się do `D2:D4`, więc wykres używa obliczonych wartości zysku. W tym przepływie nie ma osobnego wywołania odświeżenia wykresu: najpierw ponownie oblicz skoroszyt, a potem użyj lub zapisz dane wykresu wskazujące na obliczone komórki.

## **Używanie formuł w stylu A1**

Notacja A1 identyfikuje kolumny literami, a wiersze liczbami. Przypisuj wyrażenia w stylu A1 poprzez [ChartDataCell::setFormula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula).

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

Odwołania względne mogą się zmieniać, gdy formuła jest przenoszona lub kopiowana przez aplikację arkusza kalkulacyjnego. Odwołania bezwzględne utrzymują oba współrzędne stałe, natomiast odwołania mieszane fixują tylko wiersz lub kolumnę.

## **Używanie formuł w stylu R1C1**

Notacja R1C1 identyfikuje zarówno wiersze, jak i kolumny numerycznie. Odwołania względne używają przesunięć w kwadratowych nawiasach. Przypisz tę składnię poprzez [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

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

Na przykład w komórce `D2` zapis `RC[-2]` oznacza komórkę w tym samym wierszu dwie kolumny w lewo (`B2`).

## **Stałe i operatory w formułach**

Wbudowany evaluator formuł obsługuje wartości logiczne, literały liczbowe, łańcuchy znaków, wartości błędów arkusza, operatory arytmetyczne i operatory porównania.

### **Stałe i literały**

| Typ | Przykłady | Uwagi |
|---|---|---|
| Logiczny | `TRUE`, `FALSE` | Może być używany bezpośrednio w wyrażeniach logicznych, np. `A2=TRUE`. |
| Numeryczny | `1`, `0.5`, `.3`, `1E-2` | Obsługiwane są notacje zwykła i naukowa. |
| Łańcuch | `"abc"`, `"2/3/2020 12:00"` | Literały tekstowe są otoczone podwójnymi cudzysłowami wewnątrz formuły. |
| Wynik błędu | `#DIV/0!`, `#N/A`, `#REF!` | Poprawna formuła może zwrócić wartość błędu arkusza zamiast normalnego wyniku. |

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

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // fałsz
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
| `+` | Dodawanie lub znak plus jednosygnalny | `2+3` |
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
| `<>` | Nierówne | `A2<>3` |
| `>` | Większe niż | `A2>3` |
| `>=` | Większe lub równe | `A2>=3` |
| `<` | Mniejsze niż | `A2<3` |
| `<=` | Mniejsze lub równe | `A2<=3` |

## **Obsługiwane funkcje wbudowane**

Aspose.Slides zawiera wbudowany evaluator formuł dla arkuszy wykresów, ale nie jest to pełny silnik obliczeniowy Excel. Dokumentowany zestaw funkcji jest ograniczony do poniższych funkcji. Nie zakładaj, że dowolna funkcja Excel zostanie ponownie obliczona przez [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Funkcja | Cel lub obsługiwana forma | Przykład |
|---|---|---|
| `ABS` | Wartość bezwzględna | `ABS(A2)` |
| `AVERAGE` | Średnia arytmetyczna | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrąglenie w górę do wielokrotności | `CEILING(A2,5)` |
| `CHOOSE` | Wybór wartości po indeksie | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Łączenie tekstów | `CONCAT(A2,B2)` |
| `CONCATENATE` | Łączenie tekstów | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tworzenie wartości daty w systemie 1900 | `DATE(2026,8,19)` |
| `DAYS` | Liczba dni między datami | `DAYS(B2,A2)` |
| `FIND` | Znajdź tekst w innym tekście | `FIND("-",A2)` |
| `FINDB` | Wyszukiwanie tekstu bajt po bajcie | `FINDB("a",A2)` |
| `IF` | Wynik warunkowy | `IF(A2>0,A2,0)` |
| `INDEX` | Forma referencyjna | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma wektorowa | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma wektorowa | `MATCH(A2,B2:B5,0)` |
| `MAX` | Największa wartość | `MAX(B2:B5)` |
| `SUM` | Suma wartości | `SUM(B2:B5)` |
| `VLOOKUP` | Wyszukiwanie pionowe | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ograniczenia przedstawione w tabeli mają istotne znaczenie: `INDEX` jest dokumentowany w formie referencyjnej, natomiast `LOOKUP` i `MATCH` w ich formach wektorowych. `DATE` używa systemu dat 1900. Funkcje i cechy nie wymienione tutaj należy traktować jako nieobsługiwane przez evaluator Aspose.Slides, chyba że zostały udokumentowane osobno.

## **Rekalkulacja i wartości buforowane**

Pliki arkuszy zazwyczaj przechowują zarówno formułę, jak i jej ostatnio obliczoną wartość. Aspose.Slides może więc odczytać wartość buforowaną z [ChartDataCell::getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#getValue), gdy prezentacja zostanie załadowana i odpowiednie dane wykresu nie zostały zmienione.

Po zmianie komórek wejściowych lub formuł nie polegaj na starej wartości buforowanej. Wywołaj [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) przed odczytem obliczonych wartości lub zapisem danych wykresu, które od nich zależą.

Dla formuł spoza obsługiwanego podzbioru Aspose.Slides może nie być w stanie przetworzyć formuły lub ustalić jej zależności. Jeśli skoroszyt został zmodyfikowany, poprzednia wartość buforowana nie jest już wiarygodna. W takiej sytuacji odczyt wartości komórki z nieobsługiwanymi danymi może spowodować podniesienie [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellunsupporteddataexception/).

Jeśli Twój wykres zależy od funkcji Excel, których Aspose.Slides nie ocenia, oblicz te formuły przy użyciu silnika arkusza, który je obsługuje, i zapisz otrzymane wyniki z powrotem do skoroszytu wykresu. Nie zastępuj nieobsługiwanych formuł odgadywanymi wartościami.

## **Obsługa błędów formuł**

Istnieją dwa różne rodzaje problemów.

Formuła może być poprawna, ale zwrócić wynik błędu arkusza, taki jak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` lub `#VALUE!`. W takim przypadku token błędu jest wynikiem komórki i może być zwrócony przez [ChartDataCell::getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#getValue).

Formuła może także nie powieść się na etapie parsowania, odwołań, zależności lub obsługi danych. Aspose.Slides dostarcza specyficzne dla arkuszy wyjątki: [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellcircularreferenceexception/) oraz [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellunsupporteddataexception/).

W PHP via Java wyjątki Java są przekazywane jako `JavaException`. Gdy formuły pochodzą z szablonów lub danych wejściowych użytkownika, obsłuż je wokół rekalkulacji i dostępu do wartości. Zgłoszony w śladzie stosu wyjątek Java identyfikuje konkretną awarię arkusza:

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

Obsługa formuł w arkuszach wykresów jest przeznaczona dla określonego podzbioru obliczeń arkuszowych, a nie dla pełnej kompatybilności z Excelem. Pamiętaj o tych ograniczeniach przy projektowaniu przepływu raportowania:

- Używaj wyłącznie udokumentowanych stałych, operatorów, odwołań i funkcji, gdy potrzebujesz, aby Aspose.Slides ponownie obliczał formuły.
- Rekalkuluj po zmianie komórek, od których zależą wyniki formuł.
- Traktuj wartości buforowane z załadowanych prezentacji jako migawki, nie jako substytut rekalkulacji po edycji.
- Testuj formuły z istniejących szablonów przed poleganiem na ich obliczonych wartościach, szczególnie gdy używają funkcji spoza udokumentowanej listy.
- Dla formuł wymagających pełnego silnika obliczeniowego arkusza, oblicz je zewnętrznie, a następnie zaktualizuj skoroszyt wykresu otrzymanymi wartościami.

## **FAQ**

**Jaka jest różnica między [ChartDataCell::setFormula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula) a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula) zapisuje wyrażenie w stylu A1, np. `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setR1C1Formula) zapisuje wyrażenie w stylu R1C1, np. `RC[-2]-RC[-1]`. Użyj notacji, która najlepiej pasuje do tego, jak generujesz lub kopiujesz formuły.

**Czy po obliczeniu muszę odczytywać samą komórkę czy jej wartość?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#getCell) zwraca obiekt [ChartDataCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/). Aby uzyskać obliczony wynik, po rekalkulacji wywołaj metodę [ChartDataCell::getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#getValue) tego obiektu.

**Kiedy wywołać [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Wywołaj [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) po zmianie wartości wejściowych lub formuł i przed użyciem obliczonych wyników. Aktualizuje to wartości formuł obsługiwanych przez wbudowany evaluator.

**Czy Aspose.Slides obsługuje każdą funkcję Excela?**

Nie. Wbudowany evaluator obsługuje udokumentowany podzbiór funkcji. Funkcje spoza tego podzbioru nie powinny być uznawane za poprawnie przeliczane. Jeśli wymagana jest pełna kompatybilność z formułami Excela, wykonaj obliczenia przy użyciu odpowiedniego silnika arkusza i zapisz końcowe wartości do skoroszytu wykresu.

**Co się stanie, gdy załadowana prezentacja zawiera nieobsługiwaną formułę?**

Jeśli dane wykresu nie zostały zmienione, skoroszyt może nadal zawierać wcześniej obliczoną wartość buforowaną. Po modyfikacji powiązanych danych ta wartość buforowana może przestać być ważna. Dostęp do komórki, której formuła nie może być obsłużona, może podnieść [CellUnsupportedDataException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellunsupporteddataexception/).

**Czy wartości błędów formuły są takie same jak wyjątki PHP?**

Nie. Wynik taki jak `#DIV/0!` jest wartością arkusza uzyskaną w wyniku prawidłowego obliczenia. Błędy przetwarzania arkusza, takie jak [CellInvalidFormulaException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellinvalidformulaexception/) czy [CellCircularReferenceException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellcircularreferenceexception/), są wyjątkami Java propagowanymi do PHP za pośrednictwem `JavaException`.

**Czy wykres aktualizuje się automatycznie po zmianie komórki z formułą?**

Seria wykresu może odwoływać się do komórek skoroszytu. Najpierw przelicz skoroszyt, a potem zapisz lub wyrenderuj prezentację. Jeśli punkty danych wykresu odwołują się do obliczonych komórek, wykres użyje zaktualizowanych wartości; nie jest wymagane osobne wywołanie odświeżenia wykresu.

**Czy wykresy mogą używać zewnętrznego skoroszytu Excel?**

Tak, dane wykresu mogą być skonfigurowane do użycia zewnętrznego skoroszytu poprzez API danych wykresu. Jednak opisany w tym artykule przepływ pracy dotyczy skoroszytu danych wykresu i podzbioru formuł ocenianych przez Aspose.Slides. Nie zakładaj, że [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) zapewnia pełną rekalkulację dowolnych formuł w zewnętrznym pliku XLSX.

**Czy mogę używać formuł odwołujących się do innego arkusza lub skoroszytu?**

Odwołania w stylu Excel mogą występować w skoroszytach wykresów, ale ocena formuł jest ograniczona przez obsługiwany parser i zestaw funkcji. Jeśli odwołanie między arkuszami lub do zewnętrznego pliku jest kluczowe, zweryfikuj tę konkretną formułę w wersji Aspose.Slides, której używasz. Dla przepływów wymagających szerokiej kompatybilności odwołań Excel, oblicz skoroszyt zewnętrznie i zapisz rozwiązywane wartości z powrotem do danych wykresu.

**Czy ciągi formuł powinny zaczynać się od `=`?**

Przykłady API Aspose.Slides przypisują wyrażenia takie jak `B2-C2` lub `SUM(B2:B5)` bez wiodącego `=`. Stosowanie tej formy utrzymuje generowane formuły zgodne z udokumentowanymi przykładami API.