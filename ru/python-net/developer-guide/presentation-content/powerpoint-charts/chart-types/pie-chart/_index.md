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
- цвет сегмента
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и настраивать круговые диаграммы в Python с помощью Aspose.Slides, экспортировать их в PowerPoint и OpenDocument, ускоряя рассказ о данных за секунды."
---

## **Параметры второго графика для диаграмм «Круг внутри круга» и «Столбец внутри круга»**
Aspose.Slides for Python via .NET теперь поддерживает параметры второго графика для диаграмм «Круг внутри круга» и «Столбец внутри круга». В этой статье мы покажем на примере, как указать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующие шаги:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавьте диаграмму на слайд.
3. Укажите параметры второго графика диаграммы.
4. Сохраните презентацию на диск.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создать экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Добавить диаграмму на слайд
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Установить различные свойства
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Сохранить презентацию на диск
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Установить автоматические цвета сегментов круговой диаграммы**
Aspose.Slides for Python via .NET предоставляет простой API для установки автоматических цветов сегментов круговой диаграммы. Пример кода применяет указанные выше свойства.

1. Создайте экземпляр класса Presentation.
2. Получите первый слайд.
3. Добавьте диаграмму с данными по умолчанию.
4. Установите заголовок диаграммы.
5. Установите для первой серии отображение значений.
6. Установите индекс листа данных диаграммы.
7. Получите лист данных диаграммы.
8. Удалите автоматически сгенерированные серии и категории.
9. Добавьте новые категории.
10. Добавьте новую серию.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation, представляющего файл PPTX
with slides.Presentation() as presentation:
	# Получить первый слайд
	slide = presentation.slides[0]

	# Добавить диаграмму с данными по умолчанию
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Установить заголовок диаграммы
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Установить для первой серии отображение значений
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Установить индекс листа данных диаграммы
	defaultWorksheetIndex = 0

	# Получить лист данных диаграммы
	fact = chart.chart_data.chart_data_workbook

	# Удалить автоматически сгенерированные серии и категории
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Добавить новые категории
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Добавить новую серию
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Теперь заполняем данные серии
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Поддерживаются ли варианты «Круг внутри круга» и «Столбец внутри круга»?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) вторичный график для круговых диаграмм, включая типы «Круг внутри круга» и «Столбец внутри круга».

**Можно ли экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (например, PNG) без всей презентации.