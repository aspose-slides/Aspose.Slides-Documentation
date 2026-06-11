---
title: Zastosowanie formuł arkusza wykresu w prezentacjach w .NET
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
- .NET
- C#
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w Aspose.Slides dla arkuszy wykresów .NET i automatyzuj raporty w plikach PPT i PPTX."
---
## **Przegląd**

Arkusz wykresu jest źródłem danych stojącym za wykresem w prezentacji. Zawiera nazwy kategorii i serii wraz z wartościami liczbowymi wyświetlanymi w wykresie. W Aspose.Slides ten arkusz jest dostępny poprzez **ChartDataWorkbook** skoroszytu danych wykresu, co umożliwia programowe operowanie danymi wykresu.

Ten artykuł wyjaśnia, jak używać formuł arkusza w danych wykresu, aby wartości komórek mogły być obliczane i aktualizowane automatycznie zamiast wprowadzania ich ręcznie. Pokazuje, jak przypisywać formuły, używać zarówno odniesień w stylu A1, jak i R1C1, przeliczać formuły skoroszytu oraz pracować z obsługiwanymi stałymi, operatorami, odwołaniami do komórek i predefiniowanymi funkcjami dostępnymi dla arkuszy wykresów w prezentacjach.

## **O formułach arkusza wykresu w prezentacjach**
**Arkusz wykresu** (lub arkusz danych wykresu) w prezentacji jest źródłem danych wykresu. Arkusz wykresu zawiera dane, które są przedstawiane na wykresie w formie graficznej. Kiedy tworzysz wykres w PowerPoint, arkusz powiązany z tym wykresem jest tworzony automatycznie. Arkusz wykresu jest tworzony dla wszystkich typów wykresów: wykres liniowy, słupkowy, sunburst, kołowy itp. Aby zobaczyć arkusz wykresu w PowerPoint, należy dwukrotnie kliknąć wykres:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Arkusz wykresu zawiera nazwy elementów wykresu (Nazwa kategorii: *Category1*, Nazwa serii) oraz tabelę z danymi liczbowymi odpowiadającymi tym kategoriom i seriom. Domyślnie, po utworzeniu nowego wykresu – dane arkusza wykresu są ustawione na wartości domyślne. Następnie można ręcznie zmienić dane arkusza w arkuszu.

Zazwyczaj wykres przedstawia skomplikowane dane (np. analizy finansowe, analizy naukowe), posiadając komórki obliczane z wartości w innych komórkach lub z innych dynamicznych danych. Ręczne obliczanie wartości komórki i wpisywanie jej na stałe utrudnia późniejsze zmiany. Jeśli zmienisz wartość określonej komórki, wszystkie zależne od niej komórki również wymagają aktualizacji. Co więcej, dane tabeli mogą zależeć od danych z innych tabel, tworząc złożony schemat danych prezentacji, który wymaga łatwej i elastycznej aktualizacji.

**Formuła arkusza wykresu** w prezentacji jest wyrażeniem służącym do automatycznego obliczania i aktualizacji danych arkusza wykresu. Formuła arkusza definiuje logikę obliczeń danych dla określonej komórki lub zestawu komórek. Formuła arkusza jest formułą matematyczną lub logiczną, wykorzystującą: odwołania do komórek, funkcje matematyczne, operatory logiczne, operatory arytmetyczne, funkcje konwersji, stałe łańcuchowe itp. Definicja formuły jest zapisywana w komórce, a ta komórka nie zawiera prostej wartości. Formuła arkusza oblicza wartość i zwraca ją, a następnie wynik jest przypisywany do komórki. Formuły arkusza wykresu w prezentacjach są właściwie takie same jak formuły Excela i obsługują te same domyślne funkcje, operatory i stałe.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/net/) arkusz wykresu jest reprezentowany przez właściwość 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) typu 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook). 
Formułę arkusza można przypisać i zmienić za pomocą właściwości 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/properties/formula). 
Poniższa funkcjonalność jest obsługiwana dla formuł w Aspose.Slides:

- Stałe logiczne
- Stałe liczbowe
- Stałe łańcuchowe
- Stałe błędów
- Operatory arytmetyczne
- Operatory porównania
- Odwołania do komórek w stylu A1
- Odwołania do komórek w stylu R1C1
- Funkcje predefiniowane



Typowo arkusze przechowują ostatnie wyliczone wartości formuł. Jeśli po załadowaniu prezentacji dane wykresu nie zostały zmienione – właściwość **IChartDataCell.Value** zwraca te wartości podczas odczytu. Jednak jeśli dane arkusza zostały zmienione, odczyt właściwości **ChartDataCell.Value** powoduje rzucony **CellUnsupportedDataException** dla nieobsługiwanych formuł. Dzieje się tak, ponieważ po pomyślnym parsowaniu formuł określane są zależności komórek i poprawność ostatnich wartości. Jeśli formuła nie może być sparsowana, nie można zagwarantować poprawności wartości komórki.

## **Dodanie formuły arkusza wykresu do prezentacji**
Najpierw dodaj wykres z przykładowymi danymi do pierwszego slajdu nowej prezentacji przy użyciu 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/addchart/methods/1). 
Arkusz wykresu jest tworzony automatycznie i można go uzyskać za pomocą właściwości 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook):

