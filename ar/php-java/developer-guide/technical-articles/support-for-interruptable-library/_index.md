---
title: إيقاف عمليات العرض التقديمي طويلة المدة في PHP
linktitle: إيقاف عمليات العرض التقديمي
type: docs
weight: 120
url: /ar/php-java/support-for-interruptable-library/
keywords:
- رمز الانقطاع
- إلغاء
- مهلة التحويل
- تصدير الشرائح
- PowerPoint
- PHP
- Aspose.Slides
description: "تعلم كيفية إلغاء تحويل عرض تقديمي باستخدام مؤقت وإرجاع الشرائح التي تم تصديرها قبل الإلغاء باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides للـ PHP عبر Java إيقاف العمليات طويلة التنفيذ مثل تحميل العروض، حفظها، وعرضها. في الحلقة التي تصدر شريحة واحدة في كل مرة، يسمح الرمز المميز نفسه لتطبيقك بالتوقف قبل الشريحة التالية وإرجاع قائمة بالصادرات المكتملة.

كل من أمثلة PHP تفترض أن استدعاء التمهيد الخاص بك ينفذ `define("JAVA_PREFER_VALUES", 1);` قبل تحميل جسر الـ `Java.inc`، ثم يحمل `aspose.slides.php`. هذا الإعداد يسمح لـ PHP بالتقاط استثناءات Java أثناء الاستدعاء. تقوم الأمثلة بفحص سبب الاستثناء المغلف بحيث تصل أخطاء التحويل الأخرى إلى المتصل.

## **إيقاف عملية عرض تقديمي**

أنشئ [مصدر رمز الانقطاع](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/)، واحصل على الرمز المميز الخاص به باستخدام [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken)، ومرره إلى [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). قدّم هذه الخيارات عند إنشاء الـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). استدعاء [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) يطلب الإلغاء. تتوقف العملية الجارية عندما تلاحظ الطلب.

### **تعيين مهلة تحويل**

أثناء انتظار PHP لتحميل أو حفظ متزامن عبر جسر PHP/Java، يمكن لمؤقت Java طلب الإلغاء في خيط منفصل. احفظ المساعد التالي باسم `ConversionTimeout.java`، ثم قم بترجمته مع ملف JAR الخاص بـ Aspose.Slides على مسار الـ classpath، واجعل الفئة المترجمة متاحة للجسر تحت اسم الحزمة `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

مع تحميل الجسر وملف تغليف Aspose.Slides PHP، نفّذ المثال التالي مع وجود `sample.pptx` في دليل العمل لعملية Java، أو استخدم مسارات مطلقة يمكن الوصول إليها من تلك العملية. الحد الزمني البالغ 20 ثانية يغطي كلًا من التحميل وتصدير PDF. إذا انتهى التحويل مبكرًا، يقوم PHP بإلغاء المؤقت. لتحويل إلى صيغة PowerPoint الأقدم بحد زمني قدره 10 ثوانٍ، استخدم `sample.ppt`، `SaveFormat::Ppt`، و`10000` مللي ثانية.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **التوقف قبل معالجة الشريحة التالية**

تحقق من [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) قبل كل عملية تصدير. التحميل الفائض لـ [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) للشرائح المختارة يأخذ أرقام الشرائح بدءًا من 1. مرّر مصفوفة ذات عنصر واحد لكتابة ملف PDF منفصل لكل شريحة.

استخدم `sample.pptx` يحتوي على شريحتين على الأقل. لتوضيح الإلغاء بين الصادرات، يطلب المثال الإلغاء فورًا بعد تسجيل الشريحة الأولى.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

يكتب المثال `slide-1.pdf` ويطبع `Completed: [1]`. ترى الدورة الثانية الطلب قبل بدء تصدير آخر. إذا حدث الإلغاء أثناء حفظ، تحتوي القائمة فقط على الصادرات التي تم تأكيدها مسبقًا. قد يترك حفظ مقطوع ملفًا غير مكتمل على القرص.

لتمرير الإلغاء إلى المتصل، استبدل الفحص في بداية الحلقة بـ `$token->throwIfInterruptionRequested();` واحذف كتلة `try`/`catch` الداخلية، مع الحفاظ على عملية الحفظ والفحص التالي لها. مع نفس المدخلات، يرفع [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) استثناءً قبل الشريحة الثانية ولا يتلقى المتصل أي قائمة.

## **الأسئلة الشائعة**

**متى يجب طلب الإلغاء؟**

اطلب الإلغاء عندما ينتهي الموعد النهائي أو عندما لا يحتاج المتصل إلى النتيجة بعد الآن. الطلب المقدم بعد انتهاء العملية يترك نتيجتها كما هي.

**كيف يختلف المصدر عن الرمز المميز؟**

المصدر يتيح للتطبيق طلب الإلغاء. الرمز المميز يتيح لـ Aspose.Slides ولرمز التطبيق ملاحظة ذلك الطلب.

**هل يمكن لعمليات متعددة مشاركة مصدر واحد؟**

نعم. ينطبق الطلب على جميع العمليات التي تستخدم رموزًا مميزة من ذلك المصدر. أنشئ مصادر منفصلة للعمليات التي تحتاج إلى إلغاء مستقل.