---
title: Zastosuj formuły arkusza wykresu w prezentacjach przy użyciu C++
linktitle: Formuły arkusza
type: docs
weight: 70
url: /pl/cpp/chart-worksheet-formulas/
keywords:
- arkusz wykresu
- arkusz danych wykresu
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
- predefiniowana funkcja
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zastosuj formuły w stylu Excel w arkuszach wykresów Aspose.Slides dla C++ i automatyzuj raporty w plikach PPT i PPTX."
---
## **Przegląd**

Arkusz wykresu jest źródłem danych dla wykresu w prezentacji. Przechowuje on nazwy kategorii i serii wraz z wartościami liczbowymi wyświetlanymi na wykresie. W Aspose.Slides arkusz ten jest dostępny poprzez skoroszyt danych wykresu, co umożliwia programowe operowanie danymi wykresu.

Ten artykuł wyjaśnia, jak używać formuł arkusza w danych wykresu, aby wartości komórek mogły być obliczane i aktualizowane automatycznie zamiast wprowadzania ich ręcznie. Pokazuje, jak przypisywać formuły, używać odwołań w stylu A1 i R1C1, przeliczać formuły skoroszytu oraz pracować z obsługiwanymi stałymi, operatorami, odwołaniami do komórek i predefiniowanymi funkcjami dostępnymi dla arkuszy wykresów w prezentacjach.

## **O formułach arkusza wykresu w prezentacjach**
**Arkusz wykresu** (lub arkusz wykresu) w prezentacji jest źródłem danych wykresu. Arkusz wykresu zawiera dane, które są reprezentowane na wykresie w sposób graficzny. Gdy tworzysz wykres w PowerPoint, arkusz powiązany z tym wykresem jest tworzony automatycznie. Arkusz wykresu tworzony jest dla wszystkich typów wykresów: wykresu liniowego, słupkowego, sunburst, kołowego itp. Aby zobaczyć arkusz wykresu w PowerPoint, należy dwukrotnie kliknąć wykres:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Arkusz wykresu zawiera nazwy elementów wykresu (Nazwa kategorii: *Category1*, Nazwa serii) oraz tabelę z danymi liczbowymi odpowiadającymi tym kategoriom i seriom. Domyślnie, po utworzeniu nowego wykresu – dane arkusza są ustawione na wartości domyślne. Następnie możesz ręcznie zmienić dane arkusza.

Zazwyczaj wykresy przedstawiają skomplikowane dane (np. analizy finansowe, analizy naukowe), posiadające komórki obliczane na podstawie wartości w innych komórkach lub danych dynamicznych. Ręczne obliczanie wartości komórki i wprowadzanie jej jako stałej utrudnia późniejsze zmiany. Jeśli zmienisz wartość jednej komórki, wszystkie zależne od niej komórki będą wymagały aktualizacji. Ponadto dane tabelaryczne mogą zależeć od danych z innych tabel, tworząc złożony schemat danych prezentacji, który powinien być aktualizowany w prosty i elastyczny sposób.

**Formuła arkusza wykresu** w prezentacji to wyrażenie służące do automatycznego obliczania i aktualizacji danych arkusza wykresu. Formuła arkusza definiuje logikę obliczania danych dla określonej komórki lub zestawu komórek. Formuła może być matematyczna lub logiczna i wykorzystuje odwołania do komórek, funkcje matematyczne, operatory logiczne, operatory arytmetyczne, funkcje konwersji, stałe łańcuchowe itp. Definicja formuły jest zapisywana w komórce, a komórka nie zawiera prostej wartości. Formuła oblicza wartość i zwraca ją, po czym ta wartość jest przypisywana do komórki. Formuły arkusza wykresu w prezentacjach są w rzeczywistości takie same jak formuły Excela i obsługują te same domyślne funkcje, operatory i stałe.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/cpp/) arkusz wykresu jest reprezentowany przez metodę 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) typu 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_data_workbook). 
Formułę arkusza można przypisać i zmienić metodą 
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
- Predefiniowane funkcje

Typowo arkusze przechowują ostatnie obliczone wartości formuł. Jeśli po załadowaniu prezentacji dane wykresu nie zostały zmienione – metoda **IChartDataCell.get_Value()** zwraca te wartości podczas odczytu. Natomiast jeśli dane arkusza zostały zmienione, metoda **ChartDataCell.get_Value()** zgłasza **CellUnsupportedDataException** dla nieobsługiwanych formuł. Dzieje się tak, ponieważ po pomyślnym przetworzeniu formuły określane są zależności komórek oraz prawidłowość ostatnich wartości. Gdy formuła nie może zostać sparsowana, nie można zagwarantować prawidłowości wartości komórki.

## **Dodawanie formuły arkusza wykresu do prezentacji**
Najpierw dodaj wykres do pierwszego slajdu nowej prezentacji przy pomocy 
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

*Uwaga*: metoda [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) służy do ustawiania odwołań w stylu A1.

Aby ustawić odwołanie w stylu R1C1, użyj metody [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):

