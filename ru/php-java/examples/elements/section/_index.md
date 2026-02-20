---
title: Раздел
type: docs
weight: 90
url: /ru/php-java/examples/elements/section/
keywords:
- раздел
- раздел слайдов
- добавить раздел
- доступ к разделу
- удалить раздел
- переименовать раздел
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте разделами слайдов в PHP с помощью Aspose.Slides: создавайте, переименовывайте, легко изменяйте порядок, перемещайте слайды между разделами и контролируйте видимость для PPT, PPTX и ODP."
---
Примеры управления разделами презентации — добавление, доступ, удаление и переименование их программно с помощью **Aspose.Slides for PHP via Java**.

## **Добавить раздел**

Создайте раздел, который начинается с определённого слайда.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Укажите слайд, который отмечает начало раздела.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Доступ к разделу**

Прочитайте информацию о разделе из презентации.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Доступ к разделу по индексу.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить раздел**

Удалите ранее добавленный раздел.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Удалить раздел.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Переименовать раздел**

Измените имя существующего раздела.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```