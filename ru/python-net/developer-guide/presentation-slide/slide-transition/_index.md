---
title: Переход слайда
type: docs
weight: 90
url: /ru/python-net/slide-transition/
keywords: "Добавить переход слайда, переход слайда PowerPoint, морфический переход, расширенный переход слайда, эффекты перехода, Python, Aspose.Slides"
description: " Добавьте переход слайда PowerPoint и эффекты перехода в Python "
---

## **Добавить переход слайда**
Чтобы облегчить понимание, мы продемонстрировали использование Aspose.Slides для Python через .NET для управления простыми переходами слайдов. Разработчики могут не только применять разные эффекты перехода на слайдах, но и настраивать поведение этих эффектов перехода. Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Примените тип перехода слайда к слайду из одного из эффектов перехода, предложенных Aspose.Slides для Python через .NET, через перечисление TransitionType.
1. Запишите изменённый файл презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для загрузки исходного файла презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Примените переход типа круг к слайду 1
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Примените переход типа комб к слайду 2
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Запишите презентацию на диск
    presentation.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавить расширенный переход слайда**
В предыдущем разделе мы просто применили простой эффект перехода к слайду. Теперь, чтобы сделать этот простой эффект перехода еще лучше и контролируемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Примените тип перехода слайда к слайду из одного из эффектов перехода, предложенных Aspose.Slides для Python через .NET.
1. Вы также можете установить переход на "Продолжить по щелчку", после определённого времени или и то, и другое.
1. Если переход слайда активирован для "Продолжить по щелчку", переход будет продолжаться только когда кто-то щелкнет мышью. Более того, если свойство "Продолжить после времени" установлено, переход будет автоматически продолжен после истечения указанного времени.
1. Запишите изменённую презентацию как файл презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, который представляет файл презентации
with slides.Presentation(path + "BetterSlideTransitions.pptx") as pres:
    # Примените переход типа круг к слайду 1
    pres.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Установите время перехода в 3 секунды
    pres.slides[0].slide_show_transition.advance_on_click = True
    pres.slides[0].slide_show_transition.advance_after_time = 3000

    # Примените переход типа комб к слайду 2
    pres.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Установите время перехода в 5 секунд
    pres.slides[1].slide_show_transition.advance_on_click = True
    pres.slides[1].slide_show_transition.advance_after_time = 5000

    # Примените переход типа зум к слайду 3
    pres.slides[2].slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Установите время перехода в 7 секунд
    pres.slides[2].slide_show_transition.advance_on_click = True
    pres.slides[2].slide_show_transition.advance_after_time = 7000

    # Запишите презентацию на диск
    pres.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Морфический переход**
Aspose.Slides для Python через .NET теперь поддерживает [Морфический переход](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/). Они представляют собой новый морфический переход, введённый в PowerPoint 2019. Морфический переход позволяет анимировать плавное движение от одного слайда к следующему. Эта статья описывает концепцию и то, как использовать морфический переход. Чтобы эффективно использовать морфический переход, вам нужно иметь два слайда с по крайней мере одним общим объектом. Самый простой способ - дублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с некоторым текстом в презентацию и установить морфический тип перехода [morph type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/) ко второму слайду.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoshape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    autoshape.text_frame.text = "Морфический переход в презентациях PowerPoint"

    presentation.slides.add_clone(presentation.slides[0])

    presentation.slides[1].shapes[0].x += 100
    presentation.slides[1].shapes[0].y += 50
    presentation.slides[1].shapes[0].width -= 200
    presentation.slides[1].shapes[0].height -= 10

    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Типы морфических переходов**
Новая [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) перечисление было добавлено. Оно представляет различные типы морфических переходов слайда.

Перечисление TransitionMorphType имеет три члена:

- ByObject: морфический переход будет выполняться, принимая во внимание формы как неделимые объекты.
- ByWord: морфический переход будет выполняться с передачей текста по словам, где это возможно.
- ByChar: морфический переход будет выполняться с передачей текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить морфический переход на слайд и изменить тип морфинга:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    presentation.slides[0].slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить эффекты перехода**
Aspose.Slides для Python через .NET поддерживает установку эффектов перехода, таких как, с черного, слева, справа и т.д. Для установки эффекта перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию как файл [PPTX ](https://docs.fileformat.com/presentation/pptx/).

В приведенном ниже примере мы установили эффекты перехода.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:

    # Установите эффект
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CUT
    presentation.slides[0].slide_show_transition.value.from_black = True

    # Запишите презентацию на диск
    presentation.save("SetTransitionEffects_out.pptx", slides.export.SaveFormat.PPTX)
```