---
title: Управление абзацами текста PowerPoint в Python
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- добавить текст
- добавить абзац
- управлять текстом
- управлять абзацем
- управлять маркером
- отступ абзаца
- висячий отступ
- маркер абзаца
- нумерованный список
- маркированный список
- свойства абзаца
- импорт HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспортировать абзац
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides for Python via .NET."
---
## **Обзор**

Aspose.Slides for Python via .NET представляет текст как иерархию текстовых рамок, абзацев и фрагментов:

* [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) представляет контейнер текста в фигуре и предоставляет доступ к коллекции её абзацев.
* [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) представляет один абзац в текстовой рамке и предоставляет доступ к её фрагментам и форматированию уровня абзаца.
* [Portion](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/) представляет текстовый фрагмент внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими фрагментами**

Следующие шаги создают текстовую рамку с тремя абзацами, каждый из которых содержит три фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите доступ к нужному слайду через его индекс.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) фигуры.
5. Используйте абзац по умолчанию и добавьте два дополнительных объекта [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) в текстовую рамку.
6. Добавьте достаточное количество объектов [Portion](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/) для каждого абзаца, чтобы они содержали по три фрагмента. Абзац по умолчанию уже содержит один пустой фрагмент.
7. Установите текст каждого фрагмента.
8. Примените форматирование уровня символов через [Portion.portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/portion_format/).
9. Сохраните изменённую презентацию.

Этот пример на Python реализует указанные шаги:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Создание маркированных и нумерованных списков**

### **Создание маркированного или нумерованного списка**

Маркеры и нумерация упрощают восприятие связанных элементов. В Aspose.Slides параметры списка задаются через [BulletFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите доступ к нужному слайду через его индекс.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на выбранный слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) фигуры.
5. Удалите абзац по умолчанию из текстовой рамки.
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) для символного маркера.
7. Установите [BulletFormat.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/type/) в значение [BulletType.SYMBOL](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bullettype/) и укажите символ маркера.
8. Установите текст абзаца, отступ, цвет маркера и высоту маркера.
9. Добавьте абзац в текстовую рамку.
10. Создайте второй абзац и установите [BulletFormat.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/type/) в значение [BulletType.NUMBERED](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bullettype/).
11. Настройте стиль нумерованного маркера и добавьте абзац в текстовую рамку.
12. Сохраните презентацию.

Этот пример на Python создаёт символный маркер и нумерованный маркер:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Использование рисунков в качестве маркеров**

Рисунковые маркеры позволяют использовать пользовательское изображение вместо символа или числа.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите доступ к нужному слайду через его индекс.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) и получите доступ к его [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
4. Удалите абзац по умолчанию из текстовой рамки.
5. Загрузите изображение маркера и добавьте его в коллекцию изображений презентации как [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/).
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и задайте его текст.
7. Установите [BulletFormat.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/type/) в значение [BulletType.PICTURE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bullettype/).
8. Назначьте изображение через [BulletFormat.picture](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/picture/) и установите высоту маркера.
9. Добавьте абзац в текстовую рамку.
10. Сохраните изменённую презентацию.

Этот пример на Python создаёт рисунковый маркер:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Создание многоуровневого списка**

Установите [ParagraphFormat.depth](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/depth/) для размещения абзацев на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) и очистите абзац по умолчанию из его текстовой рамки.
3. Создайте четыре абзаца и настройте их символы маркеров.
4. Установите их значения [ParagraphFormat.depth](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/depth/) в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на Python создаёт четырёхуровневый маркированный список:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Начало нумерации пунктов списка со пользовательских значений**

Используйте [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) для задания начального номера, отображаемого для нумерованного абзаца.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
2. Очистите абзац по умолчанию из текстовой рамки фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на Python задаёт пользовательский начальный номер для каждого абзаца:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление разметкой абзаца и свойствами окончания**

### **Установка отступа первой строки**

Используйте свойство [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/) для управления отступом первой строки абзаца. Это свойство смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/margin_left/) когда нужно переместить весь абзац. Используйте [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/) когда нужно переместить только первую строку.

Ниже приведён пример, создающий несколько абзацев и применяющий разные значения [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/) для демонстрации влияния отступа первой строки на разметку абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/).
6. Добавьте абзацы в текстовую рамку.
7. Сохраните изменённую презентацию.

Этот код демонстрирует, как установить отступ абзаца:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это разметка, при которой первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся с помощью свойства [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/). Установите `indent` в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/margin_left/) определяет левую позицию тела абзаца, а [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/) — позицию первой строки относительно этого поля. Для создания висячего отступа задайте положительное значение `margin_left` и отрицательное значение `indent`.

Это форматирование полезно для библиографий, ссылок, словарных статей и других абзацев, где переносы строк должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и задайте каждому положительное значение [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/margin_left/).
6. Установите отрицательное значение [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/) для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовую рамку.
8. Сохраните изменённую презентацию.

Этот код показывает, как задать висячий отступ для абзаца:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Висячий отступ абзацев](hanging_indent.png)

### **Установка свойств завершающего фрагмента абзаца**

Свойство [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) управляет форматированием символа окончания абзаца. В следующем примере задаётся размер шрифта и латинский шрифт для символа окончания второго абзаца:

