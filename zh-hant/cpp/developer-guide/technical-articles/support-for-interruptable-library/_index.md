---
title: 在 C++ 中中斷長時間執行的簡報操作
linktitle: 中斷簡報操作
type: docs
weight: 150
url: /zh-hant/cpp/support-for-interruptable-library/
keywords:
- 可中斷的操作
- 中斷 Token
- 取消 Token
- 長時間執行的工作
- 中斷工作
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中取消長時間執行的簡報操作，並在迴圈匯出投影片時返回部分結果。"
---
## **概述**

Aspose.Slides for C++ 可以中斷長時間執行的操作，例如載入、儲存和算繪簡報。您的應用程式可以使用相同的 interruption token 在開始處理下一張投影片之前停止迴圈。

## **中斷簡報操作**

建立一個 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)，使用 [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/) 取得其 token，將 token 傳遞給 [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/)，並將載入選項傳遞給 [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/)。若要請求取消，對來源呼叫 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)。可中斷的操作會在觀察到請求時停止。

此範例在背景工作中開始將 `sample.pptx` 轉換為 `sample.ppt`，並在任務在 10 秒後仍在執行時請求取消。如果轉換較早完成，輸出已經完整。

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

## **將應用程式取消連結至 Aspose.Slides**

如果您的應用程式使用 [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/)，請使用 [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) 將取消請求轉發至 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)。此範例在背景工作中將 `sample.pptx` 匯出為 `sample.pdf`。如果匯出在 20 秒後仍在執行，應用程式會呼叫 [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/)，進而觸發已註冊的回呼。

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

## **在處理下一張投影片前停止**

對簡報本身以及匯出投影片的迴圈使用相同的 [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/)。在開始每次匯出前檢查 [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/)。如果呼叫端可以接受部分結果，則回傳已成功完成匯出的投影片編號。

使用名稱為 `sample.pptx` 且至少包含兩張投影片的簡報。此範例在記錄第一次成功匯出後立即請求取消。

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

此範例寫入 `slide-1.pdf` 並輸出 `Starting slide 1`，接著 `Completed: [1]`。迴圈在開始第 2 張投影片前即看到取消請求。如果取消改為在匯出期間中斷 [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)，`catch` 區塊會在記錄目前投影片完成之前退出迴圈。

如果呼叫端需要處理取消，請將迴圈頂部的 `if` 檢查及其 `break` 替換為在 token 上呼叫 [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/)。移除匯出周圍的 `try`/`catch`，使在儲存期間的取消也能傳遞給呼叫端。使用相同的輸入，範例僅輸出 `Starting slide 1` 並寫入 `slide-1.pdf`。在第二次迭代開始時，呼叫端會在匯出開始前收到 [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/)。呼叫端不會收到已完成投影片的清單。

## **常見問題**

**何時應該請求取消？**  
當操作超過您的時間限制或您的應用程式不再需要結果時，請求取消。

**[InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) 有何差異？**  
來源允許您的應用程式發出取消請求。Token 讓 Aspose.Slides 與您的應用程式檢查該請求。

**我可以將 [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) 與 Aspose.Slides 一起使用嗎？**  
可以。當您的應用程式 token 發出取消訊號時，對與簡報相關的來源呼叫 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)。

**哪些操作可以被中斷？**  
您可以中斷載入、儲存與算繪。透過 [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) 將 token 傳遞給 [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/)。之後簡報在執行如 [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 等後續操作時即可觀察到取消。

**操作會立即停止嗎？**  
取消是協作性的。操作會定期檢查 token，並在觀察到請求時停止。

**如果在操作完成後呼叫 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) 會發生什麼？**  
已完成的操作會保留其結果。

**多個操作可以共用同一個 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)？**  
可以。呼叫 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) 會對所有使用該來源 token 的操作發出取消請求。若希望各操作獨立取消，請為每個操作使用不同的來源。