---
title: شريحة
type: docs
weight: 10
url: /ar/androidjava/examples/elements/slide/
keywords:
- مثال كود
- شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "التحكم في الشرائح باستخدام Aspose.Slides للـ Android: إنشاء، استنساخ، إعادة ترتيب، تغيير الحجم، تعيين الخلفيات، وتطبيق الانتقالات باستخدام Java لعروض PPT، PPTX، وODP."
---
توفر هذه المقالة سلسلة من الأمثلة التي توضح كيفية التعامل مع الشرائح باستخدام **Aspose.Slides for Android عبر Java**. ستتعلم كيفية إضافة، الوصول، استنساخ، إعادة ترتيب، وإزالة الشرائح باستخدام الفئة `Presentation`.

يتضمن كل مثال أدناه شرحًا مختصرًا يليه مقتطف كود بلغة Java.

## **إضافة شريحة**

لإضافة شريحة جديدة، يجب أولاً اختيار تخطيط. في هذا المثال، نستخدم تخطيط `Blank` ونضيف شريحة فارغة إلى العرض التقديمي.

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

> 💡 **ملاحظة:** كل تخطيط شريحة مشتق من شريحة رئيسية، التي تحدد التصميم العام وبنية العناصر النائبة. تُظهر الصورة أدناه كيف يتم تنظيم الشرائح الرئيسية وتخطيطاتها المرتبطة في PowerPoint.

![العلاقة بين الشريحة الرئيسية والتخطيط](master-layout-slide.png)

## **الوصول إلى الشرائح حسب الفهرس**

يمكنك الوصول إلى الشرائح باستخدام فهرسها، أو العثور على فهرس شريحة بناءً على إشارة. هذا مفيد لتكرار الشرائح أو تعديل شرائح محددة.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // أضف شريحة فارغة أخرى.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // الوصول إلى الشرائح حسب الفهرس.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // الحصول على فهرس الشريحة من مرجع، ثم الوصول إليه حسب الفهرس.
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

يمكنك تغيير ترتيب الشرائح بنقل إحدى الشرائح إلى فهرس جديد. في هذه الحالة، نقوم بنقل الشريحة المستنسخة إلى الموضع الأول.

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

لإزالة شريحة، ما عليك سوى الإشارة إليها واستدعاء `remove`. يضيف هذا المثال شريحة ثانية ثم يزيل الأصلية، لتبقى الشريحة الجديدة فقط.

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