1. Загрузите [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые фрагменты.
4. Создайте [PortionFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/) для символа окончания второго абзаца.
5. Установите [PortionFormat.font_height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/font_height/) и [PortionFormat.latin_font](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/latin_font/).
6. Присвойте формат свойству [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) и сохраните презентацию.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Подсчёт отображаемых строк**

Для правил абзаца, влияющих на автоматический перенос и пунктуацию в конце строк, см. [Control Line Breaking](/slides/ru/python-net/text-formatting/#control-line-breaking) и [Control Hanging Punctuation](/slides/ru/python-net/text-formatting/#control-hanging-punctuation).

Используйте [Paragraph.get_lines_count](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/get_lines_count/) для подсчёта строк, занимаемых абзацем после размещения текста, включая автоматический перенос. Это полезно при проверке длины текста и разметки в шаблонах презентаций.

Абзац — это один элемент в [TextFrame.paragraphs](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/paragraphs/), и он может занимать несколько отображаемых строк. Явный разрыв строки внутри абзаца приводит к новой строке без создания отдельного абзаца. Автоматический перенос создаёт строки на основе доступной ширины, не вставляя явные разрывы в текст. Поэтому подсчёт абзацев или символов разрыва строки не даёт количества отображаемых строк.

Следующий пример создаёт текстовую фигуру, считает её строки, сужает фигуру, а затем заменяет текст более короткой строкой. Перенос включён, а автоподгонка отключена, чтобы ширина фигуры контролировала перенос без автоматического уменьшения текста или изменения размеров фигуры. Размеры фигуры указаны в пунктах. Затем пример добавляет ещё один абзац и суммирует количество строк по всей текстовой рамке.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

С этими текстом и размерами сужение фигуры увеличивает количество строк, а замена текста на короткую строку уменьшает его. Точные подсчёты могут различаться в зависимости от доступных шрифтов и их замены, размера шрифта, полей, отступов, переноса и настроек автоподгонки. Используйте шрифты и параметры разметки, предназначенные для целевой среды, при проверке шаблона.

Само количество строк не определяет, выходит ли текст за пределы контейнера. Важны доступная высота, высота строк, межстрочный и абзацный интервал, а также поведение автоподгонки; даже одна строка может превышать доступную ширину при отключённом переносе.

## **Импорт и экспорт содержимого абзацев**

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphcollection/add_from_html/) для преобразования разметки HTML в абзацы и фрагменты в текстовой рамке.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите доступ к слайду и добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).
3. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) фигуры и очистите её абзац по умолчанию.
4. Прочитайте исходный файл HTML.
5. Передайте строку HTML в метод [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Сохраните изменённую презентацию.

Этот пример на Python импортирует HTML в текстовую рамку:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Экспорт текста абзаца в HTML**

Используйте [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphcollection/export_to_html/) для экспорта выбранного диапазона абзацев в виде HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите доступ к слайду и найдите [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/), содержащий текст.
3. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) фигуры.
4. Вызовите [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphcollection/export_to_html/) с указанием индекса начального абзаца и количества экспортируемых абзацев.
5. Запишите полученную строку HTML в файл.

Этот пример на Python экспортирует все абзацы из первой текстовой фигуры:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Отрисовка абзаца как изображения**

[Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) предоставляет метод `get_image` для прямой отрисовки отдельного абзаца. Метод возвращает объект [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/), который можно сохранить в файл или поток с помощью [IImage.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/save/). Нет необходимости отрисовывать содержащую фигуру или вручную обрезать bitmap.

Метод `get_image` может вернуть `None`, если абзац не найден в родительской коллекции, у него нет действительных границ для рендеринга или он не может быть отрисован. Проверьте результат перед сохранением и используйте полученное изображение как контекстный менеджер для освобождения ресурсов.

#### **Отрисовка абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример отрисовывает второй абзац в обычной текстовой фигуре в масштабе по умолчанию и сохраняет полученное изображение в формате PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

#### **Отрисовка абзаца в ячейке таблицы с масштабированием**

Передайте горизонтальный и вертикальный коэффициенты масштаба в `get_image`, чтобы управлять размером отрисованного абзаца. В следующем примере создаётся таблица, абзац в её первой ячейке отрисовывается в два раза шире и выше, чем по умолчанию, и результат сохраняется как PNG‑изображение:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Коэффициент масштаба `1` сохраняет соответствующую ось в её стандартном пиксельном размере. Например, `2` для обеих осей даёт изображение, ширина и высота которого примерно вдвое больше стандартных размеров, а значит, в четыре раза больше пикселей. Большие коэффициенты, как правило, дают более чёткий текст для увеличения или вывода в высоком разрешении, но также увеличивают потребление памяти и размер файла. Коэффициенты ниже `1` дают более небольшие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить соотношение сторон абзаца; разные горизонтальный и вертикальный коэффициенты растягивают вывод независимо.

Отрисовка всей фигуры с помощью [Shape.get_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_image/) остаётся полезной, когда вывод должен включать заливку, границу или другой визуальный контекст фигуры. Для изображения только абзаца используйте `Paragraph.get_image`.

## **Вопросы и ответы**

**Могу ли я полностью отключить перенос строк внутри текстовой рамки?**

Да. Установите [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/wrap_text/) в значение, отключающее перенос, чтобы строки не разрывались у краёв текстовой рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [Paragraph.get_rect](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/get_rect/) для получения прямоугольника, ограничивающего абзац. [Portion.get_rect](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/get_rect/) предоставляет границы отдельного фрагмента.

**Где задаётся выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/alignment/) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли установить язык проверки орфографии только для части абзаца?**

Да. Установите [PortionFormat.language_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/language_id/) для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.