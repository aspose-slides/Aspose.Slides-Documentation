---
title: جدول
type: docs
weight: 120
url: /fa/php-java/examples/elements/table/
keywords:
- جدول
- افزودن جدول
- دسترسی به جدول
- حذف جدول
- ادغام سلول‌ها
- نمونه کد
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و قالب‌بندی جداول در PHP با Aspose.Slides: وارد کردن داده‌ها، ادغام سلول‌ها، استایل‌گذاری مرزها، تراز کردن محتوا، و واردات/صادرات برای PPT، PPTX و ODP."
---
مثال‌هایی برای افزودن جداول، دسترسی به آن‌ها، حذف آن‌ها و ادغام سلول‌ها با استفاده از **Aspose.Slides for PHP via Java**.

## **اضافه کردن جدول**

یک جدول ساده با دو ردیف و دو ستون ایجاد کنید.

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

## **دسترسی به جدول**

شکل جدول اول در اسلاید را بازیابی کنید.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین جدول در اسلاید.
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

## **حذف جدول**

یک جدول را از اسلاید حذف کنید.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم جدول اولین شکل در اسلاید است.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ادغام سلول‌های جدول**

سلول‌های مجاور یک جدول را به یک سلول واحد ادغام کنید.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم جدول اولین شکل در اسلاید است.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```