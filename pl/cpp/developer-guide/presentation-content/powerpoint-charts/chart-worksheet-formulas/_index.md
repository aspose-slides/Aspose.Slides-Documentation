---
title: Zastosowanie formuł arkusza wykresu w prezentacjach przy użyciu С++
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/cpp/chart-worksheet-formulas/
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
- funkcja wbudowana
- PowerPoint
- prezentacja
- С++
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w Aspose.Slides dla arkuszy wykresów w С++ i automatyzuj raporty w plikach PPT i PPTX."
---
## **Przegląd**

Arkusz kalkulacyjny wykresu jest źródłem danych wykresu w prezentacji. Przechowuje on nazwy kategorii i serii oraz wartości liczbowe wyświetlane na wykresie. W Aspose.Slides arkusz ten jest dostępny poprzez skoroszyt danych wykresu, co umożliwia programowe operowanie danymi wykresu.

Ten artykuł wyjaśnia, jak używać formuł arkusza w danych wykresu, aby wartości komórek były obliczane i aktualizowane automatycznie zamiast wprowadzane ręcznie. Pokazuje, jak przypisywać formuły, używać odwołań w stylu A1 i R1C1, przeliczać formuły skoroszytu oraz pracować z obsługiwanymi stałymi, operatorami, odwołaniami do komórek i wbudowanymi funkcjami dostępnymi dla arkuszy wykresów w prezentacjach.

## **O formułach arkusza wykresu w prezentacjach**
**Arkusz wykresu** (lub arkusz kalkulacyjny wykresu) w prezentacji jest źródłem danych wykresu. Arkusz wykresu zawiera dane, które są przedstawiane na wykresie w formie graficznej. Gdy tworzysz wykres w PowerPoint, arkusz powiązany z tym wykresem jest tworzony automatycznie. Arkusz wykresu jest tworzony dla wszystkich typów wykresów: wykresu liniowego, słupkowego, sunburst, kołowego itp. Aby zobaczyć arkusz wykresu w PowerPoint, kliknij dwukrotnie wykres:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Arkusz wykresu zawiera nazwy elementów wykresu (Nazwa kategorii: *Category1*, Nazwa serii) oraz tabelę z danymi liczbowymi odpowiadającymi tym kategoriom i seriom. Domyślnie, po utworzeniu nowego wykresu – dane arkusza wykresu są ustawione na wartości domyślne. Następnie możesz ręcznie zmieniać dane arkusza w arkuszu.

Zazwyczaj wykres przedstawia skomplikowane dane (np. analizy finansowe, analizy naukowe), mając komórki obliczane na podstawie wartości w innych komórkach lub z innych dynamicznych danych. Ręczne obliczanie wartości komórki i wpisywanie jej na stałe utrudnia późniejsze zmiany. Jeśli zmienisz wartość określonej komórki, wszystkie komórki od niej zależne będą wymagały aktualizacji. Co więcej, dane tabel mogą zależeć od danych z innych tabel, tworząc złożony schemat danych prezentacji, który musi być aktualizowany w prosty i elastyczny sposób.

**Formuła arkusza wykresu** w prezentacji to wyrażenie służące do automatycznego obliczania i aktualizacji danych arkusza wykresu. Formuła arkusza definiuje logikę obliczania danych dla określonej komórki lub zestawu komórek. Formuła arkusza to formuła matematyczna lub logiczna, wykorzystująca: odwołania do komórek, funkcje matematyczne, operatory logiczne, operatory arytmetyczne, funkcje konwersji, stałe łańcuchowe itp. Definicja formuły jest zapisywana w komórce, a komórka nie zawiera prostych wartości. Formuła arkusza oblicza wartość i zwraca ją, po czym wartość ta jest przypisywana do komórki. Formuły arkusza wykresu w prezentacjach są właściwie takie same jak formuły Excel i obsługują te same domyślne funkcje, operatory i stałe.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/cpp/) arkusz wykresu jest reprezentowany metodą 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) typu 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_data_workbook). 
Formuła arkusza może być przypisywana i zmieniana metodą 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). 
W Aspose.Slides obsługiwane są następujące elementy formuł:

- Stałe logiczne
- Stałe liczbowe
- Stałe łańcuchowe
- Stałe błędów
- Operatory arytmetyczne
- Operatory porównania
- Odwołania do komórek w stylu A1
- Odwołania do komórek w stylu R1C1
- Funkcje wbudowane



Zazwyczaj arkusze przechowują ostatnie obliczone wartości formuł. Jeśli po załadowaniu prezentacji dane wykresu nie zostały zmienione – metoda **IChartDataCell.get_Value()** zwraca te wartości przy odczycie. Jednakże, jeśli dane arkusza zostały zmienione, przy odczycie metoda **ChartDataCell.get_Value()** zgłasza **CellUnsupportedDataException** dla nieobsługiwanych formuł. Dzieje się tak, ponieważ po pomyślnym parsowaniu formuł określane są zależności komórek i weryfikowana jest poprawność ostatnich wartości. Jeśli formuła nie może zostać sparsowana, nie można zagwarantować poprawności wartości komórki.


## **Dodanie formuły arkusza wykresu do prezentacji**
Najpierw dodaj wykres na pierwszym slajdzie nowej prezentacji metodą 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
Arkusz wykresu jest tworzony automatycznie i można go uzyskać metodą 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea):



``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```



Zapiszmy kilka wartości w komórkach metodą 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) typu **Object**, co oznacza, że możesz przekazać dowolną wartość do tej metody:



``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```



