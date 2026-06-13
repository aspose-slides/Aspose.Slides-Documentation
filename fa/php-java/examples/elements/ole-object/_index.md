---
title: شیء OLE
type: docs
weight: 210
url: /fa/php-java/examples/elements/ole-object/
keywords:
- شیء OLE
- افزودن شیء OLE
- دسترسی به شیء OLE
- حذف شیء OLE
- به‌روزرسانی شیء OLE
- مثال‌های کد
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "کار با اشیاء OLE در PHP با استفاده از Aspose.Slides: وارد کردن یا به‌روزرسانی فایل‌های جاسازی‌شده، تنظیم آیکون یا لینک‌ها، استخراج محتوا، کنترل رفتار برای PPT، PPTX و ODP."
---
نشان می‌دهد که چگونه یک فایل را به عنوان یک شیء OLE جاسازی کرده و داده‌های آن را با استفاده از **Aspose.Slides for PHP via Java** به‌روزرسانی می‌کند.

## **افزودن یک شیء OLE**

یک فایل PDF را در یک ارائه جاسازی کنید.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به یک شیء OLE**

دست‌رسی به اولین فریم شیء OLE در یک اسلاید.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین فریم OLE در اسلاید.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف یک شیء OLE**

شیء OLE جاسازی‌شده را از اسلاید حذف کنید.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض بر این است که اولین شکل در اسلاید فریم OLE است.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **به‌روزرسانی داده‌های شیء OLE**

داده‌های جاسازی‌شده در یک شیء OLE موجود را جایگزین کنید.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض بر این است که اولین شکل در اسلاید فریم OLE است.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```