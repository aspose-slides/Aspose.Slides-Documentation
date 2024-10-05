---
title: Aspose.Slidesにおけるフォント置換のための警告コールバックの取得
type: docs
weight: 120
url: /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for .NETでは、レンダリングプロセス中に使用されるフォントがマシン上で利用できない場合に、フォント置換のための警告コールバックを取得できるようにします。警告コールバックは、レンダリングプロセス中の欠損またはアクセス不能なフォントの問題をデバッグするのに役立ちます。

{{% /alert %}} 
## **フォント置換のための警告コールバックの取得**
Aspose.Slides for .NETは、レンダリングプロセス中に警告コールバックを取得するためのシンプルなAPIメソッドを提供します。警告コールバックを設定するために、以下の手順に従う必要があります。:

1. コールバックを受信するためのカスタムコールバッククラスを作成します。
1. LoadOptionsクラスを使用して警告コールバックを設定します。
1. 目的のマシン上で利用できないフォントを使用しているプレゼンテーションファイルを読み込みます。
1. スライドのサムネイルを生成して効果を確認します。

```c#
//警告コールバックの設定
LoadOptions lo = new LoadOptions();
lo.WarningCallback = new HandleFontsWarnings();

//プレゼンテーションのインスタンス化
Presentation presentation = new Presentation("1.ppt", lo);

//スライドサムネイルの生成
foreach (ISlide slide in presentation.Slides)
{
    IImage image = slide.GetImage();
}
```

```c#
class HandleFontsWarnings : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine(warning.WarningType); // 1 - WarningType.DataLoss
        Console.WriteLine(warning.Description); // "フォントはXからYに置換されます"
        return ReturnAction.Continue;
    }
}
```