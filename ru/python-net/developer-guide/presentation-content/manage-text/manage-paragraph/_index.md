---
title: Управление текстовыми абзацами PowerPoint в Python
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
- экспорт абзаца
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Освойте форматирование абзацев с Aspose.Slides для Python через .NET - оптимизируйте выравнивание, интервалы и стиль в презентациях PowerPoint и OpenDocument в Python, чтобы заинтересовать зрителей."
---
## **Введение**

Aspose.Slides предоставляет классы, необходимые для работы с текстом PowerPoint в Python.

* Aspose.Slides предоставляет класс [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) для создания объектов текстовых рамок. Объект `TextFrame` может содержать один или несколько абзацев (каждый абзац разделяется переводом строки).
* Aspose.Slides предоставляет класс [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) для создания объектов абзацев. Объект `Paragraph` может содержать одну или несколько частей текста.
* Aspose.Slides предоставляет класс [Portion](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/) для создания объектов частей текста и задания их свойств форматирования.

Объект `Paragraph` может обрабатывать текст с различными свойствами форматирования через вложенные объекты `Portion`.

## **Установка**

```bash
pip install aspose.slides
```

## **Добавление нескольких абзацев, содержащих несколько частей**

Эти шаги показывают, как добавить текстовую рамку, содержащую три абзаца, каждый с тремя частями:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на целевой слайд по его индексу.
1. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame], связанный с [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).
1. Создайте два объекта [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и добавьте их в коллекцию абзацев [TextFrame] (вместе с абзацем по умолчанию это даст три абзаца).
1. Для каждого абзаца создайте три объекта [Portion](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/) и добавьте их в коллекцию частей этого абзаца.
1. Установите текст для каждой части.
1. Примените желаемое форматирование к каждой части текста, используя свойства, предоставляемые [Portion](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/).
1. Сохраните изменённую презентацию.

Следующий код Python реализует эти шаги:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте объект класса Presentation для создания нового файла PPTX.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте прямоугольную AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Получите TextFrame AutoShape.
    text_frame = shape.text_frame

    # Создайте абзацы и части; форматирование будет применено ниже.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Сохраните PPTX на диск.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление маркерами абзацев**

Списки с маркерами помогают быстро и эффективно упорядочить и представить информацию. Абзацы с маркерами обычно легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите доступ к целевому слайду по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) формы.
1. Удалите абзац по умолчанию из [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Создайте первый абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/).
1. Установите тип маркера абзаца в `SYMBOL` и задайте символ маркера.
1. Установите текст абзаца.
1. Установите отступ маркера для абзаца.
1. Установите цвет маркера.
1. Установите размер (высоту) маркера.
1. Добавьте абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Добавьте второй абзац и повторите шаги 7–12.
1. Сохраните презентацию.

Этот код Python показывает, как добавить абзацы с маркерами:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Create a presentation instance.
with slides.Presentation() as presentation:

    # Access the first slide.
    slide = presentation.slides[0]

    # Add and access an AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Access the text frame of the created AutoShape.
    text_frame = shape.text_frame

    # Remove the default paragraph.
    text_frame.paragraphs.remove_at(0)

    # Create a paragraph.
    paragraph = slides.Paragraph()

    # Set the paragraph's bullet style and symbol.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Set the paragraph text.
    paragraph.text = "Welcome to Aspose.Slides"

    # Set the bullet indent.
    paragraph.paragraph_format.indent = 25

    # Set the bullet color.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # Set the bullet height.
    paragraph.paragraph_format.bullet.height = 100

    # Add the paragraph to the text frame.
    text_frame.paragraphs.add(paragraph)

    # Create the second paragraph.
    paragraph2 = slides.Paragraph()

    # Set the paragraph's bullet type and style.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # Set the paragraph text.
    paragraph2.text = "This is numbered bullet"

    # Set the bullet indent.
    paragraph2.paragraph_format.indent = 25

    # Set the bullet color.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # Set the bullet height.
    paragraph2.paragraph_format.bullet.height = 100

    # Add the paragraph to the text frame.
    text_frame.paragraphs.add(paragraph2)

    # Save the presentation as a PPTX file.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление маркерами‑изображениями**

