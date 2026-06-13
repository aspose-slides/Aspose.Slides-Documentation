---
title: شکل‌گروه
type: docs
weight: 170
url: /fa/php-java/examples/elements/group-shape/
keywords:
- گروه
- افزودن شکل گروهی
- دسترسی به شکل گروهی
- حذف شکل گروهی
- جداسازی اشکال
- نمونه‌های کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "کار با شکل‌های گروهی در PHP با استفاده از Aspose.Slides: ایجاد و جداسازی، مرتب‌سازی اشکال فرزند، تنظیم تبدیلات و مرزها در PowerPoint و OpenDocument."
---
نمونه‌هایی برای ایجاد گروه‌های اشکال، دسترسی به آن‌ها، جداسازی، و حذف با استفاده از **Aspose.Slides for PHP via Java**.

## **افزودن یک شکل گروهی**

یک گروه شامل دو شکل پایه ایجاد کنید.

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دستیابی به یک شکل گروهی**

شکل گروهی اول را از یک اسلاید بازیابی کنید.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین شکل گروهی در اسلاید.
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف یک شکل گروهی**

یک شکل گروهی را از اسلاید حذف کنید.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // فرض می‌کنیم اولین شکل در اسلاید یک شکل گروهی است.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **جداسازی اشکال**

اشکال را از داخل یک ظرف گروهی بیرون بیاورید.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم اولین شکل در اسلاید یک شکل گروهی است.
        $group = $slide->getShapes()->get_Item(0);

        // هر شکل را از گروه کپی می‌کنیم و به اسلاید اضافه می‌کنیم.
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```