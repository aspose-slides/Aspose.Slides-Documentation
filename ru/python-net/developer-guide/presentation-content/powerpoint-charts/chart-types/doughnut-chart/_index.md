---
title: Настройте кольцевые графики в презентациях с помощью Python
linktitle: Кольцевой график
type: docs
weight: 30
url: /ru/python-net/doughnut-chart/
keywords:
  - кольцевой график
  - центральный зазор
  - размер отверстия
  - PowerPoint
  - OpenDocument
  - презентация
  - Python
  - Aspose.Slides
description: "Узнайте, как создавать и настраивать кольцевые графики в Aspose.Slides for Python via .NET, поддерживая форматы PowerPoint и OpenDocument для динамических презентаций."
---

## **Укажите размер отверстия в кольцевой диаграмме**
Для того чтобы указать размер отверстия в кольцевой диаграмме, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Добавьте кольцевую диаграмму на слайд.
- Укажите размер отверстия в кольцевой диаграмме.
- Сохраните презентацию на диск.

В приведенном ниже примере мы задали размер отверстия в кольцевой диаграмме.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создайте экземпляр класса Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Сохраните презентацию на диск
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```