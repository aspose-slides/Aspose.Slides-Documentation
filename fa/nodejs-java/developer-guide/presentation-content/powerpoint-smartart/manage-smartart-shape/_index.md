---
title: مدیریت گرافیک‌های SmartArt در ارائه‌ها با استفاده از JavaScript
linktitle: گرافیک‌های SmartArt
type: docs
weight: 20
url: /fa/nodejs-java/manage-smartart-shape/
keywords:
- شیء SmartArt
- گرافیک SmartArt
- سبک SmartArt
- رنگ SmartArt
- ایجاد SmartArt
- افزودن SmartArt
- ویرایش SmartArt
- تغییر SmartArt
- دسترسی به SmartArt
- نوع Layout SmartArt
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد، ویرایش و استایل‌دهی خودکار گرافیک‌های SmartArt در PowerPoint با استفاده از JavaScript در Aspose.Slides، شامل مثال‌های کد مختصر و راهنمایی‌های متمرکز بر عملکرد."
---
## **نمای کلی**

Aspose.Slides به شما اجازه می‌دهد تا گرافیک‌های SmartArt را به صورت برنامه‌نویسی در ارائه‌های PowerPoint ایجاد و مدیریت کنید. این مقاله توضیح می‌دهد چگونه یک شکل SmartArt را به یک اسلاید اضافه کنید، به اشکال SmartArt موجود دسترسی پیدا کنید، SmartArt را بر اساس نوع Layout خاصی پیدا کنید و ظاهر بصری آن را با تغییر سبک SmartArt یا سبک رنگی به‌روزرسانی کنید.

مثال‌ها نشان می‌دهند چگونه با اشکال SmartArt از طریق مجموعهٔ شکل‌های اسلاید ارائه کار کنید، بررسی کنید آیا یک شکل SmartArt است و سپس ویژگی‌های آن را تغییر یا بررسی کنید.

## **Create SmartArt Shape**
Aspose.Slides for Node.js via Java یک API برای ایجاد اشکال SmartArt فراهم کرده است. برای ایجاد یک شکل SmartArt در یک اسلاید، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. از طریق Index، مرجع یک اسلاید را به‌دست آورید.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) با تنظیم آن [LayoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArtLayoutType).
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```javascript
// نمونه‌سازی کلاس Presentation
var pres = new aspose.slides.Presentation();
try {
    // دریافت اسلاید اول
    var slide = pres.getSlides().get_Item(0);
    // افزودن شکل Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // ذخیره‌سازی ارائه
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شکل: شکل SmartArt به اسلاید اضافه شد**|

## **Access SmartArt Shape in Slide**
کد زیر برای دسترسی به اشکال SmartArt اضافه‌شده در اسلاید ارائه استفاده خواهد شد. در کد نمونه ما از هر شکل داخل اسلاید عبور می‌کنیم و بررسی می‌کنیم آیا یک شکل [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است. اگر شکل از نوع SmartArt باشد، آن را به نمونهٔ [**SmartArt**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) تبدیل می‌کنیم.

```javascript
// بارگذاری ارائه موردنظر
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // عبور از تمام اشکال داخل اسلاید اول
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تبدیل نوع شکل به SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Access SmartArt Shape with Particular Layout Type**
کد نمونهٔ زیر به شما کمک می‌کند تا به شکل [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) با LayoutType خاص دسترسی پیدا کنید. لطفاً توجه کنید که نمی‌توانید LayoutType را برای SmartArt تغییر دهید زیرا فقط هنگام افزودن شکل [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) تنظیم می‌شود و فقط قابل خواندن است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید و ارائه حاوی شکل SmartArt را بارگذاری کنید.
1. از طریق Index، مرجع اولین اسلاید را به‌دست آورید.
1. در تمام اشکال داخل اولین اسلاید عبور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است و در صورت بودن، شکل انتخاب شده را به SmartArt تبدیل کنید.
1. شکل SmartArt با LayoutType خاص را بررسی کنید و کارهای مورد نیاز بعدی را انجام دهید.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // عبور از تمام اشکال داخل اسلاید اول
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تبدیل نوع شکل به SmartArtEx
            var smart = shape;
            // بررسی Layout SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Change SmartArt Shape Style**
