---
title: Управляйте переходами слайдов в презентациях с использованием PHP
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/php-java/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- расширенный переход слайда
- морф‑переход
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как настраивать переходы слайдов в Aspose.Slides for PHP via Java с пошаговым руководством для презентаций PowerPoint и OpenDocument."
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java также позволяет разработчикам управлять или настраивать эффекты переходов между слайдами. В этой статье мы расскажем о простом управлении переходами между слайдами с использованием Aspose.Slides for PHP via Java.

{{% /alert %}} 

Для более лёгкого восприятия мы продемонстрировали использование Aspose.Slides for PHP via Java для управления простыми переходами между слайдами. Разработчики могут не только применять разные эффекты переходов к слайдам, но и настраивать поведение этих эффектов.

## **Добавление перехода слайда**
Чтобы создать простой эффект перехода между слайдами, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Примените тип перехода к слайду, выбрав один из эффектов, предлагаемых Aspose.Slides for PHP via Java, через перечисление TransitionType.
1. Запишите изменённый файл презентации.
```php
  # Создать экземпляр класса Presentation для загрузки исходного файла презентации
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Применить переход типа «Circle» к слайду 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Применить переход типа «Comb» к слайду 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Сохранить презентацию на диск
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Добавление расширенного перехода слайда**
В предыдущем разделе мы применили простой эффект перехода к слайду. Чтобы улучшить и более точно контролировать этот эффект, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Примените тип перехода к слайду, выбрав один из эффектов, предлагаемых Aspose.Slides for PHP via Java.
1. Вы можете задать переход «Advance On Click», «Advance After Time» или оба варианта одновременно.
1. Если переход включён с «Advance On Click», он будет происходить только после клика мышью. Если установлен параметр «Advance After Time», переход будет происходить автоматически после истечения указанного времени.
1. Запишите изменённую презентацию в файл.
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Применить переход типа circle к слайду 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Установить время перехода 3 секунды
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Применить переход типа comb к слайду 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Установить время перехода 5 секунд
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Применить переход типа zoom к слайду 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Установить время перехода 7 секунд
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Сохранить презентацию на диск
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Morph‑переход**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java теперь поддерживает [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). Это новый тип перехода, введённый в PowerPoint 2019.

{{% /alert %}} 

Morph‑переход позволяет анимировать плавное перемещение от одного слайда к другому. В статье описывается концепция и способы использования Morph‑перехода. Для эффективного применения Morph‑перехода вам потребуются два слайда с хотя бы одним общим объектом. Самый простой способ — дублировать слайд и переместить объект на втором слайде в другое место.

Ниже приведён фрагмент кода, показывающий, как добавить клон слайда с текстом в презентацию и установить переход типа [morph](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) на второй слайд.
```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Типы Morph‑переходов**
Добавлено новое перечисление [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType). Оно представляет различные типы Morph‑переходов между слайдами.

Перечисление TransitionMorphType имеет три члена:

- ByObject: Morph‑переход будет выполнен с учётом фигур как неделимых объектов.
- ByWord: Morph‑переход будет выполнен с передачей текста по словам, где это возможно.
- ByChar: Morph‑переход будет выполнен с передачей текста по символам, где это возможно.

Ниже показан фрагмент кода, демонстрирующий, как задать Morph‑переход для слайда и изменить тип Morph‑перехода:
```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Установка эффектов перехода**
Aspose.Slides for PHP via Java поддерживает установку эффектов перехода, таких как «from black», «from left», «from right» и т.д. Чтобы задать эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

В примере ниже показана установка эффектов перехода.
```php
  # Создать экземпляр класса Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Установить эффект
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Сохранить презентацию на диск
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Установите [speed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) перехода с помощью параметра [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (например, slow/medium/fast).

**Можно ли прикрепить аудио к переходу и заставить его зацикливаться?**

Да. Вы можете встроить звук в переход и управлять его поведением через параметры, такие как режим звука и зацикливание (например, [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/), а также метаданные вроде [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) и [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому установка одинакового типа для всех слайдов обеспечит единообразный результат.

**Как проверить, какой переход установлен для конкретного слайда?**

Изучите [transition settings](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/); это значение точно указывает, какой эффект применяется.