---
title: У管理工作 책 диаграмм в презентациях с помощью Python
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
description: "Откройте для себя Aspose.Slides для Python через .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---

## **Установить данные диаграммы из рабочей книги**

Aspose.Slides предоставляет методы для чтения и записи рабочих книг данных диаграмм (которые содержат данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание:** Данные диаграммы должны быть организованы таким же образом или иметь структуру, похожую на исходную.

Следующий код Python демонстрирует пример операции:
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

Иногда требуются метки диаграммы, берущие данные напрямую из ячеек базовой рабочей книги. Aspose.Slides позволяет привязывать метки данных к конкретным ячейкам рабочей книги, чтобы текст метки всегда отражал значение ячейки. Пример ниже показывает, как включить метки «значение из ячейки» и направить выбранные метки к пользовательским ячейкам в рабочей книге диаграммы.

1. Создать экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
2. Получить ссылку на слайд по индексу.
3. Добавить пузырчатую диаграмму с примерными данными.
4. Получить доступ к сериям диаграммы.
5. Использовать ячейку рабочей книги в качестве метки данных.
6. Сохранить презентацию.

Следующий код Python показывает, как установить ячейку рабочей книги в качестве метки данных диаграммы:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Создайте объект класса Presentation, представляющий файл презентации.
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

Следующий код Python демонстрирует, как использовать свойство `worksheets` для доступа к коллекции листов:
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


## **Указать тип источника данных**

Следующий код Python показывает, как указать тип источника данных:
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

### **Установить внешние рабочие книги**

Используя метод [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), можно назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может обновить путь к внешней рабочей книге, если она была перемещена.

Хотя редактировать данные в рабочих книгах, хранящихся на удалённых ресурсах, невозможно, вы всё равно можете использовать такие книги как внешние источники данных. Если указать относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Следующий код Python показывает, как установить внешнюю рабочую книгу:
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

- Когда `update_chart_data` установлено в `False`, обновляется только путь к рабочей книге; данные диаграммы не загружаются и не обновляются из целевой рабочей книги. Используйте эту настройку, если целевая рабочая книга не существует или недоступна.
- Когда `update_chart_data` установлено в `True`, данные диаграммы загружаются и обновляются из целевой рабочей книги.

### **Создать внешние рабочие книги**

С помощью методов [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) можно либо создать внешнюю рабочую книгу с нуля, либо конвертировать внутреннюю книгу во внешнюю.

Этот код Python демонстрирует процесс создания внешней рабочей книги:
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


### **Получить путь к рабочей книге внешнего источника данных для диаграммы**

Иногда данные диаграммы привязаны к внешней Excel‑книге, а не к встроенным данным презентации. С помощью Aspose.Slides можно проверить источник данных диаграммы и, если это внешняя рабочая книга, прочитать её полный путь.

1. Создать экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
2. Получить ссылку на слайд по его индексу.
3. Получить ссылку на объект диаграммы.
4. Получить источник ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)), представляющий источник данных диаграммы.
5. Проверить, совпадает ли тип источника с типом внешней рабочей книги.

Следующий код Python демонстрирует эту операцию:
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

Можно редактировать данные во внешних рабочих книгах так же, как и во внутренних. Если внешнюю книгу невозможно загрузить, генерируется исключение.
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Часто задаваемые вопросы**

**Могу ли я определить, привязана ли определённая диаграмма к внешней или встроенной рабочей книге?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник — внешняя рабочая книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако следует помнить, что презентация сохраняет абсолютный путь в файле PPTX.

**Могу ли я использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут использоваться как внешний источник данных. Однако редактирование удалённых книг непосредственно из Aspose.Slides не поддерживается — они могут использоваться только в качестве источника.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**

Нет. Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) и использует её для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычное решение — снять защиту заранее или подготовить расшифрованную копию (например, с помощью [Aspose.Cells](/cells/python-net/)) и привязать к этой копии.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла будет отражено в каждой диаграмме при следующей загрузке данных.