---
title: Zastosuj formuły arkusza wykresu w prezentacjach przy użyciu Java
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/java/chart-worksheet-formulas/
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
- Java
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w arkuszach wykresów Aspose.Slides dla Java i automatyzuj raporty w plikach PPT i PPTX."
---
## **Przegląd**

Arkusz wykresu jest źródłem danych dla wykresu w prezentacji. Przechowuje on nazwy kategorii i serii wraz z wartościami liczbowymi wyświetlanymi na wykresie. W Aspose.Slides ten arkusz jest dostępny za pośrednictwem skoroszytu danych wykresu, co umożliwia programowe operowanie danymi wykresu.

Ten artykuł wyjaśnia, jak używać formuł arkusza w danych wykresu, aby wartości komórek mogły być obliczane i aktualizowane automatycznie zamiast wprowadzania ich ręcznie. Pokazuje, jak przypisywać formuły, używać zarówno odwołań w stylu A1, jak i R1C1, przeliczać formuły skoroszytu oraz pracować z obsługiwanymi stałymi, operatorami, odwołaniami do komórek i predefiniowanymi funkcjami dostępnymi dla arkuszy wykresów w prezentacjach.

## **O formułach arkusza wykresu w prezentacjach**
**Arkusz wykresu** (lub arkusz wykresu) w prezentacji jest źródłem danych wykresu. Arkusz wykresu zawiera dane, które są przedstawiane na wykresie w formie graficznej. Gdy tworzysz wykres w PowerPoint, arkusz powiązany z tym wykresem jest tworzony automatycznie. Arkusz wykresu jest tworzony dla wszystkich typów wykresów: wykresu liniowego, słupkowego, słonecznika, kołowego itp. Aby zobaczyć arkusz wykresu w PowerPoint, należy dwukrotnie kliknąć wykres:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Arkusz wykresu zawiera nazwy elementów wykresu (Nazwa kategorii: *Category1*, Nazwa serii) oraz tabelę z danymi liczbowymi odpowiadającymi tym kategoriom i seriach. Domyślnie, gdy tworzysz nowy wykres – dane arkusza wykresu są ustawiane na wartości domyślne. Następnie możesz ręcznie zmienić dane arkusza w arkuszu.

Zazwyczaj wykres reprezentuje złożone dane (np. analizy finansowe, analizy naukowe), posiadając komórki obliczane na podstawie wartości w innych komórkach lub innych dynamicznych danych. Ręczne obliczanie wartości komórki i wprowadzanie jej na stałe utrudnia późniejsze zmiany. Jeśli zmienisz wartość konkretnej komórki, wszystkie komórki od niej zależne również będą wymagały aktualizacji. Ponadto dane tabel mogą zależeć od danych z innych tabel, tworząc złożony schemat danych prezentacji, który wymaga łatwej i elastycznej aktualizacji.

**Formuła arkusza wykresu** w prezentacji jest wyrażeniem służącym do automatycznego obliczania i aktualizacji danych arkusza wykresu. Formuła arkusza określa logikę obliczania danych dla określonej komórki lub zestawu komórek. Formuła arkusza jest formułą matematyczną lub logiczną, wykorzystującą: odwołania do komórek, funkcje matematyczne, operatory logiczne, operatory arytmetyczne, funkcje konwersji, stałe łańcuchowe itp. Definicja formuły zapisywana jest w komórce, a komórka nie zawiera prostej wartości. Formuła arkusza oblicza wartość i zwraca ją, po czym wartość ta jest przypisywana do komórki. Formuły arkusza wykresu w prezentacjach są w rzeczywistości takie same jak formuły Excel i obsługują te same domyślne funkcje, operatory i stałe.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/java/) arkusz wykresu jest reprezentowany przy pomocy metody 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartData#getChartDataWorkbook--) typu 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataWorkbook). 
Formuła arkusza może być przypisywana i zmieniana przy użyciu metody 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-). 
W Aspose.Slides obsługiwana jest następująca funkcjonalność dla formuł:
- Stałe logiczne
- Stałe liczbowe
- Stałe łańcuchowe
- Stałe błędów
- Operatory arytmetyczne
- Operatory porównania
- Odwołania do komórek w stylu A1
- Odwołania do komórek w stylu R1C1
- Funkcje predefiniowane

Typowo arkusze przechowują ostatnio obliczone wartości formuł. Jeśli po załadowaniu prezentacji dane wykresu nie zostały zmienione – metoda [**IChartDataCell.getValue**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataCell#getValue--) zwraca te wartości podczas odczytu. Jednak jeśli dane arkusza zostały zmienione, podczas odczytu właściwość **ChartDataCell.Value** wyrzuca [**CellUnsupportedDataException**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/CellUnsupportedDataException) dla nieobsługiwanych formuł. Dzieje się tak, ponieważ po pomyślnym parsowaniu formuł ustalane są zależności komórek i weryfikowana jest poprawność ostatnich wartości. Jeśli formuła nie może zostać sparsowana, nie można zagwarantować poprawności wartości komórki.

## **Dodaj formułę arkusza wykresu do prezentacji**
Najpierw dodaj wykres do pierwszego slajdu nowej prezentacji przy użyciu 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
Arkusz wykresu jest tworzony automatycznie i można go uzyskać za pomocą metody 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartData#getChartDataWorkbook--):

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Zapiszmy kilka wartości w komórkach przy użyciu właściwości 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) typu **Object**, co oznacza, że możesz ustawić dowolną wartość:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Aby zapisać formułę w komórce, możesz użyć metody 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-):

*Uwaga*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metoda jest używana do ustawiania odwołań do komórek w stylu A1.

Aby ustawić odwołanie do komórki [R1C1Formula](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataCell#getR1C1Formula--), możesz użyć metody [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Następnie, jeśli spróbujesz odczytać wartości z komórek B2 i C2, zostaną one obliczone:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Stałe logiczne**
Możesz używać stałych logicznych, takich jak *FALSE* i *TRUE*, w formułach komórek:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // wartość zawiera wartość logiczną "false"
```

## **Stałe liczbowe**
Liczby mogą być używane w notacji zwykłej lub naukowej do tworzenia formuł arkusza wykresu:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Stałe łańcuchowe**
Stała łańcuchowa (lub literał) jest określoną wartością używaną wprost i niezmienną. Stałe łańcuchowe mogą być: datami, tekstami, liczbami itp.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Stałe błędów**
Czasami nie jest możliwe obliczenie wyniku za pomocą formuły. W takim przypadku w komórce wyświetlany jest kod błędu zamiast jej wartości. Każdy typ błędu ma określony kod:
- #DIV/0! – formuła próbuje dzielić przez zero.
- #GETTING_DATA – może być wyświetlane w komórce, gdy jej wartość jest nadal obliczana.
- #N/A – brak informacji lub niedostępne. Przyczyną może być: pusta komórka użyta w formule, dodatkowy znak spacji, błąd literowy itp.
- #NAME? – nie można znaleźć określonej komórki lub innego obiektu formuły po nazwie.
- #NULL! – może wystąpić, gdy w formule jest błąd, np. (,) lub użyto spacji zamiast dwukropka (:).
- #NUM! – liczba w formule może być nieprawidłowa, za długa lub za mała itp.
- #REF! – nieprawidłowe odwołanie do komórki.
- #VALUE! – nieoczekiwany typ wartości. Na przykład, wartość łańcuchowa ustawiona w komórce liczbowej.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // wartość zawiera ciąg "#DIV/0!"
```

## **Operatory arytmetyczne**
Możesz używać wszystkich operatorów arytmetycznych w formułach arkusza wykresu:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|+ (plus sign)|Dodawanie lub znak unarny plus|2 + 3|
|- (minus sign)|Odejmowanie lub negacja|2 - 3<br>-3|
|* (asterisk)|Mnożenie|2 * 3|
|/ (forward slash)|Dzielenie|2 / 3|
|% (percent sign)|Procent|30%|
|^ (caret)|Potęgowanie|2 ^ 3|

*Uwaga*: Aby zmienić kolejność obliczeń, umieść w nawiasach część formuły, którą należy obliczyć jako pierwszą.

## **Operatory porównania**
Możesz porównywać wartości komórek przy użyciu operatorów porównania. Gdy dwie wartości są porównywane za pomocą tych operatorów, wynikiem jest wartość logiczna *TRUE* lub *FALSE*:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|= (equal sign)|Równe|A2 = 3|
|<> (not equal sign)|Nie równe|A2 <> 3|
|> (greater than sign)|Większe niż|A2 > 3|
|>= (greater than or equal to sign)|Większe lub równe|A2 >= 3|
|< (less than sign)|Mniejsze niż|A2 < 3|
|<= (less than or equal to sign)|Mniejsze lub równe|A2 <= 3|

## **Odwołania do komórek w stylu A1**
**Odwołania do komórek w stylu A1** są używane w arkuszach, gdzie kolumna ma literowy identyfikator (np. "*A*"), a wiersz ma numeryczny identyfikator (np. "*1*"). Odwołania w stylu A1 można stosować w następujący sposób:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Bezwzględne|Względne|Mieszane|
|Komórka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Wiersz|$2:$2|2:2|-|
|Kolumna|$A:$A|A:A|-|
|Zakres|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Poniżej przykład użycia odwołania do komórki w stylu A1 w formule:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Odwołania do komórek w stylu R1C1**
**Odwołania do komórek w stylu R1C1** są używane w arkuszach, gdzie zarówno wiersz, jak i kolumna mają numeryczne identyfikatory. Odwołania w stylu R1C1 można stosować w następujący sposób:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Bezwzględne|Względne|Mieszane|
|Komórka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Wiersz|R2|R[2]|-|
|Kolumna|C3|C[3]|-|
|Zakres|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Poniżej przykład użycia odwołania do komórki w stylu A1 w formule:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Funkcje predefiniowane**
Istnieją funkcje predefiniowane, które można używać w formułach w celu uproszczenia ich implementacji. Funkcje te kapsułują najczęściej używane operacje, takie jak:
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

Tak. Aspose.Slides obsługuje zewnętrzne skoroszyty jako [źródło danych wykresu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdatasourcetype/), co umożliwia używanie formuł z pliku XLSX znajdującego się poza prezentacją.

**Czy formuły wykresu mogą odwoływać się do arkuszy w tym samym skoroszycie po nazwie arkusza?**

Tak. Formuły stosują standardowy model odwołań Excel, więc możesz odwoływać się do innych arkuszy w tym samym skoroszycie lub do skoroszytu zewnętrznego. W przypadku odwołań zewnętrznych podaj ścieżkę i nazwę skoroszytu, używając składni Excel.