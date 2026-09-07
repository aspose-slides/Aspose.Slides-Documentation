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
description: "Работайте с текстовыми полями в Aspose.Slides for Python via Java: добавляйте, форматируйте, находите и удаляйте текст в презентациях PowerPoint и OpenDocument."
---
В **Aspose.Slides for Python via Java** текстовое поле — это автоматическая фигура, содержащая текст. Практически любая фигура может содержать текст, но обычное текстовое поле не имеет заливки или границы и отображает только текст.

В этом руководстве объясняется, как программно добавлять, получать доступ и удалять текстовые поля.

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, затем импортирует API после запуска JVM.

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

## **Доступ к текстовым полям по содержимому**

Добавьте пример текстового поля, затем найдите фигуры, чьё текстовое содержимое включает ключевое слово "Slide".

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

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # Использовать соответствующее текстовое поле.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Удалить текстовые поля по содержимому**

Найдите и удалите текстовые поля на первом слайде, содержащие определённое ключевое слово.

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
Соберите соответствующие фигуры в отдельный список перед их удалением, чтобы избежать изменения коллекции фигур во время итерации.
{{% /alert %}}