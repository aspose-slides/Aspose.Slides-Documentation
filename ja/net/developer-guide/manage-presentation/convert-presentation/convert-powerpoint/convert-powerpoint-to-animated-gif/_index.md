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
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーション（PPT、PPTX）を簡単にアニメーション GIF に変換します。高速で高品質な結果を提供します。"
---
## **概要**

Aspose.Slides を使用すると、数行のコードで PowerPoint プレゼンテーションをアニメーション GIF ファイルに変換できます。これは、スライドの内容を軽量で広くサポートされているアニメーション形式で共有し、Web ページやメッセンジャー、ドキュメントに埋め込む必要がある場合に便利です。この記事では、デフォルト設定でプレゼンテーションを GIF にエクスポートする方法と、[GifOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/gifoptions/) を使用してフレームサイズ、スライド遅延、遷移フレームレートなどのオプションを構成して出力をカスタマイズする方法を説明します。

## **デフォルト設定を使用したプレゼンテーションのアニメーションGIFへの変換**

この C# サンプルコードは、標準設定でプレゼンテーションをアニメーション GIF に変換する方法を示しています：

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

アニメーション GIF はデフォルトのパラメーターで作成されます。

{{%  alert  title="TIP"  color="info"  %}} 

GIF のパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/gifoptions) クラスを使用できます。以下のサンプルコードをご覧ください。 

{{% /alert %}} 

## **カスタム設定を使用したプレゼンテーションのアニメーションGIFへの変換**

このサンプルコードは、C# でカスタム設定を使用してプレゼンテーションをアニメーション GIF に変換する方法を示しています：

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 生成された GIF のサイズ  
        DefaultDelay = 2000, // 各スライドが表示される時間（次のスライドに切り替わるまでの時間）
        TransitionFps = 35 // トランジション アニメーションの品質を向上させるために FPS を上げる
    });
}
```

{{% alert title="Info" color="info" %}}

Aspose が開発した無料の [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータをぜひお試しください。 

{{% /alert %}}

## **FAQ**

### プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？

欠落しているフォントをインストールするか、[フォールバック フォントを構成](/slides/ja/net/powerpoint-fonts/)してください。Aspose.Slides は代替フォントを使用しますが、外観が異なる場合があります。ブランドの一貫性を保つため、必要なフォントは必ず明示的に利用可能にしてください。

### GIF フレームに透かしを重ねることはできますか？

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/net/watermark/)を追加すると、透かしがすべてのフレームに表示されます。