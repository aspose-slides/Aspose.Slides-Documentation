---
title: SmartArt
type: docs
weight: 140
url: /ar/php-java/examples/elements/smartart/
keywords:
- SmartArt
- إضافة SmartArt
- الوصول إلى SmartArt
- إزالة SmartArt
- تخطيط SmartArt
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتعديل SmartArt في PHP باستخدام Aspose.Slides: إضافة العقد، تغيير التخطيطات والأنماط، التحويل إلى أشكال بدقة، وتصدير للملفات PPT و PPTX و ODP."
---
يعرض كيفية إضافة رسومات SmartArt، والوصول إليها، وإزالتها، وتغيير التخطيطات باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة SmartArt**

إدراج رسم SmartArt باستخدام أحد التخطيطات المدمجة.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى SmartArt**

استرداد أول كائن SmartArt في الشريحة.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول SmartArt على الشريحة.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة SmartArt**

حذف شكل SmartArt من الشريحة.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // افتراض أن الشكل الأول على الشريحة هو SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تغيير تخطيط SmartArt**

تحديث نوع التخطيط لرسم SmartArt موجود.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // افتراض أن الشكل الأول على الشريحة هو SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // تغيير تخطيط SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```