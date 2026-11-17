---
title: Управление переходами слайдов в презентациях с помощью Python через Java
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/python-java/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- расширенный переход слайда
- Morph‑переход
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое переключение слайдов и кастомизируйте Morph и другие эффекты переходов с помощью Aspose.Slides for Python via Java."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды появляются во время показа. С помощью Aspose.Slides for Python via Java вы можете выбрать эффект перехода для каждого слайда, настроить переключение по щелчку мыши или по таймеру и изменить параметры, специфичные для эффекта. В этой статье используются примеры на Python для применения переходов, установки точных длительностей переходов, управления временем отображения слайда и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавить переход слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и получите настройки перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Используйте [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) со значением из перечисления [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), затем сохраните презентацию.

В следующем примере применяется переход Circle к первому слайду и переход Comb ко второму. Используйте файл `input.pptx` как минимум с двумя слайдами.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Wheel Transition**

Используйте [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), чтобы выбрать Wheel из [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Затем вызовите [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue), чтобы получить настройки [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Его метод [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) управляет количеством радиальных секторов, открывающих целевой слайд.

В примере создаются две одинаковые пары слайдов. Каждая пара начинается черным слайдом и заканчивается золотым прямоугольником на весь слайд. Обе целевые слайды используют одинаковую медленную скорость, установленную через [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed), и одинаковую явную длительность — 8 000 мс, установленную через [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Изменяется только количество спиц.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Откройте `wheel-transitions.pptx` в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, чтобы увидеть, как один сектор по часовой стрелке открывает золотой прямоугольник. Затем перейдите со слайда 3 на слайд 4, чтобы увидеть восемь радиальных секторов, одновременно открывающих тот же прямоугольник.

## **Добавить расширенный переход слайда**

Вы можете настроить, как долго слайд остаётся на экране и будет ли щелчок мыши переключать показ. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) позволяет зрителю переключать по щелчку мыши.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) включает автоматическое переключение.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) задаёт задержку перед автоматическим переключением в миллисекундах.

Включите оба типа переключения, чтобы зритель мог перейти по щелчку или ждать таймер. Чтобы использовать только таймер, передайте `False` в [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Задержка управляет тем, когда показываются слайды; она не задаёт длительность визуального эффекта перехода.

В этом примере разным первым трем слайдам назначаются разные эффекты, и включается автоматическое переключение через 3, 5 и 7 секунд соответственно. По щелчку мыши также можно перейти к этим слайдам. Используйте файл `input.pptx` с минимум тремя слайдами.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Чтобы проверить, включено ли автоматическое переключение, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Хранение задержки само по себе не указывает, что таймер активен.

Следующий пример открывает сохранённый выше файл, выводит информацию о каждом включённом таймере и отключает автоматическое переключение для слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мышью, после чего обновлённые настройки сохраняются.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Точное управление временем перехода**

Используйте [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), чтобы задать точную длину эффекта перехода в миллисекундах. Метод [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) слайда раскрывает эти настройки через [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Задает длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Задает задержку перед автоматическим переключением слайда в миллисекундах. Передайте `True` в [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter), чтобы активировать таймер. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) управляет только эффектом перехода; он не определяет, как долго слайд остаётся видимым. Задержку автоматического переключения необходимо настраивать отдельно. Если явная длительность не указана, Aspose.Slides определяет длительность эффекта исходя из типа перехода и значения [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Отдельные полосы показывают длительность 750 мс перехода и 5 000 мс автоматического переключения.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Пример демонстрирует, как каждому слайду задаётся переход Fade длительностью 750 мс и отдельно включается автоматическое переключение через 5 000 мс. Длительность перехода контролирует эффект; переключение контролирует момент выхода со слайда. Эти полосы – схематические настройки, а не измеренная суммарная шкала времени.*
<!-- visual-explanation:slide-transition:end -->

### **Применить одинаковую длительность ко всем слайдам**

Чтобы обеспечить одинаковое темпо, примените один и тот же эффект и точную длительность ко каждому слайду. В этом примере загружается `input.pptx`, выбирается Fade из [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), и каждой переходу задаётся длительность 750 мс. Затем отдельно включается автоматическое переключение через 5 000 мс и отключается переключение по щелчку мыши, после чего результат сохраняется в PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Настройте автоматическое переключение независимо от длительности эффекта.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Установить разные длительности для отдельных слайдов**

Разные слайды могут иметь разную длительность эффекта. Например, используйте короткий переход для титульного слайда и более длительный – для вступления раздела. В этом примере первая slide получает 500 мс, а вторая – 1 200 мс. Используйте файл `input.pptx` с минимум двумя слайдами.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Скоординировать переходы с анимированным выводом**

При подготовке [animated GIF](/slides/ru/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/python-java/export-to-html5/) или [video](/slides/ru/python-java/convert-powerpoint-to-video/) задавайте точные длительности переходов перед экспортом, чтобы они соответствовали запланированному темпу. Например, используйте 600‑мс затухание между сценами и отдельно задавайте задержку автоматического переключения каждого слайда, чтобы обеспечить время для озвучки или контента.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствует 18 кадрам при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры таймингов выбранного формата и предварительно просмотрите результат для подтверждения синхронизации.

### **Прочитать существующую длительность перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) до изменения перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) для её определения. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph-переход**

Morph‑переход анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, склонируйте слайд, переместите или измените размер объекта в клоне и примените Morph‑переход ко второму слайду. Это заставит соответствующие объекты анимироваться между их исходным и изменённым состояниями.

В следующем примере создаётся слайд с прямоугольником‑текстом, клонируется, а позиция и размер прямоугольника изменяются в клоне. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике, поддерживающем Morph, чтобы увидеть эффект во время показа.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Типы Morph‑перехода**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) определяет, как Morph сопоставляет и анимирует контент:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как единый объект.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя символы, где это возможно.

Используйте [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), чтобы выбрать Morph перед получением [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Возвращённое значение будет экземпляром класса [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), метод [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) которого выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и для второго слайда настраивается анимация Morph по словам.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Установить эффекты переходов**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от перехода, выбранного с помощью [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Сначала задайте тип, затем используйте соответствующий класс, полученный через [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

В следующем примере применяется переход Cut к первому слайду `input.pptx`. Через [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) вызывается [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack), чтобы переход начинался с чёрного экрана.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я управлять скоростью воспроизведения перехода слайда?**

Да. Предпочтительно используйте [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), когда нужна точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed), когда достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) — Slow, Medium или Fast, и явная длительность не задаётся. Эти настройки управляют только эффектом перехода, независимо от задержки автоматического переключения.

**Могу ли я прикрепить звук к переходу и включить его зацикливание?**

Да. Присвойте встроенный звук с помощью [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), передайте `StartSound` из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) и включите [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) со значением `True`. Звук будет повторяться до следующего звукового события в показе.

**Как быстро применить один и тот же переход ко всем слайдам?**

Пройдитесь по коллекции [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) презентации и вызовите [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) с тем же значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы поведение было одинаковым на всех слайдах.

**Как проверить, какой переход сейчас установлен на слайде?**

Вызовите [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) у результата [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) слайда. Он вернёт значение из перечисления [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); `None_` означает, что переход не назначен.