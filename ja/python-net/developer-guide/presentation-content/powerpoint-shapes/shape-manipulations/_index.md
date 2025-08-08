---
title: Python でプレゼンテーションの図形を管理
linktitle: 図形の操作
type: docs
weight: 40
url: /ja/python-net/shape-manipulations/
keywords:
- PowerPoint 図形
- プレゼンテーションの図形
- スライド上の図形
- 図形を検索
- 図形を複製
- 図形を削除
- 図形を非表示
- 図形の順序を変更
- Interop 図形 ID を取得
- 図形の代替テキスト
- 図形のレイアウト形式
- 図形を SVG として
- 図形を SVG に変換
- 図形を整列
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET で図形を作成・編集・最適化する方法を学び、高性能な PowerPoint および OpenDocument のプレゼンテーションを作成して提供します。"
---

## **スライド内の形を見つける**
このトピックでは、開発者が内部 ID を使用せずにスライド上の特定の形を見つけるための簡単なテクニックを説明します。 PowerPoint プレゼンテーションファイルには、内部の一意の ID 以外にスライド上の形を識別する手段はありません。 開発者が内部の一意の ID を使用して形を見つけるのは難しいようです。 スライドに追加されたすべての形には、何らかの代替テキストがあります。 開発者には、特定の形を見つけるために代替テキストを使用することをお勧めします。 将来的に変更する予定のオブジェクトの代替テキストを定義するために MS PowerPoint を使用できます。

任意の形の代替テキストを設定した後、.NET 経由の Aspose.Slides for Python を使用してそのプレゼンテーションを開き、スライドに追加されたすべての形を反復処理できます。 各反復の間に、形の代替テキストを確認し、一致する代替テキストを持つ形が必要な形になります。 このテクニックをより良く示すために、スライド内の特定の形を見つけて単にその形を返すメソッド [FindShape](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) を作成しました。

```py
import aspose.slides as slides

# 代替テキストを使用してスライド内の形を見つけるメソッドの実装
def find_shape(slide, alttext):
    for i in range(len(slide.shapes)):
        if slide.shapes[i].alternative_text == alttext:
            return slide.shapes[i]
    return None
    
# プレゼンテーションファイルを表す Presentation クラスをインスタンス化
with slides.Presentation(path + "FindingShapeInSlide.pptx") as p:
    slide = p.slides[0]
    # 見つけるべき形の代替テキスト
    shape = find_shape(slide, "Shape1")
    if shape != None:
        print("形の名前: " + shape.name)
```



## **形を複製する**
.NET 経由の Aspose.Slides for Python を使用してスライドに形を複製するには:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソーススライドの形コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソーススライドの形コレクションから新しいスライドに形を複製します。
1. 修正されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ形を追加します。

```py
import aspose.slides as slides

# Presentation クラスをインスタンス化
with slides.Presentation(path + "Source Frame.pptx") as srcPres:
	sourceShapes = srcPres.slides[0].shapes
	blankLayout = srcPres.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
	destSlide = srcPres.slides.add_empty_slide(blankLayout)
	destShapes = destSlide.shapes
	destShapes.add_clone(sourceShapes[1], 50, 150 + sourceShapes[0].height)
	destShapes.add_clone(sourceShapes[2])                 
	destShapes.insert_clone(0, sourceShapes[0], 50, 150)

	# PPTX ファイルをディスクに書き込む
	srcPres.save("CloneShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **形を削除する**
.NET 経由の Aspose.Slides for Python によって開発者は任意の形を削除することができます。 どのスライドから形を削除するには、以下の手順に従ってください:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つ形を見つけます。
1. 形を削除します。
1. ファイルをディスクに保存します。

```py
import aspose.slides as slides

