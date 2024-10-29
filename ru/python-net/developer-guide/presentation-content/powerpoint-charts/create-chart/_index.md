---
title: Создание диаграмм для презентаций PowerPoint на Python
linktitle: Создать диаграмму
type: docs
weight: 10
url: /ru/python-net/create-chart/
keywords: "Создать диаграмму, разбросанная диаграмма, круговая диаграмма, диаграмма дерева, фондовая диаграмма, диаграмма ящика и усов, гистограмма, воронкообразная диаграмма, диаграмма с солнечным всплеском, многокатегорная диаграмма, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Создайте диаграмму в презентации PowerPoint на Python"
---

## **Создание диаграммы**

Диаграммы помогают людям быстро визуализировать данные и получать понимание, которое может быть неочевидным из таблицы или электронной таблицы.

**Почему стоит создавать диаграммы?**

Создавая диаграммы, вы можете

* агрегировать, сжимать или обобщать большие объемы данных на одном слайде презентации
* выявлять закономерности и тенденции в данных
* выводить направление и импульс данных со временем или относительно конкретной единицы измерения
* выявлять выбросы, аномалии, отклонения, ошибки, нелепые данные и т. д.
* передавать или представлять сложные данные

В PowerPoint вы можете создавать диаграммы с помощью функции вставки, которая предоставляет шаблоны, используемые для проектирования самых различных типов диаграмм. Используя Aspose.Slides, вы можете создавать обычные диаграммы (на основе популярных типов диаграмм) и настраиваемые диаграммы.

{{% alert color="primary" %}} 

Чтобы позволить вам создавать диаграммы, Aspose.Slides предоставляет перечисление [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) в пространстве имен [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/). Члены этого перечисления соответствуют различным типам диаграмм. 

{{% /alert %}} 

### **Создание обычных диаграмм**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с некоторыми данными и укажите предпочтительный тип диаграммы. 
1. Добавьте заголовок для диаграммы. 
1. Получите рабочий лист данных диаграммы.
1. Очистите все стандартные ряды и категории.
1. Добавьте новые ряды и категории.
1. Добавьте новые данные диаграммы для рядов диаграммы.
1. Добавьте цвет заливки для рядов диаграммы.
1. Добавьте метки для рядов диаграммы. 
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python покажет вам, как создать обычную диаграмму:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаем экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as pres:

    # Обратитесь к первому слайду
    sld = pres.slides[0]

    # Добавьте диаграмму с данными по умолчанию
    chart = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 0, 0, 500, 500)

    # Установка заголовка диаграммы
    chart.chart_title.add_text_frame_for_overriding("Пример заголовка")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # Установите для первой серии отображение значений
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Установка индекса рабочего листа диаграммы
    defaultWorksheetIndex = 0

    # Получаем рабочий лист данных диаграммы
    fact = chart.chart_data.chart_data_workbook

    # Удаляем стандартные серии и категории
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    s = len(chart.chart_data.series)
    s = len(chart.chart_data.categories)

    # Добавляем новые серии
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.type)

    # Добавляем новые категории
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Категория 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Категория 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Категория 3"))

    # Берем первую серию диаграммы
    series = chart.chart_data.series[0]

    # Теперь заполняем данные серии

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # Установка цвета заливки для серии
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red


    # Берем вторую серию диаграммы
    series = chart.chart_data.series[1]

    # Теперь заполняем данные серии
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Установка цвета заливки для серии
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Первая метка будет показывать имя категории
    lbl = series.data_points[0].label
    lbl.data_label_format.show_category_name = True

    lbl = series.data_points[1].label
    lbl.data_label_format.show_series_name = True

    # Покажите значение для третьей метки
    lbl = series.data_points[2].label
    lbl.data_label_format.show_value = True
    lbl.data_label_format.show_series_name = True
    lbl.data_label_format.separator = "/"
                
    # Сохраните презентацию с диаграммой
    pres.save("AsposeChart_out-1.pptx", slides.export.SaveFormat.PPTX)
