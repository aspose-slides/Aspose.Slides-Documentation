---
title: Управление текстовыми абзацами PowerPoint в Python через Java
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- добавление текста
- добавление абзаца
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
- Java
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, части, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides for Python via Java."
---
## **Обзор**

Aspose.Slides for Python via Java представляет текст в виде иерархии текстовых рамок, абзацев и частей:

* [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) представляет контейнер текста в фигуре и предоставляет доступ к его коллекции абзацев.
* [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) представляет один абзац в текстовой рамке и предоставляет доступ к его частям и форматированию уровня абзаца.
* [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) представляет последовательность текста внутри абзаца. Каждая часть может иметь собственный текст и форматирование на уровне символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другими параметрами форматирования, используя несколько частей.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими частями**

Следующие шаги создают текстовую рамку с тремя абзацами, каждый из которых содержит три части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) на слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры.
5. Используйте абзац по умолчанию и добавьте ещё два объекта [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) в текстовую рамку.
6. Добавьте достаточное количество объектов [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) для каждого абзаца, чтобы в нём было три части. Абзац по умолчанию уже содержит одну пустую часть.
7. Установите текст для каждой части.
8. Примените форматирование на уровне символов через [Portion.getPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getPortionFormat).
9. Сохраните изменённую презентацию.

Этот пример на Python реализует перечисленные шаги:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **Создание маркированных и нумерованных списков**

### **Создание маркированного или нумерованного списка**

Маркировка и нумерация упрощают восприятие связанных пунктов. В Aspose.Slides параметры списка определяются через [BulletFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) на выбранный слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры.
5. Удалите абзац по умолчанию из текстовой рамки.
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) для символа‑марки.
7. Установите [BulletFormat.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setType) в значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bullettype/#Symbol) и задайте символ марки.
8. Задайте текст абзаца, отступ, цвет марки и высоту марки.
9. Добавьте абзац в текстовую рамку.
10. Создайте второй абзац и установите [BulletFormat.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setType) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bullettype/#Numbered).
11. Настройте стиль нумерованной марки и добавьте абзац в текстовую рамку.
12. Сохраните презентацию.

Этот пример на Python создаёт символ‑марку и нумерованную марку:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


### **Использование картинных маркировок**

