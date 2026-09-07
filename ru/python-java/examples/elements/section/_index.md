---
title: Раздел
type: docs
weight: 90
url: /ru/python-java/examples/elements/section/
keywords:
- пример кода
- раздел
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Управляйте разделами презентации в Aspose.Slides for Python via Java: добавляйте, получайте доступ, удаляйте и переименовывайте разделы с примерами кода на Python."
---
Примеры управления разделами презентации — добавление, доступ, удаление и переименование их программно с использованием **Aspose.Slides for Python via Java**.

Установите пакет, как описано в [Установка](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, затем импортирует API после того, как JVM запущена.

## **Добавить раздел**

Создайте раздел, начинающийся с определённого слайда.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Укажите слайд, который отмечает начало раздела.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Получить доступ к разделу**

Прочитайте информацию о разделе из презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Доступ к разделу по индексу.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Удалить раздел**

Удалите ранее добавленный раздел.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Удалить первый раздел.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Переименовать раздел**

Измените имя существующего раздела.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```