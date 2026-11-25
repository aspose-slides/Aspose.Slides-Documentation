---
title: .NET における長時間実行プレゼンテーション操作の中断
linktitle: プレゼンテーション操作の中断
type: docs
weight: 150
url: /ja/net/support-for-interruptable-library/
keywords:
- 中断可能な操作
- インタラプション トークン
- キャンセルトークン
- 長時間実行タスク
- タスクの中断
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で長時間実行されるプレゼンテーション操作をキャンセルし、スライドをループでエクスポートする際に部分結果を返す方法を学びます。"
---
## **概要**

Aspose.Slides for .NET は、プレゼンテーションの読み込み、保存、レンダリングなどの長時間実行される操作を中断できます。アプリケーションは同じインタラプション トークンを使用して、次のスライドの処理を開始する前にループを停止できます。

## **プレゼンテーション操作の中断**

[InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) を作成し、その [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) を [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) に割り当て、ロード オプションを [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) に渡します。キャンセルを要求するには、ソース上で [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) を呼び出します。中断可能な操作は、要求を検知すると停止します。

この例は、バックグラウンド タスクで `sample.pptx` を `sample.ppt` に変換し、10 秒後にキャンセルを要求します。変換がそれより早く完了した場合、出力はすでに完了しています。

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
    Run(action, tokenSource.Token); // 別スレッドでアクションを実行します
    Thread.Sleep(10000);            // タイムアウト
    tokenSource.Interrupt();        // 変換を停止します
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```
## **.NET キャンセルを Aspose.Slides に接続**

アプリケーションが .NET の [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) を使用している場合、そのキャンセル要求を Aspose.Slides に転送します。この例は `sample.pptx` を `sample.pdf` にエクスポートし、20 秒のタイムアウトを設定して開始します。エクスポート中は、500 ミリ秒ごとに [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) をチェックします。プロパティが `true` になると、[InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) を呼び出します。

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
    Task task = Run(action, tokenSource.Token); // 別スレッドでアクションを実行します

    while (!task.Wait(500)) // キャンセル トークンの IsCancellationRequested が設定されているか待機し、監視します
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // プレゼンテーション処理を中断します
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
## **次のスライドを処理する前に停止**

[IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) をプレゼンテーションとスライドをエクスポートするループの両方で同じものとして使用します。各エクスポートを開始する前に [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) をチェックします。呼び出し元が部分結果を使用できる場合、正常に完了したエクスポートのスライド番号を返します。

少なくとも 2 枚のスライドがある `sample.pptx` というプレゼンテーションを使用します。この例は最初のエクスポートが成功した直後にキャンセルを要求します。

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
この例は `slide-1.pdf` を書き込み、`Starting slide 1` を出力し、続いて `Completed: [1]` を表示します。ループはスライド 2 を開始する前にキャンセル要求を検知します。キャンセルがエクスポート中に [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) を中断した場合、`catch` ブロックが現在のスライドを完了として記録する前にループを抜けます。

呼び出し元がキャンセルを処理する必要がある場合、ループ上部の `if` チェックとその `break` をトークン上の [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) 呼び出しに置き換えます。エクスポート周囲の `try`/`catch` を削除し、保存中のキャンセルも呼び出し元に伝わるようにします。同じ入力で、例は `Starting slide 1` のみを出力し、`slide-1.pdf` を書き込みます。2 回目のイテレーション開始時に、エクスポート開始前に呼び出し元は [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) を受け取ります。このメソッドはリストを返しません。

## **よくある質問**

**キャンセルはいつ要求すべきですか？**

操作が時間制限を超えた場合や、アプリケーションが結果をもう必要としない場合にキャンセルを要求します。

**[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) の違いは何ですか？**

ソースはアプリケーションがキャンセルを要求できるようにします。トークンは Aspose.Slides とアプリケーションがその要求を確認できるようにします。

**.NET の [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) を Aspose.Slides で使用できますか？**

はい。.NET のトークンがキャンセルを示したときは、プレゼンテーションに関連付けられたソースに対して [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) を呼び出します。

**どの操作を中断できますか？**

読み込み、保存、レンダリングを中断できます。トークンは [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) を介して [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) に渡します。これにより、プレゼンテーションは以降の操作（例: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)）中にキャンセルを検知できるようになります。

**操作はすぐに停止しますか？**

キャンセルは協調的です。操作はトークンを定期的にチェックし、要求を検知した時点で停止します。

**操作が完了した後に [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) を呼び出すとどうなりますか？**

完了した操作はその結果を保持します。

**複数の操作が同じ [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) を共有できますか？**

はい。[InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) を呼び出すと、そのソースから取得したトークンを使用するすべての操作に対してキャンセルが要求されます。個別にキャンセルしたい操作ごとに別々のソースを使用してください。