Картинные марки позволяют использовать собственное изображение вместо символа или числа.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) и получите доступ к её [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).
4. Удалите абзац по умолчанию из текстовой рамки.
5. Загрузите изображение марки и добавьте его в коллекцию изображений презентации как объект [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/).
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) и задайте его текст.
7. Установите [BulletFormat.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setType) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bullettype/#Picture).
8. Назначьте изображение через [BulletFormat.getPicture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#getPicture) и задайте высоту марки.
9. Добавьте абзац в текстовую рамку.
10. Сохраните изменённую презентацию.

Этот пример на Python создаёт картинную марку:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```


### **Создание многоуровневого списка**

Установите [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setDepth), чтобы разместить абзацы на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) и очистите абзац по умолчанию из её текстовой рамки.
3. Создайте четыре абзаца и настройте их символы марки.
4. Установите их значения [ParagraphFormat.setDepth] в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на Python создаёт четырёхуровневый маркированный список:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


### **Начало нумерованных пунктов списка с пользовательских значений**

Используйте [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), чтобы задать начальное число, отображаемое для нумерованного абзаца.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) на слайд.
2. Очистите абзац по умолчанию из текстовой рамки фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [BulletFormat.setNumberedBulletStartWith] в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на Python назначает пользовательское начальное число для каждого абзаца:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Управление расположением абзаца и конечными свойствами**

### **Установка отступа первой строки**

Используйте [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setIndent) для управления отступом первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat.setMarginLeft], когда нужно переместить весь абзац. Используйте [ParagraphFormat.setIndent], когда необходимо сместить только первую строку.

В приведённом примере создаются несколько абзацев и применяются различные значения [ParagraphFormat.setIndent], чтобы продемонстрировать, как отступ первой строки влияет на расположение абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) на слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [ParagraphFormat.setIndent].
6. Добавьте абзацы в текстовую рамку.
7. Сохраните изменённую презентацию.

Этот код показывает, как установить отступ абзаца:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся с помощью [ParagraphFormat.setIndent]. Передайте отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat.setMarginLeft] задаёт левую позицию тела абзаца, а [ParagraphFormat.setIndent] определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, передайте положительное значение в [ParagraphFormat.setMarginLeft] и отрицательное значение в [ParagraphFormat.setIndent].

Такое форматирование полезно для библиографий, ссылок, глоссарных статей и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) на слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и задайте положительное значение [ParagraphFormat.setMarginLeft] для каждого абзаца.
6. Передайте отрицательное значение [ParagraphFormat.setIndent] для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовую рамку.
8. Сохраните изменённую презентацию.

Этот код показывает, как установить висячий отступ для абзаца:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Висячий отступ абзацев](hanging_indent.png)

### **Установка свойств завершающего фрагмента абзаца**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) управляет форматированием конечного знака абзаца. В следующем примере задаётся размер шрифта и латинский шрифт для конечного знака второго абзаца:

1. Загрузите объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые части.
4. Создайте [PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/) для конечного знака второго абзаца.
5. Установите [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setFontHeight) и [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. Примените формат с помощью [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) и сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **Импорт и экспорт содержимого абзацев**

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphcollection/#addFromHtml) для преобразования разметки HTML в абзацы и части внутри текстовой рамки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите доступ к слайду и добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).
3. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры и очистите её абзац по умолчанию.
4. Считайте исходный HTML‑файл.
5. Передайте строку HTML в [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Сохраните изменённую презентацию.

Этот пример на Python импортирует HTML в текстовую рамку:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```


### **Экспорт текста абзаца в HTML**

Используйте [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphcollection/#exportToHtml) для экспорта выбранного диапазона абзацев в виде HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите доступ к слайду и найдите [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/), содержащий текст.
3. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры.
4. Вызовите [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphcollection/#exportToHtml) с индексом начального абзаца и числом абзацев для экспорта.
5. Запишите полученную строку HTML в файл.

Этот пример на Python экспортирует все абзацы из первой текстовой фигуры:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Рендеринг абзаца в виде изображения**

[Paragraph.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) непосредственно рендерит отдельный абзац и возвращает объект изображения. Сохраните результат в файл или поток с помощью его метода `save`. Нет необходимости рендерить содержащую фигуру или вручную обрезать растровое изображение.

[Paragraph.getImage] может вернуть `None`, если абзац не найден в родительской коллекции, не имеет корректных границ рендеринга или не может быть отрисован. Проверьте результат перед сохранением и освободите возвращённое изображение после использования.

#### **Рендеринг абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

В следующем примере второй абзац в обычной текстовой фигуре рендерится в масштабе по умолчанию и сохраняется в формате PNG. Блок `finally` гарантирует правильное освобождение изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

#### **Рендеринг абзаца в ячейке таблицы с масштабированием**

Используйте перегрузку [Paragraph.getImage], принимающую параметры `scale_x` и `scale_y` для задания горизонтального и вертикального коэффициентов масштабирования. В следующем примере создаётся таблица, абзац в её первой ячейке рендерится с двойной шириной и высотой по сравнению с масштабом по умолчанию, и результат сохраняется как PNG‑изображение.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

Коэффициент масштабирования `1` сохраняет размер оси в пикселях по умолчанию. Например, `2` для обоих коэффициентов создаёт изображение, ширина и высота которого примерно вдвое превышают размеры по умолчанию, что даёт в четыре раза больше пикселей. Большие коэффициенты обычно дают более чёткий текст при масштабировании или выводе в высоком разрешении, но также увеличивают использование памяти и размер файла. Коэффициенты ниже `1` создают более маленькие изображения с меньшей детализацией. Используйте одинаковые коэффициенты для сохранения пропорций абзаца; разные горизонтальный и вертикальный коэффициенты растягивают вывод независимо.

Рендеринг всей фигуры с помощью [Shape.getImage] остаётся полезным, когда вывод должен включать заливку, границу или другой визуальный контекст фигуры. Для изображения только абзаца используйте [Paragraph.getImage].

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстовой рамки?**

Да. Установите [TextFrameFormat.setWrapText], чтобы отключить перенос, и строки не будут разбиваться по краям текстовой рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [Paragraph.getRect] для получения ограничивающего прямоугольника абзаца. [Portion.getRect] предоставляет границы отдельной части.

**Где контролируется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[ParagraphFormat.setAlignment] — это настройка уровня абзаца, применяющаяся ко всему абзацу независимо от форматирования отдельных частей.

**Можно ли задать язык проверки части абзаца?**

Да. Установите [BasePortionFormat.setLanguageId] для отдельных частей, чтобы один абзац мог содержать текст на нескольких языках.