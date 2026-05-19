---
title: Управление книгами диаграмм в презентациях с помощью Python
linktitle: Книга диаграммы
type: docs
weight: 70
url: /ru/python-net/chart-workbook/
keywords:
- книга диаграмм
- данные диаграммы
- ячейка книги
- метка данных
- лист
- источник данных
- внешняя книга
- внешние данные
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Откройте Aspose.Slides для Python через .NET: без труда управляйте книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные ваших презентаций."
---
## **Обзор**

В этой статье объясняется, как работать с книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграмм через потоки книги, использовать ячейки книги в качестве меток данных, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграмм.

Также рассматривается работа с внешними книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создавать и назначать внешнюю книгу, получать путь к внешней книге, связанной с диаграммой, и редактировать данные диаграммы, когда книга доступна.

## **Чтение и запись данных диаграммы из книги**

Aspose.Slides предоставляет методы для чтения и записи книг данных диаграмм (которые содержат данные, отредактированные с помощью Aspose.Cells). **Примечание:** Данные диаграммы должны быть организованы одинаково или иметь структуру, аналогичную источнику.

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

## **Установить ячейку рабочей книги в качестве метки данных диаграммы**

Иногда нужно, чтобы метки диаграммы напрямую получали значения из ячеек основной книги данных. Aspose.Slides позволяет привязывать метки данных к конкретным ячейкам книги, чтобы текст метки всегда отражал значение ячейки. Пример ниже показывает, как включить метки «значение из ячейки» и направить выбранные метки к пользовательским ячейкам в книге диаграммы.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Добавьте пузырчатую диаграмму с примерными данными.
4. Получите доступ к рядам диаграммы.
5. Используйте ячейку книги в качестве метки данных.
6. Сохраните презентацию.

Ниже показан пример кода на Python, который устанавливает ячейку книги в качестве метки данных диаграммы:

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

Ниже приведён пример кода на Python, демонстрирующий использование свойства `worksheets` для доступа к коллекции листов:

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

## **Обнаружение неподдерживаемых форматов встроенных книг**

Aspose.Slides не поддерживает формат Excel binary workbook (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать свойство `embedded_workbook_type` объекта [ChartData](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм.

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
            # Встроенная книга находится в формате .xlsb, который не поддерживается.
            continue

        # Здесь можно читать или изменять данные книги диаграммы.
```

## **Внешние книги**

Aspose.Slides поддерживает использование внешних книг в качестве источника данных для диаграмм.

### **Установить внешние книги**

С помощью метода [ChartData.set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете назначить внешнюю книгу диаграмме в качестве её источника данных. Этот метод также может обновлять путь к внешней книге, если она была перемещена.

Хотя редактировать данные в книгах, хранящихся на удалённых ресурсах, нельзя, их всё равно можно использовать как внешние источники данных. Если указать относительный путь к внешней книге, он автоматически преобразуется в полный путь.

Ниже показан пример кода на Python, который устанавливает внешнюю книгу:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Параметр `update_chart_data` метода [set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) определяет, будет ли Excel‑книга загружена.

- Когда `update_chart_data` установлен в `False`, обновляется только путь к книге; данные диаграммы не загружаются и не обновляются из целевой книги. Используйте эту настройку, когда целевая книга отсутствует или недоступна.
- Когда `update_chart_data` установлен в `True`, данные диаграммы загружаются и обновляются из целевой книги.

### **Создать внешние книги**

С помощью методов [read_workbook_stream](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете либо создать внешнюю книгу с нуля, либо преобразовать внутреннюю книгу во внешнюю.

Этот пример кода на Python демонстрирует процесс создания внешней книги:

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

### **Получить путь к внешней книге‑источнику данных для диаграммы**

Иногда данные диаграммы связаны с внешней книгой Excel, а не с встроенными данными презентации. С помощью Aspose.Slides можно проверить источник данных диаграммы и, если это внешняя книга, прочитать её полный путь.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на объект диаграммы.
4. Получите источник ([ChartDataSourceType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatasourcetype/)), представляющий источник данных диаграммы.
5. Проверьте, соответствует ли тип источника типу внешней книги.

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

### **Редактировать данные диаграммы**

Вы можете редактировать данные во внешних книгах так же, как и во внутренних. Если внешняя книга не может быть загружена, будет выброшено исключение.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Могу ли я определить, привязана ли конкретная диаграмма к внешней или встроенной книге?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/data_source_type/) и [путь к внешней книге](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник — внешняя книга, можно считать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта, однако презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — их можно только использовать как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/) и использует её для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту заранее или создают расшифрованную копию (например, с помощью [Aspose.Cells](/cells/python-net/)) и связываются с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу?**

Да. Каждая диаграмма хранит собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла будет отражено во всех диаграммах при следующей загрузке данных.