---
title: Управление рабочими книгами диаграмм в презентациях с Python
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/python-net/chart-workbook/
keywords:
- рабочая книга диаграмм
- данные диаграммы
- ячейка рабочей книги
- подпись данных
- лист рабочего листа
- источник данных
- внешняя рабочая книга
- внешние данные
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Python via .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument для оптимизации данных вашей презентации."
---

## **Установка данных диаграммы из рабочей книги**

Aspose.Slides предоставляет методы для чтения и записи рабочих книг данных диаграмм (которые содержат данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание:** Данные диаграммы должны быть организованы одинаково или иметь структуру, схожую с исходной.

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

## **Установка ячейки рабочей книги в качестве подписи данных диаграммы**

Иногда требуется, чтобы подписи диаграммы брались непосредственно из ячеек основной рабочей книги данных. Aspose.Slides позволяет привязывать подписи данных к конкретным ячейкам рабочей книги, чтобы текст подписи всегда отражал значение ячейки. Пример ниже показывает, как включить подписи «значение‑из‑ячейки» и направить выбранные подписи к пользовательским ячейкам в рабочей книге диаграммы.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. Получите ссылку на слайд по индексу.
1. Добавьте пузырчатую диаграмму с примерными данными.
1. Доступ к сериям диаграммы.
1. Используйте ячейку рабочей книги в качестве подписи данных.
1. Сохраните презентацию.

Ниже показан код на Python, демонстрирующий установку ячейки рабочей книги в качестве подписи данных диаграммы:

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

## **Управление листами рабочего листа**

Ниже показан код на Python, демонстрирующий использование свойства `worksheets` для доступа к коллекции листов:

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

Ниже показан код на Python, демонстрирующий, как указать тип источника данных:

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

## **Внешние рабочие книги**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Установка внешних рабочих книг**

С помощью метода [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может обновлять путь к внешней рабочей книге, если её переместили.

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, их всё равно можно использовать в качестве внешних источников данных. Если вы указываете относительный путь к внешней рабочей книге, он автоматически преобразуется в абсолютный.

Ниже показан код на Python, демонстрирующий установку внешней рабочей книги:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Параметр `update_chart_data` метода [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) указывает, будет ли загружена Excel‑рабочая книга.

- Когда `update_chart_data` установлено в `False`, обновляется только путь к рабочей книге; данные диаграммы не загружаются и не обновляются из целевой рабочей книги. Используйте эту настройку, когда целевая рабочая книга не существует или недоступна.
- Когда `update_chart_data` установлено в `True`, данные диаграммы загружаются и обновляются из целевой рабочей книги.

### **Создание внешних рабочих книг**

С помощью методов [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете либо создать внешнюю рабочую книгу с нуля, либо преобразовать внутреннюю рабочую книгу во внешнюю.

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

### **Получение пути к внешнему источнику данных рабочей книги для диаграммы**

Иногда данные диаграммы привязаны к внешней Excel‑рабочей книге, а не к встроенным данным презентации. С помощью Aspose.Slides вы можете проверить источник данных диаграммы и, если это внешняя рабочая книга, прочитать полный путь к ней.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите ссылку на объект диаграммы.
1. Получите источник ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)), представляющий источник данных диаграммы.
1. Проверьте, соответствует ли тип источника типу внешней рабочей книги.

Ниже показан код на Python, демонстрирующий эту операцию:

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

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) и [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако имейте в виду, что презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать рабочие книги, размещённые на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут использоваться в качестве внешнего источника данных. Однако прямое редактирование удалённых рабочих книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация сохраняет [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) и использует его только для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту предварительно или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/python-net/)) и связываются с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.