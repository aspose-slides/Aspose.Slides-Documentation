---
title: رأس وتذييل
type: docs
weight: 220
url: /ar/php-java/examples/elements/header-footer/
keywords:
- رأس وتذييل
- إضافة رأس وتذييل
- تحديث رأس وتذييل
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحكم في الرؤوس والتذييلات في PHP باستخدام Aspose.Slides: أضف أو حرر التاريخ/الوقت، أرقام الشرائح، ونص التذييل، اعرض أو أخفِ العناصر النائبة عبر ملفات PPT و PPTX و ODP."
---
يعرض كيفية إضافة تذييلات وتحديث عناصر نائب التاريخ والوقت باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة تذييل**

أضف نصًا إلى منطقة التذييل في الشريحة واجعله مرئيًا.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تحديث التاريخ والوقت**

تعديل عنصر نائب التاريخ والوقت في الشريحة.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```