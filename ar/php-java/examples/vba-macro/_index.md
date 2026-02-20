---
title: ماكرو VBA
type: docs
weight: 150
url: /ar/php-java/examples/elements/vba-macro/
keywords:
- ماكرو VBA
- إضافة ماكرو VBA
- الوصول إلى ماكرو VBA
- إزالة ماكرو VBA
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "العمل مع ماكروات VBA في PHP باستخدام Aspose.Slides: إضافة أو تعديل المشاريع والوحدات، توقيع أو إزالة الماكروات، وحفظ العروض التقديمية بصيغ PPT و PPTX و ODP."
---
يوضح كيفية إضافة ماكرو VBA والوصول إليه وإزالته باستخدام **Aspose.Slides for PHP عبر Java**.

## **إضافة ماكرو VBA**

إنشاء عرض تقديمي يحتوي على مشروع VBA ووحدة ماكرو بسيطة.

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

## **الوصول إلى ماكرو VBA**

استرجاع الوحدة الأولى من مشروع VBA.

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

## **إزالة ماكرو VBA**

حذف وحدة من مشروع VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // بافتراض وجود وحدة واحدة على الأقل في مشروع VBA.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```