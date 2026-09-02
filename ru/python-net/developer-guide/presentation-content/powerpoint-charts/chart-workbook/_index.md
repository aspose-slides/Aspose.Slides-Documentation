---
title: Управление рабочими книгами диаграмм в презентациях с Python
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/python-net/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кэш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Python через .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, оптимизируя данные вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграмм через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и задавать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides предоставляет методы для чтения и записи рабочих книг данных диаграмм (которые содержат данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание:** Данные диаграммы должны быть организованы одинаково или иметь структуру, похожую на исходную.

Ниже приведён пример кода на Python:

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

### **Проверка макета диаграммы после изменения рабочей книги**

При замене встроенной рабочей книги её изменённой версией диаграмма сохраняет исходные коллекции рядов и категорий. Это несоответствие может привести к ошибке [IChart.validate_chart_layout](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichart/validate_chart_layout/) с сообщением о выходе индекса за пределы диапазона. Очистите существующие ряды и категории перед записью обновлённой рабочей книги обратно в диаграмму.

```python
# После изменения потока рабочей книги (например, с использованием Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Очистить существующие ссылки на данные.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Очистка коллекций гарантирует, что структура данных диаграммы соответствует новой рабочей книге, позволяя `validate_chart_layout` завершиться без ошибок.

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**

Иногда необходимо, чтобы метки диаграммы брались непосредственно из ячеек базовой рабочей книги. Aspose.Slides позволяет привязывать метки данных к конкретным ячейкам рабочей книги, чтобы текст метки всегда отражал значение ячейки. Ниже показан пример, как включить метки «значение из ячейки» и указать выбранные метки на пользовательские ячейки в рабочей книге диаграммы.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/).
1. Получите ссылку на слайд по индексу.
1. Добавьте пузырьковую диаграмму с примерными данными.
1. Получите доступ к рядам диаграммы.
1. Используйте ячейку рабочей книги в качестве метки данных.
1. Сохраните презентацию.

Ниже показан пример кода на Python, который устанавливает ячейку рабочей книги в качестве метки данных диаграммы:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Создать экземпляр класса Presentation, представляющего файл презентации.
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

## **Управление листами**

Ниже приведён пример кода на Python, демонстрирующий, как использовать свойство `worksheets` для доступа к коллекции листов:

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

## **Задание типа источника данных**

Ниже показан пример кода на Python, который задаёт тип источника данных:

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

## **Обнаружение неподдерживаемых форматов встроенных рабочих книг**

Aspose.Slides не поддерживает формат двоичной рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать свойство `embedded_workbook_type` на [ChartData](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

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
            # Встроенная рабочая книга в формате .xlsb, который не поддерживается.
            continue

        # Читайте или изменяйте данные рабочей книги диаграммы здесь.
```

## **Внешние рабочие книги**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Установка внешних рабочих книг**

С помощью метода [ChartData.set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может обновлять путь к внешней рабочей книге, если она была перемещена.

Хотя редактировать данные в рабочих книгах, хранящихся на удалённых ресурсах, нельзя, вы всё равно можете использовать такие книги как внешние источники данных. Если указать относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Ниже показан пример кода на Python, который устанавливает внешнюю рабочую книгу:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Укажите False, чтобы сохранялся только путь: целевая рабочая книга ещё не обязана существовать.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Параметр `update_chart_data` метода [set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) указывает, будет ли загружена Excel‑книга.

- Когда `update_chart_data` установлен в `False`, обновляется только путь к рабочей книге; данные диаграммы не загружаются и не обновляются из целевой книги. Используйте эту настройку, когда целевая книга отсутствует или недоступна.
- Когда `update_chart_data` установлен в `True` (значение по умолчанию), данные диаграммы загружаются и обновляются из целевой книги. Если эту книгу нельзя открыть, будет выброшено исключение с сообщением «External workbook is not available».

### **Создание внешних рабочих книг**

С помощью методов [read_workbook_stream](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете либо создать внешнюю рабочую книгу с нуля, либо преобразовать внутреннюю книгу во внешнюю.

Ниже показан пример кода на Python, демонстрирующий процесс создания внешней рабочей книги:

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

### **Получение пути к внешней рабочей книге‑источнику данных для диаграммы**

Иногда данные диаграммы привязаны к внешней Excel‑книге, а не к встроенным данным презентации. С помощью Aspose.Slides вы можете проверить источник данных диаграммы и, если это внешняя рабочая книга, считать её полный путь.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите ссылку на объект диаграммы.
1. Получите источник ([ChartDataSourceType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatasourcetype/)), представляющий источник данных диаграммы.
1. Проверьте, совпадает ли тип источника с типом внешней рабочей книги.

Ниже показан пример кода на Python, демонстрирующий эту операцию:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как во внутренних. Если внешнюю рабочую книгу нельзя загрузить, будет выброшено исключение.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, закешированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/), затем включите [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ru/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) через [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/spreadsheet_options/) перед открытием презентации.

Ниже приведён пример на Python, который открывает презентацию с диаграммой, ссылающейся на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [Chart.chart_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/chart_data/) и [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Читайте или изменяйте данные восстановленной рабочей книги здесь.
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides выбрасывает исключение. Включайте восстановление только тогда, когда использование закешированных данных диаграммы считается приемлемой альтернативой, поскольку кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/data_source_type/) и [path to an external workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник — внешняя рабочая книга, вы можете считать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако обратите внимание, что презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Тем не менее редактирование удалённых книг напрямую из Aspose.Slides не поддерживается — они могут лишь служить источником.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Только если вы редактировали данные диаграммы. Презентация хранит [link to the external file](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/) и использует его для чтения данных, поэтому открытие и сохранение презентации не изменяют рабочую книгу. Однако значения, изменённые через данные диаграммы (см. **Edit Chart Data** выше), записываются обратно во внешнюю книгу при сохранении презентации — работайте с копией, если оригинал должен оставаться нетронутым.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно предварительно снимают защиту или подготавливают расшифрованную копию (например, с помощью [Aspose.Cells](/cells/python-net/)) и связывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.