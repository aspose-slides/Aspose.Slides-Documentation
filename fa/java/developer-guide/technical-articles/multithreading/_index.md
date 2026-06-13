---
title: کار چندرشته‌ای در Aspose.Slides برای جاوا
linktitle: چندرشته‌ای
type: docs
weight: 310
url: /fa/java/multithreading/
keywords:
- چندرشته‌ای
- چندین رشته
- کار موازی
- تبدیل اسلایدها
- اسلایدها به تصویر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "کار چندرشته‌ای Aspose.Slides برای جاوا، پردازش PowerPoint و OpenDocument را افزایش می‌دهد. بهترین روش‌ها برای جریان کارهای مؤثر ارائه را کشف کنید."
---
## **معرفی**

در حالی که کار موازی با ارائه‌ها (به جز تجزیه/بارگذاری/کلون) امکان‌پذیر است و اکثر اوقات همه چیز خوب پیش می‌رود، احتمال کمی وجود دارد که هنگام استفاده از کتابخانه در چندین رشته نتایج نادرست دریافت کنید.

ما اکیداً توصیه می‌کنیم که **از یک** [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) **در محیط چندرشته‌ای استفاده نکنید** زیرا ممکن است منجر به خطاها یا شکست‌های غیرقابل پیش‌بینی شود که به راحتی تشخیص داده نمی‌شوند.

بارگذاری، ذخیره‌سازی و/یا کلون کردن یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) در چندین رشته **امن نیست**. چنین عملیات‌هایی **پشتیبانی نمی‌شود**. اگر نیاز به انجام این کارها دارید، باید عملیات را با استفاده از چندین فرآیند تک‌رشته‌ای موازی کنید و هر یک از این فرآیندها باید از نمونه ارائه خود استفاده کند.

## **تبدیل اسلایدهای ارائه به تصویر به صورت موازی**

فرض کنید می‌خواهیم تمام اسلایدهای یک ارائهٔ PowerPoint را به تصاویر PNG به صورت موازی تبدیل کنیم. از آنجا که استفاده از یک نمونهٔ `Presentation` در چندین رشته ناامن است، اسلایدهای ارائه را به ارائه‌های جداگانه تقسیم می‌کنیم و اسلایدها را به تصاویر تبدیل می‌کنیم، به‌طوری که هر ارائه در یک رشتهٔ جداگانه استفاده شود. مثال کد زیر نشان می‌دهد چگونه این کار را انجام می‌دهیم.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // اسلاید i را به یک ارائهٔ جداگانه استخراج کنید.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // اسلاید را در یک وظیفهٔ جداگانه به تصویر تبدیل کنید.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Wait for all tasks to complete.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **پرسش‌های متداول**

**آیا باید تنظیم لایسنس را در هر رشته فراخوانی کنم؟**

خیر. کافی است یک بار قبل از شروع رشته‌ها در هر فرآیند/دامنهٔ برنامه انجام شود. اگر [license setup](/slides/fa/java/licensing/) ممکن است به‌طور همزمان فراخوانی شود (مثلاً هنگام مقداردهی lazy)، آن فراخوانی را همگام‌سازی کنید زیرا خود روش تنظیم لایسنس thread‑safe نیست.

**آیا می‌توانم اشیای `Presentation` یا `Slide` را بین رشته‌ها عبور دهم؟**

عبور اشیای «زنده» ارائه بین رشته‌ها توصیه نمی‌شود: برای هر رشته یک نمونه مستقل استفاده کنید یا پیش از آن ارائه‌ها/کانتینرهای اسلاید جداگانه‌ای برای هر رشته ایجاد کنید. این رویکرد مطابق با توصیهٔ کلی عدم اشتراک یک نمونهٔ ارائه بین رشته‌هاست.

**آیا ایمن است که صادرات به فرمت‌های مختلف (PDF، HTML، تصاویر) را موازی‌سازی کنم به شرطی که هر رشته دارای نمونهٔ `Presentation` خودش باشد؟**

بله. با نمونه‌های مستقل و مسیرهای خروجی جداگانه، چنین کارها معمولاً به‌درستی موازی می‌شوند؛ از هر گونه اشتراک اشیای ارائه و جریان‌های I/O مشترک خودداری کنید.

**در مورد تنظیمات قلم جهانی (پوشه‌ها، جایگزین‌ها) در چندرشته‌ای چه کاری باید انجام دهم؟**

تمام تنظیمات [font settings](/slides/fa/java/powerpoint-fonts/) را قبل از شروع رشته‌ها مقداردهی کنید و در طول کار موازی آنها را تغییر ندهید. این کار مسابقه‌ها را هنگام دسترسی به منابع قلم مشترک از بین می‌برد.