---
title: 割り込み可能ライブラリのサポート
type: docs
weight: 150
url: /net/support-for-interruptable-library/

---

## **割り込み可能ライブラリ**

[Aspose.Slides 18.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-18-4-release-notes/) では、[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) クラスと [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource) クラスを追加しました。これにより、デシリアライズ、シリアライズ、またはレンダリングなどの長時間実行されるタスクの割り込みをサポートします。

- InterruptionTokenSource は **ILoadOptions.InterruptionToken** に渡されるトークンまたは複数のトークンのソースを表します。
- ILoadOptions.InterruptionToken が設定され、LoadOptions インスタンスが Presentation コンストラクターに渡されると、InterruptionTokenSource.Interrupt メソッドを呼び出すことで、Presentation に関連する長時間実行されるタスクが割り込まれます。

以下のコードスニペットは、実行中のタスクの割り込みを示しています：

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("pres.pptx", options))
        {
            presentation.Save("pres.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // 別のスレッドでアクションを実行
    Thread.Sleep(10000);            // タイムアウト
    tokenSource.Interrupt();        // 変換を停止


}
private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken と割り込み可能ライブラリ**

[Slides Interruptable Library](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) と一緒に [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) を使用する必要がある場合、Presentation 処理をラップし、[cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) が true に設定されている場合は [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) を割り込みます。

この C# コードは、説明された操作を示しています：

``` csharp
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("pres.pptx", "pres.pdf", tokenSource.Token);
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
    Task task = Run(action, tokenSource.Token); // 別のスレッドでアクションを実行

    while (!task.Wait(500)) // cancellationToken.IsCancellationRequested が設定されているかを監視するために待機します。
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("プレゼンテーション処理がキャンセルされました");
            tokenSource.Interrupt(); // プレゼンテーション処理を割り込む
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