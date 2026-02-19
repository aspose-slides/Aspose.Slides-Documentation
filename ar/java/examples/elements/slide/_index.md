---
title: شريحة
type: docs
weight: 10
url: /ar/java/examples/elements/slide/
keywords:
- مثال شفرة
- شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحكم في الشرائح في Aspose.Slides for Java: إنشاء، استنساخ، إعادة ترتيب، تغيير الحجم، ضبط الخلفيات، وتطبيق الانتقالات باستخدام Java لعروض PPT و PPTX و ODP."
---
توفر هذه المقالة مجموعة من الأمثلة التي توضح كيفية العمل مع الشرائح باستخدام **Aspose.Slides for Java**. ستتعلم كيفية إضافة، الوصول، استنساخ، إعادة ترتيب، وإزالة الشرائح باستخدام الفئة `Presentation`.

يتضمن كل مثال أدناه شرحًا موجزًا يليه مقتطف شفرة بلغة Java.

## **إضافة شريحة**

لإضافة شريحة جديدة، يجب عليك أولاً تحديد تخطيط. في هذا المثال، نستخدم تخطيط `Blank` ونضيف شريحة فارغة إلى العرض التقديمي.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة:** كل تخطيط شريحة مشتق من شريحة رئيسية، التي تحدد التصميم العام وبنية العناصر النائبة. الصورة أدناه توضح كيفية تنظيم الشرائح الرئيسية والتخطيطات المرتبطة بها في PowerPoint.

![العلاقة بين الشريحة الرئيسية والتخطيط](master-layout-slide.png)

## **الوصول إلى الشرائح حسب الفهرس**

يمكنك الوصول إلى الشرائح باستخدام فهرسها، أو العثور على فهرس شريحة بناءً على مرجع. هذا مفيد للتنقل عبر أو تعديل شرائح معينة.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // أضف شريحة فارغة أخرى.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // الوصول إلى الشرائح بواسطة الفهرس.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // احصل على فهرس الشريحة من مرجع، ثم الوصول إليه بواسطة الفهرس.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **استنساخ شريحة**

يوضح هذا المثال كيفية استنساخ شريحة موجودة. تُضاف الشريحة المستنسخة تلقائيًا إلى نهاية مجموعة الشرائح.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **إعادة ترتيب الشرائح**

يمكنك تغيير ترتيب الشرائح بنقل إحدى الشرائح إلى فهرس جديد. في هذه الحالة، ننقل الشريحة المستنسخة إلى الموضع الأول.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة شريحة**

لإزالة شريحة، ما عليك إلا الإشارة إليها واستدعاء `remove`. يضيف هذا المثال شريحة ثانية ثم يزيل الأصلية، مما يترك الشريحة الجديدة فقط.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```