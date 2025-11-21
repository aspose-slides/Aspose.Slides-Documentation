---
title: スライド全体の背景を画像として取得
type: docs
weight: 95
url: /ja/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライド背景
- 背景を画像に変換
- PowerPoint
- PPT
- PPTX
- PowerPoint プレゼンテーション
- C#
- VB.NET
- Aspose.Slides for .NET
---

## **スライド全体の背景を取得**

PowerPoint プレゼンテーションでは、スライドの背景は複数の要素で構成されることがあります。[slide background](/slides/ja/net/presentation-background/) として設定された画像に加えて、プレゼンテーションのテーマ、カラースキーム、マスタースライドやレイアウトスライドに配置された図形が最終的な背景に影響します。

Aspose.Slides for .NET では、プレゼンテーション全体のスライド背景を画像として抽出する簡単なメソッドは提供されていませんが、以下の手順で実現できます。
1. Presentation([https://reference.aspose.com/slides/net/aspose.slides/presentation/](https://reference.aspose.com/slides/net/aspose.slides/presentation/)) クラスを使用してプレゼンテーションをロードします。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンしたスライドから図形を削除します。
1. クローンしたスライドを画像に変換します。

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

**マスタースライドの複雑なグラデーション、テクスチャ、または画像塗りつぶしは、生成された背景画像に保持されますか？**

はい。Aspose.Slides は、スライド、レイアウト、またはマスターで定義されたグラデーション、画像、テクスチャの塗りつぶしをレンダリングします。継承されたマスターから外観を分離したい場合は、エクスポート前に現在のスライドに[set an own background](/slides/ja/net/presentation-background/) を設定してください。

**保存する前に、生成された背景画像に透かしを追加できますか？**

はい。作業用の[copy of the slide](/slides/ja/net/clone-slides/) に[add a watermark](/slides/ja/net/watermark/) 図形または画像を（他のコンテンツの背面に配置して）追加し、その後エクスポートできます。これにより、透かしが埋め込まれた背景画像を生成できます。

**既存のスライドに結び付けずに、特定のレイアウトまたはマスターの背景を取得できますか？**

はい。目的のマスターまたはレイアウトにアクセスし、必要なサイズの[temporary slide](/slides/ja/net/clone-slides/) に適用してエクスポートすれば、そのレイアウトまたはマスターから派生した背景を取得できます。

**画像エクスポートに影響するライセンスの制限はありますか？**

レンダリング機能は[valid license](/slides/ja/net/licensing/) があれば完全に利用できます。評価モードでは、透かしなどの制限が出力に含まれる可能性があります。バッチエクスポートを実行する前に、プロセスごとに一度ライセンスを有効化してください。