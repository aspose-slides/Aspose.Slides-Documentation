---
title: حبر
type: docs
weight: 180
url: /ar/java/examples/elements/ink/
keywords:
- مثال على الكود
- حبر
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "العمل مع الحبر في Aspose.Slides for Java: رسم، استيراد، وتعديل الضربات، ضبط اللون والعرض، وتصدير إلى PPT و PPTX و ODP باستخدام أمثلة جافا."
---
توفر هذه المقالة أمثلة على الوصول إلى أشكال الحبر الموجودة وإزالتها باستخدام **Aspose.Slides for Java**.

> ❗ **ملاحظة:** تمثل أشكال الحبر إدخال المستخدم من الأجهزة المتخصصة. لا يمكن لـ Aspose.Slides إنشاء ضربات حبر جديدة برمجياً، لكن يمكنك قراءة الحبر الموجود وتعديله.

## **الوصول إلى الحبر**

اقرأ العلامات من أول شكل حبر على الشريحة.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // استخدم tagName حسب الحاجة.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة الحبر**

احذف شكل حبر من الشريحة إذا كان موجودًا.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```