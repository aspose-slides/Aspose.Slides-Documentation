---
title: Управление рабочими книгами диаграмм в презентациях с помощью Python через Java
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/python-java/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кеш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Откройте для себя Aspose.Slides for Python via Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными презентаций."
---
## **Обзор**

В этой статье объясняется, как работать с книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграммы через потоки книги, использовать ячейки книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними книгами в качестве источников данных диаграммы. Примеры демонстрируют, как создать и назначить внешнюю книгу, получить путь к внешней книге, связанной с диаграммой, и редактировать данные диаграммы, когда книга доступна.

## **Чтение и запись данных диаграммы из книги**
Aspose.Slides предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#readWorkbookStream) и [writeWorkbookStream](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#writeWorkbookStream), позволяющие читать и записывать книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Note** что данные диаграммы должны быть организованы одинаково или иметь структуру, аналогичную источнику.

Этот пример на Python демонстрирует операцию:

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

### **Проверка макета диаграммы после изменения книги**

Когда вы заменяете встроенную книгу изменённой, диаграмма сохраняет исходные коллекции серий и категорий. Эта несогласованность может привести к тому, что [Chart.validateChartLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#validateChartLayout) выбросит `ArgumentOutOfRangeException` (параметр: index). Чтобы избежать исключения, очистите существующие серии и категории **до** записи обновлённой книги обратно в диаграмму.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Прочитайте рабочую книгу после её изменения (например, с помощью Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Очистить существующие ссылки на данные.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Очистка коллекций обеспечивает соответствие структуры данных диаграммы новой книге, позволяя [validateChartLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#validateChartLayout) завершиться без ошибок.

## **Установка ячейки книги в качестве метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте пузырчатую диаграмму с некоторыми данными.
1. Получите доступ к сериям диаграммы.
1. Установите ячейку книги в качестве метки данных.
1. Сохраните презентацию.

Этот пример на Python показывает, как установить ячейку книги в качестве метки данных диаграммы:

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

## **Управление листами**

Этот пример на Python демонстрирует использование метода [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/#getWorksheets) для доступа к коллекции листов:

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

## **Указание типа источника данных**

Этот пример на Python показывает, как указать тип для источника данных:

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

## **Обнаруживание неподдерживаемых форматов встроенных книг**

Aspose.Slides не поддерживает бинарный формат книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) на объекте [ChartData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

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
            # Встроенная рабочая книга в формате .xlsb, который не поддерживается.
            continue
        # Читать или изменять данные рабочей книги диаграммы здесь.
finally:
    presentation.dispose()
```

### **Создание внешней книги**

Используя методы [readWorkbookStream](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#readWorkbookStream) и [setExternalWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setExternalWorkbook), вы можете либо создать внешнюю книгу с нуля, либо превратить внутреннюю книгу во внешнюю.

Этот пример на Python демонстрирует процесс создания внешней книги:

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

### **Назначение внешней книги**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setExternalWorkbook) вы можете присвоить внешнюю книгу диаграмме в качестве источника данных. Этот метод также может использоваться для обновления пути к внешней книге (если она была перемещена).

Хотя редактировать данные в книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно могут использоваться в качестве внешнего источника данных. Если указан относительный путь к внешней книге, он автоматически преобразуется в абсолютный путь.

Этот пример на Python показывает, как установить внешнюю книгу:

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

Второй (`bool`) параметр метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setExternalWorkbook) указывает, будет ли загружена Excel‑книга.

* Когда его значение `False`, обновляется только путь к книге — данные диаграммы не будут загружены и обновлены из целевой книги. Это полезно, когда целевая книга отсутствует или недоступна.  
* Когда его значение `True`, данные диаграммы обновляются из целевой книги.

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

### **Получение пути к внешнему источнику данных книги диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для формы диаграммы.
1. Создайте объект для типа источника ([ChartDataSourceType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatasourcetype/)), представляющего источник данных диаграммы.
1. Укажите соответствующее условие в зависимости от того, что тип источника совпадает с типом внешнего источника данных книги.

Этот пример на Python демонстрирует операцию:

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

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних книгах так же, как вносите изменения во внутренние книги. Если внешняя книга не может быть загружена, будет выброшено исключение.

Этот пример на Python реализует описанный процесс:

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

### **Восстановление книги из кеша диаграммы**

Если диаграмма использует внешнюю книгу, которой нет или она недоступна, Aspose.Slides может восстановить книгу диаграммы из данных, закешированных в презентации. Создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/), настройте его с помощью [SpreadsheetOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/spreadsheetoptions/) и вызовите [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) со значением `True` перед открытием презентации.

Следующий пример на Python открывает презентацию, в которой диаграмма ссылается на недоступную внешнюю книгу, и получает восстановленные данные через [Chart.getChartData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#getChartData) и [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

    # Прочитать или изменить данные восстановленной рабочей книги здесь.
finally:
    presentation.dispose()
```

Если внешняя книга недоступна и восстановление отключено, Aspose.Slides выбрасывает исключение. Включайте восстановление только тогда, когда использование закешированных данных диаграммы приемлемо, так как кеш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной книгой?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getDataSourceType) и [path to an external workbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); если источник — внешняя книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам и как они сохраняются?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако в PPTX‑файле будет сохранён абсолютный путь.

**Можно ли использовать книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться в качестве внешнего источника данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешнюю XLSX при сохранении презентации?**

Нет. Презентация хранит [link to the external file](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) и использует его только для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/python-java/)) и связываются с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.