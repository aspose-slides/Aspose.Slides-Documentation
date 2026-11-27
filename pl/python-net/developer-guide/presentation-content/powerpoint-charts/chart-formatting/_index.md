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
- zaokrąglone obramowanie
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla Pythona poprzez .NET i podnieś swoją prezentację PowerPoint dzięki niestandardowym osiom, czcionkom, formatom liczbowym i zaokrąglonym obramowaniom wykresu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu i wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Pokazuje także, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wstępnie zdefiniowane formaty numeryczne do danych wykresu oraz włączyć zaokrąglone rogi obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresów w prezentacji.

Dla oddzielnych wypełnień i konturów w rosnących i spadających przedziałach, zobacz [przykład wykresu giełdowego](/slides/pl/python-net/create-chart/#create-stock-charts).

## **Formatowanie elementów wykresu**

Użyj [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), aby sformatować tytuły wykresu, osie, linie siatki, legendy i obszar wykresu. Ten przykład tworzy wykres liniowy z markerami i domyślnymi danymi, a następnie stosuje oddzielne style tekstu i linii do osi wartości i osi kategorii. Rozmiary czcionek i szerokości linii podawane są w punktach; etykiety kategorii są obrócone o 45 stopni.

Oś wartości używa [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) niezależnie od komórek źródłowych. Jej skala rozciąga się od -2 do 15, z głównymi przedziałami co 2 i mniejszymi przedziałami co 0,5. Przykład łączy także formatowanie procentowe z [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ustawionym na tysiące, więc dostosuj te ustawienia do znaczenia i wielkości swoich danych. Legenda pozostaje poza obszarem wykresu, ponieważ [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) jest wyłączone. Wypełnienia tylnej ściany i podłogi konfigurowane są za pomocą [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) oraz [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), ale te powierzchnie są widoczne tylko w wykresach 3D.

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

Ustaw domyślny rozmiar czcionki dla tekstu wykresu za pomocą [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Przykład tworzy skumulowany wykres słupkowy z czcionką 20 punktów i włącza etykiety wartości dla pierwszej serii przy użyciu [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Elementy tekstowe z własnymi wyraźnymi ustawieniami czcionki mogą nadpisać domyślne ustawienia wykresu.

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

## **Ponowne użycie formatowania ramki tekstowej dla legendy wykresu**

Aby dopasować legendę do nagłówka slajdu, ustaw czcionkę poprzez [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) w pierwszym paragrafie nagłówka. Wywołaj [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) na [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) legendy. Kopiuje to ustawienia ramki tekstowej, formatowanie pierwszego paragrafu oraz domyślne właściwości czcionki tego paragrafu. Formatowanie zastosowane bezpośrednio do pojedynczych fragmentów lub późniejszych paragrafów pozostaje lokalne dla źródła.

Przykład używa nagłówka wytłuszczonego, granatowego, 26‑punktowego Calibri jako szablonu. Po sformatowaniu legendy, używa [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/), aby zastosować to samo formatowanie do oddzielnego podpisu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

W zapisanej prezentacji legenda i podpis odpowiadają nagłówkowi pod względem rozmiaru, grubości i koloru. Legenda nadal wyświetla nazwy serii, a podpis zachowuje własny tekst. Jeśli fragment w podpisie ma już wyraźnie ustawiony rozmiar czcionki, ten rozmiar ma pierwszeństwo przed skopiowanym domyślnym rozmiarem paragrafu.

| Przed kopiowaniem | Po kopiowaniu |
| --- | --- |
| ![Wykres kwartalnej sprzedaży z zwykłymi czarnymi etykietami legendy i czarnym podpisem](legend-formatting-before.png) | ![Ten sam wykres z większymi, pogrubionymi, granatowymi etykietami legendy i pasującym podpisem](legend-formatting.png) |

## **Ustaw format liczbowy**

Użyj [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/), aby zastosować wbudowany format liczbowy do komórek skoroszytu wykresu. Ten przykład tworzy skumulowany wykres słupkowy z domyślnymi danymi opartymi na komórkach i stosuje indeks formatu 10 (`0.00%`) do każdej komórki wartości serii. Zmienia to sposób wyświetlania wartości w skoroszycie bez zmiany podstawowych liczb; na przykład 0,25 wyświetlane jest jako 25,00%. Formaty osi i etykiet danych mogą być konfigurowane osobno.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Poniższa tabela wymienia wbudowane indeksy formatów liczbowych wraz z przykładowymi formatami Excel dla regionalnego ustawienia angielskiego (Stany Zjednoczone). Dokładne ciągi formatów i ich wyświetlanie mogą się różnić w zależności od aplikacji i ustawień regionalnych, szczególnie dla walut i dat. Niektóre formaty Excel różnią się także od domyślnych w standardzie OOXML, co opisano w [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indeks | Format |
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

Włącz [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/), aby zaokrąglić rogi obszaru wykresu. Przykład tworzy skumulowany wykres słupkowy i używa [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/), aby nadać jego obramowaniu jednolity szary kolor i styl jednej linii przed zapisaniem prezentacji.

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

Wykres może zawierać niestandardowe kształty, takie jak adnotacja tekstowa wyjaśniająca status raportu. Dostęp do tych kształtów uzyskuje się przez [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Jego kolekcja [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) zawiera kształty należące do wykresu.

Zwykłe pole tekstowe umieszczone nad wykresem należy do slajdu, nawet jeśli wygląda na część wykresu. Iteracja przez [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) znajduje wykres oraz zwykłe kształty slajdu, ale nie wylicza poszczególnych kształtów wewnątrz wykresu. Tytuły wykresów i etykiety danych są oddzielnymi elementami wykresu, a nie niestandardowymi adnotacjami w tej kolekcji.

Pobierz [chart-annotations.pptx](chart-annotations.pptx) i umieść go w katalogu roboczym aplikacji. Jego pierwszy slajd zawiera wykres z niezwiniętą adnotacją o treści "Preliminary results", linią należącą do wykresu oraz zwykłym polem tekstowym slajdu o treści "Slide overlay". Przykład znajduje pierwszy wykres na tym slajdzie i zmienia adnotację na "Final results", gdy raport jest gotowy do publikacji. Sprawdza, czy kolekcja nie jest pusta i edytuje jedynie [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) z [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/), które nie jest `None` i zawiera oczekiwany tekst.

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

Linia i pole tekstowe slajdu pozostają niezmienione. Poniższe obrazy pokazują wejściowy oraz zapisany, ponownie otwarty wynik:

| Przed edycją | Po edycji |
| --- | --- |
| ![Adnotacja wykresu z napisem "Preliminary results"](chart-annotations-before.png) | ![Adnotacja wykresu z napisem "Final results"](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Przykład sprawdza tylko kształty należące do wykresu na najwyższym poziomie. Jeśli adnotacja znajduje się wewnątrz [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), sprawdź również kolekcję [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) tej grupy. Powtarzaj to rekurencyjnie dla zagnieżdżonych grup, stosując te same kontrole tekstu do ich kształtów podrzędnych. Grupa sama w sobie jest kontenerem; nie traktuj jej jako pola tekstowego.
{{% /alert %}}

## **FAQ**

**Czy mogę ustawić półprzezroczyste wypełnienia dla słupków/obszarów, zachowując nieprzezroczyste obramowanie?**

Tak. Przezroczystość wypełnienia i obramowanie są konfigurowane oddzielnie. Jest to przydatne do poprawy czytelności siatki i danych w gęstych wizualizacjach.

**Jak mogę radzić sobie z etykietami danych, gdy nakładają się na siebie?**

Zmniejsz rozmiar czcionki, wyłącz nieistotne elementy etykiet (na przykład kategorie), dostosuj położenie etykiety, wyświetlaj etykiety tylko dla wybranych punktów, jeśli to konieczne, lub przełącz format na „wartość + legenda”.

**Czy mogę zastosować wypełnienia gradientowe lub wzorcowe do serii?**

Tak. Serie obsługują wypełnienia jednolite, gradientowe i wzorcowe. W praktyce używaj gradientów oszczędnie i unikaj kombinacji, które obniżają kontrast względem siatki i tekstu.