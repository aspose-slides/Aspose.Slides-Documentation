---
title: Настройка пузырьковых диаграмм в презентациях с помощью Python
linktitle: Пузырьковая диаграмма
type: docs
url: /ru/python-net/bubble-chart/
keywords:
- пузырьковая диаграмма
- размер пузыря
- масштабирование размера
- представление размера
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создавайте и настраивайте мощные пузырьковые диаграммы в PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, чтобы легко улучшать визуализацию данных."
---

## **Bubble Chart Size Scaling**
Aspose.Slides для Python через .NET предоставляет поддержку масштабирования размеров пузырьковой диаграммы. В Aspose.Slides для Python через .NET добавлены свойства **ChartSeries.bubble_size_scale** и **ChartSeriesGroup.bubble_size_scale**. Ниже приведён пример.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```


## **Represent Data as Bubble Chart Sizes**
В классы ChartSeries и ChartSeriesGroup добавлено свойство **bubble_size_representation**. **bubble_size_representation** определяет, как значения размеров пузырей отображаются на пузырьковой диаграмме. Возможные значения: **BubbleSizeRepresentationType.AREA** и **BubbleSizeRepresentationType.WIDTH**. Соответственно, добавлен перечисление **BubbleSizeRepresentationType**, позволяющее указать возможные способы представления данных в виде размеров пузырей. Ниже приведён пример кода.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

Да. Существует отдельный тип диаграммы «Bubble with 3‑D». Он применяет 3‑D стилизацию к пузырям, но не добавляет дополнительную ось; данные остаются X‑Y‑S (размер). Этот тип доступен в перечислении [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

**Is there a limit on the number of series and points in a bubble chart?**

На уровне API жёсткого ограничения нет; ограничения определяются производительностью и целевой версией PowerPoint. Рекомендуется держать количество точек в разумных пределах для читаемости и скорости рендеринга.

**How will export affect the appearance of a bubble chart (PDF, images)?**

Экспорт в поддерживаемые форматы сохраняет внешний вид диаграммы; рендеринг выполняется движком Aspose.Slides. Для растровых/векторных форматов применяются общие правила отрисовки графики диаграмм (разрешение, сглаживание), поэтому выбирайте достаточное DPI для печати.