Списки с маркерами помогают быстро и эффективно упорядочить и представить информацию. Маркеры‑изображения легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите доступ к целевому слайду по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) формы.
1. Удалите абзац по умолчанию из [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Создайте абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и задайте его текст.
1. Загрузите изображение и добавьте его в коллекцию изображений презентации как [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/).
1. Установите тип маркера в `PICTURE` и присвойте [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) маркеру.
1. Установите высоту маркера.
1. Добавьте новый абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Сохраните презентацию.

Этот код Python показывает, как добавить и управлять маркерами‑изображениями:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Загрузите изображение маркера.
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # Добавьте и получите AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Получите TextFrame созданного AutoShape.
    text_frame = auto_shape.text_frame

    # Удалите абзац по умолчанию.
    text_frame.paragraphs.remove_at(0)

    # Создайте новый абзац.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Установите тип маркера абзаца как Picture и назначьте изображение.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Установите высоту маркера.
    paragraph.paragraph_format.bullet.height = 100

    # Добавьте абзац в TextFrame.
    text_frame.paragraphs.add(paragraph)

    # Сохраните презентацию в файл PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Сохраните презентацию в файл PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Управление многоуровневыми маркерами**

Списки с маркерами помогают быстро и эффективно упорядочить и представить информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите доступ к целевому слайду по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) у [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).
1. Удалите абзац по умолчанию из [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Создайте первый абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и задайте его глубину 0.
1. Создайте второй абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и задайте его глубину 1.
1. Создайте третий абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и задайте его глубину 2.
1. Создайте четвёртый абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и задайте его глубину 3.
1. Добавьте новые абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Сохраните презентацию.

Следующий код Python показывает, как добавить и управлять многоуровневыми маркерами:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]
    
    # Добавьте AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Получите TextFrame созданного AutoShape.
    text_frame = shape.text_frame
    
    # Очистите абзац по умолчанию.
    text_frame.paragraphs.clear()

    # Добавьте первый абзац.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установите уровень маркера.
    paragraph1.paragraph_format.depth = 0

    # Добавьте второй абзац.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установите уровень маркера.
    paragraph2.paragraph_format.depth = 1

    # Добавьте третий абзац.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установите уровень маркера.
    paragraph3.paragraph_format.depth = 2

    # Добавьте четвертый абзац.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установите уровень маркера.
    paragraph4.paragraph_format.depth = 3

    # Добавьте абзацы в коллекцию.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Сохраните презентацию в файл PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление абзацами с пользовательскими нумерованными списками**

Класс [BulletFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/) предоставляет свойство `numbered_bullet_start_with` (и другие) для управления пользовательской нумерацией и форматированием абзацев.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите доступ к слайду, который будет содержать абзацы.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) формы.
1. Удалите абзац по умолчанию из [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Создайте первый [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и задайте `numbered_bullet_start_with` = 2.
1. Создайте второй [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и задайте `numbered_bullet_start_with` = 3.
1. Создайте третий [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) и задайте `numbered_bullet_start_with` = 7.
1. Добавьте абзацы в коллекцию [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Сохраните презентацию.

Следующий код Python демонстрирует, как добавить и управлять абзацами с пользовательской нумерацией и форматированием.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Добавьте и получите AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Получите TextFrame созданного AutoShape.
    text_frame = shape.text_frame

    # Удалите существующий абзац по умолчанию.
    text_frame.paragraphs.remove_at(0)

    # Создайте первый нумерованный элемент (начинается с 2, уровень глубины 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Создайте второй нумерованный элемент (начинается с 3, уровень глубины 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Создайте третий нумерованный элемент (начинается с 7, уровень глубины 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка отступа первой строки для абзаца**

Используйте свойство [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/) для управления отступом первой строки абзаца. Это свойство смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Для смещения всего абзаца используйте [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/margin_left/). Для смещения только первой строки — [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/).

В примере ниже создаются несколько абзацев и применяются разные значения `indent`, чтобы продемонстрировать влияние отступа первой строки на расположение текста.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) к форме и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/).
6. Добавьте абзацы в текстовую рамку.
7. Сохраните изменённую презентацию.

Этот код показывает, как установить отступ абзаца:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

## **Установка висячего отступа для абзаца**

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides такой эффект создаётся с помощью свойства [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/). Установите `indent` в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/margin_left/) определяет левую позицию тела абзаца, а [ParagraphFormat.indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `margin_left` и отрицательное значение `indent`.

Такое форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) к форме и удалите абзац по умолчанию.
5. Создайте абзацы и задайте каждому положительное значение [margin_left](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/margin_left/).
6. Установите отрицательное значение [indent](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/indent/) для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовую рамку.
8. Сохраните изменённую презентацию.

Этот код показывает, как установить висячий отступ для абзаца:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Висячий отступ абзацев](hanging_indent.png)

## **Управление форматом части в конце абзаца**

Когда необходимо контролировать стили «конца» абзаца (форматирование, применяемое после последней части текста), используйте свойство `end_paragraph_portion_format`. В примере ниже к концу второго абзаца применяется более крупный шрифт Times New Roman.

