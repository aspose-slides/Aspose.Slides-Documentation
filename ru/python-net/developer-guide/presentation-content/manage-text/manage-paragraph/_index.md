---
title: Управление абзацами PowerPoint на Python
type: docs
weight: 40
url: /ru/python-net/manage-paragraph/
keywords: "Добавить абзац PowerPoint, Управлять абзацами, Отступ абзаца, Свойства абзаца, HTML текст, Экспорт текста абзаца, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Создание и управление абзацами, текстом, отступами и свойствами в презентациях PowerPoint на Python"
---

Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстами PowerPoint, абзацами и частями на Python.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/), который позволяет добавлять объекты, представляющие абзац. Объект `ITextFame` может иметь один или несколько абзацев (каждый абзац создается через перенос строки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/), который позволяет добавлять объекты, представляющие части. Объект `IParagraph` может иметь одну или несколько частей (коллекция объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/), который позволяет добавлять объекты, представляющие тексты и их форматирующие свойства.

Объект `IParagraph` способен обрабатывать тексты с различными форматирующими свойствами через свои базовые объекты `IPortion`.

## **Добавить несколько абзацев, содержащих несколько частей**

Эти шаги покажут вам, как добавить текстовый фрейм, содержащий 3 абзаца, и каждый абзац, содержащий 3 части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте прямоугольник [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` объекта [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) для каждого нового `IParagraph` (два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion каждого `IParagraph`.
7. Установите некоторый текст для каждой части.
8. Примените ваши предпочтительные форматирующие функции к каждой части с помощью свойств форматирования, предоставленных объектом `IPortion`.
9. Сохраните измененную презентацию.

Этот код на Python является реализацией шагов для добавления абзацев, содержащих части:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создание экземпляра класса Presentation, представляющего файл PPTX
with slides.Presentation() as pres:
    # Получение первого слайда
    slide = pres.slides[0]

    # Добавление автофигуры типа прямоугольник
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Доступ к текстовому фрейму автофигуры
    tf = ashp.text_frame

    # Создание абзацев и частей с различными текстовыми форматами
    para0 = tf.paragraphs[0]
    port01 = slides.Portion()
    port02 = slides.Portion()
    para0.portions.add(port01)
    para0.portions.add(port02)

    para1 = slides.Paragraph()
    tf.paragraphs.add(para1)
    port10 = slides.Portion()
    port11 = slides.Portion()
    port12 = slides.Portion()
    para1.portions.add(port10)
    para1.portions.add(port11)
    para1.portions.add(port12)

    para2 = slides.Paragraph()
    tf.paragraphs.add(para2)
    port20 = slides.Portion()
    port21 = slides.Portion()
    port22 = slides.Portion()
    para2.portions.add(port20)
    para2.portions.add(port21)
    para2.portions.add(port22)

    for i in range(3):
        for j in range(3):
            tf.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                tf.paragraphs[i].portions[j].portion_format.font_bold = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                tf.paragraphs[i].portions[j].portion_format.font_italic = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 18

    # Запись PPTX на диск
    pres.save("multiParaPort_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление маркерами абзацев**

Маркеры помогают организовать и быстро представить информацию. Абзацы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. Установите тип маркера для абзаца в `Symbol` и установите символ маркера.
8. Установите `Text` для абзаца.
9. Установите `Indent` для абзаца с маркером.
10. Установите цвет для маркера.
11. Установите высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, описанный в шагах 7–13.
14. Сохраните презентацию.

Этот код на Python показывает, как добавить маркер абзаца:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создание экземпляра презентации
with slides.Presentation() as pres:
    # Получение первого слайда
    slide = pres.slides[0]

    # Добавление и доступ к автофигуре
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Доступ к текстовому фрейму созданной автофигуры
    txtFrm = aShp.text_frame

    # Удаление существующего абзаца по умолчанию
    txtFrm.paragraphs.remove_at(0)

    # Создание абзаца
    para = slides.Paragraph()

    # Установка стиля и символа маркера абзаца
    para.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para.paragraph_format.bullet.char = chr(8226)

    # Установка текста абзаца
    para.text = "Добро пожаловать в Aspose.Slides"

    # Установка отступа для маркера
    para.paragraph_format.indent = 25

    # Установка цвета маркера
    para.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para.paragraph_format.bullet.color.color = draw.Color.black
    para.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Установка высоты маркера
    para.paragraph_format.bullet.height = 100

    # Добавление абзаца в текстовый фрейм
    txtFrm.paragraphs.add(para)

    # Создание второго абзаца
    para2 = slides.Paragraph()

    # Установка типа и стиля маркера абзаца
    para2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    para2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Добавление текста абзаца
    para2.text = "Это нумерованный маркер"

    # Установка отступа для маркера
    para2.paragraph_format.indent = 25

    para2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para2.paragraph_format.bullet.color.color = draw.Color.black
    para2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Установка высоты маркера
    para2.paragraph_format.bullet.height = 100

    # Добавление абзаца в текстовый фрейм
    txtFrm.paragraphs.add(para2)

    # Запись презентации в файл PPTX
    pres.save("bullet_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление картинками-маркерами**

Маркеры помогают организовать и быстро представить информацию. Абзацы с картинками легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/).
8. Установите тип маркера в [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) и установите изображение.
9. Установите текст абзаца.
10. Установите отступ абзаца для маркера.
11. Установите цвет для маркера.
12. Установите высоту для маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс на основе предыдущих шагов.
15. Сохраните измененную презентацию.

Этот код на Python показывает, как добавлять и управлять маркерами с изображением:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Получение первого слайда
    slide = presentation.slides[0]

    # Создание изображения для маркеров
    image = draw.Bitmap(path + "bullets.png")
    ippxImage = presentation.images.add_image(image)

    # Добавление и доступ к автофигуре
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Доступ к текстовому фрейму созданной автофигуры
    textFrame = autoShape.text_frame

    # Удаление существующего абзаца по умолчанию
    textFrame.paragraphs.remove_at(0)

    # Создание нового абзаца
    paragraph = slides.Paragraph()
    paragraph.text = "Добро пожаловать в Aspose.Slides"

    # Установка стиля и изображения маркера абзаца
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = ippxImage

    # Установка высоты маркера
    paragraph.paragraph_format.bullet.height = 100

    # Добавление абзаца в текстовый фрейм
    textFrame.paragraphs.add(paragraph)

    # Запись презентации в файл PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", slides.export.SaveFormat.PPTX)
    # Запись презентации в файл PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", slides.export.SaveFormat.PPT)
```


## **Управление многоуровневыми маркерами**

Маркеры помогают организовать и быстро представить информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) на новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и установите глубину на 0.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и установите глубину на 1.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и установите глубину на 2.
9. Создайте четвертый экземпляр абзаца через класс `Paragraph` и установите глубину на 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните измененную презентацию.

