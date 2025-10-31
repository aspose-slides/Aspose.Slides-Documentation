---
title: プレゼンテーションから全スライド背景を画像として取得する
linktitle: 全スライド背景
type: docs
weight: 95
url: /ja/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライド背景
- 最終背景
- 背景を画像へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションからスライド全体の背景を画像として抽出し、視覚的ワークフローを効率化します。"
---

## **全スライド背景の取得**

PowerPoint プレゼンテーションでは、スライドの背景は多数の要素で構成されることがあります。[スライド背景](/slides/ja/python-net/presentation-background/) として設定された画像に加えて、プレゼンテーションのテーマ、カラースキーム、マスタースライドやレイアウトスライドに配置された形状が最終的な背景に影響します。

Aspose.Slides for Python には、プレゼンテーション全体のスライド背景を画像として抽出する単純なメソッドは用意されていませんが、以下の手順で実現できます。
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込む。
1. プレゼンテーションからスライドサイズを取得する。
1. スライドを選択する。
1. 一時的なプレゼンテーションを作成する。
1. 一時的なプレゼンテーションに同じスライドサイズを設定する。
1. 選択したスライドを一時的なプレゼンテーションにクローンする。
1. クローンしたスライドから形状を削除する。
1. クローンしたスライドを画像に変換する。

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

## **よくある質問**

**マスタースライドの複雑なグラデーション、テクスチャ、または画像の塗りつぶしは、生成される背景画像に保持されますか？**

はい。Aspose.Slides はスライド、レイアウト、またはマスター上で定義されたグラデーション、画像、テクスチャの塗りつぶしをレンダリングします。継承されたマスターの見た目を除外したい場合は、エクスポート前に現在のスライドに[独自の背景](/slides/ja/python-net/presentation-background/)を設定してください。

**保存前に結果の背景画像に透かしを追加できますか？**

はい。[透かし](/slides/ja/python-net/watermark/) の形状または画像を作業用の[スライドコピー](/slides/ja/python-net/clone-slides/)（他のコンテンツの背後に配置）に追加し、エクスポートすれば、透かしが埋め込まれた背景画像を生成できます。

**既存のスライドに結びつけずに、特定のレイアウトまたはマスターの背景だけを取得できますか？**

はい。目的のマスターまたはレイアウトにアクセスし、必要なサイズの[一時スライド](/slides/ja/python-net/clone-slides/)に適用してエクスポートすれば、そのレイアウトまたはマスターから派生した背景を取得できます。

**画像エクスポートに影響するライセンス制限はありますか？**

レンダリング機能は[有効なライセンス](/slides/ja/python-net/licensing/)があればフルに利用可能です。評価モードでは透かしなどの制限が出力に含まれる場合があります。バッチエクスポートを実行する前に、プロセスごとに一度ライセンスを有効化してください。