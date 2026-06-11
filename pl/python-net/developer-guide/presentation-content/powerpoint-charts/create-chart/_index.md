---
title: Utwórz lub zaktualizuj wykresy prezentacji PowerPoint w Pythonie
linktitle: Utwórz lub zaktualizuj wykres
type: docs
weight: 10
url: /pl/python-net/create-chart/
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
- wykres akcji
- wykres pudełkowo‑wąsowy
- wykres lejkowy
- wykres promieniowy
- wykres histogramu
- wykres radarowy
- wykres wielokategorii
- prezentacja PowerPoint
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET. Omówiono dodawanie, formatowanie i edytowanie wykresów w prezentacjach wraz z praktycznymi przykładami kodu w języku Python."
---
## **Przegląd**

Ten artykuł zawiera kompleksowy przewodnik, jak tworzyć i dostosowywać wykresy za pomocą Aspose.Slides for Python via .NET. Nauczysz się programowo dodawać wykres do slajdu, wypełniać go danymi i stosować różne opcje formatowania, aby dopasować go do konkretnych wymagań projektowych. W całym artykule szczegółowe przykłady kodu ilustrują każdy krok, od inicjalizacji prezentacji i obiektu wykresu po konfigurowanie serii, osi i legend. Postępując zgodnie z tym przewodnikiem, zdobędziesz solidne zrozumienie, jak integrować dynamiczne generowanie wykresów w aplikacjach, usprawniając proces tworzenia prezentacji opartych na danych.

## **Utworzenie wykresu**

Wykresy pomagają szybko wizualizować dane i uzyskać wnioski, które mogą nie być od razu oczywiste z tabeli lub arkusza kalkulacyjnego.

**Dlaczego tworzyć wykresy?**

Używając wykresów, możesz:

* agregować, konsolidować lub podsumowywać duże ilości danych na jednym slajdzie w prezentacji;
* ujawniać wzorce i trendy w danych;
* wyciągać wnioski o kierunku i dynamice danych w czasie lub w odniesieniu do określonej jednostki miary;
* wykrywać odstające wartości, aberracje, odchylenia, błędy i nielogiczne dane;
* komunikować lub prezentować złożone dane.

W PowerPoint możesz tworzyć wykresy za pomocą funkcji *Insert*, która udostępnia szablony do projektowania wielu typów wykresów. Korzystając z Aspose.Slides, możesz tworzyć zarówno standardowe wykresy (oparte na popularnych typach wykresów), jak i wykresy niestandardowe.

{{% alert color="primary" %}} 

Użyj wyliczenia [ChartType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/charttype/) w przestrzeni nazw [Aspose.Slides.Charts](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/). Wartości w tym wyliczeniu odpowiadają różnym typom wykresów.

{{% /alert %}} 

### **Utworzenie wykresów kolumnowych grupowanych**

Ta sekcja wyjaśnia, jak tworzyć wykresy kolumnowe grupowane za pomocą Aspose.Slides for Python via .NET. Nauczysz się inicjalizować prezentację, dodawać wykres i dostosowywać jego elementy, takie jak tytuł, dane, serie, kategorie i stylizację. Postępuj zgodnie z poniższymi krokami, aby zobaczyć, jak generowany jest standardowy wykres kolumnowy grupowany:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z pewnymi danymi i określ typ `ChartType.CLUSTERED_COLUMN`.
1. Dodaj tytuł do wykresu.
1. Uzyskaj dostęp do arkusza danych wykresu.
1. Wyczyść wszystkie domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane wykresu dla serii wykresu.
1. Zastosuj kolor wypełnienia do serii wykresu.
1. Dodaj etykiety do serii wykresu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation() as presentation:

    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Dodaj wykres kolumnowy grupowany z domyślnymi danymi.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Ustaw tytuł wykresu.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Ustaw pierwszą serię, aby wyświetlała wartości.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Ustaw indeks arkusza danych wykresu.
    worksheet_index = 0

    # Pobierz skoroszyt danych wykresu.
    workbook = chart.chart_data.chart_data_workbook

    # Usuń domyślnie wygenerowane serie i kategorie.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Dodaj nowe serie.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # Dodaj nowe kategorie.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # Pobierz pierwszą serię wykresu.
    series = chart.chart_data.series[0]

    # Wypełnij dane serii.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Ustaw kolor wypełnienia dla serii.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Pobierz drugą serię wykresu.
    series = chart.chart_data.series[1]

    # Wypełnij dane serii.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Ustaw kolor wypełnienia dla serii.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Ustaw pierwszą etykietę, aby wyświetlała nazwę kategorii.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # Ustaw serię, aby wyświetlała wartość dla trzeciej etykiety.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # Zapisz prezentację na dysku jako plik PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres kolumnowy grupowany](clustered_column_chart.png)

