---
title: ActiveX
type: docs
weight: 200
url: /ar/php-java/examples/elements/activex/
keywords:
- ActiveX
- عنصر تحكم ActiveX
- إضافة ActiveX
- الوصول إلى ActiveX
- إزالة ActiveX
- خصائص ActiveX
- أمثلة على الشيفرة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية العثور على عناصر تحكم ActiveX وتعديلها وإزالتها في PHP باستخدام Aspose.Slides، بما في ذلك تحديث الخصائص لعروض PowerPoint التقديمية."
---
يوضح كيفية إضافة، الوصول، إزالة وتكوين عناصر تحكم ActiveX في عرض تقديمي باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة عنصر تحكم ActiveX**

إدراج عنصر تحكم ActiveX جديد.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إضافة عنصر تحكم ActiveX جديد.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // تحرير العرض التقديمي.
        $presentation->dispose();
    }
}
```

## **الوصول إلى عنصر تحكم ActiveX**

قراءة المعلومات من أول عنصر تحكم ActiveX على الشريحة.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول عنصر تحكم ActiveX.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // تحرير العرض التقديمي.
        $presentation->dispose();
    }
}
```

## **إزالة عنصر تحكم ActiveX**

حذف عنصر تحكم ActiveX موجود من الشريحة.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // إزالة أول عنصر تحكم ActiveX.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // تحرير العرض التقديمي.
        $presentation->dispose();
    }
}
```

## **تعيين خصائص ActiveX**

تكوين عدة خصائص لـ ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // افتراض أن العنصر الأول هو الذي أضفناه.
        $control = $slide->getControls()->get_Item(0);

        // تكوين الخصائص.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // تحرير العرض التقديمي.
        $presentation->dispose();
    }
}
```