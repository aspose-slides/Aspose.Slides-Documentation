---
title: プレゼンテーションのスライド全体の背景を画像として取得
linktitle: スライド全体の背景
type: docs
weight: 95
url: /ja/androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションからスライド全体の背景を画像として抽出し、ビジュアルワークフローを効率化します。"
---

## **スライド全体の背景を取得する**

PowerPoint プレゼンテーションでは、スライドの背景は多数の要素で構成される可能性があります。[スライドの背景](/slides/ja/androidjava/presentation-background/) に設定された画像に加えて、最終的な背景はプレゼンテーションのテーマ、カラースキーム、マスタースライドやレイアウトスライドに配置された形状の影響を受けます。

Aspose.Slides for Android via Java には、プレゼンテーションのスライド全体の背景を画像として抽出する簡単なメソッドは用意されていませんが、以下の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンしたスライドから形状を削除します。
1. クローンしたスライドを画像に変換します。

以下のコード例は、プレゼンテーションのスライド全体の背景を画像として抽出します。
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```


## **よくある質問**

**マスタースライドの複雑なグラデーション、テクスチャ、または画像塗りつぶしは、生成される背景画像に保持されますか？**

はい。Aspose.Slides は、スライド、レイアウト、またはマスターで定義されたグラデーション、画像、テクスチャの塗りつぶしをレンダリングします。継承されたマスターから外観を分離したい場合は、エクスポート前に現在のスライドで[独自の背景](/slides/ja/androidjava/presentation-background/) を設定してください。

**保存する前に、生成された背景画像に透かしを追加できますか？**

はい。作業用の[スライドのコピー](/slides/ja/androidjava/clone-slides/) に[透かし](/slides/ja/androidjava/watermark/) の形状または画像を（他のコンテンツの背後に配置して）追加し、その後エクスポートできます。これにより、透かしが組み込まれた背景画像を生成できます。

**既存のスライドに紐付けずに、特定のレイアウトまたはマスターの背景を取得できますか？**

はい。目的のマスターまたはレイアウトにアクセスし、必要なサイズの[一時スライド](/slides/ja/androidjava/clone-slides/) に適用して、そのスライドをエクスポートすれば、レイアウトまたはマスターから派生した背景を取得できます。

**画像エクスポートに影響するライセンス制限はありますか？**

レンダリング機能は[有効なライセンス](/slides/ja/androidjava/licensing/) があれば完全に利用できます。評価モードでは、透かしなどの制限が出力に含まれる場合があります。バッチエクスポートを実行する前に、プロセスごとに一度ライセンスを有効化してください。