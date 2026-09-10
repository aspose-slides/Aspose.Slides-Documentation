---
title: Zarządzanie zeszytami wykresów w prezentacjach przy użyciu Pythona przez Java
linktitle: Zeszyt wykresu
type: docs
weight: 70
url: /pl/python-java/chart-workbook/
keywords:
- zeszyt wykresu
- dane wykresu
- komórka zeszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny zeszyt
- dane zewnętrzne
- pamięć podręczna wykresu
- odzyskiwanie zeszytu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Pythona przez Java: łatwo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pośrednictwem strumieni zeszytu, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje także pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

## **Odczyt i zapis danych wykresu z zeszytu**
Aspose.Slides udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#readWorkbookStream) i [writeWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#writeWorkbookStream), które pozwalają odczytywać i zapisywać zeszyty danych wykresu (zawierające dane wykresu edytowane w Aspose.Cells). **Uwaga**, że dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten kod w Pythonie przedstawia przykładową operację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Walidacja układu wykresu po modyfikacji zeszytu**

Po zastąpieniu osadzonego zeszytu zmodyfikowanym, wykres zachowuje oryginalne kolekcje serii i kategorii. Ta niespójność może spowodować, że [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#validateChartLayout) zgłosi `ArgumentOutOfRangeException` (parameter: index). Aby uniknąć wyjątku, należy wyczyścić istniejące serie i kategorie **przed** zapisaniem zaktualizowanego zeszytu z powrotem do wykresu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

    # Wczytaj zeszyt po jego modyfikacji (np. przy użyciu Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Wyczyść istniejące odwołania do danych.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Wyczyszczenie kolekcji zapewnia, że struktura danych wykresu jest zgodna z nowym zeszytem, co umożliwia wykonanie [validateChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#validateChartLayout) bez błędów.

## **Ustawienie komórki zeszytu jako etykiety danych wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odwołanie do slajdu przez jego indeks.
1. Dodaj wykres bąbelkowy z pewnymi danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Ustaw komórkę zeszytu jako etykietę danych.
1. Zapisz prezentację.

Ten kod w Pythonie pokazuje, jak ustawić komórkę zeszytu jako etykietę danych wykresu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zarządzanie arkuszami**

Ten kod w Pythonie demonstruje użycie metody [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#getWorksheets) do uzyskania dostępu do kolekcji arkuszy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Określenie typu źródła danych**

Ten kod w Pythonie pokazuje, jak określić typ źródła danych:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wykrywanie nieobsługiwanych formatów osadzonych zeszytów**

Aspose.Slides nie obsługuje formatu binarnego zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody [getEmbeddedWorkbookType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) na obiekcie [ChartData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć te wykresy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Osadzony zeszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue
        # Odczytaj lub zmodyfikuj tutaj dane zeszytu wykresu.
finally:
    presentation.dispose()
```

### **Utworzenie zewnętrznego zeszytu**

Przy użyciu metod [readWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#readWorkbookStream) i [setExternalWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook) możesz zarówno utworzyć zewnętrzny zeszyt od podstaw, jak i uczynić istniejący zeszyt wewnętrzny zewnętrznym.

Ten kod w Pythonie demonstruje proces tworzenia zewnętrznego zeszytu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ustawienie zewnętrznego zeszytu**

Przy użyciu metody [setExternalWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook) możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metodę tę można także użyć do zaktualizowania ścieżki do zewnętrznego zeszytu (jeśli został on przeniesiony).

Choć nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego zeszytu, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Ten kod w Pythonie pokazuje, jak ustawić zewnętrzny zeszyt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Drugi parametr (`bool`) metody [setExternalWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook) służy do określenia, czy zeszyt Excel zostanie załadowany.

* Gdy jego wartość jest ustawiona na `False`, aktualizowana jest tylko ścieżka zeszytu – dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego zeszytu. Użyj tej opcji, gdy docelowy zeszyt nie istnieje lub jest niedostępny.  
* Gdy jego wartość jest ustawiona na `True`, dane wykresu zostają zaktualizowane z docelowego zeszytu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Pobranie ścieżki zewnętrznego źródła danych wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odwołanie do slajdu przez jego indeks.
1. Utwórz obiekt dla kształtu wykresu.
1. Utwórz obiekt dla typu źródła ([ChartDataSourceType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatasourcetype/)) reprezentującego źródło danych wykresu.
1. Określ odpowiedni warunek w zależności od tego, czy typ źródła jest taki sam jak typ zewnętrznego źródła danych zeszytu.

Ten kod w Pythonie demonstruje tę operację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Edycja danych wykresu**

Możesz edytować dane w zewnętrznych zeszytach tak samo, jak zmieniasz zawartość wewnętrznych zeszytów. Gdy zewnętrzny zeszyt nie może zostać załadowany, zostaje rzucony wyjątek.

Ten kod w Pythonie jest implementacją opisanego procesu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Odzyskiwanie zeszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/), skonfiguruj go przy pomocy [SpreadsheetOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/spreadsheetoptions/), i wywołaj [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) z wartością `True` przed otwarciem prezentacji.

Poniższy przykład w Pythonie otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego zeszytu, i uzyskuje dostęp do odzyskanych danych poprzez [Chart.getChartData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#getChartData) oraz [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Wczytaj lub zmodyfikuj tutaj dane odzyskanego zeszytu.
finally:
    presentation.dispose()
```

Jeśli zewnętrzny zeszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest dopuszczalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym zeszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getDataSourceType) oraz [path to an external workbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych zeszytów i w jaki sposób są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona na ścieżkę bezwzględną. Jest to wygodne dla przenoszenia projektów; jednak prezentacja zapisze ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się w zasobach sieciowych/udostępnieniach?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Edycja zdalnych zeszytów bezpośrednio z poziomu Aspose.Slides nie jest obsługiwana – mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) i używa go do odczytu danych. Zewnętrzny plik nie jest modyfikowany podczas zapisu prezentacji.

**Co zrobić, gdy zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie akceptuje hasła przy tworzeniu łącza. Typowym rozwiązaniem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/python-java/)) i odwołanie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własne łącze. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.