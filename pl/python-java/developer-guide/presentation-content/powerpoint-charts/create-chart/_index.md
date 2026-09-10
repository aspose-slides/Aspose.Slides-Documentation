---
title: Tworzenie lub aktualizacja wykresów w prezentacjach PowerPoint w Pythonie
linktitle: Tworzenie lub aktualizacja wykresów
type: docs
weight: 10
url: /pl/python-java/create-chart/
keywords:
- dodaj wykres
- utwórz wykres
- edytuj wykres
- zmień wykres
- zaktualizuj wykres
- wykres punktowy
- wykres kołowy
- wykres liniowy
- wykres mapy drzewa
- wykres giełdowy
- wykres pudełkowy i wąsowy
- wykres lejkowy
- wykres promieniowy
- wykres histogramu
- wykres radarowy
- wykres wielokategorialny
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz i dostosowuj wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java. Dodawaj, formatuj i edytuj wykresy z praktycznymi przykładami kodu w Pythonie."
---
## **Przegląd**

Ten artykuł zawiera kompleksowy przewodnik, jak tworzyć i dostosowywać wykresy przy użyciu Aspose.Slides. Dowiesz się, jak programowo dodać wykres do slajdu, wypełnić go danymi i zastosować różne opcje formatowania, aby spełnić określone wymagania projektowe. W całym artykule szczegółowe przykłady kodu ilustrują każdy krok, od inicjalizacji prezentacji i obiektu wykresu po konfigurowanie serii, osi i legend. Postępując zgodnie z tym przewodnikiem, zdobędziesz solidną wiedzę na temat integracji dynamicznego generowania wykresów w aplikacjach, upraszczając proces tworzenia prezentacji opartych na danych.

## **Utwórz wykres**

Wykresy pomagają szybko wizualizować dane i uzyskać wnioski, które nie są od razu widoczne w tabeli lub arkuszu kalkulacyjnym.

**Dlaczego tworzyć wykresy?**

Korzystając z wykresów, możesz:

* zagregować, skondensować lub podsumować duże ilości danych na jednym slajdzie prezentacji
* uwidocznić wzorce i trendy w danych
* określić kierunek i dynamikę danych w czasie lub względem określonej jednostki miary
* wykrywać odstające wartości, anomalie, odchylenia, błędy, dane nielogiczne itp.
* przekazywać lub prezentować złożone dane

W PowerPoint możesz tworzyć wykresy za pomocą funkcji *Insert*, która oferuje szablony do projektowania wielu typów wykresów. Korzystając z Aspose.Slides, możesz tworzyć zarówno standardowe wykresy (oparte na popularnych typach) jak i wykresy niestandardowe.

{{% alert color="info" title="Uwaga" %}}

Aby tworzyć wykresy, użyj klasy [ChartType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/). Pól w tej klasie odpowiadają różnym typom wykresów.

{{% /alert %}}

### **Utwórz wykresy kolumnowe grupowane**

