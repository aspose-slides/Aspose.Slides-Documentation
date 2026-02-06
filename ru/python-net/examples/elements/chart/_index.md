---
title: Диаграмма
type: docs
weight: 60
url: /ru/python-net/examples/elements/chart/
keywords:
- диаграмма
- добавить диаграмму
- доступ к диаграмме
- удалить диаграмму
- обновить диаграмму
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы в Python с помощью Aspose.Slides: добавляйте данные, форматируйте серии, оси и подписи, меняйте типы и экспортируйте — работает с PPT, PPTX и ODP."
---
Примеры добавления, доступа, удаления и обновления различных типов диаграмм с помощью **Aspose.Slides for Python via .NET**. Ниже приведённые фрагменты демонстрируют базовые операции с диаграммами.

## **Add a Chart**
Этот метод добавляет простую площадную диаграмму на первый слайд.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Добавить простую столбчатую диаграмму на первый слайд.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Chart**
Следующий код извлекает диаграмму из коллекции фигур.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Доступ к первой диаграмме на слайде.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Remove a Chart**
Следующий код удаляет диаграмму со слайда.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура — это диаграмма.
        chart = slide.shapes[0]

        # Удалить диаграмму.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Update Chart Data**
Можно изменить свойства диаграммы, такие как заголовок.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура — это диаграмма.
        chart = slide.shapes[0]

        # Изменить заголовок диаграммы.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```