---
title: Текстовое поле
type: docs
weight: 40
url: /ru/python-java/examples/elements/text-box/
keywords:
- пример кода
- текстовое поле
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Работа с текстовыми полями в Aspose.Slides for Python via Java: добавление, форматирование, поиск и удаление текста в презентациях PowerPoint и OpenDocument."
---
В **Aspose.Slides for Python via Java** текстовое поле представляет собой автофигуру, содержащую текст. Практически любую фигуру можно заполнить текстом, но типичное текстовое поле не имеет заливки и границы и отображает только текст.

Это руководство объясняет, как программно добавлять, получать доступ к и удалять текстовые поля.

Установите пакет, как описано в [Установка](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, затем импортирует API после того, как JVM запущена.

## **Добавить текстовое поле**

Создайте прямоугольник, удалите его заливку и границу и задайте отформатированный текст.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Создать прямоугольную форму.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Удалить заливку и границу, чтобы отображать только текст.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Установить форматирование текста по умолчанию.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Получить доступ к текстовым полям по содержанию**

Добавьте пример текстового поля, затем найдите фигуры, текст которых содержит ключевое слово "Slide".

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # Использовать совпадающее текстовое поле.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Удалить текстовые поля по содержанию**

Найдите и удалите текстовые поля на первом слайде, которые содержат определённое ключевое слово.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
Соберите соответствующие фигуры в отдельный список перед удалением, чтобы избежать изменения коллекции фигур во время итерации.
{{% /alert %}}