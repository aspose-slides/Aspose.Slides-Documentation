---
title: Слайд
type: docs
weight: 10
url: /ru/php-java/examples/elements/slide/
keywords:
- слайд
- добавить слайд
- доступ к слайду
- индекс слайда
- клонировать слайд
- переставить слайды
- удалить слайд
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте слайдами в PHP с помощью Aspose.Slides: создавайте, клонируйте, переставляйте, скрывайте, задавайте фоны и размер, применяйте переходы и экспортируйте для PowerPoint и OpenDocument."
---
В этой статье представлены примеры, демонстрирующие работу со слайдами с использованием **Aspose.Slides for PHP via Java**. Вы узнаете, как добавлять, получать доступ, клонировать, переставлять и удалять слайды с помощью класса `Presentation`.

Каждый пример ниже содержит краткое объяснение, за которым следует фрагмент кода на PHP.

## **Добавить слайд**

Чтобы добавить новый слайд, сначала необходимо выбрать макет. В этом примере мы используем макет `Blank` и добавляем пустой слайд в презентацию.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Каждый слайд основан на макете, который сам основан на главном слайде.
        // Используйте макет Blank для создания нового слайда.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Добавьте новый пустой слайд, используя выбранный макет.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Подсказка:** Каждый макет слайда наследуется от главного слайда, который определяет общий дизайн и структуру заполнителей. На изображении ниже показано, как главные слайды и связанные с ними макеты организованы в PowerPoint.

![Отношения между главным слайдом и макетом](master-layout-slide.png)

## **Доступ к слайдам по индексу**

Вы можете получить доступ к слайдам, используя их индекс.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Получить слайд по индексу.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Клонировать слайд**

Этот пример показывает, как клонировать существующий слайд. Клон автоматически добавляется в конец коллекции слайдов.

```php
function cloneSlide() {
    // По умолчанию презентация содержит один пустой слайд.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Клонируйте первый слайд; он будет добавлен в конец презентации.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // Индекс клонированного слайда равен 1 (второй слайд в презентации).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Переставить слайды**

Вы можете изменить порядок слайдов, переместив один на новый индекс. В данном случае мы перемещаем слайд на первую позицию.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Переместить слайд в первую позицию (остальные смещаются вниз).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить слайд**

Чтобы удалить слайд, просто укажите его и вызовите `remove`. В этом примере слайды удаляются по индексу и по ссылке.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Удалить слайд по индексу.
        $presentation->getSlides()->removeAt(0);

        // Удалить слайд по ссылке.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```