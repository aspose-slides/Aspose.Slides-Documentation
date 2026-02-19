---
title: ActiveX
type: docs
weight: 200
url: /ar/nodejs-java/examples/elements/activex/
keywords:
- مثال على الشيفرة
- ActiveX
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "اطلع على أمثلة ActiveX في Aspose.Slides لـ Node.js: إدراج وتكوين والتحكم في كائنات ActiveX في عروض PPT و PPTX مع كود JavaScript واضح."
---
توضح هذه المقالة كيفية إضافة، الوصول، إزالة وتكوين عناصر التحكم ActiveX في عرض تقديمي باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة عنصر تحكم ActiveX**
إضافة عنصر تحكم ActiveX جديد إلى شريحة.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // إضافة عنصر تحكم ActiveX جديد.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى عنصر تحكم ActiveX**
قراءة المعلومات من أول عنصر تحكم ActiveX في الشريحة.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // الوصول إلى أول عنصر تحكم ActiveX.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة عنصر تحكم ActiveX**
حذف عنصر تحكم ActiveX موجود من الشريحة.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // إزالة أول عنصر تحكم ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **تعيين خصائص ActiveX**
تكوين عدة خصائص لعنصر التحكم ActiveX.

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