---
title: Zarządzaj zeszytami wykresów w prezentacjach przy użyciu Pythona
linktitle: Zeszyt wykresu
type: docs
weight: 70
url: /pl/python-net/chart-workbook/
keywords:
- zeszyt wykresu
- dane wykresu
- komórka zeszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny zeszyt
- zewnętrzne dane
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Pythona via .NET: bez wysiłku zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu. Omówiono również pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

## **Odczytywanie i zapisywanie danych wykresu z zeszytu**

Aspose.Slides provides methods to read and write chart data workbooks (which contain chart data edited with Aspose.Cells). **Note:** The chart data must be organized in the same way or have a structure similar to the source.

The following Python code demonstrates a sample operation:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

## **Ustawienie komórki WorkBook jako etykiety danych wykresu**

Sometimes you need chart labels that come directly from cells in the underlying data workbook. Aspose.Slides allows you to bind data labels to specific workbook cells so the label text always reflects the cell’s value. The example below shows how to enable value-from-cell labels and point selected labels to custom cells in the chart’s workbook.

1. Create an instance of the [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/) class.
1. Get a reference to the slide by index.
1. Add a bubble chart with sample data.
1. Access the chart series.
1. Use a workbook cell as a data label.
1. Save the presentation.

The following Python code shows how to set a workbook cell as a chart data label:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Zarządzanie arkuszami**

The following Python code demonstrates how to use the `worksheets` property to access the worksheet collection:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Określenie typu źródła danych**

The following Python code shows how to specify a data source type:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Wykrywanie nieobsługiwanych wbudowanych formatów zeszytów**

Aspose.Slides does not support the Excel binary workbook (.xlsb) format that can be embedded in some charts. You can use the `embedded_workbook_type` property on [ChartData](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/) together with the [WorkbookType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/workbooktype/) enumeration to detect unsupported formats and skip those charts.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # Osadzony zeszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue

        # Odczytaj lub zmodyfikuj dane zeszytu wykresu tutaj.
```

## **Zewnętrzne zeszyty**

Aspose.Slides supports using external workbooks as a data source for charts.

### **Ustawianie zewnętrznych zeszytów**

Używając metody [ChartData.set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może również zaktualizować ścieżkę do zewnętrznego zeszytu, jeśli został przeniesiony.

Mimo że nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać tych zeszytów jako zewnętrznych źródeł danych. Jeśli podasz ścieżkę względną do zewnętrznego zeszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

The following Python code shows how to set an external workbook:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

The `update_chart_data` parameter of the [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) method specifies whether the Excel workbook will be loaded.

- When `update_chart_data` is set to `False`, only the workbook path is updated; the chart data is not loaded or refreshed from the target workbook. Use this setting when the target workbook does not exist or is unavailable.
- When `update_chart_data` is set to `True`, the chart data is loaded and updated from the target workbook.

### **Tworzenie zewnętrznych zeszytów**

Używając metod [read_workbook_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), możesz albo utworzyć zewnętrzny zeszyt od podstaw, albo przekonwertować wewnętrzny zeszyt na zewnętrzny.

This Python code demonstrates the external workbook creation process:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Pobranie ścieżki zewnętrznego zeszytu źródła danych dla wykresu**

Czasami dane wykresu są powiązane z zewnętrznym zeszytem Excel, zamiast z wbudowanymi danymi prezentacji. Dzięki Aspose.Slides możesz sprawdzić źródło danych wykresu i, jeśli jest to zewnętrzny zeszyt, odczytać pełną ścieżkę zeszytu.

1. Utwórz instancję klasy [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według indeksu.
1. Uzyskaj odwołanie do kształtu wykresu.
1. Uzyskaj źródło ([ChartDataSourceType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatasourcetype/)), które reprezentuje źródło danych wykresu.
1. Sprawdź, czy typ źródła odpowiada typowi źródła danych zewnętrznego zeszytu.

Następujący kod w Pythonie demonstruje operację:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Edytowanie danych wykresu**

You can edit data in external workbooks the same way you edit data in internal workbooks. If an external workbook cannot be loaded, an exception is thrown.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany ze zewnętrznym czy wbudowanym zeszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/data_source_type/) oraz [ścieżkę do zewnętrznego zeszytu](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jeśli źródło jest zewnętrznym zeszytem, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy ścieżki względne do zewnętrznych zeszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz ścieżkę względną, zostanie ona automatycznie przekształcona w ścieżkę bezwzględną. Jest to wygodne przy przenoszeniu projektu; jednak należy pamiętać, że prezentacja zapisze ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się na zasobach/udziałach sieciowych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edytowanie zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest obsługiwane — mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisie prezentacji?**

Nie. Prezentacja przechowuje [odniesienie do zewnętrznego pliku](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) i używa go do odczytu danych. Sam zewnętrzny plik nie jest modyfikowany przy zapisie prezentacji.

**Co zrobić, gdy zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie akceptuje hasła przy tworzeniu odnośnika. Typowe podejście to usunięcie ochrony wcześniej lub przygotowanie odkodowanej kopii (np. przy użyciu [Aspose.Cells](/cells/python-net/)) i odwołanie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własne odwołanie. Jeśli wszystkie wskazują na ten sam plik, jego aktualizacja zostanie odzwierciedlona w każdym wykresie przy następnym załadowaniu danych.