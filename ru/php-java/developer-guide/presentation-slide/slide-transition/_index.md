---
title: Управление переходами слайдов в презентациях с использованием PHP
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/php-java/slide-transition/
keywords:
- переход слайда
- добавление перехода слайда
- применение перехода слайда
- расширенный переход слайда
- морф-переход
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как настраивать переходы слайдов в Aspose.Slides для PHP через Java, получив пошаговые инструкции для презентаций PowerPoint и OpenDocument."
---

## **Обзор**
{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java также позволяет разработчикам управлять и настраивать эффекты переходов слайдов. В этой теме мы рассмотрим управление переходами слайдов с большой легкостью, используя Aspose.Slides for PHP via Java.
{{% /alert %}} 
Чтобы упростить понимание, мы продемонстрировали использование Aspose.Slides for PHP via Java для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты переходов к слайдам, но и настраивать поведение этих эффектов.

## **Добавить переход слайда**
Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Примените тип перехода слайда, выбрав один из эффектов переходов, предлагаемых Aspose.Slides for PHP via Java, через перечисление TransitionType.
3. Запишите изменённый файл презентации.
```php
  # Создать экземпляр класса Presentation для загрузки исходного файла презентации
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Применить переход типа circle на слайде 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Применить переход типа comb на слайде 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Записать презентацию на диск
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Добавить расширенный переход слайда**
В предыдущем разделе мы применили простой эффект перехода к слайду. Теперь, чтобы улучшить и контролировать этот эффект, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Примените тип перехода слайда, выбрав один из эффектов переходов, предлагаемых Aspose.Slides for PHP via Java.
3. Вы также можете установить переход «Advance On Click», через определённый промежуток времени или оба варианта.
4. Если переход слайда включён «Advance On Click», он будет продвигаться только при щелчке мышью. Кроме того, если установлено свойство «Advance After Time», переход будет происходить автоматически после указанного времени.
5. Запишите изменённую презентацию как файл презентации.
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Применить переход типа circle на слайде 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Установить время перехода 3 секунды
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Применить переход типа comb на слайде 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Установить время перехода 5 секунд
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Применить переход типа zoom на слайде 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Установить время перехода 7 секунд
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Записать презентацию на диск
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Морф‑переход**
{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java теперь поддерживает [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/). Это новый морф‑переход, представленный в PowerPoint 2019.
{{% /alert %}} 
Морф‑переход позволяет анимировать плавное перемещение от одного слайда к другому. В этой статье описывается концепция и способы использования морф‑перехода. Чтобы эффективно использовать морф‑переход, вам нужны два слайда с хотя бы одним общим объектом. Самый простой способ – дублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода демонстрирует, как добавить клон слайда с текстом в презентацию и установить переход типа [morph type](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) для второго слайда.
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


## **Типы морф‑переходов**
Новый перечисление [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) добавлено. Оно представляет различные типы морф‑переходов слайда.

Перечисление TransitionMorphType имеет три члена:

- ByObject: морф‑переход будет выполнен с учётом фигур как неделимых объектов.
- ByWord: морф‑переход будет выполнен с передачей текста по словам, где это возможно.
- ByChar: морф‑переход будет выполнен с передачей текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить морф‑переход для слайда и изменить тип морфа:
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


## **Установить эффекты перехода**
Aspose.Slides for PHP via Java поддерживает установку эффектов перехода, таких как «from black», «from left», «from right» и др. Чтобы задать эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/)​.

В приведённом ниже примере мы задали эффекты перехода.
```php
  # Создать экземпляр класса Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Установить эффект
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Записать презентацию на диск
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**Могу ли я контролировать скорость воспроизведения перехода слайда?**  
Да. Установите [speed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) перехода с помощью настройки [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (например, slow/medium/fast).

**Могу ли я прикрепить аудио к переходу и сделать его зацикленным?**  
Да. Вы можете встроить звук в переход и управлять его поведением через параметры, такие как режим звука и зацикливание (например, [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/), а также метаданные, такие как [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) и [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**  
Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одинакового типа ко всем слайдам дает единообразный результат.

**Как я могу проверить, какой переход сейчас установлен на слайде?**  
Осмотрите [transition settings](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/); это значение точно указывает, какой эффект применён.