```


### **Создание разбросанных диаграмм**
Разбросанные диаграммы (также известные как диаграммы разброса или x-y графики) часто используются для проверки паттернов или демонстрации корреляций между двумя переменными. 

Вы можете захотеть использовать разбросанную диаграмму, когда 

* у вас есть парные числовые данные
* у вас есть 2 переменные, которые хорошо сочетаются друг с другом
* вы хотите определить, связаны ли 2 переменные
* у вас есть независимая переменная с несколькими значениями для зависимой переменной

Этот код на Python покажет вам, как создать разбросанные диаграммы с другим набором маркеров: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    slide = pres.slides[0]

    # Создание стандартной диаграммы
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 0, 0, 400, 400)

    # Получение индекса рабочего листа данных диаграммы
    defaultWorksheetIndex = 0

    # Получаем рабочий лист данных диаграммы
    fact = chart.chart_data.chart_data_workbook

    # Удаляем демонстрационные серии
    chart.chart_data.series.clear()

    # Добавляем новые серии
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Серия 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 3, "Серия 2"), chart.type)

    # Берем первую серию диаграммы
    series = chart.chart_data.series[0]

    # Добавляем новую точку (1:3) там.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 1), fact.get_cell(defaultWorksheetIndex, 2, 2, 3))

    # Добавляем новую точку (2:10)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 2), fact.get_cell(defaultWorksheetIndex, 3, 2, 10))

    # Редактирование типа серии
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Изменение маркера серии диаграммы
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Берем вторую серию диаграммы
    series = chart.chart_data.series[1]

    # Добавляем новую точку (5:2) там.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 5), fact.get_cell(defaultWorksheetIndex, 2, 4, 2))

    # Добавляем новую точку (3:1)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 3), fact.get_cell(defaultWorksheetIndex, 3, 4, 1))

    # Добавляем новую точку (2:2)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 4, 3, 2), fact.get_cell(defaultWorksheetIndex, 4, 4, 2))

    # Добавляем новую точку (5:1)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 5, 3, 5), fact.get_cell(defaultWorksheetIndex, 5, 4, 1))

    # Изменение маркера серии диаграммы
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    pres.save("AsposeChart_out-2.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание круговых диаграмм**

Круговые диаграммы лучше всего использовать для отображения отношения части к целому в данных, особенно когда данные содержат категориальные метки с числовыми значениями. Однако, если ваши данные содержат много частей или меток, вам может быть лучше рассмотреть возможность использования столбчатой диаграммы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и желаемым типом (в данном случае `ChartType.PIE`).
1. Получите IChartDataWorkbook данных диаграммы.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для рядов диаграммы.
1. Добавьте новые точки для диаграмм и установите пользовательские цвета для секторов круговой диаграммы.
1. Установите метки для рядов.
1. Установите линии лидера для меток рядов.
1. Установите угол поворота для секторов круговой диаграммы.
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python покажет вам, как создать круговую диаграмму:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаем экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as presentation:

    # Обратитесь к первому слайду
    slide = presentation.slides[0]

    # Добавьте диаграмму с данными по умолчанию
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Установка заголовка диаграммы
    chart.chart_title.add_text_frame_for_overriding("Пример заголовка")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # Установите для первой серии отображение значений
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Установка индекса рабочего листа диаграммы
    defaultWorksheetIndex = 0

    # Получаем рабочий лист данных диаграммы
    fact = chart.chart_data.chart_data_workbook

    # Удаляем стандартные серии и категории
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Добавляем новые категории
    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "Первый квартал"))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "Второй квартал"))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "Третий квартал"))

    # Добавляем новые серии
    series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Серия 1"), chart.type)

    # Теперь заполняем данные серии
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # Не работает в новой версии
    # Добавление новых точек и установка цвета сектора
    # series.IsColorVaried = True
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan
    # Установка границы сектора
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Установка границы сектора
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Установка границы сектора
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Создание пользовательских меток для каждой категории для новой серии
    lbl1 = series.data_points[0].label

    # lbl.show_category_name = True
    lbl1.data_label_format.show_value = True

    lbl2 = series.data_points[1].label
    lbl2.data_label_format.show_value = True
    lbl2.data_label_format.show_legend_key = True
    lbl2.data_label_format.show_percentage = True

    lbl3 = series.data_points[2].label
    lbl3.data_label_format.show_series_name = True
    lbl3.data_label_format.show_percentage = True

    # Показать линии лидера для диаграммы
    series.labels.default_data_label_format.show_leader_lines = True

    # Установка угла поворота для секторов круговой диаграммы
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Сохраните презентацию с диаграммой
    presentation.save("PieChart_out-3.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание линейных диаграмм**

Линейные диаграммы (также известные как линейные графики) лучше всего использовать в ситуациях, когда вы хотите продемонстрировать изменения значения с течением времени. Используя линейную диаграмму, вы можете сравнивать множество данных одновременно, отслеживать изменения и тенденции с течением времени, подчеркивать аномалии в серии данных и т. д.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и желаемым типом (в данном случае, `ChartType.Line`).
1. Получите [IChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/) данных диаграммы.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для рядов диаграммы.
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python покажет вам, как создать линейную диаграмму: 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)
    
    pres.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

По умолчанию точки на линейной диаграмме соединяются прямыми непрерывными линиями. Если вы хотите, чтобы точки соединялись линиями с тире, вы можете указать предпочитаемый тип тире следующим образом: 

```python
lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in lineChart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

### **Создание диаграмм дерева**

