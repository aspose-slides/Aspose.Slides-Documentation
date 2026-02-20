---
title: مجموعة الشكل
type: docs
weight: 170
url: /ar/php-java/examples/elements/group-shape/
keywords:
- مجموعة
- إضافة مجموعة شكل
- الوصول إلى مجموعة شكل
- إزالة مجموعة شكل
- فك تجميع الأشكال
- أمثلة على الشفرات
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "العمل مع مجموعات الأشكال في PHP باستخدام Aspose.Slides: إنشاء وفك التجميع، إعادة ترتيب الأشكال الفرعية، ضبط التحولات والحدود عبر PowerPoint وOpenDocument."
---
أمثلة على إنشاء مجموعات من الأشكال، والوصول إليها، وفك التجميع، وإزالتها باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة مجموعة أشكال**

إنشاء مجموعة تحتوي على شكلين أساسيين.

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

## **الوصول إلى مجموعة أشكال**

استرجاع أول مجموعة أشكال من الشريحة.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى مجموعة الشكل الأولى في الشريحة.
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

## **إزالة مجموعة أشكال**

حذف مجموعة أشكال من الشريحة.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // بافتراض أن الشكل الأول في الشريحة هو مجموعة شكل.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **فك تجميع الأشكال**

نقل الأشكال خارج حاوية المجموعة.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول في الشريحة هو مجموعة شكل.
        $group = $slide->getShapes()->get_Item(0);

        // استنسخ كل شكل من المجموعة وأضفه إلى الشريحة.
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