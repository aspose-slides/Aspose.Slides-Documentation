---
title: Zastosowanie formuł arkusza wykresu w prezentacjach na Androidzie
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/androidjava/chart-worksheet-formulas/
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
- Android
- Java
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w Aspose.Slides dla Androida za pomocą arkuszy wykresów w Javie i automatyzuj raporty w plikach PPT i PPTX."
---
## **Przegląd**

Arkusz wykresu jest źródłem danych stojącym za wykresem w prezentacji. Przechowuje nazwy kategorii i serii wraz z wartościami liczbowymi wyświetlanymi na wykresie. W Aspose.Slides arkusz ten jest dostępny za pośrednictwem skoroszytu danych wykresu, co umożliwia programowe operowanie danymi wykresu.

Ten artykuł wyjaśnia, jak używać formuł arkusza w danych wykresu, aby wartości komórek były obliczane i aktualizowane automatycznie zamiast wpisywania ich ręcznie. Pokazuje, jak przypisywać formuły, używać zarówno odwołań w stylu A1, jak i R1C1, przeliczać formuły skoroszytu oraz pracować z obsługiwanymi stałymi, operatorami, odwołaniami do komórek i predefiniowanymi funkcjami dostępnymi dla arkuszy wykresów w prezentacjach.

## **O formułach arkusza wykresu w prezentacjach**
**Arkusz wykresu** (lub arkusz wykresu) w prezentacji jest źródłem danych wykresu. Arkusz wykresu zawiera dane, które są reprezentowane na wykresie w formie graficznej. Gdy tworzysz wykres w PowerPoint, arkusz powiązany z tym wykresem jest tworzony automatycznie. Arkusz wykresu tworzony jest dla wszystkich typów wykresów: wykresu liniowego, słupkowego, sunburst, kołowego itp. Aby zobaczyć arkusz wykresu w PowerPoint, należy dwukrotnie kliknąć wykres:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Arkusz wykresu zawiera nazwy elementów wykresu (Nazwa kategorii: *Category1*, Nazwa serii) oraz tabelę z danymi liczbowymi odpowiadającymi tym kategoriom i seriom. Domyślnie, gdy tworzysz nowy wykres – dane arkusza wykresu są ustawione na domyślne wartości. Następnie możesz ręcznie zmieniać dane arkusza w arkuszu kalkulacyjnym.

Zazwyczaj wykres przedstawia złożone dane (np. analizy finansowe, analizy naukowe), posiadające komórki obliczane na podstawie wartości w innych komórkach lub innych dynamicznych danych. Ręczne obliczanie wartości komórki i wpisywanie jej na stałe utrudnia późniejsze zmiany. Jeśli zmienisz wartość konkretnej komórki, wszystkie komórki od niej zależne będą wymagały aktualizacji. Co więcej, dane tabeli mogą zależeć od danych z innych tabel, tworząc złożony schemat danych prezentacji, który wymaga łatwej i elastycznej aktualizacji.

**Formuła arkusza wykresu** w prezentacji jest wyrażeniem służącym do automatycznego obliczania i aktualizowania danych arkusza wykresu. Formuła arkusza definiuje logikę obliczeń danych dla określonej komórki lub zestawu komórek. Formuła arkusza jest formułą matematyczną lub logiczną, wykorzystującą: odwołania do komórek, funkcje matematyczne, operatory logiczne, operatory arytmetyczne, funkcje konwersji, stałe tekstowe itp. Definicja formuły jest zapisywana w komórce, a ta komórka nie zawiera prostej wartości. Formuła arkusza oblicza wartość i zwraca ją, po czym wartość ta jest przypisywana do komórki. Formuły arkusza wykresu w prezentacjach są w rzeczywistości takie same jak formuły Excel i obsługują te same domyślne funkcje, operatory i stałe.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/androidjava/) arkusz wykresu jest reprezentowany przez metodę [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) typu [**IChartDataWorkbook**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataWorkbook). Formułę arkusza można przypisać i zmienić za pomocą metody [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-). W Aspose.Slides obsługiwane są następujące funkcje formuł:

- Stałe logiczne
- Stałe liczbowe
- Stałe tekstowe
- Stałe błędów
- Operatory arytmetyczne
- Operatory porównania
- Odwołania komórek w stylu A1
- Odwołania komórek w stylu R1C1
- Predefiniowane funkcje