Диаграммы дерева лучше всего использовать для данных о продажах, когда вы хотите показать относительный размер категорий данных и одновременно быстро привлечь внимание к элементам, которые являются крупными вкладчиками в каждую категорию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и желаемым типом (в данном случае, `ChartType.TREEMAP`).
1. Получите IChartDataWorkbook данных диаграммы.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для рядов диаграммы.
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python покажет вам, как создать диаграмму дерева:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #ветка 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Лист1"))
    leaf.grouping_levels.set_grouping_item(1, "Стебель1")
    leaf.grouping_levels.set_grouping_item(2, "Ветка1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Лист2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Лист3"))
    leaf.grouping_levels.set_grouping_item(1, "Стебель2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Лист4"))


    #ветка 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Лист5"))
    leaf.grouping_levels.set_grouping_item(1, "Стебель3")
    leaf.grouping_levels.set_grouping_item(2, "Ветка2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Лист6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Лист7"))
    leaf.grouping_levels.set_grouping_item(1, "Стебель4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Лист8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    pres.save("Treemap-4.pptx", slides.export.SaveFormat.PPTX)
```


### **Создание фондовых диаграмм**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и желаемым типом (ChartType.OPEN_HIGH_LOW_CLOSE).
1. Получите IChartDataWorkbook данных диаграммы.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для рядов диаграммы.
1. Укажите формат HiLowLines.
1. Запишите измененную презентацию в файл PPTX.

Пример кода на Python, используемого для создания фондовой диаграммы:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 50, 50, 600, 400, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    wb = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(wb.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(wb.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(wb.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(wb.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    pres.save("output-5.pptx", slides.export.SaveFormat.PPTX)
```


### **Создание диаграмм «Ящик и усы»**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и желаемым типом (ChartType.BOX_AND_WHISKER).
1. Получите IChartDataWorkbook данных диаграммы.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для рядов диаграммы.
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python покажет вам, как создать диаграмму «Ящик и усы»:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "Категория 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "Категория 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "Категория 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "Категория 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "Категория 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "Категория 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B6", 16))


    pres.save("BoxAndWhisker-6.pptx", slides.export.SaveFormat.PPTX)
```


### **Создание воронкообразных диаграмм**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и желаемым типом (ChartType.Funnel).
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python покажет вам, как создать воронкообразную диаграмму:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "Категория 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "Категория 2"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "Категория 3"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "Категория 4"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "Категория 5"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "Категория 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B6", 500))

    pres.save("Funnel-7.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание диаграмм солнечного всплеска**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и желаемым типом (в данном случае, `ChartType.SUNBURST`).
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python покажет вам, как создать диаграмму солнечного всплеска:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #ветка 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Лист1"))
    leaf.grouping_levels.set_grouping_item(1, "Стебель1")
    leaf.grouping_levels.set_grouping_item(2, "Ветка1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Лист2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Лист3"))
    leaf.grouping_levels.set_grouping_item(1, "Стебель2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Лист4"))

    #ветка 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Лист5"))
    leaf.grouping_levels.set_grouping_item(1, "Стебель3")
    leaf.grouping_levels.set_grouping_item(2, "Ветка2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Лист6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Лист7"))
    leaf.grouping_levels.set_grouping_item(1, "Стебель4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Лист8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D8", 3))

    pres.save("Sunburst-8.pptx", slides.export.SaveFormat.PPTX)
```


### **Создание гистограмм**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу. 
1. Добавьте диаграмму с некоторыми данными и укажите предпочтительный тип диаграммы (в данном случае, `ChartType.HISTOGRAM`).
1. Получите IChartDataWorkbook данных диаграммы.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python покажет вам, как создать гистограмму:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    pres.save("Histogram-9.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание радиальных диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу. 
1. Добавьте диаграмму с некоторыми данными и укажите предпочитаемый тип диаграммы (`ChartType.RADAR` в этом случае).
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python покажет вам, как создать радиальную диаграмму:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 400, 300)
    pres.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание многокатегорных диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и желаемым типом (ChartType.ClusteredColumn).
1. Получите IChartDataWorkbook данных диаграммы.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для рядов диаграммы.
1. Запишите измененную презентацию в файл.

Этот код на Python покажет вам, как создать многокатегорную диаграмму:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]

    ch = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 600, 450)
    ch.chart_data.series.clear()
    ch.chart_data.categories.clear()


    fact = ch.chart_data.chart_data_workbook
    fact.clear(0)
    defaultWorksheetIndex = 0

    category = ch.chart_data.categories.add(fact.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Группа1")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c3", "B"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Группа2")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c5", "D"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Группа3")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c7", "F"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Группа4")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c9", "H"))

    # Добавление серий
    series = ch.chart_data.series.add(fact.get_cell(0, "D1", "Серия 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D2", 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D3", 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D4", 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D5", 40))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D6", 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D7", 60))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D8", 70))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D9", 80))
    # Сохраните презентацию с диаграммой
    pres.save("AsposeChart_out-10.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание картографических диаграмм**

Картографическая диаграмма — это визуализация области, содержащей данные. Картографические диаграммы лучше всего использовать для сравнения данных или значений по географическим регионам.

Этот код на Python покажет вам, как создать картографическую диаграмму:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 50, 50, 500, 400, False)
    pres.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание комбинированных диаграмм**

