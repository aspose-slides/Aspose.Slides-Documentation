---
title: تصویر
type: docs
weight: 50
url: /fa/nodejs-java/examples/elements/picture/
keywords:
- مثال کد
- تصویر
- پاورپوینت
- سند باز
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "کار با تصاویر در Aspose.Slides برای Node.js: درج، برش، فشرده‌سازی، تغییر رنگ و استخراج تصاویر با مثال‌ها برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه می‌توان تصاویر را با استفاده از **Aspose.Slides for Node.js via Java** وارد و دسترسی پیدا کرد. مثال‌های زیر یک تصویر را از فایل می‌خوانند، آن را بر روی یک اسلاید قرار می‌دهند و سپس بازیابی می‌کنند.

## **افزودن تصویر**

این کد یک تصویر را از فایل می‌خواند و به‌عنوان یک فریم تصویر در اولین اسلاید وارد می‌کند.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // درج یک فریم تصویر که تصویر را در اولین اسلاید نشان می‌دهد.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به تصویر**

این مثال اطمینان می‌دهد که یک اسلاید شامل یک فریم تصویر است و سپس به اولین فریم موجود دسترسی پیدا می‌کند.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```