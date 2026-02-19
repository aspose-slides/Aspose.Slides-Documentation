---
title: الشريحة الرئيسية
type: docs
weight: 30
url: /ar/java/examples/elements/master-slide/
keywords:
- مثال على الكود
- الشريحة الرئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استكشف أمثلة الشرائح الرئيسية في Aspose.Slides for Java: إنشاء، تعديل، وتنسيق الشرائح الرئيسية، العناصر النائبة، والسمات في ملفات PPT و PPTX و ODP باستخدام كود جافا واضح."
---
تشكل الشرائح الرئيسية المستوى الأعلى في تسلسل وراثة الشرائح في PowerPoint. تُعرّف **الشريحة الرئيسية** عناصر التصميم المشتركة مثل الخلفيات والشعارات وتنسيق النص. **شرائح التخطيط** ترث من الشرائح الرئيسية، و**الشرائح العادية** ترث من شرائح التخطيط.

توضح هذه المقالة كيفية إنشاء الشرائح الرئيسية وتعديلها وإدارتها باستخدام Aspose.Slides for Java.

## **إضافة شريحة رئيسية**

يوضح هذا المثال كيفية إنشاء شريحة رئيسية جديدة عن طريق استنساخ الشريحة الافتراضية. ثم يضيف شريطًا يحمل اسم الشركة إلى جميع الشرائح من خلال وراثة التخطيط.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // استنساخ الشريحة الرئيسية الافتراضية.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // إضافة شريط يحمل اسم الشركة إلى أعلى الشريحة الرئيسية.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // تعيين الشريحة الرئيسية الجديدة إلى شريحة تخطيط.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // تعيين شريحة التخطيط إلى الشريحة الأولى في العرض التقديمي.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة 1:** توفر الشرائح الرئيسية طريقة لتطبيق العلامة التجارية المتسقة أو عناصر التصميم المشتركة عبر جميع الشرائح. أي تغييرات تُجرى على الشريحة الرئيسية ستنعكس تلقائيًا على شرائح التخطيط والشرائح العادية التابعة لها.

> 💡 **ملاحظة 2:** أي أشكال أو تنسيقات تُضاف إلى شريحة رئيسية يتم وراثتها بواسطة شرائح التخطيط، وبالتالي جميع الشرائح العادية التي تستخدم تلك التخطيطات.  
> الصورة أدناه توضح كيف يتم عرض مربع نص يُضاف إلى شريحة رئيسية تلقائيًا على الشريحة النهائية.

![مثال على وراثة الشريحة الرئيسية](master-slide-banner.png)

## **الوصول إلى شريحة رئيسية**

يمكنك الوصول إلى الشرائح الرئيسية باستخدام مجموعة الشرائح الرئيسية في العرض التقديمي. إليك كيفية استرجاعها والعمل معها:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // تغيير نوع الخلفية.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة شريحة رئيسية**

يمكن إزالة الشرائح الرئيسية إما عن طريق الفهرس أو عن طريق المرجعية.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // إزالة شريحة رئيسية عن طريق الفهرس.
        presentation.getMasters().removeAt(0);

        // إزالة شريحة رئيسية عن طريق المرجع.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة الشرائح الرئيسية غير المستخدمة**

تحتوي بعض العروض التقديمية على شرائح رئيسية غير مستخدمة. يمكن أن يساعد حذف هذه الشرائح في تقليل حجم الملف.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // إزالة جميع الشرائح الرئيسية غير المستخدمة (حتى تلك التي تم تعليمها كـ Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```