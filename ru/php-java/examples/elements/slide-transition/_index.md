---
title: ПереходСлайда
type: docs
weight: 110
url: /ru/php-java/examples/elements/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- доступ к переходу слайда
- удалить переход слайда
- длительность перехода
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте переходами слайдов в PHP с помощью Aspose.Slides: выбирайте типы, скорость, звук и тайминг, чтобы совершенствовать презентации в PPT, PPTX и ODP."
---
Показывает применение эффектов переходов слайдов и таймингов с помощью **Aspose.Slides for PHP via Java**.

## **Добавить переход слайда**

Примените эффект плавного перехода к первому слайду.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Применить плавный переход.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Доступ к переходу слайда**

Прочитайте тип перехода, назначенный слайду.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Доступ к типу перехода.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить переход слайда**

Очистите любой эффект перехода, установив тип в `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Удалить переход, установив none.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Установить длительность перехода**

Укажите, как долго слайд отображается перед автоматическим переходом.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // в миллисекундах.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```