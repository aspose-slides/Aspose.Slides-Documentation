---
title: جوهر
type: docs
weight: 180
url: /fa/nodejs-java/examples/elements/ink/
keywords:
- مثال کد
- جوهر
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کار با جوهر در Aspose.Slides برای Node.js: رسم، وارد کردن و ویرایش خطوط، تنظیم رنگ و عرض، و صادر کردن به فرمت‌های PPT، PPTX و ODP با استفاده از مثال‌ها."
---
این مقاله مثال‌هایی از دسترسی به اشکال جوهر موجود و حذف آن‌ها با استفاده از **Aspose.Slides for Node.js via Java** ارائه می‌دهد.

> ❗ **توجه:** اشکال جوهر ورودی کاربر را از دستگاه‌های تخصصی نشان می‌دهند. Aspose.Slides نمی‌تواند خطوط جوهر جدید را به‌صورت برنامه‌نویسی ایجاد کند، اما می‌توانید جوهر موجود را بخوانید و اصلاح کنید.

## **دسترسی به جوهر**

اولین شکل جوهر را در یک اسلاید بازیابی کنید.

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

## **حذف جوهر**

یک شکل جوهر را از اسلاید حذف کنید.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض می‌کنیم که شکل جوهر اولین شکل در اسلاید است.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```