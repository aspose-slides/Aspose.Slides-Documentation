---
title: 支援可中斷函式庫
type: docs
weight: 150
url: /zh-hant/cpp/support-for-interruptable-library/
keywords:
- 可中斷函式庫
- 中斷標記
- 取消標記
- 長時間執行的任務
- 中斷任務
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 讓長時間執行的任務可取消。安全地中斷 PowerPoint 和 OpenDocument 的呈現與轉換，並提供範例。"
---
## **概述**

Aspose.Slides 提供一種可中斷的處理機制，用於長時間執行的簡報任務，例如反序列化、序列化和渲染。此機制基於 `InterruptionToken` 和 `InterruptionTokenSource` 類別。

`InterruptionToken` 可以指派給 `LoadOptions` 並傳遞給 `Presentation` 建構函式。當呼叫 `InterruptionTokenSource::Interrupt()` 時，相關的長時間任務會被中斷。

## **可中斷函式庫**

在 [Aspose.Slides 18.4](https://releases.aspose.com/slides/zh-hant/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) 中，我們引入了 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/interruptiontoken/) 和 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/interruptiontokensource/) 類別。它們允許您中斷長時間執行的任務，例如反序列化、序列化和渲染。

- [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/interruptiontokensource/) 是傳遞給 [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_interruptiontoken/) 的 token(s) 來源。
- 當設定 [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_interruptiontoken/) 並將 [LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/) 實例傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 建構函式時，呼叫 [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/interruptiontokensource/interrupt/) 會中斷與該 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 相關的任何長時間任務。

以下程式碼片段示範如何中斷執行中的任務：

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
    
    Run(action, tokenSource->get_Token()); // 在單獨執行緒中執行動作
    Threading::Thread::Sleep(10000);       // 逾時
    tokenSource->Interrupt();              // 停止轉換
}
```

## **常見問題**

**Aspose.Slides 中斷函式庫的目的為何？**

它提供一種機制，可在長時間操作（例如載入、儲存或渲染簡報）完成之前中斷這些操作。當需要限制處理時間或任務已不再需要時，此機制非常有用。

**[InterruptionToken] 與 [InterruptionTokenSource] 之間有何差異？**

- `InterruptionToken` 會傳遞給 Aspose.Slides API，並在長時間操作期間被檢查。
- `InterruptionTokenSource` 用於您的程式碼中建立 token，並透過呼叫 `Interrupt()` 觸發中斷。

**哪些任務可以被中斷？**

任何接受 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/interruptiontoken/) 的 Aspose.Slides 任務——例如使用 `Presentation(path, loadOptions)` 載入簡報或使用 `Presentation::Save(...)` 儲存——都可以被中斷。

**中斷會立即發生嗎？**

不會。中斷是合作式的：操作會定期檢查 token，並在偵測到已呼叫 [Interrupt()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/interruptiontokensource/interrupt/) 後盡快停止。

**如果在任務已完成後呼叫 [Interrupt()] 會發生什麼？**

什麼都不會發生——如果對應的任務已經結束，呼叫不會產生任何影響。

**我可以在多個任務中重複使用相同的 [InterruptionTokenSource] 嗎？**

可以——但在對該來源呼叫 [Interrupt()] 後，所有使用其 token 的任務都會被中斷。若需獨立管理任務，請使用不同的 token 來源。