---
title: SmartArt
type: docs
weight: 140
url: /fa/nodejs-java/examples/elements/smart-art/
keywords:
- نمونه کد
- SmartArt
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کار با SmartArt در Aspose.Slides برای Node.js: ایجاد، ویرایش، تبدیل و استایل‌ دادن به نمودارها با JavaScript برای ارائه‌های PowerPoint و OpenDocument."
---
این مقاله نشان می‌دهد چگونه می‌توانید گرافیک‌های SmartArt را اضافه کنید، به آن‌ها دسترسی پیدا کنید، حذف کنید و طرح‌ها را با استفاده از **Aspose.Slides for Node.js via Java** تغییر دهید.

## **افزودن SmartArt**

یک گرافیک SmartArt را با استفاده از یکی از طرح‌های پیش فرض اضافه کنید.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به SmartArt**

اولین شیء SmartArt را در یک اسلاید بازیابی کنید.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف SmartArt**

یک شکل SmartArt را از اسلاید حذف کنید.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض بر این است که اولین شکل SmartArt است.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تغییر طرح SmartArt**

نوع طرح یک گرافیک SmartArt موجود را به روزرسانی کنید.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض بر این است که اولین شکل SmartArt است.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```