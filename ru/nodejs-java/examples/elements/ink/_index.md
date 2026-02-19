---
title: Чернила
type: docs
weight: 180
url: /ru/nodejs-java/examples/elements/ink/
keywords:
- пример кода
- чернила
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Работайте с чернилами в Aspose.Slides for Node.js: рисуйте, импортируйте и редактируйте штрихи, настраивайте цвет и толщину, а также экспортируйте в PPT, PPTX и ODP с помощью примеров."
---
В этой статье приведены примеры доступа к существующим формам чернил и их удаления с использованием **Aspose.Slides for Node.js via Java**.

> ❗ **Примечание:** Формы чернил представляют ввод пользователя с специализированных устройств. Aspose.Slides не может программно создавать новые штрихи чернил, но вы можете читать и изменять существующие чернила.

## **Доступ к чернилам**

Получите первую форму чернил на слайде.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить чернила**

Удалите форму чернил со слайда.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предполагается, что форма чернил является первой формой на слайде.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```