---
title: الشريحة الرئيسة
type: docs
weight: 30
url: /ar/androidjava/examples/elements/master-slide/
keywords:
- مثال على الكود
- شريحة رئيسة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استكشف أمثلة الشرائح الرئيسة في Aspose.Slides for Android: إنشاء وتحرير وتنسيق الشرائح الرئيسة، العناصر النائبة، والسمات في صيغ PPT و PPTX و ODP باستخدام كود Java واضح."
---
تشكل الشرائح الرئيسة المستوى الأعلى في تسلسل وراثة الشرائح في PowerPoint. **الشريحة الرئيسة** تحدد عناصر التصميم المشتركة مثل الخلفيات والشعارات وتنسيق النص. **شرائح التخطيط** ترث من الشرائح الرئيسة، و**الشرائح العادية** ترث من شرائح التخطيط.

توضح هذه المقالة كيفية إنشاء وتعديل وإدارة الشرائح الرئيسة باستخدام Aspose.Slides for Android عبر Java.

## **إضافة شريحة رئيسة**

يوضح هذا المثال كيفية إنشاء شريحة رئيسة جديدة عن طريق استنساخ الشريحة الافتراضية. ثم يضيف بانر باسم الشركة إلى جميع الشرائح عبر وراثة التخطيط.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // استنساخ الشريحة الرئيسة الافتراضية.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // إضافة بانر باسم الشركة إلى أعلى الشريحة الرئيسة.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // تعيين الشريحة الرئيسة الجديدة إلى شريحة تخطيط.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // تعيين شريحة التخطيط إلى الشريحة الأولى في العرض التقديمي.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة 1:** توفر الشرائح الرئيسة طريقة لتطبيق هوية علامة تجارية ثابتة أو عناصر تصميم مشتركة عبر جميع الشرائح. أي تغييرات تُجرى على الشريحة الرئيسة ستنعكس تلقائيًا على شرائح التخطيط والشرائح العادية التابعة.

> 💡 **ملاحظة 2:** أي أشكال أو تنسيقات تُضاف إلى شريحة رئيسة تُورّث إلى شرائح التخطيط، وبالتالي إلى جميع الشرائح العادية التي تستخدم تلك التخطيطات. الصورة أدناه توضح كيف يتم عرض مربع نص يُضاف إلى شريحة رئيسة تلقائيًا على الشريحة النهائية.

![مثال على وراثة الشريحة الرئيسة](master-slide-banner.png)

## **الوصول إلى شريحة رئيسة**

يمكنك الوصول إلى الشرائح الرئيسة باستخدام مجموعة الشرائح الرئيسة في العرض التقديمي. إليك كيفية استرجاعها والعمل معها:

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

## **إزالة شريحة رئيسة**

يمكن إزالة الشرائح الرئيسة إما حسب الفهرس أو حسب المرجع.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // إزالة شريحة رئيسة حسب الفهرس.
        presentation.getMasters().removeAt(0);

        // إزالة شريحة رئيسة حسب المرجع.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة الشرائح الرئيسة غير المستخدمة**

بعض العروض التقديمية تحتوي على شرائح رئيسة غير مستخدمة. إزالة هذه الشرائح يمكن أن تساعد في تقليل حجم الملف.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // إزالة جميع الشرائح الرئيسة غير المستخدمة (حتى تلك التي تم تعيينها كـ Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```