---
title: Настройка областей построения диаграмм в презентациях на Python
linktitle: Область построения
type: docs
url: /ru/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-plot-area/
keywords:
- диаграмма
- область построения
- ширина области построения
- высота области построения
- размер области построения
- режим компоновки
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как настраивать области построения диаграмм в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Легко улучшайте визуальное оформление своих слайдов."
---

## **Получить ширину и высоту области построения диаграммы**
Aspose.Slides for Python via .NET предоставляет простой API для .

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите первый слайд.
3. Добавьте диаграмму с данными по умолчанию.
4. Вызовите метод IChart.ValidateChartLayout() перед получением фактических значений.
5. Получает фактическое положение по оси X (слева) элемента диаграммы относительно левого верхнего угла диаграммы.
6. Получает фактическую верхнюю позицию элемента диаграммы относительно левого верхнего угла диаграммы.
7. Получает фактическую ширину элемента диаграммы.
8. Получает фактическую высоту элемента диаграммы.

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
	
	# Save presentation with chart
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить режим компоновки области построения диаграммы**
Aspose.Slides for Python via .NET предоставляет простой API для установки режима компоновки области построения диаграммы. Свойство **LayoutTargetType** было добавлено в классы **ChartPlotArea** и **IChartPlotArea**. Если компоновка области построения задаётся вручную, это свойство указывает, следует ли размещать область построения по её внутренней части (не включая оси и подписи осей) или по внешней части (включая оси и подписи осей). Существует два возможных значения, определённых в перечислении **LayoutTargetType**.

- **LayoutTargetType.Inner** — указывает, что размер области построения определяет размер области построения без отметок делений и подписей осей.
- **LayoutTargetType.Outer** — указывает, что размер области построения определяет размер области построения, включая отметки делений и подписи осей.

Sample code is given below.

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

## **FAQ**

**В каких единицах возвращаются actual_x, actual_y, actual_width и actual_height?**

В пунктах; 1 дюйм = 72 пункта. Это единицы координат Aspose.Slides.

**Чем отличается Область построения от Области диаграммы по содержимому?**

Область построения — это область рисунка данных (серии, линии сетки, линии тренда и т.д.); Область диаграммы включает окружающие элементы (заголовок, легенду и т.д.). В 3D‑диаграммах Область построения также включает стены/пол и оси.

**Как интерпретируются X, Y, Width и Height области построения при ручной компоновке?**

Это дробные значения (0–1) от общего размера диаграммы; в этом режиме автоматическое позиционирование отключено, и используются заданные вами дроби.

**Почему позиция области построения изменилась после добавления/перемещения легенды?**

Легенда располагается в области диаграммы вне Области построения, но влияет на компоновку и доступное пространство, поэтому Область построения может сместиться, когда включено автоматическое позиционирование. (Это стандартное поведение диаграмм PowerPoint.)