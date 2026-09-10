---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst w Pythonie
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć dane hierarchiczne i dostosowywać poziomy, etykiety oraz kolory w wykresach Treemap i Sunburst za pomocą Aspose.Slides dla Pythona poprzez Javę."
---
## **Przegląd**

Treemap i Sunburst wyświetlają ten sam rodzaj danych hierarchicznych, ale używają różnych układów. Treemap rysuje hierarchię jako zagnieżdżone prostokąty, których pola reprezentują wartości liści. Sunburst przedstawia ją jako koncentryczne pierścienie: grupy najwyższego poziomu znajdują się blisko środka, a kategorie liści na zewnętrznym pierścieniu.

W Aspose.Slides for Python via Java każda wartość liczbowa jest obiektem [ChartDataPoint](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/). Jego metoda [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) zapewnia dostęp do liścia oraz jego grup nadrzędnych. Ten artykuł wyjaśnia to mapowanie i pokazuje, jak utworzyć oraz sformatować oba typy wykresów na podstawie tych samych danych przykładowych.

![Wykres Treemap z gałęziami Consumer i Business](treemap-hierarchy.png)

![Wykres Sunburst z tą samą hierarchią Consumer i Business](sunburst-hierarchy.png)

## **Zrozumienie kategorii, punktów danych i poziomów**

Przykład użyty poniżej posiada trzy poziomy kategorii oraz jedną serię liczbową:

| Gałąź | Odcinek | Liść | Przychód |
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

Indeksy zwracane przez [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) są liczone od liścia w górę:

| indeks `getDataPointLevels()` | Poziom logiczny | Reprezentacja Treemap | Reprezentacja Sunburst |
| ---: | --- | --- | --- |
| `0` | Liść | Prostokąt wartości | Segment zewnętrznego pierścienia |
| `1` | Odcinek | Prostokąt rodzica lub nagłówek | Segment środkowego pierścienia |
| `2` | Gałąź | Prostokąt najwyższego poziomu lub nagłówek | Segment wewnętrznego pierścienia |

Ten porządek jest taki sam dla obu typów wykresów, mimo że ich układy wizualne się różnią. Segment rodzica jest współdzielony przez kilka liści. Aby go sformatować, użyj odpowiedniego poziomu pierwszego punktu danych w danej grupie. Na przykład gałąź `Consumer` zaczyna się od punktu `Laptops`, a odcinek `Software` od punktu `Licenses`. Przechowywanie odwołań do tych punktów jest czytelniejsze i bezpieczniejsze niż używanie nieopisanych wyrażeń takich jak `data_points.get_Item(0)` czy `data_points.get_Item(6)`.

## **Utworzenie i dostosowanie obu typów wykresów**

Poniższy kompletny przykład tworzy Treemap na pierwszym slajdzie i Sunburst na drugim slajdzie. Buduje hierarchię, wyświetla wartość dla `Tablets`, nakłada stałe kolory na wybrane poziomy, formatuje etykietę gałęzi i zapisuje prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Dodaj kategorie liści. Element grupowania jest ustawiany tylko wtedy, gdy rozpoczyna się nowa grupa;
        # kolejne kategorie pozostają w tej grupie, aż zostanie ustawiony kolejny element.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Pokaż kategorię i wartość na liściu Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Formatuj gałąź Consumer poprzez pierwszy liść w tej gałęzi.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Formatuj odcinek Software poprzez pierwszy liść w tym odcinku.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout wpływa na etykiety rodziców w Treemap; Sunburst używa segmentów pierścieni.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Komórki kategorii i wartości używają tego samego wiersza arkusza, więc ich pozycje w kolekcji pozostają wyrównane. Gdy pracujesz z istniejącym wykresem zamiast tworzyć nowy, najpierw sprawdź wiersze kategorii i przechowaj nazwane odwołania do punktów danych oraz poziomów, które zamierzasz formatować.

## **Zachowanie i praktyczne uwagi**

### **Różnice między Treemap a Sunburst**