``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```

Zapiszmy kilka wartości w komórkach przy użyciu właściwości 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/properties/value) typu **Object**, co oznacza, że możesz ustawić dowolną wartość w tej właściwości:

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

Aby zapisać formułę w komórce, użyj właściwości 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/properties/formula):

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Uwaga*: właściwość [**IChartDataCell.Formula**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/properties/formula) służy do ustawiania odwołań w stylu A1.  

Aby ustawić odwołanie komórki w stylu **R1C1Formula**, użyj właściwości [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula):

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Następnie użyj metody [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas), aby obliczyć wszystkie formuły w skoroszycie i zaktualizować odpowiadające wartości komórek:

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```

## **Stałe logiczne**
Możesz używać stałych logicznych takich jak *FALSE* i *TRUE* w formułach komórek:

## **Stałe liczbowe**
Liczby mogą być używane w notacji zwykłej lub naukowej do tworzenia formuł arkusza wykresu:

## **Stałe łańcuchowe**
Stała łańcuchowa (lub literał) to konkretny wartość używana tak, jak jest, i nie zmienia się. Stałe łańcuchowe mogą być: daty, teksty, liczby itp.:

## **Stałe błędów**
Czasami nie jest możliwe obliczenie wyniku formuły. W takim przypadku w komórce wyświetlany jest kod błędu zamiast wartości. Każdy typ błędu ma określony kod:

- #DIV/0! – formuła próbuje podzielić przez zero.
- #GETTING_DATA – może być wyświetlane w komórce, gdy jej wartość jest jeszcze obliczana.
- #N/A – brak informacji lub nie dostępne. Przyczyny: puste komórki użyte w formule, dodatkowy znak spacji, literówka itp.
- #NAME? – nie można znaleźć określonej komórki lub innego obiektu formuły po nazwie.
- #NULL! – może się pojawić przy błędzie w formule, np. (,) lub znak spacji zamiast dwukropka (:).
- #NUM! – liczba w formule jest nieprawidłowa, zbyt duża lub zbyt mała.
- #REF! – nieprawidłowe odwołanie do komórki.
- #VALUE! – nieoczekiwany typ wartości. Na przykład łańcuch ustawiony w komórce numerycznej.

## **Operatory arytmetyczne**
Możesz używać wszystkich operatorów arytmetycznych w formułach arkusza wykresu:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|+ (plus)|Dodawanie lub jedynkowy plus|2 + 3|
|- (minus)|Odejmowanie lub negacja|2 - 3<br>-3|
|* (gwiazdka)|Mnożenie|2 * 3|
|/ (ukośnik)|Dzielenie|2 / 3|
|% (procent)|Procent|30%|
|^ (daszek)|Potęgowanie|2 ^ 3|

*Uwaga*: aby zmienić kolejność obliczeń, otocz część formuły, którą chcesz obliczyć najpierw, nawiasami.

## **Operatory porównania**
Możesz porównywać wartości komórek przy użyciu operatorów porównania. Gdy dwa wartości są porównywane przy ich użyciu, wynik jest wartością logiczną *TRUE* lub *FALSE*:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|= (znak równości)|Równe|A2 = 3|
|<> (znak nierówności)|Nierówne|A2 <> 3|
|> (większy niż)|Większy niż|A2 > 3|
|>= (większy lub równy)|Większy lub równy|A2 >= 3|
|< (mniejszy niż)|Mniejszy niż|A2 < 3|
|<= (mniejszy lub równy)|Mniejszy lub równy|A2 <= 3|

## **Odwołania do komórek w stylu A1**
**Odwołania do komórek w stylu A1** są używane w arkuszach, w których kolumna ma literowy identyfikator (np. "*A*"), a wiersz ma numeryczny identyfikator (np. "*1*"). Odwołania w stylu A1 mogą być używane w następujący sposób:

|**Odwołanie**|**Przykład**| | |
| :- | :- | :- | :- |
| |Bezwzględne|Względne|Mieszane|
|Komórka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Wiersz|$2:$2|2:2|-|
|Kolumna|$A:$A|A:A|-|
|Zakres|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Oto przykład użycia odwołania w stylu A1 w formule:

## **Odwołania do komórek w stylu R1C1**
**Odwołania do komórek w stylu R1C1** są używane w arkuszach, w których zarówno wiersz, jak i kolumna mają identyfikatory liczbowe. Odwołania w stylu R1C1 mogą być używane w następujący sposób:

|**Odwołanie**|**Przykład**| | |
| :- | :- | :- | :- |
| |Bezwzględne|Względne|Mieszane|
|Komórka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Wiersz|R2|R[2]|-|
|Kolumna|C3|C[3]|-|
|Zakres|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Oto przykład użycia odwołania w stylu R1C1 w formule:

## **Funkcje predefiniowane**
Istnieją funkcje predefiniowane, które mogą być używane w formułach w celu uproszczenia ich implementacji. Funkcje te kapsułują najczęściej używane operacje, takie jak:

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

Tak. Aspose.Slides obsługuje zewnętrzne skoroszyty jako [źródło danych wykresu](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdatasourcetype/), co pozwala używać formuł z pliku XLSX poza prezentacją.

**Czy formuły wykresu mogą odwoływać się do arkuszy w tym samym skoroszycie po nazwie arkusza?**

Tak. Formuły podążają za standardowym modelem odwołań Excel, więc możesz odwoływać się do innych arkuszy w tym samym skoroszycie lub do skoroszytu zewnętrznego. W przypadku odwołań zewnętrznych, podaj ścieżkę i nazwę skoroszytu używając składni Excela.