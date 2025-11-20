---
title: Python を使用したプレゼンテーションでの図形管理
linktitle: 図形操作
type: docs
weight: 40
url: /ja/python-net/shape-manipulations/
keywords:
- PowerPoint の図形
- プレゼンテーションの図形
- スライド上の図形
- 図形の検索
- 図形のクローン
- 図形の削除
- 図形の非表示
- 図形の順序変更
- Interop 図形 ID の取得
- 図形の代替テキスト
- 図形のレイアウト書式
- SVG としての図形
- 図形を SVG に変換
- 図形の整列
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して図形を作成、編集、最適化し、高速な PowerPoint と OpenDocument プレゼンテーションを提供する方法を学びます。"
---

## **概要**

このガイドでは、.NET を介した Python 用 Aspose.Slides の図形操作について紹介します。代替テキストによる検索を含む図形の検索、複製、削除または非表示、再配置、整列とフリップ、ID の取得やレイアウト主導の書式設定、そして個別の図形を SVG にエクスポートする方法を、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) と [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) API を使用して学びます。

## **スライド上の図形を検索**

PowerPoint は内部 ID のみで図形を識別します。PowerPoint で対象の図形に一意の Alt Text を設定し、Aspose.Slides for Python でプレゼンテーションを開き、スライドの図形を反復処理して Alt Text が一致するものを選択します。`find_shape` メソッドはこのアプローチを実装し、一致する図形を返します。
```py
import aspose.slides as slides

# スライド上の図形を代替テキストで検索します。
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Text "Shape1" の図形を検索します。
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```


## **図形のクローン作成**

Aspose.Slides でソーススライドから新しいスライドへ図形をクローンするには、次の手順に従います。

