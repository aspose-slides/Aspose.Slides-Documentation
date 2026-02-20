---
title: صورة
type: docs
weight: 50
url: /ar/php-java/examples/elements/picture/
keywords:
- صورة
- إطار صورة
- إضافة صورة
- الوصول إلى صورة
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "العمل مع الصور في PHP باستخدام Aspose.Slides: إدراج، استبدال، قص، ضغط، تعديل الشفافية والتأثيرات، تعبئة الأشكال، وتصدير إلى PPT و PPTX و ODP."
---
يوضح كيفية إدراج الصور والوصول إليها باستخدام **Aspose.Slides for PHP via Java**. الأمثلة أدناه تضع صورة على شريحة، ثم تسترجعها.

## **إضافة صورة**

هذا الكود يدرج صورة كإطار صورة على الشريحة الأولى.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // إضافة الصورة إلى موارد العرض التقديمي.
        $ppImage = $presentation->getImages()->addImage($image);

        // إدراج إطار صورة يعرض الصورة على الشريحة الأولى.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى صورة**

هذا المثال يضمن أن الشريحة تحتوي على إطار صورة ثم يصل إلى أول إطار يجدها.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول إطار صورة على الشريحة.
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