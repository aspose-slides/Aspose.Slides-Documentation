---
title: Python でプレゼンテーション シェイプのサムネイルを作成する
linktitle: シェイプ サムネイル
type: docs
weight: 70
url: /ja/python-net/create-shape-thumbnails/
keywords:
- シェイプ サムネイル
- シェイプ 画像
- シェイプ レンダリング
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument スライドから高品質なシェイプ サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成・エクスポートできます。"
---

## **概要**

Aspose.Slides for Python via .NET は、各ページがスライドとなるプレゼンテーション ファイルを作成するために使用されます。プレゼンテーション ファイルを開くことで、Microsoft PowerPoint でこれらのスライドを表示できます。ただし、開発者がシェイプの画像を画像ビューアで個別に確認したい場合があります。そのようなケースでは、Aspose.Slides がスライド シェイプのサムネイル画像を生成できます。本記事ではこの機能の使い方を解説します。

## **スライドからシェイプ サムネイルを生成する**

スライド全体ではなく特定のオブジェクトのプレビューが必要な場合、個々のシェイプのサムネイルをレンダリングできます。Aspose.Slides を使用すれば、任意のシェイプを画像としてエクスポートでき、軽量なプレビューやアイコン、下流処理用アセットの作成が容易になります。

任意のシェイプからサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスでスライドへの参照を取得します。  
3. そのスライド上のシェイプへの参照を取得します。  
4. シェイプのサムネイル画像をレンダリングします。  
5. 必要な形式でサムネイル画像を保存します。

以下の例はシェイプ サムネイルを生成します。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成してプレゼンテーション ファイルを開きます。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # デフォルトのスケールで画像を作成します。
    with shape.get_image() as thumbnail:
        # PNG 形式でディスクに画像を保存します。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **カスタム スケーリング係数でサムネイルを生成する**

このセクションでは、Aspose.Slides でユーザー定義のスケーリング係数を使用してシェイプ サムネイルを生成する方法を示します。スケールを制御することで、プレビュー、エクスポート、または高 DPI ディスプレイに合わせたサムネイル サイズを微調整できます。

スライド上の任意のシェイプのサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスでスライドを取得します。  
3. そのスライド上の対象シェイプを取得します。  
4. 指定したスケールでシェイプのサムネイル画像をレンダリングします。  
5. 必要な形式でサムネイル画像を保存します。

以下の例はユーザー定義のスケーリング係数でサムネイルを生成します。

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Presentation クラスのインスタンスを作成してプレゼンテーション ファイルを開きます。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 定義したスケールで画像を作成します。
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # PNG 形式でディスクに画像を保存します。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **シェイプの外観境界を使用してサムネイルを生成する**

このセクションでは、シェイプの外観境界内でサムネイルを生成する方法を示します。シェイプに適用されたすべてのエフェクトが考慮され、生成されたサムネイルはスライドの境界に制限されます。

外観境界内の任意のスライド シェイプのサムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスでスライドを取得します。  
3. そのスライド上の対象シェイプを取得します。  
4. 指定した境界でシェイプのサムネイル画像をレンダリングします。  
5. 必要な画像形式でサムネイルを保存します。

以下の例はユーザー定義の境界でサムネイルを作成します。

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Presentation クラスのインスタンスを作成してプレゼンテーション ファイルを開きます。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 外観境界を使用したシェイプ画像を作成します。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # PNG 形式でディスクに画像を保存します。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**シェイプ サムネイルの保存に使用できる画像形式は何ですか？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) など。シェイプは [SVG 形式のベクターとしてエクスポート](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) することもできます。

**サムネイルをレンダリングする際の SHAPE と APPEARANCE 境界の違いは何ですか？**

`SHAPE` はシェイプのジオメトリを使用し、`APPEARANCE` は [ビジュアル エフェクト](/slides/ja/python-net/shape-effect/)（影、光彩など）を考慮します。

**シェイプが非表示としてマークされている場合、サムネイルは生成されますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショー表示にのみ影響し、シェイプの画像生成を妨げません。

**グループ シェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) として表現されるすべてのオブジェクト（[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) など）はサムネイルや SVG として保存できます。

**システムにインストールされたフォントはテキスト シェイプのサムネイル品質に影響しますか？**

はい。不要なフォント代替やテキストの折り返しを防ぐために、[必要なフォントを提供](/slides/ja/python-net/custom-font/)（または [フォント置換を構成](/slides/ja/python-net/font-substitution/)）する必要があります。