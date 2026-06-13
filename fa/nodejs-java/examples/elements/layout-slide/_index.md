---
title: اسلاید طرح‌بندی
type: docs
weight: 20
url: /fa/nodejs-java/examples/elements/layout-slide/
keywords:
- مثال کد
- اسلاید طرح‌بندی
- پاورپوینت
- سند باز
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "اسلایدهای قالب اصلی در Aspose.Slides برای Node.js: انتخاب، اعمال و سفارشی‌سازی قالب‌های اسلید، جای‌دارها و مسترها با مثال برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه می‌توان با **Layout Slides** در Aspose.Slides برای Node.js از طریق Java کار کرد. یک اسلاید طرح‌بندی، طراحی و قالب‌بندی‌ای را که اسلایدهای عادی به ارث می‌برند، تعریف می‌کند. می‌توانید اسلایدهای طرح‌بندی را اضافه، دسترسی، کلون و حذف کنید و همچنین اسلایدهای غیرقابل استفاده را پاک‌سازی کنید تا اندازه ارائه کاهش یابد.

## **Add a Layout Slide**

می‌توانید یک اسلاید طرح‌بندی سفارشی ایجاد کنید تا قالب‌بندی قابل استفاده مجدد را تعریف کنید.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // یک اسلاید طرح‌بندی با نوع طرح‌بندی خالی و نام سفارشی ایجاد کنید.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** اسلایدهای طرح‌بندی به عنوان قالب برای اسلایدهای فردی عمل می‌کنند. می‌توانید عناصر مشترک را یک‌بار تعریف کنید و در اسلایدهای متعدد از آنها استفاده کنید.

> 💡 **Note 2:** وقتی اشکال یا متن را به یک اسلاید طرح‌بندی اضافه می‌کنید، تمام اسلایدهایی که بر پایه آن طرح هستند، به‌ طور خودکار این محتوای مشترک را نمایش می‌دهند.  
> تصویر زیر دو اسلاید را نشان می‌دهد که هر کدام یک جعبه متن را از همان اسلاید طرح‌بندی به ارث می‌برند.

![اسلایدهای وراثت‌دار محتویات طرح](layout-slide-result.png)

## **Access a Layout Slide**

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // دسترسی به یک اسلاید طرح‌بندی بر اساس ایندکس.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // دسترسی به یک اسلاید طرح‌بندی بر اساس نوع.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Layout Slide**

اگر دیگر نیازی به یک اسلاید طرح‌بندی خاص نیست، می‌توانید آن را حذف کنید.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // یک اسلاید طرح‌بندی را بر اساس نوع دریافت کرده و حذف کنید.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Unused Layout Slides**

برای کاهش اندازه ارائه، ممکن است بخواهید اسلایدهای طرح‌بندی که توسط هیچ اسلاید عادی استفاده نمی‌شوند را حذف کنید.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // به طور خودکار تمام اسلایدهای طرح‌بندی که توسط هیچ اسلایدی ارجاع داده نشده‌اند را حذف می‌کند.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Clone a Layout Slide**

می‌توانید یک اسلاید طرح‌بندی را با استفاده از متد `addClone` تکثیر کنید.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // یک اسلاید طرح‌بندی موجود را بر اساس نوع دریافت کنید.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // اسلاید طرح‌بندی را به انتهای مجموعه اسلایدهای طرح‌بندی کلون کنید.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** اسلایدهای طرح‌بندی ابزارهای قدرتمندی برای مدیریت قالب‌بندی ثابت در تمام اسلایدها هستند. Aspose.Slides کنترل کامل بر ایجاد، مدیریت و بهینه‌سازی اسلایدهای طرح‌بندی را فراهم می‌کند.