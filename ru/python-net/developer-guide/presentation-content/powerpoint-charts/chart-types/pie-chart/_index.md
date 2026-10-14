---
title: Настройка круговых диаграмм в презентациях с помощью Python
linktitle: Круговая диаграмма
type: docs
url: /ru/python-net/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- настройка диаграммы
- параметры диаграммы
- настройки диаграммы
- параметры построения
- цвет сектора
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте и настраивайте круговые диаграммы в Python с помощью Aspose.Slides. Настраивайте вторичные графики, отображайте подписи данных и применяйте автоматическое раскрашивание секторов в PowerPoint."
---
## **Обзор**

Эта статья объясняет, как работать с круговыми диаграммами в Aspose.Slides. Она показывает, как настроить параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie, а также как включить автоматическое раскрашивание секторов для обычной круговой диаграммы.

Примеры сосредоточены на задачах настройки диаграмм, таких как добавление диаграммы на слайд, изменение настроек серий и меток, замена данных диаграммы по умолчанию на пользовательские категории и значения, а также сохранение обновлённой презентации.

## **Параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie**

Aspose.Slides for Python via .NET поддерживает параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie. Эти параметры управляют размером вторичного графика и тем, как точки данных распределяются между двумя графиками.

Следующий пример создает диаграмму Pie of Pie в новой презентации и отображает значения точек данных в виде меток. Свойство [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) задает размер вторичного графика 149% от основного графика. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) выбирает разбиение по процентам, а [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) устанавливает пороговое значение 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Отображать значения и настроить вторичный график.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Выбор категорий для вторичного графика**

Используйте пользовательское разбиение, когда необходимо сгруппировать определённые категории во вторичном графике независимо от их процентных значений. Например, в отчёте о продажах могут быть сгруппированы Online и Events, чтобы читатели могли сравнить эти два канала, хотя они составляют 35% и 10% от общей суммы продаж.

Установите [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) в значение [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) и выберите точки через [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). Метод коллекции [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) принимает либо нулевой индекс в серии, либо объект точки данных. В этом примере индекс 1 выбирает Online, а точка с индексом 3 выбирает Events. Partners также временно добавляется, затем исключается с помощью [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Заменить данные по умолчанию данными о продажах по каналам.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Выбрать Online по его нулевому индексу и Events по объекту точки данных.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Исключить Partners из выбора без удаления его исходных данных.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) и Events (10) отображаются как отдельные сектора во вторичном графике. В основном графике они представлены одним объединённым сектором со значением 45, вместе с Retail (40) и Partners (15). Удаление Partners из пользовательского выбора оставляет её в основном графике; категория и её значение не удаляются из исходных данных диаграммы.

Следующее изображение показывает сохранённую презентацию в PowerPoint:

![Диаграмма Pie of Pie с Online и Events во вторичном графике и их объединённым значением 45 в основном графике](pie_of_pie_custom.png)

## **Установка автоматических цветов секторов круговой диаграммы**

Aspose.Slides for Python via .NET может автоматически назначать разные цвета секторам круговой диаграммы. Следующий пример создаёт круговую диаграмму с заголовком по центру и заменяет данные по умолчанию на три квартальные категории и их значения. Свойство [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) отображает значения 20, 50 и 30 в виде меток, а [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) включает различный цвет для каждого сектора.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Добавить центрированный заголовок диаграммы.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Заменить данные по умолчанию, используя первый лист.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Показать значения и назначить разные цвета секторам.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Вопросы и ответы**

**Поддерживаются ли варианты Pie of Pie и Bar of Pie?**

Да, библиотека [supports](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) вторичный график для круговых диаграмм, включая типы Pie of Pie и Bar of Pie.

**Могу ли я экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [export the chart itself as an image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (например PNG) без экспорта всей презентации.