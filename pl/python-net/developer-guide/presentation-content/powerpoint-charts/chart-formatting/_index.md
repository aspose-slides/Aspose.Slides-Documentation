---
title: Formatowanie wykresów w prezentacjach przy użyciu Pythona
linktitle: Formatowanie wykresu
type: docs
weight: 60
url: /pl/python-net/chart-formatting/
keywords:
- formatowanie wykresu
- formatowanie wykresu
- element wykresu
- właściwości wykresu
- ustawienia wykresu
- opcje wykresu
- właściwości czcionki
- zaokrąglona ramka
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla Pythona przy użyciu .NET i podnieś swoją prezentację PowerPoint dzięki niestandardowym osiom, czcionkom, formatom liczbowym oraz zaokrąglonym obramowaniom wykresu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu i wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Pokazuje również, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować predefiniowane formaty liczbowe do danych wykresu oraz włączyć zaokrąglone rogi obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresu w prezentacji.

## **Formatuj elementy wykresu**

Użyj [Wykres](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) do formatowania tytułów wykresu, osi, linii siatki, legend i obszaru wykresu. Ten przykład tworzy wykres liniowy z znacznikami i domyślnymi danymi, a następnie stosuje osobne style tekstu i linii do jego osi wartości i osi kategorii. Rozmiary czcionek i grubości linii podawane są w punktach; etykiety kategorii są obrócone o 45 stopni.

Oś wartości używa [format_liczbowy](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) niezależnie od komórek źródłowych. Jej skala przebiega od -2 do 15, z głównymi interwałami co 2 i mniejszymi interwałami 0,5. Przykład łączy także formatowanie procentowe z [jednostka_wyświetlania](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ustawioną na tysiące, więc dopasuj te ustawienia do znaczenia i wielkości swoich danych. Legenda pozostaje poza obszarem wykresu, ponieważ [nakładka](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) jest wyłączona. Wypełnienia tylnych ścian i podłogi konfigurowane są przez [ściana_tylna](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) i [podłoga](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), ale te powierzchnie są widoczne tylko w wykresach 3D.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw właściwości czcionki dla wykresu**

Ustaw domyślny rozmiar czcionki dla tekstu wykresu za pomocą [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Przykład tworzy skumulowany wykres kolumnowy z czcionką 20 punktów i włącza etykiety wartości dla pierwszej serii poprzez [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Elementy tekstowe z własnymi explicite ustawieniami czcionki mogą nadpisać domyślne ustawienia wykresu.

```python
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

Użyj [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) aby zastosować wbudowany format liczbowy do komórek skoroszytu wykresu. Ten przykład tworzy skumulowany wykres kolumnowy z domyślnymi, opartymi na komórkach danymi i stosuje indeks formatu 10 (`0.00%`) do każdej komórki wartości serii. Zmienia to sposób wyświetlania wartości w skoroszycie bez zmiany leżących pod nimi liczb; na przykład 0,25 jest wyświetlane jako 25,00%. Formaty osi i etykiet danych można konfigurować osobno.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0,00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Ta tabela wymienia wbudowane indeksy formatów liczbowych wraz z reprezentatywnymi formatami Excel dla ustawień regionalnych angielskiego (Stany Zjednoczone). Dokładne ciągi formatu i ich wyświetlanie mogą się różnić w zależności od aplikacji i ustawień regionalnych, szczególnie dla walut i dat. Niektóre formaty Excel różnią się także od domyślnych w standardzie OOXML, jak opisano w [notatki implementacyjne formatu liczbowego Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Ustaw zaokrąglone krawędzie obszaru wykresu**

Włącz [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/), aby zaokrąglić rogi obszaru wykresu. Przykład tworzy skumulowany wykres kolumnowy i używa [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) aby nadać jego konturowi jednolity szary kolor oraz styl jednej linii przed zapisaniem prezentacji.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Edytuj istniejące adnotacje wykresu**

Wykres może zawierać niestandardowe kształty, takie jak adnotacja tekstowa wyjaśniająca status raportu. Uzyskaj dostęp do tych kształtów przez [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Jego kolekcja [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) zawiera kształty należące do wykresu.

Zwykłe pole tekstowe umieszczone nad wykresem należy do slajdu, nawet jeśli wygląda jak część wykresu. Iteracja przez [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) znajduje wykres oraz zwykłe kształty slajdu, ale nie wylicza poszczególnych kształtów wewnątrz wykresu. Tytuły wykresów i etykiety danych są oddzielnymi elementami wykresu, a nie niestandardowymi adnotacjami w tej kolekcji.

Pobierz [chart-annotations.pptx](chart-annotations.pptx) i umieść go w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera wykres z niezgrupowaną adnotacją o treści „Preliminary results”, linią należącą do wykresu oraz zwykłym polem tekstowym slajdu o treści „Slide overlay”. Przykład znajduje pierwszy wykres na tym slajdzie i zmienia adnotację na „Final results”, gdy raport jest gotowy do publikacji. Sprawdza, czy kolekcja nie jest pusta i edytuje jedynie [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) z [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/), który nie jest `None` i zawiera oczekiwany tekst.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

Linia i pole tekstowe slajdu pozostają niezmienione. Poniższe obrazy pokazują wejście oraz zapisany, ponownie otwarty wynik:

| Before editing | After editing |
| --- | --- |
| ![Adnotacja wykresu – Preliminary results](chart-annotations-before.png) | ![Adnotacja wykresu – Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Przykład sprawdza tylko kształty najwyższego poziomu należące do wykresu. Jeśli adnotacja znajduje się wewnątrz [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), sprawdź również kolekcję [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) tej grupy. Powtarzaj to rekurencyjnie dla zagnieżdżonych grup, stosując te same kontrole tekstu do ich podrzędnych kształtów. Grupa sama w sobie jest kontenerem; nie traktuj jej jako pola tekstowego.
{{% /alert %}}

## **FAQ**

**Czy mogę ustawić półprzezroczyste wypełnienia dla kolumn/obszarów, zachowując nieprzezroczyste obramowanie?**

Tak. Przezroczystość wypełnienia i obramowanie konfigurowane są osobno. Jest to przydatne do poprawy czytelności siatki i danych w gęstych wizualizacjach.

**Jak mogę radzić sobie z etykietami danych, gdy nachodzą na siebie?**

Zmniejsz rozmiar czcionki, wyłącz nieistotne elementy etykiet (np. kategorie), dostosuj położenie etykiety, pokaż etykiety tylko dla wybranych punktów w razie potrzeby lub przełącz format na „wartość + legenda”.

**Czy mogę zastosować wypełnienia gradientowe lub wzorcowe do serii?**

Tak. Serie obsługują wypełnienia jednolite, gradientowe i wzorcowe. W praktyce używaj gradientów oszczędnie i unikaj kombinacji, które obniżają kontrast względem siatki i tekstu.