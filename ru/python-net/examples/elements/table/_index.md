---
title: Таблица
type: docs
weight: 120
url: /ru/python-net/examples/elements/table/
keywords:
- таблица
- добавить таблицу
- доступ к таблице
- удалить таблицу
- объединить ячейки
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создавайте и форматируйте таблицы в Python с помощью Aspose.Slides: вставляйте данные, объединяйте ячейки, оформляйте границы, выравнивайте содержимое и импортируйте/экспортируйте в PPT, PPTX и ODP."
---
Примеры добавления таблиц, доступа к ним, удаления их и объединения ячеек с использованием **Aspose.Slides for Python via .NET**.

## **Добавить таблицу**

Создайте простую таблицу с двумя строками и двумя столбцами.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Определите ширины столбцов и высоты строк.
        widths = [80, 80]
        heights = [30, 30]

        # Добавьте форму таблицы на слайд.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить доступ к таблице**

Получить первую форму таблицы на слайде.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Доступ к первой таблице на слайде.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Удалить таблицу**

Удалить таблицу со слайда.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура является таблицей.
        table = slide.shapes[0]

        # Удалить таблицу со слайда.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Объединить ячейки таблицы**

Объединить соседние ячейки таблицы в одну ячейку.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура является таблицей.
        table = slide.shapes[0]

        # Объединить ячейки.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```