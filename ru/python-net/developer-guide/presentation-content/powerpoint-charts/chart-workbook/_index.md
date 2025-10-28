---
title: "Управление рабочими книгами диаграмм в презентациях с помощью Python"
linktitle: "Рабочая книга диаграммы"
type: docs
weight: 70
url: /ru/python-net/chart-workbook/
keywords:
- "рабочая книга диаграммы"
- "данные диаграммы"
- "ячейка рабочей книги"
- "метка данных"
- "лист"
- "источник данных"
- "внешняя рабочая книга"
- "внешние данные"
- "PowerPoint"
- "презентация"
- "Python"
- "Aspose.Slides"
description: "Откройте для себя Aspose.Slides для Python через .NET: без труда управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---

## **Установить данные диаграммы из рабочей книги**

Aspose.Slides предоставляет методы для чтения и записи рабочих книг данных диаграмм (которые содержат данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание:** Данные диаграммы должны быть организованы одинаково или иметь структуру, схожую с исходными.

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

Иногда нужны метки диаграммы, получаемые непосредственно из ячеек базовой рабочей книги данных. Aspose.Slides позволяет привязывать метки данных к конкретным ячейкам рабочей книги, чтобы текст метки всегда соответствовал значению ячейки. Ниже показан пример, как включить метки «значение из ячейки» и привязать выбранные метки к пользовательским ячейкам в рабочей книге диаграммы.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) .
1. Получите ссылку на слайд по индексу.
1. Добавьте пузырчатую диаграмму с примерными данными.
1. Получите доступ к сериям диаграммы.
1. Используйте ячейку рабочей книги в качестве метки данных.
1. Сохраните презентацию.

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

С помощью метода [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете назначить внешнюю рабочую книгу диаграмме в качестве источника данных. Этот метод также может обновлять путь к внешней рабочей книге, если она была перемещена.

Хотя вы не можете редактировать данные в рабочих книгах, находящихся на удалённых ресурсах, их всё равно можно использовать в качестве внешних источников данных. Если указать относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

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

- Когда `update_chart_data` установлен в `False`, обновляется только путь к рабочей книге; данные диаграммы не загружаются и не обновляются из целевой рабочей книги. Используйте эту настройку, если целевая рабочая книга не существует или недоступна.
- Когда `update_chart_data` установлен в `True`, данные диаграммы загружаются и обновляются из целевой рабочей книги.

### **Создание внешних рабочих книг**

С помощью методов [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете либо создать внешнюю рабочую книгу с нуля, либо преобразовать внутреннюю рабочую книгу во внешнюю.

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

Иногда данные диаграммы связаны с внешней Excel‑книгой, а не с встроенными данными презентации. С помощью Aspose.Slides вы можете проверить источник данных диаграммы и, если это внешняя рабочая книга, прочитать её полный путь.

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на объект диаграммы.
4. Получите источник ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)), представляющий источник данных диаграммы.
5. Проверьте, соответствует ли тип источника типу внешней рабочей книги.

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

Вы можете редактировать данные во внешних рабочих книгах так же, как во внутренних. Если внешняя рабочая книга не может быть загружена, будет выброшено исключение.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**  
Да. Диаграмма имеет [тип источника данных](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник — внешняя рабочая книга, вы можете прочитать её полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам, и как они хранятся?**  
Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако следует учитывать, что презентация сохраняет абсолютный путь в файле PPTX.

**Могу ли я использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**  
Да, такие рабочие книги могут использоваться в качестве внешнего источника данных. Однако прямое редактирование удалённых рабочих книг через Aspose.Slides не поддерживается — их можно лишь использовать как источник.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**  
Нет. Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) и использует её для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищен паролем?**  
Aspose.Slides не принимает пароль при связывании. Обычно предварительно удаляют защиту или готовят расшифрованную копию (например, используя [Aspose.Cells](/cells/python-net/)) и ссылаются на неё.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**  
Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла отразится во всех диаграммах при следующей загрузке данных.