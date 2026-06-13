---
title: پردازش چندنخی در Aspose.Slides برای Node.js از طریق Java
linktitle: چندنخی
type: docs
weight: 310
url: /fa/nodejs-java/multithreading/
keywords:
- چندنخی
- چندین رشته
- کار موازی
- تبدیل اسلایدها
- اسلایدها به تصاویر
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "پردازش چندنخی Aspose.Slides برای Node.js از طریق Java عملکرد پردازش PowerPoint و OpenDocument را افزایش می‌دهد. بهترین شیوه‌ها را برای جریان کار کارآمد ارائه‌ها کشف کنید."
---
## **مقدمه**

در حالی که کار موازی با ارائه‌ها (به جز تجزیه/بارگذاری/کلون کردن) ممکن است و اکثر اوقات همه چیز به خوبی پیش می‌رود، اما احتمال کمی وجود دارد که هنگام استفاده از کتابخانه در چندین رشته نتایج نادرستی دریافت کنید.

ما قویاً توصیه می‌کنیم که **از** یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) **استفاده نکنید** در محیط چندنخی زیرا ممکن است منجر به خطاها یا شکست‌های پیش‌بینی‌نشده‌ای شود که به سادگی قابل تشخیص نیستند.

استفاده از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) در چندین رشته **امن** نیست. چنین عملیاتی **پشتیبانی** نمی‌شود. اگر نیاز به انجام این کارها دارید، باید عملیات را با استفاده از چندین پردازش تک‌نخی موازی کنید و هر یک از این پردازش‌ها باید از نمونهٔ ارائهٔ خود استفاده کنند.

## **تبدیل اسلایدهای ارائه به تصاویر به‌صورت موازی**

فرض کنیم می‌خواهیم تمام اسلایدهای یک ارائهٔ پاورپوینت را به تصاویر PNG به‌صورت موازی تبدیل کنیم. از آنجا که استفاده از یک نمونهٔ `Presentation` در چندین رشته ناامن است، اسلایدهای ارائه را به ارائه‌های جداگانه تقسیم می‌کنیم و اسلایدها را به‌صورت موازی به تصاویر تبدیل می‌کنیم، به‌طوری که هر ارائه در یک رشتهٔ جداگانه استفاده شود. مثال کد زیر نشان می‌دهد چگونه این کار انجام شود.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // استخراج اسلاید i به یک ارائهٔ جداگانه.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // منتظر بمانید تا تمام کارها کامل شوند.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **سوالات متداول**

**آیا نیاز است در هر رشته تنظیم مجوز را صدا بزنم؟**

خیر. کافی است یک‌بار برای هر فرآیند/دامنهٔ برنامه قبل از شروع رشته‌ها انجام شود. اگر [license setup](/slides/fa/nodejs-java/licensing/) ممکن است به صورت همزمان صدا زده شود (به‌عنوان مثال هنگام مقداردهی تنبل)، آن فراخوانی را همزمان کنید زیرا متد تنظیم مجوز خود به خود thread‑safe نیست.

**آیا می‌توانم اشیای `Presentation` یا `Slide` را بین رشته‌ها عبور دهم؟**

عبور اشیای «زنده» ارائه بین رشته‌ها توصیه نمی‌شود: برای هر رشته یک نمونهٔ مستقل استفاده کنید یا پیش از آن ارائه‌ها/کنترلرهای اسلاید جداگانه‌ای برای هر رشته ایجاد کنید. این روش مطابق با توصیهٔ عمومی برای عدم اشتراک یک نمونهٔ ارائه بین رشته‌هاست.

**آیا ایمن است که خروجی به قالب‌های مختلف (PDF، HTML، تصاویر) را به‌صورت موازی انجام دهیم به شرطی که هر رشته یک نمونهٔ `Presentation` داشته باشد؟**

بله. با داشتن نمونه‌های مستقل و مسیرهای خروجی مجزا، چنین کارهایی معمولاً به‌درستی موازی می‌شوند؛ از هرگونه به اشتراک‌گذاری اشیای ارائه و جریان‌های I/O مشترک خودداری کنید.

**در محیط چندنخی باید با تنظیمات سراسری قلم (پوشه‌ها، جایگزینی‌ها) چه کنم؟**

تمام تنظیمات سراسری قلم را قبل از شروع رشته‌ها مقداردهی کنید و در طول کار موازی آن‌ها را تغییر ندهید. این کار رقابت‌های دسترسی به منابع قلم مشترک را از بین می‌برد.