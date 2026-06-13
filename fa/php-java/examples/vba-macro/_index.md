---
title: ماکرو VBA
type: docs
weight: 150
url: /fa/php-java/examples/elements/vba-macro/
keywords:
- ماکرو VBA
- افزودن ماکرو VBA
- دسترسی به ماکرو VBA
- حذف ماکرو VBA
- مثال‌های کد
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "کار با ماکروهای VBA در PHP با استفاده از Aspose.Slides: افزودن یا ویرایش پروژه‌ها و ماژول‌ها، امضا یا حذف ماکروها، و ذخیره ارائه‌ها در فرمت‌های PPT، PPTX و ODP."
---
نحوه افزودن، دسترسی و حذف ماکروهای VBA را با استفاده از **Aspose.Slides for PHP via Java** نشان می‌دهد.

## **افزودن یک ماکرو VBA**

یک ارائه با یک پروژه VBA و یک ماژول ماکرو ساده ایجاد کنید.

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترس به یک ماکرو VBA**

اولین ماژول را از پروژه VBA بازیابی کنید.

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف یک ماکرو VBA**

یک ماژول را از پروژه VBA حذف کنید.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // فرض می‌شود که حداقل یک ماژول در پروژه VBA وجود دارد.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```