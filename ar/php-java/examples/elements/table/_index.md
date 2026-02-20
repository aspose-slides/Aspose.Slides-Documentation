---
title: جدول
type: docs
weight: 120
url: /ar/php-java/examples/elements/table/
keywords:
- جدول
- إضافة جدول
- الوصول إلى جدول
- إزالة جدول
- دمج خلايا
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتنسيق الجداول في PHP باستخدام Aspose.Slides: إدراج البيانات، دمج الخلايا، تنسيق الحدود، محاذاة المحتوى، والاستيراد/التصدير لملفات PPT و PPTX و ODP."
---
أمثلة على إضافة الجداول والوصول إليها وإزالتها ودمج الخلايا باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة جدول**

إنشاء جدول بسيط يتكون من صفين وعمودين.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى جدول**

استرداد الشكل الجدولي الأول على الشريحة.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول جدول على الشريحة.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة جدول**

حذف جدول من الشريحة.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // افتراض أن الجدول هو الشكل الأول على الشريحة.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دمج خلايا الجدول**

دمج الخلايا المتجاورة في جدول إلى خلية واحدة.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // افتراض أن الجدول هو الشكل الأول على الشريحة.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```