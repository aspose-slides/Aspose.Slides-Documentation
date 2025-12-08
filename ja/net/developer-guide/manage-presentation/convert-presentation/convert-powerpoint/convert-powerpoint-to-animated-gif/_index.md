---
title: PowerPoint をアニメーション GIF に変換
type: docs
weight: 65
url: /ja/net/convert-powerpoint-to-animated-gif/
keywords: "PowerPoint を変換, PPT, PPTX, アニメーション GIF, PPT をアニメーション GIF に変換, PPTX をアニメーション GIF に変換, C#, Csharp, .NET, デフォルト設定, カスタム設定"
description: "PowerPoint プレゼンテーションをアニメーション GIF に変換: PPT を GIF に、PPTX を GIF に C# または .NET で"
---

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換する**

この C# のサンプルコードは、標準設定を使用してプレゼンテーションをアニメーション GIF に変換する方法を示します：
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


アニメーション GIF はデフォルトのパラメーターで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 
GIF のパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) クラスを使用できます。以下のサンプルコードをご覧ください。 
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換する**

このサンプルコードは、C# でカスタム設定を使用してプレゼンテーションをアニメーション GIF に変換する方法を示します：
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 生成された GIF のサイズ  
        DefaultDelay = 2000, // 各スライドが次に切り替わるまで表示される時間
        TransitionFps = 35 // 遷移アニメーションの品質を向上させるために FPS を増加させる
    });
}
```


{{% alert title="Info" color="info" %}}
Aspose が提供する無料の [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバーターをご確認ください。 
{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうすればよいですか？**

不足しているフォントをインストールするか、[フォールバック フォントを構成](/slides/ja/net/powerpoint-fonts/)してください。Aspose.Slides は代替フォントを使用しますが、見た目が変わる可能性があります。ブランディングのためには、必ず必要な書体が明示的に利用可能であることを確認してください。

**GIF フレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/net/watermark/)を追加すると、透かしがすべてのフレームに表示されます。