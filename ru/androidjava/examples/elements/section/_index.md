---
title: Секция
type: docs
weight: 90
url: /ru/androidjava/examples/elements/section/
keywords:
- пример кода
- секция
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте секциями слайдов в Aspose.Slides for Android: создавайте, переименовывайте, меняйте порядок и группируйте слайды с примерами Java для PPT, PPTX и ODP."
---
Примеры управления секциями презентации — добавление, доступ, удаление и переименование их программно с использованием **Aspose.Slides for Android via Java**.

## **Добавить секцию**

Создайте секцию, начинающуюся с определённого слайда.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Укажите слайд, который отмечает начало секции.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к секции**

Прочитайте информацию о секции из презентации.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        //        Получить доступ к секции по индексу.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить секцию**

Удалите ранее добавленную секцию.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Удалить первую секцию.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Переименовать секцию**

Измените название существующей секции.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```