1. Создайте или откройте файл [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите целевой слайд по индексу.
1. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Используйте [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) формы и создайте два абзаца.
1. Создайте [PortionFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/) размером 48 pt Times New Roman и примените его как формат части в конце абзаца.
1. Присвойте его свойству `end_paragraph_portion_format` абзаца (применяется к окончанию второго абзаца).
1. Запишите изменённую презентацию в файл PPTX.

Этот код Python показывает, как задать формат части в конце второго абзаца:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# Удалите абзац по умолчанию.
	shape.text_frame.paragraphs.clear()

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Импорт HTML‑текста в абзацы**

Aspose.Slides предоставляет расширенную поддержку импорта HTML‑текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите доступ к целевому слайду по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) у [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).
1. Удалите абзац по умолчанию из [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Прочитайте исходный HTML‑файл.
1. Добавьте HTML‑содержимое в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).
1. Сохраните изменённую презентацию.

Следующий код Python реализует импорт HTML‑текста в абзацы.

```python
import aspose.slides as slides

# Создайте пустой объект Presentation.
with slides.Presentation() as presentation:

    # Получите первый слайд презентации.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Добавьте AutoShape для размещения HTML‑контента.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Очистите все абзацы в добавленном TextFrame.
    shape.text_frame.paragraphs.clear()

    # Загрузите HTML‑файл.
    with open("file.html", "rt") as html_stream:
        # Добавьте текст из HTML‑файла в TextFrame.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Сохраните презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Экспорт текста абзаца в HTML**

Aspose.Slides предоставляет расширенную поддержку экспорта текста в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и загрузите целевую презентацию.
1. Получите нужный слайд по его индексу.
1. Выберите форму, содержащую текст для экспорта.
1. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) формы.
1. Откройте поток файла для записи вывода HTML.
1. Укажите начальный индекс и экспортируйте требуемые абзацы.

Этот пример Python показывает, как экспортировать текст абзаца в HTML.

```python
import aspose.slides as slides

# Загрузите файл презентации.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Получите первый слайд презентации.
    slide = presentation.slides[0]

    # Индекс целевой формы.
    index = 0

    # Получите форму по индексу.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Запишите данные абзацев в HTML, указав начальный индекс абзаца и общее количество экспортируемых абзацев.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Сохранение абзаца как изображения**

В этом разделе рассматриваются два примера, демонстрирующие, как сохранить текстовый абзац, представленный классом [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/), в виде изображения. Оба примера включают получение изображения формы, содержащей абзац, с помощью методов `get_image` из класса [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/), вычисление границ абзаца внутри формы и экспорт его как растрового изображения. Такие подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, что у нас есть файл презентации sample.pptx с одним слайдом, где первая форма — это текстовое поле, содержащие три абзаца.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого извлекаем изображение формы с первого слайда презентации, затем вычисляем границы второго абзаца в текстовой рамке формы. Абзац затем перерисовывается на новом растровом изображении, которое сохраняется в формате PNG. Этот метод особенно полезен, когда необходимо сохранить конкретный абзац как отдельное изображение, сохранив точные размеры и форматирование текста.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Сохранить форму в памяти как битмап.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Создать битмап формы из памяти.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Вычислить границы второго абзаца.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Вычислить координаты и размер выходного изображения (минимальный размер — 1×1 пиксель).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Обрезать битмап формы, чтобы получить только битмап абзаца.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

**Пример 2**

Во втором примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Форма извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это позволяет получить более высокое разрешение при экспорте абзаца. Затем границы абзаца вычисляются с учётом масштаба. Масштабирование особенно полезно, когда требуется более детализированное изображение, например, для печатных материалов высокого качества.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Сохранить форму в памяти как битмап.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Создать битмап формы из памяти.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Вычислить границы второго абзаца.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Вычислить координаты и размер выходного изображения (минимальный размер — 1×1 пиксель).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Обрезать битмап формы, чтобы получить только битмап абзаца.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **Вопросы и ответы**

### Можно ли полностью отключить перенос строк внутри текстовой рамки?

Да. Используйте настройку переноса текста рамки ([wrap_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/wrap_text/)), чтобы выключить перенос, и строки не будут разбиваться по краям рамки.

### Как получить точные границы конкретного абзаца на слайде?

Вы можете получить прямоугольник ограничивающий абзац (и даже отдельную часть), чтобы знать его точное положение и размер на слайде.

### Где контролируется выравнивание абзаца (по‑левому, по‑правому, по‑центру, по‑ширине)?

[Alignment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/alignment/) — это настройка уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/); она применяется ко всему абзацу независимо от форматирования отдельных частей.

### Можно ли задать язык проверки орфографии только для части абзаца (например, для одного слова)?

Да. Язык задаётся на уровне части ([PortionFormat.language_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/language_id/)), поэтому в одном абзаце могут сосуществовать несколько языков.