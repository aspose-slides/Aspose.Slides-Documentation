---
title: Zarządzanie seriami danych wykresu w Pythonie
linktitle: Serie danych
type: docs
url: /pl/python-net/chart-series/
keywords:
- serie wykresu
- nakładanie serii
- kolor serii
- kolor kategorii
- nazwa serii
- punkt danych
- przerwa serii
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami danych wykresu w Pythonie dla PowerPoint (PPT/PPTX) przy użyciu praktycznych przykładów kodu i najlepszych praktyk, aby ulepszyć swoje prezentacje danych."
---
## **Przegląd**

Ten artykuł opisuje rolę [ChartSeries](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartseries/) w Aspose.Slides for Python, koncentrując się na tym, jak dane są strukturyzowane i wizualizowane w prezentacjach. Obiekty te zapewniają podstawowe elementy definiujące pojedyncze zestawy punktów danych, kategorie i parametry wyglądu wykresu. Pracując z [ChartSeries](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartseries/), deweloperzy mogą bezproblemowo integrować źródła danych i zachować pełną kontrolę nad sposobem wyświetlania informacji, co skutkuje dynamicznymi, opartymi na danych prezentacjami jasno przekazującymi wnioski i analizy.

Seria to wiersz lub kolumna liczb przedstawionych na wykresie.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii**

Właściwość [ChartSeries.overlap](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartseries/overlap/) kontroluje, jak słupki i kolumny nakładają się na siebie w wykresie 2D, określając zakres od -100 do 100. Ponieważ ta właściwość jest powiązana z grupą serii, a nie z pojedynczą serią wykresu, jest ona tylko do odczytu na poziomie serii. Aby skonfigurować wartości nakładania, użyj właściwości `parent_series_group.overlap` odczyt/zapis, która stosuje określone nakładanie do wszystkich serii w tej grupie.

Poniżej znajduje się przykład w języku Python, który pokazuje, jak utworzyć prezentację, dodać wykres słupkowy skumulowany, uzyskać dostęp do pierwszej serii wykresu, skonfigurować ustawienie nakładania i zapisać wynik jako plik PPTX:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj wykres słupkowy skumulowany z domyślnymi danymi.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Ustaw nakładanie serii.
        series.parent_series_group.overlap = series_overlap

    # Zapisz plik prezentacji na dysku.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![The series overlap](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Aspose.Slides umożliwia łatwe dostosowanie kolorów wypełnienia serii wykresu, pozwalając wyróżnić konkretne punkty danych i tworzyć wizualnie atrakcyjne wykresy. Odbywa się to poprzez obiekt [Format](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/format/), który obsługuje różne typy wypełnień, konfiguracje kolorów i inne zaawansowane opcje stylizacji. Po dodaniu wykresu do slajdu i uzyskaniu dostępu do żądanej serii, wystarczy pobrać serię i zastosować odpowiedni kolor wypełnienia. Oprócz jednolitych wypełnień można również wykorzystać wypełnienia gradientowe lub wzorcowe, zwiększając elastyczność projektu. Po ustawieniu kolorów zgodnie z wymaganiami, zapisz prezentację, aby zakończyć aktualizację wyglądu.

Poniższy przykład w języku Python pokazuje, jak zmienić kolor pierwszej serii:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj wykres słupkowy skumulowany z domyślnymi danymi.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Ustaw kolor pierwszej serii.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Zapisz plik prezentacji na dysku.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![The color of the series](series_color.png)

## **Zmień nazwę serii** 

Aspose.Slides oferuje prosty sposób na modyfikację nazw serii wykresu, co ułatwia etykietowanie danych w sposób przejrzysty i znaczący. Uzyskując dostęp do odpowiedniej komórki arkusza w danych wykresu, deweloperzy mogą dostosować sposób prezentacji danych. Ta modyfikacja jest szczególnie przydatna, gdy nazwy serii muszą zostać zaktualizowane lub wyjaśnione w kontekście danych. Po zmianie nazwy serii, prezentację można zapisać, aby zachować zmiany.

