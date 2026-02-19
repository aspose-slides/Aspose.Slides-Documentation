---
title: Текстовое поле
type: docs
weight: 40
url: /ru/nodejs-java/examples/elements/text-box/
keywords:
- пример кода
- текстовое поле
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Работайте с текстовыми полями в Aspose.Slides для Node.js: добавляйте, форматируйте, выравнивайте, переносите, автоматически подгоняйте и оформляйте текст с помощью JavaScript для презентаций PPT, PPTX и ODP."
---
В Aspose.Slides **текстовое поле** представлено объектом `AutoShape`. Практически любую форму можно заполнить текстом, но типичное текстовое поле не имеет заливки или границы и отображает только текст.

Это руководство объясняет, как программно добавлять, получать доступ и удалять текстовые поля.

## **Добавить текстовое поле**

Текстовое поле — это просто `AutoShape` без заливки и границы и с некоторым форматированным текстом. Вот как создать его:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Создайте прямоугольную форму (по умолчанию заполнена с границей и без текста).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Удалите заливку и границу, чтобы выглядело как типичное текстовое поле.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Установите форматирование текста.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Назначьте фактическое текстовое содержание.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Примечание:** Любой `AutoShape`, содержащий непустой `TextFrame`, может работать как текстовое поле.

## **Получить текстовое поле**

Получите первое текстовое поле со слайда.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Только AutoShape могут содержать редактируемый текст.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить текстовые поля по содержанию**

В этом примере находятся и удаляются все текстовые поля на первом слайде, содержащие определённое ключевое слово:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Совет:** Всегда создавайте копию коллекции фигур перед её изменением во время итерации, чтобы избежать ошибок модификации коллекции.