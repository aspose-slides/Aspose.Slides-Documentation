---
title: Zarządzaj skoroszytami wykresów w prezentacjach przy użyciu Pythona
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
- dane zewnętrzne
- pamięć podręczna wykresu
- odzyskiwanie skoroszytu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Pythona via .NET: bezproblemowo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pośrednictwem strumieni skoroszytu, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje również pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

Dla komórek skoroszytu, które reprezentują brakujące dane, zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/python-net/chart-series/) po różnicę między pustą komórką a zerem oraz porównanie linii wykresu dostępnych trybów wyświetlania.

## **Odczyt i zapis danych wykresu ze skoroszytu**

Aspose.Slides udostępnia metody do odczytu i zapisu skoroszytów danych wykresu (które zawierają dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga:** Dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Następujący kod w języku Python demonstruje przykładową operację:

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

### **Sprawdź układ wykresu po modyfikacji skoroszytu**

Kiedy zamieniasz osadzony skoroszyt na zmodyfikowany, wykres zachowuje oryginalne kolekcje serii i kategorii. To niezgodność może spowodować, że [IChart.validate_chart_layout](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/ichart/validate_chart_layout/) zakończy się niepowodzeniem z błędem indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego skoroszytu z powrotem do wykresu.

```python
# Po zmodyfikowaniu strumienia skoroszytu (np. przy użyciu Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Wyczyść istniejące odwołania danych.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Czyszczenie kolekcji zapewnia, że struktura danych wykresu jest spójna z nowym skoroszytem, co pozwala `validate_chart_layout` zakończyć bez błędów.

## **Ustaw komórkę skoroszytu jako etykietę danych wykresu**

Czasami potrzebujesz etykiet wykresu pochodzących bezpośrednio z komórek w leżącym pod spodem skoroszycie danych. Aspose.Slides umożliwia powiązanie etykiet danych z konkretnymi komórkami skoroszytu, tak aby tekst etykiety zawsze odzwierciedlał wartość komórki. Poniższy przykład pokazuje, jak włączyć etykiety pochodzące z komórek i skierować wybrane etykiety do własnych komórek w skoroszycie wykresu.

1. Utwórz instancję klasy [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według indeksu.
1. Dodaj wykres bąbelkowy z przykładowymi danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Użyj komórki skoroszytu jako etykiety danych.
1. Zapisz prezentację.

Następujący kod w języku Python pokazuje, jak ustawić komórkę skoroszytu jako etykietę danych wykresu:

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

Następujący kod w języku Python demonstruje, jak używać właściwości `worksheets` do uzyskania dostępu do kolekcji arkuszy:

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

## **Określ typ źródła danych**

Następujący kod w języku Python pokazuje, jak określić typ źródła danych:

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

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje binarnego formatu skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć właściwości `embedded_workbook_type` na [ChartData](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać te wykresy.

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
            # Osadzony skoroszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue

        # Odczytaj lub zmodyfikuj dane skoroszytu wykresu tutaj.
```

## **Zewnętrzne skoroszyty**

Aspose.Slides obsługuje używanie zewnętrznych skoroszytów jako źródła danych dla wykresów.

### **Ustaw zewnętrzne skoroszyty**

Korzystając z metody [ChartData.set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Ta metoda może także zaktualizować ścieżkę do zewnętrznego skoroszytu, jeśli został przeniesiony.

Chociaż nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać tych skoroszytów jako zewnętrznych źródeł danych. Jeśli podasz względną ścieżkę do zewnętrznego skoroszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

Następujący kod w języku Python pokazuje, jak ustawić zewnętrzny skoroszyt:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Przekaż False, aby zapisano tylko ścieżkę: docelowy skoroszyt nie musi jeszcze istnieć.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) określa, czy skoroszyt Excel zostanie załadowany.

- Gdy `update_chart_data` jest ustawiony na `False`, aktualizowana jest tylko ścieżka do skoroszytu; dane wykresu nie są ładowane ani odświeżane z docelowego skoroszytu. Użyj tego ustawienia, gdy docelowy skoroszyt nie istnieje lub jest niedostępny.
- Gdy `update_chart_data` jest ustawiony na `True` (wartość domyślna), dane wykresu są ładowane i aktualizowane z docelowego skoroszytu. Jeśli ten skoroszyt nie może zostać otwarty, zgłaszany jest wyjątek z komunikatem "External workbook is not available".

### **Utwórz zewnętrzne skoroszyty**

Korzystając z metod [read_workbook_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) i [set_external_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), możesz albo utworzyć zewnętrzny skoroszyt od podstaw, albo przekształcić wewnętrzny skoroszyt w zewnętrzny.

Następujący kod w języku Python demonstruje proces tworzenia zewnętrznego skoroszytu:

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

### **Pobierz ścieżkę skoroszytu źródła zewnętrznego danych dla wykresu**

Czasami dane wykresu są powiązane z zewnętrznym skoroszytem Excel, a nie z osadzonymi danymi prezentacji. Dzięki Aspose.Slides możesz zbadać źródło danych wykresu i, jeśli jest to zewnętrzny skoroszyt, odczytać pełną ścieżkę do skoroszytu.

1. Utwórz instancję klasy [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Uzyskaj odwołanie do kształtu wykresu.
1. Uzyskaj źródło ([ChartDataSourceType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatasourcetype/)), które reprezentuje źródło danych wykresu.
1. Sprawdź, czy typ źródła odpowiada typowi źródła danych zewnętrznego skoroszytu.

Następujący kod w języku Python demonstruje tę operację:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Edytuj dane wykresu**

Możesz edytować dane w zewnętrznych skoroszytach tak samo, jak w wewnętrznych skoroszytach. Jeśli zewnętrzny skoroszyt nie może zostać załadowany, zostaje zgłoszony wyjątek.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Odzyskaj skoroszyt z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/), następnie włącz [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/pl/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) poprzez [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/spreadsheet_options/) przed otwarciem prezentacji.

Następujący przykład w języku Python otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego skoroszytu, i uzyskuje dostęp do odzyskanych danych poprzez [Chart.chart_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/chart_data/) oraz [ChartData.chart_data_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Odczytaj lub zmodyfikuj odzyskane dane skoroszytu tutaj.
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie buforowanych danych wykresu jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/data_source_type/) oraz [path to an external workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych skoroszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona w ścieżkę bezwzględną. Jest to wygodne w kontekście przenoszenia projektu; jednak pamiętaj, że prezentacja zapisze ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać skoroszytów znajdujących się na zasobach/udziałach sieciowych?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edytowanie zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwane — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Tylko jeśli edytowałeś dane wykresu. Prezentacja przechowuje [link do zewnętrznego pliku](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) i używa go do odczytu danych, więc otwarcie i zapisanie prezentacji nie zmienia skoroszytu. Jednak wartości zmienione za pomocą danych wykresu (zobacz [Edit Chart Data](#edit-chart-data) powyżej) są zapisywane z powrotem do zewnętrznego skoroszytu przy zapisywaniu prezentacji — pracuj na kopii, jeśli oryginał musi pozostać nienaruszony.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Typowe rozwiązanie to usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](/cells/python-net/)) i podlinkowanie do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku będzie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.