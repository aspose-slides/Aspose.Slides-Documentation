---
title: اسلاید مستر
type: docs
weight: 30
url: /fa/nodejs-java/examples/elements/master-slide/
keywords:
- مثال کد
- اسلاید مستر
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مثال‌های اسلاید مستر Aspose.Slides برای Node.js را کشف کنید: ایجاد، ویرایش و استایل‌دهی به مسترها، مکان‌گیرها و تم‌ها در PPT، PPTX و ODP با کد واضح."
---
اسلایدهای مستر سطح بالای سلسله‌مراتب ارث‌بری اسلایدها در PowerPoint را تشکیل می‌دهند. یک **master slide** عناصر طراحی مشترک مانند پس‌زمینه‌ها، لوگوها و قالب‌بندی متن را تعریف می‌کند. **Layout slides** از اسلایدهای مستر ارث می‌گیرند و **normal slides** از اسلایدهای لایه‌بندی ارث می‌برند.

این مقاله نشان می‌دهد چگونه اسلایدهای مستر را با استفاده از Aspose.Slides برای Node.js از طریق Java ایجاد، اصلاح و مدیریت کنید.

## **افزودن اسلاید مستر**

این مثال نشان می‌دهد چگونه با کلون کردن اسلاید پیش‌فرض، یک اسلاید مستر جدید ایجاد کنیم. سپس بنر نام شرکت را از طریق ارث‌بری لایه به تمام اسلایدها اضافه می‌کند.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // کپی اسلاید مستر پیش‌فرض.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // یک بنر با نام شرکت به بالای اسلاید مستر اضافه کنید.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // اسلاید مستر جدید را به یک اسلاید لایه‌بندی اختصاص دهید.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // اسلاید لایه‌بندی را به اولین اسلاید در ارائه اختصاص دهید.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **یادداشت 1:** اسلایدهای مستر روشی برای اعمال برندینگ ثابت یا عناصر طراحی مشترک در تمام اسلایدها فراهم می‌کنند. هر تغییری که در مستر اعمال شود به‌صورت خودکار بر روی اسلایدهای لایه‌بندی و اسلایدهای عادی وابسته بازتاب خواهد یافت.

> 💡 **یادداشت 2:** هر شکل یا قالب‌بندی‌ای که به یک اسلاید مستر اضافه شود، توسط اسلایدهای لایه‌بندی به ارث می‌رسد و به نوبه خود به تمام اسلایدهای عادی که از آن لایه‌ها استفاده می‌کنند.  
> تصویر زیر نشان می‌دهد چگونه یک جعبه متن که در یک اسلاید مستر اضافه شده به‌صورت خودکار در اسلاید نهایی رندر می‌شود.

![مثال ارث‌بری مستر](master-slide-banner.png)

## **دسترسی به اسلاید مستر**

شما می‌توانید با استفاده از مجموعه مستر ارائه، به اسلایدهای مستر دسترسی پیدا کنید. در اینجا نحوه بازیابی و کار با آن‌ها آمده است:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // نوع پس‌زمینه را تغییر دهید.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلاید مستر**

اسلایدهای مستر می‌توانند یا بر اساس ایندکس یا بر اساس مرجع حذف شوند.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // حذف یک اسلاید مستر بر اساس ایندکس.
        presentation.getMasters().removeAt(0);

        // حذف یک اسلاید مستر بر اساس مرجع.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلایدهای مستر استفاده‌نشده**

برخی ارائه‌ها شامل اسلایدهای مستری هستند که استفاده نمی‌شوند. حذف این اسلایدها می‌تواند به کاهش حجم فایل کمک کند.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // حذف تمام اسلایدهای مستر استفاده‌نشده (حتی آنهایی که به‌عنوان Preserve علامت‌گذاری شده‌اند).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```