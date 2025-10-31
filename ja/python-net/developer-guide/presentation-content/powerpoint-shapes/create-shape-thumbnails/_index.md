---
title: Pythonでプレゼンテーション形状のサムネイルを作成する
linktitle: 形状サムネイル
type: docs
weight: 70
url: /ja/python-net/create-shape-thumbnails/
keywords:
- 形状サムネイル
- 形状画像
- 形状をレンダリング
- 形状レンダリング
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument スライドから高品質な形状サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートできます。"
---

## **導入**

Aspose.Slides for Python via .NET は、各ページがスライドとなるプレゼンテーション ファイルを作成するために使用されます。プレゼンテーション ファイルを開くことで、Microsoft PowerPoint でこれらのスライドを表示できます。しかし、開発者は画像ビューアで形状の画像を個別に確認したい場合があります。そのようなケースでは、Aspose.Slides がスライド形状のサムネイル画像を生成できます。本記事ではこの機能の使い方を説明します。

## **スライドから形状サムネイルを生成する**

スライド全体ではなく特定のオブジェクトのプレビューが必要なときは、個々の形状のサムネイルをレンダリングできます。Aspose.Slides を使用すると任意の形状を画像としてエクスポートでき、軽量プレビューやアイコン、下流処理用のアセットを簡単に作成できます。

任意の形状からサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. ID またはインデックスでスライドへの参照を取得します。
1. そのスライド上の形状への参照を取得します。
1. 形状のサムネイル画像をレンダリングします。
1. 希望の形式でサムネイル画像を保存します。

以下の例は形状サムネイルを生成します。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成し、プレゼンテーション ファイルを開きます。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # デフォルトのスケールで画像を作成します。
    with shape.get_image() as thumbnail:
        # PNG 形式でディスクに画像を保存します。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **カスタム スケーリング係数でサムネイルを生成する**

このセクションでは、Aspose.Slides でユーザー定義のスケーリング係数を使用して形状サムネイルを生成する方法を示します。スケールを制御することで、プレビュー、エクスポート、または高 DPI ディスプレイに合わせてサムネイルサイズを微調整できます。

スライド上の任意の形状のサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. ID またはインデックスでスライドを取得します。
1. そのスライド上の対象形状を取得します。
1. 指定したスケールで形状のサムネイル画像をレンダリングします。
1. 希望の形式でサムネイル画像を保存します。

以下の例はユーザー定義のスケーリング係数でサムネイルを生成します。

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Presentation クラスのインスタンスを作成し、プレゼンテーション ファイルを開きます。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 定義されたスケールで画像を作成します。
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # PNG 形式でディスクに画像を保存します。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **形状の外観境界を使用してサムネイルを生成する**

このセクションでは、形状の外観境界内でサムネイルを生成する方法を示します。すべての形状エフェクトを考慮し、生成されたサムネイルはスライド境界で制限されます。

外観境界内で任意のスライド形状のサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. ID またはインデックスでスライドを取得します。
1. そのスライド上の対象形状を取得します。
1. 指定した境界で形状のサムネイル画像をレンダリングします。
1. 希望の画像形式でサムネイル画像を保存します。

以下の例はユーザー定義の境界でサムネイルを作成します。

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Presentation クラスのインスタンスを作成し、プレゼンテーション ファイルを開きます。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 外観境界の形状画像を作成します。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # PNG 形式でディスクに画像を保存します。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**形状サムネイルを保存する際に使用できる画像形式は何ですか？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)、その他の形式が使用できます。また、形状の内容を SVG として保存することで、[ベクタ SVG としてエクスポート](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) も可能です。

**サムネイルをレンダリングする際の SHAPE 境界と APPEARANCE 境界の違いは何ですか？**

`SHAPE` は形状のジオメトリを使用します。`APPEARANCE` は[視覚効果](/slides/ja/python-net/shape-effect/)（影、グローなど）を考慮します。

**形状が非表示としてマークされている場合、サムネイルは生成されますか？**

非表示の形状はモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショー表示に影響しますが、形状の画像生成を妨げません。

**グループ形状、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) として表現できるすべてのオブジェクト（[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) を含む）は、サムネイルまたは SVG として保存できます。

**システムにインストールされたフォントはテキスト形状のサムネイル品質に影響しますか？**

はい。不要なフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/python-net/custom-font/)（または[フォント置換を構成](/slides/ja/python-net/font-substitution/)）する必要があります。