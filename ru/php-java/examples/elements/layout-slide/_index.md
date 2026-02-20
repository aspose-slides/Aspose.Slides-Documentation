---
title: Слайд макета
type: docs
weight: 20
url: /ru/php-java/examples/elements/layout-slide/
keywords:
- слайд макета
- добавить слайд макета
- доступ к слайду макета
- удалить слайд макета
- неиспользуемый слайд макета
- клонировать слайд макета
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Используйте PHP для управления слайдами макетов с помощью Aspose.Slides: создавайте, применяйте, клонируйте, переименовывайте и настраивайте заполнители и темы в презентациях для PPT, PPTX и ODP."
---
В этой статье показано, как работать с **Layout Slides** в Aspose.Slides для PHP через Java. Слайд макета определяет дизайн и форматирование, наследуемое обычными слайдами. Вы можете добавлять, получать доступ, клонировать и удалять слайды макетов, а также очищать неиспользуемые, чтобы уменьшить размер презентации.

## **Добавить слайд макета**

Вы можете создать пользовательский слайд макета для определения повторно используемого форматирования. Например, вы можете добавить текстовое поле, которое будет отображаться на всех слайдах, использующих этот макет.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Создайте слайд макета с типом пустого макета и пользовательским именем.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Совет 1:** Слайды макетов выступают в роли шаблонов для отдельных слайдов. Вы можете определить общие элементы один раз и повторно использовать их на многих слайдах.
> 
> 💡 **Совет 2:** Когда вы добавляете фигуры или текст в слайд макета, все слайды, основанные на этом макете, автоматически отображают этот общий контент.
> 
> Скриншот ниже показывает два слайда, каждый из которых наследует текстовое поле из одного и того же слайда макета.

![Слайды, наследующие содержимое макета](layout-slide-result.png)


## **Получить доступ к слайду макета**

К слайдами макетов можно получить доступ по индексу или по типу макета (например, `Blank`, `Title`, `SectionHeader` и т.д.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Доступ по индексу.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Доступ по типу макета.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить слайд макета**

Вы можете удалить конкретный слайд макета, если он больше не нужен.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Получить слайд макета по типу и удалить его.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить неиспользуемые слайды макетов**

Чтобы уменьшить размер презентации, вы можете удалить слайды макетов, которые не используются ни одним обычным слайдом.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Автоматически удаляет все слайды макетов, на которые не ссылаются никакие слайды.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Клонировать слайд макета**

Вы можете дублировать слайд макета, используя метод `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Получить существующий слайд макета по типу.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Клонировать слайд макета в конец коллекции слайдов макетов.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Итог:** Слайды макетов — мощный инструмент для управления единообразным форматированием на всех слайдах. Aspose.Slides предоставляет полный контроль над созданием, управлением и оптимизацией слайдов макетов.