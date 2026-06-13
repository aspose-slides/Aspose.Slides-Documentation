---
title: انتقال اسلاید
type: docs
weight: 110
url: /fa/androidjava/examples/elements/slide-transition/
keywords:
- مثال کد
- انتقال اسلاید
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "مدیریت انتقال‌های اسلاید در Aspose.Slides برای اندروید: افزودن، سفارشی‌سازی و توالی‌سازی افکت‌ها و مدت‌ها با مثال‌های جاوا برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه اعمال افکت‌های انتقال اسلاید و زمان‌بندی‌ها را با **Aspose.Slides for Android via Java** نشان می‌دهد.

## **افزودن یک انتقال اسلاید**

یک افکت انتقال محو را به اسلاید اول اعمال کنید.

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

## **دسترسی به یک انتقال اسلاید**

نوع انتقالی که در حال حاضر به اسلاید اختصاص داده شده است را بخوانید.

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

## **حذف یک انتقال اسلاید**

هر افکت انتقالی را با تنظیم نوع به `None` پاک کنید.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // حذف انتقال با تنظیم none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم مدت زمان انتقال**

مشخص کنید اسلاید تا چه مدت قبل از پیشروی خودکار نمایش داده شود.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // بر حسب میلی‌ثانیه.
    } finally {
        presentation.dispose();
    }
}
```