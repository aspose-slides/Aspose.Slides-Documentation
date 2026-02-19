---
title: Раздел
type: docs
weight: 90
url: /ru/nodejs-java/examples/elements/section/
keywords:
- пример кода
- раздел
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте разделами слайдов в Aspose.Slides for Node.js via Java: создавайте, переименовывайте, меняйте порядок и группируйте слайды с примерами JavaScript для PPT, PPTX и ODP."
---
Примеры управления разделами презентации — добавление, доступ, удаление и переименование их программно с использованием **Aspose.Slides for Node.js via Java**.

## **Добавить раздел**

Создайте раздел, начинающийся с определённого слайда.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Укажите слайд, который помечает начало раздела.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к разделу**

Прочитайте информацию о разделе из презентации.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Получить доступ к разделу по индексу.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить раздел**

Удалите ранее добавленный раздел.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Удалить первый раздел.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Переименовать раздел**

Измените имя существующего раздела.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```