---
title: Переход слайдов
type: docs
weight: 80
url: /php-java/slide-transition/
keywords: "Переход слайдов PowerPoint, морфный переход"
description: "Переход слайдов PowerPoint, морфный переход PowerPoint"
---


## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides для PHP через Java также позволяет разработчикам управлять или настраивать эффекты перехода слайдов. В этой теме мы обсудим управление переходами слайдов с легкостью, используя Aspose.Slides для PHP через Java.

{{% /alert %}} 

Чтобы сделать это понятнее, мы продемонстрировали использование Aspose.Slides для PHP через Java для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты перехода слайдов, но также настраивать поведение этих эффектов перехода.

## **Добавить переход слайда**
Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Примените тип перехода слайда с одного из эффектов перехода, предлагаемых Aspose.Slides для PHP через Java через перечисление TransitionType.
1. Запишите модифицированный файл презентации.

```php
  # Создайте экземпляр класса Presentation для загрузки исходного файла презентации
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Примените переход типа круг к слайду 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Примените переход типа гребенки к слайду 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Запишите презентацию на диск
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Добавить сложный переход слайда**
В предыдущем разделе мы просто применили простой эффект перехода к слайду. Теперь, чтобы сделать этот простой эффект перехода еще более интересным и управляемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Примените тип перехода слайда с одного из эффектов перехода, предлагаемых Aspose.Slides для PHP через Java.
1. Вы также можете установить переход на "Продолжить по клику", после определенного времени или и то, и другое.
1. Если переход слайда включен для "Продолжить по клику", переход будет продвигаться только при нажатии мыши. Более того, если свойство "Продолжить после времени" установлено, переход будет автоматически продвигаться после истечения указанного времени.
1. Запишите модифицированную презентацию в виде файла презентации.

```php
  # Создайте экземпляр класса Presentation, который представляет файл презентации
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Примените переход типа круг к слайду 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Установите время перехода 3 секунды
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Примените переход типа гребенки к слайду 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Установите время перехода 5 секунд
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Примените переход типа зум к слайду 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Установите время перехода 7 секунд
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Запишите презентацию на диск
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Морфный переход**
{{% alert color="primary" %}} 

Aspose.Slides для PHP через Java теперь поддерживает [морфный переход](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). Он представляет собой новый морфный переход, введенный в PowerPoint 2019.

{{% /alert %}} 

Морфный переход позволяет анимировать плавное движение от одного слайда к следующему. Эта статья описывает концепцию и то, как использовать морфный переход. Чтобы эффективно использовать морфный переход, вам понадобятся два слайда с как минимум одним общим объектом. Легче всего продублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с некоторым текстом в презентацию и установить переход [морфного типа](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) на второй слайд.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Морфный переход в презентациях PowerPoint");
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

## **Типы морфного перехода**
Новая перечисление [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) была добавлена. Оно представляет собой различные типы морфных переходов слайдов.

Перечисление TransitionMorphType имеет три члена:

- ByObject: морфный переход будет выполнен с учетом фигур как неделимых объектов.
- ByWord: морфный переход будет выполнен с переносом текста по словам, где это возможно.
- ByChar: морфный переход будет выполнен с переносом текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить морфный переход на слайд и изменить тип морфа:

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
Aspose.Slides для PHP через Java поддерживает установку эффектов перехода, таких как "с черного", "слева", "справа" и т.д. Для установки эффекта перехода выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию в виде файла [PPTX](https://docs.fileformat.com/presentation/pptx/).

В приведенном ниже примере мы установили эффекты перехода.

```php
  # Создайте экземпляр класса Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Установите эффект
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Запишите презентацию на диск
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```