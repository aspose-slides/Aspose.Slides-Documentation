---
title: دعم مكتبة القابلة للمقاطعة
type: docs
weight: 150
url: /ar/cpp/support-for-interruptable-library/
keywords:
- مكتبة القابلة للمقاطعة
- رمز المقاطعة
- رمز الإلغاء
- مهمة طويلة الأمد
- مقاطعة المهمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "اجعل المهام الطويلة قابلة للإلغاء باستخدام Aspose.Slides للغة C++. قم بمقاطعة عملية العرض والتحويلات لPowerPoint وOpenDocument بأمان، مع أمثلة."
---

## **مكتبة القابلة للمقاطعة**

في [Aspose.Slides 18.4](https://releases.aspose.com/slides/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/)، قدمنا الفئات [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) و[InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/). تسمح لك بمقاطعة المهام الطويلة مثل فك التسلسل، التسلسل، والعرض.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) هو مصدر الرموز (Token) الممررة إلى [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- عندما يتم تعيين [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) ويتم تمرير كائن [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) إلى مُنشئ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)، فإن استدعاء [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) يقطع أي مهمة طويلة مرتبطة بذلك [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).

المقتطف البرمجي التالي يوضح مقاطعة مهمة قيد التنفيذ:
```cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto threadFunction = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(threadFunction);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        auto options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        auto presentation = System::MakeObject<Presentation>(dataDir + u"sample.pptx", options);
        presentation->Save(dataDir + u"sample.ppt", Export::SaveFormat::Ppt);
    });

    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);
    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    
    Run(action, tokenSource->get_Token()); // تشغيل الإجراء في خيط منفصل
    Threading::Thread::Sleep(10000);       // مهلة
    tokenSource->Interrupt();              // إيقاف التحويل
}
```


## **الأسئلة المتداولة**

**ما هو هدف مكتبة المقاطعة في Aspose.Slides؟**

توفر آلية لمقاطعة العمليات الطويلة — مثل تحميل العروض، حفظها، أو عرضها — قبل إكمالها. هذا مفيد عندما يجب حصر زمن المعالجة أو عندما لم تعد المهمة ضرورية.

**ما الفرق بين [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) و[InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` يُمرّر إلى واجهة برمجة تطبيقات Aspose.Slides ويتم فحصه أثناء العمليات الطويلة.
- `InterruptionTokenSource` يُستخدم في الكود الخاص بك لإنشاء رموز وإحداث مقاطعات عن طريق استدعاء `Interrupt()`.

**ما هي المهام التي يمكن مقاطعتها؟**

أي مهمة في Aspose.Slides تقبل [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) — مثل تحميل عرض باستخدام `Presentation(path, loadOptions)` أو حفظه عبر `Presentation::Save(...)` — يمكن مقاطعتها.

**هل تحدث المقاطعة فورًا؟**

لا. المقاطعة تعاونية: العملية تتحقق دوريًا من الرمز وتتوقف بمجرد اكتشاف أنها تم استدعاء [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/).

**ماذا يحدث إذا ناديت [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) بعد اكتمال المهمة بالفعل؟**

لا شيء — الاستدعاء لا يؤثر إذا كانت المهمة المقابلة قد اكتملت بالفعل.

**هل يمكنني إعادة استخدام نفس [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) لمهام متعددة؟**

نعم — لكن بعد استدعاء [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) على ذلك المصدر، ستتم مقاطعة جميع المهام التي تستخدم رموزه. استخدم مصادر رموز منفصلة لإدارة المهام بشكل مستقل.