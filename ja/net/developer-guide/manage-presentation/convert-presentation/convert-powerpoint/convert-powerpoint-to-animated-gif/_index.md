---
title: PowerPoint プレゼンテーションを .NET でアニメーション GIF に変換
linktitle: PowerPoint を GIF に変換
type: docs
weight: 65
url: /ja/net/convert-powerpoint-to-animated-gif/
keywords:
- アニメーション GIF
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
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーション（PPT、PPTX）を簡単にアニメーション GIF に変換できます。高速で高品質な結果を提供します。"
---

## **プレゼンテーションをデフォルト設定でアニメーションGIFに変換**

このC#サンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


アニメーションGIFはデフォルトのパラメーターで作成されます。 

{{%  alert  title="TIP"  color="primary"  %}} 
GIFのパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions)クラスを使用できます。以下のサンプルコードをご参照ください。 
{{% /alert %}} 

## **プレゼンテーションをカスタム設定でアニメーションGIFに変換**

このサンプルコードは、C#でカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 生成された GIF のサイズ  
        DefaultDelay = 2000, // 各スライドが次に切り替わるまで表示される時間
        TransitionFps = 35 // トランジションアニメーションの品質を向上させるために FPS を増やす
    });
}
```


{{% alert title="Info" color="info" %}}
Asposeが提供する無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバーターをご利用ください。 
{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[フォールバックフォントを構成](/slides/ja/net/powerpoint-fonts/)してください。Aspose.Slides は代替フォントで置き換えますが、外観が異なる場合があります。ブランドの一貫性を保つため、必要な書体が確実に利用可能であることを常に確認してください。

**GIFフレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個別のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/net/watermark/)を追加してください。透かしはすべてのフレームに表示されます。