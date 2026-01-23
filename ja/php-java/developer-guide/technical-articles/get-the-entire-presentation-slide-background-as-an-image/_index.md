---
title: プレゼンテーションからスライド全体の背景を画像として取得
linktitle: スライド全体の背景
type: docs
weight: 95
url: /ja/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド背景
- 最終背景
- 背景抽出
- 全体背景
- 背景を画像に変換
- PPT背景
- PPTX背景
- ODP背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションからスライド全体の背景を画像として抽出し、視覚的ワークフローを効率化します。"
---

## **スライド全体の背景を取得**

PowerPoint プレゼンテーションでは、スライドの背景は多数の要素で構成される場合があります。[スライドの背景](/slides/ja/php-java/presentation-background/)として設定された画像に加えて、プレゼンテーションのテーマ、配色、マスタースライドやレイアウトスライドに配置された形状が最終的な背景に影響します。

Aspose.Slides for PHP via Java には、プレゼンテーション全体のスライド背景を画像として抽出する簡単なメソッドはありませんが、以下の手順で実現できます:
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンしたスライドから形状を削除します。
1. クローンしたスライドを画像に変換します。

次のコード例は、プレゼンテーション全体のスライド背景を画像として抽出します。
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```


## **FAQ**

**マスタースライドの複雑なグラデーション、テクスチャ、または画像塗りつぶしは、生成された背景画像に保持されますか？**

はい。Aspose.Slides は、スライド、レイアウト、またはマスターで定義されたグラデーション、画像、テクスチャの塗りつぶしをレンダリングします。継承されたマスターから見た目を分離したい場合は、エクスポート前に現在のスライドに[独自の背景](/slides/ja/php-java/presentation-background/) を設定してください。

**保存する前に結果の背景画像に透かしを追加できますか？**

はい。作業用の[スライドのコピー](/slides/ja/php-java/clone-slides/) に[透かし](/slides/ja/php-java/watermark/) 形状または画像を（他のコンテンツの背後に）配置し、次にエクスポートできます。これにより、透かしが埋め込まれた背景画像を生成できます。

**既存のスライドに結び付けずに、特定のレイアウトまたはマスターの背景だけを取得できますか？**

はい。目的のマスターまたはレイアウトにアクセスし、必要なサイズの[一時スライド](/slides/ja/php-java/clone-slides/) に適用してからエクスポートすれば、そのレイアウトまたはマスター由来の背景を取得できます。

**画像エクスポートに影響するライセンス制限はありますか？**

レンダリング機能は[有効なライセンス](/slides/ja/php-java/licensing/) があればフルに利用できます。評価モードでは、透かしなどの制限が出力に含まれる場合があります。バッチエクスポートを実行する前に、プロセスごとにライセンスを有効化してください。