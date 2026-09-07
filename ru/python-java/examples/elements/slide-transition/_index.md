---
title: Переход слайда
type: docs
weight: 110
url: /ru/python-java/examples/elements/slide-transition/
keywords:
- пример кода
- переход слайда
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте и удаляйте переходы слайдов и задавайте тайминги автоматического продвижения слайдов с помощью примеров кода Aspose.Slides for Python via Java для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется применение эффектов перехода слайдов и таймингов с помощью **Aspose.Slides for Python via Java**.

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, а затем импортирует API после запуска JVM.

## **Добавить переход слайда**

Примените эффект плавного перехода к первому слайду.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Применить плавный переход.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Получить доступ к переходу слайда**

Прочитайте тип перехода, в данный момент назначенный слайду.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Получить тип перехода.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Удалить переход слайда**

Очистите любой эффект перехода. JPype предоставляет Java-константу с именем `None` как `None_`, потому что `None` является зарезервированным словом в Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Удалить эффект перехода.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Установить длительность перехода**

Укажите, как долго слайд отображается перед автоматическим переключением. В этом примере переключение происходит через две секунды, а также допускает переключение щелчком мыши. Этот тайминг управляет переходом слайда, а не скоростью эффекта перехода.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # В миллисекундах.
finally:
    presentation.dispose()
```