Ta sekcja opisuje, jak tworzyć wykresy kolumnowe grupowane przy użyciu Aspose.Slides. Nauczysz się inicjalizować prezentację, dodać wykres i dostosować jego elementy, takie jak tytuł, dane, serie, kategorie i styl. Postępuj zgodnie z poniższymi krokami, aby zobaczyć, jak generowany jest standardowy wykres kolumnowy grupowany:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation) .
1. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
1. Dodaj wykres z danymi i określ typ `ChartType.ClusteredColumn` .
1. Dodaj tytuł do wykresu.
1. Uzyskaj dostęp do arkusza danych wykresu.
1. Wyczyść wszystkie domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane wykresu dla serii wykresu.
1. Zastosuj kolor wypełnienia do serii wykresu.
1. Dodaj etykiety do serii wykresu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# demonstruje, jak utworzyć wykres kolumnowy grupowany:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX.
presentation = Presentation()
try:
    # Uzyskuje dostęp do pierwszego slajdu
    slide = presentation.getSlides().get_Item(0)

    # Dodaje wykres z domyślnymi danymi
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Ustawia tytuł wykresu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ustawia indeks arkusza danych wykresu
    default_worksheet_index = 0

    # Pobiera arkusz danych wykresu
    workbook = chart.getChartData().getChartDataWorkbook()

    # Usuwa domyślnie wygenerowane serie i kategorie
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Dodaje nowe serie
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Dodaje nowe kategorie
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # Pobiera pierwszą serię wykresu
    series = chart.getChartData().getSeries().get_Item(0)

    # Teraz wypełnia dane serii
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Ustawia kolor wypełnienia serii
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # Pobiera drugą serię wykresu
    series = chart.getChartData().getSeries().get_Item(1)

    # Wypełnia dane serii
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Ustawia kolor wypełnienia serii
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Create niestandardowe etykiety dla każdej kategorii dla nowej serii
    # Ustawia pierwszą etykietę, aby wyświetlała nazwę kategorii
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Wyświetla wartość dla trzeciej etykiety
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Zapisuje prezentację z wykresem
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy punktowe**

Wykresy punktowe (znane też jako wykresy rozrzutu lub wykresy x‑y) są często używane do sprawdzania wzorców lub wykazywania korelacji między dwoma zmiennymi.

Użyj wykresu punktowego, gdy:

* masz sparowane dane liczbowe
* masz dwie zmienne, które dobrze ze sobą współgrają
* chcesz określić, czy dwie zmienne są ze sobą powiązane
* masz zmienną niezależną, która ma wiele wartości dla zmiennej zależnej

