---
title: Управление переходами слайдов в презентациях с использованием C++
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/cpp/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- расширенный переход слайда
- морф-переход
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как настроить переходы слайдов в Aspose.Slides для C++, с подробными пошаговыми инструкциями для презентаций PowerPoint и OpenDocument."
---

## **Добавить переход слайда**
Чтобы было проще понять, мы продемонстрировали использование Aspose.Slides for C++ для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты перехода на слайдах, но и настраивать поведение этих эффектов. Чтобы создать простой эффект перехода, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
1. Примените тип перехода Slide Transition к слайду, выбрав один из эффектов, предлагаемых Aspose.Slides for C++ через перечисление TransitionType.
1. Запишите изменённый файл презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Добавить расширенный переход слайда**
В предыдущем разделе мы применили простой эффект перехода к слайду. Теперь, чтобы сделать этот простой эффект более гибким и контролируемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
1. Примените тип перехода Slide Transition к слайду, выбрав один из эффектов, предлагаемых Aspose.Slides for C++.
1. Вы можете также установить переход «Advance On Click», после определённого периода времени или оба варианта одновременно.
1. Если переход слайда включён как «Advance On Click», он будет продвигаться только при щелчке мышью. Кроме того, если свойство «Advance After Time» задано, переход будет автоматически продвигаться после истечения указанного времени.
1. Запишите изменённую презентацию в файл презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph-переход**
Aspose.Slides for C++ теперь поддерживает Morph‑переход. Это новый тип перехода, представленный в PowerPoint 2019. Morph‑переход позволяет анимировать плавное перемещение от одного слайда к другому. Эта статья описывает концепцию и способы использования Morph‑перехода. Для эффективного применения Morph‑перехода вам понадобится два слайда с хотя бы одним общим объектом. Самый простой способ – дублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с некоторым текстом в презентацию и установить тип перехода morph для второго слайда.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Типы Morph‑переходов**
Было добавлено новое перечисление Aspose.Slides.SlideShow.TransitionMorphType. Оно представляет различные типы Morph‑переходов слайда.

Перечисление TransitionMorphType имеет три члена:

- ByObject: Morph‑переход будет выполнен с учётом фигур как неделимых объектов.
- ByWord: Morph‑переход будет выполнен с переносом текста по словам, где это возможно.
- ByChar: Morph‑переход будет выполнен с переносом текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить Morph‑переход для слайда и изменить тип morph:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Установить эффекты перехода**
Aspose.Slides for C++ поддерживает установку эффектов перехода, таких как «из чёрного», «слева», «справа» и т. д. Чтобы задать эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса Presentation.
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию в файл PPTX.

В приведённом ниже примере мы задали эффекты перехода.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Можно ли контролировать скорость воспроизведения перехода слайда?**

Да. Установите [speed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) перехода, используя настройку [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) (например, slow/medium/fast).

**Можно ли прикрепить звук к переходу и заставить его зацикливаться?**

Да. Вы можете внедрить звук для перехода и управлять его поведением через настройки, такие как режим звука и зацикливание (например, [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/)), а также метаданные, такие как [set_SoundIsBuiltIn](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) и [set_SoundName](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/).

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одинакового типа ко всем слайдам даст одинаковый результат.

**Как проверить, какой переход в данный момент установлен на слайде?**

Осмотрите [настройки перехода слайда](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_slideshowtransition/) и прочитайте его [тип перехода](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); это значение точно указывает, какой эффект применён.