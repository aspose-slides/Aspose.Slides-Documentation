---
title: Получить границы абзаца из презентаций на Python
linktitle: Абзац
type: docs
weight: 60
url: /ru/python-net/paragraph/
keywords:
- границы абзаца
- границы части текста
- координата абзаца
- координата части
- размер абзаца
- размер части текста
- текстовый фрейм
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как получить границы абзаца и части текста в Aspose.Slides для Python via .NET, чтобы оптимизировать позиционирование текста в презентациях PowerPoint и OpenDocument."
---

## **Получить координаты абзаца и части в TextFrame**
С помощью Aspose.Slides для Python via .NET разработчики теперь могут получать прямоугольные координаты Paragraph внутри коллекции абзацев TextFrame. Также можно получить координаты Portion внутри коллекции частей абзаца. В этой статье мы покажем на примере, как получить прямоугольные координаты абзаца вместе с положением части внутри него.

## **Получить прямоугольные координаты абзаца**
Добавлен новый метод **GetRect()**. Он позволяет получить прямоугольник границ абзаца.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Получить размер абзаца и части внутри текстового фрейма ячейки таблицы** ##

Чтобы получить размер и координаты [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) или [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) в текстовом фрейме ячейки таблицы, можно использовать методы [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) и [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

Этот пример кода демонстрирует описанную операцию:

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

## **FAQ**

**В каких единицах измеряются координаты, возвращаемые для абзаца и его частей?**

В пунктах, где 1 дюйм = 72 пункта. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос строк на границы абзаца?**

Да. Если [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) включён в [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), текст переносится для соответствия ширине области, что изменяет фактические границы абзаца.

**Можно ли надёжно сопоставить координаты абзаца с пикселями в экспортированном изображении?**

Да. Преобразуйте пункты в пиксели по формуле: пиксели = пункты × (DPI / 72). Результат зависит от выбранного DPI при рендеринге/экспорте.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [структуру данных эффективных параметров форматирования абзаца](/slides/ru/python-net/shape-effective-properties/); она возвращает окончательные консолидированные значения отступов, интервалов, переноса, RTL и др.