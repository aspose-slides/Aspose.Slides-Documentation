---
title: Заголовок и нижний колонтитул
type: docs
weight: 220
url: /ru/nodejs-java/examples/elements/header-footer/
keywords:
- пример кода
- заголовок
- нижний колонтитул
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте заголовками и нижними колонтитулами слайдов с помощью Aspose.Slides for Node.js: добавляйте даты, номера слайдов и пользовательский текст в PPT, PPTX и ODP с примерами на JavaScript."
---
В этой статье демонстрируется, как добавить нижние колонтитулы и обновить заполнители даты и времени с использованием **Aspose.Slides for Node.js via Java**.

## **Добавить нижний колонтитул**

Добавьте текст в область нижнего колонтитула слайда и сделайте его видимым.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Обновить дату и время**

Измените заполнитель даты и времени на слайде.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```