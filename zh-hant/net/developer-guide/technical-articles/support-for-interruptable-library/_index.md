---
title: 支援可中斷函式庫
type: docs
weight: 150
url: /zh-hant/net/support-for-interruptable-library/
keywords:
- 可中斷函式庫
- 中斷 Token
- 取消 Token
- 長時間執行任務
- 中斷任務
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 使長時間執行的任務可取消。安全地中斷 PowerPoint 和 OpenDocument 的渲染與轉換，並提供範例。"
---
## **概述**

Aspose.Slides for .NET 提供可中斷的處理機制，用於長時間執行的簡報任務，例如反序列化、序列化和渲染。此機制基於 `InterruptionToken` 與 `InterruptionTokenSource` 類別。

`InterruptionToken` 可指派給 `LoadOptions`，並傳遞給 `Presentation` 建構函式。當呼叫 `InterruptionTokenSource.Interrupt()` 時，相關的長時間執行任務會被中斷。本文亦示範如何結合標準 .NET `CancellationToken` 使用此機制，透過監控取消請求，並在需要取消時呼叫 `Interrupt()`。

## **可中斷函式庫**

在 [Aspose.Slides 18.4](https://releases.aspose.com/slides/zh-hant/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/) 中，我們推出了 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/interruptiontokensource/) 類別。它們讓您能夠中斷長時間執行的任務，例如反序列化、序列化與渲染。

- [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/interruptiontokensource/) 是傳遞給 [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iloadoptions/interruptiontoken/) 的 token（或多個 token）的來源。
- 當設定了 [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iloadoptions/interruptiontoken/) 且將 [LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/) 實例傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 建構函式時，呼叫 [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/interruptiontokensource/interrupt/) 會中斷與該 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 相關的任何長時間執行任務。

以下程式碼片段示範如何中斷執行中的任務：

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // 在單獨的執行緒中執行此動作
    Thread.Sleep(10000);            // 超時
    tokenSource.Interrupt();        // 停止轉換
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken 與可中斷函式庫**

當您需要在 Aspose.Slides 可中斷函式庫之外，同時使用 [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) 時，請將 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 的處理包裹起來，並在 [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) 為 `true` 時呼叫 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/interruptiontoken/) 的 `Interrupt()`。

此 C# 程式碼示範了此操作：

```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // 在單獨的執行緒中執行此動作

    while (!task.Wait(500)) // 等待並監控 cancellationToken.IsCancellationRequested 是否已設定
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was cancelled");
            tokenSource.Interrupt(); // 中斷簡報處理
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```

## **常見問題**

**Aspose.Slides 可中斷函式庫的目的為何？**

它提供一種機制，可在長時間執行的操作（例如載入、儲存或渲染簡報）完成之前中斷該操作。當處理時間需要受限或任務已不再需要時，這非常有用。

**[InterruptionToken](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iinterruptiontokensource/) 有何差異？**

- `InterruptionToken` 會傳遞給 Aspose.Slides API，在長時間執行的操作中被檢查。
- `InterruptionTokenSource` 則由您的程式碼使用，以建立 token 並透過呼叫 `Interrupt()` 觸發中斷。

**可以在 .NET 中同時使用 [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) 與可中斷函式庫嗎？**

可以。您可以在應用程式邏輯中監控 [CancellationToken]，當需要取消時呼叫 [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iinterruptiontokensource/interrupt/)，從而讓 Aspose.Slides 與標準 .NET 取消工作流程整合。

**哪些任務可以被中斷？**

任何接受 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/interruptiontoken/) 的 Aspose.Slides 任務——例如使用 `Presentation(path, loadOptions)` 載入簡報，或使用 `Presentation.Save(...)` 儲存——都可以被中斷。

**中斷會立即發生嗎？**

不會。中斷是合作式的：操作會定期檢查 token，並在偵測到已呼叫 [Interrupt()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iinterruptiontokensource/interrupt/) 後立即停止。

**如果在任務已完成後呼叫 [Interrupt()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iinterruptiontokensource/interrupt/)，會發生什麼？**

不會有任何影響——若相應任務已完成，呼叫將不產生作用。

**可以將相同的 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iinterruptiontokensource/) 重複使用於多個任務嗎？**

可以，但在對該來源呼叫 [Interrupt()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iinterruptiontokensource/interrupt/) 後，所有使用其 token 的任務皆會被中斷。若需獨立管理任務，請使用不同的 token 來源。