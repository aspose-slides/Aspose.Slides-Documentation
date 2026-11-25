---
title: متوقف کردن عملیات‌های طولانی‌مدت ارائه در اندروید
linktitle: متوقف کردن عملیات ارائه
type: docs
weight: 120
url: /fa/androidjava/support-for-interruptable-library/
keywords:
- عملیات‌های قابل قطع
- توکن انقطاع
- توکن لغو
- وظیفه طولانی‌مدت
- متوقف کردن وظیفه
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه عملیات‌های طولانی‌مدت ارائه را در Aspose.Slides برای اندروید از طریق جاوا لغو کنید و هنگام استخراج اسلایدها در یک حلقه، نتیجهٔ جزئی برگردانید."
---
## **نمای کلی**

Aspose.Slides for Android via Java می‌تواند عملیات طولانی‌مدت مانند بارگذاری، ذخیره‌سازی و رندر ارائه‌ها را متوقف کند. برنامه شما می‌تواند از همان توکن انقطاع برای متوقف کردن یک حلقه قبل از اینکه اسلاید بعدی را پردازش کند، استفاده کند.

## **متوقف کردن عملیات ارائه**

یک [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) ایجاد کنید، توکن آن را با [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--) دریافت کنید و توکن را به [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) بدهید. گزینه‌های بارگذاری را به سازندهٔ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) پاس کنید. برای درخواست لغو، روی منبع متد [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) را فراخوانی کنید. یک عملیات قابل قطع زمانی که درخواست را مشاهده کند، متوقف می‌شود.

مثال فایل `sample.pptx` را به `sample.ppt` در یک نخ پس‌زمینه تبدیل می‌کند. نخ فراخوانی تا ۱۰ ثانیه صبر می‌کند تا تبدیل تکمیل شود. اگر تبدیل هنوز ادامه داشته باشد، درخواست لغو را می‌دهد و منتظر خروج کارگر می‌ماند.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // از یک نخ پس‌زمینه صدا بگیرید و context.getFilesDir() را پاس کنید، که شامل sample.pptx است.
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
    }
}
```

## **اتصال زمان‌سیم Java به Aspose.Slides**

برای تعیین محدودیت زمانی روی یک عملیات ارائه، از یک [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) استفاده کنید تا هنگام پایان زمان‌سیم، متد [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) را فراخوانی کند. مثال اجازه می‌دهد ۲۰ ثانیه برای بارگذاری `sample.pptx` و استخراج آن به `sample.pdf` صرف شود. اگر استخراج زودتر تمام شد، برنامه درخواست زمان‌بندی شده را لغو می‌کند.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // از یک نخ پس‌زمینه صدا بگیرید و context.getFilesDir() را پاس کنید، که شامل sample.pptx است.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **متوقف کردن قبل از پردازش اسلاید بعدی**

از همان [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) برای ارائه و حلقه‌ای که اسلایدهای آن را استخراج می‌کند استفاده کنید. قبل از هر استخراج، [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) را بررسی کنید. اگر فراخوانی می‌تواند از نتیجهٔ جزئی استفاده کند، شماره اسلایدهای استخراج‑های موفق را بازگردانید.

یک ارائه به نام `sample.pptx` با حداقل دو اسلاید استفاده کنید. بارگذاری‌گردان [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) که آرایه‌ای از شماره اسلایدها می‌گیرد، شماره‌ها از ۱ شروع می‌شوند. مثال هر اسلاید را به یک PDF جداگانه ذخیره می‌کند و بلافاصله پس از ثبت اولین استخراج موفق درخواست لغو می‌دهد.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // از یک نخ پس‌زمینه صدا بگیرید و context.getFilesDir() را پاس کنید، که شامل sample.pptx است.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

مثال `slide-1.pdf` می‌نویسد و `Starting slide 1` را چاپ می‌کند و سپس `Completed: [1]`. حلقه درخواست را قبل از شروع اسلاید ۲ مشاهده می‌کند. اگر لغو در حین ذخیره رخ دهد، حلقه قبل از ثبت کامل شدن آن اسلاید خارج می‌شود.

اگر فراخوانی نیاز به پردازش لغو داشته باشد، بررسی و `break` در بالای حلقه را با `token.throwIfInterruptionRequested()` جایگزین کنید. `try`/`catch` اطراف ذخیره را حذف کنید تا لغو در هنگام استخراج نیز به فراخوانی برسد. با همان ورودی، مثال فقط `Starting slide 1` را چاپ می‌کند و `slide-1.pdf` می‌نویسد. در شروع تکرار دوم، [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) قبل از شروع استخراج بعدی، `com.aspose.slides.exceptions.OperationCanceledException` را پرتاب می‌کند. متد هیچ لیستی بر نمی‌گرداند.

## **سؤالات متداول**

**چه زمانی باید درخواست لغو را بدهید؟**

وقتیکه یک عملیات از محدودیت زمانی شما فراتر رود یا برنامهٔ شما دیگر به نتیجهٔ آن نیازی نداشته باشد، درخواست لغو کنید.

**تفاوت بین [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) چیست؟**

منبع به برنامهٔ شما اجازه می‌دهد درخواست لغو را بدهد. توکن به Aspose.Slides و برنامهٔ شما امکان می‌دهد این درخواست را بررسی کنند.

**آیا می‌توانم یک عملیات را از یک تایمر Java لغو کنم؟**

بله. یک فراخوانی به [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) را برای منبع مرتبط با ارائه زمان‌بندی کنید.

**کدام عملیات‌ها را می‌توانم متوقف کنم؟**

می‌توانید بارگذاری، ذخیره‌سازی و رندر را متوقف کنید. توکن را از طریق [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) به سازندهٔ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) پاس دهید. سپس ارائه می‌تواند در عملیات‌های بعدی مانند ذخیره به PDF، لغو را مشاهده کند.

**آیا یک عملیات بلافاصله متوقف می‌شود؟**

لغو تعاونی است. یک عملیات به‌طور دوره‌ای توکن را چک می‌کند و وقتی درخواست را مشاهده کرد، متوقف می‌شود.

**اگر پس از اتمام یک عملیات متد [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) را صدا بزنم چه می‌شود؟**

عملیاتی که تکمیل شده‌اند نتیجهٔ خود را حفظ می‌کنند.

**آیا چند عملیات می‌توانند یک [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) مشترک داشته باشند؟**

بله. فراخوانی [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) برای هر عملیاتی که توکن آن منبع را استفاده می‌کند، درخواست لغو می‌دهد. برای هر عملیاتی که می‌خواهید به‌صورت مستقل لغو شود، یک منبع جداگانه استفاده کنید.