Этот код на Python показывает, как добавлять и управлять многоуровневыми маркерами:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создание экземпляра презентации
with slides.Presentation() as pres:
    # Получение первого слайда
    slide = pres.slides[0]
    
    # Добавление и доступ к автофигуре
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Доступ к текстовому фрейму созданной автофигуры
    text = aShp.add_text_frame("")
    
    # Очистка абзаца по умолчанию
    text.paragraphs.clear()

    # Добавление первого абзаца
    para1 = slides.Paragraph()
    para1.text = "Содержимое"
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установка уровня маркера
    para1.paragraph_format.depth = 0

    # Добавление второго абзаца
    para2 = slides.Paragraph()
    para2.text = "Второй уровень"
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = '-'
    para2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установка уровня маркера
    para2.paragraph_format.depth = 1

    # Добавление третьего абзаца
    para3 = slides.Paragraph()
    para3.text = "Третий уровень"
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установка уровня маркера
    para3.paragraph_format.depth = 2

    # Добавление четвертого абзаца
    para4 = slides.Paragraph()
    para4.text = "Четвертый уровень"
    para4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para4.paragraph_format.bullet.char = '-'
    para4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Установка уровня маркера
    para4.paragraph_format.depth = 3

    # Добавление абзацев в коллекцию
    text.paragraphs.add(para1)
    text.paragraphs.add(para2)
    text.paragraphs.add(para3)
    text.paragraphs.add(para4)

    # Запись презентации в файл PPTX
    pres.save("MultilevelBullet.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление абзацем с пользовательским нумерованным списком**

Интерфейс [IBulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformat/#ibulletformat/) предоставляет свойство `NumberedBulletStartWith` и другие, которые позволяют управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и установите `NumberedBulletStartWith` на 2.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 3.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните измененную презентацию.

Этот код на Python показывает, как добавлять и управлять абзацами с пользовательской нумерацией:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Доступ к текстовому фрейму созданной автофигуры
    textFrame = shape.text_frame

    # Удаление существующего абзаца по умолчанию
    textFrame.paragraphs.remove_at(0)

    # Первый список
    paragraph1 = slides.Paragraph()
    paragraph1.text = "маркер 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.text = "маркер 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    textFrame.paragraphs.add(paragraph2)

    paragraph5 = slides.Paragraph()
    paragraph5.text = "маркер 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph5)

    presentation.save("SetCustomBulletsNumber-slides.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить отступ абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на соответствующий слайд через его индекс.
1. Добавьте прямоугольник [автофигуру](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) с тремя абзацами в прямоугольник автофигуры.
1. Скрыть линии прямоугольника.
1. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) через их свойство BulletOffset.
1. Запишите измененную презентацию в файл PPT.

Этот код на Python показывает, как установить отступ абзаца:

```python
import aspose.slides as slides

# Создание экземпляра класса Presentation
with slides.Presentation() as pres:

    # Получение первого слайда
    sld = pres.slides[0]

    # Добавление автофигуры типа прямоугольник
    rect = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # Добавление TextFrame к прямоугольнику
    tf = rect.add_text_frame("Это первая строка \rЭто вторая строка \rЭто третья строка")

    # Установка текста в объеме фигуры
    tf.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Скрытие линий прямоугольника
    rect.line_format.fill_format.fill_type = slides.FillType.SOLID

    # Получение первого абзаца в текстовом фрейме и установка его отступа
    para1 = tf.paragraphs[0]
    # Установка стиля и символа маркера абзаца
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.alignment = slides.TextAlignment.LEFT

    para1.paragraph_format.depth = 2
    para1.paragraph_format.indent = 30

    # Получение второго абзаца в текстовом фрейме и установка его отступа
    para2 = tf.paragraphs[1]
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = chr(8226)
    para2.paragraph_format.alignment = slides.TextAlignment.LEFT
    para2.paragraph_format.depth = 2
    para2.paragraph_format.indent = 40

    # Получение третьего абзаца в текстовом фрейме и установка его отступа
    para3 = tf.paragraphs[2]
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.alignment = slides.TextAlignment.LEFT
    para3.paragraph_format.depth = 2
    para3.paragraph_format.indent = 50

    # Запись презентации на диск
    pres.save("InOutDent_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить висячий отступ для абзаца**

Этот код на Python показывает, как установить висячий отступ для абзаца:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    auto_shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    para1 = slides.Paragraph()
    para1.text = "Пример"
    para2 = slides.Paragraph()
    para2.text = "Установить висячий отступ для абзаца"
    para3 = slides.Paragraph()
    para3.text = "Этот код C# показывает, как установить висячий отступ для абзаца: "

    para2.paragraph_format.margin_left = 10
    para3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(para1)
    paragraphs.add(para2)
    paragraphs.add(para3)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление свойствами конца абзаца для абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, содержащий абзац, через его позицию.
1. Добавьте прямоугольник [автофигуру](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) с двумя абзацами в прямоугольник.
1. Установите `FontHeight` и тип шрифта для абзацев.
1. Установите свойства конца для абзацев.
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python показывает, как установить свойства конца для абзацев в PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	para1 = slides.Paragraph()
	para1.portions.add(slides.Portion("Образец текста"))

	para2 = slides.Paragraph()
	para2.portions.add(slides.Portion("Образец текста 2"))
	endParagraphPortionFormat = slides.PortionFormat()
	endParagraphPortionFormat.font_height = 48
	endParagraphPortionFormat.latin_font = slides.FontData("Times New Roman")
	para2.end_paragraph_portion_format = endParagraphPortionFormat

	shape.text_frame.paragraphs.add(para1)
	shape.text_frame.paragraphs.add(para2)

	pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **Импорт HTML текста в абзацы**

Aspose.Slides предоставляет улучшенную поддержку импорта HTML текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите `автофигуру` [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/).
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Прочитайте исходный HTML файл в TextReader.
7. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
8. Добавьте содержимое HTML файла, прочитанное TextReader, в коллекцию [ParagraphCollection](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/) текстового фрейма.
9. Сохраните измененную презентацию.

Этот код на Python является реализацией шагов по импорту HTML текстов в абзацы:

```python
import aspose.slides as slides

# Создание пустого экземпляра презентации
with slides.Presentation() as pres:
    # Доступ к первому слайду презентации
    slide = pres.slides[0]

    # Добавление автофигуры для размещения HTML содержимого
    ashape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, pres.slide_size.size.width - 20, pres.slide_size.size.height - 10)

    ashape.fill_format.fill_type = slides.FillType.NO_FILL

    # Добавление текстового фрейма к фигуре
    ashape.add_text_frame("")

    # Очистка всех абзацев в добавленном текстовом фрейме
    ashape.text_frame.paragraphs.clear()

    # Загрузка HTML файла с помощью потока чтения
    with open(path + "file.html", "rt") as tr:
        # Добавление текста из потока HTML в текстовый фрейм
        ashape.text_frame.paragraphs.add_from_html(tr.read())

    # Сохранение презентации
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Экспорт текста абзацев в HTML**

Aspose.Slides предоставляет улучшенную поддержку для экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите желаемую презентацию.
2. Получите ссылку на соответствующий слайд через его индекс.
3. Получите фигуру, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) фигуры.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML файл.
6. Укажите стартовый индекс StreamWriter и экспортируйте ваши предпочтительные абзацы.

Этот код на Python показывает, как экспортировать текст абзацев PowerPoint в HTML:

```python
import aspose.slides as slides

# Загрузка файла презентации
with slides.Presentation(path + "ExportingHTMLText.pptx") as pres:
    # Получение первого слайда презентации
    slide = pres.slides[0]

    # Желаемый индекс
    index = 0

    # Доступ к добавленной фигуре
    ashape = slide.shapes[index]

    with open("output_out.html", "w") as sw:
        # Запись данных абзацев в HTML, предоставляя начальный индекс абзаца, общее количество абзацев для копирования
        sw.write(ashape.text_frame.paragraphs.export_to_html(0, ashape.text_frame.paragraphs.count, None))
```