---
title: اسلاید
type: docs
weight: 10
url: /fa/java/examples/elements/slide/
keywords:
- مثال کد
- اسلاید
- پاورپوینت
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "کنترل اسلایدها در Aspose.Slides برای Java: ایجاد، کلون، تغییر ترتیب، تغییر اندازه، تنظیم پس‌زمینه‌ها و اعمال انتقال‌ها با Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله مجموعه‌ای از مثال‌ها را ارائه می‌دهد که نشان می‌دهد چگونه می‌توان با اسلایدها با استفاده از **Aspose.Slides for Java** کار کرد. شما یاد خواهید گرفت چگونه اسلایدها را با استفاده از کلاس `Presentation` اضافه، دسترسی، کلون، ترتیب‌مجدد و حذف کنید.

هر مثال زیر شامل توضیح کوتاهی است که پس از آن یک قطعه کد به زبان Java می‌آید.

## **افزودن اسلاید**

برای افزودن اسلاید جدید، ابتدا باید یک طرح‌بندی (layout) را انتخاب کنید. در این مثال، از طرح‌بندی `Blank` استفاده می‌کنیم و یک اسلاید خالی را به ارائه اضافه می‌کنیم.

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

> 💡 **نکته:** هر طرح‌بندی اسلاید از یک اسلاید اصلی (master slide) نشأت می‌گیرد که طراحی کلی و ساختار جای‌دارها (placeholder) را تعریف می‌کند. تصویر زیر نحوه سازماندهی اسلایدهای اصلی و طرح‌بندی‌های مرتبط با آن‌ها در PowerPoint را نشان می‌دهد.

![رابطه اسلاید اصلی و طرح‌بندی](master-layout-slide.png)

## **دسترسی به اسلایدها بر اساس اندیس**

شما می‌توانید با استفاده از اندیس هر اسلاید به آن دسترسی پیدا کنید، یا اندیس یک اسلاید را بر پایه یک مرجع پیدا کنید. این برای پیمایش یا تغییر اسلایدهای خاص مفید است.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // یک اسلاید خالی دیگر اضافه کنید.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // دسترسی به اسلایدها بر اساس اندیس.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // دریافت اندیس اسلاید از یک مرجع، سپس دسترسی به آن بر اساس اندیس.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **کلون کردن اسلاید**

این مثال نشان می‌دهد چگونه یک اسلاید موجود را کلون کنید. اسلاید کلون‌شده به صورت خودکار به انتهای مجموعه اسلایدها افزوده می‌شود.

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

می‌توانید ترتیب اسلایدها را با جابجایی یک اسلاید به اندیس جدید تغییر دهید. در این مثال، یک اسلاید کلون‌شده را به موقعیت اول منتقل می‌کنیم.

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

## **حذف اسلاید**

برای حذف یک اسلاید، به سادگی به آن ارجاع دهید و متد `remove` را فراخوانی کنید. این مثال یک اسلاید دوم اضافه می‌کند و سپس اسلاید اصلی را حذف می‌نماید، به طوری که تنها اسلاید جدید باقی می‌ماند.

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