Następnie, jeśli odczytasz wartości z komórek B2 i C2, zostaną one obliczone:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Stałe logiczne**
Możesz używać stałych logicznych, takich jak *FALSE* i *TRUE*, w formułach komórek:

## **Stałe liczbowe**
Liczby mogą być używane w notacji zwykłej lub naukowej do tworzenia formuł arkusza wykresu:

## **Stałe łańcuchowe**
Stała łańcuchowa (lub literał) to specyficzna wartość używana tak, jak jest, i nie zmienia się. Stałe łańcuchowe mogą być: datami, tekstami, liczbami itp.:

## **Stałe błędów**
Czasami nie jest możliwe obliczenie wyniku formuły. W takim wypadku w komórce wyświetlany jest kod błędu zamiast wartości. Każdy typ błędu ma określony kod:

- #DIV/0! – formuła próbuje dzielić przez zero.  
- #GETTING_DATA – może być wyświetlany w komórce, gdy jej wartość jest jeszcze obliczana.  
- #N/A – brak informacji lub nie dostępne. Przyczynami mogą być: puste komórki użyte w formule, dodatkowy znak spacji, literówka itp.  
- #NAME? – nie można znaleźć określonej komórki lub innego obiektu formuły po nazwie.  
- #NULL! – może wystąpić przy błędzie w formule, np. (,) lub znak spacji zamiast dwukropka (:).  
- #NUM! – liczba w formule może być nieprawidłowa, za długa lub za mała.  
- #REF! – nieprawidłowe odwołanie do komórki.  
- #VALUE! – nieoczekiwany typ wartości, np. łańcuch w komórce liczbowej.

## **Operatory arytmetyczne**
Możesz używać wszystkich operatorów arytmetycznych w formułach arkusza wykresu:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|+ (plus)|Dodawanie lub plus jedynkowy|2 + 3|
|- (minus)|Odejmowanie lub negacja|2 - 3<br>-3|
|* (asterisk)|Mnożenie|2 * 3|
|/ (ukośnik)|Dzielenie|2 / 3|
|% (procent)|Procent|30%|
|^ (daszek)|Potęgowanie|2 ^ 3|

*Uwaga*: aby zmienić kolejność obliczeń, umieść w nawiasach część formuły, którą chcesz obliczyć najpierw.

## **Operatory porównania**
Możesz porównywać wartości komórek przy użyciu operatorów porównania. Gdy dwa wartości są porównywane, wynikiem jest wartość logiczna *TRUE* lub *FALSE*:

|**Operator**|**Znaczenie**|**Przykład**|
| :- | :- | :- |
|= (równanie)|Równa się|A2 = 3|
|<> (różne)|Nie równa się|A2 <> 3|
|> (większe niż)|Większe niż|A2 > 3|
|>= (większe lub równe)|Większe lub równe|A2 >= 3|
|< (mniejsze niż)|Mniejsze niż|A2 < 3|
|<= (mniejsze lub równe)|Mniejsze lub równe|A2 <= 3|

## **Odwołania do komórek w stylu A1**
**Odwołania w stylu A1** są używane w arkuszach, gdzie kolumna ma literowy identyfikator (np. "*A*"), a wiersz ma numeryczny identyfikator (np. "*1*"). Odwołania w stylu A1 można stosować w następujący sposób:

|**Odwołanie**|**Przykład**|||
| :- | :- | :- | :- |
||Absolutne|Względne|Mieszane|
|Komórka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Wiersz|$2:$2|2:2|-|
|Kolumna|$A:$A|A:A|-|
|Zakres|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Przykład użycia odwołania A1 w formule:

## **Odwołania do komórek w stylu R1C1**
**Odwołania w stylu R1C1** są używane w arkuszach, gdzie zarówno wiersz, jak i kolumna mają identyfikatory liczbowe. Odwołania w stylu R1C1 można stosować w następujący sposób:

|**Odwołanie**|**Przykład**|||
| :- | :- | :- | :- |
||Absolutne|Względne|Mieszane|
|Komórka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Wiersz|R2|R[2]|-|
|Kolumna|C3|C[3]|-|
|Zakres|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Przykład użycia odwołania R1C1 w formule:

## **Predefiniowane funkcje**
Istnieją predefiniowane funkcje, które można używać w formułach w celu uproszczenia ich implementacji. Funkcje te obejmują najczęściej używane operacje, takie jak:

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

Tak. Aspose.Slides obsługuje zewnętrzne skoroszyty jako [źródło danych wykresu](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdatasourcetype/), co pozwala używać formuł z pliku XLSX znajdującego się poza prezentacją.

**Czy formuły wykresu mogą odwoływać się do arkuszy w tym samym skoroszycie po nazwie arkusza?**

Tak. Formuły podążają za standardowym modelem odwołań Excela, więc możesz odwoływać się do innych arkuszy w tym samym skoroszycie lub w skoroszycie zewnętrznym. W przypadku odwołań zewnętrznych podaj ścieżkę i nazwę skoroszytu używając składni Excela.