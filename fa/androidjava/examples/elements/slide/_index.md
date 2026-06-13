---
title: اسلاید
type: docs
weight: 10
url: /fa/androidjava/examples/elements/slide/
keywords:
- مثال کد
- اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "کنترل اسلایدها در Aspose.Slides برای Android: ایجاد، کپی، تغییر ترتیب، تغییر اندازه، تنظیم پس‌زمینه‌ها و اعمال انتقال‌ها با Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله مجموعه‌ای از مثال‌ها را ارائه می‌دهد که نشان می‌دهد چگونه با اسلایدها با استفاده از **Aspose.Slides for Android via Java** کار کنید. شما خواهید آموخت چگونه اسلایدها را با استفاده از کلاس `Presentation` اضافه، دسترسی، کپی، ترتیب‌دادن مجدد و حذف کنید.

هر مثال زیر شامل توضیحی کوتاه و سپس یک قطعه کد به زبان جاوا است.

## **اضافه کردن اسلاید**

برای افزودن اسلاید جدید، ابتدا باید یک قالب را انتخاب کنید. در این مثال، از قالب `Blank` استفاده می‌کنیم و یک اسلاید خالی به ارائه اضافه می‌کنیم.

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

> 💡 **نکته:** هر قالب اسلاید از یک اسلاید اصلی مشتق می‌شود که طراحی کلی و ساختار نگهدارنده‌ها را تعریف می‌کند. تصویر زیر نشان می‌دهد که اسلایدهای اصلی و قالب‌های مرتبط با آنها چگونه در PowerPoint سازماندهی شده‌اند.

![رابطه اسلاید اصلی و قالب](master-layout-slide.png)

## **دسترسی به اسلایدها بر اساس اندیس**

می‌توانید اسلایدها را با استفاده از اندیس آنها دسترسی پیدا کنید، یا اندیس یک اسلاید را بر اساس یک مرجع پیدا کنید. این برای پیمایش یا تغییر اسلایدهای خاص مفید است.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // یک اسلاید خالی دیگر اضافه کنید.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // دسترس به اسلایدها بر اساس اندیس.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // اندیس اسلاید را از یک مرجع دریافت کنید، سپس با اندیس به آن دسترسی پیدا کنید.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **کپی یک اسلاید**

این مثال نشان می‌دهد چگونه یک اسلاید موجود را کپی کنید. اسلاید کپی‌شده به‌صورت خودکار به انتهای مجموعه اسلایدها اضافه می‌شود.

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

## **تغییر ترتیب اسلایدها**

می‌توانید ترتیب اسلایدها را با جابجا کردن یک اسلاید به اندیس جدید تغییر دهید. در این مثال، یک اسلاید کپی‌شده را به اولین موقعیت منتقل می‌کنیم.

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

## **حذف یک اسلاید**

برای حذف یک اسلاید، به سادگی به آن ارجاع دهید و متد `remove` را صدا بزنید. این مثال یک اسلاید دوم اضافه می‌کند و سپس اسلاید اصلی را حذف می‌نماید، به طوری که فقط اسلاید جدید باقی می‌ماند.

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