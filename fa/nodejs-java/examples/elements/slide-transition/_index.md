---
title: انتقال اسلاید
type: docs
weight: 110
url: /fa/nodejs-java/examples/elements/slide-transition/
keywords:
- مثال کد
- انتقال اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "به تسلط بر تغییرات اسلاید در Aspose.Slides برای Node.js: افزودن، سفارشی‌سازی و ترتیب‌گذاری اثرها و مدت‌ها با مثال‌ها برای ارائه‌های PPT، PPTX و ODP دست یابید."
---
این مقاله نحوه اعمال افکت‌های تغییر اسلاید و زمان‌بندی‌ها را با **Aspose.Slides for Node.js via Java** نشان می‌دهد.

## **افزودن تغییر اسلاید**

یک افکت تغییر محو (fade) را بر روی اولین اسلاید اعمال کنید.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // یک انتقال محو اعمال کنید.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به تغییر اسلاید**

نوع تغییر اسلایدی که در حال حاضر به یک اسلاید اختصاص یافته است را بخوانید.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // دسترسی به نوع انتقال.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **حذف تغییر اسلاید**

هر اثر تغییر را با تنظیم نوع به `None` پاک کنید.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // حذف انتقال با تنظیم none.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم مدت زمان تغییر**

مشخص کنید که اسلاید تا چه مدت قبل از پیشروی خودکار نمایش داده شود.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // بر حسب میلی‌ثانیه.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```