---
title: Параграф
type: docs
weight: 60
url: /python-net/paragraph/
keywords: "Параграф, доля, координаты параграфа, координаты доли, презентация PowerPoint, Python, Aspose.Slides для Python via .NET"
description: "Параграф и доля в презентации PowerPoint на Python"
---

## **Получение координат параграфа и доли в TextFrame**
Используя Aspose.Slides для Python via .NET, разработчики теперь могут получать прямоугольные координаты для параграфа внутри коллекции параграфов TextFrame. Это также позволяет получать координаты доли внутри коллекции долей параграфа. В этой теме мы собираемся продемонстрировать на примере, как получить прямоугольные координаты для параграфа вместе с положением доли внутри параграфа.

## **Получение прямоугольных координат параграфа**
В метод была добавлена новая функция **GetRect()**. Она позволяет получить прямоугольные границы параграфа.

```py
import aspose.slides as slides

# Создаем объект Presentation, который представляет файл презентации
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Получение размера параграфа и доли внутри текстового фрейма ячейки таблицы** ##

Чтобы получить размер и координаты [Доли](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) или [Параграфа](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) в текстовом фрейме ячейки таблицы, вы можете использовать методы [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) и [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

Этот образец кода демонстрирует описанную операцию:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]

    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```