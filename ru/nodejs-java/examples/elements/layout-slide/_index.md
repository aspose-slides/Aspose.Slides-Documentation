---
title: Слайд‑шаблон
type: docs
weight: 20
url: /ru/nodejs-java/examples/elements/layout-slide/
keywords:
- пример кода
- слайд‑шаблон
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Мастерство работы с макетами слайдов в Aspose.Slides для Node.js: выбирайте, применяйте и настраивайте макеты слайдов, заполняющие элементы и шаблоны с примерами для презентаций PPT, PPTX и ODP."
---
Эта статья демонстрирует, как работать с **Layout Slides** в Aspose.Slides для Node.js через Java. Слайд‑шаблон определяет дизайн и форматирование, наследуемое обычными слайдами. Вы можете добавлять, получать доступ, клонировать и удалять слайды‑шаблоны, а также очищать неиспользуемые, чтобы уменьшить размер презентации.

## **Добавить слайд‑шаблон**

Вы можете создать пользовательский слайд‑шаблон для определения повторно используемого форматирования.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Создайте слайд‑шаблон с пустым типом макета и пользовательским именем.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Слайды‑шаблоны выступают в роли шаблонов для отдельных слайдов. Вы можете определить общие элементы один раз и повторно использовать их на многих слайдах.

> 💡 **Note 2:** Когда вы добавляете формы или текст в слайд‑шаблон, все слайды, основанные на этом шаблоне, автоматически отображают этот общий контент.  
> На скриншоте ниже показаны два слайда, каждый из которых наследует текстовое поле из одного и того же слайда‑шаблона.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Получить доступ к слайду‑шаблону**

Слайды‑шаблоны можно получать по индексу или по типу шаблона (например, `Blank`, `Title`, `SectionHeader` и т.д.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Получить слайд‑шаблон по индексу.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Получить слайд‑шаблон по типу.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить слайд‑шаблон**

Вы можете удалить конкретный слайд‑шаблон, если он больше не нужен.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Получить слайд‑шаблон по типу и удалить его.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить неиспользуемые слайды‑шаблоны**

Чтобы уменьшить размер презентации, можно удалить слайды‑шаблоны, которые не используются ни одним обычным слайдом.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Автоматически удаляет все слайды‑шаблоны, не используемые ни одним слайдом.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Клонировать слайд‑шаблон**

Вы можете продублировать слайд‑шаблон с помощью метода `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Получить существующий слайд‑шаблон по типу.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Клонировать слайд‑шаблон в конец коллекции слайдов‑шаблонов.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** Слайды‑шаблоны — мощный инструмент для управления единообразным форматированием across slides. Aspose.Slides предоставляет полный контроль над созданием, управлением и оптимизацией слайдов‑шаблонов.