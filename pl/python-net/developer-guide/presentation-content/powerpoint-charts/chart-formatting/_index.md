---
title: Formatowanie wykresów w prezentacjach przy użyciu Pythona
linktitle: Formatowanie wykresu
type: docs
weight: 60
url: /pl/python-net/chart-formatting/
keywords:
- format wykresu
- formatowanie wykresu
- obiekt wykresu
- właściwości wykresu
- ustawienia wykresu
- opcje wykresu
- właściwości czcionki
- zaokrąglona krawędź
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla Pythona przez .NET i podnieś swoją prezentację PowerPoint lub OpenDocument dzięki profesjonalnemu, przyciągającemu uwagę stylowi."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu i wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Pokazuje również, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wstępnie zdefiniowane i niestandardowe formaty liczbowe do danych wykresu oraz włączyć zaokrąglone rogi obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresu w prezentacji.

## **Formatowanie elementów wykresu**

Aspose.Slides for Python umożliwia programistom dodawanie własnych wykresów do slajdów od podstaw. Ta sekcja wyjaśnia, jak formatować różne elementy wykresu, w tym osie kategorii i wartości.

Aspose.Slides provides a simple API for managing chart elements and applying custom formatting:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj wykres z domyślnymi danymi wybranego typu (w tym przykładzie `ChartType.LINE_WITH_MARKERS`).
1. Uzyskaj dostęp do osi wartości wykresu i ustaw następujące elementy:
   1. Ustaw **format linii** dla głównych linii siatki osi wartości.
   1. Ustaw **format linii** dla pomocniczych linii siatki osi wartości.
   1. Ustaw **format liczbowy** dla osi wartości.
   1. Ustaw **minimalne, maksymalne, jednostki główne i pomocnicze** dla osi wartości.
   1. Ustaw **właściwości tekstu** dla etykiet osi wartości.
   1. Ustaw **tytuł** dla osi wartości.
   1. Ustaw **format linii** dla osi wartości.
1. Uzyskaj dostęp do osi kategorii wykresu i ustaw następujące elementy:
   1. Ustaw **format linii** dla głównych linii siatki osi kategorii.
   1. Ustaw **format linii** dla pomocniczych linii siatki osi kategorii.
   1. Ustaw **właściwości tekstu** dla etykiet osi kategorii.
   1. Ustaw **tytuł** dla osi kategorii.
   1. Ustaw **pozycjonowanie etykiet** dla osi kategorii.
   1. Ustaw **kąt obrotu** dla etykiet osi kategorii.
1. Uzyskaj dostęp do legendy wykresu i ustaw jej **właściwości tekstu**.
1. Pokaż legendę wykresu bez nakładania się na wykres.
1. Uzyskaj dostęp do **drugorzędnej osi wartości** wykresu i ustaw następujące elementy:
   1. Włącz drugorzędną **osię wartości**.
   1. Ustaw **format linii** dla drugorzędnej osi wartości.
   1. Ustaw **format liczbowy** dla drugorzędnej osi wartości.
   1. Ustaw **minimalne, maksymalne, jednostki główne i pomocnicze** dla drugorzędnej osi wartości.
1. Wykreśl pierwszą serię wykresu na drugorzędnej osi wartości.
1. Ustaw kolor wypełnienia tylnej ściany wykresu.
1. Ustaw kolor wypełnienia obszaru wykresu.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:

    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Dodaj przykładowy wykres.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Ustaw tytuł wykresu.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Ustaw format głównych linii siatki dla osi wartości.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Ustaw format pomocniczych linii siatki dla osi wartości.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Ustaw format liczbowy osi wartości.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Ustaw maksymalną, minimalną, jednostkę główną i pomocniczą osi wartości.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Ustaw właściwości tekstu osi wartości.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Ustaw tytuł osi wartości.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Ustaw format głównych linii siatki dla osi kategorii.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Ustaw format pomocniczych linii siatki dla osi kategorii.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Ustaw właściwości tekstu osi kategorii.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Ustaw tytuł osi kategorii.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Ustaw pozycję etykiet osi kategorii.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Ustaw kąt obrotu etykiet osi kategorii.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Ustaw właściwości tekstu legendy.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Pokaż legendę wykresu nakładającą się na wykres.
    chart.legend.overlay = True
                
    # Ustaw kolor tylnej ściany wykresu.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Ustaw kolor obszaru wykresu.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Zapisz prezentację.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw właściwości czcionki wykresu**

Aspose.Slides for Python obsługuje ustawianie właściwości związanych z czcionką dla wykresów. Postępuj zgodnie z poniższymi krokami, aby skonfigurować właściwości czcionki wykresu:

1. Utwórz obiekt [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Dodaj wykres do slajdu.
1. Ustaw wysokość czcionki.
1. Zapisz zmodyfikowaną prezentację.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw format numeryczny**

Aspose.Slides for Python udostępnia prosty interfejs API do zarządzania formatami danych wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj wykres z domyślnymi danymi dowolnego wybranego typu.
1. Ustaw wstępny format liczbowy z dostępnych wartości wstępnych.
1. Przejdź przez komórki danych wykresu w każdej serii i ustaw format liczbowy.
1. Zapisz prezentację.
1. Ustaw niestandardowy format liczbowy.
1. Przejdź przez komórki danych wykresu w każdej serii i ustaw inny format liczbowy.
1. Zapisz prezentację.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Dodaj domyślny wykres słupkowy grupowy.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Ustaw wstępny format liczbowy.
    # Przejdź przez każdą serię wykresu.
    for series in chart.chart_data.series:
        # Przejdź przez każdy punkt danych w serii.
        for cell in series.data_points:
            # Ustaw format liczbowy.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Zapisz prezentację.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Dostępne wstępne formaty liczbowe i ich odpowiadające indeksy są wymienione poniżej.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Ustaw zaokrąglone krawędzie obszaru wykresu**

Aspose.Slides for Python obsługuje konfigurowanie obszaru wykresu przy użyciu właściwości `Chart.has_rounded_corners`.

1. Utwórz obiekt [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Dodaj wykres do slajdu.
3. Ustaw typ wypełnienia wykresu oraz kolor wypełnienia.
4. Ustaw właściwość rounded-corners na `True`.
5. Zapisz zmodyfikowaną prezentację.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę ustawić półprzezroczyste wypełnienia dla kolumn/obszarów, zachowując nieprzezroczyste krawędzie?**

Tak. Przezroczystość wypełnienia i kontur są konfigurowane osobno. Jest to przydatne dla poprawy czytelności siatki i danych w gęstych wizualizacjach.

**Jak radzić sobie z etykietami danych, gdy nakładają się na siebie?**

Zmniejsz rozmiar czcionki, wyłącz nieistotne elementy etykiet (na przykład kategorie), ustaw przesunięcie/pozycję etykiety, wyświetlaj etykiety tylko dla wybranych punktów w razie potrzeby lub zmień format na "wartość + legenda".

**Czy mogę zastosować wypełnienia gradientowe lub wzorcowe do serii?**

Tak. Zarówno wypełnienia jednorodne, jak i gradientowe/wzorcowe są zazwyczaj dostępne. W praktyce używaj gradientów oszczędnie i unikaj kombinacji, które zmniejszają kontrast w stosunku do siatki i tekstu.