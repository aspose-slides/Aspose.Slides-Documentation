---
title: موصل
type: docs
weight: 190
url: /ar/php-java/examples/elements/connector/
keywords:
- موصل
- إضافة موصل
- الوصول إلى موصل
- إزالة موصل
- إعادة ربط الأشكال
- أمثلة برمجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "رسم والتحكم في الموصلات في PHP باستخدام Aspose.Slides: إضافة، توجيه، إعادة توجيه، تعيين نقاط الاتصال، الأسهم والأنماط لربط الأشكال في ملفات PPT و PPTX و ODP."
---
يعرض كيفية ربط الأشكال باستخدام الموصلات وتغيير أهدافها باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة موصل**

أدخل شكل موصل بين نقطتين على الشريحة.

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى موصل**

استرداد أول شكل موصل تم إضافته إلى شريحة.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول موصل على الشريحة.
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة موصل**

احذف موصلاً من الشريحة.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // افتراض أن الشكل الأول على الشريحة هو موصل.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **إعادة ربط الأشكال**

إرفاق موصل إلى شكلين عن طريق تعيين أهداف البداية والنهاية.

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```