### **Utworzenie wykresów punktowych**

Wykresy punktowe (znane również jako wykresy rozproszenia lub grafy x‑y) są często używane do sprawdzania wzorców lub wykazywania korelacji między dwoma zmiennymi.

Użyj wykresu punktowego, gdy:

* Masz sparowane dane liczbowe.
* Masz dwie zmienne, które dobrze ze sobą współgrają.
* Chcesz określić, czy dwie zmienne są ze sobą powiązane.
* Masz zmienną niezależną, która ma wiele wartości dla zmiennej zależnej.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:

    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Utwórz domyślny wykres punktowy.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Ustaw indeks arkusza danych wykresu.
    worksheet_index = 0

    # Pobierz skoroszyt danych wykresu.
    workbook = chart.chart_data.chart_data_workbook

    # Usuń domyślną serię.
    chart.chart_data.series.clear()

    # Dodaj nowe serie.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Pobierz pierwszą serię wykresu.
    series = chart.chart_data.series[0]

    # Dodaj nowy punkt (1:3) do serii.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Dodaj nowy punkt (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Zmień typ serii.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Zmień znacznik serii wykresu.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Pobierz drugą serię wykresu.
    series = chart.chart_data.series[1]

    # Dodaj nowy punkt (5:2) do serii wykresu.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Dodaj nowy punkt (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Dodaj nowy punkt (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Dodaj nowy punkt (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Zmień znacznik serii wykresu.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres punktowy](scatter_chart.png)

### **Utworzenie wykresów kołowych**

Wykresy kołowe są najlepsze do przedstawiania zależności części‑do‑całości w danych, szczególnie gdy dane zawierają etykiety kategoryczne z wartościami liczbowymi. Jednak jeśli dane zawierają wiele części lub etykiet, warto rozważyć użycie wykresu słupkowego.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ `ChartType.PIE`.
1. Uzyskaj dostęp do arkusza danych wykresu ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Wyczyść domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane wykresu dla serii.
1. Dodaj nowe punkty do wykresu i zastosuj niestandardowe kolory do sektorów wykresu kołowego.
1. Ustaw etykiety dla serii.
1. Włącz linie prowadzące dla etykiet serii.
1. Ustaw kąt obrotu wykresu kołowego.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation() as presentation:

    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Dodaj wykres z domyślnymi danymi.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Ustaw tytuł wykresu.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Ustaw pierwszą serię, aby wyświetlała wartości.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Ustaw indeks arkusza danych wykresu.
    worksheet_index = 0

    # Pobierz skoroszyt danych wykresu.
    workbook = chart.chart_data.chart_data_workbook

    # Usuń domyślnie wygenerowane serie i kategorie.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Dodaj nowe kategorie.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Dodaj nową serię.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Wypełnij dane serii.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Ustaw kolor sektora.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Ustaw obramowanie sektora.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Ustaw obramowanie sektora.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Ustaw obramowanie sektora.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Utwórz własne etykiety dla każdej kategorii w nowej serii.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Ustaw serię, aby wyświetlała linie prowadzące dla wykresu.
    series.labels.default_data_label_format.show_leader_lines = True

    # Ustaw kąt obrotu sektorów wykresu kołowego.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Zapisz prezentację na dysku jako plik PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres kołowy](pie_chart.png)

### **Utworzenie wykresów liniowych**

Wykresy liniowe (znane również jako wykresy liniowe) są najlepsze w sytuacjach, gdy chcesz pokazać zmiany wartości w czasie. Korzystając z wykresu liniowego, możesz jednocześnie porównać dużą ilość danych, śledzić zmiany i trendy w czasie, podkreślać anomalie w seriach danych i więcej.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ `ChartType.LINE`.
1. Uzyskaj dostęp do arkusza danych wykresu ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Wyczyść domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane wykresu dla serii.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Domyślnie punkty na wykresie liniowym są łączone prostymi, ciągłymi liniami. Jeśli chcesz, aby punkty były łączone kreskami, możesz określić preferowany typ kreski w następujący sposób:

