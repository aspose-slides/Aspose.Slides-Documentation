---
title: Управление переходами слайдов в презентациях с использованием Python через Java
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/python-java/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- расширенный переход слайда
- переход Morph
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайда и кастомизируйте Morph и другие эффекты переходов с Aspose.Slides для Python через Java."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды отображаются во время показа. С помощью Aspose.Slides for Python через Java можно выбрать эффект перехода для каждого слайда, настроить переход по щелчку мыши или таймеру и изменить параметры, специфичные для эффекта. В этой статье приведены примеры на Python для применения переходов, установки точных длительностей переходов, управления временем показа слайдов и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавление перехода слайда**

Чтобы применить переход, загрузите презентацию с помощью класса[Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и получите доступ к настройкам перехода слайда через[ getSlideShowTransition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getSlideShowTransition). Используйте[ setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setType) со значением из перечисления[ TransitionType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitiontype/), затем сохраните презентацию.

Следующий пример применяет переход Circle к первому слайду и переход Comb ко второму. Используйте файл `input.pptx` с минимум двумя слайдами.

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

## **Добавление расширенного перехода слайда**

Можно настроить, как долго слайд остаётся на экране и будет ли щелчок мыши продвигать показ. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) позволяет зрителю продвигать показ щелчком мыши.
- [setAdvanceAfter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) включает автоматическое продвижение.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) задаёт задержку перед автоматическим продвижением в миллисекундах.

