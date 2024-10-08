---
title: 可中断库支持
type: docs
weight: 150
url: /cpp/support-for-interruptable-library/
---

## **可中断库**
[InterruptionToken](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token) 和 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) 类已添加到 Aspose.Slides for C++。这些类型支持中断长时间运行的任务，例如反序列化、序列化或渲染。[InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) 表示传递给 [LoadOptions.set_InterruptionToken()](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options#a9caea79d46cd939505687fdf634530a5) 方法的令牌或多个令牌的来源。当设置中断令牌并将 [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) 实例传递给 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 构造函数时，与此演示文稿相关的任何长时间运行的任务将在调用 [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source#a98ba5fd8badce28a63b5d30a2cfa1e83) 方法时被中断。

下面的代码片段演示了如何中断正在运行的任务。

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
    // 在单独的线程中运行操作
    Run(action, tokenSource->get_Token());
    // 超时
    Threading::Thread::Sleep(5000);
    // 停止转换
    tokenSource->Interrupt();
}
```