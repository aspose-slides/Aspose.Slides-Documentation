---
title: إيقاف عمليات العرض التقديمي ذات التشغيل الطويل على Android
linktitle: إيقاف عمليات العرض التقديمي
type: docs
weight: 120
url: /ar/androidjava/support-for-interruptable-library/
keywords:
- عمليات قابلة للمقاطعة
- رمز الانقطاع
- رمز الإلغاء
- مهمة طويلة التشغيل
- مقاطعة المهمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعرّف على كيفية إلغاء عمليات العرض التقديمي الطويلة في Aspose.Slides for Android عبر Java وإرجاع نتيجة جزئية عند تصدير الشرائح في حلقة."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Android عبر Java قطع العمليات الطويلة مثل التحميل والحفظ وتصيير العروض التقديمية. يمكن لتطبيقك استخدام نفس رمز الانقطاع لإيقاف حلقة قبل أن تبدأ بمعالجة الشريحة التالية.

## **إيقاف عملية عرض تقديمي**

قم بإنشاء [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)، احصل على رمزه باستخدام [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--)، ومرّر الرمز إلى [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). مرّر خيارات التحميل إلى [منشئ Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). لطلب الإلغاء، استدعِ [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) على المصدر. تتوقف العملية القابلة للانقطاع عندما تلاحظ الطلب.

المثال يحول `sample.pptx` إلى `sample.ppt` في خيط خلفي. ينتظر الخيط المستدعي حتى 10 ثوانٍ لانتهاء التحويل. إذا استمر التحويل في العمل، يطلب الإلغاء وينتظر انتهاء العامل.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // استدعِ من خيط خلفي ومرّر context.getFilesDir()، الذي يحتوي على sample.pptx.
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

## **ربط مهلة Java بـ Aspose.Slides**

لتحديد حد زمني لعملية عرض تقديمي، استخدم [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) لاستدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) عندما تنتهي المهلة. يسمح المثال بـ 20 ثانية لتحميل `sample.pptx` وتصديره إلى `sample.pdf`. إذا انتهى التصدير مبكرًا، يلغي التطبيق الطلب المجدول.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // استدعِ من خيط خلفي ومرّر context.getFilesDir()، الذي يحتوي على sample.pptx.
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

## **الإيقاف قبل معالجة الشريحة التالية**

استخدم نفس [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) للعرض التقديمي والحلقة التي تصدر شرائحه. تحقّق من [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) قبل كل تصدير. إذا كان المستدعي يمكنه استخدام نتيجة جزئية، أرجع أرقام الشرائح التي تم تصديرها بنجاح.

استخدم عرضًا تقديميًا باسم `sample.pptx` يحتوي على شريحتين على الأقل. التحميل الزائد لـ [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) الذي يأخذ مصفوفة من أرقام الشرائح يبدأ من 1. المثال يحفظ كل شريحة في ملف PDF منفصل ويطلب الإلغاء فور تسجيل أول تصدير ناجح.

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

    // استدعِ من خيط خلفي ومرّر context.getFilesDir()، الذي يحتوي على sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

المثال يكتب `slide-1.pdf` ويطبع `Starting slide 1` متبوعًا بـ `Completed: [1]`. الحلقة تلاحظ الطلب قبل بدء الشريحة 2. إذا وصل الإلغاء أثناء الحفظ، تخرج الحلقة قبل أن تسجل الشريحة كمنجزة.

إذا كان المستدعي بحاجة للتعامل مع الإلغاء، استبدل الفحص و`break` في أعلى الحلقة بـ `token.throwIfInterruptionRequested()`. احذف الـ `try`/`catch` حول الحفظ بحيث يصل الإلغاء أثناء التصدير إلى المستدعي. باستخدام نفس المدخلات، يطبع المثال فقط `Starting slide 1` ويكتب `slide-1.pdf`. عند بداية التكرار الثاني، [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) يرمي `com.aspose.slides.exceptions.OperationCanceledException` قبل بدء التصدير التالي. لا تُرجع الطريقة أي قائمة.

## **الأسئلة الشائعة**

**متى يجب أن أطلب الإلغاء؟**

اطلب الإلغاء عندما تتجاوز العملية الحد الزمني المحدد لك أو عندما لا يحتاج تطبيقك إلى النتيجة بعد الآن.

**ما الفرق بين [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

المصدر يتيح لتطبيقك طلب الإلغاء. الرمز يتيح لـ Aspose.Slides وتطبيقك التحقق من ذلك الطلب.

**هل يمكنني إلغاء عملية باستخدام مؤقت Java؟**

نعم. جدول استدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) على المصدر المرتبط بالعرض التقديمي.

**ما العمليات التي يمكنني قطعها؟**

يمكنك قطع التحميل والحفظ والتصيير. مرّر الرمز إلى [منشئ Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) عبر [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). ثم يمكن للعرض التقديمي ملاحظة الإلغاء خلال العمليات اللاحقة مثل الحفظ إلى PDF.

**هل تتوقف العملية فورًا؟**

الإلغاء تعاوني. العملية تتحقق من الرمز بشكل دوري وتتوقف عندما تلاحظ الطلب.

**ماذا يحدث إذا استدعيت [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) بعد انتهاء العملية؟**

تحتفظ العملية المكتملة بنتيجتها.

**هل يمكن لعمليات متعددة مشاركة [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

نعم. استدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) يطلب الإلغاء لكل عملية تستخدم رمزًا من ذلك المصدر. استخدم مصدرًا منفصلًا لكل عملية تريد إلغاؤها بشكل مستقل.