---
title: حبر
type: docs
weight: 180
url: /ar/nodejs-java/examples/elements/ink/
keywords:
- مثال على الكود
- حبر
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "العمل مع الحبر في Aspose.Slides لـ Node.js: رسم، استيراد، وتحرير الضربات، ضبط اللون والعرض، وتصدير إلى PPT، PPTX، و ODP باستخدام الأمثلة."
---
توفر هذه المقالة أمثلة على الوصول إلى أشكال الحبر الموجودة وإزالتها باستخدام **Aspose.Slides for Node.js via Java**.

> ❗ **ملاحظة:** تمثل أشكال الحبر مدخلات المستخدم من الأجهزة المتخصصة. لا يمكن لـ Aspose.Slides إنشاء ضربات حبر جديدة برمجياً، ولكن يمكنك قراءة وتعديل الحبر الموجود.

## **الوصول إلى الحبر**
استرجع أول شكل حبر في الشريحة.

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

## **إزالة الحبر**
احذف شكل حبر من الشريحة.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // بافتراض أن شكل الحبر هو الشكل الأول في الشريحة.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```