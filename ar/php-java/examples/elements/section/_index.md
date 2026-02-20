---
title: قسم
type: docs
weight: 90
url: /ar/php-java/examples/elements/section/
keywords:
- قسم
- قسم الشرائح
- إضافة قسم
- الوصول إلى قسم
- إزالة قسم
- إعادة تسمية قسم
- أمثلة على الكود
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "إدارة أقسام الشرائح في PHP باستخدام Aspose.Slides: إنشاء، إعادة تسمية، إعادة ترتيب بسهولة، نقل الشرائح بين الأقسام، والتحكم في الرؤية للملفات PPT وPPTX وODP."
---
أمثلة على إدارة أقسام العرض—الإضافة، الوصول، الإزالة، وإعادة التسمية برمجيًا باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة قسم**

إنشاء قسم يبدأ من شريحة محددة.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // حدد الشريحة التي تمثل بداية القسم.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى قسم**

قراءة معلومات القسم من عرض تقديمي.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // الوصول إلى قسم حسب الفهرس.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة قسم**

حذف قسم تم إضافته مسبقًا.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // إزالة القسم.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **إعادة تسمية قسم**

تغيير اسم قسم موجود.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```