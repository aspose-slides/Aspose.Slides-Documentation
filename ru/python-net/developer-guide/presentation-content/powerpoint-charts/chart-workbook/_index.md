---
title: Управление рабочими книгами диаграмм в презентациях с помощью Python
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
- кеш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Python через .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными презентации."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграмм через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграмм.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных для диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides предоставляет методы для чтения и записи рабочих книг данных диаграмм (которые содержат данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание:** Данные диаграммы должны быть организованы таким же образом или иметь структуру, аналогичную источнику.

Следующий код на Python демонстрирует пример операции:

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

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**

Иногда требуется, чтобы метки диаграммы получали значения непосредственно из ячеек базовой рабочей книги данных. Aspose.Slides позволяет привязывать метки данных к конкретным ячейкам рабочей книги, чтобы текст метки всегда отражал значение ячейки. В примере ниже показано, как включить метки, получающие значение из ячейки, и направить выбранные метки к пользовательским ячейкам в рабочей книге диаграммы.

1. Создать экземпляр класса [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/).
2. Получить ссылку на слайд по индексу.
3. Добавить пузырчатую диаграмму с примерными данными.
4. Получить доступ к сериям диаграммы.
5. Использовать ячейку рабочей книги в качестве метки данных.
6. Сохранить презентацию.

Следующий код на Python показывает, как установить ячейку рабочей книги в качестве метки данных диаграммы:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Создайте экземпляр класса Presentation, представляющего файл презентации.
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

Следующий код на Python демонстрирует, как использовать свойство `worksheets` для доступа к коллекции листов:

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

## **Указание типа источника данных**

Следующий код на Python показывает, как указать тип источника данных:

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

Aspose.Slides не поддерживает двоичный формат рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать свойство `embedded_workbook_type` в объекте [ChartData](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

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

        # Здесь читаем или изменяем данные рабочей книги диаграммы.
```

## **Внешние рабочие книги**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Установка внешних рабочих книг**

С помощью метода [ChartData.set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) можно назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может обновить путь к внешней рабочей книге, если она была перемещена.

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, их всё равно можно использовать в качестве внешних источников данных. Если указать относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Следующий код на Python показывает, как установить внешнюю рабочую книгу:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Параметр `update_chart_data` метода [set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) указывает, будет ли загружена Excel‑рабочая книга.

- Когда `update_chart_data` установлен в `False`, обновляется только путь к рабочей книге; данные диаграммы не загружаются и не обновляются из целевой рабочей книги. Используйте эту настройку, когда целевая рабочая книга не существует или недоступна.
- Когда `update_chart_data` установлен в `True`, данные диаграммы загружаются и обновляются из целевой рабочей книги.

### **Создание внешних рабочих книг**

С помощью методов [read_workbook_stream](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) можно либо создать внешнюю рабочую книгу с нуля, либо преобразовать внутреннюю рабочую книгу во внешнюю.

Этот код на Python демонстрирует процесс создания внешней рабочей книги:

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

### **Получение пути к внешней рабочей книге источника данных для диаграммы**

Иногда данные диаграммы связаны с внешней рабочей книгой Excel, а не со встроенными данными презентации. С помощью Aspose.Slides можно проверить источник данных диаграммы и, если это внешняя рабочая книга, считать полный путь к ней.

1. Создать экземпляр класса [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/).
2. Получить ссылку на слайд по его индексу.
3. Получить ссылку на форму диаграммы.
4. Получить источник ([ChartDataSourceType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatasourcetype/)), представляющий источник данных диаграммы.
5. Проверить, соответствует ли тип источника типу внешней рабочей книги.

Следующий код на Python демонстрирует эту операцию:

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

Данные во внешних рабочих книгах можно редактировать так же, как и данные во внутренних рабочих книгах. Если внешнюю рабочую книгу нельзя загрузить, будет выброшено исключение.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/), затем включите [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ru/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) через [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/spreadsheet_options/) перед открытием презентации.

Следующий пример на Python открывает презентацию, в которой диаграмма ссылается на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [Chart.chart_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/chart_data/) и [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Здесь читаем или изменяем данные восстановленной рабочей книги.
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемым резервным вариантом, так как кэш может не содержать изменений, внесённых во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/data_source_type/) и [path to an external workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник — внешняя рабочая книга, можно считать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако имейте в виду, что презентация сохраняет абсолютный путь в файле PPTX.

**Могу ли я использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги можно использовать в качестве внешнего источника данных. Однако редактирование удалённых рабочих книг непосредственно из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**

Нет. Презентация сохраняет [link to the external file](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/) и использует его для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при установке ссылки. Распространённый подход — заранее снять защиту или подготовить расшифрованную копию (например, с помощью [Aspose.Cells](/cells/python-net/)) и ссылаться на эту копию.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.