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
- переход Morph
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и кастомизируйте Morph и другие эффекты переходов с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды появляются во время демонстрации. С помощью Aspose.Slides for Python via Java вы можете выбрать эффект перехода для каждого слайда, настроить переход по щелчку мыши или таймеру и изменить параметры, специфичные для эффекта. В этой статье используются примеры на Python для применения переходов, установки точной длительности перехода, управления временем показа слайда и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавить переход слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и получите настройки перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Используйте [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) со значением из перечисления [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), затем сохраните презентацию.

В следующем примере к первому слайду применяется переход Circle, а ко второму — Comb. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

Используйте [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), чтобы выбрать Wheel из [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Затем вызовите [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue), чтобы получить настройки [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Его метод [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) управляет количеством радиальных секторов, раскрывающих целевой слайд.

Пример создает две одинаковые пары слайдов. Каждая пара начинается чёрным слайдом и заканчивается золотым прямоугольником на весь слайд. Оба целевых слайда используют одинаковую медленную скорость, установленную через [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed), и одинаковую явную длительность 8 000 миллисекунд, установленную через [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Меняется только количество спиц.

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

Откройте `wheel-transitions.pptx` в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, чтобы увидеть одно вращающееся раскрытие золотого прямоугольника. Затем перейдите со слайда 3 на слайд 4, чтобы увидеть восемь радиальных секторов, раскрывающих тот же прямоугольник одновременно.

## **Fade Through Black with the Reveal Transition**

Установите тип перехода целевого слайда в Reveal, затем вызовите [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) у его настроек [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/). Пример создаёт бирюзовый исходный слайд и коралловый целевой слайд, после чего клонирует их. Каждая пара использует один и тот же двухсекундный переход Reveal. Только вторая пара затемняется через чёрный цвет.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Откройте `reveal-transitions.pptx` в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, чтобы увидеть плавный переход бирюзового в коралловый. Затем перейдите со слайда 3 на слайд 4. Экран на мгновение затемняется почти до чёрного, после чего появляется коралловый слайд. Оба слайда сохраняют исходные цвета фона.

Ниже показаны кадры PowerPoint с интервалом полсекунды. Сравните средний кадр в каждой строке, чтобы увидеть эффект.

![Воспроизведение PowerPoint с отключённым (вверху) и включённым (внизу) затемнением через чёрный. Только нижняя строка проходит через почти чёрный.](reveal-through-black.png)

## **Add Advanced Slide Transition**

Вы можете настроить, как долго слайд остаётся на экране и будет ли щелчок мышью переключать показ слайдов. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) позволяет зрителю продвигать показ щелчком мыши.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) включает автоматический переход.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) задаёт задержку перед автоматическим переходом в миллисекундах.

