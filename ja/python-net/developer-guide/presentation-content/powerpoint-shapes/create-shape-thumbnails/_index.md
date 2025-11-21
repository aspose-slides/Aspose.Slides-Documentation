---
title: Pythonでプレゼンテーション形状のサムネイルを作成
linktitle: 形状サムネイル
type: docs
weight: 70
url: /ja/python-net/create-shape-thumbnails/
keywords:
- 形状サムネイル
- 形状画像
- 形状のレンダリング
- 形状レンダリング
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument スライドから高品質な形状サムネイルを生成し、簡単にプレゼンテーションのサムネイルを作成・エクスポートできます。"
---

## **導入**

Aspose.Slides for Python via .NET は、各ページがスライドとなるプレゼンテーション ファイルを作成するために使用されます。プレゼンテーション ファイルを開くことで、Microsoft PowerPoint でこれらのスライドを表示できます。ただし、開発者が形状の画像を別々に画像ビューアで確認したい場合があります。そのようなケースでは、Aspose.Slides がスライド形状のサムネイル画像を生成できます。本記事では、この機能の使用方法を説明します。

## **スライドから形状サムネイルを生成する**

スライド全体ではなく、特定のオブジェクトのプレビューが必要なときは、個々の形状のサムネイルをレンダリングできます。Aspose.Slides は任意の形状を画像としてエクスポートできるため、軽量プレビューやアイコン、下流処理用のアセット作成が容易です。

任意の形状からサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. ID またはインデックスでスライドへの参照を取得します。
1. そのスライド上の形状への参照を取得します。
1. 形状のサムネイル画像をレンダリングします。
1. サムネイル画像を希望のフォーマットで保存します。

以下の例は形状サムネイルを生成します。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを開くために Presentation クラスのインスタンスを作成します。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # デフォルトのスケールで画像を作成します。
    with shape.get_image() as thumbnail:
        # PNG 形式で画像をディスクに保存します。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```


## **カスタム拡大縮小率でサムネイルを生成する**

このセクションでは、Aspose.Slides でユーザー定義の拡大縮小率を使用して形状サムネイルを生成する方法を示します。スケールを制御することで、プレビューやエクスポート、高 DPI ディスプレイに最適なサムネイルサイズを微調整できます。

スライド上の任意の形状のサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. ID またはインデックスでスライドを取得します。
1. そのスライド上の対象形状を取得します。
1. 指定した拡大縮小率で形状のサムネイル画像をレンダリングします。
1. サムネイル画像を希望のフォーマットで保存します。

以下の例はユーザー定義の拡大縮小率でサムネイルを生成します。
```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# プレゼンテーション ファイルを開くために Presentation クラスのインスタンスを作成します。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 定義されたスケールで画像を作成します。
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # PNG 形式で画像をディスクに保存します。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```


## **形状の表示境界を使用してサムネイルを生成する**

このセクションでは、形状の表示境界内でサムネイルを生成する方法を示します。すべての形状エフェクトを考慮し、生成されたサムネイルはスライド境界で制限されます。

表示境界内で任意のスライド形状のサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. ID またはインデックスでスライドを取得します。
1. そのスライド上の対象形状を取得します。
1. 指定した境界で形状のサムネイル画像をレンダリングします。
1. サムネイル画像を希望の画像フォーマットで保存します。

以下の例はユーザー定義の境界でサムネイルを作成します。
```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# プレゼンテーション ファイルを開くために Presentation クラスのインスタンスを作成します。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 表示境界で形状画像を作成します。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # PNG 形式で画像をディスクに保存します。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```


## **FAQ**

**形状サムネイルの保存に使用できる画像フォーマットは何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) など。形状は [SVG 形式でベクタとしてエクスポート](/slides/ja/python-net/shape/write_as_svg/) することもできます。

**サムネイルをレンダリングする際の SHAPE 境界と APPEARANCE 境界の違いは何ですか？**

`SHAPE` は形状のジオメトリを使用し、`APPEARANCE` は [視覚エフェクト](/slides/ja/python-net/shape-effect/)（影、光彩など）を考慮します。

**形状が非表示としてマークされている場合、サムネイルは生成されますか？**

非表示の形状はモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショー表示に影響しますが、形状画像の生成を妨げません。

**グループ形状、チャート、SmartArt、その他の複合オブジェクトはサポートされていますか？**

はい。`Shape` として表現できるすべてのオブジェクト（`GroupShape`、`Chart`、`SmartArt` など）をサムネイルまたは SVG として保存できます。

**システムにインストールされたフォントはテキスト形状のサムネイル品質に影響しますか？**

はい。不要なフォント置き換えやテキストの再フローを防ぐために、[必要なフォントを提供](/slides/ja/python-net/custom-font/)（または [フォント置換を構成](/slides/ja/python-net/font-substitution/)）する必要があります。