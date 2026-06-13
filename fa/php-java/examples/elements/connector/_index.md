---
title: کانکتور
type: docs
weight: 190
url: /fa/php-java/examples/elements/connector/
keywords:
- کانکتور
- افزودن کانکتور
- دسترسی به کانکتور
- حذف کانکتور
- اتصال مجدد اشکال
- نمونه‌های کد
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "کشیدن و کنترل کانکتورها در PHP با Aspose.Slides: افزودن، مسیردهی، مسیردهی مجدد، تنظیم نقاط اتصال، پیکان‌ها و سبک‌ها برای اتصال اشکال در PPT، PPTX و ODP."
---
نحوه اتصال اشکال با کانکتورها و تغییر هدف آنها را با استفاده از **Aspose.Slides for PHP via Java** نشان می‌دهد.

## **افزودن یک کانکتور**
یک شکل کانکتور را بین دو نقطه در اسلاید درج کنید.

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

## **دسترسی به یک کانکتور**
اولین شکل کانکتور افزوده شده به اسلاید را بازیابی کنید.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین کانکتور در اسلاید.
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

## **حذف یک کانکتور**
یک کانکتور را از اسلاید حذف کنید.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم اولین شکل در اسلاید یک کانکتور است.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **اتصال مجدد اشکال**
یک کانکتور را به دو شکل متصل کنید با اختصاص هدف شروع و پایان.

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