---
title: Слайд‑шаблон
type: docs
weight: 30
url: /ru/java/examples/elements/master-slide/
keywords:
- пример кода
- слайд‑шаблон
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Изучите примеры слайдов‑шаблонов Aspose.Slides for Java: создавайте, редактируйте и оформляйте шаблоны, заполнители и темы в PPT, PPTX и ODP с понятным кодом Java."
---
Слайды‑шаблоны находятся на верхнем уровне иерархии наследования слайдов в PowerPoint. **Слайд‑шаблон** определяет общие элементы дизайна, такие как фон, логотипы и форматирование текста. **Слайды‑компоновки** наследуются от слайдов‑шаблонов, а **обычные слайды** наследуются от слайдов‑компоновки.

В этой статье демонстрируется, как создавать, изменять и управлять слайдами‑шаблонами с помощью Aspose.Slides for Java.

## **Добавить слайд‑шаблон**

В этом примере показано, как создать новый слайд‑шаблон, клонировав стандартный. Затем он добавляет баннер с названием компании ко всем слайдам через наследование компоновки.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Клонировать стандартный слайд‑шаблон.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Добавить баннер с названием компании в верхнюю часть слайда‑шаблона.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Назначить новый слайд‑шаблон слайду‑компоновки.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Назначить слайд‑компоновку первому слайду в презентации.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Слайды‑шаблоны позволяют применять единый брендинг или общие элементы дизайна ко всем слайдам. Любые изменения, внесённые в шаблон, автоматически отразятся на зависимых слайдах‑компоновках и обычных слайдах.

> 💡 **Note 2:** Любые фигуры или форматирование, добавленные в слайд‑шаблон, наследуются слайдами‑компоновки и, в свою очередь, всеми обычными слайдами, использующими эти компоновки.  
> Изображение ниже показывает, как текстовое поле, добавленное в слайд‑шаблон, автоматически отображается на конечном слайде.

![Master Inheritance Example](master-slide-banner.png)

## **Получить слайд‑шаблон**

Вы можете получить доступ к слайдам‑шаблонам через коллекцию мастеров презентации. Ниже показано, как извлечь их и работать с ними:

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

## **Удалить слайд‑шаблон**

Слайды‑шаблоны могут быть удалены либо по индексу, либо по ссылке.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Удалить слайд‑шаблон по индексу.
        presentation.getMasters().removeAt(0);

        // Удалить слайд‑шаблон по ссылке.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить неиспользуемые слайды‑шаблоны**

Некоторые презентации содержат слайды‑шаблоны, которые не используются. Удаление этих слайдов может помочь уменьшить размер файла.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Удалить все неиспользуемые слайды‑шаблоны (даже те, которые помечены как Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```