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
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Python через .NET: без труда управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---

## **Установить данные диаграммы из рабочей книги**

Aspose.Slides предоставляет методы для чтения и записи рабочих книг данных диаграмм (которые содержат данные диаграммы, отредактированные с помощью Aspose.Cells). **Примечание:** Данные диаграммы должны быть организованы тем же способом или иметь структуру, похожую на исходную.

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

## **Установить ячейку рабочей книги в качестве метки данных диаграммы**

Иногда требуется, чтобы подписи диаграмм брались напрямую из ячеек базовой рабочей книги. Aspose.Slides позволяет привязать подписи данных к конкретным ячейкам рабочей книги, чтобы текст подписи всегда отражал значение ячейки. Пример ниже показывает, как включить подписи «значение из ячейки» и указать пользовательские ячейки для подписи точек в рабочей книге диаграммы.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Добавьте пузырьковую диаграмму с примерными данными.
4. Доступ к сериям диаграммы.
5. Используйте ячейку рабочей книги в качестве подписи данных.
6. Сохраните презентацию.

Следующий код на Python показывает, как установить ячейку рабочей книги в качестве подписи данных диаграммы:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instantiate the Presentation class that represents a presentation file.
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

## **Внешние рабочие книги**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Установка внешних рабочих книг**

С помощью метода [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может обновить путь к внешней рабочей книге, если она была перемещена.

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, вы всё равно можете использовать такие книги в качестве внешних источников данных. Если вы указываете относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

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

Параметр `update_chart_data` метода [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) указывает, будет ли загружена Excel‑книга.

- Когда `update_chart_data` установлен в `False`, обновляется только путь к книге; данные диаграммы не загружаются и не обновляются из целевой книги. Используйте эту настройку, когда целевая книга не существует или недоступна.
- Когда `update_chart_data` установлен в `True`, данные диаграммы загружаются и обновляются из целевой книги.

### **Создание внешних рабочих книг**

С помощью методов [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете либо создать внешнюю рабочую книгу с нуля, либо преобразовать внутреннюю книгу во внешнюю.

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

### **Получить путь к внешней рабочей книге источника данных для диаграммы**

Иногда данные диаграммы привязаны к внешней Excel‑книге, а не к встроенным данным презентации. С помощью Aspose.Slides вы можете исследовать источник данных диаграммы и, если это внешняя рабочая книга, прочитать полный путь к книге.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на форму диаграммы.
4. Получите источник ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)), представляющий источник данных диаграммы.
5. Проверьте, соответствует ли тип источника типу внешней рабочей книги.

Следующий код на Python демонстрирует операцию:

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

Вы можете редактировать данные во внешних рабочих книгах так же, как и во внутренних. Если внешняя рабочая книга не может быть загружена, будет выброшено исключение.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник — внешняя рабочая книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако учтите, что презентация сохраняет абсолютный путь в файле PPTX.

**Могу ли я использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться в качестве внешнего источника данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**

Нет. Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) и использует её для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при установке ссылки. Обычно снимают защиту заранее или подготавливают расшифрованную копию (например, с помощью [Aspose.Cells](/cells/python-net/)) и ссылаются на неё.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма сохраняет свою собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла отразится во всех диаграммах при следующей загрузке данных.