---
title: كائن OLE
type: docs
weight: 210
url: /ar/php-java/examples/elements/ole-object/
keywords:
- كائن OLE
- إضافة كائن OLE
- الوصول إلى كائن OLE
- إزالة كائن OLE
- تحديث كائن OLE
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "العمل مع كائنات OLE في PHP باستخدام Aspose.Slides: إدراج أو تحديث الملفات المضمَّنة، تعيين أيقونات أو روابط، استخراج المحتوى، التحكم في السلوك لملفات PPT و PPTX و ODP."
---
يوضح كيفية تضمين ملف ككائن OLE وتحديث بياناته باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة كائن OLE**

تضمين ملف PDF في عرض تقديمي.

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

## **الوصول إلى كائن OLE**

استرجاع إطار كائن OLE الأول في الشريحة.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول إطار OLE في الشريحة.
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

## **إزالة كائن OLE**

حذف كائن OLE المضمن من الشريحة.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // نفترض أن الشكل الأول في الشريحة هو إطار OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تحديث بيانات كائن OLE**

استبدال البيانات المضمنة في كائن OLE موجود.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // نفترض أن الشكل الأول في الشريحة هو إطار OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```