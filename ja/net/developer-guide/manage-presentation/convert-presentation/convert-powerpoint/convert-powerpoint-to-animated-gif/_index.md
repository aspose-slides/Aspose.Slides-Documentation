---
title: .NET で PowerPoint プレゼンテーションをアニメーション GIF に変換
linktitle: PowerPoint を GIF に変換
type: docs
weight: 65
url: /ja/net/convert-powerpoint-to-animated-gif/
keywords:
- アニメーションGIF
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を GIF に変換
- プレゼンテーションを GIF に変換
- スライドを GIF に変換
- PPT を GIF に変換
- PPTX を GIF に変換
- PPT を GIF として保存
- PPTX を GIF として保存
- PPT を GIF にエクスポート
- PPTX を GIF にエクスポート
- デフォルト設定
- カスタム設定
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーション (PPT、PPTX) をアニメーション GIF に簡単に変換します。高速で高品質な結果を実現します。"
---

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換する**

このC#のサンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


アニメーションGIFはデフォルトパラメータで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 
GIFのパラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) クラスを使用できます。以下のサンプルコードをご覧ください。 
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換する**

このC#のサンプルコードは、カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 生成されたGIFのサイズ  
        DefaultDelay = 2000, // 各スライドが次のスライドに切り替わるまでの表示時間
        TransitionFps = 35 // トランジションアニメーションの品質を向上させるためにFPSを増加させる
    });
}
```


{{% alert title="Info" color="info" %}}
Asposeが提供する無料の[テキストからGIFへ](https://products.aspose.app/slides/text-to-gif) コンバータを確認してみてください。 
{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[フォールバックフォントを設定する](/slides/ja/net/powerpoint-fonts/) してください。Aspose.Slides は代替フォントで置き換えますが、外観が異なる場合があります。ブランド管理のため、必ず必要な書体が明示的に利用できるようにしてください。

**GIFフレームにウォーターマークを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個別のスライドに[半透明のオブジェクト/ロゴを追加](/slides/ja/net/watermark/) すれば、ウォーターマークがすべてのフレームに表示されます。