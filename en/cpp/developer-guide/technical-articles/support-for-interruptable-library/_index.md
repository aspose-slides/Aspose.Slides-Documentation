---
title: Support For Interruptable Library
type: docs
weight: 150
url: /cpp/support-for-interruptable-library/
---

## **Interruptable Library**
The [InterruptionToken](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token) and [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) classes have been added to Aspose.Slides for C++. These types support interruption of long-running tasks, such as deserialization, serialization or rendering. The [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) represents the source of the token or multiple tokens passed to the [LoadOptions.set_InterruptionToken()](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options#a9caea79d46cd939505687fdf634530a5) method. When the interruption token is set and the [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) instance passed to the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) constructor, any long-running task related to this presentation will be interrupted when the [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source#a98ba5fd8badce28a63b5d30a2cfa1e83) method will be invoked.

The code snippet below demonstrates interrupting a running task.

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
    // run action in a separate thread
    Run(action, tokenSource->get_Token());
    // timeout
    Threading::Thread::Sleep(5000);
    // stop conversion
    tokenSource->Interrupt();
}
```
