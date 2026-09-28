---
title: Управление абзацами текста PowerPoint в Python через Java
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
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
- Java
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides for Python via Java представляет текст как иерархию текстовых рамок, абзацев и фрагментов:

* [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) представляет контейнер текста в фигуре и предоставляет доступ к его коллекции абзацев.
* [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) представляет один абзац в текстовой рамке и предоставляет доступ к его фрагментам и форматированию уровня абзаца.
* [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) представляет фрагмент текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими фрагментами**

Следующие шаги создают текстовую рамку с тремя абзацами, каждый из которых содержит три фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры.
5. Используйте абзац по умолчанию и добавьте два дополнительных объекта [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) в текстовую рамку.
6. Добавьте достаточно объектов [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) для каждого абзаца, чтобы в нем было три фрагмента. Абзац по умолчанию уже содержит один пустой фрагмент.
7. Установите текст для каждого фрагмента.
8. Примените форматирование уровня символов через [Portion.getPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getPortionFormat).
9. Сохраните изменённую презентацию.

Этот пример на Python реализует указанные шаги:

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

Марки и нумерация упрощают восприятие связанных элементов. В Aspose.Slides параметры списка задаются через [BulletFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) к выбранному слайду.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры.
5. Удалите абзац по умолчанию из текстовой рамки.
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) для символической маркеры.
7. Установите [BulletFormat.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setType) в значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bullettype/#Symbol) и задайте символ маркера.
8. Установите текст абзаца, отступ, цвет маркера и высоту маркера.
9. Добавьте абзац в текстовую рамку.
10. Создайте второй абзац и установите [BulletFormat.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setType) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bullettype/#Numbered).
11. Настройте стиль нумерованного маркера и добавьте абзац в текстовую рамку.
12. Сохраните презентацию.

Этот пример на Python создаёт символический маркер и нумерованный маркер:

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


### **Использование графических маркеров**

Графические маркеры позволяют вместо символа или номера использовать пользовательское изображение.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) и получите его [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).
4. Удалите абзац по умолчанию из текстовой рамки.
5. Загрузите изображение маркера и добавьте его в коллекцию изображений презентации как [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/).
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) и задайте его текст.
7. Установите [BulletFormat.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setType) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bullettype/#Picture).
8. Присвойте изображение через [BulletFormat.getPicture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#getPicture) и задайте высоту маркера.
9. Добавьте абзац в текстовую рамку.
10. Сохраните изменённую презентацию.

Этот пример на Python создаёт графический маркер:

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

Установите [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setDepth), чтобы разместить абзацы на разных уровнях списка. У верхнего уровня глубина `0`.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и получите слайд.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) и очистите абзац по умолчанию из его текстовой рамки.
3. Создайте четыре абзаца и настройте их символы маркеров.
4. Установите их значения [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setDepth) в `0`, `1`, `2` и `3`.
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


### **Задание пользовательского начального значения для нумерованных пунктов списка**

Используйте [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), чтобы задать начальный номер, отображаемый для нумерованного абзаца.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) на слайд.
2. Очистите абзац по умолчанию из текстовой рамки фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на Python назначает пользовательский начальный номер каждому абзацу:

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

Используйте [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setIndent), чтобы задать отступ первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Для перемещения всего абзаца используйте [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setMarginLeft). Для перемещения только первой строки — [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setIndent).

Пример ниже создаёт несколько абзацев и применяет разные значения [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setIndent), чтобы показать, как отступ первой строки влияет на расположение абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им различные значения [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setIndent).
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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся с помощью [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setIndent). Задайте отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setMarginLeft) определяет левую позицию тела абзаца, а [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setIndent) задаёт позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setMarginLeft) и отрицательное значение [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setIndent).

Это форматирование полезно для библиографий, ссылок, словарных статей и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и задайте положительное значение [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setMarginLeft) для каждого абзаца.
6. Задайте отрицательное значение [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setIndent) для создания эффекта висячего отступа.
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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Установка свойств конечного символа абзаца**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) управляет форматированием конечного знака абзаца. В следующем примере задаётся размер шрифта и латинский шрифт для конечного знака второго абзаца:

1. Загрузите [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и получите слайд.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые фрагменты.
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


## **Подсчёт отрисованных строк**

Для правил абзаца, влияющих на автоматический перенос и пунктуацию в конце строк, см. разделы [Control Line Breaking](/slides/ru/python-java/text-formatting/#control-line-breaking) и [Control Hanging Punctuation](/slides/ru/python-java/text-formatting/#control-hanging-punctuation).

Используйте [Paragraph.getLinesCount](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/#getLinesCount), чтобы подсчитать количество строк, занимаемых абзацем после раскладки текста, включая автоматический перенос. Это полезно при проверке длины текста и раскладки в шаблонах презентаций.

Абзац — один элемент в [TextFrame.getParagraphs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParagraphs) и может занимать несколько отрисованных строк. Явный разрыв строки внутри абзаца заставляет перейти на новую строку без создания нового абзаца. Автоматический перенос формирует строки на основе доступной ширины, не вставляя явных разрывов в текст. Поэтому подсчёт абзацев или символов разрыва строк не даёт количества отрисованных строк.

В следующем примере создаётся текстовая фигура, подсчитываются её строки, затем фигура сужается, после чего текст заменяется более короткой строкой. Перенос включён, а автоподгонка отключена, чтобы ширина фигуры контролировала перенос без автоматического уменьшения текста или изменения размеров фигуры. Размеры фигуры указаны в пунктах. В конце пример добавляет ещё один абзац и суммирует количество строк по всей текстовой рамке.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

При данном тексте и этих размерах сужение фигуры увеличивает количество строк, а замена текста короткой строкой уменьшает его. Точные подсчёты могут варьироваться в зависимости от доступных шрифтов и их замен, размера шрифта, полей, отступов, переноса и настроек автоподгонки. При проверке шаблона используйте шрифты и параметры раскладки, предназначенные для целевой среды.

Само количество строк не определяет, выходит ли текст за пределы контейнера. Важны доступная высота, высота строк, межабзацный и межстрочный интервалы, а также поведение автоподгонки; даже одна строка может превысить доступную ширину, если перенос отключён.

## **Импорт и экспорт содержимого абзацев**

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphcollection/#addFromHtml) для преобразования разметки HTML в абзацы и фрагменты в текстовой рамке.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите слайд и добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).
3. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры и очистите её абзац по умолчанию.
4. Прочитайте исходный HTML‑файл.
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

Используйте [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphcollection/#exportToHtml) для экспорта выбранного диапазона абзацев в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите слайд и найдите [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/), содержащий текст.
3. Получите [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) фигуры.
4. Вызовите [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphcollection/#exportToHtml), указав индекс начального абзаца и количество экспортируемых абзацев.
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

### **Рендеринг абзаца как изображения**

[Paragraph.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) напрямую рендерит отдельный абзац и возвращает объект изображения. Сохраните результат в файл или поток методом `save`. Не требуется рендерить содержащую фигуру или вручную обрезать bitmap.

[Paragraph.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) может вернуть `None`, если абзац не найден в родительской коллекции, не имеет действительных границ для рендеринга или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Рендеринг абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации `sample.pptx` с одним слайдом, где первая фигура — текстовое окно, содержащее три абзаца.

![The text box with three paragraphs](paragraph_to_image_input.png)

Следующий пример рендерит второй абзац в обычной текстовой фигуре в масштабе по умолчанию и сохраняет полученное изображение в формате PNG. Блок `finally` гарантирует корректное освобождение изображения.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Рендеринг абзаца в ячейке таблицы с масштабированием**

Используйте перегрузку [Paragraph.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/), принимающую параметры `scale_x` и `scale_y`, чтобы задать горизонтальные и вертикальные коэффициенты масштабирования. В следующем примере создаётся таблица, абзац в её первой ячейке рендерится с двойной шириной и высотой по сравнению со значением по умолчанию, и результат сохраняется как PNG‑изображение.

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

Коэффициент масштаба `1` сохраняет размер оси в пикселях по умолчанию. Например, `2` для обеих осей даёт изображение, ширина и высота которого примерно вдвое больше базовых размеров, а количество пикселей увеличивается в четыре раза. Большие коэффициенты обычно дают более чёткий текст при увеличении или выводе в высоком разрешении, но также увеличивают расход памяти и размер файла. Коэффициенты ниже `1` дают меньшие изображения с меньшим детализацией. Используйте одинаковые коэффициенты, чтобы сохранить соотношение сторон абзаца; разные горизонтальные и вертикальные коэффициенты растягивают изображение независимо.

Рендеринг целой фигуры через [Shape.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) остаётся полезным, когда в выводе должны присутствовать заливка, контур или другие визуальные элементы фигуры. Для изображения только абзаца используйте [Paragraph.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/).

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстовой рамки?**

Да. Установите [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setWrapText), чтобы отключить перенос, и строки не будут разрываться у краёв текстовой рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [Paragraph.getRect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/#getRect) для получения ограничивающего прямоугольника абзаца. [Portion.getRect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getRect) предоставляет границы отдельного фрагмента.

**Где контролируется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setAlignment) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки правописания только для части абзаца?**

Да. Установите [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId) для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.