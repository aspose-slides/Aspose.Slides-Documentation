---
title: Dostosuj punkty danych w wykresach Treemap i Sunburst w Pythonie
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- wykres treemap
- wykres sunburst
- wykres hierarchiczny
- punkt danych
- etykieta danych
- kolor gałęzi
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć dane hierarchiczne i dostosowywać poziomy, etykiety oraz kolory w wykresach Treemap i Sunburst przy użyciu Aspose.Slides dla Pythona poprzez .NET."
---
## **Przegląd**

Treemap i Sunburst wyświetlają ten sam rodzaj danych hierarchicznych, ale używają różnych układów. Treemap rysuje hierarchię jako zagnieżdżone prostokąty, których pola reprezentują wartości liści. Sunburst rysuje ją jako koncentryczne pierścienie: grupy najwyższego poziomu znajdują się blisko środka, a kategorie liści na zewnętrznym pierścieniu.

W Aspose.Slides for Python via .NET każda wartość numeryczna jest obiektem [ChartDataPoint](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapoint/). Jego kolekcja [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) zapewnia dostęp do liścia oraz jego grup nadrzędnych. Ten artykuł wyjaśnia to mapowanie i pokazuje, jak utworzyć i sformatować oba typy wykresów na podstawie tych samych danych przykładowych.

![Diagram Treemap z gałęziami Consumer i Business](treemap-hierarchy.png)

![Diagram Sunburst z tą samą hierarchią Consumer i Business](sunburst-hierarchy.png)

## **Zrozumienie kategorii, punktów danych i poziomów**

Przykład użyty poniżej zawiera trzy poziomy kategorii i jedną serię numeryczną:

| Gałąź | Pęd | Liść | Przychód |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Każdy wiersz tworzy jedną kategorię liścia i jeden punkt danych. Poziomy grupowania kategorii opisują ścieżkę od tego liścia do jego rodziców. Dla pierwszego wiersza ścieżka to `Consumer > Computers > Laptops`.

Indeksy w [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) liczą się od liścia w górę:

| `data_point_levels` index | Poziom logiczny | Reprezentacja Treemap | Reprezentacja Sunburst |
| ---: | --- | --- | --- |
| `0` | Liść | Prostokąt wartości | Segment zewnętrznego pierścienia |
| `1` | Łodyga | Prostokąt rodzica lub nagłówek | Segment środkowego pierścienia |
| `2` | Gałąź | Prostokąt najwyższego poziomu lub nagłówek | Segment wewnętrznego pierścienia |

Kolejność ta jest taka sama dla obu typów wykresów, mimo że ich układy wizualne się różnią. Segment rodzica jest współdzielony przez kilka liści. Aby sformatować go, użyj odpowiadającego poziomu pierwszego punktu danych w tej grupie. Na przykład gałąź `Consumer` zaczyna się od punktu `Laptops`, natomiast łodyga `Software` zaczyna się od punktu `Licenses`. Przechowywanie odwołań do tych punktów jest jaśniejsze i bezpieczniejsze niż używanie nieopisanych wyrażeń, takich jak `data_points[0]` lub `data_points[6]`.

## **Utworzenie i dostosowanie obu typów wykresów**

Poniższy kompletny przykład tworzy wykres Treemap na pierwszym slajdzie i wykres Sunburst na drugim slajdzie. Buduje hierarchię, wyświetla wartość dla `Tablets`, stosuje stałe kolory do wybranych poziomów, formatuje etykietę gałęzi i zapisuje prezentację.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Dodaj kategorie liści. Element grupujący jest ustawiany tylko wtedy, gdy rozpoczyna się nowa grupa;
    # kolejne kategorie pozostają w tej grupie, aż zostanie ustawiony kolejny element.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Pokaż kategorię i wartość w liściu Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Sformatuj gałąź Consumer poprzez pierwszy liść w tej gałęzi.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Sformatuj łodygę Software poprzez pierwszy liść w tej łodydze.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout wpływa na etykiety rodziców w Treemap; Sunburst używa segmentów pierścieni.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Komórki kategorii i komórki wartości używają tego samego wiersza arkusza, więc ich pozycje w kolekcji pozostają wyrównane. Gdy pracujesz z istniejącym wykresem zamiast go tworzyć, najpierw sprawdź wiersze kategorii i zachowaj nazwane odwołania do punktów danych oraz poziomów, które zamierzasz sformatować.

## **Zachowanie i praktyczne uwagi**

### **Różnice między Treemap a Sunburst**

