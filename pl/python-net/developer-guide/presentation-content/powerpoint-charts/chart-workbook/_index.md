---
title: Zarządzanie książkami wykresów w prezentacjach przy użyciu Pythona
linktitle: Książka wykresu
type: docs
weight: 70
url: /pl/python-net/chart-workbook/
keywords:
- książka wykresu
- dane wykresu
- komórka książki
- etykieta danych
- arkusz
- źródło danych
- zewnętrzna książka
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie książki
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj Aspose.Slides for Python via .NET: łatwo zarządzaj książkami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z książkami roboczymi wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni książek roboczych, używać komórek książki jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Następnie omawia pracę z zewnętrznymi książkami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzną książkę, pobrać ścieżkę zewnętrznej książki powiązanej z wykresem oraz edytować dane wykresu, gdy książka jest dostępna.

Dla komórek książki reprezentujących brakujące dane zobacz [Kontrola wyświetlania pustych komórek](/slides/pl/python-net/chart-series/) aby zobaczyć różnicę między pustą komórką a zerem oraz porównanie trybów wyświetlania w wykresie liniowym.

## **Uwzględnianie danych z ukrytych wierszy i kolumn**

Użyj [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/plot_visible_cells_only/), aby kontrolować, czy wykres uwzględnia dane z ukrytych wierszy i kolumn arkusza. Ustaw na `True`, aby rysować tylko widoczne komórki, lub `False`, aby uwzględniać zarówno widoczne, jak i ukryte komórki. To ustawienie steruje rysowaniem wykresu; nie ukrywa ani nie odsłania wierszy czy kolumn arkusza.

Pobierz [hidden-source-data.pptx](hidden-source-data.pptx) i umieść go w katalogu roboczym. Jego pierwsza slajd zawiera wykres kolumnowy jako pierwszy kształt. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Sprzedaż detaliczna | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych poprzez [ChartData.chart_data_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) i odczytaj [ChartDataCell.is_hidden](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatacell/is_hidden/), aby sprawdzić ich status ukrycia. Ta właściwość jest tylko do odczytu. W tym pliku B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `False`, `True` i `True`.

