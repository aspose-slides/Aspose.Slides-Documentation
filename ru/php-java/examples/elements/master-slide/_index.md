---
title: Мастер‑слайд
type: docs
weight: 30
url: /ru/php-java/examples/elements/master-slide/
keywords:
- мастер‑слайд
- добавить мастер‑слайд
- доступ к мастер‑слайду
- удалить мастер‑слайд
- неиспользуемый мастер‑слайд
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте мастер‑слайдами в PHP с помощью Aspose.Slides: создавайте, редактируйте, клонируйте и форматируйте темы, фон, заполнительные элементы, чтобы унифицировать слайды в PowerPoint и OpenDocument."
---
Мастер‑слайды образуют верхний уровень иерархии наследования слайдов в PowerPoint. **Мастер‑слайд** определяет общие элементы дизайна, такие как фон, логотипы и форматирование текста. **Слайды‑макеты** наследуются от мастер‑слайдов, а **обычные слайды** наследуются от слайдов‑макетов.

Эта статья демонстрирует, как создавать, изменять и управлять мастер‑слайдами с помощью Aspose.Slides for PHP via Java.

## **Добавить мастер‑слайд**

Этот пример показывает, как создать новый мастер‑слайд, клонировав стандартный.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Клонировать стандартный мастер‑слайд.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Совет 1:** Мастер‑слайды позволяют применять единый брендинг или общие элементы дизайна ко всем слайдам. Любые изменения в мастер‑слайде автоматически отражаются на зависимых макетах и обычных слайдах.

> 💡 **Совет 2:** Любые фигуры или форматирование, добавленные в мастер‑слайд, наследуются слайдами‑макетами и, в свою очередь, всеми обычными слайдами, использующими эти макеты.  
> Ниже изображение показывает, как текстовое поле, добавленное в мастер‑слайд, автоматически отображается на конечном слайде.

![Master Inheritance Example](master-slide-banner.png)

## **Получить доступ к мастер‑слайду**

Вы можете получить доступ к мастер‑слайдам с помощью метода `Presentation::getMasters`. Вот как их извлечь и работать с ними:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Доступ к первому мастер‑слайду.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить мастер‑слайд**

Мастер‑слайды можно удалять либо по индексу, либо по ссылке.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Удалить по индексу.
        $presentation->getMasters()->removeAt(0);

        // Или удалить по ссылке.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить неиспользуемые мастер‑слайды**

В некоторых презентациях присутствуют мастер‑слайды, которые не используются. Их удаление может помочь снизить размер файла.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Удалить все неиспользуемые мастер‑слайды (даже те, которые помечены как Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Совет:** Используйте `removeUnused(true)`, чтобы очистить неиспользуемые мастер‑слайды и минимизировать размер презентации.