Poniżej znajduje się fragment kodu w języku Python prezentujący ten proces w praktyce.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj wykres słupkowy skumulowany z domyślnymi danymi.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Ustaw nazwę pierwszej serii.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Zapisz plik prezentacji na dysku.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Poniższy kod w języku Python pokazuje alternatywny sposób zmiany nazwy serii:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj wykres słupkowy skumulowany z domyślnymi danymi.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Ustaw nazwę pierwszej serii.
    series.name.as_cells[0].value = series_name

    # Zapisz plik prezentacji na dysku.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

Wynik:

![The series name](series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

Aspose.Slides for Python umożliwia pobranie automatycznego koloru wypełnienia serii wykresu w obszarze wykresu. Po utworzeniu instancji klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), możesz uzyskać odwołanie do żądanego slajdu za pomocą indeksu, a następnie dodać wykres używając wybranego typu (np. `ChartType.CLUSTERED_COLUMN`). Dostając się do serii w wykresie, możesz pobrać automatyczny kolor wypełnienia.

Poniższy kod w języku Python demonstruje ten proces szczegółowo.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj wykres słupkowy skumulowany z domyślnymi danymi.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Pobierz kolor wypełnienia serii.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

Przykładowe wyjście:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Ustaw odwrócone kolory wypełnienia dla serii**

Gdy seria danych zawiera zarówno dodatnie, jak i ujemne wartości, jednolite kolorowanie wszystkich słupków może utrudniać odczyt wykresu. Aspose.Slides for Python pozwala przypisać odwrócony kolor wypełnienia — osobne wypełnienie stosowane automatycznie do punktów danych poniżej zera — dzięki czemu wartości ujemne wyróżniają się na pierwszy rzut oka. W tej sekcji dowiesz się, jak włączyć tę opcję, wybrać odpowiedni kolor i zapisać zaktualizowaną prezentację.

Poniższy przykład kodu ilustruje operację:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Dodaj nowe kategorie.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Dodaj nową serię.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Wypełnij dane serii.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Ustaw ustawienia koloru dla serii.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![The inverted solid fill color](inverted_solid_fill_color.png)

Możesz odwrócić kolor wypełnienia dla pojedynczego punktu danych, a nie całej serii. Wystarczy uzyskać dostęp do żądanego `ChartDataPoint` i ustawić jego właściwość `invert_if_negative` na `True`.

Poniższy przykład kodu pokazuje, jak to zrobić:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Wyczyść dane dla określonych punktów danych**

Czasami wykres zawiera wartości testowe, wartości odstające lub przestarzałe wpisy, które trzeba usunąć bez konieczności przebudowy całej serii. Aspose.Slides for Python umożliwia wybranie dowolnego punktu danych po indeksie, wyczyszczenie jego zawartości i natychmiastowe odświeżenie wykresu, tak aby pozostałe punkty przemieściły się, a osie automatycznie przeskalowały się.

Poniższy przykład kodu demonstruje tę operację:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw szerokość przerwy serii**

Szerokość przerwy reguluje ilość pustej przestrzeni pomiędzy sąsiadującymi słupkami lub kolumnami — większe przerwy podkreślają poszczególne kategorie, natomiast mniejsze przerwy tworzą gęstszy, bardziej zwarty wygląd. Dzięki Aspose.Slides for Python możesz precyzyjnie dostroić ten parametr dla całej serii, uzyskując dokładnie taki balans wizualny, jaki wymaga Twoja prezentacja, bez zmiany danych podstawowych.

Poniższy przykład kodu pokazuje, jak ustawić szerokość przerwy dla serii:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Utwórz pustą prezentację.
with slides.Presentation() as presentation:

    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Dodaj wykres z domyślnymi danymi.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Zapisz prezentację na dysku.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Ustaw wartość gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Zapisz prezentację na dysku.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![The gap width](gap_width.png)

## **FAQ**

**Czy istnieje limit liczby serii, które może zawierać pojedynczy wykres?**

Aspose.Slides nie narzuca sztywnego limitu liczby serii, które możesz dodać. Praktyczny limit zależy od czytelności wykresu oraz dostępnej pamięci w Twojej aplikacji.

**Co zrobić, gdy kolumny w klastrze są zbyt blisko siebie lub za daleko od siebie?**

Dostosuj ustawienie [gap_width](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartseries/gap_width/) dla tej serii (lub jej grupy nadrzędnej). Zwiększenie wartości powiększa odstęp między kolumnami, a zmniejszenie go przybliża kolumny do siebie.