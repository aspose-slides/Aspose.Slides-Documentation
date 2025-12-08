---
title: プレゼンテーション全体のスライド背景を画像として取得
type: docs
weight: 95
url: /ja/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライド背景
- 背景を画像に変換
- PowerPoint
- PPT
- PPTX
- PowerPoint プレゼンテーション
- Node
- JavaScript
- Aspose.Slides for Node.js via Java
---

## **スライドの全体背景の取得**

PowerPoint プレゼンテーションでは、スライドの背景は多数の要素で構成される場合があります。画像が[スライドの背景](/slides/ja/nodejs-java/presentation-background/)として設定されていることに加えて、最終的な背景はプレゼンテーションのテーマ、配色、マスタースライドやレイアウトスライドに配置された形状の影響を受けます。

Aspose.Slides for Node.js via Java には、プレゼンテーションのスライド全体の背景を画像として抽出する簡単な方法は用意されていませんが、以下の手順で実現できます。
1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時プレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時プレゼンテーションにクローンします。
1. クローンしたスライドから形状を削除します。
1. クローンしたスライドを画像に変換します。

次のコード例は、プレゼンテーションのスライド全体の背景を画像として抽出します。
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```


## **よくある質問**

**マスタースライドの複雑なグラデーション、テクスチャ、または画像塗りが生成された背景画像に保持されますか？**

はい。Aspose.Slides はスライド、レイアウト、またはマスターで定義されたグラデーション、画像、テクスチャの塗りをレンダリングします。継承されたマスターから外観を分離したい場合は、エクスポート前に現在のスライドに[独自の背景を設定](/slides/ja/nodejs-java/presentation-background/)してください。

**保存する前に、生成された背景画像に透かしを追加できますか？**

はい。作業用の[スライドのコピー](/slides/ja/nodejs-java/clone-slides/)に[透かしを追加](/slides/ja/nodejs-java/watermark/)形状または画像を配置（他のコンテンツの後ろに置く）し、エクスポートすれば、透かしが埋め込まれた背景画像を生成できます。

**既存のスライドに結びつけずに、特定のレイアウトまたはマスターの背景を取得できますか？**

はい。目的のマスターまたはレイアウトにアクセスし、必要なサイズの[一時スライド](/slides/ja/nodejs-java/clone-slides/)に適用してエクスポートすれば、そのレイアウトまたはマスター由来の背景を取得できます。

**画像エクスポートに影響するライセンス制限はありますか？**

レンダリング機能は[有効なライセンス](/slides/ja/nodejs-java/licensing/)があれば完全に利用可能です。評価モードでは、透かしなどの制限が出力に含まれる場合があります。バッチエクスポートを実行する前に、プロセスごとに一度ライセンスを有効化してください。