---
title: Настройка областей построения диаграмм в презентациях на Python
linktitle: Область построения
type: docs
url: /ru/python-net/chart-plot-area/
keywords:
- диаграмма
- область построения
- ширина области построения
- высота области построения
- размер области построения
- режим расположения
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как настроить области построения диаграмм в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Улучшайте визуальное оформление слайдов без усилий."
---

## **Получить ширину и высоту области построения диаграммы**
Aspose.Slides для Python через .NET предоставляет простой API для .

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Вызовите метод IChart.ValidateChartLayout() перед получением фактических значений.
5. Получает фактическое положение X (слева) элемента диаграммы относительно левого верхнего угла диаграммы.
6. Получает фактическую позицию Y (верх) элемента диаграммы относительно левого верхнего угла диаграммы.
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
	
	# Сохранить презентацию с диаграммой
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Установить режим расположения области построения диаграммы**
Aspose.Slides для Python через .NET предоставляет простой API для установки режима расположения области построения диаграммы. Свойство **LayoutTargetType** было добавлено в классы **ChartPlotArea** и **IChartPlotArea**. Если расположение области построения задаётся вручную, это свойство указывает, следует ли располагать область построения внутри (не включая оси и подписи осей) или снаружи (включая оси и подписи осей). Существует два возможных значения, определённых в перечислении **LayoutTargetType**.

- **LayoutTargetType.Inner** — указывает, что размер области построения определяется без учёта делений и подписей осей.
- **LayoutTargetType.Outer** — указывает, что размер области построения определяется вместе с делениями и подписями осей.

Пример кода ниже.

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

**Чем отличается область построения от области диаграммы по содержимому?**

Область построения — это регион рисования данных (серии, сетка, линии тренда и т.д.); область диаграммы включает окружающие элементы (заголовок, легенду и т.п.). В 3‑мерных диаграммах область построения также включает стены/пол и оси.

**Как интерпретируются X, Y, ширина и высота области построения, когда расположение задано вручную?**

Это доли (0–1) от общего размера диаграммы; в этом режиме автоматическое позиционирование отключено, и используются указанные вами доли.

**Почему позиция области построения изменилась после добавления/перемещения легенды?**

Легенда находится в области диаграммы вне области построения, но влияет на расположение и доступное пространство, поэтому при включённом автоматическом позиционировании область построения может сместиться. (Это стандартное поведение диаграмм PowerPoint.)