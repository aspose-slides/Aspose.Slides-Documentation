---
title: プレゼンテーションからスライド全体の背景を画像として取得
linktitle: スライド全体の背景
type: docs
weight: 95
url: /ja/cpp/get-the-entire-presentation-slide-background-as-an-image/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションからスライド全体の背景を画像として抽出し、視覚的ワークフローを効率化します。"
---

## **スライド全体の背景を取得**

PowerPoint プレゼンテーションでは、スライドの背景は複数の要素で構成されることがあります。画像だけでなく、[スライド背景](/slides/ja/cpp/presentation-background/)として設定された画像に加えて、プレゼンテーションのテーマ、配色スキーム、マスタースライドやレイアウトスライドに配置されたシェイプも最終的な背景に影響します。

Aspose.Slides for C++ には、プレゼンテーション全体のスライド背景を画像として抽出する単純なメソッドは用意されていませんが、以下の手順で実現できます。
1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時プレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時プレゼンテーションにクローンします。
1. クローンしたスライドからシェイプを削除します。
1. クローンしたスライドを画像に変換します。

以下のコード例は、プレゼンテーションのスライド全体の背景を画像として抽出します。
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```


## **FAQ**

**マスタースライドの複雑なグラデーション、テクスチャ、または画像塗りつぶしは、生成された背景画像に保持されますか？**

はい。Aspose.Slides はスライド、レイアウト、またはマスター上で定義されたグラデーション、画像、テクスチャの塗りつぶしをレンダリングします。継承されたマスターから外観を分離したい場合は、エクスポート前に現在のスライドに[独自の背景](/slides/ja/cpp/presentation-background/)を設定してください。

**保存前に結果の背景画像に透かしを追加できますか？**

はい。[透かし](/slides/ja/cpp/watermark/) シェイプまたは画像を作業用の[スライドのコピー](/slides/ja/cpp/clone-slides/)（他のコンテンツの背後に配置）に追加してからエクスポートできます。これにより、透かしが埋め込まれた背景画像を生成できます。

**既存のスライドに結び付けずに、特定のレイアウトまたはマスターの背景を取得できますか？**

はい。目的のマスターまたはレイアウトにアクセスし、必要なサイズの[一時スライド](/slides/ja/cpp/clone-slides/)に適用してからエクスポートすれば、そのレイアウトまたはマスターから派生した背景を取得できます。

**画像エクスポートに影響するライセンス制限はありますか？**

レンダリング機能は[有効なライセンス](/slides/ja/cpp/licensing/)があればフルに利用できます。評価モードでは、透かしなどの制限が出力に含まれる場合があります。バッチエクスポートを実行する前に、プロセスごとにライセンスを有効化してください。