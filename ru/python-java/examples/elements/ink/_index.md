---
title: Чернильные формы
type: docs
weight: 180
url: /ru/python-java/examples/elements/ink/
keywords:
- пример кода
- чернь
- доступ к черни
- удалить чернь
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Доступ к чернильным формам и их удаление в презентациях Aspose.Slides для Python через Java, включая файлы PPT, PPTX и ODP."
---
Эта статья предоставляет примеры доступа к существующим ink shape и их удаления с помощью **Aspose.Slides for Python via Java**.

Установите пакет, как описано в разделе [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, а затем импортирует API после того, как JVM запущена.

{{% alert color="info" title="Note" %}}
Ink shape представляют ввод пользователя со специализированных устройств. Aspose.Slides не может программно создавать новые ink stroke, но вы можете читать и изменять существующий ink.
{{% /alert %}}

## **Доступ к Ink**

Прочитайте теги первой ink shape на слайде.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Используйте tag_name по необходимости.
finally:
    presentation.dispose()
```

## **Удалить Ink**

Удалите ink shape со слайда, если она существует.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```