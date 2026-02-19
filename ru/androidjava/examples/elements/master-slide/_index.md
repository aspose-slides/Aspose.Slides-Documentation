---
title: Мастер‑слайд
type: docs
weight: 30
url: /ru/androidjava/examples/elements/master-slide/
keywords:
- пример кода
- мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Изучите примеры мастер‑слайдов Aspose.Slides для Android: создавайте, редактируйте и оформляйте мастера, заполнители и темы в PPT, PPTX и ODP с понятным кодом Java."
---
Мастер‑слайды находятся на верхнем уровне иерархии наследования слайдов в PowerPoint. **Мастер‑слайд** определяет общие элементы дизайна, такие как фон, логотипы и форматирование текста. **Слайды‑макеты** наследуются от мастер‑слайдов, а **обычные слайды** — от слайдов‑макетов.

В этой статье показано, как создавать, изменять и управлять мастер‑слайдами с помощью Aspose.Slides for Android через Java.

## **Добавление мастер‑слайда**

В этом примере демонстрируется создание нового мастер‑слайда путём клонирования стандартного. Затем через наследование макетов к каждому слайду добавляется баннер с названием компании.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Клонировать стандартный мастер‑слайд.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Добавить баннер с названием компании в верхнюю часть мастер‑слайда.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Назначить новый мастер‑слайд слайду‑макету.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Назначить слайд‑макет первым слайдом презентации.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Примечание 1:** Мастер‑слайды позволяют применять согласованный брендинг или общие элементы дизайна ко всем слайдам. Любые изменения в мастере автоматически отразятся на зависимых макетах и обычных слайдах.

> 💡 **Примечание 2:** Все фигуры и форматирование, добавленные в мастер‑слайд, наследуются слайдами‑макетами и, в свою очередь, всеми обычными слайдами, использующими эти макеты.  
> Ниже изображено, как текстовое поле, добавленное в мастер‑слайд, автоматически отображается на конечном слайде.

![Пример наследования мастер‑слайда](master-slide-banner.png)

## **Доступ к мастер‑слайду**

К мастер‑слайдам можно получить через коллекцию мастеров презентации. Ниже показано, как их извлечь и работать с ними:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Изменить тип фона.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Удаление мастер‑слайда**

Мастер‑слайды можно удалять как по индексу, так и по ссылке.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Удалить мастер‑слайд по индексу.
        presentation.getMasters().removeAt(0);

        // Удалить мастер‑слайд по ссылке.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Удаление неиспользуемых мастер‑слайдов**

В некоторых презентациях присутствуют мастер‑слайды, которые не используются. Удаление таких слайдов помогает уменьшить размер файла.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Удалить все неиспользуемые мастер‑слайды (включая помеченные как Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```