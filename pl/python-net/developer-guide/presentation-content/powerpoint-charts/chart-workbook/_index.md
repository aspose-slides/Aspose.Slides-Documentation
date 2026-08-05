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
- pamięć podręczna wykresu
- odzyskiwanie zeszytu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Pythona poprzez .NET: bez wysiłku zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pośrednictwem strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono także pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

## **Odczyt i zapis danych wykresu z zeszytu**

Aspose.Slides udostępnia metody do odczytu i zapisu zeszytów danych wykresu (które zawierają dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga:** Dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Poniższy kod Python demonstruje przykładową operację:

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

## **Ustaw komórkę WorkBook jako etykietę danych wykresu**

Czasami potrzebujesz etykiet wykresu pochodzących bezpośrednio z komórek w podstawowym zeszycie danych. Aspose.Slides umożliwia powiązanie etykiet danych z określonymi komórkami zeszytu, tak aby tekst etykiety zawsze odzwierciedlał wartość komórki. Poniższy przykład pokazuje, jak włączyć etykiety wartości z komórek i skierować wybrane etykiety do niestandardowych komórek w zeszycie wykresu.

1. Utwórz instancję klasy [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według indeksu.
1. Dodaj wykres bąbelkowy z przykładowymi danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Użyj komórki zeszytu jako etykiety danych.
1. Zapisz prezentację.

Poniższy kod Python pokazuje, jak ustawić komórkę zeszytu jako etykietę danych wykresu:

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

Poniższy kod Python demonstruje, jak używać właściwości `worksheets` do uzyskania dostępu do kolekcji arkuszy:

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

Poniższy kod Python pokazuje, jak określić typ źródła danych:

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

Aspose.Slides nie obsługuje binarnego formatu zeszytu Excel (.xlsb), który może być wbudowany w niektóre wykresy. Można użyć właściwości `embedded_workbook_type` w [ChartData](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy.

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
            # Wbudowany zeszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue

        # Odczytaj lub zmodyfikuj tutaj dane zeszytu wykresu.
```

## **Zewnętrzne zeszyty**

Aspose.Slides obsługuje używanie zewnętrznych zeszytów jako źródła danych dla wykresów.

### **Ustawianie zewnętrznych zeszytów**

Korzystając z metody [ChartData.set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może również zaktualizować ścieżkę do zewnętrznego zeszytu, jeśli został on przeniesiony.

Chociaż nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać tych zeszytów jako zewnętrznych źródeł danych. Jeśli podasz ścieżkę względną do zewnętrznego zeszytu, zostanie ona automatycznie przekształcona na pełną ścieżkę.

Poniższy kod Python pokazuje, jak ustawić zewnętrzny zeszyt:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) określa, czy skoroszyt Excel zostanie załadowany.

- Gdy `update_chart_data` jest ustawiony na `False`, aktualizowana jest tylko ścieżka do zeszytu; dane wykresu nie są ładowane ani odświeżane z docelowego zeszytu. Użyj tego ustawienia, gdy docelowy zeszyt nie istnieje lub jest niedostępny.
- Gdy `update_chart_data` jest ustawiony na `True`, dane wykresu są ładowane i aktualizowane z docelowego zeszytu.

### **Tworzenie zewnętrznych zeszytów**

Korzystając z metod [read_workbook_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), możesz albo utworzyć zewnętrzny zeszyt od podstaw, albo przekonwertować wewnętrzny zeszyt na zewnętrzny.

Ten kod Python demonstruje proces tworzenia zewnętrznego zeszytu:

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

### **Uzyskanie ścieżki zewnętrznego zeszytu źródła danych dla wykresu**

Czasami dane wykresu są powiązane z zewnętrznym skoroszytem Excel, a nie z wbudowanymi danymi prezentacji. Dzięki Aspose.Slides możesz sprawdzić źródło danych wykresu i, jeśli jest to zewnętrzny zeszyt, odczytać pełną ścieżkę do zeszytu.

1. Utwórz instancję klasy [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu według jego indeksu.
3. Pobierz odwołanie do kształtu wykresu.
4. Uzyskaj źródło ([ChartDataSourceType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatasourcetype/)), które reprezentuje źródło danych wykresu.
5. Sprawdź, czy typ źródła odpowiada typowi źródła danych zewnętrznego zeszytu.

Poniższy kod Python demonstruje tę operację:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Edycja danych wykresu**

Możesz edytować dane w zewnętrznych zeszytach tak samo, jak w wewnętrznych zeszytach. Jeśli zewnętrzny zeszyt nie może zostać załadowany, zostaje wyrzucony wyjątek.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Odzyskiwanie zeszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/), a następnie włącz [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/pl/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) za pośrednictwem [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/spreadsheet_options/) przed otwarciem prezentacji.

Poniższy przykład Python otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego zeszytu, i uzyskuje dostęp do odzyskanych danych poprzez [Chart.chart_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/chart_data/) oraz [ChartData.chart_data_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Odczytaj lub zmodyfikuj tutaj dane odzyskanego zeszytu.
```

Jeśli zewnętrzny zeszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest połączony z zewnętrznym czy wbudowanym zeszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/data_source_type/) oraz [ścieżkę do zewnętrznego zeszytu](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych zeszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli określisz ścieżkę względną, zostanie ona automatycznie przekształcona na ścieżkę absolutną. Jest to wygodne dla przenoszenia projektu; jednak pamiętaj, że prezentacja zapisze ścieżkę absolutną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się w zasobach/udziałach sieciowych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisywania prezentacji?**

Nie. Prezentacja przechowuje [odnośnik do zewnętrznego pliku](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) i używa go do odczytu danych. Sam zewnętrzny plik nie jest modyfikowany podczas zapisywania prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła podczas łączenia. Typowe podejście to usunięcie ochrony z wyprzedzeniem lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](/cells/python-net/)) i połączenie się z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.