- Treemap używa pola do przekazywania wartości oraz zagnieżdżonych prostokątów do przedstawiania hierarchii. Metoda [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#setParentLabelLayout) kontroluje, jak etykiety rodziców są wyświetlane w tym typie wykresu.
- Sunburst używa kąta do przekazywania wartości oraz głębokości pierścienia do przedstawiania hierarchii. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#setParentLabelLayout) nie kontroluje etykiet pierścieni w tym typie wykresu.
- Oba typy wykresów używają tych samych poziomów grupowania kategorii oraz tego samego porządku liść‑do‑rodzic zwracanego przez [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), więc kod budujący dane i formatujący poziomy może być współdzielony.
- Wartości rodziców są obliczane na podstawie ich liści potomnych. Nie dodawaj oddzielnych punktów liczbowych dla gałęzi lub odcinków.

### **Sortowanie i kolejność segmentów**

Silnik układu wykresu określa ostateczne położenie prostokątów i segmentów pierścieni. Ułóż powiązane wiersze kategorii razem przed ich dodaniem, ale nie polegaj na konkretnej pozycji prostokąta ani kącie początkowym. Jeśli kolejność ma znaczenie, uwzględnij ją w etykietach lub użyj typu wykresu z wyraźną osią kategorii.

### **Motyw i stałe kolory**

Niefiltrowane poziomy wykresu dziedziczą kolory z motywu prezentacji. Przykład używa wyraźnych wypełnień RGB dla przewidywalnego wyniku. Jeśli wykres ma podążać za zmianami motywu, używaj kolorów schematu zamiast stałych wartości RGB i unikaj nadpisywania każdego poziomu. Sprawdź także kontrast etykiet po zmianie wypełnienia gałęzi lub odcinka.

### **Etykiety i dostępna przestrzeń**

PowerPoint może ukrywać lub obcinać etykiety, gdy segment jest zbyt mały. Zwiększenie rozmiaru wykresu, skrócenie nazw kategorii lub wyświetlenie mniejszej liczby pól etykiet zwykle daje czytelniejszy rezultat. Etykieta może łączyć nazwę kategorii, nazwę serii i wartość za pomocą [DataLabelFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datalabelformat/), ale włączanie wszystkich pól często utrudnia odczytanie wykresów hierarchicznych.

### **Eksport i renderowanie**

Zapis do PPTX zachowuje możliwość edycji wykresu. Gdy Aspose.Slides renderuje prezentację do PDF lub obrazu, obsługiwane wypełnienia i ustawienia etykiet są renderowane razem z wykresem. Zamiana czcionek oraz małe różnice w dostępnej przestrzeni układu mogą zmienić łamanie linii lub widoczność etykiet, więc zainstaluj wymagane czcionki i zweryfikuj kluczowe cele eksportu.

## **FAQ**

**Dlaczego zmiana poziomu rodzica wpływa na kilka liści?**

Gałąź lub odcinek jest współdzielonym segmentem wizualnym. Jego [ChartDataPointLevel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapointlevel/) można osiągnąć przez liść potomny, ale formatowanie należy do współdzielonego segmentu rodzica, a nie wyłącznie do tego liścia.

**Dlaczego brak etykiety danych?**

Najpierw włącz wymagane pola w obiekcie [DataLabelFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datalabelformat/) etykiety. Następnie sprawdź, czy segment ma wystarczająco miejsca. Layout rodzica w Treemap, wymiary wykresu, długość etykiety, rozmiar czcionki i liczba włączonych pól wpływają na to, czy etykieta może zostać wyświetlona.

**Czy mogę ustawić dokładną kolejność lub współrzędne segmentów?**

Możesz kontrolować kolejność wierszy źródłowych i utrzymać każdą grupę ciągłą, ale nie możesz przypisać dokładnych prostokątów Treemap ani kątów Sunburst. Silnik układu wykresu wylicza je na podstawie hierarchii, wartości i dostępnej przestrzeni.

**Dlaczego kolory zmieniają się po zmianie motywu prezentacji?**

Wypełnienia oparte na motywie są zaprojektowane tak, aby podążały za paletą prezentacji. Zastosuj wyraźne kolory RGB do poziomów, które mają pozostać stałe, lub używaj kolorów schematu, gdy preferujesz automatyczne dostosowanie do nowego motywu.

**Czy formatowanie niestandardowe zostanie zachowane przy eksporcie do PDF i obrazu?**

Tak, obsługiwane wypełnienia wykresu i ustawienia etykiet są uwzględniane podczas renderowania. Dla spójnych wyników na różnych systemach udostępnij wymagane czcionki i przetestuj ostateczny rozmiar eksportu, ponieważ dopasowanie etykiet zależy od układu.

## **Zobacz też**

- [Utwórz wykresy Treemap](/slides/pl/python-java/create-chart/#create-tree-map-charts)
- [Utwórz wykresy Sunburst](/slides/pl/python-java/create-chart/#create-sunburst-charts)
- [Eksportuj wykresy w prezentacji](/slides/pl/python-java/export-chart/)
- [Zarządzaj motywami prezentacji](/slides/pl/python-java/presentation-theme/)