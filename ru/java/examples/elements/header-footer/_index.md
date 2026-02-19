---
title: Заголовок и нижний колонтитул
type: docs
weight: 220
url: /ru/java/examples/elements/header-footer/
keywords:
- пример кода
- заголовок
- нижний колонтитул
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте заголовками и нижними колонтитулами слайдов с помощью Aspose.Slides for Java: добавляйте даты, номера слайдов и пользовательский текст в PPT, PPTX и ODP с примерами на Java."
---
В этой статье демонстрируется, как добавить колонтитулы и обновить заполнители даты и времени с помощью **Aspose.Slides for Java**.

## **Добавить колонтитул**

Добавьте текст в область колонтитула слайда и сделайте его видимым.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **Обновить дату и время**

Измените заполнитель даты и времени на слайде.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```