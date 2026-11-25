---
title: 中断 C++ 中的长时间运行的演示文稿操作
linktitle: 中断演示文稿操作
type: docs
weight: 150
url: /zh/cpp/support-for-interruptable-library/
keywords:
- 可中断的操作
- 中断令牌
- 取消令牌
- 长时间任务
- 中断任务
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中取消长时间运行的演示文稿操作，并在循环导出幻灯片时返回部分结果。"
---
## **概述**

Aspose.Slides for C++ 可以中断长时间运行的操作，例如加载、保存和呈现演示文稿。您的应用程序可以使用相同的 interruption token 在循环开始处理下一张幻灯片之前停止它。

## **中断演示文稿操作**

创建一个[InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)，使用[get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/) 获取其 token，将 token 传递给[LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/)，并将加载选项传递给[Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/)。要请求取消，请在源上调用[InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)。可中断的操作会在检测到请求后停止。

示例在后台任务中开始将 `sample.pptx` 转换为 `sample.ppt`，并在任务运行超过 10 秒后请求取消。如果转换更早完成，输出已经完成。

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **将应用程序取消连接到 Aspose.Slides**

如果您的应用程序使用[System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/)，请使用[Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) 将取消请求转发给[InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)。示例在后台任务中将 `sample.pptx` 导出为 `sample.pdf`。如果导出在 20 秒后仍在运行，应用程序调用[CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/)，从而触发已注册的回调。

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **在处理下一张幻灯片前停止**

在演示文稿和导出幻灯片的循环中使用相同的[IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/)。在开始每个导出之前检查[get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/)。如果调用方可以使用部分结果，则返回已成功完成导出的幻灯片编号。

使用名为 `sample.pptx` 且至少包含两张幻灯片的演示文稿。示例在记录第一次成功导出后立即请求取消。

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

示例写入 `slide-1.pdf` 并打印 `Starting slide 1`，随后是 `Completed: [1]`。循环在开始第 2 张幻灯片之前看到取消请求。如果取消在导出期间中断[Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)，`catch` 块将在代码将当前幻灯片记录为完成之前退出循环。

如果调用方需要处理取消，请将循环顶部的 `if` 检查及其 `break` 替换为对 token 调用[ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/)。移除导出周围的 `try`/`catch`，使在保存期间的取消也能传递给调用方。使用相同的输入，示例仅打印 `Starting slide 1` 并写入 `slide-1.pdf`。在第二次迭代开始时，调用方在导出开始前收到一个[System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/)。调用方不会收到已完成幻灯片的列表。

## **常见问题**

**何时应请求取消？**

当操作超过您的时间限制或当您的应用程序不再需要结果时，请求取消。

**[InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) 与 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) 有什么区别？**

源允许您的应用程序请求取消。token 允许 Aspose.Slides 和您的应用程序检查该请求。

**可以在 Aspose.Slides 中使用 [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) 吗？**

可以。当您的应用程序 token 发出取消信号时，调用与演示文稿关联的源的[InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)。

**我可以中断哪些操作？**

您可以中断加载、保存和渲染。通过[LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/)将 token 传递给[Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/)。随后，演示文稿在后续操作（例如[Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)）期间即可观察到取消请求。

**操作会立即停止吗？**

取消是合作式的。操作会定期检查 token，并在检测到请求时停止。

**如果在操作完成后调用 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) 会怎样？**

已完成的操作会保留其结果。

**多个操作可以共享一个 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) 吗？**

可以。调用[InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)会请求取消所有使用该源 token 的操作。对于希望独立取消的每个操作，请使用单独的源。