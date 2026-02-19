---
title: رأس وتذييل
type: docs
weight: 220
url: /ar/nodejs-java/examples/elements/header-footer/
keywords:
- مثال على الشيفرة
- رأس
- تذييل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحكم في رؤوس وتذييلات الشرائح باستخدام Aspose.Slides for Node.js: أضف تواريخ وأرقام شرائح ونصًا مخصصًا في ملفات PPT و PPTX و ODP مع أمثلة JavaScript."
---
توضح هذه المقالة كيفية إضافة تذييلات وتحديث العناصر النائبة للتاريخ والوقت باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة تذييل**
أضف نصًا إلى منطقة التذييل في الشريحة واجعلها مرئية.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تحديث التاريخ والوقت**
قم بتعديل العنصر النائب للتاريخ والوقت في الشريحة.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```