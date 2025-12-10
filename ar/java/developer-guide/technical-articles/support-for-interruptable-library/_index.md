---
title: الدعم لمكتبة القابلة للمقاطعة
type: docs
weight: 120
url: /ar/java/support-for-interruptable-library/
keywords:
- مكتبة القابلة للمقاطعة
- رمز المقاطعة
- رمز الإلغاء
- مهمة طويلة التنفيذ
- مقاطعة المهمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "اجعل المهام طويلة التنفيذ قابلة للإلغاء باستخدام Aspose.Slides for Java. مقاطعة عمليات العرض والتحويل لبرنامج PowerPoint وOpenDocument بأمان، مع أمثلة."
---

## **مكتبة القابلة للمقاطعة**

في [Aspose.Slides 18.4](https://releases.aspose.com/slides/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/)، قدمنا الفئات [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) و[InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/). تمكنك من مقاطعة المهام طويلة التنفيذ مثل فك التسلسل، التسلسل، والعرض.

- [InterruptionTokenSource] هو مصدر الرمز (الرموز) الذي يُمرَّر إلى [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- عندما يتم تعيين [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) وتم تمرير نسخة [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) إلى مُنشئ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، فإن استدعاء [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) يقطع أي مهمة طويلة التنفيذ مرتبطة بذلك [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).

المقتطف التالي من الشيفرة يوضح مقاطعة مهمة قيد التشغيل:
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
thread.start();          // تشغيل الإجراء في خيط منفصل
Thread.sleep(10000);     // مهلة
tokenSource.interrupt(); // إيقاف التحويل
```


## **الأسئلة الشائعة**

**ما الغرض من مكتبة المقاطعة في Aspose.Slides؟**

توفر آلية لمقاطعة العمليات طويلة التنفيذ—مثل تحميل، حفظ، أو عرض العروض—قبل إكمالها. هذا مفيد عندما يجب تحديد وقت المعالجة أو لم تعد المهمة ضرورية.

**ما الفرق بين [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) و[InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` يُمرَّر إلى واجهة برمجة تطبيقات Aspose.Slides ويتم التحقق منه أثناء العمليات طويلة التنفيذ.
- `InterruptionTokenSource` يُستخدم في شفرتك لإنشاء الرموز وتفعيل المقاطعات عبر استدعاء `Interrupt()`.

**ما هي المهام التي يمكن مقاطعتها؟**

أي مهمة في Aspose.Slides تقبل [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/)—مثل تحميل عرض تقديمي باستخدام `Presentation(path, loadOptions)` أو حفظه عبر `Presentation.save(...)`—يمكن مقاطعتها.

**هل تحدث المقاطعة فوراً؟**

لا. المقاطعة تعاونية: العملية تتحقق دوريًا من الرمز وتتوقف بمجرد اكتشاف أنها تم استدعاء [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) .

**ماذا يحدث إذا استدعيت [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) بعد انتهاء المهمة بالفعل؟**

لا شيء—الاستدعاء ليس له تأثير إذا كانت المهمة المقابلة قد اكتملت بالفعل.

**هل يمكنني إعادة استخدام نفس [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) لعدة مهام؟**

نعم—لكن بعد استدعاء [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) على ذلك المصدر، ستُقَطَع جميع المهام التي تستخدم رموزه. استخدم مصادر رموز منفصلة لإدارة المهام بشكل مستقل.