1. ソースファイルから [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成します。
1. インデックスでソーススライドを取得し、その図形コレクションを取得します。
1. マスタースライドから空白のレイアウトを取得します。
1. そのレイアウトを使用して空のスライドを追加し、その図形を取得します。
1. 図形を対象スライドにクローンします。
1. プレゼンテーションを PPTX として保存します。

以下のコード例は、あるスライドから別のスライドへ図形をクローンします。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **図形の削除**

Aspose.Slides を使用すると、スライドから任意の図形を削除できます。たとえば、最初のスライドの図形を代替テキストで削除するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成し、ファイルをロードします。
1. スライドコレクションから最初のスライドにアクセスします。
1. 代替テキストの値で図形を検索します。
1. スライドの図形コレクションから図形を削除します。
1. プレゼンテーションを PPTX 形式でディスクに保存します。
```py
import aspose.slides as slides

# スライド上の図形を代替テキストで検索します。
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Text "User Defined" の図形を検索します。
    shape = find_shape(slide, "User Defined")
    # 図形を削除します。
    slide.shapes.remove(shape)
    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **図形の非表示**

Aspose.Slides を使用すると、スライド上の任意の図形を非表示にできます。たとえば、最初のスライドの図形を代替テキストで非表示にするには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成し、ファイルをロードします。
1. スライドコレクションから最初のスライドにアクセスします。
1. 代替テキストの値で図形を検索します。
1. 図形を非表示にします。
1. プレゼンテーションを PPTX 形式でディスクに保存します。
```py
# スライド上の図形を代替テキストで検索します。
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Text "User Defined" の図形を検索します。
    shape = find_shape(slide, "User Defined")
    # 図形を非表示にします。
    shape.hidden = True
    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **図形の順序変更**

Aspose.Slides では、開発者が図形の順序（z オーダー）を変更できます。順序変更により、どの図形が前面または背面に表示されるかが決まります。たとえば、最初のスライドで 2 つの図形の順序を変更するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 最初の図形を追加します（例: 四角形）。
1. 2 番目の図形を追加します（例: 三角形）。
1. コレクション内で 2 番目の図形を最初の位置に移動して図形の順序を変更します。
1. プレゼンテーションをディスクに保存します。
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # スライドに 2 つの図形を追加します。
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # 2 番目の図形を先頭に移動します。
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Interop 図形 ID の取得**

Aspose.Slides では、プレゼンテーション全体で一意である `unique_id` プロパティとは異なり、スライド単位で図形のユニーク識別子を取得できます。`office_interop_shape_id` プロパティは [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスで利用可能です。その値は `Microsoft.Office.Interop.PowerPoint.Shape` オブジェクトの `Id` に対応します。以下にサンプルコードを示します。
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # スライド内の図形のユニーク識別子を取得します。
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```


## **図形の代替テキスト設定**

Aspose.Slides では、任意の図形に代替テキストを設定できます。代替テキストを使用して、プレゼンテーション内の図形を識別および検索できます。代替テキストプロパティは Aspose.Slides と Microsoft PowerPoint の両方で読み書き可能です。このプロパティで図形にタグ付けすることで、後でスライド上で削除、非表示、順序変更が可能です。

図形の代替テキストを設定するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに図形を追加します。
1. 代替テキストを設定します。
1. プレゼンテーションをディスクに保存します。
```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # 図形を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # 図形の代替テキストを設定します。
    shape.alternative_text = "User Defined"
    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **図形のレイアウト書式へのアクセス**

Aspose.Slides は図形のレイアウト書式にアクセスするシンプルな API を提供します。このセクションではレイアウト書式へのアクセス方法を示します。
```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```


## **図形を SVG としてレンダリング**

Aspose.Slides は図形を SVG としてレンダリングすることをサポートします。[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスの `write_as_svg` メソッド（およびそのオーバーロード）を使用すると、図形の内容を SVG 画像として保存できます。以下のコードスニペットは、図形を SVG ファイルにエクスポートする方法を示します。
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # 最初のスライドの最初の図形を取得します。
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```


## **図形の整列**

[SlidesUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) クラスの `align_shape` メソッドを使用すると、以下が可能です。

* スライドの余白に対して図形を整列させる（例 1 を参照）。
* 図形同士を相対的に整列させる（例 2 を参照）。

[ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) 列挙体は、利用可能な整列オプションを定義します。

**例 1**

この Python コードは、インデックス 1、2、4 の図形をスライドの上端に整列させる方法を示しています。
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```


**例 2**

この Python の例は、コレクション内のすべての図形を、その中で最下位の図形に対して相対的に整列させる方法を示しています。
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```


## **フリップ プロパティ**

Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) クラスが `flip_h` および `flip_v` プロパティを介して図形の水平・垂直ミラーリングを制御します。これらのプロパティはすべて [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 型で、`TRUE` はフリップ、`FALSE` はフリップなし、`NOT_DEFINED` はデフォルト動作を使用することを示します。これらの値は図形の [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) から取得できます。

フリップ設定を変更するには、図形の現在の位置とサイズ、希望する `flip_h` と `flip_v` の値、回転角度を指定して新しい [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) インスタンスを構築します。このインスタンスを図形の [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) に割り当て、プレゼンテーションを保存することで、ミラー変換が適用され、出力ファイルに反映されます。

たとえば、sample.pptx ファイルの最初のスライドにデフォルトのフリップ設定の単一図形が含まれているとします。下記をご覧ください。

![フリップ対象の図形](shape_to_be_flipped.png)

以下のコード例は、図形の現在のフリッププロパティを取得し、水平および垂直にフリップします。
```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # 図形の水平フリッププロパティを取得します。
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # 図形の垂直フリッププロパティを取得します。
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # 水平および垂直にフリップします。
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![フリップされた図形](flipped_shape.png)

## **FAQ**

**スライド上でデスクトップエディタのように図形を結合（union/intersect/subtract）できますか？**

組み込みのブール演算 API はありません。自身で目的の輪郭を作成することで近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しい図形を作成し、必要に応じて元の図形を削除します。

**図形が常に「最上位」に表示されるように、スタック順序（z-order）を制御するにはどうすればよいですか？**

スライドの [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) コレクション内で挿入/移動順序を変更します。予測可能な結果を得るには、他のすべてのスライド変更が完了した後に z-order を確定してください。

**PowerPoint でユーザーが編集できないように図形を「ロック」できますか？**

はい。[shape-level protection flags](/slides/ja/python-net/applying-protection-to-presentation/)（例：選択ロック、移動ロック、サイズ変更ロック、テキスト編集ロック）を設定します。必要に応じて、マスターやレイアウトにも同様の制限を適用できます。これは UI レベルの保護であり、セキュリティ機能ではないことに注意してください。より強固な保護が必要な場合は、[読み取り専用推奨やパスワード](/slides/ja/python-net/password-protected-presentation/) などのファイルレベルの制限と組み合わせてください。