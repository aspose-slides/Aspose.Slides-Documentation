---
title: 中断可能ライブラリのサポート
type: docs
weight: 150
url: /ja/net/support-for-interruptable-library/
keywords:
- 中断可能ライブラリ
- 割り込みトークン
- キャンセルトークン
- 長時間実行タスク
- タスクの中断
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して長時間実行タスクをキャンセル可能にします。PowerPoint および OpenDocument のレンダリングや変換を安全に中断でき、サンプル付きです。"
---

## **中断可能ライブラリ**

Aspose.Slides 18.4 では、[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) クラスを導入しました。これらは、デシリアライズ、シリアライズ、レンダリングなどの長時間実行タスクを中断できるようにします。

- [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) は、[ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) に渡されるトークンのソースです。
- [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) が設定され、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) インスタンスが [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) コンストラクタに渡された場合、[InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) を呼び出すと、その [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) に関連付けられた長時間実行タスクが中断されます。

以下のコードスニペットは、実行中のタスクを中断する方法を示しています:
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
    Run(action, tokenSource.Token); // 別スレッドでアクションを実行します
    Thread.Sleep(10000);            // タイムアウト
    tokenSource.Interrupt();        // 変換を停止します
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```


## **.NET CancellationToken と 中断可能ライブラリ**

Aspose.Slides の中断可能ライブラリと共に [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) を使用する必要がある場合は、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) の処理をラップし、[CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) が `true` のときに [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) を中断します。

この C# コードはその操作を示しています:
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
    Task task = Run(action, tokenSource.Token); // 別スレッドでアクションを実行します

    while (!task.Wait(500)) // キャンセルトークンが要求されているか待機し、監視します
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // プレゼンテーションの処理を中断します
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


## **FAQ**

**Aspose.Slides の中断ライブラリの目的は何ですか？**

長時間実行される操作（プレゼンテーションの読み込み、保存、レンダリングなど）を完了前に中断できるメカニズムを提供します。処理時間を制限したい場合やタスクが不要になった場合に便利です。

**[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) の違いは何ですか？**

- `InterruptionToken` は Aspose.Slides API に渡され、長時間実行される操作中にチェックされます。
- `InterruptionTokenSource` はコード側でトークンを作成し、`Interrupt()` を呼び出すことで中断をトリガーします。

**.NET の [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) を中断ライブラリと併用できますか？**

はい。アプリケーションロジックで [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) を監視し、キャンセルが要求されたときに [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) を呼び出すことができます。これにより Aspose.Slides が標準的な .NET のキャンセルフローと統合されます。

**どのタスクを中断できますか？**

[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) を受け取るすべての Aspose.Slides タスク、たとえば `Presentation(path, loadOptions)` でのプレゼンテーションの読み込みや `Presentation.Save(...)` での保存などが中断可能です。

**中断はすぐに行われますか？**

いいえ。中断は協調的に行われます。操作は定期的にトークンをチェックし、[Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) が呼び出されたことを検出した時点で停止します。

**タスクがすでに完了した後に [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) を呼び出すとどうなりますか？**

何も起こりません。対象のタスクがすでに完了している場合、呼び出しは効果がありません。

**複数のタスクで同じ [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) を再利用できますか？**

はい。ただし、そのソースで [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) を呼び出すと、其々のトークンを使用しているすべてのタスクが中断されます。タスクを個別に管理したい場合は、別々のトークンソースを使用してください。