---
title: プレゼンテーションからスライド全体の背景を画像として取得
linktitle: スライド全体の背景
type: docs
weight: 95
url: /ja/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド 背景
- 最終 背景
- 背景 抽出
- 全体 背景
- 背景を画像に変換
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションからスライド全体の背景を画像として抽出し、ビジュアル ワークフローを効率化します。"
---
## **概要**

PowerPoint プレゼンテーションでは、スライドの背景はスライド背景画像、プレゼンテーション テーマ、配色スキーム、マスタースライドまたはレイアウトスライドに配置されたオブジェクトなど、複数の要素から構成される場合があります。

この記事では、Aspose.Slides for Python via Java を使用してスライド全体の背景を画像として抽出する方法を示します。このタスクに対する単一のメソッドは存在しないため、選択したスライドを一時的なプレゼンテーションにクローンし、スライドのシェイプを削除した後、結果として得られるスライド背景を画像に変換する手順を取ります。

## **スライド全体の背景を取得**

Aspose.Slides for Python via Java には、プレゼンテーション全体のスライド背景を画像として抽出する単純なメソッドは用意されていませんが、以下の手順で実現できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンしたスライドからシェイプを削除します。
1. クローンしたスライドを画像に変換します。

以下のコード例は、プレゼンテーションのスライド全体の背景を画像として抽出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**マスタースライドからの複雑なグラデーション、テクスチャ、画像フィルが結果の背景画像に保持されますか？**

はい。Aspose.Slides はスライド、レイアウト、またはマスターで定義されたグラデーション、画像、テクスチャのフィルをレンダリングします。継承されたマスターからの外観を分離したい場合は、エクスポート前に現在のスライドに[カスタム背景を設定](/slides/ja/python-java/presentation-background/)してください。

**保存前に結果の背景画像に透かしを追加できますか？**

はい。[透かしを追加](/slides/ja/python-java/watermark/) 形状または画像を作業用の[スライドのコピー](/slides/ja/python-java/clone-slides/)に（他のコンテンツの背面に配置して）追加し、そこからエクスポートできます。これにより、透かしが埋め込まれた背景画像を生成できます。

**既存のスライドに結び付けずに、特定のレイアウトまたはマスターの背景だけを取得できますか？**

はい。目的のマスターまたはレイアウトにアクセスし、必要なサイズの[一時スライド](/slides/ja/python-java/clone-slides/)に適用してエクスポートすれば、そのレイアウトまたはマスターから派生した背景を取得できます。

**画像エクスポートに影響するライセンスの制限はありますか？**

レンダリング機能は[有効なライセンス](/slides/ja/python-java/licensing/) があれば完全に利用可能です。評価モードでは、ウォーターマークなどの制限が出力に含まれる場合があります。バッチエクスポートを実行する前に、プロセスごとに一度ライセンスを有効化してください。