- Treemap używa pola powierzchni do przekazywania wartości oraz zagnieżdżonych prostokątów do przekazywania hierarchii. Właściwość [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartseries/parent_label_layout/) kontroluje, jak etykiety rodziców wyświetlają się w tym typie wykresu.
- Sunburst używa kąta do przekazywania wartości oraz głębokości pierścienia do przekazywania hierarchii. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartseries/parent_label_layout/) nie kontroluje etykiet pierścieni.
- Oba typy wykresów używają tych samych poziomów grupowania kategorii i tego samego porządku liść‑do‑rodzica w `data_point_levels`, więc kod budujący dane i formatujący poziomy może być współdzielony.
- Wartości rodziców są obliczane na podstawie ich liści potomnych. Nie dodawaj osobnych punktów liczbowych dla gałęzi lub łodyg.

### **Sortowanie i kolejność segmentów**

Silnik układu wykresu określa ostateczne położenie prostokątów i segmentów pierścieni. Ułóż powiązane wiersze kategorii razem przed ich dodaniem, ale nie polegaj na konkretnym położeniu prostokąta ani kącie początkowym. Jeśli kolejność ma znaczenie, uwzględnij ją w etykietach lub użyj typu wykresu z wyraźną osią kategorii.

### **Motyw i stałe kolory**

Nie sformatowane poziomy wykresu dziedziczą kolory z motywu prezentacji. Przykład używa wyraźnych wypełnień RGB, aby uzyskać przewidywalny wynik. Jeśli wykres ma podążać za zmianami motywu, używaj kolorów ze schematu zamiast stałych wartości RGB i unikaj nadpisywania każdego poziomu. Sprawdź również kontrast etykiet po zmianie wypełnienia gałęzi lub łodygi.

### **Etykiety i dostępna przestrzeń**

PowerPoint może ukrywać lub obcinać etykiety, gdy segment jest zbyt mały. Zwiększenie rozmiaru wykresu, skrócenie nazw kategorii lub wyświetlenie mniejszej liczby pól etykiety zazwyczaj daje czytelniejszy wynik. Etykieta może łączyć nazwę kategorii, nazwę serii i wartość za pomocą [DataLabelFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabelformat/), ale włączanie wszystkich pól często utrudnia czytanie wykresów hierarchicznych.

### **Eksport i renderowanie**

Zapis do formatu PPTX zachowuje możliwość edycji wykresu. Gdy Aspose.Slides renderuje prezentację do PDF lub obrazu, obsługiwane wypełnienia i ustawienia etykiet są renderowane wraz z wykresem. Podstawianie czcionek i niewielkie różnice w dostępnej przestrzeni układu mogą zmienić łamanie linii lub widoczność etykiet, dlatego zainstaluj wymagane czcionki i zweryfikuj istotne cele eksportu.

## **FAQ**

**Dlaczego zmiana poziomu rodzica wpływa na kilka liści?**

Gałąź lub łodyga jest współdzielonym segmentem wizualnym. Jej [ChartDataPointLevel](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapointlevel/) można osiągnąć przez potomny liść, ale formatowanie dotyczy współdzielonego segmentu rodzica, a nie tylko tego liścia.

**Dlaczego brakuje etykiety danych?**

Najpierw włącz wymagane pola w obiekcie [DataLabelFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabelformat/) etykiety. Następnie sprawdź, czy segment ma wystarczająco dużo miejsca. Układ etykiet rodziców w Treemap, wymiary wykresu, długość etykiety, rozmiar czcionki oraz liczba włączonych pól wpływają na to, czy etykieta może być wyświetlona.

**Czy mogę ustawić dokładną kolejność lub współrzędne segmentów?**

Możesz kontrolować kolejność wierszy źródłowych i utrzymać każdą grupę w jedności, ale nie możesz przypisać dokładnych prostokątów Treemap ani kątów Sunburst. Silnik układu wykresu oblicza je na podstawie hierarchii, wartości i dostępnej przestrzeni.

**Dlaczego kolory zmieniają się po zmianie motywu prezentacji?**

Wypełnienia oparte na motywie są zaprojektowane tak, aby podążały za paletą prezentacji. Zastosuj wyraźne kolory RGB do poziomów, które mają pozostać stałe, lub zachowaj kolory ze schematu, gdy preferowane jest dostosowanie do nowego motywu.

**Czy niestandardowe formatowanie zostanie zachowane w eksportach PDF i obrazu?**

Tak, obsługiwane wypełnienia wykresu i ustawienia etykiet są uwzględniane podczas renderowania. Aby uzyskać spójne wyniki na różnych systemach, udostępnij wymagane czcionki i przetestuj ostateczny rozmiar eksportu, ponieważ dopasowanie etykiet zależy od układu.

## **Zobacz także**

- [Tworzenie wykresów Treemap](/slides/pl/python-net/create-chart/#create-tree-map-charts)
- [Tworzenie wykresów Sunburst](/slides/pl/python-net/create-chart/#create-sunburst-charts)
- [Eksport wykresów prezentacji](/slides/pl/python-net/export-chart/)
- [Zarządzanie motywami prezentacji](/slides/pl/python-net/presentation-theme/)