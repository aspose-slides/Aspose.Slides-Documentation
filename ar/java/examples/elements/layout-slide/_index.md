---
title: شريحة التخطيط
type: docs
weight: 20
url: /ar/java/examples/elements/layout-slide/
keywords:
- مثال على الكود
- شريحة تخطيط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحكم في شرائح التخطيط في Aspose.Slides for Java: اختر، طبق، وخصص تخطيطات الشرائح، النائبات، والنماذج الأساسية باستخدام أمثلة Java لعروض PPT و PPTX و ODP."
---
توّضح هذه المقالة كيفية العمل مع **Layout Slides** في Aspose.Slides for Java. تُعرّف شريحة التخطيط التصميم والتنسيق الموروث من الشرائح العادية. يمكنك إضافة، الوصول، استنساخ، وإزالة شرائح التخطيط، بالإضافة إلى تنظيف الشرائح غير المستخدمة لتقليل حجم العرض التقديمي.

## **إضافة شريحة تخطيط**

يمكنك إنشاء شريحة تخطيط مخصصة لتحديد تنسيق قابل لإعادة الاستخدام. على سبيل المثال، قد تضيف مربع نص يظهر في جميع الشرائح باستخدام هذا التخطيط.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // إنشاء شريحة تخطيط بنوع تخطيط فارغ واسم مخصص.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // إضافة مربع نص إلى شريحة التخطيط.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // إضافة شريحتين باستخدام هذا التخطيط؛ ستورث كل منهما النص من التخطيط.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة 1:** تعمل شرائح التخطيط كقوالب للشرائح الفردية. يمكنك تعريف العناصر المشتركة مرة واحدة وإعادة استخدامها عبر العديد من الشرائح.

> 💡 **ملاحظة 2:** عند إضافة أشكال أو نص إلى شريحة التخطيط، ستعرض جميع الشرائح المستندة إلى ذلك التخطيط هذا المحتوى المشترك تلقائيًا.
> تظهر لقطة الشاشة أدناه شريحتين، كل منهما ترث مربع نص من شريحة التخطيط نفسها.

![الشرائح التي ترث محتوى التخطيط](layout-slide-result.png)

## **الوصول إلى شريحة تخطيط**

يمكن الوصول إلى شرائح التخطيط عن طريق الفهرس أو نوع التخطيط (مثال: `Blank`، `Title`، `SectionHeader`، إلخ).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // الوصول إلى شريحة تخطيط حسب الفهرس.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // الوصول إلى شريحة تخطيط حسب النوع.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة شريحة تخطيط**

يمكنك إزالة شريحة تخطيط معينة إذا لم تعد بحاجة إليها.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // احصل على شريحة تخطيط حسب النوع واحذفها.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة شرائح التخطيط غير المستخدمة**

لتقليل حجم العرض التقديمي، قد ترغب في إزالة شرائح التخطيط التي لا تستخدمها أي شرائح عادية.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // يزيل تلقائيًا جميع شرائح التخطيط التي لا يتم الإشارة إليها من قبل أي شريحة.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **استنساخ شريحة تخطيط**

يمكنك تكرار شريحة تخطيط باستخدام طريقة `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // الحصول على شريحة تخطيط موجودة حسب النوع.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // استنساخ شريحة التخطيط إلى نهاية مجموعة شرائح التخطيط.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **ملخص:** شرائح التخطيط هي أدوات قوية لإدارة التنسيق المتسق عبر الشرائح. يتيح Aspose.Slides التحكم الكامل في إنشاء وإدارة وتحسين شرائح التخطيط.