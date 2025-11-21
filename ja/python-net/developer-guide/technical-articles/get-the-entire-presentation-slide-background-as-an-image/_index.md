---
title: プレゼンテーションからスライド全体の背景を画像として取得
linktitle: スライド全体の背景
type: docs
weight: 95
url: /ja/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライド背景
- 最終背景
- 背景を画像に変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET）を使用して、PowerPoint と OpenDocument のプレゼンテーションからスライド全体の背景を画像として抽出し、ビジュアル ワークフローを効率化します。"
---

## **スライド全体の背景を取得**

PowerPoint プレゼンテーションでは、スライドの背景は多数の要素で構成されることがあります。[スライドの背景](/slides/ja/python-net/presentation-background/) に設定された画像に加えて、最終的な背景はプレゼンテーションのテーマ、カラースキーム、およびマスタースライドやレイアウトスライドに配置された図形の影響を受けます。

Aspose.Slides for Python には、プレゼンテーション全体のスライド背景を画像として抽出する簡単な方法は用意されていませんが、以下の手順で実行できます:
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
1. プレゼンテーションからスライドのサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンしたスライドから図形を削除します。
1. クローンしたスライドを画像に変換します。

以下のコード例は、プレゼンテーション全体のスライド背景を画像として抽出します。
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```


## **FAQ**

**マスタースライドからの複雑なグラデーション、テクスチャ、または画像塗りつぶしは、生成された背景画像に保持されますか？**

はい。Aspose.Slides はスライド、レイアウト、またはマスターで定義されたグラデーション、画像、テクスチャの塗りつぶしをレンダリングします。継承されたマスターの外観を分離したい場合は、エクスポート前に現在のスライドに[独自の背景](/slides/ja/python-net/presentation-background/) を設定してください。

**保存する前に、生成された背景画像に透かしを追加できますか？**

はい。作業用の[スライドのコピー](/slides/ja/python-net/clone-slides/) に透かしシェイプや画像を（他のコンテンツの背後に配置して）追加し、次にエクスポートできます。これにより、透かしが埋め込まれた背景画像を生成できます。

**既存のスライドに紐付けずに、特定のレイアウトまたはマスターの背景を取得できますか？**

はい。目的のマスターまたはレイアウトにアクセスし、必要なサイズの[一時スライド](/slides/ja/python-net/clone-slides/) に適用してエクスポートすれば、そのレイアウトまたはマスターから導き出された背景を取得できます。

**画像エクスポートに影響するライセンス制限はありますか？**

レンダリング機能は[有効なライセンス](/slides/ja/python-net/licensing/) があれば完全に利用できます。評価モードでは、出力に透かしなどの制限が含まれる場合があります。バッチエクスポートを実行する前に、プロセスごとにライセンスを一度アクティブ化してください。