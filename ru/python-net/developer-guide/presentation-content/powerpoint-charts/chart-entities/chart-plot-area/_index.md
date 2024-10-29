---
title: Область построения графика
type: docs
url: /ru/python-net/chart-plot-area/
keywords: "Область построения графика презентации PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Получить ширину, высоту области построения графика. Установить режим компоновки. Презентация PowerPoint на Python"
---

## **Получить ширину, высоту области построения графика**
Aspose.Slides для Python через .NET предоставляет простой API для.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите доступ к первому слайду.
1. Добавьте график с данными по умолчанию.
1. Вызовите метод IChart.ValidateChartLayout() перед получением актуальных значений.
1. Получите актуальное положение X (влево) элемента графика относительно верхнего левого угла графика.
1. Получите актуальную верхнюю часть элемента графика относительно верхнего левого угла графика.
1. Получите актуальную ширину элемента графика.
1. Получите актуальную высоту элемента графика.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Сохранить презентацию с графиком
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить режим компоновки области построения графика**
Aspose.Slides для Python через .NET предоставляет простой API для установки режима компоновки области построения графика. Свойство **LayoutTargetType** было добавлено в классы **ChartPlotArea** и **IChartPlotArea**. Если компоновка области построения определяется вручную, это свойство указывает, следует ли располагать область построения внутри (не включая оси и метки осей) или снаружи (включая оси и метки осей). Существует два возможных значения, определенных в перечислении **LayoutTargetType**.

- **LayoutTargetType.Inner** - указывает, что размер области построения должен определять размер области построения, не включая метки и метки осей.
- **LayoutTargetType.Outer** - указывает, что размер области построения должен определять размер области построения, меток и меток осей.

Пример кода приведен ниже.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```