Dla tego przykładu odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzoną książkę za pomocą [read_workbook_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i ponownie wczytaj ją przy pomocy [write_workbook_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Gdy uwzględniasz wszystkie komórki, użyj również [set_range](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_range/), aby przywrócić pełny zakres, w tym ukrytą kategorię luty. Samo zmienienie flagi nie wystarczy, aby odświeżyć buforowane dane wykresu i etykiety kategorii w tym przykładzie.

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

            # Odśwież dane wykresu z osadzonej książki.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Przywróć pełny zakres źródłowy, w tym ukryte kategorie.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Przykład zapisuje `hidden_cells_True.pptx` zawierający tylko widoczne wartości Sprzedaży detalicznej (10 i 20) oraz `hidden_cells_False.pptx` z wszystkimi sześcioma wartościami. Poniższe obrazy zostały wygenerowane z zapisanych prezentacji po ich ponownym otwarciu; oba pliki zachowują przypisane ustawienie rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych książkach.

| Tylko widoczne komórki (`True`) | Wszystkie komórki (`False`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości Sprzedaży detalicznej 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości Sprzedaży detalicznej i hurtowej dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [Chart.display_blanks_as](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/display_blanks_as/) kontroluje, jak wyświetlane są brakujące wartości; nie uwzględnia ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontrola wyświetlania pustych komórek](/slides/pl/python-net/chart-series/#control-the-display-of-empty-cells) po przykład.

## **Odczyt i zapis danych wykresu z książki roboczej**

Aspose.Slides for Python via .NET udostępnia metody [read_workbook_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i [write_workbook_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/write_workbook_stream/), które pozwalają odczytywać i zapisywać książki danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga** że dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład otwiera `chart.pptx`, który musi zawierać wykres jako pierwszy kształt na pierwszym slajdzie. Odczytuje osadzoną książkę do strumienia, czyści istniejące serie i kategorie, a następnie zapisuje z powrotem tę samą książkę. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

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

### **Walidacja układu wykresu po modyfikacji książki**

Kiedy zastępujesz osadzoną książkę zmodyfikowaną, wykres zachowuje oryginalne kolekcje serii i kategorii. To niezgodność może spowodować, że [Chart.validate_chart_layout](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/validate_chart_layout/) zakończy się błędem indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanej książki z powrotem do wykresu. Ten przykład wymaga `chart.pptx` z wykresem jako pierwszym kształtem na pierwszym slajdzie. Komentarz wskazuje, gdzie miałaby nastąpić edycja książki; uruchamialny przykład zapisuje oryginalną książkę i waliduje układ w pamięci.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Modyfikuj tutaj strumień książki, na przykład przy użyciu Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Czyszczenie kolekcji usuwa przestarzałe odwołania do danych przed zapisaniem książki. Przed użyciem wykresu odbuduj wymagane mapowania serii i kategorii dla zaktualizowanej książki.

## **Ustaw komórkę książki jako etykietę danych wykresu**

Możesz używać tekstu z komórek książki jako etykiet danych wykresu. Poniższe kroki pokazują, jak połączyć etykiety w wykresie bąbelkowym z komórkami w jego książce danych.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj dostęp do pierwszego slajdu po jego indeksie zerowym.
1. Dodaj wykres bąbelkowy z danymi domyślnymi.
1. Uzyskaj dostęp do serii wykresu.
1. Ustaw komórkę książki jako etykietę danych.
1. Zapisz prezentację.

Ten przykład otwiera `chart2.pptx`, który musi zawierać co najmniej jeden slajd, i dodaje wykres bąbelkowy z danymi domyślnymi. Używa komórek A10:A12 w arkuszu 0 jako pierwsze trzy etykiety w pierwszej serii, włącza etykiety z komórek i zapisuje wynik do `resultchart.pptx`.

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

Właściwość [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) zapewnia dostęp do arkuszy w książce wykresu. Ten przykład tworzy wykres kołowy z danymi domyślnymi i wypisuje nazwę każdego arkusza na konsolę.

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

Ten przykład tworzy trójwymiarowy wykres kolumnowy z danymi domyślnymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa używa literału łańcucha znaków; druga używa komórki C1 w arkuszu 0. Enumeracja [DataSourceType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datasourcetype/) wybiera źródło dla każdej nazwy. Wynik zostaje zapisany do `pres.pptx`.

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

## **Wykrywanie nieobsługiwanych formatów osadzonych książek**

Aspose.Slides nie obsługuje formatu binarnej książki Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć właściwości [embedded_workbook_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) na [ChartData](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/) wraz z enumeracją [WorkbookType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy. Ten przykład przegląda kształty na pierwszym slajdzie `sample.pptx`, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzoną książką .xlsb.

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

        # Odczytaj lub zmodyfikuj obsługiwane dane książki wykresu tutaj.
```

## **Zewnętrzna książka**

Aspose.Slides obsługuje użycie zewnętrznych książek jako źródła danych dla wykresów.

### **Utworzenie zewnętrznej książki**

Użyj [read_workbook_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), aby wyeksportować osadzoną książkę wykresu do pliku i powiązać wykres z tą zewnętrzną książką.

Ten przykład tworzy wykres kołowy z danymi domyślnymi, zapisuje jego książkę do `externalWorkbook1.xlsx` i zamyka strumień wyjściowy przed przypisaniem pliku jako źródła danych wykresu. Zapisuje połączoną prezentację do `externalWorkbook.pptx`.

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

### **Ustawienie zewnętrznej książki**

Za pomocą metody [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) możesz przypisać zewnętrzną książkę do wykresu jako jego źródło danych. Metoda ta może również służyć do zaktualizowania ścieżki do zewnętrznej książki (jeśli została przeniesiona).

Choć nie możesz edytować danych w książkach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać tych książek jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznej książki, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Ten przykład wymaga pliku `externalWorkbook.xlsx` w katalogu roboczym. Jego arkusz o nazwie `Sheet1` musi zawierać nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy książkę i używa [set_range](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_range/), aby zmapować A1:B4 na jedną serię i trzy kategorie. Zapisuje wynik do `Presentation_with_externalWorkbook.pptx`.

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

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) steruje, czy książka jest ładowana.

* Gdy `update_chart_data` jest `False`, aktualizowana jest tylko ścieżka do książki. Dane wykresu nie są ładowane ani aktualizowane z docelowej książki, więc książka może być niedostępna.
* Gdy `update_chart_data` jest `True`, dane wykresu są aktualizowane z docelowej książki.

Poniższy przykład przypisuje adres URL zastępczy z `update_chart_data` ustawionym na `False`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnej książki.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Pobranie ścieżki zewnętrznej książki źródła danych wykresu**

Aby zidentyfikować książkę połączoną z wykresem, najpierw sprawdź, czy wykres używa zewnętrznego źródła danych. Jeśli tak, możesz pobrać ścieżkę książki, wykonując następujące kroki.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj dostęp do pierwszego slajdu po jego indeksie zerowym.
1. Sprawdź, czy pierwszy kształt jest wykresem.
1. Odczytaj typ źródła danych wykresu.
1. Jeśli źródłem jest zewnętrzna książka, odczytaj jej ścieżkę.

Ten przykład otwiera `externalWorkbook.pptx`, utworzony w poprzednim przykładzie, i analizuje pierwszy kształt na pierwszym slajdzie. Jeśli jest to wykres powiązany ze zewnętrzną książką, przykład wypisuje [external_workbook_path](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) na konsolę. Następnie zapisuje kopię prezentacji do `Result.pptx`.

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

Możesz edytować dane w zewnętrznych książkach w taki sam sposób, w jaki zmieniasz zawartość wewnętrznych książek. Jeśli zewnętrzna książka nie może zostać załadowana, zostaje zgłoszony wyjątek.

Ten przykład wymaga pliku `presentation.pptx` z wykresem jako pierwszym kształtem na pierwszym slajdzie oraz dostępnej zewnętrznej książki. Ustawia wartość pierwszego punktu danych w pierwszej serii na 100 i zapisuje prezentację do `presentation_out.pptx`. Edycja wartości komórek może zaktualizować połączony zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalną książkę.

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

### **Odzyskanie książki z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznej książki, której brakuje lub jest niedostępna, Aspose.Slides może odtworzyć książkę wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/), skonfiguruj jej [spreadsheet_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/spreadsheet_options/), i ustaw [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/pl/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) na `True` przed otwarciem prezentacji.

Poniższy przykład w Pythonie otwiera `presentation.pptx`, którego pierwszy kształt na pierwszym slajdzie musi być wykresem odwołującym się do niedostępnej zewnętrznej książki, i uzyskuje dostęp do odzyskanych danych poprzez [Chart.chart_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/chart_data/) i [ChartData.chart_data_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Odczytaj lub zmodyfikuj odzyskane dane książki tutaj.
    else:
        print("The first shape is not a chart.")
```

Jeśli zewnętrzna książka jest niedostępna i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych do zewnętrznej książki po ostatniej aktualizacji prezentacji.

## **Najczęściej zadawane pytania**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrzną czy osadzoną książką?**

Tak. Wykres ma [data source type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/data_source_type/) oraz [path to an external workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jeśli źródłem jest zewnętrzna książka, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych książek i jak są one przechowywane?**

Tak. Jeśli określisz ścieżkę względną, zostaje ona automatycznie przekształcona na ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie książki może wymagać aktualizacji odnośnika.

**Czy mogę używać książek znajdujących się na zasobach/udziałach sieciowych?**

Tak, takie książki mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych książek bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Prezentacja przechowuje [link do zewnętrznego pliku](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Edycja danych wykresu powiązanych z komórkami może również zaktualizować połączony lokalny plik XLSX. Użyj kopii książki, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, jeśli zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła przy tworzeniu odnośnika. Typowe podejście to usunięcie zabezpieczenia wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) i odwołanie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tej samej zewnętrznej książki?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku będzie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.