---
title: Zarządzanie zeszytami wykresów w prezentacjach przy użyciu Pythona
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
description: "Odkryj Aspose.Slides dla Pythona poprzez .NET: łatwo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono także pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

## **Odczyt i zapis danych wykresu z zeszytu**

Aspose.Slides udostępnia metody do odczytu i zapisu zeszytów danych wykresu (zawierających dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga:** Dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Poniższy kod Pythona przedstawia przykładową operację:

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

### **Walidacja układu wykresu po modyfikacji zeszytu**

Kiedy zastępujesz osadzony zeszyt zmodyfikowanym, wykres zachowuje swoje pierwotne kolekcje serii i kategorii. To niezgodność może spowodować, że [IChart.validate_chart_layout](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichart/validate_chart_layout/) zakończy się niepowodzeniem z błędem „index out of range”. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego zeszytu z powrotem do wykresu.

```python
# Po modyfikacji strumienia zeszytu (np. przy użyciu Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Wyczyść istniejące odniesienia danych.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Czyszczenie kolekcji zapewnia, że struktura danych wykresu jest zgodna z nowym zeszytem, co pozwala `validate_chart_layout` zakończyć się bez błędów.

## **Ustawienie komórki zeszytu jako etykiety danych wykresu**

Czasami potrzebne są etykiety wykresu pochodzące bezpośrednio z komórek w leżącym pod spodem zeszycie danych. Aspose.Slides pozwala powiązać etykiety danych z konkretnymi komórkami zeszytu, tak aby tekst etykiety zawsze odzwierciedlał wartość komórki. Poniższy przykład pokazuje, jak włączyć etykiety pobierane z komórek i skierować wybrane etykiety do niestandardowych komórek w zeszycie wykresu.

1. Utwórz instancję klasy [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu według indeksu.
3. Dodaj wykres bąbelkowy z przykładowymi danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Użyj komórki zeszytu jako etykiety danych.
6. Zapisz prezentację.

Poniższy kod Pythona pokazuje, jak ustawić komórkę zeszytu jako etykietę danych wykresu:

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

Poniższy kod Pythona demonstruje, jak używać właściwości `worksheets` do uzyskania dostępu do kolekcji arkuszy:

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

Poniższy kod Pythona pokazuje, jak określić typ źródła danych:

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

## **Wykrywanie nieobsługiwanych formatów osadzonych zeszytów**

Aspose.Slides nie obsługuje formatu binarnego zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć właściwości `embedded_workbook_type` na [ChartData](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy.

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

        # Odczytaj lub zmodyfikuj tutaj dane zeszytu wykresu.
```

## **Zewnętrzne zeszyty**

Aspose.Slides obsługuje używanie zewnętrznych zeszytów jako źródła danych dla wykresów.

### **Ustawienie zewnętrznych zeszytów**

Korzystając z metody [ChartData.set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może także zaktualizować ścieżkę do zewnętrznego zeszytu, jeśli został on przeniesiony.

Chociaż nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać ich jako zewnętrznych źródeł danych. Jeśli podasz względną ścieżkę do zewnętrznego zeszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

Poniższy kod Pythona pokazuje, jak ustawić zewnętrzny zeszyt:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Przekaż False, aby zapisano tylko ścieżkę: docelowy zeszyt nie musi jeszcze istnieć.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) określa, czy zeszyt Excel zostanie załadowany.

- Gdy `update_chart_data` jest ustawione na `False`, aktualizowana jest tylko ścieżka zeszytu; dane wykresu nie są ładowane ani odświeżane z docelowego zeszytu. Użyj tego ustawienia, gdy docelowy zeszyt nie istnieje lub jest niedostępny.
- Gdy `update_chart_data` jest ustawione na `True` (wartość domyślna), dane wykresu są ładowane i aktualizowane z docelowego zeszytu. Jeśli ten zeszyt nie może zostać otwarty, zostanie zgłoszony wyjątek z komunikatem „External workbook is not available”.

### **Tworzenie zewnętrznych zeszytów**

Korzystając z metod [read_workbook_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), możesz zarówno utworzyć zewnętrzny zeszyt od podstaw, jak i przekonwertować wewnętrzny zeszyt na zewnętrzny.

Ten kod Pythona demonstruje proces tworzenia zewnętrznego zeszytu:

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

### **Pobranie ścieżki zewnętrznego źródła danych zeszytu dla wykresu**

Czasami dane wykresu są powiązane z zewnętrznym zeszytem Excel, a nie z osadzonymi danymi prezentacji. Dzięki Aspose.Slides możesz sprawdzić źródło danych wykresu i, jeśli jest to zewnętrzny zeszyt, odczytać pełną ścieżkę do tego zeszytu.

1. Utwórz instancję klasy [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu według jego indeksu.
3. Pobierz odwołanie do kształtu wykresu.
4. Uzyskaj źródło ([ChartDataSourceType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatasourcetype/)), które reprezentuje źródło danych wykresu.
5. Sprawdź, czy typ źródła odpowiada typowi zewnętrznego zeszytu.

Poniższy kod Pythona demonstruje tę operację:

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

Możesz edytować dane w zewnętrznych zeszytach tak samo, jak w wewnętrznych. Jeśli zewnętrzny zeszyt nie może zostać załadowany, zostanie rzucony wyjątek.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Odzyskiwanie zeszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych zbuforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/), a następnie włącz [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) przez [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/spreadsheet_options/) przed otwarciem prezentacji.

Poniższy przykład Pythona otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego zeszytu, i uzyskuje dostęp do odzyskanych danych poprzez [Chart.chart_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/chart_data/) oraz [ChartData.chart_data_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Odczytaj lub zmodyfikuj tutaj dane odzyskanego zeszytu.
```

Jeśli zewnętrzny zeszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłosi wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym planem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym, czy osadzonym zeszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/data_source_type/) oraz [path to an external workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych zeszytów i w jaki sposób są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie zamieniona na ścieżkę absolutną. Jest to wygodne przy przenoszeniu projektów; jednak prezentacja zapisuje ścieżkę absolutną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest jednak wspierana – mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisywania prezentacji?**

Tylko jeśli edytowałeś dane wykresu. Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) i używa go do odczytu danych, więc otwarcie i zapisanie prezentacji nie wpływa na zeszyt. Natomiast wartości zmienione poprzez dane wykresu (zob. [Edit Chart Data](#edit-chart-data) powyżej) są zapisywane z powrotem do zewnętrznego zeszytu przy zapisie prezentacji – pracuj na kopii, jeśli oryginał musi pozostać nienaruszony.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie przyjmuje hasła przy łączeniu. Typowe rozwiązanie to usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/python-net/)) i podlinkowanie tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie odwołują się do tego samego pliku, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.