---
title: تصویر
type: docs
weight: 50
url: /fa/php-java/examples/elements/picture/
keywords:
- تصویر
- قاب تصویر
- افزودن تصویر
- دسترسی به تصویر
- نمونه‌های کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "کار با تصاویر در PHP با استفاده از Aspose.Slides: درج، جای‌گزینی، برش، فشرده‌سازی، تنظیم شفافیت و افکت‌ها، پر کردن اشکال، و خروجی برای PPT، PPTX و ODP."
---
نحوه درج و دسترسی به تصاویر با استفاده از **Aspose.Slides for PHP via Java** را نشان می‌دهد. مثال‌های زیر یک تصویر را بر روی اسلاید قرار می‌دهند و سپس آن را بازیابی می‌کنند.

## **افزودن تصویر**

این کد یک تصویر را به‌عنوان فریم تصویر در اولین اسلاید درج می‌کند.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // تصویر را به منابع ارائه اضافه می‌کند.
        $ppImage = $presentation->getImages()->addImage($image);

        // یک فریم تصویر که تصویر را در اولین اسلاید نمایش می‌دهد، درج می‌کند.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به تصویر**

این مثال اطمینان می‌دهد که یک اسلاید شامل فریم تصویر است و سپس به اولین فریمی که یافت می‌شود دسترسی پیدا می‌کند.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین PictureFrame در اسلاید.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```