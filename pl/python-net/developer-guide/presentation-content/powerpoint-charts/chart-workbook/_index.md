---
title: Zarządzanie skoroszytami wykresów w prezentacjach przy użyciu Pythona
linktitle: Skoroszyt wykresu
type: docs
weight: 70
url: /pl/python-net/chart-workbook/
keywords:
- skoroszyt wykresu
- dane wykresu
- komórka skoroszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny skoroszyt
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie skoroszytu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj Aspose.Slides for Python via .NET: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresów za pomocą strumieni skoroszytu, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje także pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

Dla komórek skoroszytu, które reprezentują brakujące dane, zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/python-net/chart-series/) aby poznać różnicę między pustą komórką a zerem oraz porównanie wykresu liniowego dostępnych trybów wyświetlania.

## **Uwzględnianie danych z ukrytych wierszy i kolumn**

Użyj [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) aby kontrolować, czy wykres używa danych z ukrytych wierszy i kolumn arkusza. Ustaw na `True`, aby wykresem były wyświetlane tylko widoczne komórki, lub na `False`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odkrywa wierszy ani kolumn arkusza.

[Sample presentation](hidden-source-data.pptx) zawiera wykres kolumnowy jako pierwszy kształt na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Worksheet row | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych przez [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) i odczytaj [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) aby sprawdzić ich status ukrycia. Ta właściwość jest tylko do odczytu. W tym pliku B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `False`, `True` i `True`.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony skoroszyt za pomocą [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i wczytaj go ponownie przy pomocy [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Przy uwzględnianiu wszystkich komórek użyj także [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) aby przywrócić pełny zakres, włącznie z ukrytą kategorią luty. Samej zmiany flagi nie wystarczy, aby odświeżyć pamięć podręczną danych wykresu i etykiet kategorii w tym przykładzie.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Odśwież dane wykresu z osadzonego skoroszytu.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Przywróć pełny zakres źródłowy, w tym ukryte kategorie.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Przykład zapisuje dwie wersje prezentacji: jedną z jedynie widocznymi wartościami detalicznymi (10 i 20) oraz drugą ze wszystkimi sześcioma wartościami. Poniższe obrazy zostały wyrenderowane z zapisanych prezentacji po ich ponownym otwarciu; oba pliki zachowują przypisane ustawienie rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych skoroszytach.

| Tylko widoczne komórki (`True`) | Wszystkie komórki (`False`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości detaliczne 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości detaliczne i hurtowe dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) kontroluje, jak wyświetlane są brakujące wartości; nie obejmuje ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/python-net/chart-series/#control-the-display-of-empty-cells) po przykład.

## **Pobieranie zakresu danych wykresu**

Przed aktualizacją danych skoroszytu w istniejącej prezentacji, sprawdź zakresy źródłowe, aby określić, które komórki arkusza każdy wykres używa. Metoda [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) zwraca bieżący zakres danych jako formułę kwalifikowaną do arkusza, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` to nazwa arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5, włącznie. Znaki dolarowe wskazują odwołania bezwzględne do wierszy i kolumn.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego skoroszytu. Jeśli wykres nie używa skoroszytu jako źródła danych, metoda zgłasza wyjątek. Więcej informacji znajdziesz w [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Ten przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdym slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu oraz jego zakres źródłowy. Jeśli zakres nie może zostać pobrany, wypisuje komunikat diagnostyczny i przechodzi do kolejnego wykresu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Odczyt i zapis danych wykresu z skoroszytu**

Aspose.Slides for Python via .NET udostępnia metody [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/), które pozwalają odczytywać i zapisywać skoroszyty danych wykresu (zawierające dane wykresu edytowane przy pomocy Aspose.Cells). **Uwaga** dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład używa prezentacji z wykresem jako pierwszym kształtem na pierwszym slajdzie. Odczytuje osadzony skoroszyt do strumienia, czyści istniejące serie i kategorie, a następnie zapisuje ten sam skoroszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Walidacja układu wykresu po modyfikacji skoroszytu**

Po zastąpieniu osadzonego skoroszytu zmodyfikowanym, wykres zachowuje pierwotne kolekcje serii i kategorii. Ten niezgodny stan może spowodować, że [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) zakończy się błędem indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisem zaktualizowanego skoroszytu do wykresu. Ten przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie. Komentarz oznacza miejsce, w którym miałaby nastąpić edycja skoroszytu; działający przykład zapisuje oryginalny skoroszyt z powrotem i w pamięci waliduje układ.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Zmodyfikuj strumień skoroszytu tutaj, na przykład używając Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Czyszczenie kolekcji usuwa przestarzałe odwołania danych przed zapisaniem skoroszytu. Zbuduj ponownie wymagane mapowania serii i kategorii dla zaktualizowanego skoroszytu przed użyciem wykresu.

## **Ustawianie własnych formatów liczbowych dla komórek skoroszytu**

Użyj [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/), aby kontrolować, jak wartości liczbowe wyświetlane są w osadzonym skoroszycie wykresu. Na przykład raport może wymagać wyświetlenia współczynnika konwersji jako procentu z czterema miejscami po przecinku oraz współczynnika wyświetlanego z pięcioma miejscami po przecinku. Zachowaj oba wartości jako liczby, aby pozostały dostępne do obliczeń i rysowania wykresu.

Format liczbowy zmienia wyświetlanie, a nie przechowywaną wartość. Format `0.0000%` wyświetla `0.125` jako `12.5000%`; nie zastępuje przechowywanej liczby wartością `12.5`. Podobnie `0.00000` wyświetla `0.1234567` jako `0.12346` bez zaokrąglania wartości przechowywanej. Jeśli własny format jest pustym ciągiem (`""`), używany jest [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/).

Poniższy przykład tworzy wykres kolumnowy i uzyskuje dostęp do jego komórek przez [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). W arkuszu 0, B2 zawiera współczynnik konwersji, a C2 współczynnik. Obie komórki dostarczają wartości wykresu. Przykład dodatkowo włącza etykiety wartości powiązane z formatami źródłowymi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

Formaty komórek skoroszytu są oddzielne od formatów ustawianych bezpośrednio na osiach wykresu lub etykietach danych. W tym przykładzie każda etykieta wyświetla wartość swojej komórki źródłowej, ponieważ [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) jest włączone, a flagę powiązania formatu liczbowego z źródłem ustawia się na `True` ([is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/)). Po zapisaniu i ponownym otwarciu prezentacji etykiety wyświetlają `12.5000%` i `0.12346`, jak pokazano poniżej. Pionowa oś używa własnego [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`, z [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) ustawionym na `False`.

Aby sformatować etykietę danych niezależnie, ustaw jej flagę powiązania ze źródłem na `False` i przypisz własny [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). Nie zmieni to formatu komórki skoroszytu. Na przykład niezależny format etykiety `0.00` wyświetli pierwszą wartość jako `0.13`, podczas gdy B2 nadal wyświetla `12.5000%`. Zobacz [Chart Data Labels](/slides/pl/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) po bezpośrednie formatowanie etykiet.

Obraz poniżej został wyrenderowany z zapisanej prezentacji po jej ponownym otwarciu:

![Wykres kolumnowy z etykietami powiązanymi z źródłem, wyświetlającymi 12.5000% i 0.12346 oraz niezależnie sformatowaną osią liczbową.](custom-cell-formats.png)

## **Ustawienie komórki skoroszytu jako etykiety danych wykresu**

Możesz używać tekstu z komórek skoroszytu jako etykiet danych wykresu.

Ten przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 jako pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Zarządzanie arkuszami**

Właść­wość [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) zapewnia dostęp do arkuszy w skoroszycie wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwy poszczególnych arkuszy na konsolę.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Określenie typu źródła danych**

Wartości punktów serii mogą być także przechowywane bezpośrednio jako literały liczbowe. Zobacz [Set Series Values Using Numeric Literals](/slides/pl/python-net/chart-series/#set-series-values-using-numeric-literals) po kompletny przykład zapisu i odczytu. Typ źródła punktów jest oddzielny od wewnętrznej lub zewnętrznej konfiguracji skoroszytu wykresu; użycie literałów liczbowych nie usuwa automatycznie osadzonego skoroszytu.

Ten przykład tworzy wykres kolumnowy 3D z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa używa literału łańcuchowego; druga używa komórki C1 w arkuszu 0. Wyliczenie [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Można użyć właściwości [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) na [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy. Ten przykład sprawdza kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym skoroszytem .xlsb.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Odczytaj lub zmodyfikuj obsługiwane dane skoroszytu wykresu tutaj.
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje używanie zewnętrznych skoroszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego skoroszytu**

Użyj [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), aby wyeksportować osadzony skoroszyt wykresu do pliku i powiązać wykres z tym zewnętrznym skoroszytem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego skoroszyt. Zamyka strumień wyjściowy przed przypisaniem zewnętrznego skoroszytu jako źródła danych wykresu, a następnie zapisuje powiązaną prezentację.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Ustawienie zewnętrznego skoroszytu**

Za pomocą metody [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda może być także użyta do zaktualizowania ścieżki do zewnętrznego skoroszytu (jeśli został on przeniesiony).

Choć nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz ich używać jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego skoroszytu, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Ten przykład używa zewnętrznego skoroszytu, którego arkusz o nazwie `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy skoroszyt i używa [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/), aby zmapować A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z powiązanym wykresem.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kontroluje, czy skoroszyt jest ładowany.

* Gdy `update_chart_data` jest `False`, aktualizowana jest tylko ścieżka do skoroszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego skoroszytu, więc skoroszyt może być niedostępny.
* Gdy `update_chart_data` jest `True`, dane wykresu są aktualizowane z docelowego skoroszytu.

Poniższy przykład przypisuje przykładowy adres URL z `update_chart_data` ustawionym na `False`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego skoroszytu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Pobranie ścieżki skoroszytu źródła danych zewnętrznych wykresu**

Aby zidentyfikować skoroszyt powiązany z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i pobierz jego ścieżkę.

Ten przykład sprawdza pierwszy kształt na pierwszym slajdzie prezentacji z powiązanym zewnętrznym skoroszytem. Jeśli jest to wykres powiązany z zewnętrznym skoroszytem, przykład wypisuje [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) na konsolę. Następnie zapisuje kopię prezentacji.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Edycja danych wykresu**

Możesz edytować dane w zewnętrznych skoroszytach tak samo, jak zmieniasz zawartość wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może być załadowany, zostaje zgłoszony wyjątek.

Ten przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie i jest powiązany z dostępnym zewnętrznym skoroszytem. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości w komórkach może aktualizować powiązany zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalny skoroszyt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Odzyskiwanie skoroszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), skonfiguruj jego [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), i ustaw [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) na `True` przed otwarciem prezentacji.

Poniższy przykład w Pythonie odtwarza dane skoroszytu dla wykresu, który jest pierwszym kształtem na pierwszym slajdzie i odwołuje się do niedostępnego zewnętrznego skoroszytu. Dostęp do odtworzonych danych uzyskuje się przez [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) i [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Odczytaj lub zmodyfikuj odzyskane dane skoroszytu tutaj.
    else:
        print("The first shape is not a chart.")
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie pamięci podręcznej danych wykresu jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) oraz [ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych skoroszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona na ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie skoroszytu może wymagać aktualizacji linku.

**Czy mogę używać skoroszytów znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisie prezentacji?**

Prezentacja przechowuje [link do pliku zewnętrznego](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Edycja danych wykresu powiązanych z komórkami może również zaktualizować powiązany lokalny plik XLSX. Użyj kopii skoroszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Typowym rozwiązaniem jest uprzednie usunięcie ochrony lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) i podlinkowanie do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.