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
  - управление текстом
  - управление абзацем
  - управление маркером
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
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides for Python via .NET."
---
## **Обзор**

Aspose.Slides for Python via .NET представляет текст как иерархию текстовых фреймов, абзацев и фрагментов:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) представляет контейнер текста в фигуре и предоставляет доступ к её коллекции абзацев.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) представляет один абзац в текстовом фрейме и предоставляет доступ к его фрагментам и форматированию уровня абзаца.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) представляет фрагмент текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

Создавайте абзацы в текстовом фрейме фигуры и используйте фрагменты для форматирования отдельных текстовых запусков. В этом разделе показано, как комбинировать несколько фрагментов внутри каждого абзаца и применять разные цвета, размеры шрифтов и стили.

### **Создание абзацев с несколькими фрагментами**

Следующий пример на Python создает три абзаца, каждый из которых содержит три текстовых запуска в своей коллекции [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). Он переиспользует абзац по умолчанию и его пустой фрагмент, затем добавляет оставшиеся абзацы и фрагменты. Форматирование применяется через [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): первый фрагмент в каждом абзаце красный, полужирный и 15 пунктов; второй — синий, курсив и 18 пунктов. Третий фрагмент сохраняет форматирование по умолчанию:

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

Организуйте текст абзацев в списки с символами, цифрами или пользовательскими изображениями. Примеры в этом разделе охватывают форматирование маркеров, многоуровневые списки и пользовательские начальные номера.

### **Создание маркированного или нумерованного списка**

Марки и нумерация упрощают восприятие связанных элементов. В Aspose.Slides параметры списка определяются через [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Этот пример на Python добавляет символный маркер и нумерованный элемент в один и тот же текстовый фрейм. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) выбирает тип маркера, а [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) задаёт символ и [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) выбирает стиль нумерации. Оба элемента используют черные маркеры высотой 100 % и отступ абзаца 25 пунктов:

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

### **Использование маркеров‑картинок**

Маркер‑картинка позволяет использовать собственное изображение вместо символа или цифры.

Пример требует файл `bullets.png` в рабочем каталоге. Этот пример на Python добавляет изображение в коллекцию изображений презентации как [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) и использует его в качестве маркера абзаца. Он задаёт [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) для использования маркера‑картинки и назначает изображение через [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) устанавливается в 100 % для масштабирования маркера относительно текста абзаца:

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

Установите [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) для размещения абзацев на разных уровнях списка. Верхний уровень имеет глубину `0`.

Этот пример на Python присваивает значения [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) от 0 до 3 четырем абзацам, создавая иерархию внутри одного текстового фрейма. Каждый абзац использует символный маркер, при этом [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) чередуется между круглым маркером и дефисом для различения соседних уровней:

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

### **Задание пользовательских начальных значений нумерации**

Используйте [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) для установки начального номера, отображаемого для нумерованного абзаца.

Этот пример на Python задаёт [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) для нумерации трёх абзацев и присваивает [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) значения 2, 3 и 7. Начальное значение конфигурируется отдельно для каждого абзаца, позволяя пропускать номера:

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

## **Управление расположением абзаца и завершающими свойствами**

Регулируйте поля и отступы абзаца для контроля позиции первой строки и перенесённых строк. Вы также можете форматировать символ конца абзаца отдельно от видимых текстовых фрагментов.

### **Установка отступа первой строки**

Используйте свойство [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) для управления отступом первой строки абзаца. Это свойство смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, в то время как остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) когда необходимо переместить весь абзац. Используйте [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) когда нужно сместить только первую строку.

В следующем примере три абзаца получают одинаковое [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) = 20 пунктов и значения [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) = 0, 20 и 40 пунктов. Первые строки начинают с постепенно больших смещений, а перенесённые строки сохраняют одинаковое левое поле:

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

Висячий отступ — это макет абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides такой эффект создаётся с помощью свойства [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Установите `indent` в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) задаёт левую позицию тела абзаца, а [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) определяет позицию первой строки относительно этого поля. Чтобы получить висячий отступ, задайте положительное значение `margin_left` и отрицательное значение `indent`.

