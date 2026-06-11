---
title: Zastosuj formuły arkusza wykresu w prezentacjach przy użyciu Pythona
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/python-net/chart-worksheet-formulas/
keywords:
- arkusz wykresu
- arkusz wykresu
- formuła wykresu
- formuła arkusza
- formuła arkusza
- źródło danych
- stała logiczna
- stała numeryczna
- stała łańcuchowa
- stała błędu
- stała arytmetyczna
- operator porównania
- styl A1
- styl R1C1
- funkcja predefiniowana
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Stosuj formuły w stylu Excel w Aspose.Slides dla Pythona za pomocą arkuszy wykresów .NET i automatyzuj raporty w plikach PPT, PPTX oraz ODP."
---
## **Przegląd**

Arkusz wykresu jest źródłem danych za wykresem w prezentacji. Przechowuje nazwy kategorii i serii wraz z wartościami liczbowymi wyświetlanymi na wykresie. W Aspose.Slides ten arkusz jest dostępny poprzez skoroszyt danych wykresu, co umożliwia programowe manipulowanie danymi wykresu.

Ten artykuł wyjaśnia, jak używać formuł arkusza w danych wykresu, aby wartości komórek mogły być obliczane i aktualizowane automatycznie zamiast wprowadzania ich ręcznie. Pokazuje, jak przypisywać formuły, używać odwołań w stylu A1 i R1C1, przeliczać formuły skoroszytu oraz pracować z obsługiwanymi stałymi, operatorami, odwołaniami do komórek i wbudowanymi funkcjami dostępnymi dla arkuszy wykresów w prezentacjach.

## **O formule arkusza wykresu w prezentacji**
**Chart spreadsheet** (lub arkusz wykresu) w prezentacji jest źródłem danych wykresu. Arkusz wykresu zawiera dane, które są przedstawiane na wykresie w formie graficznej. Gdy tworzysz wykres w PowerPoint, arkusz powiązany z tym wykresem jest tworzony automatycznie. Arkusz wykresu jest tworzony dla wszystkich typów wykresów: wykresu liniowego, słupkowego, sunburst, kołowego itp. Aby zobaczyć arkusz wykresu w PowerPoint, należy dwukrotnie kliknąć wykres:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Arkusz wykresu zawiera nazwy elementów wykresu (Nazwa kategorii: *Category1*, Nazwa serii) oraz tabelę z danymi liczbowymi odpowiadającymi tym kategoriom i seriom. Domyślnie, gdy tworzysz nowy wykres – dane arkusza wykresu są ustawione na domyślne. Następnie możesz ręcznie zmienić dane arkusza.

Zazwyczaj wykres przedstawia skomplikowane dane (np. analizy finansowe, analizy naukowe), posiadające komórki obliczane na podstawie wartości w innych komórkach lub z innych dynamicznych danych. Ręczne obliczanie wartości komórki i wpisywanie jej na stałe utrudnia późniejsze zmiany. Jeśli zmienisz wartość określonej komórki, wszystkie komórki od niej zależne będą wymagały aktualizacji. Ponadto dane tabeli mogą zależeć od danych z innych tabel, tworząc złożony schemat danych prezentacji, który należy aktualizować w łatwy i elastyczny sposób.

**Formuła arkusza wykresu** w prezentacji jest wyrażeniem, które automatycznie oblicza i aktualizuje dane arkusza wykresu. Formuła arkusza definiuje logikę obliczeń danych dla określonej komórki lub zestawu komórek. Formuła arkusza jest formułą matematyczną lub logiczną, wykorzystującą: odwołania do komórek, funkcje matematyczne, operatory logiczne, operatory arytmetyczne, funkcje konwersji, stałe łańcuchowe itp. Definicja formuły jest zapisywana w komórce, a ta komórka nie zawiera prostej wartości. Formuła arkusza oblicza wartość i zwraca ją, a następnie wartość ta jest przypisywana do komórki. Formuły arkusza wykresu w prezentacjach są zasadniczo takie same jak formuły Excel i obsługują te same domyślne funkcje, operatory i stałe.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/python-net/) arkusz wykresu jest reprezentowany przez właściwość 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdata/) typu 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdataworkbook/). 
Formułę arkusza można przypisać i zmienić za pomocą właściwości 
[**formula**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/). 
Obsługiwane funkcje formuł w Aspose.Slides:

- Stałe logiczne
- Stałe liczbowe
- Stałe łańcuchowe
- Stałe błędów
- Operatory arytmetyczne
- Operatory porównania
- Odwołania do komórek w stylu A1
- Odwołania do komórek w stylu R1C1
- Predefiniowane funkcje

Typowo arkusze przechowują ostatnie obliczone wartości formuł. Jeśli po załadowaniu prezentacji dane wykresu nie zostały zmienione – właściwość **IChartDataCell.Value** zwraca te wartości przy odczycie. Jednak jeśli dane arkusza zostały zmienione, przy odczycie właściwość **ChartDataCell.Value** zgłasza **CellUnsupportedDataException** dla nieobsługiwanych formuł. Dzieje się tak, ponieważ gdy formuły zostaną pomyślnie przetworzone, określane są zależności komórek i poprawność ostatnich wartości. Jeśli formuła nie może być parsowana, poprawność wartości komórki nie może być zagwarantowana.

