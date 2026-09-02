---
title: Python でプレゼンテーション シェイプのサムネイルを作成する
linktitle: シェイプサムネイル
type: docs
weight: 70
url: /ja/python-net/create-shape-thumbnails/
keywords:
- シェイプサムネイル
- シェイプ画像
- シェイプのレンダリング
- シェイプレンダリング
- ビジュアル境界
- シェイプ境界
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument スライドから高品質なシェイプサムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートできます。"
---
## **はじめに**

Aspose.Slides for Python via .NET は、各ページがスライドとなるプレゼンテーション ファイルを作成するために使用されます。プレゼンテーション ファイルを開くことで、Microsoft PowerPoint でこれらのスライドを表示できます。ただし、開発者がシェイプの画像を別途画像ビューアで確認したい場合があります。そのようなケースでは、Aspose.Slides がスライドのシェイプ用サムネイル画像を生成できます。本記事ではこの機能の使用方法を説明します。

## **スライドからシェイプのサムネイルを生成する**

特定のオブジェクトだけのプレビューが必要で、スライド全体ではなく個別のシェイプのサムネイルを描画したい場合に利用できます。Aspose.Slides は任意のシェイプを画像としてエクスポートできるため、軽量なプレビューやアイコン、下流処理用アセットの作成が簡単です。

シェイプからサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスでスライドへの参照を取得します。  
3. そのスライド上のシェイプへの参照を取得します。  
4. シェイプのサムネイル画像を描画します。  
5. サムネイル画像を目的の形式で保存します。

以下の例はシェイプのサムネイルを生成します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを開くために Presentation クラスのインスタンスを作成します。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # デフォルトのスケールで画像を作成します。
    with shape.get_image() as thumbnail:
        # PNG 形式で画像をディスクに保存します。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **カスタム倍率でサムネイルを生成する**

このセクションでは、Aspose.Slides でユーザー定義のスケーリング係数を使用してシェイプサムネイルを生成する方法を示します。倍率を制御することで、プレビュー、エクスポート、または高 DPI ディスプレイ向けにサムネイルサイズを細かく調整できます。

スライド上の任意のシェイプのサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスでスライドを取得します。  
3. そのスライド上の対象シェイプを取得します。  
4. 指定した倍率でシェイプのサムネイル画像を描画します。  
5. サムネイル画像を目的の形式で保存します。

以下の例はユーザー定義の倍率でサムネイルを生成します。

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# プレゼンテーションファイルを開くために Presentation クラスのインスタンスを作成します。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 定義されたスケールで画像を作成します。
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # PNG 形式で画像をディスクに保存します。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **シェイプの外観境界を使用してサムネイルを生成する**

このセクションでは、シェイプの外観境界内でサムネイルを生成する方法を示します。すべてのシェイプ効果が考慮され、生成されたサムネイルはスライド境界で制限されます。

シェイプの外観境界内で任意のスライドシェイプのサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスでスライドを取得します。  
3. そのスライド上の対象シェイプを取得します。  
4. 指定した境界でシェイプのサムネイル画像を描画します。  
5. サムネイル画像を目的の画像形式で保存します。

以下の例はユーザー定義の境界でサムネイルを作成します。

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# プレゼンテーションファイルを開くために Presentation クラスのインスタンスを作成します。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 外観境界に基づくシェイプ画像を作成します。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # PNG 形式で画像をディスクに保存します。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **シェイプの実際のビジュアル境界を取得する**

[Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) のフレーム プロパティ（`Shape.x`、`Shape.y`、`Shape.width`、`Shape.height`）は、プレゼンテーション モデルに格納されている矩形を表します。実際に描画されるコンテンツはそのフレームを超えて拡張したり、別の軸揃え矩形を占有したりすることがあります。回転、アウトライン、矢じり、テキスト配置とオーバーフロー、生成された SmartArt のジオメトリ、その他のレンダリング効果が占有領域を変える要因です。

画像を作成せずに占有領域を計算するには、[Shape.get_visual_bounds](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_visual_bounds/) を使用します。このメソッドはスライド座標系の浮動小数点矩形を返します。返された矩形はスライドにクリップされていないため、コンテンツがスライドの原点を超える場合は座標が負になることがあります。

以下の例はフレーム境界とビジュアル境界を取得して比較します。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

同じ矩形を使用して、隣接シェイプを `left`、`right`、`top`、`bottom` エッジに揃えたり、生成レイアウトで十分な余白を確保したり、許可領域外のコンテンツを検出したりできます。ビジュアル境界は特に SmartArt、テキスト ボックス、矢印、画像、回転シェイプ、グループ シェイプで有用です。これらの場合、保存されたフレームが完全な描画結果を表さないことがあります。

レイアウトや検証のために座標が必要でビットマップが不要な場合は [Shape.get_visual_bounds](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_visual_bounds/) を使用します。シェイプを実際に描画したい場合は [Shape.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_image/) を使用します。[ShapeThumbnailBounds](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapethumbnailbounds/) を使用すると、`ShapeThumbnailBounds.SHAPE` はシェイプのジオメトリ（アウトライン設定を含む）から画像サイズを決定し、`ShapeThumbnailBounds.APPEARANCE` はシェイプの外観からサイズを決定してスライド境界で結果を制限します。対照的に、`Shape.get_visual_bounds` は計算された矩形のみを返し、スライドへのクリッピングは行いません。

## **FAQ**

**シェイプのサムネイルを保存する際に使用できる画像形式は何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imageformat/)、その他の形式が利用可能です。シェイプは SVG としてベクトル形式で[エクスポート](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/write_as_svg/)することもできます。

**サムネイルを描画する際の SHAPE 境界と APPEARANCE 境界の違いは何ですか？**

`SHAPE` はシェイプのジオメトリを使用し、`APPEARANCE` は[ビジュアル効果](/slides/ja/python-net/shape-effect/)（影、グローなど）を考慮します。

**シェイプが非表示としてマークされている場合、サムネイルは生成されますか？**

非表示シェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショー表示にのみ影響し、シェイプ画像の生成を妨げません。

**グループ シェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) として表現できるオブジェクト（[GroupShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartart/) を含む）はサムネイルまたは SVG として保存できます。

**システムにインストールされたフォントはテキストシェイプのサムネイル品質に影響しますか？**

はい。不要なフォント置き換えやテキストの再流動を防ぐために、[必要なフォントを提供](/slides/ja/python-net/custom-font/)（または[フォント置換を構成](/slides/ja/python-net/font-substitution/)）する必要があります。