Включите как щелчок, так и таймер, чтобы зритель мог перейти щелчком или ждать таймера. Чтобы использовать только таймер, передайте `False` в[ setAdvanceOnClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Задержка управляет моментом перехода в показе; она не задаёт длительность визуального эффекта перехода.

В этом примере назначаются разные эффекты первым трем слайдам и включается автоматическое продвижение через 3, 5 и 7 секунд соответственно. Щелчки мышью также могут продвигать эти слайды. Используйте файл `input.pptx` с минимум тремя слайдами.

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

Чтобы проверить, включено ли автоматическое продвижение, вызовите[ getAdvanceAfter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Хранимая задержка сама по себе не указывает, активен ли таймер.

Следующий пример открывает файл, сохранённый выше, сообщает о каждом включённом таймере и отключает автоматическое продвижение для слайдов с задержкой более двух секунд. Он включает щелчки мышью для этих слайдов и сохраняет обновлённые настройки.

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

Используйте[ setDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setDuration) для указания точной длины эффекта перехода в миллисекундах. Метод[ getSlideShowTransition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getSlideShowTransition) слайда раскрывает эти настройки через[ SlideShowTransition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/):

| Метод | Описание |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setDuration) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Задает задержку перед автоматическим продвижением слайда в миллисекундах. Передайте `True` в[ setAdvanceAfter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter), чтобы активировать таймер. |
| [setSpeed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setSpeed) | Выбирает предопределённую категорию скорости из[ TransitionSpeed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[setDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setDuration) управляет только эффектом перехода; он не определяет, как долго слайд остаётся видимым. Задержку автоматического продвижения настраивайте отдельно. Когда явная длительность не задана, Aspose.Slides определяет длительность эффекта по типу перехода и значению[ getSpeed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#getSpeed).

### **Применить одинаковую длительность ко всем слайдам**

Для равномерного темпа применяйте один и тот же эффект и точную длительность ко всем слайдам. Этот пример загружает `input.pptx`, выбирает Fade из[ TransitionType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitiontype/) и задаёт каждой переходу длительность 750 миллисекунд. Отдельно включается автоматическое продвижение после 5 000 миллисекунд и отключается продвижение щелчком мыши, затем сохраняется результат в PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Настройте автоматическое продвижение независимо от длительности эффекта.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Установить разные длительности для отдельных слайдов**

Разные слайды могут использовать разные длительности эффектов. Например, короткий переход для титульного слайда и более длительный для введения раздела. Этот пример задаёт 500 миллисекунд для первого слайда и 1 200 миллисекунд для второго. Используйте файл `input.pptx` с минимум двумя слайдами.

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

### **Координация переходов с анимированным выводом**

При подготовке[ animated GIF](/slides/ru/python-java/convert-powerpoint-to-animated-gif/),[ HTML5 presentation](/slides/ru/python-java/export-to-html5/)или[ video](/slides/ru/python-java/convert-powerpoint-to-video/) задавайте точные длительности переходов перед экспортом, чтобы соответствовать задуманному темпу. Например, используйте 600‑миллисекундный fade между сценами и отдельно регулируйте задержку продвижения каждого слайда, чтобы было время для озвучки или содержимого.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 миллисекунд соответствует 18 кадрам при 30 кадрах в секунду. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата и просмотрите результат для подтверждения синхронизации.

### **Чтение существующей длительности перехода**

Вызовите[ getDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#getDuration) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является вычисленной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение[ getSpeed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#getSpeed) для её расчёта. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

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

## **Переход Morph**

Переход Morph анимирует изменения объектов между последовательными слайдами. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта в клоне и примените переход Morph ко второму слайду. Это даёт переходу соответствующие объекты для анимации между их исходным и изменённым состоянием.

Следующий пример создаёт слайд с текстовым прямоугольником, клонирует его и меняет позицию и размер прямоугольника в клоне. Затем выбирает Morph из перечисления[ TransitionType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitiontype/) для второго слайда. Откройте сохранённый файл в просмотрщике, поддерживающем Morph, чтобы увидеть эффект во время показа.

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

## **Типы перехода Morph**

Перечисление[ TransitionMorphType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitionmorphtype/) управляет тем, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как целый объект.
- [ByWord](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя отдельные символы.

Используйте[ setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setType) для выбора Morph перед получением[ getValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#getValue). Затем значение будет экземпляром класса[ MorphTransition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/morphtransition/), у которого метод[ setMorphType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/morphtransition/#setMorphType) выбирает режим сопоставления.

Этот пример открывает презентацию, созданную в предыдущем разделе, и настраивает второй слайд для анимации Morph на основе слов.

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

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от перехода, выбранного через[ setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setType). Сначала задайте тип, затем используйте соответствующий класс из[ getValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#getValue).

Следующий пример применяет переход Cut к первому слайду `input.pptx`. Он вызывает[ setFromBlack](https://reference.aspose.com/slides/ru/python-java/aspose.slides/optionalblacktransition/#setFromBlack) через[ OptionalBlackTransition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/optionalblacktransition/), чтобы переход начинался с чёрного экрана.

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

## **Часто задаваемые вопросы**

**Могу ли я контролировать скорость воспроизведения перехода слайда?**

Да. Предпочтительно используйте[ setDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setDuration), когда нужна точная длительность эффекта в миллисекундах. Используйте[ setSpeed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setSpeed), когда достаточно предопределённой категории[ TransitionSpeed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitionspeed/) — Slow, Medium или Fast — и явная длительность не задаётся. Эти настройки управляют эффектом перехода независимо от задержки автоматического продвижения.

**Можно ли прикрепить звук к переходу и заставить его зацикливаться?**

Да. Присвойте встроенный звук через[ setSound](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setSound), передайте значение StartSound из перечисления[ TransitionSoundMode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitionsoundmode/) в[ setSoundMode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setSoundMode) и включите[ setSoundLoop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setSoundLoop) с `True`. Звук будет зацикливаться до следующего звукового события в показе.

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Пройдитесь в цикле по коллекции[ getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides) презентации и вызовите[ setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#setType) с тем же значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы поведение было одинаковым для всех слайдов.

**Как проверить, какой переход сейчас установлен на слайде?**

Вызовите[ getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowtransition/#getType) у результата[ getSlideShowTransition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getSlideShowTransition) слайда. Он вернёт значение из перечисления[ TransitionType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/transitiontype/); None_ означает, что переход не применён.