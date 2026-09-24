---
title: Zarządzanie zeszytami wykresów w prezentacjach przy użyciu Pythona w środowisku Java
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
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie zeszytu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Pythona w środowisku Java: łatwo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono również pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

Dla komórek zeszytu, które reprezentują brakujące dane, zobacz [Control the Display of Empty Cells](/slides/pl/python-java/chart-series/) aby poznać różnicę między pustą komórką a zerem oraz porównanie trybów wyświetlania w wykresie liniowym.

## **Odczyt i zapis danych wykresu z zeszytu**
Aspose.Slides udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#readWorkbookStream) i [writeWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#writeWorkbookStream), które pozwalają odczytywać i zapisywać zeszyty danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga**, dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

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

### **Sprawdź układ wykresu po modyfikacji zeszytu**

Kiedy zamieniasz osadzony zeszyt na zmodyfikowany, wykres zachowuje swoje pierwotne kolekcje serii i kategorii. Ta niespójność może spowodować, że [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#validateChartLayout) rzuci `ArgumentOutOfRangeException` (parameter: index). Aby uniknąć wyjątku, wyczyść istniejące serie i kategorie **przed** zapisaniem zaktualizowanego zeszytu z powrotem do wykresu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Odczytaj zeszyt po jego modyfikacji (np. przy użyciu Aspose.Cells).
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

Wyczyszczenie kolekcji zapewnia, że struktura danych wykresu jest zgodna z nowym zeszytem, co pozwala [validateChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#validateChartLayout) zakończyć bez błędów.

## **Ustaw komórkę zeszytu jako etykietę danych wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj wykres typu Bubble z pewnymi danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Ustaw komórkę zeszytu jako etykietę danych.
1. Zapisz prezentację.

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

Ten kod Pythona demonstruje operację, w której metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#getWorksheets) jest używana do uzyskania dostępu do kolekcji arkuszy:

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

## **Określ typ źródła danych**

Ten kod Pythona pokazuje, jak określić typ dla źródła danych:

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

## **Wykryj nieobsługiwane formaty osadzonych zeszytów**

Aspose.Slides nie obsługuje binarnego formatu zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody [getEmbeddedWorkbookType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) na [ChartData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć te wykresy.

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
        # Tutaj odczytaj lub zmodyfikuj dane zeszytu wykresu.
finally:
    presentation.dispose()
```

## **Zewnętrzny zeszyt**

Aspose.Slides obsługuje używanie zewnętrznych zeszytów jako źródła danych dla wykresów.

### **Utwórz zewnętrzny zeszyt**

Korzystając z metod [readWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#readWorkbookStream) i [setExternalWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook), możesz albo utworzyć zewnętrzny zeszyt od podstaw, albo uczynić wewnętrzny zeszyt zewnętrznym.

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

### **Ustaw zewnętrzny zeszyt**

Za pomocą metody [setExternalWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook) możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metodę tę można także użyć do zaktualizowania ścieżki do zewnętrznego zeszytu (jeśli ten został przeniesiony).

Choć nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podana zostanie ścieżka względna do zewnętrznego zeszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

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

Drugi parametr (`bool`) metody [setExternalWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook) określa, czy zeszyt Excel zostanie załadowany.

* Gdy jego wartość jest ustawiona na `False`, aktualizowana jest tylko ścieżka zeszytu – dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego zeszytu. Użyj tej opcji, gdy docelowy zeszyt nie istnieje lub jest niedostępny.  
* Gdy jego wartość jest ustawiona na `True`, dane wykresu zostaną zaktualizowane z docelowego zeszytu.

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

### **Uzyskaj ścieżkę zewnętrznego zeszytu źródła danych wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Utwórz obiekt dla kształtu wykresu.
1. Utwórz obiekt dla typu źródła ([ChartDataSourceType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatasourcetype/)) reprezentującego źródło danych wykresu.
1. Określ odpowiedni warunek, bazując na tym, że typ źródła jest taki sam jak typ zewnętrznego zeszytu źródła danych.

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

### **Edytuj dane wykresu**

Możesz edytować dane w zewnętrznych zeszytach tak samo, jak wprowadzisz zmiany w zawartości wewnętrznych zeszytów. Gdy zewnętrzny zeszyt nie może zostać załadowany, zostaje wyrzucony wyjątek.

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

### **Odzyskaj zeszyt z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/), skonfiguruj je przy pomocy [SpreadsheetOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/spreadsheetoptions/), i wywołaj [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) z wartością `True` przed otwarciem prezentacji.

Poniższy przykład Pythona otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego zeszytu, i uzyskuje dostęp do odzyskanych danych poprzez [Chart.getChartData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#getChartData) oraz [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

    # Odczytaj lub zmodyfikuj tutaj odzyskane dane zeszytu.
finally:
    presentation.dispose()
```

Jeśli zewnętrzny zeszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides rzuca wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie buforowanych danych wykresu jest akceptowalnym rozwiązaniem awaryjnym, ponieważ bufor może nie zawierać zmian wprowadzonych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest połączony ze zewnętrznym czy osadzonym zeszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getDataSourceType) oraz [path to an external workbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy ścieżki względne do zewnętrznych zeszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz ścieżkę względną, zostanie ona automatycznie przekształcona w ścieżkę bezwzględną. Ułatwia to przenoszenie projektów; pamiętaj jednak, że prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się na zasobach/udostępnieniach sieciowych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być wykorzystywane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) i używa go do odczytu danych. Sam plik zewnętrzny nie jest modyfikowany podczas zapisu prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła przy tworzeniu linku. Typowym podejściem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/python-java/)) i wskazanie tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują ten sam plik, zmiana tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.