Включите как щелчок, так и таймер, чтобы зритель мог перейти по щелчку или ждать таймера. Чтобы использовать только таймер, передайте `False` в [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Задержка управляет моментом перехода показом; она не задаёт длительность визуального эффекта перехода.

Этот пример назначает разные эффекты первым трём слайдам и включает автоматический переход через 3, 5 и 7 секунд соответственно. Щелчки мыши также могут продвигать эти слайды. Используйте файл `input.pptx` с как минимум тремя слайдами.

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

Чтобы проверить, включён ли таймер, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Сохранённая задержка сама по себе не указывает, активен ли таймер.

Следующий пример открывает файл, сохранённый выше, выводит каждый включённый таймер и отключает автоматический переход для слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мыши, после чего настройки сохраняются.

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

## **Control Transition Timing Precisely**

Используйте [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), чтобы задать точную продолжительность эффекта перехода в миллисекундах. Метод слайда [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) раскрывает эти настройки через класс [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Метод | Описание |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Задает задержку перед автоматическим переходом слайда в миллисекундах. Передайте `True` в [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter), чтобы активировать этот таймер. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) управляет только эффектом перехода; он не определяет, как долго слайд остаётся видимым. Настройте задержку автоматического перехода отдельно. Когда явная длительность не указана, Aspose.Slides определяет её исходя из типа перехода и значения [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Отдельные полосы указывают длительность перехода 750 мс и настройку автоматического перехода 5 000 мс.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Пример показывает, как каждому слайду задаётся 750‑мс переход Fade и отдельно включается автоматический переход через 5 000 мс. Длительность перехода управляет эффектом; автоматический переход — моментом выхода со слайда. Эти полосы являются схематичными настройками, а не измеренной общей шкалой времени.*
<!-- visual-explanation:slide-transition:end -->

### **Применить одинаковую длительность ко всем слайдам**

Для обеспечения одинакового темпа примените один и тот же эффект и точную длительность ко всем слайдам. Этот пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) и задаёт каждой смене длительность 750 мс. Он отдельно включает автоматический переход после 5 000 мс и отключает переход по щелчку мыши, затем сохраняет результат в PPTX.

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

        # Настройте автоматическое продвижение независимо от длительности эффекта.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Установить разные длительности для отдельных слайдов**

Разные слайды могут использовать разные длительности эффекта. Например, короткий переход для титульного слайда и более длительный для вводного раздела. Этот пример задаёт 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

При подготовке [animated GIF](/slides/ru/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/python-java/export-to-html5/) или [video](/slides/ru/python-java/convert-powerpoint-to-video/) задайте точные длительности переходов перед экспортом, чтобы соответствовать задуманному темпу. Например, используйте 600‑мс затухание между сценами и задайте отдельную задержку перехода каждого слайда, позволяя времени для озвучки или содержимого.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствуют 18 кадрам при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата и просмотрите результат для подтверждения синхронизации.

### **Прочитать существующую длительность перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) для определения этой длительности. Установка типа перехода может инициализировать длительность, поэтому сначала изучите оригинальные настройки.

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

## **Morph Transition**

Переход Morph анимирует изменения объектов между последовательными слайдами. Чтобы создать простой эффект Morph, склонируйте слайд, переместите или измените размер объекта на копии и примените переход Morph ко второму слайду. Это позволяет анимировать соответствующие объекты между их исходным и изменённым состоянием.

Следующий пример создаёт слайд с текстовым прямоугольником, клонирует его и меняет позицию и размер прямоугольника в копии. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа слайдов.

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

## **Morph Transition Types**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) управляет тем, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как единый объект.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя символы, где это возможно.

Используйте [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), чтобы выбрать Morph перед получением [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Полученное значение будет экземпляром класса [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), чей метод [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) выбирает режим сопоставления.

Этот пример открывает презентацию, созданную в предыдущем разделе, и настраивает второй слайд для анимации Morph по словам.

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

## **Set Transition Effects**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от перехода, выбранного с помощью [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Сначала задайте тип, затем используйте соответствующий класс, получаемый через [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

В следующем примере применяется переход Cut к первому слайду `input.pptx`. Он вызывает [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) через класс [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/), чтобы переход начинался с чёрного экрана.

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

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Предпочтительно используйте [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), когда требуется точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed), если достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) — Slow, Medium или Fast — и явная длительность не задаётся. Эти настройки управляют эффектом перехода независимо от задержки автоматического перехода.

**Можно ли прикрепить звук к переходу и заставить его зацикливаться?**

Да. Назначьте встроенный звук с помощью [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), передайте `StartSound` из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) и включите [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) со значением `True`. Звук будет зацикливаться до следующего звукового события в показе слайдов.

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Пройдитесь циклом по коллекции [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) презентации и вызовите [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) с одинаковым значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы поведение было одинаковым для всех слайдов.

**Как проверить, какой переход установлен в данный момент на слайде?**

Вызовите [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) у результата [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) слайда. Он возвращает значение из перечисления [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); `None_` означает, что переход не применён.