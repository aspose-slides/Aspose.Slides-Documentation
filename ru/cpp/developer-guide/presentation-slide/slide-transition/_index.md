---
title: Переход между слайдами
type: docs
weight: 80
url: /ru/cpp/slide-transition/
keywords: "Переход слайда PowerPoint, морфный переход"
description: "Переход слайда PowerPoint, морфный переход PowerPoint с помощью Aspose.Slides."
---


## **Добавить переход между слайдами**
Чтобы сделать это понятнее, мы продемонстрировали использование Aspose.Slides для C++ для управления простыми переходами между слайдами. Разработчики могут не только применять различные эффекты перехода между слайдами, но и настраивать поведение этих эффектов. Чтобы создать простой эффект перехода между слайдами, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Примените тип перехода слайда на слайде из одного из эффектов перехода, предлагаемых Aspose.Slides для C++ через перечисление TransitionType.
1. Запишите измененный файл презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Добавить сложный переход между слайдами**
В предыдущем разделе мы просто применили простой эффект перехода на слайде. Теперь, чтобы сделать этот простой эффект перехода еще лучше и более контролируемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Примените тип перехода слайда на слайде из одного из эффектов перехода, предлагаемых Aspose.Slides для C++.
1. Вы также можете установить переход на «Автоматический при клике», через определенный период времени или то и другое.
1. Если переход на слайде включен для «Автоматического при клике», переход будет осуществляться только при клике мыши. Более того, если установлено свойство «Автоматически через время», переход будет осуществляться автоматически после истечения заданного времени.
1. Запишите изменённую презентацию в качестве файла презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}


## **Морфный переход**
Aspose.Slides для C++ теперь поддерживает морфный переход. Они представляют собой новый морфный переход, внедренный в PowerPoint 2019. Морфный переход позволяет анимировать плавное движение от одного слайда к другому. Эта статья описывает концепцию и как использовать морфный переход. Чтобы эффективно использовать морфный переход, вам понадобятся два слайда с по крайней мере одним общим объектом. Проще всего дублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с некоторым текстом в презентацию и установить переход морфного типа для второго слайда.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Тип морфного перехода**
Добавлено новое перечисление Aspose.Slides.SlideShow.TransitionMorphType. Оно представляет собой различные типы морфного перехода слайда.

Перечисление TransitionMorphType имеет три члена:

- ByObject: Морфный переход будет осуществляться с учетом фигур как неделимых объектов.
- ByWord: Морфный переход будет осуществляться с передачей текста по словам, где это возможно.
- ByChar: Морфный переход будет осуществляться с передачей текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить морфный переход для слайда и изменить тип морфирования:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}


## **Установить эффекты перехода**
Aspose.Slides для C++ поддерживает установку эффектов перехода, таких как: от черного, слева, справа и т.д. Для установки эффекта перехода. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса Presentation.
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию в виде файла PPTX.

В приведенном ниже примере мы установили эффекты перехода.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}