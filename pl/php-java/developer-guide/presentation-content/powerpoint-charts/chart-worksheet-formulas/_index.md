---
title: Zastosowanie formuł arkusza wykresu w prezentacjach przy użyciu PHP
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
- źródło danych
- stała logiczna
- stała liczbowa
- stała tekstowa
- stała błędu
- stała arytmetyczna
- operator porównania
- styl A1
- styl R1C1
- funkcja predefiniowana
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Stosowanie formuł w stylu Excel w Aspose.Slides dla PHP poprzez arkusze wykresów Java i automatyzację raportów w plikach PPT i PPTX."
---
## **Przegląd**

Arkusz wykresu jest źródłem danych stojącym za wykresem w prezentacji. Przechowuje on nazwy kategorii i serii oraz wartości liczbowe wyświetlane na wykresie. W Aspose.Slides ten arkusz jest dostępny za pośrednictwem skoroszytu danych wykresu, co umożliwia programowe operowanie danymi wykresu.

Ten artykuł wyjaśnia, jak używać formuł arkusza w danych wykresu, aby wartości komórek mogły być obliczane i aktualizowane automatycznie zamiast wprowadzania ich ręcznie. Pokazuje, jak przypisywać formuły, używać zarówno odwołań w stylu A1, jak i R1C1, przeliczać formuły skoroszytu oraz pracować z obsługiwanymi stałymi, operatorami, odwołaniami do komórek i predefiniowanymi funkcjami dostępnymi dla arkuszy wykresów w prezentacjach.

## **O formułach arkusza wykresu w prezentacjach**
**Chart spreadsheet** (lub arkusz wykresu) w prezentacji jest źródłem danych wykresu. Arkusz wykresu zawiera dane, które są graficznie przedstawiane na wykresie. Gdy tworzysz wykres w PowerPoint, arkusz powiązany z tym wykresem jest automatycznie tworzony. Arkusz wykresu jest tworzony dla wszystkich typów wykresów: wykres liniowy, słupkowy, promieniowy, kołowy itp. Aby zobaczyć arkusz wykresu w PowerPoint, należy dwukrotnie kliknąć wykres:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Arkusz wykresu zawiera nazwy elementów wykresu (Nazwa kategorii: *Category1*, Nazwa serii) oraz tabelę z danymi liczbowymi odpowiednimi dla tych kategorii i serii. Domyślnie, gdy tworzysz nowy wykres, dane arkusza wykresu są ustawiane na domyślne wartości. Następnie możesz ręcznie zmienić dane arkusza w arkuszu kalkulacyjnym.

Zazwyczaj wykres przedstawia skomplikowane dane (np. analizy finansowe, analizy naukowe), posiadające komórki obliczane na podstawie wartości w innych komórkach lub z innych danych dynamicznych. Ręczne obliczanie wartości komórki i wprowadzanie jej na stałe utrudnia późniejsze zmiany. Jeśli zmienisz wartość określonej komórki, wszystkie zależne od niej komórki również będą wymagały aktualizacji. Co więcej, dane w tabeli mogą zależeć od danych z innych tabel, tworząc złożony schemat danych w prezentacji, który wymaga łatwej i elastycznej aktualizacji.

**Chart spreadsheet formula** w prezentacji jest wyrażeniem służącym do automatycznego obliczania i aktualizacji danych arkusza wykresu. Formuła arkusza definiuje logikę obliczania danych dla określonej komórki lub zestawu komórek. Formuła arkusza to formuła matematyczna lub logiczna, wykorzystująca: odwołania do komórek, funkcje matematyczne, operatory logiczne, operatory arytmetyczne, funkcje konwersji, stałe tekstowe itp. Definicja formuły jest zapisywana w komórce, a ta komórka nie zawiera prostej wartości. Formuła arkusza oblicza wartość i zwraca ją, po czym wartość ta jest przypisywana do komórki. Formuły arkusza wykresu w prezentacjach są w rzeczywistości takie same jak formuły Excela i obsługują te same domyślne funkcje, operatory i stałe.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/php-java/) arkusz wykresu jest reprezentowany przez metodę
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#getChartDataWorkbook) typu
[**ChartDataWorkbook**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/).
Formuła arkusza może być przypisywana i zmieniana metodą
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula).
W Aspose.Slides obsługiwane są następujące funkcje formuł:
- Stałe logiczne
- Stałe liczbowe
- Stałe tekstowe
- Stałe błędów
- Operatory arytmetyczne
- Operatory porównania
- Odwołania do komórek w stylu A1
- Odwołania do komórek w stylu R1C1
- Predefiniowane funkcje

Typowo, arkusze przechowują ostatnie obliczone wartości formuł. Jeśli po załadowaniu prezentacji dane wykresu nie zostały zmienione, metoda [**ChartDataCell::getValue**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#getValue) zwraca te wartości podczas odczytu. Jednak jeśli dane w arkuszu zostały zmienione, podczas odczytu wartości zostaje zgłoszony [**CellUnsupportedDataException**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/CellUnsupportedDataException) z powodu nieobsługiwanych formuł. Dzieje się tak, ponieważ po pomyślnym sparsowaniu formuł ustalane są zależności komórek i poprawność ostatnich wartości. Jeśli formuła nie może być sparsowana, poprawność wartości komórki nie może być zagwarantowana.

## **Dodaj formułę arkusza wykresu do prezentacji**
Najpierw dodaj wykres do pierwszego slajdu nowej prezentacji za pomocą 
[ShapeCollection::addChart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addChart).
Arkusz wykresu jest tworzony automatycznie i można go uzyskać metodą 
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Zapiszmy kilka wartości w komórkach przy użyciu metody [**ChartDataCell::setValue**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setValue) typu **Object**, co oznacza, że możesz ustawić dowolną wartość:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Teraz, aby zapisać formułę w komórce, możesz użyć metody 
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula).