Такое форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где перенесённые строки должны выравниваться по телу абзаца, а не по первому символу первой строки.

В следующем примере на Python сочетает значения [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) = 40 и 60 пунктов с [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) = -20 и -30 пунктов. В каждом абзаце первая строка начинается левее перенесённых строк; второй абзац имеет более глубокий висячий отступ:

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

Свойство [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) управляет форматированием символа конца абзаца. В примере загружается `Test.pptx`, который должен содержать минимум один слайд, и создаётся [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) с [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) = 48 пунктов и [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) = Times New Roman. Этот формат назначается символу конца второго абзаца, оставляя видимые текстовые фрагменты без изменений:

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

## **Подсчёт отрисованных строк**

Для правил абзаца, влияющих на автоматический перенос и пунктуацию в конце строк, см. [Control Line Breaking](/slides/ru/python-net/text-formatting/#control-line-breaking) и [Control Hanging Punctuation](/slides/ru/python-net/text-formatting/#control-hanging-punctuation).

Используйте [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) для подсчёта строк, занимаемых абзацем после компоновки текста, включая автоматический перенос. Это полезно при проверке длины текста и макета в шаблонах презентаций.

Абзац — это один элемент в [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), и он может занимать несколько отрисованных строк. Явный разрыв строки внутри абзаца принудительно создаёт новую строку без создания нового абзаца. Автоматический перенос образует строки исходя из доступной ширины без вставки явных разрывов в текст. Поэтому подсчёт абзацев или символов разрыва строк не даёт количества отрисованных строк.

В следующем примере создаётся текстовая фигура, считается количество её строк, затем фигура сужается, и текст заменяется более короткой строкой. Пример включает [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) и отключает [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/), чтобы ширина фигуры контролировала перенос без автоматического сжатия текста или изменения размеров фигуры. Каждый измерение использует [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Размеры фигуры указаны в пунктах. В конце примера добавляется ещё один абзац и суммируются количества строк по всему текстовому фрейму.

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

При данных тексте и размерах сужение фигуры увеличивает количество строк, а замена текста короткой строкой уменьшает его. Точные значения могут различаться в зависимости от доступных шрифтов и их подстановки, размера шрифта, полей, отступов, переноса и настроек автоподгонки. При проверке шаблона используйте шрифты и параметры макета, предназначенные для целевой среды.

Само количество строк не определяет, выходит ли текст за пределы контейнера. Важны также доступная высота, высота строк, интервалы между абзацами и строками и поведение автоподгонки; даже одна строка может превышать ширину при отключенном переносе.

## **Импорт и экспорт содержимого абзацев**

Используйте HTML для импортирования текста в презентацию или экспорта существующих абзацев для использования за её пределами. В этом разделе также показано, как отрисовывать отдельные абзацы как изображения, включая абзацы в ячейках таблиц.

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) для преобразования HTML‑разметки в абзацы и фрагменты внутри текстового фрейма.

Этот пример на Python читает HTML из `file.html` в рабочем каталоге и передаёт разметку в [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Он очищает абзац по умолчанию в текстовом фрейме, чтобы фрейм содержал только импортированный контент. Прямоугольная фигура оставляет 10‑пунктовый отступ со всех сторон слайда:

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

Используйте [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) для экспорта выбранного диапазона абзацев в HTML. При повторном использовании текста презентации на веб‑сайте вы можете захотеть сохранить локальное выделение без переноса шрифтов, размеров или стилей текстовых коробок презентации. Установите [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) для управления тем, насколько глубоко экспортер следует наследованию форматирования.

Скачайте [пример презентации](text-inheritance.pptx) и разместите её в рабочем каталоге приложения. На первом слайде находится одна текстовая фигура с текстом «Inherited text; explicit red 18pt». Ввод намеренно использует несколько уровней форматирования:

- Стиль текста по умолчанию презентации задаёт Calibri размером 28 pt.
- Стиль первого уровня текстового фрейма задаёт синий текст и курсив.
- Абзац явно задаёт полужирный текст.
- Второй фрагмент, «explicit red 18pt», явно задаёт красный цвет и размер 18 pt.

Следующий полностью рабочий пример экспортирует те же абзацы трижды. Он передаёт [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) в метод экспорта и сохраняет каждый результат как отдельный UTF‑8 HTML‑файл:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

Сгенерированный HTML содержит следующий CSS для первого фрагмента, «Inherited text; ». Таблица перечисляет соответствующие объявления; остальные сгенерированные свойства опущены для ясности.

| Вывод | Соответствующий CSS для первого фрагмента | Внешний вид |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Синий, полужирный, курсивный текст размером 28 pt в Calibri, если этот шрифт доступен. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Синий, полужирный, курсивный текст; шрифт и размер задаются страницей или браузером. |
| `ParagraphOnly.html` | `font-weight:bold` | Полужирный текст; шрифт, размер, цвет и курсив задаются страницей или браузером. |

Второй фрагмент сохраняет `color:#ff0000`, `font-size:18pt` и `font-weight:bold` во всех трёх выводах. Он также сохраняет курсив в `ALL` и `TEXT_BOX`, но не в `PARAGRAPH_ONLY`. Ограничение наследования поэтому не удаляет явно заданное форматирование абзаца или фрагмента.

Откройте файлы в одном браузере для их сравнения. В двух ограниченных режимах опущенные свойства CSS разрешаются стилями целевой страницы или настройками браузера, поэтому итоговый внешний вид зависит от места использования HTML.

### **Отрисовка абзаца как изображения**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) отрисовывает отдельный абзац напрямую и возвращает [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Не требуется отрисовывать содержащую фигуру или вручную обрезать битмап.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) может вернуть `None`, если абзац не найден в родительской коллекции, не имеет допустимых границ отрисовки или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отрисовка абзаца в масштабе по умолчанию**

Пример использует `sample.pptx`, презентацию с одним слайдом, где первая фигура — текстовый блок, содержащий три абзаца.

![Текстовый блок с тремя абзацами](paragraph_to_image_input.png)

Следующий пример выбирает второй абзац с индексом 1 и вызывает [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) без параметров масштаба. Он проверяет, что фигура содержит требуемый абзац и что отрисовка вернула изображение, прежде чем вызвать [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) для сохранения в формате PNG. Контекстный менеджер освобождает ресурсы изображения после использования.

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

Используйте перегрузку [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) с параметрами `scale_x` и `scale_y` для задания горизонтального и вертикального коэффициентов масштабирования. Следующий пример создаёт таблицу, отрисовывает абзац в её первой ячейке с двойной шириной и высотой относительно значения по умолчанию и сохраняет результат как PNG‑изображение.

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

Коэффициент масштаба `1` сохраняет размер оси по умолчанию в пикселях. Например, `2` для обеих осей даёт изображение, ширина и высота которого примерно вдвое превышают стандартные размеры, что приводит к четырём раз большему числу пикселей. Большие коэффициенты обычно дают более резкий текст для увеличения или вывода высокого разрешения, но они также увеличивают расход памяти и размер файла. Коэффициенты ниже `1` дают более мелкие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить пропорцию абзаца; разные горизонтальный и вертикальный коэффициенты растягивают вывод независимо.

Отрисовка всей фигуры с помощью [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) остаётся полезной, когда требуется включить заливку, границу или другой визуальный контекст фигуры. Для изображения только абзаца используйте [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **ЧаВо**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Установите [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) в значение, отключающее перенос, чтобы строки не разрывались у краёв текстового фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) для получения ограничивающего прямоугольника абзаца. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) предоставляет границы отдельного фрагмента.

**Где контролируется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) — это параметр уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

Чтобы вертикально выровнять фрагменты разных размеров шрифтов в каждой строке, см. [Align Fonts Within a Line](/slides/ru/python-net/text-formatting/#align-fonts-within-a-line).

**Можно ли задать язык проверки орфографии только для части абзаца?**

Да. Установите [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.