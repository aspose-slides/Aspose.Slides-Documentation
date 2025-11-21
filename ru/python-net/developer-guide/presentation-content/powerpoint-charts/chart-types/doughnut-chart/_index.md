---
title: Настройка кольцевых диаграмм в презентациях с Python
linktitle: Кольцевая диаграмма
type: docs
weight: 30
url: /ru/python-net/doughnut-chart/
keywords:
- кольцевая диаграмма
- центральный зазор
- размер отверстия
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и настраивать кольцевые диаграммы в Aspose.Slides для Python через .NET, поддерживая форматы PowerPoint и OpenDocument для динамических презентаций."
---

## **Указать центральный зазор в кольцевой диаграмме**
Чтобы задать размер отверстия в кольцевой диаграмме, выполните следующие действия:

- Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Добавить кольцевую диаграмму на слайд.
- Задать размер отверстия в кольцевой диаграмме.
- Записать презентацию на диск.

В приведённом ниже примере мы задали размер отверстия в кольцевой диаграмме.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создать экземпляр класса Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Сохранить презентацию на диск
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли создать многоуровневую кольцевую диаграмму с несколькими кольцами?**

Да. Добавьте несколько серий в одну кольцевую диаграмму — каждая серия становится отдельным кольцом. Порядок колец определяется порядком серий в коллекции.

**Поддерживается ли «взрывная» кольцевая диаграмма (отдельные срезы)?**

Да. Существует тип диаграммы Exploded Doughnut [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) и свойство explosion у точек данных; можно отделять отдельные срезы.

**Как получить изображение кольцевой диаграммы (PNG/SVG) для отчёта?**

Диаграмма является фигурой; её можно отрендерить в [растровое изображение](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) или экспортировать в [SVG‑изображение](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/).