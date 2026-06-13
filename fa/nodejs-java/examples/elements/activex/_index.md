---
title: ActiveX
type: docs
weight: 200
url: /fa/nodejs-java/examples/elements/activex/
keywords:
- مثال کد
- ActiveX
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نمونه‌های ActiveX در Aspose.Slides برای Node.js را ببینید: درج، پیکربندی و کنترل اشیای ActiveX در ارائه‌های PPT و PPTX با کد واضح JavaScript."
---
این مقاله نحوه افزودن، دسترسی، حذف و پیکربندی کنترل‌های ActiveX در یک ارائه را با استفاده از **Aspose.Slides for Node.js via Java** نشان می‌دهد.

## **افزودن یک کنترل ActiveX**
یک کنترل ActiveX جدید را به یک اسلاید اضافه کنید.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // یک کنترل ActiveX جدید اضافه کنید.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به یک کنترل ActiveX**
اطلاعات اولین کنترل ActiveX موجود در اسلاید را بخوانید.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // دسترسی به اولین کنترل ActiveX.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف یک کنترل ActiveX**
یک کنترل ActiveX موجود را از اسلاید حذف کنید.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // حذف اولین کنترل ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم خصوصیات ActiveX**
چندین خصوصیت ActiveX را پیکربندی کنید.

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