Комбинированная диаграмма (или комбо-диаграмма) — это диаграмма, которая сочетает в себе две или более диаграмм на одном графике. Такая диаграмма позволяет выделить, сравнить или просмотреть различия между двумя (или более) наборами данных. Таким образом, вы видите взаимосвязь (если такая имеется) между наборами данных. 

![combination-chart-ppt](combination-chart-ppt.png)

Этот код на Python покажет вам, как создать комбинированную диаграмму в PowerPoint:

```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    pres = slides.Presentation()
    chart = create_chart(pres.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)
    pres.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Серия 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Серия 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Категория 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Категория 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Категория 3"))

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    series = chart.chart_data.series[1]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    return chart


def add_first_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Серия 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Серия 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```

## **Обновление диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), который представляет презентацию, содержащую диаграмму.
2. Получите ссылку на слайд по его индексу.
3. Пройдите через все фигуры, чтобы найти желаемую диаграмму.
4. Получите рабочий лист данных диаграммы.
5. Измените данные рядов диаграммы, изменив значения рядов.
6. Добавьте новый ряд и заполните его данными.
7. Запишите измененную презентацию как файл PPTX.

Этот код на Python покажет вам, как обновить диаграмму:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаем экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation(path + "ExistingChart.pptx") as pres:

    # Обратитесь к первому слайду
    sld = pres.slides[0]

    # Добавьте диаграмму с данными по умолчанию
    chart = sld.shapes[0]

    # Установка индекса рабочего листа диаграммы
    defaultWorksheetIndex = 0

    # Получаем рабочий лист данных диаграммы
    fact = chart.chart_data.chart_data_workbook


    # Изменение имени категории диаграммы
    fact.get_cell(defaultWorksheetIndex, 1, 0, "Измененная категория 1")
    fact.get_cell(defaultWorksheetIndex, 2, 0, "Измененная категория 2")


    # Берем первую серию диаграммы
    series = chart.chart_data.series[0]

    # Теперь обновляем данные серии
    fact.get_cell(defaultWorksheetIndex, 0, 1, "Новая_Серия1")# Изменение имени серии
    series.data_points[0].value.data = 90
    series.data_points[1].value.data = 123
    series.data_points[2].value.data = 44

    # Берем вторую серию диаграммы
    series = chart.chart_data.series[1]

    # Теперь обновляем данные серии
    fact.get_cell(defaultWorksheetIndex, 0, 2, "Новая_Серия2")# Изменение имени серии
    series.data_points[0].value.data = 23
    series.data_points[1].value.data = 67
    series.data_points[2].value.data = 99


    # Теперь добавляем новую серию
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 3, "Серия 3"), chart.type)

    # Берем третью серию диаграммы
    series = chart.chart_data.series[2]

    # Теперь заполняем данные серии
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 3, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 30))

    chart.type = charts.ChartType.CLUSTERED_CYLINDER

    # Сохраните презентацию с диаграммой
    pres.save("AsposeChartModified_out-11.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка диапазона данных для диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), который представляет презентацию, содержащую диаграмму.
2. Получите ссылку на слайд по его индексу.
3. Пройдите через все фигуры, чтобы найти желаемую диаграмму.
4. Получите данные диаграммы и установите диапазон.
5. Сохраните измененную презентацию как файл PPTX.

Этот код на Python покажет вам, как установить диапазон данных для диаграммы:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаем экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Обратитесь к первому слайду и добавьте диаграмму с данными по умолчанию
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    chart.chart_data.set_range("Sheet1!A1:B4")
    presentation.save("SetDataRange_out-12.pptx", slides.export.SaveFormat.PPTX)
```


## **Использование стандартных маркеров в диаграммах**
Когда вы используете стандартный маркер в диаграммах, каждая серия диаграммы автоматически получает разные стандартные символы маркера.

Этот код на Python покажет вам, как установить маркер серии диаграммы автоматически:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    fact = chart.chart_data.chart_data_workbook
    chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Серия 1"), chart.type)
    series = chart.chart_data.series[0]

    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 1, 24))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 1, 23))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 1, -10))
    chart.chart_data.categories.add(fact.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 1, None))

    chart.chart_data.series.add(fact.get_cell(0, 0, 2, "Серия 2"), chart.type)
    # Берем вторую серию диаграммы
    series2 = chart.chart_data.series[1]

    # Теперь заполняем данные серии
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    pres.save("DefaultMarkersInChart-13.pptx", slides.export.SaveFormat.PPTX)
```