---
title: دعم المكتبة القابلة للإيقاف
type: docs
weight: 150
url: /cpp/support-for-interruptable-library/
---

## **المكتبة القابلة للإيقاف**
تمت إضافة صنف [InterruptionToken](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token) وصنف [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) إلى Aspose.Slides لـ C++. تدعم هذه الأنواع إيقاف المهام طويلة الأمد، مثل إلغاء تسلسل البيانات، التسلسل أو العرض. يمثل [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) مصدر الرمز أو رموز متعددة تمرر إلى طريقة [LoadOptions.set_InterruptionToken()](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options#a9caea79d46cd939505687fdf634530a5). عندما يتم تعيين رمز الإيقاف ويتم تمرير مثيل [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) إلى منشئ [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)، سيتم إيقاف أي مهمة طويلة الأمد تتعلق بهذه العرض عندما يتم استدعاء طريقة [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source#a98ba5fd8badce28a63b5d30a2cfa1e83).

يظهر مقطع الشيفرة أدناه كيفية إيقاف مهمة قيد التشغيل.

``` cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto thread_function = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(thread_function);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"pres.pptx", options);
        presentation->Save(dataDir + u"pres.ppt", Export::SaveFormat::Ppt);
    });
    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);

    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    // تشغيل الإجراء في خيط منفصل
    Run(action, tokenSource->get_Token());
    // مهلة
    Threading::Thread::Sleep(5000);
    // إيقاف التحويل
    tokenSource->Interrupt();
}
```