Aby zapisać formułę w komórce, użyj metody 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692):





*Uwaga*: metoda [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) służy do ustawiania odwołań do komórek w stylu A1.



Aby ustawić odwołanie R1C1Formula, użyj metody [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):





Następnie, jeśli odczytasz wartości z komórek B2 i C2, zostaną one obliczone:



``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Stałe logiczne**
Możesz używać stałych logicznych takich jak *FALSE* i *TRUE* w formułach komórek:




## **Stałe liczbowe**
Liczby mogą być używane w notacji zwykłej lub naukowej do tworzenia formuły arkusza wykresu:




## **Stałe łańcuchowe**
Stała łańcuchowa (lub literał) to określona wartość używana tak, jak jest, i nie podlega zmianom. Stałe łańcuchowe mogą być: datami, tekstami, liczbami itp.:




## **Stałe błędów**
Czasami nie jest możliwe obliczenie wyniku przy pomocy formuły. W takim przypadku w komórce wyświetlany jest kod błędu zamiast wartości. Każdy rodzaj błędu ma określony kod:

- #DIV/0! – formuła próbuje podzielić przez zero.
- #GETTING_DATA – może być wyświetlony w komórce, gdy jej wartość jest w trakcie obliczania.
- #N/A – brak informacji lub niedostępność. Przyczyny mogą być: puste komórki użyte w formule, dodatkowy znak spacji, literówka itp.
- #NAME? – nie można znaleźć określonej komórki lub innego obiektu formuły po nazwie.
- #NULL! – może wystąpić przy błędzie w formule, np. (,) lub znak spacji zamiast dwukropka (:).
- #NUM! – liczba w formule jest nieprawidłowa, za długa lub za mała.
- #REF! – nieprawidłowe odwołanie do komórki.
- #VALUE! – nieoczekiwany typ wartości. Na przykład łańcuch ustawiony w komórce numerycznej.




## **Operatory arytmetyczne**
Możesz używać wszystkich operatorów arytmetycznych w formułach arkusza wykresu:



|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|+ (plus)|Dodawanie lub znak jednokropny|2 + 3|
|- (minus)|Odejmowanie lub negacja|2 - 3<br>-3|
|* (gwiazdka)|Mnożenie|2 * 3|
|/ (ukośnik)|Dzielenie|2 / 3|
|% (procent)|Procent|30%|
|^ (daszek)|Potęgowanie|2 ^ 3|


*Uwaga*: aby zmienić kolejność obliczeń, umieść w nawiasach część formuły, która ma być obliczona najpierw.


## **Operatory porównania**
Możesz porównywać wartości komórek przy użyciu operatorów porównania. Gdy dwa wartości są porównywane przy użyciu tych operatorów, wynik jest wartością logiczną *TRUE* lub *FALSE*:



|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|= (znak równości)|Równe|A2 = 3|
|<> (znak nierówności)|Nierówne|A2 <> 3|
|> (większy niż)|Większe niż|A2 > 3|
|>= (większy lub równy)|Większe lub równe|A2 >= 3|
|< (mniejszy niż)|Mniejsze niż|A2 < 3|
|<= (mniejszy lub równy)|Mniejsze lub równe|A2 <= 3|

## **Odwołania do komórek w stylu A1**
**Odwołania do komórek w stylu A1** są używane w arkuszach, w których kolumna ma literowy identyfikator (np. "*A*"), a wiersz ma identyfikator liczbowy (np. "*1*"). Odwołania w stylu A1 można używać w następujący sposób:



|**Odwołanie**|**Przykład**| | |
| :- | :- | :- | :- |
| |Bezwzględne|Względne|Mieszane|
|Komórka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Wiersz|$2:$2|2:2|-|
|Kolumna|$A:$A|A:A|-|
|Zakres|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Przykład użycia odwołania w stylu A1 w formule:




## **Odwołania do komórek w stylu R1C1**
**Odwołania do komórek w stylu R1C1** są używane w arkuszach, w których zarówno wiersz, jak i kolumna mają identyfikatory liczbowe. Odwołania w stylu R1C1 można używać w następujący sposób:



|**Odwołanie**|**Przykład**| | |
| :- | :- | :- | :- |
| |Bezwzględne|Względne|Mieszane|
|Komórka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Wiersz|R2|R[2]|-|
|Kolumna|C3|C[3]|-|
|Zakres|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Przykład użycia odwołania w stylu R1C1 w formule:




## **Funkcje wbudowane**
Istnieją funkcje wbudowane, które mogą być używane w formułach w celu uproszczenia ich implementacji. Funkcje te kapsułują najczęściej używane operacje, takie jak:

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

**Czy zewnętrzne pliki Excel są obsługiwane jako źródło danych wykresu z formułami?**

Tak. Aspose.Slides obsługuje zewnętrzne skoroszyty jako [źródło danych wykresu](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdatasourcetype/), co pozwala na użycie formuł z pliku XLSX znajdującego się poza prezentacją.

**Czy formuły wykresu mogą odwoływać się do arkuszy w tym samym skoroszycie po nazwie arkusza?**

Tak. Formuły podążają za standardowym modelem odwołań Excel, więc możesz odwoływać się do innych arkuszy w tym samym skoroszycie lub do skoroszytu zewnętrznego. W przypadku odwołań zewnętrznych podaj ścieżkę i nazwę skoroszytu zgodnie z składnią Excel.