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
description: "Узнайте, как получить границы абзаца и текстового фрагмента в Aspose.Slides для Python через .NET, чтобы оптимизировать позиционирование текста в презентациях PowerPoint и OpenDocument."
---

## **Получить координаты абзаца и фрагмента в TextFrame**
С помощью Aspose.Slides для Python через .NET разработчики теперь могут получать прямоугольные координаты абзаца внутри коллекции абзацев TextFrame. Это также позволяет получать координаты фрагмента внутри коллекции фрагментов абзаца. В этом разделе мы продемонстрируем на примере, как получить прямоугольные координаты абзаца вместе с позицией фрагмента внутри абзаца.

## **Получить прямоугольные координаты абзаца**
Новый метод **GetRect()** был добавлен. Он позволяет получить прямоугольник границ абзаца.

```py
import aspose.slides as slides

# Создать объект Presentation, представляющий файл презентации
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Получить размер абзаца и фрагмента внутри текстового кадра ячейки таблицы** ##

Чтобы получить размер и координаты [Фрагмента](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) или [Абзаца](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) в текстовом кадре ячейки таблицы, можно воспользоваться методами [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) и [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

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

В пунктах, где 1 дюйм = 72 пункта. Это касается всех координат и размеров на слайде.

**Влияет ли перенос строк на границы абзаца?**

Да. Если включён [перенос](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) в [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), текст разбивается для соответствия ширине области, что изменяет фактические границы абзаца.

**Можно ли надежно сопоставить координаты абзаца пикселям в экспортированном изображении?**

Да. Преобразуйте пункты в пиксели по формуле: пиксели = пункты × (DPI / 72). Результат зависит от выбранного DPI при рендеринге/экспорте.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [структуру данных эффективного форматирования абзаца](/slides/ru/python-net/shape-effective-properties/); она возвращает окончательные консолидированные значения отступов, интервалов, переноса, RTL и прочего.