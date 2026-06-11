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
- źródło danych
- stała logiczna
- stała liczbowa
- stała łańcuchowa
- stała błędu
- stała arytmetyczna
- operator porównania
- styl A1
- styl R1C1
- funkcja predefiniowana
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w Aspose.Slides dla Node.js za pomocą arkuszy wykresów Java i automatyzuj raporty w plikach PPT i PPTX przy użyciu JavaScript."
---
## **Przegląd**

Arkusz wykresu jest źródłem danych dla wykresu w prezentacji. Przechowuje nazwy kategorii i serii wraz z wartościami liczbowymi wyświetlanymi na wykresie. W Aspose.Slides arkusz ten jest dostępny za pośrednictwem skoroszytu danych wykresu, co pozwala na programowe operowanie danymi wykresu.

Ten artykuł wyjaśnia, jak używać formuł arkusza w danych wykresu, aby wartości komórek były obliczane i aktualizowane automatycznie zamiast wprowadzania ich ręcznie. Pokazuje, jak przypisywać formuły, używać odwołań w stylu A1 i R1C1, przeliczać formuły skoroszytu oraz pracować z obsługiwanymi stałymi, operatorami, odwołaniami do komórek i funkcjami predefiniowanymi dostępnymi dla arkuszy wykresów w prezentacjach.

## **O formule arkusza wykresu w prezentacji**
**Chart spreadsheet** (lub arkusz wykresu) w prezentacji jest źródłem danych wykresu. Arkusz wykresu zawiera dane, które są graficznie przedstawiane na wykresie. Gdy tworzysz wykres w PowerPoint, arkusz powiązany z tym wykresem jest tworzony automatycznie. Arkusz wykresu jest tworzony dla wszystkich typów wykresów: wykresu liniowego, słupkowego, sunburst, kołowego itp. Aby zobaczyć arkusz wykresu w PowerPoint, należy dwukrotnie kliknąć wykres:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Arkusz wykresu zawiera nazwy elementów wykresu (Category Name: *Category1*, Serie Name) oraz tabelę z danymi liczbowymi odpowiednimi dla tych kategorii i serii. Domyślnie, po utworzeniu nowego wykresu – dane arkusza wykresu są ustawione na dane domyślne. Następnie można ręcznie zmienić dane w arkuszu.

Zazwyczaj wykres przedstawia skomplikowane dane (np. analizy finansowe, analizy naukowe), posiadając komórki obliczane na podstawie wartości w innych komórkach lub z innych dynamicznych danych. Ręczne obliczanie wartości komórki i wpisywanie jej na stałe utrudnia późniejsze zmiany. Jeśli zmienisz wartość określonej komórki, wszystkie komórki od niej zależne również będą wymagały aktualizacji. Ponadto dane w tabeli mogą zależeć od danych z innych tabel, tworząc złożony schemat danych prezentacji, który wymaga łatwej i elastycznej aktualizacji.

**Chart spreadsheet formula** w prezentacji to wyrażenie służące do automatycznego obliczania i aktualizowania danych arkusza wykresu. Formuła arkusza definiuje logikę obliczania danych dla określonej komórki lub zestawu komórek. Formuła arkusza jest formułą matematyczną lub logiczną, wykorzystującą: odwołania do komórek, funkcje matematyczne, operatory logiczne, operatory arytmetyczne, funkcje konwersji, stałe łańcuchowe itp. Definicja formuły jest zapisana w komórce, a ta komórka nie zawiera prostej wartości. Formuła arkusza oblicza wartość i zwraca ją, a następnie wartość ta jest przypisywana do komórki. Formuły arkusza wykresu w prezentacjach są w rzeczywistości takie same jak formuły Excel i obsługują te same domyślne funkcje, operatory i stałe.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/nodejs-java/) arkusz wykresu jest reprezentowany metodą [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) typu [**ChartDataWorkbook**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataWorkbook). Formuła arkusza może być przypisana i zmieniona metodą [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-). W Aspose.Slides obsługiwane są następujące funkcjonalności formuł:

- Stałe logiczne
- Stałe liczbowe
- Stałe łańcuchowe
- Stałe błędów
- Operatory arytmetyczne
- Operatory porównania
- Odwołania do komórek w stylu A1
- Odwołania do komórek w stylu R1C1
- Funkcje predefiniowane

