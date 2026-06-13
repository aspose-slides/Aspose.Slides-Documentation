---
title: پشتیبانی از کتابخانه قابل قطع
type: docs
weight: 120
url: /fa/java/support-for-interruptable-library/
keywords:
- کتابخانه قابل قطع
- توکن وقفه
- توکن لغو
- وظیفه طولانی‌مدت
- قطع وظیفه
- پاورپوینت
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "وظایف طولانی‌مدت را با Aspose.Slides برای جاوا لغوپذیر کنید. رندرینگ و تبدیل‌ها برای پاورپوینت و OpenDocument را به‌صورت ایمن متوقف کنید، همراه با مثال‌ها."
---
## **نمای کلی**

Aspose.Slides مکانیزم پردازش قابل قطع برای وظایف طولانی‌مدت ارائه، مانند بازسازی، سریالی‌سازی و رندرینگ فراهم می‌کند. این مکانیزم بر پایه کلاس‌های `InterruptionToken` و `InterruptionTokenSource` است.

یک `InterruptionToken` می‌تواند به `LoadOptions` اختصاص داده شود و به سازنده `Presentation` پاس داده شود. وقتی `InterruptionTokenSource.interrupt()` فراخوانی می‌شود، وظیفه طولانی‌مدت مرتبط قطع می‌شود.

## **کتابخانه قابل قطع**

در [Aspose.Slides 18.4](https://releases.aspose.com/slides/fa/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/) ما کلاس‌های [InterruptionToken](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontokensource/) را معرفی کردیم. این کلاس‌ها به شما امکان می‌دهند وظایف طولانی‌مدت مانند بازسازی، سریالی‌سازی و رندرینگ را قطع کنید.

- [InterruptionTokenSource](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontokensource/) منبع توکن(ها) است که به [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) پاس داده می‌شود.
- وقتی [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) تنظیم می‌شود و نمونهٔ [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) پاس داده می‌شود، فراخوانی [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontokensource/#interrupt--) هر وظیفهٔ طولانی‌مدتی که با آن [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) مرتبط است را قطع می‌کند.

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // عمل را در یک رشته جداگانه اجرا کنید
Thread.sleep(10000);     // زمان‌پایان
tokenSource.interrupt(); // تبدیل را متوقف کنید
```

## **سوالات متداول**

**هدف کتابخانه قطع Aspose.Slides چیست؟**

این مکانیزمی را برای قطع عملیات طولانی‌مدت—مانند بارگذاری، ذخیره یا رندرینگ ارائه‌ها—قبل از اتمام آن‌ها فراهم می‌کند. این در زمانی که زمان پردازش باید محدود شود یا کار دیگر لازم نیست، مفید است.

**تفاوت [InterruptionToken](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontokensource/) چیست؟**

- `InterruptionToken` به API Aspose.Slides پاس داده می‌شود و در طول عملیات طولانی‌مدت بررسی می‌شود.
- `InterruptionTokenSource` در کد شما برای ایجاد توکن‌ها و ایجاد قطع‌ها با فراخوانی `Interrupt()` استفاده می‌شود.

**کدام وظایف می‌توانند قطع شوند؟**

هر وظیفه Aspose.Slides که یک [InterruptionToken](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontoken/) می‌پذیرد—مانند بارگذاری ارائه با `Presentation(path, loadOptions)` یا ذخیره با `Presentation.save(...)`—قابلیت قطع شدن دارد.

**آیا قطع شدن بلافاصله اتفاق می‌افتد؟**

خیر. قطع شدن تعاونی است: عملیات به‌صورت دوره‌ای توکن را بررسی می‌کند و به محض اینکه متوجه فراخوانی [Interrupt()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontokensource/#interrupt--) شود، متوقف می‌شود.

**اگر پس از تکمیل یک وظیفه، [Interrupt()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontokensource/#interrupt--) را فراخوانی کنم چه می‌شود؟**

هیچ‌چه—در صورتی که وظیفه مربوطه پیش از این تکمیل شده باشد، فراخوانی تأثیری ندارد.

**آیا می‌توانم از همان [InterruptionTokenSource](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontokensource/) برای چندین وظیفه استفاده مجدد کنم؟**

بله—اما پس از اینکه [Interrupt()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/interruptiontokensource/#interrupt--) را بر روی آن منبع فراخوانی کردید، تمام وظایفی که از توکن‌های آن استفاده می‌کنند قطع می‌شوند. برای مدیریت مستقل وظایف، از منابع توکن جداگانه استفاده کنید.