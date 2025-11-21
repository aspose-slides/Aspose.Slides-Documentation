---
title: プレゼンテーションからスライド全体の背景を画像として取得
linktitle: スライド全体の背景
type: docs
weight: 95
url: /ja/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド背景
- 最終背景
- 背景抽出
- 全体背景
- 背景を画像に変換
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションからスライド全体の背景を画像として抽出し、ビジュアルワークフローを効率化します。"
---

## **スライド全体の背景を取得**

PowerPoint プレゼンテーションでは、スライドの背景は多数の要素で構成される場合があります。[スライド背景](/slides/ja/net/presentation-background/)として設定された画像に加えて、プレゼンテーションのテーマや配色、マスタースライドやレイアウトスライドに配置された図形が最終的な背景に影響を与えることがあります。

Aspose.Slides for .NET には、プレゼンテーション全体のスライド背景を画像として抽出する簡単なメソッドは用意されていませんが、以下の手順で実現できます。
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込む。
1. プレゼンテーションからスライドサイズを取得する。
1. スライドを選択する。
1. 一時的なプレゼンテーションを作成する。
1. 一時的なプレゼンテーションに同じスライドサイズを設定する。
1. 選択したスライドを一時的なプレゼンテーションにクローンする。
1. クローンしたスライドから図形を削除する。
1. クローンしたスライドを画像に変換する。

以下のコード例は、プレゼンテーションのスライド全体の背景を画像として抽出します。
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```


## **よくある質問**

**マスタースライドからの複雑なグラデーション、テクスチャ、または画像塗りつぶしは、生成される背景画像に保持されますか？**

はい。Aspose.Slides はスライド、レイアウト、またはマスターで定義されたグラデーション、画像、テクスチャの塗りつぶしをレンダリングします。継承されたマスターから外観を分離したい場合は、エクスポート前に現在のスライドに[独自の背景](/slides/ja/net/presentation-background/)を設定してください。

**保存する前に、結果の背景画像に透かしを追加できますか？**

はい。[透かし](/slides/ja/net/watermark/) の形状または画像を作業用の[スライドコピー](/slides/ja/net/clone-slides/)（他のコンテンツの背後に配置）に追加し、その後エクスポートできます。これにより、透かしが埋め込まれた背景画像を生成できます。

**既存のスライドに結び付けずに、特定のレイアウトまたはマスターの背景だけを取得できますか？**

はい。対象のマスターまたはレイアウトにアクセスし、必要なサイズの[一時スライド](/slides/ja/net/clone-slides/)に適用してからエクスポートすれば、そのレイアウトやマスターから派生した背景を取得できます。

**画像エクスポートに影響するライセンス制限はありますか？**

レンダリング機能は[有効なライセンス](/slides/ja/net/licensing/)があればフルに利用可能です。評価モードでは透かしなどの制限が出力に含まれる場合があります。バッチエクスポートを実行する前に、プロセス開始時にライセンスを有効化してください。