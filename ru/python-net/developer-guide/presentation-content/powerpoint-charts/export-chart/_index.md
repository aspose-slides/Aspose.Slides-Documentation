---
title: Экспортировать график
type: docs
weight: 90
url: /ru/python-net/export-chart/
keywords: "График, изображение графика, извлечение изображения графика, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Получить изображения графиков в презентации PowerPoint на Python"
---

## **Получить изображение графика**
Aspose.Slides для Python через .NET предоставляет поддержку извлечения изображения конкретного графика. Приведен пример ниже.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    with chart.get_image() as img:
        img.save("image.png", slides.ImageFormat.PNG)
```