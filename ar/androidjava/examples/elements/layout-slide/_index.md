---
title: شريحة التخطيط
type: docs
weight: 20
url: /ar/androidjava/examples/elements/layout-slide/
keywords:
- مثال على الكود
- شريحة تخطيط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة شرائح التخطيط في Aspose.Slides لنظام Android: اختر، طبّق، وخصّص تخطيطات الشرائح، العناصر النائبة، والماسترات مع أمثلة Java لعروض PPT، PPTX، وODP."
---
توضح هذه المقالة كيفية العمل مع **Layout Slides** في Aspose.Slides لنظام Android عبر Java. تُعرّف شريحة التخطيط التصميم والتنسيق الذي تُورثه الشرائح العادية. يمكنك إضافة، والوصول إلى، واستنساخ، وإزالة شرائح التخطيط، وكذلك تنظيف الشرائح غير المستخدمة لتقليل حجم العرض التقديمي.

## **Add a Layout Slide**

يمكنك إنشاء شريحة تخطيط مخصصة لتحديد تنسيق يمكن إعادة استخدامه. على سبيل المثال، قد تضيف مربع نص يظهر في جميع الشرائح التي تستخدم هذا التخطيط.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // إنشاء شريحة تخطيط بنوع تخطيط فارغ واسم مخصص.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // إضافة صندوق نص إلى شريحة التخطيط.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // إضافة شريحتين باستخدام هذا التخطيط؛ سيورث كل منهما النص من الشريحة.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** شريحة التخطيط تعمل كقوالب للشرائح الفردية. يمكنك تعريف العناصر المشتركة مرة واحدة وإعادة استخدامها عبر العديد من الشرائح.

> 💡 **Note 2:** عند إضافة أشكال أو نص إلى شريحة التخطيط، ستعرض جميع الشرائح القائمة على ذلك التخطيط هذا المحتوى المشترك تلقائيًا.
> تُظهر الصورة أدناه شريحتين، كل منهما يرث مربع نص من نفس شريحة التخطيط.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Access a Layout Slide**

يمكن الوصول إلى شرائح التخطيط عبر الفهرس أو عبر نوع التخطيط (مثل `Blank`، `Title`، `SectionHeader`، إلخ).

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

## **Remove a Layout Slide**

يمكنك إزالة شريحة تخطيط محددة إذا لم تعد بحاجة إليها.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // احصل على شريحة تخطيط حسب النوع وأزلها.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Unused Layout Slides**

لتقليل حجم العرض التقديمي، قد ترغب في إزالة شرائح التخطيط التي لا تُستخدم من قبل أي شريحة عادية.

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

## **Clone a Layout Slide**

يمكنك تكرار شريحة التخطيط باستخدام طريقة `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // احصل على شريحة تخطيط موجودة حسب النوع.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // استنسخ شريحة التخطيط إلى نهاية مجموعة شرائح التخطيط.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** شرائح التخطيط هي أدوات قوية لإدارة التنسيق المتسق عبر الشرائح. يتيح Aspose.Slides التحكم الكامل في إنشاء، وإدارة، وتحسين شرائح التخطيط.