---
title: プレゼンテーションのスライド全体の背景を画像として取得
linktitle: スライド全体の背景
type: docs
weight: 95
url: /ja/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライドの背景
- 最終背景
- 背景の抽出
- 全体の背景
- 背景を画像に変換
- PPT の背景
- PPTX の背景
- ODP の背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint と OpenDocument のプレゼンテーションからスライド全体の背景を画像として抽出し、ビジュアルワークフローを効率化します。"
---

## **スライド全体の背景を取得する**

PowerPoint プレゼンテーションでは、スライドの背景は多数の要素で構成される可能性があります。[slide background](/slides/ja/java/presentation-background/) として設定された画像に加えて、最終的な背景はプレゼンテーションのテーマ、配色、マスタースライドやレイアウトスライドに配置された図形の影響を受けます。

Aspose.Slides for Java には、プレゼンテーション全体のスライド背景を画像として抽出する簡単なメソッドはありませんが、以下の手順で実行できます。
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンしたスライドから図形を削除します。
1. クローンしたスライドを画像に変換します。

以下のコード例は、プレゼンテーション全体のスライド背景を画像として抽出します。
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```


## **よくある質問**

**マスタースライドからの複雑なグラデーション、テクスチャ、または画像塗りつぶしは、生成される背景画像に保持されますか？**

はい。Aspose.Slides はスライド、レイアウト、またはマスターで定義されたグラデーション、画像、テクスチャの塗りつぶしをレンダリングします。継承されたマスターから外観を分離したい場合は、エクスポート前に現在のスライドに[set an own background](/slides/ja/java/presentation-background/) を設定してください。

**保存前に生成された背景画像に透かしを追加できますか？**

はい。[watermark](/slides/ja/java/watermark/) 形状または画像を作業用の[copy of the slide](/slides/ja/java/clone-slides/) に（他のコンテンツの背後に配置して）追加し、エクスポートできます。これにより、透かしが埋め込まれた背景画像を生成できます。

**既存のスライドに紐付けずに、特定のレイアウトまたはマスターの背景を取得できますか？**

はい。目的のマスターまたはレイアウトにアクセスし、必要なサイズの[temporary slide](/slides/ja/java/clone-slides/) に適用してエクスポートすれば、そのレイアウトまたはマスターから派生した背景を取得できます。

**画像エクスポートに影響するライセンス制限はありますか？**

レンダリング機能は[valid license](/slides/ja/java/licensing/) があれば完全に利用可能です。評価モードでは透かしなどの制限が出力に含まれる場合があります。バッチエクスポートを実行する前に、プロセスごとにライセンスを有効化してください。