Zwykle arkusze przechowują ostatnie obliczone wartości formuł. Jeśli po załadowaniu prezentacji dane wykresu nie zostały zmienione – metoda [**ChartDataCell.getValue**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataCell#getValue--) zwraca te wartości podczas odczytu. Jednak jeśli dane arkusza zostały zmienione, przy odczycie właściwości **ChartDataCell.Value** zostaje rzucony wyjątek [**CellUnsupportedDataException**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CellUnsupportedDataException) dla nieobsługiwanych formuł. Dzieje się tak, ponieważ po pomyślnym parsowaniu formuł określane są zależności komórek i poprawność ostatnich wartości. Jeśli formuła nie może być sparsowana, nie można zagwarantować poprawności wartości komórki.

## **Dodaj formułę arkusza wykresu do prezentacji**
Najpierw dodaj wykres do pierwszego slajdu nowej prezentacji metodą [ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-). Arkusz wykresu jest tworzony automatycznie i można go uzyskać metodą [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Zapiszmy kilka wartości w komórkach przy pomocy właściwości [**ChartDataCell.setValue**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) typu **Object**, co oznacza, że możesz ustawić dowolną wartość:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

Aby zapisać formułę w komórce, możesz użyć metody [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-):

*Note*: metoda [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) służy do ustawiania odwołań w stylu A1.

Aby ustawić odwołanie [R1C1Formula](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) możesz użyć metody [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-):

Następnie, jeśli odczytasz wartości z komórek B2 i C2, zostaną one obliczone:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **Stałe logiczne**
Możesz używać stałych logicznych, takich jak *FALSE* i *TRUE*, w formułach komórek:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// wartość zawiera wartość logiczną "false"
```

## **Stałe liczbowe**
Liczby mogą być używane w notacji zwykłej lub naukowej do tworzenia formuł arkusza wykresu:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Stałe łańcuchowe**
Stała łańcuchowa (lub literał) to konkretny wartość używana tak, jak jest, i nie zmienia się. Stałe łańcuchowe mogą być: datami, tekstami, liczbami itp.:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Stałe błędów**
Czasami nie jest możliwe obliczenie wyniku formuły. W takim przypadku w komórce wyświetlany jest kod błędu zamiast wartości. Każdy typ błędu ma określony kod:

- #DIV/0! – formuła próbuje dzielić przez zero.
- #GETTING_DATA – może być wyświetlony w komórce, gdy jej wartość jest wciąż obliczana.
- #N/A – brak informacji lub nie są dostępne. Niektóre przyczyny: komórki użyte w formule są puste, dodatkowy znak spacji, literówka, itp.
- #NAME? – nie można znaleźć określonej komórki lub innego obiektu formuły po nazwie.
- #NULL! – może wystąpić, gdy w formule jest błąd, np. (,) lub znak spacji zamiast dwukropka (:).
- #NUM! – liczba w formule może być nieprawidłowa, za długa lub za mała, itp.
- #REF! – nieprawidłowe odwołanie do komórki.
- #VALUE! – nieoczekiwany typ wartości. Na przykład, wartość łańcuchowa ustawiona w komórce numerycznej.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// wartość zawiera ciąg "#DIV/0!"
```

## **Operatory arytmetyczne**
Możesz używać wszystkich operatorów arytmetycznych w formułach arkusza wykresu:

|**Operator** |**Znaczenie** |**Przykład**|
| :- | :- | :- |
|+ (plus sign) |Dodawanie lub plus jedynkowy|2 + 3|
|- (minus sign) |Odejmowanie lub negacja |2 - 3<br>-3|
|* (asterisk)|Mnożenie |2 * 3|
|/ (forward slash)|Dzielenie |2 / 3|
|% (percent sign) |Procent |30%|
|^ (caret) |Potęgowanie |2 ^ 3|

*Note*: Aby zmienić kolejność obliczeń, otocz część formuły nawiasami, która ma być obliczona jako pierwsza.

## **Operatory porównania**
Możesz porównywać wartości komórek przy użyciu operatorów porównania. Gdy dwa wartości są porównywane przy użyciu tych operatorów, wynik jest wartością logiczną *TRUE* lub *FALSE*:

|**Operator** |**Znaczenie** |**Przykład**|
| :- | :- | :- |
|= (equal sign) |Równe |A2 = 3|
|<> (not equal sign) |Nie równe|A2 <> 3|
|> (greater than sign) |Większe niż|A2 > 3|
|>= (greater than or equal to sign)|Większe lub równe|A2 >= 3|
|< (less than sign)|Mniejsze niż|A2 < 3|
|<= (less than or equal to sign)|Mniejsze lub równe|A2 <= 3|

## **Odwołania do komórek w stylu A1**
**Odwołania do komórek w stylu A1** używane są w arkuszach, w których kolumna ma literowy identyfikator (np. "*A*"), a wiersz ma liczbowy identyfikator (np. "*1*"). Odwołania w stylu A1 mogą być używane w następujący sposób:

|**Odwołanie do komórki**|**Przykład**|||
| :- | :- | :- | :- |
||Absolutne |Względne |Mieszane|
|Komórka |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Wiersz |$2:$2 |2:2 |-|
|Kolumna |$A:$A |A:A |-|
|Zakres |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Oto przykład użycia odwołania w stylu A1 w formule:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Odwołania do komórek w stylu R1C1**
**Odwołania do komórek w stylu R1C1** używane są w arkuszach, w których zarówno wiersz, jak i kolumna mają identyfikatory liczbowe. Odwołania w stylu R1C1 mogą być używane w następujący sposób:

|**Odwołanie do komórki**|**Przykład**|||
| :- | :- | :- | :- |
||Absolutne |Względne |Mieszane|
|Komórka |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Wiersz |R2|R[2]|-|
|Kolumna |C3|C[3]|-|
|Zakres |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Oto przykład użycia odwołania w stylu R1C1 w formule:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Funkcje predefiniowane**
Istnieją funkcje predefiniowane, które można używać w formułach w celu uproszczenia ich implementacji. Funkcje te enkapsulują najczęściej używane operacje, takie jak:

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

**Czy zewnętrzne pliki Excel są obsługiwane jako źródło danych dla wykresu z formułami?**

Tak. Aspose.Slides obsługuje zewnętrzne skoroszyty jako [chart's data source](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatasourcetype/), co pozwala używać formuł z pliku XLSX poza prezentacją.

**Czy formuły wykresu mogą odwoływać się do arkuszy w tym samym skoroszycie po nazwie arkusza?**

Tak. Formuły stosują standardowy model odwołań Excel, więc możesz odwoływać się do innych arkuszy w tym samym skoroszycie lub do zewnętrznego skoroszytu. Dla odwołań zewnętrznych podaj ścieżkę i nazwę skoroszytu używając składni Excel.