```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

Wynik:

![Wykres liniowy](line_chart.png)

### **Utworzenie wykresów mapy drzewa**

Wykresy mapy drzewa są najlepsze dla danych sprzedażowych, gdy chcesz pokazać względny rozmiar kategorii danych i szybko zwrócić uwagę na elementy będące dużymi wkładami w każdej kategorii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ `ChartType.TREEMAP`.
1. Uzyskaj dostęp do arkusza danych wykresu ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Wyczyść domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane wykresu dla serii.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Gałąź 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Gałąź 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres mapy drzewa](treemap_chart.png)

### **Utworzenie wykresów akcyjnych**

Wykresy akcji są używane do wyświetlania danych finansowych, takich jak ceny otwarcia, wysokie, niskie i zamknięcia, pomagając analizować trendy rynkowe i zmienność. Dostarczają istotnych informacji o wynikach akcji, wspierając inwestorów i analityków w podejmowaniu świadomych decyzji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ `ChartType.OPEN_HIGH_LOW_CLOSE`.
1. Uzyskaj dostęp do arkusza danych wykresu ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Wyczyść domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane wykresu dla serii.
1. Określ format HiLowLines.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres giełdowy](stock_chart.png)

### **Utworzenie wykresów pudełkowo‑wąsowych**

Wykresy pudełkowo‑wąsowe służą do wyświetlania rozkładu danych poprzez podsumowanie kluczowych miar statystycznych, takich jak mediana, kwartyle i potencjalne wartości odstające. Są szczególnie przydatne w eksploracyjnej analizie danych i badaniach statystycznych, umożliwiają szybkie zrozumienie zmienności danych i identyfikację anomalii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ `ChartType.BOX_AND_WHISKER`.
1. Uzyskaj dostęp do arkusza danych wykresu ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Wyczyść domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane wykresu dla serii.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Utworzenie wykresów lejkowych**

Wykresy lejkowe służą do wizualizacji procesów obejmujących kolejne etapy, w których wolumen danych maleje wraz z przejściem z jednego kroku do następnego. Są szczególnie pomocne przy analizie wskaźników konwersji, identyfikacji wąskich gardeł i śledzeniu efektywności procesów sprzedaży lub marketingu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ `ChartType.FUNNEL`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres lejkowy](funnel_chart.png)

### **Utworzenie wykresów promieniowych (Sunburst)**

Wykresy promieniowe służą do wizualizacji danych hierarchicznych, wyświetlając poziomy jako koncentryczne pierścienie. Pomagają ilustrować zależności części‑do‑całości i są idealne do przedstawiania zagnieżdżonych kategorii i podkategorii w przejrzystym, zwartym formacie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ `ChartType.SUNBURST`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Gałąź 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Gałąź 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres promieniowy](sunburst_chart.png)

### **Utworzenie wykresów histogramu**

Wykresy histogramu służą do przedstawiania rozkładu danych liczbowych poprzez grupowanie wartości w przedziały lub kosze. Są szczególnie przydatne do identyfikacji wzorców danych, takich jak częstotliwość, skośność i rozproszenie, oraz do wykrywania wartości odstających w zestawie danych.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z pewnymi danymi i określ typ `ChartType.HISTOGRAM`.
1. Uzyskaj dostęp do arkusza danych wykresu ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Wyczyść domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres histogramu](histogram_chart.png)

### **Utworzenie wykresów radarowych**

Wykresy radarowe służą do wyświetlania danych wielowymiarowych w dwuwymiarowym formacie, umożliwiając łatwe porównanie kilku zmiennych jednocześnie. Są szczególnie przydatne do identyfikacji wzorców, mocnych i słabych stron w różnych metrykach wydajności lub cechach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z pewnymi danymi i określ typ `ChartType.RADAR`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres radarowy](radar_chart.png)

### **Utworzenie wykresów wielokategorii**

Wykresy wielokategorii służą do wyświetlania danych obejmujących więcej niż jedną grupę kategoryczną, umożliwiając jednoczesne porównanie wartości w wielu wymiarach. Są szczególnie pomocne przy analizie trendów i zależności w złożonych, warstwowych zestawach danych.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ `ChartType.CLUSTERED_COLUMN`.
1. Uzyskaj dostęp do arkusza danych wykresu ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Wyczyść domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane wykresu dla serii.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Dodaj serię.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Zapisz prezentację z wykresem.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres wielokategorii](multi_category_chart.png)

### **Utworzenie wykresów mapowych**

Wykresy mapowe służą do wizualizacji danych geograficznych poprzez mapowanie informacji na konkretne lokalizacje, takie jak kraje, stany czy miasta. Są szczególnie przydatne przy analizie trendów regionalnych, danych demograficznych i rozkładów przestrzennych w przejrzysty, wizualnie angażujący sposób.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wykres mapowy](map_chart.png)

### **Utworzenie wykresów kombinowanych**

Wykres kombinowany (lub wykres combo) łączy dwa lub więcej typów wykresów w jednej grafice. Ten wykres pozwala wyróżnić, porównać lub zbadać różnice między dwoma lub więcej zestawami danych, pomagając zidentyfikować zależności między nimi.

![Wykres kombinowany](combination_chart.png)

Poniższy kod Python pokazuje, jak stworzyć powyższy wykres kombinowany w prezentacji PowerPoint:

```python
def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # Ustaw tytuł wykresu.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # Ustaw legendę wykresu.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # Usuń domyślnie wygenerowane serie i kategorie.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # Dodaj nowe kategorie.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # Dodaj pierwszą serię.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # Ustaw oś poziomą.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # Ustaw oś pionową.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # Ustaw kolor głównych linii siatki pionowej.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # Ustaw drugą oś poziomą.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # Ustaw drugą oś pionową.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **Aktualizacja wykresów**

