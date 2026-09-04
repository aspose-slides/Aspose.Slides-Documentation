---
title: Заметка
type: docs
weight: 240
url: /ru/python-java/examples/elements/note/
keywords:
- пример кода
- заметка
- примечание выступающего
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Работайте со слайдами заметок в Aspose.Slides for Python via Java: добавляйте, читайте, удаляйте и обновляйте заметки выступающего в презентациях PowerPoint и OpenDocument."
---
В этой статье демонстрируется, как добавлять, читать, удалять и обновлять слайды заметок с помощью **Aspose.Slides for Python via Java**.

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, а затем импортирует API после запуска JVM.

## **Добавить слайд заметок**

Создайте слайд заметок и присвойте ему текст.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Доступ к слайду заметок**

Прочитайте текст из существующего слайда заметок.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Удалить слайд заметок**

Удалите слайд заметок, связанный со слайдом.

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Обновить текст заметок**

Измените текст слайда заметок.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```