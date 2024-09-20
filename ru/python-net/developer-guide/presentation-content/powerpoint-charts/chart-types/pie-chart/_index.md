---
title: Пироговая диаграмма
type: docs
url: /python-net/pie-chart/
keywords: "Пироговая диаграмма, параметры графика, цвета срезов, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Параметры построения пироговой диаграммы и цвета срезов в презентации PowerPoint на Python"
---

## **Вторые параметры построения для диаграммы Пирог из Пирога и Бар из Пирога**
Aspose.Slides для Python через .NET теперь поддерживает вторые параметры построения для диаграммы Пирог из Пирога или Бар из Пирога. В этой теме мы рассмотрим примеры того, как указать эти параметры с помощью Aspose.Slides. Чтобы указать свойства, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте график на слайд.
1. Укажите вторые параметры построения графика.
1. Запишите презентацию на диск.

В приведенном ниже примере мы установили различные свойства диаграммы Пирог из Пирога.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создание экземпляра класса Presentation
with slides.Presentation() as presentation:
    # Добавление графика на слайд
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Установка различных свойств
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Запись презентации на диск
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка автоматических цветов срезов пироговой диаграммы**
Aspose.Slides для Python через .NET предоставляет простой API для установки автоматических цветов срезов пироговой диаграммы. Пример кода применяет установку вышеуказанных свойств.

1. Создайте экземпляр класса Presentation.
1. Получите первый слайд.
1. Добавьте график с данными по умолчанию.
1. Установите заголовок графика.
1. Установите первое значение серии на Показать значения.
1. Установите индекс рабочего листа графика.
1. Получите рабочий лист данных графика.
1. Удалите сгенерированные по умолчанию серии и категории.
1. Добавьте новые категории.
1. Добавьте новые серии.

Запишите изменённую презентацию в файл PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as presentation:
	# Получите первый слайд
	slide = presentation.slides[0]

	# Добавьте график с данными по умолчанию
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Установка заголовка графика
	chart.chart_title.add_text_frame_for_overriding("Пример заголовка")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Установите первое значение серии на Показать значения
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Установка индекса рабочего листа графика
	defaultWorksheetIndex = 0

	# Получение рабочего листа данных графика
	fact = chart.chart_data.chart_data_workbook

	# Удаление сгенерированных по умолчанию серий и категорий
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Добавление новых категорий
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "Первый квартал"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "Второй квартал"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "Третий квартал"))

	# Добавление новых серий
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Серия 1"), chart.type)

	# Теперь заполним данные серии
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```