Aspose.Slides for Python via .NET umożliwia aktualizację wykresów PowerPoint poprzez modyfikację danych wykresu, formatowania i stylizacji. Ta funkcjonalność upraszcza proces utrzymania prezentacji w aktualnym stanie z dynamiczną zawartością i zapewnia, że wykresy dokładnie odzwierciedlają bieżące dane oraz standardy wizualne.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), która reprezentuje prezentację zawierającą wykres.
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty, aby znaleźć wykres.
1. Uzyskaj dostęp do arkusza danych wykresu.
1. Zmodyfikuj serię danych wykresu, zmieniając wartości serii.
1. Dodaj nową serię i wypełnij jej dane.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Ustaw indeks arkusza danych wykresu.
            worksheet_index = 0

            # Pobierz skoroszyt danych wykresu.
            workbook = chart.chart_data.chart_data_workbook

            # Zmień nazwy kategorii wykresu.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Pobierz pierwszą serię wykresu.
            series = chart.chart_data.series[0]

            # Zaktualizuj dane serii.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Modyfikacja nazwy serii.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Pobierz drugą serię wykresu.
            series = chart.chart_data.series[1]

            # Zaktualizuj dane serii.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Modyfikacja nazwy serii.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Dodaj nową serię.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Wypełnij dane serii.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Zapisz prezentację z wykresem.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw zakres danych dla wykresów**

Aspose.Slides for Python via .NET zapewnia elastyczność definiowania konkretnego zakresu danych z arkusza jako źródła danych wykresu. Oznacza to, że możesz bezpośrednio mapować część arkusza na wykres, kontrolując, które komórki przyczyniają się do serii i kategorii wykresu. W rezultacie możesz łatwo aktualizować i synchronizować wykresy z najnowszymi zmianami danych w arkuszu, zapewniając, że prezentacje PowerPoint odzwierciedlają aktualne i dokładne informacje.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), która reprezentuje prezentację zawierającą wykres.
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty, aby znaleźć wykres.
1. Uzyskaj dostęp do danych wykresu i ustaw zakres.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Użyj domyślnych znaczników w wykresach**

Kiedy używasz domyślnych znaczników w wykresach, każda seria wykresu automatycznie otrzymuje inny domyślny symbol znacznika.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Wypełnij dane serii.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jakie typy wykresów są obsługiwane przez Aspose.Slides for Python via .NET?**

Aspose.Slides for Python via .NET obsługuje szeroką gamę typów wykresów, w tym słupkowe, liniowe, kołowe, powierzchniowe, punktowe, histogramy, radarowe i wiele innych. Ta elastyczność pozwala wybrać najbardziej odpowiedni typ wykresu do potrzeb wizualizacji danych.

**Jak dodać nowy wykres do slajdu?**

Aby dodać wykres, najpierw tworzysz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), pobierasz żądany slajd przy użyciu jego indeksu, a następnie wywołujesz metodę dodającą wykres, określając typ wykresu i początkowe dane. Proces ten integruje wykres bezpośrednio w Twojej prezentacji.

**Jak mogę zaktualizować dane wyświetlane na wykresie?**

Możesz zaktualizować dane wykresu, uzyskując dostęp do jego arkusza danych ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/)), usuwając domyślne serie i kategorie, a następnie dodając własne dane. Dzięki temu możesz programowo odświeżać wykres, aby odzwierciedlał najnowsze informacje.

**Czy można dostosować wygląd wykresu?**

Tak, Aspose.Slides for Python via .NET oferuje rozbudowane opcje dostosowywania. Możesz modyfikować kolory, czcionki, etykiety, legendy i inne elementy formatowania, aby dopasować wygląd wykresu do konkretnych wymagań projektowych.