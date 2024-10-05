---
title: PowerPointをアニメーションGIFに変換
type: docs
weight: 65
url: /net/convert-powerpoint-to-animated-gif/
keywords: "PowerPointの変換, PPT, PPTX, アニメーションGIF, PPTをアニメーションGIFに, PPTXをアニメーションGIFに C#, Csharp, .NET, 既定の設定, カスタム設定"
description: "PowerPointプレゼンテーションをアニメーションGIFに変換: C#または.NETでPPTをGIF、PPTXをGIFに"
---

## 既定の設定を使用してプレゼンテーションをアニメーションGIFに変換する ##

このC#のサンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

アニメーションGIFは、既定のパラメーターで作成されます。

{{%  alert  title="ヒント"  color="primary"  %}} 

GIFのパラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions)クラスを使用できます。以下のサンプルコードを参照してください。

{{% /alert %}} 

## カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する ##
このサンプルコードは、C#でカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 結果のGIFのサイズ  
        DefaultDelay = 2000, // 各スライドが表示されてから次のスライドに変更されるまでの時間
        TransitionFps = 35 // トランジションアニメーションの品質を向上させるためにFPSを上げる
    });
}
```

{{% alert title="情報" color="info" %}}

Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバーターをチェックしてみると良いでしょう。

{{% /alert %}}