---
title: اسلاید
type: docs
weight: 10
url: /fa/nodejs-java/examples/elements/slide/
keywords:
- مثال کد
- اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کنترل اسلایدها در Aspose.Slides برای Node.js: ایجاد، کلون، بازمرتب‌سازی، تغییر اندازه، تنظیم پس‌زمینه‌ها و اعمال انتقال‌ها برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله مجموعه‌ای از مثال‌ها را ارائه می‌دهد که نشان می‌دهد چگونه می‌توان با اسلایدها با استفاده از **Aspose.Slides for Node.js via Java** کار کرد. شما یاد خواهید گرفت چگونه اسلایدها را اضافه، دسترسی، کلون، بازمرتب‌سازی و حذف کنید با استفاده از کلاس `Presentation`.

هر مثال در زیر شامل توضیحی کوتاه و سپس یک قطعه کد در JavaScript است.

## **افزودن اسلاید**

برای افزودن یک اسلاید جدید، ابتدا باید یک طرح‌بندی انتخاب کنید. در این مثال، از طرح‌بندی `Blank` استفاده می‌کنیم و یک اسلاید خالی به ارائه اضافه می‌کنیم.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **توجه:** هر طرح‌بندی اسلاید از یک اسلاید اصلی مشتق می‌شود که طراحی کلی و ساختار جای‌گیرها را تعریف می‌کند. تصویر زیر نشان می‌دهد چگونه اسلایدهای اصلی و طرح‌بندی‌های مرتبط با آن‌ها در PowerPoint سازماندهی شده‌اند.

![رابطهٔ اسلاید اصلی و طرح‌بندی](master-layout-slide.png)

## **دسترسی به اسلایدها بر اساس ایندکس**

می‌توانید اسلایدها را با استفاده از ایندکس آن‌ها دسترسی پیدا کنید. این برای پیمایش یا تغییر اسلایدهای خاص مفید است.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // دسترسی به اسلاید با ایندکس.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **کلون یک اسلاید**

این مثال نشان می‌دهد چگونه یک اسلاید موجود را کلون کنید. اسلاید کلون شده به طور خودکار در انتهای مجموعه اسلایدها اضافه می‌شود.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **بازچینی اسلایدها**

می‌توانید ترتیب اسلایدها را با جابه‌جایی یکی به ایندکس جدید تغییر دهید. در این حالت، یک اسلاید را به موقعیت اول منتقل می‌کنیم.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // بازمرتب‌سازی اسلایدها با جابجایی اسلاید دوم به موقعیت اول.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف یک اسلاید**

برای حذف یک اسلاید، به سادگی به آن ارجاع دهید و متد `remove` را فراخوانی کنید. این مثال یک اسلاید دوم اضافه می‌کند و سپس اسلاید اصلی را حذف می‌نماید؛ به طوری که فقط اسلاید جدید باقی می‌ماند.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```