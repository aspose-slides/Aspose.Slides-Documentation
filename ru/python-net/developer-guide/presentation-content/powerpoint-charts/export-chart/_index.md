---
title: Экспортируйте диаграммы из презентаций на Python
linktitle: Экспорт диаграммы
type: docs
weight: 90
url: /ru/python-net/export-chart/
keywords:
- диаграмма
- диаграмма в изображение
- диаграмма как изображение
- извлечь изображение диаграммы
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как экспортировать диаграммы из презентаций с помощью Aspose.Slides for Python via .NET с поддержкой форматов PPT, PPTX и ODP и упростить подготовку отчетов в любом рабочем процессе."
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