1. Postępuj zgodnie z krokami w sekcji [Utwórz wykresy kolumnowe grupowane](#utwórz-wykresy-kolumnowe-grupowane).
2. W trzecim kroku dodaj wykres z danymi i określ typ wykresu jako jeden z następujących:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Reprezentuje wykres punktowy z markerami._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Reprezentuje wykres punktowy połączony krzywymi, z markerami danych._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Reprezentuje wykres punktowy połączony krzywymi, bez markerów danych._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Reprezentuje wykres punktowy połączony liniami, z markerami danych._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Reprezentuje wykres punktowy połączony liniami, bez markerów danych._

Ten kod Python pokazuje, jak utworzyć wykres punktowy z różnymi markerami dla każdej serii:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX.
presentation = Presentation()
try:
    # Uzyskuje dostęp do pierwszego slajdu
    slide = presentation.getSlides().get_Item(0)

    # Tworzy domyślny wykres
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Pobiera indeks domyślnego arkusza danych wykresu
    default_worksheet_index = 0

    # Pobiera arkusz danych wykresu
    workbook = chart.getChartData().getChartDataWorkbook()

    # Usuwa przykładowe serie
    chart.getChartData().getSeries().clear()

    # Dodaje nowe serie
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Pobiera pierwszą serię wykresu
    series = chart.getChartData().getSeries().get_Item(0)

    # Dodaje nowy punkt (1:3) do serii
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Dodaje nowy punkt (2:10)
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Zmienia typ serii
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Zmienia znacznik serii wykresu
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # Pobiera drugą serię wykresu
    series = chart.getChartData().getSeries().get_Item(1)

    # Dodaje nowy punkt (5:2) tam
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Dodaje nowy punkt (3:1)
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Dodaje nowy punkt (2:2)
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Dodaje nowy punkt (5:1)
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Zmienia znacznik serii wykresu
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy kołowe**

Wykresy kołowe najlepiej służą do przedstawiania relacji część‑całość w danych, szczególnie gdy dane zawierają etykiety kategoryczne z wartościami liczbowymi. Jeśli jednak Twoje dane zawierają wiele części lub etykiet, rozważ użycie wykresu słupkowego.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType.Pie](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#Pie) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii wykresu.
8. Dodaj nowe punkty do wykresu i zastosuj niestandardowe kolory dla sektorów wykresu kołowego.
9. Ustaw etykiety dla serii.
10. Włącz linie prowadzące dla etykiet serii.
11. Ustaw kąt obrotu sektorów wykresu kołowego.
12. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres kołowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX.
presentation = Presentation()
try:
    # Uzyskuje dostęp do pierwszego slajdu
    slide = presentation.getSlides().get_Item(0)

    # Dodaje wykres z domyślnymi danymi
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Ustawia tytuł wykresu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ustawia indeks arkusza danych wykresu
    default_worksheet_index = 0

    # Pobiera arkusz danych wykresu
    workbook = chart.getChartData().getChartDataWorkbook()

    # Usuwa domyślnie wygenerowane serie i kategorie
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Dodaje nowe kategorie
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Dodaje nowe serie
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Populates the series data
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Dodaje nowe punkty i ustawia kolor sektorów
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Ustawia obramowanie sektora
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Ustawia obramowanie sektora
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Ustawia obramowanie sektora
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Tworzy niestandardowe etykiety dla każdej kategorii nowej serii
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Wyświetla linie prowadzące dla wykresu
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Ustawia kąt obrotu sektorów wykresu kołowego
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Zapisuje prezentację z wykresem
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy liniowe**

Wykresy liniowe (znane także jako wykresy liniowe) są najlepsze w sytuacjach, gdy chcesz pokazać zmiany wartości w czasie. Dzięki wykresowi liniowemu możesz jednocześnie porównać dużą ilość danych, śledzić zmiany i trendy w czasie, podkreślać anomalie w serii danych i wiele więcej.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ [ChartType.Line](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#Line) .
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres liniowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Domyślnie punkty na wykresie liniowym są połączone prostymi liniami ciągłymi. Jeśli chcesz, aby punkty były połączone kreskami, możesz określić preferowany typ linii przerywanej w następujący sposób:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy mapy drzewa**

Wykresy mapy drzewa są najlepsze dla danych sprzedażowych, gdy chcesz pokazać względny rozmiar kategorii danych i szybko zwrócić uwagę na pozycje, które są dużymi wkładaczami w każdej kategorii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType.Treemap](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#Treemap) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii wykresu.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres mapy drzewa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #gałąź 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #gałąź 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy giełdowe**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii wykresu.
8. Określ format linii wysokich‑niskich.
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres giełdowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy pudełkowe i wąsowe**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii wykresu.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres pudełkowy i wąsowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy lejkowe**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType.Funnel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#Funnel) .
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres lejkowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy promieniowe**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType.Sunburst](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#Sunburst) .
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres promieniowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #gałąź 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #gałąź 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy histogramu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType.Histogram](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#Histogram) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres histogramu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy radarowe**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z danymi i określ preferowany typ wykresu ([ChartType.Radar](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#Radar) w tym przypadku).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres radarowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy wielokategorialne**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType.ClusteredColumn](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#ClusteredColumn) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii wykresu.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak utworzyć wykres wielokategorialny:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpjp.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # Dodawanie serii
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Zapisz prezentację z wykresem
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy mapowe**

Wykresy mapowe wizualizują dane geograficzne i pomagają porównywać wartości w różnych regionach.

Ten kod Python pokazuje, jak utworzyć wykres mapowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz wykresy kombinowane**

Wykres kombinowany (lub wykres combo) łączy dwa lub więcej typów wykresów w jednym diagramie. Ten wykres umożliwia wyróżnianie, porównywanie lub badanie różnic między dwoma lub więcej zestawami danych, pomagając zidentyfikować zależności pomiędzy nimi.

![The combination chart](combination_chart.png)

Poniższy kod Python pokazuje, jak utworzyć wykres kombinowany przedstawiony powyżej w prezentacji PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Ustaw tytuł wykresu.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Ustaw legendę wykresu.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Usuń domyślnie wygenerowane serie i kategorie.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Dodaj nowe kategorie.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Dodaj pierwszą serię.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Ustaw oś poziomą.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Ustaw oś pionową.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Ustaw kolor głównych linii siatki pionowej.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Ustaw drugą oś poziomą.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Ustaw drugą oś pionową.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Aktualizuj wykresy**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) reprezentującą prezentację zawierającą wykres, który chcesz zaktualizować.
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Przejdź przez wszystkie kształty, aby znaleźć żądany wykres.
4. Uzyskaj dostęp do arkusza danych wykresu.
5. Zmodyfikuj serię danych wykresu, zmieniając wartości serii.
6. Dodaj nową serię i wypełnij ją danymi.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak zaktualizować wykres:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Otwiera prezentację, która zawiera wykres do aktualizacji
presentation = Presentation("ExistingChart.pptx")
try:
    # Dostęp do pierwszego slajdu
    slide = presentation.getSlides().get_Item(0)

    # Pobierz wykres ze slajdu
    chart = slide.getShapes().get_Item(0)

    # Ustawianie indeksu arkusza danych wykresu
    default_worksheet_index = 0

    # Pobieranie arkusza danych wykresu
    workbook = chart.getChartData().getChartDataWorkbook()

    # Zmiana nazwy kategorii wykresu
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # Weź pierwszą serię wykresu
    series = chart.getChartData().getSeries().get_Item(0)

    # Teraz aktualizujemy dane serii
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Modyfikacja nazwy serii
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # Weź drugą serię wykresu
    series = chart.getChartData().getSeries().get_Item(1)

    # Teraz aktualizujemy dane serii
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Modyfikacja nazwy serii
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Teraz dodajemy nową serię
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Weź trzecią serię wykresu
    series = chart.getChartData().getSeries().get_Item(2)

    # Teraz wypełniamy dane serii
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Zapisz prezentację z wykresem
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw zakres danych dla wykresu**

Aby ustawić zakres danych dla wykresu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) reprezentującą prezentację zawierającą wykres.
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.
3. Przejdź przez wszystkie kształty, aby znaleźć żądany wykres.
4. Uzyskaj dostęp do danych wykresu i ustaw zakres.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Python pokazuje, jak ustawić zakres danych dla wykresu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Otwiera prezentację, która zawiera wykres
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Użyj domyślnych znaczników w wykresach**

