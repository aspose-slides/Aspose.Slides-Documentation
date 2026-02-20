---
title: رابط تشعبي
type: docs
weight: 130
url: /ar/php-java/examples/elements/hyperlink/
keywords:
- رابط تشعبي
- إضافة رابط تشعبي
- الوصول إلى رابط تشعبي
- إزالة رابط تشعبي
- تحديث رابط تشعبي
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إضافة وتحرير وإزالة الروابط التشعبية في PHP باستخدام Aspose.Slides: نص الرابط، الأشكال، الشرائح، عناوين URL والبريد الإلكتروني؛ تعيين الأهداف والإجراءات لـ PPT و PPTX و ODP."
---
يوضح إضافة، الوصول، إزالة وتحديث الروابط التشعبية على الأشكال باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة رابط تشعبي**

إنشاء شكل مستطيل يحتوي على رابط تشعبي يشير إلى موقع ويب خارجي.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى رابط تشعبي**

قراءة معلومات الرابط التشعبي من جزء النص في الشكل.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول يحتوي على الارتباط التشعبي.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة رابط تشعبي**

مسح الرابط التشعبي من نص الشكل.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول يحتوي على الارتباط التشعبي.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تحديث رابط تشعبي**

تغيير هدف الرابط التشعبي الموجود. استخدم `HyperlinkManager` لتعديل النص الذي يحتوي بالفعل على رابط تشعبي، وهو ما يحاكي طريقة تحديث PowerPoint للروابط التشعبية بأمان.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // على افتراض أن الشكل الأول يحتوي على الارتباط التشعبي.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // يجب تغيير رابط تشعبي داخل النص الموجود عبر
        // HyperlinkManager بدلاً من تعيين الخاصية مباشرة.
        // هذا يحاكي طريقة تحديث PowerPoint للروابط التشعبية بأمان.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```