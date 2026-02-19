---
title: Раздел
type: docs
weight: 90
url: /ru/java/examples/elements/section/
keywords:
- пример кода
- раздел
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте разделами слайдов в Aspose.Slides for Java: создавайте, переименовывайте, переупорядочивайте и группируйте слайды с примерами Java для PPT, PPTX и ODP."
---
Примеры управления секциями презентации — добавление, доступ, удаление и переименование программным способом с использованием **Aspose.Slides for Java**.

## **Add a Section**
Создайте секцию, начинающуюся с определённого слайда.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Укажите слайд, который отмечает начало раздела.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Section**
Прочитайте информацию о секции из презентации.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Доступ к разделу по индексу.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Section**
Удалите ранее добавленную секцию.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Удалить первый раздел.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Rename a Section**
Измените имя существующей секции.

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