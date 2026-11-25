---
title: قطع عملیات ارائه طولانی‌مدت در جاوا
linktitle: قطع عملیات ارائه
type: docs
weight: 120
url: /fa/java/support-for-interruptable-library/
keywords:
- عملیات‌های قابل قطع
- توکن قطع
- توکن لغو
- کار طولانی‌مدت
- کار قطع
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه عملیات ارائه طولانی‌مدت را در Aspose.Slides برای جاوا لغو کنید و هنگام استخراج اسلایدها در یک حلقه، نتیجهٔ جزئی برگردانید."
---
## **نمای کلی**

Aspose.Slides for Java می‌تواند عملیات طولانی‌مدت مانند بارگیری، ذخیره‌سازی و رندر ارائه‌ها را مختل کند. برنامه شما می‌تواند از همان توکن قطع برای متوقف کردن یک حلقه قبل از اینکه اسلاید بعدی را پردازش کند، استفاده کند.

## **متوقف کردن یک عملیات ارائه**

یک [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) ایجاد کنید، توکن آن را با [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--) دریافت کنید و توکن را به [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) پاس بدهید. گزینه‌های بارگذاری را به سازندهٔ [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) منتقل کنید. برای درخواست لغو، روی منبع متد [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) را فراخوانی کنید. یک عملیات قابل قطع، زمانی که درخواست را مشاهده کند متوقف می‌شود.

مثال `sample.pptx` را به `sample.ppt` در یک نخ پس‌زمینه تبدیل می‌کند. نخ فراخوانی حداکثر تا ۱۰ ثانیه برای پایان تبدیل صبر می‌کند. اگر تبدیل هنوز در حال اجرا باشد، درخواست لغو می‌دهد و تا خروج کارگر صبر می‌کند.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **اتصال یک زمان‌سنج جاوا به Aspose.Slides**

برای تعیین محدودیت زمانی روی یک عملیات ارائه، از [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) استفاده کنید تا زمانی که زمان‌سنج منقضی شود، متد [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) را فراخوانی کند. مثال ۲۰ ثانیه برای بارگذاری `sample.pptx` و استخراج آن به `sample.pdf` اجازه می‌دهد. اگر استخراج زودتر تمام شد، برنامه درخواست زمان‌بندی‌شده را لغو می‌کند.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **متوقف کردن پیش از پردازش اسلاید بعدی**

از همان [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) برای ارائه و حلقه‌ای که اسلایدهای آن را استخراج می‌کند، استفاده کنید. قبل از هر استخراج، [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) را بررسی کنید. اگر فراخوانی بتواند از نتیجهٔ جزئی استفاده کند، شماره‌های اسلایدهای استخراج‌شدهٔ موفق را بازگردانید.

از ارائه‌ای به نام `sample.pptx` با حداقل دو اسلاید استفاده کنید. overload متد [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) که آرایه‌ای از شماره‌های اسلاید دریافت می‌کند، شماره‌گذاری را از ۱ آغاز می‌کند. مثال هر اسلاید را در یک PDF جداگانه ذخیره می‌کند و بلافاصله پس از ثبت اولین استخراج موفق، درخواست لغو می‌دهد.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

مثال `slide-1.pdf` را می‌نویسد و `Starting slide 1` را چاپ می‌کند و سپس `Completed: [1]`. حلقه قبل از شروع اسلاید ۲ درخواست را مشاهده می‌کند. اگر لغو هنگام ذخیره رخ دهد، حلقه قبل از ثبت تکمیل آن اسلاید خارج می‌شود.

اگر فراخوانی نیاز به مدیریت لغو داشته باشد، بررسی و `break` آن در بالای حلقه را با `token.throwIfInterruptionRequested()` جایگزین کنید. `try`/`catch` اطراف ذخیره‌سازی را حذف کنید تا لغو در حین استخراج نیز به فراخوانی برسد. با همان ورودی، مثال فقط `Starting slide 1` را چاپ می‌کند و `slide-1.pdf` را می‌نویسد. در ابتدای تکرار دوم، [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) قبل از شروع استخراج بعدی `com.aspose.slides.exceptions.OperationCanceledException` را پرتاب می‌کند. این متد هیچ فهرستی بر نمی‌گرداند.

## **سوالات متداول**

**کی باید درخواست لغو بدهم؟**

در زمانی که یک عملیات بیش از محدودیت زمانی شما باشد یا زمانی که برنامه شما دیگر به نتیجه نیاز نداشته باشد، درخواست لغو کنید.

**تفاوت بین [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) چیست؟**

منبع به برنامه شما امکان درخواست لغو را می‌دهد. توکن به Aspose.Slides و برنامه شما امکان بررسی آن درخواست را می‌دهد.

**آیا می‌توانم یک عملیات را از یک تایمر جاوا لغو کنم؟**

بله. یک فراخوانی به متد [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) را روی منبع مرتبط با ارائه زمان‌بندی کنید.

**کدام عملیات‌ها را می‌توانم قطع کنم؟**

می‌توانید بارگیری، ذخیره‌سازی و رندرینگ را قطع کنید. توکن را از طریق [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) به [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) پاس بدهید. سپس ارائه می‌تواند در عملیات‌های بعدی مانند ذخیره‌سازی به PDF، لغو را مشاهده کند.

**آیا یک عملیات فوراً متوقف می‌شود؟**

لغو به صورت تعاونی است. یک عملیات به‌صورت دوره‌ای توکن را بررسی می‌کند و زمانی که درخواست را مشاهده کند، متوقف می‌شود.

**اگر پس از اتمام یک عملیات، [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) را فراخوانی کنم چه می‌شود؟**

عملیات تکمیل‌شده نتیجهٔ خود را حفظ می‌کند.

**آیا چند عملیات می‌توانند یک [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) را به اشتراک بگذارند؟**

بله. فراخوانی [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) لغو را برای هر عملیاتی که از توکن آن منبع استفاده می‌کند، درخواست می‌کند. برای هر عملیاتی که می‌خواهید به‌صورت مستقل لغو کنید، از منبع جداگانه‌ای استفاده کنید.