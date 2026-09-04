---
title: ActiveX
type: docs
weight: 200
url: /ru/python-java/examples/elements/activex/
keywords:
- пример кода
- ActiveX
- элемент управления ActiveX
- свойства ActiveX
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Используйте Aspose.Slides for Python via Java для добавления, доступа, удаления и настройки элементов управления ActiveX в презентациях PowerPoint с практическими примерами кода."
---
Эта статья демонстрирует, как добавлять, получать доступ, удалять и настраивать элементы управления ActiveX в презентации, используя **Aspose.Slides for Python via Java**.

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, затем импортирует API после того, как JVM запущена. Примеры доступа и удаления используют `add_activex.pptm`, созданный первым примером.

## **Добавление элемента управления ActiveX**

Вставьте элемент управления Windows Media Player на первый слайд и сохраните презентацию в виде файла PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавить элемент управления Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Доступ к элементу управления ActiveX**

Прочитайте имя и настройку автоматического воспроизведения первого элемента управления ActiveX на слайде.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Доступ к первому элементу управления ActiveX.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **Удаление элемента управления ActiveX**

Удалите первый элемент управления ActiveX со слайда и сохраните измененную презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Удалить первый элемент управления ActiveX.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Установка свойств ActiveX**

Добавьте элемент управления Windows Media Player, отключите автоматическое воспроизведение и скройте его элементы управления воспроизведением. Используйте [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/ru/python-java/aspose.slides/controlpropertiescollection/#set_Item), чтобы задать значения свойств в виде строк.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавить элемент управления Windows Media Player и настроить его свойства.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```