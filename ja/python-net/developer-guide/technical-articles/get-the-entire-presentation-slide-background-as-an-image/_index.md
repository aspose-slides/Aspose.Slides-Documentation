---
title: プレゼンテーションスライド全体の背景を画像として取得する
type: docs
weight: 95
url: /ja/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライド背景
- 背景を画像に
- PowerPoint
- PPT
- PPTX
- PowerPointプレゼンテーション
- Python
- Aspose.Slides for Python
---

PowerPointプレゼンテーションでは、スライドの背景は多くの要素から構成される場合があります。[スライド背景](/slides/ja/python-net/presentation-background/)として設定された画像に加え、最終的な背景はプレゼンテーションテーマ、カラースキーム、マスタースライドやレイアウトスライドに配置された図形に影響されることがあります。

Aspose.Slides for Pythonには、プレゼンテーションスライド全体の背景を画像として抽出するための簡単な方法は提供されていませんが、以下の手順に従うことでこれを実行できます：
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションに複製します。
1. 複製したスライドから図形を削除します。
1. 複製したスライドを画像に変換します。

以下のコード例は、プレゼンテーションスライド全体の背景を画像として抽出します。
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