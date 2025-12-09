---
title: .NET で PowerPoint プレゼンテーションをアニメーション GIF に変換
linktitle: PowerPoint から GIF へ
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
- PowerPoint から GIF へ
- プレゼンテーションから GIF へ
- スライドから GIF へ
- PPT から GIF へ
- PPTX から GIF へ
- PPT を GIF として保存
- PPTX を GIF として保存
- PPT を GIF にエクスポート
- PPTX を GIF にエクスポート
- デフォルト設定
- カスタム設定
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーション（PPT、PPTX）をアニメーション GIF に簡単に変換できます。高速で高品質な結果を提供します。"
---

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換する**

このC#サンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示します:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


アニメーションGIFはデフォルトパラメータで作成されます。 

{{%  alert  title="TIP"  color="primary"  %}} 
カスタム設定でGIFのパラメータを調整したい場合は、[GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions)クラスを使用できます。以下のサンプルコードをご参照ください。 
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換する**

このサンプルコードは、C#でカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示します:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 生成された GIF のサイズ
        DefaultDelay = 2000, // 各スライドが次に切り替わるまで表示される時間
        TransitionFps = 35 // トランジションアニメーションの品質向上のために FPS を上げる
    });
}
```


{{% alert title="Info" color="info" %}}
Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバータをご利用ください。 
{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうすればよいですか？**

不足しているフォントをインストールするか、[フォールバックフォントを構成](/slides/ja/net/powerpoint-fonts/)してください。Aspose.Slidesは代替フォントを使用しますが、外観が変わる可能性があります。ブランディングのためには、必要な書体が確実に利用可能であることを確認してください。

**GIFフレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個別スライドに[半透明オブジェクト/ロゴ](/slides/ja/net/watermark/)を追加すると、透かしがすべてのフレームに表示されます。