Kiedy używasz domyślnych znaczników w wykresach, każda seria wykresu automatycznie otrzymuje inny symbol znacznika.

Ten kod Python pokazuje, jak automatycznie ustawić znacznik serii wykresu:

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #Weź drugą serię wykresu
    second_series = chart.getChartData().getSeries().get_Item(1)

    #Teraz wypełniamy dane serii
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jakie typy wykresów są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje szeroką gamę [typów wykresów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/), w tym słupkowe, liniowe, kołowe, powierzchniowe, punktowe, histogramy, radarowe i wiele innych. Ta elastyczność pozwala wybrać najbardziej odpowiedni typ wykresu do potrzeb wizualizacji danych.

**Jak dodać nowy wykres do slajdu?**

Aby dodać wykres, najpierw utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) , pobierz żądany slajd przy użyciu jego indeksu, a następnie wywołaj metodę dodania wykresu, określając typ wykresu i początkowe dane. Proces ten integruje wykres bezpośrednio w prezentacji.

**Jak mogę zaktualizować dane wyświetlane w wykresie?**

Możesz zaktualizować dane wykresu, uzyskując dostęp do jego skoroszytu danych ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/)), wyczyszczając domyślne serie i kategorie, a następnie dodając własne dane. Umożliwia to odświeżenie wykresu, aby odzwierciedlał najnowsze informacje.

**Czy można dostosować wygląd wykresu?**

Tak, Aspose.Slides oferuje rozbudowane opcje dostosowywania. Możesz modyfikować kolory, czcionki, etykiety, legendy oraz inne [elementy formatowania](/slides/pl/python-java/chart-entities/), aby dopasować wygląd wykresu do konkretnych wymagań projektowych.