در این مثال، نحوه تغییر سبک سریع برای هر شکل SmartArt را یاد می‌گیریم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید و ارائه حاوی شکل SmartArt را بارگذاری کنید.
1. از طریق Index، مرجع اولین اسلاید را به‌دست آورید.
1. در تمام اشکال داخل اولین اسلاید عبور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است و در صورت بودن، شکل انتخاب شده را به SmartArt تبدیل کنید.
1. شکل SmartArt با Style خاص را پیدا کنید.
1. Style جدید را برای شکل SmartArt تنظیم کنید.
1. ارائه را ذخیره کنید.

```javascript
// نمونه‌سازی کلاس Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // دریافت اولین اسلاید
    var slide = pres.getSlides().get_Item(0);
    // عبور از تمام اشکال داخل اولین اسلاید
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تبدیل نوع شکل به SmartArtEx
            var smart = shape;
            // بررسی سبک SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // تغییر سبک SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // ذخیره‌سازی ارائه
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شکل: شکل SmartArt با سبک تغییر یافته**|

## **Change SmartArt Shape Color Style**
در این مثال، نحوه تغییر سبک رنگی برای هر شکل SmartArt را می‌آموزیم. در کد نمونهٔ زیر به شکل SmartArt با سبک رنگی خاص دسترسی پیدا می‌کنیم و سبک آن را تغییر می‌دهیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید و ارائه حاوی شکل SmartArt را بارگذاری کنید.
1. از طریق Index، مرجع اولین اسلاید را به‌دست آورید.
1. در تمام اشکال داخل اولین اسلاید عبور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است و در صورت بودن، شکل انتخاب شده را به SmartArt تبدیل کنید.
1. شکل SmartArt با Color Style خاص را پیدا کنید.
1. Color Style جدید را برای شکل SmartArt تنظیم کنید.
1. ارائه را ذخیره کنید.

```javascript
// نمونه‌سازی کلاس Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // دریافت اولین اسلاید
    var slide = pres.getSlides().get_Item(0);
    // عبور از تمام اشکال داخل اولین اسلاید
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تبدیل نوع شکل به SmartArtEx
            var smart = shape;
            // بررسی نوع رنگ SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // تغییر نوع رنگ SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // ذخیره‌سازی ارائه
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**شکل: شکل SmartArt با سبک رنگی تغییر یافته**|

## **FAQ**

**آیا می‌توانم SmartArt را به عنوان یک شیء واحد انیمیشن کنم؟**

بله. SmartArt یک شکل است، بنابراین می‌توانید همان‌طور که برای سایر شکل‌ها اعمال می‌کنید، [standard animations](/slides/fa/nodejs-java/powerpoint-animation/) را از طریق API انیمیشن‌ها (ورودی، خروجی، تأکید، مسیرهای حرکتی) اعمال کنید.

**چگونه می‌توانم SmartArt خاصی را در اسلاید پیدا کنم اگر شناسه داخلی آن را نمی‌دانم؟**

متن جایگزین (AltText) را تنظیم کنید و از آن برای جستجوی شکل بر اساس این مقدار استفاده کنید؛ این روش پیشنهادی برای یافتن شکل موردنظر است.

**آیا می‌توانم SmartArt را با سایر شکل‌ها گروه‌بندی کنم؟**

بله. می‌توانید SmartArt را با سایر شکل‌ها (تصاویر، جداول و غیره) گروه‌بندی کنید و سپس [گروه را دستکاری کنید](/slides/fa/nodejs-java/group/).

**چگونه می‌توانم تصویر یک SmartArt خاص را دریافت کنم (مثلاً برای پیش‌نمایش یا گزارش)؟**

یک تصویر/تصویر کوچک از شکل استخراج کنید؛ کتابخانه می‌تواند [شکل‌های جداگانه را رندر کند](/slides/fa/nodejs-java/create-shape-thumbnails/) به فایل‌های رستر (PNG/JPG/TIFF).

**آیا ظاهر SmartArt هنگام تبدیل کل ارائه به PDF حفظ می‌شود؟**

بله. موتور رندرینگ برای [صدور PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) با کیفیت بالا هدف‌گذاری می‌شود و گزینه‌های متنوعی برای کیفیت و سازگاری فراهم می‌کند.