---
title: Получить границы абзаца из презентаций в Python
linktitle: Абзац
type: docs
weight: 60
url: /ru/python-net/paragraph/
keywords:
- границы абзаца
- границы текстового фрагмента
- координата абзаца
- координата фрагмента
- размер абзаца
- размер текстового фрагмента
- текстовый кадр
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как получить границы абзаца и текстового фрагмента в Aspose.Slides for Python via .NET для оптимизации позиционирования текста в презентациях PowerPoint и OpenDocument."
---

## **Получение координат абзаца и фрагмента в TextFrame**
Используя Aspose.Slides for Python via .NET, разработчики теперь могут получить прямоугольные координаты Paragraph внутри коллекции абзацев TextFrame. Это также позволяет получить координаты Portion внутри коллекции фрагментов абзаца. В этой теме мы покажем на примере, как получить прямоугольные координаты абзаца вместе с позицией фрагмента внутри абзаца.

## **Получение прямоугольных координат абзаца**
Добавлен новый метод **GetRect()**. Он позволяет получить прямоугольник границ абзаца.
```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```


## **Получить размер абзаца и фрагмента внутри текстового кадра ячейки таблицы** ##

Чтобы получить размер и координаты [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) или [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) в текстовом кадре ячейки таблицы, вы можете использовать методы [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) и [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

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

**В каких единицах измеряются возвращаемые координаты абзаца и текстовых фрагментов?**

В пунктах, где 1 дюйм = 72 пункта. Это применимо ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если [wrapping](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) включён в [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), текст разбивается по ширине области, что меняет фактические границы абзаца.

**Можно ли надёжно сопоставить координаты абзаца с пикселями в экспортированном изображении?**

Да. Преобразуйте пункты в пиксели с помощью: pixels = points × (DPI / 72). Результат зависит от выбранного DPI при рендеринге/экспорте.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [effective paragraph formatting data structure](/slides/ru/python-net/shape-effective-properties/); он возвращает окончательные объединённые значения отступов, интервалов, переноса, RTL и др.