# Presentation オブジェクトを作成する
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形タイプのオートシェイプを追加
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "ユーザー定義"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[0]
        if ashp.alternative_text == alttext:
            sld.shapes.remove(ashp)

    # プレゼンテーションをディスクに保存
    pres.save("RemoveShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **形を隠す**
.NET 経由の Aspose.Slides for Python によって開発者は任意の形を隠すことができます。 どのスライドから形を隠すには、以下の手順に従ってください:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つ形を見つけます。
1. 形を隠します。
1. ファイルをディスクに保存します。

```py
import aspose.slides as slides

# PPTX を表す Presentation クラスをインスタンス化
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形タイプのオートシェイプを追加
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "ユーザー定義"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[i]
        if ashp.alternative_text == alttext:
            ashp.hidden = True

    # プレゼンテーションをディスクに保存
    pres.save("Hiding_Shapes_out.pptx", slides.export.SaveFormat.PPTX)
```



## **形の順序を変更する**
.NET 経由の Aspose.Slides for Python によって開発者は形の順序を再配置することができます。 形の順序を変更することで、どの形が前面または背面にあるかを指定します。 どのスライドで形を再配置するには、以下の手順に従ってください:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 形を追加します。
1. 形のテキストフレームにいくつかのテキストを追加します。
1. 同じ座標を持つ別の形を追加します。
1. 形の順序を変更します。
1. ファイルをディスクに保存します。

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation1:
    slide = presentation1.slides[0]
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 365, 400, 150)
    shp3.fill_format.fill_type = slides.FillType.NO_FILL
    shp3.add_text_frame(" ")

    txtFrame = shp3.text_frame
    para = txtFrame.paragraphs[0]
    portion = para.portions[0]
    portion.text="ウォーターマーク テキスト ウォーターマーク テキスト ウォーターマーク テキスト"
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 200, 365, 400, 150)
    slide.shapes.reorder(2, shp3)
    presentation1.save( "Reshape_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Interop 形 ID を取得する**
.NET 経由の Aspose.Slides for Python によって開発者は、UniqueId プロパティに対してスライドスコープでユニークな形識別子を取得できます。これは、プレゼンテーションスコープでユニークな識別子を取得するためのものです。 OfficeInteropShapeId プロパティは、IShape インターフェースおよび Shape クラスに追加されました。 OfficeInteropShapeId プロパティによって返される値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。 以下にサンプルコードを示します。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation.pptx") as presentation:
    # スライドスコープ内のユニーク形識別子を取得
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```



## **形の代替テキストを設定する**
.NET 経由の Aspose.Slides for Python によって開発者は任意の形の AlternateText を設定することができます。
プレゼンテーション内の形は、AlternativeText または Shape Name プロパティによって区別することができます。
代替テキストプロパティは、Aspose.Slides および Microsoft PowerPoint を使用して読み取ったり設定したりできます。
このプロパティを使用することで、形にタグを付けて、形を削除、形を隠す、またはスライド上の形を再配置するなど、さまざまな操作を実行できます。
形の代替テキストを設定するには、以下の手順に従ってください:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに任意の形を追加します。
1. 新しく追加された形に対して何か処理を行います。
1. 形を見つけるために形を反復処理します。
1. 代替テキストを設定します。
1. ファイルをディスクに保存します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX を表す Presentation クラスをインスタンス化
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形タイプのオートシェイプを追加
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.gray

    for i in range(len(sld.shapes)):
        shape = sld.shapes[i]
        if shape != None:
            shape.alternative_text = "ユーザー定義"

    # プレゼンテーションをディスクに保存
    pres.save("Set_AlternativeText_out.pptx", slides.export.SaveFormat.PPTX)
```




## **形のレイアウトフォーマットにアクセスする**
.NET 経由の Aspose.Slides for Python は、形のレイアウトフォーマットにアクセスするためのシンプルな API を提供します。この記事では、どのようにしてレイアウトフォーマットにアクセスできるかを示します。

以下にサンプルコードを示します。

```py
import aspose.slides as slides

with slides.Presentation("Set_AlternativeText_out.pptx") as pres:
    for layoutSlide in pres.layout_slides:
        fillFormats = list(map(lambda shape: shape.fill_format, layoutSlide.shapes))
        lineFormats = list(map(lambda shape: shape.line_format, layoutSlide.shapes))
```

## **形を SVG としてレンダリングする**
現在、.NET 経由の Aspose.Slides for Python には、形を svg としてレンダリングするサポートがあります。 WriteAsSvg メソッド（およびそのオーバーロード）が Shape クラスおよび IShape インターフェースに追加されました。このメソッドを使用することで、形のコンテンツを SVG ファイルとして保存できます。 以下のコードスニペットは、スライドの形を SVG ファイルにエクスポートする方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with open("SingleShape.svg", "wb") as stream:
        pres.slides[0].shapes[0].write_as_svg(stream)
```

## 形を整列する

[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) オーバーロードメソッドを通じて、形を

* スライドのマージンに対して整列させることができます。例 1 を参照してください。 
* 互いに対して整列させることができます。例 2 を参照してください。 

[ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) 列挙型は、利用可能な整列オプションを定義します。

### 例 1

この Python コードは、スライドの上部境界線に沿ってインデックス 1、2、および 4 の形を整列させる方法を示しています。
以下のソースコードは、スライドの上部境界線に沿ってインデックス 1、2、および 4 の形を整列させます。

```py
import aspose.slides as slides

with slides.Presentation("OutputPresentation.pptx") as pres:
     slide = pres.slides[0]
     shape1 = slide.shapes[1]
     shape2 = slide.shapes[2]
     shape3 = slide.shapes[4]
     slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, pres.slides[0], [
            slide.shapes.index_of(shape1),
            slide.shapes.index_of(shape2),
            slide.shapes.index_of(shape3)])
```

### 例 2

この Python コードは、コレクション内の底の形に対して、形のコレクション全体を整列させる方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("example.pptx") as pres:
    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_BOTTOM, False, pres.slides[0].shapes)
```