*Uwaga*: metoda [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setFormula) służy do ustawiania odwołań do komórek w stylu A1.

Aby ustawić formułę w stylu R1C1, możesz użyć metody [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

Następnie, jeśli spróbujesz odczytać wartości z komórek B2 i C2, zostaną one obliczone:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1
```

## **Stałe logiczne**
Możesz używać stałych logicznych, takich jak *FALSE* i *TRUE*, w formułach komórek:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// wartość zawiera wartość logiczną "false"
```

## **Stałe liczbowe**
Liczby mogą być używane w notacji zwykłej lub naukowej do tworzenia formuł arkusza wykresu:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Stałe tekstowe**
Stała łańcuchowa (lub literał) jest określoną wartością używaną taką jaka jest i nie ulega zmianie. Stałe tekstowe mogą być: datami, tekstami, liczbami itp.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Stałe błędów**
Czasami nie jest możliwe obliczenie wyniku przez formułę. W takim przypadku w komórce wyświetlany jest kod błędu zamiast jej wartości. Każdy typ błędu ma określony kod:
- #DIV/0! – formuła próbuje podzielić przez zero.
- #GETTING_DATA – może być wyświetlony w komórce, gdy jej wartość jest jeszcze obliczana.
- #N/A – brak informacji lub niedostępne. Przyczynami mogą być: komórki użyte w formule są puste, dodatkowy znak spacji, literówka itp.
- #NAME? – nie można znaleźć określonej komórki lub innego obiektu formuły po nazwie.
- #NULL! – może wystąpić, gdy w formule jest błąd, np. (,) lub znak spacji zamiast dwukropka (:).
- #NUM! – liczba w formule może być nieprawidłowa, zbyt duża lub zbyt mała itp.
- #REF! – nieprawidłowe odwołanie do komórki.
- #VALUE! – nieoczekiwany typ wartości. Na przykład, wartość tekstowa w komórce numerycznej.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// wartość zawiera ciąg "#DIV/0!"


```

## **Operatory arytmetyczne**
Możesz używać wszystkich operatorów arytmetycznych w formułach arkusza wykresu:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|+ (plus sign)|Dodawanie lub znak plus jedynkowy|2 + 3|
|- (minus sign)|Odejmowanie lub negacja|2 - 3<br>-3|
|* (asterisk)|Mnożenie|2 * 3|
|/ (forward slash)|Dzielenie|2 / 3|
|% (percent sign)|Procent|30%|
|^ (caret)|Potęgowanie|2 ^ 3|

*Uwaga*: Aby zmienić kolejność obliczeń, otocz część formuły, którą chcesz obliczyć najpierw, nawiasami.

## **Operatory porównania**
Możesz porównywać wartości komórek przy użyciu operatorów porównania. Gdy dwa wartości są porównywane za pomocą tych operatorów, wynik jest wartością logiczną *TRUE* lub FALSE:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|= (equal sign)|Równe|A2 = 3|
|<> (not equal sign)|Nie równe|A2 <> 3|
|> (greater than sign)|Większe niż|A2 > 3|
|>= (greater than or equal to sign)|Większe lub równe|A2 >= 3|
|< (less than sign)|Mniejsze niż|A2 < 3|
|<= (less than or equal to sign)|Mniejsze lub równe|A2 <= 3|

## **Odwołania do komórek w stylu A1**
**Odwołania do komórek w stylu A1** są używane w arkuszach, w których kolumna ma literowy identyfikator (np. "*A*”), a wiersz ma numeryczny identyfikator (np. "*1*”). Odwołania w stylu A1 mogą być używane w następujący sposób:

|**Odwołanie do komórki**|**Przykład**|||
| :- | :- | :- | :- |
||Absolutne|Względne|Mieszane|
|Komórka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Wiersz|$2:$2|2:2|-|
|Kolumna|$A:$A|A:A|-|
|Zakres|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Oto przykład użycia odwołania w stylu A1 w formule:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **Odwołania do komórek w stylu R1C1**
**Odwołania do komórek w stylu R1C1** są używane w arkuszach, w których zarówno wiersz, jak i kolumna mają numeryczne identyfikatory. Odwołania w stylu R1C1 mogą być używane w następujący sposób:

|**Odwołanie do komórki**|**Przykład**|||
| :- | :- | :- | :- |
||Absolutne|Względne|Mieszane|
|Komórka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Wiersz|R2|R[2]|-|
|Kolumna|C3|C[3]|-|
|Zakres|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Oto przykład użycia odwołania w stylu R1C1 w formule:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Predefiniowane funkcje**
Istnieją predefiniowane funkcje, które można używać w formułach w celu uproszczenia ich implementacji. Funkcje te obejmują najczęściej używane operacje, takie jak:
- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Czy pliki Excel zewnętrzne są obsługiwane jako źródło danych dla wykresu z formułami?**

Tak. Aspose.Slides obsługuje zewnętrzne skoroszyty jako [źródło danych wykresu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatasourcetype/), co pozwala używać formuł z pliku XLSX spoza prezentacji.

**Czy formuły wykresu mogą odwoływać się do arkuszy w tym samym skoroszycie po nazwie arkusza?**

Tak. Formuły korzystają ze standardowego modelu odwołań Excela, więc możesz odwoływać się do innych arkuszy w tym samym skoroszycie lub w zewnętrznym skoroszycie. W przypadku odwołań zewnętrznych należy podać ścieżkę i nazwę skoroszytu, używając składni Excela.