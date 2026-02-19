---
title: القسم
type: docs
weight: 90
url: /ar/nodejs-java/examples/elements/section/
keywords:
- مثال على الكود
- قسم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة أقسام الشرائح في Aspose.Slides for Node.js عبر Java: إنشاء، إعادة تسمية، إعادة ترتيب، وتجميع الشرائح بأمثلة JavaScript لصيغ PPT، PPTX، و ODP."
---
أمثلة لإدارة أقسام العرض التقديمي — الإضافة، الوصول، الإزالة، وإعادة التسمية برمجيًا باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة قسم**

إنشاء قسم يبدأ من شريحة معينة.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // حدد الشريحة التي تمثل بداية القسم.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى قسم**

قراءة معلومات القسم من عرض تقديمي.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // الوصول إلى قسم عن طريق الفهرس.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة قسم**

حذف قسم تم إضافته مسبقًا.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // إزالة القسم الأول.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **إعادة تسمية قسم**

تغيير اسم قسم موجود.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```