---
title: انتقال اسلاید
type: docs
weight: 110
url: /fa/java/examples/elements/slide-transition/
keywords:
- نمونه کد
- انتقال اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "تسلط بر انتقال‌های اسلاید در Aspose.Slides برای Java: افزودن، سفارشی‌سازی و ترتیب‌دهی افکت‌ها و مدت‌ها با مثال‌های Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه اعمال افکت‌های انتقال اسلاید و زمان‌بندی‌ها را با **Aspose.Slides for Java** نشان می‌دهد.

## **افزودن انتقال اسلاید**

یک افکت انتقال محو را بر روی اولین اسلاید اعمال کنید.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // اعمال یک انتقال محو.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به انتقال اسلاید**

نوع انتقالی که در حال حاضر به یک اسلاید اختصاص یافته است را بخوانید.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // دسترسی به نوع انتقال.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **حذف انتقال اسلاید**

هر افکت انتقالی را با تنظیم نوع به `None` پاک کنید.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // حذف انتقال با تنظیم None.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم مدت زمان انتقال**

مدت زمان نمایش اسلاید قبل از پیشرفت خودکار را مشخص کنید.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // به میلی ثانیه.
    } finally {
        presentation.dispose();
    }
}
```