## **Dodawanie formuły arkusza wykresu do prezentacji**
Najpierw dodaj wykres z przykładowymi danymi do pierwszego slajdu nowej prezentacji za pomocą 
[add_chart](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishapecollection/). 
Arkusz wykresu jest tworzony automatycznie i można go uzyskać za pomocą właściwości 
[**chart_data_workbook**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdata/):

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Zapiszmy kilka wartości w komórkach za pomocą właściwości 
[**value**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/) typu **Object**, co oznacza, że możesz ustawić dowolną wartość tej właściwości:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Teraz, aby zapisać formułę w komórce, użyj 
[**formula**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/) :

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Uwaga*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/) służy do ustawiania odwołań w stylu A1.

Aby ustawić odwołanie komórki [r1c1_formula](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/), użyj właściwości [**r1c1_formula**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Następnie użyj metody [**calculate_formulas**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/) aby obliczyć wszystkie formuły w skoroszycie i zaktualizować odpowiadające wartości komórek:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Stałe logiczne**
Możesz używać stałych logicznych takich jak *FALSE* i *TRUE* w formułach komórek:

## **Stałe liczbowe**
Liczby mogą być używane w notacji zwykłej lub naukowej do tworzenia formuł arkusza wykresu:

## **Stałe łańcuchowe**
Stała łańcuchowa (lub literał) jest określoną wartością, która jest używana wprost i nie zmienia się. Stałe łańcuchowe mogą być: datami, tekstami, liczbami itp.:

## **Stałe błędów**
Czasami nie jest możliwe obliczenie wyniku formuły. W takim przypadku w komórce wyświetlany jest kod błędu zamiast wartości. Każdy typ błędu ma określony kod:

- #DIV/0! – formuła próbuje podzielić przez zero.
- #GETTING_DATA – może być wyświetlany w komórce, gdy jej wartość jest w trakcie obliczania.
- #N/A – informacja jest brakująca lub niedostępna. Przyczynami mogą być: puste komórki użyte w formule, dodatkowy znak spacji, literówka itp.
- #NAME? – nie można znaleźć określonej komórki lub innego obiektu formuły po nazwie. 
- #NULL! – może pojawić się, gdy w formule jest błąd, np.  (,) lub znak spacji zamiast dwukropka (:).
- #NUM! – liczba w formule może być nieprawidłowa, za długa lub za mała itp.
- #REF! – nieprawidłowe odwołanie do komórki.
- #VALUE! – nieoczekiwany typ wartości. Na przykład, łańcuch ustawiony w komórce liczbowej.

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

*Uwaga*: Aby zmienić kolejność wykonywania, umieść w nawiasach część formuły, którą należy obliczyć najpierw.

## **Operatory porównania**
Możesz porównywać wartości komórek przy użyciu operatorów porównania. Gdy dwa wartości są porównywane przy użyciu tych operatorów, wynik jest wartością logiczną *TRUE* lub *FALSE*:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|= (equal sign)|Równa się|A2 = 3|
|<> (not equal sign)|Nie równa się|A2 <> 3|
|> (greater than sign)|Większe niż|A2 > 3|
|>= (greater than or equal to sign)|Większe lub równe|A2 >= 3|
|< (less than sign)|Mniejsze niż|A2 < 3|
|<= (less than or equal to sign)|Mniejsze lub równe|A2 <= 3|

## **Odwołania do komórek w stylu A1**
**Odwołania do komórek w stylu A1** są używane w arkuszach, w których kolumna ma literowy identyfikator (np. "*A*"), a wiersz ma identyfikator liczbowy (np. "*1*"). Odwołania w stylu A1 mogą być używane w następujący sposób:

|**Odwołanie do komórki**|**Przykład**|**Bezwzględny**|**Względny**|**Mieszany**|
| :- | :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Oto przykład użycia odwołania w stylu A1 w formule:

## **Odwołania do komórek w stylu R1C1**
**Odwołania do komórek w stylu R1C1** są używane w arkuszach, w których zarówno wiersz, jak i kolumna mają identyfikatory liczbowe. Odwołania w stylu R1C1 mogą być używane w następujący sposób:

|**Odwołanie do komórki**|**Przykład**|**Bezwzględny**|**Względny**|**Mieszany**|
| :- | :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Oto przykład użycia odwołania w stylu R1C1 w formule:

## **Predefiniowane funkcje**
Istnieją predefiniowane funkcje, które mogą być używane w formułach w celu uproszczenia ich implementacji. Funkcje te kapsułują najczęściej używane operacje, takie jak: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (system daty 1900)
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

Tak. Aspose.Slides obsługuje zewnętrzne skoroszyty jako [źródło danych wykresu](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatasourcetype/), co pozwala używać formuł z pliku XLSX spoza prezentacji.

**Czy formuły wykresu mogą odwoływać się do arkuszy w tym samym skoroszycie po nazwie arkusza?**

Tak. Formuły stosują standardowy model odwołań Excel, więc możesz odwoływać się do innych arkuszy w tym samym skoroszycie lub do skoroszytu zewnętrznego. Dla odwołań zewnętrznych podaj ścieżkę i nazwę skoroszytu używając składni Excel.