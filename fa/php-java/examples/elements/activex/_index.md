---
title: ActiveX
type: docs
weight: 200
url: /fa/php-java/examples/elements/activex/
keywords:
- ActiveX
- کنترل ActiveX
- افزودن ActiveX
- دسترسی به ActiveX
- حذف ActiveX
- ویژگی‌های ActiveX
- نمونه‌های کد
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "چگونگی یافتن، ویرایش و حذف کنترل‌های ActiveX در PHP با Aspose.Slides را بیاموزید، به‌همراه به‌روزرسانی ویژگی‌ها برای ارائه‌های PowerPoint."
---
نحوهٔ افزودن، دسترسی، حذف و پیکربندی کنترل‌های ActiveX در یک ارائه با استفاده از **Aspose.Slides for PHP via Java** را نشان می‌دهد.

## **افزودن یک کنترل ActiveX**
یک کنترل ActiveX جدید اضافه کنید.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // یک کنترل ActiveX جدید اضافه کنید.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // ارائه را آزاد کنید.
        $presentation->dispose();
    }
}
```

## **دسترسی به یک کنترل ActiveX**
اطلاعات اولین کنترل ActiveX روی اسلاید را بخوانید.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین کنترل ActiveX.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // ارائه را آزاد کنید.
        $presentation->dispose();
    }
}
```

## **حذف یک کنترل ActiveX**
یک کنترل ActiveX موجود را از اسلاید حذف کنید.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // حذف اولین کنترل ActiveX.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // ارائه را آزاد کنید.
        $presentation->dispose();
    }
}
```

## **تنظیم ویژگی‌های ActiveX**
چندین ویژگی ActiveX را پیکربندی کنید.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم اولین کنترل همان چیزی است که اضافه کرده‌ایم.
        $control = $slide->getControls()->get_Item(0);

        // پیکربندی ویژگی‌ها.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // ارائه را آزاد کنید.
        $presentation->dispose();
    }
}
```