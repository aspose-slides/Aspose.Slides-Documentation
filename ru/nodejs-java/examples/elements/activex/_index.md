---
title: ActiveX
type: docs
weight: 200
url: /ru/nodejs-java/examples/elements/activex/
keywords:
- пример кода
- ActiveX
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Смотрите примеры ActiveX для Aspose.Slides для Node.js: вставка, настройка и управление объектами ActiveX в презентациях PPT и PPTX с ясным кодом JavaScript."
---
В этой статье демонстрируется, как добавлять, получать доступ, удалять и настраивать элементы управления ActiveX в презентации с использованием **Aspose.Slides for Node.js via Java**.

## **Добавить элемент управления ActiveX**

Добавьте новый элемент управления ActiveX на слайд.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Добавить новый элемент управления ActiveX.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Получить доступ к элементу управления ActiveX**

Прочитайте информацию из первого элемента управления ActiveX на слайде.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Получить доступ к первому элементу управления ActiveX.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить элемент управления ActiveX**

Удалите существующий элемент управления ActiveX со слайда.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Удалить первый элемент управления ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Установить свойства ActiveX**

Настройте несколько свойств ActiveX.

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```