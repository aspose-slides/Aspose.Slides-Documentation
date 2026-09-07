---
title: SmartArt
type: docs
weight: 140
url: /ru/python-java/examples/elements/smart-art/
keywords:
- пример кода
- SmartArt
- добавление SmartArt
- доступ к SmartArt
- удаление SmartArt
- макет SmartArt
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Работайте со SmartArt в Aspose.Slides for Python via Java: добавляйте, получайте доступ, удаляйте и меняйте макеты диаграмм в презентациях PowerPoint и OpenDocument."
---
В этой статье демонстрируется, как добавлять графику SmartArt, получать к ней доступ, удалять её и изменять макеты с помощью **Aspose.Slides for Python via Java**.

Установите пакет, как описано в разделе [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, а затем импортирует API после запуска JVM.

## **Добавить SmartArt**

Вставьте графику SmartArt, используя один из встроенных макетов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **Получить SmartArt**

Получите первый объект SmartArt на слайде.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **Удалить SmartArt**

Удалите форму SmartArt со слайда.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Изменить макет SmartArt**

Обновите тип макета существующей графики SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```