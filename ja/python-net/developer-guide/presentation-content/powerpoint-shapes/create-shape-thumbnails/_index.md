---
title: Pythonでプレゼンテーションシェイプのサムネイルを作成
linktitle: シェイプ サムネイル
type: docs
weight: 70
url: /ja/python-net/create-shape-thumbnails/
keywords:
- シェイプ サムネイル
- シェイプ 画像
- シェイプ をレンダリング
- シェイプ レンダリング
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument スライドから高品質なシェイプサムネイルを生成し、簡単にプレゼンテーションのサムネイルを作成およびエクスポートできます。"
---

## **はじめに**

Aspose.Slides for Python via .NET は、各ページがスライドであるプレゼンテーション ファイルを作成するために使用されます。プレゼンテーション ファイルを開くことで、Microsoft PowerPoint でこれらのスライドを表示できます。ただし、開発者がシェイプの画像を別々に画像ビューアで確認したい場合があります。そのようなケースでは、Aspose.Slides がスライド シェイプのサムネイル画像を生成できます。本記事ではこの機能の使用方法を説明します。

## **スライドからシェイプのサムネイルを生成**

スライド全体ではなく特定のオブジェクトのプレビューが必要なときは、個別のシェイプのサムネイルをレンダリングできます。Aspose.Slides を使えば、任意のシェイプを画像としてエクスポートでき、軽量なプレビューやアイコン、下流処理用のアセットを簡単に作成できます。

シェイプからサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスでスライドへの参照を取得します。  
3. そのスライド上のシェイプへの参照を取得します。  
4. シェイプのサムネイル画像をレンダリングします。  
5. サムネイル画像を希望の形式で保存します。

以下の例はシェイプのサムネイルを生成します。

```py
import aspose.slides as slides

# Presentation クラスをインスタンス化してプレゼンテーション ファイルを開く。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # デフォルトのスケールで画像を作成。
    with shape.get_image() as thumbnail:
        # PNG 形式でディスクに保存。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **カスタムスケーリング係数でサムネイルを生成**

このセクションでは、Aspose.Slides でユーザー定義のスケーリング係数を使用してシェイプ サムネイルを生成する方法を示します。スケールを制御することで、プレビュー、エクスポート、または高 DPI ディスプレイ向けにサムネイルサイズを微調整できます。

スライド上の任意のシェイプのサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスでスライドを取得します。  
3. そのスライド上の対象シェイプを取得します。  
4. 指定したスケールでシェイプのサムネイル画像をレンダリングします。  
5. サムネイル画像を希望の形式で保存します。

以下の例はユーザー定義のスケーリング係数でサムネイルを生成します。

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Presentation クラスをインスタンス化してプレゼンテーション ファイルを開く。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 定義したスケールで画像を作成。
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # PNG 形式でディスクに保存。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **シェイプの外観境界を使用してサムネイルを生成**

このセクションでは、シェイプの外観境界内でサムネイルを生成する方法を示します。すべてのシェイプ効果が考慮され、生成されたサムネイルはスライド境界で制限されます。

外観境界内で任意のスライド シェイプのサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスでスライドを取得します。  
3. そのスライド上の対象シェイプを取得します。  
4. 指定した境界でシェイプのサムネイル画像をレンダリングします。  
5. 希望の画像形式でサムネイル画像を保存します。

以下の例はユーザー定義の境界でサムネイルを作成します。

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Presentation クラスをインスタンス化してプレゼンテーション ファイルを開く。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 外観境界でシェイプ画像を作成。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # PNG 形式でディスクに保存。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**シェイプ サムネイルを保存する際に使用できる画像形式は何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) など。他にも、シェイプのコンテンツを SVG として保存することで、シェイプをベクタ形式の SVG に**エクスポート**することもできます（[SVG として書き出す](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)）。

**サムネイルをレンダリングする際の SHAPE と APPEARANCE の境界の違いは何ですか？**

`SHAPE` はシェイプのジオメトリを使用し、`APPEARANCE` は[ビジュアル エフェクト](/slides/ja/python-net/shape-effect/)（影や光彩など）を考慮します。

**シェイプが非表示にマークされていた場合、サムネイルは生成されますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショー表示に影響しますが、シェイプ画像の生成を妨げません。

**グループ シェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) として表現できるオブジェクト（[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) を含む）は、サムネイルまたは SVG として保存可能です。

**システムにインストールされたフォントは、テキスト シェイプのサムネイル品質に影響しますか？**

はい。不要なフォント代替やテキストのレイアウト崩れを防ぐために、[必要なフォントを提供](/slides/ja/python-net/custom-font/)（または[フォント置換を構成](/slides/ja/python-net/font-substitution/)）する必要があります。