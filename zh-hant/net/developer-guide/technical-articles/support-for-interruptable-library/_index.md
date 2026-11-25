---
title: 在 .NET 中中斷長時間執行的簡報作業
linktitle: 中斷簡報作業
type: docs
weight: 150
url: /zh-hant/net/support-for-interruptable-library/
keywords:
- 可中斷的作業
- 中斷 token
- 取消 token
- 長時間執行的工作
- 中斷工作
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中取消長時間執行的簡報作業，以及在迴圈匯出投影片時返回部分結果。"
---
## **概述**

Aspose.Slides for .NET 可以中斷長時間執行的操作，例如載入、儲存和算繪簡報。您的應用程式可以使用相同的 interruption token 來在處理下一張投影片之前停止迴圈。

## **中斷簡報作業**

建立一個 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)，將其 [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) 指派給 [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/)，並將載入選項傳遞給 [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)。要請求取消，請對來源呼叫 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/)。當可中斷的作業偵測到請求時即會停止。

範例在背景工作中開始將 `sample.pptx` 轉換為 `sample.ppt`，並在 10 秒後請求取消。如果轉換較早完成，輸出已經完成。

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Run(action, tokenSource.Token); // 在獨立執行緒中執行動作
    Thread.Sleep(10000);            // 逾時
    tokenSource.Interrupt();        // 停止轉換
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **將 .NET 取消連接至 Aspose.Slides**

如果您的應用程式使用 .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)，請將其取消請求轉發給 Aspose.Slides。範例開始將 `sample.pptx` 匯出為 `sample.pdf`，並設定 20 秒的逾時時間。匯出執行期間，每 500 毫秒檢查一次 [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested)。當屬性變為 `true` 時，就呼叫 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/)。

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Task task = Run(action, tokenSource.Token); // 在單獨的執行緒中執行動作

    while (!task.Wait(500)) // 等待並監控 cancellationToken.IsCancellationRequested 是否已被設置
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
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

## **在處理下一張投影片前停止**

對簡報本身與匯出其投影片的迴圈皆使用相同的 [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/)。在開始每一次匯出前檢查 [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/)。如果呼叫端可以使用部分結果，則回傳成功完成匯出的投影片編號。

使用名稱為 `sample.pptx` 且至少包含兩張投影片的簡報。範例在記錄第一個成功的匯出後立即請求取消。

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

範例寫入 `slide-1.pdf`，並印出 `Starting slide 1`，接著是 `Completed: [1]`。迴圈在開始投影片 2 前已看到取消請求。如果取消改為在匯出期間中斷 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)，`catch` 區塊會在程式碼將目前投影片記錄為完成之前退出迴圈。

如果呼叫端需要處理取消，請將迴圈頂部的 `if` 判斷式及其 `break` 替換為對 token 呼叫 [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/)。移除匯出周圍的 `try`/`catch`，使在儲存期間的取消也能傳遞給呼叫端。使用相同的輸入，範例只會印出 `Starting slide 1` 並寫入 `slide-1.pdf`。在第二次迭代開始時，呼叫端會在匯出開始前收到 [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception)。此方法不會回傳任何清單。

## **常見問題**

**何時應該請求取消？**

當作業超過您的時間限制或您的應用程式不再需要結果時，請求取消。

**[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) 之間有何差異？**

來源允許您的應用程式請求取消。Token 讓 Aspose.Slides 與您的應用程式檢查此請求。

**我可以在 Aspose.Slides 中使用 .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) 嗎？**

可以。當您的 .NET token 發出取消訊號時，對與簡報關聯的來源呼叫 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/)。

**我可以中斷哪些作業？**

您可以中斷載入、儲存和算繪。透過 [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) 將 token 傳遞給 [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)。之後簡報在執行如 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 等後續作業時即可偵測取消。

**作業會立即停止嗎？**

取消是合作式的。作業會定期檢查 token，並在偵測到請求時停止。

**如果在作業完成後呼叫 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) 會發生什麼情況？**

已完成的作業會保留其結果。

**多個作業可以共用同一個 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) 嗎？**

可以。呼叫 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) 會對所有使用該來源之 token 的作業請求取消。若希望個別取消每個作業，請為每個作業使用不同的來源。