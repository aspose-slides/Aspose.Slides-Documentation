---
title: 可中断库支持
type: docs
weight: 150
url: /zh/cpp/support-for-interruptable-library/
keywords:
- 可中断库
- 中断令牌
- 取消令牌
- 长时间运行任务
- 中断任务
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 使长时间运行的任务可取消。安全地中断 PowerPoint 和 OpenDocument 的渲染和转换，并提供示例。"
---

## **可中断库**

在 [Aspose.Slides 18.4](https://releases.aspose.com/slides/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) 中，我们引入了 [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) 和 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) 类。它们允许您中断诸如反序列化、序列化和渲染等长时间运行的任务。

- [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) 是传递给 [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) 的令牌的来源。
- 当设置了 [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) 并将 [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) 实例传递给 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 构造函数时，调用 [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) 会中断与该 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 关联的任何长时间运行的任务。

以下代码片段演示了如何中断正在运行的任务：
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
    
    Run(action, tokenSource->get_Token()); // 在单独的线程中运行操作
    Threading::Thread::Sleep(10000);       // 超时
    tokenSource->Interrupt();              // 停止转换
}
```


## **常见问题**

**Aspose.Slides 中断库的目的是什么？**

它提供了一种机制，可在加载、保存或渲染演示文稿等长时间运行的操作完成之前中断它们。当处理时间必须受限或任务已不再需要时，这非常有用。

**[InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) 与 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) 有何区别？**

- `InterruptionToken` 被传递给 Aspose.Slides API 并在长时间运行的操作期间进行检查。
- `InterruptionTokenSource` 在您的代码中用于创建令牌，并通过调用 `Interrupt()` 来触发中断。

**哪些任务可以被中断？**

任何接受 [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) 的 Aspose.Slides 任务——例如使用 `Presentation(path, loadOptions)` 加载演示文稿或使用 `Presentation::Save(...)` 保存——都可以被中断。

**中断会立即发生吗？**

不会。中断是协作式的：操作会定期检查令牌，并在检测到已调用 [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) 时立即停止。

**如果在任务已经完成后调用 [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)，会发生什么？**

没有任何影响——如果相应的任务已经完成，调用将不起作用。

**我可以在多个任务中复用同一个 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) 吗？**

可以——但在对该源调用 [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) 后，使用其令牌的所有任务都会被中断。请使用不同的令牌源来独立管理任务。