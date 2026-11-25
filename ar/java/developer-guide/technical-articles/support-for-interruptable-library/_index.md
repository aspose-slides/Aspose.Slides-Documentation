---
title: مقاطعة عمليات العرض التقديمي طويلة الأمد في Java
linktitle: مقاطعة عمليات العرض التقديمي
type: docs
weight: 120
url: /ar/java/support-for-interruptable-library/
keywords:
- عمليات قابلة للمقاطعة
- رمز المقاطعة
- رمز الإلغاء
- مهمة طويلة الأمد
- مقاطعة المهمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إلغاء عمليات العرض التقديمي طويلة الأمد في Aspose.Slides for Java وإرجاع نتيجة جزئية عند تصدير الشرائح في حلقة."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java مقاطعة عمليات طويلة الأمد مثل التحميل والحفظ وعرض العروض التقديمية. يمكن لتطبيقك استخدام نفس رمز المقاطعة لإيقاف حلقة قبل أن تبدأ بمعالجة الشريحة التالية.

## **مقاطعة عملية عرض تقديمي**

قم بإنشاء [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)، واحصل على رمزه باستخدام [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--)، ومرر الرمز إلى [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). مرر خيارات التحميل إلى [منشئ Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). لطلب الإلغاء، استدعِ [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) على المصدر. تتوقف العملية القابلة للمقاطعة عندما تلاحظ الطلب.

يقوم المثال بتحويل `sample.pptx` إلى `sample.ppt` في خيط خلفية. ينتظر الخيط المستدعي حتى 10 ثوانٍ لإكمال التحويل. إذا كان التحويل لا يزال جارياً، يطلب الإلغاء وينتظر انتهاء العامل.

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
## **ربط مهلة Java بـ Aspose.Slides**

لتحديد حد زمني لعملية عرض تقديمي، استخدم [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) لاستدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) عندما تنقضي المهلة. يتيح المثال 20 ثانية لتحميل `sample.pptx` وتصديره إلى `sample.pdf`. إذا انتهى التصدير مبكراً، يلغي التطبيق الطلب المجدول.

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
## **الإيقاف قبل معالجة الشريحة التالية**

استخدم نفس [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) للعرض التقديمي والحلقة التي تُصدِّر شرائحه. تحقق من [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) قبل كل تصدير. إذا كان المستدعي يستطيع استخدام نتيجة جزئية، أرجع أرقام الشرائح التي تم تصديرها بنجاح.

استخدم عرضًا تقديميًا باسم `sample.pptx` يحتوي على شريحتين على الأقل. التحميل الزائد [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) الذي يستقبل مصفوفة من أرقام الشرائح يبدأ العد من 1. يقوم المثال بحفظ كل شريحة في ملف PDF منفصل ويطلب الإلغاء مباشرةً بعد تسجيل أول تصدير ناجح.

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
يقوم المثال بكتابة `slide-1.pdf` ويطبع `Starting slide 1` متبوعًا بـ `Completed: [1]`. تلاحظ الحلقة الطلب قبل بدء الشريحة 2. إذا وصل الإلغاء أثناء عملية الحفظ، تخرج الحلقة قبل أن تسجل تلك الشريحة كمنجزة.

إذا كان المستدعي يحتاج إلى معالجة الإلغاء، استبدل الفحص وعبارة `break` في أعلى الحلقة بـ `token.throwIfInterruptionRequested()`. احذف الـ `try`/`catch` حول عملية الحفظ لكي يصل الإلغاء أثناء التصدير إلى المستدعي أيضًا. مع نفس الإدخال، يطبع المثال فقط `Starting slide 1` ويكتب `slide-1.pdf`. عند بداية التكرار الثاني، [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) يرمي استثناء `com.aspose.slides.exceptions.OperationCanceledException` قبل بدء التصدير التالي. لا تُعيد الطريقة أي قائمة.

## **الأسئلة الشائعة**

**متى ينبغي طلب الإلغاء؟**

اطلب الإلغاء عندما تتجاوز العملية حد الوقت المحدد لك أو عندما لا يحتاج تطبيقك إلى النتيجة بعد الآن.

**ما الفرق بين [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

المصدر يسمح لتطبيقك بطلب الإلغاء. الرمز يسمح لـ Aspose.Slides وتطبيقك بالتحقق من هذا الطلب.

**هل يمكنني إلغاء عملية من مؤقت Java؟**

نعم. جدولة استدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) على المصدر المرتبط بالعرض التقديمي.

**ما هي العمليات التي يمكنني مقاطعتها؟**

يمكنك مقاطعة التحميل والحفظ والعرض. مرر الرمز إلى [منشئ Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) عبر [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). يمكن للعرض التقديمي بعد ذلك ملاحظة الإلغاء خلال العمليات اللاحقة مثل الحفظ إلى PDF.

**هل تتوقف العملية فورًا؟**

الإلغاء تعاوني. تقوم العملية بالتحقق من الرمز دوريًا وتتوقف عندما تلاحظ الطلب.

**ماذا يحدث إذا استدعيت [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) بعد انتهاء العملية؟**

تحتفظ العملية المكتملة بنتيجتها.

**هل يمكن لعمليات متعددة مشاركة نفس [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

نعم. استدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) يطلب الإلغاء لكل عملية تستخدم رمزًا من ذلك المصدر. استخدم مصدرًا منفصلًا لكل عملية تريد إلغاؤها بشكل مستقل.