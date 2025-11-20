---
title: Управление абзацами текста PowerPoint в Python
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/python-net/manage-paragraph/
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
- экспортировать абзац
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Освойте форматирование абзацев с помощью Aspose.Slides для Python через .NET — оптимизируйте выравнивание, интервал и стиль в презентациях PowerPoint и OpenDocument в Python, чтобы привлечь внимание зрителей."
---

## **Обзор**

Aspose.Slides предоставляет классы, необходимые для работы с текстом PowerPoint в Python.

* Aspose.Slides предоставляет класс [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) для создания объектов текстовых фреймов. Объект `TextFrame` может содержать один или несколько абзацев (каждый абзац разделяется возвратом каретки).
* Aspose.Slides предоставляет класс [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) для создания объектов абзацев. Объект `Paragraph` может содержать один или несколько фрагментов текста.
* Aspose.Slides предоставляет класс [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) для создания объектов фрагментов текста и указания их свойств форматирования.

Объект `Paragraph` может обрабатывать текст с различными свойствами форматирования через свои вложенные объекты `Portion`.

## **Добавление нескольких абзацев, содержащих несколько частей**

Эти шаги показывают, как добавить текстовый фрейм, содержащий три абзаца, каждый из которых имеет три части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на целевой слайд по его индексу.
1. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), связанный с [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Создайте два объекта [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и добавьте их в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) (вместе со стандартным абзацем это даст три абзаца).
1. Для каждого абзаца создайте три объекта [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) и добавьте их в коллекцию фрагментов этого абзаца.
1. Установите текст для каждого фрагмента.
1. Примените необходимое форматирование к каждому фрагменту текста, используя свойства, доступные в [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Сохраните изменённую презентацию.

Следующий код Python реализует эти шаги:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать объект класса Presentation для создания нового файла PPTX.
with slides.Presentation() as presentation:

    # Доступ к первому слайду.
    slide = presentation.slides[0]

    # Добавить прямоугольный AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Получить TextFrame AutoShape.
    text_frame = shape.text_frame

    # Создать абзацы и части; форматирование будет применено ниже.
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
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Сохранить PPTX на диск.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление маркированными абзацами**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Абзацы с маркерами часто легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на целевой слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) формы.
1. Удалите стандартный абзац из [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Создайте первый абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Установите тип маркера абзаца в `SYMBOL` и задайте символ маркера.
1. Установите текст абзаца.
1. Установите отступ маркера для абзаца.
1. Установите цвет маркера.
1. Установите размер (высоту) маркера.
1. Добавьте абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Добавьте второй абзац и повторите шаги 7–12.
1. Сохраните презентацию.

Этот код Python показывает, как добавить маркированные абзацы:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр презентации.
with slides.Presentation() as presentation:

    # Получить доступ к первому слайду.
    slide = presentation.slides[0]

    # Добавить и получить доступ к AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Получить текстовый фрейм созданного AutoShape.
    text_frame = shape.text_frame

    # Удалить абзац по умолчанию.
    text_frame.paragraphs.remove_at(0)

    # Создать абзац.
    paragraph = slides.Paragraph()

    # Установить стиль маркера абзаца и символ.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Задать текст абзаца.
    paragraph.text = "Welcome to Aspose.Slides"

    # Установить отступ маркера.
    paragraph.paragraph_format.indent = 25

    # Установить цвет маркера.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Установить высоту маркера.
    paragraph.paragraph_format.bullet.height = 100

    # Добавить абзац в текстовый фрейм.
    text_frame.paragraphs.add(paragraph)

    # Создать второй абзац.
    paragraph2 = slides.Paragraph()

    # Установить тип и стиль маркера абзаца.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Задать текст абзаца.
    paragraph2.text = "This is numbered bullet"

    # Установить отступ маркера.
    paragraph2.paragraph_format.indent = 25

    # Установить цвет маркера.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Установить высоту маркера.
    paragraph2.paragraph_format.bullet.height = 100

    # Добавить абзац в текстовый фрейм.
    text_frame.paragraphs.add(paragraph2)

    # Сохранить презентацию в файл PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление маркерами‑изображениями**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Маркеры‑изображения легко читаются и понимаются.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на целевой слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) формы.
1. Удалите стандартный абзац из [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Создайте первый абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Загрузите изображение в [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
1. Установите тип маркера в [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) и задайте изображение.
1. Установите текст абзаца.
1. Установите отступ маркера для абзаца.
1. Установите цвет маркера.
1. Установите высоту маркера.
1. Добавьте новый абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Добавьте второй абзац и повторите шаги 8–12.
1. Сохраните презентацию.

Этот код Python показывает, как добавить и управлять маркерами‑изображениями:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Доступ к первому слайду.
    slide = presentation.slides[0]

    # Загрузить изображение маркера.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Добавить и получить доступ к AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Доступ к TextFrame созданного AutoShape.
    text_frame = auto_shape.text_frame

    # Удалить абзац по умолчанию.
    text_frame.paragraphs.remove_at(0)

    # Создать новый абзац.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Установить тип маркера абзаца как Picture и назначить изображение.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Установить высоту маркера.
    paragraph.paragraph_format.bullet.height = 100

    # Добавить абзац в TextFrame.
    text_frame.paragraphs.add(paragraph)

    # Сохранить презентацию в файл PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Сохранить презентацию в файл PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```


## **Управление многоуровневыми маркерами**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Многоуровневые маркеры легко читаются и понимаются.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на целевой слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) у [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Удалите стандартный абзац из [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Создайте первый абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и задайте его глубину 0.
1. Создайте второй абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и задайте его глубину 1.
1. Создайте третий абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и задайте его глубину 2.
1. Создайте четвертый абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и задайте его глубину 3.
1. Добавьте новые абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Сохраните презентацию.

Следующий код Python показывает, как добавить и управлять многоуровневыми маркерами:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр презентации.
with slides.Presentation() as presentation:

    # Получить доступ к первому слайду.
    slide = presentation.slides[0]
    
    # Добавить AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Получить TextFrame созданного AutoShape.
    text_frame = auto_shape.text_frame
    
    # Очистить абзац по умолчанию.
    text_frame.paragraphs.clear()

    # Добавить первый абзац.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установить уровень маркера.
    paragraph1.paragraph_format.depth = 0

    # Добавить второй абзац.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установить уровень маркера.
    paragraph2.paragraph_format.depth = 1

    # Добавить третий абзац.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установить уровень маркера.
    paragraph3.paragraph_format.depth = 2

    # Добавить четвертый абзац.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установить уровень маркера.
    paragraph4.paragraph_format.depth = 3

    # Добавить абзацы в коллекцию.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Сохранить презентацию в файл PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление абзацами с пользовательскими нумерованными списками**

Класс [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) предоставляет свойство `numbered_bullet_start_with` (и другие) для контроля пользовательской нумерации и форматирования абзацев.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите слайд, который будет содержать абзацы.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) формы.
1. Удалите стандартный абзац из [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Создайте первый [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и установите `numbered_bullet_start_with` в 2.
1. Создайте второй [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и установите `numbered_bullet_start_with` в 3.
1. Создайте третий [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и установите `numbered_bullet_start_with` в 7.
1. Добавьте абзацы в коллекцию [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Сохраните презентацию.

Следующий код Python демонстрирует, как добавить и управлять абзацами с пользовательской нумерацией и форматированием.
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Добавить и получить доступ к AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Получить доступ к TextFrame созданного AutoShape.
    text_frame = shape.text_frame

    # Удалить существующий абзац по умолчанию.
    text_frame.paragraphs.remove_at(0)

    # Создать первый нумерованный элемент (начинается с 2, уровень глубины 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Создать второй нумерованный элемент (начинается с 3, уровень глубины 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Создать третий нумерованный элемент (начинается с 7, уровень глубины 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка отступа абзаца**

Отступы абзацев помогают установить чёткую иерархию чтения на слайде и точно настроить выравнивание текста. Пример ниже показывает, как установить как общий, так и первый‑строчный отступ в Aspose.Slides для Python через свойства [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите целевой слайд по его индексу.
1. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) с тремя абзацами к [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Скрыть контур прямоугольника.
1. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) с помощью свойства `paragraph_format`.
1. Сохраните изменённую презентацию в виде файла PPT.

Следующий код Python показывает, как установить отступы абзацев:
```python
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:

    # Доступ к первому слайду.
    slide = presentation.slides[0]

    # Добавить прямоугольную форму.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # Добавить TextFrame к прямоугольнику.
    text_frame = shape.add_text_frame("This is first line \rThis is second line \rThis is third line")

    # Установить автоматическое размещение текста по форме.
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Установить сплошную обводку для прямоугольника.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    # Получить первый абзац в TextFrame и установить его маркер и отступ.
    paragraph1 = text_frame.paragraphs[0]
    # Установить стиль маркера абзаца и символ.
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.alignment = slides.TextAlignment.LEFT

    paragraph1.paragraph_format.depth = 2
    paragraph1.paragraph_format.indent = 30

    # Получить второй абзац в TextFrame и установить его маркер и отступ.
    paragraph2 = text_frame.paragraphs[1]
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = chr(8226)
    paragraph2.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph2.paragraph_format.depth = 2
    paragraph2.paragraph_format.indent = 40

    # Получить третий абзац в TextFrame и установить его маркер и отступ.
    paragraph3 = text_frame.paragraphs[2]
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph3.paragraph_format.depth = 2
    paragraph3.paragraph_format.indent = 50

    # Записать презентацию на диск.
    presentation.save("indent_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка висячего отступа для абзацев**

Этот код Python показывает, как установить висячий отступ для абзаца:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    paragraph1 = slides.Paragraph()
    paragraph1.text = "Example"
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Set Hanging Indent for Paragraphs"
    paragraph3 = slides.Paragraph()
    paragraph3.text = "This Python code shows how to set a hanging indent for a paragraph: "

    paragraph2.paragraph_format.margin_left = 10
    paragraph3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(paragraph1)
    paragraphs.add(paragraph2)
    paragraphs.add(paragraph3)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление форматом конечного фрагмента абзаца**

Когда необходимо контролировать оформление «конца» абзаца (форматирование, применяемое после последнего фрагмента текста), используйте свойство `end_paragraph_portion_format`. Пример ниже применяет более крупный шрифт Times New Roman к концу второго абзаца.

1. Создайте или откройте файл [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите целевой слайд по индексу.
1. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Используйте [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) формы и создайте два абзаца.
1. Создайте [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) со шрифтом Times New Roman 48 pt и примените его как формат конечного фрагмента абзаца.
1. Присвойте его свойству `end_paragraph_portion_format` абзаца (применяется к окончанию второго абзаца).
1. Запишите изменённую презентацию в файл PPTX.

Этот код Python показывает, как установить формат конечного фрагмента для второго абзаца:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите целевой слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) у [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Удалите стандартный абзац из [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Прочитайте исходный HTML‑файл.
1. Создайте первый абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Добавьте HTML‑содержимое в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Сохраните изменённую презентацию.

Следующий код Python реализует эти шаги для импорта HTML‑текста в абзацы.
```python
import aspose.slides as slides

# Создать пустой экземпляр Presentation.
with slides.Presentation() as presentation:

    # Получить доступ к первому слайду презентации.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Добавить AutoShape для размещения HTML содержимого.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Очистить все абзацы в добавленном текстовом фрейме.
    shape.text_frame.paragraphs.clear()

    # Загрузить HTML файл.
    with open("file.html", "rt") as html_stream:
        # Добавить текст из HTML файла в текстовый фрейм.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Сохранить презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Экспорт текста абзаца в HTML**

Aspose.Slides предоставляет расширенную поддержку экспорта текста в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите целевую презентацию.
1. Получите нужный слайд по его индексу.
1. Выберите форму, содержащую текст для экспорта.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) формы.
1. Откройте файловый поток для записи вывода HTML.
1. Укажите начальный индекс и экспортируйте требуемые абзацы.

Этот пример Python показывает, как экспортировать текст абзаца в HTML.
```python
import aspose.slides as slides

# Загрузить файл презентации.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Получить доступ к первому слайду презентации.
    slide = presentation.slides[0]

    # Индекс целевой фигуры.
    index = 0

    # Получить фигуру по индексу.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Записать данные абзацев в HTML, указав начальный индекс абзаца и общее количество экспортируемых абзацев.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```


## **Сохранение абзаца в виде изображения**

В этом разделе мы рассмотрим два примера, демонстрирующие, как сохранить текстовый абзац, представленный классом [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/), в виде изображения. Оба примера включают получение изображения формы, содержащей абзац, с помощью методов `get_image` класса [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), вычисление границ абзаца внутри формы и экспорт его в виде растрового изображения. Эти подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, что у нас есть файл презентации sample.pptx с одним слайдом, где первая форма — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого извлекаем изображение формы с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом фрейме формы. Затем абзац перерисовывается на новом растровом изображении, которое сохраняется в формате PNG. Этот метод особенно полезен, когда нужно сохранить конкретный абзац как отдельное изображение, сохранив точные размеры и форматирование текста.
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

    # Вычислить координаты и размер выходного изображения (минимальный размер - 1x1 пиксель).
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

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Форма извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это обеспечивает более высокое разрешение при экспорте абзаца. Затем границы абзаца рассчитываются с учётом масштаба. Масштабирование особенно полезно, когда требуется более детальное изображение, например, для печати высокого качества.
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

    # Вычислить координаты и размер выходного изображения (минимальный размер - 1x1 пиксель).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Обрезать битмап формы, чтобы получить только битмап абзаца.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


## **Часто задаваемые вопросы**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Используйте параметр переноса текста у текстового фрейма ([wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)), чтобы выключить перенос, и строки не будут разрываться по краям фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Можно получить прямоугольник, ограничивающий абзац (и даже отдельный фрагмент), чтобы узнать его точное положение и размер на слайде.

**Где управляется выравнивание абзаца (лево/право/центр/по ширине)?**

[Alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) — это параметр уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/); он применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки орфографии только для части абзаца (например, одного слова)?**

Да. Язык задаётся на уровне фрагмента ([PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/)), поэтому в одном абзаце могут сосуществовать несколько языков.