Typowo arkusze przechowują ostatnie obliczone wartości formuł. Jeśli po załadowaniu prezentacji dane wykresu nie zostały zmienione – metoda [**IChartDataCell.getValue**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataCell#getValue--) zwraca te wartości przy odczycie. Jednakże, jeśli dane arkusza zostały zmienione, przy odczycie właściwość **ChartDataCell.Value** wyrzuca [**CellUnsupportedDataException**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/CellUnsupportedDataException) dla nieobsługiwanych formuł. Dzieje się tak, ponieważ po pomyślnym sparsowaniu formuł określane są zależności komórek i poprawność ostatnich wartości. Jeśli formuła nie może zostać sparsowana, poprawność wartości komórki nie może być zagwarantowana.

## **Dodanie formuły arkusza wykresu do prezentacji**
Najpierw dodaj wykres do pierwszego slajdu nowej prezentacji przy pomocy [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). Arkusz wykresu zostaje utworzony automatycznie i można go uzyskać za pomocą metody [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--):

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

Zapiszmy kilka wartości w komórkach przy pomocy właściwości [**IChartDataCell.setValue**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) typu **Object**, co oznacza, że możesz ustawić dowolną wartość:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Aby zapisać formułę w komórce, możesz użyć metody [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-):

*Uwaga*: metoda [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) służy do ustawiania odwołań w stylu A1.

Aby ustawić odwołanie komórki w stylu [R1C1Formula](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--), możesz użyć metody [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Następnie, jeśli odczytasz wartości z komórek B2 i C2, zostaną one obliczone:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Stałe logiczne**
Możesz używać stałych logicznych takich jak *FALSE* i *TRUE* w formułach komórek:

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

## **Stałe tekstowe**
Stała tekstowa (lub literał) to konkretna wartość używana wprost i niezmienna. Stałe tekstowe mogą być: daty, teksty, liczby itp.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Stałe błędów**
Czasami nie jest możliwe obliczenie wyniku formuły. W takim przypadku w komórce wyświetlany jest kod błędu zamiast wartości. Każdy typ błędu ma określony kod:

- #DIV/0! – formuła próbuje dzielić przez zero.
- #GETTING_DATA – może być wyświetlony w komórce, gdy jej wartość jest jeszcze obliczana.
- #N/A – brak informacji lub nie jest dostępna. Przyczyny mogą być: puste komórki użyte w formule, dodatkowy znak spacji, literówka itp.
- #NAME? – nie można znaleźć określonej komórki lub innego obiektu formuły po nazwie.
- #NULL! – może się pojawić, gdy w formule jest błąd, np. (,) lub znak spacji zamiast dwukropka (:).
- #NUM! – liczba w formule może być nieprawidłowa, za długa lub za mała.
- #REF! – nieprawidłowe odwołanie do komórki.
- #VALUE! – nieoczekiwany typ wartości. Na przykład, wartość tekstowa w komórce liczbowej.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // wartość zawiera ciąg "#DIV/0!"
```

## **Operatory arytmetyczne**
Możesz używać wszystkich operatorów arytmetycznych w formułach arkusza wykresu:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|+ (plus)|Dodawanie lub znak plus jedynkowy|2 + 3|
|- (minus)|Odejmowanie lub negacja|2 - 3<br>-3|
|* (gwiazdka)|Mnożenie|2 * 3|
|/ (ukośnik)|Dzielenie|2 / 3|
|% (procent)|Procent|30%|
|^ (daszek)|Potęgowanie|2 ^ 3|

*Uwaga*: aby zmienić kolejność obliczeń, otocz część formuły, którą chcesz wykonać najpierw, nawiasami.

## **Operatory porównania**
Możesz porównywać wartości komórek za pomocą operatorów porównania. Gdy dwa wartości są porównywane przy użyciu tych operatorów, wynik jest wartością logiczną *TRUE* lub *FALSE*:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|= (znak równości)|Równe|A2 = 3|
|<> (nie równe)|Nie równe|A2 <> 3|
|> (większy niż)|Większy niż|A2 > 3|
|>= (większy lub równy)|Większy lub równy|A2 >= 3|
|< (mniejszy niż)|Mniejszy niż|A2 < 3|
|<= (mniejszy lub równy)|Mniejszy lub równy|A2 <= 3|

## **Odwołania komórek w stylu A1**
**Odwołania komórek w stylu A1** są używane w arkuszach, w których kolumna ma literowy identyfikator (np. "*A*"), a wiersz ma numeryczny identyfikator (np. "*1*"). Odwołania w stylu A1 mogą być używane w następujący sposób:

|**Odwołanie**|**Przykład**| | |
| :- | :- | :- | :- |
| |Absolutne|Względne|Mieszane|
|Komórka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Wiersz|$2:$2|2:2|-|
|Kolumna|$A:$A|A:A|-|
|Zakres|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Przykład użycia odwołania w stylu A1 w formule:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Odwołania komórek w stylu R1C1**
**Odwołania komórek w stylu R1C1** są używane w arkuszach, w których zarówno wiersz, jak i kolumna mają identyfikatory liczbowe. Odwołania w stylu R1C1 mogą być używane w następujący sposób:

|**Odwołanie**|**Przykład**| | |
| :- | :- | :- | :- |
| |Absolutne|Względne|Mieszane|
|Komórka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Wiersz|R2|R[2]|-|
|Kolumna|C3|C[3]|-|
|Zakres|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Przykład użycia odwołania w stylu R1C1 w formule:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Predefiniowane funkcje**
Istnieją predefiniowane funkcje, które mogą być używane w formułach w celu uproszczenia ich implementacji. Funkcje te kapsułują najczęściej używane operacje, takie jak:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (system dat 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (forma odwołania)
- LOOKUP (forma wektorowa)
- MATCH (forma wektorowa)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Czy zewnętrzne pliki Excel są obsługiwane jako źródło danych dla wykresu z formułami?**

Tak. Aspose.Slides obsługuje zewnętrzne skoroszyty jako [źródło danych wykresu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chartdatasourcetype/), co pozwala używać formuł z pliku XLSX poza prezentacją.

**Czy formuły wykresu mogą odwoływać się do arkuszy w tym samym skoroszycie po nazwie arkusza?**

Tak. Formuły podążają za standardowym modelem odwołań Excel, więc możesz odwoływać się do innych arkuszy w tym samym skoroszycie lub w skoroszycie zewnętrznym. W przypadku odwołań zewnętrznych należy podać ścieżkę i nazwę skoroszytu używając składni Excel.