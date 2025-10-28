---
title: Настройка диаграмм пончик в презентациях с помощью Python
linktitle: Диаграмма пончик
type: docs
weight: 30
url: /ru/python-net/doughnut-chart/
keywords:
- диаграмма пончик
- центральный зазор
- размер отверстия
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и настраивать диаграммы пончик в Aspose.Slides для Python через .NET, поддерживая форматы PowerPoint и OpenDocument для динамических презентаций."
---

## **Указание центрального зазора в диаграмме пончик**
Чтобы задать размер отверстия в диаграмме пончик, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- Добавьте диаграмму пончик на слайд.
- Укажите размер отверстия в диаграмме пончик.
- Сохраните презентацию на диск.

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

## **Часто задаваемые вопросы**

**Можно ли создать многоуровневую диаграмму пончик с несколькими кольцами?**

Да. Добавьте несколько рядов к одной диаграмме пончик — каждый ряд становится отдельным кольцом. Порядок колец определяется порядком рядов в коллекции.

**Поддерживается ли «взрывная» диаграмма пончик (отдельные сектора)?**

Да. Существует тип диаграммы Exploded Doughnut ([тип диаграммы](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)) и свойство взрыва у точек данных; вы можете отделять отдельные сектора.

**Как получить изображение диаграммы пончик (PNG/SVG) для отчёта?**

Диаграмма — это shape; её можно отрисовать в [растровое изображение